Public Class frmUsuarios

    Public Sub RefreshData()
        ugdUsuario.DataSource = CommonData.GetEntireUsuarioCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdUsuario.DisplayLayout.Bands(0).Columns("NombreUsuario").Header.Caption = "Usuario"
            ugdUsuario.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Cédula"
            ugdUsuario.DisplayLayout.Bands(0).Columns("idUsuario").Header.Caption = "Nombre de Usuario"
            ugdUsuario.DisplayLayout.Bands(0).Columns("password").Header.Caption = "Contraseña"
            ugdUsuario.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
            ugdUsuario.DisplayLayout.Bands(0).Columns("admin").Header.Caption = "Administrador"
            ugdUsuario.DisplayLayout.Bands(0).Columns("idContactoCreacion").Hidden = True
            ugdUsuario.DisplayLayout.Bands(0).Columns("ContactoCreacion").Header.Caption = "Contacto de Mantenimiento"
            ugdUsuario.DisplayLayout.Bands(0).Columns("fechaCreacion").Hidden = True
            ugdUsuario.DisplayLayout.Bands(0).Columns("fechaAct").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex, "SetDisplayedColumns Usuarios")
        End Try
    End Sub

    Private Sub ugdContacto_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdUsuario.DoubleClickCell
        If Not ugdUsuario.ActiveRow.Cells("idUsuario").Value.ToString = String.Empty Then
            ShowUsuarioDetails(ugdUsuario.ActiveRow.Cells("idUsuario").Value)
        Else
            Using frmDetails As New frmUsuarioDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowUsuarioDetails(id As String)
        Using frmDetails As New frmUsuarioDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtUsuario.ValueChanged
        If txtUsuario.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdUsuario.Rows
                If InStr(r.Cells("idContacto").Value, txtUsuario.Text) <> 0 Or InStr(r.Cells("NombreUsuario").Value, txtUsuario.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdUsuario.Rows
                r.Hidden = False
            Next
        End If
    End Sub

End Class