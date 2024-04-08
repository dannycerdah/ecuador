Imports MySql.Data.MySqlClient

Public Class SecurityManager

    Public Shared Function ValidateSession(SessionKey As Guid) As Boolean
        Return True
    End Function

    Public Shared Function ValidateSession(ByRef req As Object) As Boolean
        Dim result As Boolean = False
        Dim dbSec As Database
        dbSec = MyDbFactory.CreateDatabase("TranDB")
        result = True 'result =  CBool(dbSec.ExecuteScalar("uspSessionCheckById", req.SessionKey))
        If Not result Then
            Throw New Exception("Sesión Inválida, por favor reinicie sesión.")
        End If
        Return result
    End Function


    Public Shared Function GetParameterTextValue(strParameterName As String) As String
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Result As String = String.Empty
        Dim drReader As MySqlDataReader
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .CommandText = "obtenerParametro"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("prmNombre", strParameterName)
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader()
            If drReader.Read Then
                Result = drReader.GetValue(drReader.GetOrdinal("prmTexto")).ToString
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, New GenericResponse, New GenericRequest)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function



End Class
