<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HorariosAgenciasSeguridad
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
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dgvHorario = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.DateTimeHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabelHoraFin = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabelHoraInicio = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbContacto = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnAgregarAgencia = New System.Windows.Forms.Button()
        Me.cmbAgencias = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.dgvHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAgencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox2.Controls.Add(Me.DateTimeHoraInicio)
        Me.UltraGroupBox2.Controls.Add(Me.DateTimeHoraFin)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabelHoraFin)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabelHoraInicio)
        Me.UltraGroupBox2.Controls.Add(Me.udtFinal)
        Me.UltraGroupBox2.Controls.Add(Me.udtInicio)
        Me.UltraGroupBox2.Controls.Add(Me.lblDesde)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox2.Controls.Add(Me.cmbContacto)
        Me.UltraGroupBox2.Controls.Add(Me.btnAgregarAgencia)
        Me.UltraGroupBox2.Controls.Add(Me.cmbAgencias)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel20)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(898, 269)
        Me.UltraGroupBox2.TabIndex = 36
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.dgvHorario)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 96)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(892, 162)
        Me.UltraGroupBox1.TabIndex = 104
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dgvHorario
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Me.dgvHorario.DisplayLayout.Appearance = Appearance7
        Me.dgvHorario.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.dgvHorario.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvHorario.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvHorario.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.dgvHorario.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Me.dgvHorario.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 10.0!
        Appearance10.ForeColor = System.Drawing.Color.White
        Appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvHorario.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dgvHorario.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvHorario.DisplayLayout.Override.RowSelectorAppearance = Appearance5
        Appearance13.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance13.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvHorario.DisplayLayout.Override.SelectedRowAppearance = Appearance13
        Me.dgvHorario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHorario.Location = New System.Drawing.Point(3, 0)
        Me.dgvHorario.Name = "dgvHorario"
        Me.dgvHorario.Size = New System.Drawing.Size(886, 159)
        Me.dgvHorario.TabIndex = 92
        '
        'UltraLabel3
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.BackColor2 = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.UltraLabel3.Location = New System.Drawing.Point(674, 12)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabel3.TabIndex = 103
        Me.UltraLabel3.Text = "-"
        '
        'DateTimeHoraInicio
        '
        Me.DateTimeHoraInicio.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraInicio.Location = New System.Drawing.Point(588, 56)
        Me.DateTimeHoraInicio.Name = "DateTimeHoraInicio"
        Me.DateTimeHoraInicio.ShowUpDown = True
        Me.DateTimeHoraInicio.Size = New System.Drawing.Size(73, 20)
        Me.DateTimeHoraInicio.TabIndex = 102
        Me.DateTimeHoraInicio.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'DateTimeHoraFin
        '
        Me.DateTimeHoraFin.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraFin.Location = New System.Drawing.Point(743, 59)
        Me.DateTimeHoraFin.Name = "DateTimeHoraFin"
        Me.DateTimeHoraFin.ShowUpDown = True
        Me.DateTimeHoraFin.Size = New System.Drawing.Size(71, 20)
        Me.DateTimeHoraFin.TabIndex = 101
        Me.DateTimeHoraFin.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'UltraLabelHoraFin
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BackColor2 = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabelHoraFin.Appearance = Appearance3
        Me.UltraLabelHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabelHoraFin.Location = New System.Drawing.Point(667, 59)
        Me.UltraLabelHoraFin.Name = "UltraLabelHoraFin"
        Me.UltraLabelHoraFin.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabelHoraFin.TabIndex = 100
        Me.UltraLabelHoraFin.Text = "Hora Fin:"
        '
        'UltraLabelHoraInicio
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.BackColor2 = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Center"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabelHoraInicio.Appearance = Appearance11
        Me.UltraLabelHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabelHoraInicio.Location = New System.Drawing.Point(462, 52)
        Me.UltraLabelHoraInicio.Name = "UltraLabelHoraInicio"
        Me.UltraLabelHoraInicio.Size = New System.Drawing.Size(74, 24)
        Me.UltraLabelHoraInicio.TabIndex = 99
        Me.UltraLabelHoraInicio.Text = "Hora Inicio:"
        '
        'udtFinal
        '
        Me.udtFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFinal.FormatString = ""
        Me.udtFinal.Location = New System.Drawing.Point(734, 12)
        Me.udtFinal.MaskInput = "dd/mm/yyyy"
        Me.udtFinal.Name = "udtFinal"
        Me.udtFinal.Size = New System.Drawing.Size(80, 21)
        Me.udtFinal.TabIndex = 98
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = ""
        Me.udtInicio.Location = New System.Drawing.Point(588, 12)
        Me.udtInicio.MaskInput = "dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(84, 21)
        Me.udtInicio.TabIndex = 97
        '
        'lblDesde
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Left"
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance14
        Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblDesde.Location = New System.Drawing.Point(462, 12)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(156, 21)
        Me.lblDesde.TabIndex = 96
        Me.lblDesde.Text = "Fecha de Inicio y Fin"
        '
        'UltraLabel6
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.TextHAlignAsString = "Left"
        Appearance25.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance25
        Me.UltraLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(24, 48)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(59, 26)
        Me.UltraLabel6.TabIndex = 95
        Me.UltraLabel6.Text = "Contacto"
        '
        'cmbContacto
        '
        Me.cmbContacto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cmbContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbContacto.LimitToList = True
        Me.cmbContacto.Location = New System.Drawing.Point(139, 53)
        Me.cmbContacto.Name = "cmbContacto"
        Me.cmbContacto.Size = New System.Drawing.Size(251, 21)
        Me.cmbContacto.TabIndex = 94
        '
        'btnAgregarAgencia
        '
        Me.btnAgregarAgencia.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAgencia.Image = Global.SPC.My.Resources.Resources.add16x16
        Me.btnAgregarAgencia.Location = New System.Drawing.Point(820, 33)
        Me.btnAgregarAgencia.Name = "btnAgregarAgencia"
        Me.btnAgregarAgencia.Size = New System.Drawing.Size(27, 27)
        Me.btnAgregarAgencia.TabIndex = 93
        Me.btnAgregarAgencia.UseVisualStyleBackColor = True
        '
        'cmbAgencias
        '
        Me.cmbAgencias.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cmbAgencias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbAgencias.LimitToList = True
        Me.cmbAgencias.Location = New System.Drawing.Point(139, 12)
        Me.cmbAgencias.Name = "cmbAgencias"
        Me.cmbAgencias.Size = New System.Drawing.Size(251, 21)
        Me.cmbAgencias.TabIndex = 64
        '
        'UltraLabel20
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel20.Appearance = Appearance2
        Me.UltraLabel20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel20.Location = New System.Drawing.Point(24, 12)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel20.Size = New System.Drawing.Size(92, 21)
        Me.UltraLabel20.TabIndex = 63
        Me.UltraLabel20.Text = "Agencia:"
        '
        'HorariosAgenciasSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 269)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Name = "HorariosAgenciasSeguridad"
        Me.Text = "Registro de Horario Agensia Seguridad"
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.dgvHorario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAgencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvHorario As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarAgencia As Button
    Friend WithEvents cmbAgencias As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DateTimeHoraInicio As DateTimePicker
    Friend WithEvents DateTimeHoraFin As DateTimePicker
    Friend WithEvents UltraLabelHoraFin As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabelHoraInicio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbContacto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
End Class
