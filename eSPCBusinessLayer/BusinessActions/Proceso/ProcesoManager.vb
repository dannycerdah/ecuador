Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class ProcesoManager

    Public Shared Function SaveProcesoItem(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Proceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myProcesoItem
                    Proceso = New Object() {.IdProceso, .idBriefing, .idAvion, .totalBultos, .totalPiezas, .totalPeso, .fechaInicio, .fechaFin, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "CheckExistsProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Proceso(0))
                        .Parameters.AddWithValue("idBriefing", Proceso(1))
                        .Parameters.AddWithValue("idAvion", Proceso(2))
                        .Parameters.AddWithValue("totalBultos", Proceso(3))
                        .Parameters.AddWithValue("totalPiezas", Proceso(4))
                        .Parameters.AddWithValue("totalPeso", Proceso(5))
                        .Parameters.AddWithValue("fechaInicio", Proceso(6))
                        .Parameters.AddWithValue("fechaFin", Proceso(7))
                        .Parameters.AddWithValue("estado", Proceso(8))
                        .CommandText = "modificarProceso"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Proceso(0))
                        .Parameters.AddWithValue("idBriefing", Proceso(1))
                        .Parameters.AddWithValue("idAvion", Proceso(2))
                        .Parameters.AddWithValue("totalBultos", Proceso(3))
                        .Parameters.AddWithValue("totalPiezas", Proceso(4))
                        .Parameters.AddWithValue("totalPeso", Proceso(5))
                        .Parameters.AddWithValue("fechaInicio", Proceso(6))
                        .Parameters.AddWithValue("fechaFin", Proceso(7))
                        .Parameters.AddWithValue("estado", Proceso(8))
                        .CommandText = "agregarProceso"
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

    Public Shared Function SaveProduccionItem(req As ProduccionRequest) As ProduccionResponse
        Dim Result As New ProduccionResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Produccion As Object()
        Try
            If ValidateSession(req) Then
                With req.myProduccionItem
                    Produccion = New Object() {.idProduccion, .idTarifas, .idBriefing, .idagencia, .fechaPro, .estado, .agenteCarPro, .almacenajeConPro, .almacenajeCorPro, .almacenajeCarPro, .devolucionCarPro, .correoPro, .estibaDesPro, .limpiezaElePro, .manipuleoPro, .minimoMesPro, .minimoVueloPro, .montaCargaPro, .precoolingPro, .procesamientoCarPro, .procesamientoCVPro, .variosPro, .devCarPVPro, .estibaPVPro}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("IdProd", req.myProduccionItem.idProduccion)
                    .CommandText = "CheckExistsProduccion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idProduccion", Produccion(0))
                        .Parameters.AddWithValue("idTarifas", Produccion(1))
                        .Parameters.AddWithValue("idBriefing", Produccion(2))
                        .Parameters.AddWithValue("idagencia", Produccion(3))
                        .Parameters.AddWithValue("fechaPro", Produccion(4))
                        .Parameters.AddWithValue("estado", Produccion(5))
                        .Parameters.AddWithValue("agenteCarPro", Produccion(6))
                        .Parameters.AddWithValue("almacenajeConPro", Produccion(7))
                        .Parameters.AddWithValue("almacenajeCorPro", Produccion(8))
                        .Parameters.AddWithValue("almacenajeCarPro", Produccion(9))
                        .Parameters.AddWithValue("devolucionCarPro", Produccion(10))
                        .Parameters.AddWithValue("correoPro", Produccion(11))
                        .Parameters.AddWithValue("estibaDesPro", Produccion(12))
                        .Parameters.AddWithValue("limpiezaElePro", Produccion(13))
                        .Parameters.AddWithValue("manipuleoPro", Produccion(14))
                        .Parameters.AddWithValue("minimoMesPro", Produccion(15))
                        .Parameters.AddWithValue("minimoVueloPro", Produccion(16))
                        .Parameters.AddWithValue("montaCargaPro", Produccion(17))
                        .Parameters.AddWithValue("precoolingPro", Produccion(18))
                        .Parameters.AddWithValue("procesamientoCarPro", Produccion(19))
                        .Parameters.AddWithValue("procesamientoCVPro", Produccion(20))
                        .Parameters.AddWithValue("variosPro", Produccion(21))
                        .Parameters.AddWithValue("devCarPVPro", Produccion(22))
                        .Parameters.AddWithValue("estibaPVPro", Produccion(23))
                        .CommandText = "modificarProduccion"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idProduccion", Produccion(0))
                        .Parameters.AddWithValue("idTarifas", Produccion(1))
                        .Parameters.AddWithValue("idBriefing", Produccion(2))
                        .Parameters.AddWithValue("idagencia", Produccion(3))
                        .Parameters.AddWithValue("fechaPro", Produccion(4))
                        .Parameters.AddWithValue("estado", Produccion(5))
                        .Parameters.AddWithValue("agenteCarPro", Produccion(6))
                        .Parameters.AddWithValue("almacenajeConPro", Produccion(7))
                        .Parameters.AddWithValue("almacenajeCorPro", Produccion(8))
                        .Parameters.AddWithValue("almacenajeCarPro", Produccion(9))
                        .Parameters.AddWithValue("devolucionCarPro", Produccion(10))
                        .Parameters.AddWithValue("correoPro", Produccion(11))
                        .Parameters.AddWithValue("estibaDesPro", Produccion(12))
                        .Parameters.AddWithValue("limpiezaElePro", Produccion(13))
                        .Parameters.AddWithValue("manipuleoPro", Produccion(14))
                        .Parameters.AddWithValue("minimoMesPro", Produccion(15))
                        .Parameters.AddWithValue("minimoVueloPro", Produccion(16))
                        .Parameters.AddWithValue("montaCargaPro", Produccion(17))
                        .Parameters.AddWithValue("precoolingPro", Produccion(18))
                        .Parameters.AddWithValue("procesamientoCarPro", Produccion(19))
                        .Parameters.AddWithValue("procesamientoCVPro", Produccion(20))
                        .Parameters.AddWithValue("variosPro", Produccion(21))
                        .Parameters.AddWithValue("devCarPVPro", Produccion(22))
                        .Parameters.AddWithValue("estibaPVPro", Produccion(23))
                        .CommandText = "agregarProduccion"
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

    Public Shared Function SaveDocSenae(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim docSenae As Object()
        Try
            If ValidateSession(req) Then
                With req.myDocSenae
                    docSenae = New Object() {.Id, .numeroDae, .idProducto, .peso, .piezas, .docId, .idProceso, .idGuia, .estado, .fecha}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDocSenae.Id)
                    .CommandText = "CheckExistsDocSenae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If Not CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", docSenae(0))
                        .Parameters.AddWithValue("numeroDae", docSenae(1))
                        .Parameters.AddWithValue("idProducto", docSenae(2))
                        .Parameters.AddWithValue("peso", docSenae(3))
                        .Parameters.AddWithValue("piezas", docSenae(4))
                        .Parameters.AddWithValue("docId", docSenae(5))
                        .Parameters.AddWithValue("idProceso", docSenae(6))
                        .Parameters.AddWithValue("idGuia", docSenae(7))
                        .Parameters.AddWithValue("estado", docSenae(8))
                        .Parameters.AddWithValue("fecha", docSenae(9))
                        .CommandText = "agregarDocSenae"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    cmd.Connection.Close()
                End If
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


    Public Shared Function SaveNovedadesItem(req As NovedadesRequest) As NovedadesResponse
        Dim Result As New NovedadesResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Proceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myNovedadesItem
                    Proceso = New Object() {.idProceso, .llegada, .salida, .subeDesde, .subeHasta, .observacion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myNovedadesItem.idProceso)
                    .CommandText = "CheckExistsNovedadesVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idProceso", Proceso(0))
                        .Parameters.AddWithValue("llegada", Proceso(1))
                        .Parameters.AddWithValue("salida", Proceso(2))
                        .Parameters.AddWithValue("subeDesde", Proceso(3))
                        .Parameters.AddWithValue("subeHasta", Proceso(4))
                        .Parameters.AddWithValue("observacion", Proceso(5))
                        .CommandText = "modificarNovedadesVuelo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idProceso", Proceso(0))
                        .Parameters.AddWithValue("llegada", Proceso(1))
                        .Parameters.AddWithValue("salida", Proceso(2))
                        .Parameters.AddWithValue("subeDesde", Proceso(3))
                        .Parameters.AddWithValue("subeHasta", Proceso(4))
                        .Parameters.AddWithValue("observacion", Proceso(5))
                        .CommandText = "agregarNovedadesVuelo"
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

    Public Shared Function SaveElementoProcesoItem(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Proceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoProcesoItem
                    Proceso = New Object() {.IdProceso, .idElemento, .fecha, .pesoReferencialElemento, .pesoEntradaElemento, .pesoCaptura, .indice, .usuarioComparacionPeso}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("indice", req.myElementoProcesoItem.indice)
                    .CommandText = "CheckExistsElementoProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Proceso(0))
                        .Parameters.AddWithValue("idElemento", Proceso(1))
                        .Parameters.AddWithValue("fecha", Proceso(2))
                        .Parameters.AddWithValue("pesoReferencialElemento", Proceso(3))
                        .Parameters.AddWithValue("pesoEntradaElemento", Proceso(4))
                        .Parameters.AddWithValue("pesoCaptura", Proceso(5))
                        '.Parameters.AddWithValue("pesoTotalElemento", Proceso(6))
                        .Parameters.AddWithValue("indice", Proceso(6))
                        .Parameters.AddWithValue("usuario", Proceso(7))
                        .CommandText = "modificarElementoProceso"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Proceso(0))
                        .Parameters.AddWithValue("idElemento", Proceso(1))
                        .Parameters.AddWithValue("fecha", Proceso(2))
                        .Parameters.AddWithValue("pesoReferencialElemento", Proceso(3))
                        .Parameters.AddWithValue("pesoEntradaElemento", Proceso(4))
                        .Parameters.AddWithValue("pesoCaptura", Proceso(5))
                        '.Parameters.AddWithValue("pesoTotalElemento", Proceso(6))
                        .Parameters.AddWithValue("indice", Proceso(6))
                        .Parameters.AddWithValue("usuario", Proceso(7))
                        .CommandText = "agregarElementoProceso"
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
    Public Shared Function SaveDetalleProcesoItem(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() { .IdDetalleProceso, .fecha, .idGuia, .Guia, .dae, .idElemento, .agenciaTransporte,
                                                   .bultos, .peso, .piezas, .volumen, .hora, .idProducto, .estado,
                                                   .idPosicion, .temperatura, .rx, .man, .k9, .eds, .largo, .ancho, .alto,
                                                   .tempA, .tempB, .tempC, .idCamion, .muelle, .indice, .tempA_3_4, .tempZ_Flor, .tempZ_Pq, .RegCargaCuartoFrio, .UsusarioIngreso, .nuSaca, .codsello, .incourier}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleProcesoItem.IdDetalleProceso)
                    .CommandText = "CheckExistsAgencia" 'EWLM NO ENTIENDO, ESTA ESTO BIEN???
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idProceso", DetalleProceso(0))
                        .Parameters.AddWithValue("fecha", DetalleProceso(1))
                        .Parameters.AddWithValue("idGuia", DetalleProceso(2))
                        .Parameters.AddWithValue("guia", DetalleProceso(3))
                        .Parameters.AddWithValue("dae", DetalleProceso(4))
                        .Parameters.AddWithValue("idElemento", DetalleProceso(5))
                        .Parameters.AddWithValue("agenciaTransporte", DetalleProceso(6))
                        .Parameters.AddWithValue("bultos", DetalleProceso(7))
                        .Parameters.AddWithValue("peso", DetalleProceso(8))
                        .Parameters.AddWithValue("piezas", DetalleProceso(9))
                        .Parameters.AddWithValue("volumen", DetalleProceso(10))
                        .Parameters.AddWithValue("hora", DetalleProceso(11))
                        .Parameters.AddWithValue("idProducto", DetalleProceso(12))
                        .Parameters.AddWithValue("estado", DetalleProceso(13))
                        .Parameters.AddWithValue("idPosicion", DetalleProceso(14))
                        .Parameters.AddWithValue("temperatura", DetalleProceso(15))
                        .Parameters.AddWithValue("rx", DetalleProceso(16))
                        .Parameters.AddWithValue("man", DetalleProceso(17))
                        .Parameters.AddWithValue("k9", DetalleProceso(18))
                        .Parameters.AddWithValue("eds", DetalleProceso(19))
                        .Parameters.AddWithValue("largo", DetalleProceso(20))
                        .Parameters.AddWithValue("ancho", DetalleProceso(21))
                        .Parameters.AddWithValue("alto", DetalleProceso(22))
                        .Parameters.AddWithValue("tempA", DetalleProceso(23))
                        .Parameters.AddWithValue("tempA_3_4", DetalleProceso(29)) 'sensor de temp
                        .Parameters.AddWithValue("tempB", DetalleProceso(24))
                        .Parameters.AddWithValue("tempC", DetalleProceso(25))
                        .Parameters.AddWithValue("tempZ_Flor", DetalleProceso(30)) 'sensor de temp
                        .Parameters.AddWithValue("tempZ_Pq", DetalleProceso(31)) 'sensor de temp
                        .Parameters.AddWithValue("idCamion", DetalleProceso(26))
                        .Parameters.AddWithValue("muelle", DetalleProceso(27))
                        .Parameters.AddWithValue("indice", DetalleProceso(28))
                        .Parameters.AddWithValue("RegCargaCuartoFrio", DetalleProceso(32)) 'sensor de temp
                        .Parameters.AddWithValue("UsusarioIngreso", DetalleProceso(33)) 'sensor de temp

                        .Parameters.AddWithValue("nuSaca", DetalleProceso(34))
                        .Parameters.AddWithValue("codsello", DetalleProceso(35))
                        .Parameters.AddWithValue("incourier", DetalleProceso(36))

                        .CommandText = "modificarDetalleProceso" 'NO EXISTE ESTE PROCESO, NO LO ENCUENTRO
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idProceso", DetalleProceso(0))
                        .Parameters.AddWithValue("fecha", DetalleProceso(1))
                        .Parameters.AddWithValue("idGuia", DetalleProceso(2))
                        .Parameters.AddWithValue("guia", DetalleProceso(3))
                        .Parameters.AddWithValue("dae", DetalleProceso(4))
                        .Parameters.AddWithValue("idElemento", DetalleProceso(5))
                        .Parameters.AddWithValue("agenciaTransporte", DetalleProceso(6))
                        .Parameters.AddWithValue("bultos", DetalleProceso(7))
                        .Parameters.AddWithValue("peso", DetalleProceso(8))
                        .Parameters.AddWithValue("piezas", DetalleProceso(9))
                        .Parameters.AddWithValue("volumen", DetalleProceso(10))
                        .Parameters.AddWithValue("hora", DetalleProceso(11))
                        .Parameters.AddWithValue("idProducto", DetalleProceso(12))
                        .Parameters.AddWithValue("estado", DetalleProceso(13))
                        .Parameters.AddWithValue("idPosicion", DetalleProceso(14))
                        .Parameters.AddWithValue("temperatura", DetalleProceso(15))
                        .Parameters.AddWithValue("rx", DetalleProceso(16))
                        .Parameters.AddWithValue("man", DetalleProceso(17))
                        .Parameters.AddWithValue("k9", DetalleProceso(18))
                        .Parameters.AddWithValue("eds", DetalleProceso(19))
                        .Parameters.AddWithValue("largo", DetalleProceso(20))
                        .Parameters.AddWithValue("ancho", DetalleProceso(21))
                        .Parameters.AddWithValue("alto", DetalleProceso(22))
                        .Parameters.AddWithValue("tempA", DetalleProceso(23))
                        .Parameters.AddWithValue("tempA_3_4", DetalleProceso(29)) 'sensor de temp
                        .Parameters.AddWithValue("tempB", DetalleProceso(24))
                        .Parameters.AddWithValue("tempC", DetalleProceso(25))
                        .Parameters.AddWithValue("tempZ_Flor", DetalleProceso(30)) 'sensor de temp
                        .Parameters.AddWithValue("tempZ_Pq", DetalleProceso(31)) 'sensor de temp
                        .Parameters.AddWithValue("idCamion", DetalleProceso(26))
                        .Parameters.AddWithValue("muelle", DetalleProceso(27))
                        .Parameters.AddWithValue("indice", DetalleProceso(28))
                        .Parameters.AddWithValue("RegCargaCuartoFrio", DetalleProceso(32)) 'sensor de temp
                        .Parameters.AddWithValue("UsusarioIngreso", DetalleProceso(33)) 'sensor de temp

                        .Parameters.AddWithValue("nuSaca", DetalleProceso(34))
                        .Parameters.AddWithValue("codsello", DetalleProceso(35))
                        .Parameters.AddWithValue("incourier", DetalleProceso(36))

                        .CommandText = "agregarDetalleProceso"
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
            Result.ErrorMessage = ex.Message
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function ModificarDetalleProcesoMovientoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() {.indice, .IdDetalleProceso, .idElemento}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("indice", req.myDetalleProcesoItem.indice)
                    .Parameters.AddWithValue("idProceso", req.myDetalleProcesoItem.IdDetalleProceso)
                    .Parameters.AddWithValue("idElemento", req.myDetalleProcesoItem.idElemento)
                    .Parameters.AddWithValue("UsusarioUpdate", req.myDetalleProcesoItem.UsusarioIngreso)
                    .CommandText = "modificarDetalleProcesoMovimientoPorIndice"
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

    Public Shared Function modificarPesoDescargaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim ElementoProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoProcesoItem
                    ElementoProceso = New Object() {.IdProceso, .idElemento, .fechaDescarga, .pesoDescarga}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id", ElementoProceso(0))
                    .Parameters.AddWithValue("idElemento", ElementoProceso(1))
                    .Parameters.AddWithValue("fechaDescarga", ElementoProceso(2))
                    .Parameters.AddWithValue("pesoDescarga", ElementoProceso(3))
                    .CommandText = "modificarPesoDescargaElementoProcesoPorIdProcesoElemento"
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

    Public Shared Function modificarPesoCapturaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim ElementoProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoProcesoItem
                    ElementoProceso = New Object() {.IdProceso, .idElemento, .fechaUltimoPesoCaptura, .pesoCaptura}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id", ElementoProceso(0))
                    .Parameters.AddWithValue("idElemento", ElementoProceso(1))
                    .Parameters.AddWithValue("fechaUltimoPesoCaptura", ElementoProceso(2))
                    .Parameters.AddWithValue("pesoCaptura", ElementoProceso(3))
                    .CommandText = "modificarPesoCapturaElementoProcesoPorIdProcesoElemento"
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

    Public Shared Function modificarpesoCargaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim ElementoProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoProcesoItem
                    ElementoProceso = New Object() {.IdProceso, .idElemento, .fechaCarga, .pesoCarga}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id", ElementoProceso(0))
                    .Parameters.AddWithValue("idElemento", ElementoProceso(1))
                    .Parameters.AddWithValue("fechaCarga", ElementoProceso(2))
                    .Parameters.AddWithValue("pesoCarga", ElementoProceso(3))
                    .CommandText = "modificarpesoCargaElementoProcesoPorIdProcesoElemento"
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

    Public Shared Function ModificarEstadoSenaeDetalleProcesoCarga(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() {.indice, .estadoSenae}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleProcesoItem.indice)
                    .Parameters.AddWithValue("estado", req.myDetalleProcesoItem.estadoSenae)
                    .CommandText = "modificarEstadoSenaeDetalleProcesoCarga"
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

   
    Public Shared Function ModificarEstadoElementoProcesoPorIndice(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
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
                    .Parameters.AddWithValue("indice", req.myElementoProcesoItem.indice)
                    .Parameters.AddWithValue("estado", req.myElementoProcesoItem.estado)
                    .Parameters.AddWithValue("usuario", req.myElementoProcesoItem.usuarioComparacionPeso)
                    .Parameters.AddWithValue("pesoDiferencia", req.myElementoProcesoItem.pesoDiferencia)
                    .Parameters.AddWithValue("pesoCarga", req.myElementoProcesoItem.pesoCarga)
                    .Parameters.AddWithValue("pesoCaptura", req.myElementoProcesoItem.pesoCaptura)
                    .Parameters.AddWithValue("Red", req.myElementoProcesoItem.Red)
                    .CommandText = "modificarEstadoElementoProcesoPorIndice"
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

    Public Shared Function ModificarEstadoDetalleProcesoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() {.indice, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("indice", req.myDetalleProcesoItem.indice)
                    .Parameters.AddWithValue("estado", req.myDetalleProcesoItem.estado)
                    .Parameters.AddWithValue("UsusarioIngreso", req.myDetalleProcesoItem.UsusarioIngreso)
                    .CommandText = "modificarEstadoDetalleProcesoPorIndice"
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

    Public Shared Function ModificarEstadoDetalleProcesoPorfechaYGuia(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() {.indice, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("idGuia", req.myDetalleProcesoItem.idGuia)
                    .Parameters.AddWithValue("fecha", req.myDetalleProcesoItem.fecha)
                    .Parameters.AddWithValue("estado", req.myDetalleProcesoItem.estado)
                    .Parameters.AddWithValue("UsusarioIngreso", req.myDetalleProcesoItem.UsusarioIngreso)
                    .CommandText = "modificarEstadoDetalleProcesoPorfechaYGuia"
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

    Public Shared Function ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleProcesoItem
                    DetalleProceso = New Object() {.indice, .IdDetalleProceso, .idElemento}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("indice", req.myDetalleProcesoItem.indice)
                    .Parameters.AddWithValue("idProceso", req.myDetalleProcesoItem.IdDetalleProceso)
                    .Parameters.AddWithValue("idElemento", req.myDetalleProcesoItem.idElemento)
                    .Parameters.AddWithValue("UsusarioUpdate", req.myDetalleProcesoItem.UsusarioIngreso)
                    .CommandText = "modificarDetalleProcesoMovimientoPorIndiceOtroVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .CommandTimeout = 600
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

    'Public Shared Function GetProcesoPorIdVuelo(req As ProcesoRequest) As ProcesoResponse
    '    Dim Result As New ProcesoResponse
    '    Dim dbTran As Database
    '    Dim cmd As New MySqlCommand
    '    Try

    '        If ValidateSession(req) Then
    '            dbTran = MyDbFactory.CreateDatabase("TranDB")
    '            'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
    '            With cmd
    '                .Parameters.AddWithValue("Id", req.myProcesoItem.IdVuelo)
    '                .CommandText = "ObtenerProcesoPorIdVuelo"
    '                .CommandType = CommandType.StoredProcedure
    '                .Connection = dbTran.CreateConnection
    '                .Connection.Open()
    '            End With
    '            Result.DsResult = New DataSet
    '            Result.dsResult.Tables.Add(New DataTable("dtProceso"))
    '            Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
    '            cmd.Connection.Close()
    '        End If
    '    Catch ex As Exception
    '        SetLogEvent(ex, Result, req)
    '    Finally
    '        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
    '    End Try
    '    Return Result
    'End Function

    Public Shared Function GetProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtProceso As ProcesoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "ObtenerProcesoPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtProceso = New ProcesoItem
                    With myDtProceso
                        .IdProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .idAvion = drReader.GetValue(drReader.GetOrdinal("idAvion"))
                        .totalBultos = drReader.GetValue(drReader.GetOrdinal("totalBultos"))
                        .totalPiezas = drReader.GetValue(drReader.GetOrdinal("totalPiezas"))
                        .totalPeso = drReader.GetValue(drReader.GetOrdinal("totalPeso"))
                        .fechaInicio = drReader.GetValue(drReader.GetOrdinal("fechaInicioProceso"))
                        .fechaFin = drReader.GetValue(drReader.GetOrdinal("fechaFinProceso"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myProcesoItem = myDtProceso
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

    Public Shared Function GetNovedadesPorIdProceso(req As NovedadesRequest) As NovedadesResponse
        Dim Result As New NovedadesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtNovedades As NovedadesItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myNovedadesItem.idProceso)
                    .CommandText = "obtenerNovedadesVueloPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtNovedades = New NovedadesItem
                    With myDtNovedades
                        .idProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .llegada = drReader.GetValue(drReader.GetOrdinal("llegada"))
                        .salida = drReader.GetValue(drReader.GetOrdinal("salida"))
                        .subeDesde = drReader.GetValue(drReader.GetOrdinal("subeDesde"))
                        .subeHasta = drReader.GetValue(drReader.GetOrdinal("subeHasta"))
                        .observacion = drReader.GetValue(drReader.GetOrdinal("observacion"))
                    End With
                    Result.myNovedadesItem = myDtNovedades
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

    Public Shared Function GetElementoProcesoPorIndice(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtElementoProceso As ElementoProcesoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Indice", req.myElementoProcesoItem.indice)
                    .CommandText = "ObtenerElementoProcesoPorIndice"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtElementoProceso = New ElementoProcesoItem
                    With myDtElementoProceso
                        .IdProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                        .pesoReferencialElemento = drReader.GetValue(drReader.GetOrdinal("pesoReferencialElemento"))
                        .pesoEntradaElemento = drReader.GetValue(drReader.GetOrdinal("pesoEntradaElemento"))
                        .pesoCarga = drReader.GetValue(drReader.GetOrdinal("pesoCarga"))
                        .pesoDiferencia = drReader.GetValue(drReader.GetOrdinal("pesoDiferencia"))
                        .indice = drReader.GetValue(drReader.GetOrdinal("indice"))
                    End With
                    Result.myElementoProcesoItem = myDtElementoProceso
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

    Public Shared Function GetProcesoPorIdBriefing(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtProceso As ProcesoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.idBriefing)
                    .CommandText = "ObtenerProcesoPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtProceso = New ProcesoItem
                    With myDtProceso
                        .IdProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .idAvion = drReader.GetValue(drReader.GetOrdinal("idAvion"))
                        .totalBultos = drReader.GetValue(drReader.GetOrdinal("totalBultos"))
                        .totalPiezas = drReader.GetValue(drReader.GetOrdinal("totalPiezas"))
                        .totalPeso = drReader.GetValue(drReader.GetOrdinal("totalPeso"))
                        .fechaInicio = drReader.GetValue(drReader.GetOrdinal("fechaInicioProceso"))
                        .fechaFin = drReader.GetValue(drReader.GetOrdinal("fechaFinProceso"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myProcesoItem = myDtProceso
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


    Public Shared Function Getdetalleprocesocargaporidbriefingidguia(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand

        Dim myDtProceso As DetalleProcesoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idBriefing", req.myProcesoItem.idBriefing)
                    .Parameters.AddWithValue("idGuia", req.myDetalleProcesoItem.idGuia)
                    .CommandText = "obtenerdetalleprocesocargaporidbriefingidguia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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




    Public Shared Function GetDetalleProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    '.CommandText = "obtenerDetalleProcesoPorIdProceso"
                    .CommandText = "obtenerDetalleProcesoPorIdProceso2" 'pruebas
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetDetalleProcesoPorIdProcesoDev(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    '.CommandText = "obtenerDetalleProcesoPorIdProcesoDev"
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoDev2" 'pruebas
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoDev"))
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

    Public Shared Function GetInfoProcesoPorIdAgenciaYFecha(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    If req.codigoVuelo = "F" Then 'MARZ
                        .Parameters.AddWithValue("idAgencia", req.PcId)
                        .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                        .Parameters.AddWithValue("fechaFin", req.fechaFin)
                        .CommandText = "obtenerInfoProcesoPorIdAgenciaYFecha2"
                    Else
                        .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                        .Parameters.AddWithValue("fechaFin", req.fechaFin)
                        .CommandText = "obtenerInfoProcesoPorFecha"
                    End If
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .CommandTimeout = 3 * 60
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetInfoDetalleProcesoPorIdAgenciaYFecha(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    .Parameters.AddWithValue("codigoVuelo", req.codigoVuelo)
                    .CommandText = "obtenerInfoDetalleProcesoPorIdAgenciaYFecha"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProduccion"))
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

    Public Shared Function GetDetalleProcesoDecomisoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoDecomisoPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoDecomiso"))
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

    Public Shared Function GetDetalleProcesoPorIdProcesoCaptura(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoCaptura"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetTotalPorGuiaPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerTotalPorGuiaPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtTotalPorGuia"))
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

    Public Shared Function GetTotalPorGuiaPorIdProcesoDev(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerTotalPorGuiaPorIdProcesoDev"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtTotalPorGuiaDev"))
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

    Public Shared Function GetTotalPorElementoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerTotalPorElementoPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtTotalPorElemento"))
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

    Public Shared Function GetTotalPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerTotalPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtTotalPorIdProceso"))
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

    Public Shared Function GetNextSecuencialSenae(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    '.Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerSecuencialSenae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("nextSeq"))
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

    Public Shared Function GetDetalleProcesoPorIdProceso2(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProceso2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetDetalleProcesoPorIdProcesoCargaI(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoCargaI"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoCargaI"))
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

    Public Shared Function GetDetalleProcesoPorIdProcesoCargaR(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoCargaR"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoCargaR"))
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

    Public Shared Function GetDetalleProcesoPorIdGuia(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .Parameters.AddWithValue("idGuia", req.prmArr(0))
                    .CommandText = "obtenerDetalleProcesoPorIdGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetDetalleProcesoPorIdElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .Parameters.AddWithValue("idElemento", req.prmArr(0))
                    .CommandText = "obtenerDetalleProcesoPorIdElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProceso"))
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

    Public Shared Function GetCargaDevueltaPorIdProcesoGroupElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerCargaDevueltaPorIdProcesoGroupElemento"
                    .Parameters.AddWithValue("idElemento", req.prmArr(0))
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtCargaDevueltaPorElemento"))
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

    Public Shared Function GetCargaDevueltaPorIdProcesoGroupGuia(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .Parameters.AddWithValue("idGuia", req.prmArr(0))
                    .CommandText = "obtenerCargaDevueltaPorIdProcesoGroupGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtCargaDevueltaPorGuia"))
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

    Public Shared Function GetDetalleProcesoPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoReporte"))
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

    Public Shared Function GetSubtotalCargaProcesadaPorDia(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("fecha", req.myProcesoItem.fechaInicio)
                    .CommandText = "obtenerSubtotalCargaProcesadaPorDia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtSubTotalCargaProcesadaPorDia"))
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

    Public Shared Function GetSubtotalCargaProcesadaPorMes(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("fecha", req.myProcesoItem.fechaInicio)
                    .CommandText = "obtenerSubtotalCargaProcesadaPorMes"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtSubTotalCargaProcesadaPorMes"))
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

    Public Shared Function GetSubtotalCargaProcesadaPorAño(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("fecha", req.myProcesoItem.fechaInicio)
                    .CommandText = "obtenerSubtotalCargaProcesadaPorAño"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtSubTotalCargaProcesadaPorAño"))
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

    Public Shared Function GetDetalleProcesoCargaPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoCargaPorIdProcesoReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoCargaReporte"))
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

    Public Shared Function GetDetalleProcesoCargaPorIdProcesoAlmacenaje(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoCargaPorIdProcesoAlmacenaje"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoCargaAlmacenaje"))
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

    Public Shared Function GetDetalleAcarreoPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleAcarreoReportePorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleAcarreoReporte"))
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

    Public Shared Function GetDetallePersonalPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetallePersonalPorIdProcesoReporte"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetallePersonalReporte"))
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

    Public Shared Function GetElementoProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoProcesoItem.IdProceso)
                    .CommandText = "obtenerElementoProcesoPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtElementoProceso"))
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

    Public Shared Function GetElementoProcesoPorIdProcesoYEstado(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoProcesoItem.IdProceso)
                    .CommandText = "obtenerElementoProcesoPorIdProcesoYEstado"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtElementoProcesoPorEstado"))
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

    Public Shared Function GetElementoProcesoPorIdProcesoIdElemento(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoProcesoItem.IdProceso)
                    .Parameters.AddWithValue("idElemento", req.myElementoProcesoItem.idElemento)
                    .CommandText = "obtenerElementoProcesoPorIdProcesoIdElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtElementoProceso"))
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

    Public Shared Function DeleteDetalleProcesoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Dim Result As New DetalleProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("indice", req.myDetalleProcesoItem.indice)
                    .Parameters.AddWithValue("UsusarioUpdate", req.UserId)
                    .CommandText = "eliminarDetalleProcesoPorIndice"
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

    Public Shared Function DeleteDetalleProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .Parameters.AddWithValue("UsusarioUpdate", req.UserId)
                    .CommandText = "eliminarDetalleProcesoPorId"
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

    'Public Shared Function GetDetalleProcesoPorIdProceso(req As DetalleProcesoRequest) As DetalleProcesoResponse
    '    Dim Result As New DetalleProcesoResponse
    '    Dim dbTran As Database
    '    Dim cmd As New MySqlCommand
    '    Dim drReader As MySqlDataReader
    '    Dim myDtDetalleProceso As DetalleProcesoItem
    '    Try
    '        If ValidateSession(req) Then
    '            dbTran = MyDbFactory.CreateDatabase("TranDB")
    '            'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
    '            With cmd
    '                .Parameters.AddWithValue("idProceso", req.myDetalleProcesoItem.IdDetalleProceso)
    '                .Parameters.AddWithValue("fecha", req.myDetalleProcesoItem.fecha)
    '                .Parameters.AddWithValue("idGuia", req.myDetalleProcesoItem.idGuia)
    '                .CommandText = "ObtenerDetalleProcesoPorId"
    '                .CommandType = CommandType.StoredProcedure
    '                .Connection = dbTran.CreateConnection
    '                .Connection.Open()
    '            End With
    '            drReader = cmd.ExecuteReader()
    '            If drReader.Read Then
    '                myDtDetalleProceso = New DetalleProcesoItem
    '                With myDtDetalleProceso
    '                    .IdDetalleProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
    '                    .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
    '                    .idGuia = drReader.GetValue(drReader.GetOrdinal("idGuia"))
    '                    .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
    '                    .agenciaTransporte = drReader.GetValue(drReader.GetOrdinal("agenciaTransporte"))
    '                    .bultos = drReader.GetValue(drReader.GetOrdinal("bultos"))
    '                    .peso = drReader.GetValue(drReader.GetOrdinal("peso"))
    '                    .piezas = drReader.GetValue(drReader.GetOrdinal("piezas"))
    '                    .volumen = drReader.GetValue(drReader.GetOrdinal("volumen"))
    '                    .hora = drReader.GetValue(drReader.GetOrdinal("hora"))
    '                    .idProducto = drReader.GetValue(drReader.GetOrdinal("idProducto"))
    '                    .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
    '                    .idPosicion = drReader.GetValue(drReader.GetOrdinal("idPosicion"))
    '                    .temperatura = drReader.GetValue(drReader.GetOrdinal("temperatura"))
    '                    .rx = drReader.GetValue(drReader.GetOrdinal("rx"))
    '                    .man = drReader.GetValue(drReader.GetOrdinal("man"))
    '                    .k9 = drReader.GetValue(drReader.GetOrdinal("k9"))
    '                    .eds = drReader.GetValue(drReader.GetOrdinal("eds"))
    '                    .largo = drReader.GetValue(drReader.GetOrdinal("largo"))
    '                    .ancho = drReader.GetValue(drReader.GetOrdinal("ancho"))
    '                    .alto = drReader.GetValue(drReader.GetOrdinal("alto"))
    '                    .tempA = drReader.GetValue(drReader.GetOrdinal("tempA"))
    '                    .tempB = drReader.GetValue(drReader.GetOrdinal("tempB"))
    '                    .tempC = drReader.GetValue(drReader.GetOrdinal("tempC"))
    '                    .idCamion = drReader.GetValue(drReader.GetOrdinal("idCamion"))
    '                    .muelle = drReader.GetValue(drReader.GetOrdinal("muelle"))
    '                End With
    '                Result.myDetalleProcesoItem = myDtDetalleProceso
    '            End If
    '            cmd.Connection.Close()
    '        End If
    '    Catch ex As Exception
    '        SetLogEvent(ex, Result, req)
    '    Finally
    '        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
    '    End Try
    '    Return Result
    'End Function

    'MARZ
    Public Shared Function GetProductionAgenciaDescription(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("agencia", req.id)
                    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    .CommandText = "obtenerProductionAgenciaDescription"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Production"))
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
    Public Shared Function GetDetalleProcesoDecomisoDaePorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerDetalleProcesoDecomisoDaePorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoDecomiso"))
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
    Public Shared Function GetDetalleMatrizSeguridadDecoporIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "Sp_MatrizSeguridadDecomiso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleProcesoDecomiso"))
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

