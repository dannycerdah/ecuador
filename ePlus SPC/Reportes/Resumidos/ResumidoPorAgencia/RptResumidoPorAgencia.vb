Imports Microsoft.Reporting.WinForms
Public Class RptResumidoPorAgencia
    Public enc As New List(Of ResumidoAgenciaEnc)
    Public det As New List(Of ResumidoAgenciaDet)
    Private Sub RptResumidoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptResumidoAgencia.LocalReport.DataSources.Clear()
            RptResumidoAgencia.LocalReport.DataSources.Add(New ReportDataSource("ResumidoAgenciaEn", enc))
            RptResumidoAgencia.LocalReport.DataSources.Add(New ReportDataSource("ResumidoAgenciaDet", det))
            Me.RptResumidoAgencia.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptResumidoAgencia.RefreshReport()
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