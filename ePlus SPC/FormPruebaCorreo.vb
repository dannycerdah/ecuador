Public Class FormPruebaCorreo

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            General.SendCheckUserManagerReportsMessage("pruebas", "jordan_r_a@hotmail.es", "DECOMISO ")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class