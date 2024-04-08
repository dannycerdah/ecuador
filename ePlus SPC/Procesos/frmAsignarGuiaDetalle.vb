Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.MessagesManager
Public Class frmAsignarGuiaDetalle
    Dim dtCamiones As New DataTable("Camiones")
    Dim dtGuiaCamiones As New DataTable("Camiones")
    Dim dtGuiaDaes As New DataTable("Daes")
    Dim myGuia As New GuiaItem
    Dim myGuiaCamiones As New GuiaCamionesItem
    Dim myGuiaDaes As New GuiaDaesItem
    Dim idEcuador As String = "6CCEB81A-4F97-454D-9A29-A58614058F19"
    Dim idTransportistaIndependiente As Guid = Guid.Parse("d06e6558-f5a9-11e3-b0b8-d43d7eb25e94")
    Dim stringDAE As String = String.Empty
    Dim myValidezDae As New ValidezDae
    Dim myValidezDae2 As New ValidezDae
    Dim dtValidezDae As DataTable
    Dim dtProducto As New DataTable("Productos")
    Dim lbVerificaRem As Boolean = False
    Dim RemActivo As Boolean = False


    Public Sub New(ByVal Guia As GuiaItem)
        InitializeComponent()
        myGuia = Guia
    End Sub

    Private Sub frmAsignarGuiaDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'ini Jordan Rodriguez 18/07/2022
            'Se modifica metodo para que valide un parametro si el rem esta vijente
            'con el fin de ver si en el restro de la funcionalidad de la pantalla
            'se debe considerar el rem en su proceso
            Dim dtParametros As DataTable
            dtParametros = CommonProcess.GetParametro("VALIDA_REM")
            For Each r As DataRow In dtParametros.Rows
                If r.Item("estado") = "A" Then
                    RemActivo = True
                    Exit For
                End If
            Next
            'fin Jordan Rodriguez 18/07/2022
            myGuiaCamiones.idGuia = myGuia.Id
            myGuiaCamiones.fecha = Date.Now
            myGuiaDaes.idGuia = myGuia.Id
            With dtGuiaCamiones.Columns
                .Add("idGuia", GetType(Guid))
                .Add("idAgencia", GetType(Guid))
                .Add("agencia", GetType(String))
                .Add("idCamion", GetType(Guid))
                .Add("matricula", GetType(String))
                .Add("fecha", GetType(DateTime))
                .Add("idContacto", GetType(String))
                .Add("nombreContacto", GetType(String))
                .Add("apellidoContacto", GetType(String))
                .Add("procedencia", GetType(String))
                .Add("temperatura", GetType(Integer))
                .Add("presinto", GetType(String))
                .Add("descripcionTipo", GetType(String))
                .Add("descripcionMaterial", GetType(String))
                .Add("indice", GetType(Guid))
            End With

            With dtGuiaDaes.Columns
                .Add("idGuia", GetType(Guid))
                .Add("dae", GetType(String))
                .Add("fecha", GetType(DateTime))
                .Add("estado", GetType(String))
                .Add("usuarioCreacion", GetType(String))
                .Add("NumRem", GetType(String))
                .Add("fechavigenciaRem", GetType(DateTime))
            End With

            FillUgvCamiones()
            FillUgvDaes()
            'guille  por exporexpress
            If My.Settings.LoginEmpr = 2 Then
                txtDae.Text = "00000000000000000"
                txtDae.Enabled = False
                'ugbDAE.Enabled = False
            End If

            txtGuia.Text = myGuia.Descripcion
            txtAgencia.Text = myGuia.DescripcionAgencia
            cargarComboAgencia()
            populateUceCamiones(uceAgenciaTransporte.Value)
            cargarComboProcedencia()
            cargarComboTipoEnvase()
            cargarComboMaterialEnvase()
            ObtenerPartida()
            If ModuloCierre.EndHilo = False Then
                ModuloCierre.InicioEjecucion = Date.Now
                ModuloCierre.EjecutaHiloVerificacion()
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarComboAgencia()
        uceAgenciaTransporte.Items.Clear()
        For Each r As DataRow In CommonData.GetAgenciaPorTipo("e4bc6f72-6aee-42e0-a060-6cab35ab8867").Rows
            uceAgenciaTransporte.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgenciaTransporte.SelectedIndex = 0
    End Sub

    Private Sub cargarComboProcedencia()
        Try
            uceProcedencia.Items.Clear()
            For Each r As DataRow In CommonData.GetCiudadPorIdPais(idEcuador).Rows
                uceProcedencia.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
            Next
            uceProcedencia.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub setDisplayColumnCamiones()
        Try
            ugvCamiones.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvCamiones.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvCamiones.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia de Carga"
            ugvCamiones.DisplayLayout.Bands(0).Columns("idCamion").Hidden = True
            ugvCamiones.DisplayLayout.Bands(0).Columns("matricula").Header.Caption = "Matricula Camión"
            ugvCamiones.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
            ugvCamiones.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
            ugvCamiones.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugvCamiones.DisplayLayout.Bands(0).Columns("nombreContacto").Header.Caption = "Nombre"
            ugvCamiones.DisplayLayout.Bands(0).Columns("apellidoContacto").Header.Caption = "Apellido"
            ugvCamiones.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvCamiones.DisplayLayout.Bands(0).Columns("procedencia").Header.Caption = "Procedencia"
            ugvCamiones.DisplayLayout.Bands(0).Columns("temperatura").Header.Caption = "°C"
            ugvCamiones.DisplayLayout.Bands(0).Columns("presinto").Header.Caption = "Presinto"
            ugvCamiones.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Tipo Envase"
            ugvCamiones.DisplayLayout.Bands(0).Columns("descripcionMaterial").Header.Caption = "Material Envase"
            ugvCamiones.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub setDisplayColumnDaes()
        Try
            ugvDae.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvDae.DisplayLayout.Bands(0).Columns("dae").Header.Caption = "DAE"
            ugvDae.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
            ugvDae.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
            ugvDae.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvDae.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
            ugvDae.DisplayLayout.Bands(0).Columns("usuarioCreacion").Hidden = True
            ugvDae.DisplayLayout.Bands(0).Columns("fechavigenciaRem").Format = "dd/MM/yyyy HH:mm:ss"
            ugvDae.DisplayLayout.Bands(0).Columns("fechavigenciaRem").Header.Caption = "Fecha Vigencia REM"
            ugvDae.DisplayLayout.Bands(0).Columns("fechavigenciaRem").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'ini Jordan Rodriguez 18/07/2022
            'Se modifica metodo para que valdie en base a la variable RemActivo si se debe o no mostrar en el GRID
            'Las columnas referente al REM
            If RemActivo <> True Then
                ugvDae.DisplayLayout.Bands(0).Columns("fechavigenciaRem").Hidden = True
                ugvDae.DisplayLayout.Bands(0).Columns("NumRem").Hidden = True
            End If
            'fin Jordan Rodriguez 18/07/2022
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub populateUceCamiones(idAgencia As Guid)
        Try
            dtCamiones.Rows.Clear()
            dtCamiones = CommonData.GetCamionPorIdAgencia(idAgencia)
            uceCamion.Items.Clear()
            uceCamion.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In dtCamiones.Rows
                uceCamion.Items.Add(r.Item("idCamion"), r.Item("matriculaCamion"))
            Next
            uceCamion.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevoCamion_Click(sender As Object, e As EventArgs) Handles btnNuevoCamion.Click
        Using frmDetails As New frmCamionDetails(True)
            frmDetails.ShowDialog()
        End Using
        populateUceCamiones(uceAgenciaTransporte.Value)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea Guardar este registro?"
        Dim msgc As String = "Registro Guardado con éxito."
        Try
            'If txtDae.Text.ToString = "" Then
            '    MessageBox.Show("Ingrese el Número de DAE.", "DAE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            If uceProcedencia.Text = "" Then
                MessageBox.Show("Ingrese la Procedencia del Camión.", "Procedencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtContacto.Text = "" Then
                MessageBox.Show("Ingrese el Chofer del Camión.", "Chofer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceCamion.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja el Camión.", "Camión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                DetalleGuiaCamionInfoToObject()
                If ValidaInfoGuiaCamion() Then
                    req.myGuiaCamionesItem = myGuiaCamiones
                    res = wsClnt.SaveGuiaCamionesItem(req)
                    If res.ActionResult Then

                        ''ESTA LINEA ESTA COMENTADA FUE HABILITADA EL 20 DE ABRIL DEL 2016
                        ''**********************************************************************************
                        stringDAE = txtDae.Text.Trim
                        myGuia.DAE = stringDAE
                        SaveGuia()

                        '**********************************************************************************

                        MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FillUgvCamiones()
                    Else
                        Throw New Exception(res.ErrorMessage)
                    End If
                Else
                    MessageBox.Show("El Camión selecciondo ya está asignado a esta Guia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SaveGuia()
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New Server.VuelosService.VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaItem = myGuia
            res = wsClnt.SaveGuiaItem(req)
            If Not res.ActionResult Then
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Function ValidaInfoGuiaCamion()
        Dim result As Boolean = True
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvCamiones.Rows
            If r.Cells("idCamion").Value = myGuiaCamiones.idCamion Then
                result = False
            End If
        Next
        Return result
    End Function

    Private Function ValidaInfoGuiaDae()
        Dim result As Boolean = True
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvDae.Rows
            If r.Cells("dae").Value = myGuiaDaes.dae Then
                result = False
            End If
            If myGuiaDaes.dae = String.Empty Then
                result = False
            End If
        Next
        Return result
    End Function

    Private Sub DetalleGuiaCamionInfoToObject()
        Try
            myGuiaCamiones.idGuia = myGuia.Id
            myGuiaCamiones.idCamion = uceCamion.Value
            myGuiaCamiones.fecha = Date.Now
            myGuiaCamiones.idContacto = txtContacto.Tag
            myGuiaCamiones.procedencia = uceProcedencia.Text
            myGuiaCamiones.temperatura = txtTemperatura.Value
            myGuiaCamiones.presinto = txtPresinto.Text
            myGuiaCamiones.bultos = txtBultos.Value
            myGuiaCamiones.idBriefing = myGuia.idBriefing
            myGuiaCamiones.idTipoEnvase = uceTipoEnvase.Value
            myGuiaCamiones.idMaterialEnvase = uceMaterialEnvase.Value
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DetalleGuiaDaeInfoToObject()
        Try
            myGuiaDaes.idGuia = myGuia.Id
            myGuiaDaes.dae = txtDae.Text.Trim
            myGuiaDaes.fecha = Date.Now
            myGuiaDaes.estado = txtEstado.Text
            myGuiaDaes.usuarioCreacion = MyCurrentUser.userName
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillUgvCamiones()
        Try
            dtGuiaCamiones.Clear()
            Dim nr As DataRow
            For Each r As DataRow In CommonProcess.GetGuiaCamionesPorId(myGuiaCamiones).Rows
                nr = dtGuiaCamiones.NewRow
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("idAgencia") = r.Item("idAgencia")
                nr.Item("agencia") = r.Item("agencia")
                nr.Item("idCamion") = r.Item("idCamion")
                nr.Item("matricula") = r.Item("matriculaCamion")
                nr.Item("idContacto") = r.Item("idContacto")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("nombreContacto") = r.Item("primerNombreContacto")
                nr.Item("apellidoContacto") = r.Item("primerApellidoContacto")
                nr.Item("procedencia") = r.Item("procedencia")
                nr.Item("temperatura") = r.Item("temperatura")
                nr.Item("presinto") = r.Item("presinto")
                nr.Item("descripcionTipo") = r.Item("descripcionTipo")
                nr.Item("descripcionMaterial") = r.Item("descripcionMaterial")
                nr.Item("indice") = r.Item("indice")
                dtGuiaCamiones.Rows.Add(nr)
            Next
            ugvCamiones.DataSource = dtGuiaCamiones
            setDisplayColumnCamiones()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillUgvDaes()
        Try
            dtGuiaDaes.Clear()
            Dim nr As DataRow
            For Each r As DataRow In CommonProcess.GetGuiaDaesPorIdGuia(myGuiaDaes).Rows
                nr = dtGuiaDaes.NewRow
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("dae") = r.Item("dae")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("estado") = r.Item("estado")
                nr.Item("usuarioCreacion") = r.Item("usuarioCreacion")
                nr.Item("NumRem") = r.Item("NumRem")
                nr.Item("fechavigenciaRem") = r.Item("fechavigenciaRem")
                dtGuiaDaes.Rows.Add(nr)
            Next
            ugvDae.DataSource = dtGuiaDaes
            setDisplayColumnDaes()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCamiones_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvCamiones.AfterRowsDeleted
        DeleteDetalleProceso()
    End Sub

    Private Sub ugvCamiones_ClickCell(sender As Object, e As EventArgs) Handles ugvCamiones.ClickCell
        myGuiaCamiones = New GuiaCamionesItem
        If ugvCamiones.ActiveRow.Cells("indice").Value <> Guid.Empty Then
            myGuiaCamiones.indice = ugvCamiones.ActiveRow.Cells("indice").Value
        End If
    End Sub

    Private Function DeleteDetalleProceso() As Boolean
        Dim result = False
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim WsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaCamionesItem = myGuiaCamiones
            res = WsClnt.DeleteGuiaCamion(req)
            If res.ActionResult Then
                If lbVerificaRem Then
                    res = WsClnt.DeleteHistoricoDaesRem(req)
                    If res.ActionResult Then
                        Throw New Exception(res.ErrorMessage)
                    End If
                End If
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function DeleteDetalleDae() As Boolean
        Dim result = False
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim WsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            req.myGuiaDaesItem = myGuiaDaes
            res = WsClnt.DeleteGuiaDae(req)
            If res.ActionResult Then
                If lbVerificaRem Then
                    res = WsClnt.DeleteHistoricoDaesRem(req)
                    If res.ActionResult = False Then
                        Throw New Exception(res.ErrorMessage)
                    End If
                End If
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub btnContacto_Click(sender As Object, e As EventArgs) Handles btnContacto.Click
        Try
            Dim frmContactoCamion As New frmContactoCamion
            frmContactoCamion.ShowDialog()
            If frmContactoCamion.contacto.idContacto <> String.Empty Then
                txtContacto.Clear()
                txtContacto.Tag = frmContactoCamion.contacto.idContacto
                txtContacto.Text = frmContactoCamion.contacto.primerApellido + " " + frmContactoCamion.contacto.primerNombre
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uceAgenciaTransporte_SelectionChanged(sender As Object, e As EventArgs) Handles uceAgenciaTransporte.SelectionChanged
        populateUceCamiones(uceAgenciaTransporte.Value)
    End Sub

    Private Sub cargarComboTipoEnvase()
        Try
            uceTipoEnvase.Clear()
            For Each r In CommonProcess.GetTipoEnvase.Rows
                uceTipoEnvase.Items.Add(r.item("idTipo"), r.item("descripcionTipo"))
            Next
            uceTipoEnvase.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarComboMaterialEnvase()
        Try
            uceMaterialEnvase.Items.Clear()
            For Each r In CommonProcess.GetMaterialEnvase.Rows
                uceMaterialEnvase.Items.Add(r.item("idMaterial"), r.item("descripcionMaterial"))
            Next
            uceMaterialEnvase.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDae_AfterExitEditMode(sender As Object, e As EventArgs) Handles txtDae.AfterExitEditMode
        validaDae()
    End Sub

    Private Sub validaDae()
        Dim strDate As String = String.Empty
        Dim strD() As String
        Dim strEstado As String = String.Empty
        If txtDae.Text <> String.Empty And txtDae.Text.Length = 17 Then
            Try
                dtValidezDae = SearchDAE(txtDae.Text)
                If Not IsNothing(dtValidezDae) Then
                    If dtValidezDae.Rows.Count > 0 Then
                        For Each r As DataRow In dtValidezDae.Rows
                            strEstado = r.Item("ExaminerName")
                            strDate = r.Item("effectiveEndDate").ToString
                            'strD = Split(strDate, "/")
                            'strDate = strD(0) & "/" & strD(1) & "/" & strD(2)
                            If strDate >= Now.Date Then
                                If strEstado <> String.Empty Then
                                    MessageBox.Show("El número de Dae es Válido y el Estado es: " & strEstado, "DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    strEstado = "NO TIENE ESTADO"
                                    MessageBox.Show("El número de Dae es Válido y el Estado es: " & strEstado, "DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                txtEstado.Text = strEstado
                            Else
                                strEstado = "NÚMERO DE DAE VENCIDO"
                                MessageBox.Show("El número de Dae está vencido y el Estado es: " & strEstado, "DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtEstado.Text = strEstado
                            End If
                            If lbVerificaRem = True Then
                                If Not IsDBNull(r.Item("RemNumber")) Then
                                    Dim posisicon As Integer
                                    Dim dia As String
                                    Dim mes As String
                                    Dim anohhmmss As String
                                    Dim cadenanormal As String = r.Item("RemEndVigency")
                                    Dim tamanoCadena As Integer
                                    Dim ini As Integer
                                    Dim fin As Integer
                                    posisicon = InStr(r.Item("RemEndVigency"), "/")
                                    dia = r.Item("RemEndVigency").ToString.Substring(0, posisicon - 1)
                                    tamanoCadena = Len(cadenanormal)
                                    cadenanormal = cadenanormal.Substring(posisicon, (tamanoCadena - posisicon))
                                    posisicon = InStr(cadenanormal, "/")
                                    mes = cadenanormal.Substring(0, posisicon - 1)
                                    tamanoCadena = Len(cadenanormal)
                                    cadenanormal = cadenanormal.Substring(posisicon, (tamanoCadena - posisicon))
                                    cadenanormal = mes & "/" & dia & "/" & cadenanormal
                                    If Not IsDBNull(r.Item("RemEndVigency")) Then
                                        myValidezDae2.fechavigenciaRem = DateTime.Parse(cadenanormal)
                                        myValidezDae2.NumRem = r.Item("RemNumber")
                                    End If
                                End If
                            End If
                            myValidezDae2.numeroDae = txtDae.Text
                        Next
                        If RemActivo Then
                            If lbVerificaRem = True And myValidezDae2.NumRem <> String.Empty Then
                                Dim Tiempo As TimeSpan = myValidezDae2.fechavigenciaRem.Subtract(Now)
                                Dim Hora As Integer = Tiempo.Hours
                                If Hora <= 1 Then
                                    MessageBox.Show("El REM asociado a la DAE esta a punto de caducar : " & myValidezDae2.fechavigenciaRem.ToString, "DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            ElseIf lbVerificaRem = True And myValidezDae2.NumRem = String.Empty Then
                                MessageBox.Show("La Dae no tiene un REM vigente por favor comunicarse con la Agencia : ", "DAE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                    MessageBox.Show("El número de Dae ingresado NO existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEstado.Text = "DAE No existe"
                End If
                Else
                MessageBox.Show("El número de Dae ingresado NO existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEstado.Text = "DAE No existe"
                End If
        'End If
            Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Else
            MessageBox.Show("El número de Dae es Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSaveDae_Click(sender As Object, e As EventArgs) Handles btnSaveDae.Click
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Try
            General.SetBARequest(req)
            DetalleGuiaDaeInfoToObject()
            If myGuiaDaes.dae = myValidezDae2.numeroDae And lbVerificaRem = True Then
                myGuiaDaes.NumRem = If(IsNothing(myValidezDae2.NumRem) Or (myValidezDae2.NumRem = String.Empty), "000000000000000000", myValidezDae2.NumRem)
                myGuiaDaes.fechavigenciaRem = If(IsNothing(myValidezDae2.fechavigenciaRem), Nothing, myValidezDae2.fechavigenciaRem)
            End If
            If ValidaInfoGuiaDae() Then
                req.myGuiaDaesItem = myGuiaDaes
                res = wsClnt.SaveGuiaDaesItem(req)
                If res.ActionResult Then
                    If lbVerificaRem Then
                        res = wsClnt.SaveHistoricoDaesRem(req)
                        If res.ActionResult = False Then
                            Throw New Exception(res.ErrorMessage)
                        End If
                        myValidezDae2.numeroDae = String.Empty
                        myValidezDae2.NumRem = String.Empty
                    End If
                    FillUgvDaes()
                    lbVerificaRem = False
                Else
                    lbVerificaRem = False
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                lbVerificaRem = False
                If myGuiaDaes.dae = String.Empty Then
                    MessageBox.Show("El Campo DAE no puede ser Null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("La DAE seleccionada ya está asignada a esta Guia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvDae_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvDae.AfterRowActivate
        Try
            myGuiaDaes.idGuia = ugvDae.ActiveRow.Cells("idGuia").Value
            myGuiaDaes.dae = ugvDae.ActiveRow.Cells("dae").Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvDae_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvDae.AfterRowsDeleted
        Try
            If DeleteDetalleDae() Then
                MessageBox.Show("Registro eliminado con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub ObtenerPartida()
        Try
            Dim dtParametros As New DataTable("Parametros")
            Dim rows As DataRow()
            Dim partida As String
            dtProducto = CommonProcess.GetGuiaProductoPorIdGuia(myGuia.Id)
            If Not IsNothing(dtProducto) Then
                dtParametros = CommonProcess.GetParametro("PartidasAreanCelarias")
                If dtProducto.Rows.Count > 0 Then
                    For Each r As DataRow In dtProducto.Rows
                        partida = r.Item("descripcionProducto").ToString.Replace(".", "")
                        partida = partida.Replace(" ", "")
                        partida = partida.Substring(0, 4)
                        If Not IsNothing(dtParametros) Then
                            rows = dtParametros.Select("prmTexto='" & partida & "' and estado='S'")
                            If rows.Count > 0 And RemActivo Then
                                lbVerificaRem = True
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub frmAsignarGuiaDetalle_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmAsignarGuiaDetalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmAsignarGuiaDetalle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ModuloCierre.EndHilo = False
    End Sub


End Class