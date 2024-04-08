Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class ReporteResumidoManager
    Public Shared Function GetReportePorIdProcesoGroupByAgenciaCarga(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByAgencia.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByAgenciaCargaReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByAgencia"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByGuia(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByAgencia.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByGuiaReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByGuia"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByElemento.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByElementoReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByElemento"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento2(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByElemento.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByElementoReporte2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByElemento"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento3(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByElemento.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByElementoReporte3"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByElemento"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function GetReportePorIdProcesoGroupByDestino(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByDestino.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoGroupByDestinoReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteProcesoGroupByDestino"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function Sp_RegReporteVuelosEnviados(req As ReportVuelosEnviadosRequest) As ReportVuelosEnviadosResponse
        Dim Result As New ReportVuelosEnviadosResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim ReadDatos As MySqlDataReader
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("IdBriefing", req.Datos.IdBriefing)
                    .Parameters.AddWithValue("IdVuelo", req.Datos.IdVuelo)
                    .Parameters.AddWithValue("Tipo", req.Datos.Tipo)
                    .CommandText = "Sp_RegReporteVuelosEnviados"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                ReadDatos = cmd.ExecuteReader
                If ReadDatos.Read() Then
                    Result.Datos.Total = ReadDatos.GetValue(ReadDatos.GetOrdinal("total"))
                    Result.Datos.Result = True
                End If
                ReadDatos.Close()
                cmd.Connection.Close()
            End If
            Result.Datos.Result = True
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.Datos.Result = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function Sp_MantControlEjecutHilo(req As ControlEjecucionHiloRequest) As ControlEjecucionHiloResponse
        Dim Result As New ControlEjecucionHiloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("IdControl", req.Datos.IdControl)
                    .Parameters.AddWithValue("NombreControl", req.Datos.NombreControl)
                    .Parameters.AddWithValue("UsuarioIngresoControl", req.Datos.UsuarioIngresoControl)
                    .Parameters.AddWithValue("PuntoEjecucion", req.Datos.PuntoEjecucion)
                    .Parameters.AddWithValue("Tipo", req.Datos.Tipo)
                    .CommandText = "Sp_MantControlEjecutHilo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If req.Datos.Tipo = "I" Or req.Datos.Tipo = "D" Then
                    cmd.ExecuteNonQuery()
                Else
                    Dim ReadDatos As MySqlDataReader
                    ReadDatos = cmd.ExecuteReader
                    If ReadDatos.Read() Then
                        Result.Datos.IdControl = ReadDatos.GetValue(ReadDatos.GetOrdinal("IdControl"))
                        Result.Datos.NombreControl = ReadDatos.GetValue(ReadDatos.GetOrdinal("NombreControl"))
                        Result.Datos.UsuarioIngresoControl = ReadDatos.GetValue(ReadDatos.GetOrdinal("UsuarioIngresoControl"))
                        Result.Datos.PuntoEjecucion = ReadDatos.GetValue(ReadDatos.GetOrdinal("PuntoEjecucion"))
                        Result.Datos.Estado = ReadDatos.GetValue(ReadDatos.GetOrdinal("Estado"))
                    End If
                    ReadDatos.Close()
                End If
                Result.ActionResult = True
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
    Public Shared Function obtenerdetalleVueloPorFechaHoy2(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerdetalleVueloPorFechaHoy2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("idAgencia", req.myDetalleVuelo.idAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.myDetalleVuelo.llegadaVuelo)
                    .Parameters.AddWithValue("fechaFin", req.myDetalleVuelo.salidaVuelo)
                    .CommandText = "obtenerdetalleVueloPorFechaHoy2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtVuelo = New DetalleVuelo
                    With myDtVuelo
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .idVuelo = drReader.GetValue(drReader.GetOrdinal("idVuelo"))
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .descripcionAgencia = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .codigoVuelo = drReader.GetValue(drReader.GetOrdinal("codigoVuelo"))
                        .fechaVuelo = drReader.GetValue(drReader.GetOrdinal("fechaVuelo"))
                        .llegadaVuelo = drReader.GetValue(drReader.GetOrdinal("llegadaVuelo"))
                        .salidaVuelo = drReader.GetValue(drReader.GetOrdinal("salidaVuelo"))
                        .enviaVuelo = drReader.GetValue(drReader.GetOrdinal("enviaVuelo"))
                        .recibeVuelo = drReader.GetValue(drReader.GetOrdinal("recibeVuelo"))
                        .estadoVuelo = drReader.GetValue(drReader.GetOrdinal("estadoVuelo"))
                        .briefingVuelo = drReader.GetValue(drReader.GetOrdinal("briefingVuelo"))
                        .idAvion = drReader.GetValue(drReader.GetOrdinal("idAvion"))
                        .idMatriz = drReader.GetValue(drReader.GetOrdinal("idMatriz"))
                        .descripcion = drReader.GetValue(drReader.GetOrdinal("descripcion"))
                        .descripcionAvion = drReader.GetValue(drReader.GetOrdinal("descripcionAvion"))
                        .matriculaAvion = drReader.GetValue(drReader.GetOrdinal("matriculaAvion"))
                    End With
                    Result.myDetalleVuelo = myDtVuelo
                End If
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtVuelo"))
                Result.DsResult.Tables(0).Load(cmd2.ExecuteReader())
                cmd.Connection.Close()
                cmd2.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        End Try
        Return Result
    End Function
End Class
