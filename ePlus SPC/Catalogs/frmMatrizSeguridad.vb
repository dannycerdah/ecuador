Public Class frmMatrizSeguridad

    Public Sub RefreshData()
        ugdMatrizSeguridad.DataSource = CommonData.GetEntireMatrizSeguridadCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("idMatriz").Hidden = True
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripción"
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("usuarioCreacion").Header.Caption = "Usuario Creación"
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").Header.Caption = "Fecha Creación"
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").Format = "dd/MM/yyyy"
        ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub ugdMatrizSeguridad_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdMatrizSeguridad.DoubleClickCell
        If Not ugdMatrizSeguridad.ActiveRow.Cells("idMatriz").Value.ToString = String.Empty Then
            ShowMatrizSeguridadDetails(ugdMatrizSeguridad.ActiveRow.Cells("idMatriz").Value, ugdMatrizSeguridad.ActiveRow.Cells("descripcion").Value)
        Else
            Using frmDetails As New frmMatrizSeguridadDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowMatrizSeguridadDetails(id As Guid, desc As String)
        Using frmDetails As New frmMatrizSeguridadDetails(id, desc)
            'frmDetails.RefreshData()
            frmDetails.ShowDialog()
        End Using
    End Sub

End Class