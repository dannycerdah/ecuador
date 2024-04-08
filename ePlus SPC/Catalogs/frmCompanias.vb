Imports Infragistics.Win.UltraWinGrid

Public Class frmCompanias
    Private LG_TipoAgencia As Guid
    Public GS_TipoAgencia As String
    Public Property IdUsuario As String

    Public Sub RefreshData(ByVal TipoAgencia As String, ByVal Contactos As Boolean)
        GS_TipoAgencia = TipoAgencia
        ugdCompanias.Text = CommonData.GetTipoAgenciaPorId(TipoAgencia).Rows(0).Item("descripcionTipo")
        LG_TipoAgencia = Guid.Parse(TipoAgencia)
        ugdCompanias.DataSource = CommonData.GetAgenciaPorTipo(TipoAgencia)
        If Contactos Then
            SetDisplayedColumns1()
        Else
            SetDisplayedColumns()
        End If

    End Sub
    Private Sub SetDisplayedColumns()
        Try
            ugdCompanias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
            ugdCompanias.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("TipoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Descripción"
            ugdCompanias.DisplayLayout.Bands(0).Columns("direccionAgencia").Header.Caption = "Dirección"
            ugdCompanias.DisplayLayout.Bands(0).Columns("telefonoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("mailAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("contactoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("observacionAgencia").Header.Caption = "Observación"
            ugdCompanias.DisplayLayout.Bands(0).Columns("estadoAgencia").Header.Caption = "Estado"
            ugdCompanias.DisplayLayout.Bands(0).Columns("abreviatura").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("horaProceso").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("representanteLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("rucLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("tipoContribuyenteLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("razonSocialLegal").Hidden = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetDisplayedColumns1()
        Try
            ugdCompanias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
            ugdCompanias.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("TipoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Descripción"
            ugdCompanias.DisplayLayout.Bands(0).Columns("direccionAgencia").Header.Caption = "Dirección"
            ugdCompanias.DisplayLayout.Bands(0).Columns("telefonoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("mailAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("contactoAgencia").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("observacionAgencia").Header.Caption = "Observación"
            ugdCompanias.DisplayLayout.Bands(0).Columns("estadoAgencia").Header.Caption = "Estado"
            ugdCompanias.DisplayLayout.Bands(0).Columns("abreviatura").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("horaProceso").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("representanteLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("rucLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("tipoContribuyenteLegal").Hidden = True
            ugdCompanias.DisplayLayout.Bands(0).Columns("razonSocialLegal").Hidden = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ugdCompanias_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugdCompanias.DoubleClickCell
        If Not ugdCompanias.ActiveRow.Cells("idAgencia").Value.ToString = String.Empty Then
            If uceTipoConsulta.SelectedIndex <> 2 Then
                ShowAgenciaDetails(ugdCompanias.ActiveRow.Cells("idAgencia").Value)
                'RefreshData(LG_TipoAgencia.ToString, False)
            Else
                ShowContactoAgenciaDetails()
                'RefreshData(LG_TipoAgencia.ToString, True)
            End If

        Else
            If uceTipoConsulta.SelectedIndex <> 2 Then
                'If Not isContacto Then
                Using frmDetails As New frmAgenciaDetails(True, LG_TipoAgencia)
                    frmDetails.ShowDialog()
                End Using
                'RefreshData(tipo, False)
            Else
                Using frmDetails As New frmContactoAgencia(IdUsuario) 'jro 08082018 se agrega el IdUsario que ingresa al sistema 
                    frmDetails.RefreshData(ugdCompanias.ActiveRow.Cells("idAgencia").Value)
                End Using
                'RefreshData(tipo, True)
            End If
        End If
    End Sub
    Private Sub ShowAgenciaDetails(id As Guid)
        Using frmDetails As New frmAgenciaDetails(id, LG_TipoAgencia)
            frmDetails.ShowDialog()
        End Using
    End Sub
    Private Sub ShowContactoAgenciaDetails()
        Using frmDetails As New frmContactoAgencia(IdUsuario) 'jro 08082018 se agrega el IdUsario que ingresa al sistema 
            frmDetails.RefreshData(ugdCompanias.ActiveRow.Cells("idAgencia").Value)
            frmDetails.ShowDialog()
        End Using
    End Sub
    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Dim tipoConsulta As Boolean = False
        If uceTipoConsulta.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Tipo de Consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If uceTipoConsulta.SelectedIndex = 2 Then
                tipoConsulta = True
            End If
            RefreshData(GS_TipoAgencia, tipoConsulta)
        End If
    End Sub
    Private Sub frmCompanias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        uceTipoConsulta.Items.Add(Guid.Empty, "Escoja una opción")
        uceTipoConsulta.Items.Add(Guid.Empty, "Información de Agencia")
        uceTipoConsulta.Items.Add(Guid.Empty, "Personal de la Agencia")
        uceTipoConsulta.SelectedIndex = 1
    End Sub

    Private Sub uceTipoConsulta_SelectionChanged(sender As Object, e As EventArgs) Handles uceTipoConsulta.SelectionChanged
        Dim tipoConsulta As Boolean = False
        If uceTipoConsulta.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Tipo de Consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If uceTipoConsulta.SelectedIndex = 2 Then
                tipoConsulta = True
            End If
            If GS_TipoAgencia <> String.Empty Then
                RefreshData(GS_TipoAgencia, tipoConsulta)
            End If
        End If
    End Sub
End Class