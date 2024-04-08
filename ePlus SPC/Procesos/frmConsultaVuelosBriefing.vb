Imports SPC.Server.VuelosService
Public Class frmConsultaVuelosBriefing
    Dim tipoAgencia As String = "04be18e6-fd0c-4466-aed2-04b0e8025772" 'aerolineas
    Dim tipoAgenciaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377" 'EXPOREXPRESS

    Public Aerolinea As String = ""
    Public NumeroVuelo As String = ""
    Public resDetVuelo As New DetalleVuelo
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
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, tipoAgencia, tipoAgenciaEX)).Rows
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
            ugdVuelos.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Número de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").Header.Caption = "Fecha de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").Format = "dd/MM/yyyy"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").Header.Caption = "Llegada Estimada de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").Format = "dd/MM/yyyy H:mm"
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").Header.Caption = "Salida Estimada de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").Format = "dd/MM/yyyy H:mm"
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdVuelos.DisplayLayout.Bands(0).Columns("enviaVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("recibeVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("estadoVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("briefingVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idAvion").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idMatriz").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("ciudadOrigen").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("aeropuertoOrigen").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("ciudadLlegada").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("aeropuertoLlegada").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("descripcionAvion").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("matriculaAvion").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Matriz de Seguridad"
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
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        With dtVuelo
            .IdAgencia = uceAerolinea.Value
            .llegadaVuelo = udtDesde.Value
            .salidaVuelo = udtHasta.Value
        End With
        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.GetDetalleVueloPorFecha(req)
            If res.ActionResult Then
                ugdVuelos.DataSource = res.DsResult.Tables(0)
                RefreshData()
                If res.DsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No existen Vuelos Ingresados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdVuelos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdVuelos.DoubleClickCell
        Aerolinea = ugdVuelos.ActiveRow.Cells("descripcionAgencia").Value
        VueloInfoToObject()
        NumeroVuelo = resDetVuelo.codigoVuelo
        Me.Close()
    End Sub

    Private Sub VueloInfoToObject()
        Try
            resDetVuelo.idBriefing = ugdVuelos.ActiveRow.Cells("idBriefing").Value
            resDetVuelo.idVuelo = ugdVuelos.ActiveRow.Cells("idVuelo").Value
            resDetVuelo.idAgencia = ugdVuelos.ActiveRow.Cells("idAgencia").Value
            resDetVuelo.descripcionAgencia = ugdVuelos.ActiveRow.Cells("descripcionAgencia").Value
            resDetVuelo.codigoVuelo = ugdVuelos.ActiveRow.Cells("codigoVuelo").Value
            resDetVuelo.fechaVuelo = ugdVuelos.ActiveRow.Cells("fechaVuelo").Value
            resDetVuelo.llegadaVuelo = ugdVuelos.ActiveRow.Cells("llegadaVuelo").Value
            resDetVuelo.salidaVuelo = ugdVuelos.ActiveRow.Cells("salidaVuelo").Value
            resDetVuelo.enviaVuelo = ugdVuelos.ActiveRow.Cells("enviaVuelo").Value
            resDetVuelo.recibeVuelo = ugdVuelos.ActiveRow.Cells("recibeVuelo").Value
            resDetVuelo.estadoVuelo = ugdVuelos.ActiveRow.Cells("estadoVuelo").Value
            resDetVuelo.briefingVuelo = ugdVuelos.ActiveRow.Cells("briefingVuelo").Value
            resDetVuelo.idAvion = ugdVuelos.ActiveRow.Cells("idAvion").Value
            resDetVuelo.idMatriz = ugdVuelos.ActiveRow.Cells("idMatriz").Value
            resDetVuelo.ciudadOrigen = ugdVuelos.ActiveRow.Cells("ciudadOrigen").Value.ToString
            resDetVuelo.aeropuertoOrigen = ugdVuelos.ActiveRow.Cells("aeropuertoOrigen").Value.ToString
            resDetVuelo.ciudadLlegada = ugdVuelos.ActiveRow.Cells("ciudadLlegada").Value.ToString
            resDetVuelo.aeropuertoLlegada = ugdVuelos.ActiveRow.Cells("aeropuertoLlegada").Value.ToString
            resDetVuelo.descripcionAvion = ugdVuelos.ActiveRow.Cells("descripcionAvion").Value
            resDetVuelo.matriculaAvion = ugdVuelos.ActiveRow.Cells("matriculaAvion").Value
            resDetVuelo.descripcion = ugdVuelos.ActiveRow.Cells("descripcion").Value
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
        Dim Result As New DataTable("Vuelos")
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        Dim dtVuelos As New DataTable


        'With dtVuelo
        '    .idAgencia = uceAerolinea.Value
        '    .llegadaVuelo = udtDesde.Value
        '    .salidaVuelo = udtHasta.Value
        'End With

        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.GetDetalleVueloPorFechaHoy(req)
            If res.ActionResult Then



                If My.Settings.LoginEmpr = 1 Then
                    ugdVuelos.DataSource = res.DsResult.Tables(0)

                    'dtVuelos = res.DsResult.Tables(0).Copy
                    'dtVuelos.Clear()
                    'Dim dresult() As DataRow = res.DsResult.Tables(0).Select("idAgencia <> '3917f93a-0724-11eb-af25-4cd98f5330da'")
                    'If dresult.Length > 0 Then
                    '    dtVuelos.ImportRow(dresult.First())
                    'End If
                    'ugdVuelos.DataSource = dtVuelo


                Else
                    dtVuelos = res.DsResult.Tables(0).Copy
                    dtVuelos.Clear()
                    Dim dresult() As DataRow = res.DsResult.Tables(0).Select("idAgencia = '3917f93a-0724-11eb-af25-4cd98f5330da'")
                    If dresult.Length > 0 Then
                        dtVuelos.ImportRow(dresult.First())
                    End If
                    ugdVuelos.DataSource = dtVuelo
                End If

                RefreshData()
                If res.DsResult.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No existen Vuelos Ingresados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class