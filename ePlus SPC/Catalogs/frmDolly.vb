Public Class frmDolly

    Public Sub RefreshData()
        ugdDolly.DataSource = CommonData.GetDollyCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdDolly.DisplayLayout.Bands(0).Columns("idDolly").Hidden = True
        ugdDolly.DisplayLayout.Bands(0).Columns("codigoDolly").Header.Caption = "Código"
        ugdDolly.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdDolly.DisplayLayout.Bands(0).Columns("estadoDolly").Hidden = True
        ugdDolly.DisplayLayout.Bands(0).Columns("estadoDolly").Header.Caption = "Estado"
    End Sub

    Private Sub ugdDolly_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdDolly.DoubleClickCell
        If Not ugdDolly.ActiveRow.Cells("idDolly").Value.ToString = String.Empty Then
            ShowDollyDetails(ugdDolly.ActiveRow.Cells("idDolly").Value)
        Else
            Using frmDetails As New frmDollyDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowDollyDetails(id As Guid)
        Using frmDetails As New frmDollyDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

End Class