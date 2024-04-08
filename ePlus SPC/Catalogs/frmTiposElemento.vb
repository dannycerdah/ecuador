Public Class frmTiposElemento

    Public Sub RefreshData()
        ugdTipoElemento.DataSource = CommonData.GetTipoElementoCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdTipoElemento.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
        ugdTipoElemento.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Descripción"
    End Sub

    Private Sub ugdMateriales_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdTipoElemento.DoubleClickCell
        If Not ugdTipoElemento.ActiveRow.Cells("idTipo").Value.ToString = String.Empty Then
            ShowTiposElementoDetails(ugdTipoElemento.ActiveRow.Cells("idTipo").Value)
        Else
            Using frmDetails As New frmTiposElementoDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposElementoDetails(id As Guid)
        Using frmDetails As New frmTiposElementoDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ugdTipoElemento_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugdTipoElemento.InitializeLayout

    End Sub

    Private Sub frmTiposElemento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class