Public Class frmConfiNotiTemp
    Public Property IdUsuario As String
    Private DT_notificacion_temp As New DataTable("DT_notificacion_temp")
    Private SetDisplay As Boolean = True
    Public Sub RefreshData()
        DT_notificacion_temp.Clear()
        Dim rows As DataRow
        For Each r As DataRow In CommonData.ObtenerParametrosNoti(0).Rows
            rows = DT_notificacion_temp.NewRow
            With r
                rows.Item("id_notificacion_temp") = .Item("id_notificacion_temp")
                rows.Item("idProducto") = .Item("idProducto")
                rows.Item("temp_min") = .Item("temp_min")
                rows.Item("temp_max") = .Item("temp_max")
                rows.Item("Estado") = .Item("Estado")
                rows.Item("UsuarioIngreso") = .Item("UsuarioIngreso")
                rows.Item("FechaIngreso") = .Item("FechaIngreso")
                rows.Item("UsuarioActualizacion") = .Item("UsuarioActualizacion")
                rows.Item("FechaActualizacion") = .Item("FechaActualizacion")
                rows.Item("descripcionProducto") = .Item("descripcionProducto")
            End With
            DT_notificacion_temp.Rows.Add(rows)
        Next
        If SetDisplay Then
            SetDisplayedColumns()
        End If
    End Sub
    Private Sub frmConfiNotiTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DT_notificacion_temp.Columns
            .Add("id_notificacion_temp", GetType(Integer))
            .Add("idProducto", GetType(Guid))
            .Add("temp_min", GetType(Double))
            .Add("temp_max", GetType(Double))
            .Add("Estado", GetType(String))
            .Add("UsuarioIngreso", GetType(String))
            .Add("FechaIngreso", GetType(Date))
            .Add("UsuarioActualizacion", GetType(String))
            .Add("FechaActualizacion", GetType(Date))
            .Add("descripcionProducto", GetType(String))
        End With
        ugdparatempro.DataSource = DT_notificacion_temp
    End Sub
    Private Sub SetDisplayedColumns()
        Try
            ugdparatempro.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("UsuarioIngreso").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("FechaIngreso").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("UsuarioActualizacion").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("FechaActualizacion").Hidden = True
            ugdparatempro.DisplayLayout.Bands(0).Columns("id_notificacion_temp").Header.Caption = "ID"
            ugdparatempro.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "PRODUCTO"
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_min").Header.Caption = "TEMP. MINIMA ºC"
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_max").Header.Caption = "TEMP. MAXIMA ºC"
            ugdparatempro.DisplayLayout.Bands(0).Columns("id_notificacion_temp").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_max").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_min").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdparatempro.DisplayLayout.Bands(0).Columns("id_notificacion_temp").Width = Len(ugdparatempro.DisplayLayout.Bands(0).Columns("id_notificacion_temp").Header.Caption)
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_max").Width = Len(ugdparatempro.DisplayLayout.Bands(0).Columns("temp_max").Header.Caption)
            ugdparatempro.DisplayLayout.Bands(0).Columns("temp_min").Width = Len(ugdparatempro.DisplayLayout.Bands(0).Columns("temp_min").Header.Caption)
            SetDisplay = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ugdparatempro_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdparatempro.DoubleClickCell
        If ugdparatempro.ActiveRow.Cells("id_notificacion_temp").Value.ToString = String.Empty Then
            Using frmMatNotif As New frmMatConfiNotiTemp
                frmMatNotif.IdUsuario = IdUsuario
                frmMatNotif.ShowDialog()
            End Using
        Else
            Dim DatosNotifiacion As New Server.ControlTemp.NotificacionTemp
            With DatosNotifiacion
                .idProducto = ugdparatempro.ActiveRow.Cells("idProducto").Value
                .id_notificacion_temp = ugdparatempro.ActiveRow.Cells("id_notificacion_temp").Value
                .temp_max = ugdparatempro.ActiveRow.Cells("temp_max").Value
                .temp_min = ugdparatempro.ActiveRow.Cells("temp_min").Value
                .UsuarioIngreso = ugdparatempro.ActiveRow.Cells("UsuarioIngreso").Value
                .Estado = ugdparatempro.ActiveRow.Cells("Estado").Value
                .UsuarioActualizacion = ugdparatempro.ActiveRow.Cells("descripcionProducto").Value
            End With
            Using frmMatNotif As New frmMatConfiNotiTemp(DatosNotifiacion)
                frmMatNotif.IdUsuario = IdUsuario
                frmMatNotif.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub txtproducto_ValueChanged(sender As Object, e As EventArgs) Handles txtproducto.ValueChanged
        If txtproducto.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdparatempro.Rows
                If InStr(r.Cells("descripcionProducto").Value, txtproducto.Text) <> 0 Or InStr(r.Cells("temp_max").Value, txtproducto.Text) Or InStr(r.Cells("temp_min").Value, txtproducto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdparatempro.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class
