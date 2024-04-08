<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcaciones
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
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraExplorerBarGroup2 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup()
        Dim UltraExplorerBarItem4 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem()
        Me.UltraExplorerBarContainerControl1 = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl()
        Me.uceContactos = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.DateTimeHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.UltraLabelHoraFin = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabelHoraInicio = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraCheckReporte = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.chbCompletas = New System.Windows.Forms.CheckBox()
        Me.btnPDF = New Infragistics.Win.Misc.UltraButton()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.uceCargos = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceEmpleados = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceTipoConsulta = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ugdMarcaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.uebMarcaciones = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar()
        Me.UltraExplorerBarContainerControl1.SuspendLayout()
        CType(Me.uceContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraCheckReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ugdMarcaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uebMarcaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uebMarcaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraExplorerBarContainerControl1
        '
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.uceContactos)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.DateTimeHoraInicio)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.DateTimeHoraFin)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabelHoraFin)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabelHoraInicio)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraCheckReporte)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.chbCompletas)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.btnPDF)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.btnExcelExport)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.btnBuscar)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.udtFin)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.uceCargos)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel3)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.uceEmpleados)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.udtInicio)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.UltraLabel4)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.uceTipoConsulta)
        Me.UltraExplorerBarContainerControl1.Controls.Add(Me.lblAerolinea)
        Me.UltraExplorerBarContainerControl1.Location = New System.Drawing.Point(3, 25)
        Me.UltraExplorerBarContainerControl1.Name = "UltraExplorerBarContainerControl1"
        Me.UltraExplorerBarContainerControl1.Size = New System.Drawing.Size(278, 311)
        Me.UltraExplorerBarContainerControl1.TabIndex = 0
        '
        'uceContactos
        '
        Me.uceContactos.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceContactos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceContactos.Enabled = False
        Me.uceContactos.LimitToList = True
        Me.uceContactos.Location = New System.Drawing.Point(5, 107)
        Me.uceContactos.Name = "uceContactos"
        Me.uceContactos.Size = New System.Drawing.Size(270, 21)
        Me.uceContactos.TabIndex = 82
        '
        'DateTimeHoraInicio
        '
        Me.DateTimeHoraInicio.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraInicio.Location = New System.Drawing.Point(68, 160)
        Me.DateTimeHoraInicio.Name = "DateTimeHoraInicio"
        Me.DateTimeHoraInicio.ShowUpDown = True
        Me.DateTimeHoraInicio.Size = New System.Drawing.Size(64, 20)
        Me.DateTimeHoraInicio.TabIndex = 81
        Me.DateTimeHoraInicio.Value = New Date(2018, 1, 17, 0, 0, 0, 0)
        '
        'DateTimeHoraFin
        '
        Me.DateTimeHoraFin.CustomFormat = "HH:mm:ss"
        Me.DateTimeHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeHoraFin.Location = New System.Drawing.Point(185, 160)
        Me.DateTimeHoraFin.Name = "DateTimeHoraFin"
        Me.DateTimeHoraFin.ShowUpDown = True
        Me.DateTimeHoraFin.Size = New System.Drawing.Size(65, 20)
        Me.DateTimeHoraFin.TabIndex = 80
        Me.DateTimeHoraFin.Value = New Date(2018, 1, 17, 0, 0, 0, 0)
        '
        'UltraLabelHoraFin
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.BackColor2 = System.Drawing.Color.Transparent
        Me.UltraLabelHoraFin.Appearance = Appearance12
        Me.UltraLabelHoraFin.Location = New System.Drawing.Point(137, 163)
        Me.UltraLabelHoraFin.Name = "UltraLabelHoraFin"
        Me.UltraLabelHoraFin.Size = New System.Drawing.Size(54, 17)
        Me.UltraLabelHoraFin.TabIndex = 79
        Me.UltraLabelHoraFin.Text = "Hora Fin:"
        '
        'UltraLabelHoraInicio
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.BackColor2 = System.Drawing.Color.Transparent
        Me.UltraLabelHoraInicio.Appearance = Appearance11
        Me.UltraLabelHoraInicio.Location = New System.Drawing.Point(6, 164)
        Me.UltraLabelHoraInicio.Name = "UltraLabelHoraInicio"
        Me.UltraLabelHoraInicio.Size = New System.Drawing.Size(64, 16)
        Me.UltraLabelHoraInicio.TabIndex = 78
        Me.UltraLabelHoraInicio.Text = "Hora Inicio:"
        '
        'UltraCheckReporte
        '
        Me.UltraCheckReporte.BackColor = System.Drawing.Color.Transparent
        Me.UltraCheckReporte.BackColorInternal = System.Drawing.Color.Transparent
        Me.UltraCheckReporte.Location = New System.Drawing.Point(92, 210)
        Me.UltraCheckReporte.Name = "UltraCheckReporte"
        Me.UltraCheckReporte.Size = New System.Drawing.Size(111, 20)
        Me.UltraCheckReporte.TabIndex = 60
        Me.UltraCheckReporte.Text = "Imprimir Reporte"
        '
        'chbCompletas
        '
        Me.chbCompletas.AutoSize = True
        Me.chbCompletas.BackColor = System.Drawing.Color.Transparent
        Me.chbCompletas.Checked = True
        Me.chbCompletas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCompletas.Location = New System.Drawing.Point(92, 187)
        Me.chbCompletas.Name = "chbCompletas"
        Me.chbCompletas.Size = New System.Drawing.Size(161, 17)
        Me.chbCompletas.TabIndex = 58
        Me.chbCompletas.Text = "Solo marcaciones completas"
        Me.chbCompletas.UseVisualStyleBackColor = False
        '
        'btnPDF
        '
        Appearance2.AlphaLevel = CType(110, Short)
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.BackColor2 = System.Drawing.Color.Transparent
        Appearance2.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnPDF.Appearance = Appearance2
        Me.btnPDF.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnPDF.Enabled = False
        Me.btnPDF.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnPDF.Location = New System.Drawing.Point(6, 261)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(80, 22)
        Me.btnPDF.TabIndex = 57
        Me.btnPDF.Text = "Reporte PDF"
        '
        'btnExcelExport
        '
        Appearance13.AlphaLevel = CType(110, Short)
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.BackColor2 = System.Drawing.Color.Transparent
        Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnExcelExport.Appearance = Appearance13
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.Enabled = False
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(6, 233)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(80, 22)
        Me.btnExcelExport.TabIndex = 9
        Me.btnExcelExport.Text = "Excel"
        '
        'btnBuscar
        '
        Appearance4.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnBuscar.Appearance = Appearance4
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnBuscar.Location = New System.Drawing.Point(6, 195)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 26)
        Me.btnBuscar.TabIndex = 52
        Me.btnBuscar.Text = "Consultar"
        '
        'UltraLabel2
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.Location = New System.Drawing.Point(138, 134)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(36, 20)
        Me.UltraLabel2.TabIndex = 50
        Me.UltraLabel2.Text = "Hasta"
        '
        'udtFin
        '
        Me.udtFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFin.FormatString = "dd/MM/yyyy"
        Me.udtFin.Location = New System.Drawing.Point(180, 134)
        Me.udtFin.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtFin.Name = "udtFin"
        Me.udtFin.Size = New System.Drawing.Size(96, 21)
        Me.udtFin.TabIndex = 51
        '
        'uceCargos
        '
        Me.uceCargos.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceCargos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceCargos.Enabled = False
        Me.uceCargos.LimitToList = True
        Me.uceCargos.Location = New System.Drawing.Point(6, 54)
        Me.uceCargos.Name = "uceCargos"
        Me.uceCargos.Size = New System.Drawing.Size(270, 21)
        Me.uceCargos.TabIndex = 56
        '
        'UltraLabel3
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Left"
        Appearance16.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance16
        Me.UltraLabel3.Location = New System.Drawing.Point(6, 3)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(94, 20)
        Me.UltraLabel3.TabIndex = 53
        Me.UltraLabel3.Text = "Tipo de Consulta:"
        '
        'uceEmpleados
        '
        Me.uceEmpleados.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEmpleados.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEmpleados.Enabled = False
        Me.uceEmpleados.LimitToList = True
        Me.uceEmpleados.Location = New System.Drawing.Point(5, 108)
        Me.uceEmpleados.Name = "uceEmpleados"
        Me.uceEmpleados.Size = New System.Drawing.Size(270, 21)
        Me.uceEmpleados.TabIndex = 46
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = "dd/MM/yyyy"
        Me.udtInicio.Location = New System.Drawing.Point(44, 134)
        Me.udtInicio.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(88, 21)
        Me.udtInicio.TabIndex = 49
        '
        'UltraLabel1
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance17
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 135)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(43, 20)
        Me.UltraLabel1.TabIndex = 48
        Me.UltraLabel1.Text = "Desde:"
        '
        'UltraLabel4
        '
        Appearance18.BackColor = System.Drawing.Color.Transparent
        Appearance18.TextHAlignAsString = "Left"
        Appearance18.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance18
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(6, 34)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(38, 14)
        Me.UltraLabel4.TabIndex = 54
        Me.UltraLabel4.Text = "Cargo:"
        '
        'uceTipoConsulta
        '
        Me.uceTipoConsulta.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTipoConsulta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem1.DataValue = "Cargos"
        ValueListItem2.DataValue = "Empleados"
        ValueListItem3.DataValue = "Contactos"
        Me.uceTipoConsulta.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.uceTipoConsulta.LimitToList = True
        Me.uceTipoConsulta.Location = New System.Drawing.Point(106, 3)
        Me.uceTipoConsulta.Name = "uceTipoConsulta"
        Me.uceTipoConsulta.Size = New System.Drawing.Size(170, 21)
        Me.uceTipoConsulta.TabIndex = 55
        '
        'lblAerolinea
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Left"
        Appearance19.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance19
        Me.lblAerolinea.AutoSize = True
        Me.lblAerolinea.Location = New System.Drawing.Point(6, 87)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.Size = New System.Drawing.Size(113, 14)
        Me.lblAerolinea.TabIndex = 47
        Me.lblAerolinea.Text = "Empleado / Contacto:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.42373!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.57627!))
        Me.TableLayoutPanel1.Controls.Add(Me.ugdMarcaciones, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.uebMarcaciones, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1180, 433)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'ugdMarcaciones
        '
        Appearance14.BackColor = System.Drawing.Color.White
        Me.ugdMarcaciones.DisplayLayout.Appearance = Appearance14
        Me.ugdMarcaciones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdMarcaciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugdMarcaciones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugdMarcaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugdMarcaciones.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.BasedOnDataType
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.ugdMarcaciones.DisplayLayout.Override.CardAreaAppearance = Appearance1
        Me.ugdMarcaciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdMarcaciones.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugdMarcaciones.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdMarcaciones.DisplayLayout.Override.RowSelectorAppearance = Appearance8
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance15.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdMarcaciones.DisplayLayout.Override.SelectedRowAppearance = Appearance15
        Me.ugdMarcaciones.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Me.ugdMarcaciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugdMarcaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdMarcaciones.Location = New System.Drawing.Point(3, 3)
        Me.ugdMarcaciones.Name = "ugdMarcaciones"
        Me.ugdMarcaciones.Size = New System.Drawing.Size(884, 427)
        Me.ugdMarcaciones.TabIndex = 10
        Me.ugdMarcaciones.Text = "MARCACIONES"
        '
        'uebMarcaciones
        '
        Me.uebMarcaciones.Controls.Add(Me.UltraExplorerBarContainerControl1)
        Me.uebMarcaciones.Dock = System.Windows.Forms.DockStyle.Fill
        UltraExplorerBarGroup2.Container = Me.UltraExplorerBarContainerControl1
        UltraExplorerBarItem4.Text = "New Item"
        UltraExplorerBarGroup2.Items.AddRange(New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem() {UltraExplorerBarItem4})
        UltraExplorerBarGroup2.Settings.ContainerHeight = 311
        UltraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer
        UltraExplorerBarGroup2.Text = "Consultar"
        Me.uebMarcaciones.Groups.AddRange(New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup() {UltraExplorerBarGroup2})
        Me.uebMarcaciones.Location = New System.Drawing.Point(893, 3)
        Me.uebMarcaciones.Name = "uebMarcaciones"
        Me.uebMarcaciones.Size = New System.Drawing.Size(284, 427)
        Me.uebMarcaciones.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox
        Me.uebMarcaciones.TabIndex = 8
        Me.uebMarcaciones.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2007
        '
        'frmMarcaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 433)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMarcaciones"
        Me.Text = "frmMarcacionesEmpleados"
        Me.UltraExplorerBarContainerControl1.ResumeLayout(False)
        Me.UltraExplorerBarContainerControl1.PerformLayout()
        CType(Me.uceContactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraCheckReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceCargos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTipoConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ugdMarcaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uebMarcaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uebMarcaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents uebMarcaciones As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar
    Friend WithEvents UltraExplorerBarContainerControl1 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl
    Friend WithEvents btnPDF As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uceCargos As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceEmpleados As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceTipoConsulta As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chbCompletas As System.Windows.Forms.CheckBox
    Friend WithEvents ugdMarcaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraCheckReporte As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents DateTimeHoraInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeHoraFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraLabelHoraFin As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabelHoraInicio As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceContactos As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
