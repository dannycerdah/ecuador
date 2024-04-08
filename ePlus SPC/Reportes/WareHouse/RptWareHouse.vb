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
            path = rutaejecutable & "\Reports\WareHouse\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            Dim newFile As New FileStream(path, FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
            Dim tempGuia As New Server.VuelosService.GuiaItem
            tempGuia.Id = idGuia
            tempGuia = CommonProcess.obtenerEstadoReporteGuia(tempGuia)
            If tempGuia.estadoReporte = "T" Then
                Exit Sub
            End If
            EnviarReporte()
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


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class