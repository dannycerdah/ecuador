Public Class frmTurnos

    Public Sub RefreshData()
        ugdTurnos.DataSource = CommonData.GetTableTurnos()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdTurnos.DisplayLayout.Bands(0).Columns("id").Hidden = True
            ugdTurnos.DisplayLayout.Bands(0).Columns("title").Header.Caption = "Título"
            ugdTurnos.DisplayLayout.Bands(0).Columns("title").Width = 150
            ugdTurnos.DisplayLayout.Bands(0).Columns("atraso").Header.Caption = "Tiempo de Atraso"
            ugdTurnos.DisplayLayout.Bands(0).Columns("inicio").Header.Caption = "Inicio"
            ugdTurnos.DisplayLayout.Bands(0).Columns("fin").Header.Caption = "Fin"
            ugdTurnos.DisplayLayout.Bands(0).Columns("usuario").Header.Caption = "Usuario de Mantenimiento"
            ugdTurnos.DisplayLayout.Bands(0).Columns("usuario").Width = 150
            ugdTurnos.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Mantenimiento"
            ugdTurnos.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
        Catch ex As Exception
            General.SetLogEvent(ex, "Error al graficar tabla Turnos")
        End Try
    End Sub


    Private Sub ShowTurnoDetalle(id As Guid)
        Using frmDetail As New frmTurnoDetalle(id)
            frmDetail.ShowDialog()
        End Using
    End Sub

    Private Sub txtHorario_ValueChanged(sender As Object, e As EventArgs) Handles txtHorario.ValueChanged
        If txtHorario.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdTurnos.Rows
                If InStr(r.Cells("title").Value, txtHorario.Text) <> 0 Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdTurnos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub ugdHorarios_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdTurnos.DoubleClickCell
        If Not ugdTurnos.ActiveRow.Cells("id").Value.ToString = String.Empty Then
            ShowTurnoDetalle(ugdTurnos.ActiveRow.Cells("id").Value)
        Else
            Using frmDetail As New frmTurnoDetalle(True)
                frmDetail.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub
End Class