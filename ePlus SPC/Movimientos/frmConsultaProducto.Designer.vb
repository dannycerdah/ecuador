<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaProducto
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
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaProducto))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbProducto = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnRescargar = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtProducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ugdProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbProducto.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbProducto
        '
        Me.ugbProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugbProducto.Controls.Add(Me.btnRescargar)
        Me.ugbProducto.Controls.Add(Me.UltraGroupBox3)
        Me.ugbProducto.Location = New System.Drawing.Point(0, 0)
        Me.ugbProducto.Name = "ugbProducto"
        Me.ugbProducto.Size = New System.Drawing.Size(737, 68)
        Me.ugbProducto.TabIndex = 7
        Me.ugbProducto.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnRescargar
        '
        Appearance21.Image = CType(resources.GetObject("Appearance21.Image"), Object)
        Me.btnRescargar.Appearance = Appearance21
        Me.btnRescargar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnRescargar.Location = New System.Drawing.Point(695, 23)
        Me.btnRescargar.Name = "btnRescargar"
        Me.btnRescargar.Size = New System.Drawing.Size(30, 27)
        Me.btnRescargar.TabIndex = 37
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtProducto)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 13)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(665, 47)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Producto:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtProducto
        '
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtProducto.Location = New System.Drawing.Point(97, 16)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(537, 21)
        Me.txtProducto.TabIndex = 1
        '
        'ugdProductos
        '
        Me.ugdProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdProductos.DisplayLayout.Appearance = Appearance1
        Me.ugdProductos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdProductos.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdProductos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdProductos.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdProductos.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdProductos.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugdProductos.Location = New System.Drawing.Point(0, 66)
        Me.ugdProductos.Name = "ugdProductos"
        Me.ugdProductos.Size = New System.Drawing.Size(737, 408)
        Me.ugdProductos.TabIndex = 8
        Me.ugdProductos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmConsultaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 476)
        Me.Controls.Add(Me.ugdProductos)
        Me.Controls.Add(Me.ugbProducto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta Producto"
        CType(Me.ugbProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbProducto.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbProducto As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtProducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnRescargar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugdProductos As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
