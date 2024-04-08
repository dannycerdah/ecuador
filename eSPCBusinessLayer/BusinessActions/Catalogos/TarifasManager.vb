
Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class TarifasManager

    Public Shared Function GetTarifasItemById(req As TarifasRequest) As TarifasResponse
        Dim Result As New TarifasResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTarifas As TarifasCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myTarifasCatalogItem.idTarifas)
                    .CommandText = "obtenerDestinatariosPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTarifas = New TarifasCatalogItem
                    With myTarifas
                        .idTarifas = drReader.GetValue(drReader.GetOrdinal("idTarifas"))
                        .idagencia = drReader.GetValue(drReader.GetOrdinal("idagencia"))
                        .fechaTar = drReader.GetValue(drReader.GetOrdinal("fechaTar"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .agenteCarTar = drReader.GetValue(drReader.GetOrdinal("agenteCarTar"))
                        .almacenajeConTar = drReader.GetValue(drReader.GetOrdinal("almacenajeConTar"))
                        .almacenajeCorTar = drReader.GetValue(drReader.GetOrdinal("almacenajeCorTar"))
                        .almacenajeCarTar = drReader.GetValue(drReader.GetOrdinal("almacenajeCarTar"))
                        .devolucionCarTar = drReader.GetValue(drReader.GetOrdinal("devolucionCarTar"))
                        .correoTar = drReader.GetValue(drReader.GetOrdinal("correoTar"))
                        .estibaDesTar = drReader.GetValue(drReader.GetOrdinal("estibaDesTar"))
                        .limpiezaEleTar = drReader.GetValue(drReader.GetOrdinal("limpiezaEleTar"))
                        .manipuleoTar = drReader.GetValue(drReader.GetOrdinal("manipuleoTar"))
                        .minimoMesTar = drReader.GetValue(drReader.GetOrdinal("minimoMesTar"))
                        .minimoVueloTar = drReader.GetValue(drReader.GetOrdinal("minimoVueloTar"))
                        .montaCargaTar = drReader.GetValue(drReader.GetOrdinal("montaCargaTar"))
                        .precoolingTar = drReader.GetValue(drReader.GetOrdinal("precoolingTar"))
                        .procesamientoCarTar = drReader.GetValue(drReader.GetOrdinal("procesamientoCarTar"))
                        .procesamientoCVTar = drReader.GetValue(drReader.GetOrdinal("procesamientoCVTar"))
                        .variosTar = drReader.GetValue(drReader.GetOrdinal("variosTar"))
                        .ivaTar = drReader.GetValue(drReader.GetOrdinal("ivaTar"))
                        .ageCarIvaTar = drReader.GetValue(drReader.GetOrdinal("ageCarIvaTar"))
                        .almConTar = drReader.GetValue(drReader.GetOrdinal("almConTar"))
                        .almCorIvaTar = drReader.GetValue(drReader.GetOrdinal("almCorIvaTar"))
                        .almCarIvaTar = drReader.GetValue(drReader.GetOrdinal("almCarIvaTar"))
                        .devCarIvaTar = drReader.GetValue(drReader.GetOrdinal("devCarIvaTar"))
                        .correoIvaTar = drReader.GetValue(drReader.GetOrdinal("correoIvaTar"))
                        .estibaIvaTar = drReader.GetValue(drReader.GetOrdinal("estibaIvaTar"))
                        .limEleIvaTar = drReader.GetValue(drReader.GetOrdinal("limEleIvaTar"))
                        .manValIvaTar = drReader.GetValue(drReader.GetOrdinal("manValIvaTar"))
                        .minMesIvaTar = drReader.GetValue(drReader.GetOrdinal("minMesIvaTar"))
                        .minVueIvaTar = drReader.GetValue(drReader.GetOrdinal("minVueIvaTar"))
                        .monCarIvaTar = drReader.GetValue(drReader.GetOrdinal("monCarIvaTar"))
                        .precoolingIvaTar = drReader.GetValue(drReader.GetOrdinal("precoolingIvaTar"))
                        .proCarIvaTar = drReader.GetValue(drReader.GetOrdinal("proCarIvaTar"))
                        .proCarVolIvaTar = drReader.GetValue(drReader.GetOrdinal("proCarVolIvaTar"))
                        .varIvaTar = drReader.GetValue(drReader.GetOrdinal("varIvaTar"))
                    End With
                    Result.myTarifasCatalogItem = myTarifas
                End If
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
End Class
