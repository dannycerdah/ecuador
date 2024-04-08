<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.dgvConfgTemp = New System.Windows.Forms.DataGridView()
        Me.txtResponse = New System.Windows.Forms.TextBox()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TimerMenssage = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCuarto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPruetoCom = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnMantenimiento = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvConfgTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvConfgTemp
        '
        Me.dgvConfgTemp.AllowUserToAddRows = False
        Me.dgvConfgTemp.AllowUserToOrderColumns = True
        Me.dgvConfgTemp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConfgTemp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvConfgTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvConfgTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConfgTemp.Location = New System.Drawing.Point(0, 114)
        Me.dgvConfgTemp.Name = "dgvConfgTemp"
        Me.dgvConfgTemp.ReadOnly = True
        Me.dgvConfgTemp.Size = New System.Drawing.Size(551, 107)
        Me.dgvConfgTemp.TabIndex = 5
        '
        'txtResponse
        '
        Me.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResponse.Location = New System.Drawing.Point(560, 3)
        Me.txtResponse.Multiline = True
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResponse.Size = New System.Drawing.Size(605, 221)
        Me.txtResponse.TabIndex = 8
        '
        'txtError
        '
        Me.txtError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtError.Location = New System.Drawing.Point(3, 230)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtError.Size = New System.Drawing.Size(551, 215)
        Me.txtError.TabIndex = 9
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'TimerMenssage
        '
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.70017!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.29983!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtResponse, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtError, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.78534!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.21466!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1168, 448)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvConfgTemp)
        Me.GroupBox2.Controls.Add(Me.cmbCuarto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbPruetoCom)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.btnProcesar)
        Me.GroupBox2.Controls.Add(Me.btnMantenimiento)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(551, 221)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'cmbCuarto
        '
        Me.cmbCuarto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbCuarto.FormattingEnabled = True
        Me.cmbCuarto.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H"})
        Me.cmbCuarto.Location = New System.Drawing.Point(106, 29)
        Me.cmbCuarto.Name = "cmbCuarto"
        Me.cmbCuarto.Size = New System.Drawing.Size(147, 21)
        Me.cmbCuarto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Puerto COM:"
        '
        'cmbPruetoCom
        '
        Me.cmbPruetoCom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbPruetoCom.FormattingEnabled = True
        Me.cmbPruetoCom.Location = New System.Drawing.Point(106, 62)
        Me.cmbPruetoCom.Name = "cmbPruetoCom"
        Me.cmbPruetoCom.Size = New System.Drawing.Size(147, 21)
        Me.cmbPruetoCom.TabIndex = 12
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAgregar.Location = New System.Drawing.Point(265, 65)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(33, 25)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnProcesar.Location = New System.Drawing.Point(399, 65)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(98, 25)
        Me.btnProcesar.TabIndex = 7
        Me.btnProcesar.Text = "Procesar Temp."
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnMantenimiento
        '
        Me.btnMantenimiento.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMantenimiento.Location = New System.Drawing.Point(399, 15)
        Me.btnMantenimiento.Name = "btnMantenimiento"
        Me.btnMantenimiento.Size = New System.Drawing.Size(98, 46)
        Me.btnMantenimiento.TabIndex = 6
        Me.btnMantenimiento.Text = "Mantenimiento Cuartos Frios"
        Me.btnMantenimiento.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuarto:"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 448)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Principal"
        Me.Text = "Principal"
        CType(Me.dgvConfgTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvConfgTemp As DataGridView
    Friend WithEvents txtResponse As TextBox
    Friend WithEvents txtError As TextBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents TimerMenssage As Timer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbCuarto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbPruetoCom As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnProcesar As Button
    Friend WithEvents btnMantenimiento As Button
    Friend WithEvents Label1 As Label
End Class
