Public Class ClassTemperatura
    Implements IDisposable
    Public Event ObtenerTemp(humedas As String, centigrado As String, fahrenheit As String)
    Public Event PresentarDatosPantalla(Datos As String, DatosError As String)
    Public Event CambioTemp(PuertoCom As String, CuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double)
    Public Event CambioTempHist(PuertoCom As String, CuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double)
    Private P_PuertoCom As String
    Private P_NombreCuarto As String
    Private humedas_ant As String
    Private centigrados_ant As String
    Private fahrenheit_ant As String
    Dim disposed As Boolean = False
    Public Property EndHilo As Boolean = False
    Dim pc As New IO.Ports.SerialPort
    Dim HiloRegTempHist As New Threading.Thread(AddressOf RegHistTemp)
    Public Sub New(PuertoCom As String, NombreCuarto As String)
        P_PuertoCom = PuertoCom
        P_NombreCuarto = NombreCuarto
        AbirPuertoCom()
        HiloRegTempHist.IsBackground = False
        HiloRegTempHist.Start()
        Threading.Thread.Sleep(200)
    End Sub
    Private Sub AbirPuertoCom()
        pc.PortName = P_PuertoCom
        pc.Open()
        AddHandler pc.DataReceived, AddressOf ObtenerDatos
    End Sub
    Private Sub EnviarDatos(Datos As String, DatosError As String)
        RaiseEvent PresentarDatosPantalla(Datos, DatosError)
    End Sub
    Private Sub ObtenerDatos(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        Dim DatosPantalla As String
        Dim ErroPantalla As String
        Try
            Dim DataIn As String = String.Empty
            Dim humedad As String
            Dim centigrados As String
            Dim fahrenheit As String
            Dim posicionIni As Integer
            Dim posicionFin As Integer
            Threading.Thread.Sleep(100)
            DataIn = sender.ReadExisting
            posicionFin = InStr(DataIn, "%")
            posicionIni = InStr(DataIn.Substring(0, posicionFin), ":")
            humedad = DataIn.Substring(posicionIni, posicionFin - posicionIni - 1)
            posicionFin = InStr(DataIn, "*C")
            posicionIni = InStr(DataIn.Substring(0, posicionFin), "a:")
            centigrados = DataIn.Substring(posicionIni + 2, posicionFin - (posicionIni + 2) - 1)
            posicionFin = InStr(DataIn, "*F")
            posicionIni = InStr(DataIn.Substring(0, posicionFin), "*C")
            fahrenheit = DataIn.Substring(posicionIni + 2, posicionFin - (posicionIni + 2) - 1)
            DatosPantalla = "Puerto: " + P_PuertoCom + " Cuarto: " + P_NombreCuarto + " " + DataIn
            humedad = humedad.Replace(" ", "").Replace(".", ",")
            centigrados = centigrados.Replace(" ", "").Replace(".", ",")
            fahrenheit = fahrenheit.Replace(" ", "").Replace(".", ",")
            If IsNumeric(humedad) And IsNumeric(centigrados) And IsNumeric(fahrenheit) Then
                If humedas_ant <> humedad And centigrados_ant <> centigrados And fahrenheit_ant <> fahrenheit Then
                    humedas_ant = humedad
                    centigrados_ant = centigrados
                    fahrenheit_ant = fahrenheit
                    RaiseEvent CambioTemp(P_PuertoCom, P_NombreCuarto, Double.Parse(humedad), Double.Parse(centigrados), Double.Parse(fahrenheit))
                End If
                EnviarDatos(DatosPantalla.Replace(Chr(13), ""), "")
            End If
        Catch ex As Exception
            ErroPantalla = ex.Message
            EnviarDatos("", "Puerto: " + P_PuertoCom + " Cuarto: " + P_NombreCuarto + " " + ErroPantalla)
        End Try
    End Sub
    Private Sub RegHistTemp()
        While EndHilo = False
            Try
                If Not IsNothing(humedas_ant) And Not IsNothing(centigrados_ant) And Not IsNothing(fahrenheit_ant) Then
                    If Not IsDBNull(humedas_ant) And Not IsDBNull(centigrados_ant) And Not IsDBNull(fahrenheit_ant) Then
                        RaiseEvent CambioTempHist(P_PuertoCom, P_NombreCuarto, Double.Parse(humedas_ant), Double.Parse(centigrados_ant), Double.Parse(fahrenheit_ant))
                    End If
                End If
            Catch ex As Exception
                EnviarDatos("", "Puerto: " + P_PuertoCom + " Cuarto: " + P_NombreCuarto + " " + ex.Message)
            End Try
            Threading.Thread.Sleep(300000)
        End While
    End Sub
    ' Field to handle multiple calls to Dispose gracefully.
    ' Implement IDisposable.
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                disposed = True
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
        End If
    End Sub
    Protected Overrides Sub Finalize()
        ' Simply call Dispose(False).
        Dispose(False)
    End Sub
    Public Sub EndEjecHilo()
        pc.Close()
        EndHilo = True
        HiloRegTempHist.Abort()
    End Sub
End Class
