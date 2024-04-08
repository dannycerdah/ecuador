Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class RptUld
    Public uld As New List(Of EncabezadoUld)
    Public Detail As New List(Of elementoUld)
    Public aerolinea As String = String.Empty
    Dim path As String = ""

    Private Sub RptDetalladoPorAgencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RptRecepcionUld.LocalReport.DataSources.Clear()
            RptRecepcionUld.LocalReport.DataSources.Add(New ReportDataSource("Encabezado", uld))
            RptRecepcionUld.LocalReport.DataSources.Add(New ReportDataSource("Detalle", Detail))
            Me.RptRecepcionUld.SetDisplayMode(DisplayMode.PrintLayout)
            Me.RptRecepcionUld.RefreshReport()

            guardarReporte()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub guardarReporte()
        Try
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\Uld") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\Uld")
            End If
            'If Not FileIO.FileSystem.DirectoryExists("C:\Reports\Uld") Then
            '    FileIO.FileSystem.CreateDirectory("C:\Reports\Uld")
            'End If
            Dim byteViewer As Byte() = RptRecepcionUld.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            'path = "C:\Reports\Uld\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            path = rutaejecutable & "\Reports\Uld\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            Dim newFile As New FileStream(path, FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
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
            dest = CommonData.GetDestinatariosPorIdReporte(2)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            General.SendReportsMessage("Adjunto pdf con reporte Entrega\Recepción ULD" & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje", _
                                       path, destinatarios, "Entrega\Recepcion ULD")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

End Class