Imports Microsoft.Reporting.WinForms
Public Class RptTotalServicios
    Public ListDetalleServicoFacturar2 As New List(Of ListDetalleServicoFacturar)
    Public ListDetalleServicoFacturar As New ListDetalleServicoFacturar
    Public TipoServicio As Integer = 0
    Private Sub RptTotalServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With RptTotalServFact
                .LocalReport.DataSources.Add(New ReportDataSource("ListDetallesServicosFacturar", ListDetalleServicoFacturar2))
                .LocalReport.DataSources.Add(New ReportDataSource("DetalleServicoFacturar", ListDetalleServicoFacturar.DetalleServicoFacturar))
                .SetDisplayMode(DisplayMode.PrintLayout)
                .Refresh()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class