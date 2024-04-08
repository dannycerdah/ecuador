Public Class Principal
    Private DtCuartos As New DataTable("conftemperatura")
    Private dtconftemperatura As New DataTable("conftemperatura")
    Private ObtenerConf As Integer = 0
    Private WithEvents FinalFrame As ClassTemperatura
    Private ClasTemp As ClassTemperatura
    Private BtnProcesa As Integer = 0
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With DtCuartos.Columns
                .Add("IdCuarto", GetType(Integer))
                .Add("NombreCuarto", GetType(String))
            End With
            DtCuartos.Clear()
            CargarCombo()
            If DtCuartos.Rows.Count > 0 Then
                cmbCuarto.DataSource = DtCuartos
                cmbCuarto.DisplayMember = "NombreCuarto"
                cmbCuarto.ValueMember = "NombreCuarto"
            End If
            With dtconftemperatura.Columns
                .Add("idConfig", GetType(Integer))
                .Add("Puerto", GetType(String))
                .Add("NombreCuartoFrio", GetType(String))
                .Add("Estado", GetType(String))
            End With
            CargarConfig()
            ListarPuertoCom()
            Control.CheckForIllegalCrossThreadCalls = False
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message.ToString)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub CargarCombo()
        Dim row As DataRow
        Try
            DtCuartos.Clear()
            row = DtCuartos.NewRow
            row.Item("IdCuarto") = 0
            row.Item("NombreCuarto") = "Seleccione un Registro"
            DtCuartos.Rows.Add(row)
            For Each r As DataRow In CommonDataTempera.ObtenerCuartosFrios.Rows
                row = DtCuartos.NewRow
                row.Item("IdCuarto") = r.Item("IdCuarto")
                row.Item("NombreCuarto") = r.Item("NombreCuarto")
                DtCuartos.Rows.Add(row)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message.ToString)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub CargarConfig()
        Try
            dtconftemperatura = CommonDataTempera.ObtenerConfTemp
            If dtconftemperatura.Rows.Count > 0 Then
                dgvConfgTemp.DataSource = dtconftemperatura
                dgvConfgTemp.Refresh()
                ObtenerConf = 1
                SetDataGrid()
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message.ToString)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub ListarPuertoCom()
        Try
            For Each sp As String In My.Computer.Ports.SerialPortNames
                cmbPruetoCom.Items.Add(sp)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message.ToString)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub btnMantenimiento_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click
        Try
            Using frmMantTemp As New MantCuartoFrios
                frmMantTemp.ShowDialog()
                CargarCombo()
            End Using
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message.ToString)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        Try
            If dgvConfgTemp.Rows.Count > 0 Then
                For Each r As DataGridViewRow In dgvConfgTemp.Rows
                    If r.Cells("Puerto").Value = cmbPruetoCom.SelectedItem And r.Cells("NombreCuartoFrio").Value = cmbCuarto.SelectedValue Then
                        addRow = False
                        Exit For
                    End If
                Next
            End If
            If addRow = True Then
                row = dtconftemperatura.NewRow
                row.Item("idConfig") = 0
                row.Item("Puerto") = cmbPruetoCom.SelectedItem
                row.Item("NombreCuartoFrio") = cmbCuarto.SelectedValue
                row.Item("Estado") = "A"
                dtconftemperatura.Rows.Add(row)
                If ObtenerConf = 0 Then
                    dgvConfgTemp.DataSource = dtconftemperatura
                End If
                resultIngr = CommonDataTempera.RegConfTemp(cmbPruetoCom.SelectedItem, "A", cmbCuarto.SelectedValue)
                If resultIngr Then
                    TimerMenssage.Enabled = True
                    TimerMenssage.Interval = 5000
                    MessageBox.Show("Registro Ingresado Correctamente")
                    SetDataGrid()
                Else
                    TimerMenssage.Enabled = True
                    TimerMenssage.Interval = 5000
                    MessageBox.Show("Error al registrar la Conf.")
                End If
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub SetDataGrid()
        dgvConfgTemp.Columns("idConfig").Visible = False
    End Sub
    Private Sub dgvConfgTemp_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvConfgTemp.UserDeletingRow
        Dim resp As Boolean
        Try
            For Each r As DataGridViewRow In dgvConfgTemp.SelectedRows
                resp = CommonDataTempera.RegConfTemp(r.Cells("Puerto").Value, "E", r.Cells("NombreCuartoFrio").Value)
                If Not resp Then
                    MessageBox.Show("error el intentar grebar los registros")
                End If
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            For Each r As DataGridViewRow In dgvConfgTemp.Rows
                ClasTemp = New ClassTemperatura(r.Cells("Puerto").Value, r.Cells("NombreCuartoFrio").Value)
                AddHandler ClasTemp.CambioTemp, AddressOf RegCambioTemp
                AddHandler ClasTemp.CambioTempHist, AddressOf RegCambioTempHist
                AddHandler ClasTemp.PresentarDatosPantalla, AddressOf DatosPantalla
                BtnProcesa = 1
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex.Message)
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & ex.Message & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
        End Try
    End Sub
    Private Sub RegCambioTemp(PuertoCom As String, CuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double) Handles FinalFrame.CambioTemp
        Dim result As Boolean
        result = CommonDataTempera.RegTemperatura(PuertoCom, CuartoFrio, Humedad, Centigrado, fahrenheit)
        If result <> True Then
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & "Error al Registrar la Temp" & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
            'MessageBox.Show("Error al Registrar la Temp")
        End If
    End Sub
    Private Sub RegCambioTempHist(PuertoCom As String, CuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double) Handles FinalFrame.CambioTempHist
        Dim result As Boolean
        result = CommonDataTempera.RegTemperaturaHist(PuertoCom, CuartoFrio, Humedad, Centigrado, fahrenheit)
        If result <> True Then
            TimerMenssage.Enabled = True
            TimerMenssage.Interval = 5000
            txtError.Text = Now.ToString("HH:mm:ss") & ControlChars.CrLf & "Error al Registrar la Temp Hist" & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
            'MessageBox.Show("Error al Registrar la Temp Hist")
        End If
    End Sub
    Private Sub DatosPantalla(Datos As String, DatosError As String) Handles FinalFrame.PresentarDatosPantalla
        Dim strResponsesToShow As String
        Dim srtError As String
        If Datos <> String.Empty Then
            strResponsesToShow = Now.ToString("HH:mm:ss") & ControlChars.CrLf & Datos & ControlChars.CrLf & txtResponse.Text.PadRight(2000).Substring(0, 1999)
            txtResponse.Text = strResponsesToShow
        End If
        If DatosError <> String.Empty Then
            srtError = Now.ToString("HH:mm:ss") & ControlChars.CrLf & DatosError & ControlChars.CrLf & txtError.Text.PadRight(2000).Substring(0, 1999)
            txtError.Text = srtError
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If BtnProcesa > 0 Then
            If dgvConfgTemp.Rows.Count > 0 Then
                For Each r As DataGridViewRow In dgvConfgTemp.Rows
                    If ClasTemp.EndHilo = False Then
                        ClasTemp.EndEjecHilo()
                    End If
                Next
            End If
            Application.ExitThread()
        End If
    End Sub
    Private Sub TimerMenssage_Tick(sender As Object, e As EventArgs) Handles TimerMenssage.Tick
        TimerMenssage.Enabled = False
        SendKeys.Send("{ENTER}")
    End Sub
End Class
