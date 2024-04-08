
Public Class frmConsultaProducto
    Dim Id As String = ""
    Public dtProducto As New DataTable("Producto")
    Public tempDesc As String = ""

    'Public Sub RefreshDataTipo()
    '    txtProducto.Text = ""
    '    ugdProductos.DataSource = CommonData.GetEntireProductoCatalog
    '    SetDisplayedColumnsProducto()
    '    isTipo = True
    '    txtProducto.Focus()
    'End Sub

    Public Sub RefreshDataProducto()
        txtProducto.Text = ""
        ugdProductos.DataSource = CommonData.GetEntireProductoCatalog
        SetDisplayedColumnsProducto()
        txtProducto.Focus()
    End Sub

    Private Sub cargarDtProducto()
        With dtProducto.Columns
            .Add("idProducto", GetType(String))
            .Add("tipoProducto", GetType(String))
            .Add("descripcionProducto", GetType(String))
            .Add("descripcionTipo", GetType(String))
        End With
    End Sub

    'Private Sub SetDisplayedColumnsTipo()
    '    ugdProductos.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
    '    ugdProductos.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Tipo de Producto"
    'End Sub

    Private Sub SetDisplayedColumnsProducto()
        ugdProductos.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
        ugdProductos.DisplayLayout.Bands(0).Columns("tipoProducto").Hidden = True
        ugdProductos.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
        ugdProductos.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Tipo de Producto"
    End Sub

    Private Sub ugdProductos_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugdProductos.DoubleClickRow
        'If isTipo Then
        '    RefreshDataProducto()
        '    isTipo = False
        'Else
        Dim r As DataRow
        r = dtProducto.NewRow
        r.Item("idProducto") = ugdProductos.ActiveRow.Cells("idProducto").Value
        r.Item("tipoProducto") = ugdProductos.ActiveRow.Cells("tipoProducto").Value
        r.Item("descripcionProducto") = ugdProductos.ActiveRow.Cells("descripcionProducto").Value
        r.Item("descripcionTipo") = ugdProductos.ActiveRow.Cells("descripcionTipo").Value
        dtProducto.Rows.Add(r)
        Me.Close()
        'End If
    End Sub

    Private Sub frmConsultaProducto_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshDataProducto()
        cargarDtProducto()
    End Sub

    Private Sub txtProducto_ValueChanged(sender As Object, e As EventArgs) Handles txtProducto.ValueChanged
        ''If isTipo Then
        'If txtProducto.Text.Length > 0 Then
        '    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProductos.Rows
        '        If InStr(r.Cells("descripcionTipo").Value, txtProducto.Text) Then
        '            r.Hidden = False
        '        Else
        '            r.Hidden = True
        '        End If
        '    Next
        'Else
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProductos.Rows
            r.Hidden = False
        Next
        ' End If
        'Else
        If txtProducto.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProductos.Rows
                If InStr(r.Cells("descripcionProducto").Value, txtProducto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdProductos.Rows
                r.Hidden = False
            Next
        End If
        'End If
    End Sub

    Private Sub btnRescargar_Click(sender As Object, e As EventArgs) Handles btnRescargar.Click
        RefreshDataProducto()
    End Sub
End Class