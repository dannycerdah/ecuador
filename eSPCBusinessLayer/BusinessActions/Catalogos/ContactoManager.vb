Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager
Imports eSPCBusinessLayer.ws.FaceDetectionService
Imports FaceDetectLibrary
Imports FaceDetectLibrary.Classes

Public Class ContactoManager

    Public Shared Function GetDestinatarioItemById(req As DestinatarioRequest) As DestinatarioResponse
        Dim Result As New DestinatarioResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myDestinatario As DestinatarioCatalog
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myDestinatarioItem.idDestinatario)
                    .CommandText = "obtenerDestinatariosPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myDestinatario = New DestinatarioCatalog
                    With myDestinatario
                        .idDestinatario = drReader.GetValue(drReader.GetOrdinal("idDestinatario"))
                        .idReporte = drReader.GetValue(drReader.GetOrdinal("idReporte"))
                        .mail = drReader.GetValue(drReader.GetOrdinal("mail"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                    End With
                    Result.myDestinatarioItem = myDestinatario
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

    Public Shared Function GetTipoDocCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerTipoDocumento"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("TipoDocumento"))
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

    Public Shared Function GetCargoCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerCargos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Cargos"))
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

    Shared Function GetTipoDocPorId(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", New String(req.prmArr(0)))
                    .CommandText = "obtenerTipoDocumentoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("tipoDocumento"))
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

    Public Shared Function GetEntireContactoCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerContactos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Contactos"))
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


    Public Shared Function GetEntireUsuarioCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerUsuarios"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Usuarios"))
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


    Public Shared Function GetEntireArchivoContacto(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerArchivoContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ArchivoContacto"))
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

    Public Shared Function GetArchivoContactoItemById(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myArchivo As ArchivoContactoCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idArchivo", req.myArchivoContactoItem.idArchivo)
                    .CommandText = "obtenerArchivoContactoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myArchivo = New ArchivoContactoCatalogItem
                    With myArchivo
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .idArchivo = drReader.GetValue(drReader.GetOrdinal("idArchivo"))
                        .descripcionArchivo = drReader.GetValue(drReader.GetOrdinal("descripcionArchivo"))
                        .extArchivo = drReader.GetValue(drReader.GetOrdinal("extArchivo"))
                        .binArchivo = drReader.GetValue(drReader.GetOrdinal("binArchivo"))
                    End With
                    Result.myArchivoContactoItem = myArchivo
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

    Public Shared Function GetArchivoContactoItemByIdContacto(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req.myArchivoContactoItem.idContacto)
                    .CommandText = "obtenerArchivoContactoPorIdContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ArchivosContacto"))
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
    'simon
    Public Shared Function GetRegBiometricoByIdContacto(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim checkcontacto As New MySqlCommand 'simon
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req.myContactoItem.idContacto) 'simon
                    .CommandText = "obtenerRegBiometricoPorIdContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("RegBiometrico"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            If checkcontacto.Connection IsNot Nothing Then 'simon
                checkcontacto.Connection.Close() 'simon
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If checkcontacto.Connection IsNot Nothing Then 'simon
                If checkcontacto.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        Finally
            If checkcontacto.Connection IsNot Nothing Then 'simon
                If checkcontacto.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
            If cmd.Connection IsNot Nothing Then 'simon
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'simon
            End If
        End Try
        Return Result
    End Function

    Public Shared Function GetAllRegBiometrico(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerAllRegBiometrico"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("AllRegBiometrico"))
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

    'simon
    Public Shared Function GetContactoItemById(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myContacto As ContactoCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myContactoItem.idContacto)
                    .CommandText = "ObtenerContactoPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myContacto = New ContactoCatalogItem
                    With myContacto
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .tipoDocumento = drReader.GetValue(drReader.GetOrdinal("tipoDocContacto"))
                        .primerNombre = drReader.GetValue(drReader.GetOrdinal("primerNombreContacto"))
                        .segundoNombre = drReader.GetValue(drReader.GetOrdinal("segundoNombreContacto"))
                        .primerApellido = drReader.GetValue(drReader.GetOrdinal("primerApellidoContacto"))
                        .segundoApellido = drReader.GetValue(drReader.GetOrdinal("segundoApellidoContacto"))
                        .idPais = drReader.GetValue(drReader.GetOrdinal("idPais"))
                        .idCiudad = drReader.GetValue(drReader.GetOrdinal("idCiudad"))
                        .telefono = drReader.GetValue(drReader.GetOrdinal("telefono"))
                        .correo = drReader.GetValue(drReader.GetOrdinal("correo"))
                        .direccion = drReader.GetValue(drReader.GetOrdinal("direccionContacto"))
                        .fechaNacimiento = drReader.GetValue(drReader.GetOrdinal("fechaNacimientoContacto"))
                        .tagsa = drReader.GetValue(drReader.GetOrdinal("tagsaContacto"))
                        .fechaCaducaTagsa = drReader.GetValue(drReader.GetOrdinal("fechaCaducaTagsa"))
                        .imagenPerfil = drReader.GetValue(drReader.GetOrdinal("imagenPerfil"))

                        'carga datos de  activides Cargo y agencia del contacto
                        Dim reqContactoAgencia As New ReportRequest
                        Dim resContactoAgencia As ReportResponse
                        Dim contAgenciaCatalogo As New ContactoAgenciaCatalogItem
                        reqContactoAgencia.prmArr = New String() {drReader.GetValue(drReader.GetOrdinal("idContacto"))}
                        resContactoAgencia = GetContactoAgenciaItemByIdContacto(reqContactoAgencia)
                        For Each dr As DataRow In resContactoAgencia.DsResult.Tables(0).Rows
                            contAgenciaCatalogo.idAgencia = dr.Item("idAgencia")
                            contAgenciaCatalogo.descripcionAgencia = dr.Item("descripcionAgencia")
                            contAgenciaCatalogo.idContacto = dr.Item("idContacto")
                            contAgenciaCatalogo.fechaInicio = dr.Item("fechaInicio")
                            contAgenciaCatalogo.fechaFin = dr.Item("fechaFin")
                            contAgenciaCatalogo.estado = dr.Item("estado")
                            contAgenciaCatalogo.comentario = dr.Item("comentario")
                            contAgenciaCatalogo.cargo = dr.Item("cargo")
                            contAgenciaCatalogo.indice = dr.Item("indice")
                            .AgenciaContacto.Add(contAgenciaCatalogo)
                        Next

                        'Obtengo las imagenes  de los 


                        'GetContactoImagenIdContacto

                        Dim reqContactoImagen As New ReportRequest
                        Dim resContactoImagen As ReportResponse
                        Dim contContactoImagenCatalogo As ContactoImagenCatalogoItem

                        reqContactoImagen.prmArr = New String() {drReader.GetValue(drReader.GetOrdinal("idContacto"))}
                        resContactoImagen = GetContactoImagenIdContacto(reqContactoImagen)
                        For Each dr As DataRow In resContactoImagen.DsResult.Tables(0).Rows
                            contContactoImagenCatalogo = New ContactoImagenCatalogoItem
                            contContactoImagenCatalogo.idImagen = dr.Item("idImagen")
                            contContactoImagenCatalogo.idContacto = dr.Item("idContacto")
                            contContactoImagenCatalogo.imagen = dr.Item("imagenFoto")
                            contContactoImagenCatalogo.estado = dr.Item("estado_registro")
                            contContactoImagenCatalogo.Usuario = dr.Item("usuaCreacion")

                            .imagenesPerfil.Add(contContactoImagenCatalogo)
                            contContactoImagenCatalogo = Nothing
                        Next
                    End With
                    Result.myContactoItem = myContacto
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

    Public Shared Function GetUsuarioItemById(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myUsuario As UsuarioItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idUsuario", req.myUsuarioItem.idUsuario)
                    .CommandText = "ObtenerUsuarioPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myUsuario = New UsuarioItem
                    With myUsuario
                        .idUsuario = drReader.GetValue(drReader.GetOrdinal("idUsuario"))
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .password = drReader.GetValue(drReader.GetOrdinal("password"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .admin = drReader.GetValue(drReader.GetOrdinal("admin"))
                        .idContactoCreacion = drReader.GetValue(drReader.GetOrdinal("idContactoCreacion"))
                        .fechaCreacion = drReader.GetValue(drReader.GetOrdinal("fechaCreacion"))
                        .fechaAct = drReader.GetValue(drReader.GetOrdinal("fechaAct"))
                    End With
                    Result.myUsuarioItem = myUsuario
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


    Public Shared Function GetContactoAgenciaItemById(req As ContactoAgenciaRequest) As ContactoAgenciaResponse
        Dim Result As New ContactoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myContactoAgencia As ContactoAgenciaCatalogItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idAgencia", req.myContactoAgenciaItem.idAgencia)
                    .Parameters.AddWithValue("idContacto", req.myContactoAgenciaItem.idContacto)
                    .Parameters.AddWithValue("fechaInicio", req.myContactoAgenciaItem.fechaInicio)
                    .Parameters.AddWithValue("estado", req.myContactoAgenciaItem.estado)
                    .CommandText = "ObtenerContactoAgenciaPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myContactoAgencia = New ContactoAgenciaCatalogItem
                    With myContactoAgencia
                        .idAgencia = drReader.GetValue(drReader.GetOrdinal("idAgencia"))
                        .descripcionAgencia = drReader.GetValue(drReader.GetOrdinal("descripcionAgencia"))
                        .idContacto = drReader.GetValue(drReader.GetOrdinal("idContacto"))
                        .primerNombre = drReader.GetValue(drReader.GetOrdinal("primerNombreContacto"))
                        .segundoNombre = drReader.GetValue(drReader.GetOrdinal("segundoNombreContacto"))
                        .primerApellido = drReader.GetValue(drReader.GetOrdinal("primerApellidoContacto"))
                        .segundoApellido = drReader.GetValue(drReader.GetOrdinal("segundoNombreContacto"))
                        .fechaInicio = drReader.GetValue(drReader.GetOrdinal("fechaInicio"))
                        .fechaFin = drReader.GetValue(drReader.GetOrdinal("fechaFin"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                        .comentario = drReader.GetValue(drReader.GetOrdinal("comentario"))
                        .cargo = drReader.GetValue(drReader.GetOrdinal("cargo"))
                        .indice = drReader.GetValue(drReader.GetOrdinal("indice"))
                    End With
                    Result.myContactoAgenciaItem = myContactoAgencia
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

    Public Shared Function GetContactoAgenciaItemByIdAgencia(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("IdAgencia", New String(req.prmArr(0)))
                    .CommandText = "ObtenerContactoAgenciaPorIdAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ContactoAgencia"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveDestinatarioItem(req As DestinatarioRequest) As DestinatarioResponse
        Dim Result As New DestinatarioResponse
        'Dim DsResult = New DataSet
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Destinatario As Object()
        Try
            If ValidateSession(req) Then
                With req.myDestinatarioItem
                    Destinatario = New Object() { .idDestinatario, .idReporte, .mail, .idAgencia, .estado, .idContacto}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idDestinatario", req.myDestinatarioItem.idDestinatario)
                    .CommandText = "CheckExistsDestinatario"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                'DsResult.Tables(0).Load(cmd.ExecuteScalar())
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idDestinatario", Destinatario(0))
                        .Parameters.AddWithValue("idReporte", Destinatario(1))
                        .Parameters.AddWithValue("mail", Destinatario(2))
                        .Parameters.AddWithValue("idAgencia", Destinatario(3))
                        .Parameters.AddWithValue("estado", Destinatario(4))
                        .Parameters.AddWithValue("idContacto", Destinatario(5))
                        .CommandText = "modificarDestinatario"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idDestinatario", Destinatario(0))
                        .Parameters.AddWithValue("idReporte", Destinatario(1))
                        .Parameters.AddWithValue("mail", Destinatario(2))
                        .Parameters.AddWithValue("idAgencia", Destinatario(3))
                        .Parameters.AddWithValue("estado", Destinatario(4))
                        .Parameters.AddWithValue("idContacto", Destinatario(5))
                        .CommandText = "agregarDestinatario"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function GetContactoAgenciaItemByIdContacto(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", New String(req.prmArr(0).ToString))
                    .CommandText = "ObtenerContactoAgenciaPorIdContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ContactoAgencias"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function GetPersonalAutorizadoCourierbyContacto(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", New String(req.prmArr(0).ToString))
                    .CommandText = "ObtenerPersonalAutorizadoCourierbyContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("PersonalAutorizadoIdcontacto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function


    Public Shared Function SaveArchivoContactoItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Archivo As Object()
        Try
            If ValidateSession(req) Then
                With req.myArchivoContactoItem
                    Archivo = New Object() { .idContacto, .idArchivo, .descripcionArchivo, .extArchivo, .binArchivo, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idArchivo", req.myArchivoContactoItem.idArchivo)
                    .CommandText = "CheckExistsArchivoContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idContacto", Archivo(0))
                        .Parameters.AddWithValue("idArchivo", Archivo(1))
                        .Parameters.AddWithValue("descripcion", Archivo(2))
                        .Parameters.AddWithValue("extArchivo", Archivo(3))
                        .Parameters.AddWithValue("binArchivo", Archivo(4))
                        .Parameters.AddWithValue("estado", Archivo(5))
                        .CommandText = "modificarArchivoContacto"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else
                    With cmd2
                        .Parameters.AddWithValue("idContacto", Archivo(0))
                        .Parameters.AddWithValue("idArchivo", Archivo(1))
                        .Parameters.AddWithValue("descripcion", Archivo(2))
                        .Parameters.AddWithValue("extArchivo", Archivo(3))
                        .Parameters.AddWithValue("binArchivo", Archivo(4))
                        .Parameters.AddWithValue("estado", Archivo(5))
                        .CommandText = "agregarArchivoContacto"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveContactoItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Contacto As Object()
        Dim cmdregbiomet As New MySqlCommand 'simon
        Dim cmdeliminarregbio As New MySqlCommand 'simon
        Dim parametrosBiometrico As Object() 'simon

        Dim cmdZonasAutorizadasContacto As New MySqlCommand 'simon 
        Dim cmdeliminarZonasAutorizadasContacto As New MySqlCommand 'simon 
        Dim parametrosZonasAutorizadasByContacto As Object() 'simon 
        Dim cmdAgenciaContacto As New MySqlCommand



        Dim CerrarConexion2 As Boolean = True
        Dim PermiteAct As Integer = 0
        Try
            If ValidateSession(req) Then
                With req.myContactoItem
                    Contacto = New Object() { .idContacto, .tipoDocumento, .primerNombre, .segundoNombre, .primerApellido, .segundoApellido,
                                             .idPais, .idCiudad, .telefono, .correo, .direccion, .fechaNacimiento, .tagsa, .fechaCaducaTagsa, .imagenPerfil, .IdContactoUser} 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myContactoItem.idContacto)
                    .CommandText = "CheckExistsContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    PermiteAct = PermiteActContacto(Contacto(15))
                    PermiteAct = 1
                    If PermiteAct = 0 Then 'jro
                        CerrarConexion2 = False
                    Else
                        'simon
                        'With cmdeliminarregbio
                        '    .Parameters.AddWithValue("idContacto", req.myContactoItem.idContacto)
                        '    .CommandText = "eliminarRegBiometrico"
                        '    .CommandType = CommandType.StoredProcedure
                        '    .Connection = dbTran.CreateConnection
                        '    .Connection.Open()
                        '    cmdeliminarregbio.ExecuteNonQuery()
                        'End With

                        With cmdeliminarZonasAutorizadasContacto
                            .Parameters.AddWithValue("ContactoId", req.myContactoItem.idContacto)
                            .CommandText = "eliminarZonasAutorizadasContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmdeliminarZonasAutorizadasContacto.ExecuteNonQuery()
                        End With
                        'simon
                        With cmd2
                            .Parameters.AddWithValue("Id", Contacto(0))
                            .Parameters.AddWithValue("tipoDocumento", Contacto(1))
                            .Parameters.AddWithValue("primerNombre", Contacto(2))
                            .Parameters.AddWithValue("segundoNombre", Contacto(3))
                            .Parameters.AddWithValue("primerApellido", Contacto(4))
                            .Parameters.AddWithValue("segundoApellido", Contacto(5))
                            .Parameters.AddWithValue("idPais", Contacto(6))
                            .Parameters.AddWithValue("idCiudad", Contacto(7))
                            .Parameters.AddWithValue("telefono", Contacto(8))
                            .Parameters.AddWithValue("correo", Contacto(9))
                            .Parameters.AddWithValue("direccion", Contacto(10))
                            .Parameters.AddWithValue("fechaNacimiento", Contacto(11))
                            .Parameters.AddWithValue("tagsaContacto", Contacto(12))
                            .Parameters.AddWithValue("fechaCaducaTagsa", Contacto(13))
                            .Parameters.AddWithValue("imagenPerfil", Contacto(14))
                            .Parameters.AddWithValue("UsuarioIngreso", Contacto(15)) 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                            .CommandText = "modificarContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                    End If
                    'simon
                    For Each rec As RegBiometricoCatalogItem In req.myContactoItem.BioRecords 'simon
                        cmdregbiomet = New MySqlCommand
                        With rec
                            parametrosBiometrico = New Object() { .idcod_Contacto, .idregistro_biometrico, .tag, .detalle, .calificacion, .tipo, .Estado, req.myContactoItem.IdContactoUser} 'simon
                            dbTran = MyDbFactory.CreateDatabase("TranDB")
                            With cmdregbiomet  'simon
                                .Parameters.AddWithValue("idcod_Contacto", parametrosBiometrico(0)) 'aqui se cae el sistema
                                .Parameters.AddWithValue("idregistro_biometrico", parametrosBiometrico(1))
                                .Parameters.AddWithValue("tag", parametrosBiometrico(2))
                                .Parameters.AddWithValue("detalle", parametrosBiometrico(3))
                                .Parameters.AddWithValue("calificacion", parametrosBiometrico(4))
                                .Parameters.AddWithValue("tipo", parametrosBiometrico(5))
                                .Parameters.AddWithValue("Estado", parametrosBiometrico(6)) 'jro
                                .Parameters.AddWithValue("UsuarioIngreso", parametrosBiometrico(7)) 'jro
                                .CommandText = "agregarRegBiometrico"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdregbiomet.ExecuteNonQuery()
                            End With
                            If cmdregbiomet.Connection IsNot Nothing Then
                                cmdregbiomet.Connection.Close() 'simon
                            End If
                        End With
                    Next
                    For Each rec As ZonasAutorizadasByContactoCatalogItem In req.myContactoItem.ZonasAutorizadasByContacto 'simon
                        cmdZonasAutorizadasContacto = New MySqlCommand
                        With rec
                            parametrosZonasAutorizadasByContacto = New Object() { .idZonaAutorizada_Contacto, .idContacto, .idZona, .DiaPermitido, .HorarioDesde, .HorarioHasta}

                            dbTran = MyDbFactory.CreateDatabase("TranDB")

                            With cmdZonasAutorizadasContacto  'simon
                                .Parameters.AddWithValue("idZonaAutorizada_Contacto", parametrosZonasAutorizadasByContacto(0)) 'aqui se cae el sistema
                                .Parameters.AddWithValue("idContacto", parametrosZonasAutorizadasByContacto(1))
                                .Parameters.AddWithValue("idZona", parametrosZonasAutorizadasByContacto(2))
                                .Parameters.AddWithValue("DiaPermitido", parametrosZonasAutorizadasByContacto(3))
                                .Parameters.AddWithValue("HorarioDesde", parametrosZonasAutorizadasByContacto(4))
                                .Parameters.AddWithValue("HorarioHasta", parametrosZonasAutorizadasByContacto(5))
                                .CommandText = "agregarZonasAutorizadasByContacto"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdZonasAutorizadasContacto.ExecuteNonQuery()
                            End With
                            If cmdZonasAutorizadasContacto.Connection IsNot Nothing Then
                                cmdZonasAutorizadasContacto.Connection.Close() 'simon
                            End If
                        End With
                    Next
                Else
                    With cmd2
                        .Parameters.AddWithValue("Id", Contacto(0))
                        .Parameters.AddWithValue("tipoDocumento", Contacto(1))
                        .Parameters.AddWithValue("primerNombre", Contacto(2))
                        .Parameters.AddWithValue("segundoNombre", Contacto(3))
                        .Parameters.AddWithValue("primerApellido", Contacto(4))
                        .Parameters.AddWithValue("segundoApellido", Contacto(5))
                        .Parameters.AddWithValue("idPais", Contacto(6))
                        .Parameters.AddWithValue("idCiudad", Contacto(7))
                        .Parameters.AddWithValue("telefono", Contacto(8))
                        .Parameters.AddWithValue("correo", Contacto(9))
                        .Parameters.AddWithValue("direccion", Contacto(10))
                        .Parameters.AddWithValue("fechaNacimiento", Contacto(11))
                        .Parameters.AddWithValue("tagsaContacto", Contacto(12))
                        .Parameters.AddWithValue("fechaCaducaTagsa", Contacto(13))
                        .Parameters.AddWithValue("imagenPerfil", Contacto(14))
                        .Parameters.AddWithValue("UsuarioIngreso", Contacto(15)) 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                        .CommandText = "agregarContacto"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    'simon


                    For Each rec As RegBiometricoCatalogItem In req.myContactoItem.BioRecords 'simon
                        cmdregbiomet = New MySqlCommand
                        With rec
                            parametrosBiometrico = New Object() { .idcod_Contacto, .idregistro_biometrico, .tag, .detalle, .calificacion, .tipo, .Estado, req.myContactoItem.IdContactoUser} 'simon
                            dbTran = MyDbFactory.CreateDatabase("TranDB")
                            With cmdregbiomet  'simon
                                .Parameters.AddWithValue("idcod_Contacto", parametrosBiometrico(0)) 'aqui se cae el sistema
                                .Parameters.AddWithValue("idregistro_biometrico", parametrosBiometrico(1))
                                .Parameters.AddWithValue("tag", parametrosBiometrico(2))
                                .Parameters.AddWithValue("detalle", parametrosBiometrico(3))
                                .Parameters.AddWithValue("calificacion", parametrosBiometrico(4))
                                .Parameters.AddWithValue("tipo", parametrosBiometrico(5))
                                .Parameters.AddWithValue("Estado", parametrosBiometrico(6)) 'jro
                                .Parameters.AddWithValue("UsuarioIngreso", parametrosBiometrico(7)) 'jro
                                .CommandText = "agregarRegBiometrico"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdregbiomet.ExecuteNonQuery()
                            End With
                            If cmdregbiomet.Connection IsNot Nothing Then
                                cmdregbiomet.Connection.Close() 'simon
                            End If
                        End With
                    Next



                    For Each rec As ZonasAutorizadasByContactoCatalogItem In req.myContactoItem.ZonasAutorizadasByContacto 'simon
                        cmdZonasAutorizadasContacto = New MySqlCommand
                        With rec
                            parametrosZonasAutorizadasByContacto = New Object() { .idZonaAutorizada_Contacto, .idContacto, .idZona, .DiaPermitido, .HorarioDesde, .HorarioHasta}

                            dbTran = MyDbFactory.CreateDatabase("TranDB")

                            With cmdZonasAutorizadasContacto  'simon
                                .Parameters.AddWithValue("idZonaAutorizada_Contacto", parametrosZonasAutorizadasByContacto(0)) 'aqui se cae el sistema
                                .Parameters.AddWithValue("idContacto", parametrosZonasAutorizadasByContacto(1))
                                .Parameters.AddWithValue("idZona", parametrosZonasAutorizadasByContacto(2))
                                .Parameters.AddWithValue("DiaPermitido", parametrosZonasAutorizadasByContacto(3))
                                .Parameters.AddWithValue("HorarioDesde", parametrosZonasAutorizadasByContacto(4))
                                .Parameters.AddWithValue("HorarioHasta", parametrosZonasAutorizadasByContacto(5))
                                .CommandText = "agregarZonasAutorizadasByContacto"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdZonasAutorizadasContacto.ExecuteNonQuery()
                            End With
                            If cmdZonasAutorizadasContacto.Connection IsNot Nothing Then
                                cmdZonasAutorizadasContacto.Connection.Close() 'simon
                            End If
                        End With
                    Next

                    For Each rec As ContactoAgenciaCatalogItem In req.myContactoItem.AgenciaContacto 'guille
                        cmdAgenciaContacto = New MySqlCommand
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmdAgenciaContacto  'guille
                            .Parameters.AddWithValue("idAgencia", rec.idAgencia) 'aqui se cae el sistema
                            .Parameters.AddWithValue("idContacto", rec.idContacto)
                            .Parameters.AddWithValue("fechaInicio", rec.fechaInicio)
                            .Parameters.AddWithValue("fechaFin", rec.fechaFin)
                            .Parameters.AddWithValue("estado", rec.estado)
                            .Parameters.AddWithValue("comentario", rec.comentario)
                            .Parameters.AddWithValue("cargo", rec.cargo)
                            .CommandText = "agregarContactoAgencia"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmdAgenciaContacto.ExecuteNonQuery()
                        End With
                        If cmdAgenciaContacto.Connection IsNot Nothing Then
                            cmdAgenciaContacto.Connection.Close() 'guille
                        End If
                    Next

                    'grabar  archivo en caso de existir
                    Result = SaveArchivoContactoItem(req)
                    If Result.ActionResult Then
                    Else
                        Throw New Exception(Result.ErrorMessage)
                    End If

                End If


                'IMAGENES  PARA PERFIL DE FIRMAS

                For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                    If Imagen.estado = ContactoImagenCatalogoItem.estadoImagen.Nuevo Then
                        cmd = New MySqlCommand
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmd
                            .Parameters.AddWithValue("idImagen", Imagen.idImagen)
                            .Parameters.AddWithValue("idContacto", Imagen.idContacto)
                            .Parameters.AddWithValue("imagenFoto", Imagen.imagen)
                            .Parameters.AddWithValue("usuaCreacion", Imagen.Usuario)
                            .CommandText = "agregarImagenContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd.ExecuteNonQuery()
                        End With
                        If cmd.Connection IsNot Nothing Then
                            cmd.Connection.Close()
                        End If
                    ElseIf Imagen.estado = ContactoImagenCatalogoItem.estadoImagen.Inactivo Then
                        cmd = New MySqlCommand
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmd
                            .Parameters.AddWithValue("_idImagen", Imagen.idImagen)
                            .Parameters.AddWithValue("Usuario", Imagen.Usuario)
                            .CommandText = "eliminarImagenContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd.ExecuteNonQuery()
                        End With
                        If cmd.Connection IsNot Nothing Then
                            cmd.Connection.Close()
                        End If
                    End If
                Next


                ''**********************************************************
                ''********************* DETECCION FACIAL *******************
                ''**********************************************************
                'Dim reqFD As New EPPersonRequest
                'Dim res As New EPPersonResponse
                'Dim wsClnt As New FaceDetectionMainSoapClient
                'Dim dtPerson As New DataTable
                'Dim dtFace As New DataTable
                'Dim objFace As New GeneralClassFace
                'Dim personID As String = ""
                'Try

                '    'busco   personas  registradas  

                '    reqFD.myPerson = New EPPerson
                '    reqFD.myPerson.docId = Contacto(0)
                '    res = wsClnt.GetFacePersonByDocId(reqFD)
                '    If res.DsResult.Tables.Count > 0 Then
                '        dtPerson = res.DsResult.Tables(0)
                '        If dtPerson.Rows.Count > 0 Then
                '            personID = dtPerson.Rows(0).Item("personid").ToString()
                '        End If

                '        dtFace = res.DsResult.Tables(1)
                '        'If dtFace.Rows.Count > 0 Then
                '        '    personID = dtFace.Rows(0).Item("personid").ToString()
                '        'End If


                '    End If
                '    'si no hay id es una persona nueva por lo tanto registro la persona y la cara
                '    If personID.Length < 10 Then
                '        Dim reqPerson As New FPersonRequest
                '        Dim resPerson As New FPersonResponse
                '        reqPerson.myParameter = GetParameter()
                '        reqPerson.myPerson.personName = Contacto(2) & " " & Contacto(3) & " " & Contacto(4) & " " & Contacto(5)
                '        reqPerson.myPerson.docId = Contacto(0)
                '        resPerson = objFace.RegistrarPersonaMS(reqPerson)
                '        If resPerson.ActionResult Then
                '            With reqFD.myPerson
                '                .personName = Contacto(2) & " " & Contacto(3) & " " & Contacto(4) & " " & Contacto(5)
                '                .docId = Contacto(0)
                '                .PersonImage = Contacto(14)
                '                .personNotes = "VOLCADO"
                '                .personGroupId = reqFD.myParameter.IdGrupo
                '                .personId = resPerson.myPerson.personId
                '                .Id = resPerson.myPerson.personId
                '                '.ImagenesFace = New List(Of PersonImagenesFace)
                '                'For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                '                '    .ImagenesFace.Add(New PersonImagenesFace With {.PersonidImage = Imagen.idImagen.ToString, .PersonImage = Imagen.imagen})
                '                'Next
                '            End With
                '            res = wsClnt.RegisterNewPerson(reqFD)
                '            If res.ActionResult Then
                '            End If
                '        End If

                '        'registrar caras
                '        reqPerson.myPerson.personId = resPerson.myPerson.personId
                '        reqPerson.myPerson.ImagenesFace = New List(Of FaceDetectLibrary.PersonImagenesFace)
                '        For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                '            reqPerson.myPerson.ImagenesFace.Add(New FaceDetectLibrary.PersonImagenesFace With {.PersonidImage = Imagen.idImagen.ToString, .PersonImage = Imagen.imagen})
                '        Next
                '        resPerson = objFace.RegistrarCara(reqPerson)

                '        If resPerson.ActionResult Then
                '            With reqFD.myPerson
                '                .personName = Contacto(2) & " " & Contacto(3) & " " & Contacto(4) & " " & Contacto(5)
                '                .docId = Contacto(0)
                '                .PersonImage = Contacto(14)
                '                .personNotes = "VOLCADO"
                '                .personGroupId = reqFD.myParameter.IdGrupo
                '                .personId = resPerson.myPerson.personId
                '                .Id = resPerson.myPerson.personId
                '                .ImagenesFace = New List(Of ws.FaceDetectionService.PersonImagenesFace)
                '                For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                '                    .ImagenesFace.Add(New ws.FaceDetectionService.PersonImagenesFace With {.PersonidImage = Imagen.idImagen.ToString, .PersonImage = Imagen.imagen})
                '                Next
                '            End With
                '            res = wsClnt.RegisterNewPerson(reqFD)
                '            If res.ActionResult Then
                '            End If
                '        End If

                '    Else
                '        ' solo se registra las caras  nuevas
                '        'dtFace

                '        Dim reqPerson As New FPersonRequest
                '        Dim resPerson As New FPersonResponse
                '        Dim flag As Boolean

                '        reqPerson.myParameter = GetParameter()
                '        reqPerson.myPerson.personName = Contacto(2) & " " & Contacto(3) & " " & Contacto(4) & " " & Contacto(5)
                '        reqPerson.myPerson.docId = Contacto(0)

                '        reqPerson.myPerson.personId = Guid.Parse(dtFace.Rows(0).Item("personID").ToString())
                '        reqPerson.myPerson.ImagenesFace = New List(Of FaceDetectLibrary.PersonImagenesFace)
                '        For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                '            flag = False
                '            For Each dr As DataRow In dtFace.Rows
                '                If Imagen.idImagen = dr.Item("idImagen") Then
                '                    flag = True
                '                    Exit For
                '                End If
                '            Next
                '            If Not flag Then
                '                reqPerson.myPerson.ImagenesFace.Add(New FaceDetectLibrary.PersonImagenesFace With {.PersonidImage = Imagen.idImagen.ToString, .PersonImage = Imagen.imagen})
                '            End If
                '        Next
                '        resPerson = objFace.RegistrarCara(reqPerson)

                '        If resPerson.ActionResult Then
                '            With reqFD.myPerson
                '                .personName = Contacto(2) & " " & Contacto(3) & " " & Contacto(4) & " " & Contacto(5)
                '                .docId = Contacto(0)
                '                .PersonImage = Contacto(14)
                '                .personNotes = "VOLCADO"
                '                .personGroupId = reqPerson.myParameter.IdGrupo
                '                .personId = resPerson.myPerson.personId
                '                .Id = resPerson.myPerson.personId
                '                .ImagenesFace = New List(Of ws.FaceDetectionService.PersonImagenesFace)
                '                For Each Imagen As ContactoImagenCatalogoItem In req.myContactoItem.imagenesPerfil 'guille
                '                    .ImagenesFace.Add(New ws.FaceDetectionService.PersonImagenesFace With {.PersonidImage = Imagen.idImagen.ToString, .PersonImage = Imagen.imagen})
                '                Next
                '            End With
                '            res = wsClnt.RegisterNewPerson(reqFD)
                '            If res.ActionResult Then
                '            End If
                '        End If

                '    End If


                '    'res = wsClnt.RegisterNewPerson(reqFD)
                '    'If res.ActionResult Then
                '    '    'MessageBox.Show("Contacto Registrado")
                '    'End If
                'Catch ex As Exception

                'End Try

                ''**********************************************************
                ''**********************************************************


                If CerrarConexion2 Then 'jro
                    cmd2.Connection.Close()
                End If


                If cmd.Connection IsNot Nothing Then
                    cmd.Connection.Close()
                End If

                If cmdeliminarregbio.Connection IsNot Nothing Then 'simon
                    cmdeliminarregbio.Connection.Close() 'simon
                End If
                If cmdregbiomet.Connection IsNot Nothing Then 'simon
                    cmdregbiomet.Connection.Close() 'simon
                End If
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdZonasAutorizadasContacto.Connection IsNot Nothing Then 'simon
                If cmdZonasAutorizadasContacto.Connection.State = ConnectionState.Open Then cmdZonasAutorizadasContacto.Connection.Close() 'simon
            End If
            If cmdeliminarZonasAutorizadasContacto.Connection IsNot Nothing Then 'simon
                If cmdeliminarZonasAutorizadasContacto.Connection.State = ConnectionState.Open Then cmdeliminarZonasAutorizadasContacto.Connection.Close() 'simon
            End If
            If cmdregbiomet.Connection IsNot Nothing Then 'simon
                If cmdregbiomet.Connection.State = ConnectionState.Open Then cmdregbiomet.Connection.Close() 'simon
            End If
            If cmdeliminarregbio.Connection IsNot Nothing Then 'simon
                If cmdeliminarregbio.Connection.State = ConnectionState.Open Then cmdeliminarregbio.Connection.Close() 'simon
            End If
            If CerrarConexion2 Then 'jro
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmdZonasAutorizadasContacto.Connection IsNot Nothing Then 'simon
                If cmdZonasAutorizadasContacto.Connection.State = ConnectionState.Open Then cmdZonasAutorizadasContacto.Connection.Close() 'simon
            End If
            If cmdeliminarZonasAutorizadasContacto.Connection IsNot Nothing Then 'simon
                If cmdeliminarZonasAutorizadasContacto.Connection.State = ConnectionState.Open Then cmdeliminarZonasAutorizadasContacto.Connection.Close() 'simon
            End If
            If cmdregbiomet.Connection IsNot Nothing Then 'simon
                If cmdregbiomet.Connection.State = ConnectionState.Open Then cmdregbiomet.Connection.Close() 'simon
            End If
            If cmdeliminarregbio.Connection IsNot Nothing Then 'simon
                If cmdeliminarregbio.Connection.State = ConnectionState.Open Then cmdeliminarregbio.Connection.Close() 'simon
            End If
            If CerrarConexion2 Then 'jro
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetParameter() As FParameter
        Dim wsClient As New FaceDetectionMainSoapClient
        Dim res As New EPParameterResponse
        Dim req As New EPParameterRequest
        Dim result As New FParameter

        Dim DtParametros As New DataTable("Parametros")
        Try
            res = wsClient.GetParameterFaceDetect(req)
            If res.ActionResult Then
                DtParametros = res.DsResult.Tables(0)
                Dim rows As DataRow()

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='SubscriptionKeyFace'")
                For Each r As DataRow In rows
                    result.SubscriptionKey = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='LocationApiFace'")
                For Each r As DataRow In rows
                    result.LocationApi = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='IdGroup'")
                For Each r As DataRow In rows
                    result.IdGrupo = r.Item(3)
                Next

                rows = DtParametros.Select("TipoParametro='FaceDetection' and  NombreParametro='TipGroup'")
                For Each r As DataRow In rows
                    result.TipGroup = r.Item(3)
                Next

            End If
            Return result
        Catch ex As Exception
            SetLogEvent(ex, result, req)
        End Try
    End Function



    Public Shared Function SaveUsuarioItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Usuario As Object()
        Dim cmdPerfiles As New MySqlCommand 'MARZ
        Dim dataPerfil As Object() 'MARZ
        Dim cmdEliminarPerfiles As New MySqlCommand 'MARZ
        Dim cmdUsuarioEmpr As New MySqlCommand

        Try
            If ValidateSession(req) Then
                With req.myUsuarioItem
                    Usuario = New Object() { .idUsuario, .idContacto, .password, .estado, .admin, .idContactoCreacion, .fechaCreacion, .fechaAct}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("Id", req.myUsuarioItem.idUsuario)
                    .CommandText = "CheckExistsUsuario"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idUsuario", Usuario(0))
                        .Parameters.AddWithValue("idContacto", Usuario(1))
                        .Parameters.AddWithValue("password", Usuario(2))
                        .Parameters.AddWithValue("estado", Usuario(3))
                        .Parameters.AddWithValue("admin", Usuario(4))
                        .Parameters.AddWithValue("idContactoCreacion", Usuario(5))
                        .Parameters.AddWithValue("fechaCreacion", Usuario(6))
                        .Parameters.AddWithValue("fechaAct", Usuario(7))
                        .CommandText = "modificarUsuario"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    With cmdEliminarPerfiles
                        .Parameters.AddWithValue("ID", req.myUsuarioItem.idContacto)
                        .CommandText = "eliminarPerfilesByContacto"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdEliminarPerfiles.ExecuteNonQuery()
                    End With
                    'MARZ_17-08-17
                    For Each r As PerfilesUsuarioItem In req.myUsuarioItem.perfilesUsuario
                        cmdPerfiles = New MySqlCommand
                        With r
                            dataPerfil = New Object() { .idPerfil, .idContacto}
                            dbTran = MyDbFactory.CreateDatabase("TranDB")
                            With cmdPerfiles
                                .Parameters.AddWithValue("idPerfil", dataPerfil(0))
                                .Parameters.AddWithValue("idContacto", dataPerfil(1))
                                .CommandText = "agregarPerfilContacto"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdPerfiles.ExecuteNonQuery()
                            End With
                            If cmdPerfiles.Connection IsNot Nothing Then
                                cmdPerfiles.Connection.Close()
                            End If
                        End With
                    Next
                    If cmdEliminarPerfiles.Connection IsNot Nothing Then
                        cmdEliminarPerfiles.Connection.Close()
                    End If



                    With cmdUsuarioEmpr
                        .Parameters.AddWithValue("idcontacto", req.myUsuarioItem.idContacto)
                        .CommandText = "eliminarusuarioempresa"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdUsuarioEmpr.ExecuteNonQuery()
                    End With

                    If cmdUsuarioEmpr.Connection IsNot Nothing Then
                        cmdUsuarioEmpr.Connection.Close()
                    End If

                    For Each usempr As UsuarioEmpresaItem In req.myUsuarioItem.usuarioEmpresa

                        cmdUsuarioEmpr = New MySqlCommand
                        With usempr
                            dbTran = MyDbFactory.CreateDatabase("TranDB")
                            With cmdUsuarioEmpr
                                .Parameters.AddWithValue("idcontacto", usempr.idcontacto)
                                .Parameters.AddWithValue("codigo_empresa", usempr.codigo_empresa)
                                .CommandText = "agregarusuarioempresa"
                                .CommandType = CommandType.StoredProcedure
                                .Connection = dbTran.CreateConnection
                                .Connection.Open()
                                cmdUsuarioEmpr.ExecuteNonQuery()
                            End With
                            If cmdUsuarioEmpr.Connection IsNot Nothing Then
                                cmdUsuarioEmpr.Connection.Close()
                            End If
                        End With
                    Next


                    'END MARZ
                Else
                    With cmd2
                        .Parameters.AddWithValue("idUsuario", Usuario(0))
                        .Parameters.AddWithValue("idContacto", Usuario(1))
                        .Parameters.AddWithValue("password", Usuario(2))
                        .Parameters.AddWithValue("estado", Usuario(3))
                        .Parameters.AddWithValue("admin", Usuario(4))
                        .Parameters.AddWithValue("idContactoCreacion", Usuario(5))
                        .Parameters.AddWithValue("fechaCreacion", Usuario(6))
                        .Parameters.AddWithValue("fechaAct", Usuario(7))
                        .CommandText = "agregarUsuario"
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
            If cmdEliminarPerfiles.Connection IsNot Nothing Then 'MARZ
                If cmdEliminarPerfiles.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmdPerfiles.Connection IsNot Nothing Then 'MARZ
                If cmdPerfiles.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'MARZ
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmdEliminarPerfiles.Connection IsNot Nothing Then 'MARZ
                If cmdEliminarPerfiles.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End If
            If cmdPerfiles.Connection IsNot Nothing Then 'MARZ
                If cmdPerfiles.Connection.State = ConnectionState.Open Then cmd.Connection.Close() 'MARZ
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveContactoAgenciaItem(req As ContactoAgenciaRequest) As ContactoAgenciaResponse
        Dim Result As New ContactoAgenciaResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim ContactoAgencia As Object()
        Dim CerrarConexion As Boolean = True
        Try
            If ValidateSession(req) Then
                With req.myContactoAgenciaItem
                    ContactoAgencia = New Object() { .idAgencia, .idContacto, .fechaInicio, .fechaFin, .estado, .comentario,
                                                    .cargo, .indice, .IdContactoUser}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("indice", req.myContactoAgenciaItem.indice)
                    .CommandText = "CheckExistsContactoAgencia"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    If PermiteActContacto(ContactoAgencia(8)) = 0 Then 'jro
                        Result.ActionResult = False
                        Result.ErrorMessage = "No tiene Permisos para Realizar Modificaciones en el detalle del Contacto"
                        CerrarConexion = False
                    Else
                        With cmd2
                            .Parameters.AddWithValue("idAgencia", ContactoAgencia(0))
                            .Parameters.AddWithValue("idContacto", ContactoAgencia(1))
                            .Parameters.AddWithValue("fechaInicio", ContactoAgencia(2))
                            .Parameters.AddWithValue("fechaFin", ContactoAgencia(3))
                            .Parameters.AddWithValue("estado", ContactoAgencia(4))
                            .Parameters.AddWithValue("comentario", ContactoAgencia(5))
                            .Parameters.AddWithValue("cargo", ContactoAgencia(6))
                            .Parameters.AddWithValue("indice", ContactoAgencia(7))
                            .CommandText = "modificarContactoAgencia"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                    End If
                Else
                    With cmd2
                        .Parameters.AddWithValue("idAgencia", ContactoAgencia(0))
                        .Parameters.AddWithValue("idContacto", ContactoAgencia(1))
                        .Parameters.AddWithValue("fechaInicio", ContactoAgencia(2))
                        .Parameters.AddWithValue("fechaFin", ContactoAgencia(3))
                        .Parameters.AddWithValue("estado", ContactoAgencia(4))
                        .Parameters.AddWithValue("comentario", ContactoAgencia(5))
                        .Parameters.AddWithValue("cargo", ContactoAgencia(6))
                        .CommandText = "agregarContactoAgencia"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                End If
                If CerrarConexion Then 'jro
                    cmd2.Connection.Close()
                End If

                cmd.Connection.Close()
            End If
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If CerrarConexion Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If CerrarConexion Then
                If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function SaveCargoContacto(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim Cargo As Object()
        Try
            If ValidateSession(req) Then
                With req.myCargoItem
                    Cargo = New Object() { .idCargo, .descripcionCargo}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idCargo", Cargo(0))
                    .Parameters.AddWithValue("descripcionCargo", Cargo(1))
                    .CommandText = "agregarCargo"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmd.ExecuteNonQuery()
                End With
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_15.08.17
    Public Shared Function GetProfileCatalog(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerPerfiles"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Perfiles"))
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

    'MARZ_16-08-17
    Public Shared Function GetPerfilItemById(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPerfil As PerfilItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPerfil", req.myPerfilItem.idPerfil)
                    .CommandText = "obtenerPerfilPorId"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myPerfil = New PerfilItem
                    With myPerfil
                        .idPerfil = drReader.GetValue(drReader.GetOrdinal("idPerfil"))
                        .nombrePerfil = drReader.GetValue(drReader.GetOrdinal("nombrePerfil"))
                        .comentarioPerfil = drReader.GetValue(drReader.GetOrdinal("comentarioPerfil"))
                        .estadoPerfil = drReader.GetValue(drReader.GetOrdinal("estadoPerfil"))
                        .padrePerfil = drReader.GetValue(drReader.GetOrdinal("padrePerfil"))
                    End With
                    Result.myPerfilItem = myPerfil
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

    Public Shared Function SavePerfilItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Perfil As Object()
        Dim dataPermisos As Object() 'MARZ
        Dim cmdEliminarPermisos As New MySqlCommand 'MARZ
        Dim cmdPermisos As New MySqlCommand 'MARZ
        Try
            If ValidateSession(req) Then
                With req.myPerfilItem
                    Perfil = New Object() { .idPerfil, .nombrePerfil, .comentarioPerfil, .estadoPerfil, .idUsuario, .fecha, .padrePerfil}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPerfil", req.myPerfilItem.idPerfil)
                    .CommandText = "checkExistsPerfil"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idPerfil", Perfil(0))
                        .Parameters.AddWithValue("nombrePerfil", Perfil(1))
                        .Parameters.AddWithValue("comentarioPerfil", Perfil(2))
                        .Parameters.AddWithValue("estadoPerfil", Perfil(3))
                        .Parameters.AddWithValue("idUsuario", Perfil(4))
                        .Parameters.AddWithValue("fecha", Perfil(5))
                        .Parameters.AddWithValue("padrePerfil", Perfil(6))
                        .CommandText = "modificarPerfil"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                    'Eliminar permisos
                    With cmdEliminarPermisos
                        .Parameters.AddWithValue("ID", req.myPerfilItem.idPerfil)
                        .CommandText = "eliminarPermisosByPerfil"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmdEliminarPermisos.ExecuteNonQuery()
                    End With
                    'Registrar permisos
                    For Each r As PermisosPerfilItem In req.myPerfilItem.permisosPerfil
                        cmdPermisos = New MySqlCommand
                        With r
                            dataPermisos = New Object() { .idPerfil, .idKey}
                            dbTran = MyDbFactory.CreateDatabase("TranDB")
                            With cmdPermisos
                                .Parameters.AddWithValue("idPerfil", dataPermisos(0))
                                .Parameters.AddWithValue("idKey", dataPermisos(1))
                                .CommandText = "agregarPermisoPerfil"
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
                    If cmdEliminarPermisos.Connection IsNot Nothing Then
                        cmdEliminarPermisos.Connection.Close()
                    End If
                Else 'Nuevo registro
                    With cmd2
                        .Parameters.AddWithValue("idPerfil", Perfil(0))
                        .Parameters.AddWithValue("nombrePerfil", Perfil(1))
                        .Parameters.AddWithValue("comentarioPerfil", Perfil(2))
                        .Parameters.AddWithValue("estadoPerfil", Perfil(3))
                        .Parameters.AddWithValue("idUsuario", Perfil(4))
                        .Parameters.AddWithValue("fecha", Perfil(5))
                        .Parameters.AddWithValue("padrePerfil", Perfil(6))
                        .CommandText = "agregarPerfil"
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
            If cmdEliminarPermisos.Connection IsNot Nothing Then 'MARZ
                If cmdEliminarPermisos.Connection.State = ConnectionState.Open Then cmdEliminarPermisos.Connection.Close()
            End If
            If cmdPermisos.Connection IsNot Nothing Then
                If cmdPermisos.Connection.State = ConnectionState.Open Then cmdPermisos.Connection.Close() 'MARZ
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmdEliminarPermisos.Connection IsNot Nothing Then 'MARZ
                If cmdEliminarPermisos.Connection.State = ConnectionState.Open Then cmdEliminarPermisos.Connection.Close()
            End If
            If cmdPermisos.Connection IsNot Nothing Then
                If cmdPermisos.Connection.State = ConnectionState.Open Then cmdPermisos.Connection.Close() 'MARZ
            End If
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ
    Public Shared Function GetPerfilesByContacto(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req.myPerfilesByContacto.idContacto)
                    .CommandText = "obtenerPerfilesByContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("PerfilesByContacto"))
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

    'MARZ_17.08.17
    Public Shared Function GetKeysItems(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerKeys"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Keys"))
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

    'MARZ_21.08.17
    Public Shared Function GetPermisosByPerfil(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idPerfil", req.myPermisosByPerfil.idPerfil)
                    .CommandText = "obtenerPermisosByPerfil"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("PermisosByPerfil"))
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

    'MARZ_30.08.17
    Public Shared Function GetTableTurnos(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerTurnos"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("Turnos"))
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



    'MARZ_01.09.17
    Public Shared Function GetEmpleadosGeneral(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .CommandText = "obtenerContactosGeneralair"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("EmpleadosGeneral"))
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


    Public Shared Function GetTurnoById(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myTurno As TurnoItem
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idHorario", req.myTurno.id)
                    .CommandText = "obtenerTurnoById"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    myTurno = New TurnoItem
                    With myTurno
                        .id = drReader.GetValue(drReader.GetOrdinal("id"))
                        .title = drReader.GetValue(drReader.GetOrdinal("title"))
                        .atraso = drReader.GetValue(drReader.GetOrdinal("atraso"))
                        .inicio = drReader.GetValue(drReader.GetOrdinal("inicio"))
                        .fin = drReader.GetValue(drReader.GetOrdinal("fin"))
                        .usuario = drReader.GetValue(drReader.GetOrdinal("usuario"))
                        .fecha = drReader.GetValue(drReader.GetOrdinal("fecha"))
                        .estado = drReader.GetValue(drReader.GetOrdinal("estado"))
                    End With
                    Result.myTurno = myTurno
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

    Public Shared Function SaveTurnoItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim cmd2 As New MySqlCommand
        Dim Horario As Object()
        Try
            If ValidateSession(req) Then
                With req.myTurno
                    Horario = New Object() { .id, .title, .atraso, .inicio, .fin, .usuario, .fecha, .estado}
                End With
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idHorario", req.myTurno.id)
                    .CommandText = "checkExistTurno"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                If CBool(cmd.ExecuteScalar) Then
                    With cmd2
                        .Parameters.AddWithValue("idHorario", Horario(0))
                        .Parameters.AddWithValue("title", Horario(1))
                        .Parameters.AddWithValue("atraso", Horario(2))
                        .Parameters.AddWithValue("inicio", Horario(3))
                        .Parameters.AddWithValue("fin", Horario(4))
                        .Parameters.AddWithValue("usuario", Horario(5))
                        .Parameters.AddWithValue("fecha", Horario(6))
                        .Parameters.AddWithValue("estado", Horario(7))
                        .CommandText = "modificarTurno"
                        .CommandType = CommandType.StoredProcedure
                        .Connection = dbTran.CreateConnection
                        .Connection.Open()
                        cmd2.ExecuteNonQuery()
                    End With
                Else 'Nuevo registro
                    With cmd2
                        .Parameters.AddWithValue("idHorario", Horario(0))
                        .Parameters.AddWithValue("title", Horario(1))
                        .Parameters.AddWithValue("atraso", Horario(2))
                        .Parameters.AddWithValue("inicio", Horario(3))
                        .Parameters.AddWithValue("fin", Horario(4))
                        .Parameters.AddWithValue("usuario", Horario(5))
                        .Parameters.AddWithValue("fecha", Horario(6))
                        .Parameters.AddWithValue("estado", Horario(7))
                        .CommandText = "agregarTurno"
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
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_06.09.17
    Public Shared Function SaveDaysTurnosContactoItem(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd2 As New MySqlCommand
        Dim dataTurno As Object()
        Try
            If ValidateSession(req) Then
                For Each r As DaysTurnosContactoItem In req.myTurno.daysTurnoContacto
                    cmd2 = New MySqlCommand
                    With r
                        dataTurno = New Object() { .day, .horario, .contacto, .fechaInicio, .fechaFin}
                        dbTran = MyDbFactory.CreateDatabase("TranDB")
                        With cmd2
                            .Parameters.AddWithValue("diaTurno", dataTurno(0))
                            .Parameters.AddWithValue("idHorario", dataTurno(1))
                            .Parameters.AddWithValue("idContacto", dataTurno(2))
                            .Parameters.AddWithValue("fechaInicio", dataTurno(3))
                            .Parameters.AddWithValue("fechaFin", dataTurno(4))
                            .CommandText = "agregarTurnosContacto"
                            .CommandType = CommandType.StoredProcedure
                            .Connection = dbTran.CreateConnection
                            .Connection.Open()
                            cmd2.ExecuteNonQuery()
                        End With
                        If cmd2.Connection IsNot Nothing Then
                            cmd2.Connection.Close()
                        End If
                    End With
                Next
            End If
            cmd2.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        End Try
        Return Result
    End Function

    'MARZ_07.09.17
    Public Shared Function GetTurnosEmpleado(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    'If req.PcId = "1" Then
                    '    .Parameters.AddWithValue("contacto", req.codigoVuelo)
                    '    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    '    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    '    .CommandText = "obtenerTurnosByEmpleado"
                    'Else
                    '    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    '    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    '    .CommandText = "obtenerTurnosEmpleados"
                    'End If
                    .Parameters.AddWithValue("contacto", req.codigoVuelo)
                    .Parameters.AddWithValue("fechaInicio", req.fechaIni)
                    .Parameters.AddWithValue("fechaFin", req.fechaFin)
                    .Parameters.AddWithValue("TipoConsulta", req.PcId)
                    .Parameters.AddWithValue("idTurno", req.id)
                    .CommandText = "obtenerTurnosTotalesEmpleados"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("TurnosPersonal"))
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

    'MARZ_08.09.17
    Public Shared Function DeleteTurnoEmpleado(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmdEliminar As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmdEliminar
                    .Parameters.AddWithValue("iden", CInt(req.codigoVuelo))
                    .CommandText = "eliminarTurnoEmpleadoById"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                    cmdEliminar.ExecuteNonQuery()
                End With
            End If
            cmdEliminar.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmdEliminar.Connection.State = ConnectionState.Open Then cmdEliminar.Connection.Close()

        Finally
            If cmdEliminar.Connection.State = ConnectionState.Open Then cmdEliminar.Connection.Close()
        End Try
        Return Result
    End Function
    Public Shared Function PermiteActContacto(req As String) As Integer
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPerfil As PerfilItem
        Dim Result As Integer
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req)
                    .CommandText = "Sp_PermiteActContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                drReader = cmd.ExecuteReader()
                If drReader.Read Then
                    Result = drReader.GetValue(drReader.GetOrdinal("Perfil"))
                End If
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


    Public Shared Function GetFichaPersonal(req As ContactoRequest) As ReportResponse

        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim myPerfil As PerfilItem
        Dim Result As New ReportResponse
        Try
            If ValidateSession(req) Then

                'obtener datos contactos

                Dim DsResult As DataSet
                DsResult = New DataSet

                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd

                    .Parameters.AddWithValue("IdContacto", req.myContactoItem.idContacto)
                    .Parameters.AddWithValue("feInicio", req.fechaIni)
                    .Parameters.AddWithValue("feFinal", req.fechaFin)

                    .CommandText = "obtenerdetalleprocesoporidcontacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With

                DsResult.Tables.Add(New DataTable("ProcesoDeta"))
                DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
                Result.DsResult = New DataSet
                Result.DsResult = DsResult

            End If
        Catch ex As Exception
            SetLogEvent(ex, Result, req)

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try

        Return Result



    End Function



    Public Shared Function SaveImagenContacto(req As ContactoRequest) As ContactoResponse
        Dim Result As New ContactoResponse
        Dim dbTran As Database
        Dim cmd2 As New MySqlCommand
        Dim dataTurno As Object()
        Try
            If ValidateSession(req) Then
                'For Each r As DaysTurnosContactoItem In req.myTurno.daysTurnoContacto
                '    cmd2 = New MySqlCommand
                '    With r
                '        dataTurno = New Object() {.day, .horario, .contacto, .fechaInicio, .fechaFin}
                '        dbTran = MyDbFactory.CreateDatabase("TranDB")
                '        With cmd2
                '            .Parameters.AddWithValue("diaTurno", dataTurno(0))
                '            .Parameters.AddWithValue("idHorario", dataTurno(1))
                '            .Parameters.AddWithValue("idContacto", dataTurno(2))
                '            .Parameters.AddWithValue("fechaInicio", dataTurno(3))
                '            .Parameters.AddWithValue("fechaFin", dataTurno(4))
                '            .CommandText = "agregarTurnosContacto"
                '            .CommandType = CommandType.StoredProcedure
                '            .Connection = dbTran.CreateConnection
                '            .Connection.Open()
                '            cmd2.ExecuteNonQuery()
                '        End With
                '        If cmd2.Connection IsNot Nothing Then
                '            cmd2.Connection.Close()
                '        End If
                '    End With
                'Next
            End If
            cmd2.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        Finally
            If cmd2.Connection.State = ConnectionState.Open Then cmd2.Connection.Close()
        End Try
        Return Result
    End Function


    Public Shared Function GetContactoImagenIdContacto(req As ReportRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim param As New MySqlParameter
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", New String(req.prmArr(0).ToString))
                    .CommandText = "obtenerImagenContacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("ImagenContacto"))
                Result.DsResult.Tables(0).Load(cmd.ExecuteReader())
                cmd.Connection.Close()
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            Result.ActionResult = False
            SetLogEvent(ex, Result, req)
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
        Return Result
    End Function

    Public Shared Function GetUsuarioEmpresa(req As ContactoRequest) As ReportResponse
        Dim Result As New ReportResponse
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            If ValidateSession(req) Then
                dbTran = MyDbFactory.CreateDatabase("TranDB")
                With cmd
                    .Parameters.AddWithValue("idContacto", req.myUsuarioItem.idContacto)
                    .CommandText = "obtenerusuarioempresabyidcontacto"
                    .CommandType = CommandType.StoredProcedure
                    .Connection = dbTran.CreateConnection
                    .Connection.Open()
                End With
                Result.DsResult = New DataSet
                Result.DsResult.Tables.Add(New DataTable("UsuarioEmpresa"))
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




End Class