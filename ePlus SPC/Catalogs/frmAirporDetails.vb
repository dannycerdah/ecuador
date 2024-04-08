Imports SPC.Server.ReportService
Public Class frmAirporDetails
    Public Property myAirport As New AirportCatalogItem
    Private Property blnDetailsEditingMode As Boolean = False
    Private Property IsNewAirport As Boolean = False

    Private Sub InitializeValues()
        myAirport.Id = Guid.Empty
        myAirport.IdCiudad = Guid.Empty
        myAirport.Nombre = ""
        myAirport.Direccion = ""
        myAirport.Observacion = ""
    End Sub

    Public Sub New(ByVal myAirportItem As AirportCatalogItem)
        InitializeComponent()
        InitializeValues()
        myAirport = myAirportItem
    End Sub

    Public Sub New(MustCreateNewAirport As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulatePais()
        myAirport.Id = Guid.NewGuid()
        IsNewAirport = True
    End Sub

    Public Sub New(ByVal AirportId As Guid)
        InitializeComponent()
        InitializeValues()
        myAirport = CommonData.GetAirportItem(AirportId)
    End Sub


    Private Sub frmAirportDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillAirportInfo()
    End Sub

    Private Sub FillAirportInfo()
        Dim idPais As Guid = Guid.Empty
        If Not IsNewAirport Then
            txtNombre.Text = myAirport.Nombre
            txtDireccion.Text = myAirport.Direccion
            txtObs.Text = myAirport.Observacion
            ucePais.Items.Clear()
            ucePais.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetPais().Rows
                ucePais.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
            Next
            ucePais.SelectedIndex = 0
            For i As Integer = 0 To ucePais.Items.Count - 1
                ucePais.SelectedIndex = i
                If ucePais.Value = myAirport.idPais Then
                    Exit For
                End If
            Next
            uceCiudad.Items.Clear()
            uceCiudad.Items.Add(Guid.Empty, "Escoja una opción")
            For Each r As DataRow In CommonData.GetCiudad(ucePais.Value.ToString).Rows
                uceCiudad.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
            Next
            For i As Integer = 0 To uceCiudad.Items.Count - 1
                uceCiudad.SelectedIndex = i
                If uceCiudad.Value = myAirport.IdCiudad Then
                    Exit For
                End If
            Next
            txtTelefono.Text = myAirport.Telefono
            txtPaginaWeb.Text = myAirport.PaginaWeb
            txtCodigoIATA.Text = myAirport.CodigoIATA
            txtCodigoOACI.Text = myAirport.CodigoOACI
            uneTerminales.Value = myAirport.NumeroTerminales
            txtLatitud.Text = myAirport.Latitud
            txtLongitud.Text = myAirport.Longitud
            If txtPaginaWeb.Text = "" Or txtPaginaWeb.Text = "ND" Then
                txtPaginaWeb.Text = txtNombre.Text
            End If
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New Server.ReportService.AirportRequest
        Dim res As New Server.ReportService.AirportResponse
        Dim wsClnt As New Server.ReportService.ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtNombre.Text = "" Then
                MessageBox.Show("Ingrese Nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(ucePais.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja País", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If String.Compare(uceCiudad.Text, "Escoja una opción") = 0 Then
                MessageBox.Show("Escoja Ciudad", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If IsNewAirport Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                AirportInfoToObject()
                req.myAirportCatItem = myAirport
                res = wsClnt.SaveAirportInfo(req)
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

   
    Private Sub AirportInfoToObject()
        If IsNewAirport Then
            myAirport.Id = New Guid
        End If
        myAirport.idPais = ucePais.Value
        myAirport.IdCiudad = uceCiudad.Value
        myAirport.Nombre = txtNombre.Text
        myAirport.Direccion = txtDireccion.Text
        myAirport.Observacion = txtObs.Text
        myAirport.CodigoIATA = txtCodigoIATA.Text
        myAirport.CodigoOACI = txtCodigoOACI.Text
        myAirport.PaginaWeb = txtPaginaWeb.Text
        myAirport.Telefono = txtTelefono.Text
        myAirport.NumeroTerminales = uneTerminales.Value
        myAirport.Longitud = txtLongitud.Text
        myAirport.Latitud = txtLatitud.Text
    End Sub

    Private Sub PopulatePais()
        ucePais.Items.Clear()
        ucePais.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetPais().Rows
            ucePais.Items.Add(r.Item("idPais"), r.Item("NombrePais"))
        Next
        ucePais.SelectedIndex = 0
    End Sub

    Private Sub PopulateCiudad()
        uceCiudad.Items.Clear()
        uceCiudad.Items.Add(Guid.Empty, "Escoja una opción")
        For Each r As DataRow In CommonData.GetCiudad(ucePais.Value.ToString).Rows
            uceCiudad.Items.Add(r.Item("idCiudad"), r.Item("nombreCiudad"))
        Next
        uceCiudad.SelectedIndex = 0
    End Sub

    Private Sub ucePais_ValueChanged(sender As Object, e As EventArgs) Handles ucePais.SelectionChanged
        If IsNewAirport Then
            PopulateCiudad()
        End If
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

    Private Sub txtLongitud_TextChanged(sender As Object, e As EventArgs) Handles txtLongitud.TextChanged
        Try
            Dim urlMaps As String = String.Empty
            urlMaps = "<HTML><BODY> "
            urlMaps += "<iframe name=" & Chr(34) & "fMain" & Chr(34) & " "
            urlMaps += "width=" & Chr(34) & "525" & Chr(34) & "Height =" & Chr(34) & "275" & Chr(34) & "frameborder=" & Chr(34) & "0" & Chr(34) & "style=" & Chr(34) & "border:0" & Chr(34) & " "
            urlMaps += "src=" & Chr(34) & "https://www.google.com/maps/embed/v1/search?key=AIzaSyDzjsHdJTnuDz1i0OSxFuqOLDgRN4chmt4&q=" & txtLatitud.Text & "," & txtLongitud.Text & Chr(34) & "> "
            urlMaps += "</iframe></BODY></HTML>"

            wbMaps.DocumentText = urlMaps
            Dim ele As HtmlElement = wbMaps.Document.GetElementFromPoint(MousePosition)
            ele.InvokeMember("click")

            wbMaps.Refresh()
        Catch ex As Exception

        End Try

    End Sub

   

    Private Sub btnWeb_Click(sender As Object, e As EventArgs) Handles btnWeb.Click
        Dim proceso As New System.Diagnostics.Process
        With proceso
            .StartInfo.FileName = "https://www.google.com.ec/search?ie=utf-8&btnI=&q=" & txtNombre.Text
            .Start()
        End With
    End Sub
End Class