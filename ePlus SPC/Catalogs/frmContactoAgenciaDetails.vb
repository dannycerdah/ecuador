Imports SPC.Server.ReportService
Public Class frmContactoAgenciaDetails
    Shared Property myContactoAgencia As New ContactoAgenciaCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewContactoAgencia As Boolean = False
    Dim myIndice As Guid
    Dim agencia As Guid
    Dim contacto As String = String.Empty
    Private L_IdContactoUser As String = 0

    Private Sub InitializeValues()
        myContactoAgencia.idAgencia = Guid.Empty
        myContactoAgencia.descripcionAgencia = ""
        myContactoAgencia.idContacto = ""
        myContactoAgencia.primerNombre = ""
        myContactoAgencia.segundoNombre = ""
        myContactoAgencia.primerApellido = ""
        myContactoAgencia.segundoApellido = ""
        myContactoAgencia.fechaInicio = Date.Today
        myContactoAgencia.fechaFin = Date.Today
        myContactoAgencia.estado = ""
        myContactoAgencia.comentario = ""
        myContactoAgencia.cargo = ""
    End Sub

    Public Sub New(ByVal myContactoAgenciaItem As ContactoAgenciaCatalogItem)
        InitializeComponent()
        InitializeValues()
        myContactoAgencia = myContactoAgenciaItem
    End Sub

    Public Sub New(MustCreateNew As Boolean, idAgencia As Guid, idContacto As String)
        InitializeComponent()
        agencia = idAgencia
        contacto = idContacto
        InitializeValues()
        IsNewContactoAgencia = True
    End Sub
    Public Sub New(MustCreateNew As Boolean, idAgencia As Guid, idContacto As String, IdContactoUser As String)
        InitializeComponent()
        agencia = idAgencia
        contacto = idContacto
        InitializeValues()
        IsNewContactoAgencia = True
        L_IdContactoUser = IdContactoUser
    End Sub

    Public Sub New(ByVal idAgencia As Guid, ByVal idContacto As String, ByVal fechaIni As Date, ByVal estado As String, ByVal indice As Guid)
        InitializeComponent()
        agencia = idAgencia
        contacto = idContacto
        myIndice = indice
        InitializeValues()
        myContactoAgencia = CommonData.GetContactoAgenciaPorId(idAgencia, idContacto, fechaIni, estado)
    End Sub

    Public Sub New(ByVal idAgencia As Guid, ByVal idContacto As String, ByVal fechaIni As Date, ByVal estado As String, ByVal indice As Guid, IdContactoUser As String)
        InitializeComponent()
        agencia = idAgencia
        contacto = idContacto
        myIndice = indice
        InitializeValues()
        L_IdContactoUser = IdContactoUser
        myContactoAgencia = CommonData.GetContactoAgenciaPorId(idAgencia, idContacto, fechaIni, estado)
    End Sub


    Private Sub frmTipoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        FillTipoInfo()
    End Sub

    Private Sub FillTipoInfo()
        'MARZ
        Dim frm As frmContactoDetails

        If Not MyCurrentUser.isAdministrador Then
            btnNuevoCargo.Visible = False
        End If
        If Not IsNewContactoAgencia Then
            Dim contactoItem As ContactoCatalogItem = CommonData.GetContactoItem(myContactoAgencia.idContacto)
            Dim agenciaItem As AgenciaCatalogItem = CommonData.GetAgenciaItem(agencia)
            uceContacto.Clear()
            uceContacto.Items.Add(contactoItem.idContacto, contactoItem.primerNombre & " " & contactoItem.primerApellido & " " & contactoItem.segundoApellido)
            uceContacto.SelectedIndex = 0
            PopulateAgencia()
            For i As Integer = 0 To uceAgencia.Items.Count - 1
                uceAgencia.SelectedIndex = i
                If uceAgencia.Value = agenciaItem.Id Then
                    Exit For
                End If
            Next
            PopulateCargo()
            For i As Integer = 0 To uceCargo.Items.Count - 1
                uceCargo.SelectedIndex = i
                If uceCargo.Text = myContactoAgencia.cargo Then
                    Exit For
                End If
            Next

            PopulateEstado()
            For i As Integer = 0 To uceEstado.Items.Count - 1
                uceEstado.SelectedIndex = i
                If uceEstado.Value = myContactoAgencia.estado Then
                    Exit For
                End If
            Next
            udtFechaIni.Value = myContactoAgencia.fechaInicio
            udtFechaFin.Value = myContactoAgencia.fechaFin
            txtComentario.Text = myContactoAgencia.comentario
        Else
            If agencia = Guid.Empty Then
                PopulateAgencia()
                Dim contactoItem As ContactoCatalogItem = CommonData.GetContactoItem(contacto)
                uceContacto.Clear()
                If frmContactoDetails.IsNewContacto Then
                    uceContacto.Items.Add(frmContactoDetails.idContactoNuevo, frmContactoDetails.sNombreContacto)

                Else
                    uceContacto.Items.Add(contactoItem.idContacto, contactoItem.primerNombre & " " & contactoItem.primerApellido & " " & contactoItem.segundoApellido)
                End If
                uceContacto.SelectedIndex = 0
            Else
                PopulateContacto()
                Dim agenciaItem As AgenciaCatalogItem = CommonData.GetAgenciaItem(agencia)
                PopulateAgencia()
                For i As Integer = 0 To uceAgencia.Items.Count - 1
                    uceAgencia.SelectedIndex = i
                    If uceAgencia.Value = agenciaItem.Id Then
                        Exit For
                    End If
                Next

            End If
            PopulateEstado()
            PopulateCargo()
            udtFechaIni.Value = Date.Today
            udtFechaFin.Value = Date.Today
            txtComentario.Text = ""
            End If
    End Sub

    Public Sub PopulateContacto()
        Dim dtContacto As DataTable = CommonData.GetEntireContactoCatalog()
        uceContacto.Items.Clear()
        uceContacto.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In dtContacto.Rows
            uceContacto.Items.Add(r.Item("idContacto"), r.Item("primerNombreContacto") & " " & r.Item("primerApellidoContacto") & " " & r.Item("segundoApellidoContacto"))
        Next
        uceContacto.SelectedIndex = 0
    End Sub

    Public Sub PopulateAgencia()
        Dim dtAgencia As DataTable = CommonData.GetAgenciaCatalog()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In dtAgencia.Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Public Sub PopulateEstado()
        uceEstado.Items.Clear()
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
    End Sub

    Public Sub PopulateCargo()
        uceCargo.Items.Clear()
        For Each r As DataRow In CommonData.GetCargoCatalog().Rows
            uceCargo.Items.Add(r.Item("idCargo"), r.Item("descripcionCargo"))
        Next
        uceCargo.SelectedIndex = 0
    End Sub

    Private Sub SaveChanges()
        Dim req As New ContactoAgenciaRequest
        Dim res As New ContactoAgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If String.Compare(uceContacto.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Contacto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.Compare(uceAgencia.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Actividad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.Compare(uceEstado.Text, "") = 0 Then
                MessageBox.Show("Escoja Estado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If String.Compare(uceCargo.Text, "") = 0 Then
                MessageBox.Show("Escoja Cargo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If IsNewContactoAgencia Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                ContactoAgenciaInfoToObject()
                myContactoAgencia.IdContactoUser = L_IdContactoUser
                req.myContactoAgenciaItem = myContactoAgencia
                If frmContactoDetails.IsNewContacto = False Then
                    res = wsClnt.SaveContactoAgenciaInfo(req)
                    If res.ActionResult Then
                        MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Throw New Exception(res.ErrorMessage)
                    End If
                Else

                    frmContactoDetails.ContactoAgenciaCatalogo = myContactoAgencia


                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub ContactoAgenciaInfoToObject()
        If Not IsNewContactoAgencia Then myContactoAgencia.indice = myIndice
        myContactoAgencia.idAgencia = uceAgencia.Value
        myContactoAgencia.idContacto = uceContacto.Value
        myContactoAgencia.fechaInicio = udtFechaIni.Value
        myContactoAgencia.fechaFin = udtFechaFin.Value
        myContactoAgencia.estado = uceEstado.Value
        myContactoAgencia.comentario = txtComentario.Text
        myContactoAgencia.cargo = uceCargo.Text
        myContactoAgencia.descripcionAgencia = uceAgencia.Text
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub uceAgencia_ValueChanged(sender As Object, e As EventArgs) Handles uceAgencia.ValueChanged
        If uceAgencia.Text = "GENERALAIR S.A." Then
            UltraLabel6.Visible = True
            UltraLabel3.Visible = True
            udtFechaIni.Visible = True
            udtFechaFin.Visible = True
        Else
            UltraLabel6.Visible = False
            UltraLabel3.Visible = False
            udtFechaIni.Visible = False
            udtFechaFin.Visible = False
            udtFechaIni.Value = "01/01/2000"
            udtFechaFin.Value = "01/01/2000"
        End If
    End Sub

    Private Sub btnNuevoCargo_Click(sender As Object, e As EventArgs) Handles btnNuevoCargo.Click
        'MARZ
        Using frmCargo As New frmCargoDetails()
            frmCargo.ShowDialog()
        End Using
        PopulateCargo() 'Recargar
    End Sub
End Class

