Imports SPC.Server.ReportService
Public Class frmAirplaneDetails
    Public Property myAirplane As New AirplaneCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewAirplane As Boolean = False
    Dim agencia1 As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"

    Private Sub InitializeValues()
        myAirplane.id = Guid.Empty
        myAirplane.Descripcion = ""
        myAirplane.Modelo = ""
        myAirplane.Tipo = ""
        myAirplane.PesoMax = 0
        myAirplane.Matricula = ""
        myAirplane.estado = ""
    End Sub

    Public Sub New(ByVal myAirplaneItem As AirplaneCatalogItem)
        InitializeComponent()
        InitializeValues()
        myAirplane = myAirplaneItem
    End Sub

    Public Sub New(MustCreateNewAirplane As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()
        PopulateTipo()
        myAirplane.Id = Guid.NewGuid()
        IsNewAirplane = True
    End Sub

    Public Sub New(ByVal AirplaneId As Guid)
        InitializeComponent()
        InitializeValues()
        myAirplane = CommonData.GetAirplaneItem(AirplaneId)
    End Sub


    Private Sub frmAirplaneDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cargarComboAgencia()
        FillAirplaneInfo()
    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(agencia1).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub FillAirplaneInfo()
        If Not IsNewAirplane Then
            txtDescripcion.Text = myAirplane.Descripcion
            txtModelo.Text = myAirplane.Modelo
            txtPesoMaximo.Text = myAirplane.PesoMax
            txtMatricula.Text = myAirplane.Matricula
            cargarComboAgencia()
            For i As Integer = 0 To uceAgencia.Items.Count - 1
                uceAgencia.SelectedIndex = i
                If uceAgencia.Value = myAirplane.IdAgencia Then
                    Exit For
                End If
            Next
            PopulateTipo()
            For i As Integer = uceTipo.Items.Count - 1 To 0 Step -1
                uceTipo.SelectedIndex = i
                If uceTipo.Value.ToString = myAirplane.Tipo.ToString Then
                    Exit For
                End If
            Next
            uceEstado.Items.Clear()
            For Each r As DataRow In CommonData.GetEstado().Rows
                uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
            Next
            uceEstado.SelectedIndex = 0
        End If
    End Sub


    Private Sub SaveChanges()
        Dim req As New AirplaneRequest
        Dim res As New AirplaneResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.Compare(uceEstado.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Estado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.Compare(uceTipo.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.Compare(uceAgencia.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Aerolínea", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsNewAirplane Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                AirplaneInfoToObject()
                req.myAirplaneCatItem = myAirplane
                res = wsClnt.SaveAirplaneInfo(req)
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


    Private Sub AirplaneInfoToObject()
        If IsNewAirplane Then
            myAirplane.Id = New Guid
        End If
        myAirplane.IdAgencia = uceAgencia.Value
        myAirplane.Descripcion = txtDescripcion.Text
        myAirplane.Modelo = txtModelo.Text
        myAirplane.Tipo = uceTipo.Value
        myAirplane.PesoMax = txtPesoMaximo.Text
        myAirplane.Matricula = txtMatricula.Text
        myAirplane.estado = uceEstado.Value
    End Sub

    Private Sub PopulateTipo()
        uceTipo.Items.Clear()
        uceTipo.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetTipo().Rows
            uceTipo.Items.Add(r.Item("idTipo"), r.Item("descripcion"))
        Next
        uceTipo.SelectedIndex = 0
    End Sub

    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        uceEstado.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
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

End Class