<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDestinatarioDetails
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDestinatarioDetails))
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdDestinatarios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.uceReporte = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceContacto = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblEstado = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCorreo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblDescripcion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugdDestinatarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox1)
        Me.ugbCamion.Controls.Add(Me.uceReporte)
        Me.ugbCamion.Controls.Add(Me.uceContacto)
        Me.ugbCamion.Controls.Add(Me.lblMatricula)
        Me.ugbCamion.Controls.Add(Me.uceAgencia)
        Me.ugbCamion.Controls.Add(Me.uceEstado)
        Me.ugbCamion.Controls.Add(Me.lblEstado)
        Me.ugbCamion.Controls.Add(Me.lblAgencia)
        Me.ugbCamion.Controls.Add(Me.txtCorreo)
        Me.ugbCamion.Controls.Add(Me.lblDescripcion)
        Me.ugbCamion.Controls.Add(Me.btnCancel)
        Me.ugbCamion.Controls.Add(Me.btnSave)
        Me.ugbCamion.Location = New System.Drawing.Point(0, 1)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(867, 531)
        Me.ugbCamion.TabIndex = 19
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ugdDestinatarios)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(840, 457)
        Me.UltraGroupBox1.TabIndex = 20
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdDestinatarios
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdDestinatarios.DisplayLayout.Appearance = Appearance1
        Me.ugdDestinatarios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdDestinatarios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdDestinatarios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdDestinatarios.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdDestinatarios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdDestinatarios.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdDestinatarios.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDestinatarios.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdDestinatarios.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdDestinatarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdDestinatarios.Location = New System.Drawing.Point(3, 0)
        Me.ugdDestinatarios.Name = "ugdDestinatarios"
        Me.ugdDestinatarios.Size = New System.Drawing.Size(834, 454)
        Me.ugdDestinatarios.TabIndex = 7
        Me.ugdDestinatarios.Text = "CORREOS DE DESTINATARIOS"
        '
        'uceReporte
        '
        Me.uceReporte.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceReporte.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceReporte.Enabled = False
        Me.uceReporte.LimitToList = True
        Me.uceReporte.Location = New System.Drawing.Point(81, 15)
        Me.uceReporte.Name = "uceReporte"
        Me.uceReporte.Size = New System.Drawing.Size(228, 21)
        Me.uceReporte.TabIndex = 32
        '
        'uceContacto
        '
        Me.uceContacto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContacto.LimitToList = True
        Me.uceContacto.Location = New System.Drawing.Point(216, 569)
        Me.uceContacto.Name = "uceContacto"
        Me.uceContacto.Size = New System.Drawing.Size(199, 21)
        Me.uceContacto.TabIndex = 30
        '
        'lblMatricula
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance8
        Me.lblMatricula.Location = New System.Drawing.Point(15, 15)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(60, 20)
        Me.lblMatricula.TabIndex = 20
        Me.lblMatricula.Text = "Reporte:"
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.Enabled = False
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(81, 41)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(300, 21)
        Me.uceAgencia.TabIndex = 3
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(335, 538)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(80, 21)
        Me.uceEstado.TabIndex = 4
        '
        'lblEstado
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblEstado.Appearance = Appearance7
        Me.lblEstado.Location = New System.Drawing.Point(277, 538)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblEstado.Size = New System.Drawing.Size(52, 20)
        Me.lblEstado.TabIndex = 18
        Me.lblEstado.Text = "Estado:"
        '
        'lblAgencia
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance11
        Me.lblAgencia.Location = New System.Drawing.Point(15, 41)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 13
        Me.lblAgencia.Text = "Compañia:"
        '
        'txtCorreo
        '
        Me.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCorreo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCorreo.Location = New System.Drawing.Point(216, 596)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(198, 21)
        Me.txtCorreo.TabIndex = 2
        '
        'lblDescripcion
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblDescripcion.Appearance = Appearance12
        Me.lblDescripcion.Location = New System.Drawing.Point(103, 596)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDescripcion.Size = New System.Drawing.Size(107, 20)
        Me.lblDescripcion.TabIndex = 11
        Me.lblDescripcion.Text = "Correo Destinatario:"
        '
        'btnCancel
        '
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.btnCancel.Appearance = Appearance13
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(108, 555)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.btnSave.Appearance = Appearance14
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(8, 555)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Guardar"
        '
        'frmDestinatarioDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 525)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDestinatarioDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Destinatarios"
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        Me.ugbCamion.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugdDestinatarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtCorreo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblDescripcion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblEstado As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceContacto As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceReporte As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdDestinatarios As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
