<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroSellosCamiones
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroSellosCamiones))
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAerolinea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udtEtd = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtEta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnConsultaVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.txtAerolinea)
        Me.UltraGroupBox1.Controls.Add(Me.udtEtd)
        Me.UltraGroupBox1.Controls.Add(Me.udtEta)
        Me.UltraGroupBox1.Controls.Add(Me.txtVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.btnConsultaVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel14)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox1.Controls.Add(Me.txtAvion)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.txtMatricula)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(800, 100)
        Me.UltraGroupBox1.TabIndex = 58
        Me.UltraGroupBox1.Text = "Datos del Vuelo"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraLabel6
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.TextHAlignAsString = "Right"
        Appearance17.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance17
        Me.UltraLabel6.Location = New System.Drawing.Point(256, 35)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel6.TabIndex = 58
        Me.UltraLabel6.Text = "Aerolinea:"
        '
        'txtAerolinea
        '
        Me.txtAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAerolinea.Location = New System.Drawing.Point(318, 35)
        Me.txtAerolinea.Name = "txtAerolinea"
        Me.txtAerolinea.ReadOnly = True
        Me.txtAerolinea.Size = New System.Drawing.Size(127, 21)
        Me.txtAerolinea.TabIndex = 57
        '
        'udtEtd
        '
        Me.udtEtd.DateTime = New Date(2015, 2, 5, 0, 0, 0, 0)
        Me.udtEtd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtEtd.FormatString = "dd/MM/yyyy H:mm"
        Me.udtEtd.Location = New System.Drawing.Point(522, 61)
        Me.udtEtd.MaskInput = "{longtime}"
        Me.udtEtd.Name = "udtEtd"
        Me.udtEtd.ReadOnly = True
        Me.udtEtd.Size = New System.Drawing.Size(144, 21)
        Me.udtEtd.TabIndex = 56
        Me.udtEtd.Value = New Date(2015, 2, 5, 0, 0, 0, 0)
        '
        'udtEta
        '
        Me.udtEta.DateTime = New Date(2015, 2, 5, 0, 0, 0, 0)
        Me.udtEta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtEta.FormatString = "dd/MM/yyyy H:mm"
        Me.udtEta.Location = New System.Drawing.Point(522, 35)
        Me.udtEta.MaskInput = "{longtime}"
        Me.udtEta.Name = "udtEta"
        Me.udtEta.ReadOnly = True
        Me.udtEta.Size = New System.Drawing.Size(144, 21)
        Me.udtEta.TabIndex = 55
        Me.udtEta.Value = New Date(2015, 2, 5, 0, 0, 0, 0)
        '
        'txtVuelo
        '
        Me.txtVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtVuelo.Location = New System.Drawing.Point(100, 37)
        Me.txtVuelo.Name = "txtVuelo"
        Me.txtVuelo.ReadOnly = True
        Me.txtVuelo.Size = New System.Drawing.Size(101, 21)
        Me.txtVuelo.TabIndex = 42
        '
        'btnConsultaVuelo
        '
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        Me.btnConsultaVuelo.Appearance = Appearance7
        Me.btnConsultaVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultaVuelo.Location = New System.Drawing.Point(204, 37)
        Me.btnConsultaVuelo.Name = "btnConsultaVuelo"
        Me.btnConsultaVuelo.Size = New System.Drawing.Size(24, 21)
        Me.btnConsultaVuelo.TabIndex = 43
        '
        'UltraLabel14
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel14.Appearance = Appearance10
        Me.UltraLabel14.Location = New System.Drawing.Point(466, 62)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel14.Size = New System.Drawing.Size(50, 20)
        Me.UltraLabel14.TabIndex = 53
        Me.UltraLabel14.Text = "ETD:"
        '
        'UltraLabel1
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Right"
        Appearance21.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance21
        Me.UltraLabel1.Location = New System.Drawing.Point(46, 37)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel1.TabIndex = 45
        Me.UltraLabel1.Text = "Vuelo:"
        '
        'UltraLabel13
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel13.Appearance = Appearance8
        Me.UltraLabel13.Location = New System.Drawing.Point(466, 36)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel13.Size = New System.Drawing.Size(50, 20)
        Me.UltraLabel13.TabIndex = 51
        Me.UltraLabel13.Text = "ETA:"
        '
        'txtAvion
        '
        Me.txtAvion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAvion.Location = New System.Drawing.Point(100, 61)
        Me.txtAvion.Name = "txtAvion"
        Me.txtAvion.ReadOnly = True
        Me.txtAvion.Size = New System.Drawing.Size(101, 21)
        Me.txtAvion.TabIndex = 46
        '
        'UltraLabel12
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance9
        Me.UltraLabel12.Location = New System.Drawing.Point(256, 61)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel12.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel12.TabIndex = 49
        Me.UltraLabel12.Text = "Matricula:"
        '
        'UltraLabel4
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Appearance16.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance16
        Me.UltraLabel4.Location = New System.Drawing.Point(46, 61)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel4.TabIndex = 47
        Me.UltraLabel4.Text = "Avión:"
        '
        'txtMatricula
        '
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Location = New System.Drawing.Point(318, 61)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.ReadOnly = True
        Me.txtMatricula.Size = New System.Drawing.Size(127, 21)
        Me.txtMatricula.TabIndex = 48
        '
        'frmRegistroSellosCamiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegistroSellosCamiones"
        Me.Text = "Registro Sellos de Camiones"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAerolinea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents udtEtd As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtEta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnConsultaVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
