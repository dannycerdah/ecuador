Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class UserManager
    Public Shared Function CheckUserCode(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Try
            req.myUser.CheckUserExists(req.myUser)
            req.myUser.CheckUserStatus(req.myUser)
            If req.myUser.UserExists Then
                req.myUser.LoadData()
            End If
            If Not req.myUser.UserExists Then
                req.myUser.errorString = req.myUser.errorString & "El usuario no existe en la base de datos"
                Throw New Exception("Usuario Inválido")
            ElseIf Not req.myUser.isUserAvailability Then
                req.myUser.errorString = req.myUser.errorString & "El usuario no esta disponible" & " El usuario es " & req.myUser.idUsuario & " cuya Identificación es " & req.myUser.idContacto
                Throw New Exception("Usuario no autorizado")
            End If
            result.myUser = req.myUser
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function GetUserbyCode(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Try
            result.myUser = req.myUser
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function SaveUser(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Try
            'req.myUser.SaveInDb()
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function UpdateUserPassword(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Try
            If ValidateSession(req) Then
                'req.myUser.UpdateUserPassword()
            End If
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function



    Public Shared Function LogIn(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Dim userCode As String = String.Empty
        Dim password As String = String.Empty
        Dim objUser As New User
        Try
            userCode = req.myUser.idUsuario
            password = req.myUser.password
            objUser.idUsuario = userCode
            objUser.GetUserPassword()
            If objUser.idUsuario = userCode Then
                If objUser.password.Equals(password) Then 'Ingreso correcto
                    objUser.estado = "1"
                    If objUser.userAdmin = "T" Then
                        objUser.isAdmin = True
                    End If
                    objUser.GetPermisosPerfil() 'MARZ
                Else
                    objUser.estado = "0"
                End If
            End If
            result.myUser = objUser
        Catch ex As UserNotFoundException
            result.myUser = objUser
            result.myUser.estado = "0"
        Catch ex As Exception
            result.ErrorCode = 100
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function LogOut(ByVal req As UserRequest) As Boolean
        Dim result As Boolean = False
        Dim dbsec As Database
        Try
            dbsec = DatabaseFactory.CreateDatabase("")
            dbsec.ExecuteNonQuery("", req.SessionKey)
        Catch ex As Exception
            SetLogEvent(ex, New UserResponse, req)
        End Try
        Return result
    End Function

    'MARZ
    Public Shared Function GetConfiguraciones(ByVal req As UserRequest) As UserResponse
        Dim result As New UserResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myConf As New ConfigurationItem
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .CommandText = "obtenerConfiguraciones"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader() 'Lee registro
            If drReader.Read Then
                With myConf
                    .userEcuapass = drReader.GetValue(drReader.GetOrdinal("userEcuapass"))
                    .passwordEcuapass = drReader.GetValue(drReader.GetOrdinal("passwordEcuapass"))
                    .keyEcuapass = drReader.GetValue(drReader.GetOrdinal("keyEcuapass"))
                    .tiempoMarcaciones = drReader.GetValue(drReader.GetOrdinal("tiempoMarcaciones"))
                    .margenBriefing = drReader.GetValue(drReader.GetOrdinal("margenBriefing"))
                End With
                result.myConfiguraciones = myConf
            End If
            cmd.Connection.Close()
            drReader.Close()
        Catch ex As Exception
            SetLogEvent(ex, result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return result
    End Function

    'MARZ
    Public Shared Function SaveConfigEcuapass(req As UserRequest) As UserResponse
        Dim Result As New UserResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Ecuapass As Object()
        Try
            If ValidateSession(req) Then
                With req.myConfiguraciones
                    Ecuapass = New Object() {.userEcuapass, .passwordEcuapass, .keyEcuapass}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("userEcuapass", Ecuapass(0))
                    .Parameters.AddWithValue("passwordEcuapass", Ecuapass(1))
                    .Parameters.AddWithValue("keyEcuapass", Ecuapass(2))
                    .CommandText = "modificarEcuapass"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_31.08.17
    Public Shared Function SaveConfigurations(req As UserRequest) As UserResponse
        Dim Result As New UserResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Configurations As Object()
        Try
            If ValidateSession(req) Then
                With req.myConfiguraciones
                    Configurations = New Object() {.tiempoMarcaciones, .margenBriefing}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("tiempo", Configurations(0))
                    .Parameters.AddWithValue("margen", Configurations(1))
                    .CommandText = "modificarConfiguraciones"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    'jro 01022020
    Public Shared Function SaveBitacoraPermiso(req As UserRequest) As UserResponse
        Dim Result As New UserResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Configurations As Object()
        Try
            If ValidateSession(req) Then
                With req.myUser
                    Configurations = New Object() {.estado, .userName, .userAdmin, .errorString}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("P_Proceso", Configurations(0))
                    .Parameters.AddWithValue("P_Usuario_Produccion", Configurations(1))
                    .Parameters.AddWithValue("P_Usuario_Supervisor", Configurations(2))
                    .Parameters.AddWithValue("P_Observacion", Configurations(3))
                    .CommandText = "Sp_BitacoraPermisos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
