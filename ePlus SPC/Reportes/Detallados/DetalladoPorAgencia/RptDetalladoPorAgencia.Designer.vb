<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptDetalladoPorAgencia
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
        Me.RptDetalladoAgencia = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptDetalladoAgencia
        '
        Me.RptDetalladoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DetalladoAgenciaDet"
        Me.RptDetalladoAgencia.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptDetalladoAgencia.LocalReport.ReportEmbeddedResource = "SPC.DetalladoPorAgencia.rdlc"
        Me.RptDetalladoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.RptDetalladoAgencia.Name = "RptDetalladoAgencia"
        Me.RptDetalladoAgencia.Size = New System.Drawing.Size(743, 427)
        Me.RptDetalladoAgencia.TabIndex = 0
        '
        'RptDetalladoPorAgencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 427)
        Me.Controls.Add(Me.RptDetalladoAgencia)
        Me.Name = "RptDetalladoPorAgencia"
        Me.Text = "RptResumidoPorAgencia"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptDetalladoAgencia As Microsoft.Reporting.WinForms.ReportViewer
End Class
