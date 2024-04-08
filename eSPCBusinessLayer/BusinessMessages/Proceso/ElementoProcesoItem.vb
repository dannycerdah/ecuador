Public Class ElementoProcesoItem
    Public Property IdProceso As Guid
    Public Property idElemento As String
    Public Property fecha As DateTime
    Public Property pesoReferencialElemento As Double
    Public Property pesoEntradaElemento As Double
    Public Property fechaUltimoPesoCaptura As DateTime
    Public Property pesoCaptura As Double
    Public Property fechaCarga As DateTime
    Public Property pesoCarga As Double
    Public Property fechaDescarga As DateTime
    Public Property pesoDescarga As Double
    Public Property pesoDiferencia As Double
    Public Property indice As Guid
    Public Property estado As String
    Public Property usuarioComparacionPeso As String
    Public Property Red As Decimal = 0D
End Class
