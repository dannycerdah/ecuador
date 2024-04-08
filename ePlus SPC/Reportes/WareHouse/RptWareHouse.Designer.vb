<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptWareHouse
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
        Me.WareHouse = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'WareHouse
        '
        Me.WareHouse.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Encabezado"
        ReportDataSource2.Name = "Detalle"
        Me.WareHouse.LocalReport.DataSources.Add(ReportDataSource1)
        Me.WareHouse.LocalReport.DataSources.Add(ReportDataSource2)
        Me.WareHouse.LocalReport.ReportEmbeddedResource = "SPC.WareHouse.rdlc"
        Me.WareHouse.Location = New System.Drawing.Point(0, 0)
        Me.WareHouse.Name = "WareHouse"
        Me.WareHouse.Size = New System.Drawing.Size(666, 407)
        Me.WareHouse.TabIndex = 0
        '
        'RptWareHouse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 407)
        Me.Controls.Add(Me.WareHouse)
        Me.Name = "RptWareHouse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RptWareHouse"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WareHouse As Microsoft.Reporting.WinForms.ReportViewer
End Class
