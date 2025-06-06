﻿Imports Ensamblado_ReporteFlights.ProcesoService
Imports Ensamblado_ReporteFlights.VuelosService
Imports Ensamblado_ReporteFlights.ReportService
Public Class CommonProcess

    Public Shared Function GetActividadItemPorIdTipo(ByVal IdTipo As String) As DataTable
        Dim Result As New DataTable("dtActividad")
        Dim req As New ActividadRequest
        Dim res As New ActividadResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.prmArr = New String() {IdTipo.ToString}
            res = wsClnt.GetActividadPorIdTipoAgencia(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaProductoPorIdGuia(ByVal IdGuia As Guid) As DataTable
        Dim Result As New DataTable("dtGuiaProductos")
        Dim GuiaProducto As New GuiaProductosItem
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            GuiaProducto.idGuia = IdGuia
            req.myGuiaProductoItem = GuiaProducto
            res = wsClnt.GetGuiaProductosPorIdGuia(req)
            If res.ActionResult Then
                Result = res.dsGuiaProductos.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaCamionesPorId(ByVal guiaCamion As GuiaCamionesItem) As DataTable
        Dim Result As New DataTable("dtGuiaCamiones")
        Dim myGuiaCamion As New GuiaCamionesItem
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            myGuiaCamion = guiaCamion
            req.myGuiaCamionesItem = myGuiaCamion
            res = wsClnt.GetGuiaCamionesPorId(req)
            If res.ActionResult Then
                Result = res.dsGuiaCamiones.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetElementoBriefingPorIdBriefing(ByVal elementoBriefing As ElementoBriefingItem) As DataTable
        Dim Result As New DataTable("dtElementoBriefing")
        Dim myElementoBriefing As New ElementoBriefingItem
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            myElementoBriefing = elementoBriefing
            req.myElementoBriefingItem = myElementoBriefing
            res = wsClnt.GetElementoBriefingPorIdBriefing(req)
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

    Public Shared Function GetElementoBriefingPorIdElemento(ByVal elementoBriefing As ElementoBriefingItem) As DataTable
        Dim Result As New DataTable("dtElementoBriefing")
        Dim myElementoBriefing As New ElementoBriefingItem
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            myElementoBriefing = elementoBriefing
            req.myElementoBriefingItem = myElementoBriefing
            res = wsClnt.GetElementoBriefingPorIdElemento(req)
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

    Public Shared Function GetElementoPreBriefingPorIdBriefing(ByVal elementoPreBriefing As ElementoPreBriefingItem) As DataTable
        Dim Result As New DataTable("dtElementoBriefing")
        Dim myElementoPreBriefing As New ElementoPreBriefingItem
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            myElementoPreBriefing = elementoPreBriefing
            req.myElementoPreBriefingItem = myElementoPreBriefing
            res = wsClnt.GetElementoPreBriefingPorIdBriefing(req)
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

    Public Shared Function GetElementoBriefingPorIndice(ByVal elementoBriefing As ElementoBriefingItem) As ElementoBriefingItem
        Dim Result As New ElementoBriefingItem
        Dim myElementoBriefing As New ElementoBriefingItem
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            myElementoBriefing = elementoBriefing
            req.myElementoBriefingItem = myElementoBriefing
            res = wsClnt.GetElementoProcesoPorIndice(req)
            If res.ActionResult Then
                Result = res.myElementoBriefingItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaCamionesPorIdGuia(ByVal idGuia As Guid, ByVal idBriefing As Guid) As DataTable
        Dim Result As New DataTable("dtGuiaCamiones")
        Dim myGuiaCamion As New GuiaCamionesItem
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            myGuiaCamion.idGuia = idGuia
            myGuiaCamion.idBriefing = idBriefing
            req.myGuiaCamionesItem = myGuiaCamion
            res = wsClnt.GetGuiaCamionesPorIdGuia(req)
            If res.ActionResult Then
                Result = res.dsGuiaCamiones.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetGuiaPorIdGuia(ByVal IdGuia As Guid) As GuiaItem
        Dim GuiaAgencia As New GuiaItem
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            GuiaAgencia.Id = IdGuia
            req.myGuiaItem = GuiaAgencia
            res = wsClnt.GetGuiaPorIdGuia(req)
            If res.ActionResult Then
                GuiaAgencia = res.myGuiaItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return GuiaAgencia
    End Function

    Public Shared Function GetMaterialEnvase() As DataTable
        Dim Result As New DataTable("dtMaterialEnvase")
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetMaterialEnvase(req)
            If res.ActionResult Then
                Result = res.dsMaterialEnvase.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetTipoEnvase() As DataTable
        Dim Result As New DataTable("dtTipoEnvase")
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetTipoEnvase(req)
            If res.ActionResult Then
                Result = res.dsTipoEnvase.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function GetProcesoPorIdProceso(ByVal Id As Guid) As ProcesoItem
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetProcesoPorIdProceso(req)
            If res.ActionResult Then
                resProceso = res.myProcesoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resProceso
    End Function

    Public Shared Function GetNovedadesPorIdProceso(ByVal Id As Guid) As NovedadesItem
        Dim resNovedades As New NovedadesItem
        Dim req As New NovedadesRequest
        Dim res As New NovedadesResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resNovedades.idProceso = Id
            req.myNovedadesItem = resNovedades
            res = wsClnt.GetNovedadesPorIdProceso(req)
            If res.ActionResult Then
                resNovedades = res.myNovedadesItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resNovedades
    End Function

    Public Shared Function GetAcarreoPorIdBriefing(ByVal Id As Guid) As AcarreoItem
        Dim resAcarreo As New AcarreoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resAcarreo.idBriefing = Id
            req.myAcarreoItem = resAcarreo
            res = wsClnt.GetAcarreoPorIdBriefing(req)
            If res.ActionResult Then
                resAcarreo = res.myAcarreoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resAcarreo
    End Function

    Public Shared Function GetProcesoPoridBriefing(ByVal Id As Guid) As ProcesoItem
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.idBriefing = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetProcesoPorIdBriefing(req)
            If res.ActionResult Then
                resProceso = res.myProcesoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resProceso
    End Function

    Public Shared Function GetValidezDaePorDae(ByVal numeroDae As String) As ValidezDae
        Dim resValidezDae As New ValidezDae
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            resValidezDae.numeroDae = numeroDae
            req.myValidezDae = resValidezDae
            res = wsClnt.GetValidezDaePorDae(req)
            If res.ActionResult Then
                resValidezDae = res.myValidezDae
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resValidezDae
    End Function

    Public Shared Function GetDetalleAcarreoPorId(ByVal Id As Guid) As DetalleAcarreoItem
        Dim resDetalleAcarreo As New DetalleAcarreoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        General.SetBARequest(req)
        Try
            resDetalleAcarreo.IdDetalle = Id
            req.myDetalleAcarreoItem = resDetalleAcarreo
            res = wsClnt.GetDetalleAcarreoPorId(req)
            If res.ActionResult Then
                resDetalleAcarreo = res.myDetalleAcarreoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resDetalleAcarreo
    End Function

    Public Shared Function GetDetalleProcesoPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProceso")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoDecomisoPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoDecomiso")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoDecomisoPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoPorIdProcesoCaptura(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProceso")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProcesoCaptura(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetTotalPorElementoPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoPorElemento")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetTotalPorElementoPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetElementoProcesoPorIdProcesoIdElemento(ByVal Id As Guid, ByVal idElemento As String) As DataTable
        Dim dtElementoProceso As New DataTable("dtElementoProceso")
        Dim ElementoProceso As New ElementoProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            ElementoProceso.IdProceso = Id
            ElementoProceso.idElemento = idElemento
            req.myElementoProcesoItem = ElementoProceso
            res = wsClnt.GetElementoProcesoPorIdProcesoIdElemento(req)
            If res.ActionResult Then
                dtElementoProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtElementoProceso
    End Function

    Public Shared Function GetElementoProcesoPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtElementoProceso As New DataTable("dtElementoProceso")
        Dim ElementoProceso As New ElementoProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            ElementoProceso.IdProceso = Id
            req.myElementoProcesoItem = ElementoProceso
            res = wsClnt.GetElementoProcesoPorIdProceso(req)
            If res.ActionResult Then
                dtElementoProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtElementoProceso
    End Function

    Public Shared Function GetElementoProcesoPorIdProcesoYEstado(ByVal Id As Guid) As DataTable
        Dim dtElementoProceso As New DataTable("dtElementoProcesoPorEstado")
        Dim ElementoProceso As New ElementoProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            ElementoProceso.IdProceso = Id
            req.myElementoProcesoItem = ElementoProceso
            res = wsClnt.GetElementoProcesoPorIdProcesoYEstado(req)
            If res.ActionResult Then
                dtElementoProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtElementoProceso
    End Function

    Public Shared Function GetTotalPorGuiaPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoPorGuia")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetTotalPorGuiaPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetTotalPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoTotal")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetTotalPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetNextSecuencialSenae() As Integer
        Dim secuencial As Integer = 0
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            res = wsClnt.GetNextSecuencialSenae(req)
            If res.ActionResult Then
                secuencial = res.dsResult.Tables(0).Rows(0).Item("nextSeq")
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return secuencial
    End Function

    Public Shared Function GetDetalleProcesoPorIdProceso2(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProceso")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProceso2(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoPorIdProcesoCargaI(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoCargaI")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProcesoCargaI(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoPorIdProcesoCargaR(ByVal Id As Guid) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoCargaR")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProcesoCargaR(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoPorIdGuia(ByVal Id As Guid, ByVal idGuia As String) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoPorGuia")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            req.prmArr = New String() {idGuia}
            res = wsClnt.GetDetalleProcesoPorIdGuia(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetCargaDevueltaPorIdProcesoGroupElemento(ByVal Id As Guid, ByVal idElemento As String) As DataTable
        Dim dtCargaDevuelta As New DataTable("CargaDevueltaElemento")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            req.prmArr = New String() {idElemento}
            res = wsClnt.GetCargaDevueltaPorIdProcesoGroupElemento(req)
            If res.ActionResult Then
                dtCargaDevuelta = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtCargaDevuelta
    End Function

    Public Shared Function GetCargaDevueltaPorIdProcesoGroupGuia(ByVal Id As Guid, ByVal idGuia As String) As DataTable
        Dim dtCargaDevuelta As New DataTable("CargaDevueltaElemento")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            req.prmArr = New String() {idGuia}
            res = wsClnt.GetCargaDevueltaPorIdProcesoGroupGuia(req)
            If res.ActionResult Then
                dtCargaDevuelta = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtCargaDevuelta
    End Function

    Public Shared Function ModificarDetalleProcesoMovientoPorIndice(ByVal DetalleProcesoMov As DetalleProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = DetalleProcesoMov
            res = WsClnt.ModificarDetalleProcesoMovientoPorIndice(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function ModificarEstadoSenaeDetalleProcesoCarga(ByVal DetalleProcesoMov As DetalleProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = DetalleProcesoMov
            res = WsClnt.ModificarEstadoSenaeDetalleProcesoCarga(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function ModificarEstadoDetalleProcesoPorIndice(ByVal DetalleProcesoMov As DetalleProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = DetalleProcesoMov
            res = WsClnt.ModificarEstadoDetalleProcesoPorIndice(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function ModificarEstadoDetalleProcesoPorfechaYGuia(ByVal DetalleProcesoMov As DetalleProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = DetalleProcesoMov
            res = WsClnt.ModificarEstadoDetalleProcesoPorfechaYGuia(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(ByVal DetalleProcesoMov As DetalleProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = DetalleProcesoMov
            res = WsClnt.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function modificarpesoCargaElementoProcesoPorIdProcesoElemento(ByVal ElementoProceso As ElementoProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoProcesoItem = ElementoProceso
            res = WsClnt.modificarpesoCargaElementoProcesoPorIdProcesoElemento(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ByVal ElementoProceso As ElementoProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoProcesoItem = ElementoProceso
            res = WsClnt.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Public Shared Function GetDetalleProcesoPorIdElemento(ByVal Id As Guid, ByVal idGuia As String) As DataTable
        Dim dtDetalleProceso As New DataTable("DetalleProcesoPorElemento")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            req.prmArr = New String() {idGuia}
            res = wsClnt.GetDetalleProcesoPorIdElemento(req)
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProceso
    End Function

    Public Shared Function GetDetalleProcesoPorIdProcesoReporte(ByVal Id As Guid) As DataTable
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoReporte")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoPorIdProcesoReporte(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetDetalleProcesoCargaPorIdProcesoReporte(ByVal Id As Guid) As DataTable
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoCargaReporte")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoCargaPorIdProcesoReporte(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento(ByVal Id As Guid)
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoCargaReporteElemento")
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByElemento As New ReportGroupByElemento
        Try
            General.SetBARequest(req)
            ReportGroupByElemento.idProceso = Id
            req.myReportGroupByElemento = ReportGroupByElemento
            res = wsClient.GetReportePorIdProcesoGroupByElemento(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento2(ByVal Id As Guid)
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoCargaReporteElemento")
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByElemento As New ReportGroupByElemento
        Try
            General.SetBARequest(req)
            ReportGroupByElemento.idProceso = Id
            req.myReportGroupByElemento = ReportGroupByElemento
            res = wsClient.GetReportePorIdProcesoGroupByElemento2(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetReportePorIdProcesoGroupByElemento3(ByVal Id As Guid)
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoCargaReporteElemento")
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByElemento As New ReportGroupByElemento
        Try
            General.SetBARequest(req)
            ReportGroupByElemento.idProceso = Id
            req.myReportGroupByElemento = ReportGroupByElemento
            res = wsClient.GetReportePorIdProcesoGroupByElemento3(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetDetalleProcesoCargaPorIdProcesoAlmacenaje(ByVal Id As Guid) As DataTable
        Dim dtDetalleProcesoReporte As New DataTable("DetalleProcesoCargaReporte")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleProcesoCargaPorIdProcesoAlmacenaje(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetDetalleAcarreoIdProcesoReporte(ByVal Id As Guid) As DataTable
        Dim dtDetalleAcarreoReporte As New DataTable("DetalleAcarreoReporte")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetalleAcarreoPorIdProcesoReporte(req)
            If res.ActionResult Then
                dtDetalleAcarreoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleAcarreoReporte
    End Function

    Public Shared Function GetDetallePersonalPorIdProcesoReporte(ByVal Id As Guid) As DataTable
        Dim dtDetalleProcesoReporte As New DataTable("DetallePersonalReporte")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetDetallePersonalPorIdProcesoReporte(req)
            If res.ActionResult Then
                dtDetalleProcesoReporte = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleProcesoReporte
    End Function

    Public Shared Function GetDetalleAcarreoPorIdAcarreo(ByVal Id As Guid) As DataTable
        Dim dtDetalleAcarreo As New DataTable("DetalleAcarreo")
        Dim resDetalleAcarreo As New DetalleAcarreoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resDetalleAcarreo.idAcarreo = Id
            req.myDetalleAcarreoItem = resDetalleAcarreo
            res = wsClnt.GetDetalleAcarreoPorIdAcarreo(req)
            If res.ActionResult Then
                dtDetalleAcarreo = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleAcarreo
    End Function

    Public Shared Function GetStackPalletsPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtDetalleAcarreo As New DataTable("DetalleAcarreo")
        Dim resDetalleAcarreo As New StackPalletsItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resDetalleAcarreo.idProceso = Id
            req.myStackPalletsItem = resDetalleAcarreo
            res = wsClnt.GetStackPalletsPorIdProceso(req)
            If res.ActionResult Then
                dtDetalleAcarreo = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleAcarreo
    End Function

    Public Shared Function GetDetalleAcarreoElementoPorIdAcarreo(ByVal Id As Guid) As DataTable
        Dim dtDetalleAcarreoElemento As New DataTable("DetalleAcarreoElemento")
        Dim resDetalleAcarreoElemento As New DetalleAcarreoElementoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resDetalleAcarreoElemento.idDetalleAcarreo = Id
            req.myDetalleAcarreoElementoItem = resDetalleAcarreoElemento
            res = wsClnt.GetDetalleAcarreoElementoPorIdAcarreo(req)
            If res.ActionResult Then
                dtDetalleAcarreoElemento = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleAcarreoElemento
    End Function

    Public Shared Function GetDetalleAcarreoStack(ByVal detalleAcarreo As DetalleAcarreoElementoItem) As DetalleAcarreoElementoItem
        Dim resDetalleAcarreo As New DetalleAcarreoElementoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        General.SetBARequest(req)
        Try
            req.myDetalleAcarreoElementoItem = detalleAcarreo
            res = wsClnt.GetDetalleAcarreoStack(req)
            If res.ActionResult Then
                resDetalleAcarreo = res.myDetalleAcarreoElementoItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resDetalleAcarreo
    End Function

    Public Shared Function GetDetalleAcarreoPorEstado(ByVal Id As Guid, estado As String) As DataTable
        Dim dtDetalleAcarreo As New DataTable("DetalleAcarreo")
        Dim resDetalleAcarreo As New DetalleAcarreoItem
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resDetalleAcarreo.idAcarreo = Id
            resDetalleAcarreo.estado = estado
            req.myDetalleAcarreoItem = resDetalleAcarreo
            res = wsClnt.GetDetalleAcarreoPorEstado(req)
            If res.ActionResult Then
                dtDetalleAcarreo = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            '  ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtDetalleAcarreo
    End Function

    Public Shared Function GetPersonalPorIdProceso(ByVal Id As Guid) As DataTable
        Dim dtPersonalProceso As New DataTable("PersonalProceso")
        Dim resProceso As New ProcesoItem
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim wsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            resProceso.IdProceso = Id
            req.myProcesoItem = resProceso
            res = wsClnt.GetPersonalPorIdProceso(req)
            If res.ActionResult Then
                dtPersonalProceso = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dtPersonalProceso
    End Function

    'Public Function NumeroDec(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As Infragistics.Win.UltraWinEditors.UltraTextEditor) As Integer

    '    Dim dig As Integer = Len(Text.Text & e.KeyChar)
    '    Dim a, esDecimal, NumDecimales As Integer
    '    Dim esDec As Boolean
    '    ' se verifica si es un digito o un punto 
    '    If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '        Return a
    '    Else
    '        e.Handled = True
    '    End If
    '    ' se verifica que el primer digito ingresado no sea un punto al seleccionar
    '    If Text.SelectedText <> "" Then
    '        If e.KeyChar = "." Then
    '            e.Handled = True
    '            Return a
    '        End If
    '    End If
    '    If dig = 1 And e.KeyChar = "." Then
    '        e.Handled = True
    '        Return a
    '    End If
    '    'aqui se hace la verificacion cuando es seleccionado el valor del texto
    '    'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
    '    If Text.SelectedText = "" Then
    '        ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
    '        For a = 0 To dig - 1
    '            Dim car As String = CStr(Text.Text & e.KeyChar)
    '            If car.Substring(a, 1) = "." Then
    '                esDecimal = esDecimal + 1
    '                esDec = True
    '            End If
    '            If esDec = True Then
    '                NumDecimales = NumDecimales + 1
    '            End If
    '            ' aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales 
    '            If NumDecimales >= 4 Or esDecimal >= 2 Then
    '                e.Handled = True
    '            End If
    '        Next
    '    End If
    '    Return a
    'End Function

    Public Shared Function ModificarEstadoElementoProcesoPorIndice(ByVal elementoProceso As ElementoProcesoItem) As Boolean
        Dim result As Boolean = False
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoProcesoItem = elementoProceso
            res = WsClnt.ModificarEstadoElementoProcesoPorIndice(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ' ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return result
    End Function

End Class
