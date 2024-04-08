Public Class frmTiposProducto

    Public Sub RefreshData()
        ugdTipoProducto.DataSource = CommonData.GetEntireTipoProducto()
        SetDisplayedColumns()
        txtFiltro.Focus() 'MARZ
    End Sub

    Private Sub SetDisplayedColumns()
        ugdTipoProducto.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
        ugdTipoProducto.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Descripción"
    End Sub

    Private Sub ugdTipoProducto_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdTipoProducto.DoubleClickCell
        If Not ugdTipoProducto.ActiveRow.Cells("idTipo").Value.ToString = String.Empty Then
            ShowTiposProductoDetails(ugdTipoProducto.ActiveRow.Cells("idTipo").Value)
        Else
            Using frmDetails As New frmTiposProductoDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposProductoDetails(id As Guid)
        Using frmDetails As New frmTiposProductoDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtGrupoProducto_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltro.ValueChanged
        If txtFiltro.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdTipoProducto.Rows
                If InStr(r.Cells("descripcionTipo").Value, txtFiltro.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdTipoProducto.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class