Public Class FrmDetalleServicio
    Private dtServiciosGA As New DataTable("dtServiciosGA")
    Private NewReg As Boolean
    Private IdUsuario As String
    Private ServiciosGA As New Server.Facturacion.ServiciosGA
    Public Sub New(_NewReg As Boolean, _IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _IdUsuario
    End Sub
    Public Sub New(_NewReg As Boolean, _ServiciosGA As Server.Facturacion.ServiciosGA)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _ServiciosGA.UsuarioIngreso
        With ServiciosGA
            .idServiciosGA = _ServiciosGA.idServiciosGA
            .DescripcionServicio = _ServiciosGA.DescripcionServicio
            .UsuarioIngreso = _ServiciosGA.UsuarioIngreso
            .Estado = _ServiciosGA.Estado
        End With
    End Sub
    Private Sub FrmDetalleServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If NewReg Then
                BtnAgregar.Visible = True
            Else
                btnUpdate.Visible = True
                ugvListServicios.Enabled = False
                txtServicio.Text = ServiciosGA.DescripcionServicio
                txtServicio.Enabled = False
            End If
            With dtServiciosGA.Columns
                .Add("DescripcionServicio", GetType(String))
                .Add("Estado", GetType(String))
                .Add("Tipo", GetType(String))
            End With
            ugvListServicios.DataSource = dtServiciosGA
            uceEstado.SelectedIndex = 0
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        If dtServiciosGA.Rows.Count > 0 Then
            For Each r As DataGridViewRow In dtServiciosGA.Rows
                If r.Cells("DescripcionServicio").Value = txtServicio.Text Then
                    addRow = False
                    Exit For
                End If
            Next
        End If
        If addRow And NewReg Then
            Dim ServiciosGA As New Server.Facturacion.ServiciosGA
            row = dtServiciosGA.NewRow
            row.Item("DescripcionServicio") = txtServicio.Text
            row.Item("Estado") = uceEstado.Value
            row.Item("Tipo") = uceTipo.Value
            With ServiciosGA
                .DescripcionServicio = txtServicio.Text
                .UsuarioIngreso = IdUsuario
                .Tipo = uceTipo.Value
            End With
            If CommonDataFact.MantServiciosGA(ServiciosGA) Then
                MessageBox.Show("Servicio Ingresado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtServiciosGA.Rows.Add(row)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ugvListServicios_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvListServicios.AfterRowsDeleted
        ServiciosGA.Estado = "E"
        If CommonDataFact.MantServiciosGA(ServiciosGA) Then
            MessageBox.Show("Servicio Eliminado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If NewReg = False And ((uceEstado.Value = "A" And ServiciosGA.Estado = "A") Or (uceEstado.Value = "I" And ServiciosGA.Estado = "I")) Then
            MessageBox.Show("No se Puede actualizar al cliente a un estado que ya se encontraba", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ServiciosGA.Estado = uceEstado.Value
            If CommonDataFact.MantServiciosGA(ServiciosGA) Then
                MessageBox.Show("Servicio se Inactivo con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub ugvListServicios_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvListServicios.AfterRowActivate
        With ServiciosGA
            .DescripcionServicio = ugvListServicios.ActiveRow.Cells("DescripcionServicio").Value
            .UsuarioIngreso = IdUsuario
            .Tipo = uceTipo.Value
        End With
    End Sub
End Class