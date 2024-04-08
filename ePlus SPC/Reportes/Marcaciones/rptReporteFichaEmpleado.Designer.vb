<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptReporteFichaEmpleado
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DatosFichapersonalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FichaProcesoCargaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FichaMarcacionesAtarasosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FichaMarcacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewFichaEmpl = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DetalleMarcacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DatosFichapersonalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FichaProcesoCargaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FichaMarcacionesAtarasosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FichaMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetalleMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatosFichapersonalBindingSource
        '
        Me.DatosFichapersonalBindingSource.DataSource = GetType(SPC.DatosFichapersonal)
        '
        'FichaProcesoCargaBindingSource
        '
        Me.FichaProcesoCargaBindingSource.DataSource = GetType(SPC.FichaProcesoCarga)
        '
        'FichaMarcacionesAtarasosBindingSource
        '
        Me.FichaMarcacionesAtarasosBindingSource.DataSource = GetType(SPC.FichaMarcacionesAtarasos)
        '
        'FichaMarcacionesBindingSource
        '
        Me.FichaMarcacionesBindingSource.DataSource = GetType(SPC.FichaMarcaciones)
        '
        'ReportViewFichaEmpl
        '
        Me.ReportViewFichaEmpl.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsFicha"
        ReportDataSource1.Value = Me.DatosFichapersonalBindingSource
        ReportDataSource2.Name = "DsFichaCarga"
        ReportDataSource2.Value = Me.FichaProcesoCargaBindingSource
        ReportDataSource3.Name = "DsAtrasos"
        ReportDataSource3.Value = Me.FichaMarcacionesAtarasosBindingSource
        ReportDataSource4.Name = "DsFichaMarcaciones"
        ReportDataSource4.Value = Me.FichaMarcacionesBindingSource
        Me.ReportViewFichaEmpl.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewFichaEmpl.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewFichaEmpl.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewFichaEmpl.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewFichaEmpl.LocalReport.ReportEmbeddedResource = "SPC.ReportFichaPersonalActividad.rdlc"
        Me.ReportViewFichaEmpl.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewFichaEmpl.Name = "ReportViewFichaEmpl"
        Me.ReportViewFichaEmpl.Size = New System.Drawing.Size(669, 375)
        Me.ReportViewFichaEmpl.TabIndex = 0
        Me.ReportViewFichaEmpl.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'DetalleMarcacionesBindingSource
        '
        Me.DetalleMarcacionesBindingSource.DataSource = GetType(SPC.DetalleMarcaciones)
        '
        'rptReporteFichaEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 375)
        Me.Controls.Add(Me.ReportViewFichaEmpl)
        Me.Name = "rptReporteFichaEmpleado"
        Me.Text = "rptReporteFichaEmpleado"
        CType(Me.DatosFichapersonalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FichaProcesoCargaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FichaMarcacionesAtarasosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FichaMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetalleMarcacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewFichaEmpl As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DatosFichapersonalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FichaProcesoCargaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FichaMarcacionesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FichaMarcacionesAtarasosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetalleMarcacionesBindingSource As System.Windows.Forms.BindingSource
End Class
