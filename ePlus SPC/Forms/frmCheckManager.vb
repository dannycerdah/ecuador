Public Class frmCheckManager

    Public Property result As Boolean = False

    Private Sub frmCheckManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtkey.Focus()
    End Sub

    Private Sub txtkey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtkey.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            CheckManCode()
            Close()
        End If
    End Sub

    Private Sub CheckManCode()
        txtkey.Text = (txtkey.Text.Replace("'", "_"))
        If txtkey.Text = "123" Then
            result = True
        End If
    End Sub


End Class