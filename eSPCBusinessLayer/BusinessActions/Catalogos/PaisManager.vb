Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class PaisManager
    Public Shared Function GetEntirePaisCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                'Try
                '    DatabaseFactory.SetDatabaseProviderFactory(New DatabaseProviderFactory())
                'Catch ex As Exception  
                'End Try
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'dbTran.LoadDataSet("obtenerAeropuertos", Result.DsResult, New String() {"AirportCatalog"}, New Object() {})
                With cmd
                    .CommandText = "obtenerPais"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Pais"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetPaisItemById(req As PaisRequest) As PaisResponse
        Dim Result As New PaisResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPais As PaisCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myPaisCatItem.Id)
                    .CommandText = "obtenerPaisPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myPais = New PaisCatalogItem
                    With myPais
                        .Id = drReader.GetValue(drReader.GetOrdinal("idPais"))
                        .CodigoPais = drReader.GetValue(drReader.GetOrdinal("codigoPais"))
                        .NombrePais = drReader.GetValue(drReader.GetOrdinal("nombrePais"))
                        .Nacionalidad = drReader.GetValue(drReader.GetOrdinal("nacionalidadPais"))
                    End With
                    Result.myPaisCatItem = myPais
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If Not drReader.IsClosed Then drReader.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetCodigoPaisPorId(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                'Try
                '    DatabaseFactory.SetDatabaseProviderFactory(New DatabaseProviderFactory())
                'Catch ex As Exception  
                'End Try
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'dbTran.LoadDataSet("obtenerAeropuertos", Result.DsResult, New String() {"AirportCatalog"}, New Object() {})
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerCodigoPaisPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("CodigoPais"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SavePaisItem(req As PaisRequest) As PaisResponse
        Dim Result As New PaisResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Pais As Object()
        Try
            If ValidateSession(req) Then
                With req.myPaisCatItem
                    Pais = New Object() {.Id, .CodigoPais, .NombrePais, .Nacionalidad}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myPaisCatItem.Id)
                    .CommandText = "CheckExistsPais"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Pais(0))
                        .Parameters.AddWithValue("codigoPais", Pais(1))
                        .Parameters.AddWithValue("nombrePais", Pais(2))
                        .Parameters.AddWithValue("nacionalidadPais", Pais(3))
                        .CommandText = "modificarPais"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Pais(0))
                        .Parameters.AddWithValue("codigoPais", Pais(1))
                        .Parameters.AddWithValue("nombrePais", Pais(2))
                        .Parameters.AddWithValue("nacionalidadPais", Pais(3))
                        .CommandText = "agregarPais"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
