Public Class BriefingEncabezado

    Public Property numeroVuelo As String
    Public Property aerolinea As String
    Public Property fechaRecibido As datetime
    Public Property fechaVuelo As Date
    Public Property envia As String
    Public Property recibe As String
    Public Property matriculaAvion As String
    Public Property tipoAvion As String
    Public Property eta As Date
    Public Property etd As Date
    Public Property estimadoDeCarga As Decimal
    Public Property briefingDetalle As New List(Of BriefingDetalle)
    Public Property cantidadGuias As Integer

End Class
