Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class PersonalProcesoManager

    Public Shared Function DeletePersonalProceso(req As PersonalProcesoRequest) As PersonalProcesoResponse
        Dim Result As New PersonalProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myPersonalProcesoItem.idProceso)
                    .CommandText = "eliminarPersonalPorProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
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

    Public Shared Function SavePersonalProcesoItem(req As PersonalProcesoRequest) As PersonalProcesoResponse
        Dim Result As New PersonalProcesoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim PersonalProceso As Object()
        Try
            If ValidateSession(req) Then
                With req.myPersonalProcesoItem
                    PersonalProceso = New Object() {.idProceso, .idMatrizSeg, .horaInicio, .horaFin, .idAgencia, .cargo, .idPersona, .grupoProceso, .muelle}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                With cmd
                    .Parameters.AddWithValue("Id", PersonalProceso(0))
                    .Parameters.AddWithValue("idMatrizSeg", PersonalProceso(1))
                    .Parameters.AddWithValue("horaInicio", PersonalProceso(2))
                    .Parameters.AddWithValue("horaFin", PersonalProceso(3))
                    .Parameters.AddWithValue("idAgencia", PersonalProceso(4))
                    .Parameters.AddWithValue("cargo", PersonalProceso(5))
                    .Parameters.AddWithValue("idPersona", PersonalProceso(6))
                    .Parameters.AddWithValue("grupoPersonal", PersonalProceso(7))
                    .Parameters.AddWithValue("muelle", PersonalProceso(8))
                    .CommandText = "agregarPersonalPorProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
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

    Public Shared Function GetPersonalPorIdProceso(req As ProcesoRequest) As ProcesoResponse
        Dim Result As New ProcesoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myProcesoItem.IdProceso)
                    .CommandText = "obtenerPersonalPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PersonalProceso"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
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
End Class
