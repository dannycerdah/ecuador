﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptTemperatura
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
        Me.RptvTemperatura = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RptvTemperatura
        '
        Me.RptvTemperatura.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ClassDetalleTemp"
        Me.RptvTemperatura.LocalReport.DataSources.Add(ReportDataSource1)
        Me.RptvTemperatura.LocalReport.ReportEmbeddedResource = "SPC.RptTemperatura.rdlc"
        Me.RptvTemperatura.Location = New System.Drawing.Point(0, 0)
        Me.RptvTemperatura.Name = "RptvTemperatura"
        Me.RptvTemperatura.Size = New System.Drawing.Size(800, 450)
        Me.RptvTemperatura.TabIndex = 1
        '
        'RptTemperatura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RptvTemperatura)
        Me.Name = "RptTemperatura"
        Me.Text = "RptTemperatura"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RptvTemperatura As Microsoft.Reporting.WinForms.ReportViewer
End Class
