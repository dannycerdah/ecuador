Imports MessageSender.MessagesManager
Imports MessageSender.ErrorManager
Imports MySql.Data.MySqlClient
Imports eSPC.Server.ReportService
Imports eSPC
Imports ControlTempGAEnsamblado
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.IO

'Imports Microsoft.Office.Interop

Public Class frmPrincipal
    Dim dtNuevosDae As DataTable
    Dim dtDocSenae As DataTable
    Dim dtGuiaDaesRem As DataTable
    Private dtJobs As New DataTable
    Dim TiempoSleep As Integer = 600000

    Public Shared Sub SendNotificationMessage(ByVal msj As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            With sender
                .Port = 587
                .Host = "192.168.10.181"
                .Credentials = New System.Net.NetworkCredential("reportes", "Pa$$w0rd19")
                .EnableSsl = False
            End With
            Using msg As New Net.Mail.MailMessage("supervisores@generalecu.com", "SystemAlerts@eplus.com.ec", "Error de sistema " & My.Application.Info.Description, msj)
                sender.Send(msg)
            End Using
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetLogEvent(ex)
        End Try
    End Sub
    Public Shared Sub SendCorreo(ByVal msj As String, destinatarios As String, descripcionPermiso As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = 587
                    .Host = "192.168.10.181"
                    .Credentials = New System.Net.NetworkCredential("reportes", "Pa$$w0rd19")
                    .EnableSsl = False
                End With
                Using msg As New Net.Mail.MailMessage("reportes@generalairsa.com", destinatarios, descripcionPermiso, msj)
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetLogEvent(ex)
        End Try
    End Sub
    Private Sub consultaDae()
        While True
            Try
                Dim dtNew As DataTable = SearchDAE(Date.Today, Date.Now.AddDays(1))
                Dim i As Integer = 0
                For Each r In dtNew.Rows
                    i += 1
                    SaveNewDae(r)
                    WriteDaeInViewer(r, "DAE")
                    lblDaeProcessing.Text = "Procesando " & i.ToString & " de " & dtNew.Rows.Count & " " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                Next
                lblLastExecution.Text = "Ultima Ejecucion: " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
            Catch ex As Exception
                SetLogEvent(ex)
            End Try
            System.Threading.Thread.Sleep(nudTimerDAE.Value * 1000)
        End While
    End Sub
    Private Sub consultaDas()
        While True
            Try
                Dim dtNew2 As DataTable = SearchDAS(Date.Today, Date.Now.AddDays(1))
                Dim i As Integer = 0
                For Each r In dtNew2.Rows
                    i += 1
                    SaveNewDae(r)
                    WriteDaeInViewer(r, "DAS")
                    lblDaeProcessing.Text = "Procesando " & i.ToString & " de " & dtNew2.Rows.Count & " " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                Next
                lblLastExecution.Text = "Ultima Ejecucion: " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
            Catch ex As Exception
                SetLogEvent(ex)
            End Try
            System.Threading.Thread.Sleep(nudTimerDAE.Value * 1000)
        End While
    End Sub
    Private Sub consultaDae(ByVal numeroDae As String)
        Try
            Dim dtNew As DataTable = SearchDAE(numeroDae)
            For Each r In dtNew.Rows
                SaveNewDae(r)
                WriteDaeInViewer(r, "DOC")
            Next
        Catch ex As Exception
            SetLogEvent(ex)
        End Try
    End Sub
    Private Sub consultaDas(ByVal numeroDae As String)
        Try
            Dim dtNew2 As DataTable = SearchDAS(numeroDae)
            For Each r In dtNew2.Rows
                SaveNewDae(r)
                WriteDaeInViewer(r, "DOC")
            Next
        Catch ex As Exception
            SetLogEvent(ex)
        End Try
    End Sub
    Private Sub WriteDaeInViewer(myRow As DataRow, ByVal Caller As String)
        If My.Settings.WriteDaeViewer Then
            Dim strData As String = String.Empty
            strData += Caller & "> " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "       " '& ControlChars.CrLf
            strData += myRow.Item("DeclarationNumber").ToString.PadRight(23) '& ControlChars.CrLf
            strData += myRow.Item("examinationChannelName").ToString.PadRight(35) '& ControlChars.CrLf
            strData += myRow.Item("ExporterName").ToString.PadRight(72).Substring(0, 70) & "    " '& ControlChars.CrLf
            strData += myRow.Item("EffectiveEndDate") & ControlChars.CrLf
            'strData += ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf
            txtContentVwr.Text = strData & txtContentVwr.Text
        End If
    End Sub
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
        LoadParameters()
        'bgwDae.RunWorkerAsync()
        'bgwDas.RunWorkerAsync()
        bgwDoc.RunWorkerAsync()
        bgwRem.RunWorkerAsync()
        With dtJobs.Columns
            .Add("IdJobs", GetType(Integer))
            .Add("NombreJobs", GetType(String))
            .Add("TipoEjecucion", GetType(String))
            .Add("ValorEjecucion", GetType(Integer))
            .Add("FechaEjecucion", GetType(Date))
            .Add("FechaEjecucionAnt", GetType(Date))
        End With
        DgvJobs.DataSource = dtJobs
        bgwCargaJobs.RunWorkerAsync()
        CargarDatosJobs()
    End Sub
    Private Sub LoadParameters()
        chkLogDAE.Checked = My.Settings.KeepDaeLog
        chkDAEViewer.Checked = My.Settings.WriteDaeViewer
        nudTimerDAE.Value = My.Settings.DaeTimer
        chkDocLog.Checked = My.Settings.KeepDocLog
        chkDocViewer.Checked = My.Settings.WriteDocViewer
        nudTimerDoc.Value = My.Settings.DocTimer
    End Sub
    Private Shared Sub SaveNewDae(r As DataRow)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Try
            Dim newDae As Object
            newDae = New Object() {r.Item("DeclarationNumber"), r.Item("ExporterDocumentID"), r.Item("ExporterName"),
                                   r.Item("DeclarationOffice"), r.Item("Declaration_Id"), r.Item("examinationChannelName"),
                                   Date.Today, Date.Parse(r.Item("EffectiveEndDate")), r.Item("Response_Id"), "", "A",
                                   r.Item("RemNumber"), r.Item("RemRucAgency"), If(IsDBNull(r.Item("RemEndVigency")), Nothing, DateTime.Parse(r.Item("RemEndVigency")))}
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("Id", newDae(0))
                .CommandText = "CheckExistsValidezDae"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            If Not CBool(cmd.ExecuteScalar) Then
                With cmd2
                    .Parameters.AddWithValue("numeroDae", newDae(0))
                    .Parameters.AddWithValue("exporterDocumentId", newDae(1))
                    .Parameters.AddWithValue("exporterName", newDae(2))
                    .Parameters.AddWithValue("declarationOffice", newDae(3))
                    .Parameters.AddWithValue("declarationId", newDae(4))
                    .Parameters.AddWithValue("examinerName", newDae(5))
                    .Parameters.AddWithValue("fechaIni", newDae(6))
                    .Parameters.AddWithValue("fechaFin", newDae(7))
                    .Parameters.AddWithValue("responseId", newDae(8))
                    .Parameters.AddWithValue("idProducto", newDae(9))
                    .Parameters.AddWithValue("estado", newDae(10))
                    .Parameters.AddWithValue("NumRem", newDae(11))
                    .Parameters.AddWithValue("RucAgenciaRem", newDae(12))
                    .Parameters.AddWithValue("fechaVigenciaRem", newDae(13))
                    .CommandText = "agregarValidezDae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd2.Connection.Close()
                cmd.Connection.Close()
            Else
                With cmd2
                    .Parameters.AddWithValue("numeroDae", newDae(0))
                    .Parameters.AddWithValue("exporterDocumentId", newDae(1))
                    .Parameters.AddWithValue("exporterName", newDae(2))
                    .Parameters.AddWithValue("declarationOffice", newDae(3))
                    .Parameters.AddWithValue("declarationId", newDae(4))
                    .Parameters.AddWithValue("examinerName", newDae(5))
                    .Parameters.AddWithValue("fechaIni", newDae(6))
                    .Parameters.AddWithValue("fechaFin", newDae(7))
                    .Parameters.AddWithValue("responseId", newDae(8))
                    .Parameters.AddWithValue("idProducto", newDae(9))
                    .Parameters.AddWithValue("estado", newDae(10))
                    .Parameters.AddWithValue("NumRem", newDae(11))
                    .Parameters.AddWithValue("RucAgenciaRem", newDae(12))
                    .Parameters.AddWithValue("fechaVigenciaRem", newDae(13))
                    .CommandText = "modificarValidezDae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub
    Private Sub obtenerDocSeane()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            dtDocSenae = New DataTable("dtDocSenae")
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("fecha", Date.Today.AddDays(-1))
                .CommandText = "obtenerDocSenaePorFecha"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            dtDocSenae.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub
    Private Sub QueryStatus()
        While True
            Try
                obtenerDocSeane()
                If Not IsNothing(dtDocSenae) Then
                    Dim i As Integer = 0
                    For Each r As DataRow In dtDocSenae.Rows
                        i += 1
                        QueryStatus(r.Item("docId"), r.Item("fecha"), r.Item("idRegistro"), r.Item("numeroDae").ToString)
                        lblDocProcessing.Text = "Procesando " & i.ToString & " de " & dtDocSenae.Rows.Count & " " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                    Next
                End If
                lblLastExcutionDoc.Text = "Ultima Ejecucion: " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
                SetLogEvent(ex)
            End Try
            System.Threading.Thread.Sleep(nudTimerDoc.Value * 1000)
        End While
    End Sub
    Private Sub QueryStatus(ByVal Id As String, ByVal fecha As Date, ByVal idRegistro As Guid, ByVal numeroDae As String)
        Dim resultStatus As String = String.Empty
        resultStatus = QueryDocStatus(Id, fecha) 'Webservice Ecuapass con niveles de seguridad - MARZ 
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If My.Settings.WriteDocViewer Then
                Dim strData As String = String.Empty
                strData += "IIE> " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "       " '& ControlChars.CrLf
                strData += Id.PadRight(25) & resultStatus.PadRight(60).Substring(0, 25) & "      "
                strData += "REG: " & idRegistro.ToString.PadRight(40) '& ControlChars.CrLf
                strData += "DAE: " & numeroDae.PadRight(20) & ControlChars.CrLf
                txtContentVwr.Text = strData & txtContentVwr.Text
            End If
            If resultStatus = "SIN ERRORES" Or resultStatus = String.Empty Or resultStatus = "SIN RESPUESTA" Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", idRegistro)
                    .Parameters.AddWithValue("estado", resultStatus)
                    .Parameters.AddWithValue("estadoDoc", "A")
                    .CommandText = "modificarEstadoDocSenae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            Else
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", idRegistro)
                    .Parameters.AddWithValue("estado", resultStatus)
                    .Parameters.AddWithValue("estadoDoc", "C")
                    .CommandText = "modificarEstadoDocSenae"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd.Connection.Close()
            End If
            If resultStatus <> "SIN RESPUESTA" And resultStatus <> String.Empty Then
                If numeroDae <> String.Empty Then
                    If Not DaeTieneEstado(numeroDae) Then
                        consultaDae(numeroDae)
                        consultaDas(numeroDae)
                    End If
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub

    Private Function DaeTieneEstado(NumeroDae) As Boolean
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim result As Boolean = False
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("numeroDae", NumeroDae)
                .CommandText = "obtenerValidezDaePorDae"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader()
            drReader.Read()
            If drReader.GetValue(drReader.GetOrdinal("examinerName")) <> String.Empty Then result = True
        Catch ex As Exception
            SetLogEvent(ex)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar Reader
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
                drReader = Nothing
            End If
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar Reader
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
                drReader = Nothing
            End If
        End Try
        Return result
    End Function
    Private Sub RestartDAE_Click(sender As Object, e As EventArgs) Handles StopDAE.Click
        bgwDae.CancelAsync()
        bgwRem.CancelAsync()
    End Sub
    Private Sub chkLogDAE_CheckedChanged(sender As Object, e As EventArgs) Handles chkLogDAE.CheckedChanged
        My.Settings.KeepDaeLog = chkLogDAE.Checked
        My.Settings.Save()
    End Sub
    Private Sub nudTimerDAE_ValueChanged(sender As Object, e As EventArgs) Handles nudTimerDAE.ValueChanged
        My.Settings.DaeTimer = nudTimerDAE.Value
        My.Settings.Save()
    End Sub
    Private Sub chkViewer_CheckedChanged(sender As Object, e As EventArgs) Handles chkDAEViewer.CheckedChanged
        My.Settings.WriteDaeViewer = chkDAEViewer.Checked
        My.Settings.Save()
    End Sub
    Private Sub bgwDae_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDae.DoWork
        consultaDae()
    End Sub
    Private Sub bgwDoc_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDoc.DoWork
        QueryStatus()
    End Sub
    Private Sub btnStopDOC_Click(sender As Object, e As EventArgs) Handles btnStopDOC.Click
        bgwDoc.CancelAsync()
    End Sub
    Private Sub btnStartDAE_Click(sender As Object, e As EventArgs) Handles btnStartDAE.Click
        bgwDae.RunWorkerAsync()
        bgwDas.RunWorkerAsync()
        bgwRem.RunWorkerAsync()
    End Sub
    Private Sub btnStartDoc_Click(sender As Object, e As EventArgs) Handles btnStartDoc.Click
        bgwDoc.RunWorkerAsync()
    End Sub
    Private Sub nudTimerDoc_ValueChanged(sender As Object, e As EventArgs) Handles nudTimerDoc.ValueChanged
        My.Settings.DocTimer = nudTimerDoc.Value
        My.Settings.Save()
    End Sub
    Private Sub chkDocViewer_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocViewer.CheckedChanged
        My.Settings.WriteDocViewer = chkDocViewer.Checked
        My.Settings.Save()
    End Sub
    Private Sub chkDocLog_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocLog.CheckedChanged
        My.Settings.KeepDocLog = chkDocLog.Checked
        My.Settings.Save()
    End Sub
    Private Sub bgwDas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwDas.DoWork
        consultaDas()
    End Sub

    Private Sub btnStopREM_Click(sender As Object, e As EventArgs) Handles btnStopREM.Click
        bgwRem.CancelAsync()
    End Sub
    Private Sub btnStartREM_Click(sender As Object, e As EventArgs) Handles btnStartREM.Click
        bgwRem.RunWorkerAsync()
    End Sub
    Private Sub consultaGuiasDaesRem(Tipo As Integer)
        Try
            Dim GuiaDaeRem As New GuiasDaesRem
            Dim i As Integer = 0
            Dim Tabla As New DataTable("obtenerGuiasDaesRem")
            Tabla = obtenerGuiasDaesRem(Tipo)
            Dim TotalReg As Integer = Tabla.Rows.Count
            ' For Each r In obtenerGuiasDaesRem(Tipo).Rows
            For Each r In Tabla.Rows
                i += 1
                Dim dtNew As DataTable = SearchDAE(r.item("dae"))
                For Each r2 In dtNew.Rows
                    Dim newRwm As String
                    If Tipo = 0 Then
                        If r.item("envioSenae") = 0 Then
                            If Not IsDBNull(r2.item("RemNumber")) Then
                                If r.item("NumRem") <> r2.item("RemNumber") Then
                                    GuiaDaeRem.NewfechavigenciaRem = DateTime.Parse(r2.Item("RemEndVigency"))
                                End If
                                newRwm = r2.item("RemNumber")
                            Else
                                GuiaDaeRem.NewfechavigenciaRem = Nothing
                                newRwm = Nothing
                            End If
                        End If
                    End If
                    GuiaDaeRem.dae = r.item("dae")
                    GuiaDaeRem.idGuia = r.item("idGuia")
                    GuiaDaeRem.RemAnterio = IIf(IsDBNull(r.item("NumRem")), "", r.item("NumRem"))
                    GuiaDaeRem.NewRem = newRwm
                    GuiaDaeRem.EstadoAntAforo = r.item("estado")
                    GuiaDaeRem.EstadoAforo = r2.Item("ExaminerName")
                    GuiaDaeRem.EnvioSenae = r.item("envioSenae")
                    GuiaDaeRem.fechavigenciaRem = r.item("fechavigenciaRem")
                    GuiaDaeRem.SalidaAnt = r.item("Salida")
                    GuiaDaeRem.CanalAforoAnt = r.item("CanalAforo")
                    GuiaDaeRem.Salida = r2.item("StatusName")
                    GuiaDaeRem.CanalAforo = r2.item("ExaminationChannelName")
                    SaveNewModifiGuiaDaesRem(GuiaDaeRem, Tipo)
                    lblREMProcessing.Text = "Procesando " & i.ToString & " de " & TotalReg & " " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
                    Task.Run(Async Function()
                                 Await EnviarReporteCheckUserManager(GuiaDaeRem, Tipo)
                             End Function)
                Next
            Next
            lblLastExcutionRem.Text = "Ultima Ejecucion: " & Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
        End Try
    End Sub
    Private Function obtenerGuiasDaesRem(Tipo As Integer) As DataTable
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            dtGuiaDaesRem = New DataTable("dtGuiaDaesRem")
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .CommandText = "SP_ObtenerGuiasDaesRem"
                .Parameters.AddWithValue("TipoConsult", Tipo)
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            dtGuiaDaesRem.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtGuiaDaesRem
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Function
    Private Shared Sub SaveNewModifiGuiaDae(datos As GuiasDaesRem)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim newDae As Object
        Dim ConexionCmd As Boolean = False
        Dim NewRem As String
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            If (datos.RemAnterio <> datos.NewRem And datos.EnvioSenae = 0) Or (datos.EstadoAntAforo <> datos.EstadoAforo And datos.EnvioSenae = 1) Then
                If Not IsNothing(datos.NewRem) Then
                    NewRem = datos.NewRem
                Else
                    NewRem = datos.RemAnterio
                End If
                With cmd
                    .Parameters.AddWithValue("idGuia", datos.idGuia)
                    .Parameters.AddWithValue("dae", datos.dae)
                    ' .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, If(IsNothing(datos.NewRem), "000000000000000000", datos.NewRem)))
                    .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, NewRem))
                    .Parameters.AddWithValue("fechavigenciaRem", If(datos.EnvioSenae = 1, datos.fechavigenciaRem, datos.NewfechavigenciaRem))
                    .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                    .CommandText = "Sp_ModificaDetalleGuiaDaes"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                ConexionCmd = True

            End If
            If datos.EnvioSenae = 0 And datos.RemAnterio <> datos.NewRem Then
                With cmd2
                    .Parameters.AddWithValue("dae", datos.dae)
                    .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, If(IsNothing(datos.NewRem), "000000000000000000", datos.NewRem)))
                    .Parameters.AddWithValue("fechavigenciaRem", If(datos.EnvioSenae = 1, datos.fechavigenciaRem, datos.NewfechavigenciaRem))
                    .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                    .CommandText = "SpAgregaHistoricoDaeRem"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                cmd2.Connection.Close()
                If ConexionCmd Then
                    cmd.Connection.Close()
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub
    Private Shared Sub SaveNewModifiGuiaDaesRem(datos As GuiasDaesRem, tipo As Integer)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim newDae As Object
        Dim ConexionCmd As Boolean = False
        Dim NewRem As String
        Dim Actualiza As Boolean = False
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            If tipo = 0 Then
                If (datos.RemAnterio <> datos.NewRem And datos.EnvioSenae = 0) Or (datos.EstadoAntAforo <> datos.EstadoAforo And datos.EnvioSenae = 1) Then
                    If Not IsNothing(datos.NewRem) Then
                        NewRem = datos.NewRem
                    Else
                        NewRem = datos.RemAnterio
                    End If
                    With cmd
                        .Parameters.AddWithValue("idGuia", datos.idGuia)
                        .Parameters.AddWithValue("dae", datos.dae)
                        .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, NewRem))
                        .Parameters.AddWithValue("fechavigenciaRem", If(datos.EnvioSenae = 1, datos.fechavigenciaRem, datos.NewfechavigenciaRem))
                        .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                        .Parameters.AddWithValue("Salida", datos.Salida)
                        .Parameters.AddWithValue("CanalAforo", datos.CanalAforo)
                        .Parameters.AddWithValue("tipo", tipo)
                        .CommandText = "Sp_ModificaDetalleGuiaDaes"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                    ConexionCmd = True

                End If
                If datos.EnvioSenae = 0 And datos.RemAnterio <> datos.NewRem Then
                    With cmd2
                        .Parameters.AddWithValue("dae", datos.dae)
                        .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, If(IsNothing(datos.NewRem), "000000000000000000", datos.NewRem)))
                        .Parameters.AddWithValue("fechavigenciaRem", If(datos.EnvioSenae = 1, datos.fechavigenciaRem, datos.NewfechavigenciaRem))
                        .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                        .CommandText = "SpAgregaHistoricoDaeRem"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    If ConexionCmd Then
                        cmd.Connection.Close()
                    End If
                End If
            Else
                If Not IsNothing(datos.NewRem) Then
                    NewRem = datos.NewRem
                Else
                    NewRem = datos.RemAnterio
                End If
                If datos.RemAnterio <> datos.NewRem Or datos.Salida <> datos.SalidaAnt Or datos.CanalAforo <> datos.CanalAforoAnt Or datos.EstadoAforo <> datos.EstadoAntAforo Then
                    With cmd
                        .Parameters.AddWithValue("idGuia", datos.idGuia)
                        .Parameters.AddWithValue("dae", datos.dae)
                        .Parameters.AddWithValue("NumRem", IIf(NewRem = String.Empty, datos.RemAnterio, NewRem))
                        .Parameters.AddWithValue("fechavigenciaRem", Date.Now)
                        .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                        .Parameters.AddWithValue("Salida", datos.Salida)
                        .Parameters.AddWithValue("CanalAforo", datos.CanalAforo)
                        .Parameters.AddWithValue("tipo", tipo)
                        .CommandText = "Sp_ModificaDetalleGuiaDaes"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                    ConexionCmd = True
                End If
                If datos.Salida <> datos.SalidaAnt Or datos.CanalAforo <> datos.CanalAforoAnt Or datos.EstadoAforo <> datos.EstadoAntAforo Then
                    With cmd2
                        .Parameters.AddWithValue("dae", datos.dae)
                        .Parameters.AddWithValue("NumRem", If(datos.EnvioSenae = 1, datos.RemAnterio, If(IsNothing(datos.NewRem), "000000000000000000", datos.NewRem)))
                        .Parameters.AddWithValue("fechavigenciaRem", Date.Now)
                        .Parameters.AddWithValue("EstadoAforo", datos.EstadoAforo)
                        .Parameters.AddWithValue("Salida", datos.Salida)
                        .Parameters.AddWithValue("CanalAforo", datos.CanalAforo)
                        .CommandText = "Sp_AgregaHistoricoDaeRem"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                    cmd2.Connection.Close()
                    If ConexionCmd Then
                        cmd.Connection.Close()
                    End If
                End If
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd2.Connection IsNot Nothing Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Sub
    Private Async Function EnviarReporteCheckUserManager(datos As GuiasDaesRem, tipo As Integer) As Task
        Try
            Dim dest As New DataTable("destinatarios")
            Dim contRowDest As Integer = 0
            Dim destinatarios As String = String.Empty
            Dim msj As String = String.Empty
            Dim nombreUsuarioPer As String = String.Empty
            Dim nombreUsuarioReq As String = String.Empty
            dest = GetDestinatariosPorIdReporte(7) 'CommonData.GetDestinatariosPorIdReporte(7)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            If tipo = 0 Then
                If datos.EnvioSenae = 0 Then
                    If datos.NewRem <> String.Empty And datos.NewRem <> datos.RemAnterio Then
                        msj = "Se a realizado un cambio  en el REM de la DAE : " & datos.dae & vbCrLf & vbCrLf &
                              " REM Anterior:  " & datos.RemAnterio & vbCrLf & vbCrLf &
                              " Nuevo REM: " & datos.NewRem & " Fecha Vigencia del Nuevo REM: " & datos.NewfechavigenciaRem & vbCrLf & vbCrLf & vbCrLf &
                              "Notificación automática, por favor no responder este mensaje."
                        SendCorreo(msj, destinatarios, "Cambio de Datos de la DAE") 'General.SendCheckUserManagerReportsMessage(msj, destinatarios, "Cambio de Datos de la DAE")
                    ElseIf datos.NewRem = String.Empty Or IsNothing(datos.NewRem) Then
                        msj = "Se a caducado REM de la DAE : " & datos.dae & vbCrLf &
                             " y no se ha realiado actualizacion del REM por favor cominicarse con la agencia de Carga " & datos.fechavigenciaRem & vbCrLf & vbCrLf & vbCrLf &
                             "Notificación automática, por favor no responder este mensaje."

                    End If
                Else
                    If datos.EstadoAntAforo <> datos.EstadoAforo Then
                        msj = "El estado de Aforo de la DAE : " & datos.dae & vbCrLf & vbCrLf &
                              " a cambiado de :  " & IIf(datos.EstadoAntAforo = String.Empty, "SIN AFORO", datos.EstadoAntAforo) & ", a : " & datos.EstadoAforo & vbCrLf & vbCrLf & vbCrLf &
                              " Salida : " & datos.Salida & vbCrLf & vbCrLf & vbCrLf &
                              " Canal de Aforo : " & datos.CanalAforo & vbCrLf & vbCrLf & vbCrLf &
                              "Notificación automática, por favor no responder este mensaje."
                        SendCorreo(msj, destinatarios, "Cambio de Estado de Aforo DAE") 'General.SendCheckUserManagerReportsMessage(msj, destinatarios, "Cambio de Estado de Aforo DAE")
                    End If
                End If
            Else
                If datos.EstadoAntAforo <> datos.EstadoAforo Or datos.Salida <> datos.SalidaAnt Or datos.CanalAforo <> datos.CanalAforoAnt Then
                    msj = "El estado de Aforo de la DAE : " & datos.dae & vbCrLf & vbCrLf &
                          " a cambiado de :  " & IIf(datos.EstadoAntAforo = String.Empty, "SIN AFORO", datos.EstadoAntAforo) & ", a : " & datos.EstadoAforo & vbCrLf & vbCrLf & vbCrLf &
                          " Salida : " & datos.Salida & vbCrLf & vbCrLf & vbCrLf &
                          " Canal de Aforo : " & datos.CanalAforo & vbCrLf & vbCrLf & vbCrLf &
                          "Notificación automática, por favor no responder este mensaje."
                    SendCorreo(msj, destinatarios, "Cambio de Estado de Aforo DAE") 'General.SendCheckUserManagerReportsMessage(msj, destinatarios, "Cambio de Estado de Aforo DAE")
                End If
            End If
        Catch ex As Exception
            SetLogEvent(ex)
        End Try
    End Function
    Private Sub bgwRem_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwRem.DoWork
        While True
            Try
                consultaGuiasDaesRem(0)
                consultaGuiasDaesRem(1)
                System.Threading.Thread.Sleep(nudTimerRem.Value * 1000)
            Catch ex As Exception

            End Try
        End While
    End Sub
    Shared Function GetDestinatariosPorIdReporte(req As Integer) As DataTable
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim dtDestinatarios = New DataTable("dtDestinatarios")
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("Id", req)
                .CommandText = "obtenerDestinatariosPorIdReporte"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            dtDestinatarios.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtDestinatarios
        Catch ex As Exception
            SetLogEvent(ex)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
    End Function
#Region "Tab2_Notificaciones"
    Private Sub bgwReporteTagsa_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwReporteTagsa.DoWork
        While True
            Try
                Dim resp As Boolean
                If dtJobs.Rows.Count > 0 Then
                    For Each r As DataRow In dtJobs.Rows
                        ReporteTagsa(r.Item("IdJobs"), r.Item("NombreJobs"), r.Item("FechaEjecucion"), r.Item("TipoEjecucion"), r.Item("ValorEjecucion"))
                    Next
                    Dim VerificaJobs As Boolean = False
                    While VerificaJobs = False
                        VerificaJobs = CargarDatosJobs()
                        Threading.Thread.Sleep(5000)
                    End While
                End If
                If bgwReporteTagsa.CancellationPending Then
                    BtnVerificaTagsa.Enabled = True
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Threading.Thread.Sleep(TiempoSleep)
        End While
    End Sub
    Private Function CargarDatosJobs() As Boolean
        Dim resul As Boolean = True
        Try
            Dim row As DataRow
            dtJobs.Clear()
            DgvJobs.Refresh()
            For Each r As DataRow In ObtenerDatosJob().Rows
                row = dtJobs.NewRow
                With row
                    .Item("IdJobs") = r.Item("IdJobs")
                    .Item("NombreJobs") = r.Item("NombreJobs")
                    .Item("TipoEjecucion") = r.Item("TipoEjecucion")
                    .Item("ValorEjecucion") = r.Item("ValorEjecucion")
                    .Item("FechaEjecucion") = r.Item("FechaEjecucion")
                    .Item("FechaEjecucionAnt") = r.Item("FechaEjecucionAnt")
                    dtJobs.Rows.Add(row)
                End With
            Next
            DgvJobs.Refresh()
        Catch ex As Exception
            resul = False
            Dim strData As String
            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
        End Try
        Return resul
    End Function
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        Dim NombreCuartoFrio As String
        Try
            If txtNombreJob.Text <> String.Empty And cmbTipoEjecucion.SelectedText <> "Seleccione Tipo Ejecucion" And NumJob.Value <> 0 Then
                If dtJobs.Rows.Count > 0 Then
                    For Each r As DataRow In dtJobs.Rows
                        If r.Item("NombreJobs") = txtNombreJob.Text Then
                            addRow = False
                            Exit For
                        End If
                    Next
                End If
            End If
            If addRow = True Then
                resultIngr = AgregaEjecucionJobs(txtNombreJob.Text, cmbTipoEjecucion.SelectedItem, NumJob.Value)
                If resultIngr Then
                    MessageBox.Show("Registro Ingresado Correctamente")
                    Dim strData As String
                    strData = Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Registro Ingresado Correctamente" & ControlChars.CrLf
                    txtJobs.Text = strData & txtJobs.Text
                    CargarDatosJobs()
                Else
                    MessageBox.Show("Error al registrar el Jobs")
                    Dim strData As String
                    strData = Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Error al registrar el Jobs" & ControlChars.CrLf
                    txtJobs.Text = strData & txtJobs.Text
                End If
            End If
        Catch ex As Exception
            Dim strData As String
            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
        End Try
    End Sub
    Private Sub DgvJobs_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DgvJobs.UserDeletingRow
        Dim resp As Boolean
        Try
            For Each r As DataGridViewRow In DgvJobs.SelectedRows
                resp = EliminarEjecucionJobs(r.Cells("NombreJobs").Value)
                If Not resp Then
                    MessageBox.Show("error el intentar grebar los registros")
                    Dim strData As String
                    strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " error el intentar grebar los registros" & ControlChars.CrLf
                    txtJobs.Text = strData & txtJobs.Text
                End If
            Next
        Catch ex As Exception
            Dim strData As String
            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ReporteTagsa(idJobs As Integer, NombreJobs As String, fechaEjecucion As Date, tipoEjecucion As String, ValorEjecucion As Integer)
        Dim Dt As New DataTable
        Dim Ejecuta As Integer
        Dim dtTagsa As New DataTable
        Dim rutaejecutable As String = Application.StartupPath
        Dim resul As Boolean
        Dim destinatarios As String = String.Empty
        Dim destinatariosCopia As String
        Dim strData As String
        Dim reporte As String = 0
        Try
            If tipoEjecucion = "D" Then
                Ejecuta = DateDiff(DateInterval.Day, Now().Date, fechaEjecucion)
            ElseIf tipoEjecucion = "M" Then
                Ejecuta = DateDiff(DateInterval.Month, Now().Date, fechaEjecucion)
            ElseIf tipoEjecucion = "H" Then
                Ejecuta = DateDiff(DateInterval.Hour, Now(), fechaEjecucion)
            ElseIf tipoEjecucion = "MI" Then
                Ejecuta = DateDiff(DateInterval.Minute, Now(), fechaEjecucion)
            End If
            If Ejecuta <= 0 Then
                Dim dest As New DataTable("destinatarios")
                dest = GetDestinatariosPorIdReporte(9) 'CommonData.GetDestinatariosPorIdReporte(7)
                Dim contRowDest As Integer = 0
                For Each r As DataRow In dest.Rows
                    If InStr(r.Item("mail"), "@") > 0 Then
                        If contRowDest > 0 Then
                            destinatariosCopia += ", " & r.Item("mail")
                        Else
                            destinatariosCopia = r.Item("mail")
                        End If
                        contRowDest += 1
                    End If
                Next
                Dim Msg As String
                Dim Asunto As String
                If idJobs = 1 Then
                    dtTagsa = ObtProxCaduTagsa()
                    Dim Contactos As String = "<ul><li>"
                    Dim dataViewTagsa As New DataView(dtTagsa)
                    Dim DataAgencias As DataTable
                    DataAgencias = dataViewTagsa.ToTable(True, "descripcionAgencia")
                    ' Creamos todo lo necesario para un excel
                    'Dim appXL As New Excel.Application
                    'Dim wbXl As Excel.Workbook
                    'Dim shXL As New Excel.Worksheet
                    Dim indice As Integer = 2

                    If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
                        FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
                    End If
                    Dim strFileName As String = rutaejecutable & "\ReportesTagsa.csv"
                    If File.Exists(strFileName) Then
                        My.Computer.FileSystem.DeleteFile(strFileName)
                    End If
                    Dim Encabezado As String = String.Empty
                    Dim Detalle As String = String.Empty
                    For Each i As DataRow In DataAgencias.Rows
                        If reporte = 0 Then
                            Encabezado = "Cedula,Nombre,Fecha de Caducacion Tagsa,Agencia,Email Agencia" & vbCrLf
                            IO.File.AppendAllText(strFileName, Encabezado)
                            'appXL = CreateObject("Excel.Application")
                            'appXL.Visible = False 'Para que no se muestre mientras se crea
                            'wbXl = appXL.Workbooks.Add
                            'shXL = wbXl.ActiveSheet
                            'With shXL.Range("A1:E1")
                            '    '.Merge() 'cominar columnas
                            '    .Font.Bold = True
                            '    .Font.Size = 12
                            '    With .Borders
                            '        .LineStyle = Excel.XlLineStyle.xlContinuous
                            '        .Color = System.Drawing.Color.Black
                            '        .Weight = 1
                            '    End With
                            'End With
                            'shXL.Cells(1, 1) = "Cedula"
                            'shXL.Cells(1, 2) = "Nombre"
                            'shXL.Cells(1, 3) = "Fecha de Caducacion Tagsa"
                            'shXL.Cells(1, 4) = "Agencia"
                            'shXL.Cells(1, 5) = "Email Agencia"
                        End If
                        reporte += 1
                        Dim foundRows() As DataRow
                        foundRows = dtTagsa.Select("descripcionAgencia = '" & i.Item("descripcionAgencia") & "'")
                        For Each r As DataRow In foundRows
                            'shXL.Cells(indice, 1) = r.Item(0)
                            'shXL.Cells(indice, 2) = r.Item(1)
                            'shXL.Cells(indice, 3) = r.Item(2)
                            'shXL.Cells(indice, 4) = r.Item(3)
                            'shXL.Cells(indice, 5) = r.Item(4)
                            'indice += 1
                            Detalle = r.Item(0) + "," + r.Item(1) + "," + r.Item(2) + "," + r.Item(3) + "," + r.Item(4) & vbCrLf
                            IO.File.AppendAllText(strFileName, Detalle)
                            Contactos = Contactos & r.Item(0) & " " & r.Item(1) & " (" & r.Item(2) & ")</li><li>"
                            If InStr(r.Item(4), "@") > 0 Then
                                destinatarios = r.Item(4)
                            End If
                        Next
                        If InStr(destinatarios, "@") > 0 Then
                            destinatarios += "," & destinatariosCopia
                            Contactos = Contactos & "</li></ul>"
                            For Each row As DataRow In ObtenerCorreoReporte(idJobs).Rows
                                Msg = row.Item("CuerpoCorreo")
                                Msg = Msg.Replace("(Personal)", Contactos)
                                Msg = Msg.Replace("<li></li>", "")
                                Asunto = row.Item("Asunto")
                            Next
                            destinatarios = destinatarios.Replace(";", ",")
                            destinatarios = destinatarios.Replace(",,", ",")
                            destinatarios = destinatarios.Replace("'", "")
                            destinatarios = destinatarios.Replace(" ", "")
                            SendCorreoAdjunto(Msg, String.Empty, destinatarios, Asunto, True)
                            Threading.Thread.Sleep(300)
                            strData = "Envio: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Envio de notificacion a la Compañia: " & i.Item("descripcionAgencia") & ControlChars.CrLf
                            txtJobs.Text = strData & txtJobs.Text
                        End If
                        Contactos = "<ul><li>"
                        destinatarios = ""
                    Next
                    If reporte > 0 Then
                        'If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
                        '    FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
                        'End If
                        'Dim strFileName As String = rutaejecutable & "\ReportesTagsa.xlsx"
                        ' Guardamos el excel en la ruta que ha especificado el usuario
                        'wbXl.SaveAs(strFileName)
                        '' Cerramos el workbook
                        'appXL.Workbooks.Close()
                        '' Eliminamos el objeto excel
                        'appXL.Application.Quit()
                        'appXL.Quit()

                        Msg = "Se adjunto el Listado de las personas que su credencial Tagsa esta a punto de caducar de hoy a 5 dias"
                        Asunto = "ALERTA CADUCIDAD CREDENCIAL TAGSA"
                        destinatarios = destinatarios.Replace(",", ";")
                        destinatarios = destinatarios.Replace(" ", "")
                        destinatarios = destinatarios.Replace(",,", ",")
                        SendCorreoAdjunto(Msg, strFileName, destinatariosCopia, Asunto, True)
                        Threading.Thread.Sleep(300)
                        strData = "Envio: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Envio de notificacion del listado de personas a cadaducar Tagsa " & ControlChars.CrLf
                        txtJobs.Text = strData & txtJobs.Text
                        My.Computer.FileSystem.DeleteFile(strFileName)
                    End If
                    resul = ActualizaDatosJob(NombreJobs, tipoEjecucion, ValorEjecucion)
                ElseIf idJobs = 2 Then
                    contRowDest = 0
                    For Each row As DataRow In ObtenerCorreoReporte(idJobs).Rows
                        Msg = row.Item("CuerpoCorreo")
                        Asunto = row.Item("Asunto")
                    Next
                    For Each r As DataRow In obtenerAgencia().Rows
                        If InStr(r.Item("mailAgencia"), "@") > 0 Then
                            If contRowDest > 0 Then
                                destinatarios += ", " & r.Item("mailAgencia")
                            Else
                                destinatarios = r.Item("mailAgencia")
                            End If
                            contRowDest += 1
                        End If
                        If contRowDest >= 20 Then
                            destinatarios = destinatarios & "," & destinatariosCopia
                            Dim rutaejecutable1 As String = Application.StartupPath
                            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable1 & "\LogFiles") Then
                                FileIO.FileSystem.CreateDirectory(rutaejecutable1 & "\LogFiles")
                            End If
                            Dim strFileName1 As String = rutaejecutable1 & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".xlsx"
                            IO.File.WriteAllBytes(strFileName1, My.Resources.FORMATO_SISTEMA_GENERALAIR1)
                            destinatarios = destinatarios.Replace(";", ",")
                            destinatarios = destinatarios.Replace(",,", ",")
                            destinatarios = destinatarios.Replace("'", "")
                            destinatarios = destinatarios.Replace(" ", "")
                            SendCorreoAdjunto(Msg, strFileName1, destinatarios, Asunto, True)
                            Threading.Thread.Sleep(300)
                            strData = "Envio: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Envio de notificacion mensual " & ControlChars.CrLf
                            txtJobs.Text = strData & txtJobs.Text
                            contRowDest = 0
                        End If
                    Next
                    If contRowDest < 20 Then
                        destinatarios = destinatarios & "," & destinatariosCopia
                        Dim rutaejecutable1 As String = Application.StartupPath
                        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable1 & "\LogFiles") Then
                            FileIO.FileSystem.CreateDirectory(rutaejecutable1 & "\LogFiles")
                        End If
                        Dim strFileName1 As String = rutaejecutable1 & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".xlsx"
                        IO.File.WriteAllBytes(strFileName1, My.Resources.FORMATO_SISTEMA_GENERALAIR1)
                        destinatarios = destinatarios.Replace(";", ",")
                        destinatarios = destinatarios.Replace(",,", ",")
                        destinatarios = destinatarios.Replace("'", "")
                        destinatarios = destinatarios.Replace(" ", "")
                        SendCorreoAdjunto(Msg, strFileName1, destinatarios, Asunto, True)
                        Threading.Thread.Sleep(300)
                        strData = "Envio: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " Envio de notificacion mensual " & ControlChars.CrLf
                        txtJobs.Text = strData & txtJobs.Text
                        contRowDest = 0
                    End If
                    'My.Computer.FileSystem.DeleteFile(strFileName1)
                    resul = ActualizaDatosJob(NombreJobs, tipoEjecucion, ValorEjecucion)
                ElseIf idJobs = 3 Then
                    Try
                        For Each row As DataRow In ObtenerCorreoReporte(idJobs).Rows
                            Msg = row.Item("CuerpoCorreo")
                            Asunto = row.Item("Asunto")
                        Next
                        Dim desti As String = String.Empty
                        dest = GetDestinatariosPorIdReporte(10) 'CommonData.GetDestinatariosPorIdReporte(7)
                        For Each r As DataRow In dest.Rows
                            If contRowDest > 0 Then
                                desti += ", " & r.Item("mail")
                            Else
                                desti = r.Item("mail")
                            End If
                            contRowDest += 1
                        Next
                        Dim Notificacion As ClassNotificacion
                        Dim result As String = String.Empty
                        result = Notificacion.ProcesaNotificacion(Asunto, Msg, desti, Application.StartupPath)
                        If result <> String.Empty Then
                            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & result & ControlChars.CrLf
                            txtJobs.Text = strData & result
                        End If
                        resul = ActualizaDatosJob(NombreJobs, tipoEjecucion, ValorEjecucion)
                    Catch ex As Exception
                        strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
                        txtJobs.Text = strData & txtJobs.Text
                    End Try
                End If
            End If
        Catch ex As Exception
            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
        End Try
    End Sub
    Shared Function ObtenerDatosJob() As DataTable
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim dtDestinatarios = New DataTable("Sp_ObtenerDatosJob")
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .CommandText = "Sp_ObtenerDatosJob"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            dtDestinatarios.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtDestinatarios
        Catch ex As Exception
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function
    Shared Function AgregaEjecucionJobs(NombreJobs As String, TipoEjecucion As String, ValorEjecucion As Integer) As Boolean
        Dim result As Boolean = True
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .Parameters.AddWithValue("NombreJobs", NombreJobs)
                .Parameters.AddWithValue("TipoEjecucion", TipoEjecucion)
                .Parameters.AddWithValue("ValorEjecucion", ValorEjecucion)
                .CommandText = "Sp_AgregaEjecucionJobs"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                '.CommandTimeout = 20
                .Connection.Open()
            End With
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As Exception
            result = False
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return result
    End Function
    Shared Function ActualizaDatosJob(NombreJobs As String, TipoEjecucion As String, ValorEjecucion As Integer) As Boolean
        Dim result As Boolean
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .Parameters.AddWithValue("NombreJobs", NombreJobs)
                .Parameters.AddWithValue("TipoEjecucion", TipoEjecucion)
                .Parameters.AddWithValue("ValorEjecucion", ValorEjecucion)
                .CommandText = "Sp_ActualizaDatosJob"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                '.CommandTimeout = 20
                .Connection.Open()
            End With
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As Exception
            result = False
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return result
    End Function
    Shared Function EliminarEjecucionJobs(req As String) As Boolean
        Dim result As Boolean
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .Parameters.AddWithValue("NombreJobs", req)
                .CommandText = "Sp_EliminarEjecucionJobs"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                ' .CommandTimeout = 20
                .Connection.Open()
            End With
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        Catch ex As Exception
            result = False
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
        Return result
    End Function
    Shared Function ObtProxCaduTagsa() As DataTable

        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim dtDestinatarios = New DataTable("ObtProxCaduTagsa")
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .CommandText = "Sp_ObtenerProximoCaducaTagsa"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                '  .CommandTimeout = 20
                .Connection.Open()
            End With
            dtDestinatarios.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtDestinatarios
        Catch ex As Exception
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function
    Shared Function ObtenerCorreoReporte(IdJobs As Integer) As DataTable

        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim dtDestinatarios = New DataTable("ObtProxCaduTagsa")
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .Parameters.AddWithValue("idJobs", IdJobs)
                .CommandText = "Sp_ObtenerCorreoReporte"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                '  .CommandTimeout = 20
                .Connection.Open()
            End With
            dtDestinatarios.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtDestinatarios
        Catch ex As Exception
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function
    Shared Function obtenerAgencia() As DataTable

        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim dtDestinatarios = New DataTable("Sp_ObtenerDatosJob")
        dbTran = MyDbFactory.CreateDatabase("TranDB")
        Try
            With cmd
                .CommandText = "obtenerAgencia"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                ' .CommandTimeout = 20
                .Connection.Open()
            End With
            dtDestinatarios.Load(cmd.ExecuteReader)
            cmd.Connection.Close()
            Return dtDestinatarios
        Catch ex As Exception
            SetLogEvent(ex)
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function

    Private Sub BtnVerificaTagsa_Click(sender As Object, e As EventArgs) Handles BtnVerificaTagsa.Click
        If bgwReporteTagsa.IsBusy = False Then
            TiempoSleep = 600000
            Dim strData As String
            strData = "Inicio de Ejecucion: Jobs " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
            bgwReporteTagsa.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        CargarDatosJobs()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnDetenerProceso.Click
        If bgwReporteTagsa.IsBusy Then
            TiempoSleep = 1000
            Dim strData As String
            strData = "Se Detiene de Ejecucion: Jobs " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
            bgwReporteTagsa.CancelAsync()
            BtnVerificaTagsa.Enabled = False
        End If
    End Sub

    Private Sub bgwCargaJobs_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCargaJobs.DoWork
        Dim VerificaJobs As Boolean
        BtnVerificaTagsa.Enabled = False
        BtnRefresh.Enabled = False
        BtnDetenerProceso.Enabled = False
        BtnAgregar.Enabled = False
        While VerificaJobs = False
            VerificaJobs = CargarDatosJobs()
            Threading.Thread.Sleep(5000)
        End While
        BtnVerificaTagsa.Enabled = True
        BtnRefresh.Enabled = True
        BtnDetenerProceso.Enabled = True
        BtnAgregar.Enabled = True
    End Sub
    Public Sub SendCorreoAdjunto(ByVal msj As String, direccionAdjunto As String, destinatarios As String, descripcionReporte As String, Oculto As Boolean)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = 587
                    .Host = "192.168.10.181"
                    .Credentials = New System.Net.NetworkCredential("reportes", "Pa$$w0rd19")
                    .EnableSsl = False
                End With
                Using msg As New Net.Mail.MailMessage '("reportes@generalairsa.com", destinatarios)
                    Dim from As New Net.Mail.MailAddress("reportes@generalairsa.com")
                    msg.From = from
                    If Oculto Then
                        msg.Bcc.Add(destinatarios)
                    Else
                        msg.To.Add(destinatarios)
                    End If
                    If direccionAdjunto <> String.Empty Then
                        Dim attachment As System.Net.Mail.Attachment
                        attachment = New System.Net.Mail.Attachment(direccionAdjunto)
                        msg.Attachments.Add(attachment)
                    End If
                    msg.Subject = descripcionReporte
                    msg.Body = msj
                    msg.IsBodyHtml = True
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim strData As String
            strData = "Error: " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & ex.Message & ControlChars.CrLf
            txtJobs.Text = strData & txtJobs.Text
            SetLogEvent(ex)
        End Try
    End Sub
#End Region
End Class

