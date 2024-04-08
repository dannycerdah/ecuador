Public Class FrmPlantillaClientServ
    Private dtPlantilla As New DataTable("dtPlantilla")
    Public IdUsuario As String
    Public Sub RefreshData()
        ObtenerPlantilla()
    End Sub
    Private Function ObtenerPlantilla() As DataTable
        Dim row As DataRow
        Try
            dtPlantilla.Clear()
            For Each r As DataRow In CommonDataFact.GetPlantiClienteServ(0).Rows
                row = dtPlantilla.NewRow
                row.Item("idPlantillaClienteServicio") = r.Item("idPlantillaClienteServicio")
                row.Item("IdCliente") = r.Item("IdCliente")
                row.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                row.Item("idServiciosGA") = r.Item("idServiciosGA")
                row.Item("DescripcionServicio") = r.Item("DescripcionServicio")
                row.Item("idPeriodicidad") = r.Item("idPeriodicidad")
                row.Item("DescripcionPeriodicidad") = r.Item("DescripcionPeriodicidad")
                row.Item("ValorPeriodicidad") = r.Item("ValorPeriodicidad")
                row.Item("ValorTarifa") = r.Item("ValorTarifa")
                row.Item("CantAlmaContainerPer") = r.Item("CantAlmaContainerPer")
                row.Item("IdComparacionServicio") = r.Item("IdComparacionServicio")
                row.Item("estado") = r.Item("estado")
                dtPlantilla.Rows.Add(row)
            Next
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub FrmPlantillaClientServ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With dtPlantilla.Columns
                .Add("idPlantillaClienteServicio", GetType(Integer))
                .Add("IdCliente", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("idServiciosGA", GetType(Integer))
                .Add("DescripcionServicio", GetType(String))
                .Add("idPeriodicidad", GetType(Integer))
                .Add("DescripcionPeriodicidad", GetType(String))
                .Add("ValorPeriodicidad", GetType(Integer))
                .Add("ValorTarifa", GetType(Double))
                .Add("CantAlmaContainerPer", GetType(Integer))
                .Add("IdComparacionServicio", GetType(Integer))
                .Add("estado", GetType(String))
            End With
            ugdPlantilla.DataSource = dtPlantilla
            SetDisplayedColumnsPlantilla()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsPlantilla()
        Try
            ugdPlantilla.DisplayLayout.Bands(0).Columns("idPlantillaClienteServicio").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("IdCliente").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("idServiciosGA").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("idPeriodicidad").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("CantAlmaContainerPer").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("IdComparacionServicio").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdPlantilla.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Cliente"
            ugdPlantilla.DisplayLayout.Bands(0).Columns("descripcionAgencia").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionServicio").Header.Caption = "Servicio"
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionServicio").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Header.Caption = "Periodicidad"
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").Header.Caption = "Unidad"
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorTarifa").Header.Caption = "Valor Tarifa"
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorTarifa").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionServicio").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            ugdPlantilla.DisplayLayout.Bands(0).Columns("descripcionAgencia").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorTarifa").Width = Len(ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorTarifa").Header.Caption)
            ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").Width = Len(ugdPlantilla.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").Header.Caption)
            ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Width = Len(ugdPlantilla.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Header.Caption)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ugdPlantilla_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPlantilla.DoubleClickCell
        Dim PlantillaClienServ As New Server.Facturacion.PlantillaClienServ
        Try
            If Not ugdPlantilla.ActiveRow.Cells("idCliente").Value.ToString = String.Empty Then
                With PlantillaClienServ
                    .idPlantillaClienteServicio = ugdPlantilla.ActiveRow.Cells("idPlantillaClienteServicio").Value
                    .IdCliente = ugdPlantilla.ActiveRow.Cells("IdCliente").Value
                    .idServiciosGA = ugdPlantilla.ActiveRow.Cells("idServiciosGA").Value
                    .idPeriodicidad = ugdPlantilla.ActiveRow.Cells("idPeriodicidad").Value
                    .ValorPeriodicidad = ugdPlantilla.ActiveRow.Cells("ValorPeriodicidad").Value
                    .ValorTarifa = ugdPlantilla.ActiveRow.Cells("ValorTarifa").Value
                    .CantAlmaContainerPer = IIf(IsDBNull(ugdPlantilla.ActiveRow.Cells("CantAlmaContainerPer").Value), Nothing, ugdPlantilla.ActiveRow.Cells("CantAlmaContainerPer").Value)
                    .IdComparacionServicio = ugdPlantilla.ActiveRow.Cells("IdComparacionServicio").Value
                    .Estado = ugdPlantilla.ActiveRow.Cells("estado").Value
                    .UsuarioIngreso = IdUsuario
                End With
                Using frmDetails As New FrmDetallePlantillaClientServ(False, PlantillaClienServ)
                    frmDetails.ShowDialog()
                End Using
            Else
                Using frmDetails As New FrmDetallePlantillaClientServ(True, IdUsuario)
                    frmDetails.ShowDialog()
                End Using
            End If
            ' RefreshData()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtPlantilla_ValueChanged(sender As Object, e As EventArgs) Handles txtPlantilla.ValueChanged
        Try
            If txtPlantilla.Text.Length > 0 Then
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPlantilla.Rows
                    If InStr(r.Cells("descripcionAgencia").Value, txtPlantilla.Text) <> 0 Or InStr(r.Cells("DescripcionServicio").Value, txtPlantilla.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Next
            Else
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPlantilla.Rows
                    r.Hidden = False
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class