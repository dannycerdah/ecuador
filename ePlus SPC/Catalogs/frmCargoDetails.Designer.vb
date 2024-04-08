<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargoDetails
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargoDetails))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtCargo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblNombreCiudad = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.txtCargo)
        Me.ugbCamion.Controls.Add(Me.lblNombreCiudad)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(383, 108)
        Me.ugbCamion.TabIndex = 20
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtCargo
        '
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCargo.Location = New System.Drawing.Point(15, 38)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(362, 21)
        Me.txtCargo.TabIndex = 0
        '
        'lblNombreCiudad
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblNombreCiudad.Appearance = Appearance9
        Me.lblNombreCiudad.Location = New System.Drawing.Point(15, 12)
        Me.lblNombreCiudad.Name = "lblNombreCiudad"
        Me.lblNombreCiudad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNombreCiudad.Size = New System.Drawing.Size(245, 20)
        Me.lblNombreCiudad.TabIndex = 11
        Me.lblNombreCiudad.Text = "Nombre:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(296, 67)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(15, 65)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Guardar"
        '
        'frmCargoDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 108)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCargoDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Cargo"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtCargo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblNombreCiudad As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
End Class
