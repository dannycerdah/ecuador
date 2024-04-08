Imports Microsoft.Reporting.WinForms

Public Class RptActEntregaRecep
    Public PersonDeco As New ClassPersonDeco
    Public ParametrosDeco As New List(Of ClassParametrosDeco)
    Public idAgenciaReporte As Guid
    Public aerolinea As String = String.Empty
    Public vuelo As String
    Public result As Boolean = False
    Public fecha As String
    Dim path As String = ""
    Private Sub RptActEntregaRecep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportPersonDeco.LocalReport.DataSources.Add(New ReportDataSource("ClassDetallePersonDeco", PersonDeco.DetallePersonDeco))
        ReportPersonDeco.LocalReport.DataSources.Add(New ReportDataSource("ParametrosDeco", ParametrosDeco))
        Me.ReportPersonDeco.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportPersonDeco.RefreshReport()
    End Sub
    Public Sub guardarReporte()
        Try
            ReportPersonDeco.LocalReport.DataSources.Add(New ReportDataSource("ClassDetallePersonDeco", PersonDeco.DetallePersonDeco))
            ReportPersonDeco.LocalReport.DataSources.Add(New ReportDataSource("ParametrosDeco", ParametrosDeco))
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\Decomiso") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\Decomiso")
            End If
            Dim byteViewer As Byte() = ReportPersonDeco.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            path = rutaejecutable & "\Reports\Decomiso\ReporDecomisoActaRecepcion" & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            Dim newFile As New IO.FileStream(path, IO.FileMode.Create)
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
            dest = CommonData.GetDestinatariosbyIdReporteyAgencia(6, idAgenciaReporte)
            If dest.Rows.Count = 0 Then
                MessageBox.Show("No hay destinatarios a enviar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                result = False
            Else
                For Each r As DataRow In dest.Rows
                    If r.Item("estado") = "A" Then
                        If contRowDest > 0 Then
                            destinatarios += ", " & r.Item("mail")
                        Else
                            destinatarios = r.Item("mail")
                        End If
                        contRowDest += 1
                    End If
                Next
                General.SendReportsMessage("Adjunto pdf con reporte Decomiso" & vbCrLf _
                                           & "Notificación automática, por favor no responder este mensaje",
                                            Path, destinatarios, "DECOMISO " & aerolinea & " " & vuelo & " " & fecha)
                result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
End Class