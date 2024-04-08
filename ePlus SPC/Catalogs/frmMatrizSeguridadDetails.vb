Imports SPC.Server.ReportService
Public Class frmMatrizSeguridadDetails
    Public Property myMatrizSeguridad As New MatrizSeguridadItem
    Public Property myDetalleMatrizSeguridad As New DetalleMatrizSeguridadItem
    Private Property IsNewMatrizSeguridad As Boolean = False
    Dim dte As New DataTable("MatrizSeguridad")

    Private Sub InitializeValues()
        myMatrizSeguridad.Id = Guid.Empty
        myMatrizSeguridad.FechaCreacion = Date.Now
        myMatrizSeguridad.UsuarioCreacion = ""
        myMatrizSeguridad.Descripcion = ""
        myDetalleMatrizSeguridad.IdMatriz = myMatrizSeguridad.Id
        myDetalleMatrizSeguridad.IdTipoAgencia = Guid.Empty
        myDetalleMatrizSeguridad.CargoPersonal = ""
        myDetalleMatrizSeguridad.CantidadPersonal = 0
    End Sub

    'Private Sub SetDisplayedColumns()
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("idMatriz").Hidden = True
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("fechaCreacion").Hidden = True
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("usuarioCreacion").Hidden = True
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("descripcion").Hidden = True
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("tipoAgenciaRequerida").Hidden = True
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Tipo Agencia"
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("cargoPersonal").Header.Caption = "Cargo Personal"
    '    ugdMatrizSeguridad.DisplayLayout.Bands(0).Columns("cantidadPersonal").Header.Caption = "Cantidad Personal"
    'End Sub

    Public Sub RefreshData()
        ugdDetalleMatriz.DataSource = CommonData.GetMatrizSeguridadItemById(myMatrizSeguridad.Id)
        PopulateAndBindDropDown()
    End Sub

    Public Sub New(ByVal myMatrizSeguridadItem As MatrizSeguridadItem)
        InitializeComponent()
        InitializeValues()
        myMatrizSeguridad = myMatrizSeguridadItem
    End Sub

    Public Sub New(MustCreateNewMatrizSeguridad As Boolean)
        InitializeComponent()
        InitializeValues()
        cargarComboTipoAgencia()
        cargarColumnasDte()
        myMatrizSeguridad.Id = Guid.NewGuid()
        IsNewMatrizSeguridad = True
        ugdDetalleMatriz.DataSource = dte
    End Sub

    Public Sub New(ByVal MatrizSeguridadId As Guid, ByVal desc As String)
        InitializeComponent()
        InitializeValues()
        cargarComboTipoAgencia()
        cargarColumnasDte()
        myMatrizSeguridad.Id = MatrizSeguridadId
        myMatrizSeguridad.Descripcion = desc
        ugdDetalleMatriz.DataSource = CommonData.GetMatrizSeguridadItemById(myMatrizSeguridad.Id)
    End Sub

    Private Sub FillInfo()
        SetInitialDataAndLayout()
        If Not IsNewMatrizSeguridad Then
            txtDescription.Text = myMatrizSeguridad.Descripcion
        End If
    End Sub

    Private Sub SetInitialDataAndLayout()
        PopulateAndBindDropDown()
    End Sub

    Private Sub frmMatrizSeguridadDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsNewMatrizSeguridad Then
            uceTipoAgencia.Enabled = False
            txtCantidad.Enabled = False
            txtCargo.Enabled = False
        End If
        FillInfo()
    End Sub

    Private Sub cargarComboTipoAgencia()
        uceTipoAgencia.Items.Clear()
        uceTipoAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetTipoAgencia.Rows
            uceTipoAgencia.Items.Add(r.Item("idTipo"), r.Item("descripcionTipo"))
        Next
        uceTipoAgencia.SelectedIndex = 0
    End Sub

    Private Sub cargarColumnasDte()
        With dte.Columns
            .Add("idMatriz", GetType(Guid))
            .Add("tipoAgenciaRequerida", GetType(Guid))
            .Add("descripcionTipo", GetType(String))
            .Add("cargoPersonal", GetType(String))
            .Add("cantidadPersonal", GetType(String))
        End With
    End Sub

    Private Function ValidateDetailsId(idTipo As Guid, cargoPersonal As String) As Boolean
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDetalleMatriz.Rows
            If r.Cells("idTipo").Value = idTipo And r.Cells("cargoPersonal").Value = cargoPersonal Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidateDetailsIdNewRow(idTipo As Guid, cargoPersonal As String) As Boolean
        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDetalleMatriz.Rows
            If Not r.IsAddRow And (r.Cells("idTipo").Value = idTipo And r.Cells("cargoPersonal").Value = cargoPersonal) Then
                Return False
            End If
        Next
        Return True
    End Function



    Private Sub PopulateAndBindDropDown()
        Try
            ugdDetalleMatriz.DisplayLayout.Bands(0).Columns("idMatriz").Hidden = True
            ugdDetalleMatriz.DisplayLayout.Bands(0).Columns("tipoAgenciaRequerida").Hidden = True
            ugdDetalleMatriz.DisplayLayout.Bands(0).Columns("descripcionTipo").Header.Caption = "Agencia"
            ugdDetalleMatriz.DisplayLayout.Bands(0).Columns("cargoPersonal").Header.Caption = "Cargo Personal"
            ugdDetalleMatriz.DisplayLayout.Bands(0).Columns("cantidadPersonal").Header.Caption = "Cantidad Personal"
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ugdMatrizSeguridad_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Back Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDetalleMatriz.Selected.Rows
                r.Delete()
            Next
        End If
    End Sub

    Private Sub txtDescription_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDescription.KeyUp
            If txtDescription.Text = "" Then
            'MessageBox.Show("Debe escribir un nombre para la Matriz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            uceTipoAgencia.Enabled = False
            txtCantidad.Enabled = False
            txtCargo.Enabled = False
            Else
            uceTipoAgencia.Enabled = True
            txtCantidad.Enabled = True
            txtCargo.Enabled = True
            End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If String.Compare(uceTipoAgencia.Text, "Escoja una Opción") = 0 Then
            MessageBox.Show("Escoja un Tipo de Agencia.", "Tipo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtCantidad.Text = "" Or txtCargo.Text = "" Then
            MessageBox.Show("Debe llenar todos los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim nwRow1 As DataRow
        Try
            nwRow1 = dte.NewRow
            nwRow1.Item("tipoAgenciaRequerida") = uceTipoAgencia.Value
            nwRow1.Item("descripcionTipo") = uceTipoAgencia.Text
            nwRow1.Item("cargoPersonal") = txtCargo.Text
            nwRow1.Item("cantidadPersonal") = txtCantidad.Text
            dte.Rows.Add(nwRow1)
            ugdDetalleMatriz.DataSource = dte
            uceTipoAgencia.SelectedIndex = 0
            txtCantidad.Clear()
            txtCargo.Clear()
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub SaveChanges()
        Dim req As New MatrizSeguridadRequest
        Dim req2 As New MatrizSeguridadRequest
        Dim res As New MatrizSeguridadResponse
        Dim res2 As New MatrizSeguridadResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If IsNewMatrizSeguridad Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                MatrizInfoToObject()
                req.myMatrizSeguridadItem = myMatrizSeguridad
                res = wsClnt.SaveMatrizSeguridadItem(req)
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdDetalleMatriz.Rows
                    myDetalleMatrizSeguridad.IdMatriz = myMatrizSeguridad.Id
                    myDetalleMatrizSeguridad.IdTipoAgencia = r.Cells("tipoAgenciaRequerida").Value
                    myDetalleMatrizSeguridad.CargoPersonal = r.Cells("cargoPersonal").Value
                    myDetalleMatrizSeguridad.CantidadPersonal = r.Cells("cantidadPersonal").Value
                    req2.myDetalleMatrizSeguridadItem = myDetalleMatrizSeguridad
                    res2 = wsClnt.SaveDetalleMatrizSeguridadItem(req2)
                Next
                If res.ActionResult And res2.ActionResult Then
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

    Private Sub SaveChangesDetalleMatriz()
        Dim req As New MatrizSeguridadRequest
        Dim res As New MatrizSeguridadResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try
            If IsNewMatrizSeguridad Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                MatrizInfoToObject()
                req.myDetalleMatrizSeguridadItem = myDetalleMatrizSeguridad
                res = wsClnt.SaveMatrizSeguridadItem(req)
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

    Private Sub MatrizInfoToObject()
        If IsNewMatrizSeguridad Then
            myMatrizSeguridad.Id = Guid.NewGuid
        End If
        myMatrizSeguridad.FechaCreacion = Date.Now
        myMatrizSeguridad.UsuarioCreacion = "ADMIN"
        myMatrizSeguridad.Descripcion = txtDescription.Text
    End Sub


End Class