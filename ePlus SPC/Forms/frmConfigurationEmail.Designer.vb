<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigurationEmail
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigurationEmail))
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtRemitente = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtHost = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPuerto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.chkSSL = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPuerto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.txtRemitente)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel1)
        Me.ugbDatosVuelo.Controls.Add(Me.txtClave)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel2)
        Me.ugbDatosVuelo.Controls.Add(Me.txtHost)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel3)
        Me.ugbDatosVuelo.Controls.Add(Me.txtPuerto)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel5)
        Me.ugbDatosVuelo.Controls.Add(Me.chkSSL)
        Me.ugbDatosVuelo.Controls.Add(Me.btnCancel)
        Me.ugbDatosVuelo.Controls.Add(Me.btnSave)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(284, 177)
        Me.ugbDatosVuelo.TabIndex = 21
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtRemitente
        '
        Me.txtRemitente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtRemitente.Location = New System.Drawing.Point(83, 65)
        Me.txtRemitente.Name = "txtRemitente"
        Me.txtRemitente.Size = New System.Drawing.Size(189, 21)
        Me.txtRemitente.TabIndex = 3
        '
        'UltraLabel1
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 38)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(65, 20)
        Me.UltraLabel1.TabIndex = 68
        Me.UltraLabel1.Text = "Puerto:"
        '
        'txtClave
        '
        Me.txtClave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtClave.Location = New System.Drawing.Point(83, 92)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(189, 21)
        Me.txtClave.TabIndex = 4
        '
        'UltraLabel2
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance4
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 92)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(65, 20)
        Me.UltraLabel2.TabIndex = 70
        Me.UltraLabel2.Text = "Clave:"
        '
        'txtHost
        '
        Me.txtHost.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtHost.Location = New System.Drawing.Point(83, 11)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(189, 21)
        Me.txtHost.TabIndex = 1
        '
        'UltraLabel3
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance5
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 12)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(71, 20)
        Me.UltraLabel3.TabIndex = 64
        Me.UltraLabel3.Text = "Host:"
        '
        'txtPuerto
        '
        Me.txtPuerto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPuerto.Location = New System.Drawing.Point(83, 38)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(64, 21)
        Me.txtPuerto.TabIndex = 2
        '
        'UltraLabel5
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance6
        Me.UltraLabel5.Location = New System.Drawing.Point(6, 66)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(71, 20)
        Me.UltraLabel5.TabIndex = 66
        Me.UltraLabel5.Text = "Remitente:"
        '
        'chkSSL
        '
        Me.chkSSL.AutoSize = True
        Me.chkSSL.BackColor = System.Drawing.Color.Transparent
        Me.chkSSL.Location = New System.Drawing.Point(83, 119)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(87, 17)
        Me.chkSSL.TabIndex = 0
        Me.chkSSL.Text = "Habilitar SSL"
        Me.chkSSL.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Me.btnCancel.Appearance = Appearance26
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(191, 142)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 27)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Salir"
        '
        'btnSave
        '
        Appearance28.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance28
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(12, 142)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 27)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Guardar"
        '
        'frmConfigurationEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 177)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConfigurationEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Correo"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPuerto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtRemitente As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtHost As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPuerto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkSSL As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
End Class
