﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RptActEntregaRecep
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportPersonDeco = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'ReportPersonDeco
        '
        Me.ReportPersonDeco.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ClassDetallePersonDeco"
        ReportDataSource2.Name = "ParametrosDeco"
        Me.ReportPersonDeco.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportPersonDeco.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportPersonDeco.LocalReport.ReportEmbeddedResource = "SPC.RptActEntregaRecep.rdlc"
        Me.ReportPersonDeco.Location = New System.Drawing.Point(0, 0)
        Me.ReportPersonDeco.Name = "ReportPersonDeco"
        Me.ReportPersonDeco.Size = New System.Drawing.Size(800, 450)
        Me.ReportPersonDeco.TabIndex = 1
        '
        'RptActEntregaRecep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportPersonDeco)
        Me.Name = "RptActEntregaRecep"
        Me.Text = "RptActEntregaRecep"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportPersonDeco As Microsoft.Reporting.WinForms.ReportViewer
End Class
