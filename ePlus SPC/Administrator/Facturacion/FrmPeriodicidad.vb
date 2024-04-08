Public Class FrmPeriodicidad
    Private dtPeriodicidad As New DataTable("dtPeriodicidad")
    Public IdUsuario As String
    Private Sub FrmServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With dtPeriodicidad.Columns
                .Add("idPeriodicidad", GetType(Integer))
                .Add("DescripcionPeriodicidad", GetType(String))
                .Add("Estado", GetType(String))
            End With
            ugdPeriodicidad.DataSource = dtPeriodicidad
            SetDisplayedColumnsPeriodi()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub RefreshData()
        ObtenerClientes()
    End Sub
    Private Function ObtenerClientes() As DataTable
        Dim row As DataRow
        Try
            dtPeriodicidad.Clear()
            For Each r As DataRow In CommonDataFact.GetPeriodicidad().Rows
                row = dtPeriodicidad.NewRow
                row.Item("idPeriodicidad") = r.Item("idPeriodicidad")
                row.Item("DescripcionPeriodicidad") = r.Item("DescripcionPeriodicidad")
                row.Item("Estado") = r.Item("Estado")
                dtPeriodicidad.Rows.Add(row)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub SetDisplayedColumnsPeriodi()
        Try
            ugdPeriodicidad.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            ugdPeriodicidad.DisplayLayout.Bands(0).Columns("idPeriodicidad").Header.Caption = "Secuencial"
            ugdPeriodicidad.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Header.Caption = "Periodicidad"
            ugdPeriodicidad.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Case = Infragistics.Win.UltraWinGrid.Case.Upper
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtPeriodicidad_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodicidad.ValueChanged
        Try
            If txtPeriodicidad.Text.Length > 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPeriodicidad.Rows
                    If InStr(r.Cells("DescripcionPeriodicidad").Value, txtPeriodicidad.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Next
            Else
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPeriodicidad.Rows
                    r.Hidden = False
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ugdPeriodicidad_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPeriodicidad.DoubleClickCell
        Dim ClasServiciosPeriodi As New Server.Facturacion.Periodicidad
        Try
            If Not ugdPeriodicidad.ActiveRow.Cells("idPeriodicidad").Value.ToString = String.Empty Then
                With ClasServiciosPeriodi
                    .idPeriodicidad = ugdPeriodicidad.ActiveRow.Cells("idPeriodicidad").Value
                    .DescripcionPeriodicidad = ugdPeriodicidad.ActiveRow.Cells("DescripcionPeriodicidad").Value
                    .Estado = ugdPeriodicidad.ActiveRow.Cells("Estado").Value
                    .UsuarioIngreso = IdUsuario
                End With
                Using frmDetails As New FrmDetallePeriodicidad(False, ClasServiciosPeriodi)
                    frmDetails.ShowDialog()
                End Using
            Else
                Using frmDetails As New FrmDetallePeriodicidad(True, IdUsuario)
                    frmDetails.ShowDialog()
                End Using
            End If
            RefreshData()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class