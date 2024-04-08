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
Public Class VuelosService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetDetalleVueloPorFecha(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetDetalleVueloPorFecha(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleVueloPorFechaHoy(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetDetalleVueloPorFechaHoy(req)
    End Function

    <WebMethod()> _
    Public Function GetVuelosPorIdAgencia(req As VueloRequest) As VueloResponse
        Return VueloManager.GetVuelosPorIdAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetRutaVueloPorId(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetRutaVueloPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleVueloPorCodigo(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetDetalleVueloPorCodigo(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleVueloPorIdVuelo(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetDetalleVueloPorIdVuelo(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleVueloPorIdBriefing(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.GetDetalleVueloPorIdBriefing(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoProcesoPorIndice(req As VueloRequest) As VueloResponse
        Return VueloManager.GetElementoProcesoPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoBriefingPorIdBriefing(req As VueloRequest) As VueloResponse
        Return VueloManager.GetElementoBriefingPorIdBriefing(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoBriefingPorIdElemento(req As VueloRequest) As VueloResponse
        Return VueloManager.GetElementoBriefingPorIdElemento(req)
    End Function


    <WebMethod()> _
    Public Function GetVueloPorId(req As VueloRequest) As VueloResponse
        Return VueloManager.GetVueloPorId(req)
    End Function

    <WebMethod()> _
    Public Function SaveVueloItem(req As VueloRequest) As VueloResponse
        Return VueloManager.SaveVueloItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoBriefingItem(req As VueloRequest) As VueloResponse
        Return VueloManager.SaveElementoBriefingItem(req)
    End Function


    <WebMethod()> _
    Public Function SaveDetalleVuelo(req As DetalleVueloRequest) As DetalleVueloResponse
        Return VueloManager.SaveDetalleVuelo(req)
    End Function

    <WebMethod()> _
    Public Function SaveDetalleRutaVueloItem(req As DetalleRutaVueloRequest) As DetalleRutaVueloResponse
        Return VueloManager.SaveDetalleRutaVueloItem(req)
    End Function

    <WebMethod()> _
    Public Function GetRutaVueloPorIdVuelo(req As VueloRequest) As VueloResponse
        Return VueloManager.GetRutaVueloPorIdVuelo(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaPorIdBriefing(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaPorIdBriefing(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaPorIdGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoEnvase(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetTipoEnvase(req)
    End Function

    <WebMethod()> _
    Public Function GetMaterialEnvasePorId(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetMaterialEnvasePorId(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoEnvasePorId(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetTipoEnvasePorId(req)
    End Function

    <WebMethod()> _
    Public Function GetValidezDaePorDae(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetValidezDaePorDae(req)
    End Function

    <WebMethod()> _
    Public Function GetMaterialEnvase(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetMaterialEnvase(req)
    End Function

    <WebMethod()> _
    Public Function SaveGuiaItem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.SaveGuiaItem(req)
    End Function

    <WebMethod()> _
    Public Function ModificarEstadoReporteGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.ModificarEstadoReporteGuia(req)
    End Function

    <WebMethod()> _
    Public Function SaveGuiaProductosItem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.SaveGuiaProductosItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveGuiaCamionesItem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.SaveGuiaCamionesItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveGuiaDaesItem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.SaveGuiaDaesItem(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaProductosPorIdGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaProductosPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaCamionesPorId(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaCamionesPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaCamionesPorIdGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaCamionesPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetGuiaDaesPorIdGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetGuiaDaesPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function DeleteGuiaCamion(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteGuiaCamion(req)
    End Function

    <WebMethod()> _
    Public Function modificarEstadoElementoBriefingPorIndice(req As VueloRequest) As VueloResponse
        Return VueloManager.modificarEstadoElementoBriefingPorIndice(req)
    End Function

    <WebMethod()> _
    Public Function DeleteDetalleGuiaProducto(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteDetalleGuiaProducto(req)
    End Function

    <WebMethod()> _
    Public Function DeleteDetalleGuiaCamiones(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteDetalleGuiaCamiones(req)
    End Function

    <WebMethod()> _
    Public Function DeleteGuiaDae(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteGuiaDae(req)
    End Function

    <WebMethod()> _
    Public Function DeleteGuiaItem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteGuiaItem(req)
    End Function

    <WebMethod()> _
    Public Function GetEstadoReporteGuiaPorIdGuia(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetEstadoReporteGuiaPorIdGuia(req)
    End Function

    <WebMethod()> _
    Public Function GetVuelosGuiasToday(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.GetVuelosGuiasToday(req)
    End Function

    <WebMethod()> _
    Public Function GetAgenciasByBriefing(req As DetalleVueloRequest) As VueloResponse
        Return VueloManager.GetAgenciasByBriefing(req)
    End Function

    <WebMethod()> _
    Public Function SaveHistoricoDaesRem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.SaveHistoricoDaesRem(req)
    End Function
    <WebMethod()> _
    Public Function DeleteHistoricoDaesRem(req As GuiaRequest) As GuiaResponse
        Return GuiaManager.DeleteHistoricoDaesRem(req)
    End Function
    <WebMethod()>
    Public Function obtenerdetalleVueloPorFechaHoy2(req As DetalleVueloRequest) As DetalleVueloResponse
        Return ReporteResumidoManager.obtenerdetalleVueloPorFechaHoy2(req)
    End Function
End Class