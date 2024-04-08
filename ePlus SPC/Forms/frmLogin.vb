Imports SPC.Server.UserService

Public Class frmLogin
    Public CodigoUsuario As String = ""
    Public Usuario As String = ""
    Public Nombre As String = ""
    Public Property Retorno As Boolean = False

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        'If My.Settings.LoginEmpr = 0 Then
        Me.uceEmpresa.SelectedIndex = 0
            'Else
            '    Me.uceEmpresa.SelectedIndex = My.Settings.LoginEmpr
            'End If

            txtUsuario.Select()
    End Sub

    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            txtUsuario.Text = txtUsuario.Text.TrimEnd
            txtClave.Focus()
        End If
    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If e.KeyChar = ControlChars.Cr Then
            ValidateAndLogIn()
        End If
    End Sub

    Private Function ValidateInfo() As Boolean
        Dim Result As Boolean = True
        If txtUsuario.Text = String.Empty Then Result = False
        If txtClave.Text = String.Empty Then Result = False
        If My.Settings.LoginEmpr = 0 Then Result = False

        Return Result
    End Function

    Public Sub ValidateAndLogIn()
        If ValidateInfo() Then
            LogIn()
        Else
            MessageBox.Show("Todos los campos son necesarios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LogIn()
        Dim req As New UserRequest
        Dim res As New UserResponse
        Dim xwsUser As New UserServiceSoapClient
        Dim myUser As New User
        Dim dt As DataTable
        Dim autrempr As Boolean
        myUser.idUsuario = Me.txtUsuario.Text.Trim
        myUser.Password = Me.txtClave.Text.Trim
        req.myUser = myUser
        General.SetBARequest(req)
        res = xwsUser.LogIn(req)
        If res.ActionResult = True Then
            If res.myUser.estado = "1" Then
                MyCurrentUser.userId = res.myUser.idUsuario
                MyCurrentUser.userName = res.myUser.idContacto
                MyCurrentUser.isAdministrador = res.myUser.isAdmin
                MyCurrentUser.permisosUsuario = res.myUser.myPermisos 'MARZ
                'verifica si tiene autorizacion para empresa
                autrempr = False
                dt = CommonData.Getusuarioempresabyidcontacto(res.myUser.idContacto)
                For Each r As DataRow In dt.Rows
                    If uceEmpresa.Value = r.Item("codigo_empresa") Then
                        autrempr = True
                    End If
                Next
                If autrempr = False Then
                    MessageBox.Show("No tiene Autorizacion para ingresar como  " & Me.uceEmpresa.Text, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Retorno = False
                    Exit Sub
                End If

                Retorno = True
                Me.Close()

            Else
                MessageBox.Show("Usuario y/o contraseña incorrecta", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Retorno = False
            End If
        Else
            If res.ErrorCode = 100 Then
                MessageBox.Show("Error al comunicarse con el servidor central", _
                                "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error general, reintente o comunique a sistemas", _
                "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Retorno = False
        End If
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ValidateAndLogIn()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Retorno = False
        Me.Close()
    End Sub

    Private Sub uceEmpresa_ValueChanged(sender As Object, e As EventArgs) Handles uceEmpresa.ValueChanged
        If uceEmpresa.Value = 1 Then
            Me.PictureBox1.Image = My.Resources.GA2
        End If
        If uceEmpresa.Value = 2 Then
            Me.PictureBox1.Image = My.Resources.exporexprress
        End If
        My.Settings.LoginEmpr = uceEmpresa.Value

    End Sub
End Class