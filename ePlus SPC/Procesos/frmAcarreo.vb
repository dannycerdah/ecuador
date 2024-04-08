Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.Server.ProcesoService
Imports System.IO.Ports
Imports SPC.MessagesManager
Public Class frmAcarreo
    Dim dtTotalElementos As New DataTable("TotalElementos")
    Dim dtDetalleAcarreo As New DataTable("DetalleAcarreo")
    Dim dtDetalleAcarreoElemento As New DataTable("DetalleAcarreoElemento")
    Dim myDetalleVuelo As New DetalleVuelo
    Private myAcarreo As New AcarreoItem
    Private myDetalleAcarreo As New DetalleAcarreoItem
    Private myDetalleAcarreoElemento As New DetalleAcarreoElementoItem
    Private myElemento As New ElementoCatalogItem
    Dim dtDetalleProceso As New DataTable("Procesos")
    Dim band_balanza As Boolean = False
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim existAcarreo As Boolean = False
    Dim dtElementosProceso As New DataTable("ElementosProceso")
    Dim dtStackPallet As New DataTable("ElementosProceso")
    Dim idProceso As Guid = Guid.Empty
    Dim usuarioRequiere As New Server.ReportService.ContactoCatalogItem
    Dim proceso As New ProcesoItem

    '#Region "Balanza"
    '    Private capturaPeso As Boolean = True
    '    Private Sub Configurar_Balanza()
    '        Try
    '            If Config.IsUsingScale Then
    '                With SP1
    '                    If .IsOpen Then
    '                        .Close()
    '                    End If
    '                    .PortName = Config.scPort
    '                    .BaudRate = Config.scBaudRate ' 9600 '// 19200 baud rate
    '                    .DataBits = Config.scDataBits ' 7 '// 8 data bits
    '                    .StopBits = Config.scStopBits ' IO.Ports.StopBits.One
    '                    .Parity = Config.scParity ' IO.Ports.Parity.None
    '                    .Handshake = IO.Ports.Handshake.None
    '                    .ReceivedBytesThreshold = 20
    '                    .Encoding = System.Text.Encoding.Default
    '                    .Open() ' ABRE EL PUERTO SERIE
    '                End With
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '            band_balanza = True
    '        End Try
    '    End Sub

    '    Private Sub SP1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SP1.DataReceived
    '        Try
    '            If capturaPeso Then
    '                DataIn = SP1.ReadExisting
    '                If DataIn.Length > 0 Then
    '                    SetText(DataIn)
    '                End If
    '            End If
    '        Catch ex As Exception
    '            capturaPeso = False
    '            MessageBox.Show(ex.Message)
    '        End Try
    '    End Sub

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

    '    Private Sub SetText(ByVal text As String)
    '        Try
    '            If capturaPeso Then
    '                If Me.txtPeso.InvokeRequired Then
    '                    Dim d As New SetTextCallback(AddressOf SetText)
    '                    Me.Invoke(d, New Object() {text})
    '                Else
    '                    text = text.Substring(Config.scStringBeginChar, Config.scStringEndChar - Config.scStringBeginChar)
    '                    If IsNumeric(text) Then
    '                        Me.txtPeso.Text = Double.Parse(CInt(text) / Config.scDivisor)
    '                    End If
    '                    'Me.txtpesoreal.Text = Double.Parse(text.Substring(9, 7))
    '                End If
    '                SP1.DiscardInBuffer()
    '            End If

    '        Catch ex As Exception
    '            capturaPeso = False
    '        End Try

    '    End Sub

    '#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                txtAerolinea.Text = frmConsultaVuelos.Aerolinea
                udtFecha.Value = myDetalleVuelo.fechaVuelo
                udtEta.Value = myDetalleVuelo.llegadaVuelo
                udtEta.FormatString = "dd/MM/yyyy H:mm"
                udtEtd.Value = myDetalleVuelo.salidaVuelo
                udtEtd.FormatString = "dd/MM/yyyy H:mm"
                CargarVuelo(frmConsultaVuelos.Aerolinea)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        consultaProceso()
    End Sub

    Private Sub consultaProceso()
        Try
            With proceso
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            If Not proceso Is Nothing Then
                Dim nr As DataRow
                For Each r As DataRow In CommonProcess.GetDetalleProcesoPorIdProceso2(proceso.IdProceso).Rows
                    nr = dtDetalleProceso.NewRow
                    nr.Item("idProceso") = r.Item("idProceso")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
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
                    nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                    nr.Item("tempB") = r.Item("tempB")
                    nr.Item("tempC") = r.Item("tempC")
                    nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                    nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                    nr.Item("idCamion") = r.Item("idCamion")
                    nr.Item("muelle") = r.Item("muelle")
                    nr.Item("indice") = r.Item("indice")
                    nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                    nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")
                    nr.Item("dae") = r.Item("dae")
                    dtDetalleProceso.Rows.Add(nr)
                Next
                If Not IsNothing(dtDetalleProceso) Then
                    idProceso = proceso.IdProceso
                    CalcularTotales()
                    consultaElementoProceso(proceso.IdProceso)
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalcularTotales()
        Dim nr As DataRow
        Dim existEle As Boolean = False
        Dim existGui As Boolean = False
        Dim totBulto As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Double = 0D
        Dim totVolu As Double = 0D
        Try
            dtTotalElementos.Rows.Clear()
            For Each r2 As DataRow In dtDetalleProceso.Rows
                existEle = False
                For Each r As DataRow In dtTotalElementos.Rows
                    If r.Item("elemento") = r2.Item("idElemento") Then
                        r.Item("totalBultos") = r2.Item("bultos") + r.Item("totalBultos")
                        r.Item("totalPiezas") = r2.Item("piezas") + r.Item("totalPiezas")
                        r.Item("pesoReal") = r2.Item("peso") + r.Item("pesoReal")
                        r.Item("pesoVolumen") = r2.Item("volumen") + r.Item("pesoVolumen")
                        existEle = True
                        Exit For
                    End If
                Next
                If Not existEle Then
                    nr = dtTotalElementos.NewRow
                    nr.Item("elemento") = r2.Item("idElemento")
                    nr.Item("totalBultos") = r2.Item("bultos")
                    nr.Item("totalPiezas") = r2.Item("piezas")
                    nr.Item("pesoReal") = r2.Item("peso")
                    nr.Item("pesoVolumen") = r2.Item("volumen")
                    dtTotalElementos.Rows.Add(nr)
                End If
            Next
            agregarElementosVacios()
            agregarStack()
            ugvElementos.DataSource = dtTotalElementos
            myAcarreo = CommonProcess.GetAcarreoPorIdBriefing(myDetalleVuelo.idBriefing)
            If Not IsNothing(myAcarreo) Then
                existAcarreo = True
                dtDetalleAcarreo = CommonProcess.GetDetalleAcarreoPorIdAcarreo(myAcarreo.IdAcarreo)
                For Each r As DataRow In dtDetalleAcarreo.Rows
                    dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(r.Item("idDetalle"))
                    If Not IsNothing(dtDetalleAcarreoElemento) Then
                        infodtDetalleAcarreoElementoToObjet()
                    End If
                Next
                SetDisplayedColumnsElemento()
            Else
                existAcarreo = False
                MessageBox.Show("No se encontró registrado ningún Dolly para este vuelo, por favor revise", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub frmAcarreo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            With dtTotalElementos.Columns
                .Add("elemento", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Double))
                .Add("pesoVolumen", GetType(Double))
                .Add("idDolly", GetType(Guid))
                .Add("dolly", GetType(String))
                .Add("idDetalleAcarreoElemento", GetType(Guid))
            End With
            ugvElementos.DataSource = dtTotalElementos
            SetDisplayedColumnsElemento()

            With dtDetalleProceso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Double))
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
                .Add("tempA_3_4", GetType(Integer))
                .Add("tempB", GetType(Integer))
                .Add("tempC", GetType(Integer))
                .Add("tempZ_Flor", GetType(Integer))
                .Add("tempZ_Pq", GetType(Integer))
                .Add("idCamion", GetType(Guid))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
                .Add("RegCargaCuartoFrio", GetType(String))
                .Add("UsusarioIngreso", GetType(String))
                .Add("dae", GetType(String)) 'jro 06012020
            End With
            usuarioRequiere = CommonData.GetContactoItem(MyCurrentUser.userName)
            If ModuloCierre.EndHilo = False Then
                ModuloCierre.InicioEjecucion = Date.Now
                ModuloCierre.EjecutaHiloVerificacion()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElemento()
        Try
            ugvElementos.DisplayLayout.Bands(0).Columns("elemento").Header.Caption = "Elemento"
            ugvElementos.DisplayLayout.Bands(0).Columns("totalBultos").Header.Caption = "T. Bultos"
            ugvElementos.DisplayLayout.Bands(0).Columns("totalPiezas").Header.Caption = "T. Piezas"
            ugvElementos.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
            ugvElementos.DisplayLayout.Bands(0).Columns("pesoVolumen").Header.Caption = "Peso Volumen"
            ugvElementos.DisplayLayout.Bands(0).Columns("idDolly").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("dolly").Header.Caption = "Dolly"
            ugvElementos.DisplayLayout.Bands(0).Columns("idDetalleAcarreoElemento").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvElementos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvElementos.DoubleClickCell
        Try
            If existAcarreo Then
                'Dim vista As New DataView(dtDetalleProceso)
                'vista.Sort = "dae desc"
                Dim cont As Integer = 0
                If Not ugvElementos.ActiveRow.Cells("elemento").Value = String.Empty Then
                    Dim isStack As Boolean = False
                    For Each r As DataRow In dtStackPallet.Rows
                        If ugvElementos.ActiveRow.Cells("elemento").Value = r.Item("idElemento") Then
                            isStack = True
                        End If
                    Next
                    'ini jro 08012020 verificacion de daes en los elemtos a los ws de la SENAE
                    Dim row As DataRow()
                    Dim displayView = New DataView(dtDetalleProceso)
                    Dim subset As DataTable = displayView.ToTable(True, "dae", "idElemento")
                    Dim dtValidezDae As DataTable
                    Dim B_ExitFor As Boolean = False
                    row = subset.Select("idElemento='" & ugvElementos.ActiveRow.Cells("elemento").Value & "'")
                    If row.Count > 0 Then
                        For Each r As DataRow In row
                            B_ExitFor = False
                            If r.Item("dae") <> String.Empty And r.Item("dae") <> "" And r.Item("dae") <> "00000000000000000" Then
                                dtValidezDae = SearchDAE(r.Item("dae"))
                                For Each rowDaeVali As DataRow In dtValidezDae.Rows
                                    If rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Or _
                                       rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                                        frmAlert.S_Mensaje = "La Dae " & r.Item("dae") & " que se encuentra en el Elemento " & ugvElementos.ActiveRow.Cells("elemento").Value & " Posee el siguiente estado: " & rowDaeVali.Item("ExaminationChannelName")
                                        'frmAlert.S_ColorFondo = "Rojo"
                                        frmAlert.I_Tamaño = 20
                                        frmAlert.B_Negrita = True
                                        frmAlert.B_MensajeSupervision = True
                                        frmAlert.S_MensajeSupervision = "Desea Realizar el Acarreo con la Clave y Usuario de un Supervisor"
                                        frmAlert.C_Usuario.S_Proceso = "Acarreo"
                                        frmAlert.C_Usuario.S_UsuarioProduc = MyCurrentUser.userId
                                        frmAlert.C_Usuario.S_Observacion = "Se procede a Realizar el Acarreo con la DAE " & r.Item("dae") & " que se encuentra en el Elemento " & ugvElementos.ActiveRow.Cells("elemento").Value & " Posee el siguiente estado: " & rowDaeVali.Item("ExaminationChannelName")
                                        frmAlert.ShowDialog()
                                        'MessageBox.Show("La Dae " & r.Item("dae") & " que se encuentra en el Elemento " & ugvElementos.ActiveRow.Cells("elemento").Value &
                                        '                " Posee el siguiente estado: " & rowDaeVali.Item("ExaminationChannelName"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        If frmAlert.B_MensajeSupervision = False Then
                                            Exit Sub
                                        Else
                                            B_ExitFor = True
                                            Exit For
                                        End If
                                    End If
                                Next
                            End If
                            If B_ExitFor Then
                                Exit For
                            End If
                        Next
                    End If
                    'fin jro 08012020 verificacion de daes en los elemtos a los ws de la SENAE
                    'For Each RowDae As DataRow In vista.ToTable(True, "dae", "idElemento").Rows
                    '    Try
                    '        dtValidezDae = SearchDAE(RowDae.Item(0))
                    '        For Each rowDaeVali As DataRow In dtValidezDae.Rows
                    '            If RowDae.Item(1) = ugvElementos.ActiveRow.Cells("elemento").Value Then
                    '                If rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Or _
                    '                   rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                    '                    MessageBox.Show("La Dae " & RowDae.Item(0) & " que se encuentra en el Elemento " & ugvElementos.ActiveRow.Cells("elemento").Value &
                    '                                    " Posee el siguiente estado: " & rowDaeVali.Item("ExaminationChannelName"), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '                    Exit Sub
                    '                End If
                    '                'If IsDBNull(rowDaeVali.Item("ExaminationChannelName")) Then
                    '                '    rowVista.Item("estado") = "SE"
                    '                'ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO AUTOMATICO" Then
                    '                '    rowVista.Item("estado") = "AA"
                    '                'ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO FISICO INTRUSIVO" Then
                    '                '    rowVista.Item("estado") = "AF"
                    '                'ElseIf rowDaeVali.Item("ExaminationChannelName") = "AFORO DOCUMENTAL" Then
                    '                '    rowVista.Item("estado") = "AD"
                    '                'Else
                    '                '    rowVista.Item("estado") = "VM"
                    '                'End If
                    '            End If
                    '        Next
                    '    Catch ex As Exception
                    '        For Each rowVista As DataRowView In vista
                    '            If rowVista.Item("dae") = RowDae.Item(0) Then
                    '                rowVista.Item("estado") = "VM"
                    '            End If
                    '        Next
                    '    End Try
                    'Next
                    If isStack Then
                        '    If MessageBox.Show("El Elemento seleccionado pertece a un Stack. ¿Desea editarlo?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        '        Using frmStackPallets As New frmStackPallets(idProceso, dtStackPallet)
                        '            frmStackPallets.ShowDialog()
                        '            dtStackPallet = frmStackPallets.dtStackAcarreo
                        '        End Using
                        '        llenarStackEnAcarreo()
                        '        Exit Sub
                        '    End If
                        ShowAcarreoDetails(myDetalleVuelo.idBriefing)
                        If myDetalleAcarreo.idAcarreo = Guid.Empty Then
                            Exit Sub
                        End If
                        If ugvElementos.ActiveRow.Cells("idDolly").Value.ToString = "" Then
                            If SaveDetalleAcarreoStack(ugvElementos.ActiveRow.Cells("elemento").Value) Then
                                dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                                infodtDetalleAcarreoElementoToObjet()
                            End If
                        Else
                            For Each r As DataRow In dtStackPallet.Rows
                                If r.Item("idElemento") = ugvElementos.ActiveRow.Cells("elemento").Value Or r.Item("isBase") = ugvElementos.ActiveRow.Cells("elemento").Value Then
                                    If SaveDetalleAcarreoElemento(r.Item("idElemento"), r.Item("peso")) Then
                                        dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                                        infodtDetalleAcarreoElementoToObjet()
                                    End If
                                End If
                            Next
                        End If
                    Else
                        For Each r As DataRow In dtElementosProceso.Rows
                            If r.Item("idElemento") = ugvElementos.ActiveRow.Cells("elemento").Value Then
                                cont += 1
                            End If
                        Next
                        If cont = 0 Then
                            If MessageBox.Show("El Elemento seleccionado no ha pasado por el proceso de comparación de peso. ¿Desea Continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            Else
                                Dim frmCheck As New frmCheckUserManager
                                frmCheck.ShowDialog()
                                If Not frmCheck.result Then
                                    Exit Sub
                                End If
                                Dim usuarioPermiso As New Server.ReportService.ContactoCatalogItem
                                usuarioPermiso = CommonData.GetContactoItem(frmCheck.tempUserManager.userName)
                                EnviarReporteCheckUserManager("Acarreo del El Elemento " & ugvElementos.ActiveRow.Cells("elemento").Value & " sin haber pasado por el proceso de comparación de peso", usuarioPermiso, usuarioRequiere)
                            End If
                            'ShowAcarreoDetails(myDetalleVuelo.idBriefing)
                            'If myDetalleAcarreo.idAcarreo = Guid.Empty Then
                            '    Exit Sub
                            'End If
                            'If ugvElementos.ActiveRow.Cells("idDolly").Value.ToString = "" Then
                            '    If SaveDetalleAcarreoElemento(True) Then
                            '        dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                            '        infodtDetalleAcarreoElementoToObjet()
                            '    End If
                            'Else
                            '    myDetalleAcarreoElemento.IdDetalle = ugvElementos.ActiveRow.Cells("idDetalleAcarreoElemento").Value
                            '    If SaveDetalleAcarreoElemento(False) Then
                            '        dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                            '        infodtDetalleAcarreoElementoToObjet()
                            '    End If
                            'End If
                        Else
                            ShowAcarreoDetails(myDetalleVuelo.idBriefing)
                            If myDetalleAcarreo.idAcarreo = Guid.Empty Then
                                Exit Sub
                            End If
                            If ugvElementos.ActiveRow.Cells("idDolly").Value.ToString = "" Then
                                If SaveDetalleAcarreoElemento(True) Then
                                    dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                                    infodtDetalleAcarreoElementoToObjet()
                                End If
                            Else
                                myDetalleAcarreoElemento.IdDetalle = ugvElementos.ActiveRow.Cells("idDetalleAcarreoElemento").Value
                                If SaveDetalleAcarreoElemento(False) Then
                                    dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                                    infodtDetalleAcarreoElementoToObjet()
                                End If
                            End If
                        End If
                        'ShowAcarreoDetails(myDetalleVuelo.idBriefing)
                        'If myDetalleAcarreo.idAcarreo = Guid.Empty Then
                        '    Exit Sub
                        'End If
                        'If ugvElementos.ActiveRow.Cells("idDolly").Value.ToString = "" Then
                        '    If SaveDetalleAcarreoElemento(True) Then
                        '        dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                        '        infodtDetalleAcarreoElementoToObjet()
                        '    End If
                        'Else
                        '    myDetalleAcarreoElemento.IdDetalle = ugvElementos.ActiveRow.Cells("idDetalleAcarreoElemento").Value
                        '    If SaveDetalleAcarreoElemento(False) Then
                        '        dtDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoElementoPorIdAcarreo(myDetalleAcarreo.IdDetalle)
                        '        infodtDetalleAcarreoElementoToObjet()
                        '    End If
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                                       & "Vuelo: " & txtVuelo.Text.ToUpper & vbCrLf _
                                       & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje."
            General.SendCheckUserManagerReportsMessage(msj, destinatarios, tipoDePermiso)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub

    Private Sub ShowAcarreoDetails(briefing As Guid)
        Using frmDetails As New frmDetalleAcarreo(briefing)
            frmDetails.ShowDialog()
            myDetalleAcarreo = frmDetails.myDetalleAcarreo
        End Using
    End Sub

    Private Function SaveDetalleAcarreoElemento(isnew As Boolean)
        Dim result As Boolean = False
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myDetalleAcarreoElemento) Then myDetalleAcarreoElemento = New DetalleAcarreoElementoItem
            If isnew Then
                myDetalleAcarreoElemento.IdDetalle = Guid.NewGuid
            End If
            myDetalleAcarreoElemento.idDetalleAcarreo = myDetalleAcarreo.IdDetalle
            myDetalleAcarreoElemento.idElemento = ugvElementos.ActiveRow.Cells("elemento").Value
            myDetalleAcarreoElemento.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
            myDetalleAcarreoElemento.peso = ugvElementos.ActiveRow.Cells("pesoReal").Value
            req.myDetalleAcarreoElementoItem = myDetalleAcarreoElemento
            res = WsClnt.SaveDetalleAcarreoElementoItem(req)
            If res.ActionResult Then
                result = True
                SaveEstadoElemento()
            Else
                result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function SaveDetalleAcarreoElemento(idElemento As String, peso As Decimal)
        Dim result As Boolean = False
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myDetalleAcarreoElemento) Then myDetalleAcarreoElemento = New DetalleAcarreoElementoItem
            'If isnew Then
            '    myDetalleAcarreoElemento.IdDetalle = Guid.NewGuid
            'End If
            myDetalleAcarreoElemento.idDetalleAcarreo = myDetalleAcarreo.IdDetalle
            myDetalleAcarreoElemento.idElemento = idElemento
            myDetalleAcarreoElemento.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
            myDetalleAcarreoElemento.peso = peso
            req.myDetalleAcarreoElementoItem = myDetalleAcarreoElemento
            res = WsClnt.SaveDetalleAcarreoElementoItem(req)
            If res.ActionResult Then
                result = True
                SaveEstadoElemento()
            Else
                result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub infodtDetalleAcarreoElementoToObjet()
        Try
            For Each r As DataRow In dtDetalleAcarreoElemento.Rows
                myDetalleAcarreo = CommonProcess.GetDetalleAcarreoPorId(r.Item("idDetalleAcarreo"))
                For Each r2 As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                    If r.Item("idElemento") = r2.Cells.Item("elemento").Value Then
                        r2.Cells.Item("idDolly").Value = myDetalleAcarreo.idDolly
                        r2.Cells.Item("dolly").Value = CommonData.GetDollyItem(myDetalleAcarreo.idDolly).codigo
                        r2.Cells.Item("idDetalleAcarreoElemento").Value = r.Item("idDetalle")
                    End If
                Next
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveEstadoElemento()
        Dim result As Boolean = False
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            myElemento.Id = myDetalleAcarreoElemento.idElemento
            myElemento.pesoActual = myDetalleAcarreoElemento.peso
            myElemento.estado = "S"
            General.SetBARequest(req)
            req.myElementoItem = myElemento
            res = WsClnt.SaveEstadoElemento(req)
            If res.ActionResult Then
                result = True
                Try
                    Dim resul As Boolean
                    Dim elementoHistorico As New ElementoHistoricoItem
                    elementoHistorico.Id = Guid.NewGuid
                    elementoHistorico.idElemento = myElemento.Id
                    elementoHistorico.pesoElemento = myElemento.pesoActual
                    elementoHistorico.estadoElemento = myElemento.estado
                    elementoHistorico.tipoRegistro = "SAL"
                    elementoHistorico.fecha = DateTime.Now
                    elementoHistorico.usuario = MyCurrentUser.userName
                    elementoHistorico.idProceso = proceso.IdProceso
                    elementoHistorico.idVuelo = myDetalleVuelo.idBriefing
                    resul = CommonData.SaveElementoHistorico(elementoHistorico)
                Catch ex As Exception
                    ErrorManager.SetLogEvent(ex)
                End Try
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub agregarElementosVacios()
        Dim dtElementos As New DataTable("Elementos")
        Dim dtTempElementos As New DataTable("TempElementos")
        Dim elementoBriefing As New Server.VuelosService.ElementoBriefingItem
        Try

            With dtTempElementos.Columns
                .Add("elemento", GetType(String))
            End With
            elementoBriefing.idBriefing = myDetalleVuelo.idBriefing
            dtElementos = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefing)
            For Each r As DataRow In dtTotalElementos.Rows
                Dim nr As DataRow
                nr = dtTempElementos.NewRow
                nr.Item("elemento") = r.Item("elemento")
                dtTempElementos.Rows.Add(nr)
            Next
            Dim exist As Boolean = False
            For Each r As DataRow In dtElementos.Rows
                exist = False
                Dim nr As DataRow
                For Each r2 As DataRow In dtTempElementos.Rows
                    If r2.Item("elemento") = r.Item("idElemento") Then
                        exist = True
                    End If
                Next
                If Not exist Then
                    nr = dtTotalElementos.NewRow
                    nr.Item("elemento") = r.Item("idElemento")
                    nr.Item("totalBultos") = 0
                    nr.Item("totalPiezas") = 0
                    nr.Item("pesoReal") = 0
                    nr.Item("pesoVolumen") = 0
                    dtTotalElementos.Rows.Add(nr)
                End If
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub consultaElementoProceso(idProceso As Guid)
        Try
            dtElementosProceso = CommonProcess.GetElementoProcesoPorIdProcesoYEstado(idProceso)
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnStack_Click(sender As Object, e As EventArgs) Handles btnStack.Click
    '    Try
    '        Using frmStackPallets As New frmStackPallets(idProceso, dtStackPallet)
    '            frmStackPallets.ShowDialog()
    '            dtStackPallet = frmStackPallets.dtStackAcarreo
    '        End Using
    '        llenarStackEnAcarreo()
    '    Catch ex As Exception
    '        General.SetLogEvent(ex)
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub llenarStackEnAcarreo()
    '    Try
    '        Dim exist As Boolean = False
    '        For Each r As DataRow In dtStackPallet.Rows
    '            If r.Item("estado") = "BASE" Then
    '                exist = False
    '                Dim nr As DataRow
    '                For Each r2 As DataRow In dtTotalElementos.Rows
    '                    If r2.Item("elemento") = r.Item("idElemento") Then
    '                        exist = True
    '                    End If
    '                Next
    '                If Not exist Then
    '                    nr = dtTotalElementos.NewRow
    '                    nr.Item("elemento") = r.Item("idElemento")
    '                    nr.Item("totalBultos") = 0
    '                    nr.Item("totalPiezas") = 0
    '                    nr.Item("pesoReal") = 0
    '                    nr.Item("pesoVolumen") = 0
    '                    dtTotalElementos.Rows.Add(nr)
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception
    '        General.SetLogEvent(ex)
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Function SaveDetalleAcarreoStack(idElemento As String) As Boolean
        Dim result As Boolean = False
        For Each r As DataRow In dtStackPallet.Rows
            If r.Item("idElemento") = idElemento Or r.Item("isBase") = idElemento Then
                Dim req As New AcarreoRequest
                Dim res As New AcarreoResponse
                Dim WsClnt As New ProcesoServiceSoapClient
                Try
                    General.SetBARequest(req)
                    If IsNothing(myDetalleAcarreoElemento) Then myDetalleAcarreoElemento = New DetalleAcarreoElementoItem
                    myDetalleAcarreoElemento.idDetalleAcarreo = myDetalleAcarreo.IdDetalle
                    myDetalleAcarreoElemento.idElemento = r.Item("idElemento")
                    myDetalleAcarreoElemento.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
                    myDetalleAcarreoElemento = CommonProcess.GetDetalleAcarreoStack(myDetalleAcarreoElemento)
                    If IsNothing(myDetalleAcarreoElemento) Then myDetalleAcarreoElemento = New DetalleAcarreoElementoItem
                    If myDetalleAcarreoElemento.IdDetalle = Guid.Empty Then
                        myDetalleAcarreoElemento.IdDetalle = Guid.NewGuid
                        myDetalleAcarreoElemento.idDetalleAcarreo = myDetalleAcarreo.IdDetalle
                        myDetalleAcarreoElemento.idElemento = r.Item("idElemento")
                        myDetalleAcarreoElemento.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
                    End If
                    myDetalleAcarreoElemento.peso = r.Item("peso")
                    req.myDetalleAcarreoElementoItem = myDetalleAcarreoElemento
                    res = WsClnt.SaveDetalleAcarreoElementoItem(req)
                    If res.ActionResult Then
                        result = True
                        SaveEstadoElemento()
                    Else
                        result = False
                        Throw New Exception(res.ErrorMessage)
                    End If
                Catch ex As Exception
                    General.SetLogEvent(ex)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next
        Return result
    End Function

    Private Sub agregarStack()
        Dim dtElementos As New DataTable("Elementos")
        Dim dtTempElementos As New DataTable("TempElementos")
        Try

            With dtTempElementos.Columns
                .Add("elemento", GetType(String))
                .Add("peso", GetType(Decimal))
            End With
            dtElementos = CommonProcess.GetStackPalletsPorIdProceso(proceso.IdProceso)
            dtStackPallet = CommonProcess.GetStackPalletsPorIdProceso(proceso.IdProceso)
            For Each r As DataRow In dtTotalElementos.Rows
                Dim nr As DataRow
                nr = dtTempElementos.NewRow
                nr.Item("elemento") = r.Item("elemento")
                nr.Item("peso") = r.Item("pesoReal")
                dtTempElementos.Rows.Add(nr)
            Next
            Dim exist As Boolean = False
            For Each r As DataRow In dtElementos.Rows
                If r.Item("isBase") = "B" Then
                    Dim pesoStack As Decimal = 0D
                    pesoStack = r.Item("peso")
                    For Each r2 As DataRow In dtElementos.Rows
                        If r2.Item("isBase") = r.Item("idElemento") Then
                            pesoStack += r2.Item("peso")
                        End If
                    Next
                    exist = False
                    Dim nr As DataRow
                    For Each r2 As DataRow In dtTempElementos.Rows
                        If r2.Item("elemento") = r.Item("idElemento") Then
                            exist = True
                        End If
                    Next
                    If Not exist Then
                        nr = dtTotalElementos.NewRow
                        nr.Item("elemento") = r.Item("idElemento")
                        nr.Item("totalBultos") = 0
                        nr.Item("totalPiezas") = 0
                        nr.Item("pesoReal") = pesoStack
                        nr.Item("pesoVolumen") = 0
                        dtTotalElementos.Rows.Add(nr)
                    End If
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex, "agregarStack")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAcarreo_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmAcarreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmAcarreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ModuloCierre.EndHilo = False
    End Sub

    Private Sub ugvElementos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugvElementos.InitializeLayout

    End Sub
End Class