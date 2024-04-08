Public Class frmMatConfiNotiTemp
    Public Property IdUsuario As String
    Dim tempProductoId As String
    Private DT_Produc_temp As New DataTable("DT_Produc_temp")
    Dim DatosNotificacion As New Server.ControlTemp.NotificacionTemp
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(Datos As Server.ControlTemp.NotificacionTemp)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        DatosNotificacion = Datos
        UltraLabel2.Visible = True
        uceEstado.Visible = True
        btnSave.Text = "Actualizar"
        ugdDetalleConfig.Enabled = False
        btnAgregar.Enabled = False
        CargaValoresActualizar()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub CargaValoresActualizar()
        tempProductoId = DatosNotificacion.idProducto.ToString
        txtProducto.Text = DatosNotificacion.UsuarioActualizacion 'Se pasa en este propiedad el nombre del producto
        MinTemp.Value = DatosNotificacion.temp_min
        MaxTemp.Value = DatosNotificacion.temp_max
        uceEstado.SelectedIndex = 0
    End Sub
    Private Sub frmMatConfiNotiTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DT_Produc_temp.Columns
            .Add("tempProductoId", GetType(String))
            .Add("Producto", GetType(String))
            .Add("temp_min", GetType(Double))
            .Add("temp_max", GetType(Double))
        End With
        ugdDetalleConfig.DataSource = DT_Produc_temp
        SetDisplayedColumns()
    End Sub
    Private Sub SetDisplayedColumns()
        Try
            ugdDetalleConfig.DisplayLayout.Bands(0).Columns("tempProductoId").Hidden = True
            ugdDetalleConfig.DisplayLayout.Bands(0).Columns("Producto").Header.Caption = "PRODUCTO"
            ugdDetalleConfig.DisplayLayout.Bands(0).Columns("temp_min").Header.Caption = "TEMP. MINIMA"
            ugdDetalleConfig.DisplayLayout.Bands(0).Columns("temp_max").Header.Caption = "TEMP. MAXIMA"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnConsProducto_Click(sender As Object, e As EventArgs) Handles btnConsProducto.Click
        Try
            Dim dtProducto As New DataTable("Producto")
            Dim frmConsultaProducto As New frmConsultaProducto
            frmConsultaProducto.ShowDialog()
            If frmConsultaProducto.dtProducto.Rows.Count > 0 Then
                If frmConsultaProducto.dtProducto.Rows(0).Item("idProducto") <> "" Then
                    dtProducto = frmConsultaProducto.dtProducto
                    agregarProducto(dtProducto)
                End If
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub agregarProducto(dtProducto As DataTable)
        tempProductoId = dtProducto.Rows(0).Item("idProducto")
        txtProducto.Text = dtProducto.Rows(0).Item("descripcionProducto")
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim AgregaReg As Boolean = True
        For Each r As DataRow In DT_Produc_temp.Rows
            If r.Item("tempProductoId").ToString = tempProductoId Then
                AgregaReg = False
            End If
        Next
        If AgregaReg And MaxTemp.Value > 0 And txtProducto.Text <> String.Empty And tempProductoId <> String.Empty Then
            Dim rows As DataRow = DT_Produc_temp.NewRow
            rows.Item("tempProductoId") = tempProductoId
            rows.Item("Producto") = txtProducto.Text
            rows.Item("temp_min") = MinTemp.Value
            rows.Item("temp_max") = MaxTemp.Value
            DT_Produc_temp.Rows.Add(rows)
            tempProductoId = String.Empty
            txtProducto.Text = String.Empty
            MinTemp.Value = 0
            MaxTemp.Value = 0
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim RegistraDatos As New Server.ControlTemp.NotificacionTemp
        If ugdDetalleConfig.Enabled Then
            For Each r As DataRow In DT_Produc_temp.Rows
                With RegistraDatos
                    .idProducto = Guid.Parse(r.Item("tempProductoId"))
                    .temp_max = r.Item("temp_max")
                    .temp_min = r.Item("temp_min")
                    .UsuarioIngreso = IdUsuario
                End With
                CommonData.MantNotificacionTemp(RegistraDatos)
            Next
            Me.Close()
        Else
            With RegistraDatos
                .id_notificacion_temp = DatosNotificacion.id_notificacion_temp
                .idProducto = Guid.Parse(tempProductoId)
                .temp_max = MaxTemp.Value
                .temp_min = MinTemp.Value
                .UsuarioIngreso = IdUsuario
                .Estado = uceEstado.Value
            End With
            If CommonData.MantNotificacionTemp(RegistraDatos) Then
                MessageBox.Show("Registro Actualizado con Exito")
                Me.Close()
            End If
        End If
    End Sub
End Class