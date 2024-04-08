
Public Class frmDetalleReporteVueloDollys
    Dim Id As New Guid
    Private dtDetalle As New DataTable("DetalleElementos")

    Public Sub New(ByVal idDetalle As Guid)
        InitializeComponent()
        Id = idDetalle
        obtenerDetalleElementos()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugvElementos.DisplayLayout.Bands(0).Columns("idDetalle").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("idDetalleAcarreo").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
            ugvElementos.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerDetalleElementos()
        dtDetalle = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(Id)
        ugvElementos.DataSource = dtDetalle
        SetDisplayedColumns()
    End Sub

End Class