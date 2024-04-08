Public Class frmMateriales

    Public Sub RefreshData()
        ugdMateriales.DataSource = CommonData.GetMaterialesCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdMateriales.DisplayLayout.Bands(0).Columns("idMaterial").Header.Caption = "Código"
        'ugdMateriales.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripción"'jro 26122018
        ugdMateriales.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Tipo Material" 'jro 26122018
    End Sub

    Private Sub ugdMateriales_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdMateriales.DoubleClickCell
        If Not ugdMateriales.ActiveRow.Cells("idMaterial").Value.ToString = String.Empty Then
            ShowMaterialDetails(ugdMateriales.ActiveRow.Cells("idMaterial").Value)
        Else
            Using frmDetails As New frmMaterialDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowMaterialDetails(id As String)
        Using frmDetails As New frmMaterialDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

End Class