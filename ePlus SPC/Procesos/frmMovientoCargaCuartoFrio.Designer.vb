<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovientoCargaCuartoFrio
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovientoCargaCuartoFrio))
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbCuartos2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmbCuartos = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAerolinea = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.txtNumVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtGuia = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblVuelo = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnAgregar = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.cmbCuartos2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCuartos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.cmbCuartos2)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.cmbCuartos)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel20)
        Me.UltraGroupBox1.Controls.Add(Me.lblAerolinea)
        Me.UltraGroupBox1.Controls.Add(Me.uceAerolinea)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox1.Controls.Add(Me.btnConsVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtNumVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtGuia)
        Me.UltraGroupBox1.Controls.Add(Me.lblVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.BtnAgregar)
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(-2, -1)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(784, 103)
        Me.UltraGroupBox1.TabIndex = 64
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbCuartos2
        '
        Me.cmbCuartos2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCuartos2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cmbCuartos2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbCuartos2.LimitToList = True
        Me.cmbCuartos2.Location = New System.Drawing.Point(431, 57)
        Me.cmbCuartos2.Name = "cmbCuartos2"
        Me.cmbCuartos2.Size = New System.Drawing.Size(251, 21)
        Me.cmbCuartos2.TabIndex = 109
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.UltraLabel1.Location = New System.Drawing.Point(354, 57)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(71, 31)
        Me.UltraLabel1.TabIndex = 108
        Me.UltraLabel1.Text = "Cuarto Frio a Mover:"
        '
        'cmbCuartos
        '
        Me.cmbCuartos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCuartos.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cmbCuartos.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbCuartos.LimitToList = True
        Me.cmbCuartos.Location = New System.Drawing.Point(90, 58)
        Me.cmbCuartos.Name = "cmbCuartos"
        Me.cmbCuartos.Size = New System.Drawing.Size(251, 21)
        Me.cmbCuartos.TabIndex = 107
        '
        'UltraLabel20
        '
        Me.UltraLabel20.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel20.Appearance = Appearance3
        Me.UltraLabel20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.UltraLabel20.Location = New System.Drawing.Point(13, 58)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel20.Size = New System.Drawing.Size(71, 31)
        Me.UltraLabel20.TabIndex = 106
        Me.UltraLabel20.Text = "Cuarto Frio Actual:"
        '
        'lblAerolinea
        '
        Me.lblAerolinea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblAerolinea.Appearance = Appearance9
        Me.lblAerolinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblAerolinea.Location = New System.Drawing.Point(13, 14)
        Me.lblAerolinea.Name = "lblAerolinea"
        Me.lblAerolinea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAerolinea.Size = New System.Drawing.Size(71, 20)
        Me.lblAerolinea.TabIndex = 105
        Me.lblAerolinea.Text = "Aerolinea:"
        '
        'uceAerolinea
        '
        Me.uceAerolinea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uceAerolinea.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAerolinea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAerolinea.LimitToList = True
        Me.uceAerolinea.Location = New System.Drawing.Point(90, 13)
        Me.uceAerolinea.Name = "uceAerolinea"
        Me.uceAerolinea.Size = New System.Drawing.Size(251, 21)
        Me.uceAerolinea.TabIndex = 104
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(518, 14)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(69, 20)
        Me.UltraLabel3.TabIndex = 103
        Me.UltraLabel3.Text = "Elemento:"
        '
        'btnConsVuelo
        '
        Me.btnConsVuelo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance66.Image = CType(resources.GetObject("Appearance66.Image"), Object)
        Me.btnConsVuelo.Appearance = Appearance66
        Me.btnConsVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsVuelo.Location = New System.Drawing.Point(725, 7)
        Me.btnConsVuelo.Name = "btnConsVuelo"
        Me.btnConsVuelo.Size = New System.Drawing.Size(30, 27)
        Me.btnConsVuelo.TabIndex = 101
        '
        'txtNumVuelo
        '
        Me.txtNumVuelo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNumVuelo.Enabled = False
        Me.txtNumVuelo.Location = New System.Drawing.Point(431, 14)
        Me.txtNumVuelo.Name = "txtNumVuelo"
        Me.txtNumVuelo.ReadOnly = True
        Me.txtNumVuelo.Size = New System.Drawing.Size(80, 21)
        Me.txtNumVuelo.TabIndex = 100
        '
        'txtGuia
        '
        Me.txtGuia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtGuia.Enabled = False
        Me.txtGuia.Location = New System.Drawing.Point(593, 13)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(101, 21)
        Me.txtGuia.TabIndex = 99
        '
        'lblVuelo
        '
        Me.lblVuelo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.lblVuelo.Appearance = Appearance4
        Me.lblVuelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblVuelo.Location = New System.Drawing.Point(357, 14)
        Me.lblVuelo.Name = "lblVuelo"
        Me.lblVuelo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVuelo.Size = New System.Drawing.Size(60, 20)
        Me.lblVuelo.TabIndex = 102
        Me.lblVuelo.Text = "Vuelo:"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.BtnAgregar.Location = New System.Drawing.Point(688, 51)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(67, 28)
        Me.BtnAgregar.TabIndex = 98
        Me.BtnAgregar.Text = "Mover"
        '
        'frmMovientoCargaCuartoFrio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 99)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovientoCargaCuartoFrio"
        Me.Text = "Moviento de Carga a Cuarto Frio"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.cmbCuartos2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCuartos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents cmbCuartos2 As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbCuartos As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAerolinea As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnConsVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtNumVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtGuia As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblVuelo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents BtnAgregar As Infragistics.Win.Misc.UltraButton
End Class
