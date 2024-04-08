<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfilDetalle
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfilDetalle))
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ucePerfil = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chckTodo = New System.Windows.Forms.CheckBox()
        Me.dgvPermisos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtFiltrarPermisos = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.ucePerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.dgvPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrarPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.ucePerfil)
        Me.ugbContactoAgencia.Controls.Add(Me.txtDescription)
        Me.ugbContactoAgencia.Controls.Add(Me.txtNombre)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel4)
        Me.ugbContactoAgencia.Controls.Add(Me.uceEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel2)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel1)
        Me.ugbContactoAgencia.Controls.Add(Me.lblEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.btnCancel)
        Me.ugbContactoAgencia.Controls.Add(Me.btnSave)
        Me.ugbContactoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbContactoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbContactoAgencia.Name = "ugbContactoAgencia"
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(433, 416)
        Me.ugbContactoAgencia.TabIndex = 20
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ucePerfil
        '
        Me.ucePerfil.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePerfil.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePerfil.LimitToList = True
        Me.ucePerfil.Location = New System.Drawing.Point(138, 11)
        Me.ucePerfil.Name = "ucePerfil"
        Me.ucePerfil.Size = New System.Drawing.Size(202, 21)
        Me.ucePerfil.TabIndex = 52
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescription.Location = New System.Drawing.Point(138, 65)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(283, 21)
        Me.txtDescription.TabIndex = 51
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNombre.Location = New System.Drawing.Point(138, 39)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(202, 21)
        Me.txtNombre.TabIndex = 0
        '
        'UltraLabel4
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance7
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 40)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(121, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "Nombre del Perfil:"
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem3.DataValue = "A"
        ValueListItem3.DisplayText = "Activo"
        ValueListItem4.DataValue = "I"
        ValueListItem4.DisplayText = "Inactivo"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(138, 92)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(202, 21)
        Me.uceEstado.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(72, 92)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(14, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(118, 20)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Descripción del Perfil:"
        '
        'lblEstado
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance8
        Me.lblEstado.Location = New System.Drawing.Point(14, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(118, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Perfil Superior:"
        '
        'btnCancel
        '
        Appearance10.Image = CType(resources.GetObject("Appearance10.Image"), Object)
        Me.btnCancel.Appearance = Appearance10
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(340, 369)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        Me.btnSave.Appearance = Appearance11
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(14, 369)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Guardar"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.chckTodo)
        Me.UltraGroupBox3.Controls.Add(Me.dgvPermisos)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.txtFiltrarPermisos)
        Me.UltraGroupBox3.Enabled = False
        Me.UltraGroupBox3.Location = New System.Drawing.Point(14, 119)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(407, 244)
        Me.UltraGroupBox3.TabIndex = 24
        Me.UltraGroupBox3.Text = "Asignar permisos a perfil:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chckTodo
        '
        Me.chckTodo.AutoSize = True
        Me.chckTodo.BackColor = System.Drawing.Color.Transparent
        Me.chckTodo.Location = New System.Drawing.Point(295, 21)
        Me.chckTodo.Name = "chckTodo"
        Me.chckTodo.Size = New System.Drawing.Size(106, 17)
        Me.chckTodo.TabIndex = 97
        Me.chckTodo.Text = "Seleccionar todo"
        Me.chckTodo.UseVisualStyleBackColor = False
        '
        'dgvPermisos
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.dgvPermisos.DisplayLayout.Appearance = Appearance1
        Me.dgvPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.dgvPermisos.DisplayLayout.GroupByBox.Hidden = True
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.dgvPermisos.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.dgvPermisos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvPermisos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvPermisos.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPermisos.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPermisos.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.dgvPermisos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvPermisos.Location = New System.Drawing.Point(6, 46)
        Me.dgvPermisos.Name = "dgvPermisos"
        Me.dgvPermisos.Size = New System.Drawing.Size(395, 192)
        Me.dgvPermisos.TabIndex = 96
        '
        'UltraLabel3
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance6
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 19)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(57, 20)
        Me.UltraLabel3.TabIndex = 95
        Me.UltraLabel3.Text = "Buscar:"
        '
        'txtFiltrarPermisos
        '
        Me.txtFiltrarPermisos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrarPermisos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtFiltrarPermisos.Location = New System.Drawing.Point(69, 19)
        Me.txtFiltrarPermisos.Name = "txtFiltrarPermisos"
        Me.txtFiltrarPermisos.Size = New System.Drawing.Size(220, 21)
        Me.txtFiltrarPermisos.TabIndex = 53
        '
        'frmPerfilDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 416)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPerfilDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Perfil"
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        Me.ugbContactoAgencia.PerformLayout()
        CType(Me.ucePerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.dgvPermisos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrarPermisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucePerfil As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtFiltrarPermisos As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvPermisos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chckTodo As System.Windows.Forms.CheckBox
End Class
