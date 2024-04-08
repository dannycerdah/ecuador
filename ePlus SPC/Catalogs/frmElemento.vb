Public Class frmElemento
    'Public MyFrmElemento As New frmElemento

    Private MyFrmMateriales As frmMateriales
    Public Sub RefreshDataelemento()
        ugdElemento.DataSource = CommonData.GetElementoCatalog()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        ugdElemento.DisplayLayout.Bands(0).RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout
        Dim firstGroup As Infragistics.Win.UltraWinGrid.UltraGridGroup = ugdElemento.DisplayLayout.Bands(0).Groups.Add("FirstGroup", "")
        Dim SecondGroup As Infragistics.Win.UltraWinGrid.UltraGridGroup = ugdElemento.DisplayLayout.Bands(0).Groups.Add("SecondGroup", "Peso")
        Dim ThridGroup As Infragistics.Win.UltraWinGrid.UltraGridGroup = ugdElemento.DisplayLayout.Bands(0).Groups.Add("ThirdGroup", "")
        'ugdElemento.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Codigo"
        ugdElemento.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Matricula"
        ugdElemento.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea"
        ugdElemento.DisplayLayout.Bands(0).Columns("tipoElemento").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPiso").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPared").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialTecho").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialRed").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialPuerta").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("materialSeguros").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("alto").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("ancho").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("largo").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("D_Estado").Hidden = True
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReferencial").Header.Caption = "Peso Referencial"
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoActual").Header.Caption = "Peso Actual"
        ugdElemento.DisplayLayout.Bands(0).Columns("estado").Header.Caption = "Estado"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").Header.Caption = "Fecha Ingreso"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").Format = "dd/MM/yyyy"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugdElemento.DisplayLayout.Bands(0).Columns("usuarioIngreso").Header.Caption = "Usuario Ingreso"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Header.Caption = "Fecha Ultima Actualización"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Format = "dd/MM/yyyy"
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        ugdElemento.DisplayLayout.Bands(0).Columns("idElemento").RowLayoutColumnInfo.ParentGroup = firstGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("descripcionAgencia").RowLayoutColumnInfo.ParentGroup = firstGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReferencial").RowLayoutColumnInfo.ParentGroup = SecondGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoReal").RowLayoutColumnInfo.ParentGroup = SecondGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("pesoActual").RowLayoutColumnInfo.ParentGroup = SecondGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("estado").RowLayoutColumnInfo.ParentGroup = ThridGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaIngreso").RowLayoutColumnInfo.ParentGroup = ThridGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("usuarioIngreso").RowLayoutColumnInfo.ParentGroup = ThridGroup
        ugdElemento.DisplayLayout.Bands(0).Columns("fechaUltimaAct").RowLayoutColumnInfo.ParentGroup = ThridGroup

    End Sub

    Private Sub ShowElementoDetails(id As String)
        Using frmDetails As New frmElementoDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs) Handles txtElemento.ValueChanged
        If txtElemento.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdElemento.Rows
                If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdElemento.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub ugdElemento_DoubleClickCell1(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdElemento.DoubleClickCell
        If Not ugdElemento.ActiveRow.Cells("idElemento").Value.ToString = String.Empty Then
            ShowElementoDetails(ugdElemento.ActiveRow.Cells("idElemento").Value)
        Else
            Using frmDetails As New frmElementoDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdElemento)
    End Sub

    Private Sub frmElemento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbbuscar.SelectedIndex = 0 Then
            RefreshDataelemento()
            ugdElemento.Visible = True
            ugdTipoElemento.Visible = False
        ElseIf cmbbuscar.SelectedIndex = 1 Then
            RefreshData()
            ugdElemento.Visible = False
            ugdTipoElemento.Visible = True
            'ElseIf cmbbuscar.SelectedIndex = 2 Then
            '    '  SetCurrentForm(MyFrmMateriales, GetType(frmMateriales))
            '    MyFrmMateriales.RefreshData()
        End If

    End Sub

    ''''********************************************tipos de elementos ********************************************************

    Public Sub RefreshData()
        ugdTipoElemento.DataSource = CommonData.GetTipoElementoCatalog()
        SetDisplayedColumns1()
    End Sub

    Private Sub SetDisplayedColumns1()
        ' ugdTipoElemento.DisplayLayout.Bands(0).Columns("idTipo").Hidden = True
        ugdTipoElemento.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Descripción"
    End Sub

    Private Sub ugdMateriales_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdTipoElemento.DoubleClickCell
        If Not ugdTipoElemento.ActiveRow.Cells("idTipo").Value.ToString = String.Empty Then
            ShowTiposElementoDetails(ugdTipoElemento.ActiveRow.Cells("idTipo").Value)
        Else
            Using frmDetails As New frmTiposElementoDetails(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub

    Private Sub ShowTiposElementoDetails(id As Guid)
        Using frmDetails As New frmTiposElementoDetails(id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub cmbbuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbbuscar.SelectedIndexChanged

        Me.txtElemento.Visible = (cmbbuscar.SelectedIndex = 0)


    End Sub

End Class