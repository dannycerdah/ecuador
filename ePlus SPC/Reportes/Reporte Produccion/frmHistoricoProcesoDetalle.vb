Imports SPC.Server.ReportService
Public Class frmHistoricoProcesoDetalle
    Public vuelo As String = ""
    Public fechaIni As Date
    Public fechaFin As Date
    Public Aerolinea As Guid = Guid.Empty
    Dim dtDetalleProduccion As New DataTable("DetalleProduccion")
    Dim elementoHistorico As New ElementoHistoricoItem

    Private Sub frmHistorialElementoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            txtVuelo.Text = vuelo
            dtDetalleProduccion = CommonProcess.GetInfoDetalleProcesoPorIdAgenciaYFecha(Aerolinea, fechaIni, fechaFin, vuelo)
            'setTipoRegistroHistorial()
            ugdProduccionDetalle.DataSource = dtDetalleProduccion
            setDisplayedColumns()
        Catch ex As Exception
            General.SetLogEvent(ex, "Load Elemento Historico Detalle")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub setDisplayedColumns()
        Try
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("codigoVuelo").Hidden = True
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Header.Caption = "Fecha Inicio"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Header.Caption = "Fecha Inicio"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Format = "dd/MM/yyyy"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Header.Caption = "Fecha Fin"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Format = "dd/MM/yyyy"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("peso").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("peso").Format = "0,0.0"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("piezas").Header.Caption = "Piezas"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("piezas").Format = "N0"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("piezas").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("volumen").Header.Caption = "Volumen"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("volumen").Format = "0,0.0"
            ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("volumen").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
            ugdProduccionDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("peso"))
            ugdProduccionDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("piezas"))
            ugdProduccionDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdProduccionDetalle.DisplayLayout.Bands(0).Columns("volumen"))
        Catch ex As Exception
            General.SetLogEvent(ex, "setDisplayedColumns ElementoHistoricoDetalle")
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdProduccionDetalle)
    End Sub
End Class