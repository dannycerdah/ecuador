<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcacionesDetalle
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcacionesDetalle))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbHorarioDetalle = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtObservation = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpSalida = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancelar = New Infragistics.Win.Misc.UltraButton()
        Me.btnGuardar = New Infragistics.Win.Misc.UltraButton()
        Me.dtpIngreso = New System.Windows.Forms.DateTimePicker()
        Me.txtEmpleado = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbHorarioDetalle.SuspendLayout()
        CType(Me.txtObservation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbHorarioDetalle
        '
        Me.ugbHorarioDetalle.Controls.Add(Me.txtObservation)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel2)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpSalida)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel1)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnCancelar)
        Me.ugbHorarioDetalle.Controls.Add(Me.btnGuardar)
        Me.ugbHorarioDetalle.Controls.Add(Me.dtpIngreso)
        Me.ugbHorarioDetalle.Controls.Add(Me.txtEmpleado)
        Me.ugbHorarioDetalle.Controls.Add(Me.UltraLabel4)
        Me.ugbHorarioDetalle.Controls.Add(Me.lblEstado)
        Me.ugbHorarioDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbHorarioDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugbHorarioDetalle.Name = "ugbHorarioDetalle"
        Me.ugbHorarioDetalle.Size = New System.Drawing.Size(411, 187)
        Me.ugbHorarioDetalle.TabIndex = 23
        Me.ugbHorarioDetalle.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtObservation
        '
        Me.txtObservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtObservation.Location = New System.Drawing.Point(112, 91)
        Me.txtObservation.Multiline = True
        Me.txtObservation.Name = "txtObservation"
        Me.txtObservation.Size = New System.Drawing.Size(287, 43)
        Me.txtObservation.TabIndex = 103
        '
        'UltraLabel2
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.Location = New System.Drawing.Point(14, 92)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(92, 20)
        Me.UltraLabel2.TabIndex = 102
        Me.UltraLabel2.Text = "Observación:"
        '
        'dtpSalida
        '
        Me.dtpSalida.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSalida.Location = New System.Drawing.Point(112, 66)
        Me.dtpSalida.Name = "dtpSalida"
        Me.dtpSalida.ShowUpDown = True
        Me.dtpSalida.Size = New System.Drawing.Size(167, 20)
        Me.dtpSalida.TabIndex = 101
        Me.dtpSalida.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(95, 20)
        Me.UltraLabel1.TabIndex = 100
        Me.UltraLabel1.Text = "Salida:"
        '
        'btnCancelar
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnCancelar.Appearance = Appearance5
        Me.btnCancelar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancelar.Location = New System.Drawing.Point(318, 140)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 35)
        Me.btnCancelar.TabIndex = 99
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Me.btnGuardar.Appearance = Appearance4
        Me.btnGuardar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnGuardar.Location = New System.Drawing.Point(11, 146)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 35)
        Me.btnGuardar.TabIndex = 98
        Me.btnGuardar.Text = "Guardar"
        '
        'dtpIngreso
        '
        Me.dtpIngreso.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpIngreso.Enabled = False
        Me.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngreso.Location = New System.Drawing.Point(112, 40)
        Me.dtpIngreso.Name = "dtpIngreso"
        Me.dtpIngreso.ShowUpDown = True
        Me.dtpIngreso.Size = New System.Drawing.Size(167, 20)
        Me.dtpIngreso.TabIndex = 40
        Me.dtpIngreso.Value = New Date(2017, 9, 5, 10, 33, 43, 0)
        '
        'txtEmpleado
        '
        Me.txtEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpleado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtEmpleado.Enabled = False
        Me.txtEmpleado.Location = New System.Drawing.Point(112, 11)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(287, 21)
        Me.txtEmpleado.TabIndex = 0
        '
        'UltraLabel4
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance3
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 40)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(95, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "Ingreso:"
        '
        'lblEstado
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance1
        Me.lblEstado.Location = New System.Drawing.Point(11, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(95, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Empleado:"
        '
        'frmMarcacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 187)
        Me.Controls.Add(Me.ugbHorarioDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMarcacionesDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Marcación"
        CType(Me.ugbHorarioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbHorarioDetalle.ResumeLayout(False)
        Me.ugbHorarioDetalle.PerformLayout()
        CType(Me.txtObservation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbHorarioDetalle As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dtpSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGuardar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dtpIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEmpleado As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtObservation As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
