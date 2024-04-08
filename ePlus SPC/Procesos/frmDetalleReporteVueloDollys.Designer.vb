<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleReporteVueloDollys
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
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvElementos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.ugvElementos)
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 2)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(320, 230)
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
        Me.ugvElementos.Size = New System.Drawing.Size(314, 227)
        Me.ugvElementos.TabIndex = 3
        Me.ugvElementos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmDetalleReporteVueloDollys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 231)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDetalleReporteVueloDollys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Elementos asignados a este Dolly"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvElementos As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
