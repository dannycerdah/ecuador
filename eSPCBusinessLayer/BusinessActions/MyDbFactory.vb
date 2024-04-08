Imports Microsoft.Practices.EnterpriseLibrary.Common
Public Class MyDbFactory

    Public Shared Function CreateDatabase(ByVal dbName As String) As Database
        Dim mydb As Database
        Try
            Try
                DatabaseFactory.SetDatabaseProviderFactory(New DatabaseProviderFactory())
            Catch ex1 As Exception
            End Try
            mydb = DatabaseFactory.CreateDatabase(dbName)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return mydb
    End Function

End Class
