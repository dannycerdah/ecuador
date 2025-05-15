Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class RptWareHouse
    Public enc As New List(Of Encabezado)
    Public det As New List(Of Detalle)
    Public aerolinea As String = String.Empty
    Public idGuia As Guid = Guid.Empty
    Dim path As String = ""
    Public vuelo As String
    Public fecha As String
    Public DestinatarioNotificacion As String 'jrodriguez sprint01 25/04/2025
    Public NotificacionTotal As Boolean

    Private Sub RptWareHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WareHouse.LocalReport.DataSources.Clear()
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("Encabezado", enc))
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("Detalle", det))
            Me.WareHouse.SetDisplayMode(DisplayMode.PrintLayout)
            Me.WareHouse.RefreshReport()

            guardarReporte()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guardarReporte()
        Try
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\WareHouse") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\WareHouse")
            End If
            'If Not FileIO.FileSystem.DirectoryExists("C:\Reports\WareHouse") Then
            '    FileIO.FileSystem.CreateDirectory("C:\Reports\WareHouse")
            'End If
            Dim byteViewer As Byte() = WareHouse.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            'path = "C:\Reports\WareHouse\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            'ini jrodriguez sprint01 25/04/2025
            path = rutaejecutable & "\Reports\WareHouse\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            'path = Config.RutaNotificacion & "\Reports\WareHouse\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            'fin jrodriguez sprint01 25/04/2025
            Dim newFile As New FileStream(path, FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
            Dim tempGuia As New Server.VuelosService.GuiaItem
            tempGuia.Id = idGuia
            tempGuia = CommonProcess.obtenerEstadoReporteGuia(tempGuia)
            Notificacion() 'jrodriguez sprint01 25/04/2025
            If tempGuia.estadoReporte = "T" Then
                Exit Sub
            End If
            'EnviarReporte()'jrodriguez sprint01 25/04/2025
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "guardarReporte")
        End Try
    End Sub

    Private Sub EnviarReporte()
        Try
            Dim dest As New DataTable("destinatarios")
            Dim contRowDest As Integer = 0
            Dim destinatarios As String = ""
            dest = CommonData.GetDestinatariosPorIdReporte(4)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            General.SendReportsMessage("Adjunto pdf con reporte WareHouse" & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje", _
                                        path, destinatarios, "WareHouse " & aerolinea & " " & vuelo & " " & fecha)
            Dim tempGuia As New Server.VuelosService.GuiaItem
            tempGuia.Id = idGuia
            tempGuia.estadoReporte = "T"
            CommonProcess.ModificarEstadoReporteGuia(tempGuia)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
    'ini jrodriguez sprint01 25/04/2025
    Private Sub Notificacion()
        Try
            Dim notificacion As New Server.ProcesoService.Notificacion()
            Dim msj = Config.CuerpoNotificacionWH.Replace("@guia", enc.Item(0).Guia).Replace("@fecha", enc.Item(0).Fecha.ToString()).Replace("@destino", enc.Item(0).Destino).Replace("@agencia", enc.Item(0).Agencia).Replace("@vuelo", vuelo)
            General.SendReportsMessage(msj, path, DestinatarioNotificacion.Replace(";", ","), Config.AsuntoNotificacionWH.Replace("@guia", enc.Item(0).Guia))
            If NotificacionTotal Then
                MessageBox.Show(Config.MsjAlertaNotiEmailOk, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Config.MsjAlertaNotiEmailError, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            With notificacion
                .Agencia = aerolinea & "-" & vuelo
                .Guia = enc.Item(0).Guia
                .CorreosNotificados = DestinatarioNotificacion
                .RutaWarehouse = path
            End With
            CommonProcess.NotificacionWarehouse(notificacion)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
    'fin jrodriguez sprint01 25/04/2025
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class