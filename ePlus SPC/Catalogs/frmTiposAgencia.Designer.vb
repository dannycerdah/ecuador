<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiposAgencia
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
        Me.ugdTipoAgencia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugdTipoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugdTipoAgencia
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.ugdTipoAgencia.DisplayLayout.Appearance = Appearance1
        Me.ugdTipoAgencia.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdTipoAgencia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdTipoAgencia.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdTipoAgencia.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdTipoAgencia.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdTipoAgencia.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdTipoAgencia.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdTipoAgencia.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdTipoAgencia.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdTipoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdTipoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugdTipoAgencia.Name = "ugdTipoAgencia"
        Me.ugdTipoAgencia.Size = New System.Drawing.Size(278, 201)
        Me.ugdTipoAgencia.TabIndex = 2
        Me.ugdTipoAgencia.Text = "TIPOS DE AGENCIA"
        '
        'frmTiposAgencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(278, 201)
        Me.Controls.Add(Me.ugdTipoAgencia)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTiposAgencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipos de Agencias"
        CType(Me.ugdTipoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugdTipoAgencia As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
