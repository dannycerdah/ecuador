Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class FacturacionManager
    Public Shared Function MantClientes(req As ClienteRequest) As ClienteResponse
        Dim Result As New ClienteResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Cliente As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Cliente = New Object() { .Cliente.idAgencia, .UserId, .Cliente.Estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("idAgencia", Cliente(0))
                    .CommandText = "ChekExistsClientes"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Cliente(2)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "El Cliente ya se encuentra Ingresado"
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idAgencia", Cliente(0))
                        .Parameters.AddWithValue("UsuarioIngreso", Cliente(1))
                        .Parameters.AddWithValue("estado", Cliente(2))
                        .CommandText = "Sp_MantClientes"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function MantServiciosGA(req As ServiciosGARequest) As ServiciosGAResponse
        Dim Result As New ServiciosGAResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Serv As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Serv = New Object() { .ServiciosGA.idServiciosGA, Trim(.ServiciosGA.DescripcionServicio), .UserId, .ServiciosGA.Estado, .ServiciosGA.Tipo}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("DescripcionServicio", Serv(1))
                    .CommandText = "ChekExistsServiciosGA"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Serv(3)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "YA existe un Servicio con la misma Descripcion " + Serv(1)
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idServiciosGA", Serv(0))
                        .Parameters.AddWithValue("DescripcionServicio", Serv(1))
                        .Parameters.AddWithValue("UsuarioIngreso", Serv(2))
                        .Parameters.AddWithValue("estado", Serv(3))
                        .Parameters.AddWithValue("Tipo", Serv(4))
                        .CommandText = "Sp_MantServiciosGA"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function MantPeriodicidad(req As PeriodicidadRequest) As PeriodicidadResponse
        Dim Result As New PeriodicidadResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Peri As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Peri = New Object() { .Periodicidad.idPeriodicidad, Trim(.Periodicidad.DescripcionPeriodicidad), .UserId, .Periodicidad.Estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("DescripcionPeriodicidad", Peri(1))
                    .CommandText = "ChekExistsPeriodicidad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Peri(3)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "YA existe una Periodicidad con la Descripcion: " + Peri(1)
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idPeriodicidad", Peri(0))
                        .Parameters.AddWithValue("DescripcionPeriodicidad", Peri(1))
                        .Parameters.AddWithValue("UsuarioIngreso", Peri(2))
                        .Parameters.AddWithValue("estado", Peri(3))
                        .CommandText = "Sp_MantPeriodicidad"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function MantPlantiClienteServ(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Plantilla As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Plantilla = New Object() { .PlantillaClienteServicio.idPlantillaClienteServicio, .PlantillaClienteServicio.IdCliente, .PlantillaClienteServicio.idServiciosGA,
                                               .PlantillaClienteServicio.idPeriodicidad, .PlantillaClienteServicio.ValorPeriodicidad, .PlantillaClienteServicio.ValorTarifa,
                                               .PlantillaClienteServicio.CantAlmaContainerPer,
                                               .PlantillaClienteServicio.IdComparacionServicio, .PlantillaClienteServicio.Estado, .UserId}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("IdCliente", Plantilla(1))
                    .Parameters.AddWithValue("idServiciosGA", Plantilla(2))
                    .CommandText = "ChekExistsPlantiClienteServ"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Plantilla(8)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "YA existe una platilal con el mismo Cliente y Servicio "
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idPlantillaClienteServicio", Plantilla(0))
                        .Parameters.AddWithValue("IdCliente", Plantilla(1))
                        .Parameters.AddWithValue("idServiciosGA", Plantilla(2))
                        .Parameters.AddWithValue("idPeriodicidad", Plantilla(3))
                        .Parameters.AddWithValue("ValorPeriodicidad", Plantilla(4))
                        .Parameters.AddWithValue("ValorTarifa", Plantilla(5))
                        .Parameters.AddWithValue("CantAlmaContainerPer", Plantilla(6))
                        .Parameters.AddWithValue("IdComparacionServicio", Plantilla(7))
                        .Parameters.AddWithValue("Estado", Plantilla(8))
                        .Parameters.AddWithValue("UsuarioIngreso", Plantilla(9))
                        .CommandText = "Sp_MantPlantiClienteServ"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function MantServConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Dim Result As New ServConsuClienteResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Plantilla As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Plantilla = New Object() { .ServConsuCliente.idServConsuCliente, .ServConsuCliente.idCliente, .ServConsuCliente.idServiciosGA, .ServConsuCliente.idBriefing, .ServConsuCliente.idGuia, .ServConsuCliente.Guia,
                                                .ServConsuCliente.FechaInicio, .ServConsuCliente.FechaFin, .UserId, .ServConsuCliente.Estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("idCliente", Plantilla(1))
                    .Parameters.AddWithValue("idServiciosGA", Plantilla(2))
                    .Parameters.AddWithValue("idBriefing", Plantilla(3))
                    .Parameters.AddWithValue("idGuia", Plantilla(4))
                    .Parameters.AddWithValue("Guia", Plantilla(5))
                    .Parameters.AddWithValue("FechaInicio", Plantilla(6))
                    .Parameters.AddWithValue("FechaFin", Plantilla(7))
                    .CommandText = "ChekExistsServConsClien"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Plantilla(9)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "Ya se realizo un ingreso con esos datos."
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idServConsuCliente", Plantilla(0))
                        .Parameters.AddWithValue("idCliente", Plantilla(1))
                        .Parameters.AddWithValue("idServiciosGA", Plantilla(2))
                        .Parameters.AddWithValue("idBriefing", Plantilla(3))
                        .Parameters.AddWithValue("idGuia", Plantilla(4))
                        .Parameters.AddWithValue("Guia", Plantilla(5))
                        .Parameters.AddWithValue("FechaInicio", Plantilla(6))
                        .Parameters.AddWithValue("FechaFin", Plantilla(7))
                        .Parameters.AddWithValue("UsuarioIngreso", Plantilla(8))
                        .Parameters.AddWithValue("estado", Plantilla(9))
                        .CommandText = "Sp_MantServConsuCliente"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function MantVuelosCancelados(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Dim Result As New VuelosCanceladosResponse
        Dim dbTran As Database
        Dim cmd As MySqlCommand
        Dim Plantilla As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req
                    Plantilla = New Object() { .VuelosCancelados.idVuelosCancelados, .VuelosCancelados.idCliente, .VuelosCancelados.idBriefing, .VuelosCancelados.Observacion, .VuelosCancelados.Estado,
                                                .UserId}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                cmd = New MySqlCommand
                With cmd
                    .Parameters.AddWithValue("idCliente", Plantilla(1))
                    .Parameters.AddWithValue("idBriefing", Plantilla(2))
                    .CommandText = "ChekExistsVuelosCancelados"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Plantilla(4)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "Ya se realizo un ingreso con esos datos."
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idServConsuCliente", Plantilla(0))
                        .Parameters.AddWithValue("idCliente", Plantilla(1))
                        .Parameters.AddWithValue("idBriefing", Plantilla(2))
                        .Parameters.AddWithValue("Observacion", Plantilla(3))
                        .Parameters.AddWithValue("Estado", Plantilla(4))
                        .Parameters.AddWithValue("UsuarioIngreso", Plantilla(5))
                        .CommandText = "Sp_MantVuelosCancelados"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd.ExecuteNonQuery()
                    End With
                End If
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
    Public Shared Function GetClientes(req As ClienteRequest) As ClienteResponse
        Dim Result As New ClienteResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerClientes"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerClientes"))
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
    Public Shared Function GetServiciosGA(req As ServiciosGARequest) As ServiciosGAResponse
        Dim Result As New ServiciosGAResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerServiciosGA"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerServiciosGA"))
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
    Public Shared Function GetPeriodicidad(req As PeriodicidadRequest) As PeriodicidadResponse
        Dim Result As New PeriodicidadResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerPeriodicidad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerPeriodicidad"))
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
    Public Shared Function GetPlantiClienteServ(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("IdCliente", req.PlantillaClienteServicio.IdCliente)
                    .CommandText = "Sp_ObtenerPlantiClienteServ"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerPlantiClienteServ"))
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
    Public Shared Function GetTipoProceAlmacenaCarga(req As TipoProcesoAlmacenajeCargaRequest) As TipoProcesoAlmacenajeCargaResponse
        Dim Result As New TipoProcesoAlmacenajeCargaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerTipoProceAlmacenaCarga"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerTipoProceAlmacenaCarga"))
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
    Public Shared Function PreFactObtenerPesoVolumenVuelo(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("FechaInicio", req.PlantillaClienteServicio.FechaIngreso)
                    .Parameters.AddWithValue("fechaFin", req.PlantillaClienteServicio.FechaActualizacion)
                    .CommandText = "PreFactObtenerPesoVolumenVuelo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerPesoVolumenVuelo"))
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
    Public Shared Function PreFactObtenerCantVuelosAgencia(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("FechaInicio", req.PlantillaClienteServicio.FechaIngreso)
                    .Parameters.AddWithValue("fechaFin", req.PlantillaClienteServicio.FechaActualizacion)
                    .CommandText = "PreFactObtenerCantVuelosAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerCantVuelosAgencia"))
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
    Public Shared Function PreFactObtenerPesoVolumenGuia(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("FechaInicio", req.PlantillaClienteServicio.FechaIngreso)
                    .Parameters.AddWithValue("fechaFin", req.PlantillaClienteServicio.FechaActualizacion)
                    .CommandText = "PreFactObtenerPesoVolumenGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerPesoVolumenGuia"))
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
    Public Shared Function PreFactObtenerTiempoAlmaceContainer(req As PlantillaClienServRequest) As PlantillaClienServResponse
        Dim Result As New PlantillaClienServResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("FechaInicio", req.PlantillaClienteServicio.FechaIngreso)
                    .Parameters.AddWithValue("fechaFin", req.PlantillaClienteServicio.FechaActualizacion)
                    .CommandText = "PreFactObtenerTiempoAlmaceContainer"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerTiempoAlmaceContainer"))
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
    Public Shared Function GetSerConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Dim Result As New ServConsuClienteResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerSerConsuCliente"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerSerConsuCliente"))
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
    Public Shared Function GetVuelosCancelados(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Dim Result As New VuelosCanceladosResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerVuelosCancelados"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerVuelosCancelados"))
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
    Public Shared Function GetVuelosGuias(req As VuelosCanceladosRequest) As VuelosCanceladosResponse
        Dim Result As New VuelosCanceladosResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("TipoConsulta", req.codigoVuelo)
                    .Parameters.AddWithValue("idAgencia", req.id)
                    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    .CommandText = "Sp_ObtenerVuelosGuias"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerVuelosGuias"))
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
    Public Shared Function PreFactObtenerServConsuCliente(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Dim Result As New ServConsuClienteResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idCliente", req.ServConsuCliente.idCliente)
                    .Parameters.AddWithValue("idServiciosGA", req.ServConsuCliente.idServiciosGA)
                    .Parameters.AddWithValue("FechaInicio", req.ServConsuCliente.FechaInicio)
                    .Parameters.AddWithValue("FechaFin", req.ServConsuCliente.FechaFin)
                    .CommandText = "PreFactObtenerServConsuCliente"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerServConsuCliente"))
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
    Public Shared Function PreFactObtenerPesoVolumenPorBriefGuia(req As ServConsuClienteRequest) As ServConsuClienteResponse
        Dim Result As New ServConsuClienteResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idBriefing", req.ServConsuCliente.idBriefing)
                    .Parameters.AddWithValue("idGuia", req.ServConsuCliente.idGuia)
                    .CommandText = "PreFactObtenerPesoVolumenPorBriefGuia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("PreFactObtenerPesoVolumenPorBriefGuia"))
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
