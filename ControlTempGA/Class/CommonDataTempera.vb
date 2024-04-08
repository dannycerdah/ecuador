Imports ControlTempGA.Server.ControlTemp

Public Class CommonDataTempera
    Public Shared Function ObtenerCuartosFrios() As DataTable
        Dim Result As New DataTable("Sp_ObtenerCuartosFrios")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            res = wsClient.ObtenerCuartosFrios(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerConfTemp() As DataTable
        Dim Result As New DataTable("Sp_ObtenerConfTemp")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            res = wsClient.ObtenerConfTemp(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerTempAct(NombreCuarto As String) As DataTable
        Dim Result As New DataTable("Sp_ObtenerTempAct")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            req.NombreCuartoFrio = NombreCuarto
            res = wsClient.ObtenerTempAct(req)
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function

    Public Shared Function RegConfTemp(Puerto As String, Estado As String, NombreCuartoFrio As String) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            req.Puerto = Puerto
            req.NombreCuartoFrio = NombreCuartoFrio
            req.Estado = Estado
            res = wsClient.RegConfTemp(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function RegCuartoFrio(NombreCuartoFrio As String, Estado As String, Descripcion As String) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            req.NombreCuartoFrio = NombreCuartoFrio
            req.Estado = Estado
            req.Descripcion = Descripcion
            res = wsClient.RegCuartoFrio(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function RegTemperatura(Puerto As String, NombreCuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            With req
                .Puerto = Puerto
                .NombreCuartoFrio = NombreCuartoFrio
                .Humedad = Humedad
                .Centigrado = Centigrado
                .fahrenheit = fahrenheit
            End With
            res = wsClient.RegTemperatura(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function RegTemperaturaHist(Puerto As String, NombreCuartoFrio As String, Humedad As Double, Centigrado As Double, fahrenheit As Double) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            With req
                .Puerto = Puerto
                .NombreCuartoFrio = NombreCuartoFrio
                .Humedad = Humedad
                .Centigrado = Centigrado
                .fahrenheit = fahrenheit
            End With
            res = wsClient.RegTemperaturaHist(req)
            If res.ActionResult Then
                Result = True
            Else
                Result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ActualizaVersion(NombreVersion As String) As Boolean
        Dim Result As Boolean
        Dim wsClient As New ControlTempSoapClient
        Dim req As New TempRequest
        Dim res As New TempResponse
        Try
            Result = wsClient.ActualizaVersion(NombreVersion)
        Catch ex As Exception
            Result = False
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerRegCuartProduc() As DataTable
        Dim Result As New DataTable("Sp_ObtenerTempAct")
        Dim wsClient As New ControlTempSoapClient
        Dim req As New NotificacionTempRequest
        Dim res As New NotificacionTempResponse
        Try
            res = wsClient.ObtenerRegCuartProduc()
            If res.ActionResult Then
                Result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Result
    End Function
    Public Shared Function ObtenerParametrosNoti(datos As NotificacionTemp) As DataTable
        Dim Result As New DataTable
        Dim wsClient As New ControlTempSoapClient
        Dim req As New NotificacionTempRequest
        Dim res As New NotificacionTempResponse
        Dim NotificacionTemp As New NotificacionTemp
        Try
            NotificacionTemp = datos
            req.NotificacionTemp = NotificacionTemp
            res = wsClient.ObtenerParametrosNoti(req)
            If res.ActionResult Then
                Result = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
        End Try
        Return Result
    End Function
End Class
