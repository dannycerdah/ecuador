Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class MatrizSeguridadManager

    Public Shared Function GetEntireMatrizSeguridadCatalog(req As ReportRequest) As ReportResponse
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
                    .CommandText = "obtenerMatrizSeguridad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Matriz Seguridad"))
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

    Public Shared Function GetMatrizSeguridadItemById(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerMatrizSeguridadDetallePorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Matriz"))
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

    Public Shared Function SaveMatrizSeguridadItem(req As MatrizSeguridadRequest) As MatrizSeguridadResponse
        Dim Result As New MatrizSeguridadResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim cmd3 As New MySqlCommand
        Dim MatrizSeguridad As Object()
        Try
            If ValidateSession(req) Then
                With req.myMatrizSeguridadItem
                    MatrizSeguridad = New Object() { .Id, .FechaCreacion, .UsuarioCreacion, .Descripcion}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myMatrizSeguridadItem.Id)
                    .CommandText = "CheckExistsMatrizSeguridad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", MatrizSeguridad(0))
                        .Parameters.AddWithValue("fechaCreacion", MatrizSeguridad(1))
                        .Parameters.AddWithValue("usuarioCreacion", MatrizSeguridad(2))
                        .Parameters.AddWithValue("descripcion", MatrizSeguridad(3))
                        .CommandText = "modificarMatrizSeguridad"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    With cmd3
                        .Parameters.AddWithValue("Id", MatrizSeguridad(0))
                        .CommandText = "eliminarDetalleMatrizSeguridad"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd3.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", MatrizSeguridad(0))
                        .Parameters.AddWithValue("fechaCreacion", MatrizSeguridad(1))
                        .Parameters.AddWithValue("usuarioCreacion", MatrizSeguridad(2))
                        .Parameters.AddWithValue("descripcion", MatrizSeguridad(3))
                        .CommandText = "agregarMatrizSeguridad"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                cmd3.Connection.Close()
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd3.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd3.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveDetalleMatrizSeguridadItem(req As MatrizSeguridadRequest) As MatrizSeguridadResponse
        Dim Result As New MatrizSeguridadResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        'Dim cmd2 As New MySqlCommand
        Dim DetalleMatrizSeguridad As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleMatrizSeguridadItem
                    DetalleMatrizSeguridad = New Object() {.IdMatriz, .IdTipoAgencia, .CargoPersonal, .CantidadPersonal}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'With cmd
                '    .Parameters.AddWithValue("Id", req.myDetalleMatrizSeguridadItem.IdMatriz)
                '    .CommandText = "CheckExistsDetalleMatrizSeguridad"
                '    .CommandType = CommandType.StoredProcedure
                '    .Connection = dbTran.CreateConnection
                '    .Connection.Open()
                'End With
                ''DsResult.Tables(0).Load(cmd.ExecuteScalar())
                'If CBool(cmd.ExecuteScalar) Then
                '    With cmd2
                '        .Parameters.AddWithValue("Id", DetalleMatrizSeguridad(0))
                '        .Parameters.AddWithValue("tipoAgenciaRequerida", DetalleMatrizSeguridad(1))
                '        .Parameters.AddWithValue("cargoPersonal", DetalleMatrizSeguridad(2))
                '        .Parameters.AddWithValue("cantidadPersonal", DetalleMatrizSeguridad(3))
                '        .CommandText = "agregarDetalleMatrizSeguridad"
                '        .CommandType = CommandType.StoredProcedure
                '        .Connection = dbTran.CreateConnection
                '        .Connection.Open()
                '        cmd2.ExecuteNonQuery()
                '    End With
                'Else
                With cmd
                    .Parameters.AddWithValue("Id", DetalleMatrizSeguridad(0))
                    .Parameters.AddWithValue("tipoAgenciaRequerida", DetalleMatrizSeguridad(1))
                    .Parameters.AddWithValue("cargoPersonal", DetalleMatrizSeguridad(2))
                    .Parameters.AddWithValue("cantidadPersonal", DetalleMatrizSeguridad(3))
                    .CommandText = "agregarDetalleMatrizSeguridad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
            End If
            'cmd2.Connection.Close()
            cmd.Connection.Close()
            'End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            'If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

End Class
