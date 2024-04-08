Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class RptElementoStock
    Public encabezadoElemento As New List(Of encabezadoElemento)
    Public detalleElemento As New List(Of detalleElemento)
    Public aerolinea As String = String.Empty
    Public idAgenciaReporte As Guid
    Dim path As String = ""
    Public result As Boolean = False
    Private Sub RptWareHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            StockElementos.LocalReport.DataSources.Clear()
            StockElementos.LocalReport.DataSources.Add(New ReportDataSource("encabezadoElemento", encabezadoElemento))
            StockElementos.LocalReport.DataSources.Add(New ReportDataSource("detalleElemento", detalleElemento))
            Me.StockElementos.SetDisplayMode(DisplayMode.PrintLayout)
            Me.StockElementos.RefreshReport()
            guardarReporte()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub guardarReporte()
        Try
            StockElementos.LocalReport.DataSources.Clear()
            StockElementos.LocalReport.DataSources.Add(New ReportDataSource("encabezadoElemento", encabezadoElemento))
            StockElementos.LocalReport.DataSources.Add(New ReportDataSource("detalleElemento", detalleElemento))
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\Stock") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\Stock")
            End If
            'If Not FileIO.FileSystem.DirectoryExists("C:\Reports\Stock") Then
            '    FileIO.FileSystem.CreateDirectory("C:\Reports\Stock")
            'End If
            Dim byteViewer As Byte() = StockElementos.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            'path = "C:\Reports\Stock\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy") & ".pdf"
            path = rutaejecutable & "\Reports\Stock\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy") & ".pdf"
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
            Dim fecha As String = DateTime.Now.ToString("dd-MM-yyyy")
            'dest = CommonData.GetDestinatariosPorIdReporte(7)
            dest = CommonData.GetDestinatariosbyIdReporteyAgencia(3, idAgenciaReporte)
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

                General.SendReportsMessage("Adjunto pdf con Stock de Elementos" & vbCrLf _
                                           & "Notificación automática, por favor no responder este mensaje", _
                                           path, destinatarios, "INV. " & aerolinea & " " & fecha)
                result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub

End Class