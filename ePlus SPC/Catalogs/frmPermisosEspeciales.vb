Public Class frmPermisosEspeciales

    Public Sub RefreshData()
        txtFiltradoTabla.Focus()
        ugdPermisosEspeciales.DataSource = CommonData.GetAllPermisosEspeciales("0")
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("id").Hidden = True
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("observation").Hidden = True
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("estadoPermiso").Hidden = True
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("beginDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("endDate").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("description").Header.Caption = "Descripción"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("beginDate").Header.Caption = "Fecha de inicio"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("endDate").Header.Caption = "Fecha de fin"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("beginTime").Header.Caption = "Ingreso"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("endTime").Header.Caption = "Salida"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("nombreUsuario").Header.Caption = "Autorizado Por"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Cambios"
            ugdPermisosEspeciales.DisplayLayout.Bands(0).Columns("estadoPermiso").Header.Caption = "Estado"
        Catch ex As Exception
            General.SetLogEvent(ex, "Error al graficar tabla Permisos Especiales")
        End Try
    End Sub

    Private Sub ShowPermisoEspecialDetalle(id As Guid)
        Using frmDetalle As New frmPermisoEspecialDetalle(id)
            frmDetalle.ShowDialog()
        End Using
    End Sub

    Private Sub txtFiltradoTabla_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltradoTabla.ValueChanged
        If txtFiltradoTabla.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPermisosEspeciales.Rows
                If InStr(r.Cells("description").Value, txtFiltradoTabla.Text) <> 0 Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPermisosEspeciales.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub ugdPermisosEspeciales_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPermisosEspeciales.DoubleClickCell
        If Not ugdPermisosEspeciales.ActiveRow.Cells("id").Value.ToString = String.Empty Then
            ShowPermisoEspecialDetalle(ugdPermisosEspeciales.ActiveRow.Cells("id").Value)
        Else
            Using frmDetail As New frmPermisoEspecialDetalle(True)
                frmDetail.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

End Class