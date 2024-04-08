<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraExplorerBarGroup2 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup()
        Dim UltraExplorerBarItem4 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem()
        Me.UltraExplorerBarContainerControl1 = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl()
        Me.txtTarifaProceso = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.uceLines = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ugdFacturas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.uebMarcaciones = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar()
        Me.UltraExplorerBarContainerControl1.SuspendLayout()
        CType(Me.txtTarifaProceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ugdFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uebMarcaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uebMarcaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraExplorerBarContainerControl1
        '
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.txtTarifaProceso)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel5)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.btnExcelExport)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.btnConsultar)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.udtFin)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.uceLines)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.udtInicio)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel4)
        Me.UltraExplorerBarContainerControl1.Location = New System.Drawing.Point(3, 25)
        Me.UltraExplorerBarContainerControl1.Name = "UltraExplorerBarContainerControl1"
        Me.UltraExplorerBarContainerControl1.Size = New System.Drawing.Size(246, 323)
        Me.UltraExplorerBarContainerControl1.TabIndex = 0
        '
        'txtTarifaProceso
        '
        Appearance6.BackColor = System.Drawing.Color.Red
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.TextHAlignAsString = "Right"
        Me.txtTarifaProceso.Appearance = Appearance6
        Me.txtTarifaProceso.BackColor = System.Drawing.Color.Red
        Me.txtTarifaProceso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTarifaProceso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtTarifaProceso.Location = New System.Drawing.Point(3, 131)
        Me.txtTarifaProceso.Name = "txtTarifaProceso"
        Me.txtTarifaProceso.Size = New System.Drawing.Size(80, 21)
        Me.txtTarifaProceso.TabIndex = 98
        Me.txtTarifaProceso.Text = "0"
        '
        'UltraLabel5
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Appearance26.TextHAlignAsString = "Left"
        Appearance26.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance26
        Me.UltraLabel5.Location = New System.Drawing.Point(3, 105)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(80, 20)
        Me.UltraLabel5.TabIndex = 59
        Me.UltraLabel5.Text = "Tarifa (CV)"
        '
        'btnExcelExport
        '
        Appearance21.AlphaLevel = CType(110, Short)
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.BackColor2 = System.Drawing.Color.Transparent
        Appearance21.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnExcelExport.Appearance = Appearance21
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.Enabled = False
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(89, 73)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(80, 26)
        Me.btnExcelExport.TabIndex = 9
        Me.btnExcelExport.Text = "Excel"
        '
        'btnConsultar
        '
        Appearance22.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnConsultar.Appearance = Appearance22
        Me.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultar.Location = New System.Drawing.Point(3, 72)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(80, 27)
        Me.btnConsultar.TabIndex = 52
        Me.btnConsultar.Text = "Consultar"
        '
        'UltraLabel2
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Left"
        Appearance23.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance23
        Me.UltraLabel2.Location = New System.Drawing.Point(135, 45)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(36, 20)
        Me.UltraLabel2.TabIndex = 50
        Me.UltraLabel2.Text = "Hasta"
        '
        'udtFin
        '
        Me.udtFin.DateTime = New Date(2017, 10, 25, 0, 0, 0, 0)
        Me.udtFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFin.FormatString = "dd/MM/yyyy"
        Me.udtFin.Location = New System.Drawing.Point(177, 45)
        Me.udtFin.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtFin.Name = "udtFin"
        Me.udtFin.Size = New System.Drawing.Size(96, 21)
        Me.udtFin.TabIndex = 51
        Me.udtFin.Value = New Date(2017, 10, 25, 0, 0, 0, 0)
        '
        'uceLines
        '
        Me.uceLines.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceLines.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceLines.LimitToList = True
        Me.uceLines.Location = New System.Drawing.Point(3, 19)
        Me.uceLines.Name = "uceLines"
        Me.uceLines.Size = New System.Drawing.Size(270, 21)
        Me.uceLines.TabIndex = 56
        '
        'udtInicio
        '
        Me.udtInicio.DateTime = New Date(2017, 10, 25, 0, 0, 0, 0)
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = "dd/MM/yyyy"
        Me.udtInicio.Location = New System.Drawing.Point(41, 45)
        Me.udtInicio.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(88, 21)
        Me.udtInicio.TabIndex = 49
        Me.udtInicio.Value = New Date(2017, 10, 25, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.TextHAlignAsString = "Left"
        Appearance25.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance25
        Me.UltraLabel1.Location = New System.Drawing.Point(3, 46)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(43, 20)
        Me.UltraLabel1.TabIndex = 48
        Me.UltraLabel1.Text = "Desde"
        '
        'UltraLabel4
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance4
        Me.UltraLabel4.Location = New System.Drawing.Point(3, 3)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(94, 10)
        Me.UltraLabel4.TabIndex = 54
        Me.UltraLabel4.Text = "Aerolínea "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ugdFacturas, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uebMarcaciones, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1170, 433)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'ugdFacturas
        '
        Appearance14.BackColor = System.Drawing.Color.White
        Me.ugdFacturas.DisplayLayout.Appearance = Appearance14
        Me.ugdFacturas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdFacturas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdFacturas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdFacturas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdFacturas.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.ugdFacturas.DisplayLayout.Override.CardAreaAppearance = Appearance1
        Me.ugdFacturas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdFacturas.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdFacturas.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdFacturas.DisplayLayout.Override.RowSelectorAppearance = Appearance8
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdFacturas.DisplayLayout.Override.SelectedRowAppearance = Appearance15
        Me.ugdFacturas.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Me.ugdFacturas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdFacturas.Location = New System.Drawing.Point(3, 3)
        Me.ugdFacturas.Name = "ugdFacturas"
        Me.ugdFacturas.Size = New System.Drawing.Size(906, 427)
        Me.ugdFacturas.TabIndex = 9
        Me.ugdFacturas.Text = "SERVICIO"
        '
        'uebMarcaciones
        '
        Me.uebMarcaciones.Controls.Add(Me.UltraExplorerBarContainerControl1)
        Me.uebMarcaciones.Dock = System.Windows.Forms.DockStyle.Fill
        UltraExplorerBarGroup2.Container = Me.UltraExplorerBarContainerControl1
        UltraExplorerBarItem4.Text = "New Item"
        UltraExplorerBarGroup2.Items.AddRange(New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem() {UltraExplorerBarItem4})
        UltraExplorerBarGroup2.Settings.ContainerHeight = 323
        UltraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer
        UltraExplorerBarGroup2.Text = "Consultar"
        Me.uebMarcaciones.Groups.AddRange(New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup() {UltraExplorerBarGroup2})
        Me.uebMarcaciones.Location = New System.Drawing.Point(915, 3)
        Me.uebMarcaciones.Name = "uebMarcaciones"
        Me.uebMarcaciones.Size = New System.Drawing.Size(252, 427)
        Me.uebMarcaciones.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox
        Me.uebMarcaciones.TabIndex = 8
        Me.uebMarcaciones.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2007
        '
        'frmFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1170, 433)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFactura"
        Me.Text = "frmFactura"
        Me.UltraExplorerBarContainerControl1.ResumeLayout(False)
        Me.UltraExplorerBarContainerControl1.PerformLayout()
        CType(Me.txtTarifaProceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ugdFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uebMarcaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uebMarcaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents uebMarcaciones As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar
    Friend WithEvents UltraExplorerBarContainerControl1 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uceLines As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtTarifaProceso As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ugdFacturas As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
