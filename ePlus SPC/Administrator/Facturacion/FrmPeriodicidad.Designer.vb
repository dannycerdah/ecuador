<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeriodicidad
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbPeriodicidad = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtPeriodicidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ugdPeriodicidad = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbPeriodicidad.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugdPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbPeriodicidad
        '
        Me.ugbPeriodicidad.Controls.Add(Me.UltraGroupBox3)
        Me.ugbPeriodicidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbPeriodicidad.Location = New System.Drawing.Point(0, 0)
        Me.ugbPeriodicidad.Name = "ugbPeriodicidad"
        Me.ugbPeriodicidad.Size = New System.Drawing.Size(800, 68)
        Me.ugbPeriodicidad.TabIndex = 4
        Me.ugbPeriodicidad.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtPeriodicidad)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(542, 47)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Periodicidad:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtPeriodicidad
        '
        Me.txtPeriodicidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeriodicidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPeriodicidad.Location = New System.Drawing.Point(6, 19)
        Me.txtPeriodicidad.Name = "txtPeriodicidad"
        Me.txtPeriodicidad.Size = New System.Drawing.Size(300, 21)
        Me.txtPeriodicidad.TabIndex = 1
        '
        'ugdPeriodicidad
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdPeriodicidad.DisplayLayout.Appearance = Appearance1
        Me.ugdPeriodicidad.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdPeriodicidad.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdPeriodicidad.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdPeriodicidad.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdPeriodicidad.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdPeriodicidad.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdPeriodicidad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugdPeriodicidad.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPeriodicidad.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPeriodicidad.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdPeriodicidad.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdPeriodicidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdPeriodicidad.Location = New System.Drawing.Point(0, 68)
        Me.ugdPeriodicidad.Name = "ugdPeriodicidad"
        Me.ugdPeriodicidad.Size = New System.Drawing.Size(800, 382)
        Me.ugdPeriodicidad.TabIndex = 5
        Me.ugdPeriodicidad.Text = "PERIODICIDAD"
        '
        'FrmPeriodicidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ugdPeriodicidad)
        Me.Controls.Add(Me.ugbPeriodicidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPeriodicidad"
        Me.Text = "FrmPeriodicidad"
        CType(Me.ugbPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbPeriodicidad.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugdPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbPeriodicidad As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtPeriodicidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ugdPeriodicidad As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
