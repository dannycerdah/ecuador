Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.Server.ProcesoService
Public Class frmStackPallets
    Dim dtElemento As New DataTable("Elementos")
    Dim dtTempStack As New DataTable("stack")
    Dim dtStack As New DataTable("Stack")
    Dim idProceso As Guid = Guid.Empty
    Dim myDetalleVuelo As New DetalleVuelo
    Public Property dtStackAcarreo As New DataTable("Stack")
    Dim balanzaIsActive As Boolean = True
    Dim band_balanza As Boolean = False
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim pesoTotalStack As Decimal = 0D
    Dim elementoBase As String = ""

    'Public Sub New(proceso As Guid, dtStackP As DataTable)
    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()
    '    idProceso = proceso
    '    If dtStackP.Rows.Count > 0 Then
    '        dtTempStack = dtStackP
    '    End If
    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    'End Sub
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
                    If IsNumeric(text) Then
                        Me.txtPeso.Text = Double.Parse(CDbl(text) / Config.scDivisor)
                    End If
                    'Me.txtpesoreal.Text = Double.Parse(text.Substring(9, 7))
                End If
                SP1.DiscardInBuffer()
            End If

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        SP1.Close()
        Me.Close()
        ' Else
        ' Exit Sub
        'End If
    End Sub

    Private Sub Limpiar()
        txtElemento.Text = String.Empty
        dtElemento.Rows.Clear()
        dtStack.Rows.Clear()
    End Sub

    Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs) Handles txtElemento.ValueChanged
        If txtElemento.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub ConsultaElementos()
        Try
            For Each r As DataRow In CommonData.GetElementoCatalog.Rows
                If r.Item("estado") = "D" Or r.Item("estado") = "P" Then
                    Dim nr As DataRow
                    nr = dtElemento.NewRow
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("idAgencia") = r.Item("idAgencia")
                    nr.Item("tipoElemento") = r.Item("tipoElemento")
                    nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    nr.Item("pesoReal") = r.Item("pesoReal")
                    nr.Item("estado") = r.Item("estado")
                    dtElemento.Rows.Add(nr)
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElementos()
        ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
        ugvElementos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugvElementos.DisplayLayout.Bands(0).Columns("tipoElemento").Hidden = True
        ugvElementos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
        ugvElementos.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
        ugvElementos.DisplayLayout.Bands(0).Columns("estado").Hidden = True
    End Sub

    Private Sub SetDisplayedColumnsStack()
        ugvStack.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
        ugvStack.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugvStack.DisplayLayout.Bands(0).Columns("tipoElemento").Hidden = True
        ugvStack.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
        ugvStack.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
        ugvStack.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso Actual"
        ugvStack.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Base"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim resultR As Boolean = False
        Try
            If (CDec(txtPesoTot.Text) - CDec(txtPeso.Text)) > 10 Or (CDec(txtPesoTot.Text) - CDec(txtPeso.Text)) < -10 Then
                General.SetLogEvent("El peso registrado no es correcto: PesoElementos: " + txtPesoTot.Text + " PesoBascula: " + txtPeso.Text _
                                    + "Usuario: " + MyCurrentUser.userName + " Vuelo: " + txtVuelo.Text)
                MessageBox.Show("El peso registrado no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim cont As Integer = 0
            For Each r As DataRow In dtStack.Rows
                If r.Item("estado") = "B" Then
                    cont += 1
                End If
            Next
            If cont = 1 Then
                SaveStackElementos()
            Else
                MessageBox.Show("No se encuantra registrado ningún Elemento Base", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If resultR Then
            MessageBox.Show("Registro Actualizado con Éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub frmStackPallets_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            With dtElemento.Columns
                .Add("idElemento", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("tipoElemento", GetType(Guid))
                .Add("pesoReal", GetType(Decimal))
                .Add("estado", GetType(String))
            End With

            With dtStack.Columns
                .Add("idElemento", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("tipoElemento", GetType(Guid))
                .Add("pesoReal", GetType(Decimal))
                .Add("peso", GetType(Decimal))
                .Add("estado", GetType(String))
            End With
            If dtTempStack.Rows.Count <> 0 Then
                fillStackByObject()
            End If
            ugvElementos.DataSource = dtElemento
            SetDisplayedColumnsElementos()
            ugvStack.DataSource = dtStack
            SetDisplayedColumnsStack()
            ConsultaElementos()
            ugbElementos.Enabled = False
            ugbStack.Enabled = False
            btnSave.Enabled = False

            Configurar_Balanza()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub fillStackByObject()
        Try
            For Each r As DataRow In dtTempStack.Rows
                Dim nr As DataRow
                nr = dtStack.NewRow
                nr.Item("idElemento") = r.Item("idElemento")
                Dim tempElemento = CommonData.GetElementoItem(r.Item("idElemento"))
                nr.Item("idAgencia") = tempElemento.IdAgencia
                nr.Item("descripcionAgencia") = tempElemento.descripcionAgencia
                nr.Item("tipoElemento") = tempElemento.tipoElemento
                nr.Item("pesoReal") = tempElemento.pesoReal
                nr.Item("peso") = tempElemento.pesoActual
                'If r.Item("isBase") = "B" Then
                nr.Item("estado") = r.Item("isBase")
                'Else
                'nr.Item("estado") = ""
                'End If
                dtStack.Rows.Add(nr)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvElementos_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugvElementos.DoubleClickRow
        Try
            Dim peso As Decimal = 0D
            If ugvElementos.ActiveRow.Cells("idElemento").Value <> String.Empty Then
                If chkIsBase.Checked Then
                    For Each r As DataRow In dtStack.Rows
                        If r.Item("estado") = "B" Then
                            MessageBox.Show("Ya se encuantra registrado un elemento Base", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Next
                    elementoBase = ugvElementos.ActiveRow.Cells("idElemento").Value
                    Using frmPeso As New frmStackPalletsPeso
                        frmPeso.ShowDialog()
                        peso = frmPeso.peso
                    End Using
                    Dim nr As DataRow
                    nr = dtStack.NewRow
                    nr.Item("idElemento") = ugvElementos.ActiveRow.Cells("idElemento").Value
                    nr.Item("idAgencia") = ugvElementos.ActiveRow.Cells("idAgencia").Value
                    nr.Item("tipoElemento") = ugvElementos.ActiveRow.Cells("tipoElemento").Value
                    nr.Item("descripcionAgencia") = ugvElementos.ActiveRow.Cells("descripcionAgencia").Value
                    nr.Item("pesoReal") = ugvElementos.ActiveRow.Cells("pesoReal").Value
                    nr.Item("peso") = peso
                    nr.Item("estado") = "B"
                    dtStack.Rows.Add(nr)
                Else
                    Using frmPeso As New frmStackPalletsPeso
                        frmPeso.ShowDialog()
                        peso = frmPeso.peso
                    End Using
                    Dim nr As DataRow
                    nr = dtStack.NewRow
                    nr.Item("idElemento") = ugvElementos.ActiveRow.Cells("idElemento").Value
                    nr.Item("idAgencia") = ugvElementos.ActiveRow.Cells("idAgencia").Value
                    nr.Item("tipoElemento") = ugvElementos.ActiveRow.Cells("tipoElemento").Value
                    nr.Item("descripcionAgencia") = ugvElementos.ActiveRow.Cells("descripcionAgencia").Value
                    nr.Item("pesoReal") = ugvElementos.ActiveRow.Cells("pesoReal").Value
                    nr.Item("peso") = peso
                    nr.Item("estado") = elementoBase
                    dtStack.Rows.Add(nr)
                End If
                pesoTotalStack += peso
                txtPesoTot.Text = pesoTotalStack
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SaveStackElementos()
        Try
            If dtStack.Rows.Count > 0 Then
                Dim cont As Integer = 0
                Dim stackPallet As New StackPalletsItem
                For Each r As DataRow In dtStack.Rows
                    Dim result As Boolean = False
                    Dim req As New AcarreoRequest
                    Dim res As New AcarreoResponse
                    Dim WsClnt As New ProcesoServiceSoapClient
                    stackPallet.idProceso = idProceso
                    stackPallet.idElemento = r.Item("idElemento")
                    stackPallet.idContacto = MyCurrentUser.userName
                    stackPallet.fecha = Date.Now
                    'If r.Item("estado") = "BASE" Then stackPallet.isBase = "S"
                    stackPallet.isBase = r.Item("estado")
                    stackPallet.peso = r.Item("peso")
                    stackPallet.indice = Guid.NewGuid
                    stackPallet.estado = "A"

                    General.SetBARequest(req)
                    req.myStackPalletsItem = stackPallet
                    res = WsClnt.SaveStackPalletsItem(req)
                    If res.ActionResult Then
                        cont += 1
                    End If
                Next
                If dtStack.Rows.Count = cont Then
                    infoStackPalletToObject()
                    MessageBox.Show("Registros guardados con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("Error al guardar registros, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub infoStackPalletToObject()
        Try
            dtStackAcarreo = dtStack
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub btnConsultaVuelo_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            'Limpiar()
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
                ugbElementos.Enabled = True
                ugbStack.Enabled = True
                btnSave.Enabled = True
                idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
            End If
        Catch ex As Exception
            General.SetLogEvent(ex, "btnConsultaVuelo_Click")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ugvStack_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvStack.AfterRowsDeleted
        Try
            pesoTotalStack = 0D
            For Each r As DataRow In dtStack.Rows
                pesoTotalStack += r.Item("peso")
            Next
            txtPesoTot.Text = pesoTotalStack
        Catch ex As Exception
            General.SetLogEvent(ex, "ugvStack_AfterRowsDeleted")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   
End Class