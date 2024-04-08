<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckUserManager
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtkey = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtUsuario = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtkey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.SPC.My.Resources.Resources.age_seguridad
        Me.PictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(256, 256)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'txtkey
        '
        Appearance5.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance5.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance5.BorderColor = System.Drawing.Color.CornflowerBlue
        Appearance5.BorderColor2 = System.Drawing.Color.CornflowerBlue
        Me.txtkey.Appearance = Appearance5
        Me.txtkey.BackColor = System.Drawing.Color.CornflowerBlue
        Me.txtkey.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtkey.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkey.Location = New System.Drawing.Point(33, 173)
        Me.txtkey.Name = "txtkey"
        Me.txtkey.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtkey.Size = New System.Drawing.Size(10, 9)
        Me.txtkey.TabIndex = 8
        '
        'UltraGroupBox1
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.Controls.Add(Me.txtUsuario)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraGroupBox1.HeaderAppearance = Appearance2
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(274, 6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(194, 30)
        Me.UltraGroupBox1.TabIndex = 13
        Me.UltraGroupBox1.Text = "Usuario:"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtUsuario.Location = New System.Drawing.Point(78, 4)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(110, 21)
        Me.txtUsuario.TabIndex = 0
        '
        'UltraGroupBox2
        '
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraGroupBox2.Appearance = Appearance3
        Me.UltraGroupBox2.Controls.Add(Me.txtClave)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraGroupBox2.HeaderAppearance = Appearance4
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(274, 42)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(194, 30)
        Me.UltraGroupBox2.TabIndex = 14
        Me.UltraGroupBox2.Text = "Contraseña:"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtClave.Location = New System.Drawing.Point(78, 4)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(110, 21)
        Me.txtClave.TabIndex = 1
        '
        'frmCheckUserManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(475, 267)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtkey)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckUserManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtkey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtkey As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtUsuario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
