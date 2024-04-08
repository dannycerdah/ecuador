<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaisDetails
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
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaisDetails))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtNacionalidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNacionalidad = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCodigo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblPais = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPais = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCodigo = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.txtNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.txtNacionalidad)
        Me.ugbCamion.Controls.Add(Me.lblNacionalidad)
        Me.ugbCamion.Controls.Add(Me.txtCodigo)
        Me.ugbCamion.Controls.Add(Me.lblPais)
        Me.ugbCamion.Controls.Add(Me.txtPais)
        Me.ugbCamion.Controls.Add(Me.lblCodigo)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Location = New System.Drawing.Point(-4, -4)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(321, 161)
        Me.ugbCamion.TabIndex = 19
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtNacionalidad
        '
        Me.txtNacionalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNacionalidad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNacionalidad.Location = New System.Drawing.Point(99, 65)
        Me.txtNacionalidad.Name = "txtNacionalidad"
        Me.txtNacionalidad.Size = New System.Drawing.Size(198, 21)
        Me.txtNacionalidad.TabIndex = 2
        '
        'lblNacionalidad
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblNacionalidad.Appearance = Appearance9
        Me.lblNacionalidad.Location = New System.Drawing.Point(15, 65)
        Me.lblNacionalidad.Name = "lblNacionalidad"
        Me.lblNacionalidad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNacionalidad.Size = New System.Drawing.Size(78, 20)
        Me.lblNacionalidad.TabIndex = 17
        Me.lblNacionalidad.Text = "Nacionalidad:"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCodigo.Location = New System.Drawing.Point(99, 38)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(198, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'lblPais
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblPais.Appearance = Appearance6
        Me.lblPais.Location = New System.Drawing.Point(15, 13)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(60, 20)
        Me.lblPais.TabIndex = 15
        Me.lblPais.Text = "País:"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPais.Location = New System.Drawing.Point(99, 12)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(198, 21)
        Me.txtPais.TabIndex = 0
        '
        'lblCodigo
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblCodigo.Appearance = Appearance3
        Me.lblCodigo.Location = New System.Drawing.Point(15, 39)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCodigo.Size = New System.Drawing.Size(60, 20)
        Me.lblCodigo.TabIndex = 11
        Me.lblCodigo.Text = "Codigo:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(171, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(71, 103)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Guardar"
        '
        'frmPaisDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 150)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPaisDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle País"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.txtNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtPais As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblPais As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNacionalidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNacionalidad As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCodigo As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
