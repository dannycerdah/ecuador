Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Public Class frmDevolucionDeCarga

    Dim myDetalleVuelo As New DetalleVuelo
    Dim myDetalleVueloB As New DetalleVuelo
    Dim procesoA As New ProcesoItem
    Dim procesoB As New ProcesoItem
    Dim elementoBriefingA As New Server.VuelosService.ElementoBriefingItem
    Dim elementoBriefingB As New Server.VuelosService.ElementoBriefingItem
    Dim dtElementosA As New DataTable("Elementos")
    Dim dtElementosB As New DataTable("Elementos")
    Dim dtGuias As New DataTable("Guias")
    Dim dtGuiasDevuelto As New DataTable("GuiasDevuelto")
    Dim dtElemento As New DataTable("Elementos")
    Dim dtDetallePorGuiaA As New DataTable("dtPorGuiaA")
    Dim dtDetallePorElementoA As New DataTable("dtPorElementoA")
    Dim dtDetallePorElementoDevuelto As New DataTable("dtPorElementoB")
    Dim detalleProcesoItemMov As New DetalleProcesoItem
    Public Property IdUsuario As String

    Private Sub frmMovimientoDeCarga_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dtGuias.Columns
            .Add("idGuia", GetType(Guid))
            .Add("descripcion", GetType(String))
            .Add("idBriefing", GetType(Guid))
            .Add("ciudadDestino", GetType(String))
            .Add("idAgencia", GetType(Guid))
            .Add("descripcionAgencia", GetType(String))
            .Add("peso", GetType(Decimal))
            .Add("bultos", GetType(Integer))
            .Add("fechaLlegada", GetType(DateTime))
            .Add("estado", GetType(String))
            .Add("DAE", GetType(String))
            .Add("camionAsig", GetType(Boolean))
        End With
        With dtGuiasDevuelto.Columns
            .Add("chck", GetType(Boolean))
            .Add("idProceso", GetType(Guid))
            .Add("fecha", GetType(DateTime))
            .Add("idGuia", GetType(Guid))
            .Add("idElemento", GetType(String))
            .Add("piezas", GetType(Integer))
            .Add("peso", GetType(Decimal))
            .Add("idProducto", GetType(Guid))
            .Add("descripcionProducto", GetType(String))
            .Add("guia", GetType(String))
            .Add("estado", GetType(String))
            .Add("indice", GetType(Guid))
        End With
        With dtDetallePorGuiaA.Columns
            .Add("chck", GetType(Boolean))
            .Add("idProceso", GetType(Guid))
            .Add("fecha", GetType(DateTime))
            .Add("idGuia", GetType(Guid))
            .Add("idElemento", GetType(String))
            .Add("piezas", GetType(Integer))
            .Add("peso", GetType(Decimal))
            .Add("idProducto", GetType(Guid))
            .Add("descripcionProducto", GetType(String))
            .Add("guia", GetType(String))
            .Add("estado", GetType(String))
            .Add("indice", GetType(Guid))
        End With
        With dtDetallePorElementoA.Columns
            .Add("chck", GetType(Boolean))
            .Add("idProceso", GetType(Guid))
            .Add("fecha", GetType(DateTime))
            .Add("idGuia", GetType(Guid))
            .Add("idElemento", GetType(String))
            .Add("piezas", GetType(Integer))
            .Add("peso", GetType(Decimal))
            .Add("idProducto", GetType(Guid))
            .Add("descripcionProducto", GetType(String))
            .Add("guia", GetType(String))
            .Add("estado", GetType(String))
            .Add("indice", GetType(Guid))
        End With
        With dtDetallePorElementoDevuelto.Columns
            .Add("chck", GetType(Boolean))
            .Add("idProceso", GetType(Guid))
            .Add("fecha", GetType(DateTime))
            .Add("idGuia", GetType(Guid))
            .Add("idElemento", GetType(String))
            .Add("piezas", GetType(Integer))
            .Add("peso", GetType(Decimal))
            .Add("idProducto", GetType(Guid))
            .Add("descripcionProducto", GetType(String))
            .Add("guia", GetType(String))
            .Add("estado", GetType(String))
            .Add("indice", GetType(Guid))
        End With
        btnToLeft.Enabled = False
        btnToRight.Enabled = False
        uceElementosA.Enabled = False
        uceElementoB.Enabled = False
        uceGuiasA.Enabled = False
        uceGuiaB.Enabled = False
        chckTodoGuiaA.Enabled = False
        chckTodoElementoA.Enabled = False
        chckTodoGuiaB.Enabled = False
        chckTodoElmenetoB.Enabled = False
        detalleProcesoItemMov.UsusarioIngreso = IdUsuario
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub LimpiarB()

    End Sub

    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVueloA.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                consultaProcesoA()
                ObtenerGuias(myDetalleVuelo.idBriefing)
                cargarGuias()
                CargarElementosA()
                cargarGuiasDevuelto()
                CargarElementosDevuelto()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarElementosA()
        Try
            elementoBriefingA.idBriefing = myDetalleVuelo.idBriefing
            dtElementosA = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefingA)
            If Not IsNothing(dtGuias) Then
                uceElementosA.Enabled = True
                chckTodoElementoA.Enabled = True
                uceElementosA.Items.Clear()
                For Each r As DataRow In dtElementosA.Rows
                    uceElementosA.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
                Next
                uceElementosA.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CargarElementosDevuelto()
        Try
            elementoBriefingA.idBriefing = myDetalleVuelo.idBriefing
            dtElementosB = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefingA)
            If Not IsNothing(dtGuias) Then
                uceElementoB.Enabled = True
                chckTodoElmenetoB.Enabled = True
                uceElementoB.Items.Clear()
                For Each r As DataRow In dtElementosB.Rows
                    uceElementoB.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
                Next
                uceElementoB.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarGuias()
        Try
            If Not IsNothing(dtGuias) Then
                uceGuiasA.Enabled = True
                chckTodoGuiaA.Enabled = True
                uceGuiasA.Items.Clear()
                For Each r As DataRow In dtGuias.Rows
                    uceGuiasA.Items.Add(r.Item("idGuia"), r.Item("descripcion"))
                Next
                uceGuiasA.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarGuiasDevuelto()
        Try
            If Not IsNothing(dtGuias) Then
                uceGuiaB.Enabled = True
                chckTodoGuiaB.Enabled = True
                uceGuiaB.Items.Clear()
                For Each r As DataRow In dtGuias.Rows
                    uceGuiaB.Items.Add(r.Item("idGuia"), r.Item("descripcion"))
                Next
                uceGuiaB.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub consultaProcesoA()
        Try
            With procesoA
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            procesoA = CommonProcess.GetProcesoPoridBriefing(procesoA.idBriefing)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerGuias(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim Guia As New GuiaItem
        With Guia
            .idBriefing = idBriefing
        End With
        Try
            General.SetBARequest(req)
            req.myGuiaItem = Guia
            res = wsClient.GetGuiaPorIdBriefing(req)
            If res.ActionResult Then
                Dim nr As DataRow
                For Each r As DataRow In res.dsResult.Tables(0).Rows
                    nr = dtGuias.NewRow
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("descripcion") = r.Item("descripcion")
                    nr.Item("idBriefing") = r.Item("idBriefing")
                    nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                    nr.Item("idAgencia") = r.Item("idAgencia")
                    nr.Item("descripcionAgencia") = r.Item("agencia")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("bultos") = r.Item("bultos")
                    nr.Item("fechaLlegada") = r.Item("fechaLlegada")
                    nr.Item("estado") = r.Item("estado")
                    nr.Item("DAE") = r.Item("DAE")
                    dtGuias.Rows.Add(nr)
                Next
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsUgvCargaPorGuiaA()
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("piezas").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("indice").Hidden = True
    End Sub

    Private Sub SetDisplayedColumnsUgvCargaElementoA()
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("piezas").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("indice").Hidden = True
    End Sub

    Private Sub SetDisplayedColumnsUgvCargaDevueltaPorGuia()
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("piezas").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("indice").Hidden = True
    End Sub

    Private Sub SetDisplayedColumnsUgvCargaDevueltaPorElemento()
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("piezas").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("indice").Hidden = True
    End Sub

    Private Sub uceGuiasA_SelectionChanged(sender As Object, e As EventArgs) Handles uceGuiasA.SelectionChanged
        Try

            Dim dttempDetallePorGuiaA As New DataTable
            dttempDetallePorGuiaA = CommonProcess.GetDetalleProcesoPorIdGuia(procesoA.IdProceso, uceGuiasA.Value.ToString)
            dtDetallePorGuiaA.Rows.Clear()
            For Each r As DataRow In dttempDetallePorGuiaA.Rows
                Dim r2 As DataRow = dtDetallePorGuiaA.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorGuiaA.Rows.Add(r2)
            Next
            ugvCargaPorGuiaA.DataSource = dtDetallePorGuiaA
            SetDisplayedColumnsUgvCargaPorGuiaA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uceGuiaB_SelectionChanged(sender As Object, e As EventArgs) Handles uceGuiaB.SelectionChanged
        Try
            Dim dttempDetallePorGuiaB As New DataTable
            dttempDetallePorGuiaB = CommonProcess.GetCargaDevueltaPorIdProcesoGroupGuia(procesoA.IdProceso, uceGuiaB.Value.ToString)
            dtGuiasDevuelto.Rows.Clear()
            For Each r As DataRow In dttempDetallePorGuiaB.Rows
                Dim r2 As DataRow = dtGuiasDevuelto.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtGuiasDevuelto.Rows.Add(r2)
            Next
            ugvCargaDevueltaPorGuia.DataSource = dtGuiasDevuelto
            SetDisplayedColumnsUgvCargaDevueltaPorGuia()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorGuiaA_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCargaPorGuiaA.ClickCell
        Dim cont As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Decimal = 0D
        If e.Cell.Column Is ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("chck") Then
            For Each r As DataRow In dtDetallePorGuiaA.Rows
                If r.Item("indice") = ugvCargaPorGuiaA.ActiveRow.Cells("indice").Value Then
                    If r.Item("chck") = 0 Then
                        r.Item("chck") = 1
                    Else
                        r.Item("chck") = 0
                    End If
                End If
                If r.Item("chck") = True Then
                    cont += 1
                    totPiezas += r.Item("piezas")
                    totPeso += r.Item("peso")
                End If
            Next
            If cont > 0 Then
                btnToRight.Enabled = True
            Else
                btnToRight.Enabled = False
            End If
            txtTotPiezasA.Text = totPiezas
            txtTotPesoA.Text = totPeso
        End If
    End Sub

    Private Sub btnToRight_Click(sender As Object, e As EventArgs) Handles btnToRight.Click
        Try

            If dtElementosB.Rows.Count < 1 Then
                MessageBox.Show("El Vuelo B no tiene ningun Elemento asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If utcTab.SelectedTab Is utcTab.Tabs.Item("PG") Then
                    Dim result As Boolean = False
                    For Each r As DataRow In dtDetallePorGuiaA.Rows
                        If r.Item("chck") = True Then
                            detalleProcesoItemMov.indice = r.Item("indice")
                            detalleProcesoItemMov.estado = "D"
                            result = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            If result = False Then
                                MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                        End If
                    Next
                ElseIf utcTab.SelectedTab Is utcTab.Tabs.Item("PE") Then
                    Dim result As Boolean = False
                    Dim result2 As Boolean = False
                    For Each r As DataRow In dtDetallePorElementoA.Rows
                        If r.Item("chck") = True Then
                            detalleProcesoItemMov.indice = r.Item("indice")
                            detalleProcesoItemMov.estado = "D"
                            result = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            If result = False Then
                                MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                        End If
                    Next
                End If
                actualizarDetalleProcesoA()
                actualizarDetalleProcesoB()
                btnToRight.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnToLeft_Click(sender As Object, e As EventArgs) Handles btnToLeft.Click
        Try
            If dtElementosA.Rows.Count < 1 Then
                MessageBox.Show("El Vuelo A no tiene ningun Elemento asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If utcTab.SelectedTab Is utcTab.Tabs.Item("PG") Then
                    Dim result As Boolean = False
                    For Each r As DataRow In dtGuiasDevuelto.Rows
                        If r.Item("chck") = True Then
                            detalleProcesoItemMov.indice = r.Item("indice")
                            detalleProcesoItemMov.estado = "A"
                            result = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            If result = False Then
                                MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                        End If
                    Next
                Else
                    Dim result As Boolean = False
                    Dim result2 As Boolean = False
                    For Each r As DataRow In dtDetallePorElementoDevuelto.Rows
                        If r.Item("chck") = True Then
                            detalleProcesoItemMov.indice = r.Item("indice")
                            detalleProcesoItemMov.estado = "A"
                            result = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            If result = False Then
                                MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                        End If
                    Next
                End If
                actualizarDetalleProcesoA()
                actualizarDetalleProcesoB()
                btnToLeft.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uceElementosA_SelectionChanged(sender As Object, e As EventArgs) Handles uceElementosA.SelectionChanged
        Try
            Dim dttempDetallePorElementoA As New DataTable
            dttempDetallePorElementoA = CommonProcess.GetDetalleProcesoPorIdElemento(procesoA.IdProceso, uceElementosA.Value.ToString)
            dtDetallePorElementoA.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoA.Rows
                Dim r2 As DataRow = dtDetallePorElementoA.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorElementoA.Rows.Add(r2)
            Next
            ugvCargaPorElementoA.DataSource = dtDetallePorElementoA
            SetDisplayedColumnsUgvCargaElementoA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorElementoA_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCargaPorElementoA.ClickCell
        Dim cont As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Decimal = 0D
        Try
            If e.Cell.Column Is ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("chck") Then
                For Each r As DataRow In dtDetallePorElementoA.Rows
                    If r.Item("indice") = ugvCargaPorElementoA.ActiveRow.Cells("indice").Value Then
                        If r.Item("chck") = 0 Then
                            r.Item("chck") = 1
                        Else
                            r.Item("chck") = 0
                        End If
                    End If
                    If r.Item("chck") = True Then
                        cont += 1
                        totPiezas += r.Item("piezas")
                        totPeso += r.Item("peso")
                    End If
                Next
                If cont > 0 Then
                    btnToRight.Enabled = True
                Else
                    btnToRight.Enabled = False
                End If
                txtTotPiezasA.Text = totPiezas
                txtTotPesoA.Text = totPeso
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub utcTabs_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcTabs.SelectedTabChanged

    End Sub

    Private Sub ugvCargaPorElementoB_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCargaDevueltaPorElemento.ClickCell
        Dim cont As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Decimal = 0D
        Try
            If e.Cell.Column Is ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("chck") Then
                For Each r As DataRow In dtDetallePorElementoDevuelto.Rows
                    If r.Item("indice") = ugvCargaDevueltaPorElemento.ActiveRow.Cells("indice").Value Then
                        If r.Item("chck") = 0 Then
                            r.Item("chck") = 1
                        Else
                            r.Item("chck") = 0
                        End If
                    End If
                    If r.Item("chck") = True Then
                        cont += 1
                        totPiezas += r.Item("piezas")
                        totPeso += r.Item("peso")
                    End If
                Next
                If cont > 0 Then
                    btnToLeft.Enabled = True
                Else
                    btnToLeft.Enabled = False
                End If
                txtTotPiezasB.Text = totPiezas
                txtTotPesoB.Text = totPeso
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub actualizarDetalleProcesoA()
        Try
            Dim dttempDetallePorGuiaA As New DataTable
            dttempDetallePorGuiaA = CommonProcess.GetDetalleProcesoPorIdGuia(procesoA.IdProceso, uceGuiasA.Value.ToString)
            dtDetallePorGuiaA.Rows.Clear()
            For Each r As DataRow In dttempDetallePorGuiaA.Rows
                Dim r2 As DataRow = dtDetallePorGuiaA.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorGuiaA.Rows.Add(r2)
            Next
            ugvCargaPorGuiaA.DataSource = dtDetallePorGuiaA
            SetDisplayedColumnsUgvCargaPorGuiaA()


            Dim dttempDetallePorElementoA As New DataTable
            dttempDetallePorElementoA = CommonProcess.GetDetalleProcesoPorIdElemento(procesoA.IdProceso, uceElementosA.Value.ToString)
            dtDetallePorElementoA.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoA.Rows
                Dim r2 As DataRow = dtDetallePorElementoA.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorElementoA.Rows.Add(r2)
            Next
            ugvCargaPorElementoA.DataSource = dtDetallePorElementoA
            SetDisplayedColumnsUgvCargaElementoA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub actualizarDetalleProcesoB()
        Try
            Dim dttempDetallePorGuiaB As New DataTable
            dttempDetallePorGuiaB = CommonProcess.GetCargaDevueltaPorIdProcesoGroupGuia(procesoA.IdProceso, uceGuiaB.Value.ToString)
            dtGuiasDevuelto.Rows.Clear()
            For Each r As DataRow In dttempDetallePorGuiaB.Rows
                Dim r2 As DataRow = dtGuiasDevuelto.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtGuiasDevuelto.Rows.Add(r2)
            Next
            ugvCargaDevueltaPorGuia.DataSource = dtGuiasDevuelto
            SetDisplayedColumnsUgvCargaDevueltaPorGuia()

            Dim dttempDetallePorElementoB As New DataTable
            dttempDetallePorElementoB = CommonProcess.GetCargaDevueltaPorIdProcesoGroupElemento(procesoA.IdProceso, uceElementoB.Value.ToString)
            dtDetallePorElementoDevuelto.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoB.Rows
                Dim r2 As DataRow = dtDetallePorElementoDevuelto.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorElementoDevuelto.Rows.Add(r2)
            Next
            ugvCargaDevueltaPorElemento.DataSource = dtDetallePorElementoDevuelto
            SetDisplayedColumnsUgvCargaDevueltaPorElemento()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub chckTodoGuiaA_Click(sender As Object, e As EventArgs) Handles chckTodoGuiaA.Click
        Try
            If chckTodoGuiaA.Checked = False Then
                For Each r As DataRow In dtDetallePorGuiaA.Rows
                    r.Item("chck") = 1
                Next
            Else
                For Each r As DataRow In dtDetallePorGuiaA.Rows
                    r.Item("chck") = 0
                Next
            End If
            Dim cont As Integer = 0
            Dim totPiezas As Integer = 0
            Dim totPeso As Decimal = 0D
            For Each r As DataRow In dtDetallePorGuiaA.Rows
                If r.Item("chck") = 0 Then
                    r.Item("chck") = 1
                Else
                    r.Item("chck") = 0
                End If
                If r.Item("chck") = True Then
                    cont += 1
                    totPiezas += r.Item("piezas")
                    totPeso += r.Item("peso")
                End If
            Next
            If cont > 0 Then
                btnToRight.Enabled = True
            Else
                btnToRight.Enabled = False
            End If
            txtTotPiezasA.Text = totPiezas
            txtTotPesoA.Text = totPeso
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chckTodoElementoA_Click(sender As Object, e As EventArgs) Handles chckTodoElementoA.Click
        Try
            If chckTodoElementoA.Checked = False Then
                For Each r As DataRow In dtDetallePorElementoA.Rows
                    r.Item("chck") = 1
                Next
            Else
                For Each r As DataRow In dtDetallePorElementoA.Rows
                    r.Item("chck") = 0
                Next
            End If
            Dim cont As Integer = 0
            Dim totPiezas As Integer = 0
            Dim totPeso As Decimal = 0D
            For Each r As DataRow In dtDetallePorElementoA.Rows
                If r.Item("chck") = 0 Then
                    r.Item("chck") = 1
                Else
                    r.Item("chck") = 0
                End If
                If r.Item("chck") = True Then
                    cont += 1
                    totPiezas += r.Item("piezas")
                    totPeso += r.Item("peso")
                End If
            Next
            If cont > 0 Then
                btnToRight.Enabled = True
            Else
                btnToRight.Enabled = False
            End If
            txtTotPiezasA.Text = totPiezas
            txtTotPesoA.Text = totPeso
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chckTodoElementoB_Click(sender As Object, e As EventArgs) Handles chckTodoElmenetoB.Click
        Try

            Dim cont As Integer = 0
            Dim totPiezas As Integer = 0
            Dim totPeso As Decimal = 0D
            For Each r As DataRow In dtDetallePorElementoDevuelto.Rows
                If r.Item("chck") = 0 Then
                    r.Item("chck") = 1
                Else
                    r.Item("chck") = 0
                End If
                If r.Item("chck") = True Then
                    cont += 1
                    totPiezas += r.Item("piezas")
                    totPeso += r.Item("peso")
                End If
            Next
            If cont > 0 Then
                btnToLeft.Enabled = True
            Else
                btnToLeft.Enabled = False
            End If
            txtTotPiezasB.Text = totPiezas
            txtTotPesoB.Text = totPeso
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorElementoA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvCargaPorElementoA.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                Dim cont As Integer = 0
                Dim totPiezas As Integer = 0
                Dim totPeso As Decimal = 0D
                If ugvCargaPorElementoA.ActiveCell.Column Is ugvCargaPorElementoA.DisplayLayout.Bands(0).Columns("chck") Then
                    For Each r As DataRow In dtDetallePorElementoA.Rows
                        If r.Item("indice") = ugvCargaPorElementoA.ActiveRow.Cells("indice").Value Then
                            If r.Item("chck") = 0 Then
                                r.Item("chck") = 1
                            Else
                                r.Item("chck") = 0
                            End If
                        End If
                        If r.Item("chck") = True Then
                            cont += 1
                            totPiezas += r.Item("piezas")
                            totPeso += r.Item("peso")
                        End If
                    Next
                    If cont > 0 Then
                        btnToRight.Enabled = True
                    Else
                        btnToRight.Enabled = False
                    End If
                    txtTotPiezasA.Text = totPiezas
                    txtTotPesoA.Text = totPeso
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorElementoB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvCargaDevueltaPorElemento.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                Dim cont As Integer = 0
                Dim totPiezas As Integer = 0
                Dim totPeso As Decimal = 0D
                If ugvCargaDevueltaPorElemento.ActiveCell.Column Is ugvCargaDevueltaPorElemento.DisplayLayout.Bands(0).Columns("chck") Then
                    For Each r As DataRow In dtDetallePorElementoDevuelto.Rows
                        If r.Item("indice") = ugvCargaDevueltaPorElemento.ActiveRow.Cells("indice").Value Then
                            If r.Item("chck") = 0 Then
                                r.Item("chck") = 1
                            Else
                                r.Item("chck") = 0
                            End If
                        End If
                        If r.Item("chck") = True Then
                            cont += 1
                            totPiezas += r.Item("piezas")
                            totPeso += r.Item("peso")
                        End If
                    Next
                    If cont > 0 Then
                        btnToLeft.Enabled = True
                    Else
                        btnToLeft.Enabled = False
                    End If
                    txtTotPiezasB.Text = totPiezas
                    txtTotPesoB.Text = totPeso
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorGuiaA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvCargaPorGuiaA.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                Dim cont As Integer = 0
                Dim totPiezas As Integer = 0
                Dim totPeso As Decimal = 0D
                If ugvCargaPorGuiaA.ActiveCell.Column Is ugvCargaPorGuiaA.DisplayLayout.Bands(0).Columns("chck") Then
                    For Each r As DataRow In dtDetallePorGuiaA.Rows
                        If r.Item("indice") = ugvCargaPorGuiaA.ActiveRow.Cells("indice").Value Then
                            If r.Item("chck") = 0 Then
                                r.Item("chck") = 1
                            Else
                                r.Item("chck") = 0
                            End If
                        End If
                        If r.Item("chck") = True Then
                            cont += 1
                            totPiezas += r.Item("piezas")
                            totPeso += r.Item("peso")
                        End If
                    Next
                    If cont > 0 Then
                        btnToRight.Enabled = True
                    Else
                        btnToRight.Enabled = False
                    End If
                    txtTotPiezasA.Text = totPiezas
                    txtTotPesoA.Text = totPeso
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uceElementoB_SelectionChanged(sender As Object, e As EventArgs) Handles uceElementoB.SelectionChanged
        Try
            Dim dttempDetallePorElementoB As New DataTable
            dttempDetallePorElementoB = CommonProcess.GetCargaDevueltaPorIdProcesoGroupElemento(procesoA.IdProceso, uceElementoB.Value.ToString)
            dtDetallePorElementoDevuelto.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoB.Rows
                Dim r2 As DataRow = dtDetallePorElementoDevuelto.NewRow
                r2.Item("chck") = 0
                r2.Item("idProceso") = r.Item("idProceso")
                r2.Item("fecha") = r.Item("fecha")
                r2.Item("idGuia") = r.Item("idGuia")
                r2.Item("guia") = r.Item("guia")
                r2.Item("idElemento") = r.Item("idElemento")
                r2.Item("piezas") = r.Item("piezas")
                r2.Item("peso") = r.Item("peso")
                r2.Item("idProducto") = r.Item("idProducto")
                r2.Item("descripcionProducto") = r.Item("descripcionProducto")
                r2.Item("estado") = r.Item("estado")
                r2.Item("indice") = r.Item("indice")
                dtDetallePorElementoDevuelto.Rows.Add(r2)
            Next
            ugvCargaDevueltaPorElemento.DataSource = dtDetallePorElementoDevuelto
            SetDisplayedColumnsUgvCargaDevueltaPorElemento()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chckTodoGuiaB_Click(sender As Object, e As EventArgs) Handles chckTodoGuiaB.Click
        Try
            If chckTodoGuiaB.Checked = False Then
                For Each r As DataRow In dtGuiasDevuelto.Rows
                    r.Item("chck") = 1
                Next
            Else
                For Each r As DataRow In dtGuiasDevuelto.Rows
                    r.Item("chck") = 0
                Next
            End If
            Dim cont As Integer = 0
            Dim totPiezas As Integer = 0
            Dim totPeso As Decimal = 0D
            For Each r As DataRow In dtGuiasDevuelto.Rows
                If r.Item("chck") = 0 Then
                    r.Item("chck") = 1
                Else
                    r.Item("chck") = 0
                End If
                If r.Item("chck") = True Then
                    cont += 1
                    totPiezas += r.Item("piezas")
                    totPeso += r.Item("peso")
                End If
            Next
            If cont > 0 Then
                btnToRight.Enabled = True
            Else
                btnToRight.Enabled = False
            End If
            txtTotPiezasB.Text = totPiezas
            txtTotPesoB.Text = totPeso
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ugvCargaDevueltaPorGuia_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCargaDevueltaPorGuia.ClickCell
        Dim cont As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Decimal = 0D
        Try
            If e.Cell.Column Is ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("chck") Then
                For Each r As DataRow In dtGuiasDevuelto.Rows
                    If r.Item("indice") = ugvCargaDevueltaPorGuia.ActiveRow.Cells("indice").Value Then
                        If r.Item("chck") = 0 Then
                            r.Item("chck") = 1
                        Else
                            r.Item("chck") = 0
                        End If
                    End If
                    If r.Item("chck") = True Then
                        cont += 1
                        totPiezas += r.Item("piezas")
                        totPeso += r.Item("peso")
                    End If
                Next
                If cont > 0 Then
                    btnToLeft.Enabled = True
                Else
                    btnToLeft.Enabled = False
                End If
                txtTotPiezasB.Text = totPiezas
                txtTotPesoB.Text = totPeso
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ugvCargaDevueltaPorGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvCargaDevueltaPorGuia.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                Dim cont As Integer = 0
                Dim totPiezas As Integer = 0
                Dim totPeso As Decimal = 0D
                If ugvCargaDevueltaPorGuia.ActiveCell.Column Is ugvCargaDevueltaPorGuia.DisplayLayout.Bands(0).Columns("chck") Then
                    For Each r As DataRow In dtGuiasDevuelto.Rows
                        If r.Item("indice") = ugvCargaDevueltaPorGuia.ActiveRow.Cells("indice").Value Then
                            If r.Item("chck") = 0 Then
                                r.Item("chck") = 1
                            Else
                                r.Item("chck") = 0
                            End If
                        End If
                        If r.Item("chck") = True Then
                            cont += 1
                            totPiezas += r.Item("piezas")
                            totPeso += r.Item("peso")
                        End If
                    Next
                    If cont > 0 Then
                        btnToRight.Enabled = True
                    Else
                        btnToRight.Enabled = False
                    End If
                    txtTotPiezasB.Text = totPiezas
                    txtTotPesoB.Text = totPeso
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class