Public Class General

    Public Shared Sub SetBARequest(ByRef req As Object)
        Try
            Dim wsClnt As New Ensamblado_ReporteFlights.ReportService.ReportServiceSoapClient
            req.RequestDate = wsClnt.GetServerDateTime()
            req.PcId = My.Computer.Name
            'req.ActionKey = "Manager - [" & My.Settings.StoreId.ToString & "]"
            req.UserId = My.User.Name
            'req.EnterpriseCode = "E10000"
            Dim ipEntry As Net.IPHostEntry = Net.Dns.GetHostEntry(Net.Dns.GetHostName())
            req.IpAddress = ipEntry.AddressList.GetValue(0).ToString
            ' req.SessionKey = LogonRes.SessionKey
        Catch ex As ServiceModel.EndpointNotFoundException
            ' Using frmNoConn As New frmConnection
            'frmNoConn.ShowDialog()
            'End Using
            SetBARequest(req)
        Catch ex As Exception
        End Try
    End Sub

    'Public Shared Sub ExportToExcel(GridToExport As Infragistics.Win.UltraWinGrid.UltraGrid)
    '    If MessageBox.Show("¿Desea crear un archivo en Excel con los datos consultados?", "Confirmación", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '        Dim FileDlg As New SaveFileDialog
    '        Dim ueeExcelExporter As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    '        FileDlg.Title = "Guardar archivo"
    '        FileDlg.AddExtension = True
    '        FileDlg.DefaultExt = ".xlsx"
    '        FileDlg.ShowDialog()
    '        Try
    '            ueeExcelExporter.Export(GridToExport, FileDlg.FileName, Infragistics.Excel.WorkbookFormat.Excel2007)
    '        Catch ex As ArgumentException
    '            MessageBox.Show("Nombre de archivo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End If
    'End Sub

    Public Shared Sub SetLogEvent(ex As Exception, det As String)
        If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
            FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        End If
        Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message + det & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

    Public Shared Sub SetLogEvent(ex As Exception)
        If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
            FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        End If
        Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub


    Public Shared Sub SetLogEvent(ex As String)
        If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
            FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        End If
        Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

End Class
