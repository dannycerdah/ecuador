Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class AgenciaManager
    Public Shared Function GetEntireAgenciaCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Agencia"))
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

    Public Shared Function GetEntireTipoAgencia(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerTipoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Agencia"))
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

    Public Shared Function GetEntireArchivoAgencia(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerArchivoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Agencia"))
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

    Public Shared Function GetTipoAgenciaItemById(req As TipoAgenciaRequest) As TipoAgenciaResponse
        Dim Result As New TipoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTipo As TipoAgenciaCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myTipoAgenciaItem.idTipo)
                    .CommandText = "obtenerTipoAgenciaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTipo = New TipoAgenciaCatalogItem
                    With myTipo
                        .idTipo = drReader.GetValue(drReader.GetOrdinal("idTipo"))
                        .descripcionTipo = drReader.GetValue(drReader.GetOrdinal("descripcionTipo"))

                    End With
                    Result.myTipoAgenciaItem = myTipo
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetArchivoAgenciaItemById(req As ArchivoAgenciaRequest) As ArchivoAgenciaResponse
        Dim Result As New ArchivoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myArchivo As ArchivoAgenciaCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idArchivo", req.myArchivoAgenciaItem.idArchivo)
                    .CommandText = "obtenerArchivoAgenciaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myArchivo = New ArchivoAgenciaCatalogItem
                    With myArchivo
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idEntidad"))
                        .idArchivo = drReader.GetValue(drReader.GetOrdinal("idArchivo"))
                        .descripcionArchivo = drReader.GetValue(drReader.GetOrdinal("descripcionArchivo"))
                        .extArchivo = drReader.GetValue(drReader.GetOrdinal("extArchivo"))
                        .binArchivo = drReader.GetValue(drReader.GetOrdinal("binArchivo"))
                    End With
                    Result.myArchivoAgenciaItem = myArchivo
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

    Public Shared Function GetArchivoAgenciaItemByIdAgencia(req As ArchivoAgenciaRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myArchivoAgenciaItem.idAgencia)
                    .CommandText = "obtenerArchivoAgenciaPorIdAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Archivos"))
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

    Public Shared Function SaveTipoAgenciaItem(req As TipoAgenciaRequest) As TipoAgenciaResponse
        Dim Result As New TipoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Tipo As Object()
        Try
            If ValidateSession(req) Then
                With req.myTipoAgenciaItem
                    Tipo = New Object() {.idTipo, .descripcionTipo}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myTipoAgenciaItem.idTipo)
                    .CommandText = "CheckExistsTipoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Tipo(0))
                        .Parameters.AddWithValue("descripcion", Tipo(1))
                        .CommandText = "modificarTipoAgencia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Tipo(0))
                        .Parameters.AddWithValue("descripcion", Tipo(1))
                        .CommandText = "agregarTipoAgencia"
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

    Public Shared Function SaveArchivoAgenciaItem(req As ArchivoAgenciaRequest) As ArchivoAgenciaResponse
        Dim Result As New ArchivoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Archivo As Object()
        Try
            If ValidateSession(req) Then
                With req.myArchivoAgenciaItem
                    Archivo = New Object() {.idAgencia, .idArchivo, .descripcionArchivo, .extArchivo, .binArchivo, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idArchivo", req.myArchivoAgenciaItem.idArchivo)
                    .CommandText = "CheckExistsArchivoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idAgencia", Archivo(0))
                        .Parameters.AddWithValue("idArchivo", Archivo(1))
                        .Parameters.AddWithValue("descripcion", Archivo(2))
                        .Parameters.AddWithValue("extArchivo", Archivo(3))
                        .Parameters.AddWithValue("binArchivo", Archivo(4))
                        .Parameters.AddWithValue("estado", Archivo(5))
                        .CommandText = "modificarArchivoAgencia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idAgencia", Archivo(0))
                        .Parameters.AddWithValue("idArchivo", Archivo(1))
                        .Parameters.AddWithValue("descripcion", Archivo(2))
                        .Parameters.AddWithValue("extArchivo", Archivo(3))
                        .Parameters.AddWithValue("binArchivo", Archivo(4))
                        .Parameters.AddWithValue("estado", Archivo(5))
                        .CommandText = "agregarArchivoAgencia"
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

    Public Shared Function GetAgenciaItemById(req As AgenciaRequest) As AgenciaResponse
        Dim Result As New AgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myAgencia As AgenciaCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myAgenciaCatItem.Id)
                    .CommandText = "ObtenerAgenciaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myAgencia = New AgenciaCatalogItem
                    With myAgencia
                        .Id = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .Tipo = drReader.GetValue(drReader.GetOrdinal("tipoAgencia"))
                        .Descripcion = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .Direccion = drReader.GetValue(drReader.GetOrdinal("direccionAgencia"))
                        .Telefono = drReader.GetValue(drReader.GetOrdinal("telefonoAgencia"))
                        .Mail = drReader.GetValue(drReader.GetOrdinal("mailAgencia"))
                        .Contacto = drReader.GetValue(drReader.GetOrdinal("contactoAgencia"))
                        .Estado = drReader.GetValue(drReader.GetOrdinal("estadoAgencia"))
                        .Observacion = drReader.GetValue(drReader.GetOrdinal("observacionAgencia"))
                        .RepresentanteLegal = drReader.GetValue(drReader.GetOrdinal("representanteLegal"))
                        .Ruc = drReader.GetValue(drReader.GetOrdinal("rucLegal"))
                        .TipoContribuyente = drReader.GetValue(drReader.GetOrdinal("tipoContribuyenteLegal"))
                        .RazonSocial = drReader.GetValue(drReader.GetOrdinal("razonSocialLegal"))
                        .abreviatura = drReader.GetValue(drReader.GetOrdinal("abreviatura"))
                        .horaProceso = drReader.GetValue(drReader.GetOrdinal("horaProceso"))
                    End With
                    Result.myAgenciaCatItem = myAgencia
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

    Public Shared Function SaveAgenciaItem(req As AgenciaRequest) As AgenciaResponse
        Dim Result As New AgenciaResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Agencia As Object()
        Try
            If ValidateSession(req) Then
                With req.myAgenciaCatItem
                    Agencia = New Object() {.Id, .Tipo, .Descripcion, .Direccion, .Telefono, .Mail, .Contacto,
                                            .Estado, .Observacion, .RepresentanteLegal, .Ruc, .TipoContribuyente, .RazonSocial, .abreviatura, .horaProceso}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myAgenciaCatItem.Id)
                    .CommandText = "CheckExistsAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Agencia(0))
                        .Parameters.AddWithValue("tipoAgencia", Agencia(1))
                        .Parameters.AddWithValue("descripcionAgencia", Agencia(2))
                        .Parameters.AddWithValue("direccionAgencia", Agencia(3))
                        .Parameters.AddWithValue("telefonoAgencia", Agencia(4))
                        .Parameters.AddWithValue("mailAgencia", Agencia(5))
                        .Parameters.AddWithValue("contactoAgencia", Agencia(6))
                        .Parameters.AddWithValue("estadoAgencia", Agencia(7))
                        .Parameters.AddWithValue("observacionAgencia", Agencia(8))
                        .Parameters.AddWithValue("representanteLegal", Agencia(9))
                        .Parameters.AddWithValue("rucLegal", Agencia(10))
                        .Parameters.AddWithValue("tipoContribuyenteLegal", Agencia(11))
                        .Parameters.AddWithValue("razonSocialLegal", Agencia(12))
                        .Parameters.AddWithValue("abreviatura", Agencia(13))
                        .Parameters.AddWithValue("horaTrabajo", Agencia(14))
                        .CommandText = "modificarAgencia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Agencia(0))
                        .Parameters.AddWithValue("tipoAgencia", Agencia(1))
                        .Parameters.AddWithValue("descripcionAgencia", Agencia(2))
                        .Parameters.AddWithValue("direccionAgencia", Agencia(3))
                        .Parameters.AddWithValue("telefonoAgencia", Agencia(4))
                        .Parameters.AddWithValue("mailAgencia", Agencia(5))
                        .Parameters.AddWithValue("contactoAgencia", Agencia(6))
                        .Parameters.AddWithValue("estadoAgencia", Agencia(7))
                        .Parameters.AddWithValue("observacionAgencia", Agencia(8))
                        .Parameters.AddWithValue("representanteLegal", Agencia(9))
                        .Parameters.AddWithValue("rucLegal", Agencia(10))
                        .Parameters.AddWithValue("tipoContribuyenteLegal", Agencia(11))
                        .Parameters.AddWithValue("razonSocialLegal", Agencia(12))
                        .Parameters.AddWithValue("abreviatura", Agencia(13))
                        .Parameters.AddWithValue("horaTrabajo", Agencia(14))
                        .CommandText = "agregarAgencia"
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

    Shared Function GetTipoAgencia(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerTipoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Tipo"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                'dbTran.LoadDataSet("ProductsGroupGetGlobalList", Result.DsResult, New String() {"ProductCategories"}, New Object() {})
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Shared Function GetTipoAgenciaPorId(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerTipoAgenciaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Tipo"))
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
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetAgenciaItemPorTipo(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Tipo", New Guid(req.prmArr(0)))
                    .CommandText = "ObtenerAgenciaPorTipo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Agencia"))
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
End Class
