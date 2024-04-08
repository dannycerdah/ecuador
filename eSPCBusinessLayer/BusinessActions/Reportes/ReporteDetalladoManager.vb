Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class ReporteDetalladoManager
    Public Shared Function GetReporteDetalleProcesoPorIdProceso(req As ReportGroupRequest) As ReportGroupResponse
        Dim Result As New ReportGroupResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myReportGroupByAgencia.idProceso)
                    .CommandText = "obtenerDetalleProcesoPorIdProcesoReporteDetallado"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtReporteDetalleProceso"))
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
