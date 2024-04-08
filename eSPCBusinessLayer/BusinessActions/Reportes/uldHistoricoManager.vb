Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class uldHistoricoManager

    Public Shared Function SaveUldHistoricoItem(req As uldHistoricoRequest) As uldHistoricoResponse
        Dim Result As New uldHistoricoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim uldHistorico As Object()
        Try
            If ValidateSession(req) Then
                With req.myUldHistorico
                    uldHistorico = New Object() {.idReporte, .tipo, .fecha, .procedencia, .destino, .idChofer, .idCustodio, .idControl, .idBascula, .idUsuario}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idReporte", req.myUldHistorico.idReporte)
                    .CommandText = "CheckExistsUldHistorico"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idReporte", uldHistorico(0))
                        .Parameters.AddWithValue("tipo", uldHistorico(1))
                        .Parameters.AddWithValue("fecha", uldHistorico(2))
                        .Parameters.AddWithValue("procedencia", uldHistorico(3))
                        .Parameters.AddWithValue("destino", uldHistorico(4))
                        .Parameters.AddWithValue("idChofer", uldHistorico(5))
                        .Parameters.AddWithValue("idCustodio", uldHistorico(6))
                        .Parameters.AddWithValue("idControl", uldHistorico(7))
                        .Parameters.AddWithValue("idBascula", uldHistorico(8))
                        .Parameters.AddWithValue("idUsuario", uldHistorico(9))
                        .CommandText = "modificarUldHistorico"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idReporte", uldHistorico(0))
                        .Parameters.AddWithValue("tipo", uldHistorico(1))
                        .Parameters.AddWithValue("fecha", uldHistorico(2))
                        .Parameters.AddWithValue("procedencia", uldHistorico(3))
                        .Parameters.AddWithValue("destino", uldHistorico(4))
                        .Parameters.AddWithValue("idChofer", uldHistorico(5))
                        .Parameters.AddWithValue("idCustodio", uldHistorico(6))
                        .Parameters.AddWithValue("idControl", uldHistorico(7))
                        .Parameters.AddWithValue("idBascula", uldHistorico(8))
                        .Parameters.AddWithValue("idUsuario", uldHistorico(9))
                        .CommandText = "agregarUldHistorico"
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

    Public Shared Function SaveUldHistoricoDetalleItem(req As uldHistoricoRequest) As uldHistoricoResponse
        Dim Result As New uldHistoricoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim uldHistorico As Object()
        Try
            If ValidateSession(req) Then
                With req.myUldHistoricoDetalle
                    uldHistorico = New Object() {.idReporte, .fecha, .idDolly, .idElemento, .idChofer, .idCustodio, .idControl, .idBascula, .pesoRef, .pesoReal}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idReporte", req.myUldHistoricoDetalle.idReporte)
                    .Parameters.AddWithValue("idElemento", req.myUldHistoricoDetalle.idElemento)
                    .CommandText = "CheckExistsUldHistoricoDetalle"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idReporte", uldHistorico(0))
                        .Parameters.AddWithValue("fecha", uldHistorico(1))
                        .Parameters.AddWithValue("idDolly", uldHistorico(2))
                        .Parameters.AddWithValue("idElemento", uldHistorico(3))
                        .Parameters.AddWithValue("idChofer", uldHistorico(4))
                        .Parameters.AddWithValue("idCustodio", uldHistorico(5))
                        .Parameters.AddWithValue("idControl", uldHistorico(6))
                        .Parameters.AddWithValue("idBascula", uldHistorico(7))
                        .Parameters.AddWithValue("pesoRef", uldHistorico(8))
                        .Parameters.AddWithValue("pesoReal", uldHistorico(9))
                        .CommandText = "modificarUldHistoricoDetalle"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idReporte", uldHistorico(0))
                        .Parameters.AddWithValue("fecha", uldHistorico(1))
                        .Parameters.AddWithValue("idDolly", uldHistorico(2))
                        .Parameters.AddWithValue("idElemento", uldHistorico(3))
                        .Parameters.AddWithValue("idChofer", uldHistorico(4))
                        .Parameters.AddWithValue("idCustodio", uldHistorico(5))
                        .Parameters.AddWithValue("idControl", uldHistorico(6))
                        .Parameters.AddWithValue("idBascula", uldHistorico(7))
                        .Parameters.AddWithValue("pesoRef", uldHistorico(8))
                        .Parameters.AddWithValue("pesoReal", uldHistorico(9))
                        .CommandText = "agregarUldHistoricoDetalle"
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
