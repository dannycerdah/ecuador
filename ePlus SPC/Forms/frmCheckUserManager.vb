Imports SPC.Server.UserService
Public Class frmCheckUserManager
    Public Property tempUserManager As New UserClient
    Public Property result As Boolean = False
    Public Property B_RegistraBita As Boolean = False
    Public Property S_Proceso As String
    Public Property S_UsuarioProduc As String
    Public Property S_Observacion As String

    Private Sub frmCheckManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtUsuario.Focus()
    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            LogIn()
            CheckManCode()
            Close()
        End If
    End Sub

    Private Sub LogIn()
        Dim req As New UserRequest
        Dim res As New UserResponse
        Dim xwsUser As New UserServiceSoapClient
        Dim myUser As New User
        myUser.idUsuario = Me.txtUsuario.Text.Trim
        myUser.Password = Me.txtClave.Text.Trim
        req.myUser = myUser
        General.SetBARequest(req)
        res = xwsUser.LogIn(req)
        If res.ActionResult = True Then
            If res.myUser.estado = "1" Then
                tempUserManager.userId = res.myUser.idUsuario
                tempUserManager.userName = res.myUser.idContacto
                tempUserManager.isAdministrador = res.myUser.isAdmin
                If B_RegistraBita Then
                    With req.myUser
                        .estado = S_Proceso
                        .userName = S_UsuarioProduc
                        .userAdmin = myUser.idUsuario
                        .errorString = S_Observacion
                    End With
                    res = xwsUser.SaveBitacoraPermiso(req)
                End If
            Else
                result = False
                Close()
            End If
        Else
            result = False
            Close()
        End If
    End Sub

    Private Sub CheckManCode()
        If tempUserManager.isAdministrador Then
            result = True
        Else
            result = False
        End If
    End Sub

End Class