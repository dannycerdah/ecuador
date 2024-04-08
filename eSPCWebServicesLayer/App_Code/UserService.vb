Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports eSPCBusinessLayer

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://espc.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class UserService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function CheckUserCode(ByVal req As UserRequest) As UserResponse
        Return UserManager.CheckUserCode(req)
    End Function

    <WebMethod()> _
    Public Function GetUserByCode(ByVal req As UserRequest) As UserResponse
        Return UserManager.GetUserbyCode(req)
    End Function

    <WebMethod()> _
    Public Function LogIn(ByVal req As UserRequest) As UserResponse
        Return UserManager.LogIn(req)
    End Function

    <WebMethod()> _
    Public Function LogOut(ByVal req As UserRequest) As Boolean
        Return UserManager.LogOut(req)
    End Function

    <WebMethod()> _
    Public Function SaveUser(ByVal req As UserRequest) As UserResponse
        Return UserManager.SaveUser(req)
    End Function
    <WebMethod()> _
    Public Function SaveBitacoraPermiso(ByVal req As UserRequest) As UserResponse
        Return UserManager.SaveBitacoraPermiso(req)
    End Function
    <WebMethod()> _
    Public Function SaveAutorizacionesOnline(ByVal req As AutorizacionesOnlineRequest) As AutorizacionesOnlineResponse
        Return AutorizacionesOnlineManager.SaveAutorizacionesOnline(req)
    End Function
    <WebMethod()> _
    Public Function GetAutorizacionesOnline(ByVal req As AutorizacionesOnlineRequest) As AutorizacionesOnlineResponse
        Return AutorizacionesOnlineManager.GetAutorizacionesOnline(req)
    End Function
    <WebMethod()>
    Public Function AprobarAutorizacionOnline(idAutorizacion As String, UsuarioAutoriza As String) As String
        Return AutorizacionesOnlineManager.AprobarAutorizacionOnline(idAutorizacion, UsuarioAutoriza)
    End Function

    Public Function GetEmpresas(req As EmpresaRequest) As EmpresaResponse
        Return GetEmpresas(req)
    End Function
    Public Function GetEmpresaItemById(req As EmpresaRequest) As EmpresaResponse
        Return GetEmpresaItemById(req)
    End Function
    Public Function SaveEmpresaItem(req As EmpresaRequest) As EmpresaResponse
        Return SaveEmpresaItem(req)
    End Function


End Class