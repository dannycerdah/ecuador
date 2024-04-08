<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteProduccion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.udtHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBuscar = New Infragistics.Win.Misc.UltraButton()
        Me.udtDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblDesde = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClientes = New Infragistics.Win.Misc.UltraLabel()
        Me.uceClientes = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UlGrBoPeriodo = New Infragistics.Win.Misc.UltraGroupBox()
        Me.RaBM = New System.Windows.Forms.RadioButton()
        Me.RaBQ = New System.Windows.Forms.RadioButton()
        Me.RaBS = New System.Windows.Forms.RadioButton()
        Me.RaBD = New System.Windows.Forms.RadioButton()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UlGrBoPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UlGrBoPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.udtHasta)
        Me.UltraGroupBox1.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UltraGroupBox1.Controls.Add(Me.udtDesde)
        Me.UltraGroupBox1.Controls.Add(Me.lblDesde)
        Me.UltraGroupBox1.Controls.Add(Me.lblClientes)
        Me.UltraGroupBox1.Controls.Add(Me.uceClientes)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(546, 142)
        Me.UltraGroupBox1.TabIndex = 52
        Me.UltraGroupBox1.Text = "     Datos Principales"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'udtHasta
        '
        Me.udtHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtHasta.Location = New System.Drawing.Point(154, 105)
        Me.udtHasta.MaskInput = "dd/mm/yyyy"
        Me.udtHasta.Name = "udtHasta"
        Me.udtHasta.Size = New System.Drawing.Size(114, 21)
        Me.udtHasta.TabIndex = 48
        '
        'UltraLabel2
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Left"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance11
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(52, 80)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(96, 48)
        Me.UltraLabel2.TabIndex = 47
        Me.UltraLabel2.Text = "Fin de Facturacion:"
        '
        'btnBuscar
        '
        Me.btnBuscar.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnBuscar.Location = New System.Drawing.Point(306, 71)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(161, 34)
        Me.btnBuscar.TabIndex = 46
        Me.btnBuscar.Text = "Buscar Prefacturacion"
        '
        'udtDesde
        '
        Me.udtDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.udtDesde.Location = New System.Drawing.Point(154, 70)
        Me.udtDesde.MaskInput = "dd/mm/yyyy"
        Me.udtDesde.Name = "udtDesde"
        Me.udtDesde.Size = New System.Drawing.Size(114, 21)
        Me.udtDesde.TabIndex = 45
        '
        'lblDesde
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Left"
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblDesde.Appearance = Appearance14
        Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblDesde.Location = New System.Drawing.Point(52, 43)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(96, 48)
        Me.lblDesde.TabIndex = 44
        Me.lblDesde.Text = "Inicio de Facturacion:"
        '
        'lblClientes
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblClientes.Appearance = Appearance3
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.Location = New System.Drawing.Point(52, 19)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClientes.Size = New System.Drawing.Size(59, 25)
        Me.lblClientes.TabIndex = 40
        Me.lblClientes.Text = "Clientes:"
        '
        'uceClientes
        '
        Me.uceClientes.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceClientes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceClientes.LimitToList = True
        Me.uceClientes.Location = New System.Drawing.Point(154, 31)
        Me.uceClientes.Name = "uceClientes"
        Me.uceClientes.Size = New System.Drawing.Size(313, 21)
        Me.uceClientes.TabIndex = 39
        '
        'UlGrBoPeriodo
        '
        Me.UlGrBoPeriodo.Controls.Add(Me.RaBM)
        Me.UlGrBoPeriodo.Controls.Add(Me.RaBQ)
        Me.UlGrBoPeriodo.Controls.Add(Me.RaBS)
        Me.UlGrBoPeriodo.Controls.Add(Me.RaBD)
        Me.UlGrBoPeriodo.Dock = System.Windows.Forms.DockStyle.Right
        Me.UlGrBoPeriodo.Location = New System.Drawing.Point(467, 0)
        Me.UlGrBoPeriodo.Name = "UlGrBoPeriodo"
        Me.UlGrBoPeriodo.Size = New System.Drawing.Size(79, 142)
        Me.UlGrBoPeriodo.TabIndex = 49
        Me.UlGrBoPeriodo.Text = "Periodo"
        Me.UlGrBoPeriodo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'RaBM
        '
        Me.RaBM.AutoSize = True
        Me.RaBM.BackColor = System.Drawing.Color.Transparent
        Me.RaBM.Location = New System.Drawing.Point(6, 88)
        Me.RaBM.Name = "RaBM"
        Me.RaBM.Size = New System.Drawing.Size(65, 17)
        Me.RaBM.TabIndex = 3
        Me.RaBM.TabStop = True
        Me.RaBM.Text = "Mensual"
        Me.RaBM.UseVisualStyleBackColor = False
        '
        'RaBQ
        '
        Me.RaBQ.AutoSize = True
        Me.RaBQ.BackColor = System.Drawing.Color.Transparent
        Me.RaBQ.Location = New System.Drawing.Point(6, 65)
        Me.RaBQ.Name = "RaBQ"
        Me.RaBQ.Size = New System.Drawing.Size(73, 17)
        Me.RaBQ.TabIndex = 2
        Me.RaBQ.TabStop = True
        Me.RaBQ.Text = "Quincenal"
        Me.RaBQ.UseVisualStyleBackColor = False
        '
        'RaBS
        '
        Me.RaBS.AutoSize = True
        Me.RaBS.BackColor = System.Drawing.Color.Transparent
        Me.RaBS.Location = New System.Drawing.Point(6, 42)
        Me.RaBS.Name = "RaBS"
        Me.RaBS.Size = New System.Drawing.Size(66, 17)
        Me.RaBS.TabIndex = 1
        Me.RaBS.TabStop = True
        Me.RaBS.Text = "Semanal"
        Me.RaBS.UseVisualStyleBackColor = False
        '
        'RaBD
        '
        Me.RaBD.AutoSize = True
        Me.RaBD.BackColor = System.Drawing.Color.Transparent
        Me.RaBD.Location = New System.Drawing.Point(6, 19)
        Me.RaBD.Name = "RaBD"
        Me.RaBD.Size = New System.Drawing.Size(52, 17)
        Me.RaBD.TabIndex = 0
        Me.RaBD.TabStop = True
        Me.RaBD.Text = "Diario"
        Me.RaBD.UseVisualStyleBackColor = False
        '
        'FrmReporteProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 142)
        Me.Controls.Add(Me.UlGrBoPeriodo)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmReporteProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE PRODUCCIÓN 2"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.udtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UlGrBoPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UlGrBoPeriodo.ResumeLayout(False)
        Me.UlGrBoPeriodo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents udtHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnBuscar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents udtDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblDesde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClientes As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceClientes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UlGrBoPeriodo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents RaBM As System.Windows.Forms.RadioButton
    Friend WithEvents RaBQ As System.Windows.Forms.RadioButton
    Friend WithEvents RaBS As System.Windows.Forms.RadioButton
    Friend WithEvents RaBD As System.Windows.Forms.RadioButton

End Class
