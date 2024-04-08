Imports Microsoft.Reporting.WinForms
Public Class RptDetalladoPorAgencia
    Public enc As New List(Of DetalladoAgenciaEnc)
    Public det As New List(Of DetalladoAgenciaDet)
    Private Sub RptDetalladoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptDetalladoAgencia.LocalReport.DataSources.Clear()
            RptDetalladoAgencia.LocalReport.DataSources.Add(New ReportDataSource("DetalladoAgenciaEn", enc))
            RptDetalladoAgencia.LocalReport.DataSources.Add(New ReportDataSource("DetalladoAgenciaDet", det))
            Me.RptDetalladoAgencia.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptDetalladoAgencia.RefreshReport()
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