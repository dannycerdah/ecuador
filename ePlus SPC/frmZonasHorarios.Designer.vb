<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZonasHorarios
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
        Me.dgvHorarios = New System.Windows.Forms.DataGridView()
        Me.dia = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.horario_desde = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.horario_hasta = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvHorarios
        '
        Me.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHorarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dia, Me.horario_desde, Me.horario_hasta})
        Me.dgvHorarios.Location = New System.Drawing.Point(12, 12)
        Me.dgvHorarios.Name = "dgvHorarios"
        Me.dgvHorarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvHorarios.Size = New System.Drawing.Size(366, 151)
        Me.dgvHorarios.TabIndex = 82
        '
        'dia
        '
        Me.dia.HeaderText = "Día"
        Me.dia.Items.AddRange(New Object() {"LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO"})
        Me.dia.Name = "dia"
        Me.dia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'horario_desde
        '
        Me.horario_desde.HeaderText = "Desde"
        Me.horario_desde.Items.AddRange(New Object() {"00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"})
        Me.horario_desde.Name = "horario_desde"
        Me.horario_desde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'horario_hasta
        '
        Me.horario_hasta.HeaderText = "Hasta"
        Me.horario_hasta.Items.AddRange(New Object() {"00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"})
        Me.horario_hasta.Name = "horario_hasta"
        Me.horario_hasta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(318, 169)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(60, 27)
        Me.btnAgregar.TabIndex = 83
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmZonasHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 201)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvHorarios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmZonasHorarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Horarios"
        CType(Me.dgvHorarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHorarios As DataGridView
    Friend WithEvents dia As DataGridViewComboBoxColumn
    Friend WithEvents horario_desde As DataGridViewComboBoxColumn
    Friend WithEvents horario_hasta As DataGridViewComboBoxColumn
    Friend WithEvents btnAgregar As Button
End Class
