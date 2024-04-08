Public Class frmPerfiles
    Public Sub RefreshData()
        ugdPerfiles.DataSource = CommonData.GetProfileCatalog() 'Datos de la base de datos
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns() 'Pintar datos en tabla
        Try
            ugdPerfiles.DisplayLayout.Bands(0).Columns("idPerfil").Hidden = True
            ugdPerfiles.DisplayLayout.Bands(0).Columns("nombrePerfil").Header.Caption = "Perfil"
            ugdPerfiles.DisplayLayout.Bands(0).Columns("comentarioPerfil").Header.Caption = "Descripción del Perfil"
            ugdPerfiles.DisplayLayout.Bands(0).Columns("estadoPerfil").Header.Caption = "Estado"
            ugdPerfiles.DisplayLayout.Bands(0).Columns("nombreUsuario").Header.Caption = "Usuario de Mantenimiento"
            ugdPerfiles.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Cambio"
            ugdPerfiles.DisplayLayout.Bands(0).Columns("padrePerfil").Header.Caption = "Perfil Superior"
        Catch ex As Exception
            General.SetLogEvent(ex, "Error al graficar tabla Perfiles")
        End Try
    End Sub

    'Doble click en filas de la tabla
    Private Sub ugdPerfiles_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPerfiles.DoubleClickCell
        If Not ugdPerfiles.ActiveRow.Cells("idPerfil").Value.ToString = String.Empty Then
            ShowPerfilDetalle(ugdPerfiles.ActiveRow.Cells("idPerfil").Value)
        Else
            Using frmDetail As New frmPerfilDetalle(True)
                frmDetail.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowPerfilDetalle(id As Guid)
        Using frmDetail As New frmPerfilDetalle(id)
            frmDetail.ShowDialog()
        End Using
    End Sub

    Private Sub txtPerfil_ValueChanged(sender As Object, e As EventArgs) Handles txtPerfil.ValueChanged
        If txtPerfil.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPerfiles.Rows
                If InStr(r.Cells("nombrePerfil").Value, txtPerfil.Text) <> 0 Or InStr(r.Cells("comentarioPerfil").Value, txtPerfil.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPerfiles.Rows
                r.Hidden = False
            Next
        End If
    End Sub

End Class