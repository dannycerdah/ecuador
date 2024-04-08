Public Class frmPais

    Public Sub RefreshData()
        ugdPais.DataSource = CommonData.GetPaisCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdPais.DisplayLayout.Bands(0).Columns("idPais").Hidden = True
        ugdPais.DisplayLayout.Bands(0).Columns("codigoPais").Header.Caption = "Codigo"
        ugdPais.DisplayLayout.Bands(0).Columns("nombrePais").Header.Caption = "País"
        ugdPais.DisplayLayout.Bands(0).Columns("nacionalidadPais").Header.Caption = "Nacionalidad"
    End Sub

    Private Sub ugdPais_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPais.DoubleClickCell
        If Not ugdPais.ActiveRow.Cells("idPais").Value.ToString = String.Empty Then
            ShowPaisDetails(ugdPais.ActiveRow.Cells("idPais").Value)
        Else
            Using frmDetails As New frmPaisDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowPaisDetails(id As Guid)
        Using frmDetails As New frmPaisDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtPais_ValueChanged(sender As Object, e As EventArgs) Handles txtPais.ValueChanged
        If txtPais.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPais.Rows
                If InStr(r.Cells("nombrePais").Value, txtPais.Text) Or InStr(r.Cells("codigoPais").Value, txtPais.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPais.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class