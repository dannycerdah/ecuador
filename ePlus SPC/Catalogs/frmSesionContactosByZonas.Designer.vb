<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSesionContactosByZonas
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
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSesionContactosByZonas))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugdSesionContactosByZonas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.DateTimeHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabelHoraFin = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabelHoraInicio = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraBtnExportExcel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraCheckDetalle = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsultarCZ = New Infragistics.Win.Misc.UltraButton()
        Me.udtFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbAgencias = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtContacto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.ugdSesionContactosByZonas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.UltraCheckDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAgencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugdSesionContactosByZonas
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdSesionContactosByZonas.DisplayLayout.Appearance = Appearance1
        Me.ugdSesionContactosByZonas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.Name = "Arial"
        Appearance6.FontData.SizeInPoints = 10.0!
        Appearance6.ForeColor = System.Drawing.Color.White
        Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.HeaderAppearance = Appearance6
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdSesionContactosByZonas.DisplayLayout.Override.SelectedRowAppearance = Appearance8
        Me.ugdSesionContactosByZonas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdSesionContactosByZonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdSesionContactosByZonas.Location = New System.Drawing.Point(0, 121)
        Me.ugdSesionContactosByZonas.Name = "ugdSesionContactosByZonas"
        Me.ugdSesionContactosByZonas.Size = New System.Drawing.Size(737, 463)
        Me.ugdSesionContactosByZonas.TabIndex = 2
        Me.ugdSesionContactosByZonas.Text = "REGISTRO DE CONTACTOS EN ZONA"
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(737, 121)
        Me.ugbCamion.TabIndex = 3
        Me.ugbCamion.Text = "ºº"
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.DateTimeHoraInicio)
        Me.UltraGroupBox3.Controls.Add(Me.DateTimeHoraFin)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabelHoraFin)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabelHoraInicio)
        Me.UltraGroupBox3.Controls.Add(Me.UltraBtnExportExcel)
        Me.UltraGroupBox3.Controls.Add(Me.UltraCheckDetalle)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.btnConsultarCZ)
        Me.UltraGroupBox3.Controls.Add(Me.udtFinal)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.udtInicio)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.cmbAgencias)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel20)
        Me.UltraGroupBox3.Controls.Add(Me.txtContacto)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(713, 104)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Buscar:"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'DateTimeHoraInicio
        '
        Me.DateTimeHoraInicio.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraInicio.Location = New System.Drawing.Point(76, 74)
        Me.DateTimeHoraInicio.Name = "DateTimeHoraInicio"
        Me.DateTimeHoraInicio.ShowUpDown = True
        Me.DateTimeHoraInicio.Size = New System.Drawing.Size(73, 20)
        Me.DateTimeHoraInicio.TabIndex = 77
        Me.DateTimeHoraInicio.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'DateTimeHoraFin
        '
        Me.DateTimeHoraFin.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraFin.Location = New System.Drawing.Point(240, 74)
        Me.DateTimeHoraFin.Name = "DateTimeHoraFin"
        Me.DateTimeHoraFin.ShowUpDown = True
        Me.DateTimeHoraFin.Size = New System.Drawing.Size(71, 20)
        Me.DateTimeHoraFin.TabIndex = 76
        Me.DateTimeHoraFin.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'UltraLabelHoraFin
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.BackColor2 = System.Drawing.Color.Transparent
        Me.UltraLabelHoraFin.Appearance = Appearance12
        Me.UltraLabelHoraFin.Location = New System.Drawing.Point(174, 77)
        Me.UltraLabelHoraFin.Name = "UltraLabelHoraFin"
        Me.UltraLabelHoraFin.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabelHoraFin.TabIndex = 74
        Me.UltraLabelHoraFin.Text = "Hora Fin:"
        '
        'UltraLabelHoraInicio
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.BackColor2 = System.Drawing.Color.Transparent
        Me.UltraLabelHoraInicio.Appearance = Appearance11
        Me.UltraLabelHoraInicio.Location = New System.Drawing.Point(6, 78)
        Me.UltraLabelHoraInicio.Name = "UltraLabelHoraInicio"
        Me.UltraLabelHoraInicio.Size = New System.Drawing.Size(64, 24)
        Me.UltraLabelHoraInicio.TabIndex = 73
        Me.UltraLabelHoraInicio.Text = "Hora Inicio:"
        '
        'UltraBtnExportExcel
        '
        Me.UltraBtnExportExcel.Location = New System.Drawing.Point(491, 48)
        Me.UltraBtnExportExcel.Name = "UltraBtnExportExcel"
        Me.UltraBtnExportExcel.Size = New System.Drawing.Size(107, 23)
        Me.UltraBtnExportExcel.TabIndex = 70
        Me.UltraBtnExportExcel.Text = "Reporte"
        '
        'UltraCheckDetalle
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Me.UltraCheckDetalle.Appearance = Appearance10
        Me.UltraCheckDetalle.BackColor = System.Drawing.Color.Transparent
        Me.UltraCheckDetalle.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraCheckDetalle.Location = New System.Drawing.Point(450, 51)
        Me.UltraCheckDetalle.Name = "UltraCheckDetalle"
        Me.UltraCheckDetalle.Size = New System.Drawing.Size(19, 20)
        Me.UltraCheckDetalle.TabIndex = 69
        '
        'UltraLabel3
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel3.Appearance = Appearance9
        Me.UltraLabel3.Location = New System.Drawing.Point(325, 51)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 68
        Me.UltraLabel3.Text = "Reporte Detallado:"
        '
        'btnConsultarCZ
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnConsultarCZ.Appearance = Appearance5
        Me.btnConsultarCZ.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultarCZ.ImageSize = New System.Drawing.Size(12, 12)
        Me.btnConsultarCZ.Location = New System.Drawing.Point(286, 47)
        Me.btnConsultarCZ.Name = "btnConsultarCZ"
        Me.btnConsultarCZ.Size = New System.Drawing.Size(25, 21)
        Me.btnConsultarCZ.TabIndex = 67
        '
        'udtFinal
        '
        Me.udtFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFinal.FormatString = ""
        Me.udtFinal.Location = New System.Drawing.Point(172, 47)
        Me.udtFinal.MaskInput = "dd/mm/yyyy"
        Me.udtFinal.Name = "udtFinal"
        Me.udtFinal.Size = New System.Drawing.Size(108, 21)
        Me.udtFinal.TabIndex = 66
        '
        'UltraLabel2
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Location = New System.Drawing.Point(4, 48)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel2.TabIndex = 65
        Me.UltraLabel2.Text = "Fechas:"
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = ""
        Me.udtInicio.Location = New System.Drawing.Point(60, 47)
        Me.udtInicio.MaskInput = "dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(106, 21)
        Me.udtInicio.TabIndex = 64
        '
        'UltraLabel1
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Right"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance21
        Me.UltraLabel1.Location = New System.Drawing.Point(317, 21)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(127, 20)
        Me.UltraLabel1.TabIndex = 63
        Me.UltraLabel1.Text = "Documento o apellidos:"
        '
        'cmbAgencias
        '
        Me.cmbAgencias.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cmbAgencias.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbAgencias.LimitToList = True
        Me.cmbAgencias.Location = New System.Drawing.Point(60, 20)
        Me.cmbAgencias.Name = "cmbAgencias"
        Me.cmbAgencias.Size = New System.Drawing.Size(251, 21)
        Me.cmbAgencias.TabIndex = 62
        '
        'UltraLabel20
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel20.Appearance = Appearance7
        Me.UltraLabel20.Location = New System.Drawing.Point(6, 20)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel20.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel20.TabIndex = 61
        Me.UltraLabel20.Text = "Agencia:"
        '
        'txtContacto
        '
        Me.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContacto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtContacto.Location = New System.Drawing.Point(450, 19)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(254, 21)
        Me.txtContacto.TabIndex = 1
        '
        'frmSesionContactosByZonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 584)
        Me.Controls.Add(Me.ugdSesionContactosByZonas)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSesionContactosByZonas"
        Me.Text = "frmZonasAutorizadasByContacto"
        CType(Me.ugdSesionContactosByZonas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.UltraCheckDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAgencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugdSesionContactosByZonas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbAgencias As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtContacto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnConsultarCZ As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraCheckDetalle As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraBtnExportExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabelHoraFin As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabelHoraInicio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DateTimeHoraFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeHoraInicio As System.Windows.Forms.DateTimePicker
End Class
