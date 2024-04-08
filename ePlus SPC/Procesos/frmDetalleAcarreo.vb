Imports SPC.Server.ProcesoService
Public Class frmDetalleAcarreo
    Private dtDetalleAcarreo As New DataTable("DetalleAcarreo")
    Public myDetalleAcarreo As New DetalleAcarreoItem

    Public Sub New(idBriefing As Guid)
        InitializeComponent()
        dtDetalleAcarreo = CommonProcess.GetDetalleAcarreoPorEstado(CommonProcess.GetAcarreoPorIdBriefing(idBriefing).IdAcarreo, "I")

    End Sub

    Private Sub frmDetalleAcarreo_Load(sender As Object, e As EventArgs) Handles Me.Load
        ugvDollys.DataSource = dtDetalleAcarreo
        SetDisplayedColumnsDollys()
        If ModuloCierre.EndHilo = False Then
            ModuloCierre.InicioEjecucion = Date.Now
            ModuloCierre.EjecutaHiloVerificacion()
        End If
    End Sub

    Private Sub SetDisplayedColumnsDollys()
        Try

            ugvDollys.DisplayLayout.Bands(0).Columns("idDetalle").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("idAcarreo").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("idDolly").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("dolly").Header.Caption = "Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("idChofer").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("chofer").Header.Caption = "Chofer"
            ugvDollys.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia de Rampa"
            ugvDollys.DisplayLayout.Bands(0).Columns("idCustodio").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("Custodio").Header.Caption = "Custodio"
            ugvDollys.DisplayLayout.Bands(0).Columns("idAgenciaSeguridad").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("agenciaSeguridad").Header.Caption = "Agencia de Seguridad"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").Header.Caption = "Fecha de Entrada Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").Format = "dd/MM/yyyy H:mm:ss"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").Header.Caption = "Fecha de Salida Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").Format = "dd/MM/yyyy H:mm:ss"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvDollys.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub infoDollyToObject()
        Try
            myDetalleAcarreo.idDolly = ugvDollys.ActiveRow.Cells("idDolly").Value
            myDetalleAcarreo.idAcarreo = ugvDollys.ActiveRow.Cells("idAcarreo").Value
            myDetalleAcarreo.idAgencia = ugvDollys.ActiveRow.Cells("idAgencia").Value
            myDetalleAcarreo.idChofer = ugvDollys.ActiveRow.Cells("idChofer").Value
            myDetalleAcarreo.IdDetalle = ugvDollys.ActiveRow.Cells("idDetalle").Value
            myDetalleAcarreo.idCustodio = ugvDollys.ActiveRow.Cells("idCustodio").Value
            myDetalleAcarreo.idAgenciaSeguridad = ugvDollys.ActiveRow.Cells("idAgenciaSeguridad").Value
            myDetalleAcarreo.fechaEntrada = ugvDollys.ActiveRow.Cells("fechaEntrada").Value
            myDetalleAcarreo.fechaSalida = ugvDollys.ActiveRow.Cells("fechaSalida").Value
            myDetalleAcarreo.estado = ugvDollys.ActiveRow.Cells("estado").Value
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvDollys_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvDollys.DoubleClickCell
        If Not ugvDollys.ActiveRow.Cells("idDolly").Value.ToString = String.Empty Then
            infoDollyToObject()
            Me.Close()
        End If
    End Sub

    Private Sub frmDetalleAcarreo_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmDetalleAcarreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmDetalleAcarreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ModuloCierre.EndHilo = False
    End Sub
End Class