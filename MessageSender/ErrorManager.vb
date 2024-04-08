Public Class ErrorManager
    Public Shared Sub SetLogEvent(ex As Exception)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub
    Public Shared Sub SetLogEvent(ByRef ex As Exception, ByRef Result As Object, ByRef Request As Object)
        Result.ActionResult = False
        Result.ErrorMessage = ex.Message
        SetLogEvent(ex)
    End Sub
    Public Shared Sub SendNotificationMessage(ByVal msj As String)
        Dim sender As New Net.Mail.SmtpClient("srv01.eplus.local") With {.EnableSsl = True, .Credentials = New Net.NetworkCredential("notificaciones", "Pa$$w0rdN0t1", "eplus.local")}
        Using msg As New Net.Mail.MailMessage("notificaciones@eplus.com.ec", "SystemAlerts@eplus.com.ec", "Error de sistema " & My.Application.Info.Description, msj)
            sender.Send(msg)
        End Using
    End Sub

End Class
