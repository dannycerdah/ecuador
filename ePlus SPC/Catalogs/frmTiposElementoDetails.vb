Imports SPC.Server.ReportService
Public Class frmTiposElementoDetails
    Public Property myTipo As New TiposElementoItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewTipo As Boolean = False
    Dim dtMaterialElemento As DataTable

    Private Property IsNewElemento As Boolean = False

    Private Sub InitializeValues()
        myTipo.idTipo = Guid.Empty
        myTipo.descripcionTipo = ""
    End Sub

    Public Sub New(ByVal myTipoItem As TiposElementoItem)
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
        myTipo = CommonData.GetTipoElementoItem(TipoId)
    End Sub


    Private Sub frmTipoDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillTipoInfo()
    End Sub

    Private Sub FillTipoInfo()
        If Not IsNewTipo Then
            txtDescripcion.Text = myTipo.descripcionTipo
        End If
        llenarCombos()
    End Sub

    Private Sub SaveChanges()
        Dim req As New TiposElementoRequest
        Dim res As New TiposElementoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción del Tipo de Elemento.", "Descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtCodigo.Text = "" Then
                MessageBox.Show("Ingrese el Código del Tipo de Elemento.", "Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewTipo Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CodigoInfoToObject()
                req.myTiposElemento = myTipo
                res = wsClnt.SaveTipoElementoItem(req)
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

    Private Sub CodigoInfoToObject()
        If IsNewTipo Then
            myTipo.idTipo = Guid.NewGuid
        End If
        ' myTipo.estado = "A"
        myTipo.descripcionTipo = txtDescripcion.Text
        myTipo.codigo = txtCodigo.Text
        myTipo.materialPiso = ucePiso.Value
        myTipo.materialPared = ucePared.Value
        myTipo.materialTecho = uceTecho.Value
        ' myTipo.materialRed = uceRed.Value
        myTipo.materialPuerta = ucePuerta.Value
        ' myTipo.materialSeguros = uceSeguros.Value
        myTipo.ancho = txtAncho.Value
        myTipo.largo = txtLargo.Value
        myTipo.alto = txtAlto.Value
        myTipo.pesoReferencial = txtPesoRef.Value
        myTipo.pesoreal = txtPeso.Value

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


    Private Sub llenarCombos()
        dtMaterialElemento = CommonData.GetMaterialesCatalog

        ucePared.Items.Clear()
        ucePiso.Items.Clear()
        ucePuerta.Items.Clear()
        uceRed.Items.Clear()
        uceSeguros.Items.Clear()
        uceTecho.Items.Clear()
        For Each r As DataRow In dtMaterialElemento.Rows
            ucePared.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
            ucePiso.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
            ucePuerta.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
            uceRed.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
            uceSeguros.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
            uceTecho.Items.Add(r.Item("idMaterial"), r.Item("descripcion"))
        Next
        ucePared.SelectedIndex = 0
        ucePiso.SelectedIndex = 0
        ucePuerta.SelectedIndex = 0
        uceRed.SelectedIndex = 0
        uceSeguros.SelectedIndex = 0
        uceTecho.SelectedIndex = 0
    End Sub

End Class

