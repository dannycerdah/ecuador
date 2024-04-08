Imports Microsoft.Reporting.WinForms

Public Class RptTemperatura
    Public RegTemp As New ClassTemp
    Public _FechaInicio As Date
    Public _FechaFin As Date
    Public _TipoDeInforme As String
    Private Sub RptTemperatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Parametros As ReportParameter() = New ReportParameter(2) {}
            RptvTemperatura.LocalReport.DataSources.Clear()
            RptvTemperatura.LocalReport.DataSources.Add(New ReportDataSource("ClassDetalleTemp", RegTemp.RegTempratura))
            Parametros(0) = New ReportParameter("ReportParameterFechaInicio", "Desde " & _FechaInicio.ToString("dd/MM/yyyy HH:mm:ss"))
            Parametros(1) = New ReportParameter("ReportParameterFechaFin", "Hasta " & _FechaFin.ToString("dd/MM/yyyy HH:mm:ss"))
            Parametros(2) = New ReportParameter("TipoDeInforme", _TipoDeInforme)
            Me.RptvTemperatura.LocalReport.SetParameters(Parametros)
            Me.RptvTemperatura.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptvTemperatura.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class