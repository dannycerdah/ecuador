Imports SPC.Server.ReportService
Public Class frmPerfilDetalle

    Dim isNewPerfil As Boolean = False
    Public Property myPerfil As New PerfilItem
    Private dtPermisosByContacto As New DataTable("dtPermisosByContacto")  'MARZ

    Public Sub New(MustCreateNewPerfil As Boolean)
        InitializeComponent()
        isNewPerfil = MustCreateNewPerfil
    End Sub
    Public Sub New(ByVal idPerfil As Guid)
        InitializeComponent()
        myPerfil = CommonData.GetPerfilItem(idPerfil)
        Me.UltraGroupBox3.Enabled = True 'Actualizar permisos del perfil
    End Sub

    Private Sub frmPerfilDeatalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        ucePerfil.Items.Clear()
        ucePerfil.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetProfileCatalog().Rows
            ucePerfil.Items.Add(r.Item("idPerfil"), r.Item("nombrePerfil"))
        Next
        If isNewPerfil Then
            ucePerfil.SelectedIndex = 0
            uceEstado.SelectedIndex = 0
        Else
            With dtPermisosByContacto.Columns 'Tablas
                .Add("idKey", GetType(String))
                .Add("detalleKey", GetType(String))
                .Add("checked", GetType(Boolean))
            End With
            FillDataPerfil()
        End If
    End Sub
    'MARZ
    Private Sub SetDisplayedColumnsPermisosByPerfil()
        dgvPermisos.DisplayLayout.Bands(0).Columns("idKey").Hidden = True
        dgvPermisos.DisplayLayout.Bands(0).Columns("detalleKey").Header.Caption = "Función"
        With dgvPermisos.DisplayLayout.Bands(0).Columns("checked")
            .Header.Caption = "Activo"
            .Width = 30
        End With
    End Sub

    Private Sub FillDataPerfil()
        'MARZ_21.08.17
        Dim dtTPermisosByContacto As New DataTable
        dtTPermisosByContacto = CommonData.GetPermisosByPerfil(myPerfil.idPerfil)
        dtPermisosByContacto.Rows.Clear()
        For Each r As DataRow In dtTPermisosByContacto.Rows
            Dim r2 As DataRow = dtPermisosByContacto.NewRow
            r2.Item("idKey") = r.Item("idKey")
            r2.Item("detalleKey") = r.Item("detalleKey")
            If r.Item("checked") = 1 Then
                r2.Item("checked") = True
            Else
                r2.Item("checked") = False
            End If
            dtPermisosByContacto.Rows.Add(r2)
        Next
        dgvPermisos.DataSource = dtPermisosByContacto
        SetDisplayedColumnsPermisosByPerfil()
        'END MARZ
        Try
            'Información del perfil
            ucePerfil.SelectedText = myPerfil.padrePerfil
            txtNombre.Text = myPerfil.nombrePerfil
            txtNombre.Enabled = False 'MARZ
            txtDescription.Text = myPerfil.comentarioPerfil
            If myPerfil.estadoPerfil = "A" Then
                uceEstado.SelectedIndex = 0
            Else
                uceEstado.SelectedIndex = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If validateData() Then
                SavePerfil()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, Perfiles")
        End Try
    End Sub
    Private Function validateData() As Boolean
        Dim result As Boolean = False
        If ucePerfil.SelectedIndex = 0 Then
            MsgBox("Seleccione un perfil superior")
        ElseIf txtNombre.Text.Trim = String.Empty Then
            MsgBox("Ingrese un nombre")
        ElseIf uceEstado.Text.Trim = String.Empty Then
            MsgBox("Seleccione un estado")
        Else
            result = True
        End If
        Return result
    End Function

    Private Sub SavePerfil()
        Try
            Dim req As New ContactoRequest
            Dim res As New ContactoResponse
            Dim wsClnt As New ReportServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
            Dim msgc As String = "Registro actualizado con éxito"
            If isNewPerfil Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
                myPerfil.idPerfil = Guid.NewGuid
            End If
            myPerfil.nombrePerfil = txtNombre.Text.Trim
            myPerfil.comentarioPerfil = txtDescription.Text
            myPerfil.estadoPerfil = uceEstado.Value
            myPerfil.idUsuario = MyCurrentUser.userName
            myPerfil.fecha = Date.Now
            myPerfil.padrePerfil = ucePerfil.Text
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myPerfilItem = myPerfil
                If Not isNewPerfil Then 'Sólo en actualización de perfil se registran permisos
                    PermisosPerfilObject()
                    If dtPermisosByContacto.Rows.Count = 0 Then 'MARZ
                        MessageBox.Show("Debe asignar un permiso mínimo al perfil", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
                res = wsClnt.SavePerfilItem(req)
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
            General.SetLogEvent(ex, "Save Data, Perfiles")
        End Try
    End Sub

    'MARZ_17.08.17
#Region "Permisos al perfil"
    Private Sub PermisosPerfilObject()
        myPerfil.permisosPerfil = New List(Of PermisosPerfilItem)
        dtPermisosByContacto.AcceptChanges()
        For i = 0 To dgvPermisos.Rows.Count - 1
            'Validar el checked para asignar permiso
            If dtPermisosByContacto.Rows(i).Item("checked") Then
                myPerfil.permisosPerfil.Add(New PermisosPerfilItem With {.idPerfil = myPerfil.idPerfil, .idKey = dtPermisosByContacto.Rows(i).Item("idKey")})
            End If
        Next
    End Sub
#End Region

    'MARZ_21.08.17 (Filtrar permisos por detalle)
    Private Sub txtFiltrarPermisos_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltrarPermisos.ValueChanged
        If txtFiltrarPermisos.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In dgvPermisos.Rows
                If InStr(r.Cells("detalleKey").Value, txtFiltrarPermisos.Text) <> 0 Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In dgvPermisos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub chckTodo_Click(sender As Object, e As EventArgs) Handles chckTodo.Click
        If chckTodo.Checked = True Then
            For Each r As DataRow In dtPermisosByContacto.Rows
                r.Item("checked") = 1
            Next
        Else
            For Each r As DataRow In dtPermisosByContacto.Rows
                r.Item("checked") = 0
            Next
        End If
    End Sub

    Private Sub dgvPermisos_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dgvPermisos.ClickCell
        Try
            If e.Cell.Column Is dgvPermisos.DisplayLayout.Bands(0).Columns("checked") Then
                If dgvPermisos.ActiveRow.Cells("checked").Value = True Then
                    dgvPermisos.ActiveRow.Cells("checked").Value = False
                Else
                    dgvPermisos.ActiveRow.Cells("checked").Value = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class