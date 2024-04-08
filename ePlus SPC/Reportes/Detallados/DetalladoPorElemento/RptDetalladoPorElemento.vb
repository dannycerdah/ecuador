Imports Microsoft.Reporting.WinForms
Public Class RptDetalladoPorElemento
    Public enc As New List(Of DetalladoElementoEnc)
    Public det As New List(Of DetalladoElementoDet)
    Private Sub RptDetalladoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptDetalladoElemento.LocalReport.DataSources.Clear()
            RptDetalladoElemento.LocalReport.DataSources.Add(New ReportDataSource("DetalladoElementoEn", enc))
            RptDetalladoElemento.LocalReport.DataSources.Add(New ReportDataSource("DetalladoElementoDet", det))
            Me.RptDetalladoElemento.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptDetalladoElemento.RefreshReport()
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