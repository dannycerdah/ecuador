<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCiudadDetails
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
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCiudadDetails))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ucePais = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblPais = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCiudad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNombreCiudad = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.ucePais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.ucePais)
        Me.ugbCamion.Controls.Add(Me.lblPais)
        Me.ugbCamion.Controls.Add(Me.txtCiudad)
        Me.ugbCamion.Controls.Add(Me.lblNombreCiudad)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Location = New System.Drawing.Point(-3, -3)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(201, 147)
        Me.ugbCamion.TabIndex = 19
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ucePais
        '
        Me.ucePais.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePais.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePais.LimitToList = True
        Me.ucePais.Location = New System.Drawing.Point(12, 65)
        Me.ucePais.Name = "ucePais"
        Me.ucePais.Size = New System.Drawing.Size(177, 21)
        Me.ucePais.TabIndex = 1
        '
        'lblPais
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblPais.Appearance = Appearance6
        Me.lblPais.Location = New System.Drawing.Point(12, 49)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(60, 20)
        Me.lblPais.TabIndex = 15
        Me.lblPais.Text = "País:"
        '
        'txtCiudad
        '
        Me.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCiudad.Location = New System.Drawing.Point(12, 28)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(177, 21)
        Me.txtCiudad.TabIndex = 0
        '
        'lblNombreCiudad
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblNombreCiudad.Appearance = Appearance9
        Me.lblNombreCiudad.Location = New System.Drawing.Point(12, 12)
        Me.lblNombreCiudad.Name = "lblNombreCiudad"
        Me.lblNombreCiudad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNombreCiudad.Size = New System.Drawing.Size(86, 20)
        Me.lblNombreCiudad.TabIndex = 11
        Me.lblNombreCiudad.Text = "Ciudad:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(108, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(14, 96)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Guardar"
        '
        'frmCiudadDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(196, 140)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCiudadDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle Ciudad"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.ucePais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtCiudad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNombreCiudad As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblPais As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucePais As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
