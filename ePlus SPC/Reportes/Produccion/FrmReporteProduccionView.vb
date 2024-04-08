Imports Microsoft.Reporting.WinForms

Public Class FrmReporteProduccionView
    Public Property ListDetallePesoVolumen As New DetalleClasPesoVuelo
    Private Sub FrmReporteProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SPC.RptProduccion.rdlc"
        Dim ParametroReport As ReportParameter() = New ReportParameter(3) {}
        ParametroReport(0) = New ReportParameter("PrmAgencia", ListDetallePesoVolumen.Agencia)
        ParametroReport(1) = New ReportParameter("PrmFechaIni", ListDetallePesoVolumen.FechaInicio)
        ParametroReport(2) = New ReportParameter("PrmFechaFin", ListDetallePesoVolumen.FechaFin)
        ParametroReport(3) = New ReportParameter("PrmTipo", ListDetallePesoVolumen.TipoConsulta)
        ReportViewer1.LocalReport.SetParameters(ParametroReport)
        With ReportViewer1
            .LocalReport.DataSources.Add(New ReportDataSource("DetalleClasPesoVuelo", ListDetallePesoVolumen.ListClasPesoVuelo))
            .SetDisplayMode(DisplayMode.PrintLayout)
            .Refresh()
        End With
    End Sub
End Class