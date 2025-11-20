Public Class BitacoraNovedadVueloRequest
    Inherits GenericRequest
    Public Property IdNotificacion As Integer
    Public Property Vuelo As String
    Public Property Matricula As String
    Public Property Remitente As String
    Public Property Destinatario As String
    Public Property Avion As String
    Public Property FechaVuelo As Date
    Public Property FechaETA As DateTime
    Public Property FechaETD As DateTime
    Public Property FechaIngreso As DateTime
    Public Property UsuarioIngreso As String
End Class
