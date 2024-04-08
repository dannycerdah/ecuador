Imports System.Web.Services
Imports eSPCBusinessLayer

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://espc.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class ControlTemp
    Inherits System.Web.Services.WebService
    <WebMethod()>
    Public Function ObtenerCuartosFrios(req As TempRequest) As TempResponse
        Return TemperaturaManager.ObtenerCuartosFrios(req)
    End Function
    <WebMethod()>
    Public Function ObtenerConfTemp(req As TempRequest) As TempResponse
        Return TemperaturaManager.ObtenerConfTemp(req)
    End Function
    <WebMethod()>
    Public Function ObtenerTempAct(req As TempRequest) As TempResponse
        Return TemperaturaManager.ObtenerTempAct(req)
    End Function
    <WebMethod()>
    Public Function RegConfTemp(req As TempRequest) As TempResponse
        Return TemperaturaManager.RegConfTemp(req)
    End Function
    <WebMethod()>
    Public Function RegCuartoFrio(req As TempRequest) As TempResponse
        Return TemperaturaManager.RegCuartoFrio(req)
    End Function
    <WebMethod()>
    Public Function RegTemperatura(req As TempRequest) As TempResponse
        Return TemperaturaManager.RegTemperatura(req)
    End Function
    <WebMethod()>
    Public Function RegTemperaturaHist(req As TempRequest) As TempResponse
        Return TemperaturaManager.RegTemperaturaHist(req)
    End Function
    <WebMethod()>
    Public Function ActualizaVersion(req As String) As Boolean
        Return TemperaturaManager.ActualizaVersion(req)
    End Function
    <WebMethod()>
    Public Function ObtenerReportTemp(req As TempRequest) As TempResponse
        Return TemperaturaManager.ObtenerReportTemp(req)
    End Function
    <WebMethod()>
    Public Function ObtenerCuartoFrioIdProIdGui(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Return TemperaturaManager.ObtenerCuartoFrioIdProIdGui(req)
    End Function
    <WebMethod()>
    Public Function AgregaBitacoraCargaCuarto(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Return TemperaturaManager.AgregaBitacoraCargaCuarto(req)
    End Function
    <WebMethod()>
    Public Function ObtenerVuelosElemen(req As TempBitacoraCuartoRequest) As TempBitacoraCuartoResponse
        Return TemperaturaManager.ObtenerVuelosElemen(req)
    End Function
    <WebMethod()>
    Public Function ObtenerParametrosNoti(req As NotificacionTempRequest) As NotificacionTempResponse
        Return TemperaturaManager.ObtenerParametrosNoti(req)
    End Function
    <WebMethod()>
    Public Function MantNotificacionTemp(req As NotificacionTempRequest) As NotificacionTempResponse
        Return TemperaturaManager.MantNotificacionTemp(req)
    End Function
    <WebMethod()>
    Public Function ObtenerRegCuartProduc() As NotificacionTempResponse
        Return TemperaturaManager.ObtenerRegCuartProduc()
    End Function
End Class