Imports SPC.Server.ReportService
Public Class frmCamionDetails
    Public Property myCamion As New CamionCatalogItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewCamion As Boolean = False
    Dim idTransportistas As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"

    Private Sub InitializeValues()
        myCamion.Id = Guid.Empty
        myCamion.Descripcion = ""
        myCamion.Matricula = ""
        myCamion.IdAgencia = Guid.Empty
        myCamion.nombreAgencia = ""
        myCamion.estado = ""
        myCamion.idContacto = ""
    End Sub

    Public Sub New(ByVal myCamionItem As CamionCatalogItem)
        InitializeComponent()
        InitializeValues()
        myCamion = myCamionItem
    End Sub

    Public Sub New(MustCreateNewCamion As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()
        PopulateAgencia()
        PopulateContacto()
        myCamion.Id = Guid.NewGuid()
        IsNewCamion = True
    End Sub

    Public Sub New(ByVal CamionId As Guid)
        InitializeComponent()
        InitializeValues()
        myCamion = CommonData.GetCamionItem(CamionId)
    End Sub

    Private Sub frmCamionDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillCamionInfo()
    End Sub

    Private Sub FillCamionInfo()
        Dim isSelectedContacto As Boolean = False
        If Not IsNewCamion Then
            'EDWIN LOPEZ 09/08/2016
            PopulateContacto()
            For i As Integer = uceContacto.Items.Count - 1 To 0 Step -1 'Al reves, en caso de no encontrar queda en la primera posicion a elegir
                uceContacto.SelectedIndex = i
                If uceContacto.Value.ToString = myCamion.idContacto.ToString Then
                    'isSelectedContacto = True
                    Exit For
                End If
            Next
            ' If Not isSelectedContacto Then uceContacto.SelectedIndex = 0 'Vuelvo a la posicion 0
            '----------------------

            txtDescripcion.Text = myCamion.Descripcion
            txtMatricula.Text = myCamion.Matricula
            uceEstado.Items.Clear()
            For Each r As DataRow In CommonData.GetEstado().Rows
                uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
            Next
            uceEstado.SelectedIndex = 0
            For i As Integer = 0 To uceEstado.Items.Count - 1
                uceEstado.SelectedIndex = i
                If uceEstado.Value = myCamion.estado Then
                    Exit For
                End If
            Next
            uceAgencia.Items.Clear()
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(idTransportistas).Rows
                uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgencia.SelectedIndex = 0
            For i As Integer = 0 To uceAgencia.Items.Count - 1
                uceAgencia.SelectedIndex = i
                If uceAgencia.Value = myCamion.IdAgencia Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New CamionRequest
        Dim res As New CamionResponse
        Dim wsClnt As New ReportServiceSoapClient

        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            'EWLM----------------------------
            ' If IsNewCamion Then
            Dim msg2 As String = validaMatricula()
            Dim msg1 As String = ""
            Dim boton As MessageBoxButtons = MessageBoxButtons.OK
            Dim respuesta As Integer = DialogResult.Yes

            Select Case msg2
                Case "1"
                    msg1 = "Matrícula ya se encuentra en otra agencia, desea continuar a guardar?"
                    boton = MessageBoxButtons.YesNo
                Case "2"
                    msg1 = "Se encuentra un error en la matrícula o base de datos, consulte a sistemas"
                Case "0"
                    msg1 = "Matrícula ya se encuentra en la presente agencia, favor seleccione pantalla previa"
            End Select

            If msg1 <> "" Then
                respuesta = MessageBox.Show(msg1, "Información", boton, MessageBoxIcon.Information)
            End If

            If respuesta <> DialogResult.Yes Then
                Exit Sub 'salida
            End If
            ' End If
            'EWLM 28072016-----------------------
            If uceContacto.Value = "" Then
                MessageBox.Show("Seleccione un Contacto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            ' ------------------------------------------------
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese la Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If String.Compare(uceEstado.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Estado del Camion.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewCamion Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                'CamionInfoToObject()
                req.myCamionCatItem = myCamion
                res = wsClnt.SaveCamionInfo(req)
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
        If IsNewCamion Then
            myCamion.Id = New Guid
        End If
        myCamion.Descripcion = txtDescripcion.Text
        myCamion.IdAgencia = uceAgencia.Value
        myCamion.Matricula = txtMatricula.Text
        myCamion.estado = uceEstado.Value
        myCamion.idContacto = uceContacto.Value
    End Sub

    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        uceEstado.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 0
    End Sub

    Private Sub PopulateAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(String.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(idTransportistas).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia().SelectedIndex = 0
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

    Private Sub txtMatricula_KeyUp(sender As Object, e As KeyEventArgs)
        Dim b As Boolean = False
        If b Then
            If txtDescripcion.Text = "" Then
                txtDescripcion.Text = txtMatricula.Text
            End If
        Else
            txtDescripcion.Text = txtMatricula.Text
        End If
    End Sub

    Private Function validaMatricula() As String 'EWLM CREADO 28072016
        Dim req2 As New CamionRequest
        Dim res2 As New ReportResponse
        Dim wsClnt2 As New ReportServiceSoapClient
        Dim Msg2 As String
        Dim Result As New DataTable("Camion")
        Msg2 = ""
        Try
            General.SetBARequest(req2)
            CamionInfoToObject()
            req2.myCamionCatItem = myCamion
            res2 = wsClnt2.CheckCamionMatricula(req2)
            If res2.ActionResult Then
                Result = res2.DsResult.Tables(0)
                For Each r As DataRow In Result.Rows() 'busco todos los camiones en caso que hayan varios errores antiguos
                    If myCamion.Id.ToString <> r.Item("IdCamion").ToString Then 'mientras no este actualizando el mismo camion
                        If myCamion.IdAgencia.ToString = r.Item("IdAgencia").ToString Then
                            Msg2 = "0"
                            Return Msg2
                            Exit Function 'prioridad salir si es duplicado
                        Else
                            Msg2 = "1"
                        End If
                    End If
                Next
            Else
                Throw New Exception(res2.ErrorMessage)
                Msg2 = "2"
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Msg2
    End Function
    Public Sub PopulateContacto()
        Dim dtContacto As DataTable = CommonData.GetEntireContactoCatalog()
        uceContacto.Items.Clear()
        uceContacto.Items.Add(Guid.Empty, "Escoja un contacto")
        For Each r As DataRow In dtContacto.Rows
            uceContacto.Items.Add(r.Item("idContacto"), r.Item("primerNombreContacto") & " " & r.Item("primerApellidoContacto") & " " & r.Item("segundoApellidoContacto"))
        Next
    End Sub
End Class

