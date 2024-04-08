<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamionDetails
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
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCamionDetails))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceContacto = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.txtDescripcion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDescripcion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox1)
        Me.ugbCamion.Controls.Add(Me.txtMatricula)
        Me.ugbCamion.Controls.Add(Me.lblMatricula)
        Me.ugbCamion.Controls.Add(Me.uceAgencia)
        Me.ugbCamion.Controls.Add(Me.uceEstado)
        Me.ugbCamion.Controls.Add(Me.lblEstado)
        Me.ugbCamion.Controls.Add(Me.lblAgencia)
        Me.ugbCamion.Controls.Add(Me.txtDescripcion)
        Me.ugbCamion.Controls.Add(Me.lblDescripcion)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Location = New System.Drawing.Point(-1, -2)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(339, 237)
        Me.ugbCamion.TabIndex = 19
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.uceContacto)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(13, 120)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(310, 70)
        Me.UltraGroupBox1.TabIndex = 52
        Me.UltraGroupBox1.Text = "Contacto propietario del camión"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceContacto
        '
        Me.uceContacto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContacto.LimitToList = True
        Me.uceContacto.Location = New System.Drawing.Point(79, 30)
        Me.uceContacto.Name = "uceContacto"
        Me.uceContacto.Size = New System.Drawing.Size(225, 21)
        Me.uceContacto.TabIndex = 30
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Location = New System.Drawing.Point(3, 29)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(63, 20)
        Me.UltraLabel1.TabIndex = 31
        Me.UltraLabel1.Text = "Contacto:"
        '
        'txtMatricula
        '
        Me.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Location = New System.Drawing.Point(92, 19)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(113, 21)
        Me.txtMatricula.TabIndex = 1
        '
        'lblMatricula
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance8
        Me.lblMatricula.Location = New System.Drawing.Point(19, 19)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(60, 20)
        Me.lblMatricula.TabIndex = 20
        Me.lblMatricula.Text = "Matrícula:"
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(92, 67)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(227, 21)
        Me.uceAgencia.TabIndex = 3
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(92, 93)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(113, 21)
        Me.uceEstado.TabIndex = 4
        '
        'lblEstado
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance4
        Me.lblEstado.Location = New System.Drawing.Point(19, 93)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(52, 20)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "Estado:"
        '
        'lblAgencia
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance10
        Me.lblAgencia.Location = New System.Drawing.Point(19, 67)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 13
        Me.lblAgencia.Text = "Agencia:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescripcion.Location = New System.Drawing.Point(92, 43)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(227, 21)
        Me.txtDescripcion.TabIndex = 2
        '
        'lblDescripcion
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblDescripcion.Appearance = Appearance9
        Me.lblDescripcion.Location = New System.Drawing.Point(19, 43)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescripcion.Size = New System.Drawing.Size(71, 20)
        Me.lblDescripcion.TabIndex = 11
        Me.lblDescripcion.Text = "Descripción:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(242, 196)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance5.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance5
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(13, 196)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Guardar"
        '
        'frmCamionDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 234)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCamionDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle del Camión"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtDescripcion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblDescripcion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceContacto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
