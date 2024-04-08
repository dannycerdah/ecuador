Public Class FrmDetalleCliente
    Private NewReg As Boolean
    Private IdUsuario As String
    Private Cliente As New Server.Facturacion.Cliente
    Public Sub New(_NewReg As Boolean, _IdUsuario As String)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _IdUsuario
    End Sub
    Public Sub New(_NewReg As Boolean, _Cliente As Server.Facturacion.Cliente)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _Cliente.UsuarioIngreso
        With Cliente
            .idAgencia = _Cliente.idAgencia
            .idCliente = _Cliente.idCliente
            .Estado = _Cliente.Estado
        End With
    End Sub

    Private Sub FrmDetalleCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarCombo()
            If NewReg = False Then
                Dim index As Integer
                For r = 0 To uceAgenciaClient.Items.Count - 1
                    Dim a As Integer
                    a = 1
                    If uceAgenciaClient.Items.[All](r).DataValue = Cliente.idAgencia Then
                        uceAgenciaClient.SelectedIndex = r
                        uceAgenciaClient.Enabled = False
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarCombo()
        Try
            uceAgenciaClient.Items.Clear()
            uceAgenciaClient.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetAgencia.Rows
                uceAgenciaClient.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgenciaClient.SelectedIndex = 0
            uceEstado.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If uceAgenciaClient.Value <> Guid.Empty Then
                If NewReg = False And ((uceEstado.Value = "A" And Cliente.Estado = "A") Or (uceEstado.Value = "I" And Cliente.Estado = "I")) Then
                    MessageBox.Show("No se Puede Activar un cliente que ya se Encuentra Activo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim DatosCliente As New Server.Facturacion.Cliente
                    With DatosCliente
                        .idAgencia = uceAgenciaClient.Value
                        .UsuarioIngreso = IdUsuario
                        If NewReg = False Then
                            .Estado = uceEstado.Value
                        End If
                    End With
                    If CommonDataFact.MantClientes(DatosCliente) Then
                        MessageBox.Show("Cliente Ingresado o Actualizado  con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                End If
            Else
                MessageBox.Show("Debe se Seleccionar una Agencia", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class