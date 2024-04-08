Imports eSPCBusinessLayer.ErrorManager
Public Class AutorizacionesOnlineManager


    Public Shared Function SaveAutorizacionesOnline(ByVal req As AutorizacionesOnlineRequest) As AutorizacionesOnlineResponse
        Dim result As New AutorizacionesOnlineResponse
        Try
            For Each autorizacion In req.AutorizacionesOnline
                autorizacion.SaveAutorizacionOnline()
            Next
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function GetAutorizacionesOnline(ByVal req As AutorizacionesOnlineRequest) As AutorizacionesOnlineResponse
        Dim result As New AutorizacionesOnlineResponse
        Try
            result.myAutorizacionesOnline = New List(Of AutorizacionOnline)
            For Each autorizacion In req.AutorizacionesOnline
                result.myAutorizacionesOnline.Add(New AutorizacionOnline(autorizacion.idAutorizacion))
            Next
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
        Return result
    End Function

    Public Shared Function AprobarAutorizacionOnline(idAutorizacion As String, UsuarioAutoriza As String) As String
        Dim result As String = Nothing
        Dim veriAutr As New AutorizacionOnline(New Guid(idAutorizacion))
        Try

           
            If veriAutr.EstadoAutorizacion = AutorizacionOnline.EstadoAprobacion.Aprobado Then
                result = "La solicitud fue Autorizado por : " + result + veriAutr.UsuarioAprobacion.ToString & Chr(13)
                result = result + "  El  " + veriAutr.FechaHoraAprobacion.ToString
            Else
                AutorizacionOnline.Autorizar(New Guid(idAutorizacion), UsuarioAutoriza)
                result = "Autorizacion Correcta "
            End If

        Catch ex As Exception
            SetLogEvent(ex, result, New GenericResponse)
        End Try
        Return result
    End Function

End Class
