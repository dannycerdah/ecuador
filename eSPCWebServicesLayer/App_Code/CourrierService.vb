Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports eSPCBusinessLayer

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class CourrierService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function SaveGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Return ProcesoCourrierManager.SaveGavetaGuia(req)
    End Function
    <WebMethod()>
    Public Function EliminarGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Return ProcesoCourrierManager.EliminarGavetaGuia(req)
    End Function

    <WebMethod()>
    Public Function ModificarGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Return ProcesoCourrierManager.ModificarGavetaGuia(req)
    End Function
    <WebMethod()>
    Public Function ObtenerGavetaGuiaporBriefingIdGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Return ProcesoCourrierManager.GetGavetaGuiaporBriefingIdGuia(req)
    End Function

    'getGavetaGuiaporIdGuiaIdElemento

    <WebMethod()>
    Public Function getGavetaGuiaporIdGuiaIdElemento(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Return ProcesoCourrierManager.getGavetaGuiaporIdGuiaIdElemento(req)
    End Function



End Class