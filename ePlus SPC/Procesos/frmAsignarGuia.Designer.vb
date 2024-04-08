<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarGuia
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignarGuia))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvGuias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtPara = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtDe = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblPara = New Infragistics.Win.Misc.UltraLabel()
        Me.lblDe = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblFecha = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAvion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNumVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtAgencia = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.lblVuelo = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugvGuias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.txtPara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugbAgencia.Controls.Add(Me.ugvGuias)
        Me.ugbAgencia.Location = New System.Drawing.Point(3, 88)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(838, 295)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvGuias
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Me.ugvGuias.DisplayLayout.Appearance = Appearance4
        Me.ugvGuias.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvGuias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvGuias.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.ugvGuias.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Me.ugvGuias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvGuias.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugvGuias.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvGuias.DisplayLayout.Override.RowSelectorAppearance = Appearance8
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvGuias.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugvGuias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvGuias.Location = New System.Drawing.Point(3, 0)
        Me.ugvGuias.Name = "ugvGuias"
        Me.ugvGuias.Size = New System.Drawing.Size(832, 292)
        Me.ugvGuias.TabIndex = 3
        Me.ugvGuias.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.txtPara)
        Me.ugbDatosVuelo.Controls.Add(Me.txtDe)
        Me.ugbDatosVuelo.Controls.Add(Me.lblPara)
        Me.ugbDatosVuelo.Controls.Add(Me.lblDe)
        Me.ugbDatosVuelo.Controls.Add(Me.txtAvion)
        Me.ugbDatosVuelo.Controls.Add(Me.udtFecha)
        Me.ugbDatosVuelo.Controls.Add(Me.lblFecha)
        Me.ugbDatosVuelo.Controls.Add(Me.lblAvion)
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsultar)
        Me.ugbDatosVuelo.Controls.Add(Me.txtMatricula)
        Me.ugbDatosVuelo.Controls.Add(Me.txtNumVuelo)
        Me.ugbDatosVuelo.Controls.Add(Me.txtAgencia)
        Me.ugbDatosVuelo.Controls.Add(Me.lblMatricula)
        Me.ugbDatosVuelo.Controls.Add(Me.lblVuelo)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(841, 89)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.Text = "Datos de Vuelo"
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtPara
        '
        Me.txtPara.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPara.Location = New System.Drawing.Point(581, 54)
        Me.txtPara.Name = "txtPara"
        Me.txtPara.ReadOnly = True
        Me.txtPara.Size = New System.Drawing.Size(245, 21)
        Me.txtPara.TabIndex = 17
        '
        'txtDe
        '
        Me.txtDe.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDe.Location = New System.Drawing.Point(581, 27)
        Me.txtDe.Name = "txtDe"
        Me.txtDe.ReadOnly = True
        Me.txtDe.Size = New System.Drawing.Size(245, 21)
        Me.txtDe.TabIndex = 16
        '
        'lblPara
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Right"
        Appearance18.TextVAlignAsString = "Middle"
        Me.lblPara.Appearance = Appearance18
        Me.lblPara.Location = New System.Drawing.Point(506, 55)
        Me.lblPara.Name = "lblPara"
        Me.lblPara.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPara.Size = New System.Drawing.Size(60, 20)
        Me.lblPara.TabIndex = 15
        Me.lblPara.Text = "Para:"
        '
        'lblDe
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblDe.Appearance = Appearance10
        Me.lblDe.Location = New System.Drawing.Point(506, 28)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDe.Size = New System.Drawing.Size(60, 20)
        Me.lblDe.TabIndex = 14
        Me.lblDe.Text = "De:"
        '
        'txtAvion
        '
        Me.txtAvion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAvion.Enabled = False
        Me.txtAvion.Location = New System.Drawing.Point(378, 28)
        Me.txtAvion.Name = "txtAvion"
        Me.txtAvion.ReadOnly = True
        Me.txtAvion.Size = New System.Drawing.Size(114, 21)
        Me.txtAvion.TabIndex = 13
        '
        'udtFecha
        '
        Me.udtFecha.DateTime = New Date(2014, 6, 6, 0, 0, 0, 0)
        Me.udtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFecha.Location = New System.Drawing.Point(378, 53)
        Me.udtFecha.MaskInput = "dd/mm/yyyy"
        Me.udtFecha.Name = "udtFecha"
        Me.udtFecha.ReadOnly = True
        Me.udtFecha.Size = New System.Drawing.Size(114, 21)
        Me.udtFecha.TabIndex = 12
        Me.udtFecha.Value = New Date(2014, 6, 6, 0, 0, 0, 0)
        '
        'lblFecha
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Appearance19.TextVAlignAsString = "Middle"
        Me.lblFecha.Appearance = Appearance19
        Me.lblFecha.Location = New System.Drawing.Point(298, 55)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFecha.Size = New System.Drawing.Size(60, 20)
        Me.lblFecha.TabIndex = 11
        Me.lblFecha.Text = "Fecha:"
        '
        'lblAvion
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.lblAvion.Appearance = Appearance11
        Me.lblAvion.Location = New System.Drawing.Point(298, 28)
        Me.lblAvion.Name = "lblAvion"
        Me.lblAvion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAvion.Size = New System.Drawing.Size(60, 20)
        Me.lblAvion.TabIndex = 10
        Me.lblAvion.Text = "Avion:"
        '
        'btnConsultar
        '
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        Me.btnConsultar.Appearance = Appearance9
        Me.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultar.Location = New System.Drawing.Point(264, 24)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 24)
        Me.btnConsultar.TabIndex = 9
        '
        'txtMatricula
        '
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Enabled = False
        Me.txtMatricula.Location = New System.Drawing.Point(79, 54)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.ReadOnly = True
        Me.txtMatricula.Size = New System.Drawing.Size(101, 21)
        Me.txtMatricula.TabIndex = 7
        '
        'txtNumVuelo
        '
        Me.txtNumVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNumVuelo.Enabled = False
        Me.txtNumVuelo.Location = New System.Drawing.Point(161, 27)
        Me.txtNumVuelo.Name = "txtNumVuelo"
        Me.txtNumVuelo.ReadOnly = True
        Me.txtNumVuelo.Size = New System.Drawing.Size(91, 21)
        Me.txtNumVuelo.TabIndex = 6
        '
        'txtAgencia
        '
        Me.txtAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAgencia.Enabled = False
        Me.txtAgencia.Location = New System.Drawing.Point(78, 27)
        Me.txtAgencia.Name = "txtAgencia"
        Me.txtAgencia.ReadOnly = True
        Me.txtAgencia.Size = New System.Drawing.Size(77, 21)
        Me.txtAgencia.TabIndex = 5
        '
        'lblMatricula
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance13
        Me.lblMatricula.Location = New System.Drawing.Point(13, 54)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMatricula.Size = New System.Drawing.Size(60, 20)
        Me.lblMatricula.TabIndex = 4
        Me.lblMatricula.Text = "Matricula:"
        '
        'lblVuelo
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblVuelo.Appearance = Appearance12
        Me.lblVuelo.Location = New System.Drawing.Point(12, 28)
        Me.lblVuelo.Name = "lblVuelo"
        Me.lblVuelo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVuelo.Size = New System.Drawing.Size(60, 20)
        Me.lblVuelo.TabIndex = 3
        Me.lblVuelo.Text = "Vuelo:"
        '
        'frmAsignarGuia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 384)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAsignarGuia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Guía"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugvGuias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.txtPara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvGuias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtPara As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDe As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblPara As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDe As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents udtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblFecha As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAvion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNumVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtAgencia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblVuelo As Infragistics.Win.Misc.UltraLabel
End Class
