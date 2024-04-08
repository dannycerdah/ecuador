<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptReportFlights
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
        Me.ReportFlights = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'ReportFlights
        '
        Me.ReportFlights.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportFlights.LocalReport.ReportEmbeddedResource = "SPC.ReportFlights.rdlc"
        Me.ReportFlights.Location = New System.Drawing.Point(0, 0)
        Me.ReportFlights.Name = "ReportFlights"
        Me.ReportFlights.Size = New System.Drawing.Size(669, 409)
        Me.ReportFlights.TabIndex = 0
        '
        'RptReportFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 409)
        Me.Controls.Add(Me.ReportFlights)
        Me.Name = "RptReportFlights"
        Me.Text = "RptReportFlights"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportFlights As Microsoft.Reporting.WinForms.ReportViewer
End Class
