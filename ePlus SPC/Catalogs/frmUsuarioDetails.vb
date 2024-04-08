Imports SPC.Server.ReportService
Public Class frmUsuarioDetails
    Dim isNewUsuario As Boolean = False
    Dim tempContacto As New ContactoCatalogItem
    Public Property myUsuario As New UsuarioItem
    Private dtPerfilesUsuario As New DataTable("dtPerfilesUsuario")  'MARZ
    Private dtUsuarioEmpresa As New DataTable("dtUsuarioEmpresa")

    Public Sub New(MustCreateNewMterial As Boolean)
        InitializeComponent()
        IsNewUsuario = True
    End Sub

    Public Sub New(ByVal UsuarioId As String)
        InitializeComponent()
        myUsuario = CommonData.GetUsuarioItem(UsuarioId)
    End Sub

    Private Sub frmUsuarioDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If isNewUsuario Then
            btnContacto.Visible = True
            uceEstado.SelectedIndex = 0
            uceAdmin.SelectedIndex = 0
        Else
            ugbPerfiles.Enabled = True 'Actualizar perfiles del usuario
            fillPerfiles() 'MARZ
            btnContacto.Visible = False
            FillInfoUsuario()
        End If
    End Sub

    'MARZ_16.08.17
    Sub fillPerfiles()
        ucePerfil.Items.Clear()
        ucePerfil.Items.Add(Guid.Empty, "Seleccionar perfil")
        For Each r As DataRow In CommonData.GetProfileCatalog().Rows
            ucePerfil.Items.Add(r.Item("idPerfil"), r.Item("nombrePerfil"))
        Next
        ucePerfil.SelectedIndex = 0
    End Sub

    'MARZ
    Private Sub SetDisplayedColumnsPerfilesByContacto()
        dgvPerfiles.DisplayLayout.Bands(0).Columns("idPerfil").Hidden = True
        dgvPerfiles.DisplayLayout.Bands(0).Columns("Perfil").Header.Caption = "Perfil"
    End Sub

    Private Sub FillInfoUsuario()
        'MARZ_17.08.17
        dtPerfilesUsuario = CommonData.GetPerfilesByContacto(myUsuario.idContacto)
        dgvPerfiles.DataSource = dtPerfilesUsuario
        SetDisplayedColumnsPerfilesByContacto()
        'END MARZ
        Try
            tempContacto = CommonData.GetContactoItem(myUsuario.idContacto)
            txtContacto.Text = tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre + " " + tempContacto.segundoNombre
            txtUserName.Text = myUsuario.idUsuario
            txtPass.Text = myUsuario.password
            If myUsuario.estado = "A" Then
                uceEstado.SelectedIndex = 0
            Else
                uceEstado.SelectedIndex = 1
            End If
            If myUsuario.admin = "F" Then
                uceAdmin.SelectedIndex = 0
            Else
                uceAdmin.SelectedIndex = 1
            End If


            dtUsuarioEmpresa = CommonData.Getusuarioempresabyidcontacto(myUsuario.idContacto)



            Dim n As Integer
            For n = 0 To chklistBox.Items.Count - 1
                chklistBox.SetItemChecked(n, False)

            Next

            For Each r As DataRow In dtUsuarioEmpresa.Rows
                For n = 0 To chklistBox.Items.Count - 1
                    If r.Item("codigo_empresa") = (n + 1) Then
                        chklistBox.SetItemChecked(n, True)
                    End If
                Next
            Next










        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnContacto_Click(sender As Object, e As EventArgs) Handles btnContacto.Click
        Try
            Dim frmConsultaEmpleados As New frmConsultaEmpleados()
            frmConsultaEmpleados.ShowDialog()
            If frmConsultaEmpleados.Contacto.idContacto <> String.Empty Then
                tempContacto = frmConsultaEmpleados.Contacto 'Contacto
                fillInfoContacto()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub fillInfoContacto()
        Try
            txtContacto.Text = tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre + " " + tempContacto.segundoNombre
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If ValidaInfo Then
                SaveInfoUsuario()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, Usuarios")
        End Try
    End Sub

    Private Function ValidaInfo() As Boolean
        Dim result As Boolean = False
        If txtContacto.Text.Trim = String.Empty Then
            MsgBox("Seleccione un contacto")
        ElseIf uceEstado.Text.Trim = String.Empty Then
            MsgBox("Seleccione un estado")
        ElseIf uceAdmin.Text.Trim = String.Empty Then
            MsgBox("Seleccione si es administrador")
        ElseIf txtUserName.Text.Trim = String.Empty Or txtUserName.Text.Trim.Length < 3 Then
            MsgBox("Ingrese un nombre de usuario")
        ElseIf txtPass.Text.Trim = String.Empty Or txtPass.Text.Trim.Length < 4 Then
            MsgBox("Ingrese una contraseña válida")
        ElseIf (dgvPerfiles.Rows.Count <= 0) And Not isNewUsuario And uceEstado.SelectedIndex = 0 Then 'MARZ_17.08.17
            MsgBox("Se debe asignar algún perfil al usuario")
        Else
            result = True
        End If
        Return result
    End Function

    Private Sub SaveInfoUsuario()
        Try
            Dim req As New ContactoRequest
            Dim res As New ContactoResponse
            Dim wsClnt As New ReportServiceSoapClient
            Dim itemUsuarioEmpresa As UsuarioEmpresaItem

            Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
            Dim msgc As String = "Registro actualizado con éxito."
            If isNewUsuario Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            myUsuario.idUsuario = txtUserName.Text.Trim
            myUsuario.idContacto = tempContacto.idContacto
            myUsuario.password = txtPass.Text.Trim
            myUsuario.estado = uceEstado.Value
            myUsuario.admin = uceAdmin.Value
            myUsuario.idContactoCreacion = MyCurrentUser.userName
            If isNewUsuario Then
                myUsuario.fechaCreacion = Date.Now
            Else
                myUsuario.fechaAct = Date.Now
            End If

            myUsuario.usuarioEmpresa = New List(Of UsuarioEmpresaItem)
            For n = 0 To chklistBox.Items.Count - 1
                'If chklistBox.CheckedItems(n) = True Then
                If chklistBox.GetItemChecked(n) Then
                    itemUsuarioEmpresa = New UsuarioEmpresaItem
                    itemUsuarioEmpresa.codigo_empresa = n + 1
                    itemUsuarioEmpresa.idcontacto = tempContacto.idContacto
                    myUsuario.usuarioEmpresa.Add(itemUsuarioEmpresa)
                End If
            Next



            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myUsuarioItem = myUsuario
                PerfilesUsuarioObject() 'MARZ
                res = wsClnt.SaveUsuarioItem(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save Usuario, Usuarios")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#Region "Perfiles"
    'MARZ
    Private Sub btnAgregarPerfil_Click(sender As Object, e As EventArgs) Handles btnAgregarPerfil.Click
        If tempContacto.idContacto Is Nothing Then
            MsgBox("Seleccione un contacto válido", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If
        If ucePerfil.SelectedIndex <> 0 Then
            If dtPerfilesUsuario.Columns.Count = 0 Then
                dtPerfilesUsuario.Dispose()
                dtPerfilesUsuario.Columns.Add("idPerfil").ColumnMapping = MappingType.Hidden
                dtPerfilesUsuario.Columns.Add("Perfil")
            End If
            addRow()
        Else
            MsgBox("Seleccione un perfil válido", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub addRow()
        'Nueva fila
        Dim newRow As DataRow
        newRow = dtPerfilesUsuario.NewRow
        newRow.Item(0) = ucePerfil.Value
        newRow.Item(1) = ucePerfil.Text
        dtPerfilesUsuario.Rows.Add(newRow)
        dgvPerfiles.DataSource = dtPerfilesUsuario
    End Sub

    Private Sub PerfilesUsuarioObject()
        myUsuario.perfilesUsuario = New List(Of PerfilesUsuarioItem)
        dtPerfilesUsuario.AcceptChanges()
        For i = 0 To dgvPerfiles.Rows.Count - 1
            myUsuario.perfilesUsuario.Add(New PerfilesUsuarioItem With {.idPerfil = New Guid(dtPerfilesUsuario.Rows(i).Item("idPerfil").ToString), .idContacto = myUsuario.idContacto})
        Next
    End Sub

#End Region

    Private Sub dgvPerfiles_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvPerfiles.InitializeLayout

    End Sub

End Class

