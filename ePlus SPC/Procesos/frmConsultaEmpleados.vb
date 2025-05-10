
Public Class frmConsultaEmpleados
    Dim IdGeneral As Guid = Guid.Parse("1f2ebac3-c1b8-11e3-a62b-d43d7eb25e94")
    Dim IdInsitucion As Guid = Guid.Parse("5b7f4a10-1b48-11e8-ac5f-94727d1d1b2f")
    Public Contacto As New Server.ReportService.ContactoCatalogItem
    Dim dtContactos As New DataTable("dtContactos")
    Dim dt As New DataTable
    Dim nr As DataRow
    Private Sub frmConsultaEmpleados_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dtContactos.Columns
            .Add("idAgencia", GetType(Guid))
            .Add("descripcionAgencia", GetType(String))
            .Add("idContacto", GetType(String))
            .Add("primerNombreContacto", GetType(String))
            .Add("segundoNombreContacto", GetType(String))
            .Add("primerApellidoContacto", GetType(String))
            .Add("segundoApellidoContacto", GetType(String))
            .Add("cargo", GetType(String))
            .Add("fechaInicio", GetType(DateTime))
            .Add("fechaFin", GetType(DateTime))
            .Add("estado", GetType(String))
            .Add("comentario", GetType(String))
            .Add("indice", GetType(Guid))
            .Add("mailConactoAgencia", GetType(String)) 'jro spint01 24/04/2025
        End With
        ugdPersonalGeneral.DataSource = dtContactos
        ugdPersonalGeneral.DataBind()
        dt = CommonData.GetContactoAgenciaPorIdAgencia(IdGeneral)
        For Each r As DataRow In dt.Rows
            nr = dtContactos.NewRow
            nr.Item("idAgencia") = r.Item("idAgencia")
            nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
            nr.Item("idContacto") = r.Item("idContacto")
            nr.Item("primerNombreContacto") = r.Item("primerNombreContacto")
            nr.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
            nr.Item("primerApellidoContacto") = r.Item("primerApellidoContacto")
            nr.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
            nr.Item("cargo") = r.Item("cargo")
            nr.Item("fechaInicio") = r.Item("fechaInicio")
            nr.Item("fechaFin") = r.Item("fechaFin")
            nr.Item("comentario") = r.Item("comentario")
            nr.Item("mailConactoAgencia") = r.Item("mailConactoAgencia") 'jro spint01 24/04/2025
            dtContactos.Rows.Add(nr)
        Next
        ugdPersonalGeneral.Refresh()
        RefreshData()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs)
        'ugdAgentes.DataSource = CommonData.GetContactoPorIdAgencia(uceAgencia.Value)
    End Sub

    Public Sub RefreshData()
        dt = CommonData.GetContactoAgenciaPorIdAgencia(IdInsitucion)
        For Each r As DataRow In dt.Rows
            nr = dtContactos.NewRow
            nr.Item("idAgencia") = r.Item("idAgencia")
            nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
            nr.Item("idContacto") = r.Item("idContacto")
            nr.Item("primerNombreContacto") = r.Item("primerNombreContacto")
            nr.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
            nr.Item("primerApellidoContacto") = r.Item("primerApellidoContacto")
            nr.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
            nr.Item("cargo") = r.Item("cargo")
            nr.Item("fechaInicio") = r.Item("fechaInicio")
            nr.Item("fechaFin") = r.Item("fechaFin")
            nr.Item("comentario") = r.Item("comentario")
            nr.Item("mailConactoAgencia") = r.Item("mailConactoAgencia") 'jro spint01 24/04/2025
            dtContactos.Rows.Add(nr)
        Next
        ugdPersonalGeneral.DataBind()
        ugdPersonalGeneral.Refresh()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Actividad"
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Nombre"
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Apellido"
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("cargo").Header.Caption = "Cargo"
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("fechaInicio").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("fechaFin").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("indice").Hidden = True
            ugdPersonalGeneral.DisplayLayout.Bands(0).Columns("mailConactoAgencia").Hidden = True 'jro spint01 24/04/2025
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ugdPersonalGeneral_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugdPersonalGeneral.DoubleClickRow
        Try
            Contacto.idContacto = ugdPersonalGeneral.ActiveRow.Cells("idContacto").Value
            Contacto.idAgencia = ugdPersonalGeneral.ActiveRow.Cells("idAgencia").Value
            Contacto.primerNombre = ugdPersonalGeneral.ActiveRow.Cells("primerNombreContacto").Value
            Contacto.segundoNombre = ugdPersonalGeneral.ActiveRow.Cells("segundoNombreContacto").Value
            Contacto.primerApellido = ugdPersonalGeneral.ActiveRow.Cells("primerApellidoContacto").Value
            Contacto.segundoApellido = ugdPersonalGeneral.ActiveRow.Cells("segundoApellidoContacto").Value
            Contacto.cargo = ugdPersonalGeneral.ActiveRow.Cells("cargo").Value
            Contacto.EmailContactoAgencia = If(IsDBNull(ugdPersonalGeneral.ActiveRow.Cells("mailConactoAgencia").Value), "", ugdPersonalGeneral.ActiveRow.Cells("mailConactoAgencia").Value.ToString()) 'jro spint01 24/04/2025
            Contacto.DescripcionAgencia = If(IsDBNull(ugdPersonalGeneral.ActiveRow.Cells("descripcionAgencia").Value), "", ugdPersonalGeneral.ActiveRow.Cells("descripcionAgencia").Value.ToString()) 'jro spint01 24/04/2025
            Me.Close()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmpleado_ValueChanged(sender As Object, e As EventArgs) Handles txtEmpleado.ValueChanged
        Try
            If txtEmpleado.Text.Length > 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPersonalGeneral.Rows
                    If InStr(r.Cells("idContacto").Value, txtEmpleado.Text) <> 0 Or InStr(r.Cells("primerNombreContacto").Value, txtEmpleado.Text) Or InStr(r.Cells("primerApellidoContacto").Value, txtEmpleado.Text) Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Next
            Else
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPersonalGeneral.Rows
                    r.Hidden = False
                Next
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class