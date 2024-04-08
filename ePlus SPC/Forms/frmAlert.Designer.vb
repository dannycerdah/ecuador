<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlert
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlMain = New Infragistics.Win.Misc.UltraPanel()
        Me.LblMsj = New System.Windows.Forms.Label()
        Me.pnlMain.ClientArea.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Appearance5.BorderColor = System.Drawing.Color.DarkGray
        Me.pnlMain.Appearance = Appearance5
        Me.pnlMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        '
        'pnlMain.ClientArea
        '
        Me.pnlMain.ClientArea.Controls.Add(Me.LblMsj)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(461, 174)
        Me.pnlMain.TabIndex = 15
        '
        'LblMsj
        '
        Me.LblMsj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblMsj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsj.Location = New System.Drawing.Point(0, 0)
        Me.LblMsj.Name = "LblMsj"
        Me.LblMsj.Size = New System.Drawing.Size(455, 168)
        Me.LblMsj.TabIndex = 0
        Me.LblMsj.Text = "Label1"
        Me.LblMsj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 174)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlert"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje"
        Me.pnlMain.ClientArea.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents LblMsj As System.Windows.Forms.Label
End Class
