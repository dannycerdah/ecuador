Imports Microsoft.Reporting.WinForms
Public Class RptResumidoPorGuia
    Public enc As New List(Of ResumidoGuiaEnc)
    Public det As New List(Of ResumidoGuiaDet)
    Private Sub RptResumidoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptResumidoGuia.LocalReport.DataSources.Clear()
            RptResumidoGuia.LocalReport.DataSources.Add(New ReportDataSource("ResumidoGuiaEn", enc))
            RptResumidoGuia.LocalReport.DataSources.Add(New ReportDataSource("ResumidoGuiaDet", det))
            Me.RptResumidoGuia.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptResumidoGuia.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

End Class