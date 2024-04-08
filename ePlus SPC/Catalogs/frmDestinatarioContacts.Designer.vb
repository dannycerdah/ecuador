<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDestinatarioContacts
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDestinatarioContacts))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceContacto = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceReporte = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCorreo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDescripcion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.uceContacto)
        Me.ugbCamion.Controls.Add(Me.uceReporte)
        Me.ugbCamion.Controls.Add(Me.uceAgencia)
        Me.ugbCamion.Controls.Add(Me.UltraLabel1)
        Me.ugbCamion.Controls.Add(Me.lblMatricula)
        Me.ugbCamion.Controls.Add(Me.uceEstado)
        Me.ugbCamion.Controls.Add(Me.lblEstado)
        Me.ugbCamion.Controls.Add(Me.lblAgencia)
        Me.ugbCamion.Controls.Add(Me.txtCorreo)
        Me.ugbCamion.Controls.Add(Me.lblDescripcion)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(392, 190)
        Me.ugbCamion.TabIndex = 20
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceContacto
        '
        Me.uceContacto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContacto.LimitToList = True
        Me.uceContacto.Location = New System.Drawing.Point(91, 66)
        Me.uceContacto.Name = "uceContacto"
        Me.uceContacto.Size = New System.Drawing.Size(288, 21)
        Me.uceContacto.TabIndex = 2
        '
        'uceReporte
        '
        Me.uceReporte.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceReporte.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceReporte.LimitToList = True
        Me.uceReporte.Location = New System.Drawing.Point(91, 10)
        Me.uceReporte.Name = "uceReporte"
        Me.uceReporte.Size = New System.Drawing.Size(148, 21)
        Me.uceReporte.TabIndex = 34
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(91, 39)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(288, 21)
        Me.uceAgencia.TabIndex = 33
        '
        'UltraLabel1
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(73, 20)
        Me.UltraLabel1.TabIndex = 31
        Me.UltraLabel1.Text = "Contacto:"
        '
        'lblMatricula
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance8
        Me.lblMatricula.Enabled = False
        Me.lblMatricula.Location = New System.Drawing.Point(11, 11)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(74, 20)
        Me.lblMatricula.TabIndex = 20
        Me.lblMatricula.Text = "Reporte:"
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(91, 118)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(148, 21)
        Me.uceEstado.TabIndex = 5
        '
        'lblEstado
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance7
        Me.lblEstado.Location = New System.Drawing.Point(33, 118)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(52, 20)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "Estado:"
        '
        'lblAgencia
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance11
        Me.lblAgencia.Enabled = False
        Me.lblAgencia.Location = New System.Drawing.Point(11, 40)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(74, 20)
        Me.lblAgencia.TabIndex = 13
        Me.lblAgencia.Text = "Compañia:"
        '
        'txtCorreo
        '
        Me.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCorreo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCorreo.Location = New System.Drawing.Point(91, 91)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(288, 21)
        Me.txtCorreo.TabIndex = 4
        '
        'lblDescripcion
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblDescripcion.Appearance = Appearance12
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 92)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescripcion.Size = New System.Drawing.Size(73, 20)
        Me.lblDescripcion.TabIndex = 11
        Me.lblDescripcion.Text = "Correo:"
        '
        'btnCancel
        '
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.btnCancel.Appearance = Appearance13
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(298, 145)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance14.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance14
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(12, 145)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 35)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Guardar"
        '
        'frmDestinatarioContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 190)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDestinatarioContacts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Contacto/Destinatario"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceContacto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCorreo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblDescripcion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceReporte As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
