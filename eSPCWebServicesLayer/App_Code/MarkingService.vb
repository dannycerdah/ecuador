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
Public Class MarkingService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetAllInfoContacto(req As MarcacionContactoRequest) As MarkingResponse
        Return MarkingManager.GetAllInfoContacto(req)
    End Function

    <WebMethod()> _
    Public Function CheckNewBioRecords(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.CheckNewBioRecords(req)
    End Function

    <WebMethod()>
    Public Function GetZonasAutorizadas(req As ZonasAutorizadasRequest) As MarkingResponse
        Return MarkingManager.GetAllZonasAutorizadas(req)
    End Function


    <WebMethod()>
    Public Function GetZonasAutorizadasByContacto(req As ZonasAutorizadasByContactoRequest) As MarkingResponse
        Return MarkingManager.GetZonasAutorizadasByContacto(req)
    End Function

    <WebMethod()>
    Public Function GetSesionContactoById(req As SesionContactosRequest) As MarkingResponse
        Return MarkingManager.GetSesionContactoById(req)
    End Function

    <WebMethod()>
    Public Function SaveSesionContacto(req As SesionContactosRequest) As SesionContactosResponse
        Return MarkingManager.SaveSesionContacto(req)
    End Function

    <WebMethod()>
    Public Function SaveHistoricoSesionContacto(req As HistoricoSesionContactosRequest) As HistoricoSesionContactosResponse
        Return MarkingManager.SaveHistoricoSesionContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetContactoZonasSession(req As ContactoZonasSessionRequest) As ContactoZonasSessionResponse
        Return MarkingManager.GetContactoZonasSession(req)
    End Function

    <WebMethod()> _
    Public Function GetLogContactoZonasSession(req As ContactoZonasSessionRequest) As ContactoZonasSessionResponse
        Return MarkingManager.GetContactoZonasSession(req)
    End Function


    <WebMethod()>
    Public Function SaveMarkingGeneral(req As MarkingGeneralRequest) As MarkingGeneralResponse
        Return MarkingManager.SaveMarkingGeneral(req)
    End Function

    <WebMethod()> _
    Public Function GetMarkingsGeneralair(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetMarkingsGeneralair(req)
    End Function

    <WebMethod()> _
    Public Function UpdateMarkingGeneralair(req As MarkingGeneralRequest) As MarkingGeneralResponse
        Return MarkingManager.UpdateMarkingGeneralair(req)
    End Function

    <WebMethod()> _
    Public Function GetContactoByAgenciaById(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetContactoByAgenciaById(req)
    End Function

    <WebMethod()> _
    Public Function GetAllPermisosEspeciales(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetAllPermisosEspeciales(req)
    End Function

    <WebMethod()>
    Public Function SavePermisoEspecialItem(req As ContactoRequest) As PermisoContactoResponse
        Return MarkingManager.SavePermisoEspecialItem(req)
    End Function

    <WebMethod()>
    Public Function GetContactosByPermiso(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetContactosByPermiso(req)
    End Function

    <WebMethod()>
    Public Function GetPermisoEspecialById(req As ContactoRequest) As PermisoContactoResponse
        Return MarkingManager.GetPermisoEspecialById(req)
    End Function

    <WebMethod()>
    Public Function GetPermisosEspecialesByContacto(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetPermisosEspecialesByContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetContactoByContactoByTipoAgencia(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetExistsContactoByContactoByTipoAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetHorarioDayByEmpleado(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetHorarioDayByEmpleado(req)
    End Function

    <WebMethod()>
    Public Function GetUldEntradaToday(req As ContactoRequest) As MarkingResponse
        Return MarkingManager.GetUldEntradaToday(req)
    End Function
    <WebMethod()>
    Public Function MantHorarioAgenciaSeguridad(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Return MarkingManager.MantHorarioAgenciaSeguridad(req)
    End Function
    <WebMethod()>
    Public Function GetHorAgenSeguridad(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Return MarkingManager.GetHorAgenSeguridad(req)
    End Function
    <WebMethod()>
    Public Function GetAgenciaExcluidaMarcacion(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Return MarkingManager.GetAgenciaExcluidaMarcacion(req)
    End Function

    <WebMethod()>
    Public Function SaveAuditoriaReconocimientoFacial(req As AuditoriaReconocimientoFacialRequest) As AuditoriaReconocimientoFacialResponse
        Return MarkingManager.SaveAuditoriaReconocimientoFacial(req)
    End Function

End Class