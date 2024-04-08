<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarTurnosPersonal
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignarTurnosPersonal))
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbHorarioDetalle = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraCheckSemana = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dgvTurnosEmpleados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtFiltrarEmpleados = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.uceTurno = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceEmpleados = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbHorarioDetalle.SuspendLayout()
        CType(Me.UltraCheckSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.dgvTurnosEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrarEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbHorarioDetalle
        '
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraCheckSemana)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpFecha)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraGroupBox1)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnGuardar)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnAdd)
        Me.ugbHorarioDetalle.Controls.Add(Me.uceTurno)
        Me.ugbHorarioDetalle.Controls.Add(Me.uceEmpleados)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel2)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel1)
        Me.ugbHorarioDetalle.Controls.Add(Me.lblEstado)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraButton1)
        Me.ugbHorarioDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbHorarioDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugbHorarioDetalle.Name = "ugbHorarioDetalle"
        Me.ugbHorarioDetalle.Size = New System.Drawing.Size(579, 476)
        Me.ugbHorarioDetalle.TabIndex = 22
        Me.ugbHorarioDetalle.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraCheckSemana
        '
        Me.UltraCheckSemana.BackColor = System.Drawing.Color.Transparent
        Me.UltraCheckSemana.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraCheckSemana.Location = New System.Drawing.Point(445, 37)
        Me.UltraCheckSemana.Name = "UltraCheckSemana"
        Me.UltraCheckSemana.Size = New System.Drawing.Size(70, 20)
        Me.UltraCheckSemana.TabIndex = 110
        Me.UltraCheckSemana.Text = "Semanal"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Location = New System.Drawing.Point(12, 38)
        Me.dtpFecha.MinDate = New Date(2017, 9, 11, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 109
        Me.dtpFecha.Value = New Date(2018, 2, 19, 0, 0, 0, 0)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.dgvTurnosEmpleados)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.txtFiltrarEmpleados)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 117)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(555, 306)
        Me.UltraGroupBox1.TabIndex = 108
        Me.UltraGroupBox1.Text = "Asignar turno a empleados:"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dgvTurnosEmpleados
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.dgvTurnosEmpleados.DisplayLayout.Appearance = Appearance1
        Me.dgvTurnosEmpleados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.dgvTurnosEmpleados.DisplayLayout.GroupByBox.Hidden = True
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.dgvTurnosEmpleados.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.dgvTurnosEmpleados.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvTurnosEmpleados.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvTurnosEmpleados.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvTurnosEmpleados.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvTurnosEmpleados.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.dgvTurnosEmpleados.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvTurnosEmpleados.Location = New System.Drawing.Point(6, 51)
        Me.dgvTurnosEmpleados.Name = "dgvTurnosEmpleados"
        Me.dgvTurnosEmpleados.Size = New System.Drawing.Size(543, 249)
        Me.dgvTurnosEmpleados.TabIndex = 99
        '
        'UltraLabel3
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance6
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 25)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(75, 20)
        Me.UltraLabel3.TabIndex = 98
        Me.UltraLabel3.Text = "Filtrar:"
        '
        'txtFiltrarEmpleados
        '
        Me.txtFiltrarEmpleados.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrarEmpleados.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtFiltrarEmpleados.Location = New System.Drawing.Point(87, 24)
        Me.txtFiltrarEmpleados.Name = "txtFiltrarEmpleados"
        Me.txtFiltrarEmpleados.Size = New System.Drawing.Size(282, 21)
        Me.txtFiltrarEmpleados.TabIndex = 97
        '
        'btnGuardar
        '
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        Me.btnGuardar.Appearance = Appearance9
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnGuardar.Location = New System.Drawing.Point(12, 429)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 35)
        Me.btnGuardar.TabIndex = 99
        Me.btnGuardar.Text = "Guardar"
        '
        'btnAdd
        '
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.TextHAlignAsString = "Center"
        Me.btnAdd.Appearance = Appearance10
        Me.btnAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnAdd.Location = New System.Drawing.Point(354, 90)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(27, 21)
        Me.btnAdd.TabIndex = 107
        Me.btnAdd.Text = "+"
        '
        'uceTurno
        '
        Me.uceTurno.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTurno.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTurno.LimitToList = True
        Me.uceTurno.Location = New System.Drawing.Point(218, 37)
        Me.uceTurno.Name = "uceTurno"
        Me.uceTurno.Size = New System.Drawing.Size(221, 21)
        Me.uceTurno.TabIndex = 106
        '
        'uceEmpleados
        '
        Me.uceEmpleados.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEmpleados.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEmpleados.LimitToList = True
        Me.uceEmpleados.Location = New System.Drawing.Point(12, 90)
        Me.uceEmpleados.Name = "uceEmpleados"
        Me.uceEmpleados.Size = New System.Drawing.Size(336, 21)
        Me.uceEmpleados.TabIndex = 47
        '
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(218, 12)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(118, 20)
        Me.UltraLabel2.TabIndex = 105
        Me.UltraLabel2.Text = "Turno"
        '
        'UltraLabel1
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Left"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance8
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 64)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(118, 20)
        Me.UltraLabel1.TabIndex = 104
        Me.UltraLabel1.Text = "Personal"
        '
        'lblEstado
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Left"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance7
        Me.lblEstado.Location = New System.Drawing.Point(12, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(118, 20)
        Me.lblEstado.TabIndex = 103
        Me.lblEstado.Text = "Día"
        '
        'UltraButton1
        '
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        Me.UltraButton1.Appearance = Appearance11
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.UltraButton1.Location = New System.Drawing.Point(486, 429)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(81, 35)
        Me.UltraButton1.TabIndex = 99
        Me.UltraButton1.Text = "Cancelar"
        '
        'frmAsignarTurnosPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 476)
        Me.Controls.Add(Me.ugbHorarioDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAsignarTurnosPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Turnos a Personal"
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbHorarioDetalle.ResumeLayout(False)
        Me.ugbHorarioDetalle.PerformLayout()
        CType(Me.UltraCheckSemana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.dgvTurnosEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrarEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTurno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbHorarioDetalle As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceTurno As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceEmpleados As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvTurnosEmpleados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtFiltrarEmpleados As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraCheckSemana As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
