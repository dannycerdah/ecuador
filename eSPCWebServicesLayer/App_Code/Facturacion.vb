Imports System.Web
Imports System.Web.Services
Imports eSPCBusinessLayer

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Facturacion
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function MantClientes(req As ClienteRequest) As ClienteResponse
        Return FacturacionManager.MantClientes(req)
    End Function
    <WebMethod()>
    Public Function MantServiciosGA(req As ServiciosGARequest) As ServiciosGAResponse
        Return FacturacionManager.MantServiciosGA(req)
    End Function

    <WebMethod()>
    Public Function MantPlantiClienteServ(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.MantPlantiClienteServ(req)
    End Function
    <WebMethod()>
    Public Function MantPeriodicidad(req As PeriodicidadRequest) As PeriodicidadResponse
        Return FacturacionManager.MantPeriodicidad(req)
    End Function
    <WebMethod()>
    Public Function MantServConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Return FacturacionManager.MantServConsuCliente(req)
    End Function
    <WebMethod()>
    Public Function MantVuelosCancelados(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Return FacturacionManager.MantVuelosCancelados(req)
    End Function

    <WebMethod()>
    Public Function GetClientes(req As ClienteRequest) As ClienteResponse
        Return FacturacionManager.GetClientes(req)
    End Function
    <WebMethod()>
    Public Function GetServiciosGA(req As ServiciosGARequest) As ServiciosGAResponse
        Return FacturacionManager.GetServiciosGA(req)
    End Function
    <WebMethod()>
    Public Function GetPeriodicidad(req As PeriodicidadRequest) As PeriodicidadResponse
        Return FacturacionManager.GetPeriodicidad(req)
    End Function
    <WebMethod()>
    Public Function GetPlantiClienteServ(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.GetPlantiClienteServ(req)
    End Function
    <WebMethod()>
    Public Function GetTipoProceAlmacenaCarga(req As TipoProcesoAlmacenajeCargaRequest) As TipoProcesoAlmacenajeCargaResponse
        Return FacturacionManager.GetTipoProceAlmacenaCarga(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerPesoVolumenVuelo(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.PreFactObtenerPesoVolumenVuelo(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerCantVuelosAgencia(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.PreFactObtenerCantVuelosAgencia(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerPesoVolumenGuia(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.PreFactObtenerPesoVolumenGuia(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerTiempoAlmaceContainer(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Return FacturacionManager.PreFactObtenerTiempoAlmaceContainer(req)
    End Function
    <WebMethod()>
    Public Function GetSerConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Return FacturacionManager.GetSerConsuCliente(req)
    End Function
    <WebMethod()>
    Public Function GetVuelosCancelados(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Return FacturacionManager.GetVuelosCancelados(req)
    End Function
    <WebMethod()>
    Public Function GetVuelosGuias(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Return FacturacionManager.GetVuelosGuias(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerServConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Return FacturacionManager.PreFactObtenerServConsuCliente(req)
    End Function
    <WebMethod()>
    Public Function PreFactObtenerPesoVolumenPorBriefGuia(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Return FacturacionManager.PreFactObtenerPesoVolumenPorBriefGuia(req)
    End Function

End Class