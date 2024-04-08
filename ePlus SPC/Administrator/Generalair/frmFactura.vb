Imports SPC.Server.ProcesoService
Imports SPC.Server.VuelosService
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class frmFactura

    Dim tableTarifa As DataTable = New DataTable("Tarifas")
    Dim tableProduction1 As DataTable = New DataTable("Production1")
    Dim tableProduction2 As DataTable = New DataTable("Production2")
    Dim tableProduction3 As DataTable = New DataTable("Production3")
    Dim tableProduction4 As DataTable = New DataTable("Production4")
    Dim tableProductionFinal1 As DataTable = New DataTable("ProductionFinal1")
    Dim tableProductionFinal2 As DataTable = New DataTable("ProductionFinal2")
    Dim tableProductionFinal3 As DataTable = New DataTable("ProductionFinal3")
    Dim tableProductionFinal4 As DataTable = New DataTable("ProductionFinal4")
    Dim tableVuelos As DataTable = New DataTable("Vuelos")
    Public Property myProceso As New ProcesoItem
    Dim tableCargaProcesada As DataTable = New DataTable("CargaProcesada")
    Dim tableCargaQuedada As DataTable = New DataTable("CargaQuedada")
    Dim tableCargaOtros As DataTable = New DataTable("CargaOtros")
    'Variables de Tarifas
    Dim tarifaCargaVolumen As String

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If uceLines.SelectedIndex = 0 Then
            MessageBox.Show("Debe seleccionar Aerolínea (Cliente)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If udtInicio.Value = Nothing Then
            MessageBox.Show("Debe indicar fecha de inicio mínimo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf udtFin.Value < udtInicio.Value Then
            MessageBox.Show("Fecha de final menor a la de inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            btnExcelExport.Enabled = True
            ugdFacturas.Text = "SERVICIO FACTURADO DEL " & CDate(udtInicio.Value).ToString("dd/MM/yyyy") & " AL " & CDate(udtFin.Value).ToString("dd/MM/yyyy")
            SearchData()
        End If
    End Sub

    Private Sub SearchData()
        'Limpiar tablas
        tableProductionFinal1.Rows.Clear()
        tableProduction2.Rows.Clear()
        tableProductionFinal2.Rows.Clear()
        tableProductionFinal3.Rows.Clear()
        tableProduction4.Rows.Clear()
        tableProductionFinal4.Rows.Clear()
        tableTarifa = CommonData.GetTarifaporAgenciayFecha(uceLines.Value, Now.Date)
        For i = 0 To tableTarifa.Rows.Count - 1
            tarifaCargaVolumen = tableTarifa.Rows(i).Item("procesamientoCVTar").ToString()
        Next
        Select Case uceLines.Value
            'Avianca -> Guía - Fecha - Vuelo - Kilos/Volumen
            Case Guid.Parse("ab4cde58-f5da-11e5-9826-e29e7468ae2f")
                tableProduction1 = CommonProcess.GetProductionAgenciaDescription(uceLines.Value, udtInicio.Value, udtFin.Value)
                ProcesarData1()
                ugdFacturas.DataSource = tableProductionFinal1
                SetDisplayedColumnsByProductionAgenciaDescription()
            Case Guid.Parse("d727f82c-12a2-11E4-981b-8F9d682eafe3")
            'DHL -> Kilos/Volumen día - Estiba 
            Case Guid.Parse("88867856-1270-11e4-981b-8f9d682eafe3")
                For Each row1 As DataRow In Vuelos().Rows 'Obtenemos vuelos por rango de fechas
                    'Sumatorias de Parámetros
                    Dim valorCarga As Decimal = 0D
                    Dim valorCurrier As Decimal = 0D
                    Dim valorCargaQuedada As Decimal = 0D
                    Dim valorCurrierQuedada As Decimal = 0D
                    Dim valorOtros As Decimal = 0D
                    Dim valorCurrierOtros As Decimal = 0D
                    'Vuelo
                    myProceso = CommonProcess.GetProcesoPoridBriefing(row1.Item("idBriefing"))
                    'Carga Procesada
                    tableCargaProcesada = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(myProceso.IdProceso)
                    tableCargaQuedada = CommonProcess.GetDetalleProcesoPorIdProcesoCargaI(myProceso.IdProceso)
                    For Each row2 As DataRow In tableCargaProcesada.Rows
                        If (row2.Item("agenciaCargaGuia") = "DHL (EXPRESS)" Or row2.Item("agenciaCargaGuia") = "DHL (REEMBARQUE)") And row2.Item("estado") <> "R" Then
                            valorCurrier += row2.Item("peso")
                        ElseIf row2.Item("estado") <> "R" Then
                            If row2.Item("volumen") < row2.Item("peso") Then
                                valorCarga += row2.Item("peso")
                            Else
                                valorCarga += row2.Item("volumen")
                            End If
                        Else
                            If Not row2.Item("agenciaCargaGuia") = "DHL (EXPRESS)" Or row2.Item("agenciaCargaGuia") = "DHL (REEMBARQUE)" Then
                                If row2.Item("volumen") < row2.Item("peso") Then
                                    valorOtros += row2.Item("peso")
                                Else
                                    valorOtros += row2.Item("volumen")
                                End If
                            End If
                        End If
                    Next
                    'Carga Quedada
                    For Each row3 As DataRow In tableCargaQuedada.Rows
                        If Not row3.Item("agenciaTransporteDescripcion") = "DHL (EXPRESS)" Or row3.Item("agenciaTransporteDescripcion") = "DHL (REEMBARQUE)" Then
                            If row3.Item("volumen") < row3.Item("peso") Then
                                valorCargaQuedada += row3.Item("peso")
                            Else
                                valorCargaQuedada += row3.Item("volumen")
                            End If
                        End If
                    Next
                    For Each row4 As DataRow In tableCargaQuedada.Rows
                        If row4.Item("agenciaTransporteDescripcion") = "DHL (EXPRESS)" Or row4.Item("agenciaTransporteDescripcion") = "DHL (REEMBARQUE)" Then
                            valorCurrierQuedada += row4.Item("peso")
                        End If
                    Next
                    'Agregar variables a tabla principal
                    Dim rowFinal As DataRow = tableProduction2.NewRow
                    rowFinal.Item(0) = row1.Item("fechaVuelo")
                    rowFinal.Item(1) = valorCarga
                    rowFinal.Item(2) = valorCurrier
                    rowFinal.Item(3) = valorCargaQuedada
                    rowFinal.Item(4) = valorCurrierQuedada
                    rowFinal.Item(5) = valorOtros
                    tableProduction2.Rows.Add(rowFinal)
                Next
                tableProduction2.AcceptChanges()
                ProcesarData2()
                ugdFacturas.DataSource = tableProductionFinal2
                SetDisplayedColumnsByDHL()
            Case Guid.Parse("78613da6-1277-11e4-981b-8f9d682eafe3")
                For Each row1 As DataRow In Vuelos().Rows
                    Dim valorCarga As Decimal = 0D
                    myProceso = CommonProcess.GetProcesoPoridBriefing(row1.Item("idBriefing"))
                    tableCargaProcesada = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(myProceso.IdProceso)
                    For Each row2 As DataRow In tableCargaProcesada.Rows
                        If (row2.Item("estado") = "A" Or row2.Item("estado") = "I" Or row2.Item("estado") = "D") Then
                            If row2.Item("volumen") < row2.Item("peso") Then
                                valorCarga += row2.Item("peso")
                            Else
                                valorCarga += row2.Item("volumen")
                            End If
                        End If
                    Next
                    Dim rowFinal3 As DataRow = tableProductionFinal3.NewRow
                    If CInt(valorCarga) > 0 Then
                        rowFinal3.Item(1) = "Procesamiento"
                        rowFinal3.Item(0) = CDate(row1.Item("fechaVuelo")).ToString("dd/MM/yyyy")
                        rowFinal3.Item(2) = Decimal.Round(valorCarga)
                        tableProductionFinal3.Rows.Add(rowFinal3)
                    End If
                Next
                tableProductionFinal3.AcceptChanges()
                ugdFacturas.DataSource = tableProductionFinal3
                SetDisplayedColumnsByProduction()
            Case Guid.Parse("b86b9024-12ac-11e4-981b-8f9d682eafe3")
                For Each row1 As DataRow In Vuelos().Rows
                    Dim valorCarga As Decimal = 0D
                    Dim valorEstiba As Decimal = 0D
                    myProceso = CommonProcess.GetProcesoPoridBriefing(row1.Item("idBriefing"))
                    tableCargaProcesada = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(myProceso.IdProceso)
                    For Each row2 As DataRow In tableCargaProcesada.Rows
                        If (row2.Item("estado") = "A" Or row2.Item("estado") = "I" Or row2.Item("estado") = "D") Then
                            If row2.Item("volumen") < row2.Item("peso") Then
                                valorCarga += row2.Item("peso")
                            Else
                                valorCarga += row2.Item("volumen")
                            End If
                        End If
                    Next
                    For Each row2 As DataRow In tableCargaProcesada.Rows
                        If row2.Item("agenciaCargaGuia") = "UNITED PARCEL SERVICES UPS" Then
                            valorEstiba += row2.Item("peso")
                        End If
                    Next
                    Dim rowFinal4 As DataRow = tableProduction4.NewRow
                    Dim count As Integer = 0
                    If CInt(valorEstiba) > 0 And count = 0 Then
                        rowFinal4.Item(0) = "Servicio de Estiba"
                        rowFinal4.Item(1) = ""
                        rowFinal4.Item(2) = row1.Item("fechaVuelo")
                        rowFinal4.Item(3) = Decimal.Round(valorEstiba)
                        tableProduction4.Rows.Add(rowFinal4)
                        count = count + 1
                    End If
                    Dim rowFinal5 As DataRow = tableProduction4.NewRow
                    rowFinal5.Item(0) = "Manipulación de Carga"
                    rowFinal5.Item(1) = row1.Item("codigoVuelo")
                    rowFinal5.Item(2) = row1.Item("fechaVuelo")
                    rowFinal5.Item(3) = Decimal.Round(valorCarga)
                    tableProduction4.Rows.Add(rowFinal5)
                Next
                Dim d As DataView = tableProduction4.DefaultView
                d.Sort = "fecha desc"
                tableProduction4 = d.ToTable()
                tableProduction4.AcceptChanges()
                ProcesarData4()
                ugdFacturas.DataSource = tableProductionFinal4
                SetDisplayedColumnsByUPS()
        End Select
    End Sub

    Private Sub ProcesarData1()
        For Each r As DataRow In tableProduction1.Rows
            Dim row As DataRow = tableProductionFinal1.NewRow
            row.Item(0) = r.Item(0)
            row.Item(1) = CDate(r.Item(1)).ToString("dd/MM/yyyy")
            row.Item(2) = r.Item(2)
            If r.Item("volumen") < r.Item("peso") Then
                row.Item(3) = r.Item("peso")
            Else
                row.Item(3) = r.Item("volumen")
            End If
            tableProductionFinal1.Rows.Add(row)
        Next
    End Sub

    Private Sub ProcesarData2()
        For Each r As DataRow In tableProduction2.Rows
            Dim row As DataRow = tableProductionFinal2.NewRow
            Dim express As Decimal
            Dim acsVuelo As Decimal
            express = r.Item(2) - r.Item(4)
            acsVuelo = (CDbl(r.Item(1)) + CDbl(r.Item(5))) - r.Item(3)  'Total embarcado
            row.Item(0) = CDate(r.Item(0)).ToString("dd/MM/yyyy")
            row.Item(1) = Decimal.Round(r.Item(1))
            'row.Item(2) = 948
            'row.Item(3) = 98
            row.Item(2) = Decimal.Round(r.Item(2))
            row.Item(3) = Decimal.Round(CDec(r.Item(2) * 0.0103), 2)
            row.Item(4) = Decimal.Round(acsVuelo)
            row.Item(5) = Decimal.Round(CDec(acsVuelo * 0.065), 2)
            row.Item(6) = Decimal.Round(express)
            row.Item(7) = express * 0.2
            tableProductionFinal2.Rows.Add(row)
        Next
    End Sub

    Private Sub ProcesarData4()
        For Each r As DataRow In tableProduction4.Rows
            Dim row As DataRow = tableProductionFinal4.NewRow
            Dim costo As Double = 0D
            If r.Item(0) = "Manipulación de Carga" Then
                costo = 0.055
            Else
                costo = 0.0207
            End If
            row.Item(0) = r.Item(0)
            row.Item(1) = r.Item(1)
            row.Item(2) = CDate(r.Item(2)).ToString("dd/MM/yyyy")
            row.Item(3) = r.Item(3)
            row.Item(4) = costo
            row.Item(5) = Decimal.Round(CDec(r.Item(3) * costo), 2)
            tableProductionFinal4.Rows.Add(row)
        Next
    End Sub

    Private Sub SetDisplayedColumnsByProductionAgenciaDescription()
        Dim band As UltraGridBand = ugdFacturas.DisplayLayout.Bands(0)
        band.Reset()
        band.Columns("guia").Header.Caption = "No. Guía (Descripción)"
        band.Columns("fecha").Header.Caption = "Fecha de Operación"
        band.Columns("fecha").CellActivation = Activation.NoEdit
        band.Columns("vuelo").Header.Caption = "No.Vuelo"
        band.Columns("peso").Header.Caption = "Kilos/Volumen"
        band.Columns("peso").Format = "#,##0.00"
        Dim summary As SummarySettings = band.Summaries.Add(SummaryType.Sum, band.Columns("peso"))
        summary.DisplayFormat = "{0:#,##.00}"
        band.SummaryFooterCaption = "Totales"
    End Sub

    Private Sub SetDisplayedColumnsByDHL()
        ugdFacturas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
        'ugdFacturas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Dim band As UltraGridBand = ugdFacturas.DisplayLayout.Bands(0)
        band.Columns("fecha").Header.Caption = "Fecha de Operación"
        band.Columns("fecha").CellActivation = Activation.NoEdit
        band.Columns("cargaRecibida").Header.Caption = "Kilos/Volumen"
        band.Columns("cargaRecibida").Format = "#,##0.00"
        'band.Columns("paquetes").Header.Caption = "Kilos"
        'band.Columns("documentos").Header.Caption = "Kilos"
        band.Columns("estiba").Header.Caption = "Kilos"
        band.Columns("estiba").Format = "#,##0.00"
        band.Columns("totalEstiba").Header.Caption = "Valor"
        band.Columns("totalEstiba").Format = "$#,##0.00"
        band.Columns("cargaVuelo").Header.Caption = "Kilos/Volumen"
        band.Columns("cargaVuelo").Format = "#,##0.00"
        band.Columns("totalCargaVuelo").Header.Caption = "Valor"
        band.Columns("totalCargaVuelo").Format = "$#,##0.00"
        band.Columns("express").Header.Caption = "Kilos"
        band.Columns("express").Format = "#,##0.00"
        band.Columns("expressTotal").Header.Caption = "Valor"
        band.Columns("expressTotal").Format = "$#,##0.00"
        band.RowLayoutStyle = RowLayoutStyle.GroupLayout
        ugdFacturas.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.AllowAll
        band.ColHeaderLines = 3
        Dim group1 As UltraGridGroup = Nothing
        Dim group2 As UltraGridGroup = Nothing
        Dim group3 As UltraGridGroup = Nothing
        Dim group4 As UltraGridGroup = Nothing
        'Dim group5 As UltraGridGroup = Nothing
        'Dim group6 As UltraGridGroup = Nothing
        Dim group7 As UltraGridGroup = Nothing
        Dim group8 As UltraGridGroup = Nothing
        Dim group9 As UltraGridGroup = Nothing
        'Limpiamos los Grupos
        band.Groups.Clear()
        band.Columns("fecha").RowLayoutColumnInfo.SpanY = 6 'Cubrir toda la altura de los grupos
        band.Columns("fecha").RowLayoutColumnInfo.OriginX = 0
        band.Columns("fecha").Width = 100
        'Grupos Padres
        group1 = band.Groups.Add("Group1", "ACS")
        group2 = band.Groups.Add("Group2", "DHL Express")
        group3 = band.Groups.Add("Group3", "Total Embarcado")
        group1.RowLayoutGroupInfo.OriginX = 4
        'Grupos Hijos
        group4 = band.Groups.Add("Group4", "Carga General")
        'group5 = band.Groups.Add("Group5", "Paquetería")
        'group6 = band.Groups.Add("Group6", "Documentos")
        group7 = band.Groups.Add("Group7", "Estiba")
        group8 = band.Groups.Add("Group8", "ACS")
        group9 = band.Groups.Add("Group9", "Express")
        'Asignar Grupos Hijos a Padres
        band.Groups("group4").RowLayoutGroupInfo.ParentGroup = group1
        'band.Groups("group5").RowLayoutGroupInfo.ParentGroup = group2
        'band.Groups("group6").RowLayoutGroupInfo.ParentGroup = group2
        band.Groups("group7").RowLayoutGroupInfo.ParentGroup = group2
        band.Groups("group8").RowLayoutGroupInfo.ParentGroup = group3
        band.Groups("group9").RowLayoutGroupInfo.ParentGroup = group3
        'Asignar Columnas a Grupos Hijos
        band.Columns("cargaRecibida").RowLayoutColumnInfo.ParentGroup = group4
        'band.Columns("paquetes").RowLayoutColumnInfo.ParentGroup = group5
        'band.Columns("documentos").RowLayoutColumnInfo.ParentGroup = group6
        band.Columns("estiba").RowLayoutColumnInfo.ParentGroup = group7
        band.Columns("totalEstiba").RowLayoutColumnInfo.ParentGroup = group7
        band.Columns("cargaVuelo").RowLayoutColumnInfo.ParentGroup = group8
        band.Columns("totalCargaVuelo").RowLayoutColumnInfo.ParentGroup = group8
        band.Columns("express").RowLayoutColumnInfo.ParentGroup = group9
        band.Columns("expressTotal").RowLayoutColumnInfo.ParentGroup = group9
        'Sumas
        band.Summaries.Clear()
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("cargaRecibida")).DisplayFormat = "{0:#,##.00}"
        'band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("paquetes")).DisplayFormat = "{0:#,##.00}"
        'band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("documentos")).DisplayFormat = "{0:#,##.00}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("estiba")).DisplayFormat = "{0:#,##.00}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("totalEstiba")).DisplayFormat = "{0:C2}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("cargaVuelo")).DisplayFormat = "{0:#,##.00}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("totalCargaVuelo")).DisplayFormat = "{0:C2}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("express")).DisplayFormat = "{0:#,##.00}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("expressTotal")).DisplayFormat = "{0:C2}"
        band.SummaryFooterCaption = "Totales"
    End Sub

    Private Sub SetDisplayedColumnsByProduction()
        Dim band As UltraGridBand = ugdFacturas.DisplayLayout.Bands(0)
        band.Reset()
        band.Columns("mensaje").Header.Caption = "Detalle"
        band.Columns("fecha").Header.Caption = "Fecha de Operación"
        band.Columns("fecha").CellActivation = Activation.NoEdit
        band.Columns("kilos").Header.Caption = "Total de Kilos"
        band.Columns("kilos").Format = "#,##0.00"
        Dim summary As SummarySettings = band.Summaries.Add(SummaryType.Sum, band.Columns("kilos"))
        summary.DisplayFormat = "{0:#,##.00}"
        band.SummaryFooterCaption = "Total"
    End Sub

    Private Sub SetDisplayedColumnsByUPS()
        Dim band As UltraGridBand = ugdFacturas.DisplayLayout.Bands(0)
        band.Reset()
        band.Columns("mensaje").Header.Caption = "Detalle"
        band.Columns("vuelo").Header.Caption = "No. de Vuelo"
        band.Columns("fecha").Header.Caption = "Fecha"
        band.Columns("fecha").CellActivation = Activation.NoEdit
        band.Columns("kilos").Header.Caption = "Total de Kilos"
        band.Columns("valor").Header.Caption = "Costo Unitario"
        band.Columns("subtotal").Header.Caption = "Subtotal"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("valor")).DisplayFormat = "{0:#,##.00}"
        band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns("subtotal")).DisplayFormat = "{0:C2}"
        band.SummaryFooterCaption = "Totales"
    End Sub
    Private Sub frmFactura_Load(sender As Object, e As EventArgs) Handles Me.Load
        With tableProductionFinal1.Columns
            .Add("guia")
            .Add("fecha")
            .Add("vuelo")
            .Add("peso")
        End With
        With tableProduction2.Columns
            .Add("fecha")
            .Add("cargaProcesada")
            .Add("paquetesProcesados")
            .Add("cargaQuedada")
            .Add("paquetesQuedado")
            .Add("cargaOtros")
        End With
        With tableProduction4.Columns
            .Add("mensaje")
            .Add("vuelo")
            .Add("fecha")
            .Add("kilos")
        End With
        With tableProductionFinal2.Columns
            .Add("fecha")
            .Add("cargaRecibida")
            '.Add("paquetes")
            '.Add("documentos")
            .Add("estiba")
            .Add("totalEstiba")
            .Add("cargaVuelo")
            .Add("totalCargaVuelo")
            .Add("express")
            .Add("expressTotal")
        End With
        With tableProductionFinal3.Columns
            .Add("fecha")
            .Add("mensaje")
            .Add("kilos")
        End With
        With tableProductionFinal4.Columns
            .Add("mensaje")
            .Add("vuelo")
            .Add("fecha")
            .Add("kilos")
            .Add("valor")
            .Add("subtotal")
        End With
        uceLines.Items.Clear()
        uceLines.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetTarifaCatalog().Rows
            uceLines.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceLines.SelectedIndex = 0
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdFacturas)
    End Sub

    Public Function Vuelos() As DataTable
        Dim result As New DataTable()
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        With dtVuelo
            .idAgencia = uceLines.Value
            .llegadaVuelo = udtInicio.Value
            .salidaVuelo = udtFin.Value
        End With
        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.GetDetalleVueloPorFecha(req)
            If res.ActionResult Then
                result = res.DsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function
End Class