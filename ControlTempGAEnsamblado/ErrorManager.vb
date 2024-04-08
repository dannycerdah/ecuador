Imports System.Net.Mime.MediaTypeNames

Public Class ErrorManager

    Public Shared Sub SetLogEvent(ex As Exception, StartupPath As String)
        If StartupPath = "" Then
            StartupPath = "C:"
        End If
        Dim rutaejecutable As String = StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex.Message & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

    Public Shared Sub SetLogEvent(ex As String, StartupPath As String)
        If StartupPath = "" Then
            StartupPath = "C:"
        End If
        Dim rutaejecutable As String = StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\LogFiles") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\LogFiles")
        End If
        Dim strFileName As String = rutaejecutable & "\LogFiles\" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
        Dim strMessage As String = String.Empty
        strMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & vbCrLf & ex & vbCrLf & vbCrLf & vbCrLf
        IO.File.AppendAllText(strFileName, strMessage)
    End Sub

    Public Shared Sub SetLogEvent(ByRef ex As Exception, ByRef Result As Object, ByRef Request As Object, StartupPath As String)
        Result.ActionResult = False
        Result.ErrorMessage = ex.Message
        SetLogEvent(ex, StartupPath)
    End Sub
    Public Shared Sub SendCorreoAdjunto(ByVal msj As String, direccionAdjunto As String, destinatarios As String, descripcionReporte As String, Oculto As Boolean, StartupPath As String)
        Dim sender As New System.Net.Mail.SmtpClient
        Try
            If destinatarios <> "" Then
                With sender
                    .Port = 587
                    .Host = "192.168.10.181"
                    .Credentials = New System.Net.NetworkCredential("reportes", "Pa$$w0rd19")
                    .EnableSsl = False
                End With
                Using msg As New Net.Mail.MailMessage '("reportes@generalairsa.com", destinatarios)
                    Dim from As New Net.Mail.MailAddress("reportes@generalairsa.com")
                    msg.From = from
                    If Oculto Then
                        msg.Bcc.Add(destinatarios)
                    Else
                        msg.To.Add(destinatarios)
                    End If
                    If direccionAdjunto <> String.Empty Then
                        Dim attachment As System.Net.Mail.Attachment
                        attachment = New System.Net.Mail.Attachment(direccionAdjunto)
                        msg.Attachments.Add(attachment)
                    End If
                    msg.Subject = descripcionReporte
                    msg.Body = msj
                    msg.IsBodyHtml = True
                    sender.Send(msg)
                End Using
            End If
        Catch ex As Exception
            SetLogEvent(ex, StartupPath)
        End Try
    End Sub
End Class
