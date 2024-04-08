Imports SPC.Server.ReportService
Imports SPC.Server.VuelosService
Public Class frmVueloDetails
    Dim IsNewVuelo As Boolean = False
    Dim myVuelo As New VueloItem
    Dim idAgencia As Guid
    Dim tempIdPaisO As Guid = Guid.Empty
    Dim tempIdPaisL As Guid = Guid.Empty
    Dim abrv As String

    Public Sub New(MustCreateNewMatrizSeguridad As Boolean, aerolinea As String, idAerolinea As Guid, abrv As String)
        InitializeComponent()
        IsNewVuelo = True
        idAgencia = idAerolinea
        txtAerolinea.Text = aerolinea
        txtabrv.Text = abrv
        myVuelo.idVuelo = Guid.NewGuid

    End Sub

    Public Sub New(ByVal idVuelo As Guid)
        InitializeComponent()
        myVuelo.idVuelo = idVuelo
    End Sub

    Private Sub PopulatePais()
        Dim contO As Integer = 0
        Dim contL As Integer = 0
        Dim seg As Boolean = True
        ucePaisO.Items.Clear()
        ucePaisO.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetPais().Rows

            ucePaisO.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
            If r.Item("idPais") <> tempIdPaisO And seg Then
                contO = contO + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            ucePaisO.SelectedIndex = 0
        Else
            ucePaisO.SelectedIndex = contO + 1
        End If
        seg = True
        ucePaisL.Items.Clear()
        ucePaisL.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            ucePaisL.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
            If r.Item("idPais") <> tempIdPaisL And seg Then
                contL = contL + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            ucePaisL.SelectedIndex = 0
        Else
            ucePaisL.SelectedIndex = contL + 1
        End If
    End Sub

    Private Sub ucePaisO_SelectionChanged(sender As Object, e As EventArgs) Handles ucePaisO.SelectionChanged
            PopulateCiudadO()
    End Sub

    Private Sub PopulateCiudadO()
        Dim contO As Integer = 0
        Dim seg As Boolean = True
        uceCiudadO.Items.Clear()
        uceCiudadO.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetCiudad(ucePaisO.Value.ToString).Rows
            uceCiudadO.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
            If r.Item("idCiudad") <> myVuelo.CiudadOrigen And seg Then
                contO = contO + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            uceCiudadO.SelectedIndex = 0
        Else
            uceCiudadO.SelectedIndex = contO + 1
        End If
    End Sub

    Private Sub PopulateCiudadL()
        Dim contL As Integer = 0
        Dim seg As Boolean = True
        uceCiudadL.Items.Clear()
        uceCiudadL.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetCiudad(ucePaisL.Value.ToString).Rows
            uceCiudadL.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
            If r.Item("idCiudad") <> myVuelo.CiudadLlegada And seg Then
                contL = contL + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            uceCiudadL.SelectedIndex = 0
        Else
            uceCiudadL.SelectedIndex = contL + 1
        End If
    End Sub

    Private Sub ucePaisL_SelectionChanged(sender As Object, e As EventArgs) Handles ucePaisL.SelectionChanged
            PopulateCiudadL()
    End Sub

    Private Sub frmVueloDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsNewVuelo Then
            myVuelo = CommonData.GetVueloItem(myVuelo.idVuelo)
            txtAerolinea.Text = CommonData.GetAgenciaItem(myVuelo.idAgencia).Descripcion
            txtabrv.Text = CommonData.GetAgenciaItem(myVuelo.idAgencia).abreviatura
            txtNVuelo.Text = myVuelo.descripcion
            tempIdPaisO = CommonData.GetCiudadItem(myVuelo.CiudadOrigen).IdPais
            tempIdPaisL = CommonData.GetCiudadItem(myVuelo.CiudadLlegada).IdPais
        End If


        PopulatePais()
    End Sub
    Private Sub uceCiudadO_SelectionChanged(sender As Object, e As EventArgs) Handles uceCiudadO.SelectionChanged
        Dim cont As Integer = 0
        Dim seg As Boolean = True
        uceAeropuertoO.Items.Clear()
        uceAeropuertoO.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudadO.Value).Rows
            uceAeropuertoO.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
            If r.Item("idAeropuerto") <> myVuelo.AeropuertoOrigen And seg Then
                cont = cont + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            uceAeropuertoO.SelectedIndex = 0
        Else
            uceAeropuertoO.SelectedIndex = cont + 1
        End If
    End Sub

    Private Sub uceCiudadL_SelectionChanged(sender As Object, e As EventArgs) Handles uceCiudadL.SelectionChanged
        Dim cont As Integer = 0
        Dim seg As Boolean = True
        uceAeropuertoL.Items.Clear()
        uceAeropuertoL.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudadL.Value).Rows
            uceAeropuertoL.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
            If r.Item("idAeropuerto") <> myVuelo.AeropuertoLlegada And seg Then
                cont = cont + 1
            Else
                seg = False
            End If
        Next
        If IsNewVuelo Then
            uceAeropuertoL.SelectedIndex = 0
        Else
            uceAeropuertoL.SelectedIndex = cont + 1
        End If
    End Sub

    Private Sub uceAeropuertoL_SelectionChanged(sender As Object, e As EventArgs) Handles uceAeropuertoL.SelectionChanged
        If uceAeropuertoL.Value = uceAeropuertoO.Value And uceAeropuertoL.Text <> "Escoja una Opción" And Not IsNothing(uceAeropuertoO.Value) Then
            MessageBox.Show("No puede seleccionar el mismo Aeropuerto de Origen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            uceAeropuertoL.Items.Clear()
            uceAeropuertoL.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudadL.Value).Rows
                uceAeropuertoL.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
            Next
            uceAeropuertoL.SelectedIndex = 0
        End If
    End Sub

    Private Sub uceAeropuertoO_SelectionChanged(sender As Object, e As EventArgs) Handles uceAeropuertoO.SelectionChanged
        If uceAeropuertoL.Value = uceAeropuertoO.Value And uceAeropuertoO.Text <> "Escoja una Opción" And Not IsNothing(uceAeropuertoL.Value) Then
            MessageBox.Show("No puede seleccionar el mismo Aeropuerto de Llegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            uceAeropuertoO.Items.Clear()
            uceAeropuertoO.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In CommonData.GetAeropuertoPorIdCiudad(uceCiudadL.Value).Rows
                uceAeropuertoO.Items.Add(r.Item("idAeropuerto"), r.Item("nombreAeropuerto"))
            Next
            uceAeropuertoO.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim req As New VueloRequest
        Dim res As New VueloResponse
        Dim wsClnt As New VuelosServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtNVuelo.Text = "" Then
                MessageBox.Show("Ingrese el Número de Vuelo.", "Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceAeropuertoO.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja un Aeropuerto de Origen.", "Aeropuerto Origen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceAeropuertoL.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja un Aeropuerto de Llegada.", "Aeropuerto Llegada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewVuelo Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                VueloInfoToObject()
                req.myVueloItem = myVuelo
                res = wsClnt.SaveVueloItem(req)
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

    Private Sub VueloInfoToObject()
        If IsNewVuelo Then
            myVuelo.idAgencia = idAgencia
        End If
        myVuelo.CiudadOrigen = uceCiudadO.Value
        myVuelo.CiudadLlegada = uceCiudadL.Value
        myVuelo.AeropuertoOrigen = uceAeropuertoO.Value
        myVuelo.AeropuertoLlegada = uceAeropuertoL.Value
        myVuelo.descripcion = txtNVuelo.Text
        myVuelo.fecha = udtFecha.Value


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ucePaisO_ValueChanged(sender As Object, e As EventArgs) Handles ucePaisO.ValueChanged

    End Sub
End Class

