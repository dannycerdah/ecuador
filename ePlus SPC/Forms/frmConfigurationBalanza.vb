
Public Class frmConfigurationBalanza

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If chkUseBalanza.Checked Then
                Dim checked As Integer
                If CheckKg.Checked Then
                    checked = 1
                Else
                    checked = 0
                End If
                If checked = 1 Then
                    If UltraTextCaracterBuscar.Value = String.Empty Or UltraTextLongiSubCadena.Value = String.Empty Then
                        MessageBox.Show("Configuraciones Guardadas", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Config.SetScaleSettings(txtScalePort.Text, txtScaleBaudRate.Text, _
                                                                   txtScaleStopBits.Text, txtScaleParity.Text, _
                                                                   txtScaleDataBits.Text, txtCharIni.Text, txtCharEnd.Text, txtDivisor.Text, checked, UltraTextCaracterBuscar.Value, UltraTextLongiSubCadena.Value)
                        MessageBox.Show("Configuraciones Guardadas", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        CheckKg.Checked = False
                        Me.Close()
                    End If
                Else
                    Config.SetScaleSettings(txtScalePort.Text, txtScaleBaudRate.Text, _
                                           txtScaleStopBits.Text, txtScaleParity.Text, _
                                           txtScaleDataBits.Text, txtCharIni.Text, txtCharEnd.Text, txtDivisor.Text, checked, UltraTextCaracterBuscar.Value, UltraTextLongiSubCadena.Value)
                    MessageBox.Show("Configuraciones Guardadas", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
                'Config.SetScaleSettings(txtScalePort.Text, txtScaleBaudRate.Text, _
                '                            txtScaleStopBits.Text, txtScaleParity.Text, _
                '                            txtScaleDataBits.Text, txtCharIni.Text, txtCharEnd.Text, txtDivisor.Text, checked, UltraTextCaracterBuscar.Value, UltraTextLongiSubCadena.Value)
            End If
            'MessageBox.Show("Configuraciones Guardadas", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkUseBalanza_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseBalanza.CheckedChanged
        txtScaleBaudRate.Enabled = chkUseBalanza.Checked
        txtScaleDataBits.Enabled = chkUseBalanza.Checked
        txtScaleParity.Enabled = chkUseBalanza.Checked
        txtScalePort.Enabled = chkUseBalanza.Checked
        txtScaleStopBits.Enabled = chkUseBalanza.Checked
        txtCharIni.Enabled = chkUseBalanza.Checked
        txtCharEnd.Enabled = chkUseBalanza.Checked
        txtDivisor.Enabled = chkUseBalanza.Checked
    End Sub

    Private Sub frmConfiguracionBalanza_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtScalePort.Text = Config.scPort
        txtScaleBaudRate.Text = Config.scBaudRate
        txtScaleDataBits.Text = Config.scDataBits
        txtScaleParity.Text = Config.scParity
        txtScaleStopBits.Text = Config.scStopBits
        txtCharIni.Text = Config.scStringBeginChar
        txtCharEnd.Text = Config.scStringEndChar
        txtDivisor.Text = Config.scDivisor
        CheckKg.Checked = Config.SbuscarKg
        If CheckKg.Checked Then
            UltraLabelCaracter.Visible = True
            UltraLabelLongitud.Visible = True
            UltraTextCaracterBuscar.Visible = True
            UltraTextLongiSubCadena.Visible = True
            Me.Size = New Size(517, 214)
            UltraTextCaracterBuscar.Value = Config.SCaracterBuscar
            UltraTextLongiSubCadena.Value = Config.SNumCadena
        Else
            UltraLabelCaracter.Visible = False
            UltraLabelLongitud.Visible = False
            UltraTextCaracterBuscar.Visible = False
            UltraTextLongiSubCadena.Visible = False
            Me.Size = New Size(363, 214)
        End If
        If Not txtScalePort.Text.Equals(String.Empty) Then chkUseBalanza.Checked = True
    End Sub

    Private Sub CheckKg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckKg.CheckedChanged
        If CheckKg.Checked Then
            Me.Size = New Size(517, 214)
            UltraLabelCaracter.Visible = True
            UltraLabelLongitud.Visible = True
            UltraTextCaracterBuscar.Visible = True
            UltraTextLongiSubCadena.Visible = True
        Else
            Me.Size = New Size(363, 214)
            UltraLabelCaracter.Visible = False
            UltraLabelLongitud.Visible = False
            UltraTextCaracterBuscar.Visible = False
            UltraTextLongiSubCadena.Visible = False
        End If
    End Sub

    Private Sub UltraTextLongiSubCadena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UltraTextLongiSubCadena.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class