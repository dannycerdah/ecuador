<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreseleccionElementos
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
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreseleccionElementos))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnConsVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.udtEtd = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtEta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.udtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvElementos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnConsultaElemento = New Infragistics.Win.Misc.UltraButton()
        Me.txtVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsVuelo)
        Me.ugbDatosVuelo.Controls.Add(Me.udtEtd)
        Me.ugbDatosVuelo.Controls.Add(Me.udtEta)
        Me.ugbDatosVuelo.Controls.Add(Me.udtFecha)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel14)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel13)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel12)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox2)
        Me.ugbDatosVuelo.Controls.Add(Me.txtMatricula)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel4)
        Me.ugbDatosVuelo.Controls.Add(Me.txtAvion)
        Me.ugbDatosVuelo.Controls.Add(Me.btnCancel)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel1)
        Me.ugbDatosVuelo.Controls.Add(Me.btnSave)
        Me.ugbDatosVuelo.Controls.Add(Me.btnConsultaElemento)
        Me.ugbDatosVuelo.Controls.Add(Me.txtVuelo)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraLabel2)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(595, 373)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnConsVuelo
        '
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        Me.btnConsVuelo.Appearance = Appearance9
        Me.btnConsVuelo.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnConsVuelo.Location = New System.Drawing.Point(196, 24)
        Me.btnConsVuelo.Name = "btnConsVuelo"
        Me.btnConsVuelo.Size = New System.Drawing.Size(27, 24)
        Me.btnConsVuelo.TabIndex = 57
        '
        'udtEtd
        '
        Me.udtEtd.DateTime = New Date(2014, 8, 9, 0, 0, 0, 0)
        Me.udtEtd.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtEtd.FormatString = "dd/MM/yyyy H:mm:ss"
        Me.udtEtd.Location = New System.Drawing.Point(434, 79)
        Me.udtEtd.MaskInput = "{longtime}"
        Me.udtEtd.Name = "udtEtd"
        Me.udtEtd.Size = New System.Drawing.Size(144, 21)
        Me.udtEtd.TabIndex = 56
        Me.udtEtd.Value = New Date(2014, 8, 9, 0, 0, 0, 0)
        '
        'udtEta
        '
        Me.udtEta.DateTime = New Date(2014, 8, 9, 0, 0, 0, 0)
        Me.udtEta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtEta.FormatString = "dd/MM/yyyy H:mm:ss"
        Me.udtEta.Location = New System.Drawing.Point(434, 53)
        Me.udtEta.MaskInput = "{longtime}"
        Me.udtEta.Name = "udtEta"
        Me.udtEta.Size = New System.Drawing.Size(144, 21)
        Me.udtEta.TabIndex = 55
        Me.udtEta.Value = New Date(2014, 8, 9, 0, 0, 0, 0)
        '
        'udtFecha
        '
        Me.udtFecha.DateTime = New Date(2014, 8, 9, 0, 0, 0, 0)
        Me.udtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFecha.Location = New System.Drawing.Point(434, 27)
        Me.udtFecha.MaskInput = "dd/mm/yyyy"
        Me.udtFecha.Name = "udtFecha"
        Me.udtFecha.ReadOnly = True
        Me.udtFecha.Size = New System.Drawing.Size(144, 21)
        Me.udtFecha.TabIndex = 54
        Me.udtFecha.Value = New Date(2014, 8, 9, 0, 0, 0, 0)
        '
        'UltraLabel14
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel14.Appearance = Appearance13
        Me.UltraLabel14.Location = New System.Drawing.Point(343, 80)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel14.Size = New System.Drawing.Size(85, 20)
        Me.UltraLabel14.TabIndex = 53
        Me.UltraLabel14.Text = "ETD:"
        '
        'UltraLabel13
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.UltraLabel13.Appearance = Appearance14
        Me.UltraLabel13.Location = New System.Drawing.Point(343, 54)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel13.Size = New System.Drawing.Size(85, 20)
        Me.UltraLabel13.TabIndex = 51
        Me.UltraLabel13.Text = "ETA:"
        '
        'UltraLabel12
        '
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance15
        Me.UltraLabel12.Location = New System.Drawing.Point(27, 73)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel12.Size = New System.Drawing.Size(56, 20)
        Me.UltraLabel12.TabIndex = 49
        Me.UltraLabel12.Text = "Matricula:"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.ugvElementos)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(8, 157)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(577, 149)
        Me.UltraGroupBox2.TabIndex = 44
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvElementos
        '
        Appearance18.BackColor = System.Drawing.Color.White
        Me.ugvElementos.DisplayLayout.Appearance = Appearance18
        Me.ugvElementos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvElementos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvElementos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugvElementos.Size = New System.Drawing.Size(571, 146)
        Me.ugvElementos.TabIndex = 4
        Me.ugvElementos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'txtMatricula
        '
        Me.txtMatricula.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtMatricula.Location = New System.Drawing.Point(89, 73)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.ReadOnly = True
        Me.txtMatricula.Size = New System.Drawing.Size(101, 21)
        Me.txtMatricula.TabIndex = 48
        '
        'UltraLabel4
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.TextHAlignAsString = "Right"
        Appearance25.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance25
        Me.UltraLabel4.Location = New System.Drawing.Point(35, 48)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel4.TabIndex = 47
        Me.UltraLabel4.Text = "Avión:"
        '
        'txtAvion
        '
        Me.txtAvion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtAvion.Location = New System.Drawing.Point(89, 48)
        Me.txtAvion.Name = "txtAvion"
        Me.txtAvion.ReadOnly = True
        Me.txtAvion.Size = New System.Drawing.Size(101, 21)
        Me.txtAvion.TabIndex = 46
        '
        'btnCancel
        '
        Appearance26.Image = CType(resources.GetObject("Appearance26.Image"), Object)
        Me.btnCancel.Appearance = Appearance26
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(504, 326)
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
        Me.UltraLabel1.Location = New System.Drawing.Point(35, 24)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(48, 20)
        Me.UltraLabel1.TabIndex = 45
        Me.UltraLabel1.Text = "Vuelo:"
        '
        'btnSave
        '
        Appearance28.Image = CType(resources.GetObject("Appearance28.Image"), Object)
        Me.btnSave.Appearance = Appearance28
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(12, 326)
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
        Me.btnConsultaElemento.Text = "Consulta de Elementos"
        '
        'txtVuelo
        '
        Me.txtVuelo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtVuelo.Location = New System.Drawing.Point(89, 24)
        Me.txtVuelo.Name = "txtVuelo"
        Me.txtVuelo.ReadOnly = True
        Me.txtVuelo.Size = New System.Drawing.Size(101, 21)
        Me.txtVuelo.TabIndex = 42
        '
        'UltraLabel2
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance30
        Me.UltraLabel2.Location = New System.Drawing.Point(343, 32)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(85, 20)
        Me.UltraLabel2.TabIndex = 21
        Me.UltraLabel2.Text = "Fecha:"
        '
        'frmPreseleccionElementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 373)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPreseleccionElementos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pre-selección de Elementos"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        Me.ugbDatosVuelo.PerformLayout()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.ugvElementos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents ugvElementos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnConsultaElemento As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtEtd As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtEta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnConsVuelo As Infragistics.Win.Misc.UltraButton
End Class
