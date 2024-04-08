
Public Class frmElegirMatriz
    Public MatrizSeguridadId As Guid
    Public MatrizSeguridadDesc As String
    Public Sub RefreshData()
        ugdMatrizSeguridad.DataSource = CommonData.GetEntireMatrizSeguridadCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try

            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("idMatriz").Hidden = True
            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Descripción"
            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("usuarioCreacion").Header.Caption = "Usuario Creación"
            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").Header.Caption = "Fecha Creación"
            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").Format = "dd/MM/yyyy"
            ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugdMatrizSeguridad_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdMatrizSeguridad.DoubleClickCell
        Try

            If Not ugdMatrizSeguridad.ActiveRow.Cells("idMatriz").Value.ToString = String.Empty Then
                MatrizSeguridadId = ugdMatrizSeguridad.ActiveRow.Cells("idMatriz").Value
                MatrizSeguridadDesc = ugdMatrizSeguridad.ActiveRow.Cells("descripcion").Value
                Me.Close()
            Else
                Using frmDetails As New frmMatrizSeguridadDetails(True)
                    frmDetails.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub



    Private Sub frmElegirMatriz_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshData()
    End Sub
End Class