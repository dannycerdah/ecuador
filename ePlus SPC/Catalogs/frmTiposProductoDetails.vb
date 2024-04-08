Imports SPC.Server.ReportService
Public Class frmTiposProductoDetails
    Public Property myTipo As New TipoProductoCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewTipo As Boolean = False

    Private Sub InitializeValues()
        myTipo.idTipo = Guid.Empty
        myTipo.descripcionTipo = ""
    End Sub

    Public Sub New(ByVal myTipoItem As TipoProductoCatalogItem)
        InitializeComponent()
        InitializeValues()
        myTipo = myTipoItem
    End Sub

    Public Sub New(MustCreateNewMterial As Boolean)
        InitializeComponent()
        InitializeValues()
        myTipo.idTipo = Guid.NewGuid
        IsNewTipo = True
    End Sub

    Public Sub New(ByVal TipoId As Guid)
        InitializeComponent()
        InitializeValues()
        myTipo = CommonData.GetTipoProductoItem(TipoId)
    End Sub


    Private Sub frmTipoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillTipoInfo()
    End Sub

    Private Sub FillTipoInfo()
        If Not IsNewTipo Then
            txtDescripcion.Text = myTipo.descripcionTipo
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New TipoProductoRequest
        Dim res As New TipoProductoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsNewTipo Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                TipoProductoInfoToObject()
                req.myTipoProductoItem = myTipo
                res = wsClnt.SaveTipoProductoItem(req)
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

    Private Sub TipoProductoInfoToObject()
        If IsNewTipo Then
            myTipo.idTipo = Guid.NewGuid
        End If
        myTipo.descripcionTipo = txtDescripcion.Text
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

