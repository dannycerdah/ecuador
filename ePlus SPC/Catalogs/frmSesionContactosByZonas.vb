Imports SPC.Server.MarkingService
<System.Runtime.InteropServices.GuidAttribute("7FAF6BA2-37EA-404A-B3CF-339E6ECBB9E5")> Public Class frmSesionContactosByZonas
    Public Property IsReportSesion As Boolean = False
    Public Property IsReportLogSesion As Boolean = False
    Dim CabeceraMarcaciones As CabeceraMarcaciones
    Dim Detallemarcaciones As New DetalleMarcaciones
    Private _Usuario As String
    Public Sub DataContactoZonasSession(ByVal idAgencia, ByVal idContacto, ByVal fechaInicio, ByVal fechaFinal)
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New ContactoZonasSessionRequest
        Dim res As New ContactoZonasSessionResponse
        Dim res1 As New ContactoZonasSessionResponse
        Dim dtContactoZonasSession As New ContactoZonasSessionItem
        Dim nr As DataRow
        Dim TablaTotal As New DataTable("TablaTotal")
        Dim Ejecuion As Integer = 2
        Dim FinalEjecion As Integer = 0
        Dim ExiteData As Integer = 0
        Dim tipoReporte As Boolean
        TablaTotal.Rows.Clear()
        While Ejecuion > FinalEjecion
            If FinalEjecion = 0 Then
                tipoReporte = True
            Else
                tipoReporte = False
            End If
             With dtContactoZonasSession
                .IdAgencia = idAgencia
                .IdContacto = idContacto
                .FechaInicio = fechaInicio
                .FechaFinal = fechaFinal
                .TipoReporte = tipoReporte
            End With
            Try
                General.SetBARequest(req)
                req.myContactoZonasSession = dtContactoZonasSession
                If FinalEjecion = 0 Then
                    res = wsClient.GetContactoZonasSession(req)
                Else
                    res1 = wsClient.GetLogContactoZonasSession(req)
                End If
               Catch ex As Exception
                ErrorManager.SetLogEvent(ex, res, req)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            FinalEjecion = FinalEjecion + 1
        End While

        If res.ActionResult Then
            ExiteData = ExiteData + 1
            With TablaTotal.Columns
                .Add("descripcionAgencia", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("tagsaContacto", GetType(String))
                .Add("NombreContacto", GetType(String))
                .Add("NombreZona", GetType(String))
                .Add("FechaHoraIngreso", GetType(String))
                .Add("FechaHoraSalida", GetType(String))
            End With
            For i = 0 To res.DsResult.Tables(0).Rows.Count - 1
                With TablaTotal.Columns
                    nr = TablaTotal.NewRow
                    nr.Item("descripcionAgencia") = res.DsResult.Tables(0).Rows(i).Item("descripcionAgencia").ToString
                    nr.Item("idContacto") = res.DsResult.Tables(0).Rows(i).Item("idContacto").ToString
                    nr.Item("tagsaContacto") = res.DsResult.Tables(0).Rows(i).Item("tagsaContacto").ToString
                    nr.Item("NombreContacto") = res.DsResult.Tables(0).Rows(i).Item("NombreContacto").ToString
                    nr.Item("NombreZona") = res.DsResult.Tables(0).Rows(i).Item("NombreZona").ToString
                    nr.Item("FechaHoraIngreso") = res.DsResult.Tables(0).Rows(i).Item("FechaHoraIngreso").ToString
                    nr.Item("FechaHoraSalida") = ""
                    TablaTotal.Rows.Add(nr)
                End With
            Next
        End If
        If res1.ActionResult Then
            For i = 0 To res1.DsResult.Tables(0).Rows.Count - 1
                With TablaTotal.Columns
                    nr = TablaTotal.NewRow
                    nr.Item("descripcionAgencia") = res1.DsResult.Tables(0).Rows(i).Item("descripcionAgencia").ToString
                    nr.Item("idContacto") = res1.DsResult.Tables(0).Rows(i).Item("idContacto").ToString
                    nr.Item("tagsaContacto") = res1.DsResult.Tables(0).Rows(i).Item("tagsaContacto").ToString
                    nr.Item("NombreContacto") = res1.DsResult.Tables(0).Rows(i).Item("NombreContacto").ToString
                    nr.Item("NombreZona") = res1.DsResult.Tables(0).Rows(i).Item("NombreZona").ToString
                    nr.Item("FechaHoraIngreso") = res1.DsResult.Tables(0).Rows(i).Item("FechaHoraIngreso").ToString
                    nr.Item("FechaHoraSalida") = res1.DsResult.Tables(0).Rows(i).Item("FechaHoraSalida").ToString
                    TablaTotal.Rows.Add(nr)
                End With
            Next
        End If
        If ExiteData > 0 Then
            ugdSesionContactosByZonas.DataSource = TablaTotal
            SetDisplayedColumns()
        Else

            MessageBox.Show("No existen registros con búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Configuración inicial para filtrar información_MARZ - 26-07-2017
    Public Sub ConfigurationInicial()
        ugdSesionContactosByZonas.DataSource = Nothing 'Limpiar tabla
        cmbAgencias.Clear()
        Dim dtAgencia As DataTable = CommonData.GetAgenciaCatalog()
        'cmbAgencias.Items.Add(Guid.Empty, "Todas las agencias")
        cmbAgencias.Items.Add(Guid.Empty, "Todas las Compañias")
        For Each r As DataRow In dtAgencia.Rows
            cmbAgencias.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        cmbAgencias.SelectedIndex = 0
        'If IsReportSesion Then
        '    'Se comenta esta linea de codigo debido a que tanto reporte por zona y como historial deben de ser filtrados por Agencia
        '    'cmbAgencias.Enabled = True
        '    'Agencias - (Reporte de zonas)
        '    'cmbAgencias.Enabled = True
        '    'Dim dtAgencia As DataTable = CommonData.GetAgenciaCatalog()
        '    'cmbAgencias.Items.Add(Guid.Empty, "Todas las agencias")
        '    'For Each r As DataRow In dtAgencia.Rows
        '    '    cmbAgencias.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        '    'Next
        '    'Se inactivan los txt de las fechas debido a que por zona no se debe de seleccionar 
        '    udtInicio.Enabled = False
        '    udtFinal.Enabled = False
        '    'cmbAgencias.SelectedIndex = 0
        'Else
        'udtInicio.Enabled = True
        'udtFinal.Enabled = True
        'cmbAgencias.Clear()
        'cmbAgencias.Enabled = False
        txtContacto.Focus()
        'End If
    End Sub


    Private Sub SetDisplayedColumns()
        Dim lb_visible As Boolean
        Try
            'MARZ
            'Se comenta If debido que se buscar tambien por descripcion agencia tanto por zona como historial
            'If IsReportSesion Then
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("tagsaContacto").Header.Caption = "No. Tagsa"
            'End If
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True 'Mostrar detalles de contacto
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("idContacto").Header.Caption = "Cedula"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("direccion").Header.Caption = "direccion"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("telefono").Header.Caption = "telefono"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Header.Caption = "fechaNacimientoContacto"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Format = "dd/MM/yyyy"
            If UltraCheckDetalle.CheckedValue Then
                lb_visible = False
            Else
                lb_visible = True
            End If
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("idContacto").Hidden = lb_visible
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("direccion").Hidden = lb_visible
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("telefono").Hidden = lb_visible
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("fechaNacimientoContacto").Hidden = lb_visible

            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("NombreContacto").Header.Caption = "Contacto"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("NombreZona").Header.Caption = "Zona"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaHoraIngreso").Header.Caption = "Fecha y Hora de Ingreso"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaHoraIngreso").Format = "dd/MM/yyyy HH:mm:ss"
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("HoraIngreso").Header.Caption = "Hora de Ingreso"
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("HoraIngreso").Format = "HH:mm:ss"
            'If IsReportLogSesion Then
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaSalida").Header.Caption = "Fecha de Salida"
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaSalida").Format = "dd/MM/yyyy"
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("HoraSalida").Header.Caption = "Hora de Salida"
            'ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("HoraSalida").Format = "HH:mm:ss"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaHoraSalida").Header.Caption = "Fecha y Hora de Salida"
            ugdSesionContactosByZonas.DisplayLayout.Bands(0).Columns("FechaHoraSalida").Format = "dd/MM/yyyy HH:mm:ss"
            'End If
        Catch ex As Exception
        End Try
    End Sub
    'MARZ
    Private Sub btnConsultarCZ_Click(sender As Object, e As EventArgs) Handles btnConsultarCZ.Click
        Dim fechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim fechaFinal As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim CompracionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFinal.Value)
        Dim CompracionHora As Integer = DateTime.Compare(DateTimeHoraInicio.Text, DateTimeHoraFin.Text)
        If CompracionFecha <= 0 Then
            If CompracionHora > 0 And CompracionFecha = 0 Then
                MessageBox.Show("La hora fin no puede ser menor a la hora inicio")
            Else
                If DateTimeHoraInicio.Text = DateTimeHoraFin.Text And CompracionFecha = 0 Then
                    fechaFinal = Date.Now()
                End If
                DataContactoZonasSession(cmbAgencias.Value, txtContacto.Text, fechaInicio, fechaFinal)
                txtContacto.Focus()
            End If
        ElseIf CompracionFecha > 0 Then
            MessageBox.Show("La Fecha fin no puede ser menor a la Fecha inicio")
        End If
        'If Not IsDate(fechaInicio) Or fechaInicio = Nothing Then 'Validar fecha inicial
        '    MessageBox.Show("Fecha inválida o vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        '    If fechaFinal = Nothing Then 'Busqueda un soló día
        '        fechaFinal = fechaInicio
        '    End If
        '    DataContactoZonasSession(cmbAgencias.Value, txtContacto.Text, fechaInicio, fechaFinal)
        '    txtContacto.Focus()
        'End If

    End Sub

    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtContacto.ValueChanged
        If txtContacto.Text.Length >= 3 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdSesionContactosByZonas.Rows
                If InStr(r.Cells("NombreContacto").Value, txtContacto.Text) <> 0 Or InStr(r.Cells("idContacto").Value, txtContacto.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdSesionContactosByZonas.Rows
                r.Hidden = False
            Next
        End If
    End Sub


    Private Sub UltraBtnExportExcel_Click(sender As Object, e As EventArgs) Handles UltraBtnExportExcel.Click
        Dim CompracionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFinal.Value)
        Dim CompracionHora As Integer = DateTime.Compare(DateTimeHoraInicio.Text, DateTimeHoraFin.Text)
        Dim wsClient As New MarkingServiceSoapClient
        Dim req As New ContactoZonasSessionRequest
        Dim res As New ContactoZonasSessionResponse
        Dim CabeceraMarcaciones = New CabeceraMarcaciones
        Dim dtContactoZonasSession As New ContactoZonasSessionItem
        Dim comparacionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFinal.Value)
        Dim ExiteData As Integer = 0
        Dim FinalEjecion As Integer = 0
        Dim Ejecuion As Integer = 2
        Dim tipoReporte As Boolean
        Dim FechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim FechaFin As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim frm As New rptSesionesMarcaciones()
        frm.FechaInicio = FechaInicio
        frm.FechaFin = FechaFin
        frm.Usuario = _Usuario
        frm.Segmento = cmbAgencias.Text
        Try
            If CompracionFecha <= 0 Then
                If CompracionHora > 0 And CompracionFecha = 0 Then
                    MessageBox.Show("La hora fin no puede ser menor a la hora inicio")
                Else
                    While Ejecuion > FinalEjecion
                        If FinalEjecion = 0 Then
                            tipoReporte = True
                        Else
                            tipoReporte = False
                        End If
                        With dtContactoZonasSession
                            .IdAgencia = cmbAgencias.Value
                            .IdContacto = txtContacto.Text
                            If DateTimeHoraInicio.Text = DateTimeHoraFin.Text And CompracionFecha = 0 Then
                                .FechaFinal = Date.Now()
                                frm.FechaFin = Date.Now()
                            Else
                                .FechaFinal = FechaFin
                            End If
                            .FechaInicio = FechaInicio
                            .TipoReporte = tipoReporte
                        End With
                        General.SetBARequest(req)
                        req.myContactoZonasSession = dtContactoZonasSession
                        res = wsClient.GetContactoZonasSession(req)
                        If res.ActionResult Then
                            ExiteData = ExiteData + 1
                            For i = 0 To res.DsResult.Tables(0).Rows.Count - 1
                                Detallemarcaciones = New DetalleMarcaciones
                                With Detallemarcaciones
                                    .Agencia = res.DsResult.Tables(0).Rows(i).Item("descripcionAgencia").ToString
                                    .contacto = res.DsResult.Tables(0).Rows(i).Item("idContacto").ToString
                                    .NoTagsa = res.DsResult.Tables(0).Rows(i).Item("tagsaContacto").ToString
                                    .NombresApellidos = res.DsResult.Tables(0).Rows(i).Item("NombreContacto").ToString
                                    .Zona = res.DsResult.Tables(0).Rows(i).Item("NombreZona").ToString
                                    .FechaHoraIngreso = res.DsResult.Tables(0).Rows(i).Item("FechaHoraIngreso")
                                    If FinalEjecion > 0 Then
                                        .FechaHoraSalida = res.DsResult.Tables(0).Rows(i).Item("FechaHoraSalida")
                                    Else
                                        .FechaHoraSalida = ""
                                    End If

                                    .Direccion = res.DsResult.Tables(0).Rows(i).Item("direccion").ToString
                                    .Telefono = res.DsResult.Tables(0).Rows(i).Item("telefono").ToString
                                End With
                                CabeceraMarcaciones.detalle.Add(Detallemarcaciones)
                            Next
                        End If
                        FinalEjecion = FinalEjecion + 1
                    End While
                    If ExiteData > 0 Then
                        frm.Detallemarcaciones = CabeceraMarcaciones.detalle
                        frm.Show()
                    Else
                        MessageBox.Show("No exite informacion para ese rengo de fecha")
                    End If
                End If
            ElseIf CompracionFecha > 0 Then
                MessageBox.Show("La Fecha fin no puede ser menor a la Fecha inicio")
            End If

        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'General.ExportToExcel(ugdSesionContactosByZonas)
    End Sub
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property
End Class