Imports System.Windows.Forms.CheckedListBox
Imports SPC.Server.VuelosService
Public Class frmHistorialProceso
    Dim Aerolinea As Guid = Guid.Empty
    Dim dtAgencias As New DataTable("dtAgencias")
    Dim lista As New List(Of Guid)
    Dim isAll As Boolean = False
    Public Sub RefreshData()
        'ugdDetalle.DataSource = CommonData.GetElementoCatalog()
        'SetDisplayedColumns()
    End Sub

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
            If validaInfo() Then
                If isAll Then 'If uceAerolinea.SelectedIndex = 0 Or isAll Then
                    'ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(uceAerolinea.Value, udtfechaIni.Value, udtfechaFin.Value, "T")
                    ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha("", udtfechaIni.Value, udtfechaFin.Value, "T")
                Else
                    ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(CheckeadosList(), udtfechaIni.Value, udtfechaFin.Value, "F")
                    'ugdDetalle.DataSource = CommonProcess.GetInfoProcesoPorIdAgenciaYFecha(uceAerolinea.Value, udtfechaIni.Value, udtfechaFin.Value, "F")
                End If
                Aerolinea = uceAerolinea.Value
                If ugdDetalle.DataSource.rows.count < 1 Then
                    MessageBox.Show("No se encontró ninguna información para ésta busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                SetDisplayedColumns()
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
        If udtfechaIni.Value <= udtfechaFin.Value Then
            result = True
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
End Class