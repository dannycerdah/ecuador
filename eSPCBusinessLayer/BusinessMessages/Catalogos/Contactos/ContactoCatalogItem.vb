Public Class ContactoCatalogItem
    Public Property idAgencia As Guid
    Public Property idContacto As String
    Public Property tipoDocumento As String
    Public Property primerNombre As String
    Public Property segundoNombre As String
    Public Property primerApellido As String
    Public Property segundoApellido As String
    Public Property cargo As String
    Public Property idPais As Guid
    Public Property idCiudad As Guid
    Public Property telefono As String
    Public Property correo As String
    Public Property direccion As String
    Public Property fechaNacimiento As Date
    Public Property tagsa As String
    Public Property fechaCaducaTagsa As Date
    Public Property imagenPerfil As String
    Public Property imagenesPerfil As New List(Of ContactoImagenCatalogoItem) 'guille
    Public Property BioRecords As New List(Of RegBiometricoCatalogItem) 'simon
    Public Property ZonasAutorizadas As New List(Of ZonasAutorizadasCatalogItem) 'simon
    Public Property ZonasAutorizadasByContacto As New List(Of ZonasAutorizadasByContactoCatalogItem) 'simon
    Public Property AgenciaContacto As New List(Of ContactoAgenciaCatalogItem)
    Public Property huella As String
    Public Property IdContactoUser As String 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
    Public Property EmailContactoAgencia As String 'jro spint01 24/04/2025
    Public Property DescripcionAgencia As String 'jro spint01 24/04/2025
End Class
