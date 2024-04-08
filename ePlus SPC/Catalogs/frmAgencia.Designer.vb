<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgencia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgencia))
        Me.ugdAgencia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceTipoConsulta = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceTipoAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.btnbuscar = New System.Windows.Forms.Button()
        CType(Me.ugdAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTipoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugdAgencia
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdAgencia.DisplayLayout.Appearance = Appearance1
        Me.ugdAgencia.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdAgencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdAgencia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdAgencia.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdAgencia.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdAgencia.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdAgencia.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAgencia.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAgencia.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdAgencia.Location = New System.Drawing.Point(0, 104)
        Me.ugdAgencia.Name = "ugdAgencia"
        Me.ugdAgencia.Size = New System.Drawing.Size(656, 285)
        Me.ugdAgencia.TabIndex = 8
        Me.ugdAgencia.Text = "AGENCIAS"
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(656, 104)
        Me.ugbCamion.TabIndex = 7
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox3.Controls.Add(Me.uceTipoConsulta)
        Me.UltraGroupBox3.Controls.Add(Me.uceTipoAgencia)
        Me.UltraGroupBox3.Controls.Add(Me.btnbuscar)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(9, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(542, 83)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Agencia:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel1
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance15
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 43)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(91, 23)
        Me.UltraLabel1.TabIndex = 74
        Me.UltraLabel1.Text = "Consultar Por:"
        '
        'UltraLabel7
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance3
        Me.UltraLabel7.Location = New System.Drawing.Point(6, 19)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel7.Size = New System.Drawing.Size(91, 23)
        Me.UltraLabel7.TabIndex = 24
        Me.UltraLabel7.Text = "Tipo de Agencia:"
        '
        'uceTipoConsulta
        '
        Me.uceTipoConsulta.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipoConsulta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipoConsulta.LimitToList = True
        Me.uceTipoConsulta.Location = New System.Drawing.Point(103, 45)
        Me.uceTipoConsulta.Name = "uceTipoConsulta"
        Me.uceTipoConsulta.Size = New System.Drawing.Size(193, 21)
        Me.uceTipoConsulta.TabIndex = 73
        '
        'uceTipoAgencia
        '
        Me.uceTipoAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipoAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTipoAgencia.LimitToList = True
        Me.uceTipoAgencia.Location = New System.Drawing.Point(103, 19)
        Me.uceTipoAgencia.Name = "uceTipoAgencia"
        Me.uceTipoAgencia.Size = New System.Drawing.Size(193, 21)
        Me.uceTipoAgencia.TabIndex = 72
        '
        'btnbuscar
        '
        Me.btnbuscar.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnbuscar.Location = New System.Drawing.Point(302, 45)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(27, 26)
        Me.btnbuscar.TabIndex = 70
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'frmAgencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(656, 389)
        Me.Controls.Add(Me.ugdAgencia)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAgencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Datos por Tipo de Agencia"
        CType(Me.ugdAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTipoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugdAgencia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceTipoConsulta As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceTipoAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnbuscar As Button
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
End Class
