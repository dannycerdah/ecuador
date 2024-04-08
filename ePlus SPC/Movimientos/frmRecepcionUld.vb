Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Diagnostics
Imports System.ComponentModel
Public Class frmRecepcionUld
    'Dim dtElemento As New DataTable("Elementos")
    Dim idAgenciaSeguridad As String = "d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"
    Dim idAgenciaTransporte As String = "6b18f807-1df9-42fa-a490-281e61ae9679"
    Dim idAgenciaGeneral As String = "1f2ebac3-c1b8-11e3-a62b-d43d7eb25e94"
    Dim idAgenciaRampa As String = "65ec9238-d302-49e9-bbb5-038e1caea03c"
    Dim idAgenciaCarga As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim myElemento As New ElementoCatalogItem
    Dim isSalida As Boolean = False
    Dim tempElemento As New ElementoCatalogItem
    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Dim Tipo As String = ""
    Dim dte As New DataTable("details")
    Dim t As Boolean
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim balanzaIsActive As Boolean = True
    Dim band_balanza As Boolean = False
    Dim isAKE As Boolean = False
    Dim dtElementosPreBriefing As New DataTable("ElementosPreBriefing")
    Dim isNewReport As Boolean = True
    Dim myUldHistoricoItem As New uldHistoricoItem
    Dim myUldHistoricoDetalle As New uldHistoricoDetalle
    Dim dtFotos As New DataTable("dtFotos")
    Dim idElementoHistorico As Guid 'MARZ
    Dim idElementoUld As Guid 'MARZ
    Dim myDetalleElemenPre As New ElementoPreBriefingItem 'JRO


    Public Sub New(ByVal esSalida As Boolean)

        ' Llamada necesaria para el diseñador.

        InitializeComponent()
        With dtFotos.Columns
            .Add("ruta", GetType(String))
            .Add("encabezado", GetType(String))
            .Add("Imagen", GetType(Byte()))
        End With
        If esSalida Then
            ugbInfoVuelo.Visible = False
            isSalida = True
            t = True
            ugbEntrega.Text = "RECIBE: "
            ugbRecibe.Text = "ENTREGA: "
            lblRecepcion.Text = "ENTREGA ELEMENTOS"
            lblprocedencia.Visible = False
            cmbProcedencia.Visible = False
            uceElementos.Visible = False
        Else
            ugbInfoVuelo.Visible = True
            ugbEntrega.Enabled = False
            ugbRecibe.Enabled = False
            ugbElementos.Enabled = False
            isSalida = False
            t = False
            ugbEntrega.Text = "ENTREGA: "
            ugbRecibe.Text = "RECIBE: "
            lblRecepcion.Text = "RECEPCION ELEMENTOS"
            txtElemento.Visible = False
            btnConsElemento.Visible = False
            lbldestino.Visible = False
            cmbDestino.Visible = False
        End If
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

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
            If capturaPeso Then
                DataIn = SP1.ReadExisting
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
            If capturaPeso Then
                If Me.txtpesoreal.InvokeRequired Then
                    Dim d As New SetTextCallback(AddressOf SetText)
                    Me.Invoke(d, New Object() {text})
                Else
                    text = text.Substring(Config.scStringBeginChar, Config.scStringEndChar - Config.scStringBeginChar)
                    If IsNumeric(text) Then
                        Me.txtpesoreal.Text = Double.Parse(CDbl(text) / Config.scDivisor)
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

    Private Sub cargarEmpSeg()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetAgenciaPorTipo(idAgenciaSeguridad)
            cmbempseg.Items.Add(Guid.Empty, "SELECCIONE UNA OPCION")
            For Each r As DataRow In dt.Rows
                cmbempseg.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            cmbempseg.SelectedIndex = 0
            'If Not IsNothing(dt) And dt.Rows.Count > 0 Then
            '    cmbempseg.DataSource = dt
            '    cmbempseg.DisplayMember = "descripcionAgencia"
            '    cmbempseg.ValueMember = "idAgencia"
            '    cmbempseg.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub cmbempSeg_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles cmbempseg.SelectionChangeCommitted 'JRO
    '    lbltgcustodia.Text = ""
    '    cmbcustodia.Items.Clear()
    '    cargarCustodio()
    'End Sub

    Private Sub cargarControl()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetContactoAgenciaPorIdAgencia(Guid.Parse(idAgenciaGeneral))
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbcontrol.Enabled = True
                For Each r As DataRow In dt.Rows
                    cmbcontrol.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                cmbcontrol.SelectedIndex = 0
            Else
                cmbcontrol.Text = String.Empty
                cmbcontrol.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarBascula()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetContactoAgenciaPorIdAgencia(Guid.Parse(idAgenciaGeneral))
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbbascula.Enabled = True
                For Each r As DataRow In dt.Rows
                    cmbbascula.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                cmbbascula.SelectedIndex = 0
            Else
                cmbbascula.Text = String.Empty
                cmbbascula.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarChoferDolly()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetContactoAgenciaPorIdAgencia(cmbMula.Value)
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbChoferDolly.Enabled = True
                For Each r As DataRow In dt.Rows
                    cmbChoferDolly.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                cmbChoferDolly.SelectedIndex = 0
            Else
                cmbChoferDolly.Text = String.Empty
                cmbChoferDolly.Enabled = False
                If IsShown Then
                    MessageBox.Show("No se encontró registrado ningún Chofer para esta compañia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'cmbchofer.ResetText()
                'cmbchofer.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarCustodio()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetContactoAgenciaPorIdAgencia(cmbempseg.Value)
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbcustodia.Enabled = True
                For Each r As DataRow In dt.Rows
                    cmbcustodia.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                cmbcustodia.SelectedIndex = 0
            Else
                cmbcustodia.Text = String.Empty
                cmbcustodia.Enabled = False
                MessageBox.Show("No se encuentró registrado ningún Custodio para esta compañia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cmbcustodia.Items.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbcustodia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        If Not chckSinCustodio.Checked Then
            If Not cmbcustodia.Text = "" Then
                Dim dt As New DataTable("contacto")
                dt = CommonData.GetContactoAgenciaPorIdContacto(cmbcustodia.Value)
                If Not IsNothing(dt) Then
                    For Each r As DataRow In dt.Rows
                        lbltgcustodia.Text = r.Item("tagsaContacto")
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub cmbcontrol_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub cmbbasacula_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub cargarCombos()
        cargarEmpSeg()
        cargarControl()
        cargarBascula()
        cargarMula()
        cargarnumMula()
    End Sub

    Private Sub cargarnumMula()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetDollyCatalog
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbNumMula.DataSource = dt
                cmbNumMula.DisplayMember = "codigoDolly"
                cmbNumMula.ValueMember = "idDolly"
                cmbNumMula.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub cargarMula()
        Dim dt As New DataTable
        Try
            dt = CommonData.GetAgenciaPorTipo(idAgenciaRampa)
            cmbMula.Items.Add(Guid.Empty, "SELECCIONE UNA OPCION")
            For Each r As DataRow In dt.Rows
                cmbMula.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            cmbMula.SelectedIndex = 0
            'If Not IsNothing(dt) And dt.Rows.Count > 0 Then
            '    cmbMula.DataSource = dt
            '    cmbMula.DisplayMember = "descripcionAgencia"
            '    cmbMula.ValueMember = "idAgencia"
            '    cmbMula.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmULD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        capturaPeso = False
    End Sub


    Private Sub frmULD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Configurar_Balanza()
        With dte.Columns
            .Add("Hora", GetType(DateTime))
            .Add("Procedencia", GetType(String))
            .Add("Destino", GetType(String))
            .Add("CodigoElemento", GetType(String))
            .Add("numMula", GetType(String))
            .Add("Chofer", GetType(String))
            .Add("TagsaChofer", GetType(String))
            .Add("Custodio", GetType(String))
            .Add("TagsaCustodio", GetType(String))
            .Add("Control", GetType(String))
            .Add("TagsaControl", GetType(String))
            .Add("Bascula", GetType(String))
            .Add("TagsaBascula", GetType(String))
            .Add("PesoRef", GetType(Double))
            .Add("PesoReal", GetType(Double))
        End With
        cargarCombos()
        cmbProcedencia.SelectedIndex = 0
        cmbDestino.SelectedIndex = 0
        lblFecha.Text = DateAndTime.Now.ToString()
    End Sub

    Private Sub uldGenerate()
        Try
            Dim uld As New EncabezadoUld()
            uld.EmpTrans = cmbMula.Text
            uld.EmpSeg = cmbempseg.Text
            uld.chofer = cmbChoferDolly.Text
            uld.tagsaChofer = lbltagchofer.Text
            If Not chckSinCustodio.Checked Then
                uld.custodio = cmbcustodia.Text
            Else
                uld.custodio = "Sin Custodio"
            End If
            uld.tagsaCustodio = lbltgcustodia.Text
            uld.control = cmbcontrol.Text
            uld.tagsaControl = lbltagcontrol.Text
            uld.bascula = cmbbascula.Text
            uld.tgsaBascula = lbltagbascula.Text
            uld.fecha = lblFecha.Text
            uld.tipo = t
            uld.Procedencia = cmbProcedencia.Text
            uld.Destino = cmbDestino.Text

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                Dim elem As New elementoUld()
                elem.Hora = row.Cells("Hora").Value
                elem.CodigoElemento = row.Cells("CodigoElemento").Value
                elem.Chofer = row.Cells("Chofer").Value
                elem.numMula = row.Cells("numMula").Value
                elem.TagsaChofer = row.Cells("TagsaChofer").Value
                elem.Custodio = row.Cells("Custodio").Value
                elem.TagsaCustodio = row.Cells("TagsaCustodio").Value
                elem.Control = row.Cells("Control").Value
                elem.TagsaControl = row.Cells("TagsaControl").Value
                elem.Bascula = row.Cells("Bascula").Value
                elem.TagsaBascula = row.Cells("TagsaBascula").Value
                elem.PesoRef = row.Cells("PesoRef").Value
                elem.PesoReal = row.Cells("PesoReal").Value
                uld.Detalle.Add(elem)
            Next
            Dim frm As New RptUld()
            frm.uld.Add(uld)
            frm.Detail = uld.Detalle
            'frm.aerolinea =
            frm.ShowDialog()
        Catch
            MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProcesar_Click_1(sender As Object, e As EventArgs) Handles btnProcesar.Click
        'txtpesoreal.Text = 71
        Dim elemento As String = String.Empty
        Dim elementoPreBriefing As New Server.ReportService.ElementoPreBriefingItem
        If Not isSalida Then
            elemento = uceElementos.Text
        Else
            elemento = txtElemento.Text
        End If
        If elemento = "" Or txtpesoreal.Text = "" Or txtpesoref.Text = "" _
        Or cmbProcedencia.Text = "" Or cmbDestino.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos correspondientes al elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim nwRow1 As DataRow
        Dim eleCodigo As String
        eleCodigo = elemento
        Try
            myElemento.pesoReferencial = CDec(txtpesoref.Text)
            myElemento.pesoReal = CDec(txtpesoreal.Text)
            myElemento.Id = eleCodigo
            If Not isSalida Then
                'If Not isAKE Then
                If CDec(txtpesoreal.Text) < 1 Then
                    MessageBox.Show("Error al registrar el peso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'End If
                If SaveElemento() Then
                    nwRow1 = dte.NewRow
                    nwRow1.Item("CodigoElemento") = eleCodigo
                    If cmbProcedencia.Text = "" Then
                        MessageBox.Show("Debe seleccionar la Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If cmbDestino.Text = "" Then
                        MessageBox.Show("Debe seleccionar el Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If cmbNumMula.Text = "" Then
                        MessageBox.Show("Debe seleccionar Numero de Mula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        nwRow1.Item("numMula") = cmbNumMula.Text
                    End If
                    If cmbChoferDolly.Text = "" Then
                        MessageBox.Show("Debe seleccionar Chofer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        nwRow1.Item("Chofer") = cmbChoferDolly.Text
                    End If
                    nwRow1.Item("TagsaChofer") = lbltagchofer.Text
                    If Not chckSinCustodio.Checked Then
                        If cmbcustodia.Text = "" Then
                            nwRow1.Item("Custodio") = ""
                            MessageBox.Show("Debe seleccionar Custodio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else
                            nwRow1.Item("Custodio") = cmbcustodia.Text
                        End If
                        nwRow1.Item("TagsaCustodio") = lbltgcustodia.Text
                    Else

                        nwRow1.Item("Custodio") = "Sin Custodio"
                        nwRow1.Item("TagsaCustodio") = ""
                    End If
                    If cmbcontrol.Text = "" Then
                        nwRow1.Item("Control") = ""
                        MessageBox.Show("Debe seleccionar Control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        nwRow1.Item("Control") = cmbcontrol.Text
                    End If
                    nwRow1.Item("TagsaControl") = lbltagcontrol.Text
                    If cmbbascula.Text = "" Then
                        nwRow1.Item("Bascula") = ""
                        MessageBox.Show("Debe seleccionar Bascula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        nwRow1.Item("Bascula") = cmbbascula.Text
                    End If
                    nwRow1.Item("TagsaBascula") = lbltagbascula.Text
                    nwRow1.Item("PesoRef") = txtpesoref.Text
                    nwRow1.Item("PesoReal") = txtpesoreal.Text
                    nwRow1.Item("Hora") = Date.Now
                    dte.Rows.Add(nwRow1)
                    If isNewReport Then
                        saveUldHistoricoItem()
                    End If
                    saveUldHistoricoDetalleItem()
                    ugvElementos.DataSource = dte
                    txtElemento.Clear()
                    txtpesoref.Clear()
                    elementoPreBriefing.idElemento = uceElementos.Text
                    elementoPreBriefing.idBriefing = myDetalleElemenPre.idBriefing
                    elementoPreBriefing.estado = "E"
                    elementoPreBriefing.UsuarioDelete = MyCurrentUser.userName
                    elementoPreBriefing.indice = idElementoHistorico
                    EliminaElementoPreAlert(elementoPreBriefing)
                End If
            Else
                nwRow1 = dte.NewRow
                nwRow1.Item("CodigoElemento") = eleCodigo
                ' If Not isAKE Then
                If CDec(txtpesoreal.Text) < 1 Then
                    MessageBox.Show("Error al registrar el peso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ' End If
                If cmbProcedencia.Text = "" Then
                    MessageBox.Show("Debe seleccionar la Procedencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If cmbDestino.Text = "" Then
                    MessageBox.Show("Debe seleccionar el Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If cmbNumMula.Text = "" Then
                    MessageBox.Show("Debe seleccionar Numero de Mula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    nwRow1.Item("numMula") = cmbNumMula.Text
                End If
                If cmbChoferDolly.Text = "" Then
                    MessageBox.Show("Debe seleccionar Chofer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    nwRow1.Item("Chofer") = cmbChoferDolly.Text
                End If
                nwRow1.Item("TagsaChofer") = lbltagchofer.Text
                If Not chckSinCustodio.Checked Then
                    If cmbcustodia.Text = "" Then
                        nwRow1.Item("Custodio") = ""
                        MessageBox.Show("Debe seleccionar Custodio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        nwRow1.Item("Custodio") = cmbcustodia.Text
                    End If
                    nwRow1.Item("TagsaCustodio") = lbltgcustodia.Text
                Else
                    nwRow1.Item("Custodio") = "Sin Custodio"
                    nwRow1.Item("TagsaCustodio") = ""
                End If
                If cmbcontrol.Text = "" Then
                    nwRow1.Item("Control") = ""
                    MessageBox.Show("Debe seleccionar Control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    nwRow1.Item("Control") = cmbcontrol.Text
                End If
                nwRow1.Item("TagsaControl") = lbltagcontrol.Text
                If cmbbascula.Text = "" Then
                    nwRow1.Item("Bascula") = ""
                    MessageBox.Show("Debe seleccionar Bascula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    nwRow1.Item("Bascula") = cmbbascula.Text
                End If
                nwRow1.Item("TagsaBascula") = lbltagbascula.Text
                nwRow1.Item("PesoRef") = txtpesoref.Text
                nwRow1.Item("PesoReal") = txtpesoreal.Text
                nwRow1.Item("Hora") = Date.Now
                dte.Rows.Add(nwRow1)
                If isNewReport Then
                    saveUldHistoricoItem()
                End If
                saveUldHistoricoDetalleItem()
                tempElemento = CommonData.GetElementoItem(eleCodigo)
                If tempElemento.estado = "A" Or tempElemento.estado = "D" Or tempElemento.estado = "P" Then
                    tempElemento.estado = "S"
                    tempElemento.pesoReal = CDbl(txtpesoreal.Text)
                    tempElemento.usuarioIngreso = MyCurrentUser.userName
                    tempElemento.fechaUltimaAct = Date.Now
                    tempElemento.chofer = cmbChoferDolly.Value
                    If Not chckSinCustodio.Checked Then
                        tempElemento.custodio = cmbcustodia.Value
                    Else
                        tempElemento.custodio = "Sin Custodio"
                    End If
                    tempElemento.mula = cmbMula.Value
                    tempElemento.tempId = tempElemento.Id
                    SaveElemento()
                End If
                ugvElementos.DataSource = dte
                txtElemento.Clear()
                txtpesoref.Clear()
            End If
            'MRZ - Relacionar tablas uld_historico - elemento_historico
            If SaveHistoricoUld() Then
                idElementoHistorico = Guid.Empty
            End If
            'MRZ

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorManager.SetLogEvent(ex)
        End Try

    End Sub

    Function SaveHistoricoUld() As Boolean 'MARZ
        Dim result As Boolean = False
        Try
            Dim elementoHistoricoUld As New ElementoHUldCatalogItem
            elementoHistoricoUld.IdRegistro = idElementoHistorico
            elementoHistoricoUld.IdReporte = idElementoUld
            result = CommonData.SaveElementoHistoricoUld(elementoHistoricoUld)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return result
    End Function

    Private Function SaveElemento() As Boolean
        Dim result As Boolean = False
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            If Not isSalida Then
                myElemento.chofer = cmbChoferDolly.Value
                myElemento.mula = cmbNumMula.Value
                If Not chckSinCustodio.Checked Then
                    myElemento.custodio = cmbcustodia.Value
                Else
                    myElemento.custodio = "Sin Custodio"
                End If
                myElemento.estado = "D"
                myElemento.fechaUltimaAct = Date.Now
                myElemento.fechaIngresoPlataforma = Date.Now
                myElemento.usuarioIngreso = MyCurrentUser.userName
                myElemento.fileImgCondicion = ""
                If ChkMal.Checked = True Then
                    myElemento.fileImgCondicion = myElemento.Id & " " & DateTime.Now.ToString("dd-MM-yyyy")
                End If
                myElemento.observacion2 = txtObserv.Text
                General.SetBARequest(req)
                req.myElementoItem = myElemento
                res = WsClnt.SaveElementoIngresoPlataforma(req)
                If res.ActionResult Then
                    result = True
                    Try
                        Dim resul As Boolean
                        Dim elementoHistorico As New ElementoHistoricoItem
                        elementoHistorico.Id = Guid.NewGuid
                        elementoHistorico.idElemento = myElemento.Id
                        elementoHistorico.pesoElemento = myElemento.pesoReal
                        elementoHistorico.estadoElemento = myElemento.estado
                        elementoHistorico.tipoRegistro = "ING"
                        elementoHistorico.fecha = DateTime.Now
                        elementoHistorico.usuario = MyCurrentUser.userName
                        'elementoHistorico.idProceso = CommonProcess.GetProcesoPoridBriefing(resDtVuelo.idBriefing).IdProceso 'JRO
                        'elementoHistorico.idVuelo = resDtVuelo.idBriefing 'JRO
                        elementoHistorico.fileImgCondicion = myElemento.fileImgCondicion
                        elementoHistorico.observacion = myElemento.observacion2
                        idElementoHistorico = elementoHistorico.Id 'MARZ
                        resul = CommonData.SaveElementoHistorico(elementoHistorico)
                    Catch ex As Exception
                        ErrorManager.SetLogEvent(ex)
                    End Try
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                General.SetBARequest(req)
                myElemento = tempElemento
                req.myElementoItem = myElemento
                res = WsClnt.SaveElementoIngresoPlataforma(req)
                If res.ActionResult Then
                    result = True
                    Try
                        Dim resul As Boolean
                        Dim elementoHistorico As New ElementoHistoricoItem
                        elementoHistorico.Id = Guid.NewGuid
                        elementoHistorico.idElemento = myElemento.Id
                        elementoHistorico.pesoElemento = myElemento.pesoReal
                        elementoHistorico.estadoElemento = myElemento.estado
                        elementoHistorico.tipoRegistro = "SAL"
                        elementoHistorico.fecha = DateTime.Now
                        elementoHistorico.usuario = MyCurrentUser.userName
                        elementoHistorico.idProceso = Guid.Empty
                        elementoHistorico.idVuelo = Guid.Empty
                        idElementoHistorico = elementoHistorico.Id 'MARZ
                        resul = CommonData.SaveElementoHistorico(elementoHistorico)
                    Catch ex As Exception
                        ErrorManager.SetLogEvent(ex)
                    End Try
                    MessageBox.Show("Estado del Elemento actualizado con éxito", "Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub btnimprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If MessageBox.Show("Se guardará el documento y la ventana de Recepción/Entrega de ULD se cerrará" & vbLf & "¿Desea Continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        uldGenerate()
        'SP1.Close()
        ' Me.Close()
    End Sub

    Private Sub cmbMula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMula.SelectionChanged
        If cmbMula.Value <> Guid.Empty Then
            lbltagchofer.Text = ""
            cmbChoferDolly.Items.Clear()
            cargarChoferDolly()
        End If
    End Sub

    Private Sub cmbChoferDolly_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChoferDolly.SelectionChanged
        If Not cmbChoferDolly.Text = "" Then
            Try
                Dim dt As New DataTable("contacto")
                dt = CommonData.GetContactoAgenciaPorIdContacto(cmbChoferDolly.Value)
                If Not IsNothing(dt) Then
                    For Each r As DataRow In dt.Rows
                        lbltagchofer.Text = r.Item("tagsaContacto")
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Property IsShown As Boolean = False
    Private Sub frmULD_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        IsShown = True
    End Sub

    Private Sub btnConsElemento_Click(sender As Object, e As EventArgs) Handles btnConsElemento.Click
        Try
            Dim frmConsultaElemento As New frmConsultaElementos
            frmConsultaElemento.isEntradaElemento = True
            frmConsultaElemento.ShowDialog()
            If frmConsultaElemento.Elemento.Id <> "" Then
                myElemento = frmConsultaElemento.Elemento
                'For Each re As DataRow In dtElemento.Rows
                '    If elemeneto.Id = re.Item("idElemento") Then
                '        MessageBox.Show("Elemento ya Ingresado, Por favor verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        Exit Sub
                '    End If
                'Next
                'Dim r As DataRow
                'r = dtElemento.NewRow
                'r.Item("idElemento") = elemeneto.Id
                'r.Item("idAgencia") = elemenetoo.IdAgencia
                'r.Item("descripcionAgencia") = elemeneto.descripcionAgencia
                'r.Item("pesoRef") = elemeneto.pesoReferencial
                'r.Item("pesoReal") = elemeneto.pesoReal
                'r.Item("fechaIngreso") = elemeneto.fechaIngreso
                'r.Item("indice") = Guid.NewGuid
                'dtElemento.Rows.Add(r)

                txtElemento.Text = myElemento.Id
                txtpesoref.Text = myElemento.pesoReferencial
                Dim idElemento As String = String.Empty
                idElemento = myElemento.Id.Substring(0, 3)
                If idElemento <> "AKE" And Not isSalida Then
                    txtpesoreal.ReadOnly = True
                    isAKE = False
                Else
                    txtpesoreal.ReadOnly = False
                    isAKE = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chckSinCustodio_CheckedChanged(sender As Object, e As EventArgs) Handles chckSinCustodio.CheckedChanged
        If chckSinCustodio.Checked Then
            cmbcustodia.Enabled = False
            cmbempseg.Enabled = False
            lbltgcustodia.Enabled = False
        Else
            cmbcustodia.Enabled = True
            cmbempseg.Enabled = True
            lbltgcustodia.Enabled = True
        End If
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        SP1.Close()
        Me.Close()
    End Sub

    Private Sub btnConsultaVuelo_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        'Try
        '    Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
        '    frmConsultaVuelos.ShowDialog()
        '    If frmConsultaVuelos.Aerolinea <> String.Empty Then
        '        obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
        '        CargarVuelo(frmConsultaVuelos.Aerolinea)
        '        cargarPreElementos()
        '        ugbEntrega.Enabled = True
        '        ugbRecibe.Enabled = True
        '        ugbElementos.Enabled = True
        '    End If
        'Catch ex As Exception
        '    General.SetLogEvent(ex)
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        Try
            Dim frmConsultaVuelos As New frmConsultaPreElemento
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleElemenPre = frmConsultaVuelos.resDetPreElement
                txtVuelo.Text = myDetalleElemenPre.Vuelo
                cmbMula.Value = myDetalleElemenPre.IdRampa
                If myDetalleElemenPre.IdSeguridad = Guid.Empty Then
                    cmbempseg.Value = Guid.Empty
                Else
                    cmbempseg.Value = myDetalleElemenPre.IdSeguridad
                End If
                cmbProcedencia.Value = myDetalleElemenPre.Procedencia
                udtFecha.Value = myDetalleElemenPre.fecha
                cargarPreElementos()
                ugbEntrega.Enabled = True
                ugbRecibe.Enabled = True
                ugbElementos.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "ConsultaVuelo PreAlertElementos")
        End Try
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        Try
            txtVuelo.Text = resDtVuelo.codigoVuelo
            txtAvion.Text = resDtVuelo.descripcionAvion
            txtMatricula.Text = resDtVuelo.matriculaAvion
            udtFecha.Value = resDtVuelo.fechaVuelo
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

    Private Sub cargarPreElementos()
        Try
            Dim tempElementoPreBriefingItem As New ElementoPreBriefingItem
            'tempElementoPreBriefingItem.idBriefing = resDtVuelo.idBriefing 'JRO
            tempElementoPreBriefingItem.idBriefing = myDetalleElemenPre.idBriefing 'JRO
            dtElementosPreBriefing = CommonProcess.GetElementoPreBriefingPorIdBriefing(tempElementoPreBriefingItem)
            FillUcePreElementos()
        Catch ex As Exception
            General.SetLogEvent(ex, "cargarPreElementos")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillUcePreElementos()
        Try
            uceElementos.Items.Clear()
            If dtElementosPreBriefing.Rows.Count = 0 Then
                uceElementos.Items.Add(0, "Ningún elemento encontrado")
                btnProcesar.Enabled = False
            Else
                For Each r As DataRow In dtElementosPreBriefing.Rows
                    uceElementos.Items.Add(r.Item("pesoReferencial"), r.Item("idElemento"))
                Next
                btnProcesar.Enabled = True
            End If
            uceElementos.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex, "FillUcePreElementos")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uceElementos_SelectionChanged(sender As Object, e As EventArgs) Handles uceElementos.SelectionChanged
        Try
            If uceElementos.Text = "Ningún elemento encontrado" Then
                btnProcesar.Enabled = False
            Else
                btnProcesar.Enabled = True
            End If
            txtpesoref.Text = uceElementos.Value.ToString
        Catch ex As Exception
            General.SetLogEvent(ex, "uceElementos_SelectionChanged")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveUldHistoricoItem()
        Try
            Dim req As New uldHistoricoRequest
            Dim res As New uldHistoricoResponse
            Dim WsClnt As New ReportServiceSoapClient
            If myUldHistoricoItem.idReporte = Guid.Empty Then
                myUldHistoricoItem.idReporte = Guid.NewGuid
            End If
            If isSalida Then
                myUldHistoricoItem.tipo = "S"
            Else
                myUldHistoricoItem.tipo = "E"
            End If
            myUldHistoricoItem.fecha = Date.Now
            myUldHistoricoItem.procedencia = cmbProcedencia.Text
            myUldHistoricoItem.destino = cmbDestino.Text
            myUldHistoricoItem.idChofer = cmbChoferDolly.Value
            If Not chckSinCustodio.Checked Then
                myUldHistoricoItem.idCustodio = cmbcustodia.Value
            Else
                myUldHistoricoItem.idCustodio = "Sin Custodio"
            End If
            myUldHistoricoItem.idControl = cmbcontrol.Value
            myUldHistoricoItem.idBascula = cmbbascula.Value
            myUldHistoricoItem.idUsuario = MyCurrentUser.userName
            General.SetBARequest(req)
            req.myUldHistorico = myUldHistoricoItem
            idElementoUld = myUldHistoricoItem.idReporte 'MARZ
            res = WsClnt.SaveUldHistoricoItem(req)
            If Not res.ActionResult Then
                Throw New Exception(res.ErrorMessage)
            Else
                isNewReport = False
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "saveUldHistoricoItem")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saveUldHistoricoDetalleItem()
        Try
            Dim req As New uldHistoricoRequest
            Dim res As New uldHistoricoResponse
            Dim WsClnt As New ReportServiceSoapClient
            myUldHistoricoDetalle.idReporte = myUldHistoricoItem.idReporte
            myUldHistoricoDetalle.fecha = Date.Now
            myUldHistoricoDetalle.idDolly = cmbNumMula.Value
            If Not isSalida Then
                myUldHistoricoDetalle.idElemento = uceElementos.Text
            Else
                myUldHistoricoDetalle.idElemento = txtElemento.Text
            End If
            myUldHistoricoDetalle.idChofer = cmbChoferDolly.Value
            If Not chckSinCustodio.Checked Then
                myUldHistoricoDetalle.idCustodio = cmbcustodia.Value
            Else
                myUldHistoricoDetalle.idCustodio = "Sin Custodio"
            End If
            myUldHistoricoDetalle.idControl = cmbcontrol.Value
            myUldHistoricoDetalle.idBascula = cmbbascula.Value
            myUldHistoricoDetalle.pesoRef = CDec(txtpesoref.Text)
            myUldHistoricoDetalle.pesoReal = CDec(txtpesoreal.Text)
            General.SetBARequest(req)
            req.myUldHistoricoDetalle = myUldHistoricoDetalle
            res = WsClnt.SaveUldHistoricoDetalleItem(req)
            If Not res.ActionResult Then
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "saveUldHistoricoDetalleItem")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugbElementos_Click(sender As Object, e As EventArgs) Handles ugbElementos.Click

    End Sub


    Private Sub btnSelFoto_Click(sender As Object, e As EventArgs) Handles btnSelFoto.Click
        Dim timeStamp As Date = DateTime.Now
        'llamar a programa capturador
        Dim procs() As Process =
      Process.GetProcessesByName("amcap")
        ' If there is only one, it's us.
        If procs.Length <> 1 Then
            Dim process1 As System.Diagnostics.Process = New Process()
            Process.Start("C:\Program Files (x86)\Noël Danjou\AMCap\amcap.exe")
        End If

        If MessageBox.Show("Iniciando captura..." & vbLf & "De click en aceptar al terminar la captura.", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
            If procs.Length <> 1 Then

            End If
            Exit Sub
        End If
        If procs.Length <> 1 Then

        End If

        Dim filepath As String

        dtFotos.Clear()

        Dim strFilepath = "C:\imagenes de pruebas\"  'Specify path details
        If FileIO.FileSystem.DirectoryExists(strFilepath) Then
            Dim directory As New System.IO.DirectoryInfo(strFilepath)
            Dim File As System.IO.FileInfo() = directory.GetFiles()
            Dim File1 As System.IO.FileInfo
            For Each File1 In File
                Dim strLastModified As Date
                filepath = strFilepath & File1.ToString()
                strLastModified = System.IO.File.GetLastWriteTime(strFilepath & File1.ToString()) '.ToString
                If strLastModified > timeStamp Then
                    Dim R As DataRow = dtFotos.NewRow
                    R("ruta") = filepath
                    R("encabezado") = "Elemento: " + uceElementos.Text + " Fecha: " + Date.Now.ToString
                    dtFotos.Rows.Add(R)
                End If
            Next
            If dtFotos.Rows.Count <> 0 Then
                Dim frm As New RptFotosElementosMalaCondicion(dtFotos)
                frm.elemento = uceElementos.Text
                frm.Show()
            Else
                MessageBox.Show("No hubo foto alguna capturada, vuelva a tomar las fotos Gracias. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Directorio no existe: " + strFilepath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'ofdSelFotos.Multiselect = True
        'ofdSelFotos.ShowDialog()
        ' For Each filepath In ofdSelFotos.FileNames
        'Dim R As DataRow = dtFotos.NewRow
        'R("ruta") = filepath
        'R("encabezado") = "Elemento: " + uceElementos.Text + " Fecha: " + Date.Now.ToString
        '-fotos para dataset
        '- Dim instance As Image
        '-Dim stream As New MemoryStream
        '-instance = Image.FromFile(filepath)
        '-instance.Save(stream, Imaging.ImageFormat.Jpeg)
        '-R("Imagen") = stream.ToArray()
        'dtFotos.Rows.Add(R)
        'Next filepath


        'modo multiple 1 a 1
        'Dim resp As String = InputBox("Cuantas fotos desea adicionar? " + Chr(13) + "Recuerde al volver a dar click, ud borrara las fotos previas en caso de haberse ingresado.", "Adicionar fotos del elemento", "0")
        'If IsNumeric(resp) Then
        '    Dim total As Integer = Integer.Parse(resp)
        '    If total <> 0 Then
        '        For contador As Integer = 1 To total
        '            ofdSelFotos.Title = "Seleccione la foto # " + contador.ToString + "de " + total.ToString
        '            ofdSelFotos.ShowDialog()
        '            filepath = ofdSelFotos.FileName
        '        Next
        '    Else
        '        MessageBox.Show("No hubo cambio alguno", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Else
        '    MessageBox.Show("Valor debe ser un numero entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Private Sub ChkMal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMal.CheckedChanged
        btnSelFoto.Visible = ChkMal.Checked
    End Sub

    Private Sub EliminaElementoPreAlert(elementoPreBriefing As Server.ReportService.ElementoPreBriefingItem)
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim wsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myElementoPreBriefingItem = elementoPreBriefing
            res = wsClnt.SaveElementoPreBriefing(req)
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbempseg_SelectionChanged(sender As Object, e As EventArgs) Handles cmbempseg.SelectionChanged 'JRO
        If cmbempseg.Value <> Guid.Empty Then
            lbltgcustodia.Text = ""
            cmbcustodia.Items.Clear()
            cargarCustodio()
        End If
    End Sub

    Private Sub cmbcustodia_SelectionChanged(sender As Object, e As EventArgs) Handles cmbcustodia.SelectionChanged
        If Not chckSinCustodio.Checked Then
            If Not cmbcustodia.Text = "" Then
                Dim dt As New DataTable("contacto")
                dt = CommonData.GetContactoAgenciaPorIdContacto(cmbcustodia.Value)
                If Not IsNothing(dt) Then
                    For Each r As DataRow In dt.Rows
                        lbltgcustodia.Text = r.Item("tagsaContacto")
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub cmbcontrol_SelectionChanged(sender As Object, e As EventArgs) Handles cmbcontrol.SelectionChanged
        If Not cmbcontrol.Text = "" Then
            Dim dt As New DataTable("contacto")
            dt = CommonData.GetContactoAgenciaPorIdContacto(cmbcontrol.Value)
            If Not IsNothing(dt) Then
                For Each r As DataRow In dt.Rows
                    lbltagcontrol.Text = r.Item("tagsaContacto")
                Next
            End If
        End If
    End Sub

    Private Sub cmbbascula_SelectionChanged(sender As Object, e As EventArgs) Handles cmbbascula.SelectionChanged
        If Not cmbbascula.Text = "" Then
            Dim dt As New DataTable("contacto")
            dt = CommonData.GetContactoAgenciaPorIdContacto(cmbbascula.Value)
            If Not IsNothing(dt) Then
                For Each r As DataRow In dt.Rows
                    lbltagbascula.Text = r.Item("tagsaContacto")
                Next
            End If
        End If
    End Sub
End Class