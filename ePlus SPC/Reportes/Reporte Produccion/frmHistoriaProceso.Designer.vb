<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialProceso
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialProceso))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.uceAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtfechaFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtfechaIni = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CheckedListBoxAgencia = New System.Windows.Forms.CheckedListBox()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtfechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtfechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.btnExcelExport)
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(874, 133)
        Me.ugbCamion.TabIndex = 9
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
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
        Me.btnExcelExport.Location = New System.Drawing.Point(759, 57)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(109, 32)
        Me.btnExcelExport.TabIndex = 8
        Me.btnExcelExport.Text = "Exportar a Excel"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.CheckedListBoxAgencia)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.btnBuscar)
        Me.UltraGroupBox3.Controls.Add(Me.uceAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.udtfechaFin)
        Me.UltraGroupBox3.Controls.Add(Me.lblAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.udtfechaIni)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(6, 3)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(683, 130)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel2
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.Location = New System.Drawing.Point(253, 73)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel2.TabIndex = 37
        Me.UltraLabel2.Text = "Fecha Fin:"
        '
        'btnBuscar
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnBuscar.Appearance = Appearance5
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnBuscar.Location = New System.Drawing.Point(519, 45)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 48)
        Me.btnBuscar.TabIndex = 45
        Me.btnBuscar.Text = "Consultar"
        '
        'uceAerolinea
        '
        Me.uceAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAerolinea.LimitToList = True
        Me.uceAerolinea.Location = New System.Drawing.Point(396, 18)
        Me.uceAerolinea.Name = "uceAerolinea"
        Me.uceAerolinea.Size = New System.Drawing.Size(272, 21)
        Me.uceAerolinea.TabIndex = 16
        Me.uceAerolinea.Visible = False
        '
        'udtfechaFin
        '
        Me.udtfechaFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtfechaFin.FormatString = "dd/MM/yyyy"
        Me.udtfechaFin.Location = New System.Drawing.Point(336, 72)
        Me.udtfechaFin.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtfechaFin.Name = "udtfechaFin"
        Me.udtfechaFin.Size = New System.Drawing.Size(177, 21)
        Me.udtfechaFin.TabIndex = 38
        '
        'lblAerolinea
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Left"
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance11
        Me.lblAerolinea.Location = New System.Drawing.Point(6, 18)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.Size = New System.Drawing.Size(65, 20)
        Me.lblAerolinea.TabIndex = 17
        Me.lblAerolinea.Text = "Aerolíneas:"
        '
        'UltraLabel1
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance12
        Me.UltraLabel1.Location = New System.Drawing.Point(253, 47)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel1.TabIndex = 35
        Me.UltraLabel1.Text = "Fecha Inicio:"
        '
        'udtfechaIni
        '
        Me.udtfechaIni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtfechaIni.FormatString = "dd/MM/yyyy"
        Me.udtfechaIni.Location = New System.Drawing.Point(336, 45)
        Me.udtfechaIni.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtfechaIni.Name = "udtfechaIni"
        Me.udtfechaIni.Size = New System.Drawing.Size(177, 21)
        Me.udtfechaIni.TabIndex = 36
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.ugdDetalle)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 133)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(874, 301)
        Me.UltraGroupBox2.TabIndex = 24
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdDetalle
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdDetalle.DisplayLayout.Appearance = Appearance1
        Me.ugdDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.ugdDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Me.ugdDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdDetalle.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdDetalle.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalle.DisplayLayout.Override.RowSelectorAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalle.DisplayLayout.Override.SelectedRowAppearance = Appearance10
        Me.ugdDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Me.ugdDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdDetalle.Location = New System.Drawing.Point(3, 0)
        Me.ugdDetalle.Name = "ugdDetalle"
        Me.ugdDetalle.Size = New System.Drawing.Size(868, 298)
        Me.ugdDetalle.TabIndex = 4
        Me.ugdDetalle.Text = "PRODUCCIÓN"
        '
        'CheckedListBoxAgencia
        '
        Me.CheckedListBoxAgencia.CheckOnClick = True
        Me.CheckedListBoxAgencia.FormattingEnabled = True
        Me.CheckedListBoxAgencia.Location = New System.Drawing.Point(70, 19)
        Me.CheckedListBoxAgencia.Name = "CheckedListBoxAgencia"
        Me.CheckedListBoxAgencia.ScrollAlwaysVisible = True
        Me.CheckedListBoxAgencia.Size = New System.Drawing.Size(192, 109)
        Me.CheckedListBoxAgencia.TabIndex = 24
        '
        'frmHistorialProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 434)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHistorialProceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Producción"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtfechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtfechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents udtfechaFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtfechaIni As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents CheckedListBoxAgencia As CheckedListBox
End Class
