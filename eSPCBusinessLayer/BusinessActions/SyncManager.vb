Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class SyncManager


    Public Shared Function GetServerLastUpdate(ByVal req As SyncRequest) As SyncResponse
        Dim dbTran As Database
        Dim Result As New SyncResponse
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req.SessionKey) Then
                'Try
                '    DatabaseFactory.SetDatabaseProviderFactory(New DatabaseProviderFactory())
                'Catch ex As Exception
                'End Try
                cmd.CommandText = "SyncGetServerLastUpdate"
                'dbTran = DatabaseFactory.CreateDatabase("TranDB")
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                Result.ServerLastUpdate = dbTran.ExecuteScalar(cmd)
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

End Class
