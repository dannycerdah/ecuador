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
Public Class ReportService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetEntireTarifasCatalog(req As ReportRequest) As ReportResponse
        Return TarifaManager.GetEntireTarifaCatalog(req)
    End Function
    <WebMethod()> _
    Public Function GetTarifaPorId(req As ReportRequest) As ReportResponse
        Return TarifaManager.GetTarifaById(req)
    End Function
    <WebMethod()> _
    Public Function GetTarifaporAgenciayFecha(req As ReportRequest) As ReportResponse
        Return TarifaManager.GetTarifaByAgenciayFecha(req)
    End Function
    <WebMethod()> _
    Public Function GetEntireProduccion(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEntireProduccion(req)
    End Function
    <WebMethod()> _
    Public Function GetEntireProduccionId(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEntireProduccionById(req)
    End Function
    <WebMethod()> _
    Public Function GetDestinatariosbyIdReporteyAgencia(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetDestinatariosbyIdReporteyAgencia(req)
    End Function
    <WebMethod()> _
    Public Function GetDestinatariosPorIdReporte(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetDestinatariosPorIdReporte(req)
    End Function
    <WebMethod()> _
    Public Function SaveDestinatarioItem(req As DestinatarioRequest) As DestinatarioResponse
        Return ContactoManager.SaveDestinatarioItem(req)
    End Function
    <WebMethod()> _
    Public Function GetDestinatarioItemPorId(req As DestinatarioRequest) As DestinatarioResponse
        Return ContactoManager.GetDestinatarioItemById(req)
    End Function
    <WebMethod()> _
    Public Function GetDestinatariosAgencias(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetDestinatariosAgencias(req)
    End Function
    <WebMethod()> _
    Public Function GetDestinatarios(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetDestinatarios(req)
    End Function
    <WebMethod()> _
    Public Function GetEntireAirportCatalog(req As ReportRequest) As ReportResponse
        Return AirportManager.GetEntireAirportCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireVuelosCatalog(req As ReportRequest) As ReportResponse
        Return VueloManager.GetEntireVuelosCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireAirportSimple(req As ReportRequest) As ReportResponse
        Return AirportManager.GetEntireAirportSimple(req)
    End Function

    <WebMethod()> _
    Public Function GetAirportItemById(req As AirportRequest) As AirportResponse
        Return AirportManager.GetAirportItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveAirportInfo(req As AirportRequest) As AirportResponse
        Return AirportManager.SaveAirportItem(req)
    End Function

    <WebMethod()> _
    Public Function GetPais(req As ReportRequest) As ReportResponse
        Return AirportManager.GetPais(req)
    End Function

    <WebMethod()> _
    Public Function GetCiudad(req As ReportRequest) As ReportResponse
        Return AirportManager.GetCiudad(req)
    End Function

    <WebMethod()> _
    Public Function GetCiudadPorId(req As ReportRequest) As ReportResponse
        Return AirportManager.GetCiudadPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireAirplaneCatalog(req As ReportRequest) As ReportResponse
        Return AirplaneManager.GetEntireAirplaneCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetAirplaneItemById(req As AirplaneRequest) As AirplaneResponse
        Return AirplaneManager.GetAirplaneItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveAirplaneInfo(req As AirplaneRequest) As AirplaneResponse
        Return AirplaneManager.SaveAirplaneItem(req)
    End Function

    <WebMethod()> _
    Public Function GetTipo(req As ReportRequest) As ReportResponse
        Return AirplaneManager.GetTipo(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoPorId(req As ReportRequest) As ReportResponse
        Return AirplaneManager.GetTipoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireCamionCatalog(req As ReportRequest) As ReportResponse
        Return CamionManager.GetEntireCamionCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireCamionByIdAgencia(req As CamionRequest) As ReportResponse
        Return CamionManager.GetEntireCamionByIdAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetCamionItemById(req As CamionRequest) As CamionResponse
        Return CamionManager.GetCamionItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleCamionContactoByIdFecha(req As CamionRequest) As ReportResponse
        Return CamionManager.GetDetalleCamionContactoByIdFecha(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleCamionContactoByIdCamion(req As CamionRequest) As ReportResponse
        Return CamionManager.GetDetalleCamionContactoByIdCamion(req)
    End Function

    <WebMethod()> _
    Public Function GetDetalleCamionContactoByIdDetalle(req As CamionRequest) As CamionResponse
        Return CamionManager.GetDetalleCamionContactoByIdDetalle(req)
    End Function

    <WebMethod()> _
    Public Function CheckCamionMatricula(req As CamionRequest) As ReportResponse
        Return CamionManager.CheckCamionMatriculaItem(req)
    End Function
    <WebMethod()> _
    Public Function SaveCamionInfo(req As CamionRequest) As CamionResponse
        Return CamionManager.SaveCamionItem(req)
    End Function

    <WebMethod()> _
    Public Function GetEstado(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEstado(req)
    End Function

    <WebMethod()> _
    Public Function GetEstadoPorId(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEstadoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetEstadoElemento(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEstadoElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetEstadoElementoPorId(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetEstadoElementoPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetAgencia(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetAgenciaPorId(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetAgenciaPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireAgenciaCatalog(req As ReportRequest) As ReportResponse
        Return AgenciaManager.GetEntireAgenciaCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetAgenciaItemById(req As AgenciaRequest) As AgenciaResponse
        Return AgenciaManager.GetAgenciaItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveAgenciaInfo(req As AgenciaRequest) As AgenciaResponse
        Return AgenciaManager.SaveAgenciaItem(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoAgencia(req As ReportRequest) As ReportResponse
        Return AgenciaManager.GetEntireTipoAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoAgencia(req As ReportRequest) As ReportResponse
        Return AgenciaManager.GetEntireArchivoAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoContacto(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetEntireArchivoContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoAgenciaItemById(req As ArchivoAgenciaRequest) As ArchivoAgenciaResponse
        Return AgenciaManager.GetArchivoAgenciaItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoContactoItemById(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.GetArchivoContactoItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoAgenciaItemByIdAgencia(req As ArchivoAgenciaRequest) As ReportResponse
        Return AgenciaManager.GetArchivoAgenciaItemByIdAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetArchivoContactoItemByIdContacto(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetArchivoContactoItemByIdContacto(req)
    End Function

    <WebMethod()>
    Public Function GetRegBiometricoByIdContacto(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetRegBiometricoByIdContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoAgenciaItemById(req As TipoAgenciaRequest) As TipoAgenciaResponse
        Return AgenciaManager.GetTipoAgenciaItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoAgenciaPorId(req As ReportRequest) As ReportResponse
        Return AgenciaManager.GetTipoAgenciaPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetAgenciaItemPorTipo(req As ReportRequest) As ReportResponse
        Return AgenciaManager.GetAgenciaItemPorTipo(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireMatrizSeguridadCatalog(req As ReportRequest) As ReportResponse
        Return MatrizSeguridadManager.GetEntireMatrizSeguridadCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetMatrizSeguridadItemById(req As ReportRequest) As ReportResponse
        Return MatrizSeguridadManager.GetMatrizSeguridadItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveMatrizSeguridadItem(req As MatrizSeguridadRequest) As MatrizSeguridadResponse
        Return MatrizSeguridadManager.SaveMatrizSeguridadItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveDetalleMatrizSeguridadItem(req As MatrizSeguridadRequest) As MatrizSeguridadResponse
        Return MatrizSeguridadManager.SaveDetalleMatrizSeguridadItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveUldHistoricoItem(req As uldHistoricoRequest) As uldHistoricoResponse
        Return uldHistoricoManager.SaveUldHistoricoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveUldHistoricoDetalleItem(req As uldHistoricoRequest) As uldHistoricoResponse
        Return uldHistoricoManager.SaveUldHistoricoDetalleItem(req)
    End Function

    <WebMethod()> _
    Public Function GetContactoItemById(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.GetContactoItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetusuarioItemById(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.GetUsuarioItemById(req)
    End Function


    <WebMethod()> _
    Public Function GetContactoAgenciaItemById(req As ContactoAgenciaRequest) As ContactoAgenciaResponse
        Return ContactoManager.GetContactoAgenciaItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetContactoAgenciaItemByIdAgencia(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetContactoAgenciaItemByIdAgencia(req)
    End Function

    <WebMethod()>
    Public Function GetContactoAgenciaItemByIdContacto(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetContactoAgenciaItemByIdContacto(req)
    End Function

    <WebMethod()>
    Public Function GetPersonalAutorizadoCourierbyContacto(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetPersonalAutorizadoCourierbyContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetAvionPorIdAgencia(req As ReportRequest) As ReportResponse
        Return AirplaneManager.GetAvionPorIdAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetAeropuertoPorIdPais(req As ReportRequest) As ReportResponse
        Return AirportManager.GetAeropuertoPorIdPais(req)
    End Function

    <WebMethod()> _
    Public Function GetAeropuertoPorIdCiudad(req As ReportRequest) As ReportResponse
        Return AirportManager.GetAeropuertoPorIdCiudad(req)
    End Function

    <WebMethod()> _
    Public Function GetCiudadPorIdPais(req As ReportRequest) As ReportResponse
        Return CiudadManager.GetCiudadPorIdPais(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireProductoCatalog(req As ReportRequest) As ReportResponse
        Return ProductoManager.GetEntireProductoCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoDocPorId(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetTipoDocPorId(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoDocCatalog(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetTipoDocCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetCargoCatalog(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetCargoCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireContactoCatalog(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetEntireContactoCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireUsuarioCatalog(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetEntireUsuarioCatalog(req)
    End Function


    <WebMethod()> _
    Public Function GetEntirePosicionesCatalog(req As ReportRequest) As ReportResponse
        Return VueloManager.GetEntirePosicionesCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetProductoPorIdTipo(req As ReportRequest) As ReportResponse
        Return ProductoManager.GetProcutoPorIdTipo(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireTipoProducto(req As ReportRequest) As ReportResponse
        Return ProductoManager.GetEntireTipoProducto(req)
    End Function

    <WebMethod()> _
    Public Function GetTipoProductoItemById(req As TipoProductoRequest) As TipoProductoResponse
        Return ProductoManager.GetTipoProductoItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveTipoProductoItem(req As TipoProductoRequest) As TipoProductoResponse
        Return ProductoManager.SaveTipoProductoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveTipoAgenciaItem(req As TipoAgenciaRequest) As TipoAgenciaResponse
        Return AgenciaManager.SaveTipoAgenciaItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveArchivoAgenciaItem(req As ArchivoAgenciaRequest) As ArchivoAgenciaResponse
        Return AgenciaManager.SaveArchivoAgenciaItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveArchivoContactoItem(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveArchivoContactoItem(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireCiudadCatalog(req As ReportRequest) As ReportResponse
        Return CiudadManager.GetEntireCiudadCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetCiudadItemById(req As CiudadRequest) As CiudadResponse
        Return CiudadManager.GetCiudadItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveCiudadInfo(req As CiudadRequest) As CiudadResponse
        Return CiudadManager.SaveCiudadItem(req)
    End Function

    <WebMethod()> _
    Public Function GetEntirePaisCatalog(req As ReportRequest) As ReportResponse
        Return PaisManager.GetEntirePaisCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetPaisItemById(req As PaisRequest) As PaisResponse
        Return PaisManager.GetPaisItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetCodigoPaisPorId(req As ReportRequest) As ReportResponse
        Return PaisManager.GetCodigoPaisPorId(req)
    End Function

    <WebMethod()> _
    Public Function SavePaisInfo(req As PaisRequest) As PaisResponse
        Return PaisManager.SavePaisItem(req)
    End Function

    <WebMethod()> _
    Public Function GetServerDateTime() As Date
        Return Date.Now
    End Function

    <WebMethod()> _
    Public Function GetEntireElementoCatalog(req As ReportRequest) As ReportResponse
        Return ElementoManager.GetEntireElementoCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoItemById(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.GetElementoItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgenciaYTipo(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaYTipo(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgenciaYTipoEnSalida(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaYTipoEnSalida(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgenciaEnPreseleccion(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaEnPreseleccion(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgencia(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgencia(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoHistoricoPorIdElemento(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoHistoricoPorIdElemento(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPreBriefingPorIdBriefing(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPreBriefingPorIdBriefing(req)
    End Function


    <WebMethod()> _
    Public Function GetElementosPorEstado(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementosByEstado(req)
    End Function


    <WebMethod()> _
    Public Function GetElementoPorAgenciaStock(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaStock(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgenciaEnSalida(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaEnSalida(req)
    End Function

    <WebMethod()> _
    Public Function GetElementoPorAgenciaEnPesaje(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoPorAgenciaEnPesaje(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireTipoElementoCatalog(req As ReportRequest) As ReportResponse
        Return ElementoManager.GetEntireTipoElementoCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetMaterialItemById(req As MaterialesRequest) As MaterialesResponse
        Return ElementoManager.GetMaterialItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetPosicionItemById(req As PosicionRequest) As PosicionResponse
        Return VueloManager.GetPosicionItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetProductosItemById(req As ProductoRequest) As ProductoResponse
        Return ProductoManager.GetProductoItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireMaterialesCatalog(req As ReportRequest) As ReportResponse
        Return ElementoManager.GetEntireMaterialesCatalog(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoInfo(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveElementoItem(req)
    End Function

    <WebMethod()> _
    Public Function SavePesoElemento(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SavePesoElemento(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoHistorico(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveElementoHistorico(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoPreBriefing(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveElementoPreBriefing(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoIngresoPlataforma(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveElementoIngresoPlataforma(req)
    End Function

    <WebMethod()> _
    Public Function SaveEstadoElemento(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveEstadoElemento(req)
    End Function


    <WebMethod()> _
    Public Function SavePesoActualElemento(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SavePesoActualElemento(req)
    End Function

    <WebMethod()> _
    Public Function SaveMaterialInfo(req As MaterialesRequest) As MaterialesResponse
        Return ElementoManager.SaveMaterialItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveProductoInfo(req As ProductoRequest) As ProductoResponse
        Return ProductoManager.SaveProductoItem(req)
    End Function

    <WebMethod()> _
    Public Function SaveContactoInfo(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveContactoItem(req)
    End Function

    <WebMethod()>
    Public Function SaveUsuarioItem(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveUsuarioItem(req)
    End Function


    <WebMethod()> _
    Public Function SaveContactoAgenciaInfo(req As ContactoAgenciaRequest) As ContactoAgenciaResponse
        Return ContactoManager.SaveContactoAgenciaItem(req)
    End Function

    <WebMethod()> _
    Public Function SavePosicionInfo(req As PosicionRequest) As PosicionResponse
        Return VueloManager.SavePosicionItem(req)
    End Function

    <WebMethod()> _
    Public Function GetTiposEleItemById(req As TiposElementoRequest) As TiposElementoResponse
        Return ElementoManager.GetTiposEleItemById(req)
    End Function

    <WebMethod()> _
    Public Function SaveTipoElementoItem(req As TiposElementoRequest) As TiposElementoResponse
        Return ElementoManager.SaveTipoElementoItem(req)
    End Function

    <WebMethod()> _
    Public Function GetEntireDollyCatalog(req As ReportRequest) As ReportResponse
        Return DollyManager.GetEntireDollyCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetDollyItemById(req As DollyRequest) As DollyResponse
        Return DollyManager.GetDollyItemById(req)
    End Function

    <WebMethod()> _
    Public Function GetDollyPorIdAgencia(req As ReportRequest) As ReportResponse
        Return DollyManager.GetDollyPorIdAgencia(req)
    End Function

    <WebMethod()> _
    Public Function SaveDollyInfo(req As DollyRequest) As DollyResponse
        Return DollyManager.SaveDollyItem(req)
    End Function
    <WebMethod()> _
    Public Function GetParametro(req As ReportRequest) As ReportResponse
        Return ReportsManager.GetParametro(req)
    End Function


    <WebMethod()> _
    Public Function GetAllRegBiometrico(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetAllRegBiometrico(req)
    End Function

    <WebMethod()> _
    Public Function SaveElementoHistoricoUld(req As ElementoRequest) As ElementoResponse
        Return ElementoManager.SaveElementoHistoricoUld(req)
    End Function

    <WebMethod()> _
    Public Function SaveCargoContacto(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveCargoContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetConfiguraciones(req As UserRequest) As UserResponse
        Return UserManager.GetConfiguraciones(req)
    End Function
    <WebMethod()> _
    Public Function SaveConfigEcuapass(req As UserRequest) As UserResponse
        Return UserManager.SaveConfigEcuapass(req)
    End Function

    <WebMethod()> _
    Public Function GetProfileCatalog(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetProfileCatalog(req)
    End Function

    <WebMethod()> _
    Public Function GetPerfilItemById(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.GetPerfilItemById(req)
    End Function

    <WebMethod()>
    Public Function SavePerfilItem(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SavePerfilItem(req)
    End Function

    <WebMethod()>
    Public Function GetPerfilesByContacto(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetPerfilesByContacto(req)
    End Function

    <WebMethod()> _
    Public Function GetKeysItems(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetKeysItems(req)
    End Function

    <WebMethod()>
    Public Function GetPermisosByPerfil(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetPermisosByPerfil(req)
    End Function

    <WebMethod()> _
    Public Function SaveConfigurations(req As UserRequest) As UserResponse
        Return UserManager.SaveConfigurations(req)
    End Function

    <WebMethod()>
    Public Function GetTableTurnos(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetTableTurnos(req)
    End Function
    <WebMethod()>
    Public Function GetTurnoById(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.GetTurnoById(req)
    End Function

    <WebMethod()>
    Public Function GetEmpleadosGeneral(req As ReportRequest) As ReportResponse
        Return ContactoManager.GetEmpleadosGeneral(req)
    End Function

    <WebMethod()>
    Public Function SaveTurnoItem(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveTurnoItem(req)
    End Function

    <WebMethod()>
    Public Function SaveDaysTurnosContactotem(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.SaveDaysTurnosContactoItem(req)
    End Function

    <WebMethod()>
    Public Function GetTurnosEmpleado(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetTurnosEmpleado(req)
    End Function

    <WebMethod()>
    Public Function DeleteTurnoEmpleado(req As ContactoRequest) As ContactoResponse
        Return ContactoManager.DeleteTurnoEmpleado(req)
    End Function
    <WebMethod()>
    Public Function GetElementoTotalPorAgencia(req As ElementoRequest) As ReportResponse
        Return ElementoManager.GetElementoTotalPorAgencia(req)
    End Function
    <WebMethod()>
    Public Function PermiteActContacto(req As String) As Integer
        Return ContactoManager.PermiteActContacto(req)
    End Function
    <WebMethod()>
    Public Function GetResportes(req As ReportesRequest) As ReportesResponse
        Return ReportsManager.GetResportes(req)
    End Function

    <WebMethod()>
    Public Function GetFichaPersonal(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetFichaPersonal(req)
    End Function

    <WebMethod()>
    Public Function GetUsuarioEmpresa(req As ContactoRequest) As ReportResponse
        Return ContactoManager.GetUsuarioEmpresa(req)
    End Function

End Class