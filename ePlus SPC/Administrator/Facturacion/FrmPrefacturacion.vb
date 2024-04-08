Public Class FrmPrefacturacion
    Private dtPlantilla As New DataTable("dtPlantilla")
    Private dtDetallePesoVolumenVuelo As New DataTable("dtDetallePesoVolumenVuelo")
    Private dtDetallePesoVolumenVueloDev As New DataTable("dtDetallePesoVolumenVueloDev")
    Private dtDetalleMinimoVuelo As New DataTable("dtDetalleMinimoVuelo")
    Private dtDetalleMinimoMesComparado As New DataTable("dtDetalleMinimoMesComparado")
    Private dtDetalleVuelos As New DataTable("dtDetalleVuelos")
    Private dtDetallePesoVolumenGuias As New DataTable("dtDetallePesoVolumenGuias")
    Private DtServicioAdicionalEstiDesEsti As New DataTable("DtServicioAdicionalEstiDesEsti")
    Private DtServicioAdicionalMontaCarg As New DataTable("DtServicioAdicionalMontaCarg")
    Private dtDetalleServicioContainer As New DataTable("dtDetalleServicioContainer")
    Private ugdProCarPesVol As New Infragistics.Win.UltraWinGrid.UltraGrid
    Public Property IdUsuario As String
    Private ReportDetalle As RptProCargVolum
    Private Report As RptTotalServicios
    Private Sub FrmPrefacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim row As DataRow
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
                .Add("VuelosProcesado", GetType(Integer))
                .Add("TotalVuelos", GetType(Integer))
                .Add("IdComparacionServicio", GetType(Integer))
                .Add("estado", GetType(String))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("TotalCobrar", GetType(Double))
            End With
            ugdPreFact.DataSource = dtPlantilla
            SetDisplayedColumnsPlantilla()
            With dtDetallePesoVolumenVuelo.Columns
                .Add("fecha", GetType(Date))
                .Add("guia", GetType(String))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetallePesoVolumenVueloDev.Columns
                .Add("fecha", GetType(Date))
                .Add("guia", GetType(String))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetalleMinimoVuelo.Columns
                .Add("fecha", GetType(Date))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetalleMinimoMesComparado.Columns
                .Add("fecha", GetType(Date))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetallePesoVolumenGuias.Columns
                .Add("fecha", GetType(Date))
                .Add("guia", GetType(String))
                .Add("Peso", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetalleVuelos.Columns
                .Add("fechaVuelo", GetType(Date))
                .Add("codigoVuelo", GetType(String))
                .Add("Tarifa", GetType(Double))
                .Add("total", GetType(Integer))
                .Add("SubTotal", GetType(Double))
            End With
            With DtServicioAdicionalEstiDesEsti.Columns
                .Add("Fecha", GetType(Date))
                .Add("guia", GetType(String))
                .Add("Peso", GetType(Double))
                .Add("Tarifa", GetType(Double))
                .Add("PesoVolumen", GetType(Double))
                .Add("SubTotal", GetType(Double))
                .Add("codigoVuelo", GetType(String))
            End With
            With DtServicioAdicionalMontaCarg.Columns
                .Add("Fecha", GetType(DateTime))
                .Add("codigoVuelo", GetType(String))
                .Add("guia", GetType(String))
                .Add("FechaInicio", GetType(DateTime))
                .Add("FechaFin", GetType(DateTime))
                .Add("TipoConsumo", GetType(String))
                .Add("TiempoConsumido", GetType(Integer))
                .Add("TotalPeriodo", GetType(Integer))
                .Add("Tarifa", GetType(Double))
                .Add("SubTotal", GetType(Double))
            End With
            With dtDetalleServicioContainer.Columns
                .Add("Elemento", GetType(String))
                .Add("FechaInicio", GetType(DateTime))
                .Add("FechaFin", GetType(DateTime))
                .Add("TipoConsumo", GetType(String))
                .Add("TiempoConsumido", GetType(Integer))
                .Add("Tarifa", GetType(Double))
            End With

            CargarClientes()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Proceso que carga el combo cliente
    Private Sub CargarClientes()
        Try
            uceClientes.Items.Clear()
            uceClientes.Items.Add(0, "Escoja una opción")
            For Each r As DataRow In CommonDataFact.GetClientes.Rows
                If r.Item("Estado") = "A" Then
                    uceClientes.Items.Add(r.Item("idCliente"), r.Item("descripcionAgencia")).Tag = r.Item("IdAgencia")
                End If
            Next
            uceClientes.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If uceClientes.Value <> 0 And chkTipFact.CheckedItems.Count > 0 Then
            ObtenerPlantillaCliente()
            If dtPlantilla.Rows.Count = 0 Then
                MessageBox.Show("No existe una Plantilla para el Cliente " + uceClientes.SelectedItem.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                utcTabs.Tabs.Item("PRN").Selected = True
            Else
                CalculaPreFacturacion()
            End If
        End If
        If dtPlantilla.Rows.Count > 0 Then
            BtnExporExcelTotal.Enabled = True
            BtnExporPDFTotal2.Enabled = True
        Else
            BtnExporExcelTotal.Enabled = False
            BtnExporPDFTotal2.Enabled = False
        End If
    End Sub
    'Proceso que Obtine los datos de la plantilla del cliente
    Private Sub ObtenerPlantillaCliente()
        dtPlantilla.Clear()
        Dim row As DataRow
        LbCliente.Text = uceClientes.SelectedItem.ToString
        lbFecha.Text = "Prefacturacion desde el " + Date.Parse(udtDesde.Value.ToString).ToString("dd/MM/yyyy") + " hasta el " + Date.Parse(udtHasta.Value.ToString).ToString("dd/MM/yyyy")
        For Each r As DataRow In CommonDataFact.GetPlantiClienteServ(uceClientes.Value).Rows
            If r.Item("estado") = "A" Then
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
            End If
        Next
    End Sub
    Private Sub SetDisplayedColumnsPlantilla()
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact.DisplayLayout.Bands(0).Columns("idPlantillaClienteServicio").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("idCliente").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("idServiciosGA").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("idPeriodicidad").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("IdComparacionServicio").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("DescripcionPeriodicidad").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("ValorPeriodicidad").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("descripcionAgencia").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("CantAlmaContainerPer").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("VuelosProcesado").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalVuelos").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("Peso").Hidden = True
            ugdPreFact.DisplayLayout.Bands(0).Columns("DescripcionServicio").Header.Caption = "Servicio"
            ugdPreFact.DisplayLayout.Bands(0).Columns("ValorTarifa").Header.Caption = "Tarifa"
            ugdPreFact.DisplayLayout.Bands(0).Columns("CantAlmaContainerPer").Header.Caption = "Containers"
            ugdPreFact.DisplayLayout.Bands(0).Columns("VuelosProcesado").Header.Caption = "Vuelos Procesados"
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalVuelos").Header.Caption = "Total Vuelos"
            ugdPreFact.DisplayLayout.Bands(0).Columns("Peso").Header.Caption = "Total Peso"
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Header.Caption = "Total a Facturar"
            ugdPreFact.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption = "Total(Unidad)"
            ugdPreFact.DisplayLayout.Bands(0).Columns("Peso").Format = "#,##0.00"
            ugdPreFact.DisplayLayout.Bands(0).Columns("PesoVolumen").Format = "#,##0"
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Format = "#,##0.00"
            ugdPreFact.DisplayLayout.Bands(0).Columns("ValorTarifa").CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            'ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Formula = "if(IsDBNull([PesoVolumen]),[TotalVuelos]*[ValorTarifa],[PesoVolumen]*[ValorTarifa])"
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Formula = "[PesoVolumen]*[ValorTarifa]"
            ugdPreFact.DisplayLayout.Bands(0).Columns("DescripcionServicio").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
            ugdPreFact.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            'ugdPreFact.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            'For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdPreFact.Rows
            '    If IsDBNull(r.Cells("CantAlmaContainerPer").Value) And IIf(IsDBNull(r.Cells("ComparacionPesoVolumen").Value), "N", r.Cells("ComparacionPesoVolumen").Value) = "S" Then
            '        r.Cells("ValorTarifa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '    ElseIf IsDBNull(r.Cells("CantAlmaContainerPer").Value) And IIf(IsDBNull(r.Cells("ComparacionPesoVolumen").Value), "N", r.Cells("ComparacionPesoVolumen").Value) = "N" Then
            '        r.Cells("ValorTarifa").Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '    End If
            'Next
            ugdPreFact.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar"))
            ugdPreFact.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact.DisplayLayout.Bands(0).Columns("PesoVolumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact.DisplayLayout.Bands(0).Columns("ValorTarifa").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Width = Len(ugdPreFact.DisplayLayout.Bands(0).Columns("TotalCobrar").Header.Caption) - 5
            ugdPreFact.DisplayLayout.Bands(0).Columns("PesoVolumen").Width = Len(ugdPreFact.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption) - 5
            ugdPreFact.DisplayLayout.Bands(0).Columns("ValorTarifa").Width = Len(ugdPreFact.DisplayLayout.Bands(0).Columns("ValorTarifa").Header.Caption) - 5
            ugdPreFact.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Proceso q evalua el servicio y a  que procesos debe llamar
    Private Sub CalculaPreFacturacion()
        Dim Response As New ClassPrefacturacion
        Try
            For Each r As DataRow In dtPlantilla.Rows
                If r.Item("idServiciosGA") = 1 Then 'AGENTE DE CARGA(POR VUELO)
                    Response = ObtenerVuelosAgencia()
                    r.Item("PesoVolumen") = Response.TotalVuelos
                ElseIf r.Item("idServiciosGA") = 2 Then 'ALMACENAJE  CONTAINER
                    Dim TotalContainers As Integer
                    Response = ObtenerCantidadContainers(r.Item("idPeriodicidad"), r.Item("ValorPeriodicidad"))
                    TotalContainers = Response.TotalContainers - IIf(IsDBNull(r.Item("CantAlmaContainerPer")), 0, r.Item("CantAlmaContainerPer"))
                    For i As Integer = TotalContainers + 1 To Response.TotalContainers
                        dtDetalleServicioContainer.Rows.RemoveAt(dtDetalleServicioContainer.Rows.Count - 1)
                    Next
                    If TotalContainers > 0 Then
                        r.Item("PesoVolumen") = TotalContainers
                    Else
                        r.Item("PesoVolumen") = 0
                    End If
                ElseIf r.Item("idServiciosGA") = 5 Then 'DEVOLUCION DE CARGA
                    Response = ObtenerPesoVolumenDev()
                    If Response.PesoVolumenTotal > 0 Then
                        r.Item("Peso") = Response.PesoTotal
                        r.Item("PesoVolumen") = Response.PesoVolumenTotal
                    End If
                ElseIf r.Item("idServiciosGA") = 7 Then 'ESTIBA/DESESTIBA CAMION O DOLLY
                    Dim Datos As New Server.Facturacion.ServConsuCliente
                    Dim PesoVolumenTotal As Double
                    Dim PesoTotal As Double
                    With Datos
                        .idCliente = uceClientes.Value
                        .idServiciosGA = r.Item("idServiciosGA")
                        .FechaInicio = udtDesde.Value
                        .FechaFin = udtHasta.Value
                    End With
                    For Each rows As DataRow In CommonDataFact.PreFactObtenerServConsuCliente(Datos).Rows
                        Response = ObtenerPesoVolumenPorBriefGuiaServiciosAdicional(rows.Item("idBriefing"), rows.Item("idGuia"), rows.Item("FechaInicio"))
                        PesoVolumenTotal += Response.PesoVolumenTotal
                        PesoTotal += Response.PesoTotal
                    Next
                    r.Item("Peso") = PesoTotal
                    r.Item("PesoVolumen") = PesoVolumenTotal
                ElseIf r.Item("idServiciosGA") = 10 And r.Item("IdComparacionServicio") = 0 Then 'MINIMO POR VUELO
                    Response = ObtenerVuelosAgencia()
                    r.Item("PesoVolumen") = Response.TotalVuelos
                ElseIf r.Item("idServiciosGA") = 10 And r.Item("IdComparacionServicio") > 0 Then 'MINIMO POR VUELO
                    Dim rows As DataRow()
                    rows = dtPlantilla.Select("idServiciosGA=" & r.Item("IdComparacionServicio"))
                    If rows.Count > 0 Then
                        For Each r2 As DataRow In rows
                            Response = ObtenermMinimoVueloComparativo(r.Item("ValorTarifa"), r2.Item(8))
                            r.Item("Peso") = Response.PesoTotal
                            r.Item("PesoVolumen") = Response.PesoVolumenTotal
                        Next
                    End If
                ElseIf r.Item("idServiciosGA") = 11 And r.Item("IdComparacionServicio") > 0 Then 'MINIMO POR KILO
                    Dim rows As DataRow()
                    rows = dtPlantilla.Select("idServiciosGA=" & r.Item("IdComparacionServicio"))
                    If rows.Count > 0 Then
                        For Each r2 As DataRow In rows
                            Response = ObtenerPesoVoumenMinimoMesComparativo(r.Item("ValorTarifa"), r2.Item(8))
                            r.Item("Peso") = Response.PesoTotal
                            r.Item("PesoVolumen") = Response.PesoVolumenTotal
                        Next
                    End If
                ElseIf r.Item("idServiciosGA") = 12 Then 'ALQUILER DE MONTACARGA
                    Dim Datos As New Server.Facturacion.ServConsuCliente
                    Dim PesoVolumenTotal As Double
                    Dim PesoTotal As Double
                    With Datos
                        .idCliente = uceClientes.Value
                        .idServiciosGA = r.Item("idServiciosGA")
                        .FechaInicio = udtDesde.Value
                        .FechaFin = udtHasta.Value
                    End With
                    Dim TotalPeriodoCobrar As Integer
                    Dim NumDecimal As Integer
                    Dim NumEntero As Integer
                    Dim NumeroString As String
                    Dim reg As DataRow
                    Dim lbDecimal As Boolean = False
                    For Each rows As DataRow In CommonDataFact.PreFactObtenerServConsuCliente(Datos).Rows
                        lbDecimal = False
                        If r.Item("ValorPeriodicidad") > 0 Then
                            reg = DtServicioAdicionalMontaCarg.NewRow
                            reg.Item("Fecha") = rows.Item("FechaInicio")
                            reg.Item("codigoVuelo") = rows.Item("codigoVuelo")
                            reg.Item("guia") = rows.Item("Guia")
                            reg.Item("FechaInicio") = rows.Item("FechaInicio")
                            reg.Item("FechaFin") = rows.Item("FechaFin")
                            If r.Item("idPeriodicidad") = 2 Then 'Dia
                                reg.Item("TipoConsumo") = "Dia"
                                reg.Item("TiempoConsumido") = rows.Item("DiasConsumidos")
                                NumeroString = rows.Item("DiasConsumidos") / r.Item("ValorPeriodicidad")
                                NumDecimal = NumeroString.Substring(InStr(NumeroString, "."), NumeroString.Length - InStr(NumeroString, "."))
                                If InStr(NumeroString, ".") > 0 Then
                                    lbDecimal = True
                                    NumEntero = NumeroString.Substring(0, InStr(NumeroString, ".") - 1)
                                Else
                                    NumEntero = NumeroString
                                End If
                                If lbDecimal Then
                                    NumEntero += 1
                                End If
                                reg.Item("TotalPeriodo") = NumEntero
                                DtServicioAdicionalMontaCarg.Rows.Add(reg)
                            ElseIf r.Item("idPeriodicidad") = 3 Then 'Hora
                                reg.Item("TipoConsumo") = "Hora"
                                reg.Item("TiempoConsumido") = rows.Item("HarasConsumidos")
                                NumeroString = rows.Item("HarasConsumidos") / r.Item("ValorPeriodicidad")
                                NumDecimal = NumeroString.Substring(InStr(NumeroString, "."), NumeroString.Length - InStr(NumeroString, "."))
                                If InStr(NumeroString, ".") > 0 Then
                                    lbDecimal = True
                                    NumEntero = NumeroString.Substring(0, InStr(NumeroString, ".") - 1)
                                Else
                                    NumEntero = NumeroString
                                End If
                                If lbDecimal Then
                                    NumEntero += 1
                                End If
                                reg.Item("TotalPeriodo") = NumEntero
                                DtServicioAdicionalMontaCarg.Rows.Add(reg)
                            ElseIf r.Item("idPeriodicidad") = 4 Then 'minutos
                                reg.Item("TipoConsumo") = "Minutos"
                                reg.Item("TiempoConsumido") = rows.Item("MinutosConsumidos")
                                NumeroString = rows.Item("MinutosConsumidos") / r.Item("ValorPeriodicidad")
                                NumDecimal = NumeroString.Substring(InStr(NumeroString, "."), NumeroString.Length - InStr(NumeroString, "."))
                                If InStr(NumeroString, ".") > 0 Then
                                    lbDecimal = True
                                    NumEntero = NumeroString.Substring(0, InStr(NumeroString, ".") - 1)
                                Else
                                    NumEntero = NumeroString
                                End If
                                If lbDecimal Then
                                    NumEntero += 1
                                End If
                                reg.Item("TotalPeriodo") = NumEntero
                                DtServicioAdicionalMontaCarg.Rows.Add(reg)
                            End If
                            TotalPeriodoCobrar += NumEntero
                        Else
                            MessageBox.Show("El Servicio de ALQUILER DE MONTACARGA no tiene un valor en la Periodicidad")
                            Exit For
                        End If
                    Next
                    r.Item("PesoVolumen") = TotalPeriodoCobrar
                ElseIf r.Item("idServiciosGA") = 15 Then 'PROCESAMIENTO CARGA/VOLUMEN
                    If chkTipFact.SelectedIndex = 0 Then
                        Response = ObtenerPesoVolumen()
                    Else
                        Response = ObtenerPesoVolumenGuia()
                    End If
                    If Response.PesoVolumenTotal > 0 Then
                        r.Item("Peso") = Response.PesoTotal
                        r.Item("PesoVolumen") = Response.PesoVolumenTotal
                    End If
                    'ElseIf r.Item("idServiciosGA") = 18 Then 'MINIMO POR MES
                    '    If chkTipFact.SelectedIndex = 0 Then
                    '        Response = ObtenerPesoVolumen()
                    '    Else
                    '        Response = ObtenerPesoVolumenGuia()
                    '    End If
                    '    If Response.PesoVolumenTotal > 0 Then
                    '        r.Item("Peso") = Response.PesoTotal
                    '        r.Item("PesoVolumen") = Response.PesoVolumenTotal
                    '    Else
                    '        r.Item("PesoVolumen") = 1
                    '    End If
                End If
            Next
            Dim TablaRespaldo As New DataTable
            TablaRespaldo = dtPlantilla.Clone
            Dim rows1 As DataRow
            For Each r As DataRow In dtPlantilla.Rows
                If IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen")) > 0 And r.Item("ValorTarifa") > 0 Then
                    rows1 = TablaRespaldo.NewRow
                    rows1.Item("idPlantillaClienteServicio") = r.Item("idPlantillaClienteServicio")
                    rows1.Item("IdCliente") = r.Item("IdCliente")
                    rows1.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    rows1.Item("idServiciosGA") = r.Item("idServiciosGA")
                    rows1.Item("DescripcionServicio") = r.Item("DescripcionServicio")
                    rows1.Item("idPeriodicidad") = r.Item("idPeriodicidad")
                    rows1.Item("DescripcionPeriodicidad") = r.Item("DescripcionPeriodicidad")
                    rows1.Item("ValorPeriodicidad") = r.Item("ValorPeriodicidad")
                    rows1.Item("ValorTarifa") = r.Item("ValorTarifa")
                    rows1.Item("CantAlmaContainerPer") = r.Item("CantAlmaContainerPer")
                    rows1.Item("VuelosProcesado") = r.Item("VuelosProcesado")
                    rows1.Item("TotalVuelos") = r.Item("TotalVuelos")
                    rows1.Item("IdComparacionServicio") = r.Item("IdComparacionServicio")
                    rows1.Item("estado") = r.Item("estado")
                    rows1.Item("Peso") = r.Item("Peso")
                    rows1.Item("PesoVolumen") = r.Item("PesoVolumen")
                    rows1.Item("TotalCobrar") = r.Item("TotalCobrar")
                    TablaRespaldo.Rows.Add(rows1)
                End If
            Next
            dtPlantilla.Clear()
            dtPlantilla = TablaRespaldo.Copy
            TablaRespaldo.Clear()
            ugdPreFact.DataSource = dtPlantilla
            If dtPlantilla.Rows.Count > 0 Then
                ReporteTotalServi(dtPlantilla)
            End If
            'SetDisplayedColumnsPlantilla()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Proceso que es invocado cada vez que se procesen los servicios 1,10
    Private Function ObtenerVuelosAgencia() As ClassPrefacturacion
        Dim VuelosProcesado As Integer
        Dim Result As New ClassPrefacturacion
        Try
            Dim rows As DataRow
            dtDetalleVuelos.Clear()
            For Each r As DataRow In CommonDataFact.PreFactObtenerCantVuelosAgencia(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                rows = dtDetalleVuelos.NewRow
                rows.Item("fechaVuelo") = r.Item("fechaVuelo")
                rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                rows.Item("total") = r.Item("total")
                VuelosProcesado += r.Item("total")
                dtDetalleVuelos.Rows.Add(rows)
            Next
            If VuelosProcesado > 0 Then
                Result.TotalVuelos = VuelosProcesado
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    Private Function ObtenerCantidadContainers(idPeriodicidad As Integer, Periodicidad As Integer) As ClassPrefacturacion
        Dim TotalContainer As Integer
        Dim reg As DataRow
        Dim row As Integer
        Dim Fecha As DateTime
        Dim mes As Integer
        Dim dias As Integer
        Dim horas As Integer
        Dim minutos As Integer
        Dim Result As New ClassPrefacturacion
        Dim HistorialElement As New DataTable("HistorialElement")
        Dim DataHistorialElement As DataTable
        Dim foundRows() As DataRow
        HistorialElement = CommonDataFact.PreFactObtenerTiempoAlmaceContainer(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value)
        Dim dataViewHistorial As New DataView(HistorialElement)
        DataHistorialElement = dataViewHistorial.ToTable(True, "idElemento")
        Try
            dtDetalleServicioContainer.Clear()
            For Each r As DataRow In DataHistorialElement.Rows
                foundRows = HistorialElement.Select("idElemento = '" & r.Item("idElemento") & "'")
                row = 0
                For Each rows As DataRow In foundRows
                    If row = 0 And rows.ItemArray("4") = "ING" Then
                        reg = dtDetalleServicioContainer.NewRow
                        reg.Item("Elemento") = r.Item("idElemento")
                        row += 1
                        Fecha = rows.ItemArray("2")
                        Continue For
                    End If
                    If row > 0 Then
                        If "ING" <> rows.ItemArray("4") And rows.ItemArray("4") <> "CRE" Then
                            mes = DateDiff(DateInterval.Month, Fecha, rows.ItemArray("2"))
                            dias = DateDiff(DateInterval.Day, Fecha, rows.ItemArray("2"))
                            horas = DateDiff(DateInterval.Hour, Fecha, rows.ItemArray("2"))
                            minutos = DateDiff(DateInterval.Minute, Fecha, rows.ItemArray("2"))
                            If idPeriodicidad = 1 Then 'mes 
                                reg.Item("FechaInicio") = Fecha
                                reg.Item("FechaFin") = rows.ItemArray("2")
                                reg.Item("TipoConsumo") = "Hora"
                                reg.Item("TiempoConsumido") = horas
                                dtDetalleServicioContainer.Rows.Add(reg)
                                TotalContainer += 1
                            ElseIf idPeriodicidad = 2 Then 'dia
                                reg.Item("FechaInicio") = Fecha
                                reg.Item("FechaFin") = rows.ItemArray("2")
                                reg.Item("TipoConsumo") = "Hora"
                                reg.Item("TiempoConsumido") = horas
                                dtDetalleServicioContainer.Rows.Add(reg)
                                TotalContainer += 1
                            ElseIf idPeriodicidad = 3 Then 'hora
                                'If horas >= Periodicidad Then
                                reg.Item("FechaInicio") = Fecha
                                reg.Item("FechaFin") = rows.ItemArray("2")
                                reg.Item("TipoConsumo") = "Hora"
                                reg.Item("TiempoConsumido") = horas
                                dtDetalleServicioContainer.Rows.Add(reg)
                                TotalContainer += 1
                                'End If
                            ElseIf idPeriodicidad = 4 Then 'Minuto
                                reg.Item("FechaInicio") = Fecha
                                reg.Item("FechaFin") = rows.ItemArray("2")
                                reg.Item("TipoConsumo") = "Hora"
                                reg.Item("TiempoConsumido") = horas
                                dtDetalleServicioContainer.Rows.Add(reg)
                                TotalContainer += 1
                            End If
                            row = 0
                        End If
                    End If
                Next
            Next
            Result.TotalContainers = TotalContainer
            Return Result
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    'Proceso que es invocado cada vez que se procesen los servicios 7
    Private Function ObtenerPesoVolumenPorBriefGuiaServiciosAdicional(idBriefing As Guid, idGuia As Guid, FechaInicio As Date) As ClassPrefacturacion
        Dim PesoVolumenTotal As Double
        Dim Peso As Double
        Dim Result As New ClassPrefacturacion
        Dim Datos As New Server.Facturacion.ServConsuCliente
        Try
            With Datos
                .idBriefing = idBriefing
                .idGuia = idGuia
            End With
            Dim rows As DataRow
            DtServicioAdicionalEstiDesEsti.Clear()
            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenPorBriefGuia(Datos).Rows
                rows = DtServicioAdicionalEstiDesEsti.NewRow
                rows.Item("guia") = r.Item("guia")
                rows.Item("Peso") = r.Item("Peso")
                rows.Item("PesoVolumen") = r.Item("PesoVolumen")
                rows.Item("Fecha") = FechaInicio
                PesoVolumenTotal += r.Item("PesoVolumen")
                Peso += r.Item("Peso")
                DtServicioAdicionalEstiDesEsti.Rows.Add(rows)
            Next
            If PesoVolumenTotal > 0 Then
                Try
                    PesoVolumenTotal = Redondeo(PesoVolumenTotal, 0)
                Catch ex As Exception
                End Try
                Result.PesoTotal = Peso
                Result.PesoVolumenTotal = PesoVolumenTotal
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    'Proceso que es invocado cada vez que se procesen los servicios 10 y q se deba comparar con otro servicio
    Private Function ObtenermMinimoVueloComparativo(TarifaMinimaMes As Double, TarifaMinimaComparar As Double) As ClassPrefacturacion
        Dim Peso As Double
        Dim PesoVolumen As Double
        Dim Result As New ClassPrefacturacion
        Dim rows As DataRow
        Try
            Dim PesoRedondeo As Double
            Dim PesoDias As Double
            Dim fecha As Date
            Dim Vuelo As String
            Dim row As Integer
            dtDetalleMinimoVuelo.Clear()
            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenVuelo(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                rows = dtDetalleMinimoVuelo.NewRow
                Peso += r.Item("Peso")
                row += 1
                If row = 1 Then
                    fecha = r.Item("Fecha")
                    Vuelo = r.Item("codigoVuelo")
                End If
                If fecha = r.Item("Fecha") And Vuelo = r.Item("codigoVuelo") Then
                    PesoDias += r.Item("PesoVolumen")
                    Vuelo = r.Item("codigoVuelo")
                End If
                If fecha <> r.Item("Fecha") Or Vuelo <> r.Item("codigoVuelo") Then
                    Try
                        PesoRedondeo = Redondeo(PesoDias, 0)
                        PesoRedondeo = Redondeo((PesoRedondeo * TarifaMinimaComparar), 0)
                        If PesoRedondeo < TarifaMinimaMes Then
                            PesoVolumen += 1
                            rows.Item("fecha") = fecha
                            rows.Item("Peso") = Peso
                            rows.Item("PesoVolumen") = Redondeo(PesoDias, 0)
                            rows.Item("codigoVuelo") = Vuelo
                            dtDetalleMinimoVuelo.Rows.Add(rows)
                        End If
                    Catch ex As Exception
                    End Try
                    PesoDias = r.Item("PesoVolumen")
                    fecha = r.Item("Fecha")
                    Vuelo = r.Item("codigoVuelo")
                End If

            Next
            If dtDetalleMinimoVuelo.Rows.Count > 0 Then
                Try
                    rows.Item("fecha") = fecha
                    rows.Item("Peso") = Peso
                    'rows.Item("PesoVolumen") = PesoRedondeo
                    rows.Item("codigoVuelo") = Vuelo
                    dtDetalleMinimoVuelo.Rows.Add(rows)
                    PesoRedondeo = Redondeo(PesoDias, 0)
                    PesoRedondeo = Redondeo((PesoRedondeo * TarifaMinimaComparar), 0)
                    If PesoRedondeo < TarifaMinimaMes Then
                        PesoVolumen += 1
                    End If
                    rows.Item("PesoVolumen") = Redondeo(PesoDias, 0)
                Catch ex As Exception
                End Try
                Result.PesoTotal = Peso
                Result.PesoVolumenTotal = PesoVolumen
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    Private Function ObtenerPesoVolumenDev() As ClassPrefacturacion
        Dim Peso As Double
        Dim PesoVolumen As Double
        Dim Result As New ClassPrefacturacion
        Dim rows As DataRow
        Try
            Dim PesoRedondeo As Double
            Dim PesoDias As Double
            Dim fecha As Date
            Dim row As Integer
            dtDetallePesoVolumenVueloDev.Clear()

            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenVuelo(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                If r.Item("estado") = "D" Then
                    rows = dtDetallePesoVolumenVueloDev.NewRow
                    rows.Item("fecha") = r.Item("fecha")
                    rows.Item("guia") = r.Item("guia")
                    rows.Item("Peso") = r.Item("Peso")
                    rows.Item("PesoVolumen") = r.Item("PesoVolumen")
                    rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                    row += 1
                    If row = 1 Then
                        fecha = r.Item("Fecha")
                    End If
                    If fecha = r.Item("Fecha") Then
                        PesoDias += r.Item("PesoVolumen")
                    End If
                    If fecha <> r.Item("Fecha") Then
                        Try
                            PesoRedondeo = Redondeo(PesoDias, 0)
                            If PesoRedondeo <= 0 Then
                                PesoVolumen += PesoDias
                            Else
                                PesoVolumen += PesoRedondeo
                            End If
                        Catch ex As Exception
                            PesoVolumen += PesoDias
                        End Try
                        PesoDias = r.Item("PesoVolumen")
                        fecha = r.Item("Fecha")
                    End If
                    dtDetallePesoVolumenVueloDev.Rows.Add(rows)
                End If
            Next
            If dtDetallePesoVolumenVueloDev.Rows.Count > 0 Then
                Try
                    PesoRedondeo = Redondeo(PesoDias, 0)
                    If PesoRedondeo <= 0 Then
                        PesoVolumen += PesoDias
                    Else
                        PesoVolumen += PesoRedondeo
                    End If
                Catch ex As Exception
                    PesoVolumen += PesoDias
                End Try
                Result.PesoTotal = Peso
                Result.PesoVolumenTotal = PesoVolumen
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    'Proceso que es invocado cada vez que se procesen los servicios 11,15 y se consulta por vuelo
    Private Function ObtenerPesoVolumen() As ClassPrefacturacion
        Dim Peso As Double
        Dim PesoVolumen As Double
        Dim Result As New ClassPrefacturacion
        Dim rows As DataRow
        Try
            Dim PesoRedondeo As Double
            Dim PesoDias As Double
            Dim fecha As Date
            Dim row As Integer
            dtDetallePesoVolumenVuelo.Clear()

            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenVuelo(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                rows = dtDetallePesoVolumenVuelo.NewRow
                'rows.Item("fecha") = r.Item("fecha")
                'rows.Item("guia") = r.Item("guia")
                'rows.Item("Peso") = r.Item("Peso")
                'rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                row += 1
                If row = 1 Then
                    fecha = r.Item("Fecha")
                End If
                If fecha = r.Item("Fecha") Then
                    PesoDias += r.Item("PesoVolumen")
                End If
                If fecha <> r.Item("Fecha") Then
                    Try
                        PesoRedondeo = Redondeo(PesoDias, 0)
                        rows.Item("fecha") = fecha
                        rows.Item("PesoVolumen") = PesoRedondeo
                        If PesoRedondeo <= 0 Then
                            PesoVolumen += PesoDias
                        Else
                            PesoVolumen += PesoRedondeo
                        End If
                    Catch ex As Exception
                        PesoVolumen += PesoDias
                    End Try
                    PesoDias = r.Item("PesoVolumen")
                    fecha = r.Item("Fecha")
                    dtDetallePesoVolumenVuelo.Rows.Add(rows)
                End If
            Next
            If dtDetallePesoVolumenVuelo.Rows.Count > 0 Then
                Try
                    PesoRedondeo = Redondeo(PesoDias, 0)
                    rows = dtDetallePesoVolumenVuelo.NewRow
                    rows.Item("fecha") = fecha
                    rows.Item("PesoVolumen") = PesoRedondeo
                    dtDetallePesoVolumenVuelo.Rows.Add(rows)
                    If PesoRedondeo <= 0 Then
                        PesoVolumen += PesoDias
                    Else
                        PesoVolumen += PesoRedondeo
                    End If
                Catch ex As Exception
                    PesoVolumen += PesoDias
                End Try
                Result.PesoTotal = Peso
                Result.PesoVolumenTotal = PesoVolumen
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    'Proceso que es invocado cada vez que se procesen los servicios 11,15 y se consulta por Guia
    Private Function ObtenerPesoVolumenGuia() As ClassPrefacturacion
        Dim Peso As Double
        Dim PesoVolumen As Double
        Dim Result As New ClassPrefacturacion
        Dim rows As DataRow
        Try
            Dim PesoRedondeo As Double
            Dim PesoRedondeoI As Double
            Dim PesoDias As Double
            Dim fecha As Date
            Dim row As Integer
            Dim Pesos_I As Double
            Dim Pesos_R As Double
            Dim Addrow As Boolean = False
            dtDetallePesoVolumenGuias.Clear()
            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenGuia(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                If r.Item("Estado") = "A" Or r.Item("Estado") = "R" Then
                    Peso += r.Item("Peso")
                    rows = dtDetallePesoVolumenGuias.NewRow
                    rows.Item("fecha") = r.Item("fecha")
                    rows.Item("guia") = r.Item("guia")
                    rows.Item("Peso") = r.Item("Peso")
                    rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                    rows.Item("PesoVolumen") = IIf(r.Item("PesoVolumen") < 1, 1, Redondeo(r.Item("PesoVolumen"), 0))
                    Addrow = True
                End If
                row += 1
                If row = 1 Then
                    fecha = r.Item("Fecha")
                End If
                If fecha = r.Item("Fecha") Then
                    PesoDias += IIf(r.Item("PesoVolumen") < 1, 1, r.Item("PesoVolumen"))
                    If r.Item("Estado") = "I" Then
                        Pesos_I += r.Item("PesoVolumen")
                    End If
                End If
                If fecha <> r.Item("Fecha") Then
                    Try
                        PesoRedondeo = Redondeo(PesoDias, 0)
                        PesoRedondeoI = Redondeo(Pesos_I, 0)
                        If PesoRedondeo <= 0 Then
                            PesoVolumen += PesoDias - Pesos_I
                        Else
                            PesoVolumen += PesoRedondeo - PesoRedondeoI
                        End If
                    Catch ex As Exception
                        PesoVolumen += PesoDias - Pesos_I
                    End Try
                    PesoDias = r.Item("PesoVolumen")
                    If r.Item("Estado") = "I" Then
                        Pesos_I = r.Item("PesoVolumen")
                    Else
                        Pesos_I = 0
                    End If
                    fecha = r.Item("Fecha")
                End If
                If Addrow Then
                    dtDetallePesoVolumenGuias.Rows.Add(rows)
                End If
                Addrow = False
            Next
            Try
                PesoRedondeo = Redondeo(PesoDias, 0)
                PesoRedondeoI = Redondeo(Pesos_I, 0)
                If PesoRedondeo <= 0 Then
                    PesoVolumen += PesoDias - Pesos_I
                Else
                    PesoVolumen += PesoRedondeo - PesoRedondeoI
                End If
            Catch ex As Exception
                PesoVolumen += PesoDias - Pesos_I
            End Try
            Result.PesoTotal = Peso
            Result.PesoVolumenTotal = PesoVolumen
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function
    'Proceso que es invocado cada vez que se procesen los servicios 11
    Private Function ObtenerPesoVoumenMinimoMesComparativo(TarifaMinimaMes As Double, TarifaMinimaComparar As Double) As ClassPrefacturacion
        Dim Peso As Double
        Dim PesoVolumen As Double
        Dim Result As New ClassPrefacturacion
        Dim rows As DataRow
        Try
            Dim PesoRedondeo As Double
            Dim PesoDias As Double
            Dim fecha As Date
            Dim Vuelo As String
            Dim row As Integer
            Dim TotalVuelos
            Dim PesoDetalle As Double
            For Each r As DataRow In CommonDataFact.PreFactObtenerPesoVolumenVuelo(uceClientes.SelectedItem.Tag.ToString, udtDesde.Value, udtHasta.Value).Rows
                rows = dtDetalleMinimoMesComparado.NewRow
                Peso += r.Item("Peso")
                PesoDetalle += r.Item("Peso")
                row += 1
                If row = 1 Then
                    fecha = r.Item("Fecha")
                    Vuelo = r.Item("codigoVuelo")
                End If
                If fecha = r.Item("Fecha") And Vuelo = r.Item("codigoVuelo") Then
                    PesoDias += r.Item("PesoVolumen")
                    Vuelo = r.Item("codigoVuelo")
                End If
                If fecha <> r.Item("Fecha") Or Vuelo <> r.Item("codigoVuelo") Then
                    Try
                        PesoRedondeo = Redondeo(PesoDias, 0)
                        If Redondeo((PesoRedondeo * TarifaMinimaMes), 0) > TarifaMinimaComparar Then
                            PesoVolumen += PesoRedondeo
                            rows.Item("fecha") = fecha
                            rows.Item("Peso") = PesoDetalle
                            rows.Item("PesoVolumen") = Redondeo(PesoDias, 0)
                            rows.Item("codigoVuelo") = Vuelo
                            dtDetalleMinimoMesComparado.Rows.Add(rows)
                            PesoDetalle = 0
                        End If
                    Catch ex As Exception
                    End Try
                    PesoDias = r.Item("PesoVolumen")
                    fecha = r.Item("Fecha")
                    Vuelo = r.Item("codigoVuelo")
                End If
            Next
            If dtDetalleMinimoMesComparado.Rows.Count > 0 Then
                Try
                    PesoRedondeo = Redondeo(PesoDias, 0)
                    If Redondeo((PesoRedondeo * TarifaMinimaMes), 0) > TarifaMinimaComparar Then
                        PesoVolumen += PesoRedondeo
                        rows.Item("fecha") = fecha
                        rows.Item("Peso") = PesoDetalle
                        rows.Item("PesoVolumen") = Redondeo(PesoDias, 0)
                        rows.Item("codigoVuelo") = Vuelo
                        dtDetalleMinimoMesComparado.Rows.Add(rows)
                    End If
                Catch ex As Exception
                End Try
                Result.PesoTotal = Peso
                Result.PesoVolumenTotal = PesoVolumen
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
        Return Result
    End Function

    Private Function Redondeo(ByVal Numero, ByVal Decimales)
        Redondeo = Int(Numero * 10 ^ Decimales + 1 / 2) / 10 ^ Decimales
    End Function

    Private Sub ugdPreFact_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdPreFact.DoubleClickCell
        TxtServicio.Text = ugdPreFact.ActiveRow.Cells("DescripcionServicio").Value.ToString
        ugdPreFact_.ClearUndoHistory()
        ugdPreFact_.ClearXsdConstraints()
        ugdPreFact_.DataSource = Nothing
        If ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 1 Or (ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 10 And IsNothing(ugdPreFact.ActiveRow.Cells("IdComparacionServicio").Value)) Then
            If dtDetalleVuelos.Rows.Count > 0 Then
                For Each r As DataRow In dtDetalleVuelos.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                ugdPreFact_.DataSource = dtDetalleVuelos
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                SetDisplayedColumnsDetalleVuelos(ugdPreFact.ActiveRow.Cells("idServiciosGA").Value)
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 2 Then
            If dtDetalleServicioContainer.Rows.Count > 0 Then
                ugdPreFact_.DataSource = dtDetalleServicioContainer
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                For Each r As DataRow In dtDetalleServicioContainer.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                SetDisplayedColumnsContainer()
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 5 Then
            If dtDetallePesoVolumenVueloDev.Rows.Count > 0 Then
                For Each r As DataRow In dtDetallePesoVolumenVueloDev.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                ugdPreFact_.DataSource = dtDetallePesoVolumenVueloDev
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                SetDisplayedColumnsPesoVolumenVuelo(ugdPreFact.ActiveRow.Cells("idServiciosGA").Value)
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 7 Then
            If DtServicioAdicionalEstiDesEsti.Rows.Count > 0 Then
                For Each r As DataRow In DtServicioAdicionalEstiDesEsti.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                ugdPreFact_.DataSource = DtServicioAdicionalEstiDesEsti
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                SetDisplayedColumnsServicioAdicionalEstiDesEsti()
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 10 And ugdPreFact.ActiveRow.Cells("IdComparacionServicio").Value > 0 Then
            If dtDetalleMinimoVuelo.Rows.Count > 0 Then
                ugdPreFact_.DataSource = dtDetalleMinimoVuelo
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                For Each r As DataRow In dtDetalleMinimoVuelo.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                Dim rows As DataRow()
                Dim TarifaServCompa As Double
                rows = dtPlantilla.Select("idServiciosGA=" & ugdPreFact.ActiveRow.Cells("IdComparacionServicio").Value)
                If rows.Count > 0 Then
                    For Each r2 As DataRow In rows
                        TarifaServCompa = r2.Item(8)
                    Next
                End If
                SetDisplayedColumnsMinimoMesVuelo(TarifaServCompa)
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 11 And ugdPreFact.ActiveRow.Cells("IdComparacionServicio").Value > 0 Then
            If dtDetalleMinimoMesComparado.Rows.Count > 0 Then
                For Each r As DataRow In dtDetalleMinimoMesComparado.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                ugdPreFact_.DataSource = dtDetalleMinimoMesComparado
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                SetDisplayedColumnsMinimoMesComparado()
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 12 Then
            If DtServicioAdicionalMontaCarg.Rows.Count > 0 Then
                For Each r As DataRow In DtServicioAdicionalMontaCarg.Rows
                    r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                Next
                ugdPreFact_.DataSource = DtServicioAdicionalMontaCarg
                utcTabs.Tabs.Item("DTL").Enabled = True
                utcTabs.Tabs.Item("DTL").Selected = True
                SetDisplayedColumnsAlquilerMontaCarga()
            End If
        ElseIf ugdPreFact.ActiveRow.Cells("idServiciosGA").Value.ToString = 15 Then
            If chkTipFact.SelectedIndex = 0 Then
                If dtDetallePesoVolumenVuelo.Rows.Count > 0 Then
                    For Each r As DataRow In dtDetallePesoVolumenVuelo.Rows
                        r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                    Next
                    ugdPreFact_.DataSource = dtDetallePesoVolumenVuelo
                End If
            Else
                If dtDetallePesoVolumenGuias.Rows.Count > 0 Then
                    For Each r As DataRow In dtDetallePesoVolumenGuias.Rows
                        r.Item("Tarifa") = ugdPreFact.ActiveRow.Cells("ValorTarifa").Value
                    Next
                    ugdPreFact_.DataSource = dtDetallePesoVolumenGuias
                End If
            End If
            utcTabs.Tabs.Item("DTL").Enabled = True
            utcTabs.Tabs.Item("DTL").Selected = True
            SetDisplayedColumnsPesoVolumenVuelo(ugdPreFact.ActiveRow.Cells("idServiciosGA").Value)
        End If
    End Sub
    Private Sub SetDisplayedColumnsDetalleVuelos(TipoDetalle As Integer)
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            If TipoDetalle = 1 Then
                ugdPreFact_.Text = "Detalle Prefacturacion del Servicio-Agente de Carga por Vuelo"
            ElseIf TipoDetalle = 10 Then
                ugdPreFact_.Text = "Detalle Prefacturacion  del Servicio- Minimo por Vuelo"
            End If
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fechaVuelo").Header.Caption = "Fecha de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("total").Header.Caption = "Unidad"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption = "Total"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Formula = "[Tarifa]*[total]"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fechaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("total").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("total").Header.Caption)
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption)
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ReportePesoVolumen(dtDetalleVuelos, TipoDetalle, "Detalle de Prefacturacion  del Servicio: " + vbLf + "Agente de Carga por Vuelo", 0)
            'If TipoDetalle = 1 Then
            '    Dim DetalleCargaVuelos As DetalleVuelos
            '    ugdPreFact_.Text = "Detalle de Prefacturacion  del Servicio-PROCESAMIENTO CARGA/VOLUMEN"
            '    Dim ListDetalleCargaVolumen As New ListDetallePesoVolumenVuelo
            '    For Each r As DataRow In dtDetalleVuelos.Rows
            '        DetalleCargaVuelos = New DetalleVuelos
            '        With DetalleCargaVuelos
            '            .fechaVuelo = r.Item("fechaVuelo")
            '            .codigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
            '            .total = IIf(IsDBNull(r.Item("total")), 0, r.Item("total"))
            '            .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("total")), 0, r.Item("total"))
            '            .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
            '        End With
            '        ListDetalleCargaVolumen.DetalleVuelos.Add(DetalleCargaVuelos)
            '    Next
            '    With ListDetalleCargaVolumen
            '        .Cliente = uceClientes.SelectedItem.ToString
            '        .Servicio = "Detalle de Prefacturacion  del Servicio: " + vbLf + "Agente de Carga por Vuelo"
            '        .FechaIncio = udtDesde.Value
            '        .FechaFin = udtHasta.Value
            '    End With
            '    Dim ReportDetalle As New RptProCargVolum
            '    With ReportDetalle
            '        .ListDetallePesoVolumenVuelo = ListDetalleCargaVolumen
            '        .ListDetallePesoVolumenVuelo2.Add(ListDetalleCargaVolumen)
            '        .TipoServicio = 1
            '        .ShowDialog()
            '    End With

            'ElseIf TipoDetalle = 10 Then
            'End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsPesoVolumenVuelo(TipoDetalle As Integer)
        Try
            Dim dtDatos As New DataTable
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Hidden = True
            If chkTipFact.SelectedIndex = 0 Then
                ugdPreFact_.DisplayLayout.Bands(0).Columns("guia").Hidden = True
                ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Hidden = True
            Else
                ugdPreFact_.DisplayLayout.Bands(0).Columns("guia").Hidden = False
                ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Hidden = False
            End If
            'ugdPreFact_.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True
            'ugdPreFact_.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption = "Peso Real Kg."
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption) + 5
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "GUIA"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption = "Peso Real Kg./Volumen"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption = "Total"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Formula = "[Tarifa]*[PesoVolumen]"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Format = "###,##0"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Format = "###,##0.00"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption) + 8
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption)
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption) + 20
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).SortedColumns.Add("fecha", False, True)
            If chkTipFact.SelectedIndex = 0 Then
                dtDatos = dtDetallePesoVolumenVuelo
            Else
                dtDatos = dtDetallePesoVolumenGuias
            End If
            ReportePesoVolumen(dtDatos, 15, "Detalle de Prefacturacion  del Servicio: " + vbLf + "PROCESAMIENTO CARGA/VOLUMEN", 0)
            If TipoDetalle = 5 Then
                ugdPreFact_.Text = "Detalle de Prefacturacion del Servicio-DEVOLUCION DE CARGA"
            ElseIf TipoDetalle = 15 Then
                ugdPreFact_.Text = "Detalle de Prefacturacion  del Servicio-PROCESAMIENTO CARGA/VOLUMEN"
            End If
            'If TipoDetalle = 5 Then
            '    ugdPreFact_.Text = "Detalle de Prefacturacion del Servicio-DEVOLUCION DE CARGA"
            'ElseIf TipoDetalle = 15 Then
            '    Dim DetalleCargaVolumen As DetallePesoVolumenVuelo
            '    ugdPreFact_.Text = "Detalle de Prefacturacion  del Servicio-PROCESAMIENTO CARGA/VOLUMEN"
            '    Dim ListDetalleCargaVolumen As New ListDetallePesoVolumenVuelo
            '    If chkTipFact.SelectedIndex = 0 Then
            '        For Each r As DataRow In dtDetallePesoVolumenVuelo.Rows
            '            DetalleCargaVolumen = New DetallePesoVolumenVuelo
            '            With DetalleCargaVolumen
            '                .DescripcionFecha = "PROCESAMIENTO                  " + Date.Parse(r.Item("Fecha").ToString).ToString("dd/MM/yyyy")
            '                .Fecha = r.Item("Fecha")
            '                .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
            '                .CodigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
            '                .Guia = IIf(IsDBNull(r.Item("Guia")), "", r.Item("Guia"))
            '                .PesoVolumen = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
            '                .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
            '                .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
            '            End With
            '            ListDetalleCargaVolumen.DetallePesoVolumenVuelo.Add(DetalleCargaVolumen)
            '        Next
            '        ListDetalleCargaVolumen.TipoConsulta = "PV"
            '    Else
            '        For Each r As DataRow In dtDetallePesoVolumenGuias.Rows
            '            DetalleCargaVolumen = New DetallePesoVolumenVuelo
            '            With DetalleCargaVolumen
            '                .Fecha = r.Item("Fecha")
            '                .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
            '                .CodigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
            '                .Guia = IIf(IsDBNull(r.Item("Guia")), "", r.Item("Guia"))
            '                .PesoVolumen = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
            '                .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
            '                .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
            '            End With
            '            ListDetalleCargaVolumen.DetallePesoVolumenVuelo.Add(DetalleCargaVolumen)
            '        Next
            '        ListDetalleCargaVolumen.TipoConsulta = "GUIA"
            '    End If
            '    With ListDetalleCargaVolumen
            '        .Cliente = uceClientes.SelectedItem.ToString
            '        .Servicio = "Detalle de Prefacturacion  del Servicio: " + vbLf + "PROCESAMIENTO CARGA/VOLUMEN"
            '        .FechaIncio = udtDesde.Value
            '        .FechaFin = udtHasta.Value
            '    End With
            '    Dim ReportDetalle As New RptProCargVolum
            '    With ReportDetalle
            '        .ListDetallePesoVolumenVuelo = ListDetalleCargaVolumen
            '        .ListDetallePesoVolumenVuelo2.Add(ListDetalleCargaVolumen)
            '        .TipoServicio = 15
            '        .ShowDialog()
            '    End With
            'End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ReportePesoVolumen(DatosTabla As DataTable, TipoServicio As String, DetalleServicio As String, TarifaServCompa As Double)
        Try
            Dim ListDetalleCargaVolumen As New ListDetallePesoVolumenVuelo
            btnPDFExpor.Enabled = False
            If TipoServicio = 5 Or TipoServicio = 7 Or TipoServicio = 15 Or TipoServicio = 11 Or TipoServicio = 10 Then
                Dim DetalleCargaVolumen As DetallePesoVolumenVuelo
                If chkTipFact.SelectedIndex = 0 Then
                    For Each r As DataRow In DatosTabla.Rows
                        DetalleCargaVolumen = New DetallePesoVolumenVuelo
                        With DetalleCargaVolumen
                            If TipoServicio = 11 Or TipoServicio = 10 Then
                                .DescripcionFecha = "MANIPULEO DE CARGA     " + IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo")) + "     " + Date.Parse(r.Item("Fecha").ToString).ToString("dd/MM/yyyy")
                                If TipoServicio = 10 Then
                                    .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                                    ListDetalleCargaVolumen.TipoConsulta = "PVMV"
                                    .Peso = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen")) * TarifaServCompa
                                Else
                                    .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                                    ListDetalleCargaVolumen.TipoConsulta = "PV"
                                    .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
                                End If
                            Else
                                If TipoServicio = 7 Then
                                    .DescripcionFecha = "SERVICIO DE ESTIBA DEL     " + Date.Parse(r.Item("Fecha").ToString).ToString("dd/MM/yyyy")
                                Else
                                    .DescripcionFecha = "PROCESAMIENTO                  " + Date.Parse(r.Item("Fecha").ToString).ToString("dd/MM/yyyy")
                                End If
                                .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
                                .Guia = IIf(IsDBNull(r.Item("Guia")), "", r.Item("Guia"))
                                .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                                ListDetalleCargaVolumen.TipoConsulta = "PV"
                            End If
                            .Fecha = r.Item("Fecha")
                            .CodigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
                            .PesoVolumen = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen")) 'Replace(IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen")), ".", ",")

                            .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                        End With
                        ListDetalleCargaVolumen.DetallePesoVolumenVuelo.Add(DetalleCargaVolumen)
                    Next
                    btnPDFExpor.Enabled = True
                Else
                    For Each r As DataRow In DatosTabla.Rows
                        DetalleCargaVolumen = New DetallePesoVolumenVuelo
                        With DetalleCargaVolumen
                            .Fecha = r.Item("Fecha")
                            .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
                            .CodigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
                            .Guia = IIf(IsDBNull(r.Item("Guia")), "", r.Item("Guia"))
                            .PesoVolumen = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                            .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                            .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                        End With
                        ListDetalleCargaVolumen.DetallePesoVolumenVuelo.Add(DetalleCargaVolumen)
                    Next
                    ListDetalleCargaVolumen.TipoConsulta = "GUIA"
                    btnPDFExpor.Enabled = True
                End If
            ElseIf TipoServicio = 1 Then
                Dim DetalleCargaVuelos As DetalleVuelos
                For Each r As DataRow In dtDetalleVuelos.Rows
                    DetalleCargaVuelos = New DetalleVuelos
                    With DetalleCargaVuelos
                        .fechaVuelo = r.Item("fechaVuelo")
                        .codigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
                        .total = IIf(IsDBNull(r.Item("total")), 0, r.Item("total"))
                        .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("total")), 0, r.Item("total"))
                        .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                    End With
                    ListDetalleCargaVolumen.DetalleVuelos.Add(DetalleCargaVuelos)
                Next
                With ListDetalleCargaVolumen
                    .Cliente = uceClientes.SelectedItem.ToString
                    .FechaIncio = udtDesde.Value
                    .FechaFin = udtHasta.Value
                End With
                btnPDFExpor.Enabled = True
            ElseIf TipoServicio = 2 Then
                Dim DetalleServicioContainer As DetalleServicioContainer
                For Each r As DataRow In DatosTabla.Rows
                    DetalleServicioContainer = New DetalleServicioContainer
                    With DetalleServicioContainer
                        .Elemento = IIf(IsDBNull(r.Item("Elemento")), "", r.Item("Elemento"))
                        .FechaFin = r.Item("FechaFin")
                        .FechaInicio = r.Item("FechaInicio")
                        .TiempoConsumido = IIf(IsDBNull(r.Item("TiempoConsumido")), 0, r.Item("TiempoConsumido"))
                        .TipoConsumo = IIf(IsDBNull(r.Item("TipoConsumo")), "", r.Item("TipoConsumo"))
                        .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                    End With
                    ListDetalleCargaVolumen.DetalleServicioContainer.Add(DetalleServicioContainer)
                Next
                With ListDetalleCargaVolumen
                    .Cliente = uceClientes.SelectedItem.ToString
                    .FechaIncio = udtDesde.Value
                    .FechaFin = udtHasta.Value
                End With
                btnPDFExpor.Enabled = True
            ElseIf TipoServicio = 12 Then
                Dim DetalleServMontCarga As DetalleServMontCarga
                For Each r As DataRow In DatosTabla.Rows
                    DetalleServMontCarga = New DetalleServMontCarga
                    With DetalleServMontCarga
                        .codigoVuelo = IIf(IsDBNull(r.Item("CodigoVuelo")), "", r.Item("CodigoVuelo"))
                        .Fecha = Date.Parse(r.Item("Fecha").ToString).ToString("dd/MM/yyyy")
                        .FechaFin = Date.Parse(r.Item("FechaFin").ToString).ToString("dd/MM/yyyy")
                        .FechaInicio = Date.Parse(r.Item("FechaInicio").ToString).ToString("dd/MM/yyyy")
                        .guia = IIf(IsDBNull(r.Item("Guia")), "", r.Item("Guia"))
                        .SubTotal = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa")) * IIf(IsDBNull(r.Item("TotalPeriodo")), 0, r.Item("TotalPeriodo"))
                        .Tarifa = IIf(IsDBNull(r.Item("Tarifa")), 0, r.Item("Tarifa"))
                        .TiempoConsumido = IIf(IsDBNull(r.Item("TiempoConsumido")), 0, r.Item("TiempoConsumido"))
                        .TipoConsumo = IIf(IsDBNull(r.Item("TipoConsumo")), "", r.Item("TipoConsumo"))
                        .TotalPeriodo = IIf(IsDBNull(r.Item("TotalPeriodo")), "", r.Item("TotalPeriodo"))
                    End With
                    ListDetalleCargaVolumen.DetalleServMontCarga.Add(DetalleServMontCarga)
                Next
                btnPDFExpor.Enabled = True
            End If
            With ListDetalleCargaVolumen
                .Cliente = uceClientes.SelectedItem.ToString
                .Servicio = DetalleServicio
                .FechaIncio = udtDesde.Value
                .FechaFin = udtHasta.Value
            End With
            ReportDetalle = New RptProCargVolum
            With ReportDetalle
                .ListDetallePesoVolumenVuelo = ListDetalleCargaVolumen
                .ListDetallePesoVolumenVuelo2.Add(ListDetalleCargaVolumen)
                .TipoServicio = TipoServicio
                .ShowDialog()
            End With
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ReporteTotalServi(DatosTabla As DataTable)
        Try
            Dim ListDetalleServicoFacturar As New ListDetalleServicoFacturar
            Dim DetalleServicoFacturar As DetalleServicoFacturar
            For Each r As DataRow In DatosTabla.Rows
                DetalleServicoFacturar = New DetalleServicoFacturar
                With DetalleServicoFacturar
                    .idPlantillaClienteServicio = IIf(IsDBNull(r.Item("idPlantillaClienteServicio")), 0, r.Item("idPlantillaClienteServicio"))
                    .IdCliente = IIf(IsDBNull(r.Item("idCliente")), 0, r.Item("idCliente"))
                    .idServiciosGA = IIf(IsDBNull(r.Item("idServiciosGA")), 0, r.Item("idServiciosGA"))
                    .idPeriodicidad = IIf(IsDBNull(r.Item("idPeriodicidad")), 0, r.Item("idPeriodicidad"))
                    .IdComparacionServicio = IIf(IsDBNull(r.Item("IdComparacionServicio")), 0, r.Item("IdComparacionServicio"))
                    .DescripcionPeriodicidad = IIf(IsDBNull(r.Item("DescripcionPeriodicidad")), "", r.Item("DescripcionPeriodicidad"))
                    .ValorPeriodicidad = IIf(IsDBNull(r.Item("ValorPeriodicidad")), 0, r.Item("ValorPeriodicidad"))
                    .estado = IIf(IsDBNull(r.Item("estado")), "", r.Item("estado"))
                    .CantAlmaContainerPer = IIf(IsDBNull(r.Item("CantAlmaContainerPer")), 0, r.Item("CantAlmaContainerPer"))
                    .TotalVuelos = IIf(IsDBNull(r.Item("TotalVuelos")), 0, r.Item("TotalVuelos"))
                    .Peso = IIf(IsDBNull(r.Item("Peso")), 0, r.Item("Peso"))
                    .DescripcionServicio = IIf(IsDBNull(r.Item("DescripcionServicio")), "", r.Item("DescripcionServicio"))
                    .ValorTarifa = IIf(IsDBNull(r.Item("ValorTarifa")), 0, r.Item("ValorTarifa"))
                    .CantAlmaContainerPer = IIf(IsDBNull(r.Item("CantAlmaContainerPer")), 0, r.Item("CantAlmaContainerPer"))
                    .VuelosProcesado = IIf(IsDBNull(r.Item("VuelosProcesado")), 0, r.Item("VuelosProcesado"))
                    .TotalVuelos = IIf(IsDBNull(r.Item("TotalVuelos")), 0, r.Item("TotalVuelos"))
                    .TotalCobrar = IIf(IsDBNull(r.Item("ValorTarifa")), 0, r.Item("ValorTarifa")) * IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                    .PesoVolumen = IIf(IsDBNull(r.Item("PesoVolumen")), 0, r.Item("PesoVolumen"))
                End With
                ListDetalleServicoFacturar.DetalleServicoFacturar.Add(DetalleServicoFacturar)
            Next
            BtnExporPDFTotal.Enabled = True
            With ListDetalleServicoFacturar
                .Cliente = uceClientes.SelectedItem.ToString
                .Fecha_Incio = udtDesde.Value
                .Fecha_Fin = udtHasta.Value
            End With
            Report = New RptTotalServicios
            With Report
                .ListDetalleServicoFacturar = ListDetalleServicoFacturar
                .ListDetalleServicoFacturar2.Add(ListDetalleServicoFacturar)
            End With
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsMinimoMesVuelo(TarifaServCompa As Double)
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.Text = "Detalle Prefacturacion  del Servicio-MINIMO POR VUELO"
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo de Vuelo"
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption = "Peso Real Kg."
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption = "Peso Real Kg./Volumen"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption) + 3
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption) + 8
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption) + 20
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption) + 6
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ReportePesoVolumen(dtDetalleMinimoVuelo, 10, "Detalle de Prefacturacion  del Servicio: " + vbLf + "Servicio-MINIMO POR VUELO", TarifaServCompa)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsMinimoMesComparado()
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.Text = "Detalle Prefacturacion  del Servicio-MINIMO POR KILO"
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha de Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo de Vuelo"
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption = "Peso Real Kg."
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption = "Peso Real Kg./Volumen"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption = "Total"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Formula = "[Tarifa]*[PesoVolumen]"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption) + 3
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption) + 8
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption) + 8
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption) + 20
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ReportePesoVolumen(dtDetalleMinimoMesComparado, 11, "Detalle de Prefacturacion  del Servicio: " + vbLf + "Servicio-MINIMO POR KILO", 0)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsServicioAdicionalEstiDesEsti()
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.Text = "Detalle Prefacturacion  del Servicio-ESTIBA/DESESTIBA CAMION O DOLLY"
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Fecha").Header.Caption = "Fecha del Servicio Utilizado"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption = "Peso Real Kg."
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption = "Peso Real Kg./Volumen"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption = "Total"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Format = "#,##0.00"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Formula = "[Tarifa]*[PesoVolumen]"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ' ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("Peso").Header.Caption)
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption) + 8
            ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("PesoVolumen").Header.Caption) + 20
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ReportePesoVolumen(DtServicioAdicionalEstiDesEsti, 7, "Detalle de Prefacturacion  del Servicio: " + vbLf + "Servicio-ESTIBA/DESESTIBA CAMION O DOLLY", 0)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsAlquilerMontaCarga()
        Try
            ugdPreFact_.Text = "Detalle Prefacturacion  del Servicio-ALQUILER DE MONTACARGA"
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Fecha").Header.Caption = "Fecha del Servicio Utilizado"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Vuelo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").Header.Caption = "Fecha de Inicio"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").Header.Caption = "Fecha de Fin"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TipoConsumo").Header.Caption = "Tipo de Consumo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").Header.Caption = "Timpo Consumido"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TotalPeriodo").Header.Caption = "Total Periodos"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption = "Total"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Format = "#,##0.00"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Formula = "[Tarifa]*[TotalPeriodo]"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").Format = "dd/mm/yyyy hh:mm:ss"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").Format = "dd/mm/yyyy hh:mm:ss"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("SubTotal").Header.Caption) + 5
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            ReportePesoVolumen(DtServicioAdicionalMontaCarg, 12, "Detalle de Prefacturacion  del Servicio: " + vbLf + "ALQUILER DE MONTACARGA", 0)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetDisplayedColumnsContainer()
        Try
            Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
            calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Container)
            ugdPreFact_.Text = "Detalle Prefacturacion del Servicio-ALMACENAJE  CONTAINER"
            ugdPreFact_.DisplayLayout.Grid.CalcManager = calcManager
            ugdPreFact_.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").Header.Caption = "Fecha Entrada"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").Header.Caption = "Fecha Salida/Proceso"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TipoConsumo").Header.Caption = "Tipo de Consumo"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").Header.Caption = "Timpo Consumido"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").Format = "dd/mm/yyyy hh:mm:ss"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").Format = "dd/mm/yyyy hh:mm:ss"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.Bands(0).Columns("FechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdPreFact_.DisplayLayout.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            ugdPreFact_.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Count, ugdPreFact_.DisplayLayout.Bands(0).Columns("Elemento"))
            ugdPreFact_.DisplayLayout.Bands(0).Summaries(0).DisplayFormat = "{0:#,##0.00}"
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").Width = Len(ugdPreFact_.DisplayLayout.Bands(0).Columns("TiempoConsumido").Header.Caption) * 5
            ReportePesoVolumen(dtDetalleServicioContainer, 2, "Detalle de Prefacturacion  del Servicio: " + vbLf + "ALMACENAJE  CONTAINER", 0)
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdPreFact_)
    End Sub
    Private Sub btnPDFExport_Click(sender As Object, e As EventArgs) Handles btnPDFExpor.Click
        'General.ExportToPDF(ugdPreFact_)
        With ReportDetalle
            .ShowDialog()
        End With
    End Sub
    Private Sub utcTabs_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles utcTabs.SelectedTabChanged
        If utcTabs.Tabs.Item("DTL").Selected Then
            If Not btnExcelExport.Enabled Then
                btnExcelExport.Enabled = True
            End If
            If Not btnPDFExpor.Enabled Then
                btnPDFExpor.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnExporExcelTotal_Click(sender As Object, e As EventArgs) Handles BtnExporExcelTotal.Click
        General.ExportToExcel(ugdPreFact)

    End Sub
    Private Sub BtnExporPDFTotal2_Click(sender As Object, e As EventArgs) Handles BtnExporPDFTotal2.Click
        General.ExportToPDF(ugdPreFact)
    End Sub

    Private Sub BtnExporPDFTotal_Click(sender As Object, e As EventArgs) Handles BtnExporPDFTotal.Click
        With Report
            .ShowDialog()
        End With
    End Sub
End Class
