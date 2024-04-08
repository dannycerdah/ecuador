Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager

Public Class AcarreoManager

    Public Shared Function SaveAcarreoItem(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Acarreo As Object()
        Try
            If ValidateSession(req) Then
                With req.myAcarreoItem
                    Acarreo = New Object() {.IdAcarreo, .idProceso, .idBriefing, .fecha}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myAcarreoItem.IdAcarreo)
                    .CommandText = "CheckExistsAcarreo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idAcarreo", Acarreo(0))
                        .Parameters.AddWithValue("idProceso", Acarreo(1))
                        .Parameters.AddWithValue("idBriefing", Acarreo(2))
                        .Parameters.AddWithValue("fecha", Acarreo(3))
                        .CommandText = "modificarAcarreo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idAcarreo", Acarreo(0))
                        .Parameters.AddWithValue("idProceso", Acarreo(1))
                        .Parameters.AddWithValue("idBriefing", Acarreo(2))
                        .Parameters.AddWithValue("fecha", Acarreo(3))
                        .CommandText = "agregarAcarreo"
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

    Public Shared Function SaveStackPalletsItem(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Acarreo As Object()
        Try
            If ValidateSession(req) Then
                With req.myStackPalletsItem
                    Acarreo = New Object() {.idProceso, .idElemento, .idContacto, .fecha, .isBase, .peso, .indice, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idProceso", Acarreo(0))
                    .Parameters.AddWithValue("idElemento", Acarreo(1))
                    .CommandText = "CheckExistsStackPallets"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idProceso", Acarreo(0))
                        .Parameters.AddWithValue("idElemento", Acarreo(1))
                        .Parameters.AddWithValue("idContacto", Acarreo(2))
                        .Parameters.AddWithValue("fecha", Acarreo(3))
                        .Parameters.AddWithValue("isBase", Acarreo(4))
                        .Parameters.AddWithValue("peso", Acarreo(5))
                        .Parameters.AddWithValue("indice", Acarreo(6))
                        .Parameters.AddWithValue("estado", Acarreo(7))
                        .CommandText = "modificarStackPallets"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idProceso", Acarreo(0))
                        .Parameters.AddWithValue("idElemento", Acarreo(1))
                        .Parameters.AddWithValue("idContacto", Acarreo(2))
                        .Parameters.AddWithValue("fecha", Acarreo(3))
                        .Parameters.AddWithValue("isBase", Acarreo(4))
                        .Parameters.AddWithValue("peso", Acarreo(5))
                        .Parameters.AddWithValue("indice", Acarreo(6))
                        .Parameters.AddWithValue("estado", Acarreo(7))
                        .CommandText = "agregarStackPallets"
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

    Public Shared Function SaveDetalleAcarreoElementoItem(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Acarreo As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleAcarreoElementoItem
                    Acarreo = New Object() {.IdDetalle, .idDetalleAcarreo, .idElemento, .peso, .idProceso}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleAcarreoElementoItem.IdDetalle)
                    .CommandText = "CheckExistsDetalleAcarreoElemento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idDetalle", Acarreo(0))
                        .Parameters.AddWithValue("idDetalleAcarreo", Acarreo(1))
                        .Parameters.AddWithValue("idElemento", Acarreo(2))
                        .Parameters.AddWithValue("peso", Acarreo(3))
                        .Parameters.AddWithValue("idProceso", Acarreo(4))
                        .CommandText = "modificarDetalleAcarreoElemento"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idDetalle", Acarreo(0))
                        .Parameters.AddWithValue("idDetalleAcarreo", Acarreo(1))
                        .Parameters.AddWithValue("idElemento", Acarreo(2))
                        .Parameters.AddWithValue("peso", Acarreo(3))
                        .Parameters.AddWithValue("idProceso", Acarreo(4))
                        .CommandText = "agregarDetalleAcarreoElemento"
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

    Public Shared Function SaveDetalleAcarreoItem(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Acarreo As Object()
        Try
            If ValidateSession(req) Then
                With req.myDetalleAcarreoItem
                    Acarreo = New Object() {.IdDetalle, .idAcarreo, .idDolly, .idChofer, .idAgencia, .idCustodio, .idAgenciaSeguridad, .fechaEntrada, .fechaSalida, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDetalleAcarreoItem.IdDetalle)
                    .CommandText = "CheckExistsDetalleAcarreo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idDetalle", Acarreo(0))
                        .Parameters.AddWithValue("idAcarreo", Acarreo(1))
                        .Parameters.AddWithValue("idDolly", Acarreo(2))
                        .Parameters.AddWithValue("idChofer", Acarreo(3))
                        .Parameters.AddWithValue("idAgencia", Acarreo(4))
                        .Parameters.AddWithValue("idCustodio", Acarreo(5))
                        .Parameters.AddWithValue("idAgenciaSeguridad", Acarreo(6))
                        .Parameters.AddWithValue("fechaEntrada", Acarreo(7))
                        .Parameters.AddWithValue("fechaSalida", Acarreo(8))
                        .Parameters.AddWithValue("estado", Acarreo(9))
                        .CommandText = "modificarDetalleAcarreo"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idDetalle", Acarreo(0))
                        .Parameters.AddWithValue("idAcarreo", Acarreo(1))
                        .Parameters.AddWithValue("idDolly", Acarreo(2))
                        .Parameters.AddWithValue("idChofer", Acarreo(3))
                        .Parameters.AddWithValue("idAgencia", Acarreo(4))
                        .Parameters.AddWithValue("idCustodio", Acarreo(5))
                        .Parameters.AddWithValue("idAgenciaSeguridad", Acarreo(6))
                        .Parameters.AddWithValue("fechaEntrada", Acarreo(7))
                        .Parameters.AddWithValue("fechaSalida", Acarreo(8))
                        .Parameters.AddWithValue("estado", Acarreo(9))
                        .CommandText = "agregarDetalleAcarreo"
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

   Public Shared Function GetAcarreoPorId(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtAcarreo As AcarreoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAcarreo", req.myAcarreoItem.IdAcarreo)
                    .CommandText = "ObtenerAcarreoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtAcarreo = New AcarreoItem
                    With myDtAcarreo
                        .IdAcarreo = drReader.GetValue(drReader.GetOrdinal("idAcarreo"))
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                    End With
                    Result.myAcarreoItem = myDtAcarreo
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

    Public Shared Function GetStackPalletsPorIndice(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtStackPallets As StackPalletsItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("indice", req.myStackPalletsItem.indice)
                    .CommandText = "ObtenerStackPalletsPorIndice"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtStackPallets = New StackPalletsItem
                    With myDtStackPallets
                        .idProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                        .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                        .isBase = drReader.GetValue(drReader.GetOrdinal("isBase"))
                        .peso = drReader.GetValue(drReader.GetOrdinal("peso"))
                        .indice = drReader.GetValue(drReader.GetOrdinal("indice"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myStackPalletsItem = myDtStackPallets
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

    Public Shared Function GetAcarreoPorIdBriefing(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtAcarreo As AcarreoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idBriefing", req.myAcarreoItem.idBriefing)
                    .CommandText = "ObtenerAcarreoPorIdBriefing"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtAcarreo = New AcarreoItem
                    With myDtAcarreo
                        .IdAcarreo = drReader.GetValue(drReader.GetOrdinal("idAcarreo"))
                        .idBriefing = drReader.GetValue(drReader.GetOrdinal("idBriefing"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                    End With
                    Result.myAcarreoItem = myDtAcarreo
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

    Public Shared Function GetDetalleAcarreoElementoPorId(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtAcarreoElemento As DetalleAcarreoElementoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idDetalle", req.myDetalleAcarreoElementoItem.IdDetalle)
                    .CommandText = "ObtenerDetalleAcarreoElementoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtAcarreoElemento = New DetalleAcarreoElementoItem
                    With myDtAcarreoElemento
                        .IdDetalle = drReader.GetValue(drReader.GetOrdinal("idDetalle"))
                        .idDetalleAcarreo = drReader.GetValue(drReader.GetOrdinal("idDetalleAcarreo"))
                        .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .idProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                    End With
                    Result.myDetalleAcarreoElementoItem = myDtAcarreoElemento
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

    Public Shared Function GetDetalleAcarreoStack(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtAcarreoElemento As DetalleAcarreoElementoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idDetalleAcarreo", req.myDetalleAcarreoElementoItem.IdDetalle)
                    .Parameters.AddWithValue("idElemento", req.myDetalleAcarreoElementoItem.idElemento)
                    .Parameters.AddWithValue("idProceso", req.myDetalleAcarreoElementoItem.idProceso)
                    .CommandText = "ObtenerDetalleAcarreoStack"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtAcarreoElemento = New DetalleAcarreoElementoItem
                    With myDtAcarreoElemento
                        .IdDetalle = drReader.GetValue(drReader.GetOrdinal("idDetalle"))
                        .idDetalleAcarreo = drReader.GetValue(drReader.GetOrdinal("idDetalleAcarreo"))
                        .idElemento = drReader.GetValue(drReader.GetOrdinal("idElemento"))
                        .idProceso = drReader.GetValue(drReader.GetOrdinal("idProceso"))
                    End With
                    Result.myDetalleAcarreoElementoItem = myDtAcarreoElemento
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

    Public Shared Function GetDetalleAcarreoPorId(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDtDetalleAcarreo As DetalleAcarreoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idDetalle", req.myDetalleAcarreoItem.IdDetalle)
                    .CommandText = "ObtenerDetalleAcarreoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDtDetalleAcarreo = New DetalleAcarreoItem
                    With myDtDetalleAcarreo
                        .IdDetalle = drReader.GetValue(drReader.GetOrdinal("idDetalle"))
                        .idAcarreo = drReader.GetValue(drReader.GetOrdinal("idAcarreo"))
                        .idDolly = drReader.GetValue(drReader.GetOrdinal("idDolly"))
                        .idChofer = drReader.GetValue(drReader.GetOrdinal("idChofer"))
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .idCustodio = drReader.GetValue(drReader.GetOrdinal("idCustodio"))
                        .idAgenciaSeguridad = drReader.GetValue(drReader.GetOrdinal("idAgenciaSeguridad"))
                        .fechaEntrada = drReader.GetValue(drReader.GetOrdinal("fechaEntrada"))
                        .fechaSalida = drReader.GetValue(drReader.GetOrdinal("fechaSalida"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myDetalleAcarreoItem = myDtDetalleAcarreo
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

    Public Shared Function GetDetalleAcarreoPorIdAcarreo(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAcarreo", req.myDetalleAcarreoItem.idAcarreo)
                    .CommandText = "obtenerDetalleAcarreoPorIdAcarreo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleAcarreo"))
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

    Public Shared Function GetDetalleAcarreoElementoPorIdAcarreo(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idDetalle", req.myDetalleAcarreoElementoItem.idDetalleAcarreo)
                    .CommandText = "obtenerDetalleAcarreoElementoPorIdAcarreo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleAcarreoElemento"))
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

    Public Shared Function GetStackPalletsPorIdProceso(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("Id", req.myStackPalletsItem.idProceso)
                    .CommandText = "obtenerStackPalletsPorIdProceso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtStackPalletsElementos"))
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


    Public Shared Function GetDetalleAcarreoPorEstado(req As AcarreoRequest) As AcarreoResponse
        Dim Result As New AcarreoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                'drReader = dbTran.ExecuteReader("ObtenerAeropuertoPorId", req.myAirportCatItem.Id)
                With cmd
                    .Parameters.AddWithValue("idAcarreo", req.myDetalleAcarreoItem.idAcarreo)
                    .Parameters.AddWithValue("estado", req.myDetalleAcarreoItem.estado)
                    .CommandText = "obtenerDetalleAcarreoPorEstado"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("dtDetalleAcarreo"))
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
