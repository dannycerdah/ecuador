<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptMarcacionesEmpleados
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DetalleMarcacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportMarcacionesEmpleados = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DetalleMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DetalleMarcacionesBindingSource
        '
        Me.DetalleMarcacionesBindingSource.DataMember = "DetalleMarcaciones"
        '
        'ReportMarcacionesEmpleados
        '
        Me.ReportMarcacionesEmpleados.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSetRptMarcacionEmpleados"
        ReportDataSource1.Value = Me.DetalleMarcacionesBindingSource
        Me.ReportMarcacionesEmpleados.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportMarcacionesEmpleados.LocalReport.ReportEmbeddedResource = "SPC.ReportMarcacionesEmpleadosV30.rdlc"
        Me.ReportMarcacionesEmpleados.Location = New System.Drawing.Point(0, 0)
        Me.ReportMarcacionesEmpleados.Name = "ReportMarcacionesEmpleados"
        Me.ReportMarcacionesEmpleados.Size = New System.Drawing.Size(825, 394)
        Me.ReportMarcacionesEmpleados.TabIndex = 0
        '
        'rptMarcacionesEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 394)
        Me.Controls.Add(Me.ReportMarcacionesEmpleados)
        Me.Name = "rptMarcacionesEmpleados"
        Me.Text = "MarcacionesEmpleados"
        CType(Me.DetalleMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportMarcacionesEmpleados As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DetalleMarcacionesBindingSource As System.Windows.Forms.BindingSource
End Class
