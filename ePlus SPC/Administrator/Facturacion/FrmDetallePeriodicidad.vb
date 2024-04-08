Public Class FrmDetallePeriodicidad
    Private dtPeriodicidad As New DataTable("dtPeriodicidad")
    Private NewReg As Boolean
    Private IdUsuario As String
    Private Periodicidad As New Server.Facturacion.Periodicidad
    Public Sub New(_NewReg As Boolean, _IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _IdUsuario
    End Sub
    Public Sub New(_NewReg As Boolean, _Periodicidad As Server.Facturacion.Periodicidad)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewReg = _NewReg
        IdUsuario = _Periodicidad.UsuarioIngreso
        With Periodicidad
            .idPeriodicidad = _Periodicidad.idPeriodicidad
            .DescripcionPeriodicidad = _Periodicidad.DescripcionPeriodicidad
            .UsuarioIngreso = _Periodicidad.UsuarioIngreso
            .Estado = _Periodicidad.Estado
        End With
    End Sub
    Private Sub FrmDetallePeriodicidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If NewReg Then
                BtnAgregar.Visible = True
            Else
                btnUpdate.Visible = True
                ugvListPeriodicidad.Enabled = False
                txtPeriodicidad.Text = Periodicidad.DescripcionPeriodicidad
                txtPeriodicidad.Enabled = False
            End If
            With dtPeriodicidad.Columns
                .Add("DescripcionPeriodicidad", GetType(String))
                .Add("Estado", GetType(String))
            End With
            ugvListPeriodicidad.DataSource = dtPeriodicidad
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
        If dtPeriodicidad.Rows.Count > 0 Then
            For Each r As DataGridViewRow In dtPeriodicidad.Rows
                If r.Cells("DescripcionPeriodicidad").Value = txtPeriodicidad.Text Then
                    addRow = False
                    Exit For
                End If
            Next
        End If
        If addRow And NewReg Then
            Dim Periodicidad As New Server.Facturacion.Periodicidad
            row = dtPeriodicidad.NewRow
            row.Item("DescripcionPeriodicidad") = txtPeriodicidad.Text
            row.Item("Estado") = uceEstado.Value
            With Periodicidad
                .DescripcionPeriodicidad = txtPeriodicidad.Text
                .UsuarioIngreso = IdUsuario
            End With
            If CommonDataFact.MantPeriodicidad(Periodicidad) Then
                MessageBox.Show("Servicio Ingresado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtPeriodicidad.Rows.Add(row)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ugvListPeriodicidad_AfterRowsDeleted(sender As Object, e As EventArgs) Handles ugvListPeriodicidad.AfterRowsDeleted
        Periodicidad.Estado = "E"
        If CommonDataFact.MantPeriodicidad(Periodicidad) Then
            MessageBox.Show("Servicio Eliminado con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If NewReg = False And ((uceEstado.Value = "A" And Periodicidad.Estado = "A") Or (uceEstado.Value = "I" And Periodicidad.Estado = "I")) Then
            MessageBox.Show("No se Puede Activar un cliente que ya se Encuentra Activo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Periodicidad.Estado = uceEstado.Value
            If CommonDataFact.MantPeriodicidad(Periodicidad) Then
                MessageBox.Show("Servicio se Inactivo con Exito", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub ugvListPeriodicidad_AfterRowActivate(sender As Object, e As EventArgs) Handles ugvListPeriodicidad.AfterRowActivate
        With Periodicidad
            .DescripcionPeriodicidad = ugvListPeriodicidad.ActiveRow.Cells("DescripcionPeriodicidad").Value
            .UsuarioIngreso = IdUsuario
        End With
    End Sub

End Class