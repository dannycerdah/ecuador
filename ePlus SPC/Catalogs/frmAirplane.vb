Imports Infragistics.Win.UltraWinGrid

Public Class frmAirplane

    Public Sub RefreshData()
        ugdAirplane.DataSource = CommonData.GetAirplaneCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdAirplane.DisplayLayout.Bands(0).Columns("idAvion").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        'ugdAirplane.DisplayLayout.Bands(0).Columns("descripcionAvion").Header.Caption = "Descripción"'jro 26122018
        ugdAirplane.DisplayLayout.Bands(0).Columns("descripcionAvion").Header.Caption = "Fabricante" 'jro 26122018
        ugdAirplane.DisplayLayout.Bands(0).Columns("modeloAvion").Header.Caption = "Modelo"
        ugdAirplane.DisplayLayout.Bands(0).Columns("tipoAvion").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("pesoMaximoAvion").Header.Caption = "Peso Máximo"
        ugdAirplane.DisplayLayout.Bands(0).Columns("matriculaAvion").Hidden = True
        'ugdAirplane.DisplayLayout.Bands(0).Columns("estadoAvion").Header.Caption = "Estado"'jro 26122018
        ugdAirplane.DisplayLayout.Bands(0).Columns("estadoAvion").Hidden = True 'jro 26122018
        ugdAirplane.DisplayLayout.Bands(0).Columns("pesoMaximoAvion").Format = "#,##0"
        ugdAirplane.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
    End Sub

    Private Sub ugdAirplane_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdAirplane.DoubleClickCell
        If Not ugdAirplane.ActiveRow.Cells("idAvion").Value.ToString = String.Empty Then
            ShowAirplaneDetails(ugdAirplane.ActiveRow.Cells("idAvion").Value)
        Else
            Using frmDetails As New frmAirplaneDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowAirplaneDetails(id As Guid)
        Using frmDetails As New frmAirplaneDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub
End Class