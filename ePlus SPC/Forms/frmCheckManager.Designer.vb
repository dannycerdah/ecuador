<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckManager
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtkey = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtkey, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'UltraLabel1
        '
        Appearance2.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(274, 6)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(196, 48)
        Me.UltraLabel1.TabIndex = 7
        Me.UltraLabel1.Text = "Por favor ingrese contraseña"
        '
        'txtkey
        '
        Appearance1.BackColor = System.Drawing.Color.CornflowerBlue
        Appearance1.BackColor2 = System.Drawing.Color.CornflowerBlue
        Appearance1.BorderColor = System.Drawing.Color.CornflowerBlue
        Appearance1.BorderColor2 = System.Drawing.Color.CornflowerBlue
        Me.txtkey.Appearance = Appearance1
        Me.txtkey.BackColor = System.Drawing.Color.CornflowerBlue
        Me.txtkey.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtkey.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkey.Location = New System.Drawing.Point(33, 173)
        Me.txtkey.Name = "txtkey"
        Me.txtkey.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtkey.Size = New System.Drawing.Size(10, 9)
        Me.txtkey.TabIndex = 8
        '
        'frmCheckManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(475, 267)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtkey)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtkey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtkey As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
