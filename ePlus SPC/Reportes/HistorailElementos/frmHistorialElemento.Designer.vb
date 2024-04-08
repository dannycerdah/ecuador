<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialElemento
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.ugdElemento = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltCheckFecha = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltBtnBuscarHistorico = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.lblHasta = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.txtElemento = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugdElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltCheckFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.btnExcelExport)
        Me.UltraGroupBox1.Controls.Add(Me.ugdElemento)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 136)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(737, 449)
        Me.UltraGroupBox1.TabIndex = 8
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnExcelExport
        '
        Me.btnExcelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.AlphaLevel = CType(110, Short)
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.BackColor2 = System.Drawing.Color.Transparent
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnExcelExport.Appearance = Appearance6
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(644, 22)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(89, 34)
        Me.btnExcelExport.TabIndex = 8
        Me.btnExcelExport.Text = "Exportar a Excel"
        '
        'ugdElemento
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Me.ugdElemento.DisplayLayout.Appearance = Appearance2
        Me.ugdElemento.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdElemento.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdElemento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.ugdElemento.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Me.ugdElemento.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdElemento.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdElemento.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdElemento.DisplayLayout.Override.RowSelectorAppearance = Appearance1
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdElemento.DisplayLayout.Override.SelectedRowAppearance = Appearance10
        Me.ugdElemento.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdElemento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdElemento.Location = New System.Drawing.Point(3, 0)
        Me.ugdElemento.Name = "ugdElemento"
        Me.ugdElemento.Size = New System.Drawing.Size(731, 446)
        Me.ugdElemento.TabIndex = 3
        Me.ugdElemento.Text = "ELEMENTOS"
        '
        'ugbCamion
        '
        Me.ugbCamion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Location = New System.Drawing.Point(3, 1)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(734, 138)
        Me.ugbCamion.TabIndex = 9
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltCheckFecha)
        Me.UltraGroupBox3.Controls.Add(Me.UltBtnBuscarHistorico)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.udtHasta)
        Me.UltraGroupBox3.Controls.Add(Me.udtDesde)
        Me.UltraGroupBox3.Controls.Add(Me.lblDesde)
        Me.UltraGroupBox3.Controls.Add(Me.lblHasta)
        Me.UltraGroupBox3.Controls.Add(Me.lblAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.uceAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.txtElemento)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 13)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(614, 116)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Elemento:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltCheckFecha
        '
        Me.UltCheckFecha.BackColor = System.Drawing.Color.Transparent
        Me.UltCheckFecha.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltCheckFecha.Location = New System.Drawing.Point(338, 83)
        Me.UltCheckFecha.Name = "UltCheckFecha"
        Me.UltCheckFecha.Size = New System.Drawing.Size(120, 20)
        Me.UltCheckFecha.TabIndex = 28
        Me.UltCheckFecha.Text = "Filtro por Fecha"
        '
        'UltBtnBuscarHistorico
        '
        Me.UltBtnBuscarHistorico.Location = New System.Drawing.Point(497, 80)
        Me.UltBtnBuscarHistorico.Name = "UltBtnBuscarHistorico"
        Me.UltBtnBuscarHistorico.Size = New System.Drawing.Size(109, 27)
        Me.UltBtnBuscarHistorico.TabIndex = 27
        Me.UltBtnBuscarHistorico.Text = "Buscar Historico"
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 26)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(60, 24)
        Me.UltraLabel1.TabIndex = 26
        Me.UltraLabel1.Text = "Numero Elemento:"
        '
        'udtHasta
        '
        Me.udtHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtHasta.Location = New System.Drawing.Point(222, 80)
        Me.udtHasta.MaskInput = "dd/mm/yyyy"
        Me.udtHasta.Name = "udtHasta"
        Me.udtHasta.Size = New System.Drawing.Size(98, 21)
        Me.udtHasta.TabIndex = 25
        '
        'udtDesde
        '
        Me.udtDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtDesde.Location = New System.Drawing.Point(69, 80)
        Me.udtDesde.MaskInput = "dd/mm/yyyy"
        Me.udtDesde.Name = "udtDesde"
        Me.udtDesde.Size = New System.Drawing.Size(98, 21)
        Me.udtDesde.TabIndex = 24
        '
        'lblDesde
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Left"
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance11
        Me.lblDesde.Location = New System.Drawing.Point(6, 83)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(60, 20)
        Me.lblDesde.TabIndex = 22
        Me.lblDesde.Text = "Desde:"
        '
        'lblHasta
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblHasta.Appearance = Appearance7
        Me.lblHasta.Location = New System.Drawing.Point(162, 82)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHasta.Size = New System.Drawing.Size(52, 20)
        Me.lblHasta.TabIndex = 23
        Me.lblHasta.Text = "Hasta:"
        '
        'lblAerolinea
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance4
        Me.lblAerolinea.Location = New System.Drawing.Point(6, 55)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAerolinea.Size = New System.Drawing.Size(60, 20)
        Me.lblAerolinea.TabIndex = 13
        Me.lblAerolinea.Text = "Aerolinea:"
        '
        'uceAerolinea
        '
        Me.uceAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAerolinea.LimitToList = True
        Me.uceAerolinea.Location = New System.Drawing.Point(69, 53)
        Me.uceAerolinea.Name = "uceAerolinea"
        Me.uceAerolinea.Size = New System.Drawing.Size(251, 21)
        Me.uceAerolinea.TabIndex = 12
        '
        'txtElemento
        '
        Me.txtElemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtElemento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtElemento.Location = New System.Drawing.Point(69, 26)
        Me.txtElemento.Name = "txtElemento"
        Me.txtElemento.Size = New System.Drawing.Size(537, 21)
        Me.txtElemento.TabIndex = 1
        '
        'frmHistorialElemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 584)
        Me.Controls.Add(Me.ugbCamion)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHistorialElemento"
        Me.Text = "Viones"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugdElemento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.UltCheckFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdElemento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtElemento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltBtnBuscarHistorico As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblHasta As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltCheckFecha As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
