<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesoElemento
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
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesoElemento))
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.bntSalir = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel30 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPeso = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtElemento = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.SP1 = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAgencia.SuspendLayout()
        CType(Me.txtPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAgencia
        '
        Me.ugbAgencia.Controls.Add(Me.bntSalir)
        Me.ugbAgencia.Controls.Add(Me.btnSave)
        Me.ugbAgencia.Controls.Add(Me.UltraLabel30)
        Me.ugbAgencia.Controls.Add(Me.txtPeso)
        Me.ugbAgencia.Controls.Add(Me.UltraLabel12)
        Me.ugbAgencia.Controls.Add(Me.txtElemento)
        Me.ugbAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbAgencia.Name = "ugbAgencia"
        Me.ugbAgencia.Size = New System.Drawing.Size(370, 202)
        Me.ugbAgencia.TabIndex = 19
        Me.ugbAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'bntSalir
        '
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        Me.bntSalir.Appearance = Appearance6
        Me.bntSalir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.bntSalir.Location = New System.Drawing.Point(201, 123)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(84, 35)
        Me.bntSalir.TabIndex = 62
        Me.bntSalir.Text = "SALIR"
        '
        'btnSave
        '
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        Me.btnSave.Appearance = Appearance28
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(102, 123)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 61
        Me.btnSave.Text = "Guardar"
        '
        'UltraLabel30
        '
        Appearance66.BackColor = System.Drawing.Color.Transparent
        Appearance66.TextHAlignAsString = "Right"
        Appearance66.TextVAlignAsString = "Middle"
        Me.UltraLabel30.Appearance = Appearance66
        Me.UltraLabel30.Location = New System.Drawing.Point(48, 57)
        Me.UltraLabel30.Name = "UltraLabel30"
        Me.UltraLabel30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel30.Size = New System.Drawing.Size(88, 41)
        Me.UltraLabel30.TabIndex = 60
        Me.UltraLabel30.Text = "PESO ACTUAL:"
        '
        'txtPeso
        '
        Me.txtPeso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.Location = New System.Drawing.Point(142, 57)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(100, 41)
        Me.txtPeso.TabIndex = 59
        '
        'UltraLabel12
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance15
        Me.UltraLabel12.Location = New System.Drawing.Point(80, 30)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel12.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel12.TabIndex = 51
        Me.UltraLabel12.Text = "Elemento:"
        '
        'txtElemento
        '
        Me.txtElemento.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtElemento.Location = New System.Drawing.Point(142, 30)
        Me.txtElemento.Name = "txtElemento"
        Me.txtElemento.ReadOnly = True
        Me.txtElemento.Size = New System.Drawing.Size(177, 21)
        Me.txtElemento.TabIndex = 50
        '
        'SP1
        '
        '
        'frmPesoElemento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 202)
        Me.Controls.Add(Me.ugbAgencia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPesoElemento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Peso Elemento"
        CType(Me.ugbAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAgencia.ResumeLayout(False)
        Me.ugbAgencia.PerformLayout()
        CType(Me.txtPeso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtElemento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtElemento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel30 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPeso As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents SP1 As System.IO.Ports.SerialPort
    Friend WithEvents bntSalir As Infragistics.Win.Misc.UltraButton
End Class
