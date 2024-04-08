Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class TemperaturaManager
    Public Shared Function ObtenerCuartosFrios(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerCuartosFrios"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ObtenerCuartosFrios"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerConfTemp(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerConfTemp"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ObtenerConfTemp"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerTempAct(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("NombreCuartoFrio", req.NombreCuartoFrio)
                    .CommandText = "Sp_ObtenerTempAct"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ObtenerTempAct"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function RegConfTemp(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req
                    Tipo = New Object() { .Puerto, .NombreCuartoFrio, .Estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Puerto", Tipo(0))
                    .Parameters.AddWithValue("NombreCuartoFrio", Tipo(1))
                    .Parameters.AddWithValue("Estado", Tipo(2))
                    .CommandText = "Sp_RegConfTemp"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function RegCuartoFrio(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req
                    Tipo = New Object() { .NombreCuartoFrio, .Estado, .Descripcion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("NombreCuarto", Tipo(0))
                    .Parameters.AddWithValue("Estado", Tipo(1))
                    .Parameters.AddWithValue("Descripcion", Tipo(2))
                    .CommandText = "SP_RegCuartoFrio"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function RegTemperatura(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req
                    Tipo = New Object() { .Puerto, .NombreCuartoFrio, .Humedad, .Centigrado, .fahrenheit}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Puerto", Tipo(0))
                    .Parameters.AddWithValue("NombreCuartoFrio", Tipo(1))
                    .Parameters.AddWithValue("Humedad", Tipo(2))
                    .Parameters.AddWithValue("Centigrado", Tipo(3))
                    .Parameters.AddWithValue("fahrenheit", Tipo(4))
                    .CommandText = "SP_RegTemperatura"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function RegTemperaturaHist(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req
                    Tipo = New Object() { .Puerto, .NombreCuartoFrio, .Humedad, .Centigrado, .fahrenheit}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Puerto", Tipo(0))
                    .Parameters.AddWithValue("NombreCuartoFrio", Tipo(1))
                    .Parameters.AddWithValue("Humedad", Tipo(2))
                    .Parameters.AddWithValue("Centigrado", Tipo(3))
                    .Parameters.AddWithValue("fahrenheit", Tipo(4))
                    .CommandText = "SP_RegTemperaturaHist"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ActualizaVersion(req As String) As Boolean
        Dim Result As Boolean
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("NombreVersion", req)
                    .CommandText = "Sp_ActualizaVersion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
            Result = True
        Catch ex As Exception
            Result = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerReportTemp(req As TempRequest) As TempResponse
        Dim Result As New TempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("NombreCuartoFrio", req.NombreCuartoFrio)
                    .Parameters.AddWithValue("FechaInicio", req.FechaInicio)
                    .Parameters.AddWithValue("FechaFinal", req.FechaFinal)
                    .CommandText = "Sp_ReportTemp"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ReportTemp"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerCuartoFrioIdProIdGui(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Dim Result As New TempBitacoraCuartoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idProceso", req.TempBitacoraCuarto.idProceso)
                    .Parameters.AddWithValue("idElemento", req.TempBitacoraCuarto.idElemento)
                    .CommandText = "Sp_ObtenerCuartoFrioIdProElemen"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ObtenerCuartoFrioIdProIdGui"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function AgregaBitacoraCargaCuarto(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Dim Result As New TempBitacoraCuartoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idProceso", req.TempBitacoraCuarto.idProceso)
                    .Parameters.AddWithValue("idElemento", req.TempBitacoraCuarto.idElemento)
                    .Parameters.AddWithValue("CuartoAnteriror", req.TempBitacoraCuarto.CuartoAnteriror)
                    .Parameters.AddWithValue("CuartoActual", req.TempBitacoraCuarto.CuartoActual)
                    .Parameters.AddWithValue("UsuarioIngreso", req.TempBitacoraCuarto.UsuarioIngreso)
                    .CommandText = "Sp_AgregaBitacoraCargaCuarto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd.Connection.Close()
                Result.ActionResult = True
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerVuelosElemen(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Dim Result As New TempBitacoraCuartoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("TipoConsulta", req.TempBitacoraCuarto.TipoConsulta)
                    .Parameters.AddWithValue("idAgencia", req.TempBitacoraCuarto.idAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.TempBitacoraCuarto.fechaInicio)
                    .Parameters.AddWithValue("fechaFin", req.TempBitacoraCuarto.fechaFin)
                    .CommandText = "Sp_ObtenerVuelosElemen"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerVuelosElemen"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerParametrosNoti(req As NotificacionTempRequest) As NotificacionTempResponse
        Dim Result As New NotificacionTempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("id_notificacion_temp", req.NotificacionTemp.id_notificacion_temp)
                    .Parameters.AddWithValue("idProducto", req.NotificacionTemp.idProducto)
                    .Parameters.AddWithValue("temp_max", req.NotificacionTemp.temp_max)
                    .Parameters.AddWithValue("temp_min", req.NotificacionTemp.temp_min)
                    .CommandText = "Sp_ObtenerNotifiTemp"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerNotifiTemp"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function MantNotificacionTemp(req As NotificacionTempRequest) As NotificacionTempResponse
        Dim Result As New NotificacionTempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim IngresaDatos As Boolean = True
        Try
            Result = ObtenerParametrosNoti(req)
            If Result.ActionResult Then
                If Result.dsResult.Tables(0).Rows.Count > 0 And req.NotificacionTemp.id_notificacion_temp = 0 Then
                    IngresaDatos = False
                End If
            End If
            If ValidateSession(req) And IngresaDatos Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("id_notificacion_temp", req.NotificacionTemp.id_notificacion_temp)
                    .Parameters.AddWithValue("idProducto", req.NotificacionTemp.idProducto)
                    .Parameters.AddWithValue("temp_min", req.NotificacionTemp.temp_min)
                    .Parameters.AddWithValue("temp_max", req.NotificacionTemp.temp_max)
                    .Parameters.AddWithValue("UsuarioIngreso", req.NotificacionTemp.UsuarioIngreso)
                    .Parameters.AddWithValue("Estado", req.NotificacionTemp.Estado)
                    .CommandText = "Sp_MantNotificacionTemp"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With
            ElseIf IngresaDatos = False Then
                Result.ActionResult = False
                Result.ErrorMessage = "Ya Existe un Registro para este Producto"
            End If
        Catch ex As Exception
            Result.ActionResult = False
            Result.ErrorMessage = ex.Message
            SetLogEvent(ex, Result, req)
            If IngresaDatos Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If IngresaDatos Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerRegCuartProduc() As NotificacionTempResponse
        Dim Result As New NotificacionTempResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(Result) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerRegCuartProduc"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    Result.dsResult = New DataSet
                    Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerRegCuartProduc"))
                    Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                    cmd.Connection.Close()
                End With
            End If
        Catch ex As Exception
            Result.ActionResult = False
            Result.ErrorMessage = ex.Message
            SetLogEvent(ex, Result, Result)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
