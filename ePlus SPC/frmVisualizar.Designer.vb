<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizar
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.picImagen_01 = New System.Windows.Forms.PictureBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.PictureCamara = New System.Windows.Forms.PictureBox()
        Me.iniciar = New System.Windows.Forms.Button()
        Me.chkRemplaza = New System.Windows.Forms.CheckBox()
        CType(Me.picImagen_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureCamara, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 290)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Grabar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'picImagen_01
        '
        Me.picImagen_01.AccessibleDescription = ""
        Me.picImagen_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImagen_01.Location = New System.Drawing.Point(250, 12)
        Me.picImagen_01.Name = "picImagen_01"
        Me.picImagen_01.Size = New System.Drawing.Size(220, 272)
        Me.picImagen_01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen_01.TabIndex = 2
        Me.picImagen_01.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(157, 290)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Capturar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'PictureCamara
        '
        Me.PictureCamara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureCamara.InitialImage = Nothing
        Me.PictureCamara.Location = New System.Drawing.Point(12, 12)
        Me.PictureCamara.Name = "PictureCamara"
        Me.PictureCamara.Size = New System.Drawing.Size(220, 272)
        Me.PictureCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureCamara.TabIndex = 4
        Me.PictureCamara.TabStop = False
        '
        'iniciar
        '
        Me.iniciar.Location = New System.Drawing.Point(85, 290)
        Me.iniciar.Name = "iniciar"
        Me.iniciar.Size = New System.Drawing.Size(75, 23)
        Me.iniciar.TabIndex = 5
        Me.iniciar.Text = "Camara"
        Me.iniciar.UseVisualStyleBackColor = True
        '
        'chkRemplaza
        '
        Me.chkRemplaza.AutoSize = True
        Me.chkRemplaza.Location = New System.Drawing.Point(285, 294)
        Me.chkRemplaza.Name = "chkRemplaza"
        Me.chkRemplaza.Size = New System.Drawing.Size(106, 17)
        Me.chkRemplaza.TabIndex = 6
        Me.chkRemplaza.Text = "Reemplazar Foto"
        Me.chkRemplaza.UseVisualStyleBackColor = True
        '
        'frmVisualizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 319)
        Me.Controls.Add(Me.chkRemplaza)
        Me.Controls.Add(Me.iniciar)
        Me.Controls.Add(Me.PictureCamara)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.picImagen_01)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmVisualizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualización"
        CType(Me.picImagen_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureCamara, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents picImagen_01 As System.Windows.Forms.PictureBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents PictureCamara As System.Windows.Forms.PictureBox
    Friend WithEvents iniciar As System.Windows.Forms.Button
    Friend WithEvents chkRemplaza As System.Windows.Forms.CheckBox
End Class
