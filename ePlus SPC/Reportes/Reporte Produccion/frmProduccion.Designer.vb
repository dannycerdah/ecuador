<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccion
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProduccion))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.udtFechaInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtFechaFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdAirplane = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugdAirplane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Controls.Add(Me.btnExcelExport)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(945, 96)
        Me.ugbCamion.TabIndex = 38
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.uceAgencia)
        Me.UltraGroupBox3.Controls.Add(Me.lblAgencia)
        Me.UltraGroupBox3.Controls.Add(Me.btnBuscar)
        Me.UltraGroupBox3.Controls.Add(Me.udtFechaInicio)
        Me.UltraGroupBox3.Controls.Add(Me.udtFechaFin)
        Me.UltraGroupBox3.Controls.Add(Me.lblMatricula)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(6, 10)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(441, 80)
        Me.UltraGroupBox3.TabIndex = 50
        Me.UltraGroupBox3.Text = "Consultar Producción:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(89, 19)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(253, 21)
        Me.uceAgencia.TabIndex = 48
        '
        'lblAgencia
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance5
        Me.lblAgencia.Location = New System.Drawing.Point(6, 20)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAgencia.Size = New System.Drawing.Size(77, 21)
        Me.lblAgencia.TabIndex = 49
        Me.lblAgencia.Text = "Aerolínea:"
        '
        'btnBuscar
        '
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        Me.btnBuscar.Appearance = Appearance12
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnBuscar.Location = New System.Drawing.Point(348, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(83, 48)
        Me.btnBuscar.TabIndex = 46
        Me.btnBuscar.Text = "Consultar"
        '
        'udtFechaInicio
        '
        Me.udtFechaInicio.DateTime = New Date(2018, 12, 17, 13, 8, 21, 0)
        Me.udtFechaInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFechaInicio.Location = New System.Drawing.Point(89, 47)
        Me.udtFechaInicio.MaskInput = "dd/mm/yyyy"
        Me.udtFechaInicio.Name = "udtFechaInicio"
        Me.udtFechaInicio.Size = New System.Drawing.Size(90, 21)
        Me.udtFechaInicio.TabIndex = 40
        Me.udtFechaInicio.Value = New Date(2018, 12, 17, 13, 8, 21, 0)
        '
        'udtFechaFin
        '
        Me.udtFechaFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFechaFin.Location = New System.Drawing.Point(252, 48)
        Me.udtFechaFin.MaskInput = "dd/mm/yyyy"
        Me.udtFechaFin.Name = "udtFechaFin"
        Me.udtFechaFin.Size = New System.Drawing.Size(90, 21)
        Me.udtFechaFin.TabIndex = 41
        '
        'lblMatricula
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance11
        Me.lblMatricula.Location = New System.Drawing.Point(6, 47)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(77, 21)
        Me.lblMatricula.TabIndex = 38
        Me.lblMatricula.Text = "Fecha Inicio:"
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Location = New System.Drawing.Point(185, 48)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(61, 20)
        Me.UltraLabel1.TabIndex = 39
        Me.UltraLabel1.Text = "Fecha Fin:"
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
        Me.btnExcelExport.Location = New System.Drawing.Point(877, 58)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(62, 32)
        Me.btnExcelExport.TabIndex = 40
        Me.btnExcelExport.Text = "Excel"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ugdAirplane)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 96)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(945, 297)
        Me.UltraGroupBox1.TabIndex = 39
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdAirplane
        '
        Appearance14.BackColor = System.Drawing.Color.White
        Me.ugdAirplane.DisplayLayout.Appearance = Appearance14
        Me.ugdAirplane.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdAirplane.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdAirplane.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdAirplane.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdAirplane.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.ugdAirplane.DisplayLayout.Override.CardAreaAppearance = Appearance1
        Me.ugdAirplane.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdAirplane.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdAirplane.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAirplane.DisplayLayout.Override.RowSelectorAppearance = Appearance8
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAirplane.DisplayLayout.Override.SelectedRowAppearance = Appearance15
        Me.ugdAirplane.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Me.ugdAirplane.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdAirplane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdAirplane.Location = New System.Drawing.Point(3, 0)
        Me.ugdAirplane.Name = "ugdAirplane"
        Me.ugdAirplane.Size = New System.Drawing.Size(939, 294)
        Me.ugdAirplane.TabIndex = 5
        Me.ugdAirplane.Text = "PRODUCCIÓN SOLO PESO"
        '
        'frmProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(945, 393)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmProduccion"
        Me.Text = "Producción solo peso"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugdAirplane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtFechaFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFechaInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdAirplane As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
End Class
