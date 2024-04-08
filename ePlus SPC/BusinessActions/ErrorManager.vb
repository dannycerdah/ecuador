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

End Class
