Imports Ensamblado_ReporteFlights.ReportService
Imports Ensamblado_ReporteFlights.VuelosService
Public Class CommonData

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
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '   ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function


    Public Shared Function GetContactoAgenciaPorIdAgencia(ByVal AgenciaId As Guid) As DataTable
        Dim Result As New DataTable("ContactoAgenciaCatalog")
        Dim req As New ReportRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {AgenciaId.ToString}
            res = wsClnt.GetContactoAgenciaItemByIdAgencia(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetContactoAgenciaPorId(ByVal AgenciaId As Guid, ByVal ContactoId As String,
                                                           ByVal fechIni As Date, ByVal estado As String) As ContactoAgenciaCatalogItem
        Dim Result As New ContactoAgenciaCatalogItem
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
            '  ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex, res, req)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetContactoItem(ByVal ContactoId As String) As ContactoCatalogItem
        Dim Result As New ContactoCatalogItem
        Dim req As New ContactoRequest
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            '  ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoContactoItem(ByVal ArchivoId As Guid) As ArchivoContactoCatalogItem
        Dim Result As New ArchivoContactoCatalogItem
        Dim req As New ContactoRequest
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
            ' ErrorManager.SetLogEvent(ex)
            '  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ' ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Resu
    End Function

    Public Shared Function GetArchivoContactoItemByContacto(ByVal ContactoId As String) As DataTable
        Dim Result As New ArchivoContactoCatalogItem
        Dim Resu As New DataTable("Archivo")
        Dim req As New ContactoRequest
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
            '  ErrorManager.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Resu
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
            'ErrorManager.SetLogEvent(ex)
        End Try
        Return result
    End Function

End Class
