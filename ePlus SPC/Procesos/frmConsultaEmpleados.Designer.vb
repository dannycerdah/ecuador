<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaEmpleados
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
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdPersonalGeneral = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbAerolinea = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtEmpleado = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugdPersonalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAerolinea.SuspendLayout()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.ugdPersonalGeneral)
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 58)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(766, 259)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdPersonalGeneral
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdPersonalGeneral.DisplayLayout.Appearance = Appearance1
        Me.ugdPersonalGeneral.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdPersonalGeneral.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdPersonalGeneral.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdPersonalGeneral.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdPersonalGeneral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdPersonalGeneral.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdPersonalGeneral.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPersonalGeneral.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPersonalGeneral.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugdPersonalGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdPersonalGeneral.Location = New System.Drawing.Point(3, 0)
        Me.ugdPersonalGeneral.Name = "ugdPersonalGeneral"
        Me.ugdPersonalGeneral.Size = New System.Drawing.Size(760, 256)
        Me.ugdPersonalGeneral.TabIndex = 3
        Me.ugdPersonalGeneral.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'ugbAerolinea
        '
        Me.ugbAerolinea.Controls.Add(Me.txtEmpleado)
        Me.ugbAerolinea.Controls.Add(Me.lblAgencia)
        Me.ugbAerolinea.Location = New System.Drawing.Point(0, 1)
        Me.ugbAerolinea.Name = "ugbAerolinea"
        Me.ugbAerolinea.Size = New System.Drawing.Size(766, 57)
        Me.ugbAerolinea.TabIndex = 20
        Me.ugbAerolinea.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtEmpleado
        '
        Me.txtEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpleado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtEmpleado.Location = New System.Drawing.Point(143, 18)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(236, 21)
        Me.txtEmpleado.TabIndex = 12
        '
        'lblAgencia
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance9
        Me.lblAgencia.Location = New System.Drawing.Point(63, 19)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 11
        Me.lblAgencia.Text = "Nombres:"
        '
        'frmConsultaEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 318)
        Me.Controls.Add(Me.ugbAerolinea)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaEmpleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consulta Personal General"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugdPersonalGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAerolinea.ResumeLayout(False)
        Me.ugbAerolinea.PerformLayout()
        CType(Me.txtEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ugbAerolinea As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugdPersonalGeneral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtEmpleado As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
