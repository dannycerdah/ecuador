Public Class FrmReporteProduccion
    Private ugdProCarPesVol As New Infragistics.Win.UltraWinGrid.UltraGrid
    Public Property IdUsuario As String
    Private ReportDetalle As RptProCargVolum
    Private Report As FrmReporteProduccionView
    Dim DetallePesoVuelo As DetalleClasPesoVuelo
    Dim ClasPesoVuelo As ClasPesoVuelo
    Private Sub FrmPrefacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim row As DataRow
        Try
            CargarClientes()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Proceso que carga el combo cliente
    Private Sub CargarClientes()
        Try
            uceClientes.Items.Clear()
            uceClientes.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetClientes.Rows
                If r.Item("Estado") = "A" Then
                    uceClientes.Items.Add(r.Item("idCliente"), r.Item("descripcionAgencia")).Tag = r.Item("IdAgencia")
                End If
            Next
            uceClientes.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Fecha As DateTime
        Dim Mes As Integer = 0
        DetallePesoVuelo = New DetalleClasPesoVuelo
        For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenGuia(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
            ClasPesoVuelo = New ClasPesoVuelo
            With ClasPesoVuelo
                If r.Item("Estado") = "A" Or r.Item("Estado") = "R" Then
                    .Peso = r.Item("Peso")
                    .Fecha = r.Item("fecha")
                    Fecha = r.Item("fecha")
                    .Semana = "Semana " + (DateDiff(DateInterval.WeekOfYear, New DateTime(DateTime.Now.Year, 1, 1), New DateTime(Fecha.Year, Fecha.Month, Fecha.Day)) + 1).ToString
                    .Mes = "Mes " + Fecha.Month.ToString()
                    .Quicenal = "Quincena " + ((2 * Fecha.Month) - IIf(Fecha.Day < 16, 1, 0)).ToString
                    .Guia = r.Item("guia")
                    .CodigoVuelo = r.Item("codigoVuelo")
                    .PesoVolumen = IIf(r.Item("PesoVolumen") < 1, 1, r.Item("PesoVolumen"))
                    DetallePesoVuelo.ListClasPesoVuelo.Add(ClasPesoVuelo)
                End If
            End With
        Next
        If DetallePesoVuelo.ListClasPesoVuelo.Count > 0 Then
            Using Report As New FrmReporteProduccionView
                DetallePesoVuelo.FechaInicio = udtDesde.Value
                DetallePesoVuelo.FechaFin = udtHasta.Value
                DetallePesoVuelo.Agencia = uceClientes.SelectedItem.ToString
                Report.ListDetallePesoVolumen = DetallePesoVuelo
                If RaBD.Checked Then
                    DetallePesoVuelo.TipoConsulta = "D"
                ElseIf RaBS.Checked Then
                    DetallePesoVuelo.TipoConsulta = "S"
                ElseIf RaBM.Checked Then
                    DetallePesoVuelo.TipoConsulta = "M"
                ElseIf RaBQ.Checked Then
                    DetallePesoVuelo.TipoConsulta = "Q"
                End If
                Report.ShowDialog()
            End Using
        End If
    End Sub
End Class
