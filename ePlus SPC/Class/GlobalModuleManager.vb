Module GlobalModuleManager
    Public LogonRes As Server.UserService.UserResponse
    Public Sub LogOut()
        Dim req As New Server.UserService.UserRequest
        Dim wsClient As New Server.UserService.UserServiceSoapClient
        General.SetBARequest(req)
        wsClient.LogOut(req)
    End Sub
End Module
