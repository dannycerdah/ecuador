Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class VueloManager

    Public Shared Function SaveVueloItem(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Vuelo As Object()
        Try
            If ValidateSession(req) Then
                With req.myVueloItem
                    Vuelo = New Object() {.idVuelo, .descripcion, .idAgencia, .CiudadOrigen, .AeropuertoOrigen, .CiudadLlegada, .AeropuertoLlegada, .fecha}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myVueloItem.IdVuelo)
                    .CommandText = "CheckExistsVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Vuelo(0))
                        .Parameters.AddWithValue("descripcionVuelo", Vuelo(1))
                        .Parameters.AddWithValue("idAerolinea", Vuelo(2))
                        .Parameters.AddWithValue("ciudadOrigen", Vuelo(3))
                        .Parameters.AddWithValue("aeropuertoOrigen", Vuelo(4))
                        .Parameters.AddWithValue("ciudadLlegada", Vuelo(5))
                        .Parameters.AddWithValue("aeropuertoLlegada", Vuelo(6))
                        .Parameters.AddWithValue("fecha", Vuelo(7))
                        .CommandText = "modificarVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Vuelo(0))
                        .Parameters.AddWithValue("descripcionVuelo", Vuelo(1))
                        .Parameters.AddWithValue("idAerolinea", Vuelo(2))
                        .Parameters.AddWithValue("ciudadOrigen", Vuelo(3))
                        .Parameters.AddWithValue("aeropuertoOrigen", Vuelo(4))
                        .Parameters.AddWithValue("ciudadLlegada", Vuelo(5))
                        .Parameters.AddWithValue("aeropuertoLlegada", Vuelo(6))
                        .Parameters.AddWithValue("fecha", Vuelo(7))
                        .CommandText = "agregarVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveDetalleVuelo(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim DetalleVuelo As Object()
        Dim dataAgenciasByBriefing As Object()
        Dim cmdEliminarAgencias As New MySqlCommand
        Dim cmdAgencias As New MySqlCommand
        Try
            If ValidateSession(req) Then
                With req.myDetalleVuelo
                    DetalleVuelo = New Object() {.idBriefing, .idVuelo, .idAgencia, .codigoVuelo, .fechaVuelo, .llegadaVuelo, .salidaVuelo,
                                                 .enviaVuelo, .recibeVuelo, .estadoVuelo, .briefingVuelo, .idAvion, .idMatriz}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleVuelo.idBriefing)
                    .CommandText = "CheckExistsDetalleVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", DetalleVuelo(0))
                        .Parameters.AddWithValue("idVuelo", DetalleVuelo(1))
                        .Parameters.AddWithValue("idagencia", DetalleVuelo(2))
                        .Parameters.AddWithValue("codigo", DetalleVuelo(3))
                        .Parameters.AddWithValue("fecha", DetalleVuelo(4))
                        .Parameters.AddWithValue("llegada", DetalleVuelo(5))
                        .Parameters.AddWithValue("salida", DetalleVuelo(6))
                        .Parameters.AddWithValue("envia", DetalleVuelo(7))
                        .Parameters.AddWithValue("recibe", DetalleVuelo(8))
                        .Parameters.AddWithValue("estado", DetalleVuelo(9))
                        .Parameters.AddWithValue("briefing", DetalleVuelo(10))
                        .Parameters.AddWithValue("idAvion", DetalleVuelo(11))
                        .Parameters.AddWithValue("idMatriz", DetalleVuelo(12))
                        .CommandText = "modificarDetalleDeVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    'MARZ
                    With cmdEliminarAgencias
                        .Parameters.AddWithValue("Id", req.myDetalleVuelo.idBriefing)
                        .CommandText = "eliminarAgenciasByBriefing"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdEliminarAgencias.ExecuteNonQuery()
                    End With
                    If cmdEliminarAgencias.Connection IsNot Nothing Then
                        cmdEliminarAgencias.Connection.Close()
                    End If
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", DetalleVuelo(0))
                        .Parameters.AddWithValue("idVuelo", DetalleVuelo(1))
                        .Parameters.AddWithValue("idagencia", DetalleVuelo(2))
                        .Parameters.AddWithValue("codigo", DetalleVuelo(3))
                        .Parameters.AddWithValue("fecha", DetalleVuelo(4))
                        .Parameters.AddWithValue("llegada", DetalleVuelo(5))
                        .Parameters.AddWithValue("salida", DetalleVuelo(6))
                        .Parameters.AddWithValue("envia", DetalleVuelo(7))
                        .Parameters.AddWithValue("recibe", DetalleVuelo(8))
                        .Parameters.AddWithValue("estado", DetalleVuelo(9))
                        .Parameters.AddWithValue("briefing", DetalleVuelo(10))
                        .Parameters.AddWithValue("idAvion", DetalleVuelo(11))
                        .Parameters.AddWithValue("idMatriz", DetalleVuelo(12))
                        .CommandText = "agregarDetalleDeVuelos"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                'MARZ
                For Each r As BriefingAgencias In req.myDetalleVuelo.briefingAgencias
                    cmdAgencias = New MySqlCommand
                    With r
                        dataAgenciasByBriefing = New Object() { .idBriefing, .idAgencia}
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmdAgencias
                            .Parameters.AddWithValue("IdBriefing", dataAgenciasByBriefing(0))
                            .Parameters.AddWithValue("IdAgencia", dataAgenciasByBriefing(1))
                            .CommandText = "agregarAgenciasByBriefing"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmdAgencias.ExecuteNonQuery()
                        End With
                        If cmdAgencias.Connection IsNot Nothing Then
                            cmdAgencias.Connection.Close()
                        End If
                    End With
                Next

                If cmdAgencias.Connection IsNot Nothing Then
                    cmdAgencias.Connection.Close()
                End If
                'cmdAgencias.Connection.Close()
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdEliminarAgencias.Connection IsNot Nothing Then
                If cmdEliminarAgencias.Connection.State = ConnectionState.Open Then cmdEliminarAgencias.Connection.Close()
            End If
            If cmdAgencias.Connection IsNot Nothing Then
                If cmdAgencias.Connection.State = ConnectionState.Open Then cmdAgencias.Connection.Close()
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmdEliminarAgencias.Connection IsNot Nothing Then
                If cmdEliminarAgencias.Connection.State = ConnectionState.Open Then cmdEliminarAgencias.Connection.Close()
            End If
            If cmdAgencias.Connection IsNot Nothing Then
                If cmdAgencias.Connection.State = ConnectionState.Open Then cmdAgencias.Connection.Close()
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveDetalleRutaVueloItem(req As DetalleRutaVueloRequest) As DetalleRutaVueloResponse
        Dim Result As New DetalleRutaVueloResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim RutaVuelo As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleRutaVuelo
                    RutaVuelo = New Object() {.IdVuelo, .CiudadEscala, .AeropuertoEscala}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleRutaVuelo.IdVuelo)
                    .Parameters.AddWithValue("Ciudad", req.myDetalleRutaVuelo.CiudadEscala)
                    .Parameters.AddWithValue("aeropuertoEscala", req.myDetalleRutaVuelo.AeropuertoEscala)
                    .CommandText = "CheckExistsDetalleRutaVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", RutaVuelo(0))
                        .Parameters.AddWithValue("Ciudad", RutaVuelo(1))
                        .Parameters.AddWithValue("aeropuertoEscala", RutaVuelo(2))
                        .CommandText = "modificarDetalleDeRutaVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", RutaVuelo(0))
                        .Parameters.AddWithValue("Ciudad", RutaVuelo(1))
                        .Parameters.AddWithValue("aeropuertoEscala", RutaVuelo(2))
                        .CommandText = "agregarDetalleDeRutaVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveElementoBriefingItem(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim ElementoBriefing As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoBriefingItem
                    ElementoBriefing = New Object() {.idBriefing, .idElemento, .fecha, .indice, .usuario, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("indice", req.myElementoBriefingItem.indice)
                    .CommandText = "CheckExistsElementoBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idBriefing", ElementoBriefing(0))
                        .Parameters.AddWithValue("idElemento", ElementoBriefing(1))
                        .Parameters.AddWithValue("fecha", ElementoBriefing(2))
                        .Parameters.AddWithValue("indice", ElementoBriefing(3))
                        .Parameters.AddWithValue("idContacto", ElementoBriefing(4))
                        .Parameters.AddWithValue("estado", ElementoBriefing(5))
                        .CommandText = "modificarElementoBriefing"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idBriefing", ElementoBriefing(0))
                        .Parameters.AddWithValue("idElemento", ElementoBriefing(1))
                        .Parameters.AddWithValue("fecha", ElementoBriefing(2))
                        .Parameters.AddWithValue("indice", ElementoBriefing(3))
                        .Parameters.AddWithValue("idContacto", ElementoBriefing(4))
                        .Parameters.AddWithValue("estado", ElementoBriefing(5))
                        .CommandText = "agregarElementoBriefing"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function modificarEstadoElementoBriefingPorIndice(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        'Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                'With req.myElementoProcesoItem
                '    DetalleProceso = New Object() {.indice, .estado}
                'End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("indice", req.myElementoBriefingItem.indice)
                    .Parameters.AddWithValue("estado", req.myElementoBriefingItem.estado)
                    .CommandText = "modificarEstadoElementoBriefingPorIndice"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            Result.ErrorMessage = ex.Message
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoProcesoPorIndice(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtElementoBriefing As ElementoBriefingItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Indice", req.myElementoBriefingItem.indice)
                    .CommandText = "ObtenerElementoBriefingPorIndice"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtElementoBriefing = New ElementoBriefingItem
                    With myDtElementoBriefing
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                        .indice = drReader.GetValue(drReader.GetOrdinal("indice"))
                    End With
                    Result.myElementoBriefingItem = myDtElementoBriefing
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoBriefingPorIdBriefing(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoBriefingItem.idBriefing)
                    .CommandText = "obtenerElementoBriefingPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtElementoBriefing"))
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

    Public Shared Function GetElementoBriefingPorIdElemento(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idElemento", req.myElementoBriefingItem.idElemento)
                    .CommandText = "obtenerElementoBriefingPorIdElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtElementoBriefing"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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


    Public Shared Function GetDetalleVueloPorFecha(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myDetalleVuelo.IdAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.myDetalleVuelo.llegadaVuelo)
                    .Parameters.AddWithValue("fechaFin", req.myDetalleVuelo.salidaVuelo)
                    .CommandText = "ObtenerDetalleVueloPorFecha"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("idAgencia", req.myDetalleVuelo.IdAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.myDetalleVuelo.llegadaVuelo)
                    .Parameters.AddWithValue("fechaFin", req.myDetalleVuelo.salidaVuelo)
                    .CommandText = "ObtenerDetalleVueloPorFecha"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetDetalleVueloPorFechaHoy(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    '.Parameters.AddWithValue("idAgencia", req.myDetalleVuelo.idAgencia)
                    '.Parameters.AddWithValue("fechaInicio", req.myDetalleVuelo.llegadaVuelo)
                    '.Parameters.AddWithValue("fechaFin", req.myDetalleVuelo.salidaVuelo)
                    .CommandText = "ObtenerDetalleVueloPorFechaHoy"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("idAgencia", req.myDetalleVuelo.idAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.myDetalleVuelo.llegadaVuelo)
                    .Parameters.AddWithValue("fechaFin", req.myDetalleVuelo.salidaVuelo)
                    .CommandText = "ObtenerDetalleVueloPorFechaHoy"
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

    Public Shared Function GetRutaVueloPorId(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idVuelo", req.myDetalleVuelo.idVuelo)
                    .CommandText = "ObtenerRutaVueloPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtVueloRuta"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetDetalleVueloPorCodigo(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("codigo", req.myDetalleVuelo.codigoVuelo)
                    .CommandText = "ObtenerDetalleVueloPorCodigo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("codigo", req.myDetalleVuelo.codigoVuelo)
                    .CommandText = "ObtenerDetalleVueloPorCodigo"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetDetalleVueloPorIdVuelo(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("id", req.myDetalleVuelo.idVuelo)
                    .CommandText = "ObtenerDetalleVueloPorIdVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("id", req.myDetalleVuelo.idVuelo)
                    .CommandText = "ObtenerDetalleVueloPorIdVuelo"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetDetalleVueloPorIdBriefing(req As DetalleVueloRequest) As DetalleVueloResponse
        Dim Result As New DetalleVueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtVuelo As DetalleVuelo
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("id", req.myDetalleVuelo.idBriefing)
                    .CommandText = "ObtenerDetalleVueloPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                With cmd2
                    .Parameters.AddWithValue("id", req.myDetalleVuelo.idBriefing)
                    .CommandText = "ObtenerDetalleVueloPorIdBriefing"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetVueloPorId(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myVuelo As VueloItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myVueloItem.idVuelo)
                    .CommandText = "obtenerVueloPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myVuelo = New VueloItem
                    With myVuelo
                        .idVuelo = drReader.GetValue(drReader.GetOrdinal("idVuelo"))
                        .descripcion = drReader.GetValue(drReader.GetOrdinal("descripcionVuelo"))
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idAerolinea"))
                        .CiudadOrigen = drReader.GetValue(drReader.GetOrdinal("ciudadOrigen"))
                        .AeropuertoOrigen = drReader.GetValue(drReader.GetOrdinal("aeropuertoOrigen"))
                        .CiudadLlegada = drReader.GetValue(drReader.GetOrdinal("ciudadLlegada"))
                        .AeropuertoLlegada = drReader.GetValue(drReader.GetOrdinal("aeropuertoLlegada"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                    End With
                    Result.myVueloItem = myVuelo
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetRutaVueloPorIdVuelo(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idVuelo", New String(req.prmArr(0)))
                    .CommandText = "ObtenerRutaVueloPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtRuta"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetVuelosPorIdAgencia(req As VueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", New Guid(req.prmArr(0)))
                    .CommandText = "ObtenerVuelosPorIdAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("dtVuelos"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetEntirePosicionesCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerPosiciones"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Producto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetEntireVuelosCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerVuelos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Vuelos"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetPosicionItemById(req As PosicionRequest) As PosicionResponse
        Dim Result As New PosicionResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPosicion As PosicionItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myPosicionItem.Id)
                    .CommandText = "ObtenerPosicionPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myPosicion = New PosicionItem
                    With myPosicion
                        .Id = drReader.GetValue(drReader.GetOrdinal("idPosicion"))
                        .descripcion = drReader.GetValue(drReader.GetOrdinal("descripcionPosicion"))

                    End With
                    Result.myPosicionItem = myPosicion
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SavePosicionItem(req As PosicionRequest) As PosicionResponse
        Dim Result As New PosicionResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Posicion As Object()
        Try
            If ValidateSession(req) Then
                With req.myPosicionItem
                    Posicion = New Object() {.Id, .descripcion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myPosicionItem.Id)
                    .CommandText = "CheckExistsPosicion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Posicion(0))
                        .Parameters.AddWithValue("descripcion", Posicion(1))
                        .CommandText = "modificarPosicion"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Posicion(0))
                        .Parameters.AddWithValue("descripcion", Posicion(1))
                        .CommandText = "agregarPosicion"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_03.10.17
    Public Shared Function GetAgenciasByBriefing(req As DetalleVueloRequest) As VueloResponse
        Dim Result As New VueloResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("IdBriefing", req.myDetalleVuelo.idBriefing)
                    .CommandText = "obtenerAgenciasByBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AgenciasByBriefing"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

End Class
