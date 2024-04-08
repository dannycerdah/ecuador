Public Class frmProducto

    Public Sub RefreshData()
        ugdProducto.DataSource = CommonData.GetEntireProductoCatalog()
        SetDisplayedColumns()
        txtFiltro.Focus() 'MARZ
    End Sub

    Private Sub SetDisplayedColumns()
        ugdProducto.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugdProducto.DisplayLayout.Bands(0).Columns("tipoProducto").Hidden = True
        ugdProducto.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Tipo de Producto"
        ugdProducto.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Descripción"
        ugdProducto.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.VisiblePosition = 0
        ugdProducto.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.VisiblePosition = 1
    End Sub

    Private Sub ugdProducto_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdProducto.DoubleClickCell
        If Not ugdProducto.ActiveRow.Cells("idProducto").Value.ToString = String.Empty Then
            ShowProductoDetails(ugdProducto.ActiveRow.Cells("idProducto").Value)
        Else
            Using frmDetails As New frmProductoDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowProductoDetails(id As Guid)
        Using frmDetails As New frmProductoDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtProducto_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltro.ValueChanged
        If txtFiltro.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProducto.Rows
                If InStr(r.Cells("descripcionProducto").Value, txtFiltro.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProducto.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class