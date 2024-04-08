Imports SPC.Server.ReportService
Public Class frmCiudadDetails
    Public Property myCiudad As New CiudadCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewCiudad As Boolean = False

    Private Sub InitializeValues()
        myCiudad.Id = Guid.Empty
        myCiudad.IdPais = Guid.Empty
        myCiudad.CodigoPais = ""
        myCiudad.NombreCiudad = ""
        myCiudad.NombrePais = ""
    End Sub

    Public Sub New(ByVal myCiudadItem As CiudadCatalogItem)
        InitializeComponent()
        InitializeValues()
        myCiudad = myCiudadItem
    End Sub

    Public Sub New(MustCreateNewCiudad As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulatePais()
        IsNewCiudad = True
    End Sub

    Public Sub New(ByVal CiudadId As Guid)
        InitializeComponent()
        InitializeValues()
        myCiudad = CommonData.GetCiudadItem(CiudadId)
    End Sub


    Private Sub frmCiudadDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillCiudadInfo()
    End Sub

    Private Sub FillCiudadInfo()
        If Not IsNewCiudad Then

            txtCiudad.Text = myCiudad.NombreCiudad
            ucePais.Items.Clear()
            ucePais.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In CommonData.GetPais().Rows
                ucePais.Items.Add(r.Item("idPais"), r.Item("nombrePais"))
            Next
            ucePais.SelectedIndex = 0
            For i As Integer = 0 To ucePais.Items.Count - 1
                ucePais.SelectedIndex = i
                If ucePais.Value = myCiudad.IdPais Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New CiudadRequest
        Dim res As New CiudadResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtCiudad.Text = "" Then
                MessageBox.Show("Ingrese el Nombre de la Ciudad.", "Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(ucePais.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja País de la Ciudad.", "País", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If IsNewCiudad Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CiudadInfoToObject()
                req.myCiudadCatItem = myCiudad
                res = wsClnt.SaveCiudadInfo(req)
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

    Private Sub CiudadInfoToObject()
        If IsNewCiudad Then
            myCiudad.Id = Guid.NewGuid
        End If
        myCiudad.IdPais = ucePais.Value
        myCiudad.CodigoPais = CommonData.GetCodigoPais(myCiudad.IdPais).Rows(0).Item("codigoPais").ToString
        myCiudad.NombreCiudad = txtCiudad.Text
    End Sub

    Private Sub PopulatePais()
        ucePais.Items.Clear()
        ucePais.Items.Add(String.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            ucePais.Items.Add(r.Item("idPais"), r.Item("nombrePais"))
        Next
        ucePais().SelectedIndex = 0
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

End Class

