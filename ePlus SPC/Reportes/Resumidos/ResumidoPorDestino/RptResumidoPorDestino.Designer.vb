<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptResumidoPorDestino
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
        Me.RptResumidoDestino = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptResumidoDestino
        '
        Me.RptResumidoDestino.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ResumidoDestinoDet"
        Me.RptResumidoDestino.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptResumidoDestino.LocalReport.ReportEmbeddedResource = "SPC.ResumidoPorDestino.rdlc"
        Me.RptResumidoDestino.Location = New System.Drawing.Point(0, 0)
        Me.RptResumidoDestino.Name = "RptResumidoDestino"
        Me.RptResumidoDestino.Size = New System.Drawing.Size(743, 427)
        Me.RptResumidoDestino.TabIndex = 0
        '
        'RptResumidoPorDestino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 427)
        Me.Controls.Add(Me.RptResumidoDestino)
        Me.Name = "RptResumidoPorDestino"
        Me.Text = "RptResumidoPorAgencia"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptResumidoDestino As Microsoft.Reporting.WinForms.ReportViewer
End Class
