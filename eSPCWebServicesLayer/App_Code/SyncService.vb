Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports eSPCBusinessLayer

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://espc.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class SyncService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetServerLastUpdate(ByVal req As SyncRequest) As SyncResponse
        Return SyncManager.GetServerLastUpdate(req)
    End Function

End Class