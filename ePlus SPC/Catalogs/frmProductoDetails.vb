Imports SPC.Server.ReportService
Public Class frmProductoDetails
    Public Property myProducto As New ProductoCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewProducto As Boolean = False

    Private Sub InitializeValues()
        myProducto.IdProducto = Guid.Empty
        myProducto.IdTipo = Guid.Empty
        myProducto.DescripcionProducto = ""
        myProducto.descripcionTipo = ""
    End Sub

    Public Sub New(ByVal myProductoItem As ProductoCatalogItem)
        InitializeComponent()
        InitializeValues()
        myProducto = myProductoItem
    End Sub

    Public Sub New(MustCreateNewMterial As Boolean)
        InitializeComponent()
        InitializeValues()
        myProducto.IdProducto = Guid.NewGuid
        IsNewProducto = True
    End Sub

    Public Sub New(ByVal ProductoId As Guid)
        InitializeComponent()
        InitializeValues()
        myProducto = CommonData.GetProductoItem(ProductoId)
    End Sub


    Private Sub frmProductoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillProductoInfo()
    End Sub

    Private Sub FillProductoInfo()
        If Not IsNewProducto Then
            txtDescripcion.Text = myProducto.DescripcionProducto
        End If
        uceTipoProducto.Items.Clear()
        uceTipoProducto.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetEntireTipoProducto().Rows
            uceTipoProducto.Items.Add(r.Item("idTipo"), r.Item("descripcionTipo"))
        Next
        uceTipoProducto.SelectedIndex = 0
    End Sub

    Private Sub SaveChanges()
        Dim req As New ProductoRequest
        Dim res As New ProductoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If String.Compare(uceTipoProducto.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Tipo de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewProducto Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CamionInfoToObject()
                req.myProductoItem = myProducto
                res = wsClnt.SaveProductoInfo(req)
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

    Private Sub CamionInfoToObject()
        If IsNewProducto Then
            myProducto.IdProducto = Guid.NewGuid
        End If
        myProducto.DescripcionProducto = txtDescripcion.Text
        myProducto.IdTipo = uceTipoProducto.Value
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

