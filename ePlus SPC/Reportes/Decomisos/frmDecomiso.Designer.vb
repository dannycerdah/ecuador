<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDecomiso
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDecomiso))
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbDatosVuelo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAerolinea = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udtEtd = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtEta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtVuelo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.udtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.btnConsultaVuelo = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtMatricula = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.ugvDetalleProcesoDecomiso = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDatosVuelo.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtAerolinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.ugvDetalleProcesoDecomiso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbDatosVuelo
        '
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox1)
        Me.ugbDatosVuelo.Controls.Add(Me.UltraGroupBox2)
        Me.ugbDatosVuelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbDatosVuelo.Location = New System.Drawing.Point(0, 0)
        Me.ugbDatosVuelo.Name = "ugbDatosVuelo"
        Me.ugbDatosVuelo.Size = New System.Drawing.Size(937, 416)
        Me.ugbDatosVuelo.TabIndex = 20
        Me.ugbDatosVuelo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox1.Controls.Add(Me.txtAerolinea)
        Me.UltraGroupBox1.Controls.Add(Me.udtEtd)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.udtEta)
        Me.UltraGroupBox1.Controls.Add(Me.txtVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.udtFecha)
        Me.UltraGroupBox1.Controls.Add(Me.btnConsultaVuelo)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel14)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox1.Controls.Add(Me.txtAvion)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox1.Controls.Add(Me.txtMatricula)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(931, 100)
        Me.UltraGroupBox1.TabIndex = 57
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
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(687, 35)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(85, 20)
        Me.UltraLabel2.TabIndex = 21
        Me.UltraLabel2.Text = "Fecha:"
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
        'udtFecha
        '
        Me.udtFecha.DateTime = New Date(2015, 2, 5, 0, 0, 0, 0)
        Me.udtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtFecha.Location = New System.Drawing.Point(778, 35)
        Me.udtFecha.MaskInput = "dd/mm/yyyy"
        Me.udtFecha.Name = "udtFecha"
        Me.udtFecha.ReadOnly = True
        Me.udtFecha.Size = New System.Drawing.Size(144, 21)
        Me.udtFecha.TabIndex = 54
        Me.udtFecha.Value = New Date(2015, 2, 5, 0, 0, 0, 0)
        '
        'btnConsultaVuelo
        '
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.btnConsultaVuelo.Appearance = Appearance5
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
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.ugvDetalleProcesoDecomiso)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 102)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(937, 314)
        Me.UltraGroupBox2.TabIndex = 44
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'ugvDetalleProcesoDecomiso
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Appearance = Appearance1
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.RowSelectorAppearance = Appearance4
        Appearance6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDetalleProcesoDecomiso.DisplayLayout.Override.SelectedRowAppearance = Appearance6
        Me.ugvDetalleProcesoDecomiso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvDetalleProcesoDecomiso.Location = New System.Drawing.Point(3, 0)
        Me.ugvDetalleProcesoDecomiso.Name = "ugvDetalleProcesoDecomiso"
        Me.ugvDetalleProcesoDecomiso.Size = New System.Drawing.Size(931, 311)
        Me.ugvDetalleProcesoDecomiso.TabIndex = 4
        Me.ugvDetalleProcesoDecomiso.UseOsThemes = Infragistics.Win.DefaultableBoolean.[True]
        '
        'frmDecomiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 418)
        Me.Controls.Add(Me.ugbDatosVuelo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDecomiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Decomiso"
        CType(Me.ugbDatosVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDatosVuelo.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtAerolinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEtd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVuelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.ugvDetalleProcesoDecomiso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbDatosVuelo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ugvDetalleProcesoDecomiso As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtMatricula As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnConsultaVuelo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtVuelo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents SP1 As System.IO.Ports.SerialPort
    Friend WithEvents udtEtd As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtEta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAerolinea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
End Class
