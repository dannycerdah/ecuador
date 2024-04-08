<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAsignarCubeta
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAsignarCubeta))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbGuia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvCubetasSacas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtGaveta = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.ucbSaca = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.ucbGuia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraButton2 = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblFecha = New Infragistics.Win.Misc.UltraLabel()
        Me.btnConsVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.txtNumVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblAgencia = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbGuia.SuspendLayout()
        CType(Me.ugvCubetasSacas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtGaveta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucbSaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucbGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbGuia
        '
        Me.ugbGuia.Controls.Add(Me.ugvCubetasSacas)
        Me.ugbGuia.Location = New System.Drawing.Point(12, 239)
        Me.ugbGuia.Name = "ugbGuia"
        Me.ugbGuia.Size = New System.Drawing.Size(776, 199)
        Me.ugbGuia.TabIndex = 23
        Me.ugbGuia.Text = "Detalle de Sacas"
        Me.ugbGuia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvCubetasSacas
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugvCubetasSacas.DisplayLayout.Appearance = Appearance1
        Me.ugvCubetasSacas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvCubetasSacas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugvCubetasSacas.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugvCubetasSacas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvCubetasSacas.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugvCubetasSacas.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvCubetasSacas.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvCubetasSacas.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugvCubetasSacas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvCubetasSacas.Location = New System.Drawing.Point(3, 16)
        Me.ugvCubetasSacas.Name = "ugvCubetasSacas"
        Me.ugvCubetasSacas.Size = New System.Drawing.Size(770, 180)
        Me.ugvCubetasSacas.TabIndex = 42
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraGroupBox2)
        Me.UltraGroupBox1.Controls.Add(Me.udtFecha)
        Me.UltraGroupBox1.Controls.Add(Me.lblFecha)
        Me.UltraGroupBox1.Controls.Add(Me.btnConsVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtNumVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.txtVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.lblAgencia)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(776, 221)
        Me.UltraGroupBox1.TabIndex = 24
        Me.UltraGroupBox1.Text = "Datos"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.txtGaveta)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox2.Controls.Add(Me.ucbSaca)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox2.Controls.Add(Me.ucbGuia)
        Me.UltraGroupBox2.Controls.Add(Me.UltraButton2)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(12, 94)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(758, 121)
        Me.UltraGroupBox2.TabIndex = 29
        Me.UltraGroupBox2.Text = "Asignación de Gavetas"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtGaveta
        '
        Me.txtGaveta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtGaveta.Enabled = False
        Me.txtGaveta.Location = New System.Drawing.Point(77, 84)
        Me.txtGaveta.Name = "txtGaveta"
        Me.txtGaveta.ReadOnly = True
        Me.txtGaveta.Size = New System.Drawing.Size(267, 21)
        Me.txtGaveta.TabIndex = 9
        '
        'UltraLabel2
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance8
        Me.UltraLabel2.Location = New System.Drawing.Point(5, 83)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(66, 20)
        Me.UltraLabel2.TabIndex = 21
        Me.UltraLabel2.Text = "No Gaveta:"
        '
        'ucbSaca
        '
        Me.ucbSaca.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucbSaca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucbSaca.LimitToList = True
        Me.ucbSaca.Location = New System.Drawing.Point(77, 57)
        Me.ucbSaca.Name = "ucbSaca"
        Me.ucbSaca.Size = New System.Drawing.Size(267, 21)
        Me.ucbSaca.TabIndex = 8
        '
        'UltraLabel1
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.Location = New System.Drawing.Point(16, 57)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(55, 20)
        Me.UltraLabel1.TabIndex = 19
        Me.UltraLabel1.Text = "Saca:"
        '
        'ucbGuia
        '
        Me.ucbGuia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucbGuia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucbGuia.LimitToList = True
        Me.ucbGuia.Location = New System.Drawing.Point(77, 31)
        Me.ucbGuia.Name = "ucbGuia"
        Me.ucbGuia.Size = New System.Drawing.Size(267, 21)
        Me.ucbGuia.TabIndex = 7
        '
        'UltraButton2
        '
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        Me.UltraButton2.Appearance = Appearance13
        Me.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.UltraButton2.Location = New System.Drawing.Point(654, 174)
        Me.UltraButton2.Name = "UltraButton2"
        Me.UltraButton2.Size = New System.Drawing.Size(87, 24)
        Me.UltraButton2.TabIndex = 4
        Me.UltraButton2.Text = "Aceptar"
        '
        'UltraLabel5
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance6
        Me.UltraLabel5.Location = New System.Drawing.Point(16, 31)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(55, 20)
        Me.UltraLabel5.TabIndex = 5
        Me.UltraLabel5.Text = "Guia:"
        '
        'udtFecha
        '
        Me.udtFecha.DateTime = New Date(2014, 9, 19, 0, 0, 0, 0)
        Me.udtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFecha.Location = New System.Drawing.Point(410, 57)
        Me.udtFecha.MaskInput = "dd/mm/yyyy"
        Me.udtFecha.Name = "udtFecha"
        Me.udtFecha.ReadOnly = True
        Me.udtFecha.Size = New System.Drawing.Size(114, 21)
        Me.udtFecha.TabIndex = 6
        Me.udtFecha.Value = New Date(2014, 9, 19, 0, 0, 0, 0)
        '
        'lblFecha
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.lblFecha.Appearance = Appearance10
        Me.lblFecha.Location = New System.Drawing.Point(330, 59)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFecha.Size = New System.Drawing.Size(60, 20)
        Me.lblFecha.TabIndex = 27
        Me.lblFecha.Text = "Fecha:"
        '
        'btnConsVuelo
        '
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.btnConsVuelo.Appearance = Appearance14
        Me.btnConsVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsVuelo.Location = New System.Drawing.Point(294, 29)
        Me.btnConsVuelo.Name = "btnConsVuelo"
        Me.btnConsVuelo.Size = New System.Drawing.Size(27, 27)
        Me.btnConsVuelo.TabIndex = 4
        '
        'txtNumVuelo
        '
        Me.txtNumVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNumVuelo.Enabled = False
        Me.txtNumVuelo.Location = New System.Drawing.Point(190, 32)
        Me.txtNumVuelo.Name = "txtNumVuelo"
        Me.txtNumVuelo.ReadOnly = True
        Me.txtNumVuelo.Size = New System.Drawing.Size(91, 21)
        Me.txtNumVuelo.TabIndex = 2
        '
        'txtVuelo
        '
        Me.txtVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtVuelo.Enabled = False
        Me.txtVuelo.Location = New System.Drawing.Point(78, 31)
        Me.txtVuelo.Name = "txtVuelo"
        Me.txtVuelo.ReadOnly = True
        Me.txtVuelo.Size = New System.Drawing.Size(101, 21)
        Me.txtVuelo.TabIndex = 1
        '
        'lblAgencia
        '
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Right"
        Appearance16.TextVAlignAsString = "Middle"
        Me.lblAgencia.Appearance = Appearance16
        Me.lblAgencia.Location = New System.Drawing.Point(12, 32)
        Me.lblAgencia.Name = "lblAgencia"
        Me.lblAgencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAgencia.Size = New System.Drawing.Size(60, 20)
        Me.lblAgencia.TabIndex = 22
        Me.lblAgencia.Text = "Vuelo:"
        '
        'FormAsignarCubeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 450)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.ugbGuia)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAsignarCubeta"
        Me.ShowIcon = False
        Me.Text = "FormAsignarCubeta"
        CType(Me.ugbGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbGuia.ResumeLayout(False)
        CType(Me.ugvCubetasSacas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtGaveta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucbSaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucbGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbGuia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvCubetasSacas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblFecha As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnConsVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtNumVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblAgencia As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ucbGuia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraButton2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucbSaca As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtGaveta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
