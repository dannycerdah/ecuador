<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MantCuartoFrios
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
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cmbCuarto = New System.Windows.Forms.ComboBox()
        Me.txtDescrip = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCuartos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbNum = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbNum2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvCuartos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(339, 108)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(26, 23)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cmbCuarto
        '
        Me.cmbCuarto.FormattingEnabled = True
        Me.cmbCuarto.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H"})
        Me.cmbCuarto.Location = New System.Drawing.Point(61, 10)
        Me.cmbCuarto.Name = "cmbCuarto"
        Me.cmbCuarto.Size = New System.Drawing.Size(83, 21)
        Me.cmbCuarto.TabIndex = 0
        '
        'txtDescrip
        '
        Me.txtDescrip.Location = New System.Drawing.Point(86, 78)
        Me.txtDescrip.Multiline = True
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(233, 53)
        Me.txtDescrip.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripcion:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Cuarto:"
        '
        'dgvCuartos
        '
        Me.dgvCuartos.AllowUserToAddRows = False
        Me.dgvCuartos.AllowUserToOrderColumns = True
        Me.dgvCuartos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCuartos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuartos.Location = New System.Drawing.Point(12, 141)
        Me.dgvCuartos.Name = "dgvCuartos"
        Me.dgvCuartos.ReadOnly = True
        Me.dgvCuartos.Size = New System.Drawing.Size(353, 122)
        Me.dgvCuartos.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "CERRAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbNum
        '
        Me.cmbNum.FormattingEnabled = True
        Me.cmbNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbNum.Location = New System.Drawing.Point(61, 37)
        Me.cmbNum.Name = "cmbNum"
        Me.cmbNum.Size = New System.Drawing.Size(34, 21)
        Me.cmbNum.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Num:"
        '
        'cmbNum2
        '
        Me.cmbNum2.FormattingEnabled = True
        Me.cmbNum2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbNum2.Location = New System.Drawing.Point(116, 37)
        Me.cmbNum2.Name = "cmbNum2"
        Me.cmbNum2.Size = New System.Drawing.Size(33, 21)
        Me.cmbNum2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(96, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MantCuartoFrios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 268)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbNum2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbNum)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvCuartos)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cmbCuarto)
        Me.Controls.Add(Me.txtDescrip)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MantCuartoFrios"
        Me.Text = "MantCuartoFrios"
        CType(Me.dgvCuartos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAgregar As Button
    Friend WithEvents cmbCuarto As ComboBox
    Friend WithEvents txtDescrip As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvCuartos As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbNum As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbNum2 As ComboBox
    Friend WithEvents Label4 As Label
End Class
