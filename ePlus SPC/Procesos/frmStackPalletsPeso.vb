Public Class frmStackPalletsPeso
    Public Property peso As Decimal = 0D

    Private Sub txtPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeso.KeyDown
        Try
            If e.KeyData = Keys.Enter Or e.KeyData = Keys.Space Then
                If txtPeso.Value > 0 Then
                    peso = Decimal.Parse(txtPeso.Value)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub
End Class