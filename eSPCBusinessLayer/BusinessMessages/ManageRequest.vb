Public Class ManageRequest
    Inherits GenericRequest

    Private _action As ManagementActions

    Public Property [Action]() As ManagementActions
        Get
            Return _action
        End Get
        Set(ByVal value As ManagementActions)
            _action = value
        End Set
    End Property
End Class
