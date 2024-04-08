<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContactoAgenciaDetails
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContactoAgenciaDetails))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.uceContacto = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtComentario = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFechaIni = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtFechaFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnNuevoCargo = New Infragistics.Win.Misc.UltraButton()
        Me.uceCargo = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComentario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.uceCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(12, 166)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 35)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Guardar"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(454, 166)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancelar"
        '
        'lblEstado
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance6
        Me.lblEstado.Location = New System.Drawing.Point(12, 14)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(68, 20)
        Me.lblEstado.TabIndex = 20
        Me.lblEstado.Text = "Contacto:"
        '
        'uceContacto
        '
        Me.uceContacto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContacto.LimitToList = True
        Me.uceContacto.Location = New System.Drawing.Point(86, 13)
        Me.uceContacto.Name = "uceContacto"
        Me.uceContacto.Size = New System.Drawing.Size(261, 21)
        Me.uceContacto.TabIndex = 0
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(11, 68)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel1.TabIndex = 22
        Me.UltraLabel1.Text = "Cargo:"
        '
        'UltraLabel5
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.Location = New System.Drawing.Point(11, 98)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel5.TabIndex = 30
        Me.UltraLabel5.Text = "Comentario:"
        '
        'txtComentario
        '
        Me.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtComentario.Location = New System.Drawing.Point(86, 98)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(448, 62)
        Me.txtComentario.TabIndex = 5
        '
        'UltraLabel6
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance4
        Me.UltraLabel6.Location = New System.Drawing.Point(353, 39)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(69, 21)
        Me.UltraLabel6.TabIndex = 32
        Me.UltraLabel6.Text = "Fecha Inicio:"
        '
        'udtFechaIni
        '
        Me.udtFechaIni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFechaIni.Location = New System.Drawing.Point(428, 39)
        Me.udtFechaIni.MaskInput = "dd/mm/yyyy"
        Me.udtFechaIni.Name = "udtFechaIni"
        Me.udtFechaIni.Size = New System.Drawing.Size(106, 21)
        Me.udtFechaIni.TabIndex = 3
        '
        'udtFechaFin
        '
        Me.udtFechaFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFechaFin.Location = New System.Drawing.Point(428, 67)
        Me.udtFechaFin.MaskInput = "dd/mm/yyyy"
        Me.udtFechaFin.Name = "udtFechaFin"
        Me.udtFechaFin.Size = New System.Drawing.Size(106, 21)
        Me.udtFechaFin.TabIndex = 4
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.btnNuevoCargo)
        Me.ugbContactoAgencia.Controls.Add(Me.uceCargo)
        Me.ugbContactoAgencia.Controls.Add(Me.uceAgencia)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel4)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel3)
        Me.ugbContactoAgencia.Controls.Add(Me.uceEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel2)
        Me.ugbContactoAgencia.Controls.Add(Me.udtFechaFin)
        Me.ugbContactoAgencia.Controls.Add(Me.udtFechaIni)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel6)
        Me.ugbContactoAgencia.Controls.Add(Me.txtComentario)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel5)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel1)
        Me.ugbContactoAgencia.Controls.Add(Me.uceContacto)
        Me.ugbContactoAgencia.Controls.Add(Me.lblEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.btnCancel)
        Me.ugbContactoAgencia.Controls.Add(Me.btnSave)
        Me.ugbContactoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbContactoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbContactoAgencia.Name = "ugbContactoAgencia"
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(548, 211)
        Me.ugbContactoAgencia.TabIndex = 19
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnNuevoCargo
        '
        Appearance7.Image = Global.SPC.My.Resources.Resources.list16x16
        Me.btnNuevoCargo.Appearance = Appearance7
        Me.btnNuevoCargo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnNuevoCargo.Location = New System.Drawing.Point(320, 66)
        Me.btnNuevoCargo.Name = "btnNuevoCargo"
        Me.btnNuevoCargo.Size = New System.Drawing.Size(27, 26)
        Me.btnNuevoCargo.TabIndex = 42
        Me.btnNuevoCargo.Text = "Nuevo"
        '
        'uceCargo
        '
        Me.uceCargo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceCargo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceCargo.LimitToList = True
        Me.uceCargo.Location = New System.Drawing.Point(86, 67)
        Me.uceCargo.Name = "uceCargo"
        Me.uceCargo.Size = New System.Drawing.Size(228, 21)
        Me.uceCargo.TabIndex = 40
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(86, 40)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(261, 21)
        Me.uceAgencia.TabIndex = 38
        '
        'UltraLabel4
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance3
        Me.UltraLabel4.Location = New System.Drawing.Point(12, 40)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(68, 20)
        Me.UltraLabel4.TabIndex = 39
        Me.UltraLabel4.Text = "Compañia:"
        '
        'UltraLabel3
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.Location = New System.Drawing.Point(353, 67)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(69, 21)
        Me.UltraLabel3.TabIndex = 37
        Me.UltraLabel3.Text = "Fecha Fin:"
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(428, 12)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(106, 21)
        Me.uceEstado.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(353, 14)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'frmContactoAgenciaDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 211)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmContactoAgenciaDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Agencia/Contacto"
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComentario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        Me.ugbContactoAgencia.PerformLayout()
        CType(Me.uceCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceContacto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtComentario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFechaIni As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFechaFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceCargo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnNuevoCargo As Infragistics.Win.Misc.UltraButton
End Class
