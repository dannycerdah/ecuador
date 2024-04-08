Module ProcesoCapturaPeso
    Public Property ErrorMessage As String
    Public Property ErrorRef As Integer

    Public Class administradorProcesos
        Public Shared Sub LogEventos(Optional ByRef RefEx As String = "", Optional ByRef NomTabla As String = "")
            Dim strContent As String = String.Empty
            ' Dim tabla As String = String.Empty
            ' RefEx = NumRef()
            'RefEx = ErrorRef
            'NomTabla = ErrorMessage
            strContent = Date.Now.ToString & " --> ID: " & RefEx & " --> Registros:" & NomTabla & ControlChars.CrLf
            IO.File.AppendAllText("C:\proceso\" & Date.Today.ToString("yyyy-MM-dd") & ".txt", strContent)
        End Sub

        Public Shared Function NumRef() As Integer
            Dim conv As Integer = 0
            Dim strError As String = IO.File.ReadAllText("C:\proceso\ProcesoCaptura.txt")
            conv = Val(CChar(strError))
            conv += 1
            IO.File.WriteAllText("C:\proceso\ProcesoCaptura.txt", conv.ToString)
            Return conv
        End Function
    End Class
End Module
