Public Class frmTarifas

    Public Sub RefreshData()
        ugdAirplane.DataSource = CommonData.GetTarifaCatalog()
        SetDisplayedColumns()
    End Sub
    Private Sub ugdAirplane_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdAirplane.DoubleClickCell

        If Not ugdAirplane.ActiveRow.Cells("idtarifas").Value.ToString = String.Empty Then
            ShowTarifasDetails(ugdAirplane.ActiveRow.Cells("idtarifas").Value)
        Else
            Using frmDetails As New frmTarifasDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub
   
    Private Sub SetDisplayedColumns()
        ugdAirplane.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Agencia"
        ugdAirplane.DisplayLayout.Bands(0).Columns("fechaTar").Header.Caption = "Fecha de Mantenimiento"
        ugdAirplane.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
        ugdAirplane.DisplayLayout.Bands(0).Columns("ivaTar").Header.Caption = "IVA"
        ugdAirplane.DisplayLayout.Bands(0).Columns("idtarifas").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("idagencia").Hidden = True
    End Sub
    Private Sub ShowTarifasDetails(id As Guid)
        Using frmDetails As New frmTarifasDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

End Class