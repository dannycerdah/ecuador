<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientes
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
        Me.ugbClientes = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtClientes = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ugdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbClientes.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbClientes
        '
        Me.ugbClientes.Controls.Add(Me.UltraGroupBox3)
        Me.ugbClientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbClientes.Location = New System.Drawing.Point(0, 0)
        Me.ugbClientes.Name = "ugbClientes"
        Me.ugbClientes.Size = New System.Drawing.Size(800, 68)
        Me.ugbClientes.TabIndex = 2
        Me.ugbClientes.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtClientes)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(542, 47)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Clientes:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtClientes
        '
        Me.txtClientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtClientes.Location = New System.Drawing.Point(6, 19)
        Me.txtClientes.Name = "txtClientes"
        Me.txtClientes.Size = New System.Drawing.Size(300, 21)
        Me.txtClientes.TabIndex = 1
        '
        'ugdClientes
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdClientes.DisplayLayout.Appearance = Appearance1
        Me.ugdClientes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdClientes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdClientes.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdClientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdClientes.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugdClientes.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdClientes.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdClientes.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdClientes.Location = New System.Drawing.Point(0, 68)
        Me.ugdClientes.Name = "ugdClientes"
        Me.ugdClientes.Size = New System.Drawing.Size(800, 382)
        Me.ugdClientes.TabIndex = 3
        Me.ugdClientes.Text = "CLIENTES"
        '
        'FrmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ugdClientes)
        Me.Controls.Add(Me.ugbClientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmClientes"
        Me.Text = "FrmClientes"
        CType(Me.ugbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbClientes.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbClientes As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtClientes As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ugdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
