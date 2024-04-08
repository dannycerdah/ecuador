Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports System.IO.Ports
Imports System.IO
Imports System.Threading
Imports SPC.MessagesManager

Public Class frmCapturaPeso
    Public Property myPersonalProceso As New PersonalProcesoItem
    Public Property myProceso As New ProcesoItem
    Public Property myDetalleProceso As New DetalleProcesoItem
    Public Property myGuia As New GuiaItem
    Public Property myDetalleVuelo As New DetalleVuelo
    Public Property myElementoProceso As New ElementoProcesoItem
    Public Property myElemento As New Server.ReportService.ElementoCatalogItem
    Dim envia As New Server.ReportService.ContactoCatalogItem
    Dim recibe As New Server.ReportService.ContactoCatalogItem
    Dim idTipoGeneral As String = "38b4e437-f3dd-4625-8e73-538858824fce"
    Dim Agencia2 As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim tempContacto As New Server.ReportService.ContactoCatalogItem
    Dim dtMatriz As New DataTable("Matriz")
    Dim dtTempMatriz As New DataTable("tempMatriz")
    Dim dtCaptura As New DataTable("Captura")
    Dim dtCapturaDev As New DataTable("Captura")
    Dim dtTotalElementos As New DataTable("TotalElementos")
    Dim dtTotalGuias As New DataTable("TotalGuias")
    Dim dtTotalGuiasDev As New DataTable("TotalGuias")
    Dim dtGuias As New DataTable("Guias")
    Dim dtGuiaCamiones As New DataTable("GuiaCamiones")
    Dim dtGuiaProductos As New DataTable("GuiaProductos")
    Dim dtDetalleProceso As New DataTable("Procesos")
    Dim dtDetalleProcesoDev As New DataTable("Procesos")
    Dim dtdetalleProcesoTemp As New DataTable("ProcesosTemp")
    Dim dtElementoProceso As New DataTable("dtElementoProceso")
    Dim dtSellocamiones As New DataTable("Sellocamiones")

    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Dim DataIn As String = String.Empty
    Private PI_PosicionKg As Integer = 0
    Dim band_balanza As Boolean = False
    Dim id As Guid
    Dim idProceso As New Guid
    Dim ult As Integer = 0
    Dim procesoExist As Boolean = False
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim cantBultos As Integer = 1
    Dim isNewProceso As Boolean = False
    Dim tempElementoProceso As New ElementoProcesoItem
    Dim balanzaIsActive As Boolean = True
    Dim dtPersonal As New DataTable("dtPersonalProceso")
    Dim thrdConsultaDetalleProceso As Thread
    Dim isDetalleProcesoChange As Boolean = False
    Dim isFullDetalleCapturaInGrid As Boolean = False
    Dim myValidezDae As New ValidezDae
    Dim dtValidezDae As DataTable
    Dim estadoDAE As Boolean = False
    Dim isEnableConsultaProceso As Boolean = True
    Dim usuarioRequiere As New Server.ReportService.ContactoCatalogItem
    Dim value As Boolean = True
    Dim PathLog As String = ""
    Dim PathLogBita As String = ""
    Private LsBandeAct As String = "N" 'JRO 01022018
    Private LnIndexAct As Integer = Nothing 'JRO 01022018 
    Public Property IndiceEstadoSenae As New DetalleProcesoItem
    Dim dtGuiaDaeRem As New DataTable("dtGuiaDaeRem")
    Public Property IdUsuario As String
    Dim Mensaje As String = String.Empty
    Dim ActVolumen As Boolean = True
    Dim RegActualizado As Boolean = False
    Dim RegistroActualizadoCorreo As Boolean = False
    Private RemActivo As Boolean = False
    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            'dtValidezDae = SearchDAE("01920164000003332") 'Webservice Ecuapass con niveles de seguridad - MARZ - Test
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> String.Empty Then
                obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                CargarVuelo(frmConsultaVuelos.Aerolinea)
                If Not procesoExist Then
                    SaveProceso()
                End If
                'Timer1.Enabled = True
                CalcularTotales()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SubProcesoObtenerProceso(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim bitacora As New Stopwatch()
        'bitacora.Start()
        'EscribirLineaLog("Hora en el que se ejecuto el proceso que llama al procedimiento q registra ObtenerProceso " & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & vbCrLf, PathLogBita)
        ''ObtenerProceso()
        'bitacora.Stop()
        'EscribirLineaLog("Hora en el que finalizo el proceso que llama al procedimiento q registra ObtenerProceso " & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & "Tiempo que se demoro ejecutando el proceso " & bitacora.Elapsed.ToString & vbCrLf, PathLogBita)
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        Try
            txtAgencia.Text = Aerolinea
            txtNumVuelo.Text = resDtVuelo.codigoVuelo
            envia = CommonData.GetContactoItem(resDtVuelo.enviaVuelo)
            txtDe.Text = envia.primerApellido + " " + envia.segundoApellido + " " + envia.primerNombre
            recibe = CommonData.GetContactoItem(resDtVuelo.recibeVuelo)
            txtPara.Text = recibe.primerApellido + " " + recibe.segundoApellido + " " + recibe.primerNombre
            txtAvion.Text = resDtVuelo.descripcionAvion
            txtMatricula.Text = resDtVuelo.matriculaAvion
            udtEta.Value = resDtVuelo.llegadaVuelo
            udtEtd.Value = resDtVuelo.salidaVuelo
            udtFecha.Value = resDtVuelo.fechaVuelo
            dtTempMatriz = CommonData.GetMatrizSeguridadItemById(resDtVuelo.idMatriz)
            CargarUgvPers(1)
            consultaProceso()
            If Not IsNothing(myProceso) Then
                If myProceso.estado = "T" Then
                    uceElementos.Enabled = False
                    'txtVolumen.Enabled = False
                    txtPeso.Enabled = False
                    txtLector.Enabled = False
                    For Each r In ugvPersonal.Rows
                        r.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Next
                    For Each r In ugvCaptura.Rows
                        r.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    Next
                    Me.ugvCaptura.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
                Else
                    isNewProceso = True
                    uceElementos.Enabled = True
                    'txtVolumen.Enabled = True
                    txtPeso.Enabled = True
                    txtLector.Enabled = True
                    Me.ugvCaptura.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
                End If
            Else
                myProceso = New ProcesoItem
                isNewProceso = True
                uceElementos.Enabled = True
            End If
            ObtenerGuias(resDtVuelo.idBriefing)
            CargarGuias()
            CargarPosiciones()
            CargarElementos()
            CargarSellosCamiones()


        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarElementos()
        Dim dtElementos As New DataTable("Elementos")
        Dim elementoBriefing As New Server.VuelosService.ElementoBriefingItem
        elementoBriefing.idBriefing = myDetalleVuelo.idBriefing
        dtElementos = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefing)
        uceElementos.Items.Clear()
        uceElementos.Items.Add("0", "Escoja una opción")
        For Each r As DataRow In dtElementos.Rows
            uceElementos.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
        Next
        uceElementos.SelectedIndex = 1
    End Sub

    Private Sub CargarPosiciones()
        Try
            ucePosicion.Items.Clear()
            For Each r As DataRow In CommonData.GetPosicionesCatalog.Rows
                ucePosicion.Items.Add(r.Item("idPosicion"), r.Item("descripcionPosicion"))
            Next
            ucePosicion.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarGuias()
        Try
            For Each r As DataRow In dtGuias.Rows
                Dim tempGuiaCamion As New GuiaCamionesItem
                tempGuiaCamion.idGuia = r.Item("idGuia")
                tempGuiaCamion.fecha = r.Item("fechaLlegada")
                If CommonProcess.GetGuiaCamionesPorId(tempGuiaCamion).Rows.Count > 0 Then
                    r.Item("camionAsig") = True
                Else
                    r.Item("camionAsig") = False
                End If
            Next
            If Not IsNothing(dtGuias) Then
                uceGuias.Items.Clear()
                For Each r As DataRow In dtGuias.Rows
                    uceGuias.Items.Add(r.Item("idGuia"), r.Item("descripcion"))
                Next
                uceGuias.SelectedIndex = 0
                utcTabs.Enabled = True
                'GUIAS  PARA CAMIONES
                uceGuiasSellos.Items.Clear()
                For Each r As DataRow In dtGuias.Rows
                    uceGuiasSellos.Items.Add(r.Item("idGuia"), r.Item("descripcion"))
                Next
                uceGuiasSellos.SelectedIndex = 0

            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerDetalleVuelo(ByVal BriefingId As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        With dtVuelo
            .idBriefing = BriefingId
        End With
        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.GetDetalleVueloPorIdBriefing(req)
            If res.ActionResult Then
                resDtVuelo = res.myDetalleVuelo
                resDsVuelo = res.DsResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtAvion.Clear()
        txtAlto.Text = "0.00"
        txtAncho.Text = "0.00"
        txtDe.Clear()
        txtMatricula.Clear()
        txtNumVuelo.Clear()
        txtPara.Clear()
        txtPeso.Text = "0.00"
        txtTBultosGuia.Clear()
        txtTPesoGuia.Clear()
        txtVolumen.Text = "0.00"
        txtTotBulto.Clear()
        txtTotPeso.Clear()
        txtTotPiezas.Clear()
        txtTotVol.Clear()
        txtcodSello.Text = ""
        txtnumSaca.Text = ""
        udtFecha.Value = Date.Now
        udtEta.Value = Date.Now
        udtEtd.Value = Date.Now
        dtCaptura.Rows.Clear()
        dtCapturaDev.Rows.Clear()
        dtMatriz.Rows.Clear()
        dtDetalleProceso.Rows.Clear()
        dtDetalleProcesoDev.Rows.Clear()
        dtdetalleProcesoTemp.Rows.Clear()
        dtGuiaCamiones.Rows.Clear()
        dtGuiaProductos.Rows.Clear()
        dtGuias.Rows.Clear()
        dtSellocamiones.Rows.Clear()
        dtMatriz.Rows.Clear()
        dtPersonal.Rows.Clear()
        dtTempMatriz.Rows.Clear()
        dtTotalElementos.Rows.Clear()
        dtTotalGuias.Rows.Clear()
        dtTotalGuiasDev.Rows.Clear()
        uceAgencia.Items.Clear()
        uceCamiones.Items.Clear()
        uceElementos.Items.Clear()
        uceGuias.Items.Clear()
        ucePosicion.Items.Clear()
        uceProducto.Items.Clear()
    End Sub

    Private Sub ObtenerGuias(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim Guia As New GuiaItem
        With Guia
            .idBriefing = idBriefing
        End With
        Try
            General.SetBARequest(req)
            req.myGuiaItem = Guia
            res = wsClient.GetGuiaPorIdBriefing(req)
            If res.ActionResult Then
                If dtGuias.Rows.Count = 0 Then
                    Dim nr As DataRow
                    For Each r As DataRow In res.dsResult.Tables(0).Rows
                        nr = dtGuias.NewRow
                        nr.Item("idGuia") = r.Item("idGuia")
                        nr.Item("descripcion") = r.Item("descripcion")
                        nr.Item("idBriefing") = r.Item("idBriefing")
                        nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                        nr.Item("idAgencia") = r.Item("idAgencia")
                        nr.Item("descripcionAgencia") = r.Item("agencia")
                        nr.Item("peso") = r.Item("peso")
                        nr.Item("bultos") = r.Item("bultos")
                        nr.Item("fechaLlegada") = r.Item("fechaLlegada")
                        nr.Item("estado") = r.Item("estado")
                        nr.Item("DAE") = r.Item("DAE")
                        nr.Item("enviadoSenae") = False
                        dtGuias.Rows.Add(nr)
                    Next
                Else
                    For Each r2 As DataRow In dtGuias.Rows
                        For Each r As DataRow In res.dsResult.Tables(0).Rows
                            If r2.Item("idGuia") = r.Item("idGuia") Then
                                r2.Item("DAE") = r.Item("DAE")
                                Exit For
                            End If
                        Next
                    Next
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerGuiaPorIdGuia(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim Guia As New GuiaItem
        With Guia
            .Id = uceGuias.Value
        End With
        Try
            General.SetBARequest(req)
            req.myGuiaItem = Guia
            res = wsClient.GetGuiaPorIdGuia(req)
            If res.ActionResult Then
                myGuia = res.myGuiaItem
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "Balanza"
    Private capturaPeso As Boolean = True
    Private Sub Configurar_Balanza()
        Try
            If Config.IsUsingScale And balanzaIsActive Then
                With SP1
                    If .IsOpen Then
                        .Close()
                    End If
                    .PortName = Config.scPort
                    .BaudRate = Config.scBaudRate ' 9600 '// 19200 baud rate
                    .DataBits = Config.scDataBits ' 7 '// 8 data bits
                    .StopBits = Config.scStopBits ' IO.Ports.StopBits.One
                    .Parity = Config.scParity ' IO.Ports.Parity.None
                    .Handshake = IO.Ports.Handshake.None
                    .ReceivedBytesThreshold = 20
                    .Encoding = System.Text.Encoding.Default
                    .Open() ' ABRE EL PUERTO SERIE

                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            band_balanza = True
        End Try
    End Sub

    Private Sub SP1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SP1.DataReceived
        Try
            If capturaPeso And balanzaIsActive Then
                DataIn = SP1.ReadExisting
                'EscribirLineaLog(DataIn & " " & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & vbCrLf, PathLogBita)
                If DataIn.Length > 0 Then
                    SetText(DataIn)
                End If
            End If
        Catch ex As Exception
            capturaPeso = False
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub SetText(ByVal text As String)
    '    Try
    '        If Me.txtPeso.InvokeRequired Then
    '            Dim d As New SetTextCallback(AddressOf SetText)
    '            Me.Invoke(d, New Object() {text})
    '        Else
    '            Me.txtPeso.Text = Double.Parse(text.Substring(9, 7))
    '        End If
    '        SP1.DiscardInBuffer()

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub SetText(ByVal text As String)
        Try
            If capturaPeso And balanzaIsActive Then
                If Me.txtPeso.InvokeRequired Then
                    Dim d As New SetTextCallback(AddressOf SetText)
                    Me.Invoke(d, New Object() {text})
                Else
                    If Config.SbuscarKg = 1 Then
                        'PI_PosicionKg = Config.scStringEndChar + 1
                        Dim posicion As Integer = 0
                        'If PI_PosicionKg = InStr(text, "kg") Then
                        '    posicion = InStr(text, "kg")
                        '    text = text.Substring(0, posicion - 1)
                        '    text = text.Substring(Config.scStringBeginChar)
                        '    text = text.Replace(" ", "")
                        '    If IsNumeric(text.Substring(0, 1)) Then
                        '        Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                        '    Else
                        '        EscribirLineaLog(text & " else no posicion" & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & vbCrLf, PathLogBita)
                        '        MessageBox.Show("Verificar la posicion inicial de la configuracion de la balanza")
                        '    End If
                        'Else
                        '    posicion = InStr(text, "kg")
                        '    text = text.Substring(0, posicion - 1)
                        '    text = text.Replace(" ", "")
                        '    If IsNumeric(text.Substring(0, 1)) Then
                        '        Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                        '    Else
                        '        EscribirLineaLog(text & " else no numerico" & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & vbCrLf, PathLogBita)
                        '        MessageBox.Show("El visor de la Balanza esta enviando cadena de caracteres distintas verificar con sistemas.")
                        '    End If
                        'End If
                        posicion = InStr(text, Config.SCaracterBuscar)
                        text = text.Substring(posicion - 1 - Config.SNumCadena, Config.SNumCadena)
                        text = text.Replace(" ", "")
                        If IsNumeric(text) Then
                            Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                        Else
                            EscribirLineaLog(text & " else no posicion" & Date.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt") & vbCrLf, PathLogBita)
                            MessageBox.Show("Comunicar con Sistemas para que Verifique la cadena de Caracteres enviada por el Visor de la Balzan.")
                        End If
                    Else
                        text = text.Substring(Config.scStringBeginChar, Config.scStringEndChar - Config.scStringBeginChar)
                        If IsNumeric(text) Then
                            Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                        End If
                    End If

                    'Me.txtpesoreal.Text = Double.Parse(text.Substring(9, 7))
                End If
                SP1.DiscardInBuffer()
            End If

        Catch ex As Exception
            capturaPeso = False
        End Try
    End Sub

#End Region

    Private Sub llenarDtPersoanl()
        Try
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvPersonal.Rows
                If ugvPersonal.ActiveRow.Cells("grupoPersonal").Value = r.Cells("grupoPersonal").Value Then
                    If tempContacto.idContacto = r.Cells("idContacto").Value.ToString And ugvPersonal.ActiveRow.Cells("cargoPersonal").Value.ToString = r.Cells("cargoPersonal").Value And r.Cells("horaSalida").Value.ToString = Date.Parse("00:00:00").ToString Then
                        MessageBox.Show("Contacto ya asignado para este Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            Next
            ugvPersonal.ActiveRow.Cells("idAgencia").Value = tempContacto.idAgencia
            ugvPersonal.ActiveRow.Cells("idContacto").Value = tempContacto.idContacto
            ugvPersonal.ActiveRow.Cells("contacto").Value = tempContacto.primerNombre + " " + tempContacto.primerApellido
            ugvPersonal.ActiveRow.Cells("horaEntrada").Value = DateTime.Now
            ugvPersonal.ActiveRow.Cells("horaSalida").Value = Date.Parse("00:00:00")
            SavePersonalProceso()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCapturaPeso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        takeScreenshot(PathLog)
        PI_PosicionKg = 0
        SP1.Close()
        ModuloCierre.EndHilo = False
    End Sub

    Private Sub frmCapturaPeso_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'ini Jordan Rodriguez 18/07/2022
            'Se modifica metodo para que valide un parametro si el rem esta vijente
            'con el fin de ver si en el restro de la funcionalidad de la pantalla
            'se debe considerar el rem en su proceso
            Dim dtParametros As DataTable
            dtParametros = CommonProcess.GetParametro("VALIDA_REM")
            For Each r As DataRow In dtParametros.Rows
                If r.Item("estado") = "A" Then
                    RemActivo = True
                    Exit For
                End If
            Next
            'fin Jordan Rodriguez 18/07/2022
            CrearArchivoLog(".", PathLog)
            CrearArchivoLogBitacora(".")
            udtUltimo.Value = Date.Now
            idProceso = Guid.NewGuid
            obtenerDatosHost()
            Configurar_Balanza()
            utcTabs.Enabled = False
            btnConsVuelo.Select()
            If ModuloCierre.EndHilo = False Then
                ModuloCierre.InicioEjecucion = Date.Now
                ModuloCierre.EjecutaHiloVerificacion()
            End If

            If My.Settings.LoginEmpr = 2 Then
                utcTabs.Tabs(0).Text = "Personal Autorizado para Ingreso "
                ugbSacainfo.Visible = True


            End If

            With dtGuias.Columns
                .Add("idGuia", GetType(Guid))
                .Add("descripcion", GetType(String))
                .Add("idBriefing", GetType(Guid))
                .Add("ciudadDestino", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("peso", GetType(Decimal))
                .Add("bultos", GetType(Integer))
                .Add("fechaLlegada", GetType(DateTime))
                .Add("estado", GetType(String))
                .Add("DAE", GetType(String))
                .Add("camionAsig", GetType(Boolean))
                .Add("enviadoSenae", GetType(Boolean))
            End With
            With dtMatriz.Columns
                .Add("grupoPersonal", GetType(Integer))
                .Add("cantidadPersonal", GetType(Integer))
                .Add("cargoPersonal", GetType(String))
                .Add("tipoAgenciaRequerida", GetType(String))
                .Add("descripcionTipoAgencia", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("idContacto", GetType(String))
                .Add("contacto", GetType(String))
                .Add("horaEntrada", GetType(DateTime))
                .Add("horaSalida", GetType(DateTime))
            End With
            With dtTotalElementos.Columns
                .Add("elemento", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Decimal))
                .Add("pesoVolumen", GetType(Decimal))
            End With
            ugvTotalElemento.DataSource = dtTotalElementos
            SetDisplayedColumnsElemento()

            With dtTotalGuias.Columns
                .Add("idGuia", GetType(String))
                .Add("guia", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Decimal))
                .Add("pesoVolumen", GetType(Decimal))
                .Add("fecha", GetType(DateTime))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("tempMax", GetType(Double))
                .Add("tempMin", GetType(Double))
                .Add("tempSum", GetType(Double))
                .Add("tempPro", GetType(Double))
                .Add("Rx", GetType(Integer))
                .Add("Man", GetType(Integer))
                .Add("K9", GetType(Integer))
                .Add("Eds", GetType(Integer))
                .Add("alto", GetType(Double))
                .Add("ancho", GetType(Double))
                .Add("largo", GetType(Double))
                .Add("idCamion", GetType(String))
                .Add("Observacion", GetType(String))
            End With
            With dtTotalGuiasDev.Columns
                .Add("idGuia", GetType(String))
                .Add("guia", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Decimal))
                .Add("pesoVolumen", GetType(Decimal))
                .Add("fecha", GetType(DateTime))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("tempMax", GetType(Double))
                .Add("tempMin", GetType(Double))
                .Add("tempSum", GetType(Double))
                .Add("tempPro", GetType(Double))
                .Add("Rx", GetType(Integer))
                .Add("Man", GetType(Integer))
                .Add("K9", GetType(Integer))
                .Add("Eds", GetType(Integer))
                .Add("alto", GetType(Double))
                .Add("ancho", GetType(Double))
                .Add("largo", GetType(Double))
                .Add("idCamion", GetType(String))
                .Add("Observacion", GetType(String))
            End With
            ugvTotalGuias.DataSource = dtTotalGuias
            SetDisplayedColumnsGuia()
            With dtDetalleProceso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("dae", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("agenciaTransporteDescripcion", GetType(String))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Decimal))
                .Add("piezas", GetType(Integer))
                .Add("volumen", GetType(Double))
                .Add("hora", GetType(DateTime))
                .Add("idProducto", GetType(Guid))
                .Add("estado", GetType(String))
                .Add("idPosicion", GetType(Guid))
                .Add("temperatura", GetType(Integer))
                .Add("rx", GetType(Boolean))
                .Add("man", GetType(Boolean))
                .Add("k9", GetType(Boolean))
                .Add("eds", GetType(Boolean))
                .Add("largo", GetType(Integer))
                .Add("ancho", GetType(Integer))
                .Add("alto", GetType(Integer))
                .Add("tempA", GetType(Double))
                .Add("tempA_3_4", GetType(Double))
                .Add("tempB", GetType(Double))
                .Add("tempC", GetType(Double))
                .Add("tempZ_Flor", GetType(Double))
                .Add("tempZ_Pq", GetType(Double))
                .Add("idCamion", GetType(Guid))
                .Add("camionDescripcion", GetType(String))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
                .Add("estadoSenae", GetType(String))
                .Add("RegCargaCuartoFrio", GetType(String))
                .Add("UsusarioIngreso", GetType(String))
                .Add("nuSaca", GetType(String))
                .Add("selloSaca", GetType(String))
                .Add("inCourier", GetType(String))
            End With
            ugvCaptura.DataSource = dtDetalleProceso
            ugvCaptura.DataBind()
            ugvCaptura.DisplayLayout.Bands(0).SortedColumns.Add(ugvCaptura.DisplayLayout.Bands(0).Columns("hora"), True)



            With dtDetalleProcesoDev.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("dae", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("agenciaTransporteDescripcion", GetType(String))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Decimal))
                .Add("piezas", GetType(Integer))
                .Add("volumen", GetType(Double))
                .Add("hora", GetType(DateTime))
                .Add("idProducto", GetType(Guid))
                .Add("estado", GetType(String))
                .Add("idPosicion", GetType(Guid))
                .Add("temperatura", GetType(Integer))
                .Add("rx", GetType(Boolean))
                .Add("man", GetType(Boolean))
                .Add("k9", GetType(Boolean))
                .Add("eds", GetType(Boolean))
                .Add("largo", GetType(Integer))
                .Add("ancho", GetType(Integer))
                .Add("alto", GetType(Integer))
                .Add("tempA", GetType(Double))
                .Add("tempA_3_4", GetType(Double))
                .Add("tempB", GetType(Double))
                .Add("tempC", GetType(Double))
                .Add("tempZ_Flor", GetType(Double))
                .Add("tempZ_Pq", GetType(Double))
                .Add("idCamion", GetType(Guid))
                .Add("camionDescripcion", GetType(String))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
                .Add("estadoSenae", GetType(String))
                .Add("RegCargaCuartoFrio", GetType(String))
                .Add("UsusarioIngreso", GetType(String))
                .Add("nuSaca", GetType(String))
                .Add("selloSaca", GetType(String))
                .Add("inCourier", GetType(String))
            End With

            With dtdetalleProcesoTemp.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("dae", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Decimal))
                .Add("piezas", GetType(Integer))
                .Add("volumen", GetType(Double))
                .Add("hora", GetType(DateTime))
                .Add("idProducto", GetType(Guid))
                .Add("estado", GetType(String))
                .Add("idPosicion", GetType(Guid))
                .Add("temperatura", GetType(Integer))
                .Add("rx", GetType(Boolean))
                .Add("man", GetType(Boolean))
                .Add("k9", GetType(Boolean))
                .Add("eds", GetType(Boolean))
                .Add("largo", GetType(Integer))
                .Add("ancho", GetType(Integer))
                .Add("alto", GetType(Integer))
                .Add("tempA", GetType(Integer))
                .Add("tempA_3_4", GetType(Double))
                .Add("tempB", GetType(Double))
                .Add("tempC", GetType(Double))
                .Add("tempZ_Flor", GetType(Double))
                .Add("tempZ_Pq", GetType(Double))
                .Add("idCamion", GetType(Guid))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
                .Add("estadoSenae", GetType(String))
                .Add("RegCargaCuartoFrio", GetType(String))
                .Add("UsusarioIngreso", GetType(String))
                .Add("nuSaca", GetType(String))
                .Add("selloSaca", GetType(String))
                .Add("inCourier", GetType(String))

            End With
            btnDesactivB.Text = "Desactivar Balanza"
            btnDesactivB.Tag = "A"
            llenarUdd()
            usuarioRequiere = CommonData.GetContactoItem(MyCurrentUser.userName)
            txtTempA.Text = "0"
            txtTempA34.Text = "0"
            txtTempC.Text = "0"
            txtTempB.Text = "0"
            txtTempZF.Text = "0"
            txtTempZP.Text = "0"
            txtcodSello.Text = ""
            txtnumSaca.Text = ""

            txtcodSello.Enabled = False
            txtnumSaca.Enabled = False
            If My.Settings.LoginEmpr = 2 Then
                txtcodSello.Enabled = True
                txtnumSaca.Enabled = True
            End If



            With dtGuiaDaeRem.Columns
                .Add("IdGuia", GetType(Guid))
                .Add("Dae", GetType(String))
                .Add("NumRem", GetType(String))
                .Add("FechaVigencia", GetType(DateTime))
            End With

            With dtSellocamiones.Columns
                .Add("indice_sellos")
                .Add("Guia")
                .Add("Camion")
                .Add("Briefing")
                .Add("descripcionGuia")
                .Add("matriculaCamion")
                .Add("sello")
                .Add("descripcion")
            End With

            ugvSellos.DataSource = dtSellocamiones
            ugvSellos.DataBind()


        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub llenarUdd()
        Try
            Dim dtCargos As New DataTable("cargos")
            Dim dtActividad As New DataTable("actividad")
            dtCargos = CommonData.GetCargoCatalog
            dtActividad = CommonData.GetTipoAgencia
            uddCargos.DataSource = dtCargos
            uddActividad.DataSource = dtActividad
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub obtenerDatosHost()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        lblMuelle.Text = hostInfo.HostName.ToString
    End Sub

    Private Sub SetDisplayedColumnsPersonal()
        Try
            ugvPersonal.DisplayLayout.Bands(0).Columns("grupoPersonal").Hidden = True
            ugvPersonal.DisplayLayout.Bands(0).Columns("cantidadPersonal").Hidden = True
            ugvPersonal.DisplayLayout.Bands(0).Columns("cargoPersonal").Header.Caption = "Cargo"

            uddCargos.ValueMember = "descripcionCargo"
            uddCargos.DisplayMember = "descripcionCargo"
            uddCargos.DisplayLayout.Bands(0).Columns("idCargo").Hidden = True
            uddCargos.DisplayLayout.Bands(0).Columns("descripcionCargo").Header.Caption = "Descripción"
            uddCargos.DisplayLayout.Bands(0).Columns("descripcionCargo").Width = 300
            ugvPersonal.DisplayLayout.Bands(0).Columns("cargoPersonal").ValueList = uddCargos

            ugvPersonal.DisplayLayout.Bands(0).Columns("descripcionTipoAgencia").Header.Caption = "Compañia"

            uddActividad.ValueMember = "idTipo"
            uddActividad.DisplayMember = "descripcionTipo"
            uddActividad.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
            uddActividad.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Descripción"
            uddActividad.DisplayLayout.Bands(0).Columns("descripcionTipo").Width = 300
            ugvPersonal.DisplayLayout.Bands(0).Columns("descripcionTipoAgencia").ValueList = uddActividad

            ugvPersonal.DisplayLayout.Bands(0).Columns("tipoAgenciaRequerida").Hidden = True
            ugvPersonal.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvPersonal.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugvPersonal.DisplayLayout.Bands(0).Columns("contacto").Header.Caption = "Contacto"
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaEntrada").Header.Caption = "Hora Entrada"
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaEntrada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaSalida").Header.Caption = "Hora Salida"
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaEntrada").Format = "HH:mm:ss"
            ugvPersonal.DisplayLayout.Bands(0).Columns("horaSalida").Format = "HH:mm:ss"
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnConsLin_Click(sender As Object, e As EventArgs)
        Dim frmConsultaAgentes As New frmConsultaAgentes(Agencia2)
        frmConsultaAgentes.ShowDialog()
        If frmConsultaAgentes.Contacto.idContacto <> String.Empty Then
            tempContacto = frmConsultaAgentes.Contacto
        End If
    End Sub

    Private Sub RefreshUgvPers()
        ugvPersonal.Text = resDtVuelo.descripcion
        ugvPersonal.DataSource = dtMatriz
        SetDisplayedColumnsPersonal()
    End Sub

    Private Sub CargarUgvPers(grupo As Integer)
        Dim nr As DataRow
        Try
            For Each r As DataRow In dtTempMatriz.Rows
                For i As Integer = 1 To r.Item("cantidadPersonal")
                    With dtMatriz.Columns
                        nr = dtMatriz.NewRow
                        nr.Item("grupoPersonal") = grupo
                        nr.Item("cantidadPersonal") = 1
                        nr.Item("cargoPersonal") = r.Item("cargoPersonal")
                        nr.Item("tipoAgenciaRequerida") = r.Item("tipoAgenciaRequerida").ToString
                        nr.Item("descripcionTipoAgencia") = r.Item("descripcionTipo")
                        nr.Item("idContacto") = String.Empty
                        'nr.Item("contacto") = "edison"
                        'nr.Item("horaEntrada") = "2019/05/10" '''-----
                        'nr.Item("horaEntrada") = "2019/05/11" '''
                        dtMatriz.Rows.Add(nr)
                    End With
                Next
            Next
            RefreshUgvPers()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub utcTabs_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcTabs.SelectedTabChanged
        Dim isComplete As Boolean = True
        Dim existPersonal As Boolean = True
        Dim msg As String = String.Empty
        Dim cont As Integer = 0
        Try
            If utcTabs.SelectedTab Is utcTabs.Tabs.Item("PRO") Then
                If ugvPersonal.Rows.Count <> 0 Then
                    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvPersonal.Rows
                        If r.Cells("idContacto").Value.ToString = String.Empty Then
                            isComplete = False
                        End If
                    Next
                Else
                    isComplete = False
                End If
                If Not isComplete Then
                    MessageBox.Show("Debe Ingresar todo el Personal Requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    utcTabs.Tabs("PER").Selected = True
                    Exit Sub
                End If

                If ugvPersonal.Rows.Count <> 0 Then
                    Dim vista As New DataView(dtMatriz)
                    vista.Sort = "horaEntrada"
                    For Each r2 As DataRow In dtTempMatriz.Rows
                        Dim tmpMsg As String = String.Empty
                        Dim tmpCont As Integer = 0
                        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvPersonal.Rows
                            If r.Cells("idContacto").Value.ToString <> String.Empty Then
                                If r2.Item("cargoPersonal").ToString = r.Cells("cargoPersonal").Value Then
                                    If Not (r2.Item("cargoPersonal") = "CONTROL Y VIGILANCIA" Or r2.Item("cargoPersonal") = "RECEPCIONISTA DE CARGA") Then
                                        If r.Cells("horaSalida").Value.ToShortTimeString <> Date.Parse("00:00:00").ToShortTimeString Then
                                            existPersonal = False
                                            tmpMsg += vbLf & r.Cells("contacto").Value.ToString & ":  " & r.Cells("cargoPersonal").Value.ToString
                                            tmpCont += 1
                                        Else
                                            tmpMsg = String.Empty
                                            tmpCont = 0
                                        End If
                                    End If
                                End If
                            Else
                                existPersonal = False
                            End If
                        Next
                        msg += tmpMsg
                        cont += tmpCont
                    Next
                Else
                    existPersonal = False
                End If
                If Not existPersonal Then
                    If MessageBox.Show("Los siguientes Contactos no se encuentran en la Matriz de seguridad:" & vbLf & msg & vbLf & vbLf & "¿Desea Continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                        utcTabs.Tabs("PER").Selected = True
                        Exit Sub
                    End If
                End If
                CargarGuias()
                If utcTabs.Tabs("PRO").Selected Then
                    If uceCamiones.Items.Count < 1 Then
                        MessageBox.Show("La Guia seleccionada no se puede Procesar: Es necesario asignarle un Camión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        uceCamiones.Enabled = False
                        txtPeso.Enabled = False
                        txtLector.Enabled = False
                    Else
                        uceCamiones.Enabled = True
                        txtPeso.Enabled = True
                        txtLector.Enabled = True
                    End If
                    ObtenerProceso()
                    If bgwConsultaTemp.IsBusy = False Then
                        bgwConsultaTemp.RunWorkerAsync()
                    End If
                    'If bgwConsultaProceso.IsBusy = False Then
                    '    bgwConsultaProceso.RunWorkerAsync()
                    'End If
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvPersonal_AfterRowInsert(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles ugvPersonal.AfterRowInsert, UltraGrid1.AfterRowInsert
        Try

            ugvPersonal.ActiveRow.Cells("grupoPersonal").Value = 0
            ugvPersonal.ActiveRow.Cells("cantidadPersonal").Value = 1
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvPersonal_BeforeEnterEditMode(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ugvPersonal.BeforeEnterEditMode, UltraGrid1.BeforeEnterEditMode
        Try
            Dim contacto As String = ugvPersonal.ActiveRow.Cells("contacto").Value.ToString
            Dim cargo As String = ugvPersonal.ActiveRow.Cells("cargoPersonal").Value.ToString
            Dim agencia As String = ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value.ToString
            If contacto <> String.Empty Or (cargo <> String.Empty And agencia <> String.Empty) Then
                ugvPersonal.ActiveRow.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvPersonal_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvPersonal.DoubleClickCell, UltraGrid1.DoubleClickCell
        Try
            If e.Cell.Column Is ugvPersonal.DisplayLayout.Bands(0).Columns("contacto") Then
                If ugvPersonal.ActiveRow.Cells("cargoPersonal").Value.ToString <> String.Empty And ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value.ToString <> String.Empty Then
                    If isNewProceso Then
                        If ugvPersonal.ActiveRow.Cells("contacto").Value.ToString <> String.Empty And ugvPersonal.ActiveRow.Cells("grupoPersonal").Value = 0 Then
                            If MessageBox.Show("Está seguro que desea ingresar un nuevo Contacto para este Cargo", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        ElseIf ugvPersonal.ActiveRow.Cells("contacto").Value.ToString <> String.Empty And ugvPersonal.ActiveRow.Cells("grupoPersonal").Value = 1 Then
                            Exit Sub
                        End If
                        Dim idTipoAgencia As String
                        If ugvPersonal.ActiveRow.Cells("tipoAgenciaRequerida").Value.ToString = String.Empty Then
                            idTipoAgencia = ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value.ToString
                        Else
                            idTipoAgencia = ugvPersonal.ActiveRow.Cells("tipoAgenciaRequerida").Value.ToString()
                        End If
                        Dim frmConsultaAgentes As New frmConsultaAgentes(idTipoAgencia)
                        Dim frmConsultaEmpleados As New frmConsultaEmpleados()
                        If idTipoAgencia = idTipoGeneral Then
                            frmConsultaEmpleados.ShowDialog()
                            If frmConsultaEmpleados.Contacto.idContacto <> String.Empty Then
                                tempContacto = frmConsultaEmpleados.Contacto
                            Else
                                Exit Sub
                            End If
                        Else
                            frmConsultaAgentes.ShowDialog()
                            If frmConsultaAgentes.Contacto.idContacto <> String.Empty Then
                                tempContacto = frmConsultaAgentes.Contacto
                            Else
                                Exit Sub
                            End If
                        End If
                        llenarDtPersoanl()
                    End If
                End If
            End If
            If e.Cell.Column Is ugvPersonal.DisplayLayout.Bands(0).Columns("horaSalida") Then
                If Not ugvPersonal.ActiveRow.Cells("contacto").Value.ToString = String.Empty Then
                    If Not ugvPersonal.ActiveRow.Cells("horaSalida").Value.ToShortTimeString <> Date.Parse("00:00:00").ToShortTimeString Then
                        llenarHoraSalida()
                    Else
                        MessageBox.Show("Ya existe una hora de salida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Primero debe ingresar la Persona Requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub agregarNuevoContacto()
        Dim r As DataRow
        Try
            r = dtMatriz.NewRow
            r.Item("grupoPersonal") = 0
            r.Item("cantidadPersonal") = ugvPersonal.ActiveRow.Cells("cantidadPersonal").Value
            r.Item("cargoPersonal") = ugvPersonal.ActiveRow.Cells("cargoPersonal").Value
            r.Item("tipoAgenciaRequerida") = ugvPersonal.ActiveRow.Cells("tipoAgenciaRequerida").Value
            r.Item("descripcionTipoAgencia") = ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value
            r.Item("idAgencia") = ugvPersonal.ActiveRow.Cells("idAgencia").Value
            r.Item("idContacto") = ugvPersonal.ActiveRow.Cells("idContacto").Value
            r.Item("contacto") = ugvPersonal.ActiveRow.Cells("contacto").Value
            r.Item("horaEntrada") = DateTime.Now
            r.Item("horaSalida") = Date.Parse("00:00:00")
            dtMatriz.Rows.Add(r)
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub llenarHoraSalida()
        Try

            If MessageBox.Show("Desea Marcar " + TimeOfDay + " como hora de Salida", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If ugvPersonal.ActiveRow.Cells("horaEntrada").Value > DateTime.Now Then
                    MessageBox.Show("La hora de salida NO PUEDE ser menor a la de entrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ugvPersonal.ActiveRow.Cells("horaSalida").Value = DateTime.Now
                myPersonalProceso.horaFin = ugvPersonal.ActiveRow.Cells("horaSalida").Value
                If MessageBox.Show("¿Desea ingresar un Nuevo Contacto para este cargo?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    agregarNuevoContacto()
                End If
                SavePersonalProceso()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Function DeletePersonalProceso() As Boolean
        Dim result = False
        Dim req As New PersonalProcesoRequest
        Dim res As New PersonalProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            myPersonalProceso.idProceso = myProceso.IdProceso
            req.myPersonalProcesoItem = myPersonalProceso
            res = WsClnt.DeletePersonalProceso(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function DeleteDetalleProceso() As Boolean
        Dim result = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myDetalleProcesoItem = myDetalleProceso
            req.UserId = IdUsuario
            res = WsClnt.DeleteDetalleProcesoPorIndice(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub SavePersonalProceso()
        Dim req As New PersonalProcesoRequest
        Dim res As New PersonalProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            If DeletePersonalProceso() Then
                General.SetBARequest(req)
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvPersonal.Rows
                    If Not r.Cells("contacto").Value.ToString = String.Empty Then
                        myPersonalProceso.idProceso = myProceso.IdProceso
                        myPersonalProceso.idMatrizSeg = resDtVuelo.idMatriz
                        myPersonalProceso.horaInicio = r.Cells("horaEntrada").Value
                        myPersonalProceso.horaFin = r.Cells("horaSalida").Value
                        myPersonalProceso.idAgencia = r.Cells("idAgencia").Value
                        myPersonalProceso.idPersona = r.Cells("idContacto").Value
                        myPersonalProceso.cargo = r.Cells("cargoPersonal").Value
                        myPersonalProceso.grupoProceso = r.Cells("grupoPersonal").Value
                        myPersonalProceso.muelle = lblMuelle.Text
                        req.myPersonalProcesoItem = myPersonalProceso
                        res = WsClnt.SavePersonalProcesoItem(req)
                    End If
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function validaPeso(ByVal bultos As Integer) As Boolean
        Dim peso As Decimal = 0D
        Dim bult As Integer = 0
        Dim resp As DialogResult = Windows.Forms.DialogResult.Yes
        Dim showSeg As Boolean = False
        Dim strMsg As String = String.Empty
        Try

            For i As Integer = 0 To ugvTotalGuias.Rows.Count - 1
                If ugvTotalGuias.Rows(i).Cells("guia").Value = uceGuias.Text Then
                    peso = ugvTotalGuias.Rows(i).Cells("pesoReal").Value
                    bult = ugvTotalGuias.Rows(i).Cells("totalBultos").Value
                    Exit For
                End If
            Next
            Dim tmp1 As Decimal = 0D
            Dim tmp2 As Decimal = 0D
            tmp1 = Decimal.Parse(txtPeso.Text)
            tmp2 = Decimal.Parse(txtTPesoGuia.Text)
            If peso + Decimal.Parse(txtPeso.Text) > Decimal.Parse(txtTPesoGuia.Text) Then
                showSeg = True
                resp = MessageBox.Show("Va a Ingresar mas peso del Reservado", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                strMsg = "Peso: " & txtTPesoGuia.Text & "  a: " & (peso + Decimal.Parse(txtPeso.Text)).ToString
            Else
                If bult + Integer.Parse(bultos) > Integer.Parse(txtTBultosGuia.Text) Then
                    showSeg = True
                    resp = MessageBox.Show("Va a Ingresar mas Bultos de los Reservados", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    strMsg = "# Bultos: " & txtTBultosGuia.Text & "  a: " & (bult + Integer.Parse(bultos)).ToString
                End If
            End If
            If resp = Windows.Forms.DialogResult.No Then
                Return False
                Exit Function
            End If
            If resp = Windows.Forms.DialogResult.Yes And showSeg Then
                Dim frmCheck As New frmCheckUserManager
                frmCheck.ShowDialog()
                If Not frmCheck.result Then
                    Return False
                    Exit Function
                End If
                Dim usuarioPermiso As New Server.ReportService.ContactoCatalogItem
                usuarioPermiso = CommonData.GetContactoItem(frmCheck.tempUserManager.userName)
                If usuarioPermiso.idContacto = usuarioRequiere.idContacto Then
                    MessageBox.Show("El usuario no puede autorizarse a sí mismo.", "Error en Autorización", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                    Exit Function
                End If

                Task.Run(Async Function()
                             Await EnviarReporteCheckUserManager("Ingresar mas peso/piezas del Reservado", strMsg, usuarioPermiso, usuarioRequiere)
                         End Function)
                'EnviarReporteCheckUserManager("Ingresar mas peso/piezas del Reservado", strMsg, usuarioPermiso, usuarioRequiere) ' ewlm PRUEBAS
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
        Return True
    End Function

    Private Function ValidaPeso() As Boolean
        Dim tempera As Integer
        Try

            If Double.Parse(txtPeso.Text) <= 0 Then
                MsgBox("Ingrese el Peso")
                Return False
                Exit Function
            End If
            If uceElementos.Text = String.Empty Or uceElementos.Text = "Escoja una opción" Then
                MsgBox("Escoja un Elemento")
                Return False
                Exit Function
            End If
            If Integer.TryParse(txtTemp.Text, tempera) = False Then
                MsgBox("Ingrese la Temperatura")
                Return False
                Exit Function
            End If

            If My.Settings.LoginEmpr = 2 Then
                If txtnumSaca.Text = String.Empty Then
                    MsgBox("Ingrese el numero de saca")
                    Return False
                    Exit Function
                End If
                If txtcodSello.Text = String.Empty Then
                    MsgBox("Ingrese el código de Sello")
                    Return False
                    Exit Function
                End If
            End If


        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
        Return True
    End Function

    Private Sub txtAlto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlto.KeyPress
        Dim funcion As New CommonProcess
        funcion.NumeroDec(e, txtAlto)
    End Sub

    Private Sub txtAncho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAncho.KeyPress
        Dim funcion As New CommonProcess
        funcion.NumeroDec(e, txtAncho)
    End Sub

    Private Sub txtLargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLargo.KeyPress
        Dim funcion As New CommonProcess
        funcion.NumeroDec(e, txtLargo)
    End Sub

    Private Sub txtVolumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVolumen.KeyDown
        Dim bultos As Integer = 0
        Dim piezas As Integer
        Dim val As Double
        Dim alto, ancho, largo As Double
        Try
            alto = Double.Parse(txtAlto.Text)
            ancho = Double.Parse(txtAncho.Text)
            largo = Double.Parse(txtLargo.Text)

            If ChkVol.Checked Then
                If alto = 0 Or ancho = 0 Or largo = 0 Then
                    MessageBox.Show("Faltan Dimensiones para Calcular el Volumen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            If txtPeso.Text = String.Empty Then
                txtPeso.Text = "0.00"
                Exit Sub
            End If
            If txtVolumen.Text = String.Empty Then
                txtVolumen.Text = "0.00"
                Exit Sub
            End If
            If Not Double.TryParse(txtPeso.Text, val) Then
                MsgBox("Formato  Invalido")
                txtPeso.Text = "0.00"
            End If
            If Not Double.TryParse(txtVolumen.Text, val) Then
                MsgBox("Formato  Invalido")
                txtVolumen.Text = "0.00"
            End If

            Select Case e.KeyValue
                Case Keys.F1
                    piezas = 1
                Case Keys.Return
                    piezas = 1
                Case Keys.F2
                    piezas = 2
                Case Keys.F3
                    piezas = 3
                Case Keys.F4
                    piezas = 4
                Case Keys.F5
                    piezas = 5
                Case Keys.F6
                    piezas = 6
                Case Keys.F7
                    piezas = 7
                Case Keys.F8
                    piezas = 8
                Case Keys.F9
                    piezas = 9
                Case Keys.F10
                    piezas = 10
                Case Keys.F11
                    piezas = 11
                Case Keys.F12
                    Dim strPiezas As String = String.Empty
                    Do Until IsNumeric(strPiezas)
                        strPiezas = InputBox("Ingrese la cantidad de piezas", "Piezas")
                    Loop
                    piezas = strPiezas
                    'piezas = 12
            End Select
            If piezas > 0 Then
                If Double.Parse(txtPeso.Text) > 0 Then
                    If Integer.Parse(1) > 0 Then
                        bultos = Integer.Parse(1)
                    Else
                        bultos = 1
                    End If
                    SaveCaptura(bultos, piezas)
                End If
            End If
            CalcularTotales()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlargo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLargo.TextChanged
        CalculaPesoVolumen()
    End Sub

    Private Sub txtalto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlto.TextChanged
        CalculaPesoVolumen()
    End Sub

    Private Sub txtancho_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAncho.TextChanged
        CalculaPesoVolumen()
    End Sub

    Private Sub CalculaPesoVolumen()
        Dim alto As Double
        Dim ancho As Double
        Dim largo As Double
        Try

            alto = IIf(txtAlto.Text <> "", txtAlto.Text, 0)
            ancho = IIf(txtAncho.Text <> "", txtAncho.Text, 0)
            largo = IIf(txtLargo.Text <> "", txtLargo.Text, 0)


            txtVolumen.Text = Format((Double.Parse((alto * ancho * largo) / 6000)), "#0.00")
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SaveCaptura(ByVal bultos As Integer, ByVal piezas As Integer)
        Try
            Dim val As Double = 0D
            If Double.TryParse(txtPeso.Text, val) Then
                If Double.Parse(txtPeso.Text) > 0 Then
                    If Integer.Parse(1) > 0 Then
                        bultos = Integer.Parse(1)
                    Else
                        bultos = 1
                    End If
                    If ValidaPeso() Then
                        If Not validaPeso(bultos) Then Exit Sub
                        InfoPesajeToObject(bultos, piezas)
                        If IsNothing(myDetalleProceso.idProducto) Then
                            MessageBox.Show("Seleccione nuevamente el producto", "Comunique a Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        If validaDaeObject() Then
                            EscribirLineaLog(myDetalleProceso.Guia.ToString + "; " + myDetalleProceso.dae.ToString + "; " + myDetalleProceso.hora.ToString + "; " + txtLector.Text + Chr(13), PathLog)
                            If Not SaveDetalleProceso() Then
                                MessageBox.Show("Error en Ingreso de Pesaje", "Comunique a Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                If Not ChkVol.Checked Then
                                    txtVolumen.Text = "0.00"
                                End If
                            End If
                        Else
                            If MessageBox.Show("El número de Dae de la Pieza no coincide con el de la Guia, ¿desea continuar?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                txtPeso.Text = 0
                txtnumSaca.Text = ""
                txtcodSello.Text = ""

            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Public Sub CrearArchivoLog(text As String, ByRef pathLog As String)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogsCapture") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogsCapture")
        End If
        'If Not FileIO.FileSystem.DirectoryExists("C:\LogsCapture\") Then
        '    FileIO.FileSystem.CreateDirectory("C:\LogsCapture\")
        'End If
        ' Set a variable to the My Documents path.
        'Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim mydocpath As String = rutaejecutable & "\LogsCapture" '"C:\LogsCapture"
        ' Write the text asynchronously to a new file named "WriteTextAsync.txt".
        pathLog = mydocpath & Convert.ToString("\" + Date.Now + ".txt").Replace("/", "").Replace(":", "")
        Using sw As StreamWriter = File.CreateText(pathLog)
            sw.WriteLine(text)
        End Using
    End Sub
    Public Sub CrearArchivoLogBitacora(text As String)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogsCapture") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogsCapture")
        End If
        'If Not FileIO.FileSystem.DirectoryExists("C:\LogsCapture\") Then
        '    FileIO.FileSystem.CreateDirectory("C:\LogsCapture\")
        'End If
        ' Set a variable to the My Documents path.
        'Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim mydocpath As String = rutaejecutable & "\LogsCapture" '"C:\LogsCapture"
        ' Write the text asynchronously to a new file named "WriteTextAsync.txt".
        PathLogBita = mydocpath & Convert.ToString("\BitacoraLog" + Date.Now + ".txt").Replace("/", "").Replace(":", "")
        Using sw As StreamWriter = File.CreateText(PathLogBita)
            sw.WriteLine(text)
        End Using
    End Sub
    Public Sub EscribirLineaLog(text As String, ByRef pathLog As String)
        ' Set a variable to the My Documents path.
        ' Write the text asynchronously to a new file named "WriteTextAsync.txt".
        IO.File.AppendAllText(pathLog, text)
        'Using sw As StreamWriter = File.AppendText(pathLog)
        '    sw.WriteLine(text)
        'End Using
    End Sub

    Private Function validaDaeObject() As Boolean
        Try
            For Each r In uceDaes.Items
                If r.DisplayText.Trim = myDetalleProceso.dae Then
                    Return True
                    Exit Function
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function saveDocSenae(ByVal detalleProceso As DetalleProcesoItem, Optional ByRef SenaeDocId As String = "") As Boolean
        Dim resultFunction As Boolean = False
        Dim valueEnvioSenae As Boolean = True
        If valueEnvioSenae Then
            For Each r As DataRow In dtGuias.Rows
                If r.Item("idGuia") = detalleProceso.idGuia Then
                    Dim resultMosEstadoSenae As Boolean = False
                    Dim myDocSenae As New DocSenae
                    Dim req As New ProcesoRequest
                    Dim res As New ProcesoResponse
                    Dim WsClnt As New ProcesoServiceSoapClient
                    Dim docId As String = String.Empty
                    Dim producto As String = String.Empty
                    Dim secuencial As Integer = 0
                    Dim tempDae As String = String.Empty
                    Try
                        General.SetBARequest(req)
                        myDocSenae.Id = Guid.NewGuid
                        tempDae = detalleProceso.dae
                        If tempDae <> String.Empty Then
                            myDocSenae.numeroDae = tempDae
                        Else
                            MessageBox.Show("Error: Número de DAE vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            General.SetLogEvent("Error: Número de DAE vacio (Func saveDocSenae)")
                            Return resultFunction
                            Exit Function
                        End If
                        myDocSenae.idProducto = detalleProceso.idProducto
                        myDocSenae.peso = detalleProceso.peso
                        myDocSenae.piezas = detalleProceso.piezas
                        myDocSenae.idProceso = myProceso.IdProceso
                        myDocSenae.idGuia = detalleProceso.idGuia
                        myDocSenae.estado = "Enviado Sin Respuesta"
                        myDocSenae.fecha = Date.Today
                        myDocSenae.NumRem = detalleProceso.NumRem
                        producto = CommonData.GetProductoItem(detalleProceso.idProducto).DescripcionProducto
                        If producto.Length > 200 Then
                            producto = producto.Substring(0, 200)
                        End If
                        If myDocSenae.peso <= 0 Or myDocSenae.piezas <= 0 Then
                            Return resultFunction
                            Exit Function
                        End If
                        secuencial = CommonProcess.GetNextSecuencialSenae()
                        If rbtDec.Checked Or rbtDev.Checked Then
                            docId = SendIIEDoc(myDocSenae.numeroDae, myDocSenae.piezas, myDocSenae.peso, producto, secuencial, False, myDocSenae.NumRem)
                        Else
                            'producto = " 98.06 - MUESTRAS SIN VALOR COMERCIAL, EXCEPTO LAS QUE INGRESEN POR TRAFICO POSTAL INTERNACIONAL Y CORREOS RAPIDOS  "
                            docId = SendIIEDoc(myDocSenae.numeroDae, myDocSenae.piezas, myDocSenae.peso, producto, secuencial, True, myDocSenae.NumRem)
                        End If

                        Try
                            myDocSenae.docId = docId.Substring(0, 21)
                            req.myDocSenae = myDocSenae
                            res = WsClnt.SaveDocSenae(req)
                        Catch ex As Exception
                            myDocSenae.docId = "ERROR DE ENVIO"
                        End Try
                        If res.ActionResult Then
                            r.Item("enviadoSenae") = True
                            detalleProceso.estadoSenae = myDocSenae.docId
                            'tempDocId = myDocSenae.docId
                            SenaeDocId = myDocSenae.docId
                            resultMosEstadoSenae = CommonProcess.ModificarEstadoSenaeDetalleProcesoCarga(detalleProceso)
                            resultFunction = True
                            IndiceEstadoSenae.estadoSenae = detalleProceso.estadoSenae
                            IndiceEstadoSenae.indice = detalleProceso.indice
                        Else
                            Throw New Exception(res.ErrorMessage)
                        End If
                    Catch ex As Exception
                        General.SetLogEvent(ex)
                    End Try
                End If
            Next
        End If
        Return resultFunction
    End Function

    Private Sub ObtenerProceso()
        Dim dt As New DataTable
        Dim nr As DataRow
        Try
            dtCaptura.Rows.Clear()
            dtDetalleProceso.Rows.Clear()
            With myProceso
                .idAvion = resDtVuelo.idAvion
                .idBriefing = resDtVuelo.idBriefing
            End With
            dt = CommonProcess.GetDetalleProcesoPorIdProcesoCaptura(myProceso.IdProceso)
            myProceso = CommonProcess.GetProcesoPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In dt.Rows
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = r.Item("idProceso")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
                nr.Item("dae") = r.Item("dae")
                nr.Item("idElemento") = r.Item("idElemento")
                nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                nr.Item("agenciaTransporteDescripcion") = r.Item("agenciaTransporteDescripcion")
                nr.Item("bultos") = r.Item("bultos")
                nr.Item("peso") = r.Item("peso")
                Dim t As Decimal = 0D
                t = r.Item("peso")
                nr.Item("piezas") = r.Item("piezas")
                nr.Item("volumen") = r.Item("volumen")
                nr.Item("hora") = r.Item("hora")
                nr.Item("idProducto") = r.Item("idProducto")
                nr.Item("estado") = r.Item("estado")
                nr.Item("idPosicion") = r.Item("idPosicion")
                nr.Item("temperatura") = r.Item("temperatura")
                nr.Item("rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("largo") = r.Item("largo")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("alto") = r.Item("alto")
                nr.Item("tempA") = r.Item("tempA")
                nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                nr.Item("tempB") = r.Item("tempB")
                nr.Item("tempC") = r.Item("tempC")
                nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                nr.Item("idCamion") = r.Item("idCamion")
                nr.Item("camionDescripcion") = r.Item("camionDescripcion")
                nr.Item("muelle") = r.Item("muelle")
                nr.Item("indice") = r.Item("indice")
                nr.Item("estadoSenae") = r.Item("estadoSenae")
                nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")
                nr.Item("nuSaca") = r.Item("nuSaca")
                nr.Item("sellosaca") = r.Item("codsello")
                nr.Item("incourier") = r.Item("incourier")



                dtDetalleProceso.Rows.Add(nr)
            Next
            If Not IsNothing(dtDetalleProceso) And dtDetalleProceso.Rows.Count > 0 Then
                'ugvCaptura.DataSource = dtDetalleProceso
                ugvCaptura.DataBind()
                ugvCaptura.Refresh()
                SetDisplayedColumnsCaptura()
            End If
            isFullDetalleCapturaInGrid = False
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Proceso que se utiliza para actulizar el DataTable que refresca el UltraGrid de ugvCaptura
    'Este se actuliza cuando se ingresa un nuevo registro o cuando se actulizan los man, k9, eds
    Public Sub CargarDatosGrid()
        Try
            Dim DetalleProceso As Object()
            Dim nr As DataRow
            If LsBandeAct = "S" Then 'JRO 01022018
                With myDetalleProceso
                    DetalleProceso = New Object() { .IdDetalleProceso, .fecha, .idGuia, .Guia, .dae, .idElemento, .agenciaTransporte, uceAgencia.Text,
                                                    .bultos, .peso, .piezas, .volumen, .hora, .idProducto, .estado, .idPosicion, .temperatura, .rx,
                                                    .man, .k9, .eds, .largo, .ancho, .alto, .tempA, .tempB, .tempC, .idCamion, uceCamiones.Text, .muelle, .indice,
                                                    .estadoSenae, .tempA_3_4, .tempZ_Flor, .tempZ_Pq, .RegCargaCuartoFrio, .UsusarioIngreso, .nuSaca, .codsello, .incourier}
                End With
                dtDetalleProceso.Rows.Item(LnIndexAct).Delete()
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = DetalleProceso(0)
                nr.Item("fecha") = DetalleProceso(1)
                nr.Item("idGuia") = DetalleProceso(2)
                nr.Item("guia") = DetalleProceso(3)
                nr.Item("dae") = DetalleProceso(4)
                nr.Item("idElemento") = DetalleProceso(5)
                nr.Item("agenciaTransporte") = DetalleProceso(6)
                nr.Item("agenciaTransporteDescripcion") = DetalleProceso(7)
                nr.Item("bultos") = DetalleProceso(8)
                nr.Item("peso") = DetalleProceso(9)
                nr.Item("piezas") = DetalleProceso(10)
                nr.Item("volumen") = DetalleProceso(11)
                nr.Item("hora") = DetalleProceso(12)
                nr.Item("idProducto") = DetalleProceso(13)
                nr.Item("estado") = DetalleProceso(14)
                nr.Item("idPosicion") = DetalleProceso(15)
                nr.Item("temperatura") = DetalleProceso(16)
                nr.Item("rx") = DetalleProceso(17)
                nr.Item("man") = DetalleProceso(18)
                nr.Item("k9") = DetalleProceso(19)
                nr.Item("eds") = DetalleProceso(20)
                nr.Item("largo") = DetalleProceso(21)
                nr.Item("ancho") = DetalleProceso(22)
                nr.Item("alto") = DetalleProceso(23)
                nr.Item("tempA") = DetalleProceso(24)
                nr.Item("tempB") = DetalleProceso(25)
                nr.Item("tempC") = DetalleProceso(26)
                nr.Item("idCamion") = DetalleProceso(27)
                nr.Item("camionDescripcion") = DetalleProceso(28)
                nr.Item("muelle") = DetalleProceso(29)
                nr.Item("indice") = DetalleProceso(30)
                nr.Item("estadoSenae") = DetalleProceso(31)
                LsBandeAct = "N"
                nr.Item("tempA_3_4") = DetalleProceso(32)
                nr.Item("tempZ_Flor") = DetalleProceso(33)
                nr.Item("tempZ_Pq") = DetalleProceso(34)
                nr.Item("RegCargaCuartoFrio") = DetalleProceso(35)
                nr.Item("UsusarioIngreso") = DetalleProceso(36)
                nr.Item("nuSaca") = DetalleProceso(37)
                nr.Item("sellosaca") = DetalleProceso(38)
                nr.Item("incourier") = DetalleProceso(39)


            Else
                With myDetalleProceso
                    DetalleProceso = New Object() { .IdDetalleProceso, .fecha, .idGuia, .Guia, .dae, .idElemento, .agenciaTransporte,
                                                   .bultos, .peso, .piezas, .volumen, .hora, .idProducto, .estado,
                                                   .idPosicion, .temperatura, .rx, .man, .k9, .eds, .largo, .ancho, .alto,
                                                   .tempA, .tempB, .tempC, .idCamion, .muelle, .indice, .tempA_3_4, .tempZ_Flor, .tempZ_Pq, .RegCargaCuartoFrio, .UsusarioIngreso, .nuSaca, .codsello, .incourier}
                End With
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = DetalleProceso(0)
                nr.Item("fecha") = DetalleProceso(1)
                nr.Item("idGuia") = DetalleProceso(2)
                nr.Item("guia") = DetalleProceso(3)
                nr.Item("dae") = DetalleProceso(4)
                nr.Item("idElemento") = DetalleProceso(5)
                nr.Item("agenciaTransporte") = DetalleProceso(6)
                nr.Item("agenciaTransporteDescripcion") = uceAgencia.Text
                nr.Item("bultos") = DetalleProceso(7)
                nr.Item("peso") = DetalleProceso(8)
                Dim t As Decimal = 0D
                t = DetalleProceso(8)
                nr.Item("piezas") = DetalleProceso(9)
                nr.Item("volumen") = DetalleProceso(10)
                nr.Item("hora") = DetalleProceso(11)
                nr.Item("idProducto") = DetalleProceso(12)
                nr.Item("estado") = DetalleProceso(13)
                nr.Item("idPosicion") = DetalleProceso(14)
                nr.Item("temperatura") = DetalleProceso(15)
                nr.Item("rx") = DetalleProceso(16)
                nr.Item("man") = DetalleProceso(17)
                nr.Item("k9") = DetalleProceso(18)
                nr.Item("eds") = DetalleProceso(19)
                nr.Item("largo") = DetalleProceso(20)
                nr.Item("ancho") = DetalleProceso(21)
                nr.Item("alto") = DetalleProceso(22)
                nr.Item("tempA") = DetalleProceso(23)
                nr.Item("tempB") = DetalleProceso(24)
                nr.Item("tempC") = DetalleProceso(25)
                nr.Item("idCamion") = DetalleProceso(26)
                nr.Item("camionDescripcion") = uceCamiones.Text
                nr.Item("muelle") = DetalleProceso(27)
                nr.Item("indice") = DetalleProceso(28)
                If IndiceEstadoSenae.indice = DetalleProceso(28) Then
                    nr.Item("estadoSenae") = IndiceEstadoSenae.estadoSenae
                End If
                nr.Item("tempA_3_4") = DetalleProceso(29)
                nr.Item("tempZ_Flor") = DetalleProceso(30)
                nr.Item("tempZ_Pq") = DetalleProceso(31)
                nr.Item("RegCargaCuartoFrio") = DetalleProceso(32)
                nr.Item("UsusarioIngreso") = DetalleProceso(33)

                nr.Item("nuSaca") = DetalleProceso(34)
                nr.Item("sellosaca") = DetalleProceso(35)
                nr.Item("incourier") = DetalleProceso(36)

            End If
            myDetalleProceso.indice = Guid.Empty
            dtDetalleProceso.Rows.Add(nr)
            ugvCaptura.DataBind()
            ugvCaptura.Refresh()
            ugvCaptura.DisplayLayout.Bands(0).SortedColumns.Add(ugvCaptura.DisplayLayout.Bands(0).Columns("hora"), True)
        Catch ex As Exception
            EscribirLineaLog(ex.Message.ToString & vbCrLf, PathLogBita)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerProceso2()
        Dim dtDetalle As New DataTable
        Dim nr As DataRow
        Try
            dtCaptura.Rows.Clear()
            dtDetalleProceso.Rows.Clear()
            With myProceso
                .idAvion = resDtVuelo.idAvion
                .idBriefing = resDtVuelo.idBriefing
            End With
            dtDetalle = CommonProcess.GetDetalleProcesoPorIdProceso(myProceso.IdProceso)
            myProceso = CommonProcess.GetProcesoPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In dtDetalle.Rows
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = r.Item("idProceso")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
                nr.Item("dae") = r.Item("dae")
                nr.Item("idElemento") = r.Item("idElemento")
                nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                nr.Item("agenciaTransporteDescripcion") = r.Item("agenciaTransporteDescripcion")
                nr.Item("bultos") = r.Item("bultos")
                nr.Item("peso") = r.Item("peso")
                'Dim t As Decimal = 0D
                't = r.Item("peso")
                nr.Item("piezas") = r.Item("piezas")
                nr.Item("volumen") = r.Item("volumen")
                nr.Item("hora") = r.Item("hora")
                nr.Item("idProducto") = r.Item("idProducto")
                nr.Item("estado") = r.Item("estado")
                nr.Item("idPosicion") = r.Item("idPosicion")
                nr.Item("temperatura") = r.Item("temperatura")
                nr.Item("rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("largo") = r.Item("largo")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("alto") = r.Item("alto")
                nr.Item("tempA") = r.Item("tempA")
                nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                nr.Item("tempB") = r.Item("tempB")
                nr.Item("tempC") = r.Item("tempC")
                nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                nr.Item("idCamion") = r.Item("idCamion")
                nr.Item("camionDescripcion") = r.Item("camionDescripcion")
                nr.Item("muelle") = r.Item("muelle")
                nr.Item("indice") = r.Item("indice")
                nr.Item("estadoSenae") = r.Item("estadoSenae")
                nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")

                nr.Item("nuSaca") = r.Item("nuSaca")
                nr.Item("sellosaca") = r.Item("codsello")
                nr.Item("incourier") = r.Item("incourier")


                dtDetalleProceso.Rows.Add(nr)
            Next
            If Not IsNothing(dtDetalleProceso) And dtDetalleProceso.Rows.Count > 0 Then
                ugvCaptura.DataSource = dtDetalleProceso
                SetDisplayedColumnsCaptura()
                isFullDetalleCapturaInGrid = True
                MessageBox.Show("Detalles de Captura recuperados con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerProcesoDev()
        Dim dtdev As New DataTable
        Dim nr As DataRow
        Try
            dtCapturaDev.Rows.Clear()
            dtDetalleProcesoDev.Rows.Clear()
            With myProceso
                .idAvion = resDtVuelo.idAvion
                .idBriefing = resDtVuelo.idBriefing
            End With
            dtdev = CommonProcess.GetDetalleProcesoPorIdProcesoDev(myProceso.IdProceso)
            myProceso = CommonProcess.GetProcesoPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In dtdev.Rows
                nr = dtDetalleProcesoDev.NewRow
                nr.Item("idProceso") = r.Item("idProceso")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
                nr.Item("dae") = r.Item("dae")
                nr.Item("idElemento") = r.Item("idElemento")
                nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                nr.Item("agenciaTransporteDescripcion") = r.Item("agenciaTransporteDescripcion")
                nr.Item("bultos") = r.Item("bultos")
                nr.Item("peso") = r.Item("peso")
                Dim t As Decimal = 0D
                t = r.Item("peso")
                nr.Item("piezas") = r.Item("piezas")
                nr.Item("volumen") = r.Item("volumen")
                nr.Item("hora") = r.Item("hora")
                nr.Item("idProducto") = r.Item("idProducto")
                nr.Item("estado") = r.Item("estado")
                nr.Item("idPosicion") = r.Item("idPosicion")
                nr.Item("temperatura") = r.Item("temperatura")
                nr.Item("rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("largo") = r.Item("largo")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("alto") = r.Item("alto")
                nr.Item("tempA") = r.Item("tempA")
                nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                nr.Item("tempB") = r.Item("tempB")
                nr.Item("tempC") = r.Item("tempC")
                nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                nr.Item("idCamion") = r.Item("idCamion")
                nr.Item("camionDescripcion") = r.Item("camionDescripcion")
                nr.Item("muelle") = r.Item("muelle")
                nr.Item("indice") = r.Item("indice")
                nr.Item("estadoSenae") = r.Item("estadoSenae")
                nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")

                nr.Item("nuSaca") = r.Item("nuSaca")
                nr.Item("sellosaca") = r.Item("codsello")
                nr.Item("incourier") = r.Item("incourier")

                dtDetalleProcesoDev.Rows.Add(nr)
            Next
            'If Not IsNothing(dtDetalleProceso) And dtDetalleProceso.Rows.Count > 0 Then
            '    ugvCaptura.DataSource = dtDetalleProceso
            '    SetDisplayedColumnsCaptura()
            '    isFullDetalleCapturaInGrid = True
            '    MessageBox.Show("Detalles de Captura recuperados con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InfoPesajeToObject(ByVal bultos As Integer, ByVal piezas As Integer)
        Try
            If IsNothing(myProceso) Then myProceso = New ProcesoItem
            With myDetalleProceso
                udtUltimo.Value = Date.Now

                Dim tempera As Integer = 0
                If procesoExist Then
                    .IdDetalleProceso = myProceso.IdProceso
                Else
                    .IdDetalleProceso = idProceso
                End If
                .idGuia = uceGuias.Value
                .Guia = uceGuias.Text
                If txtLector.Text.Trim = String.Empty Then
                    .dae = uceDaes.Text.Trim
                Else
                    .dae = txtLector.Text.Trim
                End If
                myProceso.idAvion = resDtVuelo.idBriefing
                .idElemento = uceElementos.Text
                .agenciaTransporte = uceAgencia.Value
                .bultos = bultos
                .piezas = piezas
                .peso = txtPeso.Text
                .volumen = txtVolumen.Text * piezas
                .fecha = Date.Now
                .hora = Date.Now
                .idProducto = uceProducto.Value
                'ESTADOS DEL PROCESO
                'A = ACTIVO
                'C = CONFISCATION
                'D = DEVUELTO
                'I = QUEDADA
                'R = REENVIADA
                'E = ELIMINADA
                If rbtRecep.Checked Then
                    .estado = "A"
                ElseIf rbtDev.Checked Then
                    .estado = "D"
                ElseIf rbtDec.Checked Then
                    .estado = "C"
                Else
                    .estado = "A"
                End If
                .temperatura = Integer.Parse(txtTemp.Text)
                .rx = IIf(chkRx.Checked, 1, 0)
                .man = IIf(chkMan.Checked, 1, 0)
                .k9 = IIf(chkK9.Checked, 1, 0)
                .eds = IIf(chkEds.Checked, 1, 0)
                .alto = txtAlto.Text
                .ancho = txtAncho.Text
                .largo = txtLargo.Text
                .tempA = IIf(txtTempA.Text = "", "0", txtTempA.Text.Replace(",", "."))
                .tempA_3_4 = IIf(txtTempA34.Text = "", "0", txtTempA34.Text.Replace(",", ".")) 'sensor temp
                .tempZ_Flor = IIf(txtTempZF.Text = "", "0", txtTempA34.Text.Replace(",", ".")) 'sensor temp
                .tempZ_Pq = IIf(txtTempZP.Text = "", "0", txtTempA34.Text.Replace(",", ".")) 'sensor temp
                If RB_A2.Checked Then
                    .RegCargaCuartoFrio = "A2"
                ElseIf RB_A34.Checked Then
                    .RegCargaCuartoFrio = "A3-4"
                ElseIf RB_C.Checked Then
                    .RegCargaCuartoFrio = "A5"
                ElseIf RB_B.Checked Then
                    .RegCargaCuartoFrio = "B"
                ElseIf RB_ZF.Checked Then
                    .RegCargaCuartoFrio = "Z-Flores"
                ElseIf RB_Zp.Checked Then
                    .RegCargaCuartoFrio = "Z-Pequeño"
                End If
                .UsusarioIngreso = IdUsuario 'sensor temp

                .tempB = IIf(txtTempB.Text = "", "0", txtTempB.Text.Replace(",", "."))
                .tempC = IIf(txtTempC.Text = "", "0", txtTempC.Text.Replace(",", "."))
                .idCamion = uceCamiones.Value
                .muelle = lblMuelle.Text
                .idPosicion = ucePosicion.Value
                .indice = Guid.NewGuid
                .codsello = txtcodSello.Text
                .nuSaca = txtnumSaca.Text
                .incourier = "N"
                If My.Settings.LoginEmpr = 2 Then
                    .incourier = "S"
                End If

            End With
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Function SaveDetalleProceso() As Boolean
        Dim result As Boolean = False
        Dim req As New DetalleProcesoRequest
        Dim res As New DetalleProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try



            If RB_A2.Checked = True Or RB_A34.Checked = True Or RB_C.Checked = True Or RB_B.Checked = True Or RB_ZF.Checked = True Or RB_Zp.Checked = True Then
                General.SetBARequest(req)
                If isDetalleProcesoChange Then
                    myDetalleProceso.indice = Guid.NewGuid
                End If
                req.myDetalleProcesoItem = myDetalleProceso
                res = WsClnt.SaveDetalleProcesoItem(req)
                If res.ActionResult Then
                    CargarDatosGrid()
                    result = True
                    RegistroActualizadoCorreo = True
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                MessageBox.Show("Debe seleccionar el Cuarto Frio donde será almacenada la carga ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function SaveProceso() As Boolean
        Dim result As Boolean = False
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myProceso) Then myProceso = New ProcesoItem
            myProceso.IdProceso = idProceso
            myProceso.idBriefing = resDtVuelo.idBriefing
            myProceso.idAvion = resDtVuelo.idAvion
            myProceso.totalBultos = myGuia.Bultos
            myProceso.totalPeso = myGuia.Peso
            myProceso.fechaInicio = udtUltimo.Value
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

    Private Sub uceGuias_SelectionChanged(sender As Object, e As EventArgs) Handles uceGuias.SelectionChanged
        Dim guiaTemp As New GuiaItem
        Try
            uceCamiones.Items.Clear()
            For Each r As DataRow In CommonProcess.GetGuiaCamionesPorIdGuia(uceGuias.Value, myDetalleVuelo.idBriefing).Rows
                uceCamiones.Items.Add(r.Item("idCamion"), r.Item("matriculaCamion"))
            Next
            uceCamiones.SelectedIndex = 0 'ATENCION AQUI!
            uceDaes.Items.Clear()
            For Each r As DataRow In CommonProcess.GetGuiaDaesPorIdGuia(uceGuias.Value).Rows
                uceDaes.Items.Add(r.Item("idGuia"), r.Item("dae"))
            Next
            uceDaes.SelectedIndex = 0

            If utcTabs.Tabs("PRO").Selected Then
                If uceCamiones.Items.Count < 1 Then
                    MessageBox.Show("La Guia seleccionada no se puede Procesar: Es necesario asignarle un Camión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    uceCamiones.Enabled = False
                    txtPeso.Enabled = False
                    txtLector.Enabled = False
                Else
                    txtPeso.Enabled = True
                    txtLector.Enabled = True
                    uceCamiones.Enabled = True
                    ObtenerGuias(myDetalleVuelo.idBriefing)
                End If
            End If
            dtGuiaProductos = CommonProcess.GetGuiaProductoPorIdGuia(uceGuias.Value)
            If Not IsNothing(dtGuiaProductos) Then
                uceProducto.Items.Clear()
                For Each r As DataRow In dtGuiaProductos.Rows
                    uceProducto.Items.Add(r.Item("idProducto"), r.Item("descripcionProducto"))
                Next
                uceProducto.SelectedIndex = 0
            End If
            uceAgencia.Items.Clear()
            guiaTemp = CommonProcess.GetGuiaPorIdGuia(uceGuias.Value)
            uceAgencia.Items.Add(guiaTemp.IdAgencia, guiaTemp.DescripcionAgencia)
            uceAgencia.SelectedIndex = 0
            txtTPesoGuia.Text = guiaTemp.Peso
            txtTBultosGuia.Text = guiaTemp.Bultos
            'txtDae.Text = guiaTemp.DAE
            'If txtDae.Text.Trim <> String.Empty Then
            '    txtEstadoDae.Text = String.Empty
            '    consultaEstadoValidezDae()
            '    TmrConsultaEstadoDae.Start()
            'Else
            '    txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
            '    txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
            '    txtEstadoDae.Text = "DAE Incorrecto"
            '    estadoDAE = False
            'End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaProceso()
        Dim proceso As New ProcesoItem
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
                Dim nr As DataRow
                procesoExist = True
                contdtMatriz = dtMatriz.Rows.Count
                dtPersonal = CommonProcess.GetPersonalPorIdProceso(proceso.IdProceso)
                If Not IsNothing(dtPersonal) Then
                    contDtPersonal = dtPersonal.Rows.Count
                End If
                For Each r2 As DataRow In dtMatriz.Rows
                    If Not IsNothing(dtPersonal) Then
                        For Each r As DataRow In dtPersonal.Rows
                            If r2.Item("grupoPersonal") = r.Item("grupoPersonal") Then
                                If r2.Item("tipoAgenciaRequerida") = r.Item("idTIpo").ToString And r.Item("cargo") = r2.Item("cargoPersonal") Then
                                    r2.Item("cantidadPersonal") = 1
                                    r2.Item("cargoPersonal") = r.Item("cargo")
                                    r2.Item("tipoAgenciaRequerida") = r.Item("idTipo").ToString
                                    r2.Item("descripcionTipoAgencia") = r.Item("descripcionTipo").ToString
                                    r2.Item("idAgencia") = r.Item("idAgencia").ToString
                                    r2.Item("idContacto") = r.Item("idPersona")
                                    r2.Item("contacto") = r.Item("primerNombreContacto") + " " + r.Item("primerApellidoContacto")
                                    r2.Item("horaEntrada") = r.Item("horaInicio")
                                    r2.Item("horaSalida") = r.Item("horaFin")
                                    r.Item("cargo") = "HECHO-" & r.Item("cargo")
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                Next
                For Each r As DataRow In dtPersonal.Rows
                    If (r.Item("cargo").ToString).Substring(0, 6) <> "HECHO-" Then
                        Dim r2 As DataRow
                        r2 = dtMatriz.NewRow
                        r2.Item("grupoPersonal") = r.Item("grupoPersonal")
                        r2.Item("cantidadPersonal") = 1
                        r2.Item("cargoPersonal") = r.Item("cargo")
                        r2.Item("tipoAgenciaRequerida") = r.Item("idTipo").ToString
                        r2.Item("descripcionTipoAgencia") = r.Item("descripcionTipo").ToString
                        r2.Item("idAgencia") = r.Item("idAgencia").ToString
                        r2.Item("idContacto") = r.Item("idPersona")
                        r2.Item("contacto") = r.Item("primerNombreContacto") + " " + r.Item("primerApellidoContacto")
                        r2.Item("horaEntrada") = r.Item("horaInicio")
                        r2.Item("horaSalida") = r.Item("horaFin")
                        dtMatriz.Rows.Add(r2)
                        r.Item("cargo") = r.Item("cargo") & "-Hecho"
                    End If
                Next
                Dim cont1 As Integer = 0
                For Each r As DataRow In dtMatriz.Rows
                    Dim datetime As String
                    If r.Item("horaSalida").ToString <> String.Empty Then
                        datetime = CDate(r.Item("horaSalida")).ToShortTimeString
                        If CDate(r.Item("horaSalida")).ToShortTimeString = "12:00 AM" Then
                            cont1 += 1
                        End If
                    Else
                        cont1 += 1
                    End If
                Next

                If myProceso.estado <> "T" Then
                    If cont1 = 0 Then
                        CargarUgvPers(cantMatriz + 1)
                    End If
                End If


                ugvPersonal.DataSource = dtMatriz
                SetDisplayedColumnsPersonal()
                For Each r As DataRow In CommonProcess.GetDetalleProcesoPorIdProcesoCaptura(myProceso.IdProceso).Rows
                    nr = dtDetalleProceso.NewRow
                    nr.Item("idProceso") = r.Item("idProceso")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                    nr.Item("agenciaTransporteDescripcion") = CommonData.GetAgenciaItem(r.Item("agenciaTransporte")).Descripcion
                    nr.Item("bultos") = r.Item("bultos")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("hora") = r.Item("hora")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("estado") = r.Item("estado")
                    nr.Item("idPosicion") = r.Item("idPosicion")
                    nr.Item("temperatura") = r.Item("temperatura")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    nr.Item("eds") = r.Item("eds")
                    nr.Item("largo") = r.Item("largo")
                    nr.Item("ancho") = r.Item("ancho")
                    nr.Item("alto") = r.Item("alto")
                    nr.Item("tempA") = r.Item("tempA")
                    nr.Item("tempA_3_4") = r.Item("tempA_3_4") 'sensor temp
                    nr.Item("tempB") = r.Item("tempB")
                    nr.Item("tempC") = r.Item("tempC")
                    nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                    nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                    nr.Item("idCamion") = r.Item("idCamion")
                    nr.Item("camionDescripcion") = CommonData.GetCamionItem(r.Item("idCamion")).Descripcion
                    nr.Item("muelle") = r.Item("muelle")
                    nr.Item("indice") = r.Item("indice")
                    nr.Item("estadoSenae") = r.Item("estadoSenae")
                    nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                    nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")

                    nr.Item("nuSaca") = r.Item("nuSaca")
                    nr.Item("sellosaca") = r.Item("codsello")
                    nr.Item("incourier") = r.Item("incourier")




                    dtDetalleProceso.Rows.Add(nr)
                Next
                'ugvCaptura.DataSource = dtDetalleProceso
                ugvCaptura.DataBind()
                ugvCaptura.Refresh()
                SetDisplayedColumnsCaptura()
                If Not IsNothing(dtDetalleProceso) And dtDetalleProceso.Rows.Count > 0 Then
                    ' CalcularTotales()
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsCaptura()
        Try
            ugvCaptura.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
            ugvCaptura.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
            ugvCaptura.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
            ugvCaptura.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
            ugvCaptura.DisplayLayout.Bands(0).Columns("agenciaTransporte").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("agenciaTransporteDescripcion").Header.Caption = "Agencia Transporte"
            ugvCaptura.DisplayLayout.Bands(0).Columns("bultos").Header.Caption = "Bultos"
            ugvCaptura.DisplayLayout.Bands(0).Columns("bultos").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
            ugvCaptura.DisplayLayout.Bands(0).Columns("piezas").Header.Caption = "Piezas"
            ugvCaptura.DisplayLayout.Bands(0).Columns("volumen").Header.Caption = "Volumen"
            ugvCaptura.DisplayLayout.Bands(0).Columns("hora").Header.Caption = "Hora"
            ugvCaptura.DisplayLayout.Bands(0).Columns("hora").Format = "HH:mm:ss"
            ugvCaptura.DisplayLayout.Bands(0).Columns("hora").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
            ugvCaptura.DisplayLayout.Bands(0).Columns("idPosicion").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("temperatura").Header.Caption = "Temperatura"
            ugvCaptura.DisplayLayout.Bands(0).Columns("rx").Header.Caption = "RX"
            ugvCaptura.DisplayLayout.Bands(0).Columns("man").Header.Caption = "MAN"
            ugvCaptura.DisplayLayout.Bands(0).Columns("k9").Header.Caption = "K9"
            ugvCaptura.DisplayLayout.Bands(0).Columns("eds").Header.Caption = "EDS"
            ugvCaptura.DisplayLayout.Bands(0).Columns("largo").Header.Caption = "Largo"
            ugvCaptura.DisplayLayout.Bands(0).Columns("ancho").Header.Caption = "Ancho"
            ugvCaptura.DisplayLayout.Bands(0).Columns("alto").Header.Caption = "Alto"
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempA").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempA_3_4").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempZ_Flor").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempZ_Pq").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("RegCargaCuartoFrio").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("UsusarioIngreso").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempB").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("tempC").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("idCamion").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("camionDescripcion").Header.Caption = "Camión"
            ugvCaptura.DisplayLayout.Bands(0).Columns("muelle").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("indice").Hidden = True
            ugvCaptura.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            ugvCaptura.DisplayLayout.Bands(0).Columns("guia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("idElemento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("agenciaTransporteDescripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("bultos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("peso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("piezas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("volumen").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("estado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCaptura.DisplayLayout.Bands(0).Columns("camionDescripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            ugvCaptura.DisplayLayout.Bands(0).Columns("nuSaca").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("sellosaca").Hidden = True
            ugvCaptura.DisplayLayout.Bands(0).Columns("inCourier").Hidden = True

            If My.Settings.LoginEmpr = 2 Then
                ugvCaptura.DisplayLayout.Bands(0).Columns("nuSaca").Hidden = False
                ugvCaptura.DisplayLayout.Bands(0).Columns("sellosaca").Hidden = False
                ugvCaptura.DisplayLayout.Bands(0).Columns("inCourier").Hidden = False
            End If



        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InfoDetalleProcesoToObject()
        Try
            myDetalleProceso.IdDetalleProceso = myProceso.IdProceso
            myDetalleProceso.fecha = ugvCaptura.ActiveRow.Cells("fecha").Value
            myDetalleProceso.dae = ugvCaptura.ActiveRow.Cells("dae").Value 'EDWIN MODIF
            myDetalleProceso.idGuia = ugvCaptura.ActiveRow.Cells("idGuia").Value
            myDetalleProceso.Guia = ugvCaptura.ActiveRow.Cells("guia").Value
            myDetalleProceso.idElemento = ugvCaptura.ActiveRow.Cells("idElemento").Value
            myDetalleProceso.agenciaTransporte = ugvCaptura.ActiveRow.Cells("agenciaTransporte").Value
            myDetalleProceso.bultos = ugvCaptura.ActiveRow.Cells("bultos").Value
            myDetalleProceso.peso = ugvCaptura.ActiveRow.Cells("peso").Value
            myDetalleProceso.piezas = ugvCaptura.ActiveRow.Cells("piezas").Value
            'myDetalleProceso.volumen = ugvCaptura.ActiveRow.Cells("volumen").Value
            myDetalleProceso.hora = ugvCaptura.ActiveRow.Cells("hora").Value
            myDetalleProceso.idProducto = ugvCaptura.ActiveRow.Cells("idProducto").Value
            myDetalleProceso.estado = ugvCaptura.ActiveRow.Cells("estado").Value
            myDetalleProceso.idPosicion = ugvCaptura.ActiveRow.Cells("idPosicion").Value
            myDetalleProceso.temperatura = ugvCaptura.ActiveRow.Cells("temperatura").Value
            myDetalleProceso.rx = ugvCaptura.ActiveRow.Cells("rx").Value
            myDetalleProceso.volumen = Decimal.Round((ugvCaptura.ActiveRow.Cells("largo").Value * ugvCaptura.ActiveRow.Cells("ancho").Value * ugvCaptura.ActiveRow.Cells("alto").Value) / 6000, 2)
            If myDetalleProceso.rx <> 0 Then
                myDetalleProceso.rx = 1
            End If
            myDetalleProceso.man = ugvCaptura.ActiveRow.Cells("man").Value
            If myDetalleProceso.man <> 0 Then
                myDetalleProceso.man = 1
            End If
            myDetalleProceso.k9 = ugvCaptura.ActiveRow.Cells("k9").Value
            If myDetalleProceso.k9 <> 0 Then
                myDetalleProceso.k9 = 1
            End If
            myDetalleProceso.eds = ugvCaptura.ActiveRow.Cells("eds").Value
            If myDetalleProceso.eds <> 0 Then
                myDetalleProceso.eds = 1
            End If
            myDetalleProceso.largo = ugvCaptura.ActiveRow.Cells("largo").Value
            myDetalleProceso.ancho = ugvCaptura.ActiveRow.Cells("ancho").Value
            myDetalleProceso.alto = ugvCaptura.ActiveRow.Cells("alto").Value
            myDetalleProceso.tempA = ugvCaptura.ActiveRow.Cells("tempA").Value
            myDetalleProceso.tempA_3_4 = ugvCaptura.ActiveRow.Cells("tempA_3_4").Value 'sensor de temp
            myDetalleProceso.tempZ_Flor = ugvCaptura.ActiveRow.Cells("tempZ_Flor").Value 'sensor de temp
            myDetalleProceso.tempZ_Pq = ugvCaptura.ActiveRow.Cells("tempZ_Pq").Value 'sensor de temp
            myDetalleProceso.RegCargaCuartoFrio = ugvCaptura.ActiveRow.Cells("RegCargaCuartoFrio").Value 'sensor de temp
            myDetalleProceso.UsusarioIngreso = ugvCaptura.ActiveRow.Cells("UsusarioIngreso").Value 'sensor de temp
            myDetalleProceso.tempB = ugvCaptura.ActiveRow.Cells("tempB").Value
            myDetalleProceso.tempC = ugvCaptura.ActiveRow.Cells("tempC").Value
            myDetalleProceso.idCamion = ugvCaptura.ActiveRow.Cells("idCamion").Value
            myDetalleProceso.muelle = ugvCaptura.ActiveRow.Cells("muelle").Value
            myDetalleProceso.indice = ugvCaptura.ActiveRow.Cells("indice").Value
            myDetalleProceso.estadoSenae = ugvCaptura.ActiveRow.Cells("estadoSenae").Value
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub EliminarDetalleProceso()
        Try
            For Each r As DataRow In dtdetalleProcesoTemp.Rows
                If r.Item("estadoSenae") = String.Empty Then
                    myDetalleProceso.IdDetalleProceso = r.Item("idProceso")
                    myDetalleProceso.fecha = r.Item("fecha")
                    myDetalleProceso.idGuia = r.Item("idGuia")
                    myDetalleProceso.Guia = r.Item("guia")
                    myDetalleProceso.idElemento = r.Item("idElemento")
                    myDetalleProceso.agenciaTransporte = r.Item("agenciaTransporte")
                    myDetalleProceso.bultos = r.Item("bultos")
                    myDetalleProceso.peso = r.Item("peso")
                    myDetalleProceso.piezas = r.Item("piezas")
                    myDetalleProceso.volumen = r.Item("volumen")
                    myDetalleProceso.hora = r.Item("hora")
                    myDetalleProceso.idProducto = r.Item("idProducto")
                    myDetalleProceso.estado = r.Item("estado")
                    myDetalleProceso.idPosicion = r.Item("idPosicion")
                    myDetalleProceso.temperatura = r.Item("temperatura")
                    myDetalleProceso.rx = r.Item("rx")
                    If myDetalleProceso.rx <> 0 Then
                        myDetalleProceso.rx = 1
                    End If
                    myDetalleProceso.man = r.Item("man")
                    If myDetalleProceso.man <> 0 Then
                        myDetalleProceso.man = 1
                    End If
                    myDetalleProceso.k9 = r.Item("k9")
                    If myDetalleProceso.k9 <> 0 Then
                        myDetalleProceso.k9 = 1
                    End If
                    myDetalleProceso.eds = r.Item("eds")
                    If myDetalleProceso.eds <> 0 Then
                        myDetalleProceso.eds = 1
                    End If
                    myDetalleProceso.largo = r.Item("largo")
                    myDetalleProceso.ancho = r.Item("ancho")
                    myDetalleProceso.alto = r.Item("alto")
                    myDetalleProceso.tempA = r.Item("tempA")
                    myDetalleProceso.tempA_3_4 = r.Item("tempA_3_4") 'sensor temp
                    myDetalleProceso.tempZ_Flor = r.Item("tempZ_Flor") 'sensor temp
                    myDetalleProceso.tempZ_Pq = r.Item("tempZ_Pq") 'sensor temp
                    myDetalleProceso.RegCargaCuartoFrio = r.Item("RegCargaCuartoFrio") 'sensor temp
                    myDetalleProceso.UsusarioIngreso = r.Item("UsusarioIngreso") 'sensor temp
                    myDetalleProceso.tempB = r.Item("tempB")
                    myDetalleProceso.tempC = r.Item("tempC")
                    myDetalleProceso.idCamion = r.Item("idCamion")
                    myDetalleProceso.muelle = r.Item("muelle")
                    myDetalleProceso.indice = r.Item("indice")
                    DeleteDetalleProceso()
                Else
                    MessageBox.Show("No puede eliminar piezas que se han enviado a SENAE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub actualizarDetalleProceso()
        DeleteDetalleProceso()
        isDetalleProcesoChange = True
        SaveDetalleProceso()
        isDetalleProcesoChange = False
    End Sub

    Private Sub CalcularTotales()
        Dim nr As DataRow
        Dim existEle As Boolean = False
        Dim existGui As Boolean = False
        Dim totBulto As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Double = 0D
        Dim totVolu As Double = 0D
        Dim dttempTotalPorGuia As New DataTable
        Dim dttempTotalPorGuiaDev As New DataTable
        Dim dttempTotalPorElemento As New DataTable
        Dim dttempTotalPorIdProceso As New DataTable
        Try
            dttempTotalPorElemento = CommonProcess.GetTotalPorElementoPorIdProceso(myProceso.IdProceso)
            dtTotalElementos.Rows.Clear()
            For Each r As DataRow In dttempTotalPorElemento.Rows
                nr = dtTotalElementos.NewRow
                nr.Item("elemento") = r.Item("idElemento")
                nr.Item("totalBultos") = r.Item("bultos")
                nr.Item("totalPiezas") = r.Item("piezas")
                nr.Item("pesoReal") = r.Item("peso")
                nr.Item("pesoVolumen") = r.Item("volumen")
                dtTotalElementos.Rows.Add(nr)
            Next
            ugvTotalElemento.DataSource = dtTotalElementos
            SetDisplayedColumnsElemento()

            dttempTotalPorGuia = CommonProcess.GetTotalPorGuiaPorIdProceso(myProceso.IdProceso)
            dtTotalGuias.Rows.Clear()
            For Each r As DataRow In dttempTotalPorGuia.Rows
                nr = dtTotalGuias.NewRow
                nr.Item("idGuia") = r.Item("idGuia").ToString
                nr.Item("guia") = r.Item("guia").ToString
                nr.Item("totalBultos") = r.Item("bultos")
                nr.Item("totalPiezas") = r.Item("piezas")
                nr.Item("pesoReal") = r.Item("peso")
                nr.Item("pesoVolumen") = r.Item("volumen")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("horaInicio") = r.Item("horaIni")
                nr.Item("horaFin") = r.Item("horaFin")
                nr.Item("tempMax") = r.Item("tempMax")
                nr.Item("tempMin") = r.Item("tempMin")
                nr.Item("tempPro") = r.Item("tempPro")
                nr.Item("tempSum") = r.Item("tempSum")
                nr.Item("Rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("alto") = r.Item("alto")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("largo") = r.Item("largo")
                nr.Item("idCamion") = r.Item("idCamion")
                dtTotalGuias.Rows.Add(nr)
            Next
            ugvTotalGuias.DataSource = dtTotalGuias
            SetDisplayedColumnsGuia()

            dttempTotalPorGuiaDev = CommonProcess.GetTotalPorGuiaPorIdProcesoDev(myProceso.IdProceso)
            dtTotalGuiasDev.Rows.Clear()
            For Each r As DataRow In dttempTotalPorGuiaDev.Rows
                nr = dtTotalGuiasDev.NewRow
                nr.Item("idGuia") = r.Item("idGuia").ToString
                nr.Item("guia") = r.Item("guia").ToString
                nr.Item("totalBultos") = r.Item("bultos")
                nr.Item("totalPiezas") = r.Item("piezas")
                nr.Item("pesoReal") = r.Item("peso")
                nr.Item("pesoVolumen") = r.Item("volumen")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("horaInicio") = r.Item("horaIni")
                nr.Item("horaFin") = r.Item("horaFin")
                nr.Item("tempMax") = r.Item("tempMax")
                nr.Item("tempMin") = r.Item("tempMin")
                nr.Item("tempPro") = r.Item("tempPro")
                nr.Item("tempSum") = r.Item("tempSum")
                nr.Item("Rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("alto") = r.Item("alto")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("largo") = r.Item("largo")
                nr.Item("idCamion") = r.Item("idCamion")
                dtTotalGuiasDev.Rows.Add(nr)
            Next

            dttempTotalPorIdProceso = CommonProcess.GetTotalPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In dttempTotalPorIdProceso.Rows
                If r.Item("bultos").ToString <> String.Empty Then
                    totBulto = r.Item("bultos")
                    totPiezas = r.Item("piezas")
                    totPeso = r.Item("peso")
                    totVolu = r.Item("volumen")
                Else
                    Exit For
                End If
            Next
            txtTotBulto.Text = totBulto
            txtTotPiezas.Text = totPiezas
            txtTotPeso.Text = totPeso
            txtTotVol.Text = totVolu
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElemento()
        Try

            ugvTotalElemento.DisplayLayout.Bands(0).Columns("elemento").Header.Caption = "Elemento"
            ugvTotalElemento.DisplayLayout.Bands(0).Columns("totalBultos").Header.Caption = "T. Bultos"
            ugvTotalElemento.DisplayLayout.Bands(0).Columns("totalBultos").Hidden = True
            ugvTotalElemento.DisplayLayout.Bands(0).Columns("totalPiezas").Header.Caption = "T. Piezas"
            ugvTotalElemento.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
            ugvTotalElemento.DisplayLayout.Bands(0).Columns("pesoVolumen").Header.Caption = "Peso Volumen"
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsGuia()
        Try

            ugvTotalGuias.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "N. Guia"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("totalBultos").Header.Caption = "T. Bultos"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("totalBultos").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("totalPiezas").Header.Caption = "T. Piezas"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("pesoVolumen").Header.Caption = "Peso Volumen"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("tempPro").Formula = "[tempSum] / [totalBultos]"
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("tempMax").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("tempMin").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("tempSum").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("tempPro").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("horaInicio").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("horaFin").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Rx").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Man").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("K9").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Eds").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Alto").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Ancho").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("Largo").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("idCamion").Hidden = True
            ugvTotalGuias.DisplayLayout.Bands(0).Columns("observacion").Header.Caption = "Observaciones"
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub ugvCaptura_AfterExitEditMode(sender As Object, e As EventArgs) Handles ugvCaptura.AfterExitEditMode
        LsBandeAct = "N" 'JRO 01022018
        Dim actualizar As Boolean = False
        Dim strMsg As String
        Dim usuarioPermiso As New Server.ReportService.ContactoCatalogItem
        If Not IsNothing(ugvCaptura.ActiveRow.Cells("estadoSenae").Value) Then
            If ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString = String.Empty Then
                If ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("largo") Or
                    ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("alto") Or
                    ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("ancho") Then
                    For Each r As DataRow In dtdetalleProcesoTemp.Rows
                        If r.Item("largo") <> ugvCaptura.ActiveRow.Cells("largo").Value Or r.Item("ancho") <> ugvCaptura.ActiveRow.Cells("ancho").Value Or
                            r.Item("alto") <> ugvCaptura.ActiveRow.Cells("alto").Value Then
                            strMsg = "Datos Anteriores de la dimencion de la caja; Alto= " & r.Item("alto").ToString & " Ancho= " & r.Item("ancho").ToString & " Largo= " & r.Item("alto").ToString
                            strMsg = strMsg & vbCrLf & "Datos Actuales de la dimencion de la caja Alto= " & ugvCaptura.ActiveRow.Cells("alto").Value & " Ancho= " & ugvCaptura.ActiveRow.Cells("ancho").Value & " Largo= " & ugvCaptura.ActiveRow.Cells("largo").Value
                            Dim frmCheck As New frmCheckUserManager
                            frmCheck.ShowDialog()
                            If Not frmCheck.result Then
                                ugvCaptura.ActiveRow.Cells("largo").Value = r.Item("largo")
                                ugvCaptura.ActiveRow.Cells("ancho").Value = r.Item("ancho")
                                ugvCaptura.ActiveRow.Cells("alto").Value = r.Item("alto")
                                Exit Sub
                            Else
                                r.Item("largo") = ugvCaptura.ActiveRow.Cells("largo").Value
                                r.Item("ancho") = ugvCaptura.ActiveRow.Cells("ancho").Value
                                r.Item("alto") = ugvCaptura.ActiveRow.Cells("alto").Value
                            End If
                            usuarioPermiso = CommonData.GetContactoItem(frmCheck.tempUserManager.userName)
                            actualizar = True
                        End If
                    Next
                    If actualizar Then
                        If IsNothing(myDetalleProceso) Then myDetalleProceso = New DetalleProcesoItem
                        If Not IsNothing(ugvCaptura.ActiveRow.Cells("indice").Value) Then
                            myDetalleProceso.indice = ugvCaptura.ActiveRow.Cells("indice").Value
                            InfoDetalleProcesoToObject()
                        End If
                        If myDetalleProceso.indice <> Guid.Empty Then
                            'Se setean las variables 9, LnIndexAct para identificar que es una actualizacion
                            LsBandeAct = "S" 'JRO 01022018
                            Dim LaPosicion As Integer
                            Dim dr As DataRow = dtDetalleProceso.Select("indice='" & ugvCaptura.ActiveRow.Cells("indice").Value.ToString & "'")(0)
                            LaPosicion = dtDetalleProceso.Rows.IndexOf(dr) 'se obtiene el indice de la celda seleccionada  JRO 01022018
                            LnIndexAct = LaPosicion
                            actualizar = False
                            actualizarDetalleProceso()
                            If RegistroActualizadoCorreo Then
                                Task.Run(Async Function()
                                             Await EnviarReporteCheckUserManager("Actualizacion de Dimenciones para Calculo de Volumen", strMsg, usuarioPermiso, usuarioRequiere)
                                         End Function)
                                RegistroActualizadoCorreo = False
                            End If
                            RegistroActualizadoCorreo = False
                            EscribirLineaLog("R2- " + myDetalleProceso.Guia.ToString + "; " + myDetalleProceso.dae.ToString + "; " + myDetalleProceso.hora.ToString + "; " + txtLector.Text, PathLog)
                            CalcularTotales()
                        End If
                    Else
                        RegActualizado = False
                    End If
                Else
                    ActVolumen = False
                End If
            End If
        End If
        'Try
        '    If IsNothing(myDetalleProceso) Then myDetalleProceso = New DetalleProcesoItem
        '    If Not IsNothing(ugvCaptura.ActiveRow.Cells("indice").Value) Then
        '        myDetalleProceso.indice = ugvCaptura.ActiveRow.Cells("indice").Value
        '        InfoDetalleProcesoToObject()
        '    End If
        '    If myDetalleProceso.indice <> Guid.Empty Then
        '        actualizarDetalleProceso()
        '        EscribirLineaLog("R- " + myDetalleProceso.Guia.ToString + "; " + myDetalleProceso.dae.ToString + "; " + myDetalleProceso.hora.ToString + "; " + txtLector.Text + Chr(13), PathLog)
        '        CalcularTotales()
        '    End If
        '    'isEnableConsultaProceso = True
        '    'Timer1.Enabled = True
        'Catch ex As Exception
        '    General.SetLogEvent(ex)
        'End Try
    End Sub

    Private Sub ugvCaptura_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvCaptura.AfterRowsDeleted
        EliminarDetalleProceso()
        CalcularTotales()
        isEnableConsultaProceso = True
        'ugvCaptura.DataBind()
        'ugvCaptura.Refresh()
    End Sub

    Private Sub ugvCaptura_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvCaptura.AfterRowActivate
        Dim r As DataRow
        Try
            If Not IsNothing(ugvCaptura.ActiveRow) Then
                If Not IsNothing(dtdetalleProcesoTemp) Then dtdetalleProcesoTemp.Rows.Clear()
                r = dtdetalleProcesoTemp.NewRow
                r.Item("idProceso") = myProceso.IdProceso
                r.Item("fecha") = ugvCaptura.ActiveRow.Cells("fecha").Value
                r.Item("idGuia") = ugvCaptura.ActiveRow.Cells("idGuia").Value
                r.Item("Guia") = ugvCaptura.ActiveRow.Cells("guia").Value
                r.Item("idElemento") = ugvCaptura.ActiveRow.Cells("idElemento").Value
                r.Item("agenciaTransporte") = ugvCaptura.ActiveRow.Cells("agenciaTransporte").Value
                r.Item("bultos") = ugvCaptura.ActiveRow.Cells("bultos").Value
                r.Item("peso") = ugvCaptura.ActiveRow.Cells("peso").Value
                r.Item("piezas") = ugvCaptura.ActiveRow.Cells("piezas").Value
                r.Item("volumen") = ugvCaptura.ActiveRow.Cells("volumen").Value
                r.Item("hora") = ugvCaptura.ActiveRow.Cells("hora").Value
                r.Item("idProducto") = ugvCaptura.ActiveRow.Cells("idProducto").Value
                r.Item("estado") = ugvCaptura.ActiveRow.Cells("estado").Value
                r.Item("idPosicion") = ugvCaptura.ActiveRow.Cells("idPosicion").Value
                r.Item("temperatura") = ugvCaptura.ActiveRow.Cells("temperatura").Value
                r.Item("rx") = ugvCaptura.ActiveRow.Cells("rx").Value
                r.Item("DAE") = ugvCaptura.ActiveRow.Cells("dae").Value 'EDWIN MODIF
                If r.Item("rx") <> 0 Then
                    r.Item("rx") = 1
                End If
                r.Item("man") = ugvCaptura.ActiveRow.Cells("man").Value
                If r.Item("man") <> 0 Then
                    r.Item("man") = 1
                End If
                r.Item("k9") = ugvCaptura.ActiveRow.Cells("k9").Value
                If r.Item("k9") <> 0 Then
                    r.Item("k9") = 1
                End If
                r.Item("eds") = ugvCaptura.ActiveRow.Cells("eds").Value
                If r.Item("eds") <> 0 Then
                    r.Item("eds") = 1
                End If
                r.Item("largo") = ugvCaptura.ActiveRow.Cells("largo").Value
                r.Item("ancho") = ugvCaptura.ActiveRow.Cells("ancho").Value
                r.Item("alto") = ugvCaptura.ActiveRow.Cells("alto").Value
                r.Item("tempA") = ugvCaptura.ActiveRow.Cells("tempA").Value
                r.Item("tempA_3_4") = ugvCaptura.ActiveRow.Cells("tempA_3_4").Value
                r.Item("tempB") = ugvCaptura.ActiveRow.Cells("tempB").Value
                r.Item("tempC") = ugvCaptura.ActiveRow.Cells("tempC").Value
                r.Item("tempZ_Flor") = ugvCaptura.ActiveRow.Cells("tempZ_Flor").Value
                r.Item("tempZ_Pq") = ugvCaptura.ActiveRow.Cells("tempZ_Pq").Value
                r.Item("RegCargaCuartoFrio") = ugvCaptura.ActiveRow.Cells("RegCargaCuartoFrio").Value
                r.Item("UsusarioIngreso") = ugvCaptura.ActiveRow.Cells("UsusarioIngreso").Value
                r.Item("idCamion") = ugvCaptura.ActiveRow.Cells("idCamion").Value
                r.Item("muelle") = ugvCaptura.ActiveRow.Cells("muelle").Value
                r.Item("indice") = ugvCaptura.ActiveRow.Cells("indice").Value
                r.Item("estadoSenae") = ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString




                dtdetalleProcesoTemp.Rows.Add(r)
            End If
            CalcularTotales()
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvCaptura_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCaptura.ClickCell
        Try
            LsBandeAct = "N" 'JRO 01022018
            Dim actualizar As Boolean = False
            If isNewProceso Then
                If ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString = String.Empty Then
                    If ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("largo") Or
                        ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("alto") Or
                        ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("ancho") Then
                        If ActVolumen Then
                            isDetalleProcesoChange = False
                            For Each r As DataRow In dtdetalleProcesoTemp.Rows
                                If r.Item("largo") <> ugvCaptura.ActiveRow.Cells("largo").Value Or r.Item("ancho") <> ugvCaptura.ActiveRow.Cells("ancho").Value Or
                                    r.Item("alto") <> ugvCaptura.ActiveRow.Cells("alto").Value Then
                                    r.Item("largo") = ugvCaptura.ActiveRow.Cells("largo").Value
                                    r.Item("ancho") = ugvCaptura.ActiveRow.Cells("ancho").Value
                                    r.Item("alto") = ugvCaptura.ActiveRow.Cells("alto").Value
                                    actualizar = True
                                End If
                            Next
                        End If
                        ActVolumen = True
                        ugvCaptura.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
                        If actualizar Then
                            If IsNothing(myDetalleProceso) Then myDetalleProceso = New DetalleProcesoItem
                            If Not IsNothing(ugvCaptura.ActiveRow.Cells("indice").Value) Then
                                myDetalleProceso.indice = ugvCaptura.ActiveRow.Cells("indice").Value
                                InfoDetalleProcesoToObject()
                            End If
                            If myDetalleProceso.indice <> Guid.Empty Then
                                'Se setean las variables 9, LnIndexAct para identificar que es una actualizacion
                                LsBandeAct = "S" 'JRO 01022018

                                Dim LaPosicion As Integer
                                Dim dr As DataRow = dtDetalleProceso.Select("indice='" & ugvCaptura.ActiveRow.Cells("indice").Value.ToString & "'")(0)
                                LaPosicion = dtDetalleProceso.Rows.IndexOf(dr) 'se obtiene el indice de la celda seleccionada  JRO 01022018
                                LnIndexAct = LaPosicion
                                actualizarDetalleProceso()
                                RegActualizado = True
                                EscribirLineaLog("R2- " + myDetalleProceso.Guia.ToString + "; " + myDetalleProceso.dae.ToString + "; " + myDetalleProceso.hora.ToString + "; " + txtLector.Text, PathLog)
                                CalcularTotales()
                                'isEnableConsultaProceso = True
                                'Timer1.Enabled = True
                            End If
                        Else
                            RegActualizado = False
                        End If
                    Else
                        ActVolumen = False
                    End If
                    If ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("rx") Or
                        ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("man") Or
                        ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("k9") Or
                        ugvCaptura.ActiveCell.Column Is ugvCaptura.DisplayLayout.Bands(0).Columns("eds") Then
                        isDetalleProcesoChange = False
                        If ugvCaptura.ActiveCell.Value = True Then
                            ugvCaptura.ActiveCell.Value = False
                        Else
                            ugvCaptura.ActiveCell.Value = True
                        End If
                        If IsNothing(myDetalleProceso) Then myDetalleProceso = New DetalleProcesoItem
                        If Not IsNothing(ugvCaptura.ActiveRow.Cells("indice").Value) Then
                            myDetalleProceso.indice = ugvCaptura.ActiveRow.Cells("indice").Value
                            InfoDetalleProcesoToObject()
                        End If
                        If myDetalleProceso.indice <> Guid.Empty Then
                            'Se setean las variables 9, LnIndexAct para identificar que es una actualizacion
                            LsBandeAct = "S" 'JRO 01022018

                            Dim LaPosicion As Integer
                            Dim dr As DataRow = dtDetalleProceso.Select("indice='" & ugvCaptura.ActiveRow.Cells("indice").Value.ToString & "'")(0)
                            LaPosicion = dtDetalleProceso.Rows.IndexOf(dr) 'se obtiene el indice de la celda seleccionada  JRO 01022018
                            LnIndexAct = LaPosicion
                            actualizarDetalleProceso()
                            EscribirLineaLog("R2- " + myDetalleProceso.Guia.ToString + "; " + myDetalleProceso.dae.ToString + "; " + myDetalleProceso.hora.ToString + "; " + txtLector.Text, PathLog)
                            CalcularTotales()
                            'isEnableConsultaProceso = True
                            'Timer1.Enabled = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvTotalGuias_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvTotalGuias.ClickCell
        'isEnableConsultaProceso = False
        'Timer1.Enabled = False
    End Sub

    Private Sub ugvTotalGuias_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvTotalGuias.DoubleClickCell
        Dim idGuia As String = String.Empty
        Dim dtProducto As New DataTable("Producto")
        Dim dtCamiones As New DataTable("Camion")
        Dim GuiaItem As New GuiaItem
        Dim idCamion As String = String.Empty
        Dim idChofer As String = String.Empty
        Try
            dtGuiaDaeRem.Clear()
            If e.Cell.Column Is ugvTotalGuias.DisplayLayout.Bands(0).Columns("guia") Then
                If dtTotalGuiasDev.Rows.Count > 0 Then
                    For Each r As DataRow In dtTotalGuiasDev.Rows
                        If r.Item("idGuia") = ugvTotalGuias.ActiveRow.Cells("idGuia").Value Then
                            If MessageBox.Show("Si desea imprimir el WareHouse Receipt click SI, si desea imprir el WareHouse Devolution click NO", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                Dim enc As New Encabezado
                                Dim det As New Detalle
                                Dim cont2 As Integer = 0
                                idGuia = ugvTotalGuias.ActiveRow.Cells("idGuia").Value
                                GuiaItem = CommonProcess.GetGuiaPorIdGuia(Guid.Parse(idGuia))
                                dtProducto = CommonProcess.GetGuiaProductoPorIdGuia(Guid.Parse(idGuia))
                                dtCamiones = CommonProcess.GetPersonalPorIdProceso(myProceso.IdProceso)
                                GuiaItem.DescripcionProducto = dtProducto.Rows(0).Item("descripcionProducto")
                                enc.estado = "A"
                                enc.Guia = GuiaItem.Descripcion
                                enc.Vuelo = txtNumVuelo.Text
                                enc.Destino = GuiaItem.ciudadDestino
                                enc.Agencia = GuiaItem.DescripcionAgencia
                                Try
                                    enc.AgenciaTransporte = GuiaItem.DescripcionAgencia
                                Catch ex As Exception
                                    ErrorManager.SetLogEvent(ex)
                                End Try
                                enc.Aerolinea = myDetalleVuelo.descripcionAgencia
                                enc.Producto = GuiaItem.DescripcionProducto
                                enc.DAE = GuiaItem.DAE
                                idCamion = ugvTotalGuias.ActiveRow.Cells("idCamion").Value
                                enc.idRecibe = MyCurrentUser.userName
                                Dim tempRecibe As New Server.ReportService.ContactoCatalogItem
                                tempRecibe = CommonData.GetContactoItem(enc.idRecibe)
                                enc.Recibe = tempRecibe.primerApellido + " " + tempRecibe.segundoApellido + " " + tempRecibe.primerNombre
                                enc.Fecha = ugvTotalGuias.ActiveRow.Cells("horaInicio").Value
                                enc.HoraInicio = ugvTotalGuias.ActiveRow.Cells("horaInicio").Value
                                enc.HoraFin = ugvTotalGuias.ActiveRow.Cells("horaFin").Value
                                enc.Bultos = ugvTotalGuias.ActiveRow.Cells("totalBultos").Value
                                enc.Piezas = ugvTotalGuias.ActiveRow.Cells("totalPiezas").Value
                                enc.Alto = ugvTotalGuias.ActiveRow.Cells("alto").Value
                                enc.Ancho = ugvTotalGuias.ActiveRow.Cells("ancho").Value
                                enc.Largo = ugvTotalGuias.ActiveRow.Cells("largo").Value
                                enc.Peso = ugvTotalGuias.ActiveRow.Cells("pesoReal").Value
                                enc.Volumen = ugvTotalGuias.ActiveRow.Cells("pesoVolumen").Value
                                enc.tempMax = ugvTotalGuias.ActiveRow.Cells("tempMax").Value
                                enc.tempMin = ugvTotalGuias.ActiveRow.Cells("tempMin").Value
                                enc.tempPro = ugvTotalGuias.ActiveRow.Cells("tempPro").Value
                                enc.Rx = ugvTotalGuias.ActiveRow.Cells("Rx").Value
                                enc.Man = ugvTotalGuias.ActiveRow.Cells("Man").Value
                                enc.K9 = ugvTotalGuias.ActiveRow.Cells("K9").Value
                                enc.Eds = ugvTotalGuias.ActiveRow.Cells("Eds").Value
                                enc.Observacion = ugvTotalGuias.ActiveRow.Cells("observacion").Value.ToString
                                Dim frmPersonalProceso As New frmElegirPersonalProceso
                                frmPersonalProceso.dtPersonal = dtCamiones
                                frmPersonalProceso.tempGuiaItem = GuiaItem
                                frmPersonalProceso.idAerolinea = myDetalleVuelo.idAgencia
                                frmPersonalProceso.ShowDialog()
                                If myDetalleVuelo.idAgencia <> Guid.Parse("78613da6-1277-11e4-981b-8f9d682eafe3") Or myDetalleVuelo.idAgencia <> Guid.Parse("b86b9024-12ac-11e4-981b-8f9d682eafe3") Then
                                    If frmPersonalProceso.isCancel Then
                                        Exit Sub
                                    End If
                                    If Not frmPersonalProceso.isSaved Then
                                        Exit Sub
                                    End If
                                End If
                                Try
                                    enc.idChofer = frmPersonalProceso.personaAgenciaCarga.idContacto
                                    enc.Chofer = frmPersonalProceso.personaAgenciaCarga.primerApellido + " " + frmPersonalProceso.personaAgenciaCarga.segundoApellido + " " + frmPersonalProceso.personaAgenciaCarga.primerNombre
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Chofer")
                                End Try
                                Try
                                    enc.idEnvia = frmPersonalProceso.personaAerolinea.idContacto
                                    enc.Envia = frmPersonalProceso.personaAerolinea.primerApellido + " " + frmPersonalProceso.personaAerolinea.segundoApellido + " " + frmPersonalProceso.personaAerolinea.primerNombre
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Quien Envia")
                                End Try
                                Try
                                    enc.idSeguridad = frmPersonalProceso.personaSeguridad.idContacto
                                    enc.seguridad = frmPersonalProceso.personaSeguridad.primerApellido + " " + frmPersonalProceso.personaSeguridad.segundoApellido + " " + frmPersonalProceso.personaSeguridad.primerNombre
                                    enc.AgenciaSeguridad = frmPersonalProceso.agenciaSeguridad
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Seguridad")
                                End Try

                                ObtenerProceso2()
                                'EnviarInfoSenae(enc.Piezas, enc.Peso, enc.Guia) JCM Cambio en Funcion se quita peso y piezas
                                EnviarInfoSenae(enc.Guia) 'EWLM PRUEBAS
                                Dim tblMedidasTemp As New DataTable("dtMedidas")
                                With tblMedidasTemp.Columns
                                    .Add("producto", GetType(String))
                                    .Add("guia", GetType(String))
                                    .Add("dae", GetType(String))
                                    .Add("total", GetType(Integer))
                                    .Add("largo", GetType(Integer))
                                    .Add("ancho", GetType(Integer))
                                    .Add("alto", GetType(Integer))
                                    .Add("piezas", GetType(Decimal))
                                    .Add("sumMedidas", GetType(Integer))
                                    .Add("Peso", GetType(Decimal))
                                    .Add("Volumen", GetType(Decimal))
                                    .Add("tempMax", GetType(Decimal))
                                    .Add("tempMin", GetType(Decimal))
                                    .Add("tempPro", GetType(Decimal))
                                    .Add("Rx", GetType(Decimal))
                                    .Add("Man", GetType(Decimal))
                                    .Add("K9", GetType(Decimal))
                                    .Add("Eds", GetType(Decimal))
                                    .Add("Estado", GetType(String))
                                End With
                                Dim tempGuia As String = ""
                                Dim tempDae As String = ""
                                Dim tempTotal As Double = 0D
                                Dim tempLa As Integer = 0
                                Dim tempAn As Integer = 0
                                Dim tempAl As Integer = 0
                                Dim sumTotal As Integer = 0
                                Dim cont As Integer = 0
                                Dim contTot As Integer = 0
                                Dim tempPeso As Decimal = 0D
                                Dim tempVolumen As Decimal = 0D
                                Dim tempTempMin As Integer = 0
                                Dim tempTempMax As Integer = 0
                                Dim tempTempPro As Integer = 0
                                Dim tempRx As Integer = 0
                                Dim tempMan As Integer = 0
                                Dim tempK9 As Integer = 0
                                Dim tempEds As Integer = 0
                                Dim TempIdGuia As Guid
                                For Each r2 In ugvCaptura.Rows
                                    If r2.Cells("guia").Value = enc.Guia Then
                                        contTot += 1
                                    End If
                                Next
                                For Each r2 As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvCaptura.Rows
                                    If r2.Cells("guia").Value = enc.Guia Then
                                        If cont = 0 Then
                                            TempIdGuia = r2.Cells("idguia").Value
                                            tempGuia = r2.Cells("guia").Value
                                            tempDae = r2.Cells("dae").Value
                                            tempTotal = r2.Cells("volumen").Value
                                            sumTotal = r2.Cells("piezas").Value
                                            tempLa = r2.Cells("largo").Value
                                            tempAn = r2.Cells("ancho").Value
                                            tempAl = r2.Cells("alto").Value
                                            tempPeso = r2.Cells("peso").Value
                                            tempVolumen = r2.Cells("volumen").Value
                                            tempTempMax = enc.tempMax
                                            tempTempMin = enc.tempMin
                                            tempTempPro = enc.tempPro
                                            If r2.Cells("rx").Value Then
                                                tempRx += 1
                                            End If
                                            If r2.Cells("man").Value Then
                                                tempMan += 1
                                            End If
                                            If r2.Cells("k9").Value Then
                                                tempK9 += 1
                                            End If
                                            If r2.Cells("eds").Value Then
                                                tempEds += 1
                                            End If
                                        Else
                                            If tempTotal = r2.Cells("volumen").Value And tempDae = r2.Cells("dae").Value Then
                                                sumTotal += r2.Cells("piezas").Value
                                                tempPeso += r2.Cells("peso").Value
                                                tempVolumen += r2.Cells("volumen").Value
                                                If r2.Cells("rx").Value Then
                                                    tempRx += 1
                                                End If
                                                If r2.Cells("man").Value Then
                                                    tempMan += 1
                                                End If
                                                If r2.Cells("k9").Value Then
                                                    tempK9 += 1
                                                End If
                                                If r2.Cells("eds").Value Then
                                                    tempEds += 1
                                                End If
                                            Else
                                                Dim nr As DataRow
                                                nr = tblMedidasTemp.NewRow
                                                nr.Item("producto") = enc.Producto
                                                nr.Item("guia") = tempGuia
                                                nr.Item("dae") = tempDae
                                                nr.Item("total") = sumTotal
                                                nr.Item("largo") = tempLa
                                                nr.Item("ancho") = tempAn
                                                nr.Item("alto") = tempAl
                                                nr.Item("piezas") = sumTotal
                                                nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                                nr.Item("Peso") = tempPeso
                                                nr.Item("Volumen") = tempVolumen
                                                nr.Item("tempMax") = tempTempMax
                                                nr.Item("tempMin") = tempTempMin
                                                nr.Item("tempPro") = tempTempPro
                                                nr.Item("Rx") = tempRx
                                                nr.Item("Man") = tempMan
                                                nr.Item("K9") = tempK9
                                                nr.Item("Eds") = tempEds
                                                tblMedidasTemp.Rows.Add(nr)
                                                tempGuia = r2.Cells("guia").Value
                                                TempIdGuia = r2.Cells("idguia").Value
                                                tempDae = r2.Cells("dae").Value
                                                tempTotal = r2.Cells("volumen").Value
                                                sumTotal = r2.Cells("piezas").Value
                                                tempLa = r2.Cells("largo").Value
                                                tempAn = r2.Cells("ancho").Value
                                                tempAl = r2.Cells("alto").Value
                                                tempPeso = r2.Cells("peso").Value
                                                tempVolumen = r2.Cells("volumen").Value
                                                tempTempMax = enc.tempMax
                                                tempTempMin = enc.tempMin
                                                tempTempPro = enc.tempPro
                                                If r2.Cells("rx").Value Then
                                                    tempRx = 1
                                                Else
                                                    tempRx = 0
                                                End If
                                                If r2.Cells("man").Value Then
                                                    tempMan = 1
                                                Else
                                                    tempMan = 0
                                                End If
                                                If r2.Cells("k9").Value Then
                                                    tempK9 = 1
                                                Else
                                                    tempK9 = 0
                                                End If
                                                If r2.Cells("eds").Value Then
                                                    tempEds = 1
                                                Else
                                                    tempEds = 0
                                                End If
                                            End If
                                        End If
                                        cont += 1
                                        If cont = contTot Then
                                            Dim nr As DataRow
                                            nr = tblMedidasTemp.NewRow
                                            nr.Item("producto") = enc.Producto
                                            nr.Item("guia") = tempGuia
                                            nr.Item("dae") = tempDae
                                            nr.Item("total") = sumTotal
                                            nr.Item("largo") = tempLa
                                            nr.Item("ancho") = tempAn
                                            nr.Item("alto") = tempAl
                                            nr.Item("piezas") = sumTotal
                                            nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                            nr.Item("Peso") = tempPeso
                                            nr.Item("Volumen") = tempVolumen
                                            nr.Item("tempMax") = tempTempMax
                                            nr.Item("tempMin") = tempTempMin
                                            nr.Item("tempPro") = tempTempPro
                                            nr.Item("Rx") = tempRx
                                            nr.Item("Man") = tempMan
                                            nr.Item("K9") = tempK9
                                            nr.Item("Eds") = tempEds
                                            tblMedidasTemp.Rows.Add(nr)
                                        End If
                                    End If
                                Next
                                Dim vista As New DataView(tblMedidasTemp)
                                vista.Sort = "sumMedidas, dae"
                                Dim tblMedidas As New DataTable("tblMedidas")
                                With tblMedidas.Columns
                                    .Add("producto", GetType(String))
                                    .Add("guia", GetType(String))
                                    .Add("dae", GetType(String))
                                    .Add("total", GetType(Integer))
                                    .Add("largo", GetType(Integer))
                                    .Add("ancho", GetType(Integer))
                                    .Add("alto", GetType(Integer))
                                    .Add("piezas", GetType(Decimal))
                                    .Add("sumMedidas", GetType(Integer))
                                    .Add("Peso", GetType(Decimal))
                                    .Add("Volumen", GetType(Decimal))
                                    .Add("tempMax", GetType(Decimal))
                                    .Add("tempMin", GetType(Decimal))
                                    .Add("tempPro", GetType(Decimal))
                                    .Add("Rx", GetType(Decimal))
                                    .Add("Man", GetType(Decimal))
                                    .Add("K9", GetType(Decimal))
                                    .Add("Eds", GetType(Decimal))
                                    .Add("Estado", GetType(String))
                                End With
                                Dim contM As Integer = 0
                                Dim tempSum As Integer = 0
                                Dim ultSum As Integer = 0
                                Dim ultDae As String = ""
                                Dim c1 As Integer = 0
                                For Each RowDae As DataRow In vista.ToTable(True, "dae").Rows
                                    Try
                                        dtValidezDae = SearchDAE(RowDae.Item(0))
                                        For Each rowDaeVali As DataRow In dtValidezDae.Rows
                                            For Each rowVista As DataRowView In vista
                                                If rowVista.Item("dae") = RowDae.Item(0) Then
                                                    If IsDBNull(rowDaeVali.Item("ExaminationChannelName")) Then
                                                        rowVista.Item("estado") = "SE"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO AUTOMATICO" Then
                                                        rowVista.Item("estado") = "AA"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Then
                                                        rowVista.Item("estado") = "AF"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                                                        rowVista.Item("estado") = "AD"
                                                    Else
                                                        rowVista.Item("estado") = "VM"
                                                    End If
                                                End If
                                            Next
                                        Next
                                    Catch ex As Exception
                                        For Each rowVista As DataRowView In vista
                                            If rowVista.Item("dae") = RowDae.Item(0) Then
                                                rowVista.Item("estado") = "VM"
                                            End If
                                        Next
                                    End Try
                                Next
                                For Each r3 As DataRowView In vista
                                    Dim c As Integer = 0
                                    Dim t As Integer = 0
                                    Dim p As Decimal = 0D
                                    Dim v As Decimal = 0D
                                    Dim rx As Integer = 0
                                    Dim man As Integer = 0
                                    Dim k9 As Integer = 0
                                    Dim eds As Integer = 0
                                    tempSum = r3.Item("sumMedidas")
                                    tempDae = r3.Item("dae")
                                    If c1 <> 0 Then
                                        If tempSum <> ultSum Then
                                            For Each r2 As DataRowView In vista
                                                If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                    If c = 0 Then
                                                        t = 0
                                                        p = 0D
                                                        v = 0D
                                                        rx = 0
                                                        man = 0
                                                        k9 = 0
                                                        eds = 0
                                                        t = r2.Item("total")
                                                        p = r2.Item("Peso")
                                                        v = r2.Item("Volumen")
                                                        rx = r2.Item("rx")
                                                        man = r2.Item("man")
                                                        k9 = r2.Item("k9")
                                                        eds = r2.Item("eds")
                                                    Else
                                                        t += r2.Item("total")
                                                        p += r2.Item("Peso")
                                                        v += r2.Item("Volumen")
                                                        rx += r2.Item("rx")
                                                        man += r2.Item("man")
                                                        k9 += r2.Item("k9")
                                                        eds += r2.Item("eds")
                                                    End If
                                                    ultSum = r2.Item("sumMedidas")
                                                    ultDae = r2.Item("dae")
                                                    c += 1
                                                End If
                                            Next
                                            c = 0
                                            Dim nr As DataRow
                                            nr = tblMedidas.NewRow
                                            nr.Item("producto") = r3.Item("producto")
                                            nr.Item("guia") = r3.Item("guia")
                                            nr.Item("dae") = r3.Item("dae")
                                            nr.Item("total") = t
                                            nr.Item("largo") = r3.Item("largo")
                                            nr.Item("ancho") = r3.Item("ancho")
                                            nr.Item("alto") = r3.Item("alto")
                                            nr.Item("piezas") = r3.Item("piezas")
                                            nr.Item("Peso") = p
                                            nr.Item("Volumen") = v
                                            nr.Item("tempMax") = r3.Item("tempMax")
                                            nr.Item("tempMin") = r3.Item("tempMin")
                                            nr.Item("tempPro") = r3.Item("tempPro")
                                            nr.Item("Rx") = rx
                                            nr.Item("Man") = man
                                            nr.Item("K9") = k9
                                            nr.Item("Eds") = eds
                                            nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                            tblMedidas.Rows.Add(nr)
                                        Else
                                            If tempDae <> ultDae Then
                                                For Each r2 As DataRowView In vista
                                                    If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                        If c = 0 Then
                                                            t = 0
                                                            p = 0D
                                                            v = 0D
                                                            rx = 0
                                                            man = 0
                                                            k9 = 0
                                                            eds = 0
                                                            t = r2.Item("total")
                                                            p = r2.Item("Peso")
                                                            v = r2.Item("Volumen")
                                                            rx = r2.Item("rx")
                                                            man = r2.Item("man")
                                                            k9 = r2.Item("k9")
                                                            eds = r2.Item("eds")
                                                        Else
                                                            t += r2.Item("total")
                                                            p += r2.Item("Peso")
                                                            v += r2.Item("Volumen")
                                                            rx += r2.Item("rx")
                                                            man += r2.Item("man")
                                                            k9 += r2.Item("k9")
                                                            eds += r2.Item("eds")
                                                        End If
                                                        ultSum = r2.Item("sumMedidas")
                                                        ultDae = r2.Item("dae")
                                                        c += 1
                                                    End If
                                                Next
                                                c = 0
                                                Dim nr As DataRow
                                                nr = tblMedidas.NewRow
                                                nr.Item("producto") = r3.Item("producto")
                                                nr.Item("guia") = r3.Item("guia")
                                                nr.Item("dae") = r3.Item("dae")
                                                nr.Item("total") = t
                                                nr.Item("largo") = r3.Item("largo")
                                                nr.Item("ancho") = r3.Item("ancho")
                                                nr.Item("alto") = r3.Item("alto")
                                                nr.Item("piezas") = r3.Item("piezas")
                                                nr.Item("Peso") = p
                                                nr.Item("Volumen") = v
                                                nr.Item("tempMax") = r3.Item("tempMax")
                                                nr.Item("tempMin") = r3.Item("tempMin")
                                                nr.Item("tempPro") = r3.Item("tempPro")
                                                nr.Item("Rx") = rx
                                                nr.Item("Man") = man
                                                nr.Item("K9") = k9
                                                nr.Item("Eds") = eds
                                                nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                                tblMedidas.Rows.Add(nr)
                                            End If
                                        End If
                                    Else
                                        For Each r2 As DataRowView In vista
                                            If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                If c = 0 Then
                                                    t = 0
                                                    p = 0D
                                                    v = 0D
                                                    rx = 0
                                                    man = 0
                                                    k9 = 0
                                                    eds = 0
                                                    t = r2.Item("total")
                                                    p = r2.Item("Peso")
                                                    v = r2.Item("Volumen")
                                                    rx = r2.Item("rx")
                                                    man = r2.Item("man")
                                                    k9 = r2.Item("k9")
                                                    eds = r2.Item("eds")
                                                Else
                                                    t += r2.Item("total")
                                                    p += r2.Item("Peso")
                                                    v += r2.Item("Volumen")
                                                    rx += r2.Item("rx")
                                                    man += r2.Item("man")
                                                    k9 += r2.Item("k9")
                                                    eds += r2.Item("eds")
                                                End If
                                                ultSum = r2.Item("sumMedidas")
                                                ultDae = r2.Item("dae")
                                                c += 1
                                            End If
                                        Next
                                        c = 0
                                        Dim nr As DataRow
                                        nr = tblMedidas.NewRow
                                        nr.Item("producto") = r3.Item("producto")
                                        nr.Item("guia") = r3.Item("guia")
                                        nr.Item("dae") = r3.Item("dae")
                                        nr.Item("total") = t
                                        nr.Item("largo") = r3.Item("largo")
                                        nr.Item("ancho") = r3.Item("ancho")
                                        nr.Item("alto") = r3.Item("alto")
                                        nr.Item("piezas") = r3.Item("piezas")
                                        nr.Item("Peso") = p
                                        nr.Item("Volumen") = v
                                        nr.Item("tempMax") = r3.Item("tempMax")
                                        nr.Item("tempMin") = r3.Item("tempMin")
                                        nr.Item("tempPro") = r3.Item("tempPro")
                                        nr.Item("Rx") = rx
                                        nr.Item("Man") = man
                                        nr.Item("K9") = k9
                                        nr.Item("Eds") = eds
                                        nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                        tblMedidas.Rows.Add(nr)
                                    End If
                                    c1 += 1
                                Next
                                For Each r3 As DataRow In tblMedidas.Rows
                                    If contM = 10 Then
                                        'Exit For
                                    End If
                                    det = New Detalle
                                    If r3.Item("guia") = enc.Guia Then
                                        det.dae = r3.Item("dae")
                                        det.Producto = r3.Item("producto")
                                        det.alto = r3.Item("alto")
                                        det.ancho = r3.Item("ancho")
                                        det.largo = r3.Item("largo")
                                        det.total = r3.Item("total")
                                        det.piezas = r3.Item("piezas")
                                        det.Peso = r3.Item("Peso")
                                        det.Volumen = r3.Item("Volumen")
                                        det.tempMax = r3.Item("tempMax")
                                        det.tempMin = r3.Item("tempMin")
                                        det.tempPro = r3.Item("tempPro")
                                        det.Rx = r3.Item("Rx")
                                        det.Man = r3.Item("Man")
                                        det.K9 = r3.Item("K9")
                                        det.Eds = r3.Item("Eds")
                                        det.estado = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                        If dtGuiaDaeRem.Rows.Count = 0 Then
                                            For Each reg As DataRow In CommonProcess.GetGuiaDaesPorIdGuia(TempIdGuia).Rows
                                                Dim Registro As DataRow
                                                Registro = dtGuiaDaeRem.NewRow
                                                Registro.Item("idGuia") = reg.Item("idGuia")
                                                Registro.Item("Dae") = reg.Item("dae")
                                                Registro.Item("NumRem") = reg.Item("NumRem")
                                                Registro.Item("FechaVigencia") = reg.Item("fechavigenciaRem")
                                                dtGuiaDaeRem.Rows.Add(Registro)
                                            Next
                                        End If
                                        Dim rows As DataRow()
                                        rows = dtGuiaDaeRem.Select("idGuia='" & TempIdGuia.ToString & "' and Dae='" & r3.Item("dae") & "'")
                                        If rows.Count > 0 Then
                                            For Each reg As DataRow In rows
                                                If reg.Item(2).ToString <> String.Empty Then
                                                    det.NumRem = reg.Item(2)
                                                End If
                                            Next
                                        End If
                                        enc.Detalle.Add(det)
                                    End If
                                    contM += 1
                                Next
                                Dim Mensaje As String = String.Empty
                                For Each RowDetalle As Detalle In enc.Detalle
                                    If RowDetalle.estado <> "AA" Then
                                        If RowDetalle.estado = "AF" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO FISICO INTRUSIVO"
                                        ElseIf RowDetalle.estado = "AD" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO DOCUMENTAL"
                                        ElseIf RowDetalle.estado = "VM" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " lo que indicaque que la DAE no tiene un estado asignado y se debe de VERIFICAR MANUALMENTE el estado."
                                        End If
                                        MessageBox.Show(Mensaje, "ESTADO DE DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                Next
                                For Each RowDetalle As Detalle In enc.Detalle
                                    If RowDetalle.estado <> "AA" Then
                                        If RowDetalle.estado = "AF" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO FISICO INTRUSIVO"
                                        ElseIf RowDetalle.estado = "AD" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO DOCUMENTAL"
                                        ElseIf RowDetalle.estado = "VM" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " lo que indicaque que la DAE no tiene un estado asignado y se debe de VERIFICAR MANUALMENTE el estado."
                                        End If
                                        MessageBox.Show(Mensaje, "ESTADO DE DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                Next
                                Dim Rpt As New RptWareHouse
                                Rpt.enc.Add(enc)
                                Rpt.det = enc.Detalle
                                Rpt.aerolinea = enc.Aerolinea
                                Rpt.idGuia = Guid.Parse(idGuia)
                                Rpt.vuelo = enc.Vuelo
                                Rpt.fecha = enc.Fecha.ToString
                                Rpt.Show()

                            Else

                                Dim enc As New Encabezado
                                Dim det As New Detalle
                                Dim cont2 As Integer = 0
                                idGuia = ugvTotalGuias.ActiveRow.Cells("idGuia").Value
                                GuiaItem = CommonProcess.GetGuiaPorIdGuia(Guid.Parse(idGuia))
                                dtProducto = CommonProcess.GetGuiaProductoPorIdGuia(Guid.Parse(idGuia))
                                dtCamiones = CommonProcess.GetPersonalPorIdProceso(myProceso.IdProceso)
                                GuiaItem.DescripcionProducto = dtProducto.Rows(0).Item("descripcionProducto")
                                enc.estado = "D"
                                enc.Guia = GuiaItem.Descripcion
                                enc.Vuelo = txtNumVuelo.Text
                                enc.Destino = GuiaItem.ciudadDestino
                                enc.Agencia = GuiaItem.DescripcionAgencia
                                Try
                                    enc.AgenciaTransporte = GuiaItem.DescripcionAgencia
                                Catch ex As Exception
                                    ErrorManager.SetLogEvent(ex)
                                End Try
                                enc.Aerolinea = myDetalleVuelo.descripcionAgencia
                                enc.Producto = GuiaItem.DescripcionProducto
                                enc.DAE = GuiaItem.DAE
                                idCamion = ugvTotalGuias.ActiveRow.Cells("idCamion").Value
                                enc.idRecibe = MyCurrentUser.userName
                                Dim tempRecibe As New Server.ReportService.ContactoCatalogItem
                                tempRecibe = CommonData.GetContactoItem(enc.idRecibe)
                                enc.Recibe = tempRecibe.primerApellido + " " + tempRecibe.segundoApellido + " " + tempRecibe.primerNombre
                                enc.Fecha = r.Item("horaInicio")
                                enc.HoraInicio = r.Item("horaInicio")
                                enc.HoraFin = r.Item("horaFin")
                                enc.Bultos = r.Item("totalBultos")
                                enc.Piezas = r.Item("totalPiezas")
                                enc.Alto = r.Item("alto")
                                enc.Ancho = r.Item("ancho")
                                enc.Largo = r.Item("largo")
                                enc.Peso = r.Item("pesoReal")
                                enc.Volumen = r.Item("pesoVolumen")
                                enc.tempMax = r.Item("tempMax")
                                enc.tempMin = r.Item("tempMin")
                                enc.tempPro = r.Item("tempPro")
                                enc.Rx = r.Item("Rx")
                                enc.Man = r.Item("Man")
                                enc.K9 = r.Item("K9")
                                enc.Eds = r.Item("Eds")
                                enc.Observacion = r.Item("observacion").ToString
                                Dim frmPersonalProceso As New frmElegirPersonalProceso
                                frmPersonalProceso.dtPersonal = dtCamiones
                                frmPersonalProceso.tempGuiaItem = GuiaItem
                                frmPersonalProceso.idAerolinea = myDetalleVuelo.idAgencia
                                frmPersonalProceso.ShowDialog()
                                If myDetalleVuelo.idAgencia <> Guid.Parse("78613da6-1277-11e4-981b-8f9d682eafe3") Or myDetalleVuelo.idAgencia <> Guid.Parse("b86b9024-12ac-11e4-981b-8f9d682eafe3") Then
                                    If frmPersonalProceso.isCancel Then
                                        Exit Sub
                                    End If
                                    If Not frmPersonalProceso.isSaved Then
                                        Exit Sub
                                    End If
                                End If
                                Try
                                    enc.idChofer = frmPersonalProceso.personaAgenciaCarga.idContacto
                                    enc.Chofer = frmPersonalProceso.personaAgenciaCarga.primerApellido + " " + frmPersonalProceso.personaAgenciaCarga.segundoApellido + " " + frmPersonalProceso.personaAgenciaCarga.primerNombre
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Chofer")
                                End Try
                                Try
                                    enc.idEnvia = frmPersonalProceso.personaAerolinea.idContacto
                                    enc.Envia = frmPersonalProceso.personaAerolinea.primerApellido + " " + frmPersonalProceso.personaAerolinea.segundoApellido + " " + frmPersonalProceso.personaAerolinea.primerNombre
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Quien Envia")
                                End Try
                                Try
                                    enc.idSeguridad = frmPersonalProceso.personaSeguridad.idContacto
                                    enc.seguridad = frmPersonalProceso.personaSeguridad.primerApellido + " " + frmPersonalProceso.personaSeguridad.segundoApellido + " " + frmPersonalProceso.personaSeguridad.primerNombre
                                    enc.AgenciaSeguridad = frmPersonalProceso.agenciaSeguridad
                                Catch ex As Exception
                                    General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Seguridad")
                                End Try
                                ObtenerProcesoDev()
                                'EnviarInfoSenae(enc.Piezas, enc.Peso, enc.Guia) JCM Cambio en funcion sin peso ni piezas
                                EnviarInfoSenae(enc.Guia) 'EWLM PRUEBAS
                                Dim tblMedidasTemp As New DataTable("dtMedidas")
                                With tblMedidasTemp.Columns
                                    .Add("producto", GetType(String))
                                    .Add("guia", GetType(String))
                                    .Add("dae", GetType(String))
                                    .Add("total", GetType(Integer))
                                    .Add("largo", GetType(Integer))
                                    .Add("ancho", GetType(Integer))
                                    .Add("alto", GetType(Integer))
                                    .Add("piezas", GetType(Decimal))
                                    .Add("sumMedidas", GetType(Integer))
                                    .Add("Peso", GetType(Decimal))
                                    .Add("Volumen", GetType(Decimal))
                                    .Add("tempMax", GetType(Decimal))
                                    .Add("tempMin", GetType(Decimal))
                                    .Add("tempPro", GetType(Decimal))
                                    .Add("Rx", GetType(Decimal))
                                    .Add("Man", GetType(Decimal))
                                    .Add("K9", GetType(Decimal))
                                    .Add("Eds", GetType(Decimal))
                                    .Add("Estado", GetType(String))
                                End With
                                Dim tempGuia As String = ""
                                Dim tempDae As String = ""
                                Dim tempTotal As Double = 0D
                                Dim tempLa As Integer = 0
                                Dim tempAn As Integer = 0
                                Dim tempAl As Integer = 0
                                Dim sumTotal As Integer = 0
                                Dim cont As Integer = 0
                                Dim contTot As Integer = 0
                                Dim tempPeso As Decimal = 0D
                                Dim tempVolumen As Decimal = 0D
                                Dim tempTempMin As Integer = 0
                                Dim tempTempMax As Integer = 0
                                Dim tempTempPro As Integer = 0
                                Dim tempRx As Integer = 0
                                Dim tempMan As Integer = 0
                                Dim tempK9 As Integer = 0
                                Dim tempEds As Integer = 0
                                For Each r3 In dtDetalleProcesoDev.Rows
                                    If r3.Item("guia") = enc.Guia Then
                                        contTot += 1
                                    End If
                                Next
                                For Each r3 As DataRow In dtDetalleProcesoDev.Rows
                                    If r3.Item("guia") = enc.Guia Then
                                        If cont = 0 Then
                                            tempGuia = r3.Item("guia")
                                            tempDae = r3.Item("dae")
                                            tempTotal = r3.Item("volumen")
                                            sumTotal = r3.Item("piezas")
                                            tempLa = r3.Item("largo")
                                            tempAn = r3.Item("ancho")
                                            tempAl = r3.Item("alto")
                                            tempPeso = r3.Item("peso")
                                            tempVolumen = r3.Item("volumen")
                                            tempTempMax = enc.tempMax
                                            tempTempMin = enc.tempMin
                                            tempTempPro = enc.tempPro
                                            If r3.Item("rx") Then
                                                tempRx += 1
                                            End If
                                            If r3.Item("man") Then
                                                tempMan += 1
                                            End If
                                            If r3.Item("k9") Then
                                                tempK9 += 1
                                            End If
                                            If r3.Item("eds") Then
                                                tempEds += 1
                                            End If
                                        Else
                                            If tempTotal = r3.Item("volumen") And tempDae = r3.Item("dae") Then
                                                sumTotal += r3.Item("piezas")
                                                tempPeso += r3.Item("peso")
                                                tempVolumen += r3.Item("volumen")
                                                If r3.Item("rx") Then
                                                    tempRx += 1
                                                End If
                                                If r3.Item("man") Then
                                                    tempMan += 1
                                                End If
                                                If r3.Item("k9") Then
                                                    tempK9 += 1
                                                End If
                                                If r3.Item("eds") Then
                                                    tempEds += 1
                                                End If
                                            Else
                                                Dim nr As DataRow
                                                nr = tblMedidasTemp.NewRow
                                                nr.Item("producto") = enc.Producto
                                                nr.Item("guia") = tempGuia
                                                nr.Item("dae") = tempDae
                                                nr.Item("total") = sumTotal
                                                nr.Item("largo") = tempLa
                                                nr.Item("ancho") = tempAn
                                                nr.Item("alto") = tempAl
                                                nr.Item("piezas") = sumTotal
                                                nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                                nr.Item("Peso") = tempPeso
                                                nr.Item("Volumen") = tempVolumen
                                                nr.Item("tempMax") = tempTempMax
                                                nr.Item("tempMin") = tempTempMin
                                                nr.Item("tempPro") = tempTempPro
                                                nr.Item("Rx") = tempRx
                                                nr.Item("Man") = tempMan
                                                nr.Item("K9") = tempK9
                                                nr.Item("Eds") = tempEds
                                                tblMedidasTemp.Rows.Add(nr)
                                                tempGuia = r3.Item("guia")
                                                tempDae = r3.Item("dae")
                                                tempTotal = r3.Item("volumen")
                                                sumTotal = r3.Item("piezas")
                                                tempLa = r3.Item("largo")
                                                tempAn = r3.Item("ancho")
                                                tempAl = r3.Item("alto")
                                                tempPeso = r3.Item("peso")
                                                tempVolumen = r3.Item("volumen")
                                                tempTempMax = enc.tempMax
                                                tempTempMin = enc.tempMin
                                                tempTempPro = enc.tempPro
                                                If r3.Item("rx") Then
                                                    tempRx = 1
                                                Else
                                                    tempRx = 0
                                                End If
                                                If r3.Item("man") Then
                                                    tempMan = 1
                                                Else
                                                    tempMan = 0
                                                End If
                                                If r3.Item("k9") Then
                                                    tempK9 = 1
                                                Else
                                                    tempK9 = 0
                                                End If
                                                If r3.Item("eds") Then
                                                    tempEds = 1
                                                Else
                                                    tempEds = 0
                                                End If
                                            End If
                                        End If
                                        cont += 1
                                        If cont = contTot Then
                                            Dim nr As DataRow
                                            nr = tblMedidasTemp.NewRow
                                            nr.Item("producto") = enc.Producto
                                            nr.Item("guia") = tempGuia
                                            nr.Item("dae") = tempDae
                                            nr.Item("total") = sumTotal
                                            nr.Item("largo") = tempLa
                                            nr.Item("ancho") = tempAn
                                            nr.Item("alto") = tempAl
                                            nr.Item("piezas") = sumTotal
                                            nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                            nr.Item("Peso") = tempPeso
                                            nr.Item("Volumen") = tempVolumen
                                            nr.Item("tempMax") = tempTempMax
                                            nr.Item("tempMin") = tempTempMin
                                            nr.Item("tempPro") = tempTempPro
                                            nr.Item("Rx") = tempRx
                                            nr.Item("Man") = tempMan
                                            nr.Item("K9") = tempK9
                                            nr.Item("Eds") = tempEds
                                            tblMedidasTemp.Rows.Add(nr)
                                        End If
                                    End If
                                Next
                                Dim vista As New DataView(tblMedidasTemp)
                                vista.Sort = "sumMedidas, dae"
                                Dim tblMedidas As New DataTable("tblMedidas")
                                With tblMedidas.Columns
                                    .Add("producto", GetType(String))
                                    .Add("guia", GetType(String))
                                    .Add("dae", GetType(String))
                                    .Add("total", GetType(Integer))
                                    .Add("largo", GetType(Integer))
                                    .Add("ancho", GetType(Integer))
                                    .Add("alto", GetType(Integer))
                                    .Add("piezas", GetType(Decimal))
                                    .Add("sumMedidas", GetType(Integer))
                                    .Add("Peso", GetType(Decimal))
                                    .Add("Volumen", GetType(Decimal))
                                    .Add("tempMax", GetType(Decimal))
                                    .Add("tempMin", GetType(Decimal))
                                    .Add("tempPro", GetType(Decimal))
                                    .Add("Rx", GetType(Decimal))
                                    .Add("Man", GetType(Decimal))
                                    .Add("K9", GetType(Decimal))
                                    .Add("Eds", GetType(Decimal))
                                    .Add("estado", GetType(String))
                                End With
                                Dim contM As Integer = 0
                                Dim tempSum As Integer = 0
                                Dim ultSum As Integer = 0
                                Dim ultDae As String = ""
                                Dim c1 As Integer = 0
                                For Each RowDae As DataRow In vista.ToTable(True, "dae").Rows
                                    Try
                                        dtValidezDae = SearchDAE(RowDae.Item(0))
                                        For Each rowDaeVali As DataRow In dtValidezDae.Rows
                                            For Each rowVista As DataRowView In vista
                                                If rowVista.Item("dae") = RowDae.Item(0) Then
                                                    If IsDBNull(rowDaeVali.Item("ExaminationChannelName")) Then
                                                        rowVista.Item("estado") = "SE"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO AUTOMATICO" Then
                                                        rowVista.Item("estado") = "AA"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Then
                                                        rowVista.Item("estado") = "AF"
                                                    ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                                                        rowVista.Item("estado") = "AD"
                                                    Else
                                                        rowVista.Item("estado") = "VM"
                                                    End If
                                                End If
                                            Next
                                        Next
                                    Catch ex As Exception
                                        For Each rowVista As DataRowView In vista
                                            If rowVista.Item("dae") = RowDae.Item(0) Then
                                                rowVista.Item("estado") = "VM"
                                            End If
                                        Next
                                    End Try
                                Next
                                For Each r3 As DataRowView In vista
                                    Dim c As Integer = 0
                                    Dim t As Integer = 0
                                    Dim p As Decimal = 0D
                                    Dim v As Decimal = 0D
                                    Dim rx As Integer = 0
                                    Dim man As Integer = 0
                                    Dim k9 As Integer = 0
                                    Dim eds As Integer = 0
                                    tempSum = r3.Item("sumMedidas")
                                    tempDae = r3.Item("dae")
                                    If c1 <> 0 Then
                                        If tempSum <> ultSum Then
                                            For Each r2 As DataRowView In vista
                                                If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                    If c = 0 Then
                                                        t = 0
                                                        p = 0D
                                                        v = 0D
                                                        rx = 0
                                                        man = 0
                                                        k9 = 0
                                                        eds = 0
                                                        t = r2.Item("total")
                                                        p = r2.Item("Peso")
                                                        v = r2.Item("Volumen")
                                                        rx = r2.Item("rx")
                                                        man = r2.Item("man")
                                                        k9 = r2.Item("k9")
                                                        eds = r2.Item("eds")
                                                    Else
                                                        t += r2.Item("total")
                                                        p += r2.Item("Peso")
                                                        v += r2.Item("Volumen")
                                                        rx += r2.Item("rx")
                                                        man += r2.Item("man")
                                                        k9 += r2.Item("k9")
                                                        eds += r2.Item("eds")
                                                    End If
                                                    ultSum = r2.Item("sumMedidas")
                                                    ultDae = r2.Item("dae")
                                                    c += 1
                                                End If
                                            Next
                                            c = 0
                                            Dim nr As DataRow
                                            nr = tblMedidas.NewRow
                                            nr.Item("producto") = r3.Item("producto")
                                            nr.Item("guia") = r3.Item("guia")
                                            nr.Item("dae") = r3.Item("dae")
                                            nr.Item("total") = t
                                            nr.Item("largo") = r3.Item("largo")
                                            nr.Item("ancho") = r3.Item("ancho")
                                            nr.Item("alto") = r3.Item("alto")
                                            nr.Item("piezas") = r3.Item("piezas")
                                            nr.Item("Peso") = p
                                            nr.Item("Volumen") = v
                                            nr.Item("tempMax") = r3.Item("tempMax")
                                            nr.Item("tempMin") = r3.Item("tempMin")
                                            nr.Item("tempPro") = r3.Item("tempPro")
                                            nr.Item("Rx") = rx
                                            nr.Item("Man") = man
                                            nr.Item("K9") = k9
                                            nr.Item("Eds") = eds
                                            nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                            tblMedidas.Rows.Add(nr)
                                        Else
                                            If tempDae <> ultDae Then
                                                For Each r2 As DataRowView In vista
                                                    If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                        If c = 0 Then
                                                            t = 0
                                                            p = 0D
                                                            v = 0D
                                                            rx = 0
                                                            man = 0
                                                            k9 = 0
                                                            eds = 0
                                                            t = r2.Item("total")
                                                            p = r2.Item("Peso")
                                                            v = r2.Item("Volumen")
                                                            rx = r2.Item("rx")
                                                            man = r2.Item("man")
                                                            k9 = r2.Item("k9")
                                                            eds = r2.Item("eds")
                                                        Else
                                                            t += r2.Item("total")
                                                            p += r2.Item("Peso")
                                                            v += r2.Item("Volumen")
                                                            rx += r2.Item("rx")
                                                            man += r2.Item("man")
                                                            k9 += r2.Item("k9")
                                                            eds += r2.Item("eds")
                                                        End If
                                                        ultSum = r2.Item("sumMedidas")
                                                        ultDae = r2.Item("dae")
                                                        c += 1
                                                    End If
                                                Next
                                                c = 0
                                                Dim nr As DataRow
                                                nr = tblMedidas.NewRow
                                                nr.Item("producto") = r3.Item("producto")
                                                nr.Item("guia") = r3.Item("guia")
                                                nr.Item("dae") = r3.Item("dae")
                                                nr.Item("total") = t
                                                nr.Item("largo") = r3.Item("largo")
                                                nr.Item("ancho") = r3.Item("ancho")
                                                nr.Item("alto") = r3.Item("alto")
                                                nr.Item("piezas") = r3.Item("piezas")
                                                nr.Item("Peso") = p
                                                nr.Item("Volumen") = v
                                                nr.Item("tempMax") = r3.Item("tempMax")
                                                nr.Item("tempMin") = r3.Item("tempMin")
                                                nr.Item("tempPro") = r3.Item("tempPro")
                                                nr.Item("Rx") = rx
                                                nr.Item("Man") = man
                                                nr.Item("K9") = k9
                                                nr.Item("Eds") = eds
                                                nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                                tblMedidas.Rows.Add(nr)
                                            End If
                                        End If
                                    Else
                                        For Each r2 As DataRowView In vista
                                            If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                                If c = 0 Then
                                                    t = 0
                                                    p = 0D
                                                    v = 0D
                                                    rx = 0
                                                    man = 0
                                                    k9 = 0
                                                    eds = 0
                                                    t = r2.Item("total")
                                                    p = r2.Item("Peso")
                                                    v = r2.Item("Volumen")
                                                    rx = r2.Item("rx")
                                                    man = r2.Item("man")
                                                    k9 = r2.Item("k9")
                                                    eds = r2.Item("eds")
                                                Else
                                                    t += r2.Item("total")
                                                    p += r2.Item("Peso")
                                                    v += r2.Item("Volumen")
                                                    rx += r2.Item("rx")
                                                    man += r2.Item("man")
                                                    k9 += r2.Item("k9")
                                                    eds += r2.Item("eds")
                                                End If
                                                ultSum = r2.Item("sumMedidas")
                                                ultDae = r2.Item("dae")
                                                c += 1
                                            End If
                                        Next
                                        c = 0
                                        Dim nr As DataRow
                                        nr = tblMedidas.NewRow
                                        nr.Item("producto") = r3.Item("producto")
                                        nr.Item("guia") = r3.Item("guia")
                                        nr.Item("dae") = r3.Item("dae")
                                        nr.Item("total") = t
                                        nr.Item("largo") = r3.Item("largo")
                                        nr.Item("ancho") = r3.Item("ancho")
                                        nr.Item("alto") = r3.Item("alto")
                                        nr.Item("piezas") = r3.Item("piezas")
                                        nr.Item("Peso") = p
                                        nr.Item("Volumen") = v
                                        nr.Item("tempMax") = r3.Item("tempMax")
                                        nr.Item("tempMin") = r3.Item("tempMin")
                                        nr.Item("tempPro") = r3.Item("tempPro")
                                        nr.Item("Rx") = rx
                                        nr.Item("Man") = man
                                        nr.Item("K9") = k9
                                        nr.Item("Eds") = eds
                                        nr.Item("estado") = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                        tblMedidas.Rows.Add(nr)
                                    End If
                                    c1 += 1
                                Next
                                For Each r3 As DataRow In tblMedidas.Rows
                                    If contM = 10 Then
                                        'Exit For
                                    End If
                                    det = New Detalle
                                    If r.Item("guia") = enc.Guia Then
                                        det.volumenpeso = IIf(r3.Item("Volumen") < r3.Item("Peso"), r3.Item("Peso"), r3.Item("Volumen"))
                                        det.dae = r3.Item("dae")
                                        det.Producto = r3.Item("producto")
                                        det.alto = r3.Item("alto")
                                        det.ancho = r3.Item("ancho")
                                        det.largo = r3.Item("largo")
                                        det.total = r3.Item("total")
                                        det.piezas = r3.Item("piezas")
                                        det.Peso = r3.Item("Peso")
                                        det.Volumen = r3.Item("Volumen")
                                        det.tempMax = r3.Item("tempMax")
                                        det.tempMin = r3.Item("tempMin")
                                        det.tempPro = r3.Item("tempPro")
                                        det.Rx = r3.Item("Rx")
                                        det.Man = r3.Item("Man")
                                        det.K9 = r3.Item("K9")
                                        det.Eds = r3.Item("Eds")
                                        det.estado = IIf(IsDBNull(r3.Item("estado")), "VM", r3.Item("estado"))
                                        enc.Detalle.Add(det)
                                    End If
                                    contM += 1
                                Next
                                For Each RowDetalle As Detalle In enc.Detalle
                                    If RowDetalle.estado <> "AA" Then
                                        If RowDetalle.estado = "AF" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO FISICO INTRUSIVO"
                                        ElseIf RowDetalle.estado = "AD" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO DOCUMENTAL"
                                        ElseIf RowDetalle.estado = "VM" Then
                                            Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " lo que indicaque que la DAE no tiene un estado asignado y se debe de VERIFICAR MANUALMENTE el estado."
                                        End If
                                        MessageBox.Show(Mensaje, "ESTADO DE DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End If
                                Next
                                Dim Rpt As New RptWareHouse
                                Rpt.enc.Add(enc)
                                Rpt.det = enc.Detalle
                                Rpt.aerolinea = enc.Aerolinea
                                Rpt.idGuia = Guid.Parse(idGuia)
                                Rpt.vuelo = enc.Vuelo
                                Rpt.fecha = enc.Fecha.ToString
                                Rpt.Show()
                            End If
                        End If
                    Next

                Else

                    Dim enc As New Encabezado
                    Dim det As New Detalle
                    Dim cont2 As Integer = 0
                    idGuia = ugvTotalGuias.ActiveRow.Cells("idGuia").Value
                    GuiaItem = CommonProcess.GetGuiaPorIdGuia(Guid.Parse(idGuia))
                    dtProducto = CommonProcess.GetGuiaProductoPorIdGuia(Guid.Parse(idGuia))
                    dtCamiones = CommonProcess.GetPersonalPorIdProceso(myProceso.IdProceso)
                    GuiaItem.DescripcionProducto = dtProducto.Rows(0).Item("descripcionProducto")
                    enc.estado = "A"
                    enc.Guia = GuiaItem.Descripcion
                    enc.Vuelo = txtNumVuelo.Text
                    enc.Destino = GuiaItem.ciudadDestino
                    enc.Agencia = GuiaItem.DescripcionAgencia
                    Try
                        enc.AgenciaTransporte = GuiaItem.DescripcionAgencia
                    Catch ex As Exception
                        ErrorManager.SetLogEvent(ex)
                    End Try
                    enc.Aerolinea = myDetalleVuelo.descripcionAgencia
                    enc.Producto = GuiaItem.DescripcionProducto
                    enc.DAE = GuiaItem.DAE
                    idCamion = ugvTotalGuias.ActiveRow.Cells("idCamion").Value
                    enc.idRecibe = MyCurrentUser.userName
                    Dim tempRecibe As New Server.ReportService.ContactoCatalogItem
                    tempRecibe = CommonData.GetContactoItem(enc.idRecibe)
                    enc.Recibe = tempRecibe.primerApellido + " " + tempRecibe.segundoApellido + " " + tempRecibe.primerNombre
                    enc.Fecha = ugvTotalGuias.ActiveRow.Cells("horaInicio").Value
                    enc.HoraInicio = ugvTotalGuias.ActiveRow.Cells("horaInicio").Value
                    enc.HoraFin = ugvTotalGuias.ActiveRow.Cells("horaFin").Value
                    enc.Bultos = ugvTotalGuias.ActiveRow.Cells("totalBultos").Value
                    enc.Piezas = ugvTotalGuias.ActiveRow.Cells("totalPiezas").Value
                    enc.Alto = ugvTotalGuias.ActiveRow.Cells("alto").Value
                    enc.Ancho = ugvTotalGuias.ActiveRow.Cells("ancho").Value
                    enc.Largo = ugvTotalGuias.ActiveRow.Cells("largo").Value
                    enc.Peso = ugvTotalGuias.ActiveRow.Cells("pesoReal").Value
                    enc.Volumen = ugvTotalGuias.ActiveRow.Cells("pesoVolumen").Value
                    enc.tempMax = ugvTotalGuias.ActiveRow.Cells("tempMax").Value
                    enc.tempMin = ugvTotalGuias.ActiveRow.Cells("tempMin").Value
                    enc.tempPro = ugvTotalGuias.ActiveRow.Cells("tempPro").Value
                    enc.Rx = ugvTotalGuias.ActiveRow.Cells("Rx").Value
                    enc.Man = ugvTotalGuias.ActiveRow.Cells("Man").Value
                    enc.K9 = ugvTotalGuias.ActiveRow.Cells("K9").Value
                    enc.Eds = ugvTotalGuias.ActiveRow.Cells("Eds").Value
                    enc.Observacion = ugvTotalGuias.ActiveRow.Cells("observacion").Value.ToString
                    Dim frmPersonalProceso As New frmElegirPersonalProceso
                    frmPersonalProceso.dtPersonal = dtCamiones
                    frmPersonalProceso.tempGuiaItem = GuiaItem
                    frmPersonalProceso.idAerolinea = myDetalleVuelo.idAgencia
                    frmPersonalProceso.ShowDialog()
                    If myDetalleVuelo.idAgencia <> Guid.Parse("78613da6-1277-11e4-981b-8f9d682eafe3") Or myDetalleVuelo.idAgencia <> Guid.Parse("b86b9024-12ac-11e4-981b-8f9d682eafe3") Then
                        If frmPersonalProceso.isCancel Then
                            Exit Sub
                        End If
                        If Not frmPersonalProceso.isSaved Then
                            Exit Sub
                        End If
                    End If
                    Try
                        enc.idChofer = frmPersonalProceso.personaAgenciaCarga.idContacto
                        enc.Chofer = frmPersonalProceso.personaAgenciaCarga.primerApellido + " " + frmPersonalProceso.personaAgenciaCarga.segundoApellido + " " + frmPersonalProceso.personaAgenciaCarga.primerNombre
                    Catch ex As Exception
                        General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Chofer")
                    End Try
                    Try
                        enc.idEnvia = frmPersonalProceso.personaAerolinea.idContacto
                        enc.Envia = frmPersonalProceso.personaAerolinea.primerApellido + " " + frmPersonalProceso.personaAerolinea.segundoApellido + " " + frmPersonalProceso.personaAerolinea.primerNombre
                    Catch ex As Exception
                        General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Quien Envia")
                    End Try
                    Try
                        enc.idSeguridad = frmPersonalProceso.personaSeguridad.idContacto
                        enc.seguridad = frmPersonalProceso.personaSeguridad.primerApellido + " " + frmPersonalProceso.personaSeguridad.segundoApellido + " " + frmPersonalProceso.personaSeguridad.primerNombre
                        enc.AgenciaSeguridad = frmPersonalProceso.agenciaSeguridad
                    Catch ex As Exception
                        General.SetLogEvent(ex, "ugvTotalGuias_DoubleClickCell Seguridad")
                    End Try
                    ObtenerProceso2()
                    'EnviarInfoSenae(enc.Piezas, enc.Peso, enc.Guia) JCM Cambio en Funcion, sin peso ni piezas
                    EnviarInfoSenae(enc.Guia) 'EWLM PRUEBAS
                    Dim tblMedidasTemp As New DataTable("dtMedidas")
                    With tblMedidasTemp.Columns
                        .Add("producto", GetType(String))
                        .Add("guia", GetType(String))
                        .Add("dae", GetType(String))
                        .Add("total", GetType(Integer))
                        .Add("largo", GetType(Integer))
                        .Add("ancho", GetType(Integer))
                        .Add("alto", GetType(Integer))
                        .Add("piezas", GetType(Decimal))
                        .Add("sumMedidas", GetType(Integer))
                        .Add("Peso", GetType(Decimal))
                        .Add("Volumen", GetType(Decimal))
                        .Add("tempMax", GetType(Decimal))
                        .Add("tempMin", GetType(Decimal))
                        .Add("tempPro", GetType(Decimal))
                        .Add("Rx", GetType(Decimal))
                        .Add("Man", GetType(Decimal))
                        .Add("K9", GetType(Decimal))
                        .Add("Eds", GetType(Decimal))
                        .Add("Estado", GetType(String))
                    End With
                    Dim tempGuia As String = ""
                    Dim tempDae As String = ""
                    Dim tempTotal As Double = 0D
                    Dim tempLa As Integer = 0
                    Dim tempAn As Integer = 0
                    Dim tempAl As Integer = 0
                    Dim sumTotal As Integer = 0
                    Dim cont As Integer = 0
                    Dim contTot As Integer = 0
                    Dim tempPeso As Decimal = 0D
                    Dim tempVolumen As Decimal = 0D
                    Dim tempTempMin As Integer = 0
                    Dim tempTempMax As Integer = 0
                    Dim tempTempPro As Integer = 0
                    Dim tempRx As Integer = 0
                    Dim tempMan As Integer = 0
                    Dim tempK9 As Integer = 0
                    Dim tempEds As Integer = 0
                    Dim TempIdGuia As Guid
                    For Each r In ugvCaptura.Rows
                        If r.Cells("guia").Value = enc.Guia Then
                            contTot += 1
                        End If
                    Next
                    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvCaptura.Rows
                        If r.Cells("guia").Value = enc.Guia Then
                            If cont = 0 Then
                                TempIdGuia = r.Cells("idguia").Value
                                tempGuia = r.Cells("guia").Value
                                tempDae = r.Cells("dae").Value
                                tempTotal = r.Cells("volumen").Value
                                sumTotal = r.Cells("piezas").Value
                                tempLa = r.Cells("largo").Value
                                tempAn = r.Cells("ancho").Value
                                tempAl = r.Cells("alto").Value
                                tempPeso = r.Cells("peso").Value
                                tempVolumen = r.Cells("volumen").Value
                                tempTempMax = enc.tempMax
                                tempTempMin = enc.tempMin
                                tempTempPro = enc.tempPro
                                If r.Cells("rx").Value Then
                                    tempRx += 1
                                End If
                                If r.Cells("man").Value Then
                                    tempMan += 1
                                End If
                                If r.Cells("k9").Value Then
                                    tempK9 += 1
                                End If
                                If r.Cells("eds").Value Then
                                    tempEds += 1
                                End If
                            Else
                                If tempTotal = r.Cells("volumen").Value And tempDae = r.Cells("dae").Value Then
                                    sumTotal += r.Cells("piezas").Value
                                    tempPeso += r.Cells("peso").Value
                                    tempVolumen += r.Cells("volumen").Value
                                    If r.Cells("rx").Value Then
                                        tempRx += 1
                                    End If
                                    If r.Cells("man").Value Then
                                        tempMan += 1
                                    End If
                                    If r.Cells("k9").Value Then
                                        tempK9 += 1
                                    End If
                                    If r.Cells("eds").Value Then
                                        tempEds += 1
                                    End If
                                Else
                                    Dim nr As DataRow
                                    nr = tblMedidasTemp.NewRow
                                    nr.Item("producto") = enc.Producto
                                    nr.Item("guia") = tempGuia
                                    nr.Item("dae") = tempDae
                                    nr.Item("total") = sumTotal
                                    nr.Item("largo") = tempLa
                                    nr.Item("ancho") = tempAn
                                    nr.Item("alto") = tempAl
                                    nr.Item("piezas") = sumTotal
                                    nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                    nr.Item("Peso") = tempPeso
                                    nr.Item("Volumen") = tempVolumen
                                    nr.Item("tempMax") = tempTempMax
                                    nr.Item("tempMin") = tempTempMin
                                    nr.Item("tempPro") = tempTempPro
                                    nr.Item("Rx") = tempRx
                                    nr.Item("Man") = tempMan
                                    nr.Item("K9") = tempK9
                                    nr.Item("Eds") = tempEds
                                    tblMedidasTemp.Rows.Add(nr)
                                    tempGuia = r.Cells("guia").Value
                                    TempIdGuia = r.Cells("idguia").Value
                                    tempDae = r.Cells("dae").Value
                                    tempTotal = r.Cells("volumen").Value
                                    sumTotal = r.Cells("piezas").Value
                                    tempLa = r.Cells("largo").Value
                                    tempAn = r.Cells("ancho").Value
                                    tempAl = r.Cells("alto").Value
                                    tempPeso = r.Cells("peso").Value
                                    tempVolumen = r.Cells("volumen").Value
                                    tempTempMax = enc.tempMax
                                    tempTempMin = enc.tempMin
                                    tempTempPro = enc.tempPro
                                    If r.Cells("rx").Value Then
                                        tempRx = 1
                                    Else
                                        tempRx = 0
                                    End If
                                    If r.Cells("man").Value Then
                                        tempMan = 1
                                    Else
                                        tempMan = 0
                                    End If
                                    If r.Cells("k9").Value Then
                                        tempK9 = 1
                                    Else
                                        tempK9 = 0
                                    End If
                                    If r.Cells("eds").Value Then
                                        tempEds = 1
                                    Else
                                        tempEds = 0
                                    End If
                                End If
                            End If
                            cont += 1
                            If cont = contTot Then
                                Dim nr As DataRow
                                nr = tblMedidasTemp.NewRow
                                nr.Item("producto") = enc.Producto
                                nr.Item("guia") = tempGuia
                                nr.Item("dae") = tempDae
                                nr.Item("total") = sumTotal
                                nr.Item("largo") = tempLa
                                nr.Item("ancho") = tempAn
                                nr.Item("alto") = tempAl
                                nr.Item("piezas") = sumTotal
                                nr.Item("sumMedidas") = tempAl * tempAn * tempLa
                                nr.Item("Peso") = tempPeso
                                nr.Item("Volumen") = tempVolumen
                                nr.Item("tempMax") = tempTempMax
                                nr.Item("tempMin") = tempTempMin
                                nr.Item("tempPro") = tempTempPro
                                nr.Item("Rx") = tempRx
                                nr.Item("Man") = tempMan
                                nr.Item("K9") = tempK9
                                nr.Item("Eds") = tempEds
                                tblMedidasTemp.Rows.Add(nr)
                            End If
                        End If
                    Next
                    Dim vista As New DataView(tblMedidasTemp)
                    vista.Sort = "sumMedidas, dae"
                    Dim tblMedidas As New DataTable("tblMedidas")
                    With tblMedidas.Columns
                        .Add("producto", GetType(String))
                        .Add("guia", GetType(String))
                        .Add("dae", GetType(String))
                        .Add("total", GetType(Integer))
                        .Add("largo", GetType(Integer))
                        .Add("ancho", GetType(Integer))
                        .Add("alto", GetType(Integer))
                        .Add("piezas", GetType(Decimal))
                        .Add("sumMedidas", GetType(Integer))
                        .Add("Peso", GetType(Decimal))
                        .Add("Volumen", GetType(Decimal))
                        .Add("tempMax", GetType(Decimal))
                        .Add("tempMin", GetType(Decimal))
                        .Add("tempPro", GetType(Decimal))
                        .Add("Rx", GetType(Decimal))
                        .Add("Man", GetType(Decimal))
                        .Add("K9", GetType(Decimal))
                        .Add("Eds", GetType(Decimal))
                        .Add("Estado", GetType(String))
                    End With
                    Dim contM As Integer = 0
                    Dim tempSum As Integer = 0
                    Dim ultSum As Integer = 0
                    Dim ultDae As String = ""
                    Dim c1 As Integer = 0
                    For Each RowDae As DataRow In vista.ToTable(True, "dae").Rows
                        Try
                            dtValidezDae = SearchDAE(RowDae.Item(0))
                            For Each rowDaeVali As DataRow In dtValidezDae.Rows
                                For Each rowVista As DataRowView In vista
                                    If rowVista.Item("dae") = RowDae.Item(0) Then
                                        If IsDBNull(rowDaeVali.Item("ExaminationChannelName")) Then
                                            rowVista.Item("estado") = "SE"
                                        ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO AUTOMATICO" Then
                                            rowVista.Item("estado") = "AA"
                                        ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Then
                                            rowVista.Item("estado") = "AF"
                                        ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                                            rowVista.Item("estado") = "AD"
                                        Else
                                            rowVista.Item("estado") = "VM"
                                        End If
                                    End If
                                Next
                            Next
                        Catch ex As Exception
                            For Each rowVista As DataRowView In vista
                                If rowVista.Item("dae") = RowDae.Item(0) Then
                                    rowVista.Item("estado") = "VM"
                                End If
                            Next
                        End Try
                    Next
                    For Each r As DataRowView In vista
                        Dim c As Integer = 0
                        Dim t As Integer = 0
                        Dim p As Decimal = 0D
                        Dim v As Decimal = 0D
                        Dim rx As Integer = 0
                        Dim man As Integer = 0
                        Dim k9 As Integer = 0
                        Dim eds As Integer = 0
                        tempSum = r.Item("sumMedidas")
                        tempDae = r.Item("dae")
                        If c1 <> 0 Then
                            If tempSum <> ultSum Then
                                For Each r2 As DataRowView In vista
                                    If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                        If c = 0 Then
                                            t = 0
                                            p = 0D
                                            v = 0D
                                            rx = 0
                                            man = 0
                                            k9 = 0
                                            eds = 0
                                            t = r2.Item("total")
                                            p = r2.Item("Peso")
                                            v = r2.Item("Volumen")
                                            rx = r2.Item("rx")
                                            man = r2.Item("man")
                                            k9 = r2.Item("k9")
                                            eds = r2.Item("eds")
                                        Else
                                            t += r2.Item("total")
                                            p += r2.Item("Peso")
                                            v += r2.Item("Volumen")
                                            rx += r2.Item("rx")
                                            man += r2.Item("man")
                                            k9 += r2.Item("k9")
                                            eds += r2.Item("eds")
                                        End If
                                        ultSum = r2.Item("sumMedidas")
                                        ultDae = r2.Item("dae")
                                        c += 1
                                    End If
                                Next
                                c = 0
                                Dim nr As DataRow
                                nr = tblMedidas.NewRow
                                nr.Item("producto") = r.Item("producto")
                                nr.Item("guia") = r.Item("guia")
                                nr.Item("dae") = r.Item("dae")
                                nr.Item("total") = t
                                nr.Item("largo") = r.Item("largo")
                                nr.Item("ancho") = r.Item("ancho")
                                nr.Item("alto") = r.Item("alto")
                                nr.Item("piezas") = r.Item("piezas")
                                nr.Item("Peso") = p
                                nr.Item("Volumen") = v
                                nr.Item("tempMax") = r.Item("tempMax")
                                nr.Item("tempMin") = r.Item("tempMin")
                                nr.Item("tempPro") = r.Item("tempPro")
                                nr.Item("Rx") = rx
                                nr.Item("Man") = man
                                nr.Item("K9") = k9
                                nr.Item("Eds") = eds
                                nr.Item("estado") = IIf(IsDBNull(r.Item("estado")), "VM", r.Item("estado"))
                                tblMedidas.Rows.Add(nr)
                            Else
                                If tempDae <> ultDae Then
                                    For Each r2 As DataRowView In vista
                                        If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                            If c = 0 Then
                                                t = 0
                                                p = 0D
                                                v = 0D
                                                rx = 0
                                                man = 0
                                                k9 = 0
                                                eds = 0
                                                t = r2.Item("total")
                                                p = r2.Item("Peso")
                                                v = r2.Item("Volumen")
                                                rx = r2.Item("rx")
                                                man = r2.Item("man")
                                                k9 = r2.Item("k9")
                                                eds = r2.Item("eds")
                                            Else
                                                t += r2.Item("total")
                                                p += r2.Item("Peso")
                                                v += r2.Item("Volumen")
                                                rx += r2.Item("rx")
                                                man += r2.Item("man")
                                                k9 += r2.Item("k9")
                                                eds += r2.Item("eds")
                                            End If
                                            ultSum = r2.Item("sumMedidas")
                                            ultDae = r2.Item("dae")
                                            c += 1
                                        End If
                                    Next
                                    c = 0
                                    Dim nr As DataRow
                                    nr = tblMedidas.NewRow
                                    nr.Item("producto") = r.Item("producto")
                                    nr.Item("guia") = r.Item("guia")
                                    nr.Item("dae") = r.Item("dae")
                                    nr.Item("total") = t
                                    nr.Item("largo") = r.Item("largo")
                                    nr.Item("ancho") = r.Item("ancho")
                                    nr.Item("alto") = r.Item("alto")
                                    nr.Item("piezas") = r.Item("piezas")
                                    nr.Item("Peso") = p
                                    nr.Item("Volumen") = v
                                    nr.Item("tempMax") = r.Item("tempMax")
                                    nr.Item("tempMin") = r.Item("tempMin")
                                    nr.Item("tempPro") = r.Item("tempPro")
                                    nr.Item("Rx") = rx
                                    nr.Item("Man") = man
                                    nr.Item("K9") = k9
                                    nr.Item("Eds") = eds
                                    nr.Item("estado") = IIf(IsDBNull(r.Item("estado")), "VM", r.Item("estado"))
                                    tblMedidas.Rows.Add(nr)
                                End If
                            End If
                        Else
                            For Each r2 As DataRowView In vista
                                If tempSum = r2.Item("sumMedidas") And tempDae = r2.Item("dae") Then
                                    If c = 0 Then
                                        t = 0
                                        p = 0D
                                        v = 0D
                                        rx = 0
                                        man = 0
                                        k9 = 0
                                        eds = 0
                                        t = r2.Item("total")
                                        p = r2.Item("Peso")
                                        v = r2.Item("Volumen")
                                        rx = r2.Item("rx")
                                        man = r2.Item("man")
                                        k9 = r2.Item("k9")
                                        eds = r2.Item("eds")
                                    Else
                                        t += r2.Item("total")
                                        p += r2.Item("Peso")
                                        v += r2.Item("Volumen")
                                        rx += r2.Item("rx")
                                        man += r2.Item("man")
                                        k9 += r2.Item("k9")
                                        eds += r2.Item("eds")
                                    End If
                                    ultSum = r2.Item("sumMedidas")
                                    ultDae = r2.Item("dae")
                                    c += 1
                                End If
                            Next
                            c = 0
                            Dim nr As DataRow
                            nr = tblMedidas.NewRow
                            nr.Item("producto") = r.Item("producto")
                            nr.Item("guia") = r.Item("guia")
                            nr.Item("dae") = r.Item("dae")
                            nr.Item("total") = t
                            nr.Item("largo") = r.Item("largo")
                            nr.Item("ancho") = r.Item("ancho")
                            nr.Item("alto") = r.Item("alto")
                            nr.Item("piezas") = r.Item("piezas")
                            nr.Item("Peso") = p
                            nr.Item("Volumen") = v
                            nr.Item("tempMax") = r.Item("tempMax")
                            nr.Item("tempMin") = r.Item("tempMin")
                            nr.Item("tempPro") = r.Item("tempPro")
                            nr.Item("Rx") = rx
                            nr.Item("Man") = man
                            nr.Item("K9") = k9
                            nr.Item("Eds") = eds
                            nr.Item("estado") = IIf(IsDBNull(r.Item("estado")), "VM", r.Item("estado"))
                            tblMedidas.Rows.Add(nr)
                        End If
                        c1 += 1
                    Next
                    For Each r As DataRow In tblMedidas.Rows
                        If contM = 10 Then
                            'Exit For
                        End If
                        det = New Detalle
                        If r.Item("guia") = enc.Guia Then
                            det.volumenpeso = IIf(r.Item("Volumen") < r.Item("Peso"), r.Item("Peso"), r.Item("Volumen"))  'no devolucion
                            det.dae = r.Item("dae")
                            det.Producto = r.Item("producto")
                            det.alto = r.Item("alto")
                            det.ancho = r.Item("ancho")
                            det.largo = r.Item("largo")
                            det.total = r.Item("total")
                            det.piezas = r.Item("piezas")
                            det.Peso = r.Item("Peso")
                            det.Volumen = r.Item("Volumen")
                            det.tempMax = r.Item("tempMax")
                            det.tempMin = r.Item("tempMin")
                            det.tempPro = r.Item("tempPro")
                            det.Rx = r.Item("Rx")
                            det.Man = r.Item("Man")
                            det.K9 = r.Item("K9")
                            det.Eds = r.Item("Eds")
                            det.estado = IIf(IsDBNull(r.Item("estado")), "VM", r.Item("estado"))
                            'det.valor = r.WValor
                            'TempIdGuia = r.Cells("idguia").Value
                            'dtValidezDae = SearchDAE(txtDae.Text)

                            If dtGuiaDaeRem.Rows.Count = 0 Then
                                For Each reg As DataRow In CommonProcess.GetGuiaDaesPorIdGuia(TempIdGuia).Rows
                                    Dim Registro As DataRow
                                    Registro = dtGuiaDaeRem.NewRow
                                    Registro.Item("idGuia") = reg.Item("idGuia")
                                    Registro.Item("Dae") = reg.Item("dae")
                                    Registro.Item("NumRem") = reg.Item("NumRem")
                                    Registro.Item("FechaVigencia") = reg.Item("fechavigenciaRem")
                                    dtGuiaDaeRem.Rows.Add(Registro)
                                Next
                            End If
                            Dim rows As DataRow()
                            rows = dtGuiaDaeRem.Select("idGuia='" & TempIdGuia.ToString & "' and Dae='" & r.Item("dae") & "'")
                            If rows.Count > 0 Then
                                For Each reg As DataRow In rows
                                    If reg.Item(2).ToString <> String.Empty Then
                                        det.NumRem = reg.Item(2)
                                    End If
                                Next
                            End If
                            enc.Detalle.Add(det)
                        End If
                        contM += 1
                    Next
                    For Each RowDetalle As Detalle In enc.Detalle
                        If RowDetalle.estado <> "AA" Then
                            If RowDetalle.estado = "AF" Then
                                Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO FISICO INTRUSIVO"
                            ElseIf RowDetalle.estado = "AD" Then
                                Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " Correspondiente a un AFORO DOCUMENTAL"
                            ElseIf RowDetalle.estado = "VM" Then
                                Mensaje = "La DAE: " & RowDetalle.dae & " de la GUIA: " & enc.Guia & " se encuentra con un estado: " & RowDetalle.estado & " lo que indicaque que la DAE no tiene un estado asignado y se debe de VERIFICAR MANUALMENTE el estado."
                            End If
                            MessageBox.Show(Mensaje, "ESTADO DE DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Next
                    Dim Rpt As New RptWareHouse
                    Rpt.enc.Add(enc)
                    Rpt.det = enc.Detalle
                    Rpt.aerolinea = enc.Aerolinea
                    Rpt.idGuia = Guid.Parse(idGuia)
                    Rpt.vuelo = enc.Vuelo
                    Rpt.fecha = enc.Fecha.ToString
                    Rpt.Show()
                End If
            End If
            If e.Cell.Column Is ugvTotalGuias.DisplayLayout.Bands(0).Columns("observacion") Then
                ugvTotalGuias.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function sortDataTable(ByVal dTable As DataTable) As DataTable
        Dim dView As New DataView(dTable)
        dView.Sort = "sumMedidas"
        Return dTable
    End Function

    Private Sub txtPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeso.KeyDown
        Dim bultos As Integer = 0
        Dim piezas As Integer
        Dim val As Double = 0D
        Dim bitacora As New Stopwatch()
        Dim bitacora2 As New Stopwatch()
        LsBandeAct = "N"
        Try
            If Not ChkPes.Checked Then
                Exit Sub
            End If
            If My.Settings.LoginEmpr = 2 Then
                If e.KeyValue = Keys.Return Then


                    If Me.txtcodSello.Text = "" Then
                        Me.txtcodSello.Focus()
                        Exit Sub
                    End If

                    If Me.txtnumSaca.Text = "" Then
                        Me.txtnumSaca.Focus()
                        Exit Sub
                    End If


                End If
            End If

            Select Case e.KeyValue
                Case Keys.F1
                    piezas = 1
                    cantBultos = 1
                Case Keys.Return
                    piezas = cantBultos
                Case Keys.F2
                    piezas = 2
                    cantBultos = 2
                Case Keys.F3
                    piezas = 3
                    cantBultos = 3
                Case Keys.F4
                    piezas = 4
                    cantBultos = 4
                Case Keys.F5
                    piezas = 5
                    cantBultos = 5
                Case Keys.F6
                    piezas = 6
                    cantBultos = 6
                Case Keys.F7
                    piezas = 7
                    cantBultos = 7
                Case Keys.F8
                    piezas = 8
                    cantBultos = 8
                Case Keys.F9
                    piezas = 9
                    cantBultos = 9
                Case Keys.F10
                    piezas = 10
                    cantBultos = 10
                Case Keys.F11
                    piezas = 11
                    cantBultos = 11
                Case Keys.F12
                    Dim strPiezas As String = String.Empty
                    Do Until IsNumeric(strPiezas)
                        strPiezas = InputBox("Ingrese la cantidad de piezas", "Piezas")
                    Loop
                    piezas = strPiezas
                    'piezas = 12
                Case Else
                    Exit Sub
            End Select
            If piezas > 0 Then
                If Double.TryParse(txtPeso.Text, val) Then
                    If Double.Parse(txtPeso.Text) > 0 Then
                        SaveCaptura(bultos, piezas)
                    End If
                    txtPeso.Text = 0
                End If
            End If
            CalcularTotales()
            txtPeso.SelectAll()
            ModuloCierre.InicioEjecucion = Date.Now
            'Timer1.Enabled = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub IntentarCaptura()
        Dim piezas As Integer = 1
        Dim bultos As Integer = 1
        Dim val As Double = 0D
        If Not ChkPes.Checked Then
            Exit Sub
        End If
        piezas = cantBultos
        If piezas > 0 Then
            If Double.TryParse(txtPeso.Text, val) Then
                If Double.Parse(txtPeso.Text) > 0 Then
                    SaveCaptura(bultos, piezas)
                End If
                'txtPeso.Text = 0
            End If
        End If

        CalcularTotales()
        'SaveElementoProceso()
        txtPeso.SelectAll()
        'Timer1.Enabled = True
        'isEnableConsultaProceso = True
    End Sub

    Public Function NumeroDec(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As Infragistics.Win.UltraWinEditors.UltraTextEditor) As Integer
        Dim dig As Integer = Len(Text.Text & e.KeyChar)
        Dim a, esDecimal, NumDecimales As Integer
        Dim esDec As Boolean
        Try

            ' se verifica si es un digito o un punto 
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return a
            Else
                e.Handled = True
            End If
            ' se verifica que el primer digito ingresado no sea un punto al seleccionar
            If Text.SelectedText <> "" Then
                If e.KeyChar = "." Then
                    e.Handled = True
                    Return a
                End If
            End If
            If dig = 1 And e.KeyChar = "." Then
                e.Handled = True
                Return a
            End If
            'aqui se hace la verificacion cuando es seleccionado el valor del texto
            'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
            If Text.SelectedText = "" Then
                ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
                For a = 0 To dig - 1
                    Dim car As String = CStr(Text.Text & e.KeyChar)
                    If car.Substring(a, 1) = "." Then
                        esDecimal = esDecimal + 1
                        esDec = True
                    End If
                    If esDec = True Then
                        NumDecimales = NumDecimales + 1
                    End If
                    ' aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales 
                    If NumDecimales >= 4 Or esDecimal >= 2 Then
                        e.Handled = True
                    End If
                Next
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
        Return a
    End Function

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
        NumeroDec(e, txtPeso)
    End Sub

    Private Sub SaveElementoProceso()
        For Each r As DataRow In dtTotalElementos.Rows
            Dim result As Boolean = False
            Dim req As New ProcesoRequest
            Dim res As New ProcesoResponse
            Dim WsClnt As New ProcesoServiceSoapClient
            Try
                dtElementoProceso = CommonProcess.GetElementoProcesoPorIdProcesoIdElemento(myProceso.IdProceso, r.Item("elemento"))
                If Not IsNothing(dtElementoProceso) Then
                    If dtElementoProceso.Rows.Count > 0 Then
                        For Each r2 As DataRow In dtElementoProceso.Rows
                            myElementoProceso.indice = r2.Item("indice")
                            Exit For
                        Next
                    Else
                        myElementoProceso.indice = Guid.NewGuid
                    End If
                Else
                    myElementoProceso.indice = Guid.NewGuid
                End If
                myElementoProceso.idElemento = r.Item("elemento")
                Dim tempElemento As New Server.ReportService.ElementoCatalogItem
                tempElemento = CommonData.GetElementoItem(myElementoProceso.idElemento)
                myElementoProceso.pesoReferencialElemento = tempElemento.pesoReferencial
                myElementoProceso.pesoEntradaElemento = tempElemento.pesoReal
                myElementoProceso.IdProceso = myProceso.IdProceso
                myElementoProceso.fecha = myDetalleProceso.fecha
                myElementoProceso.pesoCaptura = r.Item("pesoReal")
                myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                General.SetBARequest(req)
                req.myElementoProcesoItem = myElementoProceso
                res = WsClnt.SaveElementoProcesoItem(req)
                If res.ActionResult Then
                    result = True
                    SaveEstadoElemento()
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Catch ex As Exception
                ErrorManager.SetLogEvent(ex, res, req)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    Private Function validaInfoTerminaProceso() As Boolean
        Dim result As Boolean = True
        Try
            If ugvPersonal.Rows.Count <> 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvPersonal.Rows
                    If r.Cells("horaSalida").Value = Date.Parse("00:00:00") Then
                        result = False
                    End If
                Next
            End If
            If Not result Then
                MessageBox.Show("Debe Ingresar hora de salida de todo el personal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub SaveEstadoElemento()
        For Each r As DataRow In dtTotalElementos.Rows
            Dim result As Boolean = False
            Dim req As New Server.ReportService.ElementoRequest
            Dim res As New Server.ReportService.ElementoResponse
            Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
            Try
                myElemento.Id = r.Item("elemento")
                myElemento.estado = "C"
                General.SetBARequest(req)
                req.myElementoItem = myElemento
                res = WsClnt.SaveEstadoElemento(req)
                If res.ActionResult Then
                    result = True
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Catch ex As Exception
                ErrorManager.SetLogEvent(ex, res, req)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    Private Sub btnDesactivB_Click(sender As Object, e As EventArgs) Handles btnDesactivB.Click
        Dim frmCheck As New frmCheckUserManager
        frmCheck.ShowDialog()
        Try
            If Not frmCheck.result Then
                Exit Sub
            End If
            Dim usuarioPermiso As New Server.ReportService.ContactoCatalogItem
            usuarioPermiso = CommonData.GetContactoItem(frmCheck.tempUserManager.userName)
            usuarioRequiere = CommonData.GetContactoItem(MyCurrentUser.userName)
            If btnDesactivB.Tag = "A" Then
                balanzaIsActive = False
                btnDesactivB.Text = "Activar Balanza"
                btnDesactivB.Tag = "I"
                EnviarReporteCheckUserManager("Desactivar Balanza", usuarioPermiso, usuarioRequiere)
            Else
                balanzaIsActive = True
                btnDesactivB.Text = "Desactivar Balanza"
                btnDesactivB.Tag = "A"
                EnviarReporteCheckUserManager("Activar Balanza", usuarioPermiso, usuarioRequiere)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub EnviarReporteCheckUserManager(tipoDePermiso As String, usuarioPermiso As Server.ReportService.ContactoCatalogItem, usuarioRequiere As Server.ReportService.ContactoCatalogItem)
        Try
            Dim dest As New DataTable("destinatarios")
            Dim contRowDest As Integer = 0
            Dim destinatarios As String = String.Empty
            Dim msj As String = String.Empty
            Dim nombreUsuarioPer As String = String.Empty
            Dim nombreUsuarioReq As String = String.Empty

            dest = CommonData.GetDestinatariosPorIdReporte(5)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            nombreUsuarioPer = usuarioPermiso.primerApellido & " " & usuarioPermiso.segundoApellido & " " & usuarioPermiso.primerNombre
            nombreUsuarioReq = usuarioRequiere.primerApellido & " " & usuarioRequiere.segundoApellido & " " & usuarioRequiere.primerNombre
            msj = "Admini: " & nombreUsuarioPer & " con C.I. " & usuarioPermiso.idContacto & vbCrLf _
                                       & "Autoriza a: " & nombreUsuarioReq & " con C.I. " & usuarioRequiere.idContacto & vbCrLf _
                                       & "A: " & tipoDePermiso.ToUpper & vbCrLf _
                                       & "Vuelo: " & resDtVuelo.codigoVuelo.ToUpper & IIf(uceGuias.Text <> String.Empty, " Guia: " & uceGuias.Text.ToUpper, "") & vbCrLf _
                                       & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje."
            General.SendCheckUserManagerReportsMessage(msj, destinatarios, tipoDePermiso)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
    'Se Cambia a funcion Asincrona 
    Private Async Function EnviarReporteCheckUserManager(tipoDePermiso As String, adicional As String, usuarioPermiso As Server.ReportService.ContactoCatalogItem, usuarioRequiere As Server.ReportService.ContactoCatalogItem) As Task
        Try
            Dim dest As New DataTable("destinatarios")
            Dim contRowDest As Integer = 0
            Dim destinatarios As String = String.Empty
            Dim msj As String = String.Empty
            Dim nombreUsuarioPer As String = String.Empty
            Dim nombreUsuarioReq As String = String.Empty
            dest = CommonData.GetDestinatariosPorIdReporte(5)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            nombreUsuarioPer = usuarioPermiso.primerApellido & " " & usuarioPermiso.segundoApellido & " " & usuarioPermiso.primerNombre
            nombreUsuarioReq = usuarioRequiere.primerApellido & " " & usuarioRequiere.segundoApellido & " " & usuarioRequiere.primerNombre
            msj = "Admini: " & nombreUsuarioPer & " con C.I. " & usuarioPermiso.idContacto & vbCrLf _
                                       & "Autoriza a: " & nombreUsuarioReq & " con C.I. " & usuarioRequiere.idContacto & vbCrLf _
                                       & "A: " & tipoDePermiso.ToUpper & vbCrLf _
                                       & "Vuelo: " & resDtVuelo.codigoVuelo.ToUpper & IIf(uceGuias.Text <> String.Empty, " Guia: " & uceGuias.Text.ToUpper, "") & vbCrLf _
                                       & adicional & vbCrLf _
                                       & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje."
            General.SendCheckUserManagerReportsMessage(msj, destinatarios, tipoDePermiso)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Function
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        SP1.Close()
        Me.Close()
        PI_PosicionKg = 0
    End Sub

    Private Sub ugvPersonal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvPersonal.KeyPress, UltraGrid1.KeyPress
        Try

            If e.KeyChar = Convert.ToChar(Keys.Delete) Then
                Dim frmCheck As New frmCheckManager
                frmCheck.ShowDialog()
                If Not frmCheck.result Then
                    ugvPersonal.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Redo)
                    Exit Sub
                End If
                For Each r As DataRow In dtMatriz.Rows
                    If r.Item("grupoPersonal") = ugvPersonal.ActiveRow.Cells("grupoPersonal").Value _
                        And r.Item("cantidadPersonal") = ugvPersonal.ActiveRow.Cells("cantidadPersonal").Value _
                        And r.Item("cargoPersonal") = ugvPersonal.ActiveRow.Cells("cargoPersonal").Value _
                        And r.Item("tipoAgenciaRequerida") = ugvPersonal.ActiveRow.Cells("tipoAgenciaRequerida").Value _
                        And r.Item("descripcionTipoAgencia") = ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value _
                        And r.Item("idAgencia") = ugvPersonal.ActiveRow.Cells("idAgencia").Value _
                        And r.Item("idContacto") = ugvPersonal.ActiveRow.Cells("idContacto").Value _
                        And r.Item("contacto") = ugvPersonal.ActiveRow.Cells("contacto").Value _
                        And r.Item("horaEntrada") = ugvPersonal.ActiveRow.Cells("horaEntrada").Value _
                        And r.Item("horaSalida") = ugvPersonal.ActiveRow.Cells("horaSalida").Value Then
                        r.Delete()
                        Exit For
                    End If
                Next
                SavePersonalProceso()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvPersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles ugvPersonal.KeyDown, UltraGrid1.KeyDown
        Try
            If e.KeyData = Keys.Delete Then
                Dim frmCheck As New frmCheckManager
                frmCheck.ShowDialog()
                If Not frmCheck.result Then
                    Exit Sub
                End If
                For Each r As DataRow In dtMatriz.Rows
                    If r.Item("grupoPersonal").ToString = ugvPersonal.ActiveRow.Cells("grupoPersonal").Value.ToString _
                        And r.Item("cantidadPersonal").ToString = ugvPersonal.ActiveRow.Cells("cantidadPersonal").Value.ToString _
                        And r.Item("cargoPersonal").ToString = ugvPersonal.ActiveRow.Cells("cargoPersonal").Value.ToString _
                        And r.Item("tipoAgenciaRequerida").ToString = ugvPersonal.ActiveRow.Cells("tipoAgenciaRequerida").Value.ToString _
                        And r.Item("descripcionTipoAgencia").ToString = ugvPersonal.ActiveRow.Cells("descripcionTipoAgencia").Value.ToString _
                        And r.Item("idAgencia").ToString = ugvPersonal.ActiveRow.Cells("idAgencia").Value.ToString _
                        And r.Item("idContacto").ToString = ugvPersonal.ActiveRow.Cells("idContacto").Value.ToString _
                        And r.Item("contacto").ToString = ugvPersonal.ActiveRow.Cells("contacto").Value.ToString _
                        And r.Item("horaEntrada").ToString = ugvPersonal.ActiveRow.Cells("horaEntrada").Value.ToString _
                        And r.Item("horaSalida").ToString = ugvPersonal.ActiveRow.Cells("horaSalida").Value.ToString Then
                        r.Delete()
                        Exit For
                    End If
                Next
                SavePersonalProceso()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ugvCaptura_AfterSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles ugvCaptura.AfterSelectChange
        'isEnableConsultaProceso = False
        'Timer1.Enabled = False
    End Sub

    Private Sub btnObtProceso_Click(sender As Object, e As EventArgs) Handles btnObtProceso.Click
        ObtenerProceso2()
        'isEnableConsultaProceso = False
        'Timer1.Enabled = False
    End Sub

    Private Sub EnviarInfoSenae(currentGuia As String)
        'Private Sub EnviarInfoSenae(p1 As Integer, p2 As Decimal, g As String)
        Try
            Dim tempDetalleProceso As New DetalleProcesoItem
            'Dim piezas As Integer = p1
            'Dim peso As Decimal = p2
            Dim guia As String = currentGuia
            Dim cont As Integer = 0
            Dim cont2 As Integer = 0
            Dim dtDae As New DataTable("dtDae")
            With dtDae.Columns
                .Add("dae", GetType(String))
                .Add("pesoEnviado", GetType(Decimal))
                .Add("pesoPorEnviar", GetType(Decimal))
                .Add("piezasEnviada", GetType(Decimal))
                .Add("piezasPorEnviar", GetType(Decimal))
            End With

            Dim tempDae As String = ""
            Dim pesoEnviado As Decimal = 0D
            Dim piezasEnviado As Decimal = 0D
            Dim pesoPorEnviar As Decimal = 0D
            Dim piezaPorEnviar As Decimal = 0D
            Dim lastDae As String = ""
            Dim vista As New DataView(dtDetalleProceso)
            vista.Sort = "dae"
            For Each r2 As DataRowView In vista
                tempDae = r2.Item("dae")
                If tempDae <> lastDae Then
                    For Each r As DataRowView In vista
                        'If r.Item("guia") = guia And r.Item("estadoSenae") = String.Empty And r.Item("dae") = tempDae Then
                        '    pesoPorEnviar += r.Item("peso")
                        '    piezaPorEnviar += r.Item("piezas")
                        'End If
                        'If r.Item("guia") = guia And r.Item("estadoSenae") <> String.Empty And r.Item("dae") = tempDae Then
                        '    pesoEnviado += r.Item("peso")
                        '    piezasEnviado += r.Item("piezas")
                        '    cont2 += 1
                        'End If

                        'If r.Item("guia") = guia And True And r.Item("dae") = tempDae Then   JCM COMPARACION ESTADO SENAE
                        If r.Item("guia") = guia And r.Item("estadoSenae") = String.Empty And r.Item("dae") = tempDae Then
                            pesoPorEnviar += r.Item("peso")
                            piezaPorEnviar += r.Item("piezas")
                        End If

                        'If r.Item("guia") = guia And False And r.Item("dae") = tempDae Then  JCM COMPARACION ESTADO SENAE
                        If r.Item("guia") = guia And r.Item("estadoSenae") <> String.Empty And r.Item("dae") = tempDae Then
                            pesoEnviado += r.Item("peso")
                            piezasEnviado += r.Item("piezas")
                            cont2 += 1
                        End If
                        If r.Item("guia") = guia Then
                            tempDetalleProceso.idProducto = r.Item("idProducto")
                            tempDetalleProceso.idGuia = r.Item("idGuia")
                            cont += 1
                        End If
                    Next
                    If piezaPorEnviar > 0 Then
                        Dim nr As DataRow = dtDae.NewRow
                        nr.Item("dae") = tempDae
                        nr.Item("pesoPorEnviar") = pesoPorEnviar
                        nr.Item("pesoEnviado") = pesoEnviado
                        nr.Item("piezasPorEnviar") = piezaPorEnviar
                        nr.Item("piezasEnviada") = piezasEnviado
                        dtDae.Rows.Add(nr)
                    End If
                    lastDae = tempDae
                End If
                pesoPorEnviar = 0
                piezaPorEnviar = 0
            Next
            cont = cont - cont2
            'tempDetalleProceso.piezas = piezas
            'tempDetalleProceso.peso = peso

            Dim myTempSenaeDocId As String = String.Empty

            If cont > 0 Then
                If cont2 >= 0 Then
                    For Each reg As DataRow In CommonProcess.GetGuiaDaesPorIdGuia(tempDetalleProceso.idGuia).Rows
                        Dim Registro As DataRow
                        Registro = dtGuiaDaeRem.NewRow
                        Registro.Item("idGuia") = reg.Item("idGuia")
                        Registro.Item("Dae") = reg.Item("dae")
                        Registro.Item("NumRem") = reg.Item("NumRem")
                        Registro.Item("FechaVigencia") = reg.Item("fechavigenciaRem")
                        dtGuiaDaeRem.Rows.Add(Registro)
                    Next
                    For Each r2 As DataRow In dtDae.Rows
                        tempDetalleProceso.dae = r2.Item("dae")
                        'tempDetalleProceso.peso = r2.Item("pesoPorEnviar")
                        Dim PesoRedondeo As Double
                        Try
                            PesoRedondeo = Redondeo(r2.Item("pesoPorEnviar"), 0)
                            If PesoRedondeo > 0 Then
                                tempDetalleProceso.peso = PesoRedondeo
                            Else
                                tempDetalleProceso.peso = r2.Item("pesoPorEnviar")
                            End If
                        Catch ex As Exception
                            tempDetalleProceso.peso = r2.Item("pesoPorEnviar")
                        End Try
                        tempDetalleProceso.piezas = r2.Item("piezasPorEnviar")
                        'ini Jordan Rodriguez 18/07/2022
                        'Se valida que la valdiacion de REM se encuentre antiva para realizar las validaciones
                        'correspondiente del REM
                        If RemActivo Then
                            Dim rows As DataRow()
                            rows = dtGuiaDaeRem.Select("idGuia='" & tempDetalleProceso.idGuia.ToString & "' and Dae='" & tempDetalleProceso.dae & "'")
                            If rows.Count > 0 Then
                                For Each reg As DataRow In rows
                                    If reg.Item(2).ToString <> String.Empty Then
                                        tempDetalleProceso.NumRem = reg.Item(2)
                                        tempDetalleProceso.FechaVigencia = reg.Item(3)
                                    End If
                                Next
                                If tempDetalleProceso.FechaVigencia < Now() And (tempDetalleProceso.NumRem <> String.Empty) Then
                                    MessageBox.Show("La REM : " & tempDetalleProceso.NumRem & " a caducado  fecha de Caducacion: " & tempDetalleProceso.FechaVigencia, "Error", MessageBoxButtons.OK)
                                    Exit Sub
                                End If
                            End If
                        End If
                        'fin Jordan Rodriguez 18/07/2022
                        If saveDocSenae(tempDetalleProceso, myTempSenaeDocId) Then
                            For Each r As DataRow In dtDetalleProceso.Rows
                                If r.Item("guia") = guia And r.Item("estadoSenae") = String.Empty And r.Item("dae") = r2.Item("dae") Then
                                    tempDetalleProceso.indice = r.Item("indice")
                                    tempDetalleProceso.estadoSenae = myTempSenaeDocId
                                    CommonProcess.ModificarEstadoSenaeDetalleProcesoCarga(tempDetalleProceso)
                                    IndiceEstadoSenae.estadoSenae = tempDetalleProceso.estadoSenae
                                    IndiceEstadoSenae.indice = tempDetalleProceso.indice
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Private Function Redondeo(ByVal Numero, ByVal Decimales)
        Redondeo = Int(Numero * 10 ^ Decimales + 1 / 2) / 10 ^ Decimales
    End Function
    Private strCode As String = String.Empty

    Private Sub txtLector_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLector.KeyDown
        ModuloCierre.InicioEjecucion = Date.Now
        LsBandeAct = "N"
        If e.KeyValue = Keys.Return Then
            If validaDae() Then
                IntentarCaptura()
            Else
                If MessageBox.Show("El número de Dae de la Pieza no coincide con el de la Guia, ¿desea continuar?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                IntentarCaptura()
            End If
            txtLector.Text = String.Empty
        End If
    End Sub

    Private Function validaDae() As Boolean
        Try
            For Each r In uceDaes.Items
                If r.DisplayText.Trim = txtLector.Text.Trim Then
                    Return True
                    Exit Function
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function

    'Private Sub TmrConsultaEstadoDae_Tick(sender As Object, e As EventArgs)
    '    consultaEstadoValidezDae()
    'End Sub

    Private Sub consultaEstadoValidezDae()
        value = True
        While value
            Dim strEstado As String = String.Empty
            If uceDaes.Text.Length = 17 Then
                Try
                    myValidezDae = CommonProcess.GetValidezDaePorDae(uceDaes.Text)
                    If Not IsNothing(myValidezDae) Then
                        strEstado = myValidezDae.examinerName
                        If myValidezDae.examinerName <> String.Empty Then
                            txtEstadoDae.Text = strEstado
                            txtEstadoDae.BackColor = Color.CornflowerBlue '{Color [A=255, R=240, G=246, B=254]
                            txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                            value = False
                            bgwConsultaEstadoDae.CancelAsync()
                            estadoDAE = True
                        Else
                            txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                            txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                            strEstado = "NO TIENE ESTADO"
                            txtEstadoDae.Text = strEstado
                            estadoDAE = False
                            'Thread.CurrentThread.
                        End If
                    Else
                        dtValidezDae = SearchDAE(uceDaes.Text) 'Webservice Ecuapass con niveles de seguridad - MARZ
                        If Not IsNothing(dtValidezDae) Then
                            If dtValidezDae.Rows.Count > 0 Then
                                For Each r As DataRow In dtValidezDae.Rows
                                    strEstado = r.Item("ExaminerName")
                                    If strEstado <> String.Empty Then
                                        txtEstadoDae.Text = strEstado
                                        txtEstadoDae.BackColor = Color.CornflowerBlue '{Color [A=255, R=240, G=246, B=254]
                                        txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                                        value = False
                                        bgwConsultaEstadoDae.CancelAsync()
                                        estadoDAE = True
                                    Else
                                        txtEstadoDae.BackColor = Color.FromArgb(255, 240, 246, 254)
                                        txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
                                        strEstado = "NO TIENE ESTAD"
                                        txtEstadoDae.Text = strEstado
                                        estadoDAE = False
                                    End If
                                    txtEstadoDae.Text = strEstado
                                Next
                            Else
                                txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                                txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                                txtEstadoDae.Text = "DAE Incorrecto"
                                value = False
                                bgwConsultaEstadoDae.CancelAsync()
                                estadoDAE = False
                            End If
                        Else
                            txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                            txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                            txtEstadoDae.Text = "DAE Incorrecto"
                            value = False
                            bgwConsultaEstadoDae.CancelAsync()
                            estadoDAE = False
                        End If
                    End If
                Catch ex As Exception
                    General.SetLogEvent(ex)
                End Try
            Else
                txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                txtEstadoDae.Text = "DAE Incorrecto"
                value = False
                bgwConsultaEstadoDae.CancelAsync()
            End If
        End While
    End Sub

    Private Sub uceElementos_SelectionChanged(sender As Object, e As EventArgs) Handles uceElementos.SelectionChanged
        Dim tempElemento As New Server.ReportService.ElementoCatalogItem
        Try
            tempElemento = CommonData.GetElementoItem(uceElementos.Text)
            If Not IsNothing(tempElemento) Then
                If tempElemento.estado = "S" Then
                    txtPeso.Enabled = False
                    txtLector.Enabled = False
                    MessageBox.Show("El elemento seleccionado no está en las instalaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    txtPeso.Enabled = True
                    txtLector.Enabled = True
                End If
            Else
                txtPeso.Enabled = False
                txtLector.Enabled = False
                MessageBox.Show("Error al seleccionar elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvCaptura_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvCaptura.DoubleClickCell
        Try
            Dim estadoSenae As String
            If ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString <> String.Empty Then
                If MessageBox.Show("¿Desea Reenviar el IIE de este número de entrega " & ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString & "?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Dim frmCheck As New frmCheckManager
                    frmCheck.ShowDialog()
                    If Not frmCheck.result Then
                        Exit Sub
                    End If
                    estadoSenae = ugvCaptura.ActiveRow.Cells("estadoSenae").Value.ToString
                    'OBTIENE TODO EL DETALLE DE PROCESO
                    ObtenerProceso2()
                    ' isEnableConsultaProceso = False
                    'Timer1.Enabled = False
                    REnviarInfoSenae(estadoSenae) 'EWLM PRUEBAS
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub REnviarInfoSenae(ByVal estadoSenae As String)
        Try
            Dim tempDetalleProceso As New DetalleProcesoItem
            Dim piezas As Integer = 0
            Dim peso As Decimal = 0D
            Dim guia As String = String.Empty
            Dim cont As Integer = 0
            Dim currentDocSenaeId As String = String.Empty
            For Each r As DataRow In dtDetalleProceso.Rows
                If r.Item("estadoSenae") = estadoSenae Then
                    piezas += r.Item("piezas")
                    peso += r.Item("peso")
                    tempDetalleProceso.idProducto = r.Item("idProducto")
                    tempDetalleProceso.idGuia = r.Item("idGuia")
                    cont += 1
                End If
            Next
            tempDetalleProceso.piezas = piezas
            'tempDetalleProceso.peso = peso
            Dim PesoRedondeo As Double
            Try
                PesoRedondeo = Redondeo(peso, 0)
                If PesoRedondeo > 0 Then
                    tempDetalleProceso.peso = PesoRedondeo
                Else
                    tempDetalleProceso.peso = peso
                End If
            Catch ex As Exception
                tempDetalleProceso.peso = peso
            End Try
            If cont > 0 Then
                If saveDocSenae(tempDetalleProceso, currentDocSenaeId) Then
                    For Each r As DataRow In dtDetalleProceso.Rows
                        If r.Item("idGuia") = tempDetalleProceso.idGuia And r.Item("estadoSenae") = estadoSenae Then
                            tempDetalleProceso.indice = r.Item("indice")
                            tempDetalleProceso.estadoSenae = currentDocSenaeId
                            CommonProcess.ModificarEstadoSenaeDetalleProcesoCarga(tempDetalleProceso)
                            IndiceEstadoSenae.estadoSenae = tempDetalleProceso.estadoSenae
                            IndiceEstadoSenae.indice = tempDetalleProceso.indice
                        End If
                    Next
                    MessageBox.Show("Reenvio exitoso!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error en el Reenvio, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub bgwConsultaProceso_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwConsultaProceso.DoWork
        'While True
        '    'CalculaPesoVolumen()
        '    ugvCaptura.Refresh()
        '    Threading.Thread.Sleep(1000)
        'End While
    End Sub
    Private Sub RefreshCamiones()
        Dim guiaTemp As New GuiaItem
        Try
            uceCamiones.Items.Clear()
            For Each r As DataRow In CommonProcess.GetGuiaCamionesPorIdGuia(uceGuias.Value, myDetalleVuelo.idBriefing).Rows
                uceCamiones.Items.Add(r.Item("idCamion"), r.Item("matriculaCamion"))
            Next
            uceCamiones.SelectedIndex = 0
            If utcTabs.Tabs("PRO").Selected Then
                If uceCamiones.Items.Count < 1 Then
                    MessageBox.Show("La Guia seleccionada no se puede Procesar: Es necesario asignarle un Camión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    uceCamiones.Enabled = False
                    txtPeso.Enabled = False
                    txtLector.Enabled = False
                Else
                    txtPeso.Enabled = True
                    txtLector.Enabled = True
                    uceCamiones.Enabled = True
                    ObtenerGuias(myDetalleVuelo.idBriefing)
                End If
            End If
            dtGuiaProductos = CommonProcess.GetGuiaProductoPorIdGuia(uceGuias.Value)
            If Not IsNothing(dtGuiaProductos) Then
                uceProducto.Items.Clear()
                For Each r As DataRow In dtGuiaProductos.Rows
                    uceProducto.Items.Add(r.Item("idProducto"), r.Item("descripcionProducto"))
                Next
                uceProducto.SelectedIndex = 0
            End If
            uceAgencia.Items.Clear()
            guiaTemp = CommonProcess.GetGuiaPorIdGuia(uceGuias.Value)
            uceAgencia.Items.Add(guiaTemp.IdAgencia, guiaTemp.DescripcionAgencia)
            uceAgencia.SelectedIndex = 0
            txtTPesoGuia.Text = guiaTemp.Peso
            txtTBultosGuia.Text = guiaTemp.Bultos
            uceDaes.Text = guiaTemp.DAE
            If uceDaes.Text.Trim <> String.Empty Then
                txtEstadoDae.Text = String.Empty
                'consultaEstadoValidezDae()
                'TmrConsultaEstadoDae.Start()
                If bgwConsultaEstadoDae.IsBusy = False Then
                    bgwConsultaEstadoDae.RunWorkerAsync()
                End If
                'bgwConsultaEstadoDae.RunWorkerAsync()
            Else
                txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                txtEstadoDae.Text = "DAE Incorrecto"
                estadoDAE = False
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub refreshGuias()
        ObtenerGuias(resDtVuelo.idBriefing)
        CargarGuias()
    End Sub
    Private Sub btnRef_Click(sender As Object, e As EventArgs) Handles btnRef.Click
        refreshGuias()
        RefreshCamiones()
    End Sub
    Private Sub uceDaes_SelectionChanged(sender As Object, e As EventArgs) Handles uceDaes.SelectionChanged
        Try
            If uceDaes.Text.Trim <> String.Empty Then
                txtEstadoDae.Text = String.Empty
                'consultaEstadoValidezDae()
                If bgwConsultaEstadoDae.IsBusy = False Then
                    bgwConsultaEstadoDae.RunWorkerAsync()
                End If
                'bgwConsultaEstadoDae.RunWorkerAsync()
            Else
                txtEstadoDae.BackColor = Color.FromArgb(255, 128, 128)
                txtEstadoDae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                txtEstadoDae.Text = "DAE Incorrecto"
                estadoDAE = False
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub bgwConsultaEstadoDae_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwConsultaEstadoDae.DoWork
        consultaEstadoValidezDae()
        Threading.Thread.Sleep(1000)
    End Sub
    Sub takeScreenshot(ByRef pathlog As String)
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        screenshot.Save(pathlog + ".jpg", Imaging.ImageFormat.Jpeg)
    End Sub
    Private Sub chkA_CheckedChanged(sender As Object, e As EventArgs) Handles chkA2.CheckedChanged
        If chkA2.Checked Then
            txtTempA.Enabled = False
        Else
            txtTempA.Enabled = True
        End If
    End Sub
    Private Sub chkB_CheckedChanged(sender As Object, e As EventArgs) Handles chkB.CheckedChanged
        If chkB.Checked Then
            txtTempB.Enabled = False
        Else
            txtTempB.Enabled = True
        End If
    End Sub

    Private Sub chkC_CheckedChanged(sender As Object, e As EventArgs) Handles chkC.CheckedChanged
        If chkC.Checked Then
            txtTempC.Enabled = False
        Else
            txtTempC.Enabled = True
        End If
    End Sub
    Private Sub chkA34_CheckedChanged(sender As Object, e As EventArgs) Handles chkA34.CheckedChanged
        If chkA34.Checked Then
            txtTempA34.Enabled = False
        Else
            txtTempA34.Enabled = True
        End If
    End Sub
    Private Sub chkZF_CheckedChanged(sender As Object, e As EventArgs) Handles chkZF.CheckedChanged
        If chkZF.Checked Then
            txtTempZF.Enabled = False
        Else
            txtTempZF.Enabled = True
        End If
    End Sub
    Private Sub chkZp_CheckedChanged(sender As Object, e As EventArgs) Handles chkZp.CheckedChanged
        If chkZp.Checked Then
            txtTempZP.Enabled = False
        Else
            txtTempZP.Enabled = True
        End If
    End Sub
    Private Sub bgwConsultaTemp_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwConsultaTemp.DoWork
        While True
            If chkA2.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-A-2").Rows
                    txtTempA.Text = r.Item("Centigrado")
                Next
            End If
            If chkA34.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-A-3-4").Rows
                    txtTempA34.Text = r.Item("Centigrado")
                Next
            End If
            If chkB.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-B-1").Rows
                    txtTempB.Text = r.Item("Centigrado")
                Next
            End If
            If chkC.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-A-5").Rows
                    txtTempC.Text = r.Item("Centigrado")
                Next
            End If
            If chkZF.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-Z-1").Rows
                    txtTempC.Text = r.Item("Centigrado")
                Next
            End If
            If chkZp.Checked Then
                For Each r As DataRow In CommonProcess.ObtenerTempAct("CUARTO-FRIO-Z-2").Rows
                    txtTempC.Text = r.Item("Centigrado")
                Next
            End If
            Threading.Thread.Sleep(10000)
        End While
    End Sub

    Private Sub frmCapturaPeso_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmCapturaPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmCapturaPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub txtcodSello_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodSello.KeyDown

        Select Case e.KeyValue

            Case Keys.Return
                txtnumSaca.Focus()
        End Select

    End Sub


    Private Sub txtnumSaca_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnumSaca.KeyDown
        Select Case e.KeyValue

            Case Keys.Return
                txtPeso.Focus()
        End Select
    End Sub

    Private Sub uceGuiasSellos_ValueChanged(sender As Object, e As EventArgs) Handles uceGuiasSellos.ValueChanged

        Try
            uceCamionesSellos.Items.Clear()
            For Each r As DataRow In CommonProcess.GetGuiaCamionesPorIdGuia(uceGuiasSellos.Value, myDetalleVuelo.idBriefing).Rows
                uceCamionesSellos.Items.Add(r.Item("idCamion"), r.Item("matriculaCamion"))
            Next
            uceCamionesSellos.SelectedIndex = 0 'ATENCION AQUI!

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarSellosCamiones()
        Dim dt As DataTable


        Try
            'dtSellocamiones
            dtSellocamiones.Clear()

            For Each r As DataRow In dtGuias.Rows
                For Each reg As DataRow In CommonProcess.GetDetalleSellosCamionesporidguia(r.Item("idGuia").ToString(), myProceso.idBriefing.ToString()).Rows
                    Dim Registro As DataRow
                    Registro = dtSellocamiones.NewRow
                    Registro.Item("indice_sellos") = reg.Item("indice_sellos")
                    Registro.Item("Guia") = reg.Item("idGuia")
                    Registro.Item("Camion") = reg.Item("idCamion")
                    Registro.Item("Briefing") = reg.Item("idBriefing")
                    Registro.Item("descripcionGuia") = reg.Item("descripcionGuia")
                    Registro.Item("matriculaCamion") = reg.Item("matriculaCamion")
                    Registro.Item("sello") = reg.Item("nu_sello")
                    Registro.Item("descripcion") = reg.Item("descripcion")
                    dtSellocamiones.Rows.Add(Registro)
                Next
            Next

            'ugvSellos.DataSource = dtSellocamiones
            ugvSellos.DataBind()
            ugvSellos.Refresh()
            SetDisplayedColumnsSellosCammion()
            Me.txtSello.Text = ""
            Me.txtDescripcionSello.Text = ""

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtSello_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSello.KeyDown
        Dim datos As New DetalleSelloCamionesItem


        If e.KeyCode = Keys.Return Then
            If txtSello.Text.Trim() <> String.Empty Then

                datos.indice_sellos = Guid.NewGuid().ToString()
                datos.idGuia = (uceGuiasSellos.Value).ToString()
                datos.idCamion = (uceCamionesSellos.Value).ToString()
                datos.idBriefing = myProceso.idBriefing.ToString()
                datos.numSello = Me.txtSello.Text
                datos.fecha = Date.Now
                datos.descripcion = Me.txtDescripcionSello.Text
                If CommonProcess.SaveDetalleSellosCamiones(datos) Then
                    CargarSellosCamiones()
                    Me.txtDescripcionSello.Focus()
                End If

            End If
        End If
    End Sub


    Private Sub txtnumSaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumSaca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescripcionSello_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcionSello.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
    Private Sub SetDisplayedColumnsSellosCammion()
        Try
            ugvSellos.DisplayLayout.Bands(0).Columns("indice_sellos").Hidden = True
            ugvSellos.DisplayLayout.Bands(0).Columns("Guia").Hidden = True
            ugvSellos.DisplayLayout.Bands(0).Columns("Camion").Hidden = True
            ugvSellos.DisplayLayout.Bands(0).Columns("Briefing").Hidden = True
            ugvSellos.DisplayLayout.Bands(0).Columns("descripcionGuia").Header.Caption = "GUIA"
            ugvSellos.DisplayLayout.Bands(0).Columns("matriculaCamion").Header.Caption = "CAMION"
            ugvSellos.DisplayLayout.Bands(0).Columns("sello").Header.Caption = "Sello"
            ugvSellos.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripcion"
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ugvSellos_KeyDown(sender As Object, e As KeyEventArgs) Handles ugvSellos.KeyDown
        Dim indicesellos As String
        Dim datos As New DetalleSelloCamionesItem

        Try
            If e.KeyData = Keys.Delete Then
                indicesellos = ugvSellos.ActiveRow.Cells("indice_sellos").Value.ToString()
                datos.indice_sellos = indicesellos
                If CommonProcess.DeleteDetalleSellosCamiones(datos) Then
                    CargarSellosCamiones()
                End If

            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub txtSello_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSello.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDescripcionSello_ValueChanged(sender As Object, e As EventArgs) Handles txtDescripcionSello.ValueChanged

    End Sub

    Private Sub txtDescripcionSello_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcionSello.KeyDown
        If e.KeyCode = Keys.Return Then
            Me.txtSello.Focus()
        End If
    End Sub



    Private Sub txtcodSello_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodSello.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtPeso_ValueChanged(sender As Object, e As EventArgs) Handles txtPeso.ValueChanged

    End Sub


End Class
