<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatrizSeguridadDetails
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMatrizSeguridadDetails))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDetalleMatriz = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnAgregar = New Infragistics.Win.Misc.UltraButton()
        Me.txtCantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCargo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceTipoAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDescription = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdDetalleMatriz = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbDetalleMatriz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDetalleMatriz.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTipoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugdDetalleMatriz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugbDetalleMatriz
        '
        Me.ugbDetalleMatriz.Controls.Add(Me.btnAgregar)
        Me.ugbDetalleMatriz.Controls.Add(Me.txtCantidad)
        Me.ugbDetalleMatriz.Controls.Add(Me.UltraLabel2)
        Me.ugbDetalleMatriz.Controls.Add(Me.txtCargo)
        Me.ugbDetalleMatriz.Controls.Add(Me.UltraLabel1)
        Me.ugbDetalleMatriz.Controls.Add(Me.uceTipoAgencia)
        Me.ugbDetalleMatriz.Controls.Add(Me.lblAgencia)
        Me.ugbDetalleMatriz.Controls.Add(Me.txtDescription)
        Me.ugbDetalleMatriz.Controls.Add(Me.lblDescription)
        Me.ugbDetalleMatriz.Location = New System.Drawing.Point(0, 1)
        Me.ugbDetalleMatriz.Name = "ugbDetalleMatriz"
        Me.ugbDetalleMatriz.Size = New System.Drawing.Size(817, 174)
        Me.ugbDetalleMatriz.TabIndex = 19
        Me.ugbDetalleMatriz.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnAgregar
        '
        Appearance19.Image = CType(resources.GetObject("Appearance19.Image"), Object)
        Me.btnAgregar.Appearance = Appearance19
        Me.btnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnAgregar.Location = New System.Drawing.Point(361, 136)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(72, 25)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.Text = "Agregar"
        '
        'txtCantidad
        '
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCantidad.Location = New System.Drawing.Point(141, 137)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(198, 21)
        Me.txtCantidad.TabIndex = 98
        '
        'UltraLabel2
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(34, 137)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(101, 14)
        Me.UltraLabel2.TabIndex = 99
        Me.UltraLabel2.Text = "Cantidad Personal:"
        '
        'txtCargo
        '
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCargo.Location = New System.Drawing.Point(141, 110)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(198, 21)
        Me.txtCargo.TabIndex = 96
        '
        'UltraLabel1
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance16
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(49, 110)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(86, 14)
        Me.UltraLabel1.TabIndex = 97
        Me.UltraLabel1.Text = "Cargo Personal:"
        '
        'uceTipoAgencia
        '
        Me.uceTipoAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipoAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipoAgencia.LimitToList = True
        Me.uceTipoAgencia.Location = New System.Drawing.Point(141, 83)
        Me.uceTipoAgencia.Name = "uceTipoAgencia"
        Me.uceTipoAgencia.Size = New System.Drawing.Size(198, 21)
        Me.uceTipoAgencia.TabIndex = 94
        '
        'lblAgencia
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance10
        Me.lblAgencia.AutoSize = True
        Me.lblAgencia.Location = New System.Drawing.Point(62, 83)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(73, 14)
        Me.lblAgencia.TabIndex = 95
        Me.lblAgencia.Text = "Tipo Agencia:"
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescription.Location = New System.Drawing.Point(254, 11)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(387, 21)
        Me.txtDescription.TabIndex = 86
        '
        'lblDescription
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Appearance = Appearance15
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(181, 11)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(67, 14)
        Me.lblDescription.TabIndex = 93
        Me.lblDescription.Text = "Descripcion:"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ugdDetalleMatriz)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 174)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(817, 217)
        Me.UltraGroupBox1.TabIndex = 20
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdDetalleMatriz
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdDetalleMatriz.DisplayLayout.Appearance = Appearance1
        Me.ugdDetalleMatriz.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdDetalleMatriz.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdDetalleMatriz.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdDetalleMatriz.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdDetalleMatriz.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdDetalleMatriz.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalleMatriz.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalleMatriz.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdDetalleMatriz.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdDetalleMatriz.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdDetalleMatriz.Location = New System.Drawing.Point(3, 0)
        Me.ugdDetalleMatriz.Name = "ugdDetalleMatriz"
        Me.ugdDetalleMatriz.Size = New System.Drawing.Size(811, 214)
        Me.ugdDetalleMatriz.TabIndex = 3
        Me.ugdDetalleMatriz.Text = "Detalle Matriz"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.btnCancel)
        Me.UltraGroupBox2.Controls.Add(Me.btnSave)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 390)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(817, 54)
        Me.UltraGroupBox2.TabIndex = 94
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnCancel
        '
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.btnCancel.Appearance = Appearance14
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(423, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance17.Image = CType(resources.GetObject("Appearance17.Image"), Object)
        Me.btnSave.Appearance = Appearance17
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(313, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Guardar"
        '
        'frmMatrizSeguridadDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 445)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.ugbDetalleMatriz)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMatrizSeguridadDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle Matriz de Seguridad"
        CType(Me.ugbDetalleMatriz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDetalleMatriz.ResumeLayout(False)
        Me.ugbDetalleMatriz.PerformLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTipoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugdDetalleMatriz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDetalleMatriz As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblDescription As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceTipoAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCargo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAgregar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtCantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ugdDetalleMatriz As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
