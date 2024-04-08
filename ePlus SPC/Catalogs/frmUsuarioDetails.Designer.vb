<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioDetails))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chklistBox = New System.Windows.Forms.CheckedListBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.ugbPerfiles = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ucePerfil = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.dgvPerfiles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarPerfil = New System.Windows.Forms.Button()
        Me.uceAdmin = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnContacto = New Infragistics.Win.Misc.UltraButton()
        Me.txtPass = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtUserName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtContacto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugbPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbPerfiles.SuspendLayout()
        CType(Me.ucePerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(12, 297)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Guardar"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(452, 294)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancelar"
        '
        'lblEstado
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance6
        Me.lblEstado.Location = New System.Drawing.Point(11, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(79, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Contacto:"
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 75)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(79, 20)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Password:"
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.UltraGroupBox1)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel3)
        Me.ugbContactoAgencia.Controls.Add(Me.ugbPerfiles)
        Me.ugbContactoAgencia.Controls.Add(Me.uceAdmin)
        Me.ugbContactoAgencia.Controls.Add(Me.btnContacto)
        Me.ugbContactoAgencia.Controls.Add(Me.txtPass)
        Me.ugbContactoAgencia.Controls.Add(Me.txtUserName)
        Me.ugbContactoAgencia.Controls.Add(Me.txtContacto)
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
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(556, 344)
        Me.ugbContactoAgencia.TabIndex = 19
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.chklistBox)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(2, 134)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(183, 154)
        Me.UltraGroupBox1.TabIndex = 87
        Me.UltraGroupBox1.Text = "Asignar Empresa a usuario:"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chklistBox
        '
        Me.chklistBox.CheckOnClick = True
        Me.chklistBox.FormattingEnabled = True
        Me.chklistBox.Items.AddRange(New Object() {"01 GeneralAir", "02 Exporexpress"})
        Me.chklistBox.Location = New System.Drawing.Point(6, 30)
        Me.chklistBox.Name = "chklistBox"
        Me.chklistBox.Size = New System.Drawing.Size(120, 64)
        Me.chklistBox.TabIndex = 87
        '
        'UltraLabel3
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Location = New System.Drawing.Point(309, 73)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(112, 25)
        Me.UltraLabel3.TabIndex = 51
        Me.UltraLabel3.Text = "Visualizar Detalle de Informacion:"
        '
        'ugbPerfiles
        '
        Me.ugbPerfiles.Controls.Add(Me.ucePerfil)
        Me.ugbPerfiles.Controls.Add(Me.dgvPerfiles)
        Me.ugbPerfiles.Controls.Add(Me.btnAgregarPerfil)
        Me.ugbPerfiles.Enabled = False
        Me.ugbPerfiles.Location = New System.Drawing.Point(191, 134)
        Me.ugbPerfiles.Name = "ugbPerfiles"
        Me.ugbPerfiles.Size = New System.Drawing.Size(342, 154)
        Me.ugbPerfiles.TabIndex = 25
        Me.ugbPerfiles.Text = "Asignar perfil a usuario:"
        Me.ugbPerfiles.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ucePerfil
        '
        Me.ucePerfil.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePerfil.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePerfil.LimitToList = True
        Me.ucePerfil.Location = New System.Drawing.Point(53, 19)
        Me.ucePerfil.Name = "ucePerfil"
        Me.ucePerfil.Size = New System.Drawing.Size(240, 21)
        Me.ucePerfil.TabIndex = 90
        '
        'dgvPerfiles
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.dgvPerfiles.DisplayLayout.Appearance = Appearance7
        Me.dgvPerfiles.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.dgvPerfiles.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvPerfiles.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvPerfiles.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.dgvPerfiles.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Me.dgvPerfiles.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 10.0!
        Appearance10.ForeColor = System.Drawing.Color.White
        Appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvPerfiles.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dgvPerfiles.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPerfiles.DisplayLayout.Override.RowSelectorAppearance = Appearance11
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPerfiles.DisplayLayout.Override.SelectedRowAppearance = Appearance13
        Me.dgvPerfiles.Location = New System.Drawing.Point(53, 46)
        Me.dgvPerfiles.Name = "dgvPerfiles"
        Me.dgvPerfiles.Size = New System.Drawing.Size(274, 102)
        Me.dgvPerfiles.TabIndex = 89
        '
        'btnAgregarPerfil
        '
        Me.btnAgregarPerfil.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPerfil.Location = New System.Drawing.Point(281, 19)
        Me.btnAgregarPerfil.Name = "btnAgregarPerfil"
        Me.btnAgregarPerfil.Size = New System.Drawing.Size(48, 21)
        Me.btnAgregarPerfil.TabIndex = 91
        Me.btnAgregarPerfil.Text = "+"
        Me.btnAgregarPerfil.UseVisualStyleBackColor = True
        '
        'uceAdmin
        '
        Me.uceAdmin.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAdmin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem1.DataValue = "F"
        ValueListItem1.DisplayText = "No"
        ValueListItem2.DataValue = "T"
        ValueListItem2.DisplayText = "Si"
        Me.uceAdmin.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.uceAdmin.LimitToList = True
        Me.uceAdmin.Location = New System.Drawing.Point(427, 78)
        Me.uceAdmin.Name = "uceAdmin"
        Me.uceAdmin.Size = New System.Drawing.Size(106, 21)
        Me.uceAdmin.TabIndex = 3
        '
        'btnContacto
        '
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Me.btnContacto.Appearance = Appearance3
        Me.btnContacto.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnContacto.Location = New System.Drawing.Point(506, 12)
        Me.btnContacto.Name = "btnContacto"
        Me.btnContacto.Size = New System.Drawing.Size(27, 21)
        Me.btnContacto.TabIndex = 46
        Me.btnContacto.Visible = False
        '
        'txtPass
        '
        Me.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPass.Location = New System.Drawing.Point(96, 75)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(202, 21)
        Me.txtPass.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtUserName.Location = New System.Drawing.Point(96, 46)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(202, 21)
        Me.txtUserName.TabIndex = 0
        '
        'txtContacto
        '
        Me.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtContacto.Location = New System.Drawing.Point(96, 12)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(389, 21)
        Me.txtContacto.TabIndex = 50
        '
        'UltraLabel4
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance4
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 47)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(79, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "User Name:"
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem3.DataValue = "A"
        ValueListItem3.DisplayText = "Activo"
        ValueListItem4.DataValue = "I"
        ValueListItem4.DisplayText = "Inactivo"
        ValueListItem5.DataValue = "E"
        ValueListItem5.DisplayText = "Eliminado"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4, ValueListItem5})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(427, 46)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(106, 21)
        Me.uceEstado.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.Location = New System.Drawing.Point(351, 47)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'frmUsuarioDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 344)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUsuarioDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Usuario"
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        Me.ugbContactoAgencia.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugbPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbPerfiles.ResumeLayout(False)
        Me.ugbPerfiles.PerformLayout()
        CType(Me.ucePerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPass As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtUserName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtContacto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnContacto As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceAdmin As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dgvPerfiles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ucePerfil As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnAgregarPerfil As System.Windows.Forms.Button
    Friend WithEvents ugbPerfiles As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chklistBox As CheckedListBox
End Class
