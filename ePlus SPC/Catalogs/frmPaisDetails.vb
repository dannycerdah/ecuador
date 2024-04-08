Imports SPC.Server.ReportService
Public Class frmPaisDetails
    Public Property myPais As New PaisCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewPais As Boolean = False

    Private Sub InitializeValues()
        myPais.Id = Guid.Empty
        myPais.CodigoPais = ""
        myPais.NombrePais = ""
        myPais.Nacionalidad = ""
    End Sub

    Public Sub New(ByVal myPaisItem As PaisCatalogItem)
        InitializeComponent()
        InitializeValues()
        myPais = myPaisItem
    End Sub

    Public Sub New(MustCreateNewCamion As Boolean)
        InitializeComponent()
        InitializeValues()
        myPais.Id = Guid.NewGuid()
        IsNewPais = True
    End Sub

    Public Sub New(ByVal PaisId As Guid)
        InitializeComponent()
        InitializeValues()
        myPais = CommonData.GetPaisItem(PaisId)
    End Sub


    Private Sub frmPaisDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillPaisInfo()
    End Sub

    Private Sub FillPaisInfo()
        If Not IsNewPais Then

            txtPais.Text = myPais.NombrePais
            txtCodigo.Text = myPais.CodigoPais
            txtNacionalidad.Text = myPais.Nacionalidad
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New PaisRequest
        Dim res As New PaisResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtPais.Text = "" Then
                MessageBox.Show("Ingrese Nombre del País.", "País", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtCodigo.Text = "" Then
                MessageBox.Show("Ingrese Codigo del País.", "Codigo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtNacionalidad.Text = "" Then
                MessageBox.Show("Ingrese Nacionalidad.", "Nacionalidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            If IsNewPais Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CiudadInfoToObject()
                req.myPaisCatItem = myPais
                res = wsClnt.SavePaisInfo(req)
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
        If IsNewPais Then
            myPais.Id = New Guid
        End If
        myPais.NombrePais = txtPais.Text
        myPais.CodigoPais = txtCodigo.Text
        myPais.Nacionalidad = txtNacionalidad.Text
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

