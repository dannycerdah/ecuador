Imports System.Windows.Forms.CheckedListBox
Imports SPC.Server.ProcesoService
Imports SPC.Server.VuelosService
Public Class frmReporteContenedores
    Dim dtAgencias As New DataTable("dtAgencias")
    Dim isAll As Boolean = False
    Private dtParametros As DataTable
    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdDetalle)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim dtData As New DataTable()
            Dim iva As Double
            If validaInfo() Then
                ugdDetalle.DataSource = Nothing
                dtData = CommonProcess.GetReporteContenedoresFacturacion(CheckeadosList(), udtfechaIni.Value, udtfechaFin.Value)
                iva = CommonProcess.GetParametro("IVA").Rows(0).Item("prmNumero")
                For Each rows As DataRow In dtData.Rows
                    If rows.Item("totalContenedores") > rows.Item("cantidadPermitida") Then
                        rows.Item("TotalContenedoresCobrar") = rows.Item("totalContenedores") - rows.Item("cantidadPermitida")
                    Else
                        rows.Item("TotalContenedoresCobrar") = 0
                    End If
                    rows.Item("Subtotal") = rows.Item("valorTarifa") * rows.Item("TotalContenedoresCobrar")
                    rows.Item("Iva") = (rows.Item("Subtotal") + rows.Item("Fee")) * iva
                    rows.Item("Total") = rows.Item("Subtotal") + rows.Item("Iva") + rows.Item("Fee")
                Next
                ugdDetalle.DataSource = dtData
                SetDisplayedColumnsNew()
            Else
                MessageBox.Show("Verifique información a consultar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReporteContenedores_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargaListoBox(True)
        For Each r As DataRow In CommonData.GetAgenciaPorTipo("04be18e6-fd0c-4466-aed2-04b0e8025772").Rows
            CargaListoBox(False, r)
        Next
        CheckedListBoxAgencia.DataSource = dtAgencias
        CheckedListBoxAgencia.ValueMember = "idAgencia"
        CheckedListBoxAgencia.DisplayMember = "descripcionAgencia"
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
        If CheckeadosList() = "" Then
            MessageBox.Show("Seleccione una agencia para realizar una consulta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return result
    End Function
    Private Sub CheckedListBoxAgencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles CheckedListBoxAgencia.SelectedValueChanged
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
            isAll = False
        End If
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
                    Chequeado += CheckedListBoxAgencia.Items(i).row.ItemArray(0).ToString()
                End If
            Next
        End If
        Return Chequeado
    End Function
    Private Sub Limpiar(Optional agencia As Boolean = False)
        If agencia Then
            For i = 1 To CheckedListBoxAgencia.Items.Count - 1
                CheckedListBoxAgencia.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub SetDisplayedColumnsNew()
        ugdDetalle.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdDetalle.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolínea"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaPesaje").Header.Caption = "Fecha Pesaje"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaPesaje").Format = "dd/MM/yyyy HH:mm:ss"
        ugdDetalle.DisplayLayout.Bands(0).Columns("fechaPesaje").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdDetalle.DisplayLayout.Bands(0).Columns("cantidadPermitida").Header.Caption = "Cantidad de contenedores por contrato"
        ugdDetalle.DisplayLayout.Bands(0).Columns("totalContenedores").Header.Caption = "Total Piezas o Contenedores"
        ugdDetalle.DisplayLayout.Bands(0).Columns("TotalContenedoresCobrar").Header.Caption = "Total contenedores a  Cobrar"
        ugdDetalle.DisplayLayout.Bands(0).Columns("valorTarifa").Header.Caption = "Tarifa x Unidad Contenedor"
        ugdDetalle.DisplayLayout.Bands(0).Columns("cantidadPermitida").AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True


        ugdDetalle.DisplayLayout.Bands(0).Columns("cantidadPermitida").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("totalContenedores").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("TotalContenedoresCobrar").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Format = "0.000"
        ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Format = "0.000"

        ugdDetalle.DisplayLayout.Bands(0).Summaries.Clear()
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("totalContenedores")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("TotalContenedoresCobrar")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Fee")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Iva")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdDetalle.DisplayLayout.Bands(0).Columns("Total")).DisplayFormat = "{0:0.000}"
        ugdDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        ugdDetalle.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
        dtParametros = CommonProcess.GetParametro("rol_rep_pro_fact")
        For Each r As DataRow In dtParametros.Rows
            If r.Item("estado") = "A" Then
                If If(MyCurrentUser?.roles, "").Split(",").Contains(r.Item("prmTexto")) = False Then
                    ugdDetalle.DisplayLayout.Bands(0).Columns("valorTarifa").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Hidden = True
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = True
                Else
                    ugdDetalle.DisplayLayout.Bands(0).Columns("valorTarifa").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Subtotal").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Fee").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Iva").Hidden = False
                    ugdDetalle.DisplayLayout.Bands(0).Columns("Total").Hidden = False
                End If
            End If
        Next
    End Sub
End Class