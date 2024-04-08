Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class RptDecomiso
    Public DecomisoEncabezado As New List(Of DecomisoEncabezado)
    Public DecomisoDetalle As New List(Of DecomisoDetalle)
    Public DecomisoDetalleRemiDesti As New List(Of DecomisoDetalle)
    Public PersonDeco As New ClassPersonDeco 'JRO 07082018
    Public aerolinea As String = String.Empty
    Public idAgenciaReporte As Guid
    Dim path As String = ""
    Public vuelo As String
    Public fecha As String
    Public result As Boolean = False

    Private Sub RptWareHouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Ano As String = Date.Now.ToString("yy")
            Dim mes As String = Date.Now.ToString("MM")
            Dim dia As String = Date.Now.ToString("dd")
            Dim hora As String = Date.Now.ToString("HH")
            Dim minutos As String = Date.Now.ToString("mm")
            Dim ParametroReport As ReportParameter() = New ReportParameter(0) {}
            ParametroReport(0) = New ReportParameter("ReportParameterNumDecomiso", Ano & mes & dia & hora & minutos)
            WareHouse.LocalReport.SetParameters(ParametroReport)
            WareHouse.LocalReport.DataSources.Clear()
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoEncabezado", DecomisoEncabezado))
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoDetalle", DecomisoDetalle))
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoDetalleRemiDesti", DecomisoDetalleRemiDesti)) 'JRO 07082018
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("ClassDetallePersonDeco", PersonDeco.DetallePersonDeco)) 'JRO 07082018
            Me.WareHouse.SetDisplayMode(DisplayMode.PrintLayout)
            Me.WareHouse.RefreshReport()
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
            Dim Ano As String = Date.Now.ToString("yy")
            Dim mes As String = Date.Now.ToString("MM")
            Dim dia As String = Date.Now.ToString("dd")
            Dim hora As String = Date.Now.ToString("HH")
            Dim minutos As String = Date.Now.ToString("mm")
            Dim ParametroReport As ReportParameter() = New ReportParameter(0) {}
            ParametroReport(0) = New ReportParameter("ReportParameterNumDecomiso", Ano & mes & dia & hora & minutos)
            WareHouse.LocalReport.SetParameters(ParametroReport)
            WareHouse.LocalReport.DataSources.Clear()
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoEncabezado", DecomisoEncabezado))
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoDetalle", DecomisoDetalle))
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("DecomisoDetalleRemiDesti", DecomisoDetalleRemiDesti)) 'JRO 07082018
            WareHouse.LocalReport.DataSources.Add(New ReportDataSource("ClassDetallePersonDeco", PersonDeco.DetallePersonDeco)) 'JRO 07082018
            Dim rutaejecutable As String = Application.StartupPath
            'If Not FileIO.FileSystem.DirectoryExists("C:\Reports\Decomiso") Then
            '    FileIO.FileSystem.CreateDirectory("C:\Reports\Decomiso")
            'End If
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\Decomiso") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\Decomiso")
            End If
            Dim byteViewer As Byte() = WareHouse.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            'path = "C:\Reports\Decomiso\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            path = rutaejecutable & "\Reports\Decomiso\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
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
            'dest = CommonData.GetDestinatariosPorIdReporte(6)
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
                                           & "Notificación automática, por favor no responder este mensaje", _
                                            path, destinatarios, "DECOMISO " & aerolinea & " " & vuelo & " " & fecha)
                result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
End Class