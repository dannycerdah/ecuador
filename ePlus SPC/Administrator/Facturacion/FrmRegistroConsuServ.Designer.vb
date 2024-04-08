<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroConsuServ
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
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroConsuServ))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnConsVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.txtNumVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtGuia = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblVuelo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.DateTimeHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.BtnAgregar = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabelHoraFin = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabelHoraInicio = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFinal = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClientes = New Infragistics.Win.Misc.UltraLabel()
        Me.uceClientes = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceServicios = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ugvListServConsuCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugvListServConsuCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.UltraGroupBox1)
        Me.ugbContactoAgencia.Controls.Add(Me.ugvListServConsuCliente)
        Me.ugbContactoAgencia.Controls.Add(Me.btnCancel)
        Me.ugbContactoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbContactoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbContactoAgencia.Name = "ugbContactoAgencia"
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(851, 397)
        Me.ugbContactoAgencia.TabIndex = 23
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.btnConsVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtNumVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtGuia)
        Me.UltraGroupBox1.Controls.Add(Me.lblVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.DateTimeHoraInicio)
        Me.UltraGroupBox1.Controls.Add(Me.DateTimeHoraFin)
        Me.UltraGroupBox1.Controls.Add(Me.BtnAgregar)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabelHoraFin)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabelHoraInicio)
        Me.UltraGroupBox1.Controls.Add(Me.udtFinal)
        Me.UltraGroupBox1.Controls.Add(Me.udtInicio)
        Me.UltraGroupBox1.Controls.Add(Me.lblDesde)
        Me.UltraGroupBox1.Controls.Add(Me.lblClientes)
        Me.UltraGroupBox1.Controls.Add(Me.uceClientes)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.uceServicios)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(833, 153)
        Me.UltraGroupBox1.TabIndex = 63
        Me.UltraGroupBox1.Text = "Datos Genereales"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnConsVuelo
        '
        Appearance66.Image = CType(resources.GetObject("Appearance66.Image"), Object)
        Me.btnConsVuelo.Appearance = Appearance66
        Me.btnConsVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsVuelo.Location = New System.Drawing.Point(764, 48)
        Me.btnConsVuelo.Name = "btnConsVuelo"
        Me.btnConsVuelo.Size = New System.Drawing.Size(27, 27)
        Me.btnConsVuelo.TabIndex = 89
        '
        'txtNumVuelo
        '
        Me.txtNumVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNumVuelo.Enabled = False
        Me.txtNumVuelo.Location = New System.Drawing.Point(514, 52)
        Me.txtNumVuelo.Name = "txtNumVuelo"
        Me.txtNumVuelo.ReadOnly = True
        Me.txtNumVuelo.Size = New System.Drawing.Size(80, 21)
        Me.txtNumVuelo.TabIndex = 88
        '
        'txtGuia
        '
        Me.txtGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtGuia.Enabled = False
        Me.txtGuia.Location = New System.Drawing.Point(647, 52)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(101, 21)
        Me.txtGuia.TabIndex = 87
        '
        'lblVuelo
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblVuelo.Appearance = Appearance4
        Me.lblVuelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblVuelo.Location = New System.Drawing.Point(440, 52)
        Me.lblVuelo.Name = "lblVuelo"
        Me.lblVuelo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVuelo.Size = New System.Drawing.Size(60, 20)
        Me.lblVuelo.TabIndex = 90
        Me.lblVuelo.Text = "Vuelo:"
        '
        'UltraLabel2
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.BackColor2 = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance1
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.UltraLabel2.Location = New System.Drawing.Point(191, 66)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabel2.TabIndex = 86
        Me.UltraLabel2.Text = "-"
        '
        'DateTimeHoraInicio
        '
        Me.DateTimeHoraInicio.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraInicio.Location = New System.Drawing.Point(108, 105)
        Me.DateTimeHoraInicio.Name = "DateTimeHoraInicio"
        Me.DateTimeHoraInicio.ShowUpDown = True
        Me.DateTimeHoraInicio.Size = New System.Drawing.Size(73, 20)
        Me.DateTimeHoraInicio.TabIndex = 85
        Me.DateTimeHoraInicio.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'DateTimeHoraFin
        '
        Me.DateTimeHoraFin.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraFin.Location = New System.Drawing.Point(254, 105)
        Me.DateTimeHoraFin.Name = "DateTimeHoraFin"
        Me.DateTimeHoraFin.ShowUpDown = True
        Me.DateTimeHoraFin.Size = New System.Drawing.Size(71, 20)
        Me.DateTimeHoraFin.TabIndex = 84
        Me.DateTimeHoraFin.Value = New Date(2018, 1, 11, 0, 0, 0, 0)
        '
        'BtnAgregar
        '
        Appearance15.Image = Global.SPC.My.Resources.Resources.add16x16
        Me.BtnAgregar.Appearance = Appearance15
        Me.BtnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.BtnAgregar.Location = New System.Drawing.Point(395, 78)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(26, 28)
        Me.BtnAgregar.TabIndex = 2
        '
        'UltraLabelHoraFin
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BackColor2 = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabelHoraFin.Appearance = Appearance3
        Me.UltraLabelHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabelHoraFin.Location = New System.Drawing.Point(187, 104)
        Me.UltraLabelHoraFin.Name = "UltraLabelHoraFin"
        Me.UltraLabelHoraFin.Size = New System.Drawing.Size(60, 17)
        Me.UltraLabelHoraFin.TabIndex = 83
        Me.UltraLabelHoraFin.Text = "Hora Fin:"
        '
        'UltraLabelHoraInicio
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.BackColor2 = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Center"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabelHoraInicio.Appearance = Appearance11
        Me.UltraLabelHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabelHoraInicio.Location = New System.Drawing.Point(6, 101)
        Me.UltraLabelHoraInicio.Name = "UltraLabelHoraInicio"
        Me.UltraLabelHoraInicio.Size = New System.Drawing.Size(74, 24)
        Me.UltraLabelHoraInicio.TabIndex = 82
        Me.UltraLabelHoraInicio.Text = "Hora Inicio:"
        '
        'udtFinal
        '
        Me.udtFinal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFinal.FormatString = ""
        Me.udtFinal.Location = New System.Drawing.Point(254, 64)
        Me.udtFinal.MaskInput = "dd/mm/yyyy"
        Me.udtFinal.Name = "udtFinal"
        Me.udtFinal.Size = New System.Drawing.Size(80, 21)
        Me.udtFinal.TabIndex = 80
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = ""
        Me.udtInicio.Location = New System.Drawing.Point(108, 64)
        Me.udtInicio.MaskInput = "dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(84, 21)
        Me.udtInicio.TabIndex = 78
        '
        'lblDesde
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Left"
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance14
        Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblDesde.Location = New System.Drawing.Point(6, 52)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(86, 33)
        Me.lblDesde.TabIndex = 49
        Me.lblDesde.Text = "Fecha de Inicio y Fin"
        '
        'lblClientes
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextVAlignAsString = "Middle"
        Me.lblClientes.Appearance = Appearance13
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblClientes.Location = New System.Drawing.Point(6, 20)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClientes.Size = New System.Drawing.Size(74, 20)
        Me.lblClientes.TabIndex = 38
        Me.lblClientes.Text = "Clientes:"
        '
        'uceClientes
        '
        Me.uceClientes.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceClientes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceClientes.LimitToList = True
        Me.uceClientes.Location = New System.Drawing.Point(108, 20)
        Me.uceClientes.Name = "uceClientes"
        Me.uceClientes.Size = New System.Drawing.Size(313, 21)
        Me.uceClientes.TabIndex = 37
        '
        'UltraLabel1
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance19
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(437, 21)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(74, 20)
        Me.UltraLabel1.TabIndex = 40
        Me.UltraLabel1.Text = "Servicios:"
        '
        'uceServicios
        '
        Me.uceServicios.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceServicios.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceServicios.LimitToList = True
        Me.uceServicios.Location = New System.Drawing.Point(514, 21)
        Me.uceServicios.Name = "uceServicios"
        Me.uceServicios.Size = New System.Drawing.Size(313, 21)
        Me.uceServicios.TabIndex = 39
        '
        'ugvListServConsuCliente
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Me.ugvListServConsuCliente.DisplayLayout.Appearance = Appearance6
        Me.ugvListServConsuCliente.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvListServConsuCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvListServConsuCliente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvListServConsuCliente.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Me.ugvListServConsuCliente.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Me.ugvListServConsuCliente.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 10.0!
        Appearance8.ForeColor = System.Drawing.Color.White
        Appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvListServConsuCliente.DisplayLayout.Override.HeaderAppearance = Appearance8
        Me.ugvListServConsuCliente.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvListServConsuCliente.DisplayLayout.Override.RowSelectorAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvListServConsuCliente.DisplayLayout.Override.SelectedRowAppearance = Appearance10
        Me.ugvListServConsuCliente.Location = New System.Drawing.Point(12, 166)
        Me.ugvListServConsuCliente.Name = "ugvListServConsuCliente"
        Me.ugvListServConsuCliente.Size = New System.Drawing.Size(830, 191)
        Me.ugvListServConsuCliente.TabIndex = 4
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(759, 363)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Salir"
        '
        'UltraLabel3
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(601, 52)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(40, 20)
        Me.UltraLabel3.TabIndex = 91
        Me.UltraLabel3.Text = "Guia:"
        '
        'FrmRegistroConsuServ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 397)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.Name = "FrmRegistroConsuServ"
        Me.Text = "Registro de Servicios Consumidos por Cliente"
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugvListServConsuCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblClientes As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceClientes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceServicios As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ugvListServConsuCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BtnAgregar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DateTimeHoraInicio As DateTimePicker
    Friend WithEvents DateTimeHoraFin As DateTimePicker
    Friend WithEvents UltraLabelHoraFin As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabelHoraInicio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFinal As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnConsVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtNumVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtGuia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblVuelo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
