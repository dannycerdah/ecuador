Public Class frmContactoAgencia
    Dim indice As Guid = Guid.Empty
    Dim idAgencia As Guid = Guid.Empty
    Dim idContacto As String = String.Empty
    Dim fechaIni As Date
    Dim estado As String
    Dim P_IdUsuario As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        P_IdUsuario = IdUsuario
    End Sub
    Public Sub RefreshData(ByVal Agencia As Guid)
        idAgencia = Agencia
        ugdContactoAgencia.DataSource = CommonData.GetContactoAgenciaPorIdAgencia(Agencia)
        If idAgencia = Guid.Parse("1f2ebac3-c1b8-11e3-a62b-d43d7eb25e94") Then 'MARZ
            If MyCurrentUser.isAdministrador Then 'MARZ
                SetDisplayedColumns()
            Else
                SetDisplayedColumns2()
            End If
        Else
            SetDisplayedColumns()
        End If
    End Sub

    Private Sub SetDisplayedColumns2() 'MARZ
        Try
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("descripcionAgencia").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Primer Nombre"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Header.Caption = "Sergundo Nombre"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Primer Apellido"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Header.Caption = "Segundo Apellido"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("direccionContacto").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("telefono").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("correo").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("tagsaContacto").Header.Caption = "Tagsa"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaInicio").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaFin").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("cargo").Header.Caption = "Cargo"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub SetDisplayedColumns()
        Try
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Actividad"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Identificación"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("primerNombreContacto").Header.Caption = "Primer Nombre"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Primer Apellido"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Header.Caption = "Segundo Apellido"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("direccionContacto").Header.Caption = "Dirección"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("telefono").Header.Caption = "Teléfono"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("correo").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("tagsaContacto").Header.Caption = "Tagsa"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaInicio").Header.Caption = "Fecha Inicio"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaFin").Header.Caption = "Fecha Fin"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("comentario").Hidden = True
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("cargo").Header.Caption = "Cargo"
            ugdContactoAgencia.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugdContactoAgencia_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdContactoAgencia.DoubleClickCell
        If Not ugdContactoAgencia.ActiveRow.Cells("idContacto").Value.ToString = String.Empty Then
            idContacto = ugdContactoAgencia.ActiveRow.Cells("idContacto").Value
            fechaIni = ugdContactoAgencia.ActiveRow.Cells("fechaInicio").Value
            estado = ugdContactoAgencia.ActiveRow.Cells("estado").Value
            indice = ugdContactoAgencia.ActiveRow.Cells("indice").Value
            ShowTiposContactoAgenciaDetails(idAgencia, idContacto, fechaIni, estado, indice)
        Else
            Using frmDetails As New frmContactoAgenciaDetails(True, idAgencia, idContacto, P_IdUsuario) '(True, idAgencia, idContacto)'jor 08082018 Se pasa como parametros el usuario que ingreso al sistema
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData(idAgencia)
    End Sub

    Private Sub ShowTiposContactoAgenciaDetails(agencia As Guid, contacto As String, fechaI As Date, estado As String, indice As Guid)
        Using frmDetails As New frmContactoAgenciaDetails(agencia, contacto, fechaI, estado, indice, P_IdUsuario) '(agencia, contacto, fechaI, estado, indice)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdContactoAgencia)
    End Sub

    Private Sub txtbuscarnumci_ValueChanged(sender As Object, e As EventArgs) Handles txtbuscarnumci.ValueChanged
        If txtbuscarnumci.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContactoAgencia.Rows
                If InStr(r.Cells("idContacto").Value, txtbuscarnumci.Text) Or InStr(r.Cells("primerApellidoContacto").Value, txtbuscarnumci.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdContactoAgencia.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class