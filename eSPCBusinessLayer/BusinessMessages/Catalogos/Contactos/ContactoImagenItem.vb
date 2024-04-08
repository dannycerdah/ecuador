Public Class ContactoImagenCatalogoItem
    Public Property idImagen As Guid
    Public Property idContacto As String
    Public Property imagen As String
    Public Property Usuario As String
    Public Property estado As estadoImagen

    Public Enum estadoImagen As Integer
        Nuevo = 0
        Activo = 1
        Inactivo = 2
    End Enum
End Class
