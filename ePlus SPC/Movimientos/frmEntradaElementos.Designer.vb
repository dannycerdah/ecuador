<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntradaElementos
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntradaElementos))
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceChofer = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceMula = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceAgenciaRampa = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.uceAgencia = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblmula = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvElementos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnConsultaElemento = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.uceChofer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceMula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgenciaRampa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.uceChofer)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel2)
        Me.ugbDatosVuelo.Controls.Add(Me.uceMula)
        Me.ugbDatosVuelo.Controls.Add(Me.uceAgenciaRampa)
        Me.ugbDatosVuelo.Controls.Add(Me.uceAgencia)
        Me.ugbDatosVuelo.Controls.Add(Me.lblmula)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox2)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel4)
        Me.ugbDatosVuelo.Controls.Add(Me.btnCancel)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel1)
        Me.ugbDatosVuelo.Controls.Add(Me.btnSave)
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsultaElemento)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(595, 470)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceChofer
        '
        Me.uceChofer.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceChofer.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceChofer.LimitToList = True
        Me.uceChofer.Location = New System.Drawing.Point(156, 91)
        Me.uceChofer.Name = "uceChofer"
        Me.uceChofer.Size = New System.Drawing.Size(333, 21)
        Me.uceChofer.TabIndex = 54
        '
        'UltraLabel2
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance15
        Me.UltraLabel2.Location = New System.Drawing.Point(94, 92)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel2.TabIndex = 53
        Me.UltraLabel2.Text = "Chofer:"
        '
        'uceMula
        '
        Me.uceMula.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceMula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceMula.LimitToList = True
        Me.uceMula.Location = New System.Drawing.Point(156, 67)
        Me.uceMula.Name = "uceMula"
        Me.uceMula.Size = New System.Drawing.Size(333, 21)
        Me.uceMula.TabIndex = 52
        '
        'uceAgenciaRampa
        '
        Me.uceAgenciaRampa.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgenciaRampa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgenciaRampa.LimitToList = True
        Me.uceAgenciaRampa.Location = New System.Drawing.Point(156, 43)
        Me.uceAgenciaRampa.Name = "uceAgenciaRampa"
        Me.uceAgenciaRampa.Size = New System.Drawing.Size(333, 21)
        Me.uceAgenciaRampa.TabIndex = 51
        '
        'uceAgencia
        '
        Me.uceAgencia.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgencia.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgencia.LimitToList = True
        Me.uceAgencia.Location = New System.Drawing.Point(156, 19)
        Me.uceAgencia.Name = "uceAgencia"
        Me.uceAgencia.Size = New System.Drawing.Size(333, 21)
        Me.uceAgencia.TabIndex = 50
        '
        'lblmula
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.lblmula.Appearance = Appearance1
        Me.lblmula.Location = New System.Drawing.Point(94, 68)
        Me.lblmula.Name = "lblmula"
        Me.lblmula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblmula.Size = New System.Drawing.Size(56, 20)
        Me.lblmula.TabIndex = 49
        Me.lblmula.Text = "Mula:"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.ugvElementos)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(8, 157)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(577, 266)
        Me.UltraGroupBox2.TabIndex = 44
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvElementos
        '
        Appearance18.BackColor = System.Drawing.Color.White
        Me.ugvElementos.DisplayLayout.Appearance = Appearance18
        Me.ugvElementos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvElementos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvElementos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Me.ugvElementos.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Me.ugvElementos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance20.FontData.BoldAsString = "True"
        Appearance20.FontData.Name = "Arial"
        Appearance20.FontData.SizeInPoints = 10.0!
        Appearance20.ForeColor = System.Drawing.Color.White
        Appearance20.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvElementos.DisplayLayout.Override.HeaderAppearance = Appearance20
        Me.ugvElementos.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance23.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance23.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvElementos.DisplayLayout.Override.RowSelectorAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance24.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvElementos.DisplayLayout.Override.SelectedRowAppearance = Appearance24
        Me.ugvElementos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvElementos.Location = New System.Drawing.Point(3, 0)
        Me.ugvElementos.Name = "ugvElementos"
        Me.ugvElementos.Size = New System.Drawing.Size(571, 263)
        Me.ugvElementos.TabIndex = 4
        Me.ugvElementos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraLabel4
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.TextHAlignAsString = "Right"
        Appearance25.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance25
        Me.UltraLabel4.Location = New System.Drawing.Point(12, 41)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(138, 20)
        Me.UltraLabel4.TabIndex = 47
        Me.UltraLabel4.Text = "Agencia de Rampa:"
        '
        'btnCancel
        '
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Me.btnCancel.Appearance = Appearance26
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(300, 429)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(81, 35)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancelar"
        '
        'UltraLabel1
        '
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Appearance27.TextHAlignAsString = "Right"
        Appearance27.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance27
        Me.UltraLabel1.Location = New System.Drawing.Point(94, 20)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel1.TabIndex = 45
        Me.UltraLabel1.Text = "Aerolinea:"
        '
        'btnSave
        '
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        Me.btnSave.Appearance = Appearance28
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(197, 429)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 35)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Guardar"
        '
        'btnConsultaElemento
        '
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        Me.btnConsultaElemento.Appearance = Appearance29
        Me.btnConsultaElemento.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsultaElemento.Location = New System.Drawing.Point(224, 130)
        Me.btnConsultaElemento.Name = "btnConsultaElemento"
        Me.btnConsultaElemento.Size = New System.Drawing.Size(140, 21)
        Me.btnConsultaElemento.TabIndex = 43
        Me.btnConsultaElemento.Text = "Consulta Elementos"
        '
        'frmEntradaElementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 471)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEntradaElementos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Entrada de Elementos"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.uceChofer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceMula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgenciaRampa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvElementos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnConsultaElemento As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblmula As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgencia As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceAgenciaRampa As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceMula As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents uceChofer As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
