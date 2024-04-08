<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptMarcaciones
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.WareHouseMarcaciones = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'WareHouseMarcaciones
        '
        Me.WareHouseMarcaciones.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dtsMarcaciones"
        ReportDataSource2.Name = "dtsEncabezadoMarcaciones"
        Me.WareHouseMarcaciones.LocalReport.DataSources.Add(ReportDataSource1)
        Me.WareHouseMarcaciones.LocalReport.DataSources.Add(ReportDataSource2)
        Me.WareHouseMarcaciones.LocalReport.ReportEmbeddedResource = "SPC.Marcaciones.rdlc"
        Me.WareHouseMarcaciones.Location = New System.Drawing.Point(0, 0)
        Me.WareHouseMarcaciones.Name = "WareHouseMarcaciones"
        Me.WareHouseMarcaciones.Size = New System.Drawing.Size(669, 429)
        Me.WareHouseMarcaciones.TabIndex = 1
        '
        'rptMarcaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 429)
        Me.Controls.Add(Me.WareHouseMarcaciones)
        Me.Name = "rptMarcaciones"
        Me.Text = "Reporte de Marcaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WareHouseMarcaciones As Microsoft.Reporting.WinForms.ReportViewer
End Class
