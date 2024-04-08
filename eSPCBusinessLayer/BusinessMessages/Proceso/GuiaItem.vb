Public Class GuiaItem

    Public Property Id As Guid
    Public Property Descripcion As String
    Public Property idBriefing As Guid
    Public Property idCiudad As Guid
    Public Property ciudadDestino As String
    Public Property DescripcionProducto As String
    Public Property IdAgencia As Guid
    Public Property DescripcionAgencia As String
    Public Property Peso As Double
    Public Property Bultos As Integer
    Public Property FechaLlegada As DateTime
    Public Property Estado As String
    Public Property DAE As String
    Public Property FechaAct As DateTime
    Public Property usuarioAct As String
    Public Property estadoReporte As String
    Public Property Rutas As String 'Se agrega para poder obetner las rutas de la guia JRO 01022018
End Class
