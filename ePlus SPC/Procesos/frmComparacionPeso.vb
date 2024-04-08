Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Imports System.IO.Ports
Public Class frmComparacionPeso
    Dim myDetalleVuelo As New DetalleVuelo
    Dim proceso As New ProcesoItem
    Dim balanzaIsActive As Boolean = True
    Dim band_balanza As Boolean = False
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim dtElementos As New DataTable("Elementos")
    Dim pesoElemento As Decimal = 0D
    Dim pesoCarga As Decimal = 0D
    Dim pesoMovIn As Decimal = 0D
    Dim pesoMovOut As Decimal = 0D
    Dim pesoTotal As Decimal = 0D
    Dim pesoDiferencia As Decimal = 0D
    Dim pesoBascula As Decimal = 0D
    Dim indice As Guid = Guid.Empty
    Dim elementoProceso As New ElementoProcesoItem
    Dim dtElementoMod As New DataTable("ElementosMod")
    Dim dtTotalElementos As New DataTable("dtTotalElementos")
    Dim dtDetalleProceso As New DataTable("Procesos")
    Dim dtElementoProceso As New DataTable("dtElementoProceso")
    Dim myElementoProceso As New ElementoProcesoItem
    Dim pesoRed As Decimal = 0D
    Dim dtDetalleProcesoCargaElementosCargados As New DataTable("detalleProcesoCargaReporteElementosCargados")
    Dim tempElemento As New Server.ReportService.ElementoCatalogItem


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        SP1.Dispose()
        SP1.Close()
        Me.Close()
        ' Else
        ' Exit Sub
        ' End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> String.Empty Then
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                udtFecha.Value = myDetalleVuelo.fechaVuelo
                udtEta.Value = myDetalleVuelo.llegadaVuelo
                udtEtd.Value = myDetalleVuelo.salidaVuelo
                consultaProceso()
                ObtenerProceso()
                ObtenerTotalElementos()
                CargarElementos()
                SaveElementoProceso()
                consultaElementosProceso()
                'obtenerDetalleVuelo(frmConsultaVuelos.NumeroVuelo)
                'myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                'If Not procesoExist Then
                '    SaveProceso()
                'End If
                uceRed.SelectedIndex = 0
                NumRed.Value = 0
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "Fun UltraButton1.Click")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerTotalElementos()
        Try
            Dim dttempTotalPorElemento As New DataTable
            Dim nr As DataRow
            dttempTotalPorElemento = CommonProcess.GetTotalPorElementoPorIdProceso(proceso.IdProceso)
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
        Catch ex As Exception
            General.SetLogEvent(ex, "Func ObtenerTotalElementos")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarElementos()
        Try
            Dim elementoBriefing As New Server.VuelosService.ElementoBriefingItem
            elementoBriefing.idBriefing = proceso.idBriefing
            dtElementos = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefing)
            If Not IsNothing(dtElementos) Then
                cmbElemento.Items.Clear()
                For Each r As DataRow In dtElementos.Rows
                    cmbElemento.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
                Next
                cmbElemento.SelectedIndex = 0
                calculaPesoElemento()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "Func CargarElementos")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaProceso()
        Try
            proceso.idBriefing = myDetalleVuelo.idBriefing
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            dtDetalleProcesoCargaElementosCargados = CommonProcess.GetReportePorIdProcesoGroupByElemento3(proceso.IdProceso)
        Catch ex As Exception
            General.SetLogEvent(ex, "Func consultaProceso")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
        cmbElemento.Clear()
        txtPesoElemento.Clear()
        txtPesoCarga.Clear()
        txtPesoTot.Clear()
        dtElementos.Rows.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim result As Boolean = False
            'txtPeso.Text = 168
            pesoBascula = Decimal.Parse(txtPeso.Text)
            If pesoBascula > (pesoElemento + pesoRed) Then
                pesoDiferencia = pesoTotal - pesoBascula
                If 10 >= pesoDiferencia Then
                    If pesoDiferencia >= -10 Then
                        For Each r As DataRow In dtElementoMod.Rows
                            If r.Item("idElemento") = cmbElemento.Value Then
                                MessageBox.Show("Elemento ya resgistrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'Exit For
                                Exit Sub
                            End If
                        Next
                        dtElementoProceso = CommonProcess.GetElementoProcesoPorIdProcesoIdElemento(proceso.IdProceso, cmbElemento.Value)
                        If Not IsNothing(dtElementoProceso) Then
                            For Each r2 As DataRow In dtElementoProceso.Rows
                                elementoProceso.indice = r2.Item("indice")
                                Exit For
                            Next
                        End If
                        'elementoProceso.indice = Guid.Parse("03efedd1-9eea-41fe-9da2-7d71b0e00267")
                        elementoProceso.estado = "A"
                        elementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                        elementoProceso.pesoDiferencia = pesoDiferencia
                        elementoProceso.pesoCarga = pesoBascula
                        elementoProceso.pesoCaptura = pesoCarga
                        elementoProceso.Red = pesoRed
                        If elementoProceso.indice = Guid.Empty Then
                            elementoProceso.indice = Guid.NewGuid
                        End If

                        'ewlm agregado
                        If pesoDiferencia <> elementoProceso.pesoCarga - (elementoProceso.pesoCaptura + elementoProceso.pesoEntradaElemento) Then
                            MessageBox.Show("Error en diferencia", "Favor capturar pantalla y enviar a sistemas, gracias.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        'ewlm agregado
                        result = CommonProcess.ModificarEstadoElementoProcesoPorIndice(elementoProceso)
                        If result Then
                            Dim nr As DataRow
                            nr = dtElementoMod.NewRow
                            nr.Item("idElemento") = cmbElemento.Value.ToString
                            nr.Item("pesoElemento") = pesoElemento
                            nr.Item("pesoCarga") = pesoCarga
                            nr.Item("pesoTotal") = pesoTotal
                            nr.Item("pesoDiferencia") = pesoDiferencia
                            nr.Item("estado") = "A"
                            nr.Item("indice") = indice
                            dtElementoMod.Rows.Add(nr)
                        Else
                            MessageBox.Show("Error al actualizar la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            GuardarCapturaFormulario()
                            NumRed.Value = 0
                            Exit Sub
                        End If
                    Else
                        General.SetLogEvent("PesoCarga: " + txtPesoCarga.Text + " PesoElemento: " + txtPesoElemento.Text _
                                            + " PesoSuma: " + txtPesoTot.Text + " PesoBascula: " + txtPeso.Text + " PesoDif: " + pesoDiferencia.ToString _
                                            + "Usuario: " + MyCurrentUser.userName + " Vuelo: " + txtVuelo.Text)
                        MessageBox.Show("El peso registrado supera el rango permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GuardarCapturaFormulario()
                        NumRed.Value = 0
                        Exit Sub
                    End If
                Else
                    General.SetLogEvent("PesoCarga: " + txtPesoCarga.Text + " PesoElemento: " + txtPesoElemento.Text _
                                        + " PesoSuma: " + txtPesoTot.Text + " PesoBascula: " + txtPeso.Text + " PesoDif: " + pesoDiferencia.ToString _
                                            + "Usuario: " + MyCurrentUser.userName + " Vuelo: " + txtVuelo.Text)
                    MessageBox.Show("El peso registrado es inferior el rango permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GuardarCapturaFormulario()
                    NumRed.Value = 0
                    Exit Sub
                End If
            Else
                General.SetLogEvent("PesoCarga: " + txtPesoCarga.Text + " PesoElemento: " + txtPesoElemento.Text _
                                    + " PesoSuma: " + txtPesoTot.Text + " PesoBascula: " + txtPeso.Text + " PesoDif: " + pesoDiferencia.ToString _
                                            + "Usuario: " + MyCurrentUser.userName + " Vuelo: " + txtVuelo.Text)
                MessageBox.Show("El peso registrado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                GuardarCapturaFormulario()
                NumRed.Value = 0
                Exit Sub
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "Func btnSave.Click")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GuardarCapturaFormulario()
            NumRed.Value = 0
        End Try
    End Sub

    Private Sub GuardarCapturaFormulario()
        Try
            Dim grafico As Graphics = Me.CreateGraphics
            Dim medida As Size = Me.Size
            Dim bmap As New Bitmap(medida.Width, medida.Height, grafico)
            Dim grafico2 As Graphics = Graphics.FromImage(bmap)
            grafico2.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, medida)
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
            End If
            bmap.Save(rutaejecutable & "\LogFiles\" & cmbElemento.Text & ".png", Drawing.Imaging.ImageFormat.Png)
        Catch ex As Exception
            General.SetLogEvent(ex, "GuardarCapturaFormulario")
        End Try
    End Sub


    'Private Sub frmComparacionPeso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    SP1.Dispose()
    '    SP1.Close()
    'End Sub

    Private Sub frmComparacionPeso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Configurar_Balanza()

            With dtTotalElementos.Columns
                .Add("elemento", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Decimal))
                .Add("pesoVolumen", GetType(Decimal))
            End With

            With dtDetalleProceso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
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
            End With

            llenarGridElementos()
        Catch ex As Exception
            General.SetLogEvent(ex, "Func frmComparacionPeso_Load")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerProceso()
        Dim dt As New DataTable
        Dim nr As DataRow
        Try
            dtDetalleProceso.Rows.Clear()
            dt = CommonProcess.GetDetalleProcesoPorIdProcesoCaptura(proceso.IdProceso)
            For Each r As DataRow In dt.Rows
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = r.Item("idProceso")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
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
                dtDetalleProceso.Rows.Add(nr)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex, "Func ObtenerProceso")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SaveElementoProceso()
        For Each r As DataRow In dtTotalElementos.Rows
            Dim result As Boolean = False
            Dim req As New ProcesoRequest
            Dim res As New ProcesoResponse
            Dim WsClnt As New ProcesoServiceSoapClient
            Try
                dtElementoProceso = CommonProcess.GetElementoProcesoPorIdProcesoIdElemento(proceso.IdProceso, r.Item("elemento"))
                If Not IsNothing(dtElementoProceso) Then
                    If dtElementoProceso.Rows.Count > 0 Then
                        For Each r2 As DataRow In dtElementoProceso.Rows
                            myElementoProceso.indice = r2.Item("indice")
                            Exit For
                        Next
                    Else
                        myElementoProceso.indice = Guid.NewGuid
                        myElementoProceso.idElemento = r.Item("elemento")
                        Dim tempElemento As New Server.ReportService.ElementoCatalogItem
                        tempElemento = CommonData.GetElementoItem(myElementoProceso.idElemento)
                        myElementoProceso.pesoReferencialElemento = tempElemento.pesoReferencial
                        myElementoProceso.pesoEntradaElemento = tempElemento.pesoReal
                        myElementoProceso.IdProceso = proceso.IdProceso
                        myElementoProceso.fecha = Date.Now
                        myElementoProceso.pesoCaptura = r.Item("pesoReal")
                        myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                        'myElementoProceso.pesoDiferencia = r.Item("pesoReal") + myElementoProceso.pesoEntradaElemento
                        General.SetBARequest(req)
                        req.myElementoProcesoItem = myElementoProceso
                        res = WsClnt.SaveElementoProcesoItem(req)
                    End If
                Else
                    myElementoProceso.indice = Guid.NewGuid
                    myElementoProceso.idElemento = r.Item("elemento")
                    Dim tempElemento As New Server.ReportService.ElementoCatalogItem
                    tempElemento = CommonData.GetElementoItem(myElementoProceso.idElemento)
                    myElementoProceso.pesoReferencialElemento = tempElemento.pesoReferencial
                    myElementoProceso.pesoEntradaElemento = tempElemento.pesoReal
                    myElementoProceso.IdProceso = proceso.IdProceso
                    myElementoProceso.fecha = Date.Now
                    myElementoProceso.pesoCaptura = r.Item("pesoReal")
                    myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                    'myElementoProceso.pesoDiferencia = r.Item("pesoReal") + myElementoProceso.pesoEntradaElemento
                    General.SetBARequest(req)
                    req.myElementoProcesoItem = myElementoProceso
                    res = WsClnt.SaveElementoProcesoItem(req)
                End If
            Catch ex As Exception
                ErrorManager.SetLogEvent(ex, res, req)
                General.SetLogEvent(ex, "Func SaveElementoProceso")
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next

        For Each r As DataRow In dtElementos.Rows
            Dim result As Boolean = False
            Dim req As New ProcesoRequest
            Dim res As New ProcesoResponse
            Dim WsClnt As New ProcesoServiceSoapClient
            Try
                dtElementoProceso = CommonProcess.GetElementoProcesoPorIdProcesoIdElemento(proceso.IdProceso, r.Item("idElemento"))
                If Not IsNothing(dtElementoProceso) Then
                    If dtElementoProceso.Rows.Count > 0 Then
                        For Each r2 As DataRow In dtElementoProceso.Rows
                            myElementoProceso.indice = r2.Item("indice")
                            Exit For
                        Next
                    Else
                        myElementoProceso.indice = Guid.NewGuid
                        myElementoProceso.pesoCaptura = 0
                        myElementoProceso.fecha = Date.Now

                        myElementoProceso.idElemento = r.Item("idElemento")
                        Dim tempElemento As New Server.ReportService.ElementoCatalogItem
                        tempElemento = CommonData.GetElementoItem(myElementoProceso.idElemento)
                        myElementoProceso.pesoReferencialElemento = tempElemento.pesoReferencial
                        myElementoProceso.pesoEntradaElemento = tempElemento.pesoReal
                        myElementoProceso.IdProceso = proceso.IdProceso
                        myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                        'myElementoProceso.pesoDiferencia = r.Item("pesoReal") + myElementoProceso.pesoEntradaElemento
                        General.SetBARequest(req)
                        req.myElementoProcesoItem = myElementoProceso
                        res = WsClnt.SaveElementoProcesoItem(req)
                    End If
                Else
                    myElementoProceso.indice = Guid.NewGuid
                    myElementoProceso.pesoCaptura = 0
                    myElementoProceso.fecha = Date.Now
                    myElementoProceso.idElemento = r.Item("idElemento")
                    Dim tempElemento As New Server.ReportService.ElementoCatalogItem
                    tempElemento = CommonData.GetElementoItem(myElementoProceso.idElemento)
                    myElementoProceso.pesoReferencialElemento = tempElemento.pesoReferencial
                    myElementoProceso.pesoEntradaElemento = tempElemento.pesoReal
                    myElementoProceso.IdProceso = proceso.IdProceso
                    myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                    'myElementoProceso.pesoDiferencia = r.Item("pesoReal") + myElementoProceso.pesoEntradaElemento
                    General.SetBARequest(req)
                    req.myElementoProcesoItem = myElementoProceso
                    res = WsClnt.SaveElementoProcesoItem(req)
                End If
            Catch ex As Exception
                ErrorManager.SetLogEvent(ex, res, req)
                General.SetLogEvent(ex, "Func SaveElementoProceso")
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub


#Region "Balanza"
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
            If balanzaIsActive Then
                DataIn = SP1.ReadExisting
                If DataIn.Length > 0 Then
                    SetText(DataIn)
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If balanzaIsActive Then
                If Me.txtPeso.InvokeRequired Then
                    Dim d As New SetTextCallback(AddressOf SetText)
                    Me.Invoke(d, New Object() {text})
                Else
                    text = text.Substring(Config.scStringBeginChar, Config.scStringEndChar - Config.scStringBeginChar)
                    If IsNumeric(text) Then 'MARZ
                        Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                    End If
                End If
                SP1.DiscardInBuffer()
            End If

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub cmbElemento_SelectionChanged(sender As Object, e As EventArgs) Handles cmbElemento.SelectionChangeCommitted
        calculaPesoElemento()
    End Sub

    Private Sub calculaPesoElemento()
        Try
            pesoCarga = 0D
            For Each r As DataRow In dtDetalleProcesoCargaElementosCargados.Rows
                If cmbElemento.Value = r.Item("idElemento") Then
                    If r.Item("estado") = "A" Or r.Item("estado") = "R" Then
                        pesoCarga += r.Item("peso")
                    End If
                End If
            Next
            For Each r As DataRow In dtElementos.Rows
                If r.Item("idElemento") = cmbElemento.Value Then
                    tempElemento = New Server.ReportService.ElementoCatalogItem
                    tempElemento = CommonData.GetElementoItem(r.Item("idElemento"))
                    pesoElemento = tempElemento.pesoActual
                    txtPesoElemento.Text = pesoElemento
                    'pesoCarga = r.Item("pesoCaptura")
                    'pesoMovIn = r.Item("pesoCarga")
                    'pesoMovOut = r.Item("pesoDescarga")
                    pesoTotal = pesoElemento + pesoRed + pesoCarga
                    txtPesoCarga.Text = pesoCarga
                    txtPesoTot.Text = pesoTotal
                    'txtMovIn.Text = pesoMovIn
                    'txtMovOut.Text = pesoMovOut
                    indice = r.Item("indice")
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex, "Func calculaPesoElemento")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub llenarGridElementos()
        Try
            With dtElementoMod.Columns
                .Add("idElemento", GetType(String))
                .Add("pesoElemento", GetType(Decimal))
                .Add("pesoCarga", GetType(Decimal))
                .Add("pesoTotal", GetType(Decimal))
                .Add("pesoDiferencia", GetType(Decimal))
                .Add("estado", GetType(String))
                .Add("indice", GetType(Guid))
            End With
            ugdElemento.DataSource = dtElementoMod
            SetDisplayedColumnsElemento()
        Catch ex As Exception
            General.SetLogEvent(ex, "Func llenarGridElementos")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElemento()
        Try
            ugdElemento.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
            ugdElemento.DisplayLayout.Bands(0).Columns("pesoElemento").Header.Caption = "Peso Elemento"
            ugdElemento.DisplayLayout.Bands(0).Columns("pesoCarga").Header.Caption = "Peso Carga"
            ugdElemento.DisplayLayout.Bands(0).Columns("pesoTotal").Header.Caption = "Peso Total"
            ugdElemento.DisplayLayout.Bands(0).Columns("pesoDiferencia").Header.Caption = "Peso Diferencia"
            ugdElemento.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
            ugdElemento.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex, "Func SetDisplayedColumnsElemento")
        End Try
    End Sub

    Private Sub ugdElemento_KeyDown(sender As Object, e As KeyEventArgs) Handles ugdElemento.KeyDown
        Try
            If e.KeyData = Keys.Delete Then
                For Each r As DataRow In dtElementoMod.Rows
                    If r.Item("idElemento").ToString = ugdElemento.ActiveRow.Cells("idElemento").Value.ToString Then
                        r.Delete()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "Func ugdElemento_KeyDown")
        End Try
    End Sub

    Private Sub consultaElementosProceso()
        Dim tempDtEle As New DataTable
        tempDtEle = CommonProcess.GetElementoProcesoPorIdProcesoYEstado(proceso.IdProceso)
        cargarElementosProceso(tempDtEle)
    End Sub

    Private Sub cargarElementosProceso(dtEle As DataTable)
        For Each r As DataRow In dtEle.Rows
            Dim nr As DataRow
            nr = dtElementoMod.NewRow
            nr.Item("idElemento") = r.Item("idElemento")
            nr.Item("pesoElemento") = r.Item("pesoEntradaElemento")
            nr.Item("pesoCarga") = r.Item("pesoCaptura") + r.Item("pesoCarga") - r.Item("pesoDescarga")
            nr.Item("pesoTotal") = r.Item("pesoEntradaElemento") + r.Item("pesoCaptura") + r.Item("pesoCarga") - r.Item("pesoDescarga")
            nr.Item("pesoDiferencia") = r.Item("pesoDiferencia")
            nr.Item("estado") = r.Item("estado")
            nr.Item("indice") = r.Item("indice")
            dtElementoMod.Rows.Add(nr)
        Next
    End Sub

    Private Sub uceRed_SelectionChanged(sender As Object, e As EventArgs) Handles uceRed.SelectionChanged
        'If uceRed.SelectedIndex = 0 Then
        '    pesoRed = 0
        'ElseIf uceRed.SelectedIndex = 1 Then
        '    pesoRed = 8
        'ElseIf uceRed.SelectedIndex = 2 Then
        '    pesoRed = 10
        'ElseIf uceRed.SelectedIndex = 3 Then
        '    pesoRed = 12
        'ElseIf uceRed.SelectedIndex = 4 Then
        '    pesoRed = 14
        'ElseIf uceRed.SelectedIndex = 5 Then
        '    pesoRed = 16
        'ElseIf uceRed.SelectedIndex = 6 Then
        '    pesoRed = 18
        'End If
        pesoRed = uceRed.Value
        txtPesoElemento.Text = pesoElemento + uceRed.Value
        calculaPesoElemento()
    End Sub

    Private Sub NumTarifa_ValueChanged(sender As Object, e As EventArgs) Handles NumRed.ValueChanged
        pesoRed = NumRed.Value
        'txtPesoElemento.Text = pesoElemento + NumRed.Value
        calculaPesoElemento()
    End Sub
End Class