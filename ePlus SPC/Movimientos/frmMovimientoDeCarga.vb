Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Imports System.IO

Public Class frmMovimientoDeCarga

    Public Property myElementoProceso As New ElementoProcesoItem
    Dim myDetalleVuelo As New DetalleVuelo
    Dim myDetalleVueloB As New DetalleVuelo
    Dim procesoA As New ProcesoItem
    Dim procesoB As New ProcesoItem
    Dim elementoBriefingA As New Server.VuelosService.ElementoBriefingItem
    Dim elementoBriefingB As New Server.VuelosService.ElementoBriefingItem
    Dim dtElementosA As New DataTable("Elementos")
    Dim dtElementosB As New DataTable("Elementos")
    Dim dtGuias As New DataTable("Guias")
    Dim dtElemento As New DataTable("Elementos")
    Dim dtDetallePorGuiaA As New DataTable("dtPorGuiaA")
    Dim dtDetallePorElementoA As New DataTable("dtPorElementoA")
    Dim dtDetallePorElementoB As New DataTable("dtPorElementoB")
    Dim dtElementoProceso As New DataTable("dtElementoProceso")
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
        With dtDetallePorElementoB.Columns
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
        uceElementosB.Enabled = False
        uceGuiasA.Enabled = False
        chckTodoGuiaA.Enabled = False
        chckTodoElementoA.Enabled = False
        chckTodoElementoB.Enabled = False
        detalleProcesoItemMov.UsusarioIngreso = IdUsuario
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub LimpiarB()
        txtVueloB.Clear()
        txtMatriculaB.Clear()
        txtAvionB.Clear()
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsVueloB_Click(sender As Object, e As EventArgs) Handles btnConsVueloB.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            LimpiarB()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleVueloB = frmConsultaVuelos.resDetVuelo
                txtVueloB.Text = myDetalleVueloB.codigoVuelo
                txtAvionB.Text = myDetalleVueloB.descripcionAvion
                txtMatriculaB.Text = myDetalleVueloB.matriculaAvion
                consultaProcesoB()
                CargarElementosB()
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


    Private Sub CargarElementosB()
        Try
            elementoBriefingB.idBriefing = myDetalleVueloB.idBriefing
            dtElementosB = CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefingB)
            If Not IsNothing(dtGuias) Then
                uceElementosB.Enabled = True
                chckTodoElementoB.Enabled = True
                uceElementosB.Items.Clear()
                For Each r As DataRow In dtElementosB.Rows
                    uceElementosB.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
                Next
                uceElementosB.SelectedIndex = 0
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

    Private Sub consultaProcesoB()
        Try
            With procesoB
                .idBriefing = myDetalleVueloB.idBriefing
            End With
            procesoB = CommonProcess.GetProcesoPoridBriefing(procesoB.idBriefing)
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

    Private Sub SetDisplayedColumnsUgvCargaElementoB()
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("fecha").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("piezas").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("indice").Hidden = True
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

    Private Sub SaveElementoProceso(ByVal peso As Decimal)
        Dim result As Boolean = False
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            If Not IsNothing(dtElementoProceso) Then
                For Each r As DataRow In dtElementoProceso.Rows
                    myElementoProceso.indice = r.Item("indice")
                    'myElementoProceso.indice = r.Item("indice")
                    myElementoProceso.idElemento = r.Item("idElemento")
                    myElementoProceso.IdProceso = r.Item("idProceso")
                    myElementoProceso.fecha = r.Item("fecha")
                    myElementoProceso.pesoCarga = r.Item("pesoCarga")
                    myElementoProceso.pesoDescarga = peso
                    myElementoProceso.usuarioComparacionPeso = MyCurrentUser.userName
                    'myElementoProceso.pesoDiferencia = r.Item("pesoDiferencia")
                    General.SetBARequest(req)
                    req.myElementoProcesoItem = myElementoProceso
                    res = WsClnt.SaveElementoProcesoItem(req)
                    If Not res.ActionResult Then
                        Throw New Exception(res.ErrorMessage)
                    End If
                    Exit For
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnToRight_Click(sender As Object, e As EventArgs) Handles btnToRight.Click
        'Dim stopWatch = New Stopwatch()
        'Dim sactualizarDetalleProcesoA = New Stopwatch()
        'Dim sactualizarDetalleProcesoB = New Stopwatch()
        'Dim sGetElementoProcesoPorIdProcesoIdElemento = New Stopwatch()
        'Dim sModificarDetalleProcesoMovientoPorIndice = New Stopwatch()
        'Dim smodificarpesoCargaElementoProcesoPorIdProcesoElemento = New Stopwatch()
        'Dim smodificarpesoDescargaElementoProcesoPorIdProcesoElemento = New Stopwatch()
        'Dim sModificarDetalleProcesoMovientoPorIndiceOtroVuelo = New Stopwatch()

        'stopWatch.Start()
        Try
            If dtElementosB.Rows.Count < 1 Then
                MessageBox.Show("El Vuelo B no tiene ningun Elemento asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                If utcTab.SelectedTab Is utcTab.Tabs.Item("PG") Then
                    Dim result As Boolean = False
                    For Each r As DataRow In dtDetallePorGuiaA.Rows
                        If r.Item("chck") = True Then
                            Dim movimiento = New MovimientoItem
                            movimiento.Indice = r.Item("indice")
                            movimiento.IdProceso = procesoB.IdProceso
                            movimiento.IdElemento = uceElementosB.Value
                            movimiento.IdElementoDescarga = r.Item("idElemento")
                            movimiento.Peso = r.Item("peso")
                            movimiento.Fecha = DateTime.Now
                            movimiento.Usuario = MyCurrentUser.userName
                            If r.Item("idProceso") = procesoB.IdProceso Then
                                movimiento.mismoVuelo = True
                            Else
                                movimiento.mismoVuelo = False
                            End If
                            result = CommonProcess.MovimientoPorGuia(movimiento)
#Region "Comentario de anterior Proceso"
                            'detalleProcesoItemMov.indice = r.Item("indice")
                            'detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                            'detalleProcesoItemMov.idElemento = uceElementosB.Value
                            ''sGetElementoProcesoPorIdProcesoIdElemento.Start()
                            'dtElementoProceso = CommonProcess.GetElementoProcesoPorIdProcesoIdElemento(r.Item("idProceso"), r.Item("idElemento"))
                            ''sGetElementoProcesoPorIdProcesoIdElemento.Stop()
                            ''CrearArchivoLogBitacora("Proceso GetElementoProcesoPorIdProcesoIdElemento " + sGetElementoProcesoPorIdProcesoIdElemento.Elapsed.ToString())
                            'If r.Item("idProceso") = procesoB.IdProceso Then
                            '    'sModificarDetalleProcesoMovientoPorIndice.Start()
                            '    result = CommonProcess.ModificarDetalleProcesoMovientoPorIndice(detalleProcesoItemMov)
                            '    'sModificarDetalleProcesoMovientoPorIndice.Stop()
                            '    'CrearArchivoLogBitacora("Proceso ModificarDetalleProcesoMovientoPorIndice " + sModificarDetalleProcesoMovientoPorIndice.Elapsed.ToString())
                            '    If result Then
                            '        Dim ElementoCarga As New ElementoProcesoItem
                            '        Dim ElementoDescarga As New ElementoProcesoItem
                            '        ElementoCarga.IdProceso = procesoB.IdProceso
                            '        ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '        ElementoCarga.fechaCarga = DateTime.Now
                            '        ElementoCarga.pesoCarga = r.Item("peso")
                            '        ElementoDescarga.IdProceso = r.Item("idProceso")
                            '        ElementoDescarga.idElemento = r.Item("idElemento")
                            '        ElementoDescarga.fechaDescarga = DateTime.Now
                            '        ElementoDescarga.pesoDescarga = r.Item("peso")
                            '        'smodificarpesoCargaElementoProcesoPorIdProcesoElemento.Start()
                            '        CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '        'sModificarDetalleProcesoMovientoPorIndice.Stop()
                            '        'CrearArchivoLogBitacora("Proceso modificarpesoCargaElementoProcesoPorIdProcesoElemento " + smodificarpesoCargaElementoProcesoPorIdProcesoElemento.Elapsed.ToString())
                            '        'smodificarpesoDescargaElementoProcesoPorIdProcesoElemento.Start()
                            '        CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '        'smodificarpesoDescargaElementoProcesoPorIdProcesoElemento.Stop()
                            '        'CrearArchivoLogBitacora("Proceso modificarpesoDescargaElementoProcesoPorIdProcesoElemento " + smodificarpesoDescargaElementoProcesoPorIdProcesoElemento.Elapsed.ToString())
                            '    End If
                            'Else
                            '        ' sModificarDetalleProcesoMovientoPorIndiceOtroVuelo.Start()
                            '        result = CommonProcess.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(detalleProcesoItemMov)
                            '        'sModificarDetalleProcesoMovientoPorIndiceOtroVuelo.Stop()
                            '        'CrearArchivoLogBitacora("Proceso ModificarDetalleProcesoMovientoPorIndiceOtroVuelo " + sModificarDetalleProcesoMovientoPorIndiceOtroVuelo.Elapsed.ToString())
                            '        If result Then
                            '            Dim ElementoCarga As New ElementoProcesoItem
                            '            Dim ElementoDescarga As New ElementoProcesoItem
                            '            ElementoCarga.IdProceso = procesoB.IdProceso
                            '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '            ElementoCarga.fechaCarga = DateTime.Now
                            '            ElementoCarga.pesoCarga = r.Item("peso")
                            '            ElementoDescarga.IdProceso = r.Item("idProceso")
                            '            ElementoDescarga.idElemento = r.Item("idElemento")
                            '            ElementoDescarga.fechaDescarga = DateTime.Now
                            '            ElementoDescarga.pesoDescarga = r.Item("peso")
                            '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '        End If
                            '    End If
#End Region
                            If result = False Then
                                SaveElementoProceso(r.Item("peso"))
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
                            Dim movimiento = New MovimientoItem
                            movimiento.Indice = r.Item("indice")
                            movimiento.IdProceso = procesoB.IdProceso
                            movimiento.IdElemento = uceElementosB.Value
                            movimiento.IdElementoDescarga = r.Item("idElemento")
                            movimiento.Peso = r.Item("peso")
                            movimiento.Fecha = DateTime.Now
                            movimiento.Usuario = MyCurrentUser.userName
                            If r.Item("idProceso") = procesoB.IdProceso Then
                                movimiento.mismoVuelo = True
                            Else
                                movimiento.mismoVuelo = False
                            End If
                            result = CommonProcess.MovimientoPorGuia(movimiento)
#Region "Comentario de anterior Proceso2"
                            'detalleProcesoItemMov.indice = r.Item("indice")
                            ''detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                            ''detalleProcesoItemMov.idElemento = uceElementosB.Value
                            'If r.Item("idProceso") = procesoB.IdProceso Then
                            '    detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                            '    detalleProcesoItemMov.idElemento = uceElementosB.Value
                            '    result = CommonProcess.ModificarDetalleProcesoMovientoPorIndice(detalleProcesoItemMov)
                            '    If result Then
                            '        Dim ElementoCarga As New ElementoProcesoItem
                            '        Dim ElementoDescarga As New ElementoProcesoItem
                            '        ElementoCarga.IdProceso = procesoB.IdProceso
                            '        ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '        ElementoCarga.fechaCarga = DateTime.Now
                            '        ElementoCarga.pesoCarga = r.Item("peso")
                            '        ElementoDescarga.IdProceso = r.Item("idProceso")
                            '        ElementoDescarga.idElemento = r.Item("idElemento")
                            '        ElementoDescarga.fechaDescarga = DateTime.Now
                            '        ElementoDescarga.pesoDescarga = r.Item("peso")
                            '        CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '        CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '    End If
                            'Else
                            '    'If r.Item("estado") = "R" Then
                            '    detalleProcesoItemMov.indice = r.Item("indice")
                            '    'detalleProcesoItemMov.IdDetalleProceso = procesoA.IdProceso
                            '    'detalleProcesoItemMov.idElemento = uceElementosA.Value
                            '    detalleProcesoItemMov.estado = "E"
                            '    result2 = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            '    'End If
                            '    If result2 Then
                            '        detalleProcesoItemMov.indice = r.Item("indice")
                            '        detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                            '        detalleProcesoItemMov.idElemento = uceElementosB.Value
                            '        result = CommonProcess.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(detalleProcesoItemMov)
                            '        If result Then
                            '            Dim ElementoCarga As New ElementoProcesoItem
                            '            Dim ElementoDescarga As New ElementoProcesoItem
                            '            ElementoCarga.IdProceso = procesoB.IdProceso
                            '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '            ElementoCarga.fechaCarga = DateTime.Now
                            '            ElementoCarga.pesoCarga = r.Item("peso")
                            '            ElementoDescarga.IdProceso = r.Item("idProceso")
                            '            ElementoDescarga.idElemento = r.Item("idElemento")
                            '            ElementoDescarga.fechaDescarga = DateTime.Now
                            '            ElementoDescarga.pesoDescarga = r.Item("peso")
                            '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '        End If
                            '    End If

                            '    'If r.Item("estado") = "R" Then
                            '    '    detalleProcesoItemMov.indice = r.Item("indice")
                            '    '    detalleProcesoItemMov.IdDetalleProceso = procesoA.IdProceso
                            '    '    detalleProcesoItemMov.idElemento = uceElementosA.Value
                            '    '    detalleProcesoItemMov.estado = "E"
                            '    '    result2 = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                            '    '    If result2 Then
                            '    '        detalleProcesoItemMov.estado = "R"
                            '    '        detalleProcesoItemMov.indice = r.Item("indice")
                            '    '        detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                            '    '        detalleProcesoItemMov.idElemento = uceElementosB.Value
                            '    '        If r.Item("idProceso") = procesoB.IdProceso Then

                            '    '        End If
                            '    '        'result = CommonProcess.ModificarEstadoDetalleProcesoPorfechaYGuia(detalleProcesoItemMov)
                            '    '        If result Then
                            '    '            Dim ElementoCarga As New ElementoProcesoItem
                            '    '            Dim ElementoDescarga As New ElementoProcesoItem
                            '    '            ElementoCarga.IdProceso = procesoB.IdProceso
                            '    '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '    '            ElementoCarga.fechaCarga = DateTime.Now
                            '    '            ElementoCarga.pesoCarga = r.Item("peso")
                            '    '            ElementoDescarga.IdProceso = r.Item("idProceso")
                            '    '            ElementoDescarga.idElemento = r.Item("idElemento")
                            '    '            ElementoDescarga.fechaDescarga = DateTime.Now
                            '    '            ElementoDescarga.pesoDescarga = r.Item("peso")
                            '    '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '    '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '    '        End If
                            '    '    End If
                            '    'Else
                            '    '    If r.Item("idProceso") = procesoB.IdProceso Then
                            '    '        result = CommonProcess.ModificarDetalleProcesoMovientoPorIndice(detalleProcesoItemMov)
                            '    '        If result Then
                            '    '            Dim ElementoCarga As New ElementoProcesoItem
                            '    '            Dim ElementoDescarga As New ElementoProcesoItem
                            '    '            ElementoCarga.IdProceso = procesoB.IdProceso
                            '    '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '    '            ElementoCarga.fechaCarga = DateTime.Now
                            '    '            ElementoCarga.pesoCarga = r.Item("peso")
                            '    '            ElementoDescarga.IdProceso = r.Item("idProceso")
                            '    '            ElementoDescarga.idElemento = r.Item("idElemento")
                            '    '            ElementoDescarga.fechaDescarga = DateTime.Now
                            '    '            ElementoDescarga.pesoDescarga = r.Item("peso")
                            '    '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '    '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '    '        End If
                            '    '    Else
                            '    '        result = CommonProcess.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(detalleProcesoItemMov)
                            '    '        If result Then
                            '    '            Dim ElementoCarga As New ElementoProcesoItem
                            '    '            Dim ElementoDescarga As New ElementoProcesoItem
                            '    '            ElementoCarga.IdProceso = procesoB.IdProceso
                            '    '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                            '    '            ElementoCarga.fechaCarga = DateTime.Now
                            '    '            ElementoCarga.pesoCarga = r.Item("peso")
                            '    '            ElementoDescarga.IdProceso = r.Item("idProceso")
                            '    '            ElementoDescarga.idElemento = r.Item("idElemento")
                            '    '            ElementoDescarga.fechaDescarga = DateTime.Now
                            '    '            ElementoDescarga.pesoDescarga = r.Item("peso")
                            '    '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                            '    '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                            '    '        End If
                            '    '    End If
                            'End If
#End Region
                            If result = False Then
                                MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                        End If
                    Next
                End If
                MessageBox.Show("El moviento fue realizo con Exito", "Informatico", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'sactualizarDetalleProcesoA.Start()
                actualizarDetalleProcesoA()
                'sactualizarDetalleProcesoA.Stop()
                'CrearArchivoLogBitacora("Proceso actualizarDetalleProcesoA " + sactualizarDetalleProcesoA.Elapsed.ToString())
                'sactualizarDetalleProcesoB.Start()
                actualizarDetalleProcesoB()
                'sactualizarDetalleProcesoB.Stop()
                'CrearArchivoLogBitacora("Proceso actualizarDetalleProcesoB " + sactualizarDetalleProcesoB.Elapsed.ToString())
                btnToRight.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'stopWatch.Stop()
        'CrearArchivoLogBitacora("Proceso total " + stopWatch.Elapsed.ToString())
        'MessageBox.Show("Proceso Finalizado en " + stopWatch.Elapsed.ToString(), "Mensaje Sistema")
    End Sub

    Private Sub btnToLeft_Click(sender As Object, e As EventArgs) Handles btnToLeft.Click
        Try
            If dtElementosA.Rows.Count < 1 Then
                MessageBox.Show("El Vuelo A no tiene ningun Elemento asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                Dim result As Boolean = False
                Dim result2 As Boolean = False
                For Each r As DataRow In dtDetallePorElementoB.Rows
                    If r.Item("chck") = True Then
                        Dim movimiento = New MovimientoItem
                        movimiento.Indice = r.Item("indice")
                        movimiento.IdProceso = procesoA.IdProceso
                        movimiento.IdElemento = uceElementosA.Value
                        movimiento.IdElementoDescarga = r.Item("idElemento")
                        movimiento.Peso = r.Item("peso")
                        movimiento.Fecha = DateTime.Now
                        movimiento.Usuario = MyCurrentUser.userName
                        If r.Item("idProceso") = procesoA.IdProceso Then
                            movimiento.mismoVuelo = True
                        Else
                            movimiento.mismoVuelo = False
                        End If
                        result = CommonProcess.MovimientoPorGuia(movimiento)
#Region "Comentario de anterior Proceso3"
                        'detalleProcesoItemMov.indice = r.Item("indice")
                        ''detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                        ''detalleProcesoItemMov.idElemento = uceElementosB.Value
                        'If r.Item("idProceso") = procesoB.IdProceso Then
                        '    result = CommonProcess.ModificarDetalleProcesoMovientoPorIndice(detalleProcesoItemMov)
                        '    If result Then
                        '        Dim ElementoCarga As New ElementoProcesoItem
                        '        Dim ElementoDescarga As New ElementoProcesoItem
                        '        ElementoCarga.IdProceso = procesoB.IdProceso
                        '        ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                        '        ElementoCarga.fechaCarga = DateTime.Now
                        '        ElementoCarga.pesoCarga = r.Item("peso")
                        '        ElementoDescarga.IdProceso = r.Item("idProceso")
                        '        ElementoDescarga.idElemento = r.Item("idElemento")
                        '        ElementoDescarga.fechaDescarga = DateTime.Now
                        '        ElementoDescarga.pesoDescarga = r.Item("peso")
                        '        CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                        '        CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                        '    End If
                        'Else
                        '    'If r.Item("estado") = "R" Then
                        '    detalleProcesoItemMov.indice = r.Item("indice")
                        '    'detalleProcesoItemMov.IdDetalleProceso = procesoA.IdProceso
                        '    'detalleProcesoItemMov.idElemento = uceElementosA.Value
                        '    detalleProcesoItemMov.estado = "E"
                        '    result2 = CommonProcess.ModificarEstadoDetalleProcesoPorIndice(detalleProcesoItemMov)
                        '    'End If
                        '    If result2 Then
                        '        detalleProcesoItemMov.indice = r.Item("indice")
                        '        detalleProcesoItemMov.IdDetalleProceso = procesoB.IdProceso
                        '        detalleProcesoItemMov.idElemento = uceElementosB.Value
                        '        result = CommonProcess.ModificarDetalleProcesoMovientoPorIndiceOtroVuelo(detalleProcesoItemMov)
                        '        If result Then
                        '            Dim ElementoCarga As New ElementoProcesoItem
                        '            Dim ElementoDescarga As New ElementoProcesoItem
                        '            ElementoCarga.IdProceso = procesoB.IdProceso
                        '            ElementoCarga.idElemento = detalleProcesoItemMov.idElemento
                        '            ElementoCarga.fechaCarga = DateTime.Now
                        '            ElementoCarga.pesoCarga = r.Item("peso")
                        '            ElementoDescarga.IdProceso = r.Item("idProceso")
                        '            ElementoDescarga.idElemento = r.Item("idElemento")
                        '            ElementoDescarga.fechaDescarga = DateTime.Now
                        '            ElementoDescarga.pesoDescarga = r.Item("peso")
                        '            CommonProcess.modificarpesoCargaElementoProcesoPorIdProcesoElemento(ElementoCarga)
                        '            CommonProcess.modificarpesoDescargaElementoProcesoPorIdProcesoElemento(ElementoDescarga)
                        '        End If
                        '    End If
                        'End If
#End Region
                        If result = False Then
                            MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        End If
                    End If
                Next
                MessageBox.Show("El moviento fue realizo con Exito", "Informatico", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub uceElementosB_SelectionChanged(sender As Object, e As EventArgs) Handles uceElementosB.SelectionChanged
        Try

            Dim dttempDetallePorElementoB As New DataTable
            dttempDetallePorElementoB = CommonProcess.GetDetalleProcesoPorIdElemento(procesoB.IdProceso, uceElementosB.Value.ToString)
            dtDetallePorElementoB.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoB.Rows
                Dim r2 As DataRow = dtDetallePorElementoB.NewRow
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
                dtDetallePorElementoB.Rows.Add(r2)
            Next
            ugvCargaPorElementoB.DataSource = dtDetallePorElementoB
            SetDisplayedColumnsUgvCargaElementoB()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvCargaPorElementoB_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugvCargaPorElementoB.ClickCell
        Dim cont As Integer = 0
        Dim totPiezas As Integer = 0
        Dim totPeso As Decimal = 0D
        Try
            If e.Cell.Column Is ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("chck") Then
                For Each r As DataRow In dtDetallePorElementoB.Rows
                    If r.Item("indice") = ugvCargaPorElementoB.ActiveRow.Cells("indice").Value Then
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
            Dim dttempDetallePorElementoB As New DataTable
            dttempDetallePorElementoB = CommonProcess.GetDetalleProcesoPorIdElemento(procesoB.IdProceso, uceElementosB.Value.ToString)
            dtDetallePorElementoB.Rows.Clear()
            For Each r As DataRow In dttempDetallePorElementoB.Rows
                Dim r2 As DataRow = dtDetallePorElementoB.NewRow
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
                dtDetallePorElementoB.Rows.Add(r2)
            Next
            ugvCargaPorElementoB.DataSource = dtDetallePorElementoB
            SetDisplayedColumnsUgvCargaElementoB()
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

    Private Sub chckTodoElementoB_Click(sender As Object, e As EventArgs) Handles chckTodoElementoB.Click
        Try
            If chckTodoElementoB.Checked = False Then
                For Each r As DataRow In dtDetallePorElementoB.Rows
                    r.Item("chck") = 1
                Next
            Else
                For Each r As DataRow In dtDetallePorElementoB.Rows
                    r.Item("chck") = 0
                Next
            End If
            Dim cont As Integer = 0
            Dim totPiezas As Integer = 0
            Dim totPeso As Decimal = 0D
            For Each r As DataRow In dtDetallePorElementoB.Rows
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

    Private Sub ugvCargaPorElementoB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugvCargaPorElementoB.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Space) Then
                Dim cont As Integer = 0
                Dim totPiezas As Integer = 0
                Dim totPeso As Decimal = 0D
                If ugvCargaPorElementoB.ActiveCell.Column Is ugvCargaPorElementoB.DisplayLayout.Bands(0).Columns("chck") Then
                    For Each r As DataRow In dtDetallePorElementoB.Rows
                        If r.Item("indice") = ugvCargaPorElementoB.ActiveRow.Cells("indice").Value Then
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
    Public Sub CrearArchivoLogBitacora(text As String)
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\Movimiento") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\Movimiento")
        End If
        Dim mydocpath As String = rutaejecutable & "\BitacoraLog" '"C:\LogsCapture"
        ' Write the text asynchronously to a new file named "WriteTextAsync.txt".
        mydocpath = mydocpath & Convert.ToString(mydocpath + Date.Now + ".txt").Replace("/", "").Replace(":", "")
        Using sw As StreamWriter = File.CreateText(mydocpath)
            sw.WriteLine(text)
        End Using
    End Sub
End Class