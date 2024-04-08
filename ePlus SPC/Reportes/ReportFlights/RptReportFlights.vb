Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class RptReportFlights
    Public DecomisoEncabezado As New List(Of DecomisoEncabezado)
    Public DecomisoDetalle As New List(Of DecomisoDetalle)
    Public aerolinea As String = String.Empty
    Dim path As String = ""
    Public vuelo As String
    Public fecha As String
    Public result As Boolean = False
    Public idAgenciaReport As Guid
    Public briefingEncabezado As New List(Of BriefingEncabezado)
    Public briefingDetalle As New List(Of BriefingDetalle)

    Public camionesEncabezado As New List(Of CamionesEncabezado)
    Public camionesDetalle As New List(Of CamionesDetalle)

    Public PersonalProceso As New List(Of PersonalProceso)
    Public PersonalProcesoDetalle As New List(Of PersonalProcesoDetalle)

    Public ProcesoCarga As New List(Of ProcesoCarga)
    Public ProcesoCargaDetalle As New List(Of ProcesoCargaDetalle)

    Public ProcesoCarga2 As New List(Of ProcesoCarga2)
    Public ProcesoCargaDetalle2 As New List(Of ProcesoCargaDetalle2)

    Public ProcesoCargaAlmacenaje As New List(Of ProcesoCargaAlmacenaje)
    Public ProcesoCargaAlmacenajeDetalle As New List(Of ProcesoCargaAlmacenajeDetalle)

    Public Acarreo As New List(Of Acarreo)
    Public DetalleAcarreo As New List(Of DetalleAcarreo)

    Public ElementoPresel As New List(Of ElementosPreseleccionados)
    Public ElementoPreselDetalle As New List(Of ElementosPreseleccionadosDetalle)

    Public ElementoCargado As New List(Of ElementosCargados)
    Public ElementoCargadoDetalle As New List(Of ElementosCargadosDetalle)

    Public Novedades As New List(Of Novedades)

    Private Sub RptReportFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ReportFlights.LocalReport.DataSources.Clear()
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("BriefingEncabezado", briefingEncabezado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("BriefingDetalle", briefingDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoPreseleccionado", ElementoPresel))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoPreseleccionadoDetalle", ElementoPreselDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("CamionesEncabezado", camionesEncabezado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("CamionesDetalle", camionesDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("PersonalProceso", PersonalProceso))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("PersonalProcesoDetalle", PersonalProcesoDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCarga", ProcesoCarga))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaDetalle", ProcesoCargaDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCarga2", ProcesoCarga2))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaDetalle2", ProcesoCargaDetalle2))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaAlmacenaje", ProcesoCargaAlmacenaje))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaAlmacenajeDetalle", ProcesoCargaAlmacenajeDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoCargado", ElementoCargado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoCargadoDetalle", ElementoCargadoDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("Acarreo", Acarreo))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("DetalleAcarreo", DetalleAcarreo))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("Novedades", Novedades))
            ReportFlights.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportFlights.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub PersonalProcesoDetalleBindingSource_CurrentChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub guardarReporte()
        Try
            ReportFlights.LocalReport.DataSources.Clear()
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("BriefingEncabezado", briefingEncabezado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("BriefingDetalle", briefingDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoPreseleccionado", ElementoPresel))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoPreseleccionadoDetalle", ElementoPreselDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("CamionesEncabezado", camionesEncabezado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("CamionesDetalle", camionesDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("PersonalProceso", PersonalProceso))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("PersonalProcesoDetalle", PersonalProcesoDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCarga", ProcesoCarga))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaDetalle", ProcesoCargaDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCarga2", ProcesoCarga2))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaDetalle2", ProcesoCargaDetalle2))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaAlmacenaje", ProcesoCargaAlmacenaje))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ProcesoCargaAlmacenajeDetalle", ProcesoCargaAlmacenajeDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoCargado", ElementoCargado))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("ElementoCargadoDetalle", ElementoCargadoDetalle))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("Acarreo", Acarreo))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("DetalleAcarreo", DetalleAcarreo))
            ReportFlights.LocalReport.DataSources.Add(New ReportDataSource("Novedades", Novedades))
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Reports\Novedades") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Reports\Novedades")
            End If
            'If Not FileIO.FileSystem.DirectoryExists("C:\Reports\") Then
            '    FileIO.FileSystem.CreateDirectory("C:\Reports\")
            'End If
            Dim byteViewer As Byte() = ReportFlights.LocalReport.Render("PDF")
            Dim SaveFile As New SaveFileDialog
            SaveFile.Filter = "*PDF files (*.pdf)|*.pdf"
            SaveFile.FilterIndex = 2
            SaveFile.RestoreDirectory = True
            'path = "C:\Reports\Novedades\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            path = rutaejecutable & "\Reports\Novedades\" & aerolinea & " " & DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss") & ".pdf"
            Dim newFile As New FileStream(Path, FileMode.Create)
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
            dest = CommonData.GetDestinatariosbyIdReporteyAgencia(1, idAgenciaReport)
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
                General.SendReportsMessage("Adjunto pdf con reporte de Novedades del vuelo" & vbCrLf _
                                           & "Notificación automática, por favor no responder este mensaje", _
                                            path, destinatarios, "NOV. " & vuelo & " " & fecha)

                result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub
    Friend WithEvents WareHouse As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DecomisoEncabezadoBindingSource As System.Windows.Forms.BindingSource
End Class