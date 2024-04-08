Public Class FrmDetallePlantillaClientServ
    Private DtDetallePlantilla As New DataTable("DtDetallePlantilla")
    Private NewReg As Boolean
    Private IdUsuario As String
    Private PlantillaClienServ As New Server.Facturacion.PlantillaClienServ
    Public Sub New(_NewReg As Boolean, _IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _IdUsuario
    End Sub
    Public Sub New(_NewReg As Boolean, _PlantillaClienServ As Server.Facturacion.PlantillaClienServ)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _PlantillaClienServ.UsuarioIngreso
        PlantillaClienServ = _PlantillaClienServ
    End Sub
    Private Sub FrmDetallePlantillaClientServ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarClientes()
            CargarServicios()
            CargarPeriodicidad()
            With DtDetallePlantilla.Columns
                .Add("idCliente", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("idServiciosGA", GetType(Integer))
                .Add("DescripcionServicio", GetType(String))
                .Add("idPeriodicidad", GetType(Integer))
                .Add("DescripcionPeriodicidad", GetType(String))
                .Add("ValorPeriodicidad", GetType(Integer))
                .Add("ValorTarifa", GetType(Double))
                .Add("CantAlmaContainerPer", GetType(Double))
                .Add("IdComparacionServicio", GetType(Integer))
                .Add("DescripcionServicioComp", GetType(String))
            End With
            ugvListPlantillaClientServ.DataSource = DtDetallePlantilla
            SetDisplayedColumnsPlantilla()
            If NewReg = False Then
                For r = 0 To uceClientes.Items.Count - 1
                    If uceClientes.Items.[All](r).DataValue = PlantillaClienServ.IdCliente Then
                        uceClientes.SelectedIndex = r
                        uceClientes.Enabled = False
                        Exit For
                    End If
                Next
                For r = 0 To uceServicios.Items.Count - 1
                    If uceServicios.Items.[All](r).DataValue = PlantillaClienServ.idServiciosGA Then
                        uceServicios.SelectedIndex = r
                        uceServicios.Enabled = False
                        Exit For
                    End If
                Next
                For r = 0 To uceServiciosComp.Items.Count - 1
                    If uceServiciosComp.Items.[All](r).DataValue = PlantillaClienServ.IdComparacionServicio Then
                        uceServiciosComp.SelectedIndex = r
                        Exit For
                    End If
                Next
                For r = 0 To ucePeriodicidad.Items.Count - 1
                    If ucePeriodicidad.Items.[All](r).DataValue = PlantillaClienServ.idPeriodicidad Then
                        ucePeriodicidad.SelectedIndex = r
                        Exit For
                    End If
                Next
                NumTarifa.Value = PlantillaClienServ.ValorTarifa
                If IsNothing(PlantillaClienServ.CantAlmaContainerPer) = False Or PlantillaClienServ.CantAlmaContainerPer <> String.Empty Then
                    NumContainer.Value = PlantillaClienServ.CantAlmaContainerPer
                    NumContainer.Enabled = True
                    chkContainer.Checked = True
                End If
                If PlantillaClienServ.Estado = "A" Then
                    uceEstado.SelectedIndex = 0
                Else
                    uceEstado.SelectedIndex = 1
                End If
                BtnAgregar.Enabled = False
                btnUpdate.Enabled = True
                ugvListPlantillaClientServ.Enabled = False
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsPlantilla()
        Try
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("idCliente").Hidden = True
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Cliente"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("descripcionAgencia").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("idServiciosGA").Hidden = True
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionServicio").Header.Caption = "Servicio"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionServicio").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("idPeriodicidad").Hidden = True
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Header.Caption = "Periodicidad"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Case = Infragistics.Win.UltraWinGrid.Case.Upper
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").Header.Caption = "Unidad"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("ValorTarifa").Header.Caption = "Tarifa"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("ValorTarifa").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("CantAlmaContainerPer").Header.Caption = "Containers Permitidos"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("CantAlmaContainerPer").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("IdComparacionServicio").Hidden = True
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionServicioComp").Header.Caption = "Serv. a Comprar"
            ugvListPlantillaClientServ.DisplayLayout.Bands(0).Columns("DescripcionServicioComp").Case = Infragistics.Win.UltraWinGrid.Case.Upper
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarClientes()
        Try
            uceClientes.Items.Clear()
            uceClientes.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetClientes.Rows
                If r.Item("Estado") = "A" Then
                    uceClientes.Items.Add(r.Item("idCliente"), r.Item("descripcionAgencia"))
                End If
            Next
            uceClientes.SelectedIndex = 0
            uceEstado.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarServicios()
        Try
            uceServicios.Items.Clear()
            uceServiciosComp.Items.Clear()
            uceServicios.Items.Add(0, "Escoja una opción")
            uceServiciosComp.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetServiciosGA.Rows
                If r.Item("Estado") = "A" Then
                    uceServicios.Items.Add(r.Item("idServiciosGA"), r.Item("DescripcionServicio"))
                    uceServiciosComp.Items.Add(r.Item("idServiciosGA"), r.Item("DescripcionServicio"))
                End If
            Next
            uceServicios.SelectedIndex = 0
            uceServiciosComp.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarPeriodicidad()
        Try
            ucePeriodicidad.Items.Clear()
            ucePeriodicidad.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetPeriodicidad.Rows
                If r.Item("Estado") = "A" Then
                    ucePeriodicidad.Items.Add(r.Item("idPeriodicidad"), r.Item("DescripcionPeriodicidad"))
                End If
            Next
            ucePeriodicidad.SelectedIndex = 0
            uceEstado.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        If DtDetallePlantilla.Rows.Count > 0 Then
            For Each r As DataRow In DtDetallePlantilla.Rows
                If r.Item("idCliente") = uceClientes.Value And r.Item("idServiciosGA") = uceServicios.Value Then
                    addRow = False
                    Exit For
                End If
            Next
        End If
        If addRow And NewReg Then
            Dim PlantillaClienServ As New Server.Facturacion.PlantillaClienServ
            row = DtDetallePlantilla.NewRow
            row.Item("idCliente") = uceClientes.Value
            row.Item("descripcionAgencia") = uceClientes.Text
            row.Item("idServiciosGA") = uceServicios.Value
            row.Item("DescripcionServicio") = uceServicios.Text
            row.Item("idPeriodicidad") = ucePeriodicidad.Value
            row.Item("DescripcionPeriodicidad") = ucePeriodicidad.Text
            row.Item("ValorPeriodicidad") = NumPeriodi.Value
            row.Item("ValorTarifa") = NumTarifa.Value
            With PlantillaClienServ
                If NumContainer.Enabled Then
                    row.Item("CantAlmaContainerPer") = NumContainer.Value
                    .CantAlmaContainerPer = NumContainer.Value
                End If
                If uceServiciosComp.SelectedIndex <> 0 Then
                    row.Item("IdComparacionServicio") = uceServiciosComp.Value
                    row.Item("DescripcionServicioComp") = uceServiciosComp.Value
                    .IdComparacionServicio = uceServiciosComp.Value
                End If
                .IdCliente = uceClientes.Value
                .idServiciosGA = uceServicios.Value
                .idPeriodicidad = ucePeriodicidad.Value
                .ValorPeriodicidad = NumPeriodi.Value
                .ValorTarifa = NumTarifa.Value
                .UsuarioIngreso = IdUsuario
            End With
            If CommonDataFact.MantPlantiClienteServ(PlantillaClienServ) Then
                MessageBox.Show("Servicio Ingresado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtDetallePlantilla.Rows.Add(row)
            End If
        End If
    End Sub
    Private Sub chkContainer_CheckedChanged(sender As Object, e As EventArgs) Handles chkContainer.CheckedChanged
        If chkContainer.Checked Then
            NumContainer.Enabled = True
        Else
            NumContainer.Enabled = False
        End If
    End Sub
    Private Sub ugvListPlantillaClientServ_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvListPlantillaClientServ.AfterRowActivate
        With PlantillaClienServ
            .IdCliente = ugvListPlantillaClientServ.ActiveRow.Cells("idCliente").Value
            .idServiciosGA = ugvListPlantillaClientServ.ActiveRow.Cells("idServiciosGA").Value
            .UsuarioIngreso = IdUsuario
        End With
    End Sub
    Private Sub ugvListPlantillaClientServ_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvListPlantillaClientServ.AfterRowsDeleted
        PlantillaClienServ.Estado = "E"
        If CommonDataFact.MantPlantiClienteServ(PlantillaClienServ) Then
            MessageBox.Show("Servicio Eliminado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        With PlantillaClienServ
            If NumContainer.Enabled Then
                .CantAlmaContainerPer = NumContainer.Value
            Else
                .CantAlmaContainerPer = Nothing
            End If
            If uceServiciosComp.SelectedIndex <> 0 Then
                .IdComparacionServicio = uceServiciosComp.Value
            End If
            .idPeriodicidad = ucePeriodicidad.Value
            .ValorPeriodicidad = NumPeriodi.Value
            .ValorTarifa = NumTarifa.Value
            .Estado = uceEstado.Value
            .UsuarioIngreso = IdUsuario
        End With
        If CommonDataFact.MantPlantiClienteServ(PlantillaClienServ) Then
            MessageBox.Show("Servicio Actualzado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    Private Sub ucePeriodicidad_ValueChanged(sender As Object, e As EventArgs) Handles ucePeriodicidad.ValueChanged
        NumPeriodi.Value = 0
    End Sub
End Class