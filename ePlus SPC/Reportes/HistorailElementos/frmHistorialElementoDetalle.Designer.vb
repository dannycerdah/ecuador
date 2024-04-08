<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialElementoDetalle
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdHistorial = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbAerolinea = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtElemento = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblElemento = New Infragistics.Win.Misc.UltraLabel()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugdHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAerolinea.SuspendLayout()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugbAgencia.Controls.Add(Me.ugdHistorial)
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 58)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(1147, 538)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdHistorial
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdHistorial.DisplayLayout.Appearance = Appearance1
        Me.ugdHistorial.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdHistorial.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdHistorial.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdHistorial.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdHistorial.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdHistorial.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdHistorial.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdHistorial.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdHistorial.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdHistorial.Location = New System.Drawing.Point(3, 0)
        Me.ugdHistorial.Name = "ugdHistorial"
        Me.ugdHistorial.Size = New System.Drawing.Size(1141, 535)
        Me.ugdHistorial.TabIndex = 3
        Me.ugdHistorial.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ugbAerolinea
        '
        Me.ugbAerolinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugbAerolinea.Controls.Add(Me.btnExcelExport)
        Me.ugbAerolinea.Controls.Add(Me.txtElemento)
        Me.ugbAerolinea.Controls.Add(Me.lblElemento)
        Me.ugbAerolinea.Location = New System.Drawing.Point(0, 1)
        Me.ugbAerolinea.Name = "ugbAerolinea"
        Me.ugbAerolinea.Size = New System.Drawing.Size(1147, 57)
        Me.ugbAerolinea.TabIndex = 20
        Me.ugbAerolinea.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtElemento
        '
        Me.txtElemento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtElemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtElemento.Location = New System.Drawing.Point(129, 8)
        Me.txtElemento.Name = "txtElemento"
        Me.txtElemento.ReadOnly = True
        Me.txtElemento.Size = New System.Drawing.Size(240, 41)
        Me.txtElemento.TabIndex = 51
        '
        'lblElemento
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.FontData.SizeInPoints = 15.0!
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblElemento.Appearance = Appearance9
        Me.lblElemento.Location = New System.Drawing.Point(6, 16)
        Me.lblElemento.Name = "lblElemento"
        Me.lblElemento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblElemento.Size = New System.Drawing.Size(120, 20)
        Me.lblElemento.TabIndex = 11
        Me.lblElemento.Text = "Elemento:"
        '
        'btnExcelExport
        '
        Me.btnExcelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.AlphaLevel = CType(75, Short)
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.BackColor2 = System.Drawing.Color.Green
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.ForeColor = System.Drawing.Color.Black
        Me.btnExcelExport.Appearance = Appearance6
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(1052, 11)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(89, 32)
        Me.btnExcelExport.TabIndex = 52
        Me.btnExcelExport.Text = "Exportar a Excel"
        '
        'frmHistorialElementoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 594)
        Me.Controls.Add(Me.ugbAerolinea)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmHistorialElementoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta de Vuelos"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugdHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAerolinea.ResumeLayout(False)
        Me.ugbAerolinea.PerformLayout()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugbAerolinea As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdHistorial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblElemento As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtElemento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
End Class
