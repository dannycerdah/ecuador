<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtUsuario = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtClave = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnIngresar = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancelar = New Infragistics.Win.Misc.UltraButton()
        Me.pnlMain = New Infragistics.Win.Misc.UltraPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.uceEmpresa = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.ClientArea.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.uceEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Appearance8.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance8.ForeColor = System.Drawing.Color.DarkRed
        Me.UltraGroupBox1.Appearance = Appearance8
        Me.UltraGroupBox1.Controls.Add(Me.txtUsuario)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance9.BackColor = System.Drawing.Color.Black
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraGroupBox1.HeaderAppearance = Appearance9
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(6, 64)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(233, 50)
        Me.UltraGroupBox1.TabIndex = 11
        Me.UltraGroupBox1.Text = "Usuario"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtUsuario.Location = New System.Drawing.Point(0, 23)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(227, 21)
        Me.txtUsuario.TabIndex = 9
        '
        'UltraGroupBox2
        '
        Appearance3.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Me.UltraGroupBox2.Appearance = Appearance3
        Me.UltraGroupBox2.Controls.Add(Me.txtClave)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance4.BackColor = System.Drawing.Color.Black
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraGroupBox2.HeaderAppearance = Appearance4
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(6, 120)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(233, 49)
        Me.UltraGroupBox2.TabIndex = 12
        Me.UltraGroupBox2.Text = "Contraseña"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtClave.Location = New System.Drawing.Point(0, 22)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(227, 21)
        Me.txtClave.TabIndex = 13
        '
        'btnIngresar
        '
        Appearance6.BackColor = System.Drawing.Color.SlateGray
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.Image = Global.SPC.My.Resources.Resources.ok
        Me.btnIngresar.Appearance = Appearance6
        Me.btnIngresar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnIngresar.Location = New System.Drawing.Point(6, 174)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(80, 29)
        Me.btnIngresar.TabIndex = 13
        Me.btnIngresar.Text = "Ingresar"
        '
        'btnCancelar
        '
        Appearance7.BackColor = System.Drawing.Color.SlateGray
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.Image = Global.SPC.My.Resources.Resources.cancel
        Me.btnCancelar.Appearance = Appearance7
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.btnCancelar.Location = New System.Drawing.Point(158, 175)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 29)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        '
        'pnlMain
        '
        Appearance5.BorderColor = System.Drawing.Color.DarkGray
        Me.pnlMain.Appearance = Appearance5
        Me.pnlMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        '
        'pnlMain.ClientArea
        '
        Me.pnlMain.ClientArea.Controls.Add(Me.PictureBox1)
        Me.pnlMain.ClientArea.Controls.Add(Me.Panel1)
        Me.pnlMain.Location = New System.Drawing.Point(62, 21)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(260, 329)
        Me.pnlMain.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(9, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(242, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraGroupBox3)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnIngresar)
        Me.Panel1.Controls.Add(Me.UltraGroupBox2)
        Me.Panel1.Controls.Add(Me.UltraGroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(8, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 210)
        Me.Panel1.TabIndex = 15
        '
        'UltraGroupBox3
        '
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.Transparent
        Appearance1.ForeColor = System.Drawing.Color.DarkRed
        Me.UltraGroupBox3.Appearance = Appearance1
        Me.UltraGroupBox3.Controls.Add(Me.uceEmpresa)
        Me.UltraGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.BackColor = System.Drawing.Color.Black
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraGroupBox3.HeaderAppearance = Appearance2
        Me.UltraGroupBox3.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded1
        Me.UltraGroupBox3.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopInsideBorder
        Me.UltraGroupBox3.Location = New System.Drawing.Point(5, 8)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(233, 50)
        Me.UltraGroupBox3.TabIndex = 15
        Me.UltraGroupBox3.Text = "Empresa"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'uceEmpresa
        '
        Me.uceEmpresa.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceEmpresa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceEmpresa.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = "1"
        ValueListItem1.DisplayText = "Generalair"
        ValueListItem2.DataValue = "2"
        ValueListItem2.DisplayText = "ExporExpress"
        Me.uceEmpresa.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.uceEmpresa.LimitToList = True
        Me.uceEmpresa.Location = New System.Drawing.Point(6, 23)
        Me.uceEmpresa.Name = "uceEmpresa"
        Me.uceEmpresa.Size = New System.Drawing.Size(221, 21)
        Me.uceEmpresa.TabIndex = 15
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SPC.My.Resources.Resources.age_seguridad
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(361, 362)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ClientArea.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.uceEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtUsuario As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtClave As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnIngresar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancelar As Infragistics.Win.Misc.UltraButton
    Friend WithEvents pnlMain As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents uceEmpresa As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
