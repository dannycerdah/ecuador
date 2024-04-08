Public Class FrmRegistroConsuServ
    Private dtServiciosConsumidosCliente As New DataTable("dtServiciosConsumidosCliente")
    Private dtClienteAgencia As New DataTable("dtClienteAgencia")
    Private P_idBriefing As Guid
    Private P_idGuia As Guid
    Private PlantillaClienServ As New Server.Facturacion.ServConsuCliente
    Private Property myDetalleVuelo As New Server.VuelosService.DetalleVuelo
    Public IdUsuario As String
    Private Sub FrmRegistroConsuServ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dtServiciosConsumidosCliente.Columns
            .Add("idServConsuCliente", GetType(Integer))
            .Add("idCliente", GetType(Integer))
            .Add("descripcionAgencia", GetType(String))
            .Add("idServiciosGA", GetType(Integer))
            .Add("DescripcionServicio", GetType(String))
            .Add("idBriefing", GetType(Guid))
            .Add("idGuia", GetType(Guid))
            .Add("Guia", GetType(String))
            .Add("CodigoVuelo", GetType(String))
            .Add("FechaInicio", GetType(DateTime))
            .Add("FechaFin", GetType(DateTime))
        End With
        ugvListServConsuCliente.DataSource = dtServiciosConsumidosCliente
        With dtClienteAgencia.Columns
            .Add("idCliente", GetType(Integer))
            .Add("descripcionAgencia", GetType(String))
            .Add("idAgencia", GetType(Guid))
        End With
        CargarClientes()
        CargarServicios()
        CargaServConsuHoy()
        SetDisplayedColumnsPlantilla()

    End Sub
    Private Sub CargarClientes()
        Try
            Dim rows As DataRow
            uceClientes.Items.Clear()
            uceClientes.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetClientes.Rows
                If r.Item("Estado") = "A" Then
                    rows = dtClienteAgencia.NewRow
                    uceClientes.Items.Add(r.Item("idCliente"), r.Item("descripcionAgencia"))
                    rows.Item("idCliente") = r.Item("idCliente")
                    rows.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    rows.Item("idAgencia") = r.Item("idAgencia")
                    dtClienteAgencia.Rows.Add(rows)
                End If
            Next
            uceClientes.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarServicios()
        Try
            uceServicios.Items.Clear()
            uceServicios.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetServiciosGA.Rows
                If r.Item("Estado") = "A" And r.Item("Tipo") = "S" Then
                    uceServicios.Items.Add(r.Item("idServiciosGA"), r.Item("DescripcionServicio"))
                End If
            Next
            uceServicios.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsPlantilla()
        Try
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("idServConsuCliente").Hidden = True
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("idCliente").Hidden = True
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("idServiciosGA").Hidden = True
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("FechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("FechaInicio").Format = "dd/MM/yyyy HH:mm:ss"
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("FechaFin").Format = "dd/MM/yyyy HH:mm:ss"
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Cliente"
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("DescripcionServicio").Header.Caption = "Servicio"
            ugvListServConsuCliente.DisplayLayout.Bands(0).Columns("CodigoVuelo").Header.Caption = "Vuelo"
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargaServConsuHoy()
        Try
            Dim row As DataRow
            For Each r As DataRow In CommonDataFact.GetSerConsuCliente.Rows
                row = dtServiciosConsumidosCliente.NewRow
                row.Item("idServConsuCliente") = r.Item("idServConsuCliente")
                row.Item("idCliente") = r.Item("idCliente")
                row.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                row.Item("idServiciosGA") = r.Item("idServiciosGA")
                row.Item("DescripcionServicio") = r.Item("DescripcionServicio")
                row.Item("idBriefing") = r.Item("idBriefing")
                row.Item("idGuia") = r.Item("idGuia")
                row.Item("Guia") = r.Item("Guia")
                row.Item("CodigoVuelo") = r.Item("CodigoVuelo")
                row.Item("FechaInicio") = r.Item("FechaInicio")
                row.Item("FechaFin") = r.Item("FechaFin")
                dtServiciosConsumidosCliente.Rows.Add(row)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            If uceClientes.Value <> 0 Then
                Dim row As DataRow()
                row = dtClienteAgencia.Select("idCliente='" & uceClientes.Value.ToString & "'")
                If row.Count > 0 Then
                    For Each r As DataRow In row
                        Dim frmConsultaVuelos As New FrmConsultaVuelosGuias(uceClientes.Text, r.Item(2))
                        frmConsultaVuelos.ShowDialog()
                        txtNumVuelo.Text = frmConsultaVuelos.CodigoVuelo
                        txtGuia.Text = frmConsultaVuelos.Guia
                        P_idBriefing = frmConsultaVuelos.IdBriefing
                        P_idGuia = frmConsultaVuelos.IdGuia
                    Next
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim fechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim fechaFinal As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        If dtServiciosConsumidosCliente.Rows.Count > 0 Then
            For Each r As DataRow In dtServiciosConsumidosCliente.Rows
                If r.Item("idCliente") = uceClientes.Value And r.Item("idServiciosGA") = uceServicios.Value And r.Item("FechaInicio") = fechaInicio And r.Item("FechaFin") = fechaFinal Then
                    addRow = False
                    Exit For
                End If
            Next
        End If
        If addRow Then
            Dim PlantillaClienServ As New Server.Facturacion.ServConsuCliente
            row = dtServiciosConsumidosCliente.NewRow
            row.Item("idCliente") = uceClientes.Value
            row.Item("descripcionAgencia") = uceClientes.Text
            row.Item("idServiciosGA") = uceServicios.Value
            row.Item("DescripcionServicio") = uceServicios.Text
            row.Item("FechaInicio") = fechaInicio
            row.Item("FechaFin") = fechaFinal
            row.Item("idBriefing") = P_idBriefing
            row.Item("CodigoVuelo") = txtNumVuelo.Text
            row.Item("idGuia") = P_idGuia
            row.Item("Guia") = txtGuia.Text
            With PlantillaClienServ
                .IdCliente = uceClientes.Value
                .idServiciosGA = uceServicios.Value
                .idBriefing = P_idBriefing
                .idGuia = P_idGuia
                .Guia = txtGuia.Text
                .FechaInicio = fechaInicio
                .FechaFin = fechaFinal
                .UsuarioIngreso = IdUsuario
            End With
            If CommonDataFact.MantServConsuCliente(PlantillaClienServ) Then
                MessageBox.Show("Servicio Ingresado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtServiciosConsumidosCliente.Rows.Add(row)
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ugvListServConsuCliente_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvListServConsuCliente.AfterRowActivate
        With PlantillaClienServ
            .idServConsuCliente = IIf(IsDBNull(ugvListServConsuCliente.ActiveRow.Cells("idServConsuCliente").Value), 0, ugvListServConsuCliente.ActiveRow.Cells("idServConsuCliente").Value)
            .idCliente = ugvListServConsuCliente.ActiveRow.Cells("idCliente").Value
            .idServiciosGA = ugvListServConsuCliente.ActiveRow.Cells("idServiciosGA").Value
            .idBriefing = ugvListServConsuCliente.ActiveRow.Cells("idBriefing").Value
            .idGuia = ugvListServConsuCliente.ActiveRow.Cells("idGuia").Value
            .Guia = ugvListServConsuCliente.ActiveRow.Cells("Guia").Value
            .FechaInicio = ugvListServConsuCliente.ActiveRow.Cells("FechaInicio").Value
            .FechaFin = ugvListServConsuCliente.ActiveRow.Cells("FechaFin").Value
            .UsuarioIngreso = IdUsuario
        End With
    End Sub

    Private Sub ugvListServConsuCliente_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvListServConsuCliente.AfterRowsDeleted
        PlantillaClienServ.Estado = "E"
        If CommonDataFact.MantServConsuCliente(PlantillaClienServ) Then
            MessageBox.Show("Registro Eliminado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class