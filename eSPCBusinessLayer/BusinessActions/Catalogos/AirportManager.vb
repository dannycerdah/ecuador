Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager


Public Class AirportManager

    Public Shared Function GetEntireAirportSimple(req As ReportRequest) As ReportResponse
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
                    .CommandText = "obtenerAeropuertosSimple"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AirportSimple"))
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

    Public Shared Function GetEntireAirportCatalog(req As ReportRequest) As ReportResponse
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
                    .CommandText = "obtenerAeropuertos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Airport"))
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

    Public Shared Function GetAirportItemById(req As AirportRequest) As AirportResponse
        Dim Result As New AirportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myAirport As AirportCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAirport", req.myAirportCatItem.Id)
                    .CommandText = "ObtenerAeropuertoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myAirport = New AirportCatalogItem
                    With myAirport
                        .Id = drReader.GetValue(drReader.GetOrdinal("idAeropuerto"))
                        .idPais = drReader.GetValue(drReader.GetOrdinal("idPais"))
                        .IdCiudad = drReader.GetValue(drReader.GetOrdinal("idCiudad"))
                        .Nombre = drReader.GetValue(drReader.GetOrdinal("nombreAeropuerto"))
                        .Direccion = drReader.GetValue(drReader.GetOrdinal("direccionAeropuerto"))
                        .Observacion = drReader.GetValue(drReader.GetOrdinal("observacionAeropuerto"))
                        .CodigoIATA = drReader.GetValue(drReader.GetOrdinal("codigoIATA"))
                        .CodigoOACI = drReader.GetValue(drReader.GetOrdinal("codigoOACI"))
                        .PaginaWeb = drReader.GetValue(drReader.GetOrdinal("paginaWeb"))
                        .Telefono = drReader.GetValue(drReader.GetOrdinal("telefonoAeropuerto"))
                        .NumeroTerminales = drReader.GetValue(drReader.GetOrdinal("numeroTerminales"))
                        .Longitud = drReader.GetValue(drReader.GetOrdinal("longitudAeropuerto"))
                        .Latitud = drReader.GetValue(drReader.GetOrdinal("latitudAeropuerto"))
                    End With
                    Result.myAirportCatItem = myAirport
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Shared Function GetAeropuertoPorIdPais(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerAeropuertoPorIdPais"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AeropuertoPorPais"))
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

    Shared Function GetAeropuertoPorIdCiudad(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerAeropuertoPorIdCiudad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AeropuertoPorCiudad"))
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

    Public Shared Function SaveAirportItem(req As AirportRequest) As AirportResponse
        Dim Result As New AirportResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Airport As Object()
        Try
            If ValidateSession(req) Then
                With req.myAirportCatItem
                    Airport = New Object() {.Id, .idPais, .IdCiudad, .Nombre, .Direccion, .Observacion,
                                            .CodigoIATA, .CodigoOACI, .PaginaWeb, .Telefono, .NumeroTerminales, .Longitud, .Latitud}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAeropuerto", req.myAirportCatItem.Id)
                    .CommandText = "CheckExistsAeropuerto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idAeropuerto", Airport(0))
                        .Parameters.AddWithValue("idPais", Airport(1))
                        .Parameters.AddWithValue("idCiudad", Airport(2))
                        .Parameters.AddWithValue("nombre", Airport(3))
                        .Parameters.AddWithValue("direccion", Airport(4))
                        .Parameters.AddWithValue("observacion", Airport(5))
                        .Parameters.AddWithValue("codigoIATA", Airport(6))
                        .Parameters.AddWithValue("codigoOACI", Airport(7))
                        .Parameters.AddWithValue("paginaWeb", Airport(8))
                        .Parameters.AddWithValue("telefonoAeropuerto", Airport(9))
                        .Parameters.AddWithValue("numeroTerminales", Airport(10))
                        .Parameters.AddWithValue("longitudAeropuerto", Airport(11))
                        .Parameters.AddWithValue("latitudAeropuerto", Airport(12))
                        .CommandText = "modificarAeropuerto"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idAeropuerto", Airport(0))
                        .Parameters.AddWithValue("idPais", Airport(1))
                        .Parameters.AddWithValue("idCiudad", Airport(2))
                        .Parameters.AddWithValue("nombre", Airport(3))
                        .Parameters.AddWithValue("direccion", Airport(4))
                        .Parameters.AddWithValue("observacion", Airport(5))
                        .Parameters.AddWithValue("codigoIATA", Airport(6))
                        .Parameters.AddWithValue("codigoOACI", Airport(7))
                        .Parameters.AddWithValue("paginaWeb", Airport(8))
                        .Parameters.AddWithValue("telefonoAeropuerto", Airport(9))
                        .Parameters.AddWithValue("numeroTerminales", Airport(10))
                        .Parameters.AddWithValue("longitudAeropuerto", Airport(11))
                        .Parameters.AddWithValue("latitudAeropuerto", Airport(12))
                        .CommandText = "agregarAeropuerto"
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

    Public Shared Function GetPais(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
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
                'dbTran.LoadDataSet("ProductsGroupGetGlobalList", Result.DsResult, New String() {"ProductCategories"}, New Object() {})
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Shared Function GetCiudad(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPais", New Guid(req.prmArr(0)))
                    .CommandText = "obtenerCiudadPorIdPais"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Ciudad"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                'dbTran.LoadDataSet("ProductsGroupGetGlobalList", Result.DsResult, New String() {"ProductCategories"}, New Object() {})
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Shared Function GetCiudadPorId(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idCiudad", New Guid(req.prmArr(0)))
                    .CommandText = "obtenerCiudadPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Ciudad"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                'dbTran.LoadDataSet("ProductsGroupGetGlobalList", Result.DsResult, New String() {"ProductCategories"}, New Object() {})
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()

        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

End Class
