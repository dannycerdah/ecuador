Public Class DecomisoEncabezado
    Public Property agenciaVuelo As String
    Public Property nueroVuelo As String
    Public Property guia As String
    Public Property productoGuia As String
    Public Property destinoGuia As String
    Public Property peso As String
    Public Property placaCamion As String
    Public Property horaLlegadaCamion As DateTime
    Public Property descripcionDecomiso As String
    Public Property textoGuia As String
    Public Property rutas As String
    Public Property decomisoDetalle As New List(Of DecomisoDetalle)
End Class
