<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleServicio
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalleServicio))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvListServicios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BtnAgregar = New Infragistics.Win.Misc.UltraButton()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtServicio = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpdate = New Infragistics.Win.Misc.UltraButton()
        Me.uceTipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.ugvListServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.uceTipo)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel1)
        Me.ugbContactoAgencia.Controls.Add(Me.ugvListServicios)
        Me.ugbContactoAgencia.Controls.Add(Me.BtnAgregar)
        Me.ugbContactoAgencia.Controls.Add(Me.uceEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel2)
        Me.ugbContactoAgencia.Controls.Add(Me.txtServicio)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel5)
        Me.ugbContactoAgencia.Controls.Add(Me.btnCancel)
        Me.ugbContactoAgencia.Controls.Add(Me.btnUpdate)
        Me.ugbContactoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbContactoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbContactoAgencia.Name = "ugbContactoAgencia"
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(417, 306)
        Me.ugbContactoAgencia.TabIndex = 20
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvListServicios
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Me.ugvListServicios.DisplayLayout.Appearance = Appearance6
        Me.ugvListServicios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvListServicios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvListServicios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvListServicios.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.ugvListServicios.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Me.ugvListServicios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 10.0!
        Appearance8.ForeColor = System.Drawing.Color.White
        Appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvListServicios.DisplayLayout.Override.HeaderAppearance = Appearance8
        Me.ugvListServicios.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvListServicios.DisplayLayout.Override.RowSelectorAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvListServicios.DisplayLayout.Override.SelectedRowAppearance = Appearance10
        Me.ugvListServicios.Location = New System.Drawing.Point(12, 99)
        Me.ugvListServicios.Name = "ugvListServicios"
        Me.ugvListServicios.Size = New System.Drawing.Size(393, 164)
        Me.ugvListServicios.TabIndex = 4
        '
        'BtnAgregar
        '
        Appearance12.Image = Global.SPC.My.Resources.Resources.add16x16
        Me.BtnAgregar.Appearance = Appearance12
        Me.BtnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.BtnAgregar.Location = New System.Drawing.Point(167, 56)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(26, 28)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Visible = False
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem3.DataValue = "A"
        ValueListItem3.DisplayText = "Activo"
        ValueListItem4.DataValue = "I"
        ValueListItem4.DisplayText = "Inactivo"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(62, 77)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(88, 21)
        Me.uceEstado.TabIndex = 1
        '
        'UltraLabel2
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance4
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 76)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(43, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'txtServicio
        '
        Me.txtServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtServicio.Location = New System.Drawing.Point(62, 23)
        Me.txtServicio.Multiline = True
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(343, 21)
        Me.txtServicio.TabIndex = 0
        '
        'UltraLabel5
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.Location = New System.Drawing.Point(12, 24)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel5.TabIndex = 30
        Me.UltraLabel5.Text = "Servicio:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(139, 269)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Salir"
        '
        'btnUpdate
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnUpdate.Appearance = Appearance1
        Me.btnUpdate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnUpdate.Location = New System.Drawing.Point(325, 65)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(80, 28)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Actualizar"
        Me.btnUpdate.Visible = False
        '
        'uceTipo
        '
        Me.uceTipo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem1.DataValue = "P"
        ValueListItem1.DisplayText = "Principal"
        ValueListItem2.DataValue = "S"
        ValueListItem2.DisplayText = "Secundario"
        Me.uceTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.uceTipo.LimitToList = True
        Me.uceTipo.Location = New System.Drawing.Point(62, 50)
        Me.uceTipo.Name = "uceTipo"
        Me.uceTipo.Size = New System.Drawing.Size(88, 21)
        Me.uceTipo.TabIndex = 37
        '
        'UltraLabel1
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 50)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(43, 20)
        Me.UltraLabel1.TabIndex = 38
        Me.UltraLabel1.Text = "Tipo:"
        '
        'FrmDetalleServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 306)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmDetalleServicio"
        Me.Text = "FrmDetalleServicio"
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        Me.ugbContactoAgencia.PerformLayout()
        CType(Me.ugvListServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtServicio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpdate As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnAgregar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugvListServicios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents uceTipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
