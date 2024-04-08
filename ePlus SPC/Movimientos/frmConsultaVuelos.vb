Imports SPC.Server.VuelosService
Public Class frmConsultaVuelos
    Dim tipoAgencia As String = "04be18e6-fd0c-4466-aed2-04b0e8025772" 'aerolineas
    Dim tipoAgenciaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377" 'EXPOREXPRESS

    Public Aerolinea As String = ""
    Public NumeroVuelo As String = ""
    Public resVuelo As New VueloItem
    Public resDetVuelo As New DetalleVuelo
    Dim dtVuelo As New DataTable("dtVuelos")
    Public dtVueloTemp As New DataTable("dtVuelos")

    Private Sub PopulateAerolinea()
        Dim dt As New DataTable("Agencia")
        Dim ds As New DataSet
        uceAerolinea.Items.Clear()
        uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, tipoAgencia, tipoAgenciaEX)).Rows
            uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("DescripcionAgencia"))
        Next
        uceAerolinea.SelectedIndex = 0
    End Sub

    Public Sub RefreshData()
        populateInfoVuelo()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdVuelos.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True
        ugdVuelos.DisplayLayout.Bands(0).Columns("descripcionVuelo").Header.Caption = "Número de Vuelo"
        ugdVuelos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea"
        ugdVuelos.DisplayLayout.Bands(0).Columns("ciudadOrigen").Header.Caption = "Ciudad Origen"
        ugdVuelos.DisplayLayout.Bands(0).Columns("aeropuertoOrigen").Header.Caption = "Aeropuerto Origen"
        ugdVuelos.DisplayLayout.Bands(0).Columns("ciudadLlegada").Header.Caption = "Ciudad Llegada"
        ugdVuelos.DisplayLayout.Bands(0).Columns("aeropuertoLlegada").Format = "Aeropuerto Llegada"
        ugdVuelos.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Vuelo"
        ugdVuelos.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
        ugdVuelos.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub frmConsultaVuelos_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dtVueloTemp.Columns
            .Add("idVuelo", GetType(Guid))
            .Add("descripcionVuelo", GetType(String))
            .Add("descripcionAgencia", GetType(String))
            .Add("ciudadOrigen", GetType(String))
            .Add("aeropuertoOrigen", GetType(String))
            .Add("ciudadLlegada", GetType(String))
            .Add("aeropuertoLlegada", GetType(String))
            .Add("fecha", GetType(DateTime))
        End With
        PopulateAerolinea()
        uceAerolinea.Select()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim Result As New DataTable("Vuelos")
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim myVuelo As New VueloItem
        dtVuelo.Rows.Clear()
        dtVueloTemp.Rows.Clear()
        Try



            General.SetBARequest(req)
            req.prmArr = New String() {uceAerolinea.Value.ToString}
            res = wsClient.GetVuelosPorIdAgencia(req)
            If res.ActionResult Then
                dtVuelo = res.DsResult.Tables(0)
                RefreshData()
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdVuelos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdVuelos.DoubleClickCell
        Aerolinea = uceAerolinea.SelectedItem.ToString
        If MessageBox.Show("¿Desea crear un Nuevo Briefing desde este Vuelo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            resDetVuelo = Nothing
            resVuelo = CommonData.GetVueloItem(ugdVuelos.ActiveRow.Cells("idVuelo").Value)
        Else
            If IsNothing(resDetVuelo) Then
                resVuelo = CommonData.GetVueloItem(ugdVuelos.ActiveRow.Cells("idVuelo").Value)
                VueloInfoVueloToObject()
            Else
                Dim frmConsultaVuelosBriefing As New frmConsultaVuelosBriefing(uceAerolinea.Value)
                frmConsultaVuelosBriefing.ShowDialog()
                If frmConsultaVuelosBriefing.Aerolinea <> "" Then
                    resDetVuelo = frmConsultaVuelosBriefing.resDetVuelo
                End If
                'VueloInfoDetVueloToObject()
            End If
        End If
        NumeroVuelo = ugdVuelos.ActiveRow.Cells("descripcionVuelo").Value
        Me.Close()
    End Sub

    Private Sub VueloInfoDetVueloToObject()
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
            resDetVuelo.ciudadOrigen = ugdVuelos.ActiveRow.Cells("ciudadOrigen").Value
            resDetVuelo.aeropuertoOrigen = ugdVuelos.ActiveRow.Cells("aeropuertoOrigen").Value
            resDetVuelo.ciudadLlegada = ugdVuelos.ActiveRow.Cells("ciudadLlegada").Value
            resDetVuelo.aeropuertoLlegada = ugdVuelos.ActiveRow.Cells("aeropuertoLlegada").Value
            resDetVuelo.descripcionAvion = ugdVuelos.ActiveRow.Cells("descripcionAvion").Value
            resDetVuelo.matriculaAvion = ugdVuelos.ActiveRow.Cells("matriculaAvion").Value
            resDetVuelo.descripcion = ugdVuelos.ActiveRow.Cells("descripcion").Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VueloInfoVueloToObject()
        Try
            'resDetVuelo.idBriefing = ugdVuelos.ActiveRow.Cells("idVuelo").Value
            'resDetVuelo.idVuelo = ugdVuelos.ActiveRow.Cells("descripcionVuelo").Value
            'resDetVuelo.idAgencia = ugdVuelos.ActiveRow.Cells("descripcionAgencia").Value
            'resDetVuelo.descripcionAgencia = ugdVuelos.ActiveRow.Cells("ciudadOrigen").Value
            'resDetVuelo.codigoVuelo = ugdVuelos.ActiveRow.Cells("aeropuertoOrigen").Value
            'resDetVuelo.fechaVuelo = ugdVuelos.ActiveRow.Cells("ciudadLlegada").Value
            'resDetVuelo.llegadaVuelo = ugdVuelos.ActiveRow.Cells("aeropuertoLlegada").Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub populateInfoVuelo()
        If Not IsNothing(dtVuelo) Then
            Dim nr As DataRow
            For Each r As DataRow In dtVuelo.Rows
                Dim temp As String = String.Empty
                nr = dtVueloTemp.NewRow
                nr.Item("idVuelo") = r.Item("idVuelo")
                nr.Item("descripcionVuelo") = r.Item("descripcionVuelo")
                nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                nr.Item("ciudadOrigen") = CommonData.GetCiudadItem(r.Item("ciudadOrigen")).NombreCiudad
                nr.Item("aeropuertoOrigen") = CommonData.GetAirportItem(r.Item("aeropuertoOrigen")).Nombre
                nr.Item("ciudadLlegada") = CommonData.GetCiudadItem(r.Item("ciudadLlegada")).NombreCiudad
                nr.Item("aeropuertoLlegada") = CommonData.GetAirportItem(r.Item("aeropuertoLlegada")).Nombre
                nr.Item("fecha") = r.Item("fecha")
                dtVueloTemp.Rows.Add(nr)
            Next
            ugdVuelos.DataSource = dtVueloTemp
        End If
    End Sub

End Class