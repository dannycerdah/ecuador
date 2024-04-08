<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlantillaClientServ
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbClientes = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtPlantilla = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ugdPlantilla = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbClientes.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.txtPlantilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugdPlantilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbClientes
        '
        Me.ugbClientes.Controls.Add(Me.UltraGroupBox3)
        Me.ugbClientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbClientes.Location = New System.Drawing.Point(0, 0)
        Me.ugbClientes.Name = "ugbClientes"
        Me.ugbClientes.Size = New System.Drawing.Size(800, 68)
        Me.ugbClientes.TabIndex = 3
        Me.ugbClientes.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.txtPlantilla)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 15)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(542, 47)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Plantilla:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtPlantilla
        '
        Me.txtPlantilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlantilla.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPlantilla.Location = New System.Drawing.Point(6, 19)
        Me.txtPlantilla.Name = "txtPlantilla"
        Me.txtPlantilla.Size = New System.Drawing.Size(300, 21)
        Me.txtPlantilla.TabIndex = 1
        '
        'ugdPlantilla
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdPlantilla.DisplayLayout.Appearance = Appearance1
        Me.ugdPlantilla.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdPlantilla.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdPlantilla.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdPlantilla.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdPlantilla.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdPlantilla.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdPlantilla.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugdPlantilla.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPlantilla.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdPlantilla.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdPlantilla.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdPlantilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdPlantilla.Location = New System.Drawing.Point(0, 68)
        Me.ugdPlantilla.Name = "ugdPlantilla"
        Me.ugdPlantilla.Size = New System.Drawing.Size(800, 382)
        Me.ugdPlantilla.TabIndex = 6
        Me.ugdPlantilla.Text = "PLANTILLA CLIENTE SERVICIO"
        '
        'FrmPlantillaClientServ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ugdPlantilla)
        Me.Controls.Add(Me.ugbClientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPlantillaClientServ"
        Me.Text = "PlantillaClientServ"
        CType(Me.ugbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbClientes.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.txtPlantilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugdPlantilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbClientes As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtPlantilla As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ugdPlantilla As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
