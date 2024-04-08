Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports eSPCBusinessLayer
' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://espc.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ProcesoService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetActividadPorIdTipoAgencia(req As ActividadRequest) As ActividadResponse
        Return ActividadManager.GetActividadPorIdTipoAgencia(req)
    End Function

    <WebMethod()> _
    Public Function SaveProcesoItem(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.SaveProcesoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveDocSenae(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.SaveDocSenae(req)
    End Function

    <WebMethod()> _
    Public Function SaveNovedadesItem(req As NovedadesRequest) As NovedadesResponse
        Return ProcesoManager.SaveNovedadesItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoProcesoItem(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.SaveElementoProcesoItem(req)
    End Function

    <WebMethod()> _
    Public Function ModificarEstadoElementoProcesoPorIndice(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.ModificarEstadoElementoProcesoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function modificarpesoCargaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.modificarpesoCargaElementoProcesoPorIdProcesoElemento(req)
    End Function

    <WebMethod()> _
    Public Function modificarpesoCapturaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.modificarPesoCapturaElementoProcesoPorIdProcesoElemento(req)
    End Function

    <WebMethod()> _
    Public Function modificarpesoDescargaElementoProcesoPorIdProcesoElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.modificarPesoDescargaElementoProcesoPorIdProcesoElemento(req)
    End Function

    <WebMethod()> _
    Public Function SaveAcarreoItem(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.SaveAcarreoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveStackPalletsItem(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.SaveStackPalletsItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveDetalleAcarreoItem(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.SaveDetalleAcarreoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveDetalleAcarreoElementoItem(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.SaveDetalleAcarreoElementoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveDetalleProcesoItem(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.SaveDetalleProcesoItem(req)
    End Function

    <WebMethod()> _
    Public Function ModificarDetalleProcesoMovientoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.ModificarDetalleProcesoMovientoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function ModificarEstadoSenaeDetalleProcesoCarga(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.ModificarEstadoSenaeDetalleProcesoCarga(req)
    End Function

    <WebMethod()> _
    Public Function ModificarEstadoDetalleProcesoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.ModificarEstadoDetalleProcesoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function ModificarEstadoDetalleProcesoPorfechaYGuia(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.ModificarEstadoDetalleProcesoPorfechaYGuia(req)
    End Function

    <WebMethod()> _
    Public Function ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(req)
    End Function

    <WebMethod()> _
    Public Function SavePersonalProcesoItem(req As PersonalProcesoRequest) As PersonalProcesoResponse
        Return PersonalProcesoManager.SavePersonalProcesoItem(req)
    End Function

    <WebMethod()> _
    Public Function DeletePersonalProceso(req As PersonalProcesoRequest) As PersonalProcesoResponse
        Return PersonalProcesoManager.DeletePersonalProceso(req)
    End Function

    <WebMethod()> _
    Public Function DeleteDetalleProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.DeleteDetalleProceso(req)
    End Function

    <WebMethod()> _
    Public Function DeleteDetalleProcesoPorIndice(req As DetalleProcesoRequest) As DetalleProcesoResponse
        Return ProcesoManager.DeleteDetalleProcesoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function GetProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetProcesoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetNovedadesPorIdProceso(req As NovedadesRequest) As NovedadesResponse
        Return ProcesoManager.GetNovedadesPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetElementoProcesoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoProcesoPorIdProcesoYEstado(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetElementoProcesoPorIdProcesoYEstado(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoProcesoPorIdProcesoIdElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetElementoProcesoPorIdProcesoIdElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoProcesoPorIndice(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetElementoProcesoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function GetProcesoPorIdBriefing(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetProcesoPorIdBriefing(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProcesoDev(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProcesoDev(req)
    End Function

    <WebMethod()> _
    Public Function GetInfoProcesoPorIdAgenciaYFecha(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetInfoProcesoPorIdAgenciaYFecha(req)
    End Function

    <WebMethod()> _
    Public Function GetInfoDetalleProcesoPorIdAgenciaYFecha(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetInfoDetalleProcesoPorIdAgenciaYFecha(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoDecomisoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoDecomisoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetTotalPorGuiaPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetTotalPorGuiaPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetTotalPorGuiaPorIdProcesoDev(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetTotalPorGuiaPorIdProcesoDev(req)
    End Function

    <WebMethod()> _
    Public Function GetTotalPorElementoPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetTotalPorElementoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetTotalPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetTotalPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetNextSecuencialSenae(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetNextSecuencialSenae(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProcesoCaptura(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProcesoCaptura(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProceso2(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProceso2(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProcesoCargaI(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProcesoCargaI(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProcesoCargaR(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProcesoCargaR(req)
    End Function

    <WebMethod()> _
    Public Function GetCargaDevueltaPorIdProcesoGroupElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetCargaDevueltaPorIdProcesoGroupElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetCargaDevueltaPorIdProcesoGroupGuia(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetCargaDevueltaPorIdProcesoGroupGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdGuia(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdElemento(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoPorIdProcesoReporte(req)
    End Function

    <WebMethod()> _
    Public Function GetSubtotalCargaProcesadaPorDia(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetSubtotalCargaProcesadaPorDia(req)
    End Function

    <WebMethod()> _
    Public Function GetSubtotalCargaProcesadaPorMes(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetSubtotalCargaProcesadaPorMes(req)
    End Function

    <WebMethod()> _
    Public Function GetSubtotalCargaProcesadaPorAño(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetSubtotalCargaProcesadaPorAño(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoCargaPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoCargaPorIdProcesoReporte(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleProcesoCargaPorIdProcesoAlmacenaje(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoCargaPorIdProcesoAlmacenaje(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleAcarreoPorIdProcesoReporte(req)
    End Function

    <WebMethod()> _
    Public Function GetDetallePersonalPorIdProcesoReporte(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetallePersonalPorIdProcesoReporte(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoPorIdAcarreo(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoPorIdAcarreo(req)
    End Function

    <WebMethod()> _
    Public Function GetStackPalletsPorIdProceso(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetStackPalletsPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoPorId(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoElementoPorIdAcarreo(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoElementoPorIdAcarreo(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoStack(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoStack(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoElementoPorId(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoElementoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoPorEstado(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoPorEstado(req)
    End Function

    <WebMethod()> _
    Public Function GetPersonalPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return PersonalProcesoManager.GetPersonalPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetAcarreoPorIdAcarreo(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetAcarreoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetStackPalletsPorIndice(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetStackPalletsPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function GetAcarreoPorIdBriefing(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetAcarreoPorIdBriefing(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleAcarreoPorIdDetalle(req As AcarreoRequest) As AcarreoResponse
        Return AcarreoManager.GetDetalleAcarreoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByAgenciaCarga(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByAgenciaCarga(req)
    End Function

    <WebMethod()> _
    Public Function GetReporteDetalleProcesoPorIdProceso(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteDetalladoManager.GetReporteDetalleProcesoPorIdProceso(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByElemento(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByElemento2(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByElemento2(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByElemento3(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByElemento3(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByDestino(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByDestino(req)
    End Function

    <WebMethod()> _
    Public Function GetReportePorIdProcesoGroupByGuia(req As ReportGroupRequest) As ReportGroupResponse
        Return ReporteResumidoManager.GetReportePorIdProcesoGroupByGuia(req)
    End Function
    <WebMethod()> _
    Public Function SaveProduccionItem(req As ProduccionRequest) As ProduccionResponse
        Return ProcesoManager.SaveProduccionItem(req)
    End Function

    <WebMethod()> _
    Public Function GetProductionAgenciaDescription(req As ReportRequest) As ReportResponse
        Return ProcesoManager.GetProductionAgenciaDescription(req)
    End Function
    <WebMethod()>
    Public Function GetDetalleProcesoDecomisoDaePorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleProcesoDecomisoDaePorIdProceso(req)
    End Function
    <WebMethod()>
    Public Function GetDetalleMatrizSeguridadDecoporIdProceso(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.GetDetalleMatrizSeguridadDecoporIdProceso(req)
    End Function
    <WebMethod()>
    Public Function Sp_RegReporteVuelosEnviados(req As ReportVuelosEnviadosRequest) As ReportVuelosEnviadosResponse
        Return ReporteResumidoManager.Sp_RegReporteVuelosEnviados(req)
    End Function
    <WebMethod()>
    Public Function Sp_MantControlEjecutHilo(req As ControlEjecucionHiloRequest) As ControlEjecucionHiloResponse
        Return ReporteResumidoManager.Sp_MantControlEjecutHilo(req)
    End Function

    <WebMethod()>
    Public Function SaveDetalleSellosCamiones(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Return ProcesoManager.SaveDetalleSellosCamiones(req)
    End Function

    <WebMethod()>
    Public Function DeleteDetalleSellosCamiones(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Return ProcesoManager.DeleteDetalleSellosCamiones(req)
    End Function

    <WebMethod()>
    Public Function GetDetalleSellosCamionesporidguiacamion(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Return ProcesoManager.GetDetalleSellosCamionesporidguiacamion(req)
    End Function

    <WebMethod()>
    Public Function GetDetalleSellosCamionesporidguia(req As DetalleSelloCamionesRequest) As DetalleSelloCamionesResponse
        Return ProcesoManager.GetDetalleSellosCamionesporidguia(req)
    End Function
    <WebMethod()>
    Public Function Getdetalleprocesocargaporidbriefingidguia(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.Getdetalleprocesocargaporidbriefingidguia(req)
    End Function

    <WebMethod()>
    Public Function MovimientoPorGuia(req As ProcesoRequest) As ProcesoResponse
        Return ProcesoManager.MovimientoPorGuia(req)
    End Function

End Class