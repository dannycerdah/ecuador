Public Class ErrorManager

    Public Shared Sub SetLogEvent(ex As Exception)
        If Not FileIO.FileSystem.DirectoryExists("C:\LogFiles\") Then
            FileIO.FileSystem.CreateDirectory("C:\LogFiles\")
        End If
        Dim strFileName As String = "C:\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
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

    Public Shared Sub SendCorreo(ByVal msj As String, destinatarios As String, Asunto As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = 587
                    .Host = "192.168.10.181"
                    .Credentials = New System.Net.NetworkCredential("reportes", "Pa$$w0rd19")
                    .EnableSsl = False
                End With
                Using msg As New Net.Mail.MailMessage("reportes@generalairsa.com", destinatarios, Asunto, msj)
                    msg.IsBodyHtml = True
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            SetLogEvent(ex)
        End Try
    End Sub


End Class