#Region "Procesamiento Courrier"

    Public Shared Function SaveDetalleSellosCamiones(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Dim result As New DetalleSelloCamionesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand

        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleSelloCamiones.indice_sellos)
                    .CommandText = "CheckExistsDetalleSellosCamiones"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With

                If Not CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("indice_sellos", req.myDetalleSelloCamiones.indice_sellos)
                        .Parameters.AddWithValue("idGuia", req.myDetalleSelloCamiones.idGuia)
                        .Parameters.AddWithValue("idCamion", req.myDetalleSelloCamiones.idCamion)
                        .Parameters.AddWithValue("idBriefing", req.myDetalleSelloCamiones.idBriefing)
                        .Parameters.AddWithValue("nu_sello", req.myDetalleSelloCamiones.numSello)
                        .Parameters.AddWithValue("fecha", req.myDetalleSelloCamiones.fecha)
                        .Parameters.AddWithValue("descripcion", req.myDetalleSelloCamiones.descripcion)

                        .CommandText = "agregardetalleselloscamiones"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    cmd.Connection.Close()
                Else

                    With cmd2
                        .Parameters.AddWithValue("id", req.myDetalleSelloCamiones.indice_sellos)
                        .Parameters.AddWithValue("idGuia", req.myDetalleSelloCamiones.idGuia)
                        .Parameters.AddWithValue("idCamion", req.myDetalleSelloCamiones.idCamion)
                        .Parameters.AddWithValue("idBriefing", req.myDetalleSelloCamiones.idBriefing)
                        .Parameters.AddWithValue("nusello", req.myDetalleSelloCamiones.numSello)
                        .Parameters.AddWithValue("fecha", req.myDetalleSelloCamiones.fecha)
                        .Parameters.AddWithValue("descripcion", req.myDetalleSelloCamiones.descripcion)

                        .CommandText = "modificardetalleselloscamiones"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    cmd.Connection.Close()

                End If
            End If
        Catch ex As Exception
            SetLogEvent(ex, result, req)
            result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        End Try

        Return result

    End Function

    Public Shared Function DeleteDetalleSellosCamiones(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Dim result As New DetalleSelloCamionesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand

        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleSelloCamiones.indice_sellos)
                    .CommandText = "CheckExistsDetalleSellosCamiones"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With

                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("id", req.myDetalleSelloCamiones.indice_sellos)
                        .CommandText = "eliminardetalleselloscamiones"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    cmd.Connection.Close()
                End If
            End If
        Catch ex As Exception
            SetLogEvent(ex, result, req)
            result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection IsNot Nothing Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
        End Try

        Return result

    End Function


    Public Shared Function GetDetalleSellosCamionesporidguiacamion(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Dim Result As New DetalleSelloCamionesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idguia", req.myDetalleSelloCamiones.idGuia)
                    .Parameters.AddWithValue("idcamion", req.myDetalleSelloCamiones.idCamion)
                    .CommandText = "obtenerdetalleselloscamionesporidguiacamion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtdetalleselloscamionesporidguiacamion"))
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
    Public Shared Function GetDetalleSellosCamionesporidguia(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Dim Result As New DetalleSelloCamionesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idguia", req.myDetalleSelloCamiones.idGuia)
                    .Parameters.AddWithValue("idBriefing", req.myDetalleSelloCamiones.idBriefing)
                    .CommandText = "obtenerdetalleselloscamionesporidguia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtdetalleselloscamionesporidguiacamion"))
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





#End Region

    Public Shared Function MovimientoPorGuia(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim DetalleProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myMovimiento
                    DetalleProceso = New Object() { .Indice, .IdProceso, .IdElemento, .IdElementoDescarga, .Peso, .Usuario, .Fecha, .mismoVuelo}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id_Indice", req.myMovimiento.Indice)
                    .Parameters.AddWithValue("Id_Proceso", req.myMovimiento.IdProceso)
                    .Parameters.AddWithValue("Id_Elemento", req.myMovimiento.IdElemento)
                    .Parameters.AddWithValue("ususario_Update", req.myMovimiento.Usuario)
                    .Parameters.AddWithValue("Id_ElementoDescarga", req.myMovimiento.IdElementoDescarga)
                    .Parameters.AddWithValue("fecha", req.myMovimiento.Fecha)
                    .Parameters.AddWithValue("peso", req.myMovimiento.Peso)
                    .Parameters.AddWithValue("mismoVuelo", req.myMovimiento.mismoVuelo)
                    .CommandText = "modificarMovimientoGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With

                cmd.Connection.Close()
            End If
            Result.ActionResult = True
        Catch ex As Exception
            Result.ActionResult = False
            Result.ErrorMessage = ex.Message
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
