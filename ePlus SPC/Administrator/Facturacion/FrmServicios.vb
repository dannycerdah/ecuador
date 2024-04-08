Public Class FrmServicios
    Private dtServiciosGA As New DataTable("dtServiciosGA")
    Public IdUsuario As String
    Private Sub FrmServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With dtServiciosGA.Columns
                .Add("idServiciosGA", GetType(Integer))
                .Add("DescripcionServicio", GetType(String))
                .Add("Estado", GetType(String))
            End With
            ugdServicios.DataSource = dtServiciosGA
            SetDisplayedColumnsServGA()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub RefreshData()
        ObtenerServicioGA()
    End Sub
    Private Function ObtenerServicioGA() As DataTable
        Dim row As DataRow
        Try
            dtServiciosGA.Clear()
            For Each r As DataRow In CommonDataFact.GetServiciosGA().Rows
                row = dtServiciosGA.NewRow
                row.Item("idServiciosGA") = r.Item("idServiciosGA")
                row.Item("DescripcionServicio") = r.Item("DescripcionServicio")
                row.Item("Estado") = r.Item("Estado")
                dtServiciosGA.Rows.Add(row)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub SetDisplayedColumnsServGA()
        Try
            ugdServicios.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            ugdServicios.DisplayLayout.Bands(0).Columns("idServiciosGA").Header.Caption = "Secuencial"
            ugdServicios.DisplayLayout.Bands(0).Columns("DescripcionServicio").Header.Caption = "Servicio"
            'ugdServicios.DisplayLayout.Bands(0).Columns("DescripcionServicio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdServicios.DisplayLayout.Bands(0).Columns("DescripcionServicio").Case = Infragistics.Win.UltraWinGrid.Case.Upper

        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtServicios_ValueChanged(sender As Object, e As EventArgs) Handles txtServicios.ValueChanged
        Try
            If txtServicios.Text.Length > 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdServicios.Rows
                    If InStr(r.Cells("DescripcionServicio").Value, txtServicios.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Next
            Else
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdServicios.Rows
                    r.Hidden = False
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ugdServicios_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdServicios.DoubleClickCell
        Dim ClasServiciosGA As New Server.Facturacion.ServiciosGA
        Try
            If Not ugdServicios.ActiveRow.Cells("idServiciosGA").Value.ToString = String.Empty Then
                With ClasServiciosGA
                    .idServiciosGA = ugdServicios.ActiveRow.Cells("idServiciosGA").Value
                    .DescripcionServicio = ugdServicios.ActiveRow.Cells("DescripcionServicio").Value
                    .Estado = ugdServicios.ActiveRow.Cells("Estado").Value
                    .UsuarioIngreso = IdUsuario
                End With
                Using frmDetails As New FrmDetalleServicio(False, ClasServiciosGA)
                    frmDetails.ShowDialog()
                End Using
            Else
                Using frmDetails As New FrmDetalleServicio(True, IdUsuario)
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