<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaPersonalActividades
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
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFichaPersonalActividades))
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbFicha = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnImprimir = New Infragistics.Win.Misc.UltraButton()
        Me.uceEmpleados = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        CType(Me.ugbFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbFicha.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbFicha
        '
        Me.ugbFicha.Controls.Add(Me.UltraGroupBox3)
        Me.ugbFicha.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbFicha.Location = New System.Drawing.Point(0, 0)
        Me.ugbFicha.Name = "ugbFicha"
        Me.ugbFicha.Size = New System.Drawing.Size(606, 126)
        Me.ugbFicha.TabIndex = 9
        Me.ugbFicha.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.btnImprimir)
        Me.UltraGroupBox3.Controls.Add(Me.uceEmpleados)
        Me.UltraGroupBox3.Controls.Add(Me.udtFin)
        Me.UltraGroupBox3.Controls.Add(Me.lblAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.udtInicio)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(582, 110)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Ficha Personal de Actividades"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel2
        '
        Appearance43.BackColor = System.Drawing.Color.Transparent
        Appearance43.TextHAlignAsString = "Right"
        Appearance43.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance43
        Me.UltraLabel2.Location = New System.Drawing.Point(193, 82)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel2.TabIndex = 50
        Me.UltraLabel2.Text = "Fecha Fin:"
        '
        'btnImprimir
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Me.btnImprimir.Appearance = Appearance4
        Me.btnImprimir.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnImprimir.Location = New System.Drawing.Point(384, 80)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 22)
        Me.btnImprimir.TabIndex = 52
        Me.btnImprimir.Text = "Imprimir"
        '
        'uceEmpleados
        '
        Me.uceEmpleados.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEmpleados.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEmpleados.LimitToList = True
        Me.uceEmpleados.Location = New System.Drawing.Point(95, 20)
        Me.uceEmpleados.Name = "uceEmpleados"
        Me.uceEmpleados.Size = New System.Drawing.Size(272, 21)
        Me.uceEmpleados.TabIndex = 46
        '
        'udtFin
        '
        Me.udtFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFin.FormatString = "dd/MM/yyyy"
        Me.udtFin.Location = New System.Drawing.Point(276, 82)
        Me.udtFin.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtFin.Name = "udtFin"
        Me.udtFin.Size = New System.Drawing.Size(92, 21)
        Me.udtFin.TabIndex = 51
        '
        'lblAerolinea
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance7
        Me.lblAerolinea.Location = New System.Drawing.Point(14, 21)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.Size = New System.Drawing.Size(59, 20)
        Me.lblAerolinea.TabIndex = 47
        Me.lblAerolinea.Text = "Empleado:"
        '
        'UltraLabel1
        '
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Appearance44.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance44
        Me.UltraLabel1.Location = New System.Drawing.Point(14, 80)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel1.TabIndex = 48
        Me.UltraLabel1.Text = "Fecha Inicio:"
        '
        'udtInicio
        '
        Me.udtInicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtInicio.FormatString = "dd/MM/yyyy"
        Me.udtInicio.Location = New System.Drawing.Point(95, 81)
        Me.udtInicio.MaskInput = "{LOC}dd/mm/yyyy"
        Me.udtInicio.Name = "udtInicio"
        Me.udtInicio.Size = New System.Drawing.Size(92, 21)
        Me.udtInicio.TabIndex = 49
        '
        'frmFichaPersonalActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 140)
        Me.Controls.Add(Me.ugbFicha)
        Me.Name = "frmFichaPersonalActividades"
        Me.Text = "frmFichaPersonalActividades"
        CType(Me.ugbFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbFicha.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbFicha As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnImprimir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceEmpleados As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents udtFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
End Class
