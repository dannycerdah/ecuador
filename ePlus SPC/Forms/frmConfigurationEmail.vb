Public Class frmConfigurationEmail

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Config.SetScaleSettings(txtHost.Text, txtPuerto.Text, txtRemitente.Text, txtClave.Text, chkSSL.Checked)
            MessageBox.Show("Configuraciones guardadas correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmConfigurationEmail_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtHost.Text = Config.correoHost
        txtPuerto.Text = Config.correoPuerto
        txtRemitente.Text = Config.correoRemitente
        txtClave.Text = Config.correoClave
        chkSSL.Checked = Config.correoSSL
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class