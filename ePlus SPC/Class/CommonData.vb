Imports SPC.Server.ReportService
Imports SPC.Server.VuelosService
Imports SPC.Server.MarkingService
Imports ControlTempGA.ControlTemp
Imports SPC.Server.ControlTemp
Imports SPC.Server.CourrierService
Imports SPC.Server.FaceDetectionService
Imports FaceDetectLibrary.Classes

Public Class CommonData
    Public Shared Function GetProduccion(fechaIni As Date, fechaFin As Date, idagenc As Guid) As DataTable
        Dim Result As New DataTable("produccion")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.fechaIni = fechaIni
            req.fechaFin = fechaFin
            req.id = idagenc
            res = wsClient.GetEntireProduccion(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetProduccionById(idProd As Guid) As DataTable
        Dim Result As New DataTable("produccion")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.id = idProd
            res = wsClient.GetEntireProduccionId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetCamionCatalog() As DataTable
        Dim Result As New DataTable("AirplaneCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireCamionCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetVueloCatalog() As DataTable
        Dim Result As New DataTable("VueloCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireVuelosCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCamionPorIdAgencia(ByVal IdAgencia As Guid) As DataTable
        Dim Result As New DataTable("dtCamiones")
        Dim resu As New CamionCatalogItem
        Dim req As New CamionRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            resu.IdAgencia = IdAgencia
            req.myCamionCatItem = resu
            res = wsClnt.GetEntireCamionByIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetCamionItem(ByVal CamionId As Guid) As CamionCatalogItem
        Dim Result As New CamionCatalogItem
        Dim req As New CamionRequest
        Dim res As New CamionResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = CamionId
            req.myCamionCatItem = Result
            res = wsClnt.GetCamionItemById(req)
            If res.ActionResult Then
                Result = res.myCamionCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetVueloItem(ByVal VueloId As Guid) As VueloItem
        Dim Result As New VueloItem
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idVuelo = VueloId
            req.myVueloItem = Result
            res = wsClnt.GetVueloPorId(req)
            If res.ActionResult Then
                Result = res.myVueloItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetDetalleVueloPorIdVuelo(ByVal VueloId As Guid) As DetalleVuelo
        Dim Result As New DetalleVuelo
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idVuelo = VueloId
            req.myDetalleVuelo = Result
            res = wsClnt.GetDetalleVueloPorIdVuelo(req)
            If res.ActionResult Then
                Result = res.myDetalleVuelo
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetDetalleVueloPorIdBriefing(ByVal BriefingId As Guid) As DetalleVuelo
        Dim Result As New DetalleVuelo
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idBriefing = BriefingId
            req.myDetalleVuelo = Result
            res = wsClnt.GetDetalleVueloPorIdBriefing(req)
            If res.ActionResult Then
                Result = res.myDetalleVuelo
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetDollyCatalog() As DataTable
        Dim Result As New DataTable("DollyCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireDollyCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetDollyItem(ByVal DollyId As Guid) As DollyCatalogItem
        Dim Result As New DollyCatalogItem
        Dim req As New DollyRequest
        Dim res As New DollyResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = DollyId
            req.myDollyCatItem = Result
            res = wsClnt.GetDollyItemById(req)
            If res.ActionResult Then
                Result = res.myDollyCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAirplaneCatalog() As DataTable
        Dim Result As New DataTable("AirplaneCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireAirplaneCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTarifaCatalog() As DataTable
        Dim Result As New DataTable("tarifaCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireTarifasCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTarifaporId(ByVal tarifaId As Guid) As DataTable
        Dim Result As New DataTable("tarifaCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.id = tarifaId
            res = wsClient.GetTarifaPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetTarifaporAgenciayFecha(ByVal agenciaId As Guid, fecha As Date) As DataTable
        Dim Result As New DataTable("tarifaCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.id = agenciaId
            req.fechaIni = fecha
            res = wsClient.GetTarifaporAgenciayFecha(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAirplaneItem(ByVal AirplaneId As Guid) As AirplaneCatalogItem
        Dim Result As New AirplaneCatalogItem
        Dim req As New AirplaneRequest
        Dim res As New AirplaneResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = AirplaneId
            req.myAirplaneCatItem = Result
            res = wsClnt.GetAirplaneItemById(req)
            If res.ActionResult Then
                Result = res.myAirplaneCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEstado() As DataTable
        Dim Result As New DataTable("Estado")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEstado(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEstadoElemento() As DataTable
        Dim Result As New DataTable("EstadoElemento")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEstadoElemento(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEstadoPorId(ByVal EstadoId As String) As DataTable
        Dim Result As New DataTable("EstadoPorId")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {EstadoId}
            res = wsClient.GetEstadoPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEstadoElementoPorId(ByVal EstadoId As String) As DataTable
        Dim Result As New DataTable("EstadoElementoPorId")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {EstadoId}
            res = wsClient.GetEstadoElementoPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoDocPorId(ByVal TipoDocId As String) As DataTable
        Dim Result As New DataTable("TipoDocumento")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {TipoDocId}
            res = wsClient.GetTipoDocPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoDocCatalog() As DataTable
        Dim Result As New DataTable("TipoDocumento")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetTipoDocCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipo() As DataTable
        Dim Result As New DataTable("Tipo")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetTipo(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoPorId(ByVal tipoId As String) As DataTable
        Dim Result As New DataTable("Tipo")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {tipoId}
            res = wsClient.GetTipoPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAirportCatalog() As DataTable
        Dim Result As New DataTable("AirportCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireAirportCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAirportItem(ByVal AirportId As Guid) As AirportCatalogItem
        Dim Result As New AirportCatalogItem
        Dim req As New AirportRequest
        Dim res As New AirportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = AirportId
            req.myAirportCatItem = Result
            res = wsClnt.GetAirportItemById(req)
            If res.ActionResult Then
                Result = res.myAirportCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetPais() As DataTable
        Dim Result As New DataTable("Pais")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetPais(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudad(ByVal paisId As String) As DataTable
        Dim Result As New DataTable("Ciudad")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {paisId}
            res = wsClient.GetCiudad(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudadPorId(ByVal ciudadId As String) As DataTable
        Dim Result As New DataTable("Ciudad")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {ciudadId}
            res = wsClient.GetCiudadPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAgenciaPorId(ByVal AgenciaId As String) As DataTable
        Dim Result As New DataTable("Agencia")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId}
            res = wsClient.GetAgenciaPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAgencia() As DataTable
        Dim Result As New DataTable("Pais")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAgenciaCatalog() As DataTable
        Dim Result As New DataTable("AirportCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireAgenciaCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAgenciaItem(ByVal AgenciaId As Guid) As AgenciaCatalogItem
        Dim Result As New AgenciaCatalogItem
        Dim req As New AgenciaRequest
        Dim res As New AgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = AgenciaId
            req.myAgenciaCatItem = Result
            res = wsClnt.GetAgenciaItemById(req)
            If res.ActionResult Then
                Result = res.myAgenciaCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoAgencia() As DataTable
        Dim Result As New DataTable("Tipo")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetTipoAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoAgencia() As DataTable
        Dim Result As New DataTable("Archivo")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetArchivoAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoContacto() As DataTable
        Dim Result As New DataTable("ArchivoContacto")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetArchivoContacto(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoAgenciaPorId(ByVal tipoId As String) As DataTable
        Dim Result As New DataTable("Tipo")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {tipoId}
            res = wsClient.GetTipoAgenciaPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetAgenciaPorTipo(ByVal TipoAgencia As String) As DataTable
        Dim Result As New DataTable("Agencia")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {TipoAgencia}
            res = wsClient.GetAgenciaItemPorTipo(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEntireMatrizSeguridadCatalog() As DataTable
        Dim Result As New DataTable("MatrizSeguridadCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireMatrizSeguridadCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetMatrizSeguridadItemById(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("Matriz")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClnt.GetMatrizSeguridadItemById(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEntireContactoCatalog() As DataTable
        Dim Result As New DataTable("ContactoCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEntireContactoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEntireDestinatarios() As DataTable
        Dim Result As New DataTable("Destinatarios")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEntireContactoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetEntireUsuarioCatalog() As DataTable
        Dim Result As New DataTable("UsuarioCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEntireUsuarioCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function



    Public Shared Function GetContactoAgenciaPorIdAgencia(ByVal idagencia As Guid) As DataTable
        Dim Result As New DataTable("ContactoAgenciaCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            Result.Clear()
            General.SetBARequest(req)
            req.prmArr = New String() {idagencia.ToString}
            res = wsClnt.GetContactoAgenciaItemByIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetContactoAgenciaPorIdContacto(ByVal ContactoId As String) As DataTable
        Dim Result As New DataTable("ContactoAgenciasCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {ContactoId}
            res = wsClnt.GetContactoAgenciaItemByIdContacto(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0).Select("estado ='A'").CopyToDataTable()
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetContactoAgenciaPorIdContactoAll(ByVal ContactoId As String) As DataTable
        Dim Result As New DataTable("ContactoAgenciasCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {ContactoId}
            res = wsClnt.GetContactoAgenciaItemByIdContacto(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetContactoAgenciaPorId(ByVal AgenciaId As Guid, ByVal ContactoId As String,
                                                           ByVal fechIni As Date, ByVal estado As String) As SPC.Server.ReportService.ContactoAgenciaCatalogItem
        Dim Result As New SPC.Server.ReportService.ContactoAgenciaCatalogItem
        Dim req As New ContactoAgenciaRequest
        Dim res As New ContactoAgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idAgencia = AgenciaId
            Result.idContacto = ContactoId
            Result.fechaInicio = fechIni
            Result.estado = estado
            req.myContactoAgenciaItem = Result
            res = wsClnt.GetContactoAgenciaItemById(req)
            If res.ActionResult Then
                Result = res.myContactoAgenciaItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetAvionPorIdAgencia(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("Avion")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClnt.GetAvionPorIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAeropuertoPorIdPais(ByVal CiudadId As Guid) As DataTable
        Dim Result As New DataTable("AeropuertoPorPais")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {CiudadId.ToString}
            res = wsClnt.GetAeropuertoPorIdPais(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetAeropuertoPorIdCiudad(ByVal CiudadId As Guid) As DataTable
        Dim Result As New DataTable("AeropuertoPorCiudad")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {CiudadId.ToString}
            res = wsClnt.GetAeropuertoPorIdCiudad(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudadPorIdPais(ByVal PaisId As String) As DataTable
        Dim Result As New DataTable("AeropuertoPorCiudad")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {PaisId}
            res = wsClnt.GetCiudadPorIdPais(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetRutaVueloPorIdVuelo(ByVal VueloId As Guid) As DataTable
        Dim Result As New DataTable("dtRuta")
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {VueloId.ToString}
            res = wsClnt.GetRutaVueloPorIdVuelo(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetVuelosPorIdAgencia(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("dtVuelos")
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClnt.GetVuelosPorIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetDollyPorIdAgencia(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("dtDolly")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClnt.GetDollyPorIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEntireProductoCatalog() As DataTable
        Dim Result As New DataTable("Productos")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEntireProductoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetProcutoPorIdTipo(ByVal TipoId As String) As DataTable
        Dim Result As New DataTable("Productos")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {TipoId}
            res = wsClnt.GetProductoPorIdTipo(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetEntireTipoProducto() As DataTable
        Dim Result As New DataTable("Productos")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEntireTipoProducto(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudadCatalog() As DataTable
        Dim Result As New DataTable("CiudadCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireCiudadCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudadItem(ByVal CiudadId As Guid) As CiudadCatalogItem
        Dim Result As New CiudadCatalogItem
        Dim req As New CiudadRequest
        Dim res As New CiudadResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = CiudadId
            req.myCiudadCatItem = Result
            res = wsClnt.GetCiudadItemById(req)
            If res.ActionResult Then
                Result = res.myCiudadCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetPaisCatalog() As DataTable
        Dim Result As New DataTable("PaisCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntirePaisCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCodigoPais(ByVal PaisId As Guid) As DataTable
        Dim Result As New DataTable("CodigoPais")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {PaisId.ToString}
            res = wsClient.GetCodigoPaisPorId(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetPaisItem(ByVal PaisId As Guid) As PaisCatalogItem
        Dim Result As New PaisCatalogItem
        Dim req As New PaisRequest
        Dim res As New PaisResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = PaisId
            req.myPaisCatItem = Result
            res = wsClnt.GetPaisItemById(req)
            If res.ActionResult Then
                Result = res.myPaisCatItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoCatalog() As DataTable
        Dim Result As New DataTable("ElementoCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireElementoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoItem(ByVal ElementoId As String) As ElementoCatalogItem
        Dim Result As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ElementoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = ElementoId
            req.myElementoItem = Result
            res = wsClnt.GetElementoItemById(req)
            If res.ActionResult Then
                Result = res.myElementoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgenciaYTipo(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaYTipo(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementosPorEstado(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementosPorEstado(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetElementoPorAgenciaYTipoEnSalida(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaYTipoEnSalida(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgencia(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgenciaStock(ByVal idAgencia As Guid) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele.IdAgencia = idAgencia
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaStock(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgenciaEnSalida(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaEnSalida(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgenciaEnPesaje(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaEnPesaje(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoPorAgenciaEnPreseleccion(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoPorAgenciaEnPreseleccion(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoElementoCatalog() As DataTable
        Dim Result As New DataTable("TipoElementoCatalog")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireTipoElementoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetCargoCatalog() As DataTable
        Dim Result As New DataTable("Cargos")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetCargoCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetMaterialItem(ByVal MaterialId As String) As MaterialesItem
        Dim Result As New MaterialesItem
        Dim req As New MaterialesRequest
        Dim res As New MaterialesResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idMaterial = MaterialId
            req.myMaterial = Result
            res = wsClnt.GetMaterialItemById(req)
            If res.ActionResult Then
                Result = res.myMaterialItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetPosicionItem(ByVal PosicionId As Guid) As PosicionItem
        Dim Result As New PosicionItem
        Dim req As New PosicionRequest
        Dim res As New PosicionResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.Id = PosicionId
            req.myPosicionItem = Result
            res = wsClnt.GetPosicionItemById(req)
            If res.ActionResult Then
                Result = res.myPosicionItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetProductoItem(ByVal ProductoId As Guid) As ProductoCatalogItem
        Dim Result As New ProductoCatalogItem
        Dim req As New ProductoRequest
        Dim res As New ProductoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.IdProducto = ProductoId
            req.myProductoItem = Result
            res = wsClnt.GetProductosItemById(req)
            If res.ActionResult Then
                Result = res.myProductoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetContactoItem(ByVal ContactoId As String) As Server.ReportService.ContactoCatalogItem
        Dim Result As New Server.ReportService.ContactoCatalogItem
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idContacto = ContactoId
            req.myContactoItem = Result
            res = wsClnt.GetContactoItemById(req)
            If res.ActionResult Then
                Result = res.myContactoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetUsuarioItem(ByVal UsuarioId As String) As Server.ReportService.UsuarioItem
        Dim Result As New Server.ReportService.UsuarioItem
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idUsuario = UsuarioId
            req.myUsuarioItem = Result
            res = wsClnt.GetusuarioItemById(req)
            If res.ActionResult Then
                Result = res.myUsuarioItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function



    Public Shared Function GetMaterialesCatalog() As DataTable
        Dim Result As New DataTable("Materiales")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntireMaterialesCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetDestinatariosItemPorId(ByVal destinatarioId As Guid) As DestinatarioCatalog
        Dim Result As New DestinatarioCatalog
        Dim req As New DestinatarioRequest
        Dim res As New DestinatarioResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idDestinatario = destinatarioId
            req.myDestinatarioItem = Result
            res = wsClnt.GetDestinatarioItemPorId(req)
            If res.ActionResult Then
                Result = res.myDestinatarioItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetDestinatariosPorIdReporte(idReporte As Integer) As DataTable
        Dim Result As New DataTable("Destinatarios")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmInt = idReporte
            res = wsClient.GetDestinatariosPorIdReporte(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetDestinatarios() As DataTable
        Dim Result As New DataTable("Destinatarios")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetDestinatarios(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetDestinatariosAgencias() As DataTable
        Dim Result As New DataTable("Destinatarios")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetDestinatariosAgencias(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetDestinatariosbyIdReporteyAgencia(ByVal Id As Integer, ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("Destinatarios")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.prmInt = Id
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClient.GetDestinatariosbyIdReporteyAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetPosicionesCatalog() As DataTable
        Dim Result As New DataTable("Posiciones")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetEntirePosicionesCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoElementoItem(ByVal ElementoId As Guid) As TiposElementoItem
        Dim Result As New TiposElementoItem
        Dim req As New TiposElementoRequest
        Dim res As New TiposElementoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idTipo = ElementoId
            req.myTiposElemento = Result
            res = wsClnt.GetTiposEleItemById(req)
            If res.ActionResult Then
                Result = res.myTiposElementoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoProductoItem(ByVal ProductoId As Guid) As TipoProductoCatalogItem
        Dim Result As New TipoProductoCatalogItem
        Dim req As New TipoProductoRequest
        Dim res As New TipoProductoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idTipo = ProductoId
            req.myTipoProductoItem = Result
            res = wsClnt.GetTipoProductoItemById(req)
            If res.ActionResult Then
                Result = res.myTipoProductoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoAgenciaItem(ByVal AgenciaId As Guid) As TipoAgenciaCatalogItem
        Dim Result As New TipoAgenciaCatalogItem
        Dim req As New TipoAgenciaRequest
        Dim res As New TipoAgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idTipo = AgenciaId
            req.myTipoAgenciaItem = Result
            res = wsClnt.GetTipoAgenciaItemById(req)
            If res.ActionResult Then
                Result = res.myTipoAgenciaItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoAgenciaItem(ByVal ArchivoId As Guid) As ArchivoAgenciaCatalogItem
        Dim Result As New ArchivoAgenciaCatalogItem
        Dim req As New ArchivoAgenciaRequest
        Dim res As New ArchivoAgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idArchivo = ArchivoId
            req.myArchivoAgenciaItem = Result
            res = wsClnt.GetArchivoAgenciaItemById(req)
            If res.ActionResult Then
                Result = res.myArchivoAgenciaItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoContactoItem(ByVal ArchivoId As Guid) As Server.ReportService.ArchivoContactoCatalogItem
        Dim Result As New Server.ReportService.ArchivoContactoCatalogItem
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idArchivo = ArchivoId
            req.myArchivoContactoItem = Result
            res = wsClnt.GetArchivoContactoItemById(req)
            If res.ActionResult Then
                Result = res.myArchivoContactoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoAgenciaItemByAgencia(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New ArchivoAgenciaCatalogItem
        Dim Resu As New DataTable("Archivo")
        Dim req As New ArchivoAgenciaRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idAgencia = AgenciaId
            req.myArchivoAgenciaItem = Result
            res = wsClnt.GetArchivoAgenciaItemByIdAgencia(req)
            If res.ActionResult Then
                Resu = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Resu
    End Function

    Public Shared Function GetArchivoContactoItemByContacto(ByVal ContactoId As String) As DataTable
        Dim Result As New Server.ReportService.ArchivoContactoCatalogItem
        Dim Resu As New DataTable("Archivo")
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idContacto = ContactoId
            req.myArchivoContactoItem = Result
            res = wsClnt.GetArchivoContactoItemByIdContacto(req)
            If res.ActionResult Then
                Resu = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Resu
    End Function

    Public Shared Function GetRegBiometricoByContacto(ByVal ContactoId As String) As DataTable
        Dim dtRegBiometrico As New DataTable("RegBiometrico")
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myContactoItem = New Server.ReportService.ContactoCatalogItem
            req.myContactoItem.idContacto = ContactoId

            res = wsClnt.GetRegBiometricoByIdContacto(req)
            If res.ActionResult Then
                dtRegBiometrico = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtRegBiometrico
    End Function

    Public Shared Function GetZonasAutorizadasByContacto(ByVal ContactoId As String) As DataTable
        Dim dtZonasAutorizadasByContacto As New DataTable("ZonasAutorizadasByContacto")
        If dtZonasAutorizadasByContacto.Columns.Count = 0 Then
            dtZonasAutorizadasByContacto.Dispose()
            dtZonasAutorizadasByContacto.Columns.Add("idZonaAutorizada_Contacto")
            dtZonasAutorizadasByContacto.Columns.Add("idContacto")
            dtZonasAutorizadasByContacto.Columns.Add("idZona")
            dtZonasAutorizadasByContacto.Columns.Add("DiaPermitido")
            dtZonasAutorizadasByContacto.Columns.Add("HorarioDesde")
            dtZonasAutorizadasByContacto.Columns.Add("HorarioHasta")
        End If

        Dim wsClnt As New MarkingServiceSoapClient
        Dim req As New ZonasAutorizadasByContactoRequest
        Dim res As New MarkingResponse
        Try
            General.SetBARequest(req)
            req.myZonasAutorizadasByContacto = New Server.MarkingService.ZonasAutorizadasByContactoCatalogItem
            req.myZonasAutorizadasByContacto.idContacto = ContactoId
            res = wsClnt.GetZonasAutorizadasByContacto(req)
            If res.ActionResult Then
                dtZonasAutorizadasByContacto = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtZonasAutorizadasByContacto
    End Function

    Public Shared Function GetZonasAutorizadas() As DataTable
        Dim Result As New DataTable("AllZonasAutorizadas")
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New ZonasAutorizadasRequest
        Dim res As New MarkingResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetZonasAutorizadas(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function SaveElementoHistorico(ByVal elementoHistorico As ElementoHistoricoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New ElementoRequest
        Dim res As New ElementoResponse
        Dim WsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoHistoricoItem = elementoHistorico
            res = WsClnt.SaveElementoHistorico(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return result
    End Function

    Public Shared Function GetElementoHistoricoPorIdElemento(ByVal elementoHistorico As ElementoHistoricoItem) As DataTable
        Dim result As New DataTable("ElementoHistorico")
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim WsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoHistoricoItem = elementoHistorico
            res = WsClnt.GetElementoHistoricoPorIdElemento(req)
            If res.ActionResult Then
                result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return result
    End Function

    Public Shared Function SaveElementoHistoricoUld(ByVal elementoHistoricoUld As ElementoHUldCatalogItem) As Boolean
        Dim result As Boolean = False
        Dim req As New ElementoRequest
        Dim res As New ElementoResponse
        Dim WsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoHUldItem = elementoHistoricoUld
            res = WsClnt.SaveElementoHistoricoUld(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return result
    End Function
    'MARZ
    Public Shared Function GetConfiguraciones() As ConfigurationItem
        Dim Result As New ConfigurationItem
        Dim req As New UserRequest
        Dim res As New UserResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetConfiguraciones(req)
            If res.ActionResult Then
                Result = res.myConfiguraciones
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_15.08.17
    Public Shared Function GetProfileCatalog() As DataTable
        Dim Result As New DataTable("ProfileCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetProfileCatalog(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_16.08.17

    Public Shared Function GetPerfilItem(ByVal idPerfil As Guid) As Server.ReportService.PerfilItem
        Dim Result As New Server.ReportService.PerfilItem
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.idPerfil = idPerfil
            req.myPerfilItem = Result
            res = wsClnt.GetPerfilItemById(req)
            If res.ActionResult Then
                Result = res.myPerfilItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_17.08.17
    Public Shared Function GetPerfilesByContacto(ByVal idContacto As String) As DataTable
        Dim dtPerfilesByContacto As New DataTable("PerfilesByContacto")
        Dim wsClnt As New ReportServiceSoapClient
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.myPerfilesByContacto = New Server.ReportService.PerfilesUsuarioItem
            req.myPerfilesByContacto.idContacto = idContacto
            res = wsClnt.GetPerfilesByContacto(req)
            If res.ActionResult Then
                dtPerfilesByContacto = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtPerfilesByContacto
    End Function
    Public Shared Function Getusuarioempresabyidcontacto(ByVal idContacto As String) As DataTable
        Dim dtUsuarioEmpresa As New DataTable("usuarioEmpresa")
        Dim wsClnt As New ReportServiceSoapClient
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)

            req.myUsuarioItem = New Server.ReportService.UsuarioItem
            req.myUsuarioItem.idContacto = idContacto
            res = wsClnt.GetUsuarioEmpresa(req)
            If res.ActionResult Then
                dtUsuarioEmpresa = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtUsuarioEmpresa
    End Function




    'MARZ_19.08.17
    Public Shared Function GetKeysItems() As DataTable
        Dim Result As New DataTable("Keys")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            res = wsClient.GetKeysItems(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_21.08.17
    Public Shared Function GetPermisosByPerfil(ByVal idPerfil As Guid) As DataTable
        Dim dtPermisosByPerfil As New DataTable("PermisosByPerfil")
        Dim wsClnt As New ReportServiceSoapClient
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.myPermisosByPerfil = New Server.ReportService.PermisosPerfilItem
            req.myPermisosByPerfil.idPerfil = idPerfil
            res = wsClnt.GetPermisosByPerfil(req)
            If res.ActionResult Then
                dtPermisosByPerfil = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtPermisosByPerfil
    End Function

    'MARZ_30.08.17
    Public Shared Function GetTableTurnos() As DataTable
        Dim Result As New DataTable("Turnos")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetTableTurnos(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTurnoById(ByVal idTurno As Guid) As Server.ReportService.TurnoItem
        Dim Result As New Server.ReportService.TurnoItem
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.id = idTurno
            req.myTurno = Result
            res = wsClnt.GetTurnoById(req)
            If res.ActionResult Then
                Result = res.myTurno
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_01.09.17
    Public Shared Function GetEmpleadosGeneral() As DataTable
        Dim Result As New DataTable("EmpleadosGeneral")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetEmpleadosGeneral(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_02.09.17
    Public Shared Function GetMarkingsGeneralair(contacto As String, inicio As Date, fin As Date, type As String) As DataTable
        Dim Result As New DataTable("MarcacionesGeneral")
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New Server.MarkingService.ContactoRequest
        Dim res As New MarkingResponse
        Try
            General.SetBARequest(req)
            req.codigoVuelo = contacto
            req.fechaIni = inicio
            req.fechaFin = fin
            req.PcId = type
            res = wsClient.GetMarkingsGeneralair(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function





    'MARZ_07.09.17
    Public Shared Function GetTurnosEmpleado(contacto As String, inicio As Date, fin As Date, type As String, IdTurno As Guid) As DataTable
        Dim Result As New DataTable("TurnosPersonal")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ReportResponse
        Try
            General.SetBARequest(req)
            req.codigoVuelo = contacto
            req.fechaIni = inicio
            req.fechaFin = fin
            req.PcId = type
            req.id = IdTurno
            res = wsClient.GetTurnosEmpleado(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function




    'MARZ_14.09.17
    Public Shared Function GetAllPermisosEspeciales(ByVal data As String) As DataTable
        Dim Result As New DataTable("PermisosEspeciales")
        Dim req As New Server.MarkingService.ContactoRequest
        Dim res As New MarkingResponse
        Dim wsClnt As New MarkingServiceSoapClient
        Try
            General.SetBARequest(req)
            req.codigoVuelo = data
            res = wsClnt.GetAllPermisosEspeciales(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    'MARZ_15.09.17
    Public Shared Function GetContactosByPermiso(ByVal idPermiso As Guid) As DataTable
        Dim tablePermisosByContacto As New DataTable("PermisosByContacto")
        Dim wsClnt As New MarkingServiceSoapClient
        Dim req As New Server.MarkingService.ContactoRequest
        Dim res As New MarkingResponse
        Try
            General.SetBARequest(req)
            req.myPermisoEspecial = New Server.MarkingService.PermisoEspecialItem
            req.myPermisoEspecial.id = idPermiso
            res = wsClnt.GetContactosByPermiso(req)
            If res.ActionResult Then
                tablePermisosByContacto = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return tablePermisosByContacto
    End Function

    Public Shared Function GetPermisoEspecialById(ByVal idPermiso As Guid) As Server.MarkingService.PermisoEspecialItem
        Dim Result As New Server.MarkingService.PermisoEspecialItem
        Dim req As New Server.MarkingService.ContactoRequest
        Dim res As New PermisoContactoResponse
        Dim wsClnt As New MarkingServiceSoapClient
        Try
            General.SetBARequest(req)
            Result.id = idPermiso
            req.myPermisoEspecial = Result
            res = wsClnt.GetPermisoEspecialById(req)
            If res.ActionResult Then
                Result = res.myPermisoEspecial
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function GetElementoTotalPorAgencia(ByVal Elemento As ElementoCatalogItem) As DataTable
        Dim Result As New DataTable
        Dim Ele As New ElementoCatalogItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Ele = Elemento
            req.myElementoItem = Ele
            res = wsClnt.GetElementoTotalPorAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerCuartosFrios() As DataTable
        Dim Result As New DataTable("Sp_ObtenerCuartosFrios")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            res = wsClient.ObtenerCuartosFrios(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerReportTemp(NombreCuartoFrio As String, FechaInicio As Date, FechaFinal As Date) As DataTable
        Dim Result As New DataTable("ObtenerReportTemp")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            req.NombreCuartoFrio = NombreCuartoFrio
            req.FechaInicio = FechaInicio
            req.FechaFinal = FechaFinal
            res = wsClient.ObtenerReportTemp(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function MantHorarioAgenciaSeguridad(datos As HorarioAgenciaSeguridad) As Boolean
        Dim Result As Boolean
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New HorarioAgenciaSeguridadRequest
        Dim res As New HorarioAgenciaSeguridadResponse
        Try
            req.HorarioAgenciaSeguridad = datos
            res = wsClient.MantHorarioAgenciaSeguridad(req)
            If res.ActionResult Then
                Result = res.ActionResult
            Else
                Result = res.ActionResult
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function GetHorAgenSeguridad() As DataTable
        Dim Result As New DataTable("ObtenerReportTemp")
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New HorarioAgenciaSeguridadRequest
        Dim res As New HorarioAgenciaSeguridadResponse
        Dim Datos As New HorarioAgenciaSeguridad
        Try
            req.HorarioAgenciaSeguridad = Datos
            res = wsClient.GetHorAgenSeguridad(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerCuartoFrioIdProIdGui(idProceso As Guid, idElemento As String) As DataTable
        Dim Result As New DataTable("ObtenerReportTemp")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempBitacoraCuartoRequest
        Dim res As New TempBitacoraCuartoResponse
        Dim datos As New TempBitacoraCuarto
        Try
            datos.idProceso = idProceso
            datos.idElemento = idElemento
            req.TempBitacoraCuarto = datos
            res = wsClient.ObtenerCuartoFrioIdProIdGui(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function AgregaBitacoraCargaCuarto(datos As TempBitacoraCuarto) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempBitacoraCuartoRequest
        Dim res As New TempBitacoraCuartoResponse
        Try
            req.TempBitacoraCuarto = datos
            res = wsClient.AgregaBitacoraCargaCuarto(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerVuelosElemen(datos As TempBitacoraCuarto) As DataTable
        Dim Result As DataTable
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempBitacoraCuartoRequest
        Dim res As New TempBitacoraCuartoResponse
        Dim DatosTempBitacoraCuarto As New TempBitacoraCuarto
        Try
            DatosTempBitacoraCuarto = datos
            req.TempBitacoraCuarto = DatosTempBitacoraCuarto
            res = wsClient.ObtenerVuelosElemen(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerParametrosNoti(datos As Integer) As DataTable
        Dim Result As DataTable
        Dim wsClient As New ControlTempSoapClient
        Dim req As New NotificacionTempRequest
        Dim res As New NotificacionTempResponse
        Dim NotificacionTemp As New NotificacionTemp
        Try
            NotificacionTemp.id_notificacion_temp = datos
            req.NotificacionTemp = NotificacionTemp
            res = wsClient.ObtenerParametrosNoti(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function MantNotificacionTemp(datos As NotificacionTemp) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New NotificacionTempRequest
        Dim res As New NotificacionTempResponse
        Dim NotificacionTemp As New NotificacionTemp
        Try
            NotificacionTemp = datos
            req.NotificacionTemp = NotificacionTemp
            res = wsClient.MantNotificacionTemp(req)
            If res.ActionResult Then
                Result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
    Public Shared Function GetResportes() As DataTable
        Dim Result As DataTable
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportesRequest
        Dim res As New ReportesResponse
        Try
            res = wsClient.GetResportes(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function


    Public Shared Function GetDetalleProcesoporContacto(ContactoId As String, fechasini As Date, fechafina As Date) As DataTable
        Dim Result As DataTable
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim rContactoItem As New Server.ReportService.ContactoCatalogItem
        Dim reqConta As New Server.ReportService.ContactoRequest

        Try

            General.SetBARequest(req)
            rContactoItem.idContacto = ContactoId
            reqConta.myContactoItem = rContactoItem
            reqConta.fechaIni = fechasini
            reqConta.fechaFin = fechafina


            res = wsClient.GetFichaPersonal(reqConta)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function

    Public Shared Function GetLogsAccesosporContactoyFechas(idContacto As String, fechaInicio As Date, fechaFinal As Date) As DataSet
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New ContactoZonasSessionRequest
        Dim res1 As New DataSet
        Dim dtContactoZonasSession As New ContactoZonasSessionItem

        With dtContactoZonasSession
            .IdAgencia = Guid.Parse("00000000-0000-0000-0000-000000000000")
            .IdContacto = idContacto
            .FechaInicio = fechaInicio
            .FechaFinal = fechaFinal
            .TipoReporte = False
        End With
        Try
            General.SetBARequest(req)
            req.myContactoZonasSession = dtContactoZonasSession
            res1 = wsClient.GetLogContactoZonasSession(req).DsResult
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res1, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return res1

    End Function
    Public Shared Function getGavetaGuiaporIdGuiaIdElemento(ByVal IdGuia As String, ByVal ElementoId As String) As DataTable

        Dim req As New GavetaGuiaRequest
        Dim res As New GavetaGuiaResponse
        Dim wsClnt As New CourrierServiceSoapClient
        Dim Result As DataTable
        Try
            General.SetBARequest(req)
            req.myGavetaGuiaItem.idGuia = IdGuia
            req.myGavetaGuiaItem.idElemento = ElementoId
            res = wsClnt.getGavetaGuiaporIdGuiaIdElemento(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function SavegavetasGuia(datos As GavetaGuiaItem) As Boolean
        Dim Result As Boolean
        Dim wsClient As New CourrierServiceSoapClient
        Dim res As New GavetaGuiaResponse
        Dim req As GavetaGuiaRequest

        req.myGavetaGuiaItem = New GavetaGuiaItem
        req.myGavetaGuiaItem = datos

        Try
            res = wsClient.SaveGavetaGuia(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If

        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function


    Public Shared Function GetParameter() As FParameter
        Dim wsClient As New FaceDetectionMainSoapClient
        Dim res As New EPParameterResponse
        Dim req As New EPParameterRequest
        Dim result As New FParameter

        Dim DtParametros As New DataTable("Parametros")
        Try
            res = wsClient.GetParameterFaceDetect(req)
            If res.ActionResult Then
                DtParametros = res.DsResult.Tables(0)
                Dim rows As DataRow()

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='SubscriptionKeyFace'")
                For Each r As DataRow In rows
                    result.SubscriptionKey = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='LocationApiFace'")
                For Each r As DataRow In rows
                    result.LocationApi = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='IdGroup'")
                For Each r As DataRow In rows
                    result.IdGrupo = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='TipGroup'")
                For Each r As DataRow In rows
                    result.TipGroup = r.Item(3)
                Next

            End If
            Return result
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, result, req)
        End Try
    End Function

End Class
