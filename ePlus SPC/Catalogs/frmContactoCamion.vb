Public Class frmContactoCamion
    Dim indice As Guid = Guid.Empty
    Dim idAgencia As Guid = Guid.Empty
    Dim idContacto As String = String.Empty
    Dim fechaIni As Date
    Dim estado As String
    Dim idTransporte As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Public contacto As New Server.ReportService.ContactoCatalogItem

    Public Sub RefreshData()
        cargarComboAgencias()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugvContactos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Identificación"
            ugvContactos.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Nombre"
            ugvContactos.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Apellido"
            ugvContactos.DisplayLayout.Bands(0).Columns("fechaInicio").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvContactos.DisplayLayout.Bands(0).Columns("fechaFin").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvContactos.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("cargo").Hidden = True
            ugvContactos.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugdContactoAgencia_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvContactos.DoubleClickCell
        If Not IsNothing(ugvContactos.ActiveRow.Cells("idContacto").Value) Then
            contacto.idContacto = ugvContactos.ActiveRow.Cells("idContacto").Value
            contacto.primerNombre = ugvContactos.ActiveRow.Cells("primerNombreContacto").Value
            contacto.primerApellido = ugvContactos.ActiveRow.Cells("primerApellidoContacto").Value
            Me.Close()
        End If

        'If Not ugvContactos.ActiveRow.Cells("idContacto").Value.ToString = String.Empty Then
        '    idContacto = ugvContactos.ActiveRow.Cells("idContacto").Value
        '    fechaIni = ugvContactos.ActiveRow.Cells("fechaInicio").Value
        '    estado = ugvContactos.ActiveRow.Cells("estado").Value
        '    indice = ugvContactos.ActiveRow.Cells("indice").Value
        '    ShowTiposContactoAgenciaDetails(idAgencia, idContacto, fechaIni, estado, indice)
        'Else
        '    Using frmDetails As New frmContactoAgenciaDetails(True, idAgencia, idContacto)
        '        frmDetails.ShowDialog()
        '    End Using
        'End If
        'RefreshData(idAgencia)
    End Sub

    Private Sub ShowTiposContactoAgenciaDetails(agencia As Guid, contacto As String, fechaI As Date, estado As String, indice As Guid)
        Using frmDetails As New frmContactoAgenciaDetails(agencia, contacto, fechaI, estado, indice)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub frmContactoCamion_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarComboAgencias()
    End Sub

    Private Sub cargarComboAgencias()
        uceAgencia.Items.Clear()
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(idTransporte).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.Items.Add("001", "TODOS LOS CONTACTOS")
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub uceAgencia_SelectionChanged(sender As Object, e As EventArgs) Handles uceAgencia.SelectionChanged
        If uceAgencia.Text = "TODOS LOS CONTACTOS" Then
            ugvContactos.DataSource = CommonData.GetEntireContactoCatalog
            SetDisplayedColumnsCatalog()
        Else
            ugvContactos.DataSource = CommonData.GetContactoAgenciaPorIdAgencia(uceAgencia.Value)
            SetDisplayedColumns()
        End If
    End Sub

    Private Sub SetDisplayedColumnsCatalog()
        ugvContactos.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Identificación"
        ugvContactos.DisplayLayout.Bands(0).Columns("tipoDocContacto").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Nombre"
        ugvContactos.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Apellido"
        ugvContactos.DisplayLayout.Bands(0).Columns("idPais").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("telefono").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("correo").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("direccionContacto").Hidden = True
        ugvContactos.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Hidden = True
    End Sub

   
    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtContacto.ValueChanged
        If txtContacto.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvContactos.Rows
                If InStr(r.Cells("idContacto").Value, txtContacto.Text) <> 0 Or InStr(r.Cells("primerNombreContacto").Value, txtContacto.Text) Or InStr(r.Cells("primerApellidoContacto").Value, txtContacto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvContactos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub btnContacto_Click(sender As Object, e As EventArgs) Handles btnContacto.Click
        Dim frmDetails As New frmContactoDetails(True)
        frmDetails.ShowDialog()
        RefreshData()
    End Sub
End Class