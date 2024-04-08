Imports MySql.Data.MySqlClient
Imports eSPCBusinessLayer.SecurityManager
Imports eSPCBusinessLayer.ErrorManager


Public Class AutorizacionOnline
    Public Property idAutorizacion As Guid
    Public Property UsuarioSolicitante As String
    Public Property FechaHoraSolicitud As DateTime
    Public Property UsuarioAprobacion As String
    Public Property FechaHoraAprobacion As DateTime
    Public Property EstadoAutorizacion As EstadoAprobacion
    Public Property CatalogoContactoItem As ContactoCatalogItem
    Public Property EtiquetaWebGeneric As New List(Of String)


    Public Enum EstadoAprobacion As Integer
        Pendiente = 0
        Aprobado = 1
        Descartado = 2
        Expirado = 3
    End Enum

    Public Sub New()

    End Sub


    Public Sub SaveAutorizacionOnline()
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim lwsasunto As String
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("IdAutorizacion", idAutorizacion)
                .Parameters.AddWithValue("UsuarioSolicitante", UsuarioSolicitante)
                .Parameters.AddWithValue("FechaHoraSolicitud", FechaHoraSolicitud)
                .Parameters.AddWithValue("UsuarioAprobacion", UsuarioAprobacion)
                .Parameters.AddWithValue("FechaHoraAprobacion", FechaHoraAprobacion)
                .CommandText = "agregarAutorizacionOnline"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
                cmd.ExecuteNonQuery()
            End With
            cmd.Connection.Close()

            'Obtengo el nombre del usuario
            Dim user As New User
            user.idUsuario = UsuarioSolicitante
            user.GetInfoUserbyId()


            Dim reqUser As New ContactoRequest
            ''Dim RespUser As New ContactoResponse
            Dim RespUser As New ContactoResponse()
            Dim ItemContat As New ContactoCatalogItem

            ItemContat.idContacto = user.idContacto
            reqUser.myContactoItem = ItemContat
            RespUser = ContactoManager.GetContactoItemById(reqUser)


            'Obtengo las plantillas  de  correo
            Dim strCuerpoMensaje = String.Empty
            strCuerpoMensaje = SecurityManager.GetParameterTextValue("htmlEmailAutorizacionOnline")
            'strCuerpoMensaje = strCuerpoMensaje.Replace("|", "'")
            'strCuerpoMensaje = strCuerpoMensaje.Replace("|", "'")
            strCuerpoMensaje = strCuerpoMensaje.Replace("=IdAutoriza", "=" & Me.idAutorizacion.ToString)
            strCuerpoMensaje = strCuerpoMensaje.Replace("NOMBREUSUARIO", RespUser.myContactoItem.primerApellido + " " + RespUser.myContactoItem.segundoApellido + " " + RespUser.myContactoItem.primerNombre + " " + RespUser.myContactoItem.segundoNombre)

            'datos del contacto actuales de la Base de Datos 

            'Dim Contactos As New ContactoRequest

            Dim req As New ContactoRequest
            Dim contactResp As New ContactoResponse()
            req.myContactoItem = CatalogoContactoItem
            'req.myContactoItem = ObjetoGeneric

            contactResp = ContactoManager.GetContactoItemById(req)

            Dim strDatosAct As String = String.Empty
            Dim strDatosProp As String = String.Empty




            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosProp = strDatosProp & "<div><label>Compañia :</label><label>" & contactResp.myContactoItem.AgenciaContacto(0).descripcionAgencia & "</label></div>"
                strDatosAct = strDatosAct & "<div><label>Compañia :</label><label>" & contactResp.myContactoItem.AgenciaContacto(0).descripcionAgencia & "</label></div>"

                For Each ItemAgenciaContacto In contactResp.myContactoItem.AgenciaContacto
                    If ItemAgenciaContacto.estado = "A" Then
                        strDatosAct = String.Empty
                        strDatosProp = String.Empty
                        strDatosProp = strDatosProp & "<div><label>Compañia :</label><label>" & ItemAgenciaContacto.descripcionAgencia & "</label></div>"
                        strDatosAct = strDatosAct & "<div><label>Compañia :</label><label>" & ItemAgenciaContacto.descripcionAgencia & "</label></div>"
                        Exit For
                    End If
                Next

                lwsasunto = "Solicitud de Cambios en Ficha de Contactos [Modificación]"
            Else
                lwsasunto = "Solicitud de Cambios en Ficha de Contactos [Nuevo]"
                strDatosProp = strDatosProp & "<div><label>Compañia :</label><label>" & CatalogoContactoItem.AgenciaContacto(0).descripcionAgencia & "</label></div>"
            End If


            strDatosProp = strDatosProp & "<div><label>Identificación :</label><label>" & CatalogoContactoItem.idContacto & "</label></div>"
            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosAct = strDatosAct & "<div><label>Identificación :</label><label>" & contactResp.myContactoItem.idContacto & "</label></div>"
            End If

            'strDatosProp = strDatosProp & "'<div><label>Tipo de Identicación :</label><label>" & CatalogoContactoItem.tipoDocumento & "</label></div>"
            'strDatosAct = strDatosAct & "'<div><label>Identificación :</label><label>" & contactResp.myContactoItem.tipoDocumento & "</label></div>"

            strDatosProp = strDatosProp & "<div><label>Primer Nombre :</label><label>" & CatalogoContactoItem.primerNombre & "</label></div>"
            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosAct = strDatosAct & "<div><label>Primer Nombre :</label><label>" & contactResp.myContactoItem.primerNombre & "</label></div>"
            End If
            strDatosProp = strDatosProp & "<div><label>Segundo Nombre :</label><label>" & CatalogoContactoItem.segundoNombre & "</label></div>"
            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosAct = strDatosAct & "<div><label>Segundo Nombre :</label><label>" & contactResp.myContactoItem.segundoNombre & "</label></div>"
            End If

            strDatosProp = strDatosProp & "<div><label>Primer Apellido :</label><label>" & CatalogoContactoItem.primerApellido & "</label></div>"
            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosAct = strDatosAct & "<div><label>Primer Apellido :</label><label>" & contactResp.myContactoItem.primerApellido & "</label></div>"
            End If
            strDatosProp = strDatosProp & "<div><label>Segundo Apellido :</label><label>" & CatalogoContactoItem.segundoApellido & "</label></div>"
            If Not (contactResp.myContactoItem Is Nothing) Then
                strDatosAct = strDatosAct & "<div><label>Segundo Apellido :</label><label>" & contactResp.myContactoItem.segundoApellido & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If CatalogoContactoItem.telefono <> contactResp.myContactoItem.telefono Then
                    strDatosProp = strDatosProp & "<div><label>Teléfono :</label><label style='color:#F2F5A9'>" & CatalogoContactoItem.telefono & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>Teléfono :</label><label>" & contactResp.myContactoItem.telefono & "</label></div>"
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>Teléfono :</label><label>" & CatalogoContactoItem.telefono & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If contactResp.myContactoItem.correo <> CatalogoContactoItem.correo Then
                    strDatosProp = strDatosProp & "<div><label>Correo :</label><label style='color:#F2F5A9'>" & CatalogoContactoItem.correo & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>Correo :</label><label>" & contactResp.myContactoItem.correo & "</label></div>"
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>Correo :</label><label>" & CatalogoContactoItem.correo & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If contactResp.myContactoItem.direccion <> CatalogoContactoItem.direccion Then
                    strDatosProp = strDatosProp & "<div><label>Dirección :</label><label style='color:#F2F5A9' >" & CatalogoContactoItem.direccion & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>Dirección :</label><label>" & contactResp.myContactoItem.direccion & "</label></div>"
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>Dirección :</label><label>" & CatalogoContactoItem.direccion & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If contactResp.myContactoItem.fechaNacimiento <> CatalogoContactoItem.fechaNacimiento Then
                    strDatosProp = strDatosProp & "<div><label>F.Nacimiento :</label><label style='color:#F2F5A9'>" & CatalogoContactoItem.fechaNacimiento.ToShortDateString & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>F.Nacimiento :</label><label>" & contactResp.myContactoItem.fechaNacimiento.ToShortDateString & "</label></div>"
                    'FechaInicio.ToString("dd/MM/yyyy HH:mm:ss")
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>F.Nacimiento :</label><label>" & CatalogoContactoItem.fechaNacimiento.ToShortDateString & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If contactResp.myContactoItem.tagsa <> CatalogoContactoItem.tagsa Then
                    strDatosProp = strDatosProp & "<div><label>TAGSA :</label><label style='color:#F2F5A9'>" & CatalogoContactoItem.tagsa & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>TAGSA :</label><label>" & contactResp.myContactoItem.tagsa & "</label></div>"
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>TAGSA :</label><label>" & CatalogoContactoItem.tagsa & "</label></div>"
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then

                If CatalogoContactoItem.tagsa.Trim() <> "" And CatalogoContactoItem.tagsa.Trim() <> "NO TIENE" Then
                    If contactResp.myContactoItem.fechaCaducaTagsa <> CatalogoContactoItem.fechaCaducaTagsa.ToShortDateString Then
                        strDatosProp = strDatosProp & "<div><label>F.Caducidad TAGSA :</label><label style='color:#F2F5A9' >" & CatalogoContactoItem.fechaCaducaTagsa.ToShortDateString & "</label></div>"
                        strDatosAct = strDatosAct & "<div><label>F.Caducidad TAGSA :</label><label>" & contactResp.myContactoItem.fechaCaducaTagsa.ToShortDateString & "</label></div>"
                    End If
                End If
            Else
                If CatalogoContactoItem.tagsa.Trim() <> "" And CatalogoContactoItem.tagsa.Trim() <> "NO TIENE" Then
                    strDatosProp = strDatosProp & "<div><label>F.Caducidad TAGSA :</label><label>" & CatalogoContactoItem.fechaCaducaTagsa.ToShortDateString & "</label></div>"
                End If
            End If


            Dim ciudad As New CiudadRequest
            Dim ciudadres As New CiudadResponse
            Dim sciudad As String = ""
            Dim sciudadAnte As String = ""
            Dim sPais As String = ""
            Dim sPaisAnte As String = ""
            Dim CiudadManag As New CiudadManager

            ciudad.myCiudadCatItem = New CiudadCatalogItem
            ciudad.myCiudadCatItem.Id = CatalogoContactoItem.idCiudad
            ciudadres = CiudadManager.GetCiudadItemById(ciudad)
            sciudad = ciudadres.myCiudadCatItem.NombreCiudad
            sPais = ciudadres.myCiudadCatItem.NombrePais

            If Not (contactResp.myContactoItem Is Nothing) Then
                ciudadres = Nothing
                ciudadres = New CiudadResponse
                ciudad.myCiudadCatItem = New CiudadCatalogItem
                ciudad.myCiudadCatItem.Id = contactResp.myContactoItem.idCiudad
                ciudadres = CiudadManager.GetCiudadItemById(ciudad)
                sciudadAnte = ciudadres.myCiudadCatItem.NombreCiudad
                sPaisAnte = ciudadres.myCiudadCatItem.NombrePais
            End If

            If Not (contactResp.myContactoItem Is Nothing) Then
                If contactResp.myContactoItem.idCiudad <> CatalogoContactoItem.idCiudad Then
                    strDatosProp = strDatosProp & "<div><label>País :</label><label style='color:#F2F5A9' >" & sPais & "</label></div>"
                    strDatosProp = strDatosProp & "<div><label>Ciudad :</label><label style='color:#F2F5A9'>" & sciudad & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>País :</label><label>" & sPaisAnte & "</label></div>"
                    strDatosAct = strDatosAct & "<div><label>Ciudad :</label><label>" & sciudadAnte & "</label></div>"
                End If
            Else
                strDatosProp = strDatosProp & "<div><label>País :</label><label>" & sPais & "</label></div>"
                strDatosProp = strDatosProp & "<div><label>Ciudad :</label><label>" & sciudad & "</label></div>"
            End If


            For Each objetiqueta In EtiquetaWebGeneric
                strDatosProp = strDatosProp & "<div><label style='color:#F2F5A9' > " & objetiqueta.ToString() & " </label></div>"
            Next

            strCuerpoMensaje = strCuerpoMensaje.Replace("ObjetoAnterior", strDatosAct)
            strCuerpoMensaje = strCuerpoMensaje.Replace("ObjetoPropuesto", strDatosProp)




            ''busqueda de usuarios  y envio de correos

            'ErrorManager.SendCorreo(strCuerpoMensaje.Replace("IdUsuario", "desarrollo@generalairsa.com"), "desarrollo@generalairsa.com", lwsasunto)


            ''busqueda de usuarios  y envio de correos
            cmd = New MySqlCommand
            With cmd
                .Parameters.AddWithValue("Id", 9)
                .CommandText = "obtenerDestinatariosPorIdReporte"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            Dim drReader As MySqlDataReader
            drReader = cmd.ExecuteReader
            While drReader.Read
                ErrorManager.SendCorreo(strCuerpoMensaje.Replace("IdUsuario", drReader.GetValue(drReader.GetOrdinal("mail")).ToString), drReader.GetValue(drReader.GetOrdinal("mail")).ToString, lwsasunto)
            End While
            drReader.Close()
            cmd.Connection.Close()

        Catch ex As Exception
            Throw ex
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
    End Sub

    Public Sub New(idAutorizacion As Guid)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("Id", idAutorizacion)
                .CommandText = "ObtenerAutorizacionOnline"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader
            If drReader.Read Then
                Me.idAutorizacion = idAutorizacion
                Me.UsuarioSolicitante = drReader.GetValue(drReader.GetOrdinal("UsuarioSolicitante"))
                Me.FechaHoraSolicitud = drReader.GetValue(drReader.GetOrdinal("FechaHoraSolicitud"))
                Me.UsuarioAprobacion = drReader.GetValue(drReader.GetOrdinal("UsuarioAprobacion"))
                Me.FechaHoraAprobacion = drReader.GetValue(drReader.GetOrdinal("FechaHoraAprobacion"))
                Me.EstadoAutorizacion = drReader.GetValue(drReader.GetOrdinal("estado"))
            End If
            drReader.Close()
            cmd.Connection.Close()
        Catch ex As Exception
            Throw ex
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
    End Sub

    Public Shared Sub Autorizar(idAutorizacion As Guid, UsuarioAutoriza As String)
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Try
            'v If VerificaAutorizacionOnLine(idAutorizacion, UsuarioAutoriza) Then

            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .Parameters.AddWithValue("Id", idAutorizacion)
                .Parameters.AddWithValue("userAprobacion", UsuarioAutoriza)
                .CommandText = "AprobarSolicitudAutorizacionOnline"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

        Catch ex As Exception
            Throw ex
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        End Try
    End Sub

    

End Class
