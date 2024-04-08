Public Class frmTarifasDetails
    Dim dtPreciosTarifas As New DataTable("preciosTarifas")

    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewTarifa As Boolean = False
    Dim idVuelos As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim idAgencia As Guid
    Dim estadoTarifa As String

    Private Sub InitializeValues()
        udtFecha.Value = DateTime.Now
    End Sub
    Private Sub PopulateAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(idVuelos).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia().SelectedIndex = 0
    End Sub
    Public Sub New(MustCreateNewTarifa As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateAgencia()
        PopulateEstado()
        IsNewTarifa = True
    End Sub
    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        uceEstado.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
    End Sub
    Public Sub New(ByVal TarifaId As Guid)
        InitializeComponent()
        InitializeValues()
        ObtenerPrecios(TarifaId)
        PopulateAgencia()
        For i As Integer = 0 To uceAgencia.Items.Count - 1
            uceAgencia.SelectedIndex = i
            If uceAgencia.Value.ToString = idAgencia.ToString Then
                Exit For
            End If
        Next
        PopulateEstado()
        For i As Integer = 0 To uceEstado.Items.Count - 1
            uceEstado.SelectedIndex = i
            If uceEstado.Value = estadoTarifa Then
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub
    Private Sub ObtenerPrecios(TarifaId As Guid)
        Try
            dtPreciosTarifas = CommonData.GetTarifaporId(TarifaId)
            For Each r As DataRow In dtPreciosTarifas.Rows
                idAgencia = r.Item("idAgencia")
                estadoTarifa = r.Item("estado")
                txtAgCarP.Text = r.Item("agenteCarTar")
                txtalmCP.Text = r.Item("almacenajeConTar")
                txtAlmCorrP.Text = r.Item("almacenajeCorTar")
                txtAlmCarP.Text = r.Item("almacenajeCarTar")
                txtDevCarP.Text = r.Item("devolucionCarTar")
                TxtCorVueP.Text = r.Item("correoTar")
                txtEstibaP.Text = r.Item("estibaDesTar")
                txtLimpiezaP.Text = r.Item("limpiezaEleTar")
                txtManipuleoP.Text = r.Item("manipuleoTar")
                txtMinMesP.Text = r.Item("minimoMesTar")
                txtMinVueP.Text = r.Item("minimoVueloTar")
                txtMontCarP.Text = r.Item("montaCargaTar")
                txtPreCoolP.Text = r.Item("precoolingTar")
                txtProCarP.Text = r.Item("procesamientoCarTar")
                txtProCarVolP.Text = r.Item("procesamientoCVTar")
                txtVariosP.Text = r.Item("variosTar")
                udtFecha.Value = r.Item("fechaTar")
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class