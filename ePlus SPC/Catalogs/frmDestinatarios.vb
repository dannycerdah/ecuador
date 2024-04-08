Public Class frmDestinatarios
    Public Sub RefreshData()
        ugdContacto.DataSource = CommonData.GetDestinatariosAgencias()
        SetDisplayedColumns()
        txtFiltro.Focus() 'MARZ
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdContacto.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("idReporte").Hidden = True
            ugdContacto.DisplayLayout.Bands(0).Columns("descripcionReporte").Header.Caption = "Reporte"
            ugdContacto.DisplayLayout.Bands(0).Columns("descripcionagencia").Header.Caption = "Compañia"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ugdContacto_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdContacto.DoubleClickCell
        If Not ugdContacto.ActiveRow.Cells("descripcionAgencia").Value.ToString = String.Empty Then
            ShowTiposContactoDetails(ugdContacto.ActiveRow.Cells("idReporte").Value, ugdContacto.ActiveRow.Cells("idAgencia").Value)
        Else
            Using frmDetails As New frmDestinatarioDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposContactoDetails(idr As Integer, idA As Guid)
        Using frmDetails As New frmDestinatarioDetails(idr, idA)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltro.ValueChanged
        If txtFiltro.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContacto.Rows
                If InStr(r.Cells("descripcionAgencia").Value.ToString, txtFiltro.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContacto.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class