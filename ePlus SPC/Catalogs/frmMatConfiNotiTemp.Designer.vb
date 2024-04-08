<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMatConfiNotiTemp
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
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMatConfiNotiTemp))
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnConsProducto = New Infragistics.Win.Misc.UltraButton()
        Me.ugdDetalleConfig = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblBultos = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPeso = New Infragistics.Win.Misc.UltraLabel()
        Me.txtProducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblProducto = New Infragistics.Win.Misc.UltraLabel()
        Me.btnAgregar = New Infragistics.Win.Misc.UltraButton()
        Me.MinTemp = New System.Windows.Forms.NumericUpDown()
        Me.MaxTemp = New System.Windows.Forms.NumericUpDown()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.ugdDetalleConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox4.Controls.Add(Me.uceEstado)
        Me.UltraGroupBox4.Controls.Add(Me.MaxTemp)
        Me.UltraGroupBox4.Controls.Add(Me.MinTemp)
        Me.UltraGroupBox4.Controls.Add(Me.btnCancel)
        Me.UltraGroupBox4.Controls.Add(Me.btnSave)
        Me.UltraGroupBox4.Controls.Add(Me.btnConsProducto)
        Me.UltraGroupBox4.Controls.Add(Me.ugdDetalleConfig)
        Me.UltraGroupBox4.Controls.Add(Me.lblBultos)
        Me.UltraGroupBox4.Controls.Add(Me.lblPeso)
        Me.UltraGroupBox4.Controls.Add(Me.txtProducto)
        Me.UltraGroupBox4.Controls.Add(Me.lblProducto)
        Me.UltraGroupBox4.Controls.Add(Me.btnAgregar)
        Me.UltraGroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(609, 254)
        Me.UltraGroupBox4.TabIndex = 38
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnCancel
        '
        Appearance59.Image = CType(resources.GetObject("Appearance59.Image"), Object)
        Me.btnCancel.Appearance = Appearance59
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(528, 82)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 27)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Salir"
        '
        'btnSave
        '
        Appearance9.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance9
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(528, 28)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 27)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Guardar"
        '
        'btnConsProducto
        '
        Appearance40.Image = Global.SPC.My.Resources.Resources.list16x16
        Me.btnConsProducto.Appearance = Appearance40
        Me.btnConsProducto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsProducto.Location = New System.Drawing.Point(342, 7)
        Me.btnConsProducto.Name = "btnConsProducto"
        Me.btnConsProducto.Size = New System.Drawing.Size(27, 27)
        Me.btnConsProducto.TabIndex = 1
        '
        'ugdDetalleConfig
        '
        Appearance41.BackColor = System.Drawing.Color.White
        Me.ugdDetalleConfig.DisplayLayout.Appearance = Appearance41
        Me.ugdDetalleConfig.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdDetalleConfig.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdDetalleConfig.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Appearance42.BackColor = System.Drawing.Color.Transparent
        Me.ugdDetalleConfig.DisplayLayout.Override.CardAreaAppearance = Appearance42
        Me.ugdDetalleConfig.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance46.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance46.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance46.FontData.BoldAsString = "True"
        Appearance46.FontData.Name = "Arial"
        Appearance46.FontData.SizeInPoints = 10.0!
        Appearance46.ForeColor = System.Drawing.Color.White
        Appearance46.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdDetalleConfig.DisplayLayout.Override.HeaderAppearance = Appearance46
        Appearance47.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance47.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalleConfig.DisplayLayout.Override.RowSelectorAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance48.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDetalleConfig.DisplayLayout.Override.SelectedRowAppearance = Appearance48
        Me.ugdDetalleConfig.Location = New System.Drawing.Point(4, 115)
        Me.ugdDetalleConfig.Name = "ugdDetalleConfig"
        Me.ugdDetalleConfig.Size = New System.Drawing.Size(605, 137)
        Me.ugdDetalleConfig.TabIndex = 9
        Me.ugdDetalleConfig.Text = "TEMPERATURA PRODUCTO"
        '
        'lblBultos
        '
        Appearance49.BackColor = System.Drawing.Color.Transparent
        Appearance49.TextHAlignAsString = "Left"
        Appearance49.TextVAlignAsString = "Middle"
        Me.lblBultos.Appearance = Appearance49
        Me.lblBultos.Location = New System.Drawing.Point(12, 63)
        Me.lblBultos.Name = "lblBultos"
        Me.lblBultos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBultos.Size = New System.Drawing.Size(85, 22)
        Me.lblBultos.TabIndex = 36
        Me.lblBultos.Text = "Temp Maxima:"
        '
        'lblPeso
        '
        Appearance50.BackColor = System.Drawing.Color.Transparent
        Appearance50.TextHAlignAsString = "Left"
        Appearance50.TextVAlignAsString = "Middle"
        Me.lblPeso.Appearance = Appearance50
        Me.lblPeso.Location = New System.Drawing.Point(12, 35)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPeso.Size = New System.Drawing.Size(85, 21)
        Me.lblPeso.TabIndex = 35
        Me.lblPeso.Text = "Temp. Minima:"
        '
        'txtProducto
        '
        Me.txtProducto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtProducto.Location = New System.Drawing.Point(116, 7)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(220, 21)
        Me.txtProducto.TabIndex = 29
        '
        'lblProducto
        '
        Appearance54.BackColor = System.Drawing.Color.Transparent
        Appearance54.TextVAlignAsString = "Middle"
        Me.lblProducto.Appearance = Appearance54
        Me.lblProducto.Location = New System.Drawing.Point(12, 12)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblProducto.Size = New System.Drawing.Size(61, 20)
        Me.lblProducto.TabIndex = 27
        Me.lblProducto.Text = "Producto:"
        '
        'btnAgregar
        '
        Appearance55.Image = Global.SPC.My.Resources.Resources.add16x16
        Me.btnAgregar.Appearance = Appearance55
        Me.btnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnAgregar.Location = New System.Drawing.Point(221, 44)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(27, 27)
        Me.btnAgregar.TabIndex = 8
        '
        'MinTemp
        '
        Me.MinTemp.DecimalPlaces = 2
        Me.MinTemp.Location = New System.Drawing.Point(116, 36)
        Me.MinTemp.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.MinTemp.Name = "MinTemp"
        Me.MinTemp.Size = New System.Drawing.Size(68, 20)
        Me.MinTemp.TabIndex = 57
        Me.MinTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MaxTemp
        '
        Me.MaxTemp.DecimalPlaces = 2
        Me.MaxTemp.Location = New System.Drawing.Point(116, 65)
        Me.MaxTemp.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.MaxTemp.Name = "MaxTemp"
        Me.MaxTemp.Size = New System.Drawing.Size(68, 20)
        Me.MaxTemp.TabIndex = 58
        Me.MaxTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UltraLabel2
        '
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance20
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 91)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel2.TabIndex = 60
        Me.UltraLabel2.Text = "Estado:"
        Me.UltraLabel2.Visible = False
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem5.DataValue = "A"
        ValueListItem5.DisplayText = "Activo"
        ValueListItem6.DataValue = "I"
        ValueListItem6.DisplayText = "Inactivo"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem6})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(116, 90)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(68, 21)
        Me.uceEstado.TabIndex = 59
        Me.uceEstado.Visible = False
        '
        'frmMatConfiNotiTemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 254)
        Me.Controls.Add(Me.UltraGroupBox4)
        Me.Name = "frmMatConfiNotiTemp"
        Me.Text = "frmMatConfiNotiTemp"
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.ugdDetalleConfig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnConsProducto As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugdDetalleConfig As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblBultos As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblPeso As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtProducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblProducto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAgregar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents MaxTemp As NumericUpDown
    Friend WithEvents MinTemp As NumericUpDown
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
