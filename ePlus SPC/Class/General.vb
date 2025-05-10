Public Class General

    Public Shared Sub SetBARequest(ByRef req As Object)
        Try
            Dim wsClnt As New Server.ReportService.ReportServiceSoapClient
            req.RequestDate = wsClnt.GetServerDateTime() ''aqui se cae
            req.PcId = My.Computer.Name
            req.UserId = My.User.Name
            Dim ipEntry As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            req.IpAddress = ipEntry.AddressList.GetValue(0).ToString
            'req.SessionKey = LogonRes.SessionKey
        Catch ex As ServiceModel.EndpointNotFoundException
            SetBARequest(req)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ExportToExcel(GridToExport As Infragistics.Win.UltraWinGrid.UltraGrid)
        If MessageBox.Show("¿Desea crear un archivo en Excel con los datos consultados?", "Confirmación", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim FileDlg As New SaveFileDialog
            Dim ueeExcelExporter As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
            FileDlg.Title = "Guardar archivo"
            FileDlg.AddExtension = True
            FileDlg.DefaultExt = ".xlsx"
            FileDlg.ShowDialog()
            Try
                ueeExcelExporter.Export(GridToExport, FileDlg.FileName, Infragistics.Excel.WorkbookFormat.Excel2007)
            Catch ex As ArgumentException
                MessageBox.Show("Nombre de archivo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Public Shared Sub ExportToPDF(GridToExport As Infragistics.Win.UltraWinGrid.UltraGrid)
        If MessageBox.Show("¿Desea crear un archivo en PDF con los datos consultados?", "Confirmación", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim fileName As String
            Dim ultraGridDocumentExporter1 As New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter

            Dim FileDlg As New SaveFileDialog
            Dim ueeExcelExporter As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
            FileDlg.Title = "Guardar archivo"
            FileDlg.AddExtension = True
            FileDlg.DefaultExt = ".pdf"
            FileDlg.ShowDialog()
            Try
                fileName = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), FileDlg.FileName)
                ultraGridDocumentExporter1.Export(GridToExport, fileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)
                Process.Start(fileName)
            Catch ex As ArgumentException
                MessageBox.Show("Nombre de archivo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Shared Sub excelExporter_HeaderCellExporting(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.HeaderCellExportingEventArgs)
        e.GridHeader.Appearance.ForeColor = Color.Black
        e.GridHeader.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
    End Sub
    Private Shared Sub excelExporter_InitializeColumn(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs)
        e.ExcelFormatStr = e.Column.Format
    End Sub
    Private Shared Sub MyGridExporter_BeginExport(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ExcelExport.BeginExportEventArgs)
        Dim ws As Infragistics.Excel.Worksheet
        ws = e.CurrentWorksheet
        ws.PrintOptions.PaperSize = Infragistics.Excel.PaperSize.A2
        ws.PrintOptions.Orientation = Infragistics.Excel.Orientation.Landscape
        ws.DisplayOptions.MagnificationInNormalView = 80
    End Sub
    Public Shared Sub SetLogEvent(ex As Exception, det As String)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        'If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
        '    FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        'End If
        'Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message + det & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
        'MARZ_19.08.17
        MessageBox.Show("Mensaje de error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub SetLogEvent(ex As Exception)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        'If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
        '    FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        'End If
        'Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

    Public Shared Sub SetLogEvent(ex As String)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        'If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
        '    FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        'End If
        'Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

    Public Shared Sub SendReportsMessage(ByVal msj As String, direccionAdjunto As String, destinatarios As String, descripcionReporte As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = Config.correoPuerto
                    .Host = Config.correoHost
                    .Credentials = New System.Net.NetworkCredential(Config.UsuarioCorreo, Config.correoClave)
                    .EnableSsl = Config.correoSSL
                    .DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                End With
                Using msg As New Net.Mail.MailMessage(Config.correoRemitente, destinatarios, descripcionReporte, msj)
                    Dim attachment As System.Net.Mail.Attachment
                    attachment = New System.Net.Mail.Attachment(direccionAdjunto)
                    msg.IsBodyHtml = True
                    msg.Attachments.Add(attachment)
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetLogEvent(ex, "SendReportsMessage")
        End Try
    End Sub

    Public Shared Sub SendCheckUserManagerReportsMessage(ByVal msj As String, destinatarios As String, descripcionPermiso As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = Config.correoPuerto
                    .Host = Config.correoHost
                    .Credentials = New System.Net.NetworkCredential(Config.UsuarioCorreo, Config.correoClave)
                    .EnableSsl = Config.correoSSL
                End With
                Using msg As New Net.Mail.MailMessage(Config.correoRemitente, destinatarios, descripcionPermiso, msj)
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetLogEvent(ex, "SendReportsMessage")
        End Try
    End Sub

End Class
