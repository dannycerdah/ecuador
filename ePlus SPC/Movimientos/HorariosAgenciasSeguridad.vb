Public Class HorariosAgenciasSeguridad
    Public dtBriefingAgencias As New DataTable("BriefingAgencias")
    Public IdBriefing As Guid
    Public IdUsuario As String
    Public Vuelo As String
    Private DtHorarioContacto As New DataTable("DtHorarioContacto")
    Private _HorarioAgenciaSeguridad As New Server.MarkingService.HorarioAgenciaSeguridad
    Private Sub HorariosAgenciasSeguridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAgencias.Items.Clear()
        cmbAgencias.Items.Add(Guid.Empty, "Selecciones un Registro")
        If dtBriefingAgencias.Rows.Count > 0 Then
            For Each r As DataRow In dtBriefingAgencias.Rows
                cmbAgencias.Items.Add(r.Item("idAgencia"), r.Item("Agencia"))
            Next
        End If
        cmbAgencias.SelectedIndex = 0
        With DtHorarioContacto.Columns
            .Add("idBriefing", GetType(Guid))
            .Add("idContacto", GetType(String))
            .Add("nombre", GetType(String))
            .Add("idAgencia", GetType(Guid))
            .Add("Compania", GetType(String))
            .Add("vuelo", GetType(String))
            .Add("FechaInicio", GetType(DateTime))
            .Add("FechaFin", GetType(DateTime))
        End With
        dgvHorario.DataSource = DtHorarioContacto
        cargarHorarios()
        SetColummnas()
        cmbContacto.Items.Clear()
        cmbContacto.Items.Add(String.Empty, "Selecciones un Registro")
        cmbContacto.SelectedIndex = 0
    End Sub
    Private Sub cargarHorarios()
        Dim row As DataRow
        For Each r As DataRow In CommonData.GetHorAgenSeguridad.Rows
            row = DtHorarioContacto.NewRow
            row.Item("idBriefing") = r.Item("idBriefing")
            row.Item("idContacto") = r.Item("idContacto")
            row.Item("nombre") = r.Item("nombre")
            row.Item("idAgencia") = r.Item("idAgencia")
            row.Item("Compania") = r.Item("Compania")
            row.Item("vuelo") = r.Item("vuelo")
            row.Item("FechaInicio") = r.Item("FechaInicio")
            row.Item("FechaFin") = r.Item("FechaFin")
            DtHorarioContacto.Rows.Add(row)
        Next
    End Sub
    Private Sub SetColummnas()
        dgvHorario.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Cedula/Pasaporte"
        dgvHorario.DisplayLayout.Bands(0).Columns("nombre").Header.Caption = "Nombre Contacto"
        dgvHorario.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        dgvHorario.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
        dgvHorario.DisplayLayout.Bands(0).Columns("Compania").Header.Caption = "Compañia"
        dgvHorario.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        dgvHorario.DisplayLayout.Bands(0).Columns("FechaInicio").Format = "dd/MM/yyyy HH:mm:ss"
        dgvHorario.DisplayLayout.Bands(0).Columns("FechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        dgvHorario.DisplayLayout.Bands(0).Columns("FechaFin").Format = "dd/MM/yyyy HH:mm:ss"
    End Sub
    Private Sub cmbAgencias_SelectionChanged(sender As Object, e As EventArgs) Handles cmbAgencias.SelectionChangeCommitted
        Dim Agencia As Guid
        If cmbAgencias.Value.GetType.ToString = "System.String" Then
            Agencia = Guid.Parse(cmbAgencias.Value)
        Else
            Agencia = cmbAgencias.Value
        End If
        If Agencia <> Guid.Empty Then
            cmbContacto.Items.Clear()
            cmbContacto.Items.Add(String.Empty, "Selecciones un Registro")
            cargarContacto()
        End If
    End Sub
    Private Sub cargarContacto()
        Dim dt As New DataTable
        Try
            Dim Agencia As Guid
            If cmbAgencias.Value.GetType.ToString = "System.String" Then
                Agencia = Guid.Parse(cmbAgencias.Value)
            Else
                Agencia = cmbAgencias.Value
            End If
            dt = CommonData.GetContactoAgenciaPorIdAgencia(Agencia)
            If Not IsNothing(dt) And dt.Rows.Count > 0 Then
                cmbContacto.Enabled = True
                For Each r As DataRow In dt.Rows
                    cmbContacto.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                cmbContacto.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarAgencia_Click(sender As Object, e As EventArgs) Handles btnAgregarAgencia.Click
        Dim fechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim fechaFinal As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        Dim Agencia As Guid
        If cmbAgencias.Value.GetType.ToString = "System.String" Then
            Agencia = Guid.Parse(cmbAgencias.Value)
        Else
            Agencia = cmbAgencias.Value
        End If
        If DtHorarioContacto.Rows.Count > 0 Then
            For Each r As DataRow In DtHorarioContacto.Rows
                If r.Item("idContacto") = cmbContacto.Value And r.Item("idAgencia") = Agencia And r.Item("FechaInicio") = fechaInicio And r.Item("FechaFin") = fechaFinal And r.Item("idBriefing") = IdBriefing Then
                    addRow = False
                    Exit For
                End If
            Next
        End If
        If addRow Then
            Dim HorarioAgenciaSeguridad As New Server.MarkingService.HorarioAgenciaSeguridad
            row = DtHorarioContacto.NewRow
            row.Item("idBriefing") = IdBriefing
            row.Item("idContacto") = cmbContacto.Value
            row.Item("nombre") = cmbContacto.Text
            row.Item("idAgencia") = Agencia
            row.Item("Compania") = cmbAgencias.Text
            row.Item("FechaFin") = fechaFinal
            row.Item("vuelo") = Vuelo
            row.Item("FechaInicio") = fechaInicio
            row.Item("FechaFin") = fechaFinal
            With HorarioAgenciaSeguridad
                .idBriefing = IdBriefing
                .idContacto = cmbContacto.Value
                .idAgencia = Agencia
                .FechaInicio = fechaInicio
                .FechaFin = fechaFinal
                .UsuarioIngreso = IdUsuario
            End With
            If CommonData.MantHorarioAgenciaSeguridad(HorarioAgenciaSeguridad) Then
                MessageBox.Show("Registro Ingresado con exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtHorarioContacto.Rows.Add(row)
            End If
        End If
    End Sub

    Private Sub dgvHorario_AfterRowActivate(sender As Object, e As EventArgs) Handles dgvHorario.AfterRowActivate
        With _HorarioAgenciaSeguridad
            .idBriefing = dgvHorario.ActiveRow.Cells("idBriefing").Value
            .idContacto = dgvHorario.ActiveRow.Cells("idContacto").Value
            .idAgencia = dgvHorario.ActiveRow.Cells("idAgencia").Value
            .FechaInicio = dgvHorario.ActiveRow.Cells("FechaInicio").Value
            .FechaFin = dgvHorario.ActiveRow.Cells("FechaFin").Value
            .UsuarioIngreso = IdUsuario
        End With
    End Sub

    Private Sub dgvHorario_AfterRowsDeleted(sender As Object, e As EventArgs) Handles dgvHorario.AfterRowsDeleted
        _HorarioAgenciaSeguridad.Estado = "E"
        If CommonData.MantHorarioAgenciaSeguridad(_HorarioAgenciaSeguridad) Then
            MessageBox.Show("Registro Eliminado con exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class