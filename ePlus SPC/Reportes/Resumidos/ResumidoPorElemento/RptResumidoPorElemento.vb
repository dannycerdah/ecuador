Imports Microsoft.Reporting.WinForms
Public Class RptResumidoPorElemento
    Public enc As New List(Of ResumidoElementoEnc)
    Public det As New List(Of ResumidoElementoDet)
    Private Sub RptResumidoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptResumidoElemento.LocalReport.DataSources.Clear()
            RptResumidoElemento.LocalReport.DataSources.Add(New ReportDataSource("ResumidoElementoEn", enc))
            RptResumidoElemento.LocalReport.DataSources.Add(New ReportDataSource("ResumidoElementoDet", det))
            Me.RptResumidoElemento.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptResumidoElemento.RefreshReport()
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