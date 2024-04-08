<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleAcarreo
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
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvDollys = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.ugvDollys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox2)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(937, 361)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.ugvDollys)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(937, 361)
        Me.UltraGroupBox2.TabIndex = 44
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvDollys
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugvDollys.DisplayLayout.Appearance = Appearance1
        Me.ugvDollys.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvDollys.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvDollys.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugvDollys.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugvDollys.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvDollys.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugvDollys.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDollys.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDollys.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugvDollys.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvDollys.Location = New System.Drawing.Point(3, 0)
        Me.ugvDollys.Name = "ugvDollys"
        Me.ugvDollys.Size = New System.Drawing.Size(931, 358)
        Me.ugvDollys.TabIndex = 4
        Me.ugvDollys.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmDetalleAcarreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 361)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDetalleAcarreo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle Acarreo"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.ugvDollys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvDollys As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
