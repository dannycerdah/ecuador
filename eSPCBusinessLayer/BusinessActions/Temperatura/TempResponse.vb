Public Class TempResponse
    Inherits GenericResponse

    Private _dsResult As DataSet


    Public Property DsResult() As DataSet
        Get
            Return _dsResult
        End Get
        Set(ByVal value As DataSet)
            _dsResult = value
        End Set
    End Property

    Sub New()
        _dsResult = New DataSet
    End Sub
End Class
