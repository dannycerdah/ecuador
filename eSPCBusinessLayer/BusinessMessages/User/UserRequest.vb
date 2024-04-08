Public Class UserRequest
    Inherits GenericRequest

    Public Property myUser As User
    Public Property myConfiguraciones As ConfigurationItem
    Public Overloads Function SendErrorString() As String
        Return MyUser.ErrorString()
    End Function



End Class
