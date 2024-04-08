<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAirplaneDetails
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
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAirplaneDetails))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAirplane = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtPesoVacio = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceTipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPesoMaximo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblPesoMaximo = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTipo = New Infragistics.Win.Misc.UltraLabel()
        Me.txtModelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtDescripcion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblModelo = New Infragistics.Win.Misc.UltraLabel()
        Me.lblDescripcion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbAirplane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAirplane.SuspendLayout()
        CType(Me.txtPesoVacio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPesoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAirplane
        '
        Me.ugbAirplane.Controls.Add(Me.txtPesoVacio)
        Me.ugbAirplane.Controls.Add(Me.UltraLabel1)
        Me.ugbAirplane.Controls.Add(Me.lblAgencia)
        Me.ugbAirplane.Controls.Add(Me.uceAgencia)
        Me.ugbAirplane.Controls.Add(Me.uceTipo)
        Me.ugbAirplane.Controls.Add(Me.uceEstado)
        Me.ugbAirplane.Controls.Add(Me.lblEstado)
        Me.ugbAirplane.Controls.Add(Me.txtMatricula)
        Me.ugbAirplane.Controls.Add(Me.lblMatricula)
        Me.ugbAirplane.Controls.Add(Me.txtPesoMaximo)
        Me.ugbAirplane.Controls.Add(Me.lblPesoMaximo)
        Me.ugbAirplane.Controls.Add(Me.lblTipo)
        Me.ugbAirplane.Controls.Add(Me.txtModelo)
        Me.ugbAirplane.Controls.Add(Me.txtDescripcion)
        Me.ugbAirplane.Controls.Add(Me.lblModelo)
        Me.ugbAirplane.Controls.Add(Me.lblDescripcion)
        Me.ugbAirplane.Controls.Add(Me.btnCancel)
        Me.ugbAirplane.Controls.Add(Me.btnSave)
        Me.ugbAirplane.Location = New System.Drawing.Point(0, 0)
        Me.ugbAirplane.Name = "ugbAirplane"
        Me.ugbAirplane.Size = New System.Drawing.Size(458, 218)
        Me.ugbAirplane.TabIndex = 19
        Me.ugbAirplane.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtPesoVacio
        '
        Me.txtPesoVacio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesoVacio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPesoVacio.Location = New System.Drawing.Point(85, 148)
        Me.txtPesoVacio.Name = "txtPesoVacio"
        Me.txtPesoVacio.Size = New System.Drawing.Size(182, 21)
        Me.txtPesoVacio.TabIndex = 21
        '
        'UltraLabel1
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 150)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(67, 20)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Peso Vacío:"
        '
        'lblAgencia
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance9
        Me.lblAgencia.Location = New System.Drawing.Point(12, 12)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 20
        Me.lblAgencia.Text = "Agencia:"
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(85, 12)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(182, 21)
        Me.uceAgencia.TabIndex = 0
        '
        'uceTipo
        '
        Me.uceTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipo.LimitToList = True
        Me.uceTipo.Location = New System.Drawing.Point(85, 39)
        Me.uceTipo.Name = "uceTipo"
        Me.uceTipo.Size = New System.Drawing.Size(182, 21)
        Me.uceTipo.TabIndex = 6
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(319, 13)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(127, 21)
        Me.uceEstado.TabIndex = 5
        '
        'lblEstado
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance7
        Me.lblEstado.Location = New System.Drawing.Point(273, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(53, 20)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "Estado:"
        '
        'txtMatricula
        '
        Me.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Location = New System.Drawing.Point(85, 175)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(182, 21)
        Me.txtMatricula.TabIndex = 4
        '
        'lblMatricula
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance6
        Me.lblMatricula.Location = New System.Drawing.Point(12, 176)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(60, 20)
        Me.lblMatricula.TabIndex = 15
        Me.lblMatricula.Text = "Matrícula:"
        '
        'txtPesoMaximo
        '
        Me.txtPesoMaximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPesoMaximo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPesoMaximo.Location = New System.Drawing.Point(85, 121)
        Me.txtPesoMaximo.Name = "txtPesoMaximo"
        Me.txtPesoMaximo.Size = New System.Drawing.Size(182, 21)
        Me.txtPesoMaximo.TabIndex = 3
        '
        'lblPesoMaximo
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblPesoMaximo.Appearance = Appearance8
        Me.lblPesoMaximo.Location = New System.Drawing.Point(12, 124)
        Me.lblPesoMaximo.Name = "lblPesoMaximo"
        Me.lblPesoMaximo.Size = New System.Drawing.Size(67, 20)
        Me.lblPesoMaximo.TabIndex = 14
        Me.lblPesoMaximo.Text = "Peso Total:"
        '
        'lblTipo
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblTipo.Appearance = Appearance10
        Me.lblTipo.Location = New System.Drawing.Point(12, 38)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(46, 20)
        Me.lblTipo.TabIndex = 13
        Me.lblTipo.Text = "Tipo:"
        '
        'txtModelo
        '
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtModelo.Location = New System.Drawing.Point(85, 93)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(182, 21)
        Me.txtModelo.TabIndex = 2
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDescripcion.Location = New System.Drawing.Point(85, 66)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(182, 21)
        Me.txtDescripcion.TabIndex = 1
        '
        'lblModelo
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblModelo.Appearance = Appearance11
        Me.lblModelo.Location = New System.Drawing.Point(12, 94)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(60, 20)
        Me.lblModelo.TabIndex = 12
        Me.lblModelo.Text = "Modelo:"
        '
        'lblDescripcion
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblDescripcion.Appearance = Appearance5
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 67)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescripcion.Size = New System.Drawing.Size(67, 20)
        Me.lblDescripcion.TabIndex = 11
        Me.lblDescripcion.Text = "Descripción:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(366, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(273, 161)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 35)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Guardar"
        '
        'frmAirplaneDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 208)
        Me.Controls.Add(Me.ugbAirplane)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAirplaneDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Avión"
        CType(Me.ugbAirplane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAirplane.ResumeLayout(False)
        Me.ugbAirplane.PerformLayout()
        CType(Me.txtPesoVacio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPesoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAirplane As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtModelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDescripcion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblModelo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDescripcion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPesoMaximo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPesoMaximo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTipo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceTipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txtPesoVacio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
