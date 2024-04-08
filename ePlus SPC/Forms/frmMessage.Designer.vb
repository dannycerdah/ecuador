<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessage
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.UltraActivityIndicator1 = New Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator()
        Me.lblBackground = New Infragistics.Win.Misc.UltraLabel()
        Me.tmrWait = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.lblMessage)
        Me.pnlMain.Controls.Add(Me.UltraActivityIndicator1)
        Me.pnlMain.Controls.Add(Me.lblBackground)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(376, 164)
        Me.pnlMain.TabIndex = 0
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(11, 29)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(355, 23)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.Text = "Esperando Autorización de un Administrador"
        '
        'UltraActivityIndicator1
        '
        Me.UltraActivityIndicator1.AnimationEnabled = True
        Me.UltraActivityIndicator1.AnimationSpeed = 10
        Me.UltraActivityIndicator1.CausesValidation = True
        Me.UltraActivityIndicator1.Location = New System.Drawing.Point(58, 87)
        Me.UltraActivityIndicator1.MarqueeAnimationStyle = Infragistics.Win.UltraActivityIndicator.MarqueeAnimationStyle.BounceBack
        Me.UltraActivityIndicator1.Name = "UltraActivityIndicator1"
        Me.UltraActivityIndicator1.Size = New System.Drawing.Size(260, 39)
        Me.UltraActivityIndicator1.TabIndex = 1
        Me.UltraActivityIndicator1.TabStop = True
        Me.UltraActivityIndicator1.UseWaitCursor = True
        '
        'lblBackground
        '
        Appearance1.BackColor = System.Drawing.Color.LightBlue
        Appearance1.BackColor2 = System.Drawing.Color.AliceBlue
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblBackground.Appearance = Appearance1
        Me.lblBackground.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBackground.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblBackground.Location = New System.Drawing.Point(0, 0)
        Me.lblBackground.Name = "lblBackground"
        Me.lblBackground.Size = New System.Drawing.Size(376, 164)
        Me.lblBackground.TabIndex = 2
        '
        'tmrWait
        '
        Me.tmrWait.Interval = 4000
        '
        'frmMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 164)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lblBackground As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents UltraActivityIndicator1 As Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator
    Friend WithEvents tmrWait As System.Windows.Forms.Timer
End Class
