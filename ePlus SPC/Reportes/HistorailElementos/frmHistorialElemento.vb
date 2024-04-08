Public Class frmHistorialElemento
    Dim tipoAgencia As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim ln_check As Integer
    Public Sub RefreshData()
        ugdElemento.DataSource = CommonData.GetElementoCatalog()
        SetDisplayedColumns()
        UltCheckFecha.Checked = True
        uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgencia).Rows
            uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("DescripcionAgencia"))
        Next
    End Sub

    Private Sub SetDisplayedColumns()
        ugdElemento.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Codigo"
        ugdElemento.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea"
        ugdElemento.DisplayLayout.Bands(0).Columns("tipoElemento").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPiso").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPared").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialTecho").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialRed").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPuerta").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialSeguros").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("alto").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("ancho").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("largo").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReferencial").Header.Caption = "Peso Referencial"
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoActual").Header.Caption = "Peso Actual"
        ugdElemento.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").Header.Caption = "Fecha Ingreso"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").Format = "dd/MM/yyyy"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdElemento.DisplayLayout.Bands(0).Columns("usuarioIngreso").Header.Caption = "Usuario Ingreso"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Header.Caption = "Fecha Ultima Actualización"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Format = "dd/MM/yyyy"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs) Handles txtElemento.ValueChanged
        If txtElemento.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdElemento.Rows
                If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdElemento.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub ugdElemento_DoubleClickCell1(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdElemento.DoubleClickCell
        If Not ugdElemento.ActiveRow.Cells("idElemento").Value.ToString = String.Empty Then
            Using frmDetails As New frmHistorialElementoDetalle
                frmDetails.elemento = CommonData.GetElementoItem(ugdElemento.ActiveRow.Cells("idElemento").Value.ToString)
                With frmDetails.elementoHistorico
                    .idAgencia = uceAerolinea.Value
                    .ln_chekFecha = 0
                    .fechaInicio = udtDesde.Value
                    .fechaFin = udtHasta.Value
                End With
                frmDetails.ShowDialog()
            End Using
        End If
        'RefreshData()
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdElemento)
    End Sub

    Private Sub UltBtnBuscarHistorico_Click(sender As Object, e As EventArgs) Handles UltBtnBuscarHistorico.Click
        Using frmDetails As New frmHistorialElementoDetalle
            frmDetails.elemento.Id = txtElemento.Text
            frmDetails.elemento.IdAgencia = uceAerolinea.Value
            With frmDetails.elementoHistorico
                .idAgencia = uceAerolinea.Value
                .ln_chekFecha = ln_check
                .fechaInicio = udtDesde.Value
                .fechaFin = udtHasta.Value
            End With
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub UltCheckFecha_CheckedChanged(sender As Object, e As EventArgs) Handles UltCheckFecha.CheckedChanged
        If UltCheckFecha.Checked Then
            udtDesde.Enabled = True
            udtHasta.Enabled = True
            ln_check = 1
        Else
            udtDesde.Enabled = False
            udtHasta.Enabled = False
            ln_check = 0
        End If
    End Sub
End Class