Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class DollyManager
    Public Shared Function GetEntireDollyCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerDollys"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Dolly"))
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

    Public Shared Function GetDollyItemById(req As DollyRequest) As DollyResponse
        Dim Result As New DollyResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDolly As DollyCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myDollyCatItem.Id)
                    .CommandText = "ObtenerDollyPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDolly = New DollyCatalogItem
                    With myDolly
                        .Id = drReader.GetValue(drReader.GetOrdinal("idDolly"))
                        .codigo = drReader.GetValue(drReader.GetOrdinal("codigoDolly"))
                        .IdAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .nombreAgencia = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estadoDolly"))
                    End With
                    Result.myDollyCatItem = myDolly
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetDollyPorIdAgencia(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerDollysPorIdAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("DollyPorAgencia"))
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

    Public Shared Function SaveDollyItem(req As DollyRequest) As DollyResponse
        Dim Result As New DollyResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Dolly As Object()
        Try
            If ValidateSession(req) Then
                With req.myDollyCatItem
                    Dolly = New Object() {.Id, .codigo, .IdAgencia, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDollyCatItem.Id)
                    .Parameters.AddWithValue("codigoDolly", req.myDollyCatItem.codigo) 'jro 04012019
                    .CommandText = "CheckExistsDolly"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("Id", Dolly(0))
                        .Parameters.AddWithValue("codigo", Dolly(1))
                        .Parameters.AddWithValue("idAgencia", Dolly(2))
                        .Parameters.AddWithValue("estado", Dolly(3))
                        .CommandText = "modificarDolly"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Dolly(0))
                        .Parameters.AddWithValue("codigo", Dolly(1))
                        .Parameters.AddWithValue("idAgencia", Dolly(2))
                        .Parameters.AddWithValue("estado", Dolly(3))
                        .CommandText = "agregarDolly"
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
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
