Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmPreAlertElementos
    'Dim myDetalleVuelo As New DetalleVuelo
    Dim myDetalleElemenPre As New ElementoPreBriefingItem
    Dim dtElemento As New DataTable("Elementos")
    Dim idCompaniaSeguridad As String = "d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"
    Dim idCompaniaRampa As String = "65ec9238-d302-49e9-bbb5-038e1caea03c"
    Dim idAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"



    Dim dtElementoAgregado As New DataTable("ElementosAg")
    Private idBriefing As Guid

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If ugvElementosAgregados.Rows.Count > 0 Then
                If UltraTextVuelo.Text = String.Empty Then
                    MessageBox.Show("Debe de Ingresar el Bumero de Vuelo.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf UlCombAerolinea.Value = Guid.Empty Then
                    MessageBox.Show("Debe de Seleccionar una Aerolinea.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf UlCombRampa.Value = Guid.Empty Then
                    MessageBox.Show("Debe de Seleecionar una Compañia de Rampa.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    SaveElementos()
                End If
            Else
                MessageBox.Show("No ha Pre-Ingresado ningun Elemento.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "SavePreAlertElementos")
        End Try
    End Sub

    Private Sub SaveElementos()
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim wsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            General.SetBARequest(req)
            Dim elementoPreBriefing As Server.ReportService.ElementoPreBriefingItem
            If myDetalleElemenPre.idBriefing = Guid.Empty And idBriefing = Guid.Empty Then
                idBriefing = Guid.NewGuid
            ElseIf myDetalleElemenPre.idBriefing <> Guid.Empty Then
                'elementoPreBriefing.idBriefing = myDetalleVuelo.idBriefing
                idBriefing = myDetalleElemenPre.idBriefing
            End If
            For Each r As DataRow In dtElementoAgregado.Rows
                elementoPreBriefing = New Server.ReportService.ElementoPreBriefingItem
                elementoPreBriefing.idBriefing = idBriefing
                'If myDetalleElemenPre.idBriefing = Guid.Empty Then
                '    elementoPreBriefing.idBriefing = Guid.NewGuid
                'Else
                '    'elementoPreBriefing.idBriefing = myDetalleVuelo.idBriefing
                '    elementoPreBriefing.idBriefing = myDetalleElemenPre.idBriefing
                'End If
                elementoPreBriefing.idElemento = r.Item("idElemento")
                elementoPreBriefing.fecha = FechaRecepcion.Value
                elementoPreBriefing.idContacto = MyCurrentUser.userName
                elementoPreBriefing.estado = "A"
                elementoPreBriefing.indice = Guid.NewGuid
                elementoPreBriefing.IdAerolinea = UlCombAerolinea.Value
                elementoPreBriefing.IdRampa = UlCombRampa.Value
                elementoPreBriefing.IdSeguridad = UlCombSeguridad.Value
                elementoPreBriefing.Vuelo = UltraTextVuelo.Text.Replace(" ", "")
                elementoPreBriefing.Procedencia = cmbProcedencia.Value
                req.myElementoPreBriefingItem = elementoPreBriefing
                res = wsClnt.SaveElementoPreBriefing(req)
            Next
            If res.ActionResult Then
                MessageBox.Show("Elementos actualizados con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub obtenerElementosAgregados(idBriefing As Guid)
        Dim wsClient As New Server.ReportService.ReportServiceSoapClient
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ReportResponse
        Dim elemento As New Server.ReportService.ElementoPreBriefingItem
        Try
            General.SetBARequest(req)
            elemento.idBriefing = idBriefing
            req.myElementoPreBriefingItem = elemento
            res = wsClient.GetElementoPreBriefingPorIdBriefing(req)
            If res.ActionResult Then
                Dim nr As DataRow
                dtElementoAgregado.Clear()
                For Each r As DataRow In res.dsResult.Tables(0).Rows
                    nr = dtElementoAgregado.NewRow
                    nr.Item("idElemento") = r.Item("idElemento").ToString
                    nr.Item("descripcionAgencia") = CommonData.GetElementoItem(r.Item("idElemento").ToString).descripcionAgencia
                    dtElementoAgregado.Rows.Add(nr)
                Next
                ugvElementosAgregados.DataSource = Nothing
                ugvElementosAgregados.DataSource = dtElementoAgregado
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultaVuelo_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        'Try
        '    Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
        '    frmConsultaVuelos.ShowDialog()
        '    If frmConsultaVuelos.Aerolinea <> "" Then
        '        myDetalleVuelo = frmConsultaVuelos.resDetVuelo
        '        txtVuelo.Text = myDetalleVuelo.codigoVuelo
        '        txtMatricula.Text = myDetalleVuelo.matriculaAvion
        '        udtEta.Value = myDetalleVuelo.llegadaVuelo
        '        udtEtd.Value = myDetalleVuelo.salidaVuelo
        '        udtFecha.Value = myDetalleVuelo.fechaVuelo
        '        obtenerElementosAgregados(myDetalleVuelo.idBriefing)
        '        'cargarElementos() 'ewlm
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    General.SetLogEvent(ex, "ConsultaVuelo PreAlertElementos")
        'End Try
    End Sub

    Private Sub frmPreAlertElementos_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dtElemento.Columns
            .Add("idElemento", GetType(String))
            .Add("descripcionAgencia", GetType(String))
        End With

        With dtElementoAgregado.Columns
            .Add("idElemento", GetType(String))
            .Add("descripcionAgencia", GetType(String))
        End With
        ugvElementos.DataSource = dtElemento
        ugvElementosAgregados.DataSource = dtElementoAgregado
        SetDisplayedColumnsElementos()
        CargaCombos()
        If ModuloCierre.EndHilo = False Then
            ModuloCierre.InicioEjecucion = Date.Now
            ModuloCierre.EjecutaHiloVerificacion()
        End If
    End Sub
    Private Sub CargaCombos()
        cargarEmpSeg()
        cargarEmpRampa()
        cargarAerolinea()
    End Sub
    Private Sub cargarEmpSeg()
        Try
            UlCombSeguridad.Items.Add(Guid.Empty, "SELECCIONE UNA OPCION")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(idCompaniaSeguridad).Rows
                UlCombSeguridad.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            UlCombSeguridad.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cargarEmpRampa()
        Try
            UlCombRampa.Items.Add(Guid.Empty, "SELECCIONE UNA OPCION")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(idCompaniaRampa).Rows
                UlCombRampa.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            UlCombRampa.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cargarAerolinea()
        Try
            UlCombAerolinea.Items.Add(Guid.Empty, "SELECCIONE UNA OPCION")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, idAerolinea, AgenciaAerolineaEX)).Rows
                UlCombAerolinea.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            UlCombAerolinea.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElementos()
        ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
        ugvElementos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"

        ugvElementosAgregados.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
        ugvElementosAgregados.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
    End Sub


    Private Sub cargarElementos()
        Try
            'sosa nuevo
            dtElemento.Clear() 'ewlm
            Dim tempElemento As New Server.ReportService.ElementoCatalogItem
            tempElemento.estado = "S" 'ewlm comentado
            tempElemento.Id = txtElemento.Text 'ewlm
            'tempElemento.IdAgencia = myDetalleVuelo.idAgencia 'FSG CAMBIO DE LA CONSULTA AHORA POR EL ID AGENCIA PARA QUE APARESCA SOLO LO DE LAS AGENCIAS 

            For Each r As DataRow In CommonData.GetElementosPorEstado(tempElemento).Rows
                Dim nr As DataRow
                nr = dtElemento.NewRow
                nr.Item("idElemento") = r.Item("idElemento")
                ' nr.Item("idAgencia") = r.Item("idAgencia")
                ' nr.Item("tipoElemento") = r.Item("tipoElemento")
                nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                ' nr.Item("pesoReal") = r.Item("pesoReal")
                ' nr.Item("estado") = r.Item("estado")
                dtElemento.Rows.Add(nr)
            Next
            'ewlm
            'If dtElemento.Rows.Count = 0 Then

            '    If MessageBox.Show("¿Elemento No Existe Desea Crearlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        Using frmDetails As New frmElementoDetails(True)
            '            frmDetails.ShowDialog()
            '        End Using
            '    End If
            'End If
            'ewlm fin
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtElemento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtElemento.KeyPress
        'ewlm
        If e.KeyChar = Chr(13) Then
            cargarElementos() 'sosa nuevo
        End If
    End Sub

    Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs) Handles txtElemento.ValueChanged
        'todo estaba comentado ewlm
        'If txtElemento.Text.Length > 0 Then
        '    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
        '        If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
        '            r.Hidden = False
        '        Else
        '            r.Hidden = True
        '        End If
        '    Next
        'Else
        '    For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
        '        r.Hidden = False
        '    Next
        'End If
    End Sub

    Private Sub ugvElementos_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugvElementos.DoubleClickRow
        Try
            If ugvElementos.ActiveRow.Cells("idElemento").Value <> String.Empty Then
                If Not ValidaInfoElemento(ugvElementos.ActiveRow.Cells("idElemento").Value) Then
                    MessageBox.Show("Elemento ya ingresado, revisar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim nr As DataRow
                nr = dtElementoAgregado.NewRow
                nr.Item("idElemento") = ugvElementos.ActiveRow.Cells("idElemento").Value
                nr.Item("descripcionAgencia") = ugvElementos.ActiveRow.Cells("descripcionAgencia").Value
                dtElementoAgregado.Rows.Add(nr)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidaInfoElemento(idElemento As String) As Boolean
        Dim result As Boolean = True
        For Each r As DataRow In dtElementoAgregado.Rows
            If idElemento = r.Item("idElemento") Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Private Sub ugvElementos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugvElementos.InitializeLayout

    End Sub

    Private Sub UltraBtnBusPreAlert_Click(sender As Object, e As EventArgs) Handles UltraBtnBusPreAlert.Click
        Try
            Dim frmConsultaPreElemento As New frmConsultaPreElemento
            frmConsultaPreElemento.ShowDialog(ugvElementosAgregados)
            If frmConsultaPreElemento.Aerolinea <> "" Then
                myDetalleElemenPre = frmConsultaPreElemento.resDetPreElement
                UltraTextVuelo.Text = myDetalleElemenPre.Vuelo
                UlCombAerolinea.Value = myDetalleElemenPre.IdAerolinea
                UlCombRampa.Value = myDetalleElemenPre.IdRampa
                If myDetalleElemenPre.IdSeguridad = Guid.Empty Then
                    UlCombSeguridad.Value = 0
                Else
                    UlCombSeguridad.Value = myDetalleElemenPre.IdSeguridad
                End If
                cmbProcedencia.Value = myDetalleElemenPre.Procedencia
                FechaRecepcion.Value = myDetalleElemenPre.fecha
                obtenerElementosAgregados(myDetalleElemenPre.idBriefing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "ConsultaVuelo PreAlertElementos")
        End Try
    End Sub

    Private Sub frmPreAlertElementos_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmPreAlertElementos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        ModuloCierre.InicioEjecucion = Date.Now
    End Sub

    Private Sub frmPreAlertElementos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ModuloCierre.EndHilo = False
    End Sub
End Class