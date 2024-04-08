Module ModuloCierre
    Public Property EndHilo As Boolean = False
    Public Property InicioEjecucion As DateTime = Nothing
    Private TiempoLoginOut As Integer
    Private diferencia As Integer
    Public Sub EjecutaHiloVerificacion()
        EndHilo = True
        Dim HiloCierreApp As New Threading.Thread(AddressOf VerficiacionCierre)
        HiloCierreApp.IsBackground = False
        HiloCierreApp.Start()
        Threading.Thread.Sleep(200)
    End Sub
    Public Sub VerficiacionCierre()
        While EndHilo = True
            ObtenerPartida()
            If Not IsNothing(InicioEjecucion) Then
                diferencia = DateDiff(DateInterval.Minute, InicioEjecucion, Date.Now)
                If diferencia > IIf(TiempoLoginOut = 0, 10, TiempoLoginOut) Then
                    Application.ExitThread()
                    Application.Exit()
                End If
            End If
            Threading.Thread.Sleep(150000)
        End While
    End Sub
    Private Sub ObtenerPartida()
        Try
            Dim dtParametros As New DataTable("Parametros")
            Dim rows As DataRow()
            Dim partida As String
            dtParametros = CommonProcess.GetParametro("LoginOut")
            If dtParametros.Rows.Count > 0 Then
                For Each r As DataRow In dtParametros.Rows
                    TiempoLoginOut = r.Item("prmNumero")
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub
End Module
