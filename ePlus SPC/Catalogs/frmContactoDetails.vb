Imports SPC.Server.UserService
Imports SPC.Server.ReportService
Imports SPC.Server.FaceDetectionService
Imports SecuGen.FDxSDKPro.Windows
Imports AppMarcacion.Server.Schedule
Imports System.Collections.Generic
Imports System.IO 'simon
Imports System.Drawing.Image
Imports System.Web.Services 'simon
Imports FaceDetectLibrary.Classes
Imports FaceDetectLibrary
Imports FaceRekoClient.DTO.responses

Public Class frmContactoDetails
    Private dtRegBio As New DataTable("dtRegBio")
    Private dtRegBioTemp As New DataTable("dtRegBio")
    Private dtZonasAutorizadas As New DataTable("dtZonasAutorizadas") 'SIMON
    Private dtZonasAutorizadasByContacto As New DataTable("dtZonasAutorizadasByContacto") 'SIMON


    Private arrayImage As String
    Public Property IdUsuario As String 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
    Dim direccionAplication As String = My.Computer.FileSystem.CurrentDirectory


    Private Enum TipoRegistroBiometrico As Integer
        [Huella] = 0
        [Retina] = 1
        [BPM] = 2
    End Enum

    Public Property myContacto As New Server.ReportService.ContactoCatalogItem
    Public Property myContactoItem As New Server.UserService.ContactoCatalogItem 'guille
    Shared Property ContactoAgenciaCatalogo As New Server.ReportService.ContactoAgenciaCatalogItem 'guille
    Public Property ImagenContacto As New List(Of Server.ReportService.ContactoImagenCatalogoItem) 'guille
    Shared Property myArchivoContacto As New ArchivoContactoCatalogItem 'Guille

    Private Property DetailsEditingMode As Boolean = False
    Shared Property IsNewContacto As Boolean = False
    Shared Property idContactoNuevo As String
    Shared Property sNombreContacto As String


    Dim DtTemp As New DataTable
    Dim DeleteReg As Boolean = False
    Private Sub InitializeValues()
        myContacto.idContacto = String.Empty
        myContacto.primerNombre = ""
        myContacto.segundoNombre = ""
        myContacto.primerApellido = ""
        myContacto.segundoApellido = ""
        myContacto.direccion = ""
        myContacto.fechaNacimiento = DateTime.Now.AddYears(-20)
        myContacto.tagsa = ""
        myContacto.fechaCaducaTagsa = DateTime.Now.AddMonths(6)

        myContactoItem.idContacto = String.Empty
        myContactoItem.primerNombre = ""
        myContactoItem.segundoNombre = ""
        myContactoItem.primerApellido = ""
        myContactoItem.segundoApellido = ""
        myContactoItem.direccion = ""
        myContactoItem.fechaNacimiento = DateTime.Now.AddYears(-20)
        myContactoItem.tagsa = ""
        myContactoItem.fechaCaducaTagsa = DateTime.Now.AddMonths(6)


        btnActividades.Visible = IsNewContacto


    End Sub

    Public Sub New(ByVal myContactoItem As Server.ReportService.ContactoCatalogItem)
        InitializeComponent()
        InitializeValues()
        myContacto = myContactoItem
    End Sub

    Public Sub New(MustCreateNewMterial As Boolean)
        IsNewContacto = True
        InitializeComponent()
        InitializeValues()
    End Sub

    Public Sub New(ByVal ContactoId As String)
        InitializeComponent()
        InitializeValues()
        myContacto = CommonData.GetContactoItem(ContactoId)
        IsNewContacto = False

    End Sub

    Private Sub frmTipoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'utcTabs.Tabs.Item("INF").Enabled = False
        'utcTabs.Tabs.Item("BLI").Enabled = False
        'utcTabs.Tabs.Item("BIO").Enabled = False
        'utcTabs.Tabs.Item("ZON").Enabled = False
        FillTipoInfo()
        RefreshData()
        validaInfoAMostrar()
        'If PermiteActContacto(IdUsuario) = 0 And (ugvActividad.Rows.Count > 0 Or ugvListaArchivos.Rows.Count > 0 Or ugvRegBiometricos.Rows.Count > 0 Or dgvZonasAutorizadasYHorarios.Rows.Count > 0) Then
        'btnSave.Enabled = False
        'ugvActividad.Enabled = False
        'ugvListaArchivos.Enabled = False
        'btnCapturarHuella.Enabled = False
        'btnAgregarHorario.Enabled = False
        'End If
    End Sub

    Public Sub RefreshData()
        Try
            ugvActividad.DataSource = CommonData.GetContactoAgenciaPorIdContactoAll(myContacto.idContacto)
            SetDisplayedColumnsActividad()
            ugvListaArchivos.DataSource = CommonData.GetArchivoContactoItemByContacto(myContacto.idContacto)
            SetDisplayedColumnsArchivos()

            dtRegBio = CommonData.GetRegBiometricoByContacto(myContacto.idContacto) 'simon
            ugvRegBiometricos.DataSource = dtRegBio
            dtRegBioTemp = dtRegBio.Clone
            dtRegBioTemp.Clear()
            SetDisplayedColumnsRegBiometrico()

            dtZonasAutorizadas = CommonData.GetZonasAutorizadas()
            cmbAllZonas.Items.Clear()
            For i = 0 To dtZonasAutorizadas.Rows.Count - 1
                cmbAllZonas.Items.Add(dtZonasAutorizadas.Rows(i).Item("descripcion"))
            Next

            dtZonasAutorizadasByContacto = CommonData.GetZonasAutorizadasByContacto(myContacto.idContacto) 'simon
            dgvZonasAutorizadasYHorarios.DataSource = dtZonasAutorizadasByContacto
            SetDisplayedColumnsZonasAutorizadasByContacto()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsZonasAutorizadasByContacto()
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("idZonaAutorizada_Contacto").Hidden = True
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("idZona").Header.Caption = "Zona Autorizada"
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("DiaPermitido").Header.Caption = "Día Permitido"
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("HorarioDesde").Header.Caption = "Desde"
        dgvZonasAutorizadasYHorarios.DisplayLayout.Bands(0).Columns("HorarioHasta").Header.Caption = "Hasta"
    End Sub

    Private Sub SetDisplayedColumnsRegBiometrico()
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("idregistro_biometrico").Hidden = True
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("idcod_Contacto").Hidden = True
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("tag").Header.Caption = "Etiqueta"
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("detalle").Hidden = True
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("calificacion").Hidden = True 'simon
        ugvRegBiometricos.DisplayLayout.Bands(0).Columns("tipo").Header.Caption = "Tipo" 'simon
    End Sub

    Private Sub SetDisplayedColumnsArchivos()
        ugvListaArchivos.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
        ugvListaArchivos.DisplayLayout.Bands(0).Columns("idArchivo").Hidden = True
        ugvListaArchivos.DisplayLayout.Bands(0).Columns("descripcionArchivo").Header.Caption = "Descripción"
        ugvListaArchivos.DisplayLayout.Bands(0).Columns("extArchivo").Header.Caption = "Tipo"
        ugvListaArchivos.DisplayLayout.Bands(0).Columns("binArchivo").Hidden = True
    End Sub

    Private Sub SetDisplayedColumnsActividad()
        ugvActividad.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
        ugvActividad.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("Nombre").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("apellido").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("fechaInicio").Hidden = True
        'ugvActividad.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'ugvActividad.DisplayLayout.Bands(0).Columns("fechaFin").Header.Caption = "Fin"
        ugvActividad.DisplayLayout.Bands(0).Columns("fechaFin").Hidden = True
        'ugvActividad.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        'ugvActividad.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("cargo").Header.Caption = "Cargo"
        ugvActividad.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("tagsaContacto").Hidden = True
        ugvActividad.DisplayLayout.Bands(0).Columns("tipoAgencia").Hidden = True
    End Sub

    Private Sub PopulatePais()
        ucePais.Items.Clear()
        ucePais.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            ucePais.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
        Next
        ucePais.SelectedIndex = 0
    End Sub

    Private Sub PopulateCiudad()
        uceCiudad.Items.Clear()
        uceCiudad.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetCiudad(ucePais.Value.ToString).Rows
            uceCiudad.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
        Next
        uceCiudad.SelectedIndex = 0
    End Sub

    Private Sub ucePais_ValueChanged(sender As Object, e As EventArgs) Handles ucePais.SelectionChanged
        If IsNewContacto Then
            PopulateCiudad()
        End If
    End Sub

    Public Sub PopulateCombo()
        PopulatePais()
    End Sub

    Private Sub FillTipoInfo()
        If Not IsNewContacto Then
            uceTipoDoc.Items.Clear()
            For Each r As DataRow In CommonData.GetTipoDocPorId(myContacto.tipoDocumento).Rows
                uceTipoDoc.Items.Add(r.Item("idTipo"), r.Item("descripcion"))
            Next
            uceTipoDoc.SelectedIndex = 0
            For i As Integer = 0 To uceTipoDoc.Items.Count - 1
                uceTipoDoc.SelectedIndex = i
                If uceTipoDoc.Value = myContacto.tipoDocumento Then
                    Exit For
                End If
            Next

            txtId.Text = myContacto.idContacto
            txtNombre1.Text = myContacto.primerNombre
            txtNombre2.Text = myContacto.segundoNombre
            txtApellido1.Text = myContacto.primerApellido
            txtApellido2.Text = myContacto.segundoApellido
            ucePais.Items.Clear()
            ucePais.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetPais().Rows
                ucePais.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
            Next
            ucePais.SelectedIndex = 0
            For i As Integer = 0 To ucePais.Items.Count - 1
                ucePais.SelectedIndex = i
                If ucePais.Value = myContacto.idPais Then
                    Exit For
                End If
            Next
            uceCiudad.Items.Clear()
            uceCiudad.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetCiudad(ucePais.Value.ToString).Rows
                uceCiudad.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
            Next
            For i As Integer = 0 To uceCiudad.Items.Count - 1
                uceCiudad.SelectedIndex = i
                If uceCiudad.Value = myContacto.idCiudad Then
                    Exit For
                End If
            Next
            txtTelefono.Text = myContacto.telefono
            txtEmail.Text = myContacto.correo
            txtDireccion.Text = myContacto.direccion
            udtFecha.Value = myContacto.fechaNacimiento
            txtTagsa.Text = myContacto.tagsa
            udtFechaCaducaTagsa.Value = myContacto.fechaCaducaTagsa
            If myContacto.idContacto <> String.Empty Then
                utcTabs.Tabs.Item("INF").Enabled = True
                'comentado por el guille
                If Not MyCurrentUser.isAdministrador Then
                    utcTabs.Tabs.Item("BLI").Visible = False
                    'utcTabs.Tabs.Item("BIO").Visible = False
                    'utcTabs.Tabs.Item("ZON").Visible = False
                End If
                utcTabs.Tabs.Item("BLI").Enabled = True
                'utcTabs.Tabs.Item("BIO").Enabled = True
                'utcTabs.Tabs.Item("ZON").Enabled = True
            End If
            'simon
            If myContacto.imagenPerfil <> "" Then
                Dim base64String As String = myContacto.imagenPerfil
                Dim capturaRostro As System.Drawing.Image = Base64ToImage(base64String)
                pbxImagenPerfil.Image = capturaRostro
            Else
                pbxImagenPerfil.Image = Drawing.Image.FromFile(direccionAplication + "\Resources\imagenPerfil.jpg")
            End If

        Else
            udtFechaCaducaTagsa.Value = myContacto.fechaCaducaTagsa
            udtFecha.Value = myContacto.fechaNacimiento
            uceTipoDoc.Items.Clear()
            uceTipoDoc.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetTipoDocCatalog().Rows
                uceTipoDoc.Items.Add(r.Item("idTipo"), r.Item("descripcion"))
            Next
            uceTipoDoc.SelectedIndex = 0
            txtId.Enabled = False
            PopulateCombo()
            pbxImagenPerfil.Image = Drawing.Image.FromFile(direccionAplication + "\Resources\imagenPerfil.jpg")
            If myContacto.idContacto <> String.Empty Then
                utcTabs.Tabs.Item("INF").Enabled = True
                'comentado por el guille
                If Not MyCurrentUser.isAdministrador Then
                    utcTabs.Tabs.Item("BLI").Visible = False
                    'utcTabs.Tabs.Item("BIO").Visible = False
                    'utcTabs.Tabs.Item("ZON").Visible = False
                End If
                utcTabs.Tabs.Item("BLI").Enabled = True
                utcTabs.Tabs.Item("BIO").Enabled = True
                utcTabs.Tabs.Item("ZON").Enabled = True
            End If
        End If
    End Sub

    Private Sub SaveChanges()

        Dim req As New Server.ReportService.ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Dim cambiovalorobj As Boolean
        Dim cambioimg As Boolean
        Dim cambiobio As Boolean
        Dim cambiozon As Boolean
        Dim objectGeneric As New ArrayOfString


        Try
            If IsNewContacto Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)

                cambiovalorobj = ContactoInfoToObject() ' guille

                cambioimg = CargarImagenPerfil()

                cambiobio = RegBiometricoInfoObject() 'simon

                cambiozon = ZonasAutorizadasByContactoInfoObject() 'simon

                cambiovalorobj = cambiovalorobj And cambioimg And cambiobio And cambiozon

                'objectGeneric = New Object() {IIf(Not cambioimg, "CAMBIO DE IMAGEN DE PERFIL", "") _
                '                             , IIf(Not cambiobio, "CAPTURA BIOMETRICO", "") _
                '                             , IIf(Not cambiozon, "CABIO DE ZONA", "")}
                If Not cambioimg Then objectGeneric.Add("CAMBIO DE IMAGEN DE PERFIL")
                If Not cambiobio Then objectGeneric.Add("CAPTURA BIOMETRICO")
                If Not cambiozon Then objectGeneric.Add("CABIO DE ZONA")



                If IsNewContacto Then
                    req.myArchivoContactoItem = myArchivoContacto
                End If

                If Not IsNewContacto Then
                    If cambiovalorobj Then
                        If (MessageBox.Show("Al parecer no existe cambios en  los   Datos Generales del Contacto " & Chr(13) & "Aceptar para continuar o Cancelar para detener la operación ", "Mensaje del Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                            Exit Sub
                        End If
                    End If
                End If



                myContacto.IdContactoUser = IdUsuario 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contactometrico = .BioRecords.Count

                myContacto.AgenciaContacto = New List(Of Server.ReportService.ContactoAgenciaCatalogItem)
                myContacto.AgenciaContacto.Add(ContactoAgenciaCatalogo)

                req.myContactoItem = myContacto

                'desde aqui guille
                If PermiteActContacto(IdUsuario) = 0 Then
                    SolicitarAutorizacion(objectGeneric) 'guille
                    If MyAutorizacionOnline.EstadoAutorizacion = EstadoAprobacion.Aprobado Then
                        MessageBox.Show("Solicitud Autorizada por: " & MyAutorizacionOnline.UsuarioAprobacion, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Exit Sub
                    End If
                End If

                'hasta aqui guille

                'grabar datos de reconocimiento facial 
                'temporal hay que cambiar y hacer que llame desde el mismo servicio de contactos

                'If Not SaveReconocimientoFacial() Then
                '    Exit Sub
                'End If


                'START NEW: Reconocimiento Facial AWS by Tarkersito
                Dim _GetPerson_RS As FaceRekoClient.DTO.responses.GetPerson_RS

                _GetPerson_RS = FaceRekoClient.Logica.FaceRekonigtionLogic.GetFacePerson(myContacto.idContacto).Result
                If _GetPerson_RS.status Then
                    'Ya registrado
                Else
                    Dim _PersonInfo_RQ As FaceRekoClient.DTO.request.PersonInfo_RQ
                    _PersonInfo_RQ = New FaceRekoClient.DTO.request.PersonInfo_RQ
                    _PersonInfo_RQ.Nombre1 = myContacto.primerNombre
                    _PersonInfo_RQ.Nombre2 = myContacto.segundoNombre
                    _PersonInfo_RQ.Apellido1 = myContacto.primerApellido
                    _PersonInfo_RQ.Apellido2 = myContacto.segundoApellido
                    _PersonInfo_RQ.NroDocumento = myContacto.idContacto
                    'If myContacto.imagenesPerfil IsNot Nothing Then
                    '    If myContacto.imagenesPerfil.Count > 0 Then
                    '        _PersonInfo_RQ.Foto = myContacto.imagenesPerfil.ElementAt(0).imagen
                    '    End If
                    'End If
                    _PersonInfo_RQ.Foto = myContacto.imagenPerfil
                    Dim _CommonResponse_RS As FaceRekoClient.DTO.responses.CommonResponse_RS
                    _CommonResponse_RS = FaceRekoClient.Logica.FaceRekonigtionLogic.RegisterFacePerson(_PersonInfo_RQ).Result
                End If
                'END NEW: Reconocimiento Facial AWS by Tarkersito


                res = wsClnt.SaveContactoInfo(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    IsNewContacto = False
                    ContactoAgenciaCatalogo = Nothing
                Else
                    Throw New Exception(res.ErrorMessage)
                End If



            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage + Chr(13) + ex.ToString)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub
    Private Function SaveReconocimientoFacial() As Boolean
        Dim wsFace As New FaceDetectionMainSoapClient
        Dim facereq As New EPPersonRequest
        Dim faceres As New EPPersonResponse
        Dim dtPerson As DataTable
        Dim dtFace As DataTable
        Dim personID As String
        Dim objFace As New GeneralClassFace
        Dim flag As Boolean
        Dim reqPerson As New FPersonRequest
        Dim resPerson As New FPersonResponse

        Try

            reqPerson.myPerson = New FPerson()
            facereq.myPerson = New EPPerson()
            reqPerson.myPerson.ImagenesFace = New List(Of FaceDetectLibrary.PersonImagenesFace)
            facereq.myPerson.docId = myContacto.idContacto
            faceres = wsFace.GetFacePersonByDocId(facereq)

            If faceres.DsResult.Tables.Count > 0 Then
                dtPerson = faceres.DsResult.Tables(0)
                If dtPerson.Rows.Count > 0 Then
                    facereq.myPerson.personId = Guid.Parse(dtPerson.Rows(0).Item("personid").ToString())
                    facereq.myPerson.Id = facereq.myPerson.personId
                End If
                dtFace = faceres.DsResult.Tables(1)

                For Each fotosPerfil As Server.ReportService.ContactoImagenCatalogoItem In myContacto.imagenesPerfil
                    flag = False
                    For Each dr As DataRow In dtFace.Rows
                        If fotosPerfil.idImagen = dr.Item("idImagen") Then
                            flag = True
                            Exit For
                        End If
                    Next
                    If Not flag Then
                        reqPerson.myPerson.ImagenesFace.Add(New FaceDetectLibrary.PersonImagenesFace With {.PersonidImage = fotosPerfil.idImagen.ToString, .PersonImage = fotosPerfil.imagen})
                    End If
                Next

                reqPerson.myParameter = CommonData.GetParameter()
                reqPerson.myPerson.personName = myContacto.primerNombre & " " & myContacto.segundoNombre & " " & myContacto.primerApellido & " " & myContacto.segundoApellido
                reqPerson.myPerson.docId = myContacto.idContacto
                reqPerson.myPerson.personId = facereq.myPerson.personId

                If reqPerson.myPerson.personId = Guid.Parse("00000000-0000-0000-0000-000000000000") Then
                    resPerson = objFace.RegistrarPersonaMS(reqPerson)
                    reqPerson.myPerson.personId = resPerson.myPerson.personId
                Else

                End If

                resPerson = objFace.RegistrarCara(reqPerson)

                If resPerson.ActionResult Then
                    With facereq.myPerson
                        .personName = reqPerson.myPerson.personName
                        .docId = myContacto.idContacto
                        .PersonImage = ""
                        .personNotes = "VOLCADO"
                        .personGroupId = reqPerson.myParameter.IdGrupo
                        .personId = reqPerson.myPerson.personId
                        .Id = reqPerson.myPerson.personId
                        .ImagenesFace = New List(Of Server.FaceDetectionService.PersonImagenesFace)
                        For Each Imagen As FaceDetectLibrary.PersonImagenesFace In resPerson.myPerson.ImagenesFace
                            Dim wsPersistedFacesId As New List(Of Guid)
                            wsPersistedFacesId = Imagen.PersistedFacesId
                            .ImagenesFace.Add(New Server.FaceDetectionService.PersonImagenesFace With {.PersistedFacesId = wsPersistedFacesId, .PersonidImage = Imagen.PersonidImage})
                        Next
                    End With
                End If
                faceres = wsFace.RegisterNewPerson(facereq)
            End If

        Catch ex As Exception
            MessageBox.Show(resPerson.ErrorMessage + Chr(13) + ex.ToString)
            ErrorManager.SetLogEvent(ex)
            Return False
        End Try


        Return True

    End Function
    Private Function CargarImagenPerfil() As Boolean
        Dim img As New Server.ReportService.ContactoImagenCatalogoItem
        Dim imgContac As New Server.ReportService.ContactoImagenCatalogoItem
        Dim flagCambio As Boolean

        Dim lstimagen As New List(Of Server.ReportService.ContactoImagenCatalogoItem)

        flagCambio = True

        For lwicontador = 0 To ImagenContacto.Count - 1
            If ImagenContacto(lwicontador).estado = Server.ReportService.estadoImagen.Nuevo Or ImagenContacto(lwicontador).estado = Server.ReportService.estadoImagen.Inactivo Then
                ImagenContacto(lwicontador).Usuario = IdUsuario
                ImagenContacto(lwicontador).idContacto = myContacto.idContacto
                flagCambio = False
            End If

        Next



        myContacto.imagenesPerfil = Nothing
        myContacto.imagenesPerfil = ImagenContacto

        Return flagCambio

    End Function

    Private Function ContactoInfoToObject() As Boolean
        Dim flag As Boolean
        flag = True

        flag = (myContacto.idContacto = txtId.Text And flag)
        flag = (myContacto.idContacto = txtId.Text And flag)
        flag = (myContacto.tipoDocumento = uceTipoDoc.Value And flag)
        flag = (myContacto.primerNombre = txtNombre1.Text And flag)
        flag = (myContacto.segundoNombre = txtNombre2.Text And flag)
        flag = (myContacto.primerApellido = txtApellido1.Text And flag)
        flag = (myContacto.segundoApellido = txtApellido2.Text And flag)
        flag = (myContacto.idPais = ucePais.Value And flag)
        flag = (myContacto.idCiudad = uceCiudad.Value And flag)
        flag = (myContacto.telefono = txtTelefono.Text And flag)
        flag = (myContacto.correo = txtEmail.Text And flag)
        flag = (myContacto.direccion = txtDireccion.Text And flag)
        flag = (myContacto.fechaNacimiento = udtFecha.Value And flag)
        flag = (myContacto.tagsa = txtTagsa.Text And flag)
        flag = (myContacto.fechaCaducaTagsa = udtFechaCaducaTagsa.Value And flag)
        flag = (myContacto.imagenPerfil = arrayImage And flag)


        myContacto.idContacto = txtId.Text
        myContacto.tipoDocumento = uceTipoDoc.Value
        myContacto.primerNombre = txtNombre1.Text
        myContacto.segundoNombre = txtNombre2.Text
        myContacto.primerApellido = txtApellido1.Text
        myContacto.segundoApellido = txtApellido2.Text
        myContacto.idPais = ucePais.Value
        myContacto.idCiudad = uceCiudad.Value
        myContacto.telefono = txtTelefono.Text
        myContacto.correo = txtEmail.Text
        myContacto.direccion = txtDireccion.Text
        myContacto.fechaNacimiento = udtFecha.Value
        myContacto.tagsa = txtTagsa.Text
        myContacto.fechaCaducaTagsa = udtFechaCaducaTagsa.Value
        myContacto.imagenPerfil = arrayImage

        Return flag

    End Function

    Private Sub ContactoInfoAutorizacionOnline()
        Dim ContactAgenciaCatalogo As Server.UserService.ContactoAgenciaCatalogItem
        myContactoItem.idContacto = txtId.Text
        myContactoItem.tipoDocumento = uceTipoDoc.Value
        myContactoItem.primerNombre = txtNombre1.Text
        myContactoItem.segundoNombre = txtNombre2.Text
        myContactoItem.primerApellido = txtApellido1.Text
        myContactoItem.segundoApellido = txtApellido2.Text
        myContactoItem.idPais = ucePais.Value
        myContactoItem.idCiudad = uceCiudad.Value
        myContactoItem.telefono = txtTelefono.Text
        myContactoItem.correo = txtEmail.Text
        myContactoItem.direccion = txtDireccion.Text
        myContactoItem.fechaNacimiento = udtFecha.Value
        myContactoItem.tagsa = txtTagsa.Text
        myContactoItem.fechaCaducaTagsa = udtFechaCaducaTagsa.Value
        myContactoItem.imagenPerfil = arrayImage



        If Not IsNewContacto Then
            If ContactoAgenciaCatalogo Is Nothing Then

            End If
        Else
            ContactAgenciaCatalogo = New Server.UserService.ContactoAgenciaCatalogItem
            ContactAgenciaCatalogo.idAgencia = ContactoAgenciaCatalogo.idAgencia
            ContactAgenciaCatalogo.descripcionAgencia = ContactoAgenciaCatalogo.descripcionAgencia
            ContactAgenciaCatalogo.idContacto = ContactoAgenciaCatalogo.idContacto
            ContactAgenciaCatalogo.fechaInicio = ContactoAgenciaCatalogo.fechaInicio
            ContactAgenciaCatalogo.fechaFin = ContactoAgenciaCatalogo.fechaFin
            ContactAgenciaCatalogo.estado = ContactoAgenciaCatalogo.estado
            ContactAgenciaCatalogo.comentario = ContactoAgenciaCatalogo.comentario
            ContactAgenciaCatalogo.cargo = ContactoAgenciaCatalogo.cargo

            myContactoItem.AgenciaContacto = New List(Of Server.UserService.ContactoAgenciaCatalogItem)
            myContactoItem.AgenciaContacto.Add(ContactAgenciaCatalogo)

        End If



    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateInfo() Then

            arrayImage = ImageToBase64(pbxImagenPerfil.Image) 'modifca guille
            SaveChanges()
        End If
    End Sub

    Private Property MyAutorizacionOnline As New AutorizacionOnline

    Private Sub SolicitarAutorizacion(ObjectModi As ArrayOfString)
        Dim req As New AutorizacionesOnlineRequest
        Dim res As New AutorizacionesOnlineResponse
        Dim wsclient As New UserServiceSoapClient


        Try

            ContactoInfoAutorizacionOnline()




            With MyAutorizacionOnline
                .idAutorizacion = Guid.NewGuid
                .UsuarioSolicitante = modGeneral.MyCurrentUser.userId
                .FechaHoraSolicitud = Date.Now
                .UsuarioAprobacion = String.Empty
                .EtiquetaWebGeneric = ObjectModi


                .CatalogoContactoItem = myContactoItem


            End With

            req.AutorizacionesOnline = New List(Of AutorizacionOnline)
            req.AutorizacionesOnline.Add(MyAutorizacionOnline)

            res = wsclient.SaveAutorizacionesOnline(req)
            If res.ActionResult Then
                Using frmMensaje As New frmMessage("Solicitando Autorización", "Autorizaciones", True)
                    frmMensaje.MyAutorizacionOnline = MyAutorizacionOnline
                    frmMensaje.ShowDialog()
                    MyAutorizacionOnline = frmMensaje.MyAutorizacionOnline
                End Using
            End If

        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Function validateInfo() As Boolean


        Me.ErrorValida.SetError(Me.txtNombre1, "")
        If txtNombre1.Text = String.Empty Then
            MessageBox.Show("Ingrese Primer Nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtNombre1, "Campo Obligatorio")
            Return False
        End If

        Me.ErrorValida.SetError(Me.txtApellido1, "")
        If txtApellido1.Text = String.Empty Then
            MessageBox.Show("Ingrese Primer Apellido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtApellido1, "Campo Obligatorio")
            Return False
        End If


        Me.ErrorValida.SetError(Me.txtId, "")
        If txtId.Text = String.Empty Then
            MessageBox.Show("Ingrese No. Identificación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtId, "Campo Obligatorio")
            Return False
        End If
        If String.Compare(uceTipoDoc.Text, "CEDULA") = 0 Then
            If txtId.TextLength < 10 Then
                MessageBox.Show("No. Identificación incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
        If uceTipoDoc.Text = "CEDULA" Then
            Select Case txtId.Text.Length
                Case 10
                    If Not ValidateDocId(txtId.Text, "CEDULA") Then
                        MessageBox.Show("Error en No. Identificación, por favor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtId.Clear()
                        Return False
                    End If
                Case 13
                    If Not ValidateDocId(txtId.Text, "RUC") Then
                        MessageBox.Show("Error en No. RUC, por favor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case Else
                    MessageBox.Show("Error en No. Identificación, por favor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
            End Select
        End If

        Me.ErrorValida.SetError(Me.udtFecha, "")
        If udtFecha.Value = Date.Today Then
            MessageBox.Show("Ingrese Fecha de Nacimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.udtFecha, "Fecha de nacimiento invalida")
            Return False
        End If


        Me.ErrorValida.SetError(ucePais, "")
        If ucePais.Text = "Escoja una opción" Then
            MessageBox.Show("Escoja País", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(ucePais, "Campo Obligatorio")
            Return False
        End If
        Me.ErrorValida.SetError(uceCiudad, "")
        If uceCiudad.Text = "Escoja una opción" Then
            MessageBox.Show("Escoja Ciudad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(uceCiudad, "Campo Obligatorio")
            Return False
        End If
        If txtTagsa.Text = "NO TIENE" Or txtTagsa.Text = "" Then
        ElseIf udtFechaCaducaTagsa.Value < Date.Now.ToShortDateString Then
            MessageBox.Show("La fecha de Caducidad TAGSA no es válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Me.ErrorValida.SetError(Me.txtTelefono, "")
        If txtTelefono.Text = String.Empty Then
            MessageBox.Show("Favor ingrese un teléfono ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtTelefono, "Campo Obligatorio")
            Return False
        End If

        Me.ErrorValida.SetError(Me.txtDireccion, "")
        If txtDireccion.Text = String.Empty Then
            MessageBox.Show("Favor ingrese una direccion ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtDireccion, "Campo Obligatorio")
            Return False
        End If

        If txtDireccion.Text.Length < 10 Then
            MessageBox.Show("La direccion debe contener al menos 10 caracteres ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ErrorValida.SetError(Me.txtDireccion, "La direccion debe contener al menos 10 caracteres")
            Return False
        End If




        If IsNewContacto Then
            If ContactoAgenciaCatalogo Is Nothing Then
                MessageBox.Show("Escoja una compañia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            If ContactoAgenciaCatalogo.idContacto Is Nothing Then
                MessageBox.Show("Escoja una compañia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False

            End If
        End If



        Return True
    End Function

    Public Shared Function ValidateDocId(ByVal strDoc As String, ByVal docType As String) As Boolean

        Dim result As Boolean
        Dim objField As List(Of Integer) = New List(Of Integer)
        Dim intModulo As Integer = 0
        Dim intVerificador As Integer = 0
        Dim intSum As Integer = 0
        Dim intRes As Integer = 0
        Dim rucType As String = String.Empty
        Try
            strDoc = strDoc.Trim
            Dim fChar As New Char
            Dim counter As Integer = 0
            fChar = strDoc.Chars(0)

            For i As Integer = 0 To strDoc.Length - 1
                If fChar = strDoc.Chars(i) Then
                    counter += 1
                End If
            Next

            If counter = 10 Or counter = 13 Then
                Return False
            End If

            If IsNumeric(strDoc) Then

                Select Case docType
                    '////////////////////////////////////
                    ' 1 = CEDULA
                    ' 4 = RUC
                    '////////////////////////////////////
                    'Case 1, 4
                    Case "CEDULA", "RUC"

                        Select Case strDoc.Length
                            Case 10, 13
                                objField.Add(strDoc.Substring(0, 1))
                                objField.Add(strDoc.Substring(1, 1))
                                objField.Add(strDoc.Substring(2, 1))
                                objField.Add(strDoc.Substring(3, 1))
                                objField.Add(strDoc.Substring(4, 1))
                                objField.Add(strDoc.Substring(5, 1))
                                objField.Add(strDoc.Substring(6, 1))
                                objField.Add(strDoc.Substring(7, 1))
                                objField.Add(strDoc.Substring(8, 1))
                                objField.Add(strDoc.Substring(9, 1))

                                Select Case objField.Item(2)
                                    '///////////////////////////////////////////////
                                    ' EL TERCER DIGITO ES:
                                    ' 9   = PARA SOCIEDADES PRIVADAS Y EXTRANJEROS
                                    ' 6   = PARA SOCIEDADES PUBLICAS
                                    ' < 6 = (0,1,2,3,4,5) PARA PERSONAS NATURALES
                                    '///////////////////////////////////////////////
                                    Case 9      ' 9   = PARA SOCIEDADES PRIVADAS Y EXTRANJEROS
                                        If strDoc.Length <> 13 And docType = "RUC" Then
                                            Throw New Exception("LONGITUD DE RUC DEBE DE SER DE 13 DIGITOS")
                                        End If

                                        intModulo = 11
                                        intVerificador = objField.Item(9)
                                        rucType = "PRIVADAS"

                                        objField.Item(0) *= 4
                                        objField.Item(1) *= 3
                                        objField.Item(2) *= 2
                                        objField.Item(3) *= 7
                                        objField.Item(4) *= 6
                                        objField.Item(5) *= 5
                                        objField.Item(6) *= 4
                                        objField.Item(7) *= 3
                                        objField.Item(8) *= 2

                                    Case 7, 8
                                        Throw New Exception("EL TERCER DIGITO ES INVALIDO")

                                    Case 6      ' 6   = PARA SOCIEDADES PUBLICAS
                                        If strDoc.Length <> 13 And docType = "RUC" Then
                                            Throw New Exception("LONGITUD DE RUC DEBE DE SER DE 13 DIGITOS")
                                        End If

                                        intModulo = 11
                                        intVerificador = objField.Item(8)
                                        rucType = "PUBLICAS"

                                        objField.Item(0) *= 3
                                        objField.Item(1) *= 2
                                        objField.Item(2) *= 7
                                        objField.Item(3) *= 6
                                        objField.Item(4) *= 5
                                        objField.Item(5) *= 4
                                        objField.Item(6) *= 3
                                        objField.Item(7) *= 2
                                        objField.Item(8) *= 0


                                    Case Is < 6 ' (0,1,2,3,4,5) PARA PERSONAS NATURALES
                                        Select Case docType
                                            Case "CEDULA"
                                                If strDoc.Length <> 10 Then
                                                    Throw New Exception("LONGITUD DE CEDULA DEBE DE SER DE 10 DIGITOS")
                                                End If

                                            Case "RUC"
                                                If strDoc.Length <> 13 Then
                                                    Throw New Exception("LONGITUD DE RUC DE PERSONA NATURAL DEBE DE SER DE 13 DIGITOS")
                                                End If

                                        End Select

                                        intModulo = 10
                                        intVerificador = objField.Item(9)
                                        rucType = "NATURAL"

                                        objField.Item(0) *= 2 : If objField.Item(0) >= 10 Then objField.Item(0) -= 9
                                        objField.Item(1) *= 1 : If objField.Item(1) >= 10 Then objField.Item(1) -= 9
                                        objField.Item(2) *= 2 : If objField.Item(2) >= 10 Then objField.Item(2) -= 9
                                        objField.Item(3) *= 1 : If objField.Item(3) >= 10 Then objField.Item(3) -= 9
                                        objField.Item(4) *= 2 : If objField.Item(4) >= 10 Then objField.Item(4) -= 9
                                        objField.Item(5) *= 1 : If objField.Item(5) >= 10 Then objField.Item(5) -= 9
                                        objField.Item(6) *= 2 : If objField.Item(6) >= 10 Then objField.Item(6) -= 9
                                        objField.Item(7) *= 1 : If objField.Item(7) >= 10 Then objField.Item(7) -= 9
                                        objField.Item(8) *= 2 : If objField.Item(8) >= 10 Then objField.Item(8) -= 9

                                End Select

                                intSum = objField.Item(0)
                                intSum += objField.Item(1)
                                intSum += objField.Item(2)
                                intSum += objField.Item(3)
                                intSum += objField.Item(4)
                                intSum += objField.Item(5)
                                intSum += objField.Item(6)
                                intSum += objField.Item(7)
                                intSum += objField.Item(8)

                                intRes = intSum Mod intModulo

                                If intRes <> 0 Then
                                    intRes = intModulo - intRes
                                End If

                                If intRes <> intVerificador Then
                                    Throw New Exception("NUMERO DE IDENTIFICACIÓN INVALIDO")
                                End If

                                Select Case rucType
                                    Case "NATURAL"
                                        If strDoc.Length > 10 AndAlso strDoc.Substring(10, 3) <> "001" Then
                                            Throw New Exception("EL RUC DE LA PERSONA NATURAL DEBE DE TERMINAR CON 001")
                                        End If

                                    Case "PRIVADAS"
                                        If strDoc.Substring(10, 3) <> "001" Then
                                            Throw New Exception("EL RUC DE LA EMPRESA PRIVADA DEBE DE TERMINAR CON 001")
                                        End If

                                    Case "PUBLICAS"
                                        If strDoc.Substring(9, 4) <> "0001" Then
                                            Throw New Exception("EL RUC DE LA EMPRESA PUBLICA DEBE DE TERMINAR CON 0001")
                                        End If

                                End Select

                            Case Else
                                Select Case docType
                                    Case "CEDULA"
                                        Throw New Exception("LONGITUD DE CEDULA DEBE DE SER DE 10 DIGITOS")

                                    Case "RUC"
                                        Throw New Exception("LONGITUD DE RUC DEBE DE SER DE 13 DIGITOS")

                                End Select

                        End Select

                    Case Else
                        Throw New Exception(String.Format("TIPO DE DOCUMENTO DESCONOCIDO [{0}]", docType))

                End Select

            Else
                Throw New Exception("EL DOCUMENTO DEBE DE CONTENER SOLO NUMEROS")
            End If

            result = True

        Catch ex As Exception
            result = False
        Finally
            objField.Clear()
            objField = Nothing
        End Try
        Return result
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub uceTipoDoc_ValueChanged(sender As Object, e As EventArgs) Handles uceTipoDoc.SelectionChanged
        If String.Compare(uceTipoDoc.Text, "Escoja una opción") = 0 Then
            txtId.Enabled = False

        ElseIf String.Compare(uceTipoDoc.Text, "CEDULA") = 0 Then
            txtId.Enabled = True
            txtId.MaxLength = 10

        ElseIf String.Compare(uceTipoDoc.Text, "PASAPORTE") = 0 Then
            txtId.Enabled = True
            txtId.MaxLength = 15

        End If
    End Sub

    Private Sub ugvListaArchivos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvListaArchivos.DoubleClickCell

        If Not ugvListaArchivos.ActiveRow.Cells("idArchivo").Value.ToString = String.Empty Then
            ShowAirportDetails(ugvListaArchivos.ActiveRow.Cells("idArchivo").Value)
        Else
            Dim lwidContacto As String
            lwidContacto = myContacto.idContacto
            If IsNewContacto Then
                If Me.txtId.Text Is Nothing Or Me.txtId.Text = "" Then
                    Exit Sub
                End If
                lwidContacto = Me.txtId.Text
            End If

            Using frmDetails As New frmArchivo(lwidContacto)
                frmDetails.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ShowAirportDetails(id As Guid)
        Using frmDetails As New frmArchivo(myContacto.idContacto, id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ugvActividad_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvActividad.DoubleClickCell
        Dim idContacto As String = String.Empty
        Dim idAgencia As Guid = Guid.Empty
        Dim indice As Guid = Guid.Empty
        Dim fechaIni As DateTime
        Dim estado As String
        If Not ugvActividad.ActiveRow.Cells("idContacto").Value.ToString = String.Empty Then
            idContacto = ugvActividad.ActiveRow.Cells("idContacto").Value
            fechaIni = ugvActividad.ActiveRow.Cells("fechaInicio").Value
            estado = ugvActividad.ActiveRow.Cells("estado").Value
            idAgencia = ugvActividad.ActiveRow.Cells("idAgencia").Value
            indice = ugvActividad.ActiveRow.Cells("indice").Value
            ShowTiposContactoAgenciaDetails(idAgencia, idContacto, fechaIni, estado, indice, IdUsuario)
        Else
            Using frmDetails As New frmContactoAgenciaDetails(True, idAgencia, myContacto.idContacto, IdUsuario) 'Using frmDetails As New frmContactoAgenciaDetails(True, idAgencia, myContacto.idContacto)
                frmDetails.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ShowTiposContactoAgenciaDetails(agencia As Guid, contacto As String, fechaI As Date, estado As String, indice As Guid, IdUsuario As String)
        Using frmDetails As New frmContactoAgenciaDetails(agencia, contacto, fechaI, estado, indice, IdUsuario) 'frmContactoAgenciaDetails(agencia, contacto, fechaI, estado, indice)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtId_KeyUp(sender As Object, e As KeyEventArgs) Handles txtId.KeyUp
        Try
            If txtId.TextLength = 10 Then
                If validateInfo() Then
                    utcTabs.Tabs.Item("INF").Enabled = True
                    ''utcTabs.Tabs.Item("BLI").Enabled = True
                    ''utcTabs.Tabs.Item("BIO").Enabled = True
                    ''utcTabs.Tabs.Item("ZON").Enabled = True
                Else
                    utcTabs.Tabs.Item("INF").Enabled = False
                    'utcTabs.Tabs.Item("BLI").Enabled = False
                    'utcTabs.Tabs.Item("BIO").Enabled = True
                    'utcTabs.Tabs.Item("ZON").Enabled = False
                End If
            Else
                utcTabs.Tabs.Item("INF").Enabled = False
                'utcTabs.Tabs.Item("BLI").Enabled = False
                'utcTabs.Tabs.Item("BIO").Enabled = True
                'utcTabs.Tabs.Item("ZON").Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub validaInfoAMostrar()
        If Not IsNewContacto Then
            If (txtTagsa.Text = "NO TIENE" Or txtTagsa.Text = "") Then
                udtFechaCaducaTagsa.Visible = False
                UltraLabel10.Visible = False
            Else
                udtFechaCaducaTagsa.Visible = True
                UltraLabel10.Visible = True
                If (udtFechaCaducaTagsa.Value > DateTime.Now.AddYears(2)) Then
                    MessageBox.Show("¿Esta realmente seguro que es correcta está fecha?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If (udtFechaCaducaTagsa.Value < DateTime.Now.AddDays(-1)) Then
                    MessageBox.Show("No. TAGSA caducado, verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

    End Sub

    Private Sub ugvListaArchivos_KeyDown(sender As Object, e As KeyEventArgs) Handles ugvListaArchivos.KeyDown
        Try
            If e.KeyData = Keys.Delete Then
                If PermiteActContacto(IdUsuario) = 0 Then
                    MessageBox.Show("No Tiene permisos para realizar modificaciones a datos del Contacto")
                Else
                    For Each r As DataRow In ugvListaArchivos.DataSource.rows
                        If r.Item("idArchivo") = ugvListaArchivos.ActiveRow.Cells("idArchivo").Value Then
                            Dim tempArchivoContacto As New ArchivoContactoCatalogItem
                            tempArchivoContacto.idContacto = ugvListaArchivos.ActiveRow.Cells("idContacto").Value
                            tempArchivoContacto.idArchivo = ugvListaArchivos.ActiveRow.Cells("idArchivo").Value
                            tempArchivoContacto.descripcionArchivo = ugvListaArchivos.ActiveRow.Cells("descripcionArchivo").Value
                            tempArchivoContacto.extArchivo = ugvListaArchivos.ActiveRow.Cells("extArchivo").Value
                            tempArchivoContacto.binArchivo = ugvListaArchivos.ActiveRow.Cells("binArchivo").Value
                            tempArchivoContacto.estado = "E"
                            If SaveArchivoContacto(tempArchivoContacto) Then
                                r.Delete()
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function SaveArchivoContacto(tempArchivoContacto As ArchivoContactoCatalogItem) As Boolean
        Dim resp As Boolean = False
        Dim req As New ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Try
            req.myArchivoContactoItem = tempArchivoContacto
            res = wsClnt.SaveArchivoContactoItem(req)
            If res.ActionResult Then
                resp = True
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Return resp
    End Function

    Private Sub udtFecha_Validated(sender As Object, e As EventArgs) Handles udtFecha.Validated
        If udtFecha.Value < DateTime.Now.AddYears(-80) And uceTipoDoc.Items.Count > 1 Then
            MessageBox.Show("¿El contacto es mayor de 80 Años?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If udtFecha.Value > DateTime.Now.AddYears(-18) And uceTipoDoc.Items.Count > 1 Then
            MessageBox.Show("¿El contacto es menor de edad?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub udtFechaCaducaTagsa_Validated(sender As Object, e As EventArgs) Handles udtFechaCaducaTagsa.Validated
        If Not (txtTagsa.Text.Trim = "" Or txtTagsa.Text.Trim = "NO TIENE") Then
            If (udtFechaCaducaTagsa.Value > DateTime.Now.AddYears(2)) And uceTipoDoc.Items.Count > 1 Then
                MessageBox.Show("¿Esta realmente seguro que es correcta está fecha?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If (udtFechaCaducaTagsa.Value < DateTime.Now.AddDays(-1)) And uceTipoDoc.Items.Count > 1 Then
                MessageBox.Show("No. TAGSA caducado, verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub txtTagsa_TextChanged(sender As Object, e As EventArgs) Handles txtTagsa.TextChanged
        If txtTagsa.Text.Trim = "" Or txtTagsa.Text.Trim = "NO TIENE" Then
            udtFechaCaducaTagsa.Visible = False
            UltraLabel10.Visible = False
            udtFechaCaducaTagsa.Value = "01/01/2000"
        Else
            UltraLabel10.Visible = True
            udtFechaCaducaTagsa.Visible = True
        End If
    End Sub

#Region "RegistroBiometrico"
    Private pInfo As SGFPMDeviceInfoParam

    Private Function CaptureBioInfo() As String
        Dim strResult As String = String.Empty
        Dim arrCapture() As Byte
        Dim arrStoredTemplate(400) As Byte
        Dim arrCapturedTemplate(400) As Byte
        Dim iError As Int32
        Dim img_qlty As Int32
        Dim m_FPM As New SGFingerPrintManager
        Dim device_name As SGFPMDeviceName
        Dim device_id As Int32
        device_name = 6 'simon
        device_id = 6 'simon
        Try
            iError = m_FPM.Init(SGFPMDeviceName.DEV_AUTO)

            If iError <> 0 Then Throw New Exception("Error al iniciar biométrico. Error:" & iError)
            iError = m_FPM.OpenDevice(SGFPMPortAddr.USB_AUTO_DETECT)
            If iError <> 0 Then Throw New Exception("Error al abrir biométrico. Error:" & iError)

            pInfo = New SGFPMDeviceInfoParam
            iError = m_FPM.GetDeviceInfo(pInfo)
            If iError <> 0 Then Throw New Exception("Error al obtener info desde el biométrico. Error:" & iError)

            ReDim arrCapture(pInfo.ImageWidth * pInfo.ImageHeight)
            If MessageBox.Show("Coloque el dedo en el sensor.", "Captura de huella", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                iError = m_FPM.GetImage(arrCapture)
            Else
                Return strResult
            End If
            If iError <> 0 Then Throw New Exception("Error al obtener imagen de huella. Error:" & iError)

            If iError = SGFPMError.ERROR_NONE Then
                DrawImage(arrCapture, pbxBio)
                m_FPM.GetImageQuality(pInfo.ImageWidth, pInfo.ImageHeight, arrCapture, img_qlty)
                If img_qlty < 50 Then
                    Throw New Exception("Calidad de la imagen muy baja, por favor reintente")
                End If
                iError = m_FPM.CreateTemplate(arrCapture, arrCapturedTemplate)
                strResult = Convert.ToBase64String(arrCapturedTemplate)
            Else
                Throw New Exception("Error al obtener imagen para plantilla. SecErr:" & iError)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return strResult
    End Function

    Private Sub DrawImage(ByVal imgData() As Byte, ByVal picBox As PictureBox)
        Dim colorval As Int32
        Dim bmp As Bitmap
        Dim i, j As Int32

        bmp = New Bitmap(pInfo.ImageWidth, pInfo.ImageHeight)
        picBox.Image = bmp

        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                colorval = imgData((j * pInfo.ImageWidth) + i)
                bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval))
            Next j
        Next i

        picBox.Refresh()
    End Sub


#Region "AgregarRegistroBiometrico"
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnCapturarHuella.Click
        Dim strData, strEtiqueta As String
        strData = CaptureBioInfo()
        If strData <> "" Then
            strEtiqueta = UCase(InputBox("Ingrese una etiqueta para el Registro Biométrico. Etiqueta debe ser mayor a 5 caracteres", "Captura de huella"))
            Do While strEtiqueta.Count < 5
                MsgBox("Falta etiqueta del Registro. Intente nuevamente", MsgBoxStyle.Critical, "Registro biométrico")
                strEtiqueta = UCase(InputBox("Ingrese una etiqueta para el Registro Biométrico. Etiqueta debe ser mayor a 5 caracteres", "Captura de huella"))
            Loop
            AgregarRegistroBiometrico(strData, strEtiqueta)
        End If
    End Sub
    Private Sub AgregarRegistroBiometrico(ByVal BioData As String, BioTag As String)
        Dim newRow As DataRow
        newRow = dtRegBio.NewRow
        newRow.Item(0) = txtId.Text
        newRow.Item(1) = dtRegBio.Rows.Count + 1
        newRow.Item(2) = BioTag
        newRow.Item(3) = BioData
        newRow.Item(4) = "0"
        newRow.Item(5) = TipoRegistroBiometrico.Huella
        newRow.Item(6) = "N"
        dtRegBio.Rows.Add(newRow)
    End Sub
    Private Function RegBiometricoInfoObject() As Boolean
        Dim dtCAmbios As DataTable
        Dim flagCambio As Boolean

        flagCambio = True
        myContacto.BioRecords = New List(Of Server.ReportService.RegBiometricoCatalogItem)

        dtCAmbios = dtRegBio.GetChanges()

        dtRegBio.AcceptChanges()


        For i = 0 To ugvRegBiometricos.Rows.Count - 1
            myContacto.BioRecords.Add(New Server.ReportService.RegBiometricoCatalogItem With {.idcod_Contacto = txtId.Text, .idregistro_biometrico = i + 1, .tag = dtRegBio.Rows(i).Item("tag"), .detalle = dtRegBio.Rows(i).Item("detalle"), .calificacion = dtRegBio.Rows(i).Item("calificacion"), .tipo = dtRegBio.Rows(i).Item("tipo"), .Estado = dtRegBio.Rows(i).Item("Estado")})
        Next

        If Not dtCAmbios Is Nothing Then
            flagCambio = False
        End If


        Return flagCambio

    End Function
#End Region

#End Region

#Region "ImagenPerfil"
    Private Sub btnCapturarRostro_Click(sender As Object, e As EventArgs) Handles btnCapturarRostro.Click
        Using myFrmCaptura As New frmVisualizar
            myFrmCaptura.myImagen = myContacto.imagenPerfil
            myFrmCaptura.myImagenes = myContacto.imagenesPerfil
            myFrmCaptura.ShowDialog()
            If myFrmCaptura.capturaRostro IsNot Nothing Then
                pbxImagenPerfil.Image = myFrmCaptura.capturaRostro
                ImagenContacto = myFrmCaptura.myImagenes 'guille
            Else
                MessageBox.Show("No se pudo realizar la captura de la imagen de perfil, revise si la cámara se encuentra conectada y funcionando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                pbxImagenPerfil.Image = Drawing.Image.FromFile(direccionAplication + "\Resources\imagenPerfil.jpg")
            End If
        End Using
    End Sub
    Public Shared Function ImageToBase64(capturaRostro) As String
        'Dim capturaRostro = pbxImagenPerfil.Image 'comenta guille
        Dim ms = New MemoryStream()
        capturaRostro.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim imageBytes As Byte() = ms.ToArray()
        Dim base64String As String = Convert.ToBase64String(imageBytes)
        Return base64String
    End Function
    Public Shared Function Base64ToImage(base64String As String) As System.Drawing.Image
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms = New MemoryStream(imageBytes, 0, imageBytes.Length)
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim imagenPerfil As System.Drawing.Image = System.Drawing.Image.FromStream(ms, True)
        Return imagenPerfil
    End Function

#End Region

#Region "ZonasAutorizadas"

    Private Sub btnAgregarHorario_Click(sender As Object, e As EventArgs) Handles btnAgregarHorario.Click
        If cmbAllZonas.Text <> "" Then
            If dtZonasAutorizadasByContacto.Columns.Count = 0 Then
                dtZonasAutorizadasByContacto.Dispose()
                dtZonasAutorizadasByContacto.Columns.Add("idZonaAutorizada_Contacto")
                dtZonasAutorizadasByContacto.Columns.Add("idContacto")
                dtZonasAutorizadasByContacto.Columns.Add("idZona")
                dtZonasAutorizadasByContacto.Columns.Add("DiaPermitido")
                dtZonasAutorizadasByContacto.Columns.Add("HorarioDesde")
                dtZonasAutorizadasByContacto.Columns.Add("HorarioHasta")
            End If
            Dim ZonaAutorizadaSeleccionada As String = cmbAllZonas.Text
            Using myFrmHorariosByZona As New frmZonasHorarios
                myFrmHorariosByZona.ShowDialog()
                If myFrmHorariosByZona.dtHorarios.Rows.Count > 0 Then
                    For i = 0 To myFrmHorariosByZona.dtHorarios.Rows.Count - 1
                        Dim newRow As DataRow
                        newRow = dtZonasAutorizadasByContacto.NewRow
                        newRow.Item(0) = dtZonasAutorizadasByContacto.Rows.Count + 1
                        newRow.Item(1) = txtId.Text
                        newRow.Item(2) = ZonaAutorizadaSeleccionada
                        newRow.Item(3) = myFrmHorariosByZona.dtHorarios.Rows(i).Item(0)
                        newRow.Item(4) = myFrmHorariosByZona.dtHorarios.Rows(i).Item(1)
                        newRow.Item(5) = myFrmHorariosByZona.dtHorarios.Rows(i).Item(2)
                        dtZonasAutorizadasByContacto.Rows.Add(newRow)
                    Next
                Else
                    MessageBox.Show("No se ha ingresado el horario respectivo para la zona seleccionada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
            dgvZonasAutorizadasYHorarios.DataSource = dtZonasAutorizadasByContacto
        Else
            MessageBox.Show("Seleccione una zona para asignar el horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ZonasAutorizadasByContactoInfoObject() As Boolean
        Dim dtCAmbios As DataTable
        Dim flagCambio As Boolean

        flagCambio = True
        myContacto.ZonasAutorizadasByContacto = New List(Of Server.ReportService.ZonasAutorizadasByContactoCatalogItem)

        dtCAmbios = dtZonasAutorizadasByContacto.GetChanges()

        dtZonasAutorizadasByContacto.AcceptChanges()

        For i = 0 To dgvZonasAutorizadasYHorarios.Rows.Count - 1
            myContacto.ZonasAutorizadasByContacto.Add(New Server.ReportService.ZonasAutorizadasByContactoCatalogItem With {.idZonaAutorizada_Contacto = dtZonasAutorizadasByContacto.Rows(i).Item("idZonaAutorizada_Contacto"), .idContacto = txtId.Text, .idZona = dtZonasAutorizadasByContacto.Rows(i).Item("idZona"), .DiaPermitido = dtZonasAutorizadasByContacto.Rows(i).Item("DiaPermitido"), .HorarioDesde = Convert.ToString(dtZonasAutorizadasByContacto.Rows(i).Item("HorarioDesde")), .HorarioHasta = Convert.ToString(dtZonasAutorizadasByContacto.Rows(i).Item("HorarioHasta"))})
        Next

        If Not dtCAmbios Is Nothing Then

            flagCambio = False

        End If




        Return flagCambio

    End Function


#End Region
    Private Function PermiteActContacto(idContacto As String) As Integer
        Dim req As String
        Dim res As Integer
        Dim wsClnt As New ReportServiceSoapClient
        Try
            req = idContacto
            res = wsClnt.PermiteActContacto(req)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
        Return res
    End Function

    Private Sub ugvRegBiometricos_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvRegBiometricos.AfterRowsDeleted
        Dim newRow As DataRow
        For Each r As DataRow In dtRegBioTemp.Rows
            For Each i As DataRow In DtTemp.Rows
                If r.Item("idcod_Contacto") = i.Item("idcod_Contacto") And r.Item("idregistro_biometrico") = i.Item("idregistro_biometrico") Then
                    i.Item("Estado") = "E"
                    DtTemp.AcceptChanges()
                End If
            Next
        Next
        dtRegBio.Clear()
        dtRegBio = DtTemp.Copy
        ugvRegBiometricos.DataSource = dtRegBio
        DeleteReg = True
        DtTemp.Clear()
    End Sub
    Private Sub ugvRegBiometricos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvRegBiometricos.AfterRowActivate
        DtTemp.Clear()
        DtTemp = dtRegBio.Copy
        dtRegBioTemp.Clear()
        If DeleteReg = False Then
            Dim r As DataRow
            r = dtRegBioTemp.NewRow
            r.Item("idcod_Contacto") = ugvRegBiometricos.ActiveRow.Cells("idcod_Contacto").Value
            r.Item("idregistro_biometrico") = ugvRegBiometricos.ActiveRow.Cells("idregistro_biometrico").Value
            r.Item("tag") = ugvRegBiometricos.ActiveRow.Cells("tag").Value
            r.Item("detalle") = ugvRegBiometricos.ActiveRow.Cells("detalle").Value
            r.Item("calificacion") = ugvRegBiometricos.ActiveRow.Cells("calificacion").Value
            r.Item("tipo") = ugvRegBiometricos.ActiveRow.Cells("tipo").Value
            r.Item("Estado") = ugvRegBiometricos.ActiveRow.Cells("Estado").Value
            dtRegBioTemp.Rows.Add(r)
        End If
        DeleteReg = False
    End Sub






    Private Sub btnActividades_Click(sender As Object, e As EventArgs) Handles btnActividades.Click

        idContactoNuevo = txtId.Text
        sNombreContacto = txtNombre1.Text & " " & txtNombre2.Text & " " & txtApellido1.Text & " " & txtApellido2.Text
        Using frmDetails As New frmContactoAgenciaDetails(True, Guid.Empty, idContactoNuevo, IdUsuario) 'Using frmDetails As New frmContactoAgenciaDetails(True, idAgencia, myContacto.idContacto)
            frmDetails.ShowDialog()
        End Using

    End Sub


End Class