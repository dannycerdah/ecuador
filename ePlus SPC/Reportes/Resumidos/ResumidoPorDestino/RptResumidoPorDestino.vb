Imports Microsoft.Reporting.WinForms
Public Class RptResumidoPorDestino
    Public enc As New List(Of ResumidoDestinoEnc)
    Public det As New List(Of ResumidoDestinoDet)
    Private Sub RptResumidoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptResumidoDestino.LocalReport.DataSources.Clear()
            RptResumidoDestino.LocalReport.DataSources.Add(New ReportDataSource("ResumidoDestinoEn", enc))
            RptResumidoDestino.LocalReport.DataSources.Add(New ReportDataSource("ResumidoDestinoDet", det))
            Me.RptResumidoDestino.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptResumidoDestino.RefreshReport()
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