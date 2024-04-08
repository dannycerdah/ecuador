<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContactoAgencia
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugdContactoAgencia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtbuscarnumci = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.ugdContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtbuscarnumci, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugdContactoAgencia
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdContactoAgencia.DisplayLayout.Appearance = Appearance1
        Me.ugdContactoAgencia.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdContactoAgencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdContactoAgencia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdContactoAgencia.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdContactoAgencia.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdContactoAgencia.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdContactoAgencia.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugdContactoAgencia.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdContactoAgencia.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdContactoAgencia.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdContactoAgencia.Location = New System.Drawing.Point(1, 89)
        Me.ugdContactoAgencia.Name = "ugdContactoAgencia"
        Me.ugdContactoAgencia.Size = New System.Drawing.Size(1123, 320)
        Me.ugdContactoAgencia.TabIndex = 2
        '
        'btnExcelExport
        '
        Me.btnExcelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.AlphaLevel = CType(110, Short)
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.BackColor2 = System.Drawing.Color.Transparent
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance6.FontData.BoldAsString = "True"
        Me.btnExcelExport.Appearance = Appearance6
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(1021, 52)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(89, 26)
        Me.btnExcelExport.TabIndex = 9
        Me.btnExcelExport.Text = " Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ingrese número de cédula o apellido:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtbuscarnumci)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 66)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'txtbuscarnumci
        '
        Me.txtbuscarnumci.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbuscarnumci.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtbuscarnumci.Location = New System.Drawing.Point(242, 26)
        Me.txtbuscarnumci.Name = "txtbuscarnumci"
        Me.txtbuscarnumci.Size = New System.Drawing.Size(253, 21)
        Me.txtbuscarnumci.TabIndex = 14
        '
        'frmContactoAgencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 421)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExcelExport)
        Me.Controls.Add(Me.ugdContactoAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmContactoAgencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listado de Contactos"
        CType(Me.ugdContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtbuscarnumci, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugdContactoAgencia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtbuscarnumci As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
