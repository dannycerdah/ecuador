<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPreElemento
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPreElemento))
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdPreElemen = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbAerolinea = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        Me.udtHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.lblHasta = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugdPreElemen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAerolinea.SuspendLayout()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.ugdPreElemen)
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 58)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(1006, 416)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdPreElemen
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdPreElemen.DisplayLayout.Appearance = Appearance1
        Me.ugdPreElemen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdPreElemen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdPreElemen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdPreElemen.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdPreElemen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdPreElemen.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdPreElemen.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPreElemen.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPreElemen.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugdPreElemen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdPreElemen.Location = New System.Drawing.Point(3, 0)
        Me.ugdPreElemen.Name = "ugdPreElemen"
        Me.ugdPreElemen.Size = New System.Drawing.Size(1000, 413)
        Me.ugdPreElemen.TabIndex = 3
        Me.ugdPreElemen.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ugbAerolinea
        '
        Me.ugbAerolinea.Controls.Add(Me.btnConsultar)
        Me.ugbAerolinea.Controls.Add(Me.udtHasta)
        Me.ugbAerolinea.Controls.Add(Me.udtDesde)
        Me.ugbAerolinea.Controls.Add(Me.lblAerolinea)
        Me.ugbAerolinea.Controls.Add(Me.uceAerolinea)
        Me.ugbAerolinea.Controls.Add(Me.lblDesde)
        Me.ugbAerolinea.Controls.Add(Me.lblHasta)
        Me.ugbAerolinea.Location = New System.Drawing.Point(0, 1)
        Me.ugbAerolinea.Name = "ugbAerolinea"
        Me.ugbAerolinea.Size = New System.Drawing.Size(1006, 57)
        Me.ugbAerolinea.TabIndex = 20
        Me.ugbAerolinea.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnConsultar
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnConsultar.Appearance = Appearance5
        Me.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultar.Location = New System.Drawing.Point(691, 13)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 27)
        Me.btnConsultar.TabIndex = 22
        '
        'udtHasta
        '
        Me.udtHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtHasta.Location = New System.Drawing.Point(566, 17)
        Me.udtHasta.MaskInput = "dd/mm/yyyy"
        Me.udtHasta.Name = "udtHasta"
        Me.udtHasta.Size = New System.Drawing.Size(114, 21)
        Me.udtHasta.TabIndex = 21
        '
        'udtDesde
        '
        Me.udtDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtDesde.Location = New System.Drawing.Point(403, 17)
        Me.udtDesde.MaskInput = "dd/mm/yyyy"
        Me.udtDesde.Name = "udtDesde"
        Me.udtDesde.Size = New System.Drawing.Size(114, 21)
        Me.udtDesde.TabIndex = 20
        '
        'lblAerolinea
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance9
        Me.lblAerolinea.Location = New System.Drawing.Point(6, 16)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAerolinea.Size = New System.Drawing.Size(60, 20)
        Me.lblAerolinea.TabIndex = 11
        Me.lblAerolinea.Text = "Aerolinea:"
        '
        'uceAerolinea
        '
        Me.uceAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAerolinea.LimitToList = True
        Me.uceAerolinea.Location = New System.Drawing.Point(81, 16)
        Me.uceAerolinea.Name = "uceAerolinea"
        Me.uceAerolinea.Size = New System.Drawing.Size(251, 21)
        Me.uceAerolinea.TabIndex = 0
        '
        'lblDesde
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance11
        Me.lblDesde.Location = New System.Drawing.Point(337, 17)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(60, 20)
        Me.lblDesde.TabIndex = 12
        Me.lblDesde.Text = "Desde:"
        '
        'lblHasta
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblHasta.Appearance = Appearance7
        Me.lblHasta.Location = New System.Drawing.Point(512, 17)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHasta.Size = New System.Drawing.Size(52, 20)
        Me.lblHasta.TabIndex = 17
        Me.lblHasta.Text = "Hasta:"
        '
        'frmConsultaPreElemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 473)
        Me.Controls.Add(Me.ugbAerolinea)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaPreElemento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de Vuelos"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugdPreElemen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAerolinea.ResumeLayout(False)
        Me.ugbAerolinea.PerformLayout()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblHasta As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ugbAerolinea As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ugdPreElemen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
End Class
