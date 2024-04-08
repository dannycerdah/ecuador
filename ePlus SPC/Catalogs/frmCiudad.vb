Public Class frmCiudad

    Public Sub RefreshData()
        ugdCiudad.DataSource = CommonData.GetCiudadCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdCiudad.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
        ugdCiudad.DisplayLayout.Bands(0).Columns("idPais").Hidden = True
        ugdCiudad.DisplayLayout.Bands(0).Columns("CodigoPais").Hidden = True
        ugdCiudad.DisplayLayout.Bands(0).Columns("nombreCiudad").Header.Caption = "Ciudad"
        ugdCiudad.DisplayLayout.Bands(0).Columns("nombrePais").Header.Caption = "País"
    End Sub

    Private Sub ugdCiudad_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdCiudad.DoubleClickCell
        If Not ugdCiudad.ActiveRow.Cells("idCiudad").Value.ToString = String.Empty Then
            ShowCiudadDetails(ugdCiudad.ActiveRow.Cells("idCiudad").Value)
        Else
            Using frmDetails As New frmCiudadDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowCiudadDetails(id As Guid)
        Using frmDetails As New frmCiudadDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtciudad_ValueChanged(sender As Object, e As EventArgs) Handles txtciudad.ValueChanged
        If txtciudad.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdCiudad.Rows
                If InStr(r.Cells("nombreCiudad").Value, txtciudad.Text) Or InStr(r.Cells("nombrePais").Value, txtciudad.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdCiudad.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class