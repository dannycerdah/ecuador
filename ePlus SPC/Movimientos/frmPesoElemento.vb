Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmPesoElemento
    Public Property myElemento As New ElementoCatalogItem
    Dim band_balanza As Boolean = False
    Dim DataIn As String = String.Empty
    Delegate Sub SetTextCallback(ByVal text As String)
    Public Property isSave As Boolean = False
    Public Property tempPesoActual As Decimal = 0D
    Dim balanzaIsActive As Boolean = True

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
            balanzaIsActive = False
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
                        Me.txtPeso.Text = Double.Parse(CInt(text) / Config.scDivisor)
                    End If
                    'Me.txtpesoreal.Text = Double.Parse(text.Substring(9, 7))
                End If
                SP1.DiscardInBuffer()
            End If

        Catch ex As Exception
            balanzaIsActive = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim myElemento As New ElementoCatalogItem
            Dim result As Boolean = False
            Dim req As New ElementoRequest
            Dim res As New ElementoResponse
            Dim WsClnt As New ReportServiceSoapClient

            myElemento.Id = txtElemento.Text
            'txtPeso.Text = "80"
            If Decimal.Parse(txtPeso.Text) = 0D Then
                MessageBox.Show("Ingrese el Peso del Elemento.", "Peso Elemento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            myElemento.pesoActual = Decimal.Parse(txtPeso.Text)
            'myElemento.pesoActual = 108
            myElemento.fechaUltimaAct = Date.Now
            General.SetBARequest(req)
            req.myElementoItem = myElemento
            res = WsClnt.SavePesoActualElemento(req)
            If Not res.ActionResult Then
                Throw New Exception(res.ErrorMessage)
            Else
                Try
                    Dim resul As Boolean
                    Dim elementoHistorico As New ElementoHistoricoItem
                    elementoHistorico.Id = Guid.NewGuid
                    elementoHistorico.idElemento = myElemento.Id
                    elementoHistorico.pesoElemento = myElemento.pesoActual
                    elementoHistorico.estadoElemento = "P"
                    elementoHistorico.tipoRegistro = "ACT"
                    elementoHistorico.fecha = DateTime.Now
                    elementoHistorico.usuario = MyCurrentUser.userName
                    elementoHistorico.idProceso = Guid.Empty
                    elementoHistorico.idVuelo = Guid.Empty
                    resul = CommonData.SaveElementoHistorico(elementoHistorico)
                Catch ex As Exception
                    ErrorManager.SetLogEvent(ex)
                End Try
                isSave = True
                tempPesoActual = myElemento.pesoActual
                MessageBox.Show("Peso Registrado.", "Peso Elemento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SP1.Close()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPesoElemento_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Configurar_Balanza()
            txtElemento.Text = myElemento.Id
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        SP1.Close()
        Me.Close()
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress
        If InStr(1, "0123456789,. " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

End Class