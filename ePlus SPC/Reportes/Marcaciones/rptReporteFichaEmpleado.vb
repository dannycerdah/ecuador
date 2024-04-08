Imports Microsoft.Reporting.WinForms
Public Class rptReporteFichaEmpleado
    Public FechaInicio As DateTime
    Public FechaFin As DateTime
    Public Usuario As String
    Public DsFicha As List(Of DatosFichapersonal)
    Public DsFichaCarga As List(Of FichaProcesoCarga)
    Public DsFichaMarcaciones As List(Of FichaMarcaciones)
    Public DsAtrasos As List(Of FichaMarcacionesAtarasos)


    Private Sub rptReporteFichaEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewFichaEmpl.LocalReport.ReportEmbeddedResource = "ReportFichaPersonalActividadv2.rdlc"

        ReportViewFichaEmpl.LocalReport.DataSources.Clear()
        Dim Parametros As ReportParameter() = New ReportParameter(2) {}
        Parametros(0) = New ReportParameter("ReportParameterFechaInicial", FechaInicio.ToString("dd/MM/yyyy HH:mm:ss"))
        Parametros(1) = New ReportParameter("ReportParameterHasta", FechaFin.ToString("dd/MM/yyyy HH:mm:ss"))
        Parametros(2) = New ReportParameter("Usuario", Usuario)

        ReportViewFichaEmpl.LocalReport.SetParameters(Parametros)
        ReportViewFichaEmpl.LocalReport.DataSources.Add(New ReportDataSource("DsFicha", DsFicha))
        ReportViewFichaEmpl.LocalReport.DataSources.Add(New ReportDataSource("DsFichaCarga", DsFichaCarga))
        ReportViewFichaEmpl.LocalReport.DataSources.Add(New ReportDataSource("DsFichaMarcaciones", DsFichaMarcaciones))
        ReportViewFichaEmpl.LocalReport.DataSources.Add(New ReportDataSource("DsAtrasos", DsAtrasos))

        Me.ReportViewFichaEmpl.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewFichaEmpl.RefreshReport()
    End Sub
End Class