<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanias
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompanias))
        Me.ugbCampania = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupCompanias = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceTipoConsulta = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.ugdCompanias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbCampania, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCampania.SuspendLayout()
        CType(Me.UltraGroupCompanias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupCompanias.SuspendLayout()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugdCompanias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbCampania
        '
        Me.ugbCampania.Controls.Add(Me.UltraGroupCompanias)
        Me.ugbCampania.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCampania.Location = New System.Drawing.Point(0, 0)
        Me.ugbCampania.Name = "ugbCampania"
        Me.ugbCampania.Size = New System.Drawing.Size(656, 76)
        Me.ugbCampania.TabIndex = 7
        Me.ugbCampania.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupCompanias
        '
        Me.UltraGroupCompanias.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupCompanias.Controls.Add(Me.uceTipoConsulta)
        Me.UltraGroupCompanias.Controls.Add(Me.btnbuscar)
        Me.UltraGroupCompanias.Location = New System.Drawing.Point(9, 16)
        Me.UltraGroupCompanias.Name = "UltraGroupCompanias"
        Me.UltraGroupCompanias.Size = New System.Drawing.Size(635, 38)
        Me.UltraGroupCompanias.TabIndex = 23
        Me.UltraGroupCompanias.Text = "Buscar Agencia:"
        Me.UltraGroupCompanias.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel1
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance15
        Me.UltraLabel1.Location = New System.Drawing.Point(210, 6)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(91, 23)
        Me.UltraLabel1.TabIndex = 74
        Me.UltraLabel1.Text = "Consultar Por:"
        '
        'uceTipoConsulta
        '
        Me.uceTipoConsulta.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipoConsulta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipoConsulta.LimitToList = True
        Me.uceTipoConsulta.Location = New System.Drawing.Point(307, 8)
        Me.uceTipoConsulta.Name = "uceTipoConsulta"
        Me.uceTipoConsulta.Size = New System.Drawing.Size(193, 21)
        Me.uceTipoConsulta.TabIndex = 73
        '
        'btnbuscar
        '
        Me.btnbuscar.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnbuscar.Location = New System.Drawing.Point(506, 8)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(27, 26)
        Me.btnbuscar.TabIndex = 70
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'ugdCompanias
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdCompanias.DisplayLayout.Appearance = Appearance1
        Me.ugdCompanias.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdCompanias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdCompanias.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdCompanias.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdCompanias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdCompanias.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdCompanias.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdCompanias.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdCompanias.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdCompanias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdCompanias.Location = New System.Drawing.Point(0, 76)
        Me.ugdCompanias.Name = "ugdCompanias"
        Me.ugdCompanias.Size = New System.Drawing.Size(656, 313)
        Me.ugdCompanias.TabIndex = 9
        Me.ugdCompanias.Text = "AGENCIAS"
        '
        'frmCompanias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(656, 389)
        Me.Controls.Add(Me.ugdCompanias)
        Me.Controls.Add(Me.ugbCampania)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCompanias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCompanias"
        CType(Me.ugbCampania, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCampania.ResumeLayout(False)
        CType(Me.UltraGroupCompanias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupCompanias.ResumeLayout(False)
        Me.UltraGroupCompanias.PerformLayout()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugdCompanias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbCampania As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupCompanias As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceTipoConsulta As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents ugdCompanias As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
