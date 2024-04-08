Imports SPC.Server.ReportService
Imports Infragistics.Win.UltraWinGrid
Public Class frmAsignarTurnosPersonal
    Private datableTurnosByEmpleado As New DataTable("TurnosByEmpleado")
    Public Property myTurno As New TurnoItem
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If dgvTurnosEmpleados.DataSource IsNot Nothing Then
                SaveTurnosContacto()
            Else
                MessageBox.Show("No hay ningún dato a guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, TurnosContacto")
        End Try
    End Sub

    Private Sub SaveTurnosContacto()
        Try
            Dim req As New ContactoRequest
            Dim res As New ContactoResponse
            Dim wsClnt As New ReportServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea guardar este registro?"
            Dim msgc As String = "Registro guardado con éxito"
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myTurno = myTurno
                TurnosContactoObject()
                res = wsClnt.SaveDaysTurnosContactotem(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, TurnosContacto")
        End Try
    End Sub

    Private Sub TurnosContactoObject()
        myTurno.daysTurnoContacto = New List(Of DaysTurnosContactoItem)
        datableTurnosByEmpleado.AcceptChanges()
        For Each r As DataRow In datableTurnosByEmpleado.Rows
            Dim ls_Horas As String
            Dim li_posicion As Integer
            Dim ls_HoraIni As String
            Dim ls_HoraFin As String
            Dim ld_HoraInicio As Date
            Dim ld_HoraFin As Date
            Dim fecha As Date = r.Item(0)
            ls_Horas = r.Item(2)
            ls_Horas = ls_Horas.Replace(" ", "")
            li_posicion = InStr(ls_Horas, "-")
            ls_HoraIni = ls_Horas.Substring(0, li_posicion - 1)
            ls_HoraFin = ls_Horas.Substring(li_posicion, 5)
            ld_HoraInicio = Convert.ToDateTime(fecha & " " & ls_HoraIni)
            Dim CompracionHora As Integer = DateTime.Compare(Convert.ToDateTime(ls_HoraIni), Convert.ToDateTime(ls_HoraFin))
            If CompracionHora > 0 Then
                ld_HoraFin = Convert.ToDateTime(fecha.AddDays(1) & " " & ls_HoraFin)
            Else
                ld_HoraFin = Convert.ToDateTime(fecha & " " & ls_HoraFin)
            End If

            myTurno.daysTurnoContacto.Add(New DaysTurnosContactoItem With {.day = r.Item(0), .horario = New Guid(r.Item(1).ToString), .contacto = r.Item(3), .fechaInicio = ld_HoraInicio, .fechaFin = ld_HoraFin})
        Next
    End Sub

    Private Sub frmAsignarTurnosPersonal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim fechActual As String = DateTime.Now().ToString("MM/dd/yyyy")
        dtpFecha.Value = DateTime.Parse(fechActual)
        With datableTurnosByEmpleado.Columns
            .Add("day", GetType(Date))
            .Add("id", GetType(String))
            .Add("title", GetType(String))
            .Add("idContacto", GetType(String))
            .Add("empleado", GetType(String))
        End With
        'Data de empleados
        uceEmpleados.Items.Clear()
        For Each r As DataRow In CommonData.GetEmpleadosGeneral().Rows
            uceEmpleados.Items.Add(r.Item("idContacto"), r.Item("empleado"))
        Next
        uceEmpleados.SelectedIndex = 0
        'Data de turnos
        uceTurno.Items.Clear()
        For Each r As DataRow In CommonData.GetTableTurnos().Rows
            If r.Item("estado") = "Activo" Then
                uceTurno.Items.Add(r.Item("id"), r.Item("inicio") & " - " & r.Item("fin") & " (" & r.Item("title") & ") ")
            End If
        Next
        uceTurno.SelectedIndex = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addRow As Boolean = True
        If UltraCheckSemana.Checked Then
            Dim Li_dia As Integer = dtpFecha.Value.DayOfWeek
            Dim li_contador As Integer = 0
            Dim fechaRegistro As Date
            For i = Li_dia To 7
                addRow = True
                Dim fila As DataRow = datableTurnosByEmpleado.NewRow
                If datableTurnosByEmpleado.Rows.Count = 0 Then
                    fechaRegistro = dtpFecha.Value
                    fila.Item("day") = dtpFecha.Value
                    fila.Item("id") = uceTurno.Value
                    fila.Item("title") = uceTurno.Text
                    fila.Item("idContacto") = uceEmpleados.Value
                    fila.Item("empleado") = uceEmpleados.Text
                    datableTurnosByEmpleado.Rows.Add(fila)
                Else
                    If li_contador = 0 Then
                        fechaRegistro = dtpFecha.Value
                    Else
                        fechaRegistro = fechaRegistro.AddDays(1)
                    End If
                    For Each r As DataRow In datableTurnosByEmpleado.Rows
                        If r.Item("day") = fechaRegistro And r.Item("id") = uceTurno.Value.ToString And r.Item("idContacto") = uceEmpleados.Value.ToString Then
                            addRow = False
                        End If
                    Next
                    If addRow Then
                        fila.Item("day") = fechaRegistro
                        fila.Item("id") = uceTurno.Value
                        fila.Item("title") = uceTurno.Text
                        fila.Item("idContacto") = uceEmpleados.Value
                        fila.Item("empleado") = uceEmpleados.Text
                        datableTurnosByEmpleado.Rows.Add(fila)
                    End If
                End If
                li_contador = li_contador + 1
            Next
        Else
            For Each r As DataRow In datableTurnosByEmpleado.Rows
                If r.Item("day") = dtpFecha.Value And r.Item("id") = uceTurno.Value.ToString And r.Item("idContacto") = uceEmpleados.Value.ToString Then
                    addRow = False
                End If
            Next
            If addRow Then
                Dim fila As DataRow = datableTurnosByEmpleado.NewRow
                fila.Item("day") = dtpFecha.Value
                fila.Item("id") = uceTurno.Value
                fila.Item("title") = uceTurno.Text
                fila.Item("idContacto") = uceEmpleados.Value
                fila.Item("empleado") = uceEmpleados.Text
                datableTurnosByEmpleado.Rows.Add(fila)
            Else
                MessageBox.Show("Ya existe turno asignado a: " & uceEmpleados.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        dgvTurnosEmpleados.DataSource = datableTurnosByEmpleado
        SetDisplayedColumns()
        OrderColumns()
    End Sub
    Private Sub SetDisplayedColumns()
        With dgvTurnosEmpleados.DisplayLayout.Bands(0).Columns("day")
            .Header.Caption = "Día"
            .Width = 75
        End With
        dgvTurnosEmpleados.DisplayLayout.Bands(0).Columns("id").Hidden = True
        With dgvTurnosEmpleados.DisplayLayout.Bands(0).Columns("title")
            .Header.Caption = "Turno"
            .Width = 85
        End With
        dgvTurnosEmpleados.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
        dgvTurnosEmpleados.DisplayLayout.Bands(0).Columns("empleado").Header.Caption = "Personal"
    End Sub

    Sub OrderColumns()
        Dim band As UltraGridBand = dgvTurnosEmpleados.DisplayLayout.Bands(0)
        band.Columns("day").SortIndicator = SortIndicator.Ascending
        band.Columns("title").SortIndicator = SortIndicator.Ascending
        band.Columns("idContacto").SortIndicator = SortIndicator.Ascending
        dgvTurnosEmpleados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        band.SortedColumns.Clear()
    End Sub

    Private Sub txtFiltrarEmpleados_ValueChanged(sender As Object, e As EventArgs) Handles txtFiltrarEmpleados.ValueChanged
        If txtFiltrarEmpleados.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In dgvTurnosEmpleados.Rows
                If InStr(r.Cells("empleado").Value, txtFiltrarEmpleados.Text) <> 0 Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In dgvTurnosEmpleados.Rows
                r.Hidden = False
            Next
        End If
    End Sub

End Class