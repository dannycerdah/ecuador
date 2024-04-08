Public Class ContactoResponse
    Inherits GenericResponse

    Public Property myContactoItem As ContactoCatalogItem
    Public Property myArchivoContactoItem As ArchivoContactoCatalogItem
    Public Property myCargoItem As CargoItem
    Public Property myUsuarioItem As UsuarioItem
    Public Property myRegBiometricoItem As List(Of RegBiometricoCatalogItem)
    Public Property myZonasAutorizadas As List(Of ZonasAutorizadasCatalogItem)
    Public Property myZonasAutorizadasByContacto As List(Of ZonasAutorizadasByContactoCatalogItem)

    Public Property myPerfilItem As PerfilItem
    Public Property myTurno As TurnoItem

End Class
