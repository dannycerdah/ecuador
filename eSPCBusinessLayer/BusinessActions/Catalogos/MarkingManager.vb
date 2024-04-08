Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Public Class MarkingManager

    Public Shared Function GetAllInfoContacto(req As MarcacionContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerAllInfoContactoToMarcacion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.EnforceConstraints = False
                Result.DsResult.Tables.Add(New DataTable("AllInfoContacto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function

    Public Shared Function CheckNewBioRecords(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "USNBioRecords"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("USNBioRecords"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

    Public Shared Function GetSesionContactoById(req As SesionContactosRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("ContactoId", req.mySesionContactosItem.idContacto) 'simon
                    .Parameters.AddWithValue("TipoConsul", req.mySesionContactosItem.idZona) 'jro
                    .CommandText = "obtenerSesionByIdContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("SesionContacto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function

    Public Shared Function GetAllZonasAutorizadas(req As ZonasAutorizadasRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerAllZonasAutorizadas"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AllZonasAutorizadas"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetZonasAutorizadasByContacto(req As ZonasAutorizadasByContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim checkcontacto As New MySqlCommand 'simon
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("ContactoId", req.myZonasAutorizadasByContacto.idContacto) 'simon
                    .CommandText = "obtenerZonasAutorizadasByContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ZonasAutorizadasByContacto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            If checkcontacto.Connection IsNot Nothing Then 'simon
                checkcontacto.Connection.Close() 'simon
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
            If checkcontacto.Connection IsNot Nothing Then 'simon
                checkcontacto.Connection.Close() 'simon
            End If
        Finally
            If checkcontacto.Connection IsNot Nothing Then 'simon
                If checkcontacto.Connection.State = ConnectionState.Open Then checkcontacto.Connection.Close() 'simon
            End If
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function

    Public Shared Function SaveSesionContacto(req As SesionContactosRequest) As SesionContactosResponse
        Dim Result As New SesionContactosResponse
        Dim dbTran As Database
        Dim cmdagregarSesionContacto As New MySqlCommand
        Dim cmdagregarSesionContacto2 As New MySqlCommand
        Dim sesionContacto As Object()
        Try
            With req.mySesionContactosItem
                sesionContacto = New Object() {.idContacto, .idZona, .HoraIngreso, .Agencia}
            End With
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmdagregarSesionContacto
                .Parameters.AddWithValue("idContacto", sesionContacto(0))
                .Parameters.AddWithValue("NombreZona", sesionContacto(1))
                .Parameters.AddWithValue("FechaHoraIngreso", sesionContacto(2))
                .CommandText = "agregarSesionContacto"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmdagregarSesionContacto.ExecuteNonQuery()
                .Connection.Close()
            End With
            With cmdagregarSesionContacto2
                .Parameters.AddWithValue("IdContacto", sesionContacto(0))
                .Parameters.AddWithValue("Compania", sesionContacto(3))
                .Parameters.AddWithValue("FechaIngreso", sesionContacto(2))
                .CommandText = "SP_UpdateContactoFecha"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmdagregarSesionContacto2.ExecuteNonQuery()
                .Connection.Close()
            End With
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdagregarSesionContacto.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto.Connection.Close()
            If cmdagregarSesionContacto2.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto2.Connection.Close()
        Finally
            If cmdagregarSesionContacto.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto.Connection.Close()
            If cmdagregarSesionContacto2.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto2.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveHistoricoSesionContacto(req As HistoricoSesionContactosRequest) As HistoricoSesionContactosResponse
        Dim Result As New HistoricoSesionContactosResponse
        Dim dbTran As Database
        Dim cmdagregarSesionContacto As New MySqlCommand
        Dim cmdeliminarSesionContacto As New MySqlCommand
        Dim historicoSesionContacto As Object()
        Try
            With req.myHistoricoSesionContactosItem
                historicoSesionContacto = New Object() {.idContacto, .idZona, .HoraIngreso, .HoraSalida, .idBiometrico}
            End With
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmdeliminarSesionContacto
                .Parameters.AddWithValue("ContactoId", req.myHistoricoSesionContactosItem.idContacto)
                .CommandText = "eliminarSesionContacto"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmdeliminarSesionContacto.ExecuteNonQuery()
                .Connection.Close()
            End With
            With cmdagregarSesionContacto
                .Parameters.AddWithValue("idContacto", historicoSesionContacto(0))
                .Parameters.AddWithValue("NombreZona", historicoSesionContacto(1))
                .Parameters.AddWithValue("FechaHoraIngreso", historicoSesionContacto(2))
                .Parameters.AddWithValue("FechaHoraSalida", historicoSesionContacto(3))
                .Parameters.AddWithValue("idBiometrico", historicoSesionContacto(4)) 'MARZ
                .CommandText = "agregarHistoricoSesionContacto"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmdagregarSesionContacto.ExecuteNonQuery()
                .Connection.Close()
            End With
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdeliminarSesionContacto.Connection.State = ConnectionState.Open Then cmdeliminarSesionContacto.Connection.Close()
            If cmdagregarSesionContacto.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto.Connection.Close()
        Finally
            If cmdeliminarSesionContacto.Connection.State = ConnectionState.Open Then cmdeliminarSesionContacto.Connection.Close()
            If cmdagregarSesionContacto.Connection.State = ConnectionState.Open Then cmdagregarSesionContacto.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ - 28-07-2017
    Public Shared Function GetContactoZonasSession(req As ContactoZonasSessionRequest) As ContactoZonasSessionResponse
        Dim Result As New ContactoZonasSessionResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                If req.myContactoZonasSession.TipoReporte Then
                    With cmd
                        .Parameters.AddWithValue("IdAgencia", req.myContactoZonasSession.IdAgencia)
                        .Parameters.AddWithValue("IdContacto", req.myContactoZonasSession.IdContacto)
                        .Parameters.AddWithValue("FechaInicio", req.myContactoZonasSession.FechaInicio)
                        .Parameters.AddWithValue("FechaFinal", req.myContactoZonasSession.FechaFinal)
                        .CommandText = "obtenerSesionContactosFiltros"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                    End With
                Else
                    With cmd
                        .Parameters.AddWithValue("IdAgencia", req.myContactoZonasSession.IdAgencia)
                        .Parameters.AddWithValue("IdContacto", req.myContactoZonasSession.IdContacto)
                        .Parameters.AddWithValue("FechaInicio", req.myContactoZonasSession.FechaInicio)
                        .Parameters.AddWithValue("FechaFinal", req.myContactoZonasSession.FechaFinal)
                        .CommandText = "obtenerLogSesionContactosFiltros"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                    End With
                End If
                Result.DsResult = New DataSet
                If req.myContactoZonasSession.TipoReporte Then
                    Result.DsResult.Tables.Add(New DataTable("ZonaContactosSession"))
                Else
                    Result.DsResult.Tables.Add(New DataTable("LogZonaContactosSession"))
                End If
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

    'MARZ_31-08-17
    Public Shared Function SaveMarkingGeneral(req As MarkingGeneralRequest) As MarkingGeneralResponse
        Dim Result As New MarkingGeneralResponse
        Dim dbTran As Database
        Dim cmdExistMarking As New MySqlCommand
        Dim cmdDeleteMarking As New MySqlCommand
        Dim cmdRegisterMarking As New MySqlCommand
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            If req.myMarkingGeneral.flag = 0 Then
                With cmdExistMarking
                    .Parameters.AddWithValue("dato", req.myMarkingGeneral.contacto)
                    .CommandText = "checkExistMarkingContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmdExistMarking.ExecuteScalar) Then
                    With cmdDeleteMarking
                        .Parameters.AddWithValue("dato", req.myMarkingGeneral.contacto)
                        .CommandText = "deleteMarkingGeneral"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdDeleteMarking.ExecuteNonQuery()
                        .Connection.Close()
                    End With
                End If
                With cmdRegisterMarking
                    .Parameters.AddWithValue("dato", req.myMarkingGeneral.contacto)
                    .Parameters.AddWithValue("login", Date.Now)
                    .CommandText = "agregarMarkingGeneral"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmdRegisterMarking.ExecuteNonQuery()
                    .Connection.Close()
                End With
            Else
                With cmdRegisterMarking
                    .Parameters.AddWithValue("dato", req.myMarkingGeneral.contacto)
                    .Parameters.AddWithValue("logout", Date.Now)
                    .CommandText = "actualizarMarkingGeneral"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmdRegisterMarking.ExecuteNonQuery()
                    .Connection.Close()
                End With
            End If
            If cmdExistMarking.Connection IsNot Nothing Then
                If cmdExistMarking.Connection.State = ConnectionState.Open Then cmdExistMarking.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdExistMarking.Connection IsNot Nothing Then
                If cmdExistMarking.Connection.State = ConnectionState.Open Then cmdExistMarking.Connection.Close()
            End If
            If cmdDeleteMarking.Connection IsNot Nothing Then
                If cmdDeleteMarking.Connection.State = ConnectionState.Open Then cmdDeleteMarking.Connection.Close()
            End If
            If cmdRegisterMarking.Connection.State = ConnectionState.Open Then cmdRegisterMarking.Connection.Close()
        Finally
            If cmdExistMarking.Connection IsNot Nothing Then
                If cmdExistMarking.Connection.State = ConnectionState.Open Then cmdExistMarking.Connection.Close()
            End If
            If cmdDeleteMarking.Connection IsNot Nothing Then
                If cmdDeleteMarking.Connection.State = ConnectionState.Open Then cmdDeleteMarking.Connection.Close()
            End If
            If cmdRegisterMarking.Connection.State = ConnectionState.Open Then cmdRegisterMarking.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_02.09.17
    Public Shared Function GetMarkingsGeneralair(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd

                    Select Case req.PcId
                        Case 1
                            .Parameters.AddWithValue("contacto", req.codigoVuelo)
                            .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                            .Parameters.AddWithValue("fechaFin", req.fechaFin)
                            .CommandText = "obtenerMarcacionesGeneralByEmpleado"

                        Case 2
                            .Parameters.AddWithValue("descriptionCargo", req.codigoVuelo)
                            .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                            .Parameters.AddWithValue("fechaFin", req.fechaFin)
                            .CommandText = "obtenerMarcacionesGeneralByCargos"

                        Case Else
                            .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                            .Parameters.AddWithValue("fechaFin", req.fechaFin)
                            .CommandText = "obtenerMarcacionesGeneral"

                    End Select

                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("MarcacionesGeneralair"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_05-09-17
    Public Shared Function UpdateMarkingGeneralair(req As MarkingGeneralRequest) As MarkingGeneralResponse
        Dim Result As New MarkingGeneralResponse
        Dim dbTran As Database
        Dim cmdUpdateMarking As New MySqlCommand
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmdUpdateMarking
                .Parameters.AddWithValue("idMarking", req.myMarkingGeneral.id)
                .Parameters.AddWithValue("salida", req.myMarkingGeneral.salida)
                .Parameters.AddWithValue("mensaje", req.myMarkingGeneral.observation)
                .CommandText = "modificarMarkingGeneral"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmdUpdateMarking.ExecuteNonQuery()
                .Connection.Close()
            End With
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdUpdateMarking.Connection.State = ConnectionState.Open Then cmdUpdateMarking.Connection.Close()
        Finally
            If cmdUpdateMarking.Connection.State = ConnectionState.Open Then cmdUpdateMarking.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_07.09.17
    Public Shared Function GetContactoByAgenciaById(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("agencia", req.myContactoItem.idAgencia)
                    .Parameters.AddWithValue("contacto", req.myContactoItem.idContacto)
                    .CommandText = "checkContactoByAgenciaById"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ContactoGeneralair"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

    'MARZ_14.09.17
    Public Shared Function GetAllPermisosEspeciales(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                If req.codigoVuelo = "0" Then
                    With cmd
                        .CommandText = "obtenerAllPermisosEspeciales"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                    End With
                Else
                    With cmd
                        .CommandText = "obtenerAllPermisosEspecialesMarcaciones"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                    End With
                End If
                Result.DsResult = New DataSet
                Result.DsResult.EnforceConstraints = False
                Result.DsResult.Tables.Add(New DataTable("PermisosEspeciales"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

    'MARZ_14.09.17
    Public Shared Function SavePermisoEspecialItem(req As ContactoRequest) As PermisoContactoResponse
        Dim Result As New PermisoContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim PermisoEspecial As Object()
        Dim dataPermisosByContacto As Object()
        Dim cmdEliminarPermisos As New MySqlCommand
        Dim cmdPermisos As New MySqlCommand
        Try
            If ValidateSession(req) Then
                With req.myPermisoEspecial
                    PermisoEspecial = New Object() {.id, .description, .beginDate, .endDate, .beginTime, .endTime, .usuario, .fecha, .observation, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPermiso", req.myPermisoEspecial.id)
                    .CommandText = "checkExistsPermisoEspecial"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmdEliminarPermisos
                        .Parameters.AddWithValue("idPermiso", req.myPermisoEspecial.id)
                        .CommandText = "eliminarContactosByPermiso"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdEliminarPermisos.ExecuteNonQuery()
                    End With
                    If cmdEliminarPermisos.Connection IsNot Nothing Then
                        cmdEliminarPermisos.Connection.Close()
                    End If
                End If
                With cmd2
                    .Parameters.AddWithValue("idPermiso", PermisoEspecial(0))
                    .Parameters.AddWithValue("descripcion", PermisoEspecial(1))
                    .Parameters.AddWithValue("fechaInicio", PermisoEspecial(2))
                    .Parameters.AddWithValue("fechaFin", PermisoEspecial(3))
                    .Parameters.AddWithValue("tiempoInicio", PermisoEspecial(4))
                    .Parameters.AddWithValue("tiempoFin", PermisoEspecial(5))
                    .Parameters.AddWithValue("usuarioM", PermisoEspecial(6))
                    .Parameters.AddWithValue("fechaM", PermisoEspecial(7))
                    .Parameters.AddWithValue("observacion", PermisoEspecial(8))
                    .Parameters.AddWithValue("estadoP", PermisoEspecial(9))
                    .CommandText = "agregarOActualizarPermisoEspecial"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd2.ExecuteNonQuery()
                End With
                For Each r As PermisosContactoItem In req.myPermisoEspecial.permisosContacto
                    cmdPermisos = New MySqlCommand
                    With r
                        dataPermisosByContacto = New Object() {.contacto, .id}
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmdPermisos
                            .Parameters.AddWithValue("idContacto", dataPermisosByContacto(0))
                            .Parameters.AddWithValue("idPermiso", dataPermisosByContacto(1))
                            .CommandText = "agregarPermisoByContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmdPermisos.ExecuteNonQuery()
                        End With
                        If cmdPermisos.Connection IsNot Nothing Then
                            cmdPermisos.Connection.Close()
                        End If
                    End With
                Next
                cmdPermisos.Connection.Close()
                cmd2.Connection.Close()
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdEliminarPermisos.Connection IsNot Nothing Then
                If cmdEliminarPermisos.Connection.State = ConnectionState.Open Then cmdEliminarPermisos.Connection.Close()
            End If
            If cmdPermisos.Connection IsNot Nothing Then
                If cmdPermisos.Connection.State = ConnectionState.Open Then cmdPermisos.Connection.Close()
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmdEliminarPermisos.Connection IsNot Nothing Then
                If cmdEliminarPermisos.Connection.State = ConnectionState.Open Then cmdEliminarPermisos.Connection.Close()
            End If
            If cmdPermisos.Connection IsNot Nothing Then
                If cmdPermisos.Connection.State = ConnectionState.Open Then cmdPermisos.Connection.Close()
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_15.09.17
    Public Shared Function GetContactosByPermiso(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPermiso", req.myPermisoEspecial.id)
                    .CommandText = "obtenerContactosByPermiso"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ContactosByPermiso"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

    Public Shared Function GetPermisoEspecialById(req As ContactoRequest) As PermisoContactoResponse
        Dim Result As New PermisoContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPermisoEspecial As PermisoEspecialItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPermiso", req.myPermisoEspecial.id)
                    .CommandText = "obtenerPermisoEspecialById"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myPermisoEspecial = New PermisoEspecialItem
                    With myPermisoEspecial
                        .id = drReader.GetValue(drReader.GetOrdinal("id"))
                        .description = drReader.GetValue(drReader.GetOrdinal("description"))
                        .beginDate = drReader.GetValue(drReader.GetOrdinal("beginDate"))
                        .endDate = drReader.GetValue(drReader.GetOrdinal("endDate"))
                        .beginTime = drReader.GetValue(drReader.GetOrdinal("beginTime"))
                        .endTime = drReader.GetValue(drReader.GetOrdinal("endTime"))
                        .observation = drReader.GetValue(drReader.GetOrdinal("observation"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myPermisoEspecial = myPermisoEspecial
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

    Public Shared Function GetPermisosEspecialesByContacto(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("contacto", req.myPermisoEspecial.usuario)
                    .CommandText = "obtenerPermisosEspecialesByContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("MarcacionesGeneralair"))
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

    'MARZ_18.09.17
    Public Shared Function GetExistsContactoByContactoByTipoAgencia(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("contacto", req.myContactoItem.idContacto)
                    .CommandText = "checkContactoByTipoAgenciaById"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ContactoTipoAgencia"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function

    'MARZ_25.09.17
    Public Shared Function GetHorarioDayByEmpleado(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req.myContactoItem.idContacto)
                    .CommandText = "obtenerHorarioDayByEmpleado"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("HorarioEmpleado"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        Finally
            If cmd.Connection IsNot Nothing Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
        End Try
        Return Result
    End Function
    Public Shared Function GetUldEntradaToday(req As ContactoRequest) As MarkingResponse
        Dim Result As New MarkingResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "SP_ObetnerUldEntradaToday"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("UldEntrada"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function
    Public Shared Function MantHorarioAgenciaSeguridad(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Dim Result As New HorarioAgenciaSeguridadResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Datos As Object()
        Dim Exists As Integer
        Try
            If ValidateSession(req) Then
                With req.HorarioAgenciaSeguridad
                    Datos = New Object() { .idHorarioAgenciaSeguridad, .idBriefing, .idAgencia, .idContacto, .FechaInicio, .FechaFin, .Estado, .UsuarioIngreso}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idBriefing", Datos(1))
                    .Parameters.AddWithValue("idAgencia", Datos(2))
                    .Parameters.AddWithValue("idContacto", Datos(3))
                    .CommandText = "checkExistHorarioAgenciaSeguridad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Exists = cmd.ExecuteScalar
                If Exists > 0 And IsNothing(Datos(6)) Then
                    Result.ActionResult = False
                    Result.ErrorMessage = "Ya Existe un Horario para ese Contacto"
                Else
                    cmd.Connection.Close()
                    cmd = New MySqlCommand
                    With cmd
                        .Parameters.AddWithValue("idHorarioAgenciaSeguridad", Datos(0))
                        .Parameters.AddWithValue("idBriefing", Datos(1))
                        .Parameters.AddWithValue("idAgencia", Datos(2))
                        .Parameters.AddWithValue("idContacto", Datos(3))
                        .Parameters.AddWithValue("FechaInicio", Datos(4))
                        .Parameters.AddWithValue("FechaFin", Datos(5))
                        .Parameters.AddWithValue("Estado", Datos(6))
                        .Parameters.AddWithValue("UsuarioIngreso", Datos(7))
                        .CommandText = "Sp_MantHorarioAgenciaSeguridad"
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
    Public Shared Function GetHorAgenSeguridad(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Dim Result As New HorarioAgenciaSeguridadResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idBriefing", req.HorarioAgenciaSeguridad.idBriefing)
                    .Parameters.AddWithValue("idAgencia", req.HorarioAgenciaSeguridad.idAgencia)
                    .CommandText = "Sp_ObtenerHorAgenSeguridad"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Sp_ObtenerHorAgenSeguridad"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function
    Public Shared Function GetAgenciaExcluidaMarcacion(req As HorarioAgenciaSeguridadRequest) As HorarioAgenciaSeguridadResponse
        Dim Result As New HorarioAgenciaSeguridadResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "Sp_ObtenerAgenciaExcluidaMarcacion"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.dsResult = New DataSet
                Result.dsResult.Tables.Add(New DataTable("Sp_ObtenerAgenciaExcluidaMarcacion"))
                Result.dsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function
    Public Shared Function SaveAuditoriaReconocimientoFacial(req As AuditoriaReconocimientoFacialRequest) As AuditoriaReconocimientoFacialResponse
        Dim Result As New AuditoriaReconocimientoFacialResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand

        Dim sesionContacto As Object()
        Try

            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("id", req.myAuditoriaReconocimientoFacialItem.id)
                .Parameters.AddWithValue("PersistedFacesid", req.myAuditoriaReconocimientoFacialItem.PersistedFacesid)
                .Parameters.AddWithValue("imagen", req.myAuditoriaReconocimientoFacialItem.imagen)
                .Parameters.AddWithValue("fecha", req.myAuditoriaReconocimientoFacialItem.fecha)
                .Parameters.AddWithValue("tiporegistro", req.myAuditoriaReconocimientoFacialItem.tiporegistro)
                .Parameters.AddWithValue("Descripcion", req.myAuditoriaReconocimientoFacialItem.Descripcion)
                .CommandText = "AgregarAuditoriaReconocimientoFacial"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmd.ExecuteNonQuery()
            End With
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
