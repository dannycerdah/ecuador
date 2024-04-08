<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEjecucionReportVueloAuto
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.TxtTerminal = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.BtnDetenerProceso = New Infragistics.Win.Misc.UltraButton()
        Me.BtnEjecutProceso = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.TxtTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.TxtTerminal)
        Me.UltraGroupBox1.Controls.Add(Me.BtnDetenerProceso)
        Me.UltraGroupBox1.Controls.Add(Me.BtnEjecutProceso)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(301, 180)
        Me.UltraGroupBox1.TabIndex = 58
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'TxtTerminal
        '
        Me.TxtTerminal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TxtTerminal.Enabled = False
        Me.TxtTerminal.Location = New System.Drawing.Point(6, 147)
        Me.TxtTerminal.Name = "TxtTerminal"
        Me.TxtTerminal.Size = New System.Drawing.Size(282, 21)
        Me.TxtTerminal.TabIndex = 2
        Me.TxtTerminal.Visible = False
        '
        'BtnDetenerProceso
        '
        Me.BtnDetenerProceso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnDetenerProceso.Enabled = False
        Me.BtnDetenerProceso.Location = New System.Drawing.Point(6, 69)
        Me.BtnDetenerProceso.Name = "BtnDetenerProceso"
        Me.BtnDetenerProceso.Size = New System.Drawing.Size(282, 48)
        Me.BtnDetenerProceso.TabIndex = 1
        Me.BtnDetenerProceso.Text = "Detener Proceso Reporte de Vuelo Automatico"
        '
        'BtnEjecutProceso
        '
        Me.BtnEjecutProceso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnEjecutProceso.Enabled = False
        Me.BtnEjecutProceso.Location = New System.Drawing.Point(6, 11)
        Me.BtnEjecutProceso.Name = "BtnEjecutProceso"
        Me.BtnEjecutProceso.Size = New System.Drawing.Size(282, 48)
        Me.BtnEjecutProceso.TabIndex = 0
        Me.BtnEjecutProceso.Text = "Ejecutar Proceso Reporte de Vuelo Automatico"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 123)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(139, 23)
        Me.UltraLabel1.TabIndex = 3
        Me.UltraLabel1.Text = "Terminal de Ejecucion:"
        Me.UltraLabel1.Visible = False
        '
        'frmEjecucionReportVueloAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 180)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEjecucionReportVueloAuto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Automatico de Vuelo"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.TxtTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents TxtTerminal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents BtnDetenerProceso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnEjecutProceso As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
