Public Class frmCargo
    Public Sub RefreshData()
        ugdCargos.DataSource = CommonData.GetCargoCatalog()
        SetDisplayedColumns()
        txtCargo.Focus()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdCargos.DisplayLayout.Bands(0).Columns("idCargo").Hidden = True
            ugdCargos.DisplayLayout.Bands(0).Columns("descripcionCargo").Header.Caption = "Nombre de Profesiones"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ugdCargos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdCargos.DoubleClickCell
        If ugdCargos.ActiveRow.Cells("idCargo").Value.ToString = String.Empty Then
            Using frmDetails As New frmCargoDetails()
                frmDetails.ShowDialog()
            End Using
            RefreshData()
        End If
    End Sub
    Private Sub txtCargo_ValueChanged(sender As Object, e As EventArgs) Handles txtCargo.ValueChanged
        If txtCargo.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdCargos.Rows
                If InStr(r.Cells("descripcionCargo").Value, txtCargo.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdCargos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

End Class