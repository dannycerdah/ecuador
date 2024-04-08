Imports Microsoft.Reporting.WinForms
Public Class RptDetalladoPorDestino
    Public enc As New List(Of DetalladoDestinoEnc)
    Public det As New List(Of DetalladoDestinoDet)
    Private Sub RptDetalladoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptDetalladoDestino.LocalReport.DataSources.Clear()
            RptDetalladoDestino.LocalReport.DataSources.Add(New ReportDataSource("DetalladoDestinoEn", enc))
            RptDetalladoDestino.LocalReport.DataSources.Add(New ReportDataSource("DetalladoDestinoDet", det))
            Me.RptDetalladoDestino.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptDetalladoDestino.RefreshReport()
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