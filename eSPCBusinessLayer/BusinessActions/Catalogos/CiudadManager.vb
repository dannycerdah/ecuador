Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class CiudadManager
    Public Shared Function GetEntireCiudadCatalog(req As ReportRequest) As ReportResponse
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
                    .CommandText = "obtenerCiudades"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Ciudad"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Shared Function GetCiudadPorIdPais(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPais", New String(req.prmArr(0)))
                    .CommandText = "obtenerCiudadPorIdPais"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("CiudadPorPais"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                'dbTran.LoadDataSet("ProductsGroupGetGlobalList", Result.DsResult, New String() {"ProductCategories"}, New Object() {})
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetCiudadItemById(req As CiudadRequest) As CiudadResponse
        Dim Result As New CiudadResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myCiudad As CiudadCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myCiudadCatItem.Id)
                    .CommandText = "ObtenerCiudadPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myCiudad = New CiudadCatalogItem
                    With myCiudad
                        .Id = drReader.GetValue(drReader.GetOrdinal("idCiudad"))
                        .IdPais = drReader.GetValue(drReader.GetOrdinal("idPais"))
                        .CodigoPais = drReader.GetValue(drReader.GetOrdinal("codigoPais"))
                        .NombreCiudad = drReader.GetValue(drReader.GetOrdinal("nombreCiudad"))
                        .NombrePais = drReader.GetValue(drReader.GetOrdinal("nombrePais"))
                    End With
                    Result.myCiudadCatItem = myCiudad
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveCiudadItem(req As CiudadRequest) As CiudadResponse
        Dim Result As New CiudadResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim cmd3 As New MySqlCommand
        Dim Ciudad As Object()
        Try
            If ValidateSession(req) Then
                With req.myCiudadCatItem
                    Ciudad = New Object() {.Id, .IdPais, .CodigoPais, .NombreCiudad}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myCiudadCatItem.Id)
                    .CommandText = "CheckExistsCiudad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    
                        With cmd2
                            .Parameters.AddWithValue("Id", Ciudad(0))
                            .Parameters.AddWithValue("idPais", Ciudad(1))
                            .Parameters.AddWithValue("codigoPais", Ciudad(2))
                            .Parameters.AddWithValue("nombreCiudad", Ciudad(3))
                            .CommandText = "modificarCiudad"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                    

            Else
                With cmd3
                        .Parameters.AddWithValue("nombre", req.myCiudadCatItem.NombreCiudad)
                        .Parameters.AddWithValue("idPais", req.myCiudadCatItem.IdPais)
                        .CommandText = "CheckExistsCiudadPorNombre"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                End With
                    If Not CBool(cmd3.ExecuteScalar) Then
                        With cmd2
                            .Parameters.AddWithValue("Id", Ciudad(0))
                            .Parameters.AddWithValue("idPais", Ciudad(1))
                            .Parameters.AddWithValue("codigoPais", Ciudad(2))
                            .Parameters.AddWithValue("nombreCiudad", Ciudad(3))
                            .CommandText = "agregarCiudad"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                        If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
                    Else
                        Result.ActionResult = False
                        Result.ErrorMessage = "La Ciudad ya está ingresada, verifique Nombre Ciudad!"
                    End If
                    If cmd3.Connection.State = ConnectionState.Open Then cmd3.Connection.Close()
                End If
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection IsNot Nothing Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd3.Connection IsNot Nothing Then
                If cmd3.Connection.State = ConnectionState.Open Then cmd3.Connection.Close()
            End If
        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection IsNot Nothing Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd3.Connection IsNot Nothing Then
                If cmd3.Connection.State = ConnectionState.Open Then cmd3.Connection.Close()
            End If
        End Try
        Return Result
    End Function
End Class
