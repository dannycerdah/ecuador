Imports Infragistics.Win.UltraWinGrid

Public Class frmAgencia

    Dim tipoAgencia As Guid = Guid.Empty
    Public Property tipo As Guid
    Public Property isContacto As Boolean
    Public Property IdUsuario As String

    Public Sub RefreshData(ByVal tipoAgencia As Guid, ByVal contacto As Boolean)
        ugdAgencia.Text = "AGENCIA: " & CommonData.GetTipoAgenciaPorId(tipoAgencia.ToString).Rows(0).Item("descripcionTipo")
        isContacto = contacto
        If isContacto Then
            ugdAgencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Else
            ugdAgencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        End If
        tipo = tipoAgencia
        ugdAgencia.DataSource = CommonData.GetAgenciaPorTipo(tipoAgencia.ToString)
        If tipoAgencia = Guid.Parse("04be18e6-fd0c-4466-aed2-04b0e8025772") Then
            SetDisplayedColumns()
        Else
            SetDisplayedColumns1()
        End If
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdAgencia.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("TipoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Descripción"
            ugdAgencia.DisplayLayout.Bands(0).Columns("direccionAgencia").Header.Caption = "Dirección"
            ugdAgencia.DisplayLayout.Bands(0).Columns("telefonoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("mailAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("contactoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("observacionAgencia").Header.Caption = "Observación"
            ugdAgencia.DisplayLayout.Bands(0).Columns("estadoAgencia").Header.Caption = "Estado"
            ugdAgencia.DisplayLayout.Bands(0).Columns("abreviatura").Header.Caption = "Abreviatura"
            ugdAgencia.DisplayLayout.Bands(0).Columns("horaProceso").Header.Caption = "Horas de Proceso"
            ugdAgencia.DisplayLayout.Bands(0).Columns("representanteLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("rucLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("tipoContribuyenteLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("razonSocialLegal").Hidden = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetDisplayedColumns1()
        Try
            ugdAgencia.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("TipoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Descripción"
            ugdAgencia.DisplayLayout.Bands(0).Columns("direccionAgencia").Header.Caption = "Dirección"
            ugdAgencia.DisplayLayout.Bands(0).Columns("telefonoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("mailAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("contactoAgencia").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("observacionAgencia").Header.Caption = "Observación"
            ugdAgencia.DisplayLayout.Bands(0).Columns("estadoAgencia").Header.Caption = "Estado"
            ugdAgencia.DisplayLayout.Bands(0).Columns("abreviatura").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("horaProceso").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("representanteLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("rucLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("tipoContribuyenteLegal").Hidden = True
            ugdAgencia.DisplayLayout.Bands(0).Columns("razonSocialLegal").Hidden = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ugdAgencia_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdAgencia.DoubleClickCell
        If Not ugdAgencia.ActiveRow.Cells("idAgencia").Value.ToString = String.Empty Then
            If Not isContacto Then
                ShowAgenciaDetails(ugdAgencia.ActiveRow.Cells("idAgencia").Value)
                RefreshData(tipo, False)
            Else
                ShowContactoAgenciaDetails()
                RefreshData(tipo, True)
            End If
        Else
            If Not isContacto Then
                Using frmDetails As New frmAgenciaDetails(True, tipo)
                    frmDetails.ShowDialog()
                End Using
                RefreshData(tipo, False)
            Else
                Using frmDetails As New frmContactoAgencia(IdUsuario)
                    'Using frmDetails As New frmContactoAgencia() ''21122018 jro
                    frmDetails.RefreshData(ugdAgencia.ActiveRow.Cells("idAgencia").Value)
                End Using
                RefreshData(tipo, True)
            End If
        End If
    End Sub

    Private Sub ShowAgenciaDetails(id As Guid)
        Using frmDetails As New frmAgenciaDetails(id, tipo)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ShowContactoAgenciaDetails()
        Using frmDetails As New frmContactoAgencia(IdUsuario) 'Using frmDetails As New frmContactoAgencia()'21122018 jro
            frmDetails.RefreshData(ugdAgencia.ActiveRow.Cells("idAgencia").Value)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        If uceTipoAgencia.SelectedIndex = 0 Or uceTipoConsulta.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Agencia y/o Tipo de Consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim tipoConsulta As Boolean = False
            If uceTipoConsulta.SelectedIndex = 2 Then
                tipoConsulta = True
            End If
            RefreshData(uceTipoAgencia.Value, tipoConsulta)
        End If
    End Sub

    Private Sub frmAgencia_Load(sender As Object, e As EventArgs) Handles Me.Load
        uceTipoAgencia.Items.Add(Guid.Empty, "Escoja una opción")
        uceTipoAgencia.Items.Add(Guid.Parse("38b4e437-f3dd-4625-8e73-538858824fce"), "Generalairsa S.A.")
        uceTipoAgencia.Items.Add(Guid.Parse("04be18e6-fd0c-4466-aed2-04b0e8025772"), "Aerolíneas")
        uceTipoAgencia.Items.Add(Guid.Parse("e4bc6f72-6aee-42e0-a060-6cab35ab8867"), "Agencias de Carga")
        uceTipoAgencia.Items.Add(Guid.Parse("9cf3597e-0d79-4498-8d58-5889045c3729"), "Instituciones")
        uceTipoAgencia.Items.Add(Guid.Parse("d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"), "Agencias de Seguridad")
        uceTipoAgencia.Items.Add(Guid.Parse("65ec9238-d302-49e9-bbb5-038e1caea03c"), "Agencias de Rampa")
        uceTipoAgencia.Items.Add(Guid.Parse("34d5b7d2-db23-44da-8f79-e05329c20377"), "EXPOREXPRESS")

        uceTipoAgencia.SelectedIndex = 0
        'Tipo de consutla
        uceTipoConsulta.Items.Add(Guid.Empty, "Escoja una opción")
        uceTipoConsulta.Items.Add(Guid.Empty, "Información de Agencia")
        uceTipoConsulta.Items.Add(Guid.Empty, "Personal de la Agencia")
        uceTipoConsulta.SelectedIndex = 0
    End Sub

End Class