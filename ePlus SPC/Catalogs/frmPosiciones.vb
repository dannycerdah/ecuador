Public Class frmPosiciones

    Public Sub RefreshData()
        ugdPosiciones.DataSource = CommonData.GetPosicionesCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdPosiciones.DisplayLayout.Bands(0).Columns("idPosicion").Hidden = True
        ugdPosiciones.DisplayLayout.Bands(0).Columns("descripcionPosicion").Header.Caption = "Descripción"
    End Sub

    Private Sub ugdPosiciones_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPosiciones.DoubleClickCell
        If Not ugdPosiciones.ActiveRow.Cells("idPosicion").Value.ToString = String.Empty Then
            ShowPosicionDetails(ugdPosiciones.ActiveRow.Cells("idPosicion").Value)
        Else
            Using frmDetails As New frmPosicionDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowPosicionDetails(id As Guid)
        Using frmDetails As New frmPosicionDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

End Class