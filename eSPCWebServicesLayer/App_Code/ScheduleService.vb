Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports eSPCBusinessLayer

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://server.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ScheduleService
    Inherits System.Web.Services.WebService


    <WebMethod()> _
    Public Function SaveInDB(ByVal schReq As RegBiometricoRequest) As RegBiometricoResponse
        Return RegBiometricoManager.SaveInDB(schReq)
    End Function

    <WebMethod()> _
    Public Function JustifyScheduleCondensed(ByVal schReq As RegBiometricoRequest) As RegBiometricoResponse
        Return RegBiometricoManager.JustifyScheduleCondensed(schReq)
    End Function

    <WebMethod()> _
    Public Function SaveNewScheduleShift(ByVal schReq As RegBiometricoRequest) As RegBiometricoResponse
        Return RegBiometricoManager.SaveNewScheduleShift(schReq)
    End Function

End Class