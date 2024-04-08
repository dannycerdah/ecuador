Public Class EncabezadoUld
    Public Property EmpTrans() As String
    Public Property EmpSeg() As String
    Public Property chofer() As String
    Public Property custodio() As String
    Public Property tagsaChofer() As String
    Public Property tagsaCustodio() As String
    Public Property control() As String
    Public Property bascula() As String
    Public Property tagsaControl() As String
    Public Property tgsaBascula() As String
    Public Property elemento() As String
    Public Property pesoRef() As String
    Public Property pesoReal() As String
    Public Property fecha() As String
    Public Property tipo() As Boolean
    Public Property Procedencia() As String
    Public Property Destino() As String
    Public Detalle As New List(Of elementoUld)()
End Class
