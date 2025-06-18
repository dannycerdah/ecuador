Imports System.Windows.Forms.CheckedListBox
Imports SPC.Server.ProcesoService
Imports SPC.Server.VuelosService
Public Class frmHistorialProceso
    Dim Aerolinea As Guid = Guid.Empty
    Dim dtAgencias As New DataTable("dtAgencias")
    Dim lista As New List(Of Guid)
    Dim isAll As Boolean = False
    'ini jrodriguea sprint2 30/05/2025
    'se agregan nuevas variables que van hacer utilizadas en el nuevo proceso
    Public resDtVuelo As New DetalleVuelo
    Public Property myDetalleVuelo As New DetalleVuelo
    Public Property myProceso As New ProcesoItem
    Private dtParametros As DataTable
    Private dtDataCatalogoCalculo As New DataTable()
    'fin jrodriguea sprint2 30/05/2025
    'Public Sub RefreshData()
    '    'ugdDetalle.DataSource = CommonData.GetElementoCatalog()
    '    'SetDisplayedColumns()
    'End Sub

    Private Sub SetDisplayedColumns()
        ugdDetalle.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdDetalle.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolínea"
        ugdDetalle.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo Vuelo"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Header.Caption = "Fecha Inicio"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Format = "dd/MM/yyyy"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Header.Caption = "Fecha Fin"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Format = "dd/MM/yyyy"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso"
        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("piezas").Header.Caption = "Piezas"
        ugdDetalle.DisplayLayout.Bands(0).Columns("piezas").Format = "N"
        ugdDetalle.DisplayLayout.Bands(0).Columns("piezas").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").Header.Caption = "Volumen"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Clear()
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("peso"))
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("piezas"))
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("volumen"))
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdDetalle)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim dtData As New DataTable()
            Dim dtDataTarifa As New DataTable()

            Dim iva As Double
            Dim existeCatalogo As Double = False
            If validaInfo() Then
                'ini jrodriguea sprint2 30/05/2025
                'se llama nuevo metodo de consulta de reporte de facturacion
                ugdDetalle.DataSource = Nothing
                dtDataTarifa = CommonProcess.GetTarifaCarga()
                dtDataCatalogoCalculo = CommonProcess.GeCatalogoCalculoCarga()
                dtData = CommonProcess.GetReporteProduccionFacturacion(If(myProceso?.IdProceso, Guid.Empty), CheckeadosList(), udtfechaIni.Value, udtfechaFin.Value)
                iva = CommonProcess.GetParametro("IVA").Rows(0).Item("prmNumero")
                For Each rows As DataRow In dtData.Rows
                    rows("TOTAL_VOLUMEN_FACTURAR") = calculaTotalFacturar(rows)
                    For Each rowsTarias As DataRow In dtDataTarifa.Select("idAgencia = '" & rows.Item("idAgencia").ToString() & "'")
                        If rowsTarias.Item("idProducto") = rows.Item("idProducto") And rowsTarias.Item("idCompania") = rows.Item("idAgenciaCompañia") Then
                            rows.Item("Tarifa") = rowsTarias.Item("valorTarifa")
                            Exit For
                        End If
                        If rowsTarias.Item("idProducto") = rows.Item("idProducto") And rowsTarias.Item("idCompania").ToString() = Guid.Empty.ToString() Then
                            rows.Item("Tarifa") = rowsTarias.Item("valorTarifa")
                            Exit For
                        End If
                        If rowsTarias.Item("idProducto").ToString() = Guid.Empty.ToString() And rowsTarias.Item("idCompania") = rows.Item("idAgenciaCompañia") Then
                            rows.Item("Tarifa") = rowsTarias.Item("valorTarifa")
                            Exit For
                        End If
                        If rowsTarias.Item("idProducto").ToString() = Guid.Empty.ToString() And rowsTarias.Item("idCompania").ToString() = Guid.Empty.ToString() Then
                            rows.Item("Tarifa") = rowsTarias.Item("valorTarifa")
                            Exit For
                        End If
                    Next
                    rows.Item("Subtotal") = rows.Item("Tarifa") * rows.Item("TOTAL_VOLUMEN_FACTURAR")
                    rows.Item("Iva") = (rows.Item("Subtotal") + rows.Item("Fee")) * iva
                    rows.Item("Total") = rows.Item("Subtotal") + rows.Item("Iva") + rows.Item("Fee")
                Next
                ugdDetalle.DataSource = dtData
                'se comenta codigo debido a que no va hacer utilizada dicha logica
                'If isAll Then 'If uceAerolinea.SelectedIndex = 0 Or isAll Then
                '    'ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(uceAerolinea.Value, udtfechaIni.Value, udtfechaFin.Value, "T")
                '    ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha("", udtfechaIni.Value, udtfechaFin.Value, "T")
                'Else
                '    ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(CheckeadosList(), udtfechaIni.Value, udtfechaFin.Value, "F")
                '    'ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(uceAerolinea.Value, udtfechaIni.Value, udtfechaFin.Value, "F")
                'End If
                'Aerolinea = uceAerolinea.Value
                'If ugdDetalle.DataSource.rows.count < 1 Then
                '    MessageBox.Show("No se encontró ninguna información para ésta busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If
                'SetDisplayedColumns()
                'se llama nuevo metodo de setDisplayed de columnas
                SetDisplayedColumnsNew()
                'fin jrodriguea sprint2 30/05/2025
            Else
                MessageBox.Show("Verifique información a consultar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmHistorialProceso_Load(sender As Object, e As EventArgs) Handles Me.Load
        uceAerolinea.Items.Clear()
        uceAerolinea.Items.Add(Guid.Empty, "Todas las aerolíneas".ToUpper())
        CargaListoBox(True)
        For Each r As DataRow In CommonData.GetAgenciaPorTipo("04be18e6-fd0c-4466-aed2-04b0e8025772").Rows
            uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            CargaListoBox(False, r)
        Next
        CheckedListBoxAgencia.DataSource = dtAgencias
        CheckedListBoxAgencia.ValueMember = "idAgencia"
        CheckedListBoxAgencia.DisplayMember = "descripcionAgencia"
        uceAerolinea.SelectedIndex = 0
    End Sub
    Private Sub CargaListoBox(Isnew As Boolean, Optional registro As DataRow = Nothing)
        Dim row As DataRow
        row = dtAgencias.NewRow
        If Isnew Then
            With dtAgencias.Columns
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
            End With
            row.Item("idAgencia") = Guid.Empty
            row.Item("descripcionAgencia") = "Todas las aerolíneas".ToUpper()
        Else
            row.Item("idAgencia") = registro.Item("idAgencia")
            row.Item("descripcionAgencia") = registro.Item("descripcionAgencia")
        End If
        dtAgencias.Rows.Add(row)
    End Sub
    Private Function validaInfo() As Boolean
        Dim result As Boolean = False
        'jrodriguez sprint2 30/05/2025
        'se agrega validacion si determina si existe agencias selecionada no puede existir un numero de vuelo seleccionado o biseversa
        If CheckeadosList() <> "" And String.IsNullOrWhiteSpace(txtNumVuelo.Text) = False Then
            MessageBox.Show("Importancia de no asignar una agencia al seleccionar un vuelo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If udtfechaIni.Value <= udtfechaFin.Value Then
            result = True
        End If
        'jrodriguez sprint2 30/05/2025
        'se agrega validacion si determina si existe agencias selecionada no puede existir un numero de vuelo seleccionado o biseversa
        If CheckeadosList() = "" And (If(myProceso?.IdProceso, Guid.Empty) = Guid.Empty) Then
            MessageBox.Show("Seleccione una agencia o un vuelo para realizar una consulta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return result
    End Function

    Private Sub ugdDetalle_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs)
        Try
            If Not ugdDetalle.ActiveRow.Cells("codigoVuelo").Value.ToString = String.Empty Then
                Using frmDetails As New frmHistoricoProcesoDetalle
                    frmDetails.Aerolinea = ugdDetalle.ActiveRow.Cells("idAgencia").Value
                    frmDetails.vuelo = ugdDetalle.ActiveRow.Cells("codigoVuelo").Value.ToString
                    frmDetails.fechaIni = ugdDetalle.ActiveRow.Cells("fechaInicio").Value.ToString
                    frmDetails.fechaFin = ugdDetalle.ActiveRow.Cells("fechaFin").Value.ToString
                    frmDetails.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckedListBoxAgencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles CheckedListBoxAgencia.SelectedValueChanged
        'Dim check As Boolean = False
        If CheckedListBoxAgencia.Text.Contains("TODAS") Then
            Dim i As Integer
            For i = 1 To CheckedListBoxAgencia.Items.Count - 1
                CheckedListBoxAgencia.SetItemChecked(i, False)
            Next
            If CheckedListBoxAgencia.SelectedIndex = 0 And CheckedListBoxAgencia.GetItemChecked(0) Then
                For i = 1 To CheckedListBoxAgencia.Items.Count - 1
                    CheckedListBoxAgencia.SetItemChecked(i, True)
                Next
            End If
            isAll = True
        Else
            'If CheckedListBoxAgencia.GetItemChecked(CheckedListBoxAgencia.SelectedIndex) = False Then
            '    check = True
            'End If
            'CheckedListBoxAgencia.SetItemChecked(CheckedListBoxAgencia.SelectedIndex, Not CheckedListBoxAgencia.GetItemChecked(CheckedListBoxAgencia.SelectedIndex))
            isAll = False
        End If
        'jrodriguez sprint2 30/05/2025
        'se habilita controladores
        udtfechaIni.Enabled = True
        udtfechaFin.Enabled = True
        Limpiar()
    End Sub
    Public Function CheckeadosList() As String
        Dim Chequeado As String = ""
        Dim countCheck As Integer = 0
        If CheckedListBoxAgencia.CheckedItems.Count <> 0 Then
            For i As Integer = 1 To CheckedListBoxAgencia.Items.Count - 1
                If CheckedListBoxAgencia.GetItemChecked(i) Then
                    countCheck += 1
                    If countCheck > 1 Then
                        Chequeado = Chequeado + ";"
                    End If
                    'Chequeado += lista(i - 1).ToString()
                    Chequeado += CheckedListBoxAgencia.Items(i).row.ItemArray(0).ToString()
                End If
            Next
        End If
        '    If lista.Count > 0 Then
        '    For i = 1 To lista.Count
        '        If i > 1 Then
        '            Chequeado = Chequeado + ";"
        '        End If
        '        Chequeado += lista(i - 1).ToString()
        '    Next
        'End If
        Return Chequeado
    End Function
    'jrodriguez sprint2 30/05/2025
    'se agrega logica de busqueda de vuelo
    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
            Limpiar(True)
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                resDtVuelo = CommonProcess.obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                CargarVuelo(frmConsultaVuelos.Aerolinea)
                udtfechaIni.Value = myDetalleVuelo.fechaVuelo
                udtfechaFin.Value = myDetalleVuelo.fechaVuelo
                udtfechaIni.Enabled = False
                udtfechaFin.Enabled = False
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'jrodriguez sprint2 30/05/2025
    'se agrega para limpiar controladores
    Private Sub Limpiar(Optional agencia As Boolean = False)
        txtAgencia.Clear()
        txtNumVuelo.Clear()
        myProceso = Nothing
        If agencia Then
            For i = 1 To CheckedListBoxAgencia.Items.Count - 1
                CheckedListBoxAgencia.SetItemChecked(i, False)
            Next
        End If
    End Sub
    'jrodriguez sprint2 30/05/2025
    'se agrega asignacion de valores
    Private Sub CargarVuelo(ByVal Aerolinea As String)
        txtAgencia.Text = Aerolinea
        txtNumVuelo.Text = resDtVuelo.codigoVuelo
        consultaProceso()
    End Sub
    Private Sub consultaProceso()
        Dim proceso As New ProcesoItem
        Try
            With proceso
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            myProceso = proceso
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'jrodriguez sprint2 30/05/2025
    'se renombra columnas y se agrega logica de ocultar y mostrar columnas por rol
    Private Sub SetDisplayedColumnsNew()
        ugdDetalle.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdDetalle.DisplayLayout.Bands(0).Columns("idAgenciaCompañia").Hidden = True
        ugdDetalle.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugdDetalle.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolínea"
        ugdDetalle.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Codigo Vuelo"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha Vuelo"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Header.Caption = "Fecha Min. Proceso"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").Format = "dd/MM/yyyy"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Header.Caption = "Fecha Máx. Proceso"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").Format = "dd/MM/yyyy"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaFin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdDetalle.DisplayLayout.Bands(0).Columns("COMPAÑÍA").Header.Caption = "Compañia"
        ugdDetalle.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "# Guia"
        ugdDetalle.DisplayLayout.Bands(0).Columns("producto").Header.Caption = "Producto"
        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasGuia").Header.Caption = "Piezas"
        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasA").Header.Caption = "Piezas Procesada hoy"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoA").Header.Caption = "C. procesada hoy (Peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoA").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenA").Header.Caption = "C. procesada hoy (Vol.)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenA").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_PROCESADA").Header.Caption = "C. procesada hoy (a facturar)"
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_PROCESADA").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasI").Header.Caption = "Piezas Quedada"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoI").Header.Caption = "C. quedada (Peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoI").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenI").Header.Caption = "C. quedada (Vol.)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenI").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_QUEDADA_ESTE_VUELO").Header.Caption = "C. quedada (a facturar)"
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_QUEDADA_ESTE_VUELO").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasR").Header.Caption = "Piezas Q. Otros Vuelo"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoR").Header.Caption = "C. Quedada Otros Vuelos(Peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoR").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenR").Header.Caption = "C. Quedada Otros Vuelos(Vol.)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenR").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOL_NOV_CAR_QUED_OTRO_VUE_EST_VUELO").Header.Caption = "C. Quedada Otros Vuelos(a facturar)"
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOL_NOV_CAR_QUED_OTRO_VUE_EST_VUELO").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True


        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasC").Header.Caption = "Piezas Decomisadas"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoC").Header.Caption = "C. decomisada (Peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoC").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenC").Header.Caption = "C. decomisada (Vol.)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenC").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_DECOMISADA").Header.Caption = "C. decomisada (a facturar)"
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_DECOMISADA").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugdDetalle.DisplayLayout.Bands(0).Columns("piezasD").Header.Caption = "Piezas Devuelta"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoD").Header.Caption = "C. devuelta a la agencia (Peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("pesoD").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenD").Header.Caption = "C. devuelta a la agencia (Vol.)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumenD").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_DEVUELTA").Header.Caption = "C. devuelta a la agencia (a facturar)"
        'ugdDetalle.DisplayLayout.Bands(0).Columns("VOLUMEN_NOVEDAD_CARGA_DEVUELTA").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("TOTAL_VOLUMEN_FACTURAR").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Format = "N2"


        ugdDetalle.DisplayLayout.Bands(0).Columns("piezas").Header.Caption = "Piezas Total"

        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Total carga (peso)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("peso").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").Header.Caption = "Total carga (Vol.)"

        ugdDetalle.DisplayLayout.Bands(0).Columns("volumen").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Columns("TOTAL_VOLUMEN_FACTURAR").Header.Caption = "Total carga (a facturar)"
        ugdDetalle.DisplayLayout.Bands(0).Columns("TOTAL_VOLUMEN_FACTURAR").Format = "N2"
        ugdDetalle.DisplayLayout.Bands(0).Columns("TOTAL_VOLUMEN_FACTURAR").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Clear()
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("TOTAL_VOLUMEN_FACTURAR")).DisplayFormat = "{0:0.00}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal")).DisplayFormat = "{0:0.00}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Fee")).DisplayFormat = "{0:0.00}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Iva")).DisplayFormat = "{0:0.00}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Total")).DisplayFormat = "{0:0.00}"
        ugdDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        ugdDetalle.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
        ugdDetalle.DisplayLayout.Bands(0).Columns("producto").Width = 150
        dtParametros = CommonProcess.GetParametro("rol_rep_pro_fact")
        For Each r As DataRow In dtParametros.Rows
            If r.Item("estado") = "A" Then
                If MyCurrentUser.roles.Split(",").Contains(r.Item("prmTexto")) = False Then
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = True
                Else
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Tarifa").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = False
                End If
            End If
        Next
    End Sub
    Private Function calculaTotalFacturar(rows As DataRow) As Double
        Dim totalFacturar As Double = 0
        ' Buscar catálogo por idAgencia
        Dim catalogos = dtDataCatalogoCalculo.Select("idAgencia = '" & rows("idAgencia").ToString() & "'")
        If catalogos.Length > 0 Then
            For Each cat As DataRow In catalogos
                totalFacturar += ProcesarCampo(cat("procesada"), rows("pesoA"), rows("volumenA"))
                totalFacturar += ProcesarCampo(cat("quedada"), rows("pesoI"), rows("volumenI"))
                totalFacturar += ProcesarCampo(cat("decomisada"), rows("pesoC"), rows("volumenC"))
                totalFacturar += ProcesarCampo(cat("quedada_otro"), rows("pesoR"), rows("volumenR"))
                totalFacturar += ProcesarCampo(cat("devuelta"), rows("pesoD"), rows("volumenD"))
            Next
        Else
            ' Usar catálogo por defecto
            catalogos = dtDataCatalogoCalculo.Select("idAgencia = '00000000-0000-0000-0000-000000000000'")
            For Each cat As DataRow In catalogos
                totalFacturar += ProcesarCampo(cat("procesada"), rows("pesoA"), rows("volumenA"))
                totalFacturar += ProcesarCampo(cat("quedada"), rows("pesoI"), rows("volumenI"))
                totalFacturar += ProcesarCampo(cat("decomisada"), rows("pesoC"), rows("volumenC"))
                totalFacturar += ProcesarCampo(cat("quedada_otro"), rows("pesoR"), rows("volumenR"))
                totalFacturar += ProcesarCampo(cat("devuelta"), rows("pesoD"), rows("volumenD"))
            Next
        End If
        Return totalFacturar
    End Function
    ' Función auxiliar que aplica la lógica del Select Case original
    Private Function ProcesarCampo(accion As Object, peso As Object, volumen As Object) As Double
        Dim tipo As Integer = Convert.ToInt32(accion)
        Dim valor As Double = Math.Max(Convert.ToDouble(peso), Convert.ToDouble(volumen))

        Select Case tipo
            Case 1
                Return valor
            Case -1
                Return -valor
            Case Else
                Return 0
        End Select
    End Function

End Class