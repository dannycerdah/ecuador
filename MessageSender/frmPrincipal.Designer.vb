<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Me.TimerMessage = New System.Windows.Forms.Timer(Me.components)
        Me.chkLogDAE = New System.Windows.Forms.CheckBox()
        Me.StopDAE = New System.Windows.Forms.Button()
        Me.nudTimerDAE = New System.Windows.Forms.NumericUpDown()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDocProcessing = New System.Windows.Forms.Label()
        Me.btnStartDoc = New System.Windows.Forms.Button()
        Me.chkDocViewer = New System.Windows.Forms.CheckBox()
        Me.btnStopDOC = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLastExcutionDoc = New System.Windows.Forms.Label()
        Me.chkDocLog = New System.Windows.Forms.CheckBox()
        Me.nudTimerDoc = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDaeProcessing = New System.Windows.Forms.Label()
        Me.btnStartDAE = New System.Windows.Forms.Button()
        Me.chkDAEViewer = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLastExecution = New System.Windows.Forms.Label()
        Me.txtContentVwr = New System.Windows.Forms.TextBox()
        Me.bgwDae = New System.ComponentModel.BackgroundWorker()
        Me.bgwDoc = New System.ComponentModel.BackgroundWorker()
        Me.bgwDas = New System.ComponentModel.BackgroundWorker()
        Me.bgwRem = New System.ComponentModel.BackgroundWorker()
        Me.TabSenae = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgvJobs = New System.Windows.Forms.DataGridView()
        Me.txtJobs = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnDetenerProceso = New System.Windows.Forms.Button()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.NumJob = New System.Windows.Forms.NumericUpDown()
        Me.BtnVerificaTagsa = New System.Windows.Forms.Button()
        Me.cmbTipoEjecucion = New System.Windows.Forms.ComboBox()
        Me.txtNombreJob = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bgwReporteTagsa = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileReportIngresoGA = New System.Windows.Forms.OpenFileDialog()
        Me.bgwCargaJobs = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudTimerRem = New System.Windows.Forms.NumericUpDown()
        Me.lblREMProcessing = New System.Windows.Forms.Label()
        Me.btnStartREM = New System.Windows.Forms.Button()
        Me.btnStopREM = New System.Windows.Forms.Button()
        Me.lblLastExcutionRem = New System.Windows.Forms.Label()
        CType(Me.nudTimerDAE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudTimerDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabSenae.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudTimerRem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkLogDAE
        '
        Me.chkLogDAE.AutoSize = True
        Me.chkLogDAE.Location = New System.Drawing.Point(22, 47)
        Me.chkLogDAE.Name = "chkLogDAE"
        Me.chkLogDAE.Size = New System.Drawing.Size(48, 17)
        Me.chkLogDAE.TabIndex = 0
        Me.chkLogDAE.Text = "LOG"
        Me.chkLogDAE.UseVisualStyleBackColor = True
        '
        'StopDAE
        '
        Me.StopDAE.Location = New System.Drawing.Point(22, 79)
        Me.StopDAE.Name = "StopDAE"
        Me.StopDAE.Size = New System.Drawing.Size(75, 23)
        Me.StopDAE.TabIndex = 1
        Me.StopDAE.Text = "Detener"
        Me.StopDAE.UseVisualStyleBackColor = True
        '
        'nudTimerDAE
        '
        Me.nudTimerDAE.Location = New System.Drawing.Point(109, 14)
        Me.nudTimerDAE.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudTimerDAE.Name = "nudTimerDAE"
        Me.nudTimerDAE.Size = New System.Drawing.Size(61, 20)
        Me.nudTimerDAE.TabIndex = 2
        Me.nudTimerDAE.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(258, 469)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDocProcessing)
        Me.GroupBox2.Controls.Add(Me.btnStartDoc)
        Me.GroupBox2.Controls.Add(Me.chkDocViewer)
        Me.GroupBox2.Controls.Add(Me.btnStopDOC)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblLastExcutionDoc)
        Me.GroupBox2.Controls.Add(Me.chkDocLog)
        Me.GroupBox2.Controls.Add(Me.nudTimerDoc)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 143)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'lblDocProcessing
        '
        Me.lblDocProcessing.AutoSize = True
        Me.lblDocProcessing.Location = New System.Drawing.Point(6, 105)
        Me.lblDocProcessing.Name = "lblDocProcessing"
        Me.lblDocProcessing.Size = New System.Drawing.Size(64, 13)
        Me.lblDocProcessing.TabIndex = 9
        Me.lblDocProcessing.Text = "Procesando"
        '
        'btnStartDoc
        '
        Me.btnStartDoc.Location = New System.Drawing.Point(109, 70)
        Me.btnStartDoc.Name = "btnStartDoc"
        Me.btnStartDoc.Size = New System.Drawing.Size(75, 23)
        Me.btnStartDoc.TabIndex = 9
        Me.btnStartDoc.Text = "Iniciar"
        Me.btnStartDoc.UseVisualStyleBackColor = True
        '
        'chkDocViewer
        '
        Me.chkDocViewer.AutoSize = True
        Me.chkDocViewer.Location = New System.Drawing.Point(150, 47)
        Me.chkDocViewer.Name = "chkDocViewer"
        Me.chkDocViewer.Size = New System.Drawing.Size(49, 17)
        Me.chkDocViewer.TabIndex = 6
        Me.chkDocViewer.Text = "Visor"
        Me.chkDocViewer.UseVisualStyleBackColor = True
        '
        'btnStopDOC
        '
        Me.btnStopDOC.Location = New System.Drawing.Point(22, 70)
        Me.btnStopDOC.Name = "btnStopDOC"
        Me.btnStopDOC.Size = New System.Drawing.Size(75, 23)
        Me.btnStopDOC.TabIndex = 8
        Me.btnStopDOC.Text = "Detener"
        Me.btnStopDOC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Temporizador"
        '
        'lblLastExcutionDoc
        '
        Me.lblLastExcutionDoc.AutoSize = True
        Me.lblLastExcutionDoc.Location = New System.Drawing.Point(5, 127)
        Me.lblLastExcutionDoc.Name = "lblLastExcutionDoc"
        Me.lblLastExcutionDoc.Size = New System.Drawing.Size(85, 13)
        Me.lblLastExcutionDoc.TabIndex = 5
        Me.lblLastExcutionDoc.Text = "Ultima ejecucion"
        '
        'chkDocLog
        '
        Me.chkDocLog.AutoSize = True
        Me.chkDocLog.Location = New System.Drawing.Point(22, 47)
        Me.chkDocLog.Name = "chkDocLog"
        Me.chkDocLog.Size = New System.Drawing.Size(48, 17)
        Me.chkDocLog.TabIndex = 0
        Me.chkDocLog.Text = "LOG"
        Me.chkDocLog.UseVisualStyleBackColor = True
        '
        'nudTimerDoc
        '
        Me.nudTimerDoc.Location = New System.Drawing.Point(109, 14)
        Me.nudTimerDoc.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudTimerDoc.Name = "nudTimerDoc"
        Me.nudTimerDoc.Size = New System.Drawing.Size(61, 20)
        Me.nudTimerDoc.TabIndex = 2
        Me.nudTimerDoc.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDaeProcessing)
        Me.GroupBox1.Controls.Add(Me.btnStartDAE)
        Me.GroupBox1.Controls.Add(Me.chkDAEViewer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblLastExecution)
        Me.GroupBox1.Controls.Add(Me.chkLogDAE)
        Me.GroupBox1.Controls.Add(Me.nudTimerDAE)
        Me.GroupBox1.Controls.Add(Me.StopDAE)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 144)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Actualizacion DAE"
        '
        'lblDaeProcessing
        '
        Me.lblDaeProcessing.AutoSize = True
        Me.lblDaeProcessing.Location = New System.Drawing.Point(7, 105)
        Me.lblDaeProcessing.Name = "lblDaeProcessing"
        Me.lblDaeProcessing.Size = New System.Drawing.Size(64, 13)
        Me.lblDaeProcessing.TabIndex = 8
        Me.lblDaeProcessing.Text = "Procesando"
        '
        'btnStartDAE
        '
        Me.btnStartDAE.Location = New System.Drawing.Point(109, 79)
        Me.btnStartDAE.Name = "btnStartDAE"
        Me.btnStartDAE.Size = New System.Drawing.Size(75, 23)
        Me.btnStartDAE.TabIndex = 7
        Me.btnStartDAE.Text = "Iniciar"
        Me.btnStartDAE.UseVisualStyleBackColor = True
        '
        'chkDAEViewer
        '
        Me.chkDAEViewer.AutoSize = True
        Me.chkDAEViewer.Location = New System.Drawing.Point(150, 47)
        Me.chkDAEViewer.Name = "chkDAEViewer"
        Me.chkDAEViewer.Size = New System.Drawing.Size(49, 17)
        Me.chkDAEViewer.TabIndex = 6
        Me.chkDAEViewer.Text = "Visor"
        Me.chkDAEViewer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Temporizador"
        '
        'lblLastExecution
        '
        Me.lblLastExecution.AutoSize = True
        Me.lblLastExecution.Location = New System.Drawing.Point(7, 127)
        Me.lblLastExecution.Name = "lblLastExecution"
        Me.lblLastExecution.Size = New System.Drawing.Size(85, 13)
        Me.lblLastExecution.TabIndex = 5
        Me.lblLastExecution.Text = "Ultima ejecucion"
        '
        'txtContentVwr
        '
        Me.txtContentVwr.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtContentVwr.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContentVwr.Location = New System.Drawing.Point(267, 3)
        Me.txtContentVwr.Multiline = True
        Me.txtContentVwr.Name = "txtContentVwr"
        Me.txtContentVwr.Size = New System.Drawing.Size(698, 469)
        Me.txtContentVwr.TabIndex = 4
        '
        'bgwDae
        '
        Me.bgwDae.WorkerSupportsCancellation = True
        '
        'bgwDoc
        '
        Me.bgwDoc.WorkerSupportsCancellation = True
        '
        'bgwDas
        '
        Me.bgwDas.WorkerSupportsCancellation = True
        '
        'bgwRem
        '
        Me.bgwRem.WorkerSupportsCancellation = True
        '
        'TabSenae
        '
        Me.TabSenae.Controls.Add(Me.TabPage1)
        Me.TabSenae.Controls.Add(Me.TabPage2)
        Me.TabSenae.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabSenae.Location = New System.Drawing.Point(0, 0)
        Me.TabSenae.Name = "TabSenae"
        Me.TabSenae.SelectedIndex = 0
        Me.TabSenae.Size = New System.Drawing.Size(976, 501)
        Me.TabSenae.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.txtContentVwr)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(968, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(968, 475)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DgvJobs)
        Me.GroupBox4.Controls.Add(Me.txtJobs)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox4.Location = New System.Drawing.Point(232, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(733, 469)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'DgvJobs
        '
        Me.DgvJobs.AllowUserToAddRows = False
        Me.DgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvJobs.Dock = System.Windows.Forms.DockStyle.Top
        Me.DgvJobs.Location = New System.Drawing.Point(3, 16)
        Me.DgvJobs.Name = "DgvJobs"
        Me.DgvJobs.Size = New System.Drawing.Size(727, 153)
        Me.DgvJobs.TabIndex = 8
        '
        'txtJobs
        '
        Me.txtJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobs.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobs.Location = New System.Drawing.Point(3, 167)
        Me.txtJobs.Multiline = True
        Me.txtJobs.Name = "txtJobs"
        Me.txtJobs.Size = New System.Drawing.Size(727, 299)
        Me.txtJobs.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnDetenerProceso)
        Me.GroupBox3.Controls.Add(Me.BtnRefresh)
        Me.GroupBox3.Controls.Add(Me.BtnAgregar)
        Me.GroupBox3.Controls.Add(Me.NumJob)
        Me.GroupBox3.Controls.Add(Me.BtnVerificaTagsa)
        Me.GroupBox3.Controls.Add(Me.cmbTipoEjecucion)
        Me.GroupBox3.Controls.Add(Me.txtNombreJob)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(962, 469)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'BtnDetenerProceso
        '
        Me.BtnDetenerProceso.Location = New System.Drawing.Point(120, 167)
        Me.BtnDetenerProceso.Name = "BtnDetenerProceso"
        Me.BtnDetenerProceso.Size = New System.Drawing.Size(103, 39)
        Me.BtnDetenerProceso.TabIndex = 8
        Me.BtnDetenerProceso.Text = "Detener Proceso Tagsa"
        Me.BtnDetenerProceso.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Location = New System.Drawing.Point(120, 119)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(103, 42)
        Me.BtnRefresh.TabIndex = 7
        Me.BtnRefresh.Text = "Refrescar Informacion"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Location = New System.Drawing.Point(9, 119)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(95, 42)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'NumJob
        '
        Me.NumJob.Location = New System.Drawing.Point(106, 81)
        Me.NumJob.Name = "NumJob"
        Me.NumJob.Size = New System.Drawing.Size(51, 20)
        Me.NumJob.TabIndex = 5
        '
        'BtnVerificaTagsa
        '
        Me.BtnVerificaTagsa.Location = New System.Drawing.Point(9, 167)
        Me.BtnVerificaTagsa.Name = "BtnVerificaTagsa"
        Me.BtnVerificaTagsa.Size = New System.Drawing.Size(95, 39)
        Me.BtnVerificaTagsa.TabIndex = 6
        Me.BtnVerificaTagsa.Text = "Ejecutar Proceso Tagsa"
        Me.BtnVerificaTagsa.UseVisualStyleBackColor = True
        '
        'cmbTipoEjecucion
        '
        Me.cmbTipoEjecucion.FormattingEnabled = True
        Me.cmbTipoEjecucion.Items.AddRange(New Object() {"Seleccione Tipo Ejecucion", "A", "M", "D", "H", "MI"})
        Me.cmbTipoEjecucion.Location = New System.Drawing.Point(106, 54)
        Me.cmbTipoEjecucion.Name = "cmbTipoEjecucion"
        Me.cmbTipoEjecucion.Size = New System.Drawing.Size(117, 21)
        Me.cmbTipoEjecucion.TabIndex = 4
        '
        'txtNombreJob
        '
        Me.txtNombreJob.Location = New System.Drawing.Point(106, 26)
        Me.txtNombreJob.Name = "txtNombreJob"
        Me.txtNombreJob.Size = New System.Drawing.Size(117, 20)
        Me.txtNombreJob.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tiempo Ejecucion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Tipo Ejecucion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nombre Job:"
        '
        'bgwReporteTagsa
        '
        Me.bgwReporteTagsa.WorkerSupportsCancellation = True
        '
        'OpenFileReportIngresoGA
        '
        Me.OpenFileReportIngresoGA.FileName = "OpenFileDialog1"
        '
        'bgwCargaJobs
        '
        Me.bgwCargaJobs.WorkerSupportsCancellation = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblREMProcessing)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.btnStartREM)
        Me.GroupBox5.Controls.Add(Me.nudTimerRem)
        Me.GroupBox5.Controls.Add(Me.btnStopREM)
        Me.GroupBox5.Controls.Add(Me.lblLastExcutionRem)
        Me.GroupBox5.Location = New System.Drawing.Point(0, 287)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(258, 158)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Proceso Rem"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Temporizador"
        '
        'nudTimerRem
        '
        Me.nudTimerRem.Location = New System.Drawing.Point(101, 28)
        Me.nudTimerRem.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudTimerRem.Name = "nudTimerRem"
        Me.nudTimerRem.Size = New System.Drawing.Size(61, 20)
        Me.nudTimerRem.TabIndex = 10
        Me.nudTimerRem.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'lblREMProcessing
        '
        Me.lblREMProcessing.AutoSize = True
        Me.lblREMProcessing.Location = New System.Drawing.Point(-2, 116)
        Me.lblREMProcessing.Name = "lblREMProcessing"
        Me.lblREMProcessing.Size = New System.Drawing.Size(64, 13)
        Me.lblREMProcessing.TabIndex = 14
        Me.lblREMProcessing.Text = "Procesando"
        '
        'btnStartREM
        '
        Me.btnStartREM.Location = New System.Drawing.Point(109, 61)
        Me.btnStartREM.Name = "btnStartREM"
        Me.btnStartREM.Size = New System.Drawing.Size(75, 23)
        Me.btnStartREM.TabIndex = 15
        Me.btnStartREM.Text = "Iniciar"
        Me.btnStartREM.UseVisualStyleBackColor = True
        '
        'btnStopREM
        '
        Me.btnStopREM.Location = New System.Drawing.Point(22, 61)
        Me.btnStopREM.Name = "btnStopREM"
        Me.btnStopREM.Size = New System.Drawing.Size(75, 23)
        Me.btnStopREM.TabIndex = 13
        Me.btnStopREM.Text = "Detener"
        Me.btnStopREM.UseVisualStyleBackColor = True
        '
        'lblLastExcutionRem
        '
        Me.lblLastExcutionRem.AutoSize = True
        Me.lblLastExcutionRem.Location = New System.Drawing.Point(-3, 138)
        Me.lblLastExcutionRem.Name = "lblLastExcutionRem"
        Me.lblLastExcutionRem.Size = New System.Drawing.Size(85, 13)
        Me.lblLastExcutionRem.TabIndex = 11
        Me.lblLastExcutionRem.Text = "Ultima ejecucion"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 501)
        Me.Controls.Add(Me.TabSenae)
        Me.Name = "frmPrincipal"
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.nudTimerDAE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudTimerDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSenae.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudTimerRem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerMessage As System.Windows.Forms.Timer
    Friend WithEvents chkLogDAE As System.Windows.Forms.CheckBox
    Friend WithEvents StopDAE As System.Windows.Forms.Button
    Friend WithEvents nudTimerDAE As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLastExecution As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContentVwr As System.Windows.Forms.TextBox
    Friend WithEvents chkDAEViewer As System.Windows.Forms.CheckBox
    Friend WithEvents bgwDae As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDocViewer As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLastExcutionDoc As System.Windows.Forms.Label
    Friend WithEvents chkDocLog As System.Windows.Forms.CheckBox
    Friend WithEvents nudTimerDoc As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnStartDoc As System.Windows.Forms.Button
    Friend WithEvents btnStopDOC As System.Windows.Forms.Button
    Friend WithEvents btnStartDAE As System.Windows.Forms.Button
    Friend WithEvents bgwDoc As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDocProcessing As System.Windows.Forms.Label
    Friend WithEvents lblDaeProcessing As System.Windows.Forms.Label
    Friend WithEvents bgwDas As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgwRem As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabSenae As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BtnVerificaTagsa As Button
    Friend WithEvents txtJobs As TextBox
    Friend WithEvents bgwReporteTagsa As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileReportIngresoGA As OpenFileDialog
    Friend WithEvents DgvJobs As DataGridView
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents NumJob As NumericUpDown
    Friend WithEvents cmbTipoEjecucion As ComboBox
    Friend WithEvents txtNombreJob As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents BtnDetenerProceso As Button
    Friend WithEvents bgwCargaJobs As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lblREMProcessing As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnStartREM As Button
    Friend WithEvents nudTimerRem As NumericUpDown
    Friend WithEvents btnStopREM As Button
    Friend WithEvents lblLastExcutionRem As Label
End Class
