Public Class ContactoZonasSessionResponse
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

    Public Property myContactoZonasSession As ContactoZonasSessionItem
End Class
