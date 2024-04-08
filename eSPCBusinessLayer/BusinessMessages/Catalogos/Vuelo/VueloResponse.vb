Public Class VueloResponse

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

    Public Property myVueloItem As VueloItem
    Public Property myElementoBriefingItem As ElementoBriefingItem

End Class
