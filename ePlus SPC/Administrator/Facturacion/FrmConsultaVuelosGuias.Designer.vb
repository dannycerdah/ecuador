<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultaVuelosGuias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaVuelosGuias))
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAerolinea = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtAreroLinea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        Me.udtHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.lblHasta = New Infragistics.Win.Misc.UltraLabel()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdVuelos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtVueloGuia = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAerolinea.SuspendLayout()
        CType(Me.txtAreroLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugdVuelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVueloGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAerolinea
        '
        Me.ugbAerolinea.Controls.Add(Me.UltraLabel1)
        Me.ugbAerolinea.Controls.Add(Me.txtVueloGuia)
        Me.ugbAerolinea.Controls.Add(Me.txtAreroLinea)
        Me.ugbAerolinea.Controls.Add(Me.btnConsultar)
        Me.ugbAerolinea.Controls.Add(Me.udtHasta)
        Me.ugbAerolinea.Controls.Add(Me.udtDesde)
        Me.ugbAerolinea.Controls.Add(Me.lblAerolinea)
        Me.ugbAerolinea.Controls.Add(Me.lblDesde)
        Me.ugbAerolinea.Controls.Add(Me.lblHasta)
        Me.ugbAerolinea.Location = New System.Drawing.Point(-2, -1)
        Me.ugbAerolinea.Name = "ugbAerolinea"
        Me.ugbAerolinea.Size = New System.Drawing.Size(1006, 82)
        Me.ugbAerolinea.TabIndex = 21
        Me.ugbAerolinea.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtAreroLinea
        '
        Me.txtAreroLinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAreroLinea.Location = New System.Drawing.Point(83, 15)
        Me.txtAreroLinea.Name = "txtAreroLinea"
        Me.txtAreroLinea.Size = New System.Drawing.Size(274, 21)
        Me.txtAreroLinea.TabIndex = 23
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
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance8
        Me.lblAerolinea.Location = New System.Drawing.Point(6, 16)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAerolinea.Size = New System.Drawing.Size(60, 20)
        Me.lblAerolinea.TabIndex = 11
        Me.lblAerolinea.Text = "Aerolinea:"
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
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.ugdVuelos)
        Me.ugbAgencia.Location = New System.Drawing.Point(-4, 81)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(1006, 342)
        Me.ugbAgencia.TabIndex = 22
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdVuelos
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdVuelos.DisplayLayout.Appearance = Appearance1
        Me.ugdVuelos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdVuelos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdVuelos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdVuelos.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdVuelos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdVuelos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdVuelos.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdVuelos.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdVuelos.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugdVuelos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdVuelos.Location = New System.Drawing.Point(3, 0)
        Me.ugdVuelos.Name = "ugdVuelos"
        Me.ugdVuelos.Size = New System.Drawing.Size(1000, 339)
        Me.ugdVuelos.TabIndex = 3
        Me.ugdVuelos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'txtVueloGuia
        '
        Me.txtVueloGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVueloGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtVueloGuia.Location = New System.Drawing.Point(83, 55)
        Me.txtVueloGuia.Name = "txtVueloGuia"
        Me.txtVueloGuia.Size = New System.Drawing.Size(274, 21)
        Me.txtVueloGuia.TabIndex = 24
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 56)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(71, 20)
        Me.UltraLabel1.TabIndex = 25
        Me.UltraLabel1.Text = "Vuelo/Guia:"
        '
        'FrmConsultaVuelosGuias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 450)
        Me.Controls.Add(Me.ugbAgencia)
        Me.Controls.Add(Me.ugbAerolinea)
        Me.Name = "FrmConsultaVuelosGuias"
        Me.Text = "FrmConsultaVuelosGuias"
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAerolinea.ResumeLayout(False)
        Me.ugbAerolinea.PerformLayout()
        CType(Me.txtAreroLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugdVuelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVueloGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbAerolinea As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents udtHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblHasta As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdVuelos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtAreroLinea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtVueloGuia As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
