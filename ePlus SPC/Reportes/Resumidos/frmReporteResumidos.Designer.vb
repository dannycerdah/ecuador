<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteResumidos
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteResumidos))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceGuia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceDestino = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ucePallet = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.rdbMan = New System.Windows.Forms.RadioButton()
        Me.rdbGuia = New System.Windows.Forms.RadioButton()
        Me.rdbDestino = New System.Windows.Forms.RadioButton()
        Me.rdbPalet = New System.Windows.Forms.RadioButton()
        Me.rdbAgencia = New System.Windows.Forms.RadioButton()
        Me.btnImprimir = New Infragistics.Win.Misc.UltraButton()
        Me.txtAvion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblFecha = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAvion = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNumVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtAgencia = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblMatricula = New Infragistics.Win.Misc.UltraLabel()
        Me.lblVuelo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.ugvCarga = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.utcControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage3 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugbCarga = New Infragistics.Win.Misc.UltraGroupBox()
        Me.SP1 = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.uceGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucePallet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.ugvCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utcControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcControl1.SuspendLayout()
        CType(Me.ugbCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCarga.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox1)
        Me.ugbDatosVuelo.Controls.Add(Me.btnImprimir)
        Me.ugbDatosVuelo.Controls.Add(Me.txtAvion)
        Me.ugbDatosVuelo.Controls.Add(Me.udtFecha)
        Me.ugbDatosVuelo.Controls.Add(Me.lblFecha)
        Me.ugbDatosVuelo.Controls.Add(Me.lblAvion)
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsVuelo)
        Me.ugbDatosVuelo.Controls.Add(Me.txtMatricula)
        Me.ugbDatosVuelo.Controls.Add(Me.txtNumVuelo)
        Me.ugbDatosVuelo.Controls.Add(Me.txtAgencia)
        Me.ugbDatosVuelo.Controls.Add(Me.lblMatricula)
        Me.ugbDatosVuelo.Controls.Add(Me.lblVuelo)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(702, 328)
        Me.ugbDatosVuelo.TabIndex = 11
        Me.ugbDatosVuelo.Text = "Datos de Vuelo"
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.uceGuia)
        Me.UltraGroupBox1.Controls.Add(Me.uceDestino)
        Me.UltraGroupBox1.Controls.Add(Me.ucePallet)
        Me.UltraGroupBox1.Controls.Add(Me.uceAgencia)
        Me.UltraGroupBox1.Controls.Add(Me.rdbMan)
        Me.UltraGroupBox1.Controls.Add(Me.rdbGuia)
        Me.UltraGroupBox1.Controls.Add(Me.rdbDestino)
        Me.UltraGroupBox1.Controls.Add(Me.rdbPalet)
        Me.UltraGroupBox1.Controls.Add(Me.rdbAgencia)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(29, 90)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(561, 233)
        Me.UltraGroupBox1.TabIndex = 39
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceGuia
        '
        Me.uceGuia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceGuia.LimitToList = True
        Me.uceGuia.Location = New System.Drawing.Point(212, 144)
        Me.uceGuia.Name = "uceGuia"
        Me.uceGuia.Size = New System.Drawing.Size(194, 21)
        Me.uceGuia.TabIndex = 61
        '
        'uceDestino
        '
        Me.uceDestino.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceDestino.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceDestino.LimitToList = True
        Me.uceDestino.Location = New System.Drawing.Point(212, 103)
        Me.uceDestino.Name = "uceDestino"
        Me.uceDestino.Size = New System.Drawing.Size(194, 21)
        Me.uceDestino.TabIndex = 60
        '
        'ucePallet
        '
        Me.ucePallet.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePallet.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePallet.LimitToList = True
        Me.ucePallet.Location = New System.Drawing.Point(212, 62)
        Me.ucePallet.Name = "ucePallet"
        Me.ucePallet.Size = New System.Drawing.Size(194, 21)
        Me.ucePallet.TabIndex = 59
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(212, 21)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(194, 21)
        Me.uceAgencia.TabIndex = 58
        '
        'rdbMan
        '
        Me.rdbMan.AutoSize = True
        Me.rdbMan.BackColor = System.Drawing.Color.Transparent
        Me.rdbMan.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMan.Location = New System.Drawing.Point(30, 175)
        Me.rdbMan.Name = "rdbMan"
        Me.rdbMan.Size = New System.Drawing.Size(292, 35)
        Me.rdbMan.TabIndex = 57
        Me.rdbMan.Text = "Manipuelo de Carga"
        Me.rdbMan.UseVisualStyleBackColor = False
        '
        'rdbGuia
        '
        Me.rdbGuia.AutoSize = True
        Me.rdbGuia.BackColor = System.Drawing.Color.Transparent
        Me.rdbGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbGuia.Location = New System.Drawing.Point(30, 134)
        Me.rdbGuia.Name = "rdbGuia"
        Me.rdbGuia.Size = New System.Drawing.Size(93, 35)
        Me.rdbGuia.TabIndex = 56
        Me.rdbGuia.Text = "Guia"
        Me.rdbGuia.UseVisualStyleBackColor = False
        '
        'rdbDestino
        '
        Me.rdbDestino.AutoSize = True
        Me.rdbDestino.BackColor = System.Drawing.Color.Transparent
        Me.rdbDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbDestino.Location = New System.Drawing.Point(30, 93)
        Me.rdbDestino.Name = "rdbDestino"
        Me.rdbDestino.Size = New System.Drawing.Size(132, 35)
        Me.rdbDestino.TabIndex = 55
        Me.rdbDestino.Text = "Destino"
        Me.rdbDestino.UseVisualStyleBackColor = False
        '
        'rdbPalet
        '
        Me.rdbPalet.AutoSize = True
        Me.rdbPalet.BackColor = System.Drawing.Color.Transparent
        Me.rdbPalet.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbPalet.Location = New System.Drawing.Point(30, 52)
        Me.rdbPalet.Name = "rdbPalet"
        Me.rdbPalet.Size = New System.Drawing.Size(106, 35)
        Me.rdbPalet.TabIndex = 54
        Me.rdbPalet.Text = "Pallet"
        Me.rdbPalet.UseVisualStyleBackColor = False
        '
        'rdbAgencia
        '
        Me.rdbAgencia.AutoSize = True
        Me.rdbAgencia.BackColor = System.Drawing.Color.Transparent
        Me.rdbAgencia.Checked = True
        Me.rdbAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbAgencia.Location = New System.Drawing.Point(30, 11)
        Me.rdbAgencia.Name = "rdbAgencia"
        Me.rdbAgencia.Size = New System.Drawing.Size(137, 35)
        Me.rdbAgencia.TabIndex = 53
        Me.rdbAgencia.TabStop = True
        Me.rdbAgencia.Text = "Agencia"
        Me.rdbAgencia.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Appearance1.Image = CType(resources.GetObject("Appearance1.Image"), Object)
        Me.btnImprimir.Appearance = Appearance1
        Me.btnImprimir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnImprimir.Location = New System.Drawing.Point(603, 25)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(95, 27)
        Me.btnImprimir.TabIndex = 38
        Me.btnImprimir.Text = "Imprimir"
        '
        'txtAvion
        '
        Me.txtAvion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAvion.Enabled = False
        Me.txtAvion.Location = New System.Drawing.Point(476, 27)
        Me.txtAvion.Name = "txtAvion"
        Me.txtAvion.ReadOnly = True
        Me.txtAvion.Size = New System.Drawing.Size(114, 21)
        Me.txtAvion.TabIndex = 5
        '
        'udtFecha
        '
        Me.udtFecha.DateTime = New Date(2014, 8, 16, 0, 0, 0, 0)
        Me.udtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFecha.Location = New System.Drawing.Point(476, 52)
        Me.udtFecha.MaskInput = "dd/mm/yyyy"
        Me.udtFecha.Name = "udtFecha"
        Me.udtFecha.ReadOnly = True
        Me.udtFecha.Size = New System.Drawing.Size(114, 21)
        Me.udtFecha.TabIndex = 6
        Me.udtFecha.Value = New Date(2014, 8, 16, 0, 0, 0, 0)
        '
        'lblFecha
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblFecha.Appearance = Appearance6
        Me.lblFecha.Location = New System.Drawing.Point(396, 54)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFecha.Size = New System.Drawing.Size(60, 20)
        Me.lblFecha.TabIndex = 11
        Me.lblFecha.Text = "Fecha:"
        '
        'lblAvion
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblAvion.Appearance = Appearance9
        Me.lblAvion.Location = New System.Drawing.Point(396, 27)
        Me.lblAvion.Name = "lblAvion"
        Me.lblAvion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAvion.Size = New System.Drawing.Size(60, 20)
        Me.lblAvion.TabIndex = 10
        Me.lblAvion.Text = "Avion:"
        '
        'btnConsVuelo
        '
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.btnConsVuelo.Appearance = Appearance13
        Me.btnConsVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsVuelo.Location = New System.Drawing.Point(311, 25)
        Me.btnConsVuelo.Name = "btnConsVuelo"
        Me.btnConsVuelo.Size = New System.Drawing.Size(27, 27)
        Me.btnConsVuelo.TabIndex = 3
        '
        'txtMatricula
        '
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Enabled = False
        Me.txtMatricula.Location = New System.Drawing.Point(95, 54)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.ReadOnly = True
        Me.txtMatricula.Size = New System.Drawing.Size(101, 21)
        Me.txtMatricula.TabIndex = 4
        '
        'txtNumVuelo
        '
        Me.txtNumVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNumVuelo.Enabled = False
        Me.txtNumVuelo.Location = New System.Drawing.Point(208, 28)
        Me.txtNumVuelo.Name = "txtNumVuelo"
        Me.txtNumVuelo.ReadOnly = True
        Me.txtNumVuelo.Size = New System.Drawing.Size(91, 21)
        Me.txtNumVuelo.TabIndex = 2
        '
        'txtAgencia
        '
        Me.txtAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAgencia.Enabled = False
        Me.txtAgencia.Location = New System.Drawing.Point(95, 27)
        Me.txtAgencia.Name = "txtAgencia"
        Me.txtAgencia.ReadOnly = True
        Me.txtAgencia.Size = New System.Drawing.Size(101, 21)
        Me.txtAgencia.TabIndex = 1
        '
        'lblMatricula
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblMatricula.Appearance = Appearance14
        Me.lblMatricula.Location = New System.Drawing.Point(29, 54)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMatricula.Size = New System.Drawing.Size(60, 20)
        Me.lblMatricula.TabIndex = 4
        Me.lblMatricula.Text = "Matricula:"
        '
        'lblVuelo
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblVuelo.Appearance = Appearance7
        Me.lblVuelo.Location = New System.Drawing.Point(29, 28)
        Me.lblVuelo.Name = "lblVuelo"
        Me.lblVuelo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVuelo.Size = New System.Drawing.Size(60, 20)
        Me.lblVuelo.TabIndex = 3
        Me.lblVuelo.Text = "Vuelo:"
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(196, 77)
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(976, 290)
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(200, 100)
        Me.UltraTabControl1.TabIndex = 0
        '
        'ugvCarga
        '
        Appearance15.BackColor = System.Drawing.Color.White
        Me.ugvCarga.DisplayLayout.Appearance = Appearance15
        Me.ugvCarga.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvCarga.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Me.ugvCarga.DisplayLayout.Override.CardAreaAppearance = Appearance16
        Me.ugvCarga.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance17.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance17.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.Name = "Arial"
        Appearance17.FontData.SizeInPoints = 10.0!
        Appearance17.ForeColor = System.Drawing.Color.White
        Appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvCarga.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugvCarga.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance27.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance27.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvCarga.DisplayLayout.Override.RowSelectorAppearance = Appearance27
        Appearance28.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance28.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvCarga.DisplayLayout.Override.SelectedRowAppearance = Appearance28
        Me.ugvCarga.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvCarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvCarga.Location = New System.Drawing.Point(3, 0)
        Me.ugvCarga.Name = "ugvCarga"
        Me.ugvCarga.Size = New System.Drawing.Size(1076, 171)
        Me.ugvCarga.TabIndex = 5
        '
        'utcControl1
        '
        Me.utcControl1.Controls.Add(Me.UltraTabSharedControlsPage3)
        Me.utcControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.utcControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.utcControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.utcControl1.Controls.Add(Me.UltraTabPageControl7)
        Me.utcControl1.Location = New System.Drawing.Point(0, 0)
        Me.utcControl1.Name = "utcControl1"
        Me.utcControl1.SharedControlsPage = Me.UltraTabSharedControlsPage3
        Me.utcControl1.Size = New System.Drawing.Size(200, 100)
        Me.utcControl1.TabIndex = 0
        '
        'UltraTabSharedControlsPage3
        '
        Me.UltraTabSharedControlsPage3.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage3.Name = "UltraTabSharedControlsPage3"
        Me.UltraTabSharedControlsPage3.Size = New System.Drawing.Size(196, 77)
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(1081, 82)
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(1081, 102)
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(1081, 102)
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(1081, 102)
        '
        'ugbCarga
        '
        Me.ugbCarga.Controls.Add(Me.ugvCarga)
        Me.ugbCarga.Location = New System.Drawing.Point(120, 113)
        Me.ugbCarga.Name = "ugbCarga"
        Me.ugbCarga.Size = New System.Drawing.Size(1082, 174)
        Me.ugbCarga.TabIndex = 23
        Me.ugbCarga.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'frmReporteResumidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(702, 325)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReporteResumidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Resumido"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.uceGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucePallet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.ugvCarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utcControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcControl1.ResumeLayout(False)
        CType(Me.ugbCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCarga.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblMatricula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtNumVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtAgencia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnConsVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtAvion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents udtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblFecha As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAvion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents ugvCarga As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utcControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage3 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents ugbCarga As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SP1 As System.IO.Ports.SerialPort
    Friend WithEvents lblVuelo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents rdbGuia As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDestino As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPalet As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAgencia As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMan As System.Windows.Forms.RadioButton
    Friend WithEvents uceGuia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceDestino As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ucePallet As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
