Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class ElementoManager
    Public Shared Function GetEntireElementoCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerElementos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoItemById(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myElemento As ElementoCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoItem.Id)
                    .CommandText = "ObtenerElementoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myElemento = New ElementoCatalogItem
                    With myElemento
                        .Id = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .IdAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .descripcionAgencia = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .tipoElemento = drReader.GetValue(drReader.GetOrdinal("tipoElemento"))
                        .materialPiso = drReader.GetValue(drReader.GetOrdinal("materialPiso"))
                        .materialPared = drReader.GetValue(drReader.GetOrdinal("materialPared"))
                        .materialTecho = drReader.GetValue(drReader.GetOrdinal("materialTecho"))
                      '  .materialRed = drReader.GetValue(drReader.GetOrdinal("materialRed"))
                        .materialPuerta = drReader.GetValue(drReader.GetOrdinal("materialPuerta"))
                        .materialSeguros = drReader.GetValue(drReader.GetOrdinal("materialSeguros"))
                        .alto = drReader.GetValue(drReader.GetOrdinal("alto"))
                        .ancho = drReader.GetValue(drReader.GetOrdinal("ancho"))
                        .largo = drReader.GetValue(drReader.GetOrdinal("largo"))
                        .pesoReferencial = drReader.GetValue(drReader.GetOrdinal("pesoReferencial"))
                        .pesoReal = drReader.GetValue(drReader.GetOrdinal("pesoReal"))
                        .pesoActual = drReader.GetValue(drReader.GetOrdinal("pesoActual"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .fechaIngreso = drReader.GetValue(drReader.GetOrdinal("fechaIngreso"))
                        .usuarioIngreso = drReader.GetValue(drReader.GetOrdinal("usuarioIngreso"))
                        .fechaUltimaAct = drReader.GetValue(drReader.GetOrdinal("fechaUltimaAct"))
                        .fechaIngresoPlataforma = drReader.GetValue(drReader.GetOrdinal("fechaIngresoPlataforma"))
                    End With
                    Result.myElementoItem = myElemento
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

    Public Shared Function GetElementosByEstado(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    '.Parameters.AddWithValue("estado", req.myElementoItem.estado)
                    .Parameters.AddWithValue("Id", req.myElementoItem.Id)
                    ' .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementosPorEstado"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoHistoricoPorIdElemento(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idElemento", req.myElementoHistoricoItem.idElemento)
                    .Parameters.AddWithValue("idAgencia", req.myElementoHistoricoItem.idAgencia)
                    .Parameters.AddWithValue("fechaInicio", req.myElementoHistoricoItem.fechaInicio)
                    .Parameters.AddWithValue("fechaFin", req.myElementoHistoricoItem.fechaFin)
                    .Parameters.AddWithValue("ln_chekFecha", req.myElementoHistoricoItem.ln_chekFecha)
                    .CommandText = "obtenerElementoHistoricoPorIdElemento2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ElementoHistorico"))
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


    Public Shared Function GetElementoPorAgenciaYTipo(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .Parameters.AddWithValue("idTipoElemento", req.myElementoItem.tipoElemento)
                    .CommandText = "obtenerElementoPorAgenciaYTipo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPorAgenciaYTipoEnSalida(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .Parameters.AddWithValue("idTipoElemento", req.myElementoItem.tipoElemento)
                    .CommandText = "obtenerElementoPorAgenciaYTipo2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPorAgencia(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoPorAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPreBriefingPorIdBriefing(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoPreBriefingItem.idBriefing)
                    .Parameters.AddWithValue("IdAerolinea", req.myElementoPreBriefingItem.IdAerolinea)
                    .Parameters.AddWithValue("fechaInicio", req.myElementoPreBriefingItem.fechaIncio)
                    .Parameters.AddWithValue("fechaFin", req.myElementoPreBriefingItem.fechaFin)
                    .CommandText = "obtenerElementoPreBriefingPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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


    Public Shared Function GetElementoPorAgenciaStock(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoPorAgenciaStock"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPorAgenciaEnSalida(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoPorAgencia3"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPorAgenciaEnPesaje(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoPorAgencia2"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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

    Public Shared Function GetElementoPorAgenciaEnPreseleccion(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoPorAgenciaPreseleccion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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


    Public Shared Function GetEntireTipoElementoCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerTipoElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("TipoElementos"))
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

    Public Shared Function GetEntireMaterialesCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerMateriales"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Materiales"))
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

    Public Shared Function GetMaterialItemById(req As MaterialesRequest) As MaterialesResponse
        Dim Result As New MaterialesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myMaterial As MaterialesItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myMaterial.idMaterial)
                    .CommandText = "ObtenerMaterialPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myMaterial = New MaterialesItem
                    With myMaterial
                        .idMaterial = drReader.GetValue(drReader.GetOrdinal("idMaterial"))
                        .descripcion = drReader.GetValue(drReader.GetOrdinal("descripcion"))

                    End With
                    Result.myMaterialItem = myMaterial
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If Not drReader.IsClosed Then drReader.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveElementoItem(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoItem
                    Elemento = New Object() {.Id, .IdAgencia, .tipoElemento, .materialPiso, .materialPared, .materialTecho,
                                           .materialRed, .materialPuerta, .materialSeguros, .alto, .ancho, .largo,
                                           .pesoReferencial, .pesoReal, .estado, .fechaIngreso, .usuarioIngreso, .fechaUltimaAct, .tempId}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myElementoItem.Id)
                    .CommandText = "CheckExistsElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Elemento(0))
                        .Parameters.AddWithValue("idAgencia", Elemento(1))
                        .Parameters.AddWithValue("tipoElemento", Elemento(2))
                        .Parameters.AddWithValue("materialPiso", Elemento(3))
                        .Parameters.AddWithValue("materialPared", Elemento(4))
                        .Parameters.AddWithValue("materialTecho", Elemento(5))
                        .Parameters.AddWithValue("materialRed", Elemento(6))
                        .Parameters.AddWithValue("materialPuerta", Elemento(7))
                        .Parameters.AddWithValue("materialSeguros", Elemento(8))
                        .Parameters.AddWithValue("alto", Elemento(9))
                        .Parameters.AddWithValue("ancho", Elemento(10))
                        .Parameters.AddWithValue("largo", Elemento(11))
                        .Parameters.AddWithValue("pesoReferencial", Elemento(12))
                        .Parameters.AddWithValue("pesoReal", Elemento(13))
                        .Parameters.AddWithValue("estado", Elemento(14))
                        .Parameters.AddWithValue("fechaIngreso", Elemento(15))
                        .Parameters.AddWithValue("usuarioIngreso", Elemento(16))
                        .Parameters.AddWithValue("fechaUltimaAct", Elemento(17))
                        .Parameters.AddWithValue("tempId", Elemento(18))
                        .CommandText = "modificarElemento"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Elemento(0))
                        .Parameters.AddWithValue("idAgencia", Elemento(1))
                        .Parameters.AddWithValue("tipoElemento", Elemento(2))
                        .Parameters.AddWithValue("materialPiso", Elemento(3))
                        .Parameters.AddWithValue("materialPared", Elemento(4))
                        .Parameters.AddWithValue("materialTecho", Elemento(5))
                        .Parameters.AddWithValue("materialRed", Elemento(6))
                        .Parameters.AddWithValue("materialPuerta", Elemento(7))
                        .Parameters.AddWithValue("materialSeguros", Elemento(8))
                        .Parameters.AddWithValue("alto", Elemento(9))
                        .Parameters.AddWithValue("ancho", Elemento(10))
                        .Parameters.AddWithValue("largo", Elemento(11))
                        .Parameters.AddWithValue("pesoReferencial", Elemento(12))
                        .Parameters.AddWithValue("pesoReal", Elemento(13))
                        .Parameters.AddWithValue("pesoActual", Elemento(13))
                        .Parameters.AddWithValue("estado", Elemento(14))
                        .Parameters.AddWithValue("fechaIngreso", Elemento(15))
                        .Parameters.AddWithValue("usuarioIngreso", Elemento(16))
                        .Parameters.AddWithValue("fechaUltimaAct", Elemento(17))
                        .CommandText = "agregarElemento"
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

    Public Shared Function SavePesoElemento(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoItem
                    Elemento = New Object() {.Id, .alto, .ancho, .largo,
                                           .pesoReferencial, .pesoReal, .estado, .fechaUltimaAct, .obs}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Elemento(0))
                    .Parameters.AddWithValue("alto", Elemento(1))
                    .Parameters.AddWithValue("ancho", Elemento(2))
                    .Parameters.AddWithValue("largo", Elemento(3))
                    .Parameters.AddWithValue("pesoReferencial", Elemento(4))
                    .Parameters.AddWithValue("pesoReal", Elemento(5))
                    .Parameters.AddWithValue("estado", Elemento(6))
                    .Parameters.AddWithValue("fechaUltimaAct", Elemento(7))
                    .Parameters.AddWithValue("obs", Elemento(8))
                    .CommandText = "modificarPesoElemento"
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

    Public Shared Function SaveElementoHistorico(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoHistoricoItem
                    Elemento = New Object() {.Id, .idElemento, .pesoElemento, .estadoElemento,
                                           .tipoRegistro, .fecha, .usuario, .idProceso, .idVuelo, .fileImgCondicion, .observacion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Elemento(0))
                    .Parameters.AddWithValue("idElemento", Elemento(1))
                    .Parameters.AddWithValue("pesoElemento", Elemento(2))
                    .Parameters.AddWithValue("estadoElemento", Elemento(3))
                    .Parameters.AddWithValue("tipoRegistro", Elemento(4))
                    .Parameters.AddWithValue("fecha", Elemento(5))
                    .Parameters.AddWithValue("usuario", Elemento(6))
                    .Parameters.AddWithValue("idProceso", Elemento(7))
                    .Parameters.AddWithValue("idVuelo", Elemento(8))

                    If Elemento(9) = Nothing Then
                        Elemento(9) = ""
                    End If
                    .Parameters.AddWithValue("fileImgCondicion", Elemento(9))
                    If Elemento(10) = Nothing Then
                        Elemento(10) = ""
                    End If
                    .Parameters.AddWithValue("observacion", Elemento(10))
                    .CommandText = "agregarElementoHistorico"
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

    Public Shared Function SaveElementoPreBriefing(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoPreBriefingItem
                    Elemento = New Object() {.idBriefing, .idElemento, .fecha, .idContacto,
                                           .estado, .indice, .IdAerolinea, .IdRampa, .IdSeguridad, .Vuelo, .Procedencia, .UsuarioDelete}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idBriefing", Elemento(0))
                    .Parameters.AddWithValue("idElemento", Elemento(1))
                    .CommandText = "CheckExistsElementoPreBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                'If CBool(cmd.ExecuteScalar) Then
                '    With cmd2
                '        .Parameters.AddWithValue("idBriefing", Elemento(0))
                '        .Parameters.AddWithValue("idElemento", Elemento(1))
                '        .Parameters.AddWithValue("fecha", Elemento(2))
                '        .Parameters.AddWithValue("idContacto", Elemento(3))
                '        .Parameters.AddWithValue("estado", Elemento(4))
                '        .Parameters.AddWithValue("indice", Elemento(5))
                '        .CommandText = "modificarElementoPreBriefing"
                '        .CommandType = CommandType.StoredProcedure
                '        .Connection = dbTran.CreateConnection
                '        .Connection.Open()
                '        cmd2.ExecuteNonQuery()
                '    End With
                'Else
                '    With cmd2
                '        .Parameters.AddWithValue("idBriefing", Elemento(0))
                '        .Parameters.AddWithValue("idElemento", Elemento(1))
                '        .Parameters.AddWithValue("fecha", Elemento(2))
                '        .Parameters.AddWithValue("idContacto", Elemento(3))
                '        .Parameters.AddWithValue("estado", Elemento(4))
                '        .Parameters.AddWithValue("indice", Elemento(5))
                '        .CommandText = "agregarElementoPreBriefing"
                '        .CommandType = CommandType.StoredProcedure
                '        .Connection = dbTran.CreateConnection
                '        .Connection.Open()
                '        cmd2.ExecuteNonQuery()
                '    End With
                'End If

                If CBool(cmd.ExecuteScalar) Then
                    If Elemento(4) = "E" Then
                        With cmd2
                            .Parameters.AddWithValue("idBriefing", Elemento(0))
                            .Parameters.AddWithValue("idElemento", Elemento(1))
                            .Parameters.AddWithValue("UsuarioDelete", Elemento(11))
                            .Parameters.AddWithValue("estado", Elemento(4))
                            .Parameters.AddWithValue("indice", Elemento(5))
                            .CommandText = "SP_EliminarElementoPreBriefing"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                    Else
                        With cmd2
                            .Parameters.AddWithValue("idBriefing", Elemento(0))
                            .Parameters.AddWithValue("idElemento", Elemento(1))
                            .Parameters.AddWithValue("fecha", Elemento(2))
                            .Parameters.AddWithValue("idContacto", Elemento(3))
                            .Parameters.AddWithValue("estado", Elemento(4))
                            .Parameters.AddWithValue("indice", Elemento(5))
                            .Parameters.AddWithValue("IdAerolinea", Elemento(6))
                            .Parameters.AddWithValue("IdRampa", Elemento(7))
                            .Parameters.AddWithValue("IdSeguridad", Elemento(8))
                            .Parameters.AddWithValue("Vuelo", Elemento(9))
                            .Parameters.AddWithValue("Procedencia", Elemento(10))
                            .CommandText = "modificarElementoPreBriefing"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                    End If
                Else
                    With cmd2
                        .Parameters.AddWithValue("idBriefing", Elemento(0))
                        .Parameters.AddWithValue("idElemento", Elemento(1))
                        .Parameters.AddWithValue("fecha", Elemento(2))
                        .Parameters.AddWithValue("idContacto", Elemento(3))
                        .Parameters.AddWithValue("estado", Elemento(4))
                        .Parameters.AddWithValue("indice", Elemento(5))
                        .Parameters.AddWithValue("IdAerolinea", Elemento(6))
                        .Parameters.AddWithValue("IdRampa", Elemento(7))
                        .Parameters.AddWithValue("IdSeguridad", Elemento(8))
                        .Parameters.AddWithValue("Vuelo", Elemento(9))
                        .Parameters.AddWithValue("Procedencia", Elemento(10))
                        .CommandText = "agregarElementoPreBriefing"
                        '.CommandText = "agregarElementoPreBriefing2" 'eliminar despues de los 3 dias de revison
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function


    Public Shared Function SaveEstadoElemento(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoItem
                    Elemento = New Object() {.Id, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Elemento(0))
                    .Parameters.AddWithValue("estado", Elemento(1))
                    .CommandText = "modificarEstadoElemento"
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

    Public Shared Function SavePesoActualElemento(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoItem
                    Elemento = New Object() {.Id, .pesoActual, .fechaUltimaAct}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Elemento(0))
                    .Parameters.AddWithValue("pesoActual", Elemento(1))
                    .Parameters.AddWithValue("fechaUltimaAct", Elemento(2))
                    .CommandText = "modificarPesoActualElemento"
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

    Public Shared Function SaveElementoIngresoPlataforma(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Elemento As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoItem
                    Elemento = New Object() {.Id, .estado, .usuarioIngreso, .fechaUltimaAct, .chofer, .mula, .fechaIngresoPlataforma, .custodio, .pesoReferencial, .pesoReal, .fileImgCondicion, .observacion2}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", Elemento(0))
                    .Parameters.AddWithValue("estado", Elemento(1))
                    .Parameters.AddWithValue("usuarioIngreso", Elemento(2))
                    .Parameters.AddWithValue("fechaUltimaAct", Elemento(3))
                    .Parameters.AddWithValue("chofer", Elemento(4))
                    .Parameters.AddWithValue("mula", Elemento(5))
                    .Parameters.AddWithValue("fechaIngresoPlataforma", Elemento(6))
                    .Parameters.AddWithValue("custodio", Elemento(7))
                    .Parameters.AddWithValue("pesoReferencial", Elemento(8))
                    .Parameters.AddWithValue("pesoReal", Elemento(9))
                    If Elemento(10) Is Nothing Then
                        Elemento(10) = ""
                    End If
                    .Parameters.AddWithValue("fileImgCondicion", Elemento(10))
                    If Elemento(11) Is Nothing Then
                        Elemento(11) = ""
                    End If
                    .Parameters.AddWithValue("observacion2", Elemento(11))
                    .CommandText = "modificarElementoIngresoPlataforma"
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


    Public Shared Function SaveMaterialItem(req As MaterialesRequest) As MaterialesResponse
        Dim Result As New MaterialesResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Material As Object()
        Try
            If ValidateSession(req) Then
                With req.myMaterial
                    Material = New Object() {.idMaterial, .descripcion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myMaterial.idMaterial)
                    .CommandText = "CheckExistsMaterial"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Material(0))
                        .Parameters.AddWithValue("descripcion", Material(1))
                        .CommandText = "modificarMaterial"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Material(0))
                        .Parameters.AddWithValue("descripcion", Material(1))
                        .CommandText = "agregarMaterial"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetTiposEleItemById(req As TiposElementoRequest) As TiposElementoResponse
        Dim Result As New TiposElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTipo As TiposElementoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myTiposElemento.idTipo)
                    .CommandText = "obtenerTipoElementoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTipo = New TiposElementoItem
                    With myTipo
                        .idTipo = drReader.GetValue(drReader.GetOrdinal("idTipo"))
                        .descripcionTipo = drReader.GetValue(drReader.GetOrdinal("descripcionTipo"))
                        .codigo = drReader.GetValue(drReader.GetOrdinal("codigo"))

                    End With
                    Result.myTiposElementoItem = myTipo
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

    Public Shared Function SaveTipoElementoItem(req As TiposElementoRequest) As TiposElementoResponse
        Dim Result As New TiposElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req.myTiposElemento
                    Tipo = New Object() {.idTipo, .descripcionTipo, .codigo, .pesoReferencial, .materialPiso, .materialPared, .materialTecho, .materialPuerta, .ancho, .largo, .alto, .pesoreal}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myTiposElemento.idTipo)
                    .CommandText = "CheckExistsTipoElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Tipo(0))
                        .Parameters.AddWithValue("descripcion", Tipo(1))
                        .Parameters.AddWithValue("codigo", Tipo(2))
                        .Parameters.AddWithValue("pesoReferencial", Tipo(3))
                        .Parameters.AddWithValue("materialPiso", Tipo(4))
                        .Parameters.AddWithValue("materialPared", Tipo(5))
                        .Parameters.AddWithValue("materialTecho", Tipo(6))
                        '.Parameters.AddWithValue("materialRed", Tipo(6))
                        .Parameters.AddWithValue("materialPuerta", Tipo(7))
                        .Parameters.AddWithValue("ancho", Tipo(8))
                        .Parameters.AddWithValue("largo", Tipo(9))
                        .Parameters.AddWithValue("alto", Tipo(10))
                        .Parameters.AddWithValue("pesoreal", Tipo(11))
                        .CommandText = "modificarTipoElemento"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                            .Parameters.AddWithValue("Id", Tipo(0))
                        .Parameters.AddWithValue("descripcion", Tipo(1))
                        .Parameters.AddWithValue("codigo", Tipo(2))
                        .Parameters.AddWithValue("pesoReferencial", Tipo(3))
                        .Parameters.AddWithValue("materialPiso", Tipo(4))
                        .Parameters.AddWithValue("materialPared", Tipo(5))
                        .Parameters.AddWithValue("materialTecho", Tipo(6))
                        '.Parameters.AddWithValue("materialRed", Tipo(6))
                        .Parameters.AddWithValue("materialPuerta", Tipo(7))
                        .Parameters.AddWithValue("ancho", Tipo(8))
                        .Parameters.AddWithValue("largo", Tipo(9))
                        .Parameters.AddWithValue("alto", Tipo(10))
                        .Parameters.AddWithValue("pesoreal", Tipo(11))
                        .CommandText = "agregarTipoElemento"
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

    Public Shared Function SaveElementoHistoricoUld(req As ElementoRequest) As ElementoResponse
        Dim Result As New ElementoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim ElementoHuld As Object()
        Try
            If ValidateSession(req) Then
                With req.myElementoHUldItem
                    ElementoHuld = New Object() {.IdRegistro, .IdReporte}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idRegistro", ElementoHuld(0))
                    .Parameters.AddWithValue("idReporte", ElementoHuld(1))
                    .CommandText = "agregarElementoHistoricoUld"
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
    Public Shared Function GetElementoTotalPorAgencia(req As ElementoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myElementoItem.IdAgencia)
                    .CommandText = "obtenerElementoTotalPorAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Elementos"))
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
End Class
