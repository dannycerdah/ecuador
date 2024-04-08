Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Imports System.IO.Ports

Public Class frmDecomisoDetalle
    Public dtDetalleProcesoDecomiso As New DataTable("dtDetalleProcesoDecomiso")
    Public dtDetalleProcesoDaeDecomiso As New DataTable("dtDetalleProcesoDaeDecomiso")
    Private DtPersonaDecomiso As New DataTable()
    Dim dtPersonalProceso As New DataTable("PersonalProceso")
    Dim dtDetalleProcesoCamiones As New DataTable("dtDetalleProcesoCamiones")
    Dim DtPersonalFirma As New DataTable("DtPersonalFirma")
    Dim dtDetalleProceso As New DataTable("dtDetalleProceso")
    Dim detalleVuelo As New DetalleVuelo

    Dim DecomisoEncabezado As DecomisoEncabezado
    Dim DecomisoEncabezadoRemiDesti As DecomisoEncabezado
    Dim DecomisoDetalle As DecomisoDetalle
    Dim guiaItem As New GuiaItem
    Dim AEROLINEA As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim GENERALAIR As String = "38b4e437-f3dd-4625-8e73-538858824fce"
    Dim INSTITUCION As String = "9cf3597e-0d79-4498-8d58-5889045c3729"
    Dim SEGURIDAD As String = "d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"
    Dim AGENCIADECARGA As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim ContadorDaeDas As Integer = 0
    Dim DaeAnt As String = "-"

    Public Sub New()
        InitializeComponent()
        With dtDetalleProcesoDecomiso.Columns
            .Add("idProceso", GetType(Guid))
            .Add("idBriefing", GetType(Guid))
            .Add("fecha", GetType(Date))
            .Add("idGuia", GetType(Guid))
            .Add("guia", GetType(String))
            .Add("dae", GetType(String))
            .Add("camion", GetType(String))
            .Add("idChofer", GetType(String))
            .Add("fechaCamion", GetType(String))
            .Add("idElemento", GetType(String))
            .Add("agenciaTransporte", GetType(Guid))
            .Add("agenciaTransporteDescripcion", GetType(String))
            .Add("piezas", GetType(Integer))
            .Add("peso", GetType(Double))
            .Add("volumen", GetType(Double))
            .Add("idProducto", GetType(Guid))
            .Add("descripcionProducto", GetType(String))
            .Add("rx", GetType(Integer))
            .Add("man", GetType(Integer))
            .Add("k9", GetType(Integer))
            .Add("eds", GetType(Integer))
            .Add("AgenciaCamion", GetType(String)) 'Se egrea para poder tener la agencia a la que pertenece el camion registrado 'JRO 01022018
            .Add("descripcionCamion", GetType(String)) 'Se egrea para poder tener la descripcion a la que pertenece el camion registrado 'JRO 01022018
        End With
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If ugvDetalleProcesoDecomiso.Rows.Count < 2 Then
            MessageBox.Show("Debe de Ingresar Por lo Menos un Destinario y un Remitente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If validaInfo() Then
                cargarInfoReporte()
                Dim frm As New RptDecomiso
                frm.DecomisoEncabezado.Add(DecomisoEncabezado)
                frm.DecomisoDetalle = DecomisoEncabezado.decomisoDetalle
                'frm.DecomisoDetalleRemiDesti = DecomisoEncabezadoRemiDesti.decomisoDetalle 'JRO 07082018
                Dim clasPerson As New ClassPersonDeco
                For Each r As DataRow In DtPersonaDecomiso.Rows
                    Dim clasDetallePerson As New ClassDetallePersonDeco
                    clasDetallePerson.id = r.Item("id")
                    clasDetallePerson.DAE = r.Item("DAE") + " de " + r.Item("TotalPRoducto").ToString + IIf(r.Item("TotalPRoducto") <= 1, " producto", " productos")
                    clasDetallePerson.nombre = r.Item("nombre")
                    clasDetallePerson.CI = r.Item("CI")
                    clasDetallePerson.Direccion = r.Item("Direccion")
                    clasDetallePerson.Telefono = r.Item("Telefono")
                    clasDetallePerson.Nacionalidad = r.Item("Nacionalidad")
                    clasDetallePerson.Ciudad = r.Item("Ciudad")
                    clasDetallePerson.Pais = r.Item("Pais")
                    clasDetallePerson.Observacion = r.Item("Observacion")
                    clasDetallePerson.TipoPerson = r.Item("TipoPerson")
                    clasDetallePerson.Total_Producto = r.Item("TotalPRoducto")
                    clasPerson.DetallePersonDeco.Add(clasDetallePerson)
                Next
                frm.PersonDeco = clasPerson
                frm.Show()
            End If
        End If
    End Sub

    Private Sub frmDecomisoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim ItemsGuia As New GuiaItem
            Dim IdProceso As Guid
            For Each r As DataRow In dtDetalleProcesoDecomiso.Rows
                IdProceso = r.Item("idProceso")
                obtenerPersonalPorProceso(r.Item("idProceso").ToString)
                obtenerDetalleProcesoCamiones(r.Item("idProceso").ToString)
                obtenerDetalleProceso(r.Item("idProceso").ToString)
                detalleVuelo = CommonData.GetDetalleVueloPorIdBriefing(r.Item("idBriefing"))
                guiaItem.Id = r.Item("idGuia")
                guiaItem.Descripcion = r.Item("guia")
                guiaItem.Peso = r.Item("peso")
                guiaItem.DescripcionProducto = r.Item("descripcionProducto")
                ItemsGuia = CommonProcess.GetGuiaPorIdGuia(r.Item("idGuia"))
                guiaItem.ciudadDestino = ItemsGuia.ciudadDestino
                guiaItem.Rutas = ItemsGuia.Rutas
                guiaItem.ciudadDestino = CommonProcess.GetGuiaPorIdGuia(r.Item("idGuia")).ciudadDestino 'JRO 01022018
                guiaItem.IdAgencia = r.Item("agenciaTransporte")
                Exit For
            Next
            With DtPersonaDecomiso.Columns
                .Add("id", GetType(Integer))
                .Add("TipoPerson", GetType(String))
                .Add("nombre", GetType(String))
                .Add("CI", GetType(String))
                .Add("Direccion", GetType(String))
                .Add("Telefono", GetType(String))
                .Add("Nacionalidad", GetType(String))
                .Add("Ciudad", GetType(String))
                .Add("Pais", GetType(String))
                .Add("Observacion", GetType(String))
                .Add("DAE", GetType(String))
                .Add("TotalPRoducto", GetType(Integer))
            End With
            ugvDetalleProcesoDecomiso.DataSource = DtPersonaDecomiso
            With DtPersonalFirma.Columns
                .Add("Tipo", GetType(String))
                .Add("Nombre", GetType(String))
            End With
            ugdvPersonalFirma.DataSource = DtPersonalFirma
            Dim combo As New Infragistics.Win.UltraWinEditors.UltraComboEditor
            Dim combo2 As New Infragistics.Win.ValueList
            For Each r As DataRow In CommonProcess.GetDetalleMatrizSeguridadDecoporIdProceso(IdProceso).Rows
                combo2.ValueListItems.Add(r.Item("idContacto"), r.Item("nombre"))
                combo.Items.Add(r.Item("idContacto"), r.Item("nombre"))
            Next
            Dim row As DataRow
            row = DtPersonalFirma.NewRow
            row.Item("Tipo") = "Policia"
            DtPersonalFirma.Rows.Add(row)
            row = DtPersonalFirma.NewRow
            row.Item("Tipo") = "Agencia"
            DtPersonalFirma.Rows.Add(row)
            row = DtPersonalFirma.NewRow
            row.Item("Tipo") = "Seguridad"
            DtPersonalFirma.Rows.Add(row)
            row = DtPersonalFirma.NewRow
            row.Item("Tipo") = "General"
            DtPersonalFirma.Rows.Add(row)
            ugdvPersonalFirma.DisplayLayout.Bands(0).Columns("Nombre").ValueList = combo2
            ugdvPersonalFirma.DisplayLayout.Bands(0).Columns("Nombre").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.SiblingRowsOnly
            SetDisplayedColumnsCaptura()
            cmDae.Items.Add(0, "Seleccione una Dae")
            For Each r As DataRow In dtDetalleProcesoDaeDecomiso.Rows
                cmDae.Items.Add(r.Item("piezas"), r.Item("dae"))
            Next
            cmDae.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerPersonalPorProceso(idProceso As String)
        dtPersonalProceso = CommonProcess.GetDetallePersonalPorIdProcesoReporte(Guid.Parse(idProceso))
    End Sub

    Private Sub obtenerDetalleProcesoCamiones(idProceso As String)
        dtDetalleProcesoCamiones = CommonProcess.GetDetalleProcesoPorIdProcesoReporte(Guid.Parse(idProceso))
    End Sub

    Private Sub obtenerDetalleProceso(idProceso As String)
        dtDetalleProceso = CommonProcess.GetDetalleProcesoPorIdProceso(Guid.Parse(idProceso))
    End Sub

    Private Function validaInfo() As Boolean
        Try
            'If txtIdDest.Text = String.Empty Then
            '    MessageBox.Show("Ingrese Identificación del Destinatario.", "Id", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return False
            'End If
            'If txtIdRem.Text = String.Empty Then
            '    MessageBox.Show("Ingrese Identificación del Remitente.", "Id", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return False
            'End If
            'If txtNombreDest.Text = String.Empty Then
            '    MessageBox.Show("Ingrese Nombre del Destinatario.", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return False
            'End If
            'If txtNombreRem.Text = String.Empty Then
            '    MessageBox.Show("Ingrese Nombre del Remitente.", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return False
            'End If 'JRO 07082018
            Dim count As Integer = DtPersonaDecomiso.Rows.Count 'JRO 07082018
            If (count Mod 2) <> 0 Then
                MessageBox.Show("Debe de Ingrestar un Remitente y un Destinatario por cada Producto", "Remitente Destinatario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function

    Private Sub cargarInfoReporte()
        Dim ls_IdContacto As String = "IdContacto" 'JRO 09022018
        Dim ln_RegistroPersonal As Integer = 0 'JRO 09022018
        Try
            DecomisoEncabezado = New DecomisoEncabezado
            'DecomisoEncabezadoRemiDesti = New DecomisoEncabezado 'JRO 07082018
            DecomisoEncabezado.agenciaVuelo = CommonData.GetAgenciaItem(detalleVuelo.idAgencia).Descripcion
            DecomisoEncabezado.nueroVuelo = detalleVuelo.codigoVuelo
            DecomisoEncabezado.guia = guiaItem.Descripcion
            DecomisoEncabezado.productoGuia = guiaItem.DescripcionProducto
            DecomisoEncabezado.destinoGuia = guiaItem.ciudadDestino
            DecomisoEncabezado.peso = guiaItem.Peso
            DecomisoEncabezado.rutas = guiaItem.Rutas
            For Each r As DataRow In dtDetalleProcesoDecomiso.Rows
                DecomisoEncabezado.placaCamion = r.Item("camion")
                DecomisoEncabezado.horaLlegadaCamion = r.Item("fechaCamion")

                Dim tempContacto As ContactoCatalogItem
                tempContacto = CommonData.GetContactoItem(r.Item("idChofer"))
                DecomisoDetalle = New DecomisoDetalle
                DecomisoDetalle.orden = 5 '4
                DecomisoDetalle.tipo = "TRANSPORTISTA: " & r.Item("AgenciaCamion") & "-" & r.Item("descripcionCamion") & "-" & r.Item("camion")
                DecomisoDetalle.idContacto = tempContacto.idContacto
                DecomisoDetalle.nombreContacto = tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre
                DecomisoDetalle.direccionContacto = tempContacto.direccion
                DecomisoDetalle.ciudadContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombreCiudad
                'DecomisoDetalle.paisContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombrePais 'JRO 01022018
                DecomisoDetalle.telefonoContacto = tempContacto.telefono
                DecomisoDetalle.nacionalidad = ""
                DecomisoDetalle.NoTagsa = tempContacto.tagsa
                DecomisoEncabezado.decomisoDetalle.Add(DecomisoDetalle)
                Exit For
            Next

            For Each r As DataRow In dtPersonalProceso.Rows
                If ls_IdContacto <> r.Item("idContacto") Then ' se ingresa valdidacion para que no se repitan las personas en el reporte JRO 09022018
                    ls_IdContacto = r.Item("idContacto") 'JRO 09022018
                    Dim tempContacto As ContactoCatalogItem
                    tempContacto = CommonData.GetContactoItem(r.Item("idContacto"))
                    DecomisoDetalle = New DecomisoDetalle
                    If r.Item("tipoAgencia").ToString = AEROLINEA Then
                        DecomisoDetalle.orden = 1
                        DecomisoDetalle.tipo = "AEROLINEA: " & r.Item("descripcionAgencia").ToString & " - Vuelo " & detalleVuelo.codigoVuelo
                        ln_RegistroPersonal = 1
                    ElseIf r.Item("tipoAgencia").ToString = AGENCIADECARGA And r.Item("idAgencia") = guiaItem.IdAgencia Then 'determinar la agencia que de carga/transporte que pertenece a la guia JRO 09022018
                        DecomisoDetalle.orden = 2
                        DecomisoDetalle.tipo = "COMPAÑIA DE CARGA: " & r.Item("descripcionAgencia").ToString
                        ln_RegistroPersonal = 1
                    ElseIf r.Item("tipoAgencia").ToString = SEGURIDAD Then
                        DecomisoDetalle.orden = 3
                        DecomisoDetalle.tipo = "COMPAÑIA DE SEGURIDAD: " & r.Item("descripcionAgencia").ToString
                        ln_RegistroPersonal = 1
                    ElseIf r.Item("tipoAgencia").ToString = GENERALAIR Then
                        DecomisoDetalle.orden = 4 '7 'JRO 01022018
                        DecomisoDetalle.tipo = "GENERALAIR"
                        ln_RegistroPersonal = 1
                    ElseIf r.Item("tipoAgencia").ToString = INSTITUCION Then
                        DecomisoDetalle.orden = 0
                        DecomisoDetalle.tipo = "INSTITUCION: " & r.Item("cargo").ToString
                        ln_RegistroPersonal = 1
                    End If
                    If ln_RegistroPersonal > 0 Then
                        'If DecomisoDetalle.tipo = "AGENCIA DE CARGA" Then
                        If r.Item("idAgencia") = guiaItem.IdAgencia Then 'determinar el personal de la agencia que de carga/transporte que pertenece a la guia JRO 09022018
                            DecomisoDetalle.idContacto = tempContacto.idContacto
                            DecomisoDetalle.nombreContacto = tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre
                            DecomisoDetalle.direccionContacto = tempContacto.direccion
                            DecomisoDetalle.ciudadContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombreCiudad
                            'DecomisoDetalle.paisContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombrePais 'JRO 01022018
                            DecomisoDetalle.telefonoContacto = tempContacto.telefono
                            DecomisoDetalle.nacionalidad = ""
                            DecomisoDetalle.obs = ""
                            DecomisoDetalle.NoTagsa = tempContacto.tagsa
                            DecomisoEncabezado.decomisoDetalle.Add(DecomisoDetalle)
                            'End If
                        Else
                            DecomisoDetalle.idContacto = tempContacto.idContacto
                            DecomisoDetalle.nombreContacto = tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre
                            DecomisoDetalle.direccionContacto = tempContacto.direccion
                            DecomisoDetalle.ciudadContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombreCiudad
                            'DecomisoDetalle.paisContacto = CommonData.GetCiudadItem(tempContacto.idCiudad).NombrePais 'JRO 01022018
                            DecomisoDetalle.telefonoContacto = tempContacto.telefono
                            DecomisoDetalle.nacionalidad = ""
                            DecomisoDetalle.obs = ""
                            DecomisoDetalle.NoTagsa = tempContacto.tagsa
                            DecomisoEncabezado.decomisoDetalle.Add(DecomisoDetalle)
                        End If
                        If r.Item("idAgencia").ToString = "d47333f8-1d92-11e4-981b-8f9d682eafe3" Then
                            'DecomisoEncabezado.textoGuia = "El guía " + r.Item("primerApellidoContacto") + " " + r.Item("segundoApellidoContacto") + " " +
                            '                    r.Item("primerNombreContacto") + " con CNI " + r.Item("idContacto") + " con ID de TAGSA " + r.Item("tagsaContacto") +
                            '                    ", procedió a la inspección de la guia número " + guiaItem.Descripcion + "." + vbLf + "Producto declarado: " +
                            '                    guiaItem.DescripcionProducto + ", peso " + guiaItem.Peso.ToString + " kilo(s)" 'JRO 01022018
                            DecomisoEncabezado.textoGuia = "Producto declarado: " +
                                                guiaItem.DescripcionProducto 'JRO 01022018
                            DecomisoEncabezado.rutas = guiaItem.Rutas 'JRO 01022018
                        End If
                    End If
                    ln_RegistroPersonal = 0
                End If
            Next
            'JRO 01022018
            'DecomisoDetalle = New DecomisoDetalle
            'DecomisoDetalle.orden = 6 '5
            'DecomisoDetalle.tipo = "REMITENTE"
            'DecomisoDetalle.idContacto = txtIdRem.Text
            'DecomisoDetalle.nombreContacto = txtNombreRem.Text
            'DecomisoDetalle.direccionContacto = txtDireccionRem.Text
            'DecomisoDetalle.ciudadContacto = txtCiudadRem.Text
            'DecomisoDetalle.paisContacto = txtPaisRem.Text
            'DecomisoDetalle.telefonoContacto = txtTelefonoRem.Text
            'DecomisoDetalle.nacionalidad = txtNacionalidadRem.Text
            'DecomisoDetalle.obs = txtObsRem.Text
            'DecomisoEncabezado.decomisoDetalle.Add(DecomisoDetalle)

            'DecomisoDetalle = New DecomisoDetalle
            'DecomisoDetalle.orden = 7 '6
            'DecomisoDetalle.tipo = "DESTINATARIO"
            'DecomisoDetalle.idContacto = txtIdDest.Text
            'DecomisoDetalle.nombreContacto = txtNombreDest.Text
            'DecomisoDetalle.direccionContacto = txtDireccionDest.Text
            'DecomisoDetalle.ciudadContacto = txtCiudadDest.Text
            'DecomisoDetalle.paisContacto = txtPaisDest.Text
            'DecomisoDetalle.telefonoContacto = txtTelefonoDest.Text
            'DecomisoDetalle.nacionalidad = txtNacionalidadDest.Text
            'DecomisoDetalle.obs = txtObsDest.Text
            'DecomisoEncabezado.decomisoDetalle.Add(DecomisoDetalle)

            'DecomisoEncabezado.descripcionDecomiso = txtDescripcion.Text 
            'JRO 01022018
            'DecomisoDetalle = New DecomisoDetalle
            'DecomisoDetalle.orden = 0 '5
            'DecomisoDetalle.tipo = "REMITENTE"
            'DecomisoDetalle.idContacto = txtIdRem.Text
            'DecomisoDetalle.nombreContacto = txtNombreRem.Text
            'DecomisoDetalle.direccionContacto = txtDireccionRem.Text
            'DecomisoDetalle.ciudadContacto = txtCiudadRem.Text
            'DecomisoDetalle.paisContacto = txtPaisRem.Text
            'DecomisoDetalle.telefonoContacto = txtTelefonoRem.Text
            'DecomisoDetalle.nacionalidad = txtNacionalidadRem.Text
            'DecomisoDetalle.obs = txtObsRem.Text
            'DecomisoEncabezadoRemiDesti.decomisoDetalle.Add(DecomisoDetalle)  'JRO 07082018

            'DecomisoDetalle = New DecomisoDetalle
            'DecomisoDetalle.orden = 1 '6
            'DecomisoDetalle.tipo = "DESTINATARIO"
            'DecomisoDetalle.idContacto = txtIdDest.Text
            'DecomisoDetalle.nombreContacto = txtNombreDest.Text
            'DecomisoDetalle.direccionContacto = txtDireccionDest.Text
            'DecomisoDetalle.ciudadContacto = txtCiudadDest.Text
            'DecomisoDetalle.paisContacto = txtPaisDest.Text
            'DecomisoDetalle.telefonoContacto = txtTelefonoDest.Text
            'DecomisoDetalle.nacionalidad = txtNacionalidadDest.Text
            'DecomisoDetalle.obs = txtObsDest.Text
            'DecomisoEncabezadoRemiDesti.decomisoDetalle.Add(DecomisoDetalle) 'JRO 07082018

            DecomisoEncabezado.descripcionDecomiso = txtDescripcion.Text
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try
            If ugvDetalleProcesoDecomiso.Rows.Count < 2 Then
                MessageBox.Show("Debe de Ingresar Por lo Menos un Destinario y un Remitente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If validaInfo() Then
                    cargarInfoReporte()
                    Dim frm As New RptDecomiso
                    frm.aerolinea = detalleVuelo.descripcionAgencia
                    frm.vuelo = detalleVuelo.codigoVuelo
                    frm.fecha = detalleVuelo.fechaVuelo
                    frm.DecomisoEncabezado.Add(DecomisoEncabezado)
                    frm.DecomisoDetalle = DecomisoEncabezado.decomisoDetalle
                    'frm.DecomisoDetalleRemiDesti = DecomisoEncabezadoRemiDesti.decomisoDetalle 'JRO 07082018
                    frm.idAgenciaReporte = detalleVuelo.idAgencia
                    Dim clasPerson As New ClassPersonDeco
                    For Each r As DataRow In DtPersonaDecomiso.Rows
                        Dim clasDetallePerson As New ClassDetallePersonDeco
                        clasDetallePerson.id = r.Item("id")
                        clasDetallePerson.DAE = r.Item("DAE") + " de " + r.Item("TotalPRoducto").ToString + IIf(r.Item("TotalPRoducto") <= 1, " producto", " productos")
                        clasDetallePerson.nombre = r.Item("nombre")
                        clasDetallePerson.CI = r.Item("CI")
                        clasDetallePerson.Direccion = r.Item("Direccion")
                        clasDetallePerson.Telefono = r.Item("Telefono")
                        clasDetallePerson.Nacionalidad = r.Item("Nacionalidad")
                        clasDetallePerson.Ciudad = r.Item("Ciudad")
                        clasDetallePerson.Pais = r.Item("Pais")
                        clasDetallePerson.Observacion = r.Item("Observacion")
                        clasDetallePerson.TipoPerson = r.Item("TipoPerson")
                        clasDetallePerson.Total_Producto = r.Item("TotalPRoducto")
                        clasPerson.DetallePersonDeco.Add(clasDetallePerson)
                    Next
                    frm.PersonDeco = clasPerson
                    frm.guardarReporte()
                    If frm.result Then
                        MessageBox.Show("Correo eviado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al enviar correo. Por favor reintentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If txtCiudadDest.Text = String.Empty And txtDireccionDest.Text = String.Empty And txtIdDest.Text = String.Empty And txtNacionalidadDest.Text = String.Empty _
            And txtNombreDest.Text = String.Empty And txtObsDest.Text = String.Empty And txtPaisDest.Text = String.Empty And txtTelefonoDest.Text = String.Empty Then
            MessageBox.Show("Debe de Ingresar los Datos del Destinatario")
        ElseIf txtCiudadRem.Text = String.Empty And txtDireccionRem.Text = String.Empty And txtIdRem.Text = String.Empty And txtNacionalidadRem.Text = String.Empty _
            And txtNombreRem.Text = String.Empty And txtObsRem.Text = String.Empty And txtPaisRem.Text = String.Empty And txtTelefonoRem.Text = String.Empty Then
            MessageBox.Show("Debe de Ingresar los Datos del Remitente")
        Else
            If cmDae.Value <> 0 Then
                If DaeAnt <> cmDae.SelectedText Then
                    ContadorDaeDas += 1
                End If
                Dim row As DataRow()
                Dim ingreso As Boolean = False
                For i = 0 To 1
                    ingreso = True
                    row = DtPersonaDecomiso.Select("DAE='" & cmDae.SelectedItem.ToString & "'")
                    If row.Count >= (cmDae.Value * 2) Then
                        ingreso = False
                    End If
                    If ingreso Then
                        Dim r As DataRow
                        If i = 0 Then
                            If ingreso Then
                                r = DtPersonaDecomiso.NewRow
                                r.Item("id") = ContadorDaeDas
                                r.Item("nombre") = txtNombreRem.Text
                                r.Item("CI") = txtIdRem.Text
                                r.Item("Direccion") = txtDireccionRem.Text
                                r.Item("Telefono") = txtTelefonoRem.Text
                                r.Item("Nacionalidad") = txtNacionalidadRem.Text
                                r.Item("Ciudad") = txtCiudadRem.Text
                                r.Item("Pais") = txtPaisRem.Text
                                r.Item("Observacion") = txtObsRem.Text
                                r.Item("TipoPerson") = "REM"
                                r.Item("DAE") = cmDae.SelectedItem.ToString
                                r.Item("TotalPRoducto") = cmDae.Value
                                DtPersonaDecomiso.Rows.Add(r)
                            End If
                        Else
                            r = DtPersonaDecomiso.NewRow
                            r.Item("id") = ContadorDaeDas
                            r.Item("nombre") = txtNombreDest.Text
                            r.Item("CI") = txtIdDest.Text
                            r.Item("Direccion") = txtDireccionDest.Text
                            r.Item("Telefono") = txtTelefonoDest.Text
                            r.Item("Nacionalidad") = txtNacionalidadDest.Text
                            r.Item("Ciudad") = txtCiudadDest.Text
                            r.Item("Pais") = txtPaisDest.Text
                            r.Item("Observacion") = txtObsDest.Text
                            r.Item("TipoPerson") = "DES"
                            r.Item("DAE") = cmDae.SelectedItem.ToString
                            r.Item("TotalPRoducto") = cmDae.Value
                            DtPersonaDecomiso.Rows.Add(r)
                        End If
                    Else
                        MessageBox.Show("Ya Se ingreso todos los Remitentes y Destinatarios Correspondiente a esta DAE")
                        Exit For
                    End If
                Next
                If ingreso Then
                    Dim Total As Integer
                    row = DtPersonaDecomiso.Select("DAE='" & cmDae.SelectedItem.ToString & "'")
                    Total = row.Count
                    If Total > 0 And Total <= 1 Then
                        Total = Total
                    Else
                        Total = Total / 2
                    End If
                    lbTitulo.Text = "Detalle Decomiso de la Guia " + guiaItem.Descripcion + " con la Dae " + cmDae.SelectedItem.ToString + vbLf +
                    "Total de Paquetes Ingresados " + Total.ToString + " de " + cmDae.Value.ToString
                    txtCiudadRem.Text = String.Empty
                    txtDireccionRem.Text = String.Empty
                    txtIdRem.Text = String.Empty
                    txtNacionalidadRem.Text = String.Empty
                    txtNombreRem.Text = String.Empty
                    txtObsRem.Text = String.Empty
                    txtPaisRem.Text = String.Empty
                    txtTelefonoRem.Text = String.Empty
                    txtCiudadDest.Text = String.Empty
                    txtDireccionDest.Text = String.Empty
                    txtIdDest.Text = String.Empty
                    txtNacionalidadDest.Text = String.Empty
                    txtNombreDest.Text = String.Empty
                    txtObsDest.Text = String.Empty
                    txtPaisDest.Text = String.Empty
                    txtTelefonoDest.Text = String.Empty
                End If
                DaeAnt = cmDae.SelectedItem.ToString
            End If
        End If
        If ugvDetalleProcesoDecomiso.Rows.Count > 1 Then
            btnImprimir.Enabled = True
            btnEnviar.Enabled = True
            btnImpriAct.Enabled = True
            btnGuardar.Enabled = True
        End If

    End Sub
    Private Sub btnImpriAct_Click(sender As Object, e As EventArgs) Handles btnImpriAct.Click
        Dim ImprimeReporte As Boolean = True
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdvPersonalFirma.Rows
            If r.Cells("Nombre").Value.ToString = String.Empty Then
                ImprimeReporte = False
                Exit For
            End If
        Next
        If ugvDetalleProcesoDecomiso.Rows.Count < 2 Then
            MessageBox.Show("Debe de Ingresar Por lo Menos un Destinario y un Remitente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If ImprimeReporte Then
                Using frmReport As New RptActEntregaRecep
                    Dim clasPerson As New ClassPersonDeco
                    For Each r As DataRow In DtPersonaDecomiso.Rows
                        Dim clasDetallePerson As New ClassDetallePersonDeco
                        clasDetallePerson.id = r.Item("id")
                        clasDetallePerson.DAE = r.Item("DAE") + " de " + r.Item("TotalPRoducto").ToString + IIf(r.Item("TotalPRoducto") <= 1, " producto", " productos")
                        clasDetallePerson.nombre = r.Item("nombre")
                        clasDetallePerson.CI = r.Item("CI")
                        clasDetallePerson.Direccion = r.Item("Direccion")
                        clasDetallePerson.Telefono = r.Item("Telefono")
                        clasDetallePerson.Nacionalidad = r.Item("Nacionalidad")
                        clasDetallePerson.Ciudad = r.Item("Ciudad")
                        clasDetallePerson.Pais = r.Item("Pais")
                        clasDetallePerson.Observacion = r.Item("Observacion")
                        clasDetallePerson.TipoPerson = r.Item("TipoPerson")
                        clasDetallePerson.Total_Producto = r.Item("TotalPRoducto")
                        clasPerson.DetallePersonDeco.Add(clasDetallePerson)
                    Next
                    frmReport.PersonDeco = clasPerson
                    Dim parametrosDeco As New ClassParametrosDeco
                    parametrosDeco.DescripcionIlicita = txtDescripcion.Text
                    parametrosDeco.DescripcionProducto = guiaItem.DescripcionProducto.Substring(0, InStr(guiaItem.DescripcionProducto, "-") - 1)
                    parametrosDeco.Guia = guiaItem.Descripcion
                    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdvPersonalFirma.Rows
                        If r.Cells("Tipo").Value.ToString = "Policia" Then
                            parametrosDeco.Policia = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "Agencia" Then
                            parametrosDeco.Agencia = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "Seguridad" Then
                            parametrosDeco.Seguridad = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "General" Then
                            parametrosDeco.General = r.Cells("Nombre").Text
                        End If
                    Next
                    frmReport.ParametrosDeco.Add(parametrosDeco)
                    frmReport.ShowDialog()
                End Using
            Else
                MessageBox.Show("Debe Ingresar todo el Personal que estuvo en el Decomiso")
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ImprimeReporte As Boolean = True
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdvPersonalFirma.Rows
            If r.Cells("Nombre").Value.ToString = String.Empty Then
                ImprimeReporte = False
                Exit For
            End If
        Next
        If ugvDetalleProcesoDecomiso.Rows.Count < 2 Then
            MessageBox.Show("Debe de Ingresar Por lo Menos un Destinario y un Remitente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If ImprimeReporte Then
                Using frmReport As New RptActEntregaRecep
                    Dim clasPerson As New ClassPersonDeco
                    For Each r As DataRow In DtPersonaDecomiso.Rows
                        Dim clasDetallePerson As New ClassDetallePersonDeco
                        clasDetallePerson.id = r.Item("id")
                        clasDetallePerson.DAE = r.Item("DAE") + " de " + r.Item("TotalPRoducto").ToString + IIf(r.Item("TotalPRoducto") <= 1, " producto", " productos")
                        clasDetallePerson.nombre = r.Item("nombre")
                        clasDetallePerson.CI = r.Item("CI")
                        clasDetallePerson.Direccion = r.Item("Direccion")
                        clasDetallePerson.Telefono = r.Item("Telefono")
                        clasDetallePerson.Nacionalidad = r.Item("Nacionalidad")
                        clasDetallePerson.Ciudad = r.Item("Ciudad")
                        clasDetallePerson.Pais = r.Item("Pais")
                        clasDetallePerson.Observacion = r.Item("Observacion")
                        clasDetallePerson.TipoPerson = r.Item("TipoPerson")
                        clasDetallePerson.Total_Producto = r.Item("TotalPRoducto")
                        clasPerson.DetallePersonDeco.Add(clasDetallePerson)
                    Next
                    frmReport.PersonDeco = clasPerson
                    Dim parametrosDeco As New ClassParametrosDeco
                    parametrosDeco.DescripcionIlicita = txtDescripcion.Text
                    parametrosDeco.DescripcionProducto = guiaItem.DescripcionProducto.Substring(0, InStr(guiaItem.DescripcionProducto, "-") - 1)
                    parametrosDeco.Guia = guiaItem.Descripcion
                    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdvPersonalFirma.Rows
                        If r.Cells("Tipo").Value.ToString = "Policia" Then
                            parametrosDeco.Policia = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "Agencia" Then
                            parametrosDeco.Agencia = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "Seguridad" Then
                            parametrosDeco.Seguridad = r.Cells("Nombre").Text
                        ElseIf r.Cells("Tipo").Value.ToString = "General" Then
                            parametrosDeco.General = r.Cells("Nombre").Text
                        End If
                    Next
                    frmReport.ParametrosDeco.Add(parametrosDeco)
                    frmReport.idAgenciaReporte = detalleVuelo.idAgencia
                    frmReport.aerolinea = detalleVuelo.descripcionAgencia
                    frmReport.vuelo = detalleVuelo.codigoVuelo
                    frmReport.fecha = detalleVuelo.fechaVuelo
                    frmReport.guardarReporte()
                    If frmReport.result Then
                        MessageBox.Show("Correo eviado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al enviar correo. Por favor reintentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Else
                MessageBox.Show("Debe Ingresar todo el Personal que estuvo en el Decomiso")
            End If
        End If
    End Sub
    Private Sub SetDisplayedColumnsCaptura()
        Try
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("id").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("nombre").Header.Caption = "Nombres"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("TipoPerson").Header.Caption = "Tipo"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("TotalPRoducto").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmDae_SelectionChanged(sender As Object, e As EventArgs) Handles cmDae.SelectionChanged
        If cmDae.SelectedIndex <> 0 Then
            Dim row As DataRow()
            Dim Total As Integer
            row = DtPersonaDecomiso.Select("DAE='" & cmDae.SelectedItem.ToString & "'")
            Total = row.Count
            If Total > 0 And Total <= 1 Then
                Total = Total
            Else
                Total = Total / 2
            End If
            lbTitulo.Text = "Detalle Decomiso de la Guia " + guiaItem.Descripcion + " con la Dae " + cmDae.SelectedItem.ToString + vbLf +
                "Total de Paquetes Ingresados " + Total.ToString + " de " + cmDae.Value.ToString
        Else
            lbTitulo.Text = "Detalle Decomiso de la Guia " + guiaItem.Descripcion

        End If
    End Sub

    Private Sub ugvDetalleProcesoDecomiso_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvDetalleProcesoDecomiso.DoubleClickCell
        If ugvDetalleProcesoDecomiso.ActiveRow.Cells("TipoPerson").Value = "REM" Then
            txtCiudadRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Ciudad").Value
            txtDireccionRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Direccion").Value
            txtIdRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("CI").Value
            txtNacionalidadRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Nacionalidad").Value
            txtNombreRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("nombre").Value
            txtObsRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Observacion").Value
            txtPaisRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Pais").Value
            txtTelefonoRem.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Telefono").Value
        ElseIf ugvDetalleProcesoDecomiso.ActiveRow.Cells("TipoPerson").Value = "DES" Then
            txtCiudadDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Ciudad").Value
            txtDireccionDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Direccion").Value
            txtIdDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("CI").Value
            txtNacionalidadDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Nacionalidad").Value
            txtNombreDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("nombre").Value
            txtObsDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Observacion").Value
            txtPaisDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Pais").Value
            txtTelefonoDest.Text = ugvDetalleProcesoDecomiso.ActiveRow.Cells("Telefono").Value
        End If
    End Sub

    Private Sub btnLimpRem_Click(sender As Object, e As EventArgs)
        txtCiudadRem.Text = String.Empty
        txtDireccionRem.Text = String.Empty
        txtIdRem.Text = String.Empty
        txtNacionalidadRem.Text = String.Empty
        txtNombreRem.Text = String.Empty
        txtObsRem.Text = String.Empty
        txtPaisRem.Text = String.Empty
        txtTelefonoRem.Text = String.Empty
    End Sub

    Private Sub btnLimpDes_Click(sender As Object, e As EventArgs)
        txtCiudadDest.Text = String.Empty
        txtDireccionDest.Text = String.Empty
        txtIdDest.Text = String.Empty
        txtNacionalidadDest.Text = String.Empty
        txtNombreDest.Text = String.Empty
        txtObsDest.Text = String.Empty
        txtPaisDest.Text = String.Empty
        txtTelefonoDest.Text = String.Empty
    End Sub

    Private Sub ugvDetalleProcesoDecomiso_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvDetalleProcesoDecomiso.AfterRowsDeleted
        If ugvDetalleProcesoDecomiso.Rows.Count < 2 Then
            btnImprimir.Enabled = False
            btnEnviar.Enabled = False
            btnImpriAct.Enabled = False
            btnGuardar.Enabled = False
        End If
    End Sub
End Class