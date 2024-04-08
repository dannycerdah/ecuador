<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaElementos
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaElementos))
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvElementos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbAerolinea = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceTipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtElemento = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAerolinea.SuspendLayout()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.ugvElementos)
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 101)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(880, 301)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvElementos
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugvElementos.DisplayLayout.Appearance = Appearance1
        Me.ugvElementos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvElementos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvElementos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugvElementos.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugvElementos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvElementos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugvElementos.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvElementos.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvElementos.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugvElementos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvElementos.Location = New System.Drawing.Point(3, 0)
        Me.ugvElementos.Name = "ugvElementos"
        Me.ugvElementos.Size = New System.Drawing.Size(874, 298)
        Me.ugvElementos.TabIndex = 3
        Me.ugvElementos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ugbAerolinea
        '
        Me.ugbAerolinea.Controls.Add(Me.UltraLabel1)
        Me.ugbAerolinea.Controls.Add(Me.uceTipo)
        Me.ugbAerolinea.Controls.Add(Me.btnConsultar)
        Me.ugbAerolinea.Controls.Add(Me.lblAgencia)
        Me.ugbAerolinea.Controls.Add(Me.uceAgencia)
        Me.ugbAerolinea.Location = New System.Drawing.Point(0, 1)
        Me.ugbAerolinea.Name = "ugbAerolinea"
        Me.ugbAerolinea.Size = New System.Drawing.Size(880, 57)
        Me.ugbAerolinea.TabIndex = 20
        Me.ugbAerolinea.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(401, 20)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(44, 20)
        Me.UltraLabel1.TabIndex = 23
        Me.UltraLabel1.Text = "Tipo:"
        '
        'uceTipo
        '
        Me.uceTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipo.LimitToList = True
        Me.uceTipo.Location = New System.Drawing.Point(451, 19)
        Me.uceTipo.Name = "uceTipo"
        Me.uceTipo.Size = New System.Drawing.Size(226, 21)
        Me.uceTipo.TabIndex = 24
        '
        'btnConsultar
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnConsultar.Appearance = Appearance5
        Me.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultar.Location = New System.Drawing.Point(691, 15)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 27)
        Me.btnConsultar.TabIndex = 22
        '
        'lblAgencia
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance7
        Me.lblAgencia.Location = New System.Drawing.Point(59, 20)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 11
        Me.lblAgencia.Text = "Agencia:"
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(134, 20)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(251, 21)
        Me.uceAgencia.TabIndex = 19
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtElemento)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 58)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(880, 47)
        Me.UltraGroupBox3.TabIndex = 24
        Me.UltraGroupBox3.Text = "Buscar Elemento:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtElemento
        '
        Me.txtElemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtElemento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtElemento.Location = New System.Drawing.Point(97, 16)
        Me.txtElemento.Name = "txtElemento"
        Me.txtElemento.Size = New System.Drawing.Size(537, 21)
        Me.txtElemento.TabIndex = 1
        '
        'frmConsultaElementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 403)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.ugbAerolinea)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaElementos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta Elemento"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAerolinea.ResumeLayout(False)
        Me.ugbAerolinea.PerformLayout()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ugbAerolinea As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvElementos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceTipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtElemento As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
