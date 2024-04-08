Public Class DetalleVueloResponse

    Inherits GenericResponse

    Private _dsResult As DataSet

    Public Property DsResult() As DataSet
        Get
            Return _dsResult
        End Get
        Set(ByVal value As DataSet)
            _dsResult = Value
        End Set
    End Property

    Sub New()
        _dsResult = New DataSet
    End Sub

    Public Property myDetalleVuelo As DetalleVuelo

End Class
