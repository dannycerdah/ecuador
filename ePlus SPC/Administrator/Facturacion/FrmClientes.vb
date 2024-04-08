Public Class FrmClientes
    Private dtClientes As New DataTable("dtRegBio")
    Public IdUsuario As String
    Public Sub RefreshData()
        ObtenerClientes()
    End Sub
    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With dtClientes.Columns
                .Add("idCliente", GetType(Integer))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("Estado", GetType(String))
            End With
            ugdClientes.DataSource = dtClientes
            SetDisplayedColumnsCliente()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function ObtenerClientes() As DataTable
        Dim row As DataRow
        Try
            dtClientes.Clear()
            For Each r As DataRow In CommonDataFact.GetClientes().Rows
                row = dtClientes.NewRow
                row.Item("idCliente") = r.Item("idCliente")
                row.Item("idAgencia") = r.Item("idAgencia")
                row.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                row.Item("Estado") = r.Item("Estado")
                dtClientes.Rows.Add(row)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub SetDisplayedColumnsCliente()
        Try
            ugdClientes.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdClientes.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            ugdClientes.DisplayLayout.Bands(0).Columns("idCliente").Header.Caption = "Secuencial"
            ugdClientes.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Cliente"
            'ugdClientes.DisplayLayout.Bands(0).Columns("descripcionAgencia").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            ugdClientes.DisplayLayout.Bands(0).Columns("descripcionAgencia").Case = Infragistics.Win.UltraWinGrid.Case.Upper
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtClientes_ValueChanged(sender As Object, e As EventArgs) Handles txtClientes.ValueChanged
        Try
            If txtClientes.Text.Length > 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdClientes.Rows
                    If InStr(r.Cells("descripcionAgencia").Value, txtClientes.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Next
            Else
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdClientes.Rows
                    r.Hidden = False
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ugdClientes_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdClientes.DoubleClickCell
        Dim ClasCliente As New Server.Facturacion.Cliente
        Try
            If Not ugdClientes.ActiveRow.Cells("idCliente").Value.ToString = String.Empty Then
                With ClasCliente
                    .idAgencia = ugdClientes.ActiveRow.Cells("idAgencia").Value
                    .idCliente = ugdClientes.ActiveRow.Cells("idCliente").Value
                    .Estado = ugdClientes.ActiveRow.Cells("Estado").Value
                    .UsuarioIngreso = IdUsuario
                End With
                Using frmDetails As New FrmDetalleCliente(False, ClasCliente)
                    frmDetails.ShowDialog()
                End Using
            Else
                Using frmDetails As New FrmDetalleCliente(True, IdUsuario)
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