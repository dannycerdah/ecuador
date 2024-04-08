Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class GuiaManager

    Public Shared Function DeleteGuiaCamion(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("indice", req.myGuiaCamionesItem.indice)
                    .CommandText = "eliminarGuiaCamionPorIndice"
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

    Public Shared Function DeleteGuiaDae(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaDaesItem.idGuia)
                    .Parameters.AddWithValue("Daes", req.myGuiaDaesItem.dae)
                    .CommandText = "eliminarDetalleGuiaDaesPorIdGuiaDae"
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

    Public Shared Function DeleteDetalleGuiaProducto(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "eliminarDetalleGuiaProductoPorIdGuia"
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

    Public Shared Function DeleteDetalleGuiaCamiones(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "eliminarDetalleGuiaCamionesPorIdGuia"
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

    Public Shared Function DeleteGuiaItem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "eliminarGuiaPorId"
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

    Public Shared Function SaveGuiaItem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Guia As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaItem
                    Guia = New Object() {.Id, .Descripcion, .idBriefing, .idCiudad, .IdAgencia, .Peso, .Bultos, .FechaLlegada, .Estado, .DAE, .FechaAct, .usuarioAct, .Rutas}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "CheckExistsGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Guia(0))
                        .Parameters.AddWithValue("descripcion", Guia(1))
                        .Parameters.AddWithValue("idBriefing", Guia(2))
                        .Parameters.AddWithValue("ciudad", Guia(3))
                        .Parameters.AddWithValue("idAgencia", Guia(4))
                        .Parameters.AddWithValue("peso", Guia(5))
                        .Parameters.AddWithValue("bultos", Guia(6))
                        .Parameters.AddWithValue("fechaLlegada", Guia(7))
                        .Parameters.AddWithValue("estado", Guia(8))
                        .Parameters.AddWithValue("DAE", Guia(9))
                        .Parameters.AddWithValue("fechaAct", Guia(10))
                        .Parameters.AddWithValue("usuarioAct", Guia(11))
                        .Parameters.AddWithValue("Rutas", Guia(12))
                        .CommandText = "modificarGuia"
                        '.CommandText = "modificarGuia2" 'eliminar despues de los 3 dias de revision 
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Guia(0))
                        .Parameters.AddWithValue("descripcion", Guia(1))
                        .Parameters.AddWithValue("idBriefing", Guia(2))
                        .Parameters.AddWithValue("ciudad", Guia(3))
                        .Parameters.AddWithValue("idAgencia", Guia(4))
                        .Parameters.AddWithValue("peso", Guia(5))
                        .Parameters.AddWithValue("bultos", Guia(6))
                        .Parameters.AddWithValue("fechaLlegada", Guia(7))
                        .Parameters.AddWithValue("estado", Guia(8))
                        .Parameters.AddWithValue("DAE", Guia(9))
                        .Parameters.AddWithValue("fechaAct", Guia(10))
                        .Parameters.AddWithValue("usuarioAct", Guia(11))
                        .Parameters.AddWithValue("Rutas", Guia(12))
                        .CommandText = "agregarGuia"
                        '.CommandText = "agregarGuia2" 'eliminar despues de los 3 dias de revision 
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
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function ModificarEstadoReporteGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Guia As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaItem
                    Guia = New Object() {.Id, .estadoReporte}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Guia(0))
                    .Parameters.AddWithValue("estadoReporte", Guia(1))
                    .CommandText = "modificarEstadoReporteGuiaPorIdGuia"
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

    Public Shared Function SaveGuiaProductosItem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim GuiaProductos As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaProductoItem
                    GuiaProductos = New Object() {.idGuia, .idProducto}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaProductoItem.idGuia)
                    .Parameters.AddWithValue("idProducto", req.myGuiaProductoItem.idProducto)
                    .CommandText = "CheckExistsGuiaProducto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", GuiaProductos(0))
                        .Parameters.AddWithValue("idProducto", GuiaProductos(1))
                        .CommandText = "modificarDetalleGuiaProductos"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", GuiaProductos(0))
                        .Parameters.AddWithValue("idProducto", GuiaProductos(1))
                        .CommandText = "agregarDetalleGuiaProductos"
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

    Public Shared Function SaveGuiaCamionesItem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim GuiaCamiones As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaCamionesItem
                    GuiaCamiones = New Object() {.idGuia, .idCamion, .fecha, .idContacto, .procedencia, .temperatura, .presinto, .bultos, .idBriefing, .idTipoEnvase, .idMaterialEnvase}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idGuia", GuiaCamiones(0))
                    .Parameters.AddWithValue("idCamion", GuiaCamiones(1))
                    .Parameters.AddWithValue("fecha", GuiaCamiones(2))
                    .Parameters.AddWithValue("idContacto", GuiaCamiones(3))
                    .Parameters.AddWithValue("procedencia", GuiaCamiones(4))
                    .Parameters.AddWithValue("temperatura", GuiaCamiones(5))
                    .Parameters.AddWithValue("presinto", GuiaCamiones(6))
                    .Parameters.AddWithValue("bultos", GuiaCamiones(7))
                    .Parameters.AddWithValue("idBriefing", GuiaCamiones(8))
                    .Parameters.AddWithValue("idTipoEnvase", GuiaCamiones(9))
                    .Parameters.AddWithValue("idMaterialEnvase", GuiaCamiones(10))
                    .CommandText = "agregarDetalleGuiaCamiones"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
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

    Public Shared Function SaveGuiaDaesItem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim GuiaCamiones As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaDaesItem
                    GuiaCamiones = New Object() {.idGuia, .dae, .fecha, .estado, .usuarioCreacion, .NumRem, .fechavigenciaRem}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idGuia", GuiaCamiones(0))
                    .Parameters.AddWithValue("dae", GuiaCamiones(1))
                    .Parameters.AddWithValue("fecha", GuiaCamiones(2))
                    .Parameters.AddWithValue("estado", GuiaCamiones(3))
                    .Parameters.AddWithValue("usuarioCreacion", GuiaCamiones(4))
                    .Parameters.AddWithValue("NumRem", GuiaCamiones(5))
                    .Parameters.AddWithValue("fechavigenciaRem", GuiaCamiones(6))
                    .CommandText = "agregarDetalleGuiaDaes"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
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

    Public Shared Function GetGuiaPorIdBriefing(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.idBriefing)
                    .CommandText = "ObtenerGuiaPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtGuia"))
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

    Public Shared Function GetGuiaProductosPorIdGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaProductoItem.idGuia)
                    .CommandText = "ObtenerDetalleGuiaProductosPorIdGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsGuiaProductos = New DataSet
                Result.dsGuiaProductos.Tables.Add(New DataTable("dtGuiaProductos"))
                Result.dsGuiaProductos.Tables(0).Load(cmd.ExecuteReader())
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

    Public Shared Function GetGuiaCamionesPorId(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idGuia", req.myGuiaCamionesItem.idGuia)
                    .Parameters.AddWithValue("fecha", req.myGuiaCamionesItem.fecha)
                    .CommandText = "ObtenerDetalleGuiaCamionesPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsGuiaCamiones = New DataSet
                Result.dsGuiaCamiones.Tables.Add(New DataTable("dtGuiaCamiones"))
                Result.dsGuiaCamiones.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoEnvase(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .CommandText = "obtenerTipoEnvase"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsTipoEnvase = New DataSet
                Result.dsTipoEnvase.Tables.Add(New DataTable("dtTipoEnvase"))
                Result.dsTipoEnvase.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetMaterialEnvase(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .CommandText = "obtenerMaterialEnvase"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsMaterialEnvase = New DataSet
                Result.dsMaterialEnvase.Tables.Add(New DataTable("dtMaterialEnvase"))
                Result.dsMaterialEnvase.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetValidezDaePorDae(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myValidezDae As ValidezDae
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("numeroDae", req.myValidezDae.numeroDae)
                    .CommandText = "obtenerValidezDaePorDae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myValidezDae = New ValidezDae
                    With myValidezDae
                        .numeroDae = drReader.GetValue(drReader.GetOrdinal("numeroDae"))
                        .exporterDocumentId = drReader.GetValue(drReader.GetOrdinal("exporterDocumentId"))
                        .exporterName = drReader.GetValue(drReader.GetOrdinal("exporterName"))
                        .declarationOffice = drReader.GetValue(drReader.GetOrdinal("declarationOffice"))
                        .declarationId = drReader.GetValue(drReader.GetOrdinal("declarationId"))
                        .examinerName = drReader.GetValue(drReader.GetOrdinal("examinerName"))
                        .fechaIni = drReader.GetValue(drReader.GetOrdinal("fechaIni"))
                        .fechaFin = drReader.GetValue(drReader.GetOrdinal("fechaFin"))
                        .responseId = drReader.GetValue(drReader.GetOrdinal("responseId"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .NumRem = If(IsDBNull(drReader.GetValue(drReader.GetOrdinal("NumRem"))), Nothing, drReader.GetValue(drReader.GetOrdinal("NumRem")))
                        .fechavigenciaRem = If(IsDBNull(drReader.GetValue(drReader.GetOrdinal("fechavigenciaRem"))), Nothing, drReader.GetValue(drReader.GetOrdinal("fechavigenciaRem")))
                    End With
                    Result.myValidezDae = myValidezDae
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoEnvasePorId(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTipoEnvase As TipoEnvaseItem
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myTipoEnvase.Id)
                    .CommandText = "obtenerTipoEnvasePorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTipoEnvase = New TipoEnvaseItem
                    With myTipoEnvase
                        .Id = drReader.GetValue(drReader.GetOrdinal("idTipo"))
                        .Descripcion = drReader.GetValue(drReader.GetOrdinal("descripcionTipo"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myTipoEnvase = myTipoEnvase
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetMaterialEnvasePorId(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTipoEnvase As TipoEnvaseItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myMaterialEnvase.Id)
                    .CommandText = "obtenerMaterialEnvasePorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTipoEnvase = New TipoEnvaseItem
                    With myTipoEnvase
                        .Id = drReader.GetValue(drReader.GetOrdinal("idMaterial"))
                        .Descripcion = drReader.GetValue(drReader.GetOrdinal("descripcionMaterial"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myTipoEnvase = myTipoEnvase
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetEstadoReporteGuiaPorIdGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myGuia As GuiaItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "obtenerEstadoReporteGuiaPorIdGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myGuia = New GuiaItem
                    With myGuia
                        .Id = drReader.GetValue(drReader.GetOrdinal("idGuia"))
                        .estadoReporte = drReader.GetValue(drReader.GetOrdinal("estadoReporte"))
                    End With
                    Result.myGuiaItem = myGuia
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaCamionesPorIdGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idGuia", req.myGuiaCamionesItem.idGuia)
                    .Parameters.AddWithValue("idBriefing", req.myGuiaCamionesItem.idBriefing)
                    .CommandText = "ObtenerDetalleGuiaCamionesPorIdGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsGuiaCamiones = New DataSet
                Result.dsGuiaCamiones.Tables.Add(New DataTable("dtGuiaCamiones"))
                Result.dsGuiaCamiones.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaDaesPorIdGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idGuia", req.myGuiaDaesItem.idGuia)
                    .CommandText = "obtenerDetalleGuiaDaesPorIdGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsGuiaCamiones = New DataSet
                Result.dsGuiaCamiones.Tables.Add(New DataTable("dtGuiaDaes"))
                Result.dsGuiaCamiones.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaPorIdGuia(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtGuia As GuiaItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myGuiaItem.Id)
                    .CommandText = "ObtenerGuiaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtGuia = New GuiaItem
                    With myDtGuia
                        .Id = drReader.GetValue(drReader.GetOrdinal("idGuia"))
                        .Descripcion = drReader.GetValue(drReader.GetOrdinal("descripcion"))
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .idCiudad = drReader.GetValue(drReader.GetOrdinal("idCiudad"))
                        .ciudadDestino = drReader.GetValue(drReader.GetOrdinal("ciudadDestino"))
                        .IdAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .DescripcionAgencia = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .Peso = drReader.GetValue(drReader.GetOrdinal("peso"))
                        .Bultos = drReader.GetValue(drReader.GetOrdinal("bultos"))
                        .FechaLlegada = drReader.GetValue(drReader.GetOrdinal("fechaLlegada"))
                        .Estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .DAE = drReader.GetValue(drReader.GetOrdinal("DAE"))
                        .FechaAct = drReader.GetValue(drReader.GetOrdinal("fechaAct"))
                        .usuarioAct = drReader.GetValue(drReader.GetOrdinal("usuarioAct"))
                        .Rutas = drReader.GetValue(drReader.GetOrdinal("rutas"))
                    End With
                    Result.myGuiaItem = myDtGuia
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_28.09.17
    Public Shared Function GetVuelosGuiasToday(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try

            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerGuiasAerolineasToday"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsGuiasAerolineas = New DataSet
                Result.dsGuiasAerolineas.Tables.Add(New DataTable("VuelosProcesos"))
                Result.dsGuiasAerolineas.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            Result.ActionResult = False
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function SaveHistoricoDaesRem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim GuiaCamiones As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaDaesItem
                    GuiaCamiones = New Object() {.dae, .NumRem, .fechavigenciaRem, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("dae", GuiaCamiones(0))
                    .Parameters.AddWithValue("NumRem", GuiaCamiones(1))
                    .Parameters.AddWithValue("fechavigenciaRem", If(IsNothing(GuiaCamiones(2)), Nothing, GuiaCamiones(2)))
                    .Parameters.AddWithValue("EstadoAforo", GuiaCamiones(3))
                    .CommandText = "SpAgregaHistoricoDaeRem"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
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
    Public Shared Function DeleteHistoricoDaesRem(req As GuiaRequest) As GuiaResponse
        Dim Result As New GuiaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim GuiaCamiones As Object()
        Try
            If ValidateSession(req) Then
                With req.myGuiaDaesItem
                    GuiaCamiones = New Object() {.dae, .NumRem}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("dae", GuiaCamiones(0))
                    .Parameters.AddWithValue("NumRem", GuiaCamiones(1))
                    .CommandText = "SpEliminaHistoricoDaeRem"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
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
End Class
