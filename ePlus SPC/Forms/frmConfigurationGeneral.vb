Imports SPC.Server.ReportService
Public Class frmConfigurationGeneral
    Public Property myConf As New ConfigurationItem
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim userE As String = txtUsuario.Text
        Dim passE As String = txtClave.Text
        Dim keyE As String = Ecuapass.randomKey() 'Llave de encriptación
        Dim passCE As String = txtConfirmar.Text
        If userE = String.Empty Or passE = String.Empty Or passCE = String.Empty Then
            MessageBox.Show("Todos los campos son necesarios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not passE = passCE Then
            MessageBox.Show("Contraseñas no son iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            'passCE = Ecuapass.AES_Encrypt(passCE, keyE) 'Encriptar clave
            SaveEcuapass(userE, passCE, keyE)
        End If
    End Sub
    Sub SaveEcuapass(ByVal userE As String, ByVal passCe As String, ByVal keyE As String)
        Dim req As New UserRequest
        Dim res As New UserResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                myConf.userEcuapass = userE
                myConf.passwordEcuapass = passCe
                myConf.keyEcuapass = keyE
                req.myConfiguraciones = myConf
                res = wsClnt.SaveConfigEcuapass(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmConfigurationGeneral_Load(sender As Object, e As EventArgs) Handles Me.Load
        myConf = CommonData.GetConfiguraciones() 'Base de datos (Configuraciones)
        dtpHorario.Text = myConf.tiempoMarcaciones
        dtpHBriefing.Text = myConf.margenBriefing
        txtUsuario.Focus()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        '  Dim passDB As String = Ecuapass.AES_Decrypt(myConf.passwordEcuapass, myConf.keyEcuapass)
        ' Dim message = "Usuario: " & myConf.userEcuapass & " y Contraseña: " & passDB & " activas en el sistema"
        Dim message = "Usuario: " & myConf.userEcuapass & " y Contraseña: " & myConf.passwordEcuapass & " activas en el sistema"
        MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnGuardarTiempo_Click(sender As Object, e As EventArgs) Handles btnGuardarTiempo.Click
        If dtpHorario.Value.TimeOfDay.ToString = "00:00:00" Then
            MessageBox.Show("Tiempo inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim req As New UserRequest
            Dim res As New UserResponse
            Dim wsClnt As New ReportServiceSoapClient
            Try
                General.SetBARequest(req)
                myConf.tiempoMarcaciones = dtpHorario.Value.TimeOfDay.ToString
                myConf.margenBriefing = dtpHBriefing.Value.TimeOfDay.ToString
                req.myConfiguraciones = myConf
                res = wsClnt.SaveConfigurations(req)
                If res.ActionResult Then
                    MessageBox.Show("Configuraciones guardadas correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Catch ex As Exception
                MessageBox.Show(res.ErrorMessage)
                ErrorManager.SetLogEvent(ex)
            End Try
            Me.Close()
        End If
    End Sub
End Class