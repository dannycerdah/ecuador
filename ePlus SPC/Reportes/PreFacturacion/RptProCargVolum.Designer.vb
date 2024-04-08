<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptProCargVolum
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.RptProCargVolumen = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptProCargVolumen
        '
        Me.RptProCargVolumen.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DetallePesoVolumenVuelo"
        ReportDataSource1.Value = Nothing
        ReportDataSource2.Name = "ListDetallePesoVolumenVuelo"
        ReportDataSource2.Value = Nothing
        Me.RptProCargVolumen.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptProCargVolumen.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RptProCargVolumen.LocalReport.ReportEmbeddedResource = "SPC.RptProCargVolum.rdlc"
        Me.RptProCargVolumen.Location = New System.Drawing.Point(0, 0)
        Me.RptProCargVolumen.Name = "RptProCargVolumen"
        Me.RptProCargVolumen.Size = New System.Drawing.Size(756, 366)
        Me.RptProCargVolumen.TabIndex = 1
        '
        'RptProCargVolum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 366)
        Me.Controls.Add(Me.RptProCargVolumen)
        Me.Name = "RptProCargVolum"
        Me.Text = "RptProCargVolum"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptProCargVolumen As Microsoft.Reporting.WinForms.ReportViewer
End Class
