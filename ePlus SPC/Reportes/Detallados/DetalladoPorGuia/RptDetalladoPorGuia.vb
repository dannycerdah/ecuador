Imports Microsoft.Reporting.WinForms
Public Class RptDetalladoPorGuia
    Public enc As New List(Of DetalladoGuiaEnc)
    Public det As New List(Of DetalladoGuiaDet)
    Private Sub RptDetalladoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptDetalladoGuia.LocalReport.DataSources.Clear()
            RptDetalladoGuia.LocalReport.DataSources.Add(New ReportDataSource("DetalladoGuiaEn", enc))
            RptDetalladoGuia.LocalReport.DataSources.Add(New ReportDataSource("DetalladoGuiaDet", det))
            Me.RptDetalladoGuia.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptDetalladoGuia.RefreshReport()
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