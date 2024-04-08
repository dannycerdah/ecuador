Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class ProcesoCourrierManager

    Public Shared Function SaveGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Dim cmd As MySqlCommand
        Dim cmd1 As MySqlCommand
        Dim resp As New GavetaGuiaResponse
        Dim dbTran As Database

        Try

            If ValidateSession(req) Then

                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGavetaGuiaItem)
                    .CommandText = "CheckExistsGavetaGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If Not CBool(cmd.ExecuteScalar) Then
                    With cmd1
                        .Parameters.AddWithValue("_idgavetaguia", req.myGavetaGuiaItem.idgavetaguia)
                        .Parameters.AddWithValue("_idGuia", req.myGavetaGuiaItem.idGuia)
                        .Parameters.AddWithValue("_idDetalleProceso", req.myGavetaGuiaItem.idDetalleProceso)
                        .Parameters.AddWithValue("_idBriefing", req.myGavetaGuiaItem.idBriefing)
                        .Parameters.AddWithValue("_idElemento", req.myGavetaGuiaItem.idElemento)
                        .Parameters.AddWithValue("_fecha", req.myGavetaGuiaItem.fecha)
                        .Parameters.AddWithValue("_pesoReferencialElemento", req.myGavetaGuiaItem.pesoReferencialElemento)
                        .Parameters.AddWithValue("_fechaCarga", req.myGavetaGuiaItem.fechaCarga)
                        .Parameters.AddWithValue("_pesoCarga", req.myGavetaGuiaItem.pesoCarga)
                        .Parameters.AddWithValue("_estado", req.myGavetaGuiaItem.estado)
                        .CommandText = "agregarGavetaGuia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd1.ExecuteNonQuery()
                    End With
                End If
                cmd1.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            resp.ActionResult = False
            SetLogEvent(ex, resp, req)
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return resp

    End Function


    Public Shared Function EliminarGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Dim cmd As MySqlCommand
        Dim cmd1 As MySqlCommand
        Dim resp As New GavetaGuiaResponse
        Dim dbTran As Database

        Try

            If ValidateSession(req) Then

                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGavetaGuiaItem)
                    .CommandText = "CheckExistsGavetaGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd1
                        .Parameters.AddWithValue("_idgavetaguia", req.myGavetaGuiaItem.idgavetaguia)
                        .CommandText = "eliminarGavetaGuia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd1.ExecuteNonQuery()
                    End With
                End If
                cmd1.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            resp.ActionResult = False
            SetLogEvent(ex, resp, req)
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return resp

    End Function


    Public Shared Function ModificarGavetaGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Dim cmd As MySqlCommand
        Dim cmd1 As MySqlCommand
        Dim resp As New GavetaGuiaResponse
        Dim dbTran As Database

        Try

            If ValidateSession(req) Then

                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myGavetaGuiaItem)
                    .CommandText = "CheckExistsGavetaGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd1
                        .Parameters.AddWithValue("_idgavetaguia", req.myGavetaGuiaItem.idgavetaguia)
                        .Parameters.AddWithValue("_fechaCarga", req.myGavetaGuiaItem.fechaCarga)
                        .Parameters.AddWithValue("_estado", req.myGavetaGuiaItem.estado)
                        .CommandText = "modificarGavetaGuia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd1.ExecuteNonQuery()
                    End With
                End If
                cmd1.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            resp.ActionResult = False
            SetLogEvent(ex, resp, req)
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd1.Connection IsNot Nothing Then
                If cmd1.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return resp

    End Function


    Public Shared Function GetGavetaGuiaporBriefingIdGuia(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Dim Result As New GavetaGuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader

        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("_idBriefing", req.myGavetaGuiaItem.idBriefing)
                    .Parameters.AddWithValue("_idGuia", req.myGavetaGuiaItem.idGuia)

                    .CommandText = "obtenergavetaguiaporbriefingidguia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("GavetaporGuia"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                cmd.Connection.Close()
                drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function getGavetaGuiaporIdGuiaIdElemento(req As GavetaGuiaRequest) As GavetaGuiaResponse
        Dim Result As New GavetaGuiaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        'Dim drReader As MySqlDataReader

        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("_idGuia", req.myGavetaGuiaItem.idGuia)
                    .Parameters.AddWithValue("_idElemento", req.myGavetaGuiaItem.idElemento)

                    .CommandText = "obtenerGavetaGuiaporIdGuiaIdElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'drReader = cmd.ExecuteReader()
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("GavetaporGuia"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                cmd.Connection.Close()
                'drReader.Close()
            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)
            'If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            'If Not drReader.IsClosed Then drReader.Close() 'Cerrar
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function


End Class
