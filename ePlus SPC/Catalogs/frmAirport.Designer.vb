<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAirports
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
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.uceBusq = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceMetBusq = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugdAirports = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnConsultar = New Infragistics.Win.Misc.UltraButton()
        CType(Me.uceBusq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceMetBusq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.ugdAirports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'uceBusq
        '
        Me.uceBusq.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceBusq.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceBusq.LimitToList = True
        Me.uceBusq.Location = New System.Drawing.Point(6, 52)
        Me.uceBusq.Name = "uceBusq"
        Me.uceBusq.Size = New System.Drawing.Size(262, 21)
        Me.uceBusq.TabIndex = 28
        '
        'uceMetBusq
        '
        Me.uceMetBusq.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceMetBusq.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem5.DataValue = "esc"
        ValueListItem5.DisplayText = "Escoja una opción"
        ValueListItem6.DataValue = "pai"
        ValueListItem6.DisplayText = "Por País"
        ValueListItem7.DataValue = "cod"
        ValueListItem7.DisplayText = "Por Código IATA"
        ValueListItem8.DataValue = "aer"
        ValueListItem8.DisplayText = "Por Aeropuerto"
        Me.uceMetBusq.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8})
        Me.uceMetBusq.LimitToList = True
        Me.uceMetBusq.Location = New System.Drawing.Point(155, 25)
        Me.uceMetBusq.Name = "uceMetBusq"
        Me.uceMetBusq.Size = New System.Drawing.Size(147, 21)
        Me.uceMetBusq.TabIndex = 32
        '
        'UltraLabel7
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Left"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance15
        Me.UltraLabel7.Location = New System.Drawing.Point(6, 23)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel7.Size = New System.Drawing.Size(150, 23)
        Me.UltraLabel7.TabIndex = 19
        Me.UltraLabel7.Text = "Seleccionar método de filtro:"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.ugdAirports)
        Me.UltraGroupBox1.Controls.Add(Me.ugbCamion)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(566, 433)
        Me.UltraGroupBox1.TabIndex = 24
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugdAirports
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdAirports.DisplayLayout.Appearance = Appearance1
        Me.ugdAirports.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdAirports.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdAirports.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdAirports.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdAirports.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdAirports.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdAirports.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAirports.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdAirports.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdAirports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdAirports.Location = New System.Drawing.Point(3, 104)
        Me.ugdAirports.Name = "ugdAirports"
        Me.ugdAirports.Size = New System.Drawing.Size(560, 326)
        Me.ugdAirports.TabIndex = 6
        Me.ugdAirports.Text = "AEROPUERTOS DEL MUNDO"
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(3, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(560, 104)
        Me.ugbCamion.TabIndex = 5
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.btnConsultar)
        Me.UltraGroupBox3.Controls.Add(Me.uceBusq)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox3.Controls.Add(Me.uceMetBusq)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(9, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(542, 83)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar Aeropuertos:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnConsultar
        '
        Appearance7.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnConsultar.Appearance = Appearance7
        Me.btnConsultar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultar.Location = New System.Drawing.Point(275, 52)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 26)
        Me.btnConsultar.TabIndex = 68
        '
        'frmAirports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 433)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAirports"
        Me.Text = "Airport"
        CType(Me.uceBusq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceMetBusq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.ugdAirports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceBusq As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceMetBusq As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnConsultar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugdAirports As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
