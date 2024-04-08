<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockElementos
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
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockElementos))
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.uceAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtObs = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsultaElemento = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.UltraButton1)
        Me.ugbDatosVuelo.Controls.Add(Me.uceAerolinea)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel2)
        Me.ugbDatosVuelo.Controls.Add(Me.txtObs)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel1)
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsultaElemento)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(331, 248)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraButton1
        '
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        Me.UltraButton1.Appearance = Appearance29
        Me.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.UltraButton1.Location = New System.Drawing.Point(98, 213)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(140, 29)
        Me.UltraButton1.TabIndex = 48
        Me.UltraButton1.Text = "Enviar correo (pdf)"
        '
        'uceAerolinea
        '
        Me.uceAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAerolinea.LimitToList = True
        Me.uceAerolinea.Location = New System.Drawing.Point(88, 34)
        Me.uceAerolinea.Name = "uceAerolinea"
        Me.uceAerolinea.Size = New System.Drawing.Size(166, 21)
        Me.uceAerolinea.TabIndex = 0
        '
        'UltraLabel2
        '
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Appearance27.TextHAlignAsString = "Right"
        Appearance27.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance27
        Me.UltraLabel2.Location = New System.Drawing.Point(0, 70)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(82, 20)
        Me.UltraLabel2.TabIndex = 47
        Me.UltraLabel2.Text = "Observación:"
        '
        'txtObs
        '
        Me.txtObs.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtObs.Location = New System.Drawing.Point(88, 70)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(166, 96)
        Me.txtObs.TabIndex = 1
        '
        'UltraLabel1
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 34)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(70, 20)
        Me.UltraLabel1.TabIndex = 45
        Me.UltraLabel1.Text = "Aerolínea:"
        '
        'btnConsultaElemento
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnConsultaElemento.Appearance = Appearance2
        Me.btnConsultaElemento.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultaElemento.Location = New System.Drawing.Point(98, 181)
        Me.btnConsultaElemento.Name = "btnConsultaElemento"
        Me.btnConsultaElemento.Size = New System.Drawing.Size(140, 29)
        Me.btnConsultaElemento.TabIndex = 2
        Me.btnConsultaElemento.Text = "Consultar Elemento"
        '
        'frmStockElementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 248)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStockElementos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock de Elementos"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnConsultaElemento As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtObs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uceAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
End Class
