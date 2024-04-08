<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptTotalServicios
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
        Me.RptTotalServFact = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptTotalServFact
        '
        Me.RptTotalServFact.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DetalleServicoFacturar"
        ReportDataSource2.Name = "ListDetallesServicosFacturar"
        Me.RptTotalServFact.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptTotalServFact.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RptTotalServFact.LocalReport.ReportEmbeddedResource = "SPC.RptTotalServiciosFact.rdlc"
        Me.RptTotalServFact.Location = New System.Drawing.Point(0, 0)
        Me.RptTotalServFact.Name = "RptTotalServFact"
        Me.RptTotalServFact.Size = New System.Drawing.Size(715, 257)
        Me.RptTotalServFact.TabIndex = 2
        '
        'RptTotalServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 257)
        Me.Controls.Add(Me.RptTotalServFact)
        Me.Name = "RptTotalServicios"
        Me.Text = "RptTotalServicios"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptTotalServFact As Microsoft.Reporting.WinForms.ReportViewer
End Class
