Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmConsultaPreElemento
    Dim tipoAgencia As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"


    Public Aerolinea As String = ""
    Public NumeroVuelo As String = ""
    Public resDetPreElement As New ElementoPreBriefingItem
    Dim isConsultaDesdeVuelo As Boolean = False
    Dim idAgencia As Guid = Guid.Empty

    Private Sub PopulateAerolinea()
        Dim dt As New DataTable("Agencia")
        Dim ds As New DataSet
        uceAerolinea.Items.Clear()
        If isConsultaDesdeVuelo Then
            Dim tempAgencia As New Server.ReportService.AgenciaCatalogItem
            tempAgencia = CommonData.GetAgenciaItem(idAgencia)
            uceAerolinea.Items.Add(tempAgencia.Id, tempAgencia.Descripcion)
        Else
            uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, tipoAgencia, AgenciaAerolineaEX)).Rows
                uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("DescripcionAgencia"))
            Next
        End If
        uceAerolinea.SelectedIndex = 0
    End Sub

    Public Sub RefreshData()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdPreElemen.DisplayLayout.Bands(0).Columns("Aerolinea").Header.Caption = "AEROLINEA"
            ugdPreElemen.DisplayLayout.Bands(0).Columns("Vuelo").Header.Caption = "NUMERO VUELO"
            ugdPreElemen.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "FECHA RECEPCION"
            ugdPreElemen.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
            ugdPreElemen.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreElemen.DisplayLayout.Bands(0).Columns("Procedencia").Header.Caption = "PROCEDENCIA"
            ugdPreElemen.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugdPreElemen.DisplayLayout.Bands(0).Columns("IdAerolinea").Hidden = True
            ugdPreElemen.DisplayLayout.Bands(0).Columns("IdRampa").Hidden = True
            ugdPreElemen.DisplayLayout.Bands(0).Columns("IdSeguridad").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmConsultaVuelos_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateAerolinea()
        PopulateGrid()
        uceAerolinea.Select()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim Result As New DataTable("Vuelos")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim dtPreAler As New ElementoPreBriefingItem
        With dtPreAler
            .IdAerolinea = uceAerolinea.Value
            .fechaIncio = udtDesde.Value
            .fechaFin = udtHasta.Value
        End With
        Try
            General.SetBARequest(req)
            req.myElementoPreBriefingItem = dtPreAler
            res = wsClient.GetElementoPreBriefingPorIdBriefing(req)
            If res.ActionResult Then
                ugdPreElemen.DataSource = res.DsResult.Tables(0)
                RefreshData()
                If res.DsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No existen Pre-Atert de Elementos Ingresados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdVuelos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPreElemen.DoubleClickCell
        Aerolinea = ugdPreElemen.ActiveRow.Cells("Aerolinea").Value
        VueloInfoToObject()
        NumeroVuelo = resDetPreElement.Vuelo
        Me.Close()
    End Sub

    Private Sub VueloInfoToObject()
        Try
            resDetPreElement.idBriefing = ugdPreElemen.ActiveRow.Cells("idBriefing").Value
            resDetPreElement.fecha = ugdPreElemen.ActiveRow.Cells("fecha").Value
            resDetPreElement.IdAerolinea = ugdPreElemen.ActiveRow.Cells("IdAerolinea").Value
            resDetPreElement.IdRampa = ugdPreElemen.ActiveRow.Cells("IdRampa").Value
            resDetPreElement.IdSeguridad = ugdPreElemen.ActiveRow.Cells("IdSeguridad").Value
            resDetPreElement.Vuelo = ugdPreElemen.ActiveRow.Cells("Vuelo").Value
            resDetPreElement.Procedencia = ugdPreElemen.ActiveRow.Cells("Procedencia").Value
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New(ByVal idAerolinea As Guid)
        InitializeComponent()
        idAgencia = idAerolinea
        isConsultaDesdeVuelo = True
    End Sub

    Public Sub New()
        InitializeComponent()
        isConsultaDesdeVuelo = False
    End Sub

    Private Sub PopulateGrid()
        Dim Result As New DataTable("ElemenPreAlert")
        Dim wsClient As New ReportServiceSoapClient
        Dim req As New ElementoRequest
        Dim res As New ReportResponse
        Dim dtPreAler As New ElementoPreBriefingItem
        dtPreAler.fechaIncio = Date.Now
        dtPreAler.fechaFin = Date.Now
        Try
            General.SetBARequest(req)
            req.myElementoPreBriefingItem = dtPreAler
            res = wsClient.GetElementoPreBriefingPorIdBriefing(req)
            If res.ActionResult Then
                ugdPreElemen.DataSource = res.DsResult.Tables(0)
                RefreshData()
                If res.DsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No existen Pre-Atert de Elementos Ingresados el dia de Hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdVuelos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugdPreElemen.InitializeLayout

    End Sub

    Private Sub ugdVuelos_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugdPreElemen.InitializeRow

    End Sub
End Class