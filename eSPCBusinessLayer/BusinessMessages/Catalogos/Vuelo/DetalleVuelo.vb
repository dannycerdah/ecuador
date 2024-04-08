Public Class DetalleVuelo
    Public Property idBriefing As Guid
    Public Property idVuelo As Guid
    Public Property idAgencia As Guid
    Public Property descripcionAgencia As String
    Public Property codigoVuelo As String
    Public Property fechaVuelo As Date
    Public Property llegadaVuelo As DateTime
    Public Property salidaVuelo As DateTime
    Public Property enviaVuelo As String
    Public Property recibeVuelo As String
    Public Property estadoVuelo As String
    Public Property briefingVuelo As DateTime
    Public Property idAvion As Guid
    Public Property ciudadOrigen As String
    Public Property aeropuertoOrigen As String
    Public Property ciudadLlegada As String
    Public Property aeropuertoLlegada As String
    Public Property idMatriz As Guid
    Public Property descripcion As String
    Public Property descripcionAvion As String
    Public Property matriculaAvion As String
    Public Property briefingAgencias As New List(Of BriefingAgencias)

End Class
