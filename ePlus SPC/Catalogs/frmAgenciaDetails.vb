Imports SPC.Server.ReportService
Public Class frmAgenciaDetails
    Public Property myAgencia As New AgenciaCatalogItem
    Private Property blnDetailsEditingMode As Boolean = False
    Private Property IsNewAgencia As Boolean = False
    Dim TipoAgencia As Guid
    Dim idTipoAerolinea As Guid = Guid.Parse("04be18e6-fd0c-4466-aed2-04b0e8025772")
    Dim dtVuelos As New DataTable("dtVuelos")

    Private Sub InitializeValues()
        myAgencia.Id = Guid.Empty
        myAgencia.Tipo = Guid.Empty
        myAgencia.Descripcion = ""
        myAgencia.Direccion = ""
        myAgencia.Telefono = ""
        myAgencia.Mail = ""
        myAgencia.Contacto = ""
        myAgencia.Estado = ""
        myAgencia.Observacion = ""
        myAgencia.RepresentanteLegal = ""
        myAgencia.Ruc = ""
        myAgencia.TipoContribuyente = ""
        myAgencia.RazonSocial = ""
    End Sub

    Public Sub New(ByVal myAgenciaItem As AgenciaCatalogItem)
        InitializeComponent()
        InitializeValues()
        myAgencia = myAgenciaItem
    End Sub

    Public Sub New(MustCreateNewAgencia As Boolean, ByVal Tipo As Guid)
        TipoAgencia = Tipo
        myAgencia.Id = Guid.NewGuid()
        IsNewAgencia = True
        InitializeComponent()
        uceTabs.Tabs.Item("VUE").Enabled = False
        uceTabs.Tabs.Item("BLI").Enabled = False
        If idTipoAerolinea <> TipoAgencia Then
            lblHPro.Visible = False
            dtpHoraP.Visible = False
        End If
        InitializeValues()
        PopulateEstado()
        PopulateTipo()
    End Sub

    Public Sub New(ByVal AgenciaId As Guid, ByVal Tipo As Guid)
        InitializeComponent()
        TipoAgencia = Tipo
        If idTipoAerolinea <> TipoAgencia Then
            uceTabs.Tabs.Item("VUE").Enabled = False
            lblHPro.Visible = False
            dtpHoraP.Visible = False
            Me.chkCourrier.Checked = False
            Me.chkCourrier.Visible = False
        End If
        InitializeValues()
        myAgencia = CommonData.GetAgenciaItem(AgenciaId)
    End Sub

    Private Sub frmAgenciaDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If idTipoAerolinea = TipoAgencia Then
            With dtVuelos.Columns
                .Add("idVuelo", GetType(Guid))
                .Add("descripcionVuelo", GetType(String))
                .Add("descripcionAgencia", GetType(String))
                .Add("ciudadOrigen", GetType(String))
                .Add("ciudadLlegada", GetType(String))
                .Add("fecha", GetType(DateTime))
            End With
            RefreshDataVuelo()

            Me.chkCourrier.Visible = True

        End If
        FillAgenciaInfo()
        RefreshData()
    End Sub


    Public Sub RefreshData()
        ugdListaArchivos.DataSource = CommonData.GetArchivoAgenciaItemByAgencia(myAgencia.Id)
        SetDisplayedColumns()
    End Sub

    Public Sub RefreshDataVuelo()
        dtVuelos.Rows.Clear()
        Dim nr As DataRow
        For Each r As DataRow In CommonData.GetVuelosPorIdAgencia(myAgencia.Id).Rows
            nr = dtVuelos.NewRow
            nr.Item("idVuelo") = r.Item("idVuelo")
            nr.Item("descripcionVuelo") = r.Item("descripcionVuelo")
            nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
            nr.Item("ciudadOrigen") = CommonData.GetCiudadItem(r.Item("ciudadOrigen")).NombreCiudad
            nr.Item("ciudadLlegada") = CommonData.GetCiudadItem(r.Item("ciudadLlegada")).NombreCiudad
            nr.Item("fecha") = r.Item("fecha")
            dtVuelos.Rows.Add(nr)
        Next
        ugvVuelos.DataSource = dtVuelos
        SetDisplayedColumnsUgvVuelos()
    End Sub

    Private Sub FillAgenciaInfo()
        If Not IsNewAgencia Then

            txtNombre.Text = myAgencia.Descripcion
            txtDireccion.Text = myAgencia.Direccion
            txtTelefono.Text = myAgencia.Telefono
            txtEmail.Text = myAgencia.Mail
            txtContacto.Text = myAgencia.Contacto
            txtObs.Text = myAgencia.Observacion
            txtRepre.Text = myAgencia.RepresentanteLegal
            txtRuc.Text = myAgencia.Ruc
            txtTipCon.Text = myAgencia.TipoContribuyente
            txtRaz.Text = myAgencia.RazonSocial
            txtabvr.Text = myAgencia.abreviatura
            If myAgencia.horaProceso <> Nothing Then
                dtpHoraP.Text = myAgencia.horaProceso
            End If
            For Each r As DataRow In CommonData.GetEstado().Rows
                uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
            Next
            For Each r As DataRow In CommonData.GetTipoAgenciaPorId(myAgencia.Tipo.ToString).Rows
                uceTipo.Items.Add(r.Item("idTipo"), r.Item("descripcionTipo"))
            Next
            uceEstado.SelectedIndex = 0
            uceTipo.SelectedIndex = 0


            Me.Text = "Detalle " & uceTipo.Text
        End If
    End Sub


    Private Sub SaveChanges()
        Dim req As New AgenciaRequest
        Dim res As New AgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtNombre.Text = "" Then
                MessageBox.Show("Ingrese el Nombre de la agencia.", "Nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceEstado.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja Estado de la agencia.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceTipo.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja Tipo de la agencia.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewAgencia Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                AgenciaInfoToObject()
                req.myAgenciaCatItem = myAgencia
                res = wsClnt.SaveAgenciaInfo(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
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


    Private Sub AgenciaInfoToObject()
        If IsNewAgencia Then
            myAgencia.Id = New Guid
        End If
        myAgencia.Estado = uceEstado.Value
        myAgencia.Tipo = uceTipo.Value
        myAgencia.Descripcion = txtNombre.Text
        myAgencia.Direccion = txtDireccion.Text
        myAgencia.Telefono = txtTelefono.Text
        myAgencia.Mail = txtEmail.Text
        myAgencia.Contacto = txtContacto.Text
        myAgencia.Observacion = txtObs.Text
        myAgencia.RepresentanteLegal = txtRepre.Text
        myAgencia.Ruc = txtRuc.Text
        myAgencia.TipoContribuyente = txtTipCon.Text
        myAgencia.RazonSocial = txtRaz.Text
        myAgencia.abreviatura = txtabvr.Text
        myAgencia.horaProceso = dtpHoraP.Value.TimeOfDay.ToString
        myAgencia.horaProceso = myAgencia.horaProceso.Substring(0, 5)
    End Sub

    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
    End Sub

    Private Sub PopulateTipo()
        uceTipo.Items.Clear()
        For Each r As DataRow In CommonData.GetTipoAgenciaPorId(TipoAgencia.ToString).Rows
            uceTipo.Items.Add(r.Item("idTipo"), r.Item("descripcionTipo"))
        Next
        uceTipo.SelectedIndex = 0
        Me.Text = "Detalle de la Agencia: " & uceTipo.Text
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub SetDisplayedColumns()
        ugdListaArchivos.DisplayLayout.Bands(0).Columns("idEntidad").Hidden = True
        ugdListaArchivos.DisplayLayout.Bands(0).Columns("idArchivo").Hidden = True
        ugdListaArchivos.DisplayLayout.Bands(0).Columns("descripcionArchivo").Header.Caption = "Descripción"
        ugdListaArchivos.DisplayLayout.Bands(0).Columns("extArchivo").Header.Caption = "Tipo"
        ugdListaArchivos.DisplayLayout.Bands(0).Columns("binArchivo").Hidden = True
    End Sub

    Private Sub ugdListaArchivos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdListaArchivos.DoubleClickCell
        If Not ugdListaArchivos.ActiveRow.Cells("idArchivo").Value.ToString = String.Empty Then
            ShowAirportDetails(ugdListaArchivos.ActiveRow.Cells("idArchivo").Value)
        Else
            Using frmDetails As New frmArchivo(myAgencia.Id)
                frmDetails.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ShowAirportDetails(id As Guid)
        Using frmDetails As New frmArchivo(myAgencia.Id, id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ugvVuelos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvVuelos.DoubleClickCell
        If Not ugvVuelos.ActiveRow.Cells("idVuelo").Value.ToString = String.Empty Then
            ShowVueloDetails(ugvVuelos.ActiveRow.Cells("idVuelo").Value)
        Else
            Using frmDetails As New frmVueloDetails(True, myAgencia.Descripcion, myAgencia.Id, myAgencia.abreviatura)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshDataVuelo()
    End Sub

    Private Sub SetDisplayedColumnsUgvVuelos()
        ugvVuelos.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True
        ugvVuelos.DisplayLayout.Bands(0).Columns("descripcionVuelo").Header.Caption = "Vuelo"
        'ugvVuelos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea"
        ugvVuelos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Hidden = True
        ugvVuelos.DisplayLayout.Bands(0).Columns("ciudadOrigen").Header.Caption = "Ciudad Origen"
        'ugvVuelos.DisplayLayout.Bands(0).Columns("aeropuertoOrigen").Header.Caption = "Aeropuerto Origen"
        ugvVuelos.DisplayLayout.Bands(0).Columns("ciudadLlegada").Header.Caption = "Ciudad Llegada"
        'ugvVuelos.DisplayLayout.Bands(0).Columns("aeropuertoLlegada").Header.Caption = "Aeropuerto Llegada"
        ugvVuelos.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
        ugvVuelos.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
        ugvVuelos.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
    End Sub

    Private Sub ShowVueloDetails(id As Guid)
        Using frmDetails As New frmVueloDetails(id)
            'frmDetails.RefreshData()
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub ugvVuelos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugvVuelos.InitializeLayout

    End Sub

    Private Sub txtNombre_ValueChanged(sender As Object, e As EventArgs) Handles txtNombre.ValueChanged

    End Sub

    Private Sub ugbAgencia_Click(sender As Object, e As EventArgs) Handles ugbAgencia.Click

    End Sub
End Class