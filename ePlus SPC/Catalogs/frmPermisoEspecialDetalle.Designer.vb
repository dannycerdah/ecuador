<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisoEspecialDetalle
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
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPermisoEspecialDetalle))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbHorarioDetalle = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnAgregarPermisoContacto = New System.Windows.Forms.Button()
        Me.uceContactoAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.dgvPermisoContacto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtObservation = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancelar = New Infragistics.Win.Misc.UltraButton()
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton()
        Me.txtDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbHorarioDetalle.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPermisoContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbHorarioDetalle
        '
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraGroupBox3)
        Me.ugbHorarioDetalle.Controls.Add(Me.txtObservation)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel6)
        Me.ugbHorarioDetalle.Controls.Add(Me.udtFin)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel5)
        Me.ugbHorarioDetalle.Controls.Add(Me.udtInicio)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpFin)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel3)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpInicio)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel1)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnCancelar)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnGuardar)
        Me.ugbHorarioDetalle.Controls.Add(Me.txtDescription)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel4)
        Me.ugbHorarioDetalle.Controls.Add(Me.uceEstado)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel2)
        Me.ugbHorarioDetalle.Controls.Add(Me.lblEstado)
        Me.ugbHorarioDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbHorarioDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugbHorarioDetalle.Name = "ugbHorarioDetalle"
        Me.ugbHorarioDetalle.Size = New System.Drawing.Size(793, 286)
        Me.ugbHorarioDetalle.TabIndex = 23
        Me.ugbHorarioDetalle.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.btnAgregarPermisoContacto)
        Me.UltraGroupBox3.Controls.Add(Me.uceContactoAgencia)
        Me.UltraGroupBox3.Controls.Add(Me.dgvPermisoContacto)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(393, 11)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(389, 263)
        Me.UltraGroupBox3.TabIndex = 25
        Me.UltraGroupBox3.Text = "Asignar permiso a contacto:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnAgregarPermisoContacto
        '
        Me.btnAgregarPermisoContacto.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPermisoContacto.Image = Global.SPC.My.Resources.Resources.add16x16
        Me.btnAgregarPermisoContacto.Location = New System.Drawing.Point(352, 27)
        Me.btnAgregarPermisoContacto.Name = "btnAgregarPermisoContacto"
        Me.btnAgregarPermisoContacto.Size = New System.Drawing.Size(27, 27)
        Me.btnAgregarPermisoContacto.TabIndex = 111
        Me.btnAgregarPermisoContacto.Text = "+"
        Me.btnAgregarPermisoContacto.UseVisualStyleBackColor = True
        '
        'uceContactoAgencia
        '
        Me.uceContactoAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContactoAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContactoAgencia.LimitToList = True
        Me.uceContactoAgencia.Location = New System.Drawing.Point(6, 27)
        Me.uceContactoAgencia.Name = "uceContactoAgencia"
        Me.uceContactoAgencia.Size = New System.Drawing.Size(337, 21)
        Me.uceContactoAgencia.TabIndex = 110
        '
        'dgvPermisoContacto
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.dgvPermisoContacto.DisplayLayout.Appearance = Appearance1
        Me.dgvPermisoContacto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.dgvPermisoContacto.DisplayLayout.GroupByBox.Hidden = True
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.dgvPermisoContacto.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.dgvPermisoContacto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvPermisoContacto.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvPermisoContacto.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPermisoContacto.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvPermisoContacto.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.dgvPermisoContacto.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvPermisoContacto.Location = New System.Drawing.Point(6, 60)
        Me.dgvPermisoContacto.Name = "dgvPermisoContacto"
        Me.dgvPermisoContacto.Size = New System.Drawing.Size(373, 197)
        Me.dgvPermisoContacto.TabIndex = 96
        '
        'txtObservation
        '
        Me.txtObservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtObservation.Location = New System.Drawing.Point(115, 91)
        Me.txtObservation.Multiline = True
        Me.txtObservation.Name = "txtObservation"
        Me.txtObservation.Size = New System.Drawing.Size(272, 64)
        Me.txtObservation.TabIndex = 108
        '
        'UltraLabel6
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance10
        Me.UltraLabel6.Location = New System.Drawing.Point(14, 92)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(95, 20)
        Me.UltraLabel6.TabIndex = 109
        Me.UltraLabel6.Text = "Observación:"
        '
        'udtFin
        '
        Me.udtFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFin.FormatString = "dd/MM/yyyy"
        Me.udtFin.Location = New System.Drawing.Point(287, 38)
        Me.udtFin.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtFin.Name = "udtFin"
        Me.udtFin.Size = New System.Drawing.Size(100, 21)
        Me.udtFin.TabIndex = 107
        '
        'UltraLabel5
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance11
        Me.UltraLabel5.Location = New System.Drawing.Point(221, 40)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel5.TabIndex = 106
        Me.UltraLabel5.Text = "Hasta:"
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = "dd/MM/yyyy"
        Me.udtInicio.Location = New System.Drawing.Point(115, 38)
        Me.udtInicio.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(100, 21)
        Me.udtInicio.TabIndex = 105
        '
        'dtpFin
        '
        Me.dtpFin.CustomFormat = "HH:mm"
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFin.Location = New System.Drawing.Point(287, 65)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.ShowUpDown = True
        Me.dtpFin.Size = New System.Drawing.Size(100, 20)
        Me.dtpFin.TabIndex = 103
        Me.dtpFin.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraLabel3
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance8
        Me.UltraLabel3.Location = New System.Drawing.Point(220, 65)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(61, 20)
        Me.UltraLabel3.TabIndex = 102
        Me.UltraLabel3.Text = "Salida:"
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "HH:mm"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(115, 65)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.ShowUpDown = True
        Me.dtpInicio.Size = New System.Drawing.Size(100, 20)
        Me.dtpInicio.TabIndex = 101
        Me.dtpInicio.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance12
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(103, 20)
        Me.UltraLabel1.TabIndex = 100
        Me.UltraLabel1.Text = "Ingreso:"
        '
        'btnCancelar
        '
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.btnCancelar.Appearance = Appearance13
        Me.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancelar.Location = New System.Drawing.Point(306, 240)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 35)
        Me.btnCancelar.TabIndex = 99
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.btnGuardar.Appearance = Appearance14
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnGuardar.Location = New System.Drawing.Point(14, 240)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 35)
        Me.btnGuardar.TabIndex = 98
        Me.btnGuardar.Text = "Guardar"
        '
        'txtDescription
        '
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescription.Location = New System.Drawing.Point(115, 11)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(272, 21)
        Me.txtDescription.TabIndex = 0
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
        Me.UltraLabel4.Size = New System.Drawing.Size(98, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "Desde:"
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem1.DataValue = "A"
        ValueListItem1.DisplayText = "Activo"
        ValueListItem2.DataValue = "I"
        ValueListItem2.DisplayText = "Inactivo"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(115, 161)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(100, 21)
        Me.uceEstado.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance15
        Me.UltraLabel2.Location = New System.Drawing.Point(49, 162)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'lblEstado
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance9
        Me.lblEstado.Location = New System.Drawing.Point(14, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(95, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Descripción:"
        '
        'frmPermisoEspecialDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 286)
        Me.Controls.Add(Me.ugbHorarioDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPermisoEspecialDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Permiso Especial"
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbHorarioDetalle.ResumeLayout(False)
        Me.ugbHorarioDetalle.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPermisoContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbHorarioDetalle As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtObservation As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvPermisoContacto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents uceContactoAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnAgregarPermisoContacto As System.Windows.Forms.Button
End Class
