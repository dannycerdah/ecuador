<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultarTurnosPersonal
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultarTurnosPersonal))
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugdTurnosPersonal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugbCamion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnExcelExport = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.uceEmpleados = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.udtFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblAerolinea = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.udtInicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.uceTurno = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugdTurnosPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbCamion.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugdTurnosPersonal
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.ugdTurnosPersonal.DisplayLayout.Appearance = Appearance1
        Me.ugdTurnosPersonal.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugdTurnosPersonal.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnTop
        Me.ugdTurnosPersonal.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.ugdTurnosPersonal.DisplayLayout.Override.CardAreaAppearance = Appearance2
        Me.ugdTurnosPersonal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial"
        Appearance8.FontData.SizeInPoints = 10.0!
        Appearance8.ForeColor = System.Drawing.Color.White
        Appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.ugdTurnosPersonal.DisplayLayout.Override.HeaderAppearance = Appearance8
        Me.ugdTurnosPersonal.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.OnlyWhenSorted
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdTurnosPersonal.DisplayLayout.Override.RowSelectorAppearance = Appearance3
        Appearance5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugdTurnosPersonal.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.ugdTurnosPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugdTurnosPersonal.Location = New System.Drawing.Point(0, 126)
        Me.ugdTurnosPersonal.Name = "ugdTurnosPersonal"
        Me.ugdTurnosPersonal.Size = New System.Drawing.Size(573, 307)
        Me.ugdTurnosPersonal.TabIndex = 9
        Me.ugdTurnosPersonal.Text = "TURNOS ASIGNADOS"
        '
        'ugbCamion
        '
        Me.ugbCamion.Controls.Add(Me.btnExcelExport)
        Me.ugbCamion.Controls.Add(Me.UltraGroupBox3)
        Me.ugbCamion.Dock = System.Windows.Forms.DockStyle.Top
        Me.ugbCamion.Location = New System.Drawing.Point(0, 0)
        Me.ugbCamion.Name = "ugbCamion"
        Me.ugbCamion.Size = New System.Drawing.Size(573, 126)
        Me.ugbCamion.TabIndex = 8
        Me.ugbCamion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnExcelExport
        '
        Me.btnExcelExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.AlphaLevel = CType(110, Short)
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.BackColor2 = System.Drawing.Color.Transparent
        Appearance6.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.btnExcelExport.Appearance = Appearance6
        Me.btnExcelExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnExcelExport.Enabled = False
        Me.btnExcelExport.ImageSize = New System.Drawing.Size(22, 22)
        Me.btnExcelExport.Location = New System.Drawing.Point(489, 54)
        Me.btnExcelExport.Name = "btnExcelExport"
        Me.btnExcelExport.Size = New System.Drawing.Size(72, 33)
        Me.btnExcelExport.TabIndex = 9
        Me.btnExcelExport.Text = "Excel"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.uceTurno)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.btnBuscar)
        Me.UltraGroupBox3.Controls.Add(Me.uceEmpleados)
        Me.UltraGroupBox3.Controls.Add(Me.udtFin)
        Me.UltraGroupBox3.Controls.Add(Me.lblAerolinea)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.udtInicio)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(472, 110)
        Me.UltraGroupBox3.TabIndex = 23
        Me.UltraGroupBox3.Text = "Consultar Turnos Asignados:"
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
        'btnBuscar
        '
        Appearance4.Image = CType(resources.GetObject("Appearance4.Image"), Object)
        Me.btnBuscar.Appearance = Appearance4
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnBuscar.Location = New System.Drawing.Point(384, 80)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 22)
        Me.btnBuscar.TabIndex = 52
        Me.btnBuscar.Text = "Consultar"
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
        'uceTurno
        '
        Me.uceTurno.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceTurno.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceTurno.LimitToList = True
        Me.uceTurno.Location = New System.Drawing.Point(95, 49)
        Me.uceTurno.Name = "uceTurno"
        Me.uceTurno.Size = New System.Drawing.Size(272, 21)
        Me.uceTurno.TabIndex = 107
        '
        'UltraLabel3
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance12
        Me.UltraLabel3.Location = New System.Drawing.Point(14, 48)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(47, 20)
        Me.UltraLabel3.TabIndex = 108
        Me.UltraLabel3.Text = "Turno:"
        '
        'frmConsultarTurnosPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 433)
        Me.Controls.Add(Me.ugdTurnosPersonal)
        Me.Controls.Add(Me.ugbCamion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmConsultarTurnosPersonal"
        Me.Text = "frmConsultarTurnosPersonal"
        CType(Me.ugdTurnosPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugbCamion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbCamion.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceTurno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugdTurnosPersonal As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ugbCamion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnExcelExport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uceEmpleados As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents udtFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblAerolinea As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtInicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uceTurno As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
End Class
