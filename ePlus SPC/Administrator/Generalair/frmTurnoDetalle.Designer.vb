<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTurnoDetalle
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTurnoDetalle))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.txtTitle = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancelar = New Infragistics.Win.Misc.UltraButton()
        Me.ugbHorarioDetalle = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpAtraso = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbHorarioDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance7
        Me.lblEstado.Location = New System.Drawing.Point(14, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(118, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Título:"
        '
        'UltraLabel2
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.Location = New System.Drawing.Point(72, 116)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
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
        Me.uceEstado.Location = New System.Drawing.Point(138, 116)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(100, 21)
        Me.uceEstado.TabIndex = 2
        '
        'txtTitle
        '
        Me.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTitle.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtTitle.Location = New System.Drawing.Point(138, 11)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(203, 21)
        Me.txtTitle.TabIndex = 0
        '
        'btnGuardar
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Me.btnGuardar.Appearance = Appearance4
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnGuardar.Location = New System.Drawing.Point(14, 144)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 35)
        Me.btnGuardar.TabIndex = 98
        Me.btnGuardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnCancelar.Appearance = Appearance5
        Me.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancelar.Location = New System.Drawing.Point(260, 144)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 35)
        Me.btnCancelar.TabIndex = 99
        Me.btnCancelar.Text = "Cancelar"
        '
        'ugbHorarioDetalle
        '
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpFin)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel3)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpInicio)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel1)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnCancelar)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnGuardar)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpAtraso)
        Me.ugbHorarioDetalle.Controls.Add(Me.txtTitle)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel4)
        Me.ugbHorarioDetalle.Controls.Add(Me.uceEstado)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel2)
        Me.ugbHorarioDetalle.Controls.Add(Me.lblEstado)
        Me.ugbHorarioDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbHorarioDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugbHorarioDetalle.Name = "ugbHorarioDetalle"
        Me.ugbHorarioDetalle.Size = New System.Drawing.Size(353, 191)
        Me.ugbHorarioDetalle.TabIndex = 22
        Me.ugbHorarioDetalle.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dtpFin
        '
        Me.dtpFin.CustomFormat = "HH:mm"
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFin.Location = New System.Drawing.Point(138, 90)
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
        Me.UltraLabel3.Location = New System.Drawing.Point(11, 90)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(121, 20)
        Me.UltraLabel3.TabIndex = 102
        Me.UltraLabel3.Text = "Fin:"
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "HH:mm"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(138, 64)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.ShowUpDown = True
        Me.dtpInicio.Size = New System.Drawing.Size(100, 20)
        Me.dtpInicio.TabIndex = 101
        Me.dtpInicio.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 64)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(121, 20)
        Me.UltraLabel1.TabIndex = 100
        Me.UltraLabel1.Text = "Inicio:"
        '
        'dtpAtraso
        '
        Me.dtpAtraso.CustomFormat = "HH:mm"
        Me.dtpAtraso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAtraso.Location = New System.Drawing.Point(138, 38)
        Me.dtpAtraso.Name = "dtpAtraso"
        Me.dtpAtraso.ShowUpDown = True
        Me.dtpAtraso.Size = New System.Drawing.Size(100, 20)
        Me.dtpAtraso.TabIndex = 40
        Me.dtpAtraso.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        Me.dtpAtraso.Visible = False
        '
        'UltraLabel4
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance3
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 38)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(121, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "Tiempo de Atraso:"
        Me.UltraLabel4.Visible = False
        '
        'frmTurnoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 191)
        Me.Controls.Add(Me.ugbHorarioDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTurnoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Turno"
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbHorarioDetalle.ResumeLayout(False)
        Me.ugbHorarioDetalle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtTitle As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugbHorarioDetalle As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpAtraso As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
End Class
