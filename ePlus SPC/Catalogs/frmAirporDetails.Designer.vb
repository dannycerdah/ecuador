<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAirporDetails
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
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAirporDetails))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugbAirport = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnWeb = New Infragistics.Win.Misc.UltraButton()
        Me.wbMaps = New System.Windows.Forms.WebBrowser()
        Me.txtLatitud = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtLongitud = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.uneTerminales = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtTelefono = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtPaginaWeb = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCodigoOACI = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtCodigoIATA = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtObs = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtDireccion = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtNombre = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.uceCiudad = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.ucePais = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblObservcion = New Infragistics.Win.Misc.UltraLabel()
        Me.lblDireccion = New Infragistics.Win.Misc.UltraLabel()
        Me.lblPais = New Infragistics.Win.Misc.UltraLabel()
        Me.lblCiudad = New Infragistics.Win.Misc.UltraLabel()
        Me.lblNombre = New Infragistics.Win.Misc.UltraLabel()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ugbAirport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbAirport.SuspendLayout()
        CType(Me.txtLatitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLongitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uneTerminales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaginaWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoOACI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoIATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uceCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucePais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugbAirport
        '
        Me.ugbAirport.Controls.Add(Me.btnWeb)
        Me.ugbAirport.Controls.Add(Me.wbMaps)
        Me.ugbAirport.Controls.Add(Me.txtLatitud)
        Me.ugbAirport.Controls.Add(Me.UltraLabel6)
        Me.ugbAirport.Controls.Add(Me.txtLongitud)
        Me.ugbAirport.Controls.Add(Me.UltraLabel7)
        Me.ugbAirport.Controls.Add(Me.uneTerminales)
        Me.ugbAirport.Controls.Add(Me.UltraLabel5)
        Me.ugbAirport.Controls.Add(Me.txtTelefono)
        Me.ugbAirport.Controls.Add(Me.UltraLabel4)
        Me.ugbAirport.Controls.Add(Me.txtPaginaWeb)
        Me.ugbAirport.Controls.Add(Me.UltraLabel3)
        Me.ugbAirport.Controls.Add(Me.txtCodigoOACI)
        Me.ugbAirport.Controls.Add(Me.UltraLabel2)
        Me.ugbAirport.Controls.Add(Me.txtCodigoIATA)
        Me.ugbAirport.Controls.Add(Me.UltraLabel1)
        Me.ugbAirport.Controls.Add(Me.txtObs)
        Me.ugbAirport.Controls.Add(Me.txtDireccion)
        Me.ugbAirport.Controls.Add(Me.txtNombre)
        Me.ugbAirport.Controls.Add(Me.uceCiudad)
        Me.ugbAirport.Controls.Add(Me.ucePais)
        Me.ugbAirport.Controls.Add(Me.lblObservcion)
        Me.ugbAirport.Controls.Add(Me.lblDireccion)
        Me.ugbAirport.Controls.Add(Me.lblPais)
        Me.ugbAirport.Controls.Add(Me.lblCiudad)
        Me.ugbAirport.Controls.Add(Me.lblNombre)
        Me.ugbAirport.Controls.Add(Me.btnCancel)
        Me.ugbAirport.Controls.Add(Me.btnSave)
        Me.ugbAirport.Location = New System.Drawing.Point(-16, -10)
        Me.ugbAirport.Name = "ugbAirport"
        Me.ugbAirport.Size = New System.Drawing.Size(647, 561)
        Me.ugbAirport.TabIndex = 20
        Me.ugbAirport.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnWeb
        '
        Appearance1.Image = Global.SPC.My.Resources.Resources.search16x16
        Me.btnWeb.Appearance = Appearance1
        Me.btnWeb.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnWeb.Location = New System.Drawing.Point(295, 147)
        Me.btnWeb.Name = "btnWeb"
        Me.btnWeb.Size = New System.Drawing.Size(27, 26)
        Me.btnWeb.TabIndex = 23
        '
        'wbMaps
        '
        Me.wbMaps.Location = New System.Drawing.Point(28, 182)
        Me.wbMaps.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMaps.Name = "wbMaps"
        Me.wbMaps.ScrollBarsEnabled = False
        Me.wbMaps.Size = New System.Drawing.Size(548, 291)
        Me.wbMaps.TabIndex = 22
        '
        'txtLatitud
        '
        Me.txtLatitud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLatitud.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtLatitud.Location = New System.Drawing.Point(471, 120)
        Me.txtLatitud.Name = "txtLatitud"
        Me.txtLatitud.Size = New System.Drawing.Size(105, 21)
        Me.txtLatitud.TabIndex = 10
        '
        'UltraLabel6
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance10
        Me.UltraLabel6.Location = New System.Drawing.Point(367, 123)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel6.Size = New System.Drawing.Size(63, 20)
        Me.UltraLabel6.TabIndex = 21
        Me.UltraLabel6.Text = "Latitud:"
        '
        'txtLongitud
        '
        Me.txtLongitud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongitud.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtLongitud.Location = New System.Drawing.Point(471, 146)
        Me.txtLongitud.Name = "txtLongitud"
        Me.txtLongitud.Size = New System.Drawing.Size(105, 21)
        Me.txtLongitud.TabIndex = 9
        '
        'UltraLabel7
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance4
        Me.UltraLabel7.Location = New System.Drawing.Point(367, 147)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel7.Size = New System.Drawing.Size(63, 20)
        Me.UltraLabel7.TabIndex = 19
        Me.UltraLabel7.Text = "Longitud:"
        '
        'uneTerminales
        '
        Me.uneTerminales.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uneTerminales.Location = New System.Drawing.Point(471, 94)
        Me.uneTerminales.Name = "uneTerminales"
        Me.uneTerminales.Size = New System.Drawing.Size(105, 21)
        Me.uneTerminales.TabIndex = 8
        '
        'UltraLabel5
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance3
        Me.UltraLabel5.Location = New System.Drawing.Point(367, 96)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel5.Size = New System.Drawing.Size(109, 20)
        Me.UltraLabel5.TabIndex = 16
        Me.UltraLabel5.Text = "No. de Terminales:"
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtTelefono.Location = New System.Drawing.Point(91, 120)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(198, 21)
        Me.txtTelefono.TabIndex = 4
        '
        'UltraLabel4
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance9
        Me.UltraLabel4.Location = New System.Drawing.Point(28, 123)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel4.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel4.TabIndex = 14
        Me.UltraLabel4.Text = "Teléfono:"
        '
        'txtPaginaWeb
        '
        Me.txtPaginaWeb.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtPaginaWeb.Location = New System.Drawing.Point(91, 147)
        Me.txtPaginaWeb.Name = "txtPaginaWeb"
        Me.txtPaginaWeb.Size = New System.Drawing.Size(198, 21)
        Me.txtPaginaWeb.TabIndex = 5
        '
        'UltraLabel3
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance11
        Me.UltraLabel3.Location = New System.Drawing.Point(28, 147)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel3.Size = New System.Drawing.Size(60, 20)
        Me.UltraLabel3.TabIndex = 12
        Me.UltraLabel3.Text = "Web:"
        '
        'txtCodigoOACI
        '
        Me.txtCodigoOACI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoOACI.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCodigoOACI.Location = New System.Drawing.Point(471, 68)
        Me.txtCodigoOACI.Name = "txtCodigoOACI"
        Me.txtCodigoOACI.Size = New System.Drawing.Size(105, 21)
        Me.txtCodigoOACI.TabIndex = 7
        '
        'UltraLabel2
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance12
        Me.UltraLabel2.Location = New System.Drawing.Point(367, 71)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel2.Size = New System.Drawing.Size(81, 20)
        Me.UltraLabel2.TabIndex = 10
        Me.UltraLabel2.Text = "Código OACI:"
        '
        'txtCodigoIATA
        '
        Me.txtCodigoIATA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoIATA.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtCodigoIATA.Location = New System.Drawing.Point(471, 42)
        Me.txtCodigoIATA.Name = "txtCodigoIATA"
        Me.txtCodigoIATA.Size = New System.Drawing.Size(105, 21)
        Me.txtCodigoIATA.TabIndex = 6
        '
        'UltraLabel1
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance13
        Me.UltraLabel1.Location = New System.Drawing.Point(367, 43)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UltraLabel1.Size = New System.Drawing.Size(81, 20)
        Me.UltraLabel1.TabIndex = 8
        Me.UltraLabel1.Text = "Código IATA:"
        '
        'txtObs
        '
        Me.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObs.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtObs.Location = New System.Drawing.Point(28, 501)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(366, 37)
        Me.txtObs.TabIndex = 11
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtDireccion.Location = New System.Drawing.Point(91, 94)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(198, 21)
        Me.txtDireccion.TabIndex = 3
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.txtNombre.Location = New System.Drawing.Point(164, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(412, 21)
        Me.txtNombre.TabIndex = 0
        '
        'uceCiudad
        '
        Me.uceCiudad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.uceCiudad.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.uceCiudad.LimitToList = True
        Me.uceCiudad.Location = New System.Drawing.Point(91, 68)
        Me.uceCiudad.Name = "uceCiudad"
        Me.uceCiudad.Size = New System.Drawing.Size(198, 21)
        Me.uceCiudad.TabIndex = 2
        '
        'ucePais
        '
        Me.ucePais.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.ucePais.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.ucePais.LimitToList = True
        Me.ucePais.Location = New System.Drawing.Point(91, 42)
        Me.ucePais.Name = "ucePais"
        Me.ucePais.Size = New System.Drawing.Size(198, 21)
        Me.ucePais.TabIndex = 1
        '
        'lblObservcion
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblObservcion.Appearance = Appearance5
        Me.lblObservcion.Location = New System.Drawing.Point(28, 479)
        Me.lblObservcion.Name = "lblObservcion"
        Me.lblObservcion.Size = New System.Drawing.Size(86, 24)
        Me.lblObservcion.TabIndex = 6
        Me.lblObservcion.Text = "Observaciones:"
        '
        'lblDireccion
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.TextVAlignAsString = "Middle"
        Me.lblDireccion.Appearance = Appearance6
        Me.lblDireccion.Location = New System.Drawing.Point(28, 96)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(57, 20)
        Me.lblDireccion.TabIndex = 5
        Me.lblDireccion.Text = "Dirección:"
        '
        'lblPais
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblPais.Appearance = Appearance8
        Me.lblPais.Location = New System.Drawing.Point(28, 44)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(39, 20)
        Me.lblPais.TabIndex = 3
        Me.lblPais.Text = "País:"
        '
        'lblCiudad
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.TextVAlignAsString = "Middle"
        Me.lblCiudad.Appearance = Appearance7
        Me.lblCiudad.Location = New System.Drawing.Point(28, 71)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(60, 20)
        Me.lblCiudad.TabIndex = 4
        Me.lblCiudad.Text = "Ciudad:"
        '
        'lblNombre
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextVAlignAsString = "Middle"
        Me.lblNombre.Appearance = Appearance14
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(28, 18)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNombre.Size = New System.Drawing.Size(130, 20)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre de Aeropuerto:"
        '
        'btnCancel
        '
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Me.btnCancel.Appearance = Appearance2
        Me.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnCancel.Location = New System.Drawing.Point(491, 501)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 35)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancelar"
        '
        'btnSave
        '
        Appearance15.Image = Global.SPC.My.Resources.Resources.save24x24
        Me.btnSave.Appearance = Appearance15
        Me.btnSave.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button
        Me.btnSave.Location = New System.Drawing.Point(400, 501)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 35)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Guardar"
        '
        'frmAirporDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 541)
        Me.Controls.Add(Me.ugbAirport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAirporDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de Aeropuerto"
        CType(Me.ugbAirport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbAirport.ResumeLayout(False)
        Me.ugbAirport.PerformLayout()
        CType(Me.txtLatitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLongitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uneTerminales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaginaWeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoOACI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoIATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uceCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucePais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugbAirport As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtObs As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDireccion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtNombre As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblObservcion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblDireccion As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblNombre As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uceCiudad As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ucePais As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblPais As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblCiudad As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtLatitud As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtLongitud As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents uneTerminales As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtTelefono As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtPaginaWeb As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCodigoOACI As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtCodigoIATA As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents wbMaps As System.Windows.Forms.WebBrowser
    Friend WithEvents btnWeb As Infragistics.Win.Misc.UltraButton
End Class
