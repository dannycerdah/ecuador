
Imports System.Text.RegularExpressions
Imports SPC.Server.ReportService

Public Class frmDestinatarioContacts

    Public Property myDestinatario As New DestinatarioCatalog
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewDestinatario As Boolean = False
    Private Property idAgenciaDestinatario As Guid
    Private Property idReporteDestinatario As Integer
    Dim idTransportistas As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim ComboContacto = True

    Private Sub InitializeValues()
        myDestinatario.idDestinatario = Guid.Empty
        myDestinatario.idReporte = ""
        myDestinatario.mail = ""
        myDestinatario.estado = ""
        myDestinatario.idContacto = ""
        myDestinatario.idAgencia = Guid.Empty
    End Sub

    Public Sub New(ByVal myDestinatarioItem As DestinatarioCatalog)
        InitializeComponent()
        InitializeValues()
        myDestinatario = myDestinatarioItem
    End Sub

    Public Sub New(ByVal idAgencia As Guid, ByVal idReporte As Integer, MustCreateNewDestinatario As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()

        PopulateContacto()
        myDestinatario.idDestinatario = Guid.NewGuid()
        IsNewDestinatario = True
        idAgenciaDestinatario = idAgencia
        idReporteDestinatario = idReporte
        FillDestinatarioAgenciaReporte()
    End Sub
    Private Sub FillDestinatarioAgenciaReporte()
        PopulateAgencia()
        For i As Integer = 0 To uceAgencia.Items.Count - 1
            uceAgencia.SelectedIndex = i
            If uceAgencia.Value = idAgenciaDestinatario Then
                Exit For
            End If
        Next
        uceAgencia.Enabled = False
        uceReporte.Items.Add(0, "Escoja una Opcion")
        For Each r As DataRow In CommonData.GetResportes().Rows
            uceReporte.Items.Add(r.Item("idReporte"), r.Item("nombreReporte"))
        Next
        uceReporte.SelectedIndex = 0
        For i As Integer = 0 To uceReporte.Items.Count - 1
            uceReporte.SelectedIndex = i
            If uceReporte.Value = idReporteDestinatario Then
                Exit For
            End If
        Next
        uceReporte.Enabled = False
    End Sub
    Public Sub New(ByVal Id As Guid)
        InitializeComponent()
        InitializeValues()
        myDestinatario = CommonData.GetDestinatariosItemPorId(Id)
        'ini  jrodigue sprint01 24/04/2025 se corrigue bug existente
        idReporteDestinatario = myDestinatario.idReporte
        FillDestinatarioAgenciaReporte()
        'fin  jrodigue sprint01 24/04/2025
        'ugdDestinatarios.DataSource = CommonData.GetDestinatariosbyIdReporteyAgencia(destinatarioIdReporte, destinatarioIdAgencia)
    End Sub

    Private Sub frmDestinatarioDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillDestinatarioInfo()
    End Sub

    Private Sub FillDestinatarioInfo()
        Dim isSelectedContacto As Boolean = False
        If Not IsNewDestinatario Then
            'EDWIN LOPEZ 09/08/2016
            txtCorreo.Text = myDestinatario.mail
            PopulateContacto()
            ComboContacto = False
            For i As Integer = uceContacto.Items.Count - 1 To 0 Step -1 'Al reves, en caso de no encontrar queda en la primera posicion a elegir
                uceContacto.SelectedIndex = i
                If uceContacto.Value.ToString = myDestinatario.idContacto.ToString Then
                    'isSelectedContacto = True
                    Exit For
                End If
            Next
            ComboContacto = True
            ' If Not isSelectedContacto Then uceContacto.SelectedIndex = 0 'Vuelvo a la posicion 0
            '----------------------
            PopulateEstado()
            For i As Integer = 0 To uceEstado.Items.Count - 1
                uceEstado.SelectedIndex = i
                If uceEstado.Value = myDestinatario.estado Then
                    Exit For
                End If
            Next

            PopulateAgencia()
            For i As Integer = 0 To uceAgencia.Items.Count - 1
                uceAgencia.SelectedIndex = i
                If uceAgencia.Value = myDestinatario.idAgencia Then
                    Exit For
                End If
            Next
            uceAgencia.Enabled = False
            uceReporte.SelectedIndex = 0
            For i As Integer = 0 To uceReporte.Items.Count - 1
                uceReporte.SelectedIndex = i
                If uceReporte.Value = myDestinatario.idReporte Then
                    Exit For
                End If
            Next
            uceReporte.Enabled = False
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New DestinatarioRequest
        Dim res As New DestinatarioResponse
        Dim wsClnt As New ReportServiceSoapClient

        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            Dim msg1 As String = ""
            Dim boton As MessageBoxButtons = MessageBoxButtons.OK
            Dim respuesta As Integer = DialogResult.Yes


            If uceContacto.SelectedIndex = 0 Then
                MessageBox.Show("Escoja Contacto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If uceReporte.SelectedIndex = 0 Then
                MessageBox.Show("Escoja Reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.Compare(uceEstado.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Estado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If IsNewDestinatario Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DestinatarioInfoToObject()
                General.SetBARequest(req)
                req.myDestinatarioItem = myDestinatario
                res = wsClnt.SaveDestinatarioItem(req)
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

    Private Sub DestinatarioInfoToObject()
        If IsNewDestinatario Then
            myDestinatario.idDestinatario = New Guid
        End If
        myDestinatario.idReporte = uceReporte.Value
        myDestinatario.mail = txtCorreo.Text
        myDestinatario.estado = uceEstado.Value
        myDestinatario.idContacto = uceContacto.Value
        myDestinatario.idAgencia = uceAgencia.Value

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
        uceAgencia.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetAgencia().Rows
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

    Public Sub PopulateContacto()
        ComboContacto = False
        Dim dtContacto As DataTable = CommonData.GetEntireContactoCatalog()
        uceContacto.Items.Clear()
        uceContacto.Items.Add(Guid.Empty, "Seleccione contacto")
        For Each r As DataRow In dtContacto.Rows
            uceContacto.Items.Add(r.Item("idContacto"), r.Item("primerNombreContacto") & " " & r.Item("primerApellidoContacto") & " " & r.Item("segundoApellidoContacto")).Tag = r.Item("correo")
        Next
        ComboContacto = True
    End Sub

    Private Sub uceContacto_SelectionChanged(sender As Object, e As EventArgs) Handles uceContacto.SelectionChanged
        If ComboContacto Then
            If Not String.IsNullOrEmpty(uceContacto.SelectedItem.Tag) Then
                If String.IsNullOrEmpty(txtCorreo.Text) Then
                    txtCorreo.Text = uceContacto.SelectedItem.Tag
                Else
                    If MessageBox.Show("¿Desea actualizar el correo con el contacto " + uceContacto.SelectedItem.Tag + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        txtCorreo.Text = uceContacto.SelectedItem.Tag
                    End If
                End If
            End If
        End If
    End Sub
    'ini jrodigue sprint01 24/04/2025
    'se crea funcion de validacion de formato de correo
    Public Function EsCorreoValido(correo As String) As Boolean
        Dim patron As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Dim regex As New Regex(patron)
        Return regex.IsMatch(correo)
    End Function

    'Metodo que se ejecuta al valdiar el campo txtCorreo
    Private Sub txtCorreo_Validated(sender As Object, e As EventArgs) Handles txtCorreo.Validated
        If txtCorreo.Text IsNot Nothing And txtCorreo.Text.Length > 0 Then
            If EsCorreoValido(txtCorreo.Text) = False Then
                MessageBox.Show("Debe ingresar un correo valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCorreo.Select()
            End If
        End If
    End Sub
    'fin  jrodigue sprint01 24/04/2025
End Class