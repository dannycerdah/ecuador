Imports Infragistics.Win.UltraWinGrid

Public Class frmCamion

    Public Sub RefreshData()
        ugdCamion.DataSource = CommonData.GetCamionCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdCamion.DisplayLayout.Bands(0).Columns("idCamion").Hidden = True
        ugdCamion.DisplayLayout.Bands(0).Columns("estadoCamion").Hidden = True
        ugdCamion.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdCamion.DisplayLayout.Bands(0).Columns("descripcionCamion").Header.Caption = "Descripción"
        ugdCamion.DisplayLayout.Bands(0).Columns("MatriculaCamion").Header.Caption = "Matricula"
        ugdCamion.DisplayLayout.Bands(0).Columns("descripcionagencia").Header.Caption = "Compañia"
        ugdCamion.DisplayLayout.Bands(0).Columns("estadoCamion").Header.Caption = "Estado"
    End Sub

    Private Sub ugdCamion_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdCamion.DoubleClickCell
        If Not ugdCamion.ActiveRow.Cells("idCamion").Value.ToString = String.Empty Then
            ShowCamionDetails(ugdCamion.ActiveRow.Cells("idCamion").Value)
        Else
            Using frmDetails As New frmCamionDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowCamionDetails(id As Guid)
        Using frmDetails As New frmCamionDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtCamion_ValueChanged(sender As Object, e As EventArgs) Handles txtCamion.ValueChanged
        If txtCamion.TextLength > 0 Then
            For Each r As UltraGridRow In ugdCamion.Rows
                If InStr(r.Cells("MatriculaCamion").Value, txtCamion.Text) > 0 Or InStr(r.Cells("descripcionagencia").Value, txtCamion.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If

            Next
        Else
            For Each r As UltraGridRow In ugdCamion.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class