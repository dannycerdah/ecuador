Imports SPC.Server.ReportService
Public Class frmElementoDetails
    Public Property myElemento As New ElementoCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewElemento As Boolean = False
    Dim tempId As String = String.Empty

    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"

    Dim container1 As String = "2a6110b4-fb0c-4f70-a95b-390563335ec8"
    Dim container2 As String = "e257c7da-f37d-41bf-91c6-45f6d47f898c"
    Dim container3 As String = "955475e1-0679-4dd3-9fbd-6ffeeaf490a5"
    Dim sbo As String = "9fd1c2ea-fe3c-4cba-a6bc-c915120d430f"
    Dim bav As String = "08a999e8-74c0-42aa-a29f-d77b8d284e20"
    Dim isTipoEdit As Boolean = False
    Dim dtTipoElemento As DataTable
    Dim usuarioRequiere As New Server.ReportService.ContactoCatalogItem

    Private Sub InitializeValues()
        myElemento.Id = ""
        myElemento.IdAgencia = Guid.Empty
        myElemento.descripcionAgencia = ""
        myElemento.materialPiso = ""
        myElemento.materialPared = ""
        myElemento.materialTecho = ""
        ' myElemento.materialRed = ""
        myElemento.materialPuerta = ""
        myElemento.materialSeguros = ""
        myElemento.alto = 0D
        myElemento.ancho = 0D
        myElemento.largo = 0D
        myElemento.pesoReferencial = 0D
        myElemento.pesoReal = 0D
        myElemento.estado = ""
        myElemento.usuarioIngreso = ""
        myElemento.fechaUltimaAct = DateTime.Now
    End Sub

    Public Sub New(ByVal myElementoItem As ElementoCatalogItem)
        InitializeComponent()
        InitializeValues()
        myElemento = myElementoItem
    End Sub

    Public Sub New(MustCreateNewElemento As Boolean)
        InitializeComponent()
        InitializeValues()
        myElemento.Id = String.Empty
        IsNewElemento = True
    End Sub

    Public Sub New(ByVal ElementoId As String)
        InitializeComponent()
        InitializeValues()
        myElemento = CommonData.GetElementoItem(ElementoId)
    End Sub

    Private Sub frmElementoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillElementoInfo()
        usuarioRequiere = CommonData.GetContactoItem(MyCurrentUser.userName)
    End Sub

    Private Sub FillElementoInfo()

        If Not IsNewElemento Then
            tempId = myElemento.Id
            txtCodigo.Text = myElemento.Id
            txtAlto.Value = myElemento.alto
            txtAncho.Value = myElemento.ancho
            txtLargo.Value = myElemento.largo
            txtPeso.Value = myElemento.pesoReal
            txtPesoRef.Value = myElemento.pesoReferencial
        End If


        dtTipoElemento = CommonData.GetTipoElementoCatalog()
        uceTipo.Items.Clear()
        uceTipo.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In dtTipoElemento.Rows
            uceTipo.Items.Add(r.Item("idTipo"), r.Item("codigo") + " " + r.Item("descripcionTipo"))
            '  cmbaver.Items.Add(r.Item("abreviatura"))
        Next

        uceAerolinea.Items.Clear()
        uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")

        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX)).Rows
            uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next


        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX)).Rows
            If r.Item("abreviatura") <> "" Then
                cmbaver.Items.Add(r.Item("abreviatura"))
            End If
        Next
        cmbaver.SelectedIndex = 0

        If Not IsNewElemento Then
            For i As Integer = 0 To uceAerolinea.Items.Count - 1
                uceAerolinea.SelectedIndex = i
                If uceAerolinea.Value = myElemento.IdAgencia Then
                    Exit For
                End If
            Next
        Else
            uceAerolinea.SelectedIndex = 0
        End If



        uceTipo.SelectedIndex = 0
        If Not IsNewElemento Then
            For i As Integer = 0 To uceTipo.Items.Count - 1
                uceTipo.SelectedIndex = i
                If uceTipo.Value = myElemento.tipoElemento Then
                    Exit For
                End If
            Next
        End If

        uceEstado.Items.Clear()
        'uceEstado.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetEstadoElemento().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
        If Not IsNewElemento Then
            For i As Integer = 0 To uceEstado.Items.Count - 1
                uceEstado.SelectedIndex = i
                If uceEstado.Value.ToString = myElemento.estado Then
                    Exit For
                End If
            Next
        End If
        If Not IsNewElemento Then
            txtCodigo.Text = myElemento.Id
            txtAlto.Value = myElemento.alto
            txtAncho.Value = myElemento.ancho
            txtLargo.Value = myElemento.largo
            txtPeso.Value = myElemento.pesoReal
            txtPesoRef.Value = myElemento.pesoReferencial
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New ElementoRequest
        Dim res As New ElementoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtCodigo.Text = "" Then
                MessageBox.Show("Ingrese el Código del Elemento.", "Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtNum.Text = "" Then
                MessageBox.Show("Ingrese la Numeración del Elemento.", "Numeración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtAlto.Text = "" Then
                MessageBox.Show("Ingrese Alto del Elemento.", "Alto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtAncho.Text = "" Then
                MessageBox.Show("Ingrese Ancho del Elemento.", "Ancho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtLargo.Text = "" Then
                MessageBox.Show("Ingrese Largo del Elemento.", "Largo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtPeso.Text = "" Then
                MessageBox.Show("Ingrese Peso del Elemento.", "Peso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceAerolinea.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja Aerolinea del Elemento.", "Aeroliena", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If String.Compare(uceTipo.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja Tipo del Elemento.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If String.Compare(uceEstado.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja un estado.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Not isTipoEdit Then
                If String.Compare(txtPiso.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Piso del Elemento.", "Piso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If String.Compare(txtPared.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Pared del Elemento.", "Pared", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If String.Compare(txtTecho.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Techo del Elemento.", "Techo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If String.Compare(txtRed.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Red del Elemento.", "Red", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If String.Compare(txtPuerta.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Puerta del Elemento.", "Puerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If String.Compare(txtSeguros.Text, "Escoja una Opción") = 0 Then
                    MessageBox.Show("Escoja Material Seguros del Elemento.", "Seguros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If IsNewElemento Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                ElementoInfoToObject()
                req.myElementoItem = myElemento
                res = wsClnt.SaveElementoInfo(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Try
                        Dim r As Boolean
                        Dim elementoHistorico As New ElementoHistoricoItem
                        elementoHistorico.Id = Guid.NewGuid
                        elementoHistorico.idElemento = myElemento.Id
                        elementoHistorico.pesoElemento = myElemento.pesoReal
                        elementoHistorico.estadoElemento = myElemento.estado
                        If IsNewElemento Then
                            elementoHistorico.tipoRegistro = "CRE"
                        Else
                            elementoHistorico.tipoRegistro = "MOD"
                        End If
                        elementoHistorico.fecha = DateTime.Now
                        elementoHistorico.usuario = MyCurrentUser.userName
                        elementoHistorico.idProceso = Guid.Empty
                        elementoHistorico.idVuelo = Guid.Empty
                        r = CommonData.SaveElementoHistorico(elementoHistorico)
                    Catch ex As Exception
                        ErrorManager.SetLogEvent(ex)
                    End Try
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub ElementoInfoToObject()
        Try
            If IsNewElemento Then
                myElemento.Id = txtCodigo.Text.Trim
                myElemento.fechaIngreso = DateTime.Now
            End If
            myElemento.pesoReferencial = txtPesoRef.Value
            myElemento.tempId = txtCodigo.Text.Trim
            myElemento.IdAgencia = uceAerolinea.Value
            myElemento.tipoElemento = uceTipo.Value
            If Not isTipoEdit Then
                myElemento.materialPiso = txtPiso.Text
                myElemento.materialPared = txtPared.Text
                myElemento.materialTecho = txtTecho.Text
                myElemento.materialRed = txtRed.Text
                myElemento.materialPuerta = txtPuerta.Text
                myElemento.materialSeguros = txtSeguros.text
            End If
            myElemento.alto = txtAlto.Value
            myElemento.ancho = txtAncho.Value
            myElemento.largo = txtLargo.Value
            myElemento.pesoReal = txtPeso.Value
            myElemento.estado = uceEstado.Value
            myElemento.usuarioIngreso = MyCurrentUser.userName
            myElemento.fechaUltimaAct = DateTime.Now
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub uceTipo_SelectionChanged(sender As Object, e As EventArgs) Handles uceTipo.SelectionChanged
        Try
            For Each r As DataRow In dtTipoElemento.Rows
                If uceTipo.Value = r.Item("idTipo") Then
                    If r.Item("materialPiso") <> String.Empty Then
                        txtPiso.Text = r.Item("materialPiso")
                    End If
                    If r.Item("materialPared") <> String.Empty Then
                        txtPared.Text = r.Item("materialPared")
                    End If
                    If r.Item("materialTecho") <> String.Empty Then
                        txtTecho.Text = r.Item("materialTecho")
                    End If
                    'If r.Item("materialRed") <> String.Empty Then
                    '    txtRed.Text = r.Item("materialRed")
                    'End If
                    If r.Item("materialPuerta") <> String.Empty Then
                        txtPuerta.Text = r.Item("materialPuerta")
                    End If
                    'If r.Item("materialSeguros") <> String.Empty Then
                    '    txtSeguros.Text = r.Item("materialSeguros")
                    'End If
                    txtAncho.Value = r.Item("ancho")
                    txtLargo.Value = r.Item("largo")
                    txtAlto.Value = r.Item("alto")
                    txtPesoRef.Value = r.Item("pesoReferencial")
                    txtPeso.Value = r.Item("pesoreal")

                    'If r.Item("codigo") <> String.Empty Then
                    '    txtCodigo.Text = txtCodigo.Text.Insert(0, r.Item("codigo"))
                    '    'txtCodigo.Text = r.Item("codigo")
                    'End If
                    Exit For
                End If
            Next

            Try
                If txtCodigo.Text <> String.Empty Then

                    txtCodigo.Text = String.Empty

                    For Each r As DataRow In dtTipoElemento.Rows
                        If uceTipo.Value = r.Item("idTipo") Then
                            txtCodigo.Text = txtCodigo.Text.Insert(0, r.Item("codigo"))
                            Exit For
                        End If
                    Next

                    txtCodigo.Text = txtCodigo.Text.Insert(3, txtNum.Text)

                    If uceAerolinea.Value.ToString = "2e624234-1279-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "IB")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "7403cd0c-23d7-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "BRI")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "d727f82c-12a2-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "CM")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "88867856-1270-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "DHL")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "7774c13c-23bc-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "GA")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "78613da6-1277-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "KL")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "5b9c84d0-12a1-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "EQ")
                        Exit Sub
                    End If
                    If uceAerolinea.Value.ToString = "b86b9024-12ac-11e4-981b-8f9d682eafe3" Then
                        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "UPS")
                        Exit Sub
                    End If
                Else
                    For Each r As DataRow In dtTipoElemento.Rows
                        If uceTipo.Value = r.Item("idTipo") Then
                            txtCodigo.Text = txtCodigo.Text.Insert(0, r.Item("codigo"))
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                General.SetLogEvent(ex)
            End Try
        Catch ex As Exception
                General.SetLogEvent(ex)
                MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ChkEdit_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEdit.CheckedChanged
        If ChkEdit.Checked Then
            Dim resp As DialogResult = Windows.Forms.DialogResult.No
            resp = MessageBox.Show("Desea editar el Código del Elemento", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resp = Windows.Forms.DialogResult.No Then
                ChkEdit.Checked = False
                Exit Sub
            End If
            If resp = Windows.Forms.DialogResult.Yes Then
                'Dim frmCheck As New frmCheckUserManager
                'frmCheck.ShowDialog()
                'Try
                '    If Not frmCheck.result Then
                '        Exit Sub
                '    End If
                'Dim usuarioPermiso As New Server.ReportService.ContactoCatalogItem
                'usuarioPermiso = CommonData.GetContactoItem(frmCheck.tempUserManager.userName)
                'usuarioRequiere = CommonData.GetContactoItem(MyCurrentUser.userName)
                'EnviarReporteCheckUserManager("Editar manualmente Código del Elemento: " & txtCodigo.Text, usuarioPermiso, usuarioRequiere)
                ''Catch ex As Exception
                '    General.SetLogEvent(ex)
                'End Try
            End If
            txtCodigo.ReadOnly = False
        Else
            txtCodigo.ReadOnly = True
        End If
    End Sub

    Private Sub EnviarReporteCheckUserManager(tipoDePermiso As String, usuarioPermiso As Server.ReportService.ContactoCatalogItem, usuarioRequiere As Server.ReportService.ContactoCatalogItem)
        Try
            Dim dest As New DataTable("destinatarios")
            Dim contRowDest As Integer = 0
            Dim destinatarios As String = String.Empty
            Dim msj As String = String.Empty
            Dim nombreUsuarioPer As String = String.Empty
            Dim nombreUsuarioReq As String = String.Empty
            dest = CommonData.GetDestinatariosPorIdReporte(5)
            For Each r As DataRow In dest.Rows
                If contRowDest > 0 Then
                    destinatarios += ", " & r.Item("mail")
                Else
                    destinatarios = r.Item("mail")
                End If
                contRowDest += 1
            Next
            nombreUsuarioPer = usuarioPermiso.primerApellido & " " & usuarioPermiso.segundoApellido & " " & usuarioPermiso.primerNombre
            nombreUsuarioReq = usuarioRequiere.primerApellido & " " & usuarioRequiere.segundoApellido & " " & usuarioRequiere.primerNombre
            msj = "Admin: " & nombreUsuarioPer & " con C.I. " & usuarioPermiso.idContacto & vbCrLf _
                                        & "Autoriza a: " & nombreUsuarioReq & " con C.I. " & usuarioRequiere.idContacto & vbCrLf _
                                       & "A: " & tipoDePermiso.ToUpper & vbCrLf _
                                       & vbCrLf _
                                       & "Notificación automática, por favor no responder este mensaje."
            General.SendCheckUserManagerReportsMessage(msj, destinatarios, tipoDePermiso)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "EnviarReporte")
        End Try
    End Sub

    Private Sub uceAerolinea_SelectionChanged(sender As Object, e As EventArgs) Handles uceAerolinea.SelectionChanged
        Try
            If txtCodigo.Text <> String.Empty Then

                txtCodigo.Text = String.Empty

                For Each r As DataRow In dtTipoElemento.Rows
                    If uceTipo.Value = r.Item("idTipo") Then
                        txtCodigo.Text = txtCodigo.Text.Insert(0, r.Item("codigo"))
                        Exit For
                    End If
                Next

                txtCodigo.Text = txtCodigo.Text.Insert(3, txtNum.Text)

                If uceAerolinea.Value.ToString = "2e624234-1279-11e4-981b-8f9d682eafe3" Then
                    '  txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "IB")
                    ' cmbaver.Items.Add("IB")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7403cd0c-23d7-11e4-981b-8f9d682eafe3" Then
                    'txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "BRI")
                    ' cmbaver.Items.Add("BRI")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "d727f82c-12a2-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "CM")
                    ' cmbaver.Items.Add("CM")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "88867856-1270-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "DHL")
                    ' cmbaver.Items.Add("DHL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7774c13c-23bc-11e4-981b-8f9d682eafe3" Then
                    '  txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "GA")
                    ' cmbaver.Items.Add("GA")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "78613da6-1277-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "KL")
                    ' cmbaver.Items.Add("KL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "5b9c84d0-12a1-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "EQ")
                    ' cmbaver.Items.Add("EQ")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "b86b9024-12ac-11e4-981b-8f9d682eafe3" Then
                    '  txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "UPS")
                    'cmbaver.Items.Add("UPS")
                    Exit Sub
                End If
            Else
                If uceAerolinea.Value.ToString = "2e624234-1279-11e4-981b-8f9d682eafe3" Then
                    '  txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "IB")
                    'cmbaver.Items.Add("IB")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7403cd0c-23d7-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "BRI")
                    ' cmbaver.Items.Add("BRI")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "d727f82c-12a2-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "CM")
                    ' cmbaver.Items.Add("CM")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "88867856-1270-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "DHL")
                    ' cmbaver.Items.Add("DHL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7774c13c-23bc-11e4-981b-8f9d682eafe3" Then
                    'txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "GA")
                    ' cmbaver.Items.Add("GA")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "78613da6-1277-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "KL")
                    'cmbaver.Items.Add("KL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "5b9c84d0-12a1-11e4-981b-8f9d682eafe3" Then
                    ' txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "EQ")
                    'cmbaver.Items.Add("EQ")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "b86b9024-12ac-11e4-981b-8f9d682eafe3" Then
                    'txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "UPS")
                    'cmbaver.Items.Add("UPS")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub txtNum_AfterExitEditMode(sender As Object, e As EventArgs) Handles txtNum.AfterExitEditMode
        Try
            If txtCodigo.Text <> String.Empty Then

                txtCodigo.Text = String.Empty

                For Each r As DataRow In dtTipoElemento.Rows
                    If uceTipo.Value = r.Item("idTipo") Then
                        txtCodigo.Text = txtCodigo.Text.Insert(0, r.Item("codigo"))
                        Exit For
                    End If
                Next

                txtCodigo.Text = txtCodigo.Text.Insert(3, txtNum.Text)

                If uceAerolinea.Value.ToString = "2e624234-1279-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "IB")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7403cd0c-23d7-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "BRI")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "d727f82c-12a2-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "CM")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "88867856-1270-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "DHL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "7774c13c-23bc-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "GA")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "78613da6-1277-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "KL")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "5b9c84d0-12a1-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "EQ")
                    Exit Sub
                End If
                If uceAerolinea.Value.ToString = "b86b9024-12ac-11e4-981b-8f9d682eafe3" Then
                    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "UPS")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNum.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub cmbaver_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbaver.SelectedValueChanged

        'If cmbaver.SelectedItem Then
        txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, cmbaver.Text)
        ' End If
        'If cmbaver.SelectedItem.ToString = "BRI" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "BRI")
        'End If

        'If cmbaver.SelectedItem.ToString = "CM" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "CM")
        'End If
        'If cmbaver.SelectedItem.ToString = "DHL" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "DHL")
        'End If
        'If cmbaver.SelectedItem.ToString = "GA" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "GA")
        'End If
        'If cmbaver.SelectedItem.ToString = "KL" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "KL")
        'End If
        'If cmbaver.SelectedItem.ToString = "EQ" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "EQ")
        'End If
        'If cmbaver.SelectedItem.ToString = "UPS" Then
        '    txtCodigo.Text = txtCodigo.Text.Insert(txtCodigo.TextLength, "UPS")
        'End If



    End Sub

    Private Sub uceTipo_ValueChanged(sender As Object, e As EventArgs) Handles uceTipo.ValueChanged

    End Sub


End Class

