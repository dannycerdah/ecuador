<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchivo
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivo))
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnSubir = New Infragistics.Win.Misc.UltraButton()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescripcion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSelectArchivo = New Infragistics.Win.Misc.UltraButton()
        Me.txtRuta = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.btnSubir)
        Me.UltraGroupBox2.Controls.Add(Me.picImagen)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox2.Controls.Add(Me.txtDescripcion)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox2.Controls.Add(Me.btnSelectArchivo)
        Me.UltraGroupBox2.Controls.Add(Me.txtRuta)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(-3, -3)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(336, 383)
        Me.UltraGroupBox2.TabIndex = 21
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnSubir
        '
        Appearance18.Image = CType(resources.GetObject("Appearance18.Image"), Object)
        Me.btnSubir.Appearance = Appearance18
        Me.btnSubir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSubir.Location = New System.Drawing.Point(16, 340)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(97, 26)
        Me.btnSubir.TabIndex = 20
        Me.btnSubir.Text = "Subir archivo"
        '
        'picImagen
        '
        Me.picImagen.BackColor = System.Drawing.Color.Transparent
        Me.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImagen.Location = New System.Drawing.Point(16, 73)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(297, 181)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 21
        Me.picImagen.TabStop = False
        '
        'UltraLabel9
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance16
        Me.UltraLabel9.Location = New System.Drawing.Point(16, 53)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel9.Size = New System.Drawing.Size(91, 20)
        Me.UltraLabel9.TabIndex = 20
        Me.UltraLabel9.Text = "Visor de imagen:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescripcion.Location = New System.Drawing.Point(16, 280)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(297, 51)
        Me.txtDescripcion.TabIndex = 17
        '
        'UltraLabel8
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance1
        Me.UltraLabel8.Location = New System.Drawing.Point(16, 260)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel8.Size = New System.Drawing.Size(125, 20)
        Me.UltraLabel8.TabIndex = 18
        Me.UltraLabel8.Text = "Descripción del archivo:"
        '
        'btnSelectArchivo
        '
        Me.btnSelectArchivo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSelectArchivo.Location = New System.Drawing.Point(281, 25)
        Me.btnSelectArchivo.Name = "btnSelectArchivo"
        Me.btnSelectArchivo.Size = New System.Drawing.Size(32, 23)
        Me.btnSelectArchivo.TabIndex = 14
        Me.btnSelectArchivo.Text = "..."
        '
        'txtRuta
        '
        Me.txtRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRuta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtRuta.Location = New System.Drawing.Point(16, 26)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(259, 21)
        Me.txtRuta.TabIndex = 12
        '
        'UltraLabel1
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance10
        Me.UltraLabel1.Location = New System.Drawing.Point(16, 6)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(172, 20)
        Me.UltraLabel1.TabIndex = 13
        Me.UltraLabel1.Text = "Ruta del arrchivo:"
        '
        'frmArchivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 375)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmArchivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Biblioteca"
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSubir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtDescripcion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnSelectArchivo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtRuta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
