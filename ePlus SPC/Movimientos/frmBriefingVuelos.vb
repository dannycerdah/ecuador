Imports SPC.Server.VuelosService
Public Class frmBriefingVuelos
    Public Property myVuelo As New VueloItem
    Public Property myDetalleVuelo As New DetalleVuelo
    Public Property myDetalleRutaVuelo As New DetalleRutaVueloItem
    Public Property myGuia As New GuiaItem
    Public Property myGuiaProducto As New GuiaProductosItem
    Public Property myProceso As New Server.ProcesoService.ProcesoItem
    Public Property IdUsuario As String
    Dim procesoExist As Boolean = False
    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"
    Dim AgenciaTransporte As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim idGeneral As Guid = Guid.Parse("1f2ebac3-c1b8-11e3-a62b-d43d7eb25e94")
    Dim tempAvion As New Server.ReportService.AirplaneCatalogItem
    Dim tempStr As String = ""
    Dim tempIdAer As New Guid
    Dim dtMatriz As New DataTable("Matriz")
    Dim idMatriz As Guid
    Dim descMatriz As String
    Dim dtDestinos As New DataTable("Destinos")
    Dim dtDetalles As New DataTable("Detalles")
    Dim dtVuelo As New DataTable("Vuelo")
    Dim dtTemp As New DataTable("Temporal")
    Dim dtATransporte As New DataTable("Transporte")
    Dim dtBriefingAgencias As New DataTable("BriefingAgencias") 'MARZ
    Dim tempProductoId As String
    Dim tempAgenciaId As String
    Dim isNewVuelo As Boolean
    Dim vueloCreado As Boolean
    Dim guiaCreada As Boolean
    Dim dtRuta As New DataTable("RutaVuelo")
    Dim tempEnvia As String = String.Empty
    Dim tempRecibe As String = String.Empty
    Dim temGuia As New GuiaItem
    Dim dtElemento As New DataTable("Elementos")
    Dim dtElementoAgregado As New DataTable("ElementosAg")

    Public Sub RefreshData()
        Try
            ugdDestinos.DataSource = dtDestinos

            ugdDestinos.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
            ugdDestinos.DisplayLayout.Bands(0).Columns("tipo").Header.Caption = "Tipo"
            ugdDestinos.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
            ugdDestinos.DisplayLayout.Bands(0).Columns("ciudad").Header.Caption = "Ciudad"
            ugdDestinos.DisplayLayout.Bands(0).Columns("idAeropuerto").Hidden = True
            ugdDestinos.DisplayLayout.Bands(0).Columns("aeropuerto").Header.Caption = "Aeropuerto"

            cargarComboDestino()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarColumnasDestinos()
        With dtDestinos.Columns
            .Add("idTipo", GetType(String))
            .Add("tipo", GetType(String))
            .Add("idCiudad", GetType(Guid))
            .Add("ciudad", GetType(String))
            .Add("idAeropuerto", GetType(Guid))
            .Add("aeropuerto", GetType(String))
        End With
    End Sub

    Private Sub cargarColumnasDetalles()
        With dtDetalles.Columns
            .Add("idGuia", GetType(Guid))
            .Add("descripcion", GetType(String))
            .Add("idBriefing", GetType(Guid))
            .Add("idCiudad", GetType(Guid))
            .Add("ciudadDestino", GetType(String))
            .Add("AeropuetosRutas", GetType(String))
            .Add("idProducto", GetType(Guid))
            .Add("producto", GetType(String))
            .Add("idAgencia", GetType(Guid))
            .Add("agencia", GetType(String))
            .Add("peso", GetType(Double))
            .Add("bultos", GetType(Integer))
            .Add("fechaLlegada", GetType(DateTime))
            .Add("estado", GetType(String))
            .Add("DAE", GetType(String))
            .Add("fechaAct", GetType(DateTime))
            .Add("usuarioAct", GetType(String))
            .Add("isEdit", GetType(Boolean))
        End With
    End Sub

    Private Sub cargarUgdDetalles()
        ugdDetalles.DataSource = dtDetalles
        guiaCreada = False
        Try
            ugdDetalles.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripcion"
            ugdDetalles.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("ciudadDestino").Header.Caption = "Destino"
            ugdDetalles.DisplayLayout.Bands(0).Columns("AeropuetosRutas").Header.Caption = "Rutas Guia"
            ugdDetalles.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("producto").Header.Caption = "Producto"
            ugdDetalles.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia"
            ugdDetalles.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
            ugdDetalles.DisplayLayout.Bands(0).Columns("bultos").Header.Caption = "Bultos"
            ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").Header.Caption = "Fecha de Llegada Estimada"
            ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").Format = "dd/MM/yyyy HH:mm"
            ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdDetalles.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("DAE").Hidden = True
            ugdDetalles.DisplayLayout.Bands(0).Columns("isEdit").Hidden = True
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarUgdDestinos()
        Try

            dtTemp = CommonData.GetRutaVueloPorIdVuelo(myVuelo.idVuelo)
            If dtTemp.Rows.Count > 0 Then
                Dim r As DataRow
                For Each row As DataRow In dtTemp.Rows
                    r = dtDestinos.NewRow
                    r.Item("idTipo") = "E"
                    r.Item("tipo") = "Escala"
                    r.Item("idCiudad") = row.Item("ciudadEscala")
                    r.Item("ciudad") = CommonData.GetCiudadItem(row.Item("ciudadEscala")).NombreCiudad
                    r.Item("idAeropuerto") = row.Item("aeropuertoEscala")
                    r.Item("aeropuerto") = CommonData.GetAirportItem(row.Item("aeropuertoEscala")).Nombre
                    dtDestinos.Rows.Add(r)
                Next
            End If
            If myVuelo.idVuelo <> Guid.Empty Then
                Dim r As DataRow
                r = dtDestinos.NewRow
                r.Item("idTipo") = "O"
                r.Item("tipo") = "ORIGEN"
                r.Item("idCiudad") = myVuelo.CiudadOrigen
                r.Item("ciudad") = CommonData.GetCiudadItem(myVuelo.CiudadOrigen).NombreCiudad
                r.Item("idAeropuerto") = myVuelo.AeropuertoOrigen
                r.Item("aeropuerto") = CommonData.GetAirportItem(myVuelo.AeropuertoOrigen).Nombre
                dtDestinos.Rows.Add(r)

                r = dtDestinos.NewRow
                r.Item("idTipo") = "D"
                r.Item("tipo") = "DESTINO"
                r.Item("idCiudad") = myVuelo.CiudadLlegada
                r.Item("ciudad") = CommonData.GetCiudadItem(myVuelo.CiudadLlegada).NombreCiudad
                r.Item("idAeropuerto") = myVuelo.AeropuertoLlegada
                r.Item("aeropuerto") = CommonData.GetAirportItem(myVuelo.AeropuertoLlegada).Nombre
                dtDestinos.Rows.Add(r)
            End If
            RefreshData()
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub btnConsultaAvion_Click(sender As Object, e As EventArgs) Handles btnConsultaAvion.Click
        Dim frmConsultaAvion As New frmConsultaAgencia(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX))
        frmConsultaAvion.ShowDialog()
        If frmConsultaAvion.Avion.Id <> Guid.Empty Then
            tempAvion = frmConsultaAvion.Avion
            tempStr = frmConsultaAvion.tempDesc
            tempIdAer = frmConsultaAvion.tempId
            llenarDtAvion(tempAvion)
        End If
    End Sub

    Private Sub llenarDtAvion(Avion As Server.ReportService.AirplaneCatalogItem)
        txtMatricula.Text = Avion.Matricula
        txtAvion.Text = Avion.Descripcion
        txtAerolinea.Text = tempStr
    End Sub

    Private Sub cargarCombos()
        Try
            udtEta.Value = DateTime.Now
            udtEtd.Value = DateTime.Now
            udtLlegadaGuia.Value = DateTime.Now
            uceTipo.SelectedIndex = 0
            cargarComboPais()
            cargarComboDestino()
            cargarComboAgenciaTransporte()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cargarAgencias()
        cmbAgencias.Enabled = True
        Dim dtAgencia As DataTable = CommonData.GetAgenciaCatalog()
        cmbAgencias.Items.Add(Guid.Empty, "Seleccione agencia")
        For Each r As DataRow In dtAgencia.Rows
            cmbAgencias.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        cmbAgencias.SelectedIndex = 0
        btnAgregarAgencia.Enabled = True
    End Sub


    Private Sub cargarComboAgenciaTransporte()
        Try

            uceAgenciaTransporte.Items.Clear()
            uceAgenciaTransporte.Items.Add("0", "Escoja una Opción")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(AgenciaTransporte).Rows
                uceAgenciaTransporte.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgenciaTransporte.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub cargarComboContactos()
        Try
            uceEnvia.Items.Clear()
            uceEnvia.Items.Add("0", "Escoja una Opción")
            For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(myVuelo.idAgencia).Rows
                uceEnvia.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("segundoApellidoContacto") + " " + r.Item("primerNombreContacto"))
            Next
            If tempEnvia <> String.Empty Then
                Dim cont As Integer = 0
                For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(myVuelo.idAgencia).Rows
                    If r.Item("idContacto") = tempEnvia Then
                        Exit For
                    Else
                        cont += 1
                    End If
                Next
                uceEnvia.SelectedIndex = cont + 1
            Else
                uceEnvia.SelectedIndex = 0
            End If

            uceRecibe.Items.Clear()
            uceRecibe.Items.Add("0", "Escoja una Opción")
            For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(idGeneral).Rows
                uceRecibe.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("segundoApellidoContacto") + " " + r.Item("primerNombreContacto"))
            Next
            uceRecibe.SelectedIndex = 0
            If tempRecibe <> String.Empty Then
                Dim cont2 As Integer = 0
                For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(idGeneral).Rows
                    If r.Item("idContacto") = tempRecibe Then
                        Exit For
                    Else
                        cont2 += 1
                    End If
                Next
                uceRecibe.SelectedIndex = cont2 + 1
            Else
                uceRecibe.SelectedIndex = 0
            End If
            tempEnvia = String.Empty
            tempRecibe = String.Empty
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub cargarComboPais()
        ucePais.Items.Clear()
        ucePais.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            ucePais.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
        Next
        ucePais.SelectedIndex = 0
    End Sub

    Private Sub cargarComboDestino()
        uceDestino.Items.Clear()
        uceDestino.Items.Add(Guid.Empty, "Escoja una Opción")
        For i As Integer = 0 To ugdDestinos.Rows.Count - 1
            If ugdDestinos.Rows.Count > 0 Then
                uceDestino.Items.Add(ugdDestinos.Rows(i).Cells("idCiudad").Value, ugdDestinos.Rows(i).Cells("ciudad").Value)
            End If
        Next
        uceDestino.SelectedIndex = 0
    End Sub

    Private Sub cargarComboCiudad()
        uceCiudad.Items.Clear()
        uceCiudad.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetCiudad(ucePais.Value.ToString).Rows
            uceCiudad.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
        Next
        uceCiudad.SelectedIndex = 0
    End Sub

    Private Sub cargarComboAeropuerto()
        uceAeropuerto.Items.Clear()
        uceAeropuerto.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudad.Value).Rows
            uceAeropuerto.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
        Next
        uceAeropuerto.SelectedIndex = 0
    End Sub

    Private Sub uceCiudad_ValueChanged(sender As Object, e As EventArgs) Handles uceCiudad.SelectionChanged
        cargarComboAeropuerto()
        CargaChekLisAeropuerto()
    End Sub

    Private Sub ucePais_ValueChanged(sender As Object, e As EventArgs) Handles ucePais.SelectionChanged
        cargarComboCiudad()
    End Sub

    Private Sub iniciarValores()
        isNewVuelo = True
        myVuelo.idVuelo = Guid.Empty
        myDetalleVuelo.idBriefing = Guid.NewGuid
        myVuelo.idAgencia = Guid.Empty
        myVuelo.CiudadLlegada = Guid.Empty
        myVuelo.CiudadOrigen = Guid.Empty
    End Sub

    Private Sub cargarColumnasVuelo()
        Try

            With dtVuelo.Columns
                .Add("idBriefing", GetType(Guid))
                .Add("idVuelo", GetType(Guid))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("codigoVuelo", GetType(String))
                .Add("fechaVuelo", GetType(Date))
                .Add("llegadaVuelo", GetType(DateTime))
                .Add("salidaVuelo", GetType(DateTime))
                .Add("enviaVuelo", GetType(String))
                .Add("recibeVuelo", GetType(String))
                .Add("estadoVuelo", GetType(String))
                .Add("briefingVuelo", GetType(DateTime))
                .Add("idAvion", GetType(Guid))
                .Add("idMatriz", GetType(Guid))
                .Add("descripcion", GetType(String))
                .Add("descripcionAvion", GetType(String))
                .Add("matriculaAvion", GetType(String))
            End With
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub frmBriefingVuelos_Load(sender As Object, e As EventArgs) Handles Me.Load
        guiaCreada = False
        vueloCreado = False
        iniciarValores()
        cargarColumnasRuta()
        cargarColumnasVuelo()
        cargarColumnasDestinos()
        cargarColumnasDetalles()
        cargarCombos()
        RefreshData()

        With dtElemento.Columns
            .Add("idElemento", GetType(String))
            .Add("descripcionAgencia", GetType(String))
        End With

        With dtBriefingAgencias.Columns
            .Add("idAgencia", GetType(String))
            .Add("Agencia", GetType(String))
        End With

        With dtElementoAgregado.Columns
            .Add("idElemento", GetType(String))
            .Add("descripcionAgencia", GetType(String))
        End With
        'ugvElementos.DataSource = dtElemento
        'ugvElementosAgregados.DataSource = dtElementoAgregado
        'SetDisplayedColumnsElementos()
        'CargaChekLisAeropuerto()
        If ModuloCierre.EndHilo = False Then
            ModuloCierre.InicioEjecucion = Date.Now
            ModuloCierre.EjecutaHiloVerificacion()
        End If
    End Sub

    Private Sub udtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udtFecha.ValueChanged
        If udtFecha.Enabled Then
            'If udtFecha.Value < Date.Now Then
            '    udtFecha.Value = Date.Now
            'End If
        End If
    End Sub

    Private Sub btnConsultaVuelo_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        Dim frmConsultaVuelos As New frmConsultaVuelos
        frmConsultaVuelos.ShowDialog()
        If frmConsultaVuelos.Aerolinea <> "" Then
            If EvaluarOrigenVuelo() Or EvaluarLlegadaVuelo() Then
                If EvaluarOrigen() Or EvaluarLlegada() Then
                    MessageBox.Show("Ya existe una ciudad de Origen o Destino ingresada.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If frmConsultaVuelos.resVuelo.idVuelo <> Guid.Empty Then
                myVuelo = frmConsultaVuelos.resVuelo
                If Not IsNothing(frmConsultaVuelos.resDetVuelo) Then
                    myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                    cargarVuelos(myDetalleVuelo)
                    obtenerGuia(myDetalleVuelo.idBriefing)
                    obtenerAgencias(myDetalleVuelo.idBriefing)
                    obtenerElementosAgregados(myDetalleVuelo.idBriefing)
                Else
                    cargarUgdDestinos()
                    txtAerolinea.Text = (frmConsultaVuelos.Aerolinea)
                    txtVuelo.Text = (frmConsultaVuelos.NumeroVuelo)
                    RefreshData()
                End If
                cargarComboContactos()
                cargarAgencias()
            ElseIf Not IsNothing(frmConsultaVuelos.resDetVuelo) Then
                If frmConsultaVuelos.resDetVuelo.idVuelo <> Guid.Empty Then
                    myVuelo = frmConsultaVuelos.resVuelo
                    If Not IsNothing(frmConsultaVuelos.resDetVuelo) Then
                        myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                        cargarVuelos(myDetalleVuelo)
                        obtenerGuia(myDetalleVuelo.idBriefing)
                        obtenerAgencias(myDetalleVuelo.idBriefing)
                        obtenerElementosAgregados(myDetalleVuelo.idBriefing)
                    Else
                        cargarUgdDestinos()
                        txtAerolinea.Text = (frmConsultaVuelos.Aerolinea)
                        txtVuelo.Text = (frmConsultaVuelos.NumeroVuelo)
                        RefreshData()
                    End If
                End If
                cargarAgencias()
            End If
            cargarElementos()
        End If
        If dtBriefingAgencias.Rows.Count > 0 Then
            BtnAgregaHorario.Enabled = True
        End If
    End Sub

    Private Function EvaluarOrigenVuelo() As Boolean
        If myVuelo.CiudadOrigen = Guid.Empty Then
            Return False
        End If
        Return True
    End Function

    Private Function EvaluarLlegadaVuelo() As Boolean
        If myVuelo.CiudadLlegada = Guid.Empty Then
            Return False
        End If
        Return True
    End Function

    Private Function EvaluarOrigen() As Boolean
        For i As Integer = 0 To ugdDestinos.Rows.Count - 1
            If ugdDestinos.Rows(i).Cells("tipo").Value = "ORIGEN" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Origen" Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function EvaluarLlegada() As Boolean
        For i As Integer = 0 To ugdDestinos.Rows.Count - 1
            If ugdDestinos.Rows(i).Cells("tipo").Value = "LLEGADA" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Llegada" Then
                Return True
            End If
            If ugdDestinos.Rows(i).Cells("tipo").Value = "DESTINO" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Destino" Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargarVuelos(Vuelo As Server.VuelosService.DetalleVuelo)
        Try
            isNewVuelo = False
            txtVuelo.Text = Vuelo.codigoVuelo
            myVuelo = CommonData.GetVueloItem(Vuelo.idVuelo)
            cargarUgdDestinos()
            txtVuelo.Text = Vuelo.codigoVuelo
            txtMatricula.Text = Vuelo.matriculaAvion
            txtAvion.Text = Vuelo.descripcionAvion
            txtAerolinea.Text = Vuelo.descripcionAgencia
            txtMatrizSeguridad.Text = Vuelo.descripcion
            udtFecha.Value = Vuelo.fechaVuelo
            udtEta.Value = Vuelo.llegadaVuelo
            udtEtd.Value = Vuelo.salidaVuelo
            If Vuelo.enviaVuelo <> String.Empty Then
                tempEnvia = Vuelo.enviaVuelo
            End If
            If Vuelo.recibeVuelo <> String.Empty Then
                tempRecibe = Vuelo.recibeVuelo
            End If
            cargarComboContactos()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnConsMatriz_Click(sender As Object, e As EventArgs) Handles btnConsMatriz.Click
        cargarMatrizSeguridad()
    End Sub


    Private Sub cargarMatrizSeguridad()
        Dim frmElegirMatriz As New frmElegirMatriz()
        frmElegirMatriz.ShowDialog()
        idMatriz = frmElegirMatriz.MatrizSeguridadId
        descMatriz = frmElegirMatriz.MatrizSeguridadDesc
        txtMatrizSeguridad.Text = descMatriz
    End Sub

    Private Sub btnAgregarDestino_Click(sender As Object, e As EventArgs) Handles btnAgregarDestino.Click
        Try

            If String.Compare(uceTipo.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja tipo.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(ucePais.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja un Pais.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceCiudad.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja una Ciudad.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceAeropuerto.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja un Aeropuerto.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If uceTipo.Text <> "TRANSITO" Then
                If uceTipo.Text = "ORIGEN" Then
                    If EvaluarOrigen() Then
                        MessageBox.Show("Ya existe una ciudad de Origen.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                If uceTipo.Text = "DESTINO" Then
                    If EvaluarLlegada() Then
                        MessageBox.Show("Ya existe una ciudad de Destino ingresada.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            End If
            Dim r As DataRow
            r = dtDestinos.NewRow
            r.Item("idTipo") = uceTipo.SelectedItem
            r.Item("tipo") = uceTipo.Text
            r.Item("idCiudad") = uceCiudad.Value
            r.Item("ciudad") = uceCiudad.Text
            r.Item("idAeropuerto") = uceAeropuerto.Value
            r.Item("aeropuerto") = uceAeropuerto.Text
            dtDestinos.Rows.Add(r)
            RefreshData()
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir del Briefing?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnConsProducto_Click(sender As Object, e As EventArgs) Handles btnConsProducto.Click
        Try
            Dim dtProducto As New DataTable("Producto")
            Dim frmConsultaProducto As New frmConsultaProducto
            frmConsultaProducto.ShowDialog()
            If frmConsultaProducto.dtProducto.Rows.Count > 0 Then
                If frmConsultaProducto.dtProducto.Rows(0).Item("idProducto") <> "" Then
                    dtProducto = frmConsultaProducto.dtProducto
                    agregarProducto(dtProducto)
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub agregarProducto(dtProducto As DataTable)
        tempProductoId = dtProducto.Rows(0).Item("idProducto")
        txtProducto.Text = dtProducto.Rows(0).Item("descripcionProducto")
    End Sub

    Private Sub btnConsAgenTran_Click(sender As Object, e As EventArgs)
        Dim frmConsultaTransportista As New frmConsultaAgencia(AgenciaTransporte)
        frmConsultaTransportista.ShowDialog()
        If frmConsultaTransportista.ugdAgentes.Rows.Count > 0 Then
            If frmConsultaTransportista.ugdAgentes.ActiveRow.Cells("idAgencia").Value <> Guid.Empty Then
                dtATransporte = frmConsultaTransportista.dtATransporte
                agregarAgencia(dtATransporte)
            End If
        End If
    End Sub

    Private Sub agregarAgencia(dtTransporte As DataTable)
        uceAgenciaTransporte.Text = dtTransporte.Rows(0).Item("descripcionAgencia")
        uceAgenciaTransporte.Text = dtTransporte.Rows(0).Item("idAgencia")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim caracteres As String
        If txtVuelo.Text = String.Empty Then
            MessageBox.Show("Ingrese el número de Vuelo.", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtGuia.Text = String.Empty Then
            MessageBox.Show("Ingrese el número de Guia.", "Guia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If uceDestino.Text = "Escoja una Opción" Then
            MessageBox.Show("Escoja un destino", "Destino", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtProducto.Text = String.Empty Then
            MessageBox.Show("Escoja un Producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If uceAgenciaTransporte.Text = "Escoja una Opción" Then
            MessageBox.Show("Escoja una Agencia", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtPeso.Text = String.Empty Then
            MessageBox.Show("Ingrese el Peso", "Peso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtBultos.Text = String.Empty Then
            MessageBox.Show("Ingrese el número de Bultos.", "Bultos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If udtLlegadaGuia.Value < Date.Now Then
            MessageBox.Show("La fecha estimada de Llegada no puede ser Menor a la de Hoy.", "Fecha Estimada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Se verifica si es vuelo directo o no para pedir CodigoIATA 'JRO 01022018
        If UltChkDirecto.Checked = False Then
            If UltraTextAeropuertos.Text = String.Empty Then
                MessageBox.Show("Debe seleccionar las rutas por la cual pasara la GUIA", "Rutas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Else
            UltraTextAeropuertos.Text = "Vuelo Directo"
        End If
        Try
            'Limpiar caracteres inecesarios CODIGOSIATA de los Aeropuertos 
            caracteres = UltraTextAeropuertos.Text 'JRO 01022018
            UltraTextAeropuertos.Text = caracteres.Replace("//", "") 'JRO 01022018
            For Each row As DataRow In dtDetalles.Rows
                If row.Item("descripcion") = txtGuia.Text Then
                    MessageBox.Show("Guia ya Ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next
            Dim r As DataRow
            r = dtDetalles.NewRow
            r.Item("idGuia") = Guid.NewGuid
            r.Item("descripcion") = txtGuia.Text
            r.Item("idBriefing") = myDetalleVuelo.idBriefing
            r.Item("idCiudad") = uceDestino.Value
            r.Item("ciudadDestino") = uceDestino.Text
            r.Item("idProducto") = tempProductoId
            r.Item("producto") = txtProducto.Text
            r.Item("idAgencia") = uceAgenciaTransporte.Value
            r.Item("agencia") = uceAgenciaTransporte.Text
            r.Item("peso") = txtPeso.Value
            r.Item("bultos") = txtBultos.Value
            r.Item("fechaLlegada") = udtLlegadaGuia.Value
            r.Item("estado") = "A"
            r.Item("DAE") = " " ' ESTA LINEA ESTABA COM (r.Item("DAE") = " ") DONDE NO AGRAGABA El NUMERO DE DAE FUE CAMBIADA 20 ABRIL 2016 
            r.Item("fechaAct") = Date.Now
            r.Item("usuarioAct") = MyCurrentUser.userName
            r.Item("isEdit") = True
            r.Item("AeropuetosRutas") = UltraTextAeropuertos.Text 'JRO 01022018
            dtDetalles.Rows.Add(r)
            cargarUgdDetalles()
            txtGuia.Clear()
            uceDestino.Clear()
            txtProducto.Clear()
            cargarComboAgenciaTransporte()
            txtPeso.Value = 0
            txtBultos.Value = 0
            UltraTextAeropuertos.Text = Nothing 'JRO 01022018
            UltChkDirecto.Checked = False 'JRO 01022018
            ChkListAero.Items.Clear() 'JRO 01022018
            ModuloCierre.InicioEjecucion = Date.Now
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub SaveGuia()
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim req2 As New GuiaRequest
        Dim res2 As New GuiaResponse
        Dim wsClnt As New Server.VuelosService.VuelosServiceSoapClient
        Try
            'If String.Compare(uceCategories.Text, "Escoja una Opción") = 0 Then
            '    MessageBox.Show("Escoja una categoría para su producto.", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            General.SetBARequest(req)
            For Each r As DataRow In dtDetalles.Rows
                If r.Item("isEdit") Then
                    myGuia.Id = r.Item("idGuia")
                    myGuia.Descripcion = r.Item("descripcion")
                    myGuia.idBriefing = myDetalleVuelo.idBriefing
                    myGuia.idCiudad = r.Item("idCiudad")
                    myGuia.IdAgencia = r.Item("idAgencia")
                    myGuia.Peso = r.Item("peso")
                    myGuia.Bultos = r.Item("bultos")
                    myGuia.FechaLlegada = r.Item("fechaLlegada")
                    myGuia.Estado = r.Item("estado")
                    myGuia.DAE = r.Item("DAE")
                    myGuia.FechaAct = r.Item("fechaAct")
                    myGuia.usuarioAct = MyCurrentUser.userName
                    myGuiaProducto.idGuia = r.Item("idGuia")
                    myGuiaProducto.idProducto = r.Item("idProducto")
                    If r.Item("AeropuetosRutas").ToString = String.Empty Then
                        myGuia.Rutas = Nothing 'JRO 01022018
                    Else
                        myGuia.Rutas = r.Item("AeropuetosRutas") 'JRO 01022018
                    End If
                    req.myGuiaItem = myGuia
                    res = wsClnt.SaveGuiaItem(req)
                    req2.myGuiaProductoItem = myGuiaProducto
                    res2 = wsClnt.SaveGuiaProductosItem(req2)
                End If
            Next
            If res.ActionResult And res2.ActionResult Then
                MessageBox.Show("Registro actualizado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                guiaCreada = True
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
            'MessageBox.Show(res.ErrorMessage)


            MessageBox.Show(Err.Description)
            MessageBox.Show(res2.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub


    Private Function ValidaInfoVuelo() As Boolean
        Dim existOrigen As Boolean = False
        Dim existDestino As Boolean = False
        If txtVuelo.Text = String.Empty Then
            MessageBox.Show("Ingrese Numero de Vuelo.", "Numero Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If txtAerolinea.Text = String.Empty Then
            MessageBox.Show("Escoja una Aerolinea.", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If txtMatricula.Text = String.Empty Then
            MessageBox.Show("Ingrese Matricula de Vuelo.", "Matricula Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If txtAvion.Text = String.Empty Then
            MessageBox.Show("Ingrese Avión.", "Avión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If ugdDestinos.Rows.Count < 1 Then
            MessageBox.Show("No se encuentra ninguna Ciudad ingresada para este vuelo.", "Ningun Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        For i As Integer = 0 To ugdDestinos.Rows.Count - 1
            If ugdDestinos.Rows(i).Cells("tipo").Value = "ORIGEN" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Origen" Then
                existOrigen = True
            End If
        Next
        For i As Integer = 0 To ugdDestinos.Rows.Count - 1
            If (ugdDestinos.Rows(i).Cells("tipo").Value = "LLEGADA" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Llegada") Then
                existDestino = True
            ElseIf (ugdDestinos.Rows(i).Cells("tipo").Value = "DESTINO" Or ugdDestinos.Rows(i).Cells("tipo").Value = "Destino") Then
                existDestino = True
            End If
        Next
        If Not existOrigen Then
            MessageBox.Show("Ingrese una Ciudad de Origen para el Vuelo.", "Ciudad de Origen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If Not existDestino Then
            MessageBox.Show("Ingrese una Ciudad de Destino para el Vuelo.", "Ciudad de Destino", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If txtMatrizSeguridad.Text = String.Empty Then
            MessageBox.Show("Escoja una Matriz de Seguridad.", "Matriz de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If uceEnvia.Text = "Escoja una opción" Or uceEnvia.Text = String.Empty Then
            MessageBox.Show("Ingrese Remitente.", "Remitente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If uceRecibe.Text = "Escoja una opción" Or uceRecibe.Text = String.Empty Then
            MessageBox.Show("Ingrese Destinatario.", "Destinatario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            Exit Function
        End If
        If isNewVuelo Then
            If udtFecha.Value < Date.Today Then
                MessageBox.Show("Ingrese una fecha válida.", "Fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End If
            If udtEta.Value < Date.Now Then
                MessageBox.Show("Ingrese una ETA válida.", "ETA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End If
            If udtEtd.Value < udtEta.Value Then
                MessageBox.Show("Ingrese una ETD válida.", "ETD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function

    Private Sub VueloInfoToObject()
        If isNewVuelo Then
            myVuelo.idVuelo = Guid.NewGuid
        End If
        'myVuelo.idAgencia = tempIdAer
        'For i As Integer = 0 To ugdDestinos.Rows.Count - 1
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDestinos.Rows
            If r.Cells("tipo").Value = "ORIGEN" Or r.Cells("tipo").Value = "Origen" Then
                myVuelo.CiudadOrigen = r.Cells("ciudad").Value
                myVuelo.AeropuertoOrigen = r.Cells("descripcion").Value
            End If
        Next
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDestinos.Rows
            If (r.Cells("tipo").Value = "LLEGADA" Or r.Cells("tipo").Value = "Llegada") Then
                myVuelo.CiudadLlegada = r.Cells("ciudad").Value
                myVuelo.AeropuertoLlegada = r.Cells("descripcion").Value
            ElseIf (r.Cells("tipo").Value = "DESTINO" Or r.Cells("tipo").Value = "Destino") Then
                myVuelo.CiudadLlegada = r.Cells("ciudad").Value
                myVuelo.AeropuertoLlegada = r.Cells("descripcion").Value
            End If
        Next
    End Sub

    Private Sub SaveVuelo()
        Dim resDtR As New Server.VuelosService.DetalleRutaVueloResponse
        Dim reqDt As New Server.VuelosService.DetalleVueloRequest
        Dim resDt As New Server.VuelosService.DetalleVueloResponse
        Dim reqDtR As New Server.VuelosService.DetalleRutaVueloRequest
        Dim wsClnt As New Server.VuelosService.VuelosServiceSoapClient
        Try
            'If String.Compare(uceCategories.Text, "Escoja una Opción") = 0 Then
            '    MessageBox.Show("Escoja una categoría para su producto.", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            If MessageBox.Show("¿Está seguro que desea Guardar este Vuelo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(reqDt)
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDestinos.Rows
                    If r.Cells("tipo").Value = "TRANSITO" Or r.Cells("tipo").Value = "transito" Or r.Cells("tipo").Value = "Escala" Then
                        Try
                            myDetalleRutaVuelo.IdVuelo = myVuelo.idVuelo
                            myDetalleRutaVuelo.CiudadEscala = r.Cells("idCiudad").Value
                            myDetalleRutaVuelo.AeropuertoEscala = r.Cells("idAeropuerto").Value
                            reqDtR.myDetalleRutaVuelo = myDetalleRutaVuelo
                            resDtR = wsClnt.SaveDetalleRutaVueloItem(reqDtR)
                        Catch ex As Exception
                            ErrorManager.SetLogEvent(ex)
                        End Try
                    End If
                Next
                DetalleVueloInfoToObject()
                BriefingAgenciaObject() 'Agencias relacionadas con briefing
                reqDt.myDetalleVuelo = myDetalleVuelo
                resDt = wsClnt.SaveDetalleVuelo(reqDt)
                If resDt.ActionResult Then
                    MessageBox.Show("Vuelo Guardado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    vueloCreado = True
                Else
                    Throw New Exception(resDt.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(resDt.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    'MARZ_02.10.17
    Private Sub BriefingAgenciaObject()
        myDetalleVuelo.briefingAgencias = New List(Of BriefingAgencias)
        dtBriefingAgencias.AcceptChanges()
        For i = 0 To dgvAgenciaBriefing.Rows.Count - 1
            myDetalleVuelo.briefingAgencias.Add(New BriefingAgencias With {.idBriefing = myDetalleVuelo.idBriefing, .idAgencia = Guid.Parse(dtBriefingAgencias.Rows(i).Item("idAgencia").ToString)})
        Next
    End Sub

    Private Sub DetalleVueloInfoToObject()
        If myVuelo.idVuelo <> Guid.Empty Then myDetalleVuelo.idVuelo = myVuelo.idVuelo
        If myVuelo.idVuelo <> Guid.Empty Then myDetalleVuelo.idAgencia = myVuelo.idAgencia
        If txtVuelo.Text <> String.Empty Then myDetalleVuelo.codigoVuelo = txtVuelo.Text
        myDetalleVuelo.fechaVuelo = udtFecha.Value
        myDetalleVuelo.llegadaVuelo = udtEta.Value
        myDetalleVuelo.salidaVuelo = udtEtd.Value
        If uceEnvia.Value <> String.Empty Then myDetalleVuelo.enviaVuelo = uceEnvia.Value
        If uceRecibe.Value <> String.Empty Then myDetalleVuelo.recibeVuelo = uceRecibe.Value
        myDetalleVuelo.estadoVuelo = "A"
        myDetalleVuelo.briefingVuelo = Date.Now
        If tempAvion.Id <> Guid.Empty Then myDetalleVuelo.idAvion = tempAvion.Id
        If idMatriz <> Guid.Empty Then myDetalleVuelo.idMatriz = idMatriz
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidaInfoVuelo() Then
                Exit Sub
            End If
            SaveVuelo()
            If vueloCreado Then
                consultaProceso()
                If Not procesoExist Then
                    SaveProceso()
                End If
                If ugdDetalles.Rows.Count > 0 Then
                    SaveGuia()
                Else
                    MessageBox.Show("No ha ingresado ninguna Guía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
            If vueloCreado Then
                Me.Close()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveElementos()
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim wsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Dim elementoPreBriefing As New Server.ReportService.ElementoPreBriefingItem
            For Each r As DataRow In dtElementoAgregado.Rows
                elementoPreBriefing = New Server.ReportService.ElementoPreBriefingItem
                elementoPreBriefing.idBriefing = myDetalleVuelo.idBriefing
                elementoPreBriefing.idElemento = r.Item("idElemento")
                elementoPreBriefing.fecha = Date.Now
                elementoPreBriefing.idContacto = MyCurrentUser.userName
                elementoPreBriefing.estado = "A"
                elementoPreBriefing.indice = Guid.NewGuid
                req.myElementoPreBriefingItem = elementoPreBriefing
                res = wsClnt.SaveElementoPreBriefing(req)
            Next
            If res.ActionResult Then
                MessageBox.Show("Elementos actualizados con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaProceso()
        Dim proceso As New Server.ProcesoService.ProcesoItem
        Dim contdtMatriz As Integer = 0
        Dim contDtPersonal As Integer = 0
        Dim cantMatriz As Integer = 0
        Try
            With proceso
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            myProceso = proceso
            If Not proceso Is Nothing Then
                procesoExist = True
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SaveProceso() As Boolean
        Dim result As Boolean = False
        Dim req As New Server.ProcesoService.ProcesoRequest
        Dim res As New Server.ProcesoService.ProcesoResponse
        Dim WsClnt As New Server.ProcesoService.ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myProceso) Then myProceso = New Server.ProcesoService.ProcesoItem
            myProceso.IdProceso = Guid.NewGuid
            myProceso.idBriefing = myDetalleVuelo.idBriefing
            myProceso.idAvion = myDetalleVuelo.idAvion
            myProceso.totalBultos = myGuia.Bultos
            myProceso.totalPeso = myGuia.Peso
            myProceso.fechaInicio = Date.Now
            myProceso.estado = "A"
            req.myProcesoItem = myProceso
            res = WsClnt.SaveProcesoItem(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub cargarColumnasRuta()
        With dtRuta.Columns
            .Add("tipo", GetType(String))
            .Add("idCiudad", GetType(Guid))
            .Add("ciudad", GetType(String))
        End With
    End Sub

    Private Sub SetDisplayedColumnsAgencias()
        dgvAgenciaBriefing.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        dgvAgenciaBriefing.DisplayLayout.Bands(0).Columns("Agencia").Header.Caption = "Agencia"
    End Sub

    'MARZ
    Private Sub obtenerAgencias(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New VueloResponse
        Dim dtD As New DetalleVuelo
        Try
            General.SetBARequest(req)
            dtD.idBriefing = idBriefing
            req.myDetalleVuelo = dtD
            res = wsClient.GetAgenciasByBriefing(req)
            dtBriefingAgencias = res.DsResult.Tables(0)
            If res.ActionResult Then
                dgvAgenciaBriefing.DataSource = dtBriefingAgencias
                SetDisplayedColumnsAgencias()
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerGuia(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim dtGuia As New GuiaItem
        Try
            General.SetBARequest(req)
            dtGuia.idBriefing = idBriefing
            req.myGuiaItem = dtGuia
            res = wsClient.GetGuiaPorIdBriefing(req)
            If res.ActionResult Then
                Dim nr As DataRow
                For Each r As DataRow In res.dsResult.Tables(0).Rows
                    nr = dtDetalles.NewRow
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("descripcion") = r.Item("descripcion")
                    nr.Item("idBriefing") = r.Item("idBriefing")
                    nr.Item("idCiudad") = r.Item("idCiudad")
                    nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("producto") = r.Item("producto")
                    nr.Item("idAgencia") = r.Item("idAgencia")
                    nr.Item("agencia") = r.Item("agencia")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("bultos") = r.Item("bultos")
                    nr.Item("fechaLlegada") = r.Item("fechaLlegada")
                    nr.Item("estado") = r.Item("estado")
                    nr.Item("isEdit") = False
                    nr.Item("DAE") = r.Item("DAE")
                    nr.Item("fechaAct") = r.Item("fechaAct")
                    nr.Item("usuarioAct") = r.Item("usuarioAct")
                    nr.Item("AeropuetosRutas") = r.Item("rutas")
                    dtDetalles.Rows.Add(nr)
                Next
                ugdDetalles.DataSource = dtDetalles
                Try
                    ugdDetalles.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripcion"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("ciudadDestino").Header.Caption = "Destino"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("AeropuetosRutas").Header.Caption = "Transito Guia"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("producto").Header.Caption = "Producto"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("peso").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
                    ugdDetalles.DisplayLayout.Bands(0).Columns("bultos").Header.Caption = "Bultos"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("bultos").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
                    ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").Header.Caption = "Fecha"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").Format = "dd/MM/yyyy"
                    ugdDetalles.DisplayLayout.Bands(0).Columns("fechaLlegada").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
                    'CellActivation = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
                    ugdDetalles.DisplayLayout.Bands(0).Columns("estado").Hidden = True
                    ugdDetalles.DisplayLayout.Bands(0).Columns("isEdit").Hidden = True
                Catch ex As Exception
                    ErrorManager.SetLogEvent(ex)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerElementosAgregados(idBriefing As Guid)
        Dim wsClient As New Server.ReportService.ReportServiceSoapClient
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ReportResponse
        Dim elemento As New Server.ReportService.ElementoPreBriefingItem
        Try
            General.SetBARequest(req)
            elemento.idBriefing = idBriefing
            req.myElementoPreBriefingItem = elemento
            res = wsClient.GetElementoPreBriefingPorIdBriefing(req)
            If res.ActionResult Then
                Dim nr As DataRow
                For Each r As DataRow In res.DsResult.Tables(0).Rows
                    nr = dtElementoAgregado.NewRow
                    nr.Item("idElemento") = r.Item("idElemento").ToString
                    nr.Item("descripcionAgencia") = CommonData.GetElementoItem(r.Item("idElemento").ToString).descripcionAgencia
                    dtElementoAgregado.Rows.Add(nr)
                Next
                'ugvElementosAgregados.DataSource = dtElementoAgregado
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Private Sub udtEta_ValueChanged(sender As Object, e As EventArgs) Handles udtEta.ValueChanged
    '    If udtEta.Enabled Then
    '        If udtEta.Value < Date.Now.AddHours(2) Then
    '            udtEta.Value = Date.Now
    '        End If
    '        If udtEta.Value.Day < Date.Now.Day Then
    '            udtEta.Value = Date.Now
    '        End If
    '    End If
    'End Sub


    'Private Sub udtEtd_ValueChanged(sender As Object, e As EventArgs) Handles udtEtd.ValueChanged
    '    If udtEtd.Enabled Then
    '        If udtEtd.Value < (Date.Now.AddHours(2)) Then
    '            udtEtd.Value = Date.Now
    '        End If
    '    End If
    'End Sub

    'Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
    '        Using frmPreseleccionElementos As New frmPreseleccionElementos(myDetalleVuelo)
    '            frmPreseleccionElementos.ShowDialog()
    '        End Using
    'End Sub

    Private Sub ugdDetalles_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugdDetalles.AfterRowsDeleted
        If DeleteDetalleGuiaProducto() And DeleteDetalleGuiaCamiones() Then
            If Not DeleteGuiaItem() Then
                MessageBox.Show("Error al eliminar la Guia", "Error", MessageBoxButtons.OK)
            Else
                obtenerGuia(myDetalleVuelo.idBriefing)
            End If
        Else
            MessageBox.Show("Error al eliminar los deltalles de la Guia", "Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Function DeleteDetalleGuiaProducto() As Boolean
        Dim result = False
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim WsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaItem = temGuia
            res = WsClnt.DeleteDetalleGuiaProducto(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function DeleteDetalleGuiaCamiones() As Boolean
        Dim result = False
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim WsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaItem = temGuia
            res = WsClnt.DeleteDetalleGuiaCamiones(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function DeleteGuiaItem() As Boolean
        Dim result = False
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim WsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaItem = temGuia
            res = WsClnt.DeleteGuiaItem(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub ugdDetalles_AfterRowUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles ugdDetalles.AfterRowUpdate
        For Each r As DataRow In dtDetalles.Rows
            If r.Item("idGuia") = ugdDetalles.ActiveRow.Cells("idGuia").Value Then
                r.Item("isEdit") = True
            End If
        Next
    End Sub

    Private Sub ugdDetalles_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles ugdDetalles.BeforeRowsDeleted
        temGuia.Id = ugdDetalles.ActiveRow.Cells("idGuia").Value
    End Sub

    Private Sub cargarElementos()
        Try
            ConsultaElementos()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub SetDisplayedColumnsElementos()
    '    ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
    '    ugvElementos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"

    '    ugvElementosAgregados.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
    '    ugvElementosAgregados.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
    'End Sub

    Private Sub ConsultaElementos()
        Try
            Dim tempElemento As New Server.ReportService.ElementoCatalogItem
            tempElemento.estado = "S"
            For Each r As DataRow In CommonData.GetElementosPorEstado(tempElemento).Rows
                Dim nr As DataRow
                nr = dtElemento.NewRow
                nr.Item("idElemento") = r.Item("idElemento")
                ' nr.Item("idAgencia") = r.Item("idAgencia")
                ' nr.Item("tipoElemento") = r.Item("tipoElemento")
                nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                ' nr.Item("pesoReal") = r.Item("pesoReal")
                ' nr.Item("estado") = r.Item("estado")
                dtElemento.Rows.Add(nr)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs)
    '    If txtElemento.Text.Length > 0 Then
    '        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
    '            If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
    '                r.Hidden = False
    '            Else
    '                r.Hidden = True
    '            End If
    '        Next
    '    Else
    '        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
    '            r.Hidden = False
    '        Next
    '    End If
    'End Sub

    'Private Sub ugvElementos_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs)
    '    Try
    '        If ugvElementos.ActiveRow.Cells("idElemento").Value <> String.Empty Then
    '            If Not ValidaInfoElemento(ugvElementos.ActiveRow.Cells("idElemento").Value) Then
    '                MessageBox.Show("Elemento ya ingresado, revisar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Exit Sub
    '            End If
    '            Dim nr As DataRow
    '            nr = dtElementoAgregado.NewRow
    '            nr.Item("idElemento") = ugvElementos.ActiveRow.Cells("idElemento").Value
    '            nr.Item("descripcionAgencia") = ugvElementos.ActiveRow.Cells("descripcionAgencia").Value
    '            dtElementoAgregado.Rows.Add(nr)
    '        End If
    '    Catch ex As Exception
    '        General.SetLogEvent(ex)
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Function ValidaInfoElemento(idElemento As String) As Boolean
        Dim result As Boolean = True
        For Each r As DataRow In dtElementoAgregado.Rows
            If idElemento = r.Item("idElemento") Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Private Sub btnAgregarAgencia_Click(sender As Object, e As EventArgs) Handles btnAgregarAgencia.Click
        If cmbAgencias.SelectedIndex > 0 Then
            Dim newRow As DataRow
            newRow = dtBriefingAgencias.NewRow
            newRow.Item(0) = cmbAgencias.Value
            newRow.Item(1) = cmbAgencias.Text
            dtBriefingAgencias.Rows.Add(newRow)
            dgvAgenciaBriefing.DataSource = dtBriefingAgencias
            If dgvAgenciaBriefing.Rows.Count <= 1 Then
                If BtnAgregaHorario.Enabled = False Then
                    BtnAgregaHorario.Enabled = True
                End If
                SetDisplayedColumnsAgencias()
            End If
        Else
            MessageBox.Show("No ha seleccionado Agencia de relación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub CargaChekLisAeropuerto()
        Try
            ChkListAero.Items.Clear()
            For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudad.Value).Rows
                Dim cb2 = New CheckedListBox
                cb2.Tag = r.Item("codigoIATA")
                cb2.Text = r.Item("nombreAeropuerto")
                ChkListAero.Items.Add(cb2)
            Next
            ChkListAero.DisplayMember = "Text"
        Catch ex As Exception
            MessageBox.Show("Error al Cargar los Aeropuertos" & ex.Message)
        End Try

    End Sub
    'Evento para concatenar los CODIGOSIATA de los Aeropuertos 'JRO 01022018
    Private Sub ChkListAero_SelectedValueChanged(sender As Object, e As EventArgs) Handles ChkListAero.SelectedValueChanged
        Dim Caracteres As String
        For i = 0 To ChkListAero.Items.Count - 1
            If ChkListAero.GetItemChecked(i) = True And ChkListAero.GetSelected(i) = True Then
                If Len(UltraTextAeropuertos.Text) <= 1 Then
                    UltraTextAeropuertos.Text = ChkListAero.Items(i).tag.ToString
                Else
                    UltraTextAeropuertos.Text = UltraTextAeropuertos.Text & "/" & ChkListAero.Items(i).tag.ToString
                End If

            ElseIf ChkListAero.GetItemChecked(i) = False And ChkListAero.GetSelected(i) = True Then
                Caracteres = UltraTextAeropuertos.Text
                Caracteres = Caracteres.Replace(ChkListAero.Items(i).tag.ToString, "")
                UltraTextAeropuertos.Text = Caracteres.Replace("//", "")
                If Len(Caracteres) <= 1 Then
                    UltraTextAeropuertos.Text = Nothing
                End If

            End If
        Next
    End Sub
    'Evento que limpia los CODIGOSIATA de los Aeropuertos 'JRO 01022018
    Private Sub UltBtnLimRutas_Click(sender As Object, e As EventArgs) Handles UltBtnLimRutas.Click 'JRO 01022018
        UltraTextAeropuertos.Text = String.Empty
    End Sub

    Private Sub BtnAgregaHorario_Click(sender As Object, e As EventArgs) Handles BtnAgregaHorario.Click
        Dim frm As New HorariosAgenciasSeguridad
        frm.IdBriefing = myDetalleVuelo.idBriefing
        frm.Vuelo = txtVuelo.Text
        frm.dtBriefingAgencias = dtBriefingAgencias
        frm.IdUsuario = IdUsuario
        frm.ShowDialog()
    End Sub

    Private Sub frmBriefingVuelos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmBriefingVuelos_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmBriefingVuelos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ModuloCierre.EndHilo = False
    End Sub

    Private Sub txtGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGuia.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub uceAgenciaTransporte_ValueChanged(sender As Object, e As EventArgs) Handles uceAgenciaTransporte.ValueChanged
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub
End Class