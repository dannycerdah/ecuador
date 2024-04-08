<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleCliente
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
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetalleCliente))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbContactoAgencia = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceEstado = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.uceAgenciaClient = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblClientes = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbContactoAgencia.SuspendLayout()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceAgenciaClient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbContactoAgencia
        '
        Me.ugbContactoAgencia.Controls.Add(Me.uceEstado)
        Me.ugbContactoAgencia.Controls.Add(Me.UltraLabel2)
        Me.ugbContactoAgencia.Controls.Add(Me.uceAgenciaClient)
        Me.ugbContactoAgencia.Controls.Add(Me.lblClientes)
        Me.ugbContactoAgencia.Controls.Add(Me.btnCancel)
        Me.ugbContactoAgencia.Controls.Add(Me.btnSave)
        Me.ugbContactoAgencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbContactoAgencia.Location = New System.Drawing.Point(0, 0)
        Me.ugbContactoAgencia.Name = "ugbContactoAgencia"
        Me.ugbContactoAgencia.Size = New System.Drawing.Size(438, 150)
        Me.ugbContactoAgencia.TabIndex = 20
        Me.ugbContactoAgencia.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceEstado
        '
        Me.uceEstado.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEstado.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        ValueListItem2.DataValue = "A"
        ValueListItem2.DisplayText = "Activo"
        ValueListItem3.DataValue = "I"
        ValueListItem3.DisplayText = "Inactivo"
        Me.uceEstado.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem2, ValueListItem3})
        Me.uceEstado.LimitToList = True
        Me.uceEstado.Location = New System.Drawing.Point(119, 66)
        Me.uceEstado.Name = "uceEstado"
        Me.uceEstado.Size = New System.Drawing.Size(106, 21)
        Me.uceEstado.TabIndex = 2
        '
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 65)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(51, 20)
        Me.UltraLabel2.TabIndex = 36
        Me.UltraLabel2.Text = "Estado:"
        '
        'uceAgenciaClient
        '
        Me.uceAgenciaClient.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceAgenciaClient.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceAgenciaClient.LimitToList = True
        Me.uceAgenciaClient.Location = New System.Drawing.Point(119, 26)
        Me.uceAgenciaClient.Name = "uceAgenciaClient"
        Me.uceAgenciaClient.Size = New System.Drawing.Size(300, 21)
        Me.uceAgenciaClient.TabIndex = 0
        '
        'lblClientes
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblClientes.Appearance = Appearance6
        Me.lblClientes.Location = New System.Drawing.Point(12, 26)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClientes.Size = New System.Drawing.Size(101, 20)
        Me.lblClientes.TabIndex = 20
        Me.lblClientes.Text = "Aerolinea/Agencia:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(339, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 35)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance1
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(119, 103)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 35)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Guardar"
        '
        'FrmDetalleCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 150)
        Me.Controls.Add(Me.ugbContactoAgencia)
        Me.Name = "FrmDetalleCliente"
        Me.Text = "FrmDetalleCliente"
        CType(Me.ugbContactoAgencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbContactoAgencia.ResumeLayout(False)
        Me.ugbContactoAgencia.PerformLayout()
        CType(Me.uceEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceAgenciaClient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbContactoAgencia As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceEstado As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceAgenciaClient As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblClientes As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
End Class
