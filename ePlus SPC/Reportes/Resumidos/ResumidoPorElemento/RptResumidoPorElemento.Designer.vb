<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptResumidoPorElemento
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
        Me.RptResumidoElemento = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptResumidoElemento
        '
        Me.RptResumidoElemento.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ResumidoElementoDet"
        Me.RptResumidoElemento.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptResumidoElemento.LocalReport.ReportEmbeddedResource = "SPC.ResumidoPorElemento.rdlc"
        Me.RptResumidoElemento.Location = New System.Drawing.Point(0, 0)
        Me.RptResumidoElemento.Name = "RptResumidoElemento"
        Me.RptResumidoElemento.Size = New System.Drawing.Size(743, 427)
        Me.RptResumidoElemento.TabIndex = 0
        '
        'RptResumidoPorElemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 427)
        Me.Controls.Add(Me.RptResumidoElemento)
        Me.Name = "RptResumidoPorElemento"
        Me.Text = "RptResumidoPorAgencia"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptResumidoElemento As Microsoft.Reporting.WinForms.ReportViewer
End Class
