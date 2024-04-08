
Public Class frmConsultaAgentes
    Dim Id As String = ""
    Public Contacto As New Server.ReportService.ContactoCatalogItem

    Public Sub New(ByVal AgenciaId As String)
        InitializeComponent()
        Id = AgenciaId
        cargarComboAgencia()
    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(Id).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        ugdAgentes.DataSource = CommonData.GetContactoAgenciaPorIdAgencia(uceAgencia.Value)
        RefreshData()
    End Sub

    Public Sub RefreshData()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdAgentes.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Actividad"
            ugdAgentes.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Nombre"
            ugdAgentes.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Apellido"
            ugdAgentes.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("cargo").Header.Caption = "Cargo"
            ugdAgentes.DisplayLayout.Bands(0).Columns("fechaInicio").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("fechaFin").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub ugdAgentes_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugdAgentes.DoubleClickRow
        Contacto.idContacto = ugdAgentes.ActiveRow.Cells("idContacto").Value
        Contacto.idAgencia = ugdAgentes.ActiveRow.Cells("idAgencia").Value
        Contacto.primerNombre = ugdAgentes.ActiveRow.Cells("primerNombreContacto").Value
        Contacto.segundoNombre = ugdAgentes.ActiveRow.Cells("segundoNombreContacto").Value
        Contacto.primerApellido = ugdAgentes.ActiveRow.Cells("primerApellidoContacto").Value
        Contacto.segundoApellido = ugdAgentes.ActiveRow.Cells("segundoApellidoContacto").Value
        Contacto.cargo = ugdAgentes.ActiveRow.Cells("cargo").Value
        Me.Close()
    End Sub

    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtContacto.ValueChanged
        If txtContacto.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdAgentes.Rows
                If InStr(r.Cells("idContacto").Value, txtContacto.Text) <> 0 Or InStr(r.Cells("primerNombreContacto").Value, txtContacto.Text) Or InStr(r.Cells("primerApellidoContacto").Value, txtContacto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdAgentes.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub uceAgencia_ValueChanged(sender As Object, e As EventArgs) Handles uceAgencia.ValueChanged

    End Sub
End Class