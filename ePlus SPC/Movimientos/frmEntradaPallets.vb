Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports System.IO.Ports
Public Class frmEntradaPallets
    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"

    Dim dtElemento As New DataTable("Elementos")
    Dim myElemento As New ElementoCatalogItem
    Dim balanzaIsActive As Boolean = True
    Dim band_balanza As Boolean = False
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub frmEntradaPallets_Load(sender As Object, e As EventArgs) Handles Me.Load
        Configurar_Balanza()
        txtHoraIngreso.Text = Date.Now
        cargarComboAgencia()
    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX)).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
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
        End Try

    End Sub

#End Region

    Private Sub btnBuscarElemento_Click(sender As Object, e As EventArgs) Handles btnBuscarElemento.Click
        Try
            Dim frmConsultaElemento As New frmConsultaElementos
            frmConsultaElemento.isPesajeElemento = True
            frmConsultaElemento.ShowDialog()
            If frmConsultaElemento.Elemento.Id <> "" Then
                myElemento = frmConsultaElemento.Elemento
                txtElemento.Text = myElemento.Id
                txtAerolinea.Text = myElemento.descripcionAgencia
                txtAlto.Text = myElemento.alto
                txtAncho.Text = myElemento.ancho
                txtLargo.Text = myElemento.largo
                txtParedes.Text = myElemento.materialPared
                txtPesoRef.Text = myElemento.pesoReferencial
                txtPiso.Text = myElemento.materialPiso
                txtPuerta.Text = myElemento.materialPuerta
                txtTecho.Text = myElemento.materialTecho
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkPropio_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropio.CheckedChanged
        If chkPropio.Checked Then
            uceAgencia.Enabled = False
        Else
            uceAgencia.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtHoraIngreso.Text = Date.Now
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidaInfo() Then
                Exit Sub
            End If
            Dim Peso, pesoReal As Double
            'txtPeso.Text = "67.825"
            Peso = Double.Parse(Trim(txtPesoRef.Text))
            pesoReal = Double.Parse(Trim(txtPeso.Text))

            'If (Peso - pesoReal) < 2 Or (pesoReal - Peso) < 2 Then
            '    Dim frmCheck As New frmCheckManager
            '    With frmCheck
            '        .ShowDialog()
            '        If Not frmCheck.result Then
            '            Exit Sub
            '        End If
            '    End With
            'End If
            infoElementoToObject()
            SavePesoElemento()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub infoElementoToObject()
        myElemento.alto = CDbl(txtAlto.Text)
        myElemento.ancho = CDbl(txtAncho.Text)
        myElemento.fechaUltimaAct = CDate(txtHoraIngreso.Text)
        myElemento.largo = CDbl(txtLargo.Text)
        myElemento.pesoReferencial = Double.Parse(Trim(txtPesoRef.Text))
        myElemento.pesoReal = Double.Parse(Trim(txtPeso.Text))
        myElemento.obs = txtObservaciones.Text
        If chkRed.Checked Then
            myElemento.materialRed = "LON"
        Else
            myElemento.materialRed = "N/A"
        End If
    End Sub

    Private Sub SavePesoElemento()
        Dim result As Boolean = False
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            myElemento.estado = "D"
            General.SetBARequest(req)
            req.myElementoItem = myElemento
            res = WsClnt.SavePesoElemento(req)
            If res.ActionResult Then
                MessageBox.Show("Registro Actualizado con Éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SP1.Close()
                Try
                    Dim resul As Boolean
                    Dim elementoHistorico As New ElementoHistoricoItem
                    elementoHistorico.Id = Guid.NewGuid
                    elementoHistorico.idElemento = myElemento.Id
                    elementoHistorico.pesoElemento = myElemento.pesoReal
                    elementoHistorico.estadoElemento = myElemento.estado
                    elementoHistorico.tipoRegistro = "ACT"
                    elementoHistorico.fecha = DateTime.Now
                    elementoHistorico.usuario = MyCurrentUser.userName
                    elementoHistorico.idProceso = Guid.Empty
                    elementoHistorico.idVuelo = Guid.Empty
                    resul = CommonData.SaveElementoHistorico(elementoHistorico)
                    'MsgBox("save2")
                Catch ex As Exception
                    ErrorManager.SetLogEvent(ex)
                End Try

                Me.Close()
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidaInfo() As Boolean
        Dim result As Boolean = False
        Try
            If txtElemento.Text = "" Or txtAerolinea.Text = "" Or txtHoraIngreso.Text = "" Then
                MessageBox.Show("Faltan Datos Obligatorios", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
                Exit Function
            End If
            If (Not chkPropio.Checked) And uceAgencia.Text = "Escoja una Opción" Then
                MessageBox.Show("Ingrese Código de Agencia  del Prestamo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
                Exit Function
            End If
            If txtPeso.Text = "" Or txtPesoRef.Text = "" Then
                MessageBox.Show("Faltan Datos Obligatorios", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
                Exit Function
            End If
            result = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
        End Try
        Return result
    End Function

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        SP1.Close()
        Me.Close()
    End Sub
End Class