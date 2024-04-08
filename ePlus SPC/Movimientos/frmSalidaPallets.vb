Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmSalidaPallets
    Dim myDetalleVuelo As New DetalleVuelo
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelos
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                'myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                udtFecha.Value = myDetalleVuelo.fechaVuelo
                udtEta.Value = myDetalleVuelo.llegadaVuelo
                udtEtd.Value = myDetalleVuelo.salidaVuelo
                'obtenerDetalleVuelo(frmConsultaVuelos.NumeroVuelo)
                'myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                'CargarVuelo(frmConsultaVuelos.Aerolinea)
                'If Not procesoExist Then
                '    SaveProceso()
                'End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class