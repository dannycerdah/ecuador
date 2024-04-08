<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigurationGeneral
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigurationGeneral))
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.dtpHBriefing = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnGuardarTiempo = New Infragistics.Win.Misc.UltraButton()
        Me.dtpHorario = New System.Windows.Forms.DateTimePicker()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.txtConfirmar = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.txtClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtUsuario = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox1)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox3)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel1)
        Me.ugbDatosVuelo.Controls.Add(Me.btnCancel)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(327, 300)
        Me.ugbDatosVuelo.TabIndex = 21
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.dtpHBriefing)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox1.Controls.Add(Me.btnGuardarTiempo)
        Me.UltraGroupBox1.Controls.Add(Me.dtpHorario)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 155)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(304, 104)
        Me.UltraGroupBox1.TabIndex = 111
        Me.UltraGroupBox1.Text = "Configuraciones generales:"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel6
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance5
        Me.UltraLabel6.Location = New System.Drawing.Point(6, 45)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(175, 20)
        Me.UltraLabel6.TabIndex = 111
        Me.UltraLabel6.Text = "Margen de Briefing:"
        '
        'dtpHBriefing
        '
        Me.dtpHBriefing.CustomFormat = "HH:mm:ss"
        Me.dtpHBriefing.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHBriefing.Location = New System.Drawing.Point(187, 45)
        Me.dtpHBriefing.Name = "dtpHBriefing"
        Me.dtpHBriefing.ShowUpDown = True
        Me.dtpHBriefing.Size = New System.Drawing.Size(111, 20)
        Me.dtpHBriefing.TabIndex = 112
        Me.dtpHBriefing.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance1
        Me.UltraLabel5.Location = New System.Drawing.Point(6, 19)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(175, 20)
        Me.UltraLabel5.TabIndex = 81
        Me.UltraLabel5.Text = "Tiempo marcación válida:"
        '
        'btnGuardarTiempo
        '
        Appearance2.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnGuardarTiempo.Appearance = Appearance2
        Me.btnGuardarTiempo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnGuardarTiempo.Location = New System.Drawing.Point(223, 71)
        Me.btnGuardarTiempo.Name = "btnGuardarTiempo"
        Me.btnGuardarTiempo.Size = New System.Drawing.Size(81, 27)
        Me.btnGuardarTiempo.TabIndex = 82
        Me.btnGuardarTiempo.Text = "Guardar"
        '
        'dtpHorario
        '
        Me.dtpHorario.CustomFormat = "HH:mm:ss"
        Me.dtpHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHorario.Location = New System.Drawing.Point(187, 19)
        Me.dtpHorario.Name = "dtpHorario"
        Me.dtpHorario.ShowUpDown = True
        Me.dtpHorario.Size = New System.Drawing.Size(111, 20)
        Me.dtpHorario.TabIndex = 110
        Me.dtpHorario.Value = New Date(2017, 8, 30, 0, 0, 0, 0)
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraButton1)
        Me.UltraGroupBox3.Controls.Add(Me.txtConfirmar)
        Me.UltraGroupBox3.Controls.Add(Me.btnSave)
        Me.UltraGroupBox3.Controls.Add(Me.txtClave)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Controls.Add(Me.txtUsuario)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(11, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(304, 137)
        Me.UltraGroupBox3.TabIndex = 79
        Me.UltraGroupBox3.Text = "Ecuapass:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraButton1
        '
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.UltraButton1.Location = New System.Drawing.Point(217, 99)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(81, 27)
        Me.UltraButton1.TabIndex = 74
        Me.UltraButton1.Text = "Ver datos"
        '
        'txtConfirmar
        '
        Me.txtConfirmar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtConfirmar.Location = New System.Drawing.Point(111, 72)
        Me.txtConfirmar.Name = "txtConfirmar"
        Me.txtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmar.Size = New System.Drawing.Size(187, 21)
        Me.txtConfirmar.TabIndex = 73
        '
        'btnSave
        '
        Appearance8.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance8
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(6, 97)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 27)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Guardar"
        '
        'txtClave
        '
        Me.txtClave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtClave.Location = New System.Drawing.Point(111, 45)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(187, 21)
        Me.txtClave.TabIndex = 72
        '
        'UltraLabel4
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance9
        Me.UltraLabel4.Location = New System.Drawing.Point(6, 71)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(99, 20)
        Me.UltraLabel4.TabIndex = 71
        Me.UltraLabel4.Text = "Confirmar clave:"
        '
        'txtUsuario
        '
        Me.txtUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtUsuario.Location = New System.Drawing.Point(111, 18)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(187, 21)
        Me.txtUsuario.TabIndex = 1
        '
        'UltraLabel3
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance10
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 19)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(99, 20)
        Me.UltraLabel3.TabIndex = 64
        Me.UltraLabel3.Text = "Usuario:"
        '
        'UltraLabel2
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance11
        Me.UltraLabel2.Location = New System.Drawing.Point(6, 45)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(99, 20)
        Me.UltraLabel2.TabIndex = 70
        Me.UltraLabel2.Text = "Nueva clave:"
        '
        'UltraLabel1
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 94)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(99, 20)
        Me.UltraLabel1.TabIndex = 68
        Me.UltraLabel1.Text = "Char Ini:"
        '
        'btnCancel
        '
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        Me.btnCancel.Appearance = Appearance12
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(234, 265)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 27)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Salir"
        '
        'frmConfigurationGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 300)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConfigurationGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Generales"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtUsuario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtConfirmar As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnGuardarTiempo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHorario As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHBriefing As System.Windows.Forms.DateTimePicker
End Class
