Imports SPC.Server.MarkingService

Public Class frmPermisoEspecialDetalle
    Dim isNewPermisoEspecial As Boolean = False
    Public Property myPermisoEspecial As New PermisoEspecialItem
    Private tablePermisosByContacto As New DataTable("ContactosByPermiso")

    Public Sub New(isNewRegister As Boolean)
        InitializeComponent()
        isNewPermisoEspecial = isNewRegister
    End Sub

    Public Sub New(ByVal id As Guid)
        InitializeComponent()
        myPermisoEspecial = CommonData.GetPermisoEspecialById(id)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validateData() Then
                SavePermisoEspecial()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, Permiso Especial")
        End Try
    End Sub

    Private Function validateData() As Boolean
        Dim result As Boolean = False
        If txtDescription.Text = String.Empty Then
            MsgBox("Ingreso una descripción del permiso")
        ElseIf udtFin.Value < udtInicio.Value Then
            MsgBox("Fecha final debe ser mayor a fecha de inicio")
        ElseIf uceEstado.Text.Trim = String.Empty Then
            MsgBox("Seleccione un estado")
        Else
            result = True
        End If
        Return result
    End Function

    Private Sub SavePermisoEspecial()
        Try
            Dim req As New Server.MarkingService.ContactoRequest
            Dim res As New PermisoContactoResponse
            Dim wsClnt As New MarkingServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
            Dim msgc As String = "Registro actualizado con éxito"
            If isNewPermisoEspecial Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
                myPermisoEspecial.id = Guid.NewGuid
            End If
            myPermisoEspecial.description = txtDescription.Text
            myPermisoEspecial.beginDate = udtInicio.Value
            myPermisoEspecial.endDate = udtFin.Value
            myPermisoEspecial.beginTime = dtpInicio.Text
            myPermisoEspecial.endTime = dtpFin.Text
            myPermisoEspecial.usuario = MyCurrentUser.userName
            myPermisoEspecial.fecha = Date.Now
            myPermisoEspecial.observation = txtObservation.Text
            myPermisoEspecial.estado = uceEstado.Value
            If tablePermisosByContacto.Rows.Count <= 0 Or dgvPermisoContacto.Rows.Count <= 0 Then
                MessageBox.Show("Debe asignar un contacto mínimo al permiso especial", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myPermisoEspecial = myPermisoEspecial
                PermisoEspecialObject()
                res = wsClnt.SavePermisoEspecialItem(req)
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
            General.SetLogEvent(ex, "Save Data, Permiso Especial")
        End Try
    End Sub

    Private Sub PermisoEspecialObject()
        myPermisoEspecial.permisosContacto = New List(Of PermisosContactoItem)
        tablePermisosByContacto.AcceptChanges()
        For i = 0 To dgvPermisoContacto.Rows.Count - 1
            myPermisoEspecial.permisosContacto.Add(New PermisosContactoItem With {.contacto = tablePermisosByContacto.Rows(i).Item("contacto"), .id = myPermisoEspecial.id})
        Next
    End Sub

    Private Sub frmPermisoEspecialDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        With tablePermisosByContacto.Columns
            .Add("Contacto", GetType(String))
            .Add("Nombres", GetType(String))
        End With
        uceContactoAgencia.Items.Clear()
        For Each r As DataRow In CommonData.GetEntireContactoCatalog().Rows
            Dim nombreContacto = r.Item("primerApellidoContacto") & " " & r.Item("segundoApellidoContacto") & " " & r.Item("primerNombreContacto") & " " & r.Item("segundoNombreContacto")
            uceContactoAgencia.Items.Add(r.Item("idContacto"), nombreContacto)
        Next
        If isNewPermisoEspecial Then
            uceEstado.SelectedIndex = 0
        Else
            FillDataPermisoEspecial()
        End If
    End Sub

    Private Sub SetDisplayedColumnsPermisosByContacto()
        dgvPermisoContacto.DisplayLayout.Bands(0).Columns("Contacto").Hidden = True
        dgvPermisoContacto.DisplayLayout.Bands(0).Columns("Nombres").Header.Caption = "Nombres"
    End Sub

    Private Sub FillDataPermisoEspecial()
        tablePermisosByContacto = CommonData.GetContactosByPermiso(myPermisoEspecial.id)
        dgvPermisoContacto.DataSource = tablePermisosByContacto
        SetDisplayedColumnsPermisosByContacto()
        Try
            txtDescription.Text = myPermisoEspecial.description
            udtInicio.Value = myPermisoEspecial.beginDate
            udtFin.Value = myPermisoEspecial.endDate
            dtpInicio.Text = myPermisoEspecial.beginTime
            dtpFin.Text = myPermisoEspecial.endTime
            txtObservation.Text = myPermisoEspecial.observation
            If myPermisoEspecial.estado = "A" Then
                uceEstado.SelectedIndex = 0
            Else
                uceEstado.SelectedIndex = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregarPermisoContacto_Click(sender As Object, e As EventArgs) Handles btnAgregarPermisoContacto.Click
        If uceContactoAgencia.Text <> String.Empty Then
            Dim row As DataRow()
            row = tablePermisosByContacto.Select("Contacto = '" & uceContactoAgencia.Value.ToString & "'")
            If row.Count = 0 Then
                addRow()
            Else
                MsgBox("Ya existe contacto agregado en permiso", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Else
            MsgBox("Seleccione un contacto válido", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub addRow()
        Dim newRow As DataRow
        newRow = tablePermisosByContacto.NewRow
        newRow.Item(0) = uceContactoAgencia.Value
        newRow.Item(1) = uceContactoAgencia.Text
        tablePermisosByContacto.Rows.Add(newRow)
        dgvPermisoContacto.DataSource = tablePermisosByContacto
        If dgvPermisoContacto.Rows.Count <= 1 Then
            SetDisplayedColumnsPermisosByContacto()
        End If
    End Sub

    Private Sub dgvPermisoContacto_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvPermisoContacto.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        Dim result As DialogResult = System.Windows.Forms.MessageBox.Show( _
                "Desea borrar " & e.Rows.Length.ToString() & " registros de tabla?", _
                "Borrar", _
                System.Windows.Forms.MessageBoxButtons.YesNo, _
                System.Windows.Forms.MessageBoxIcon.Question)
        If System.Windows.Forms.DialogResult.No = result Then
            e.Cancel = True
        End If
    End Sub
End Class