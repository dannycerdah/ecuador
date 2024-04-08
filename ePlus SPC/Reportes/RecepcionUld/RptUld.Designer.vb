<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptUld
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
        Me.RptRecepcionUld = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.elementoUldBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EncabezadoUldBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.elementoUldBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EncabezadoUldBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RptRecepcionUld
        '
        Me.RptRecepcionUld.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Detalle"
        ReportDataSource1.Value = Me.elementoUldBindingSource
        ReportDataSource2.Name = "Encabezado"
        ReportDataSource2.Value = Me.EncabezadoUldBindingSource
        Me.RptRecepcionUld.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptRecepcionUld.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RptRecepcionUld.LocalReport.ReportEmbeddedResource = "SPC.rptULD.rdlc"
        Me.RptRecepcionUld.Location = New System.Drawing.Point(0, 0)
        Me.RptRecepcionUld.Name = "RptRecepcionUld"
        Me.RptRecepcionUld.Size = New System.Drawing.Size(743, 427)
        Me.RptRecepcionUld.TabIndex = 0
        '
        'elementoUldBindingSource
        '
        Me.elementoUldBindingSource.DataSource = GetType(SPC.elementoUld)
        '
        'EncabezadoUldBindingSource
        '
        Me.EncabezadoUldBindingSource.DataSource = GetType(SPC.EncabezadoUld)
        '
        'RptUld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 427)
        Me.Controls.Add(Me.RptRecepcionUld)
        Me.Name = "RptUld"
        Me.Text = "RptResumidoPorAgencia"
        CType(Me.elementoUldBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EncabezadoUldBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RptRecepcionUld As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents elementoUldBindingSource As BindingSource
    Friend WithEvents EncabezadoUldBindingSource As BindingSource
End Class
