<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElegirPersonalProceso
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
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElegirPersonalProceso))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ucePersonalAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ucePersonalAgenciaCarga = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.uceSeguridad = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.ucePersonalAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucePersonalAgenciaCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceSeguridad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.uceSeguridad)
        Me.ugbCamion.Controls.Add(Me.UltraLabel1)
        Me.ugbCamion.Controls.Add(Me.ucePersonalAerolinea)
        Me.ugbCamion.Controls.Add(Me.ucePersonalAgenciaCarga)
        Me.ugbCamion.Controls.Add(Me.lblEstado)
        Me.ugbCamion.Controls.Add(Me.lblAgencia)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Location = New System.Drawing.Point(-3, -4)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(278, 245)
        Me.ugbCamion.TabIndex = 19
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ucePersonalAerolinea
        '
        Me.ucePersonalAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePersonalAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePersonalAerolinea.LimitToList = True
        Me.ucePersonalAerolinea.Location = New System.Drawing.Point(15, 36)
        Me.ucePersonalAerolinea.Name = "ucePersonalAerolinea"
        Me.ucePersonalAerolinea.Size = New System.Drawing.Size(251, 21)
        Me.ucePersonalAerolinea.TabIndex = 1
        '
        'ucePersonalAgenciaCarga
        '
        Me.ucePersonalAgenciaCarga.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePersonalAgenciaCarga.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePersonalAgenciaCarga.LimitToList = True
        Me.ucePersonalAgenciaCarga.Location = New System.Drawing.Point(15, 98)
        Me.ucePersonalAgenciaCarga.Name = "ucePersonalAgenciaCarga"
        Me.ucePersonalAgenciaCarga.Size = New System.Drawing.Size(251, 21)
        Me.ucePersonalAgenciaCarga.TabIndex = 2
        '
        'lblEstado
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance3
        Me.lblEstado.Location = New System.Drawing.Point(15, 79)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(180, 20)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "Personal Agencia de Carga:"
        '
        'lblAgencia
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance10
        Me.lblAgencia.Location = New System.Drawing.Point(15, 16)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(116, 20)
        Me.lblAgencia.TabIndex = 13
        Me.lblAgencia.Text = "Personal Aerolinea:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(150, 196)
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
        Me.btnSave.Location = New System.Drawing.Point(50, 196)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Guardar"
        '
        'uceSeguridad
        '
        Me.uceSeguridad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceSeguridad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceSeguridad.LimitToList = True
        Me.uceSeguridad.Location = New System.Drawing.Point(15, 160)
        Me.uceSeguridad.Name = "uceSeguridad"
        Me.uceSeguridad.Size = New System.Drawing.Size(251, 21)
        Me.uceSeguridad.TabIndex = 19
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Location = New System.Drawing.Point(15, 141)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(180, 20)
        Me.UltraLabel1.TabIndex = 20
        Me.UltraLabel1.Text = "Personal Agencia de Seguriad:"
        '
        'frmElegirPersonalProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 239)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmElegirPersonalProceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle Dolly"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.ucePersonalAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucePersonalAgenciaCarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceSeguridad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucePersonalAgenciaCarga As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucePersonalAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceSeguridad As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
