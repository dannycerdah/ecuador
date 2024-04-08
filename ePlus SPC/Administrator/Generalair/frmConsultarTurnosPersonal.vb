Imports SPC.Server.ReportService
Imports Infragistics.Win.UltraWinGrid

Public Class frmConsultarTurnosPersonal

    Dim workTable As DataTable = New DataTable("TurnosPersonal")
    Public Property myDaysTurno As New DaysTurnosContactoItem

    Private Sub frmConsultarTurnosPersonal_Load(sender As Object, e As EventArgs) Handles Me.Load
        uceEmpleados.Items.Clear()
        uceEmpleados.Items.Add("Todos", "Todas los empleados")
        For Each r As DataRow In CommonData.GetEmpleadosGeneral().Rows
            uceEmpleados.Items.Add(r.Item("idContacto"), r.Item("empleado"))
        Next
        uceEmpleados.SelectedIndex = 0
        uceTurno.Items.Clear()
        uceTurno.Items.Add("Todos", "Todas los Turnos")
        For Each r As DataRow In CommonData.GetTableTurnos().Rows
            If r.Item("estado") = "Activo" Then
                uceTurno.Items.Add(r.Item("id"), r.Item("title") & " - " & r.Item("inicio") & " - " & r.Item("fin"))
            End If
        Next
        uceTurno.SelectedIndex = 0
        SearchData()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If udtInicio.Value = Nothing Then
            MessageBox.Show("Debe indicar fecha de inicio mínimo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf udtFin.Value < udtInicio.Value Then
            MessageBox.Show("Fecha de final menor a la de inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            SearchData()
        End If
    End Sub

    Private Sub SearchData()
        Try
            'If uceEmpleados.SelectedIndex = 0 Then 'Buscar todos los turnos de los empleados
            '    workTable = CommonData.GetTurnosEmpleado(uceEmpleados.Value, udtInicio.Value, udtFin.Value, "0", uceTurno.Value)
            'Else 'Buscar por empleado
            '    workTable = CommonData.GetTurnosEmpleado(uceEmpleados.Value, udtInicio.Value, udtFin.Value, "1", uceTurno.Value)
            'End If
            Dim TipoConsul As String
            Dim idTurno As Guid
            If uceEmpleados.SelectedIndex = 0 And uceTurno.SelectedIndex = 0 Then
                TipoConsul = 0
                idTurno = Guid.Empty
            ElseIf uceEmpleados.SelectedIndex <> 0 And uceTurno.SelectedIndex = 0 Then
                TipoConsul = 1
                idTurno = Guid.Empty
            ElseIf uceEmpleados.SelectedIndex = 0 And uceTurno.SelectedIndex <> 0 Then
                TipoConsul = 2
                idTurno = uceTurno.Value
            ElseIf uceEmpleados.SelectedIndex <> 0 And uceTurno.SelectedIndex <> 0 Then
                TipoConsul = 3
                idTurno = uceTurno.Value
            End If
            workTable = CommonData.GetTurnosEmpleado(uceEmpleados.Value, udtInicio.Value, udtFin.Value, TipoConsul, idTurno)
            ugdTurnosPersonal.DataSource = workTable
            If ugdTurnosPersonal.DataSource.rows.count < 1 Then
                SetDisplayedColumnsByTurnosPersonal()
                MessageBox.Show("No se encontró ninguna información para consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else 'Mostrar datos
                btnExcelExport.Enabled = True
                ugdTurnosPersonal.Text = "TURNOS ASIGNADOS DEL " & CDate(udtInicio.Value).ToString("dd/MM/yyyy") & " AL " & CDate(udtFin.Value).ToString("dd/MM/yyyy")
                SetDisplayedColumnsByTurnosPersonal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SetDisplayedColumnsByTurnosPersonal()
        Dim band As UltraGridBand = ugdTurnosPersonal.DisplayLayout.Bands(0)
        ugdTurnosPersonal.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.Brown
        ugdTurnosPersonal.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        'band.SortedColumns.Add("empleado", False, True) 'realiza la agrupacion de registros
        band.Columns("id").Hidden = True
        band.Columns("empleado").Header.Caption = "Empleado"
        band.Columns("Empleado").GroupByRowAppearance.ForeColor = Color.Black
        'band.Columns("dia").Header.Caption = "Fecha Ingreso Horario"
        'band.Columns("dia").Format = "dd/MM/yyyy"
        band.Columns("dia").Hidden = True
        band.Columns("title").Header.Caption = "Turno"
        band.Columns("dia").CellActivation = Activation.NoEdit
        'band.Columns("inicio").Header.Caption = "Inicio"
        'band.Columns("fin").Header.Caption = "Fin"
        band.Columns("inicio").Hidden = True
        band.Columns("fin").Hidden = True
        band.Columns("FechaInicio").Header.Caption = "Fecha y Hora Inicio"
        band.Columns("FechaFin").Header.Caption = "Fecha y Hora Fin"
        band.Columns("FechaInicio").CellActivation = Activation.NoEdit
        band.Columns("FechaInicio").Format = "dd/MM/yyyy HH:mm:ss"
        band.Columns("FechaFin").Format = "dd/MM/yyyy HH:mm:ss"
        band.Columns("FechaFin").CellActivation = Activation.NoEdit

    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdTurnosPersonal)
    End Sub

    Private Sub ugdTurnosPersonal_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugdTurnosPersonal.DoubleClickCell
        Dim id As String = ugdTurnosPersonal.ActiveRow.Cells("id").Value.ToString
        If id <> String.Empty Then
            deleteTurnoPersonal(id)
        End If
    End Sub

    Private Sub deleteTurnoPersonal(ByVal id As String)
        Try
            Dim req As New ContactoRequest
            Dim res As New ContactoResponse
            Dim wsClnt As New ReportServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea eliminar este registro?"
            Dim msgc As String = "Registro eliminado con éxito"
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.codigoVuelo = id
                res = wsClnt.DeleteTurnoEmpleado(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Delete Data, TurnoByPersonal")
        End Try
    End Sub

    Private Sub ugdTurnosPersonal_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugdTurnosPersonal.InitializeLayout
        e.Layout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
    End Sub
End Class