Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class User
    Public Property idUsuario As String
    Public Property estado As String
    Public Property UserExists As Boolean
    Public Property isUserAdmin As Boolean
    Public Property idContacto As String
    Public Property userName As String
    Public Property isAdmin As Boolean
    Public Property password As String
    Public Property isUserAvailability As Boolean
    Public Property userAdmin As String
    Public Property errorString As String
    Public Property myPermisos As New List(Of String) 'MARZ

    Public Sub CheckUserExists(user As User)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("idUsuario", user.idUsuario)
                .CommandText = "CheckExistsUsuario"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                If CBool(cmd.ExecuteScalar) Then
                    estado = "A"
                Else
                    estado = "I"
                End If
            End With
        Catch ex As Exception
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub

    Public Sub CheckUserStatus(user As User)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("idUsuario", user.idUsuario)
                .CommandText = "CheckEstadoUsuario"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                If CBool(cmd.ExecuteScalar) Then
                    UserExists = True
                Else
                    UserExists = False
                End If
            End With
        Catch ex As Exception
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub

    Public Sub LoadData()
        If UserExists Then
            Dim dbTran As Database
            Dim cmd As New MySqlCommand
            Dim drReader As MySqlDataReader
            Try
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idUsuario", idUsuario)
                    .CommandText = "obtenerUsuarioPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    idUsuario = drReader.GetValue(drReader.GetOrdinal("idUsuario"))
                    idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                    password = drReader.GetValue(drReader.GetOrdinal("password"))
                    estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    isAdmin = drReader.GetValue(drReader.GetOrdinal("admin"))
                End If
                If Not drReader.IsClosed Then drReader.Close()
            Catch ex As Exception
                If Not drReader.IsClosed Then drReader.Close() 'Cerrar
                If cmd.Connection IsNot Nothing Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                End If
            Finally
                If Not drReader.IsClosed Then drReader.Close() 'Cerrar
                If cmd.Connection IsNot Nothing Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                End If
            End Try
        Else
            Throw New Exception("Usuario no Autorizado")
        End If
    End Sub

    Public Sub GetInfoUserbyId()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("idUsuario", idUsuario)
                .CommandText = "obtenerUsuarioPorId"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader()
            If drReader.Read Then
                idUsuario = drReader.GetValue(drReader.GetOrdinal("idUsuario"))
                idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                isAdmin = drReader.GetValue(drReader.GetOrdinal("admin"))
                userName = idUsuario
            End If
            If Not drReader.IsClosed Then drReader.Close()
        Catch ex As Exception
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try



    End Sub

    Friend Sub GetUserPassword()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("usuario", idUsuario)
                .CommandText = "obtenerClaveUsuario"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader()
            If drReader.Read Then
                idUsuario = drReader.GetValue(drReader.GetOrdinal("idUsuario"))
                idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                password = drReader.GetValue(drReader.GetOrdinal("password"))
                userAdmin = drReader.GetValue(drReader.GetOrdinal("admin"))
            Else
                Throw New UserNotFoundException
            End If
            cmd.Connection.Close()
            drReader.Close()
            If Not drReader.IsClosed Then drReader.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Catch ex As Exception
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub

    'MARZ
    Friend Sub GetPermisosPerfil()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("idContacto", idContacto)
                .CommandText = "obtenerPermisosByContacto"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader()
            myPermisos.Clear() 'Limpiamos lista
            While drReader.Read() 'Leemos todos los registros
                myPermisos.Add(drReader.GetString(0))
            End While
            cmd.Connection.Close()
            drReader.Close()
        Catch ex As Exception
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub

End Class
