Imports SPC.Server.ReportService
Public Class frmDollyDetails
    Public Property myDolly As New DollyCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewDolly As Boolean = False
    Dim tipoAgencia As Guid = Guid.Parse("65ec9238-d302-49e9-bbb5-038e1caea03c")

    Private Sub InitializeValues()
        myDolly.Id = Guid.Empty
        myDolly.codigo = ""
        myDolly.IdAgencia = Guid.Empty
        myDolly.nombreAgencia = ""
        myDolly.estado = ""
    End Sub

    Public Sub New(ByVal myDollyItem As DollyCatalogItem)
        InitializeComponent()
        InitializeValues()
        myDolly = myDollyItem
    End Sub

    Public Sub New(MustCreateNewDolly As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()
        PopulateAgencia()
        myDolly.Id = Guid.NewGuid()
        IsNewDolly = True
    End Sub

    Public Sub New(ByVal DollyId As Guid)
        InitializeComponent()
        InitializeValues()
        myDolly = CommonData.GetDollyItem(DollyId)
    End Sub


    Private Sub frmDollyDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillDollyInfo()
    End Sub

    Private Sub FillDollyInfo()
        If Not IsNewDolly Then
            txtDescripcion.Text = myDolly.codigo
            uceEstado.Items.Clear()
            For Each r As DataRow In CommonData.GetEstado().Rows
                uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
            Next
            uceEstado.SelectedIndex = 0
            uceAgencia.Items.Clear()
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgencia.ToString).Rows
                uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgencia.SelectedIndex = 0
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New DollyRequest
        Dim res As New DollyResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese la descripcion del Dolly.", "Descripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceEstado.Text, "Escoja una Opción") = 0 Then
                MessageBox.Show("Escoja Estado del Dolly.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If IsNewDolly Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                DollyInfoToObject()
                req.myDollyCatItem = myDolly
                res = wsClnt.SaveDollyInfo(req)
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

    Private Sub DollyInfoToObject()
        If IsNewDolly Then
            myDolly.Id = Guid.NewGuid
        End If
        myDolly.codigo = txtDescripcion.Text
        myDolly.IdAgencia = uceAgencia.Value
        myDolly.estado = uceEstado.Value
    End Sub

    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        uceEstado.Items.Add(String.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
    End Sub

    Private Sub PopulateAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(String.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgencia.ToString).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia().SelectedIndex = 0
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

