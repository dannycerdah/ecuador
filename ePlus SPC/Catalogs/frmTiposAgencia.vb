Public Class frmTiposAgencia

    Public Sub RefreshData()
        ugdTipoAgencia.DataSource = CommonData.GetTipoAgencia()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdTipoAgencia.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
        ugdTipoAgencia.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Descripción"
    End Sub

    Private Sub ugdTipoAgencia_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdTipoAgencia.DoubleClickCell
        If Not ugdTipoAgencia.ActiveRow.Cells("idTipo").Value.ToString = String.Empty Then
            ShowTiposAgenciaDetails(ugdTipoAgencia.ActiveRow.Cells("idTipo").Value)
        Else
            Using frmDetails As New frmTiposAgenciaDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposAgenciaDetails(id As Guid)
        Using frmDetails As New frmTiposAgenciaDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ugdTipoAgencia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugdTipoAgencia.InitializeLayout

    End Sub
End Class