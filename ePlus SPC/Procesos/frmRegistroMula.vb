Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.Server.ProcesoService
Public Class frmRegistroMula
    Dim myDetalleVuelo As New DetalleVuelo
    Dim myAcarreo As New AcarreoItem
    Dim myDetalleAcarreo As New DetalleAcarreoItem
    Dim dtAcarreo As New DataTable("Acarreo")
    Dim tipoAgencia As Guid = Guid.Parse("65ec9238-d302-49e9-bbb5-038e1caea03c")
    Dim tipoAgenciaSeguridad As Guid = Guid.Parse("d68cfbd1-0c3d-4b77-9018-7e190f8b74e8")
    Dim isEditDolly As Boolean = False
    Dim idAerolineaUps As String = "b86b9024-12ac-11e4-981b-8f9d682eafe3"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles btnConsultaVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                txtAerolinea.Text = frmConsultaVuelos.Aerolinea
                udtFecha.Value = myDetalleVuelo.fechaVuelo
                udtEta.Value = myDetalleVuelo.llegadaVuelo
                udtEta.FormatString = "dd/MM/yyyy H:mm"
                udtEtd.Value = myDetalleVuelo.salidaVuelo
                udtEtd.FormatString = "dd/MM/yyyy H:mm"
                ActivaBotones()
                cargarAgencia()
                myAcarreo = CommonProcess.GetAcarreoPorIdBriefing(myDetalleVuelo.idBriefing)
                If Not IsNothing(myAcarreo) Then
                    InfoAcarreoToTable()
                End If

            End If

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ActivaBotones()
        uceAgencia.Enabled = True
        uceDolly.Enabled = True
        uceChofer.Enabled = True
        uceAgenciaSeguridad.Enabled = True
        uceCustodio.Enabled = True
        btnIn.Enabled = True
        btnSa.Enabled = True
    End Sub

    Private Sub DesactivaBotones()
        uceAgencia.Enabled = False
        uceDolly.Enabled = False
        uceChofer.Enabled = False
        uceAgenciaSeguridad.Enabled = False
        uceCustodio.Enabled = False
        btnIn.Enabled = False
        btnSa.Enabled = False
    End Sub


    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub frmAcarreo_Load(sender As Object, e As EventArgs) Handles Me.Load

        With dtAcarreo.Columns
            .Add("idDetalle", GetType(Guid))
            .Add("idAcarreo", GetType(Guid))
            .Add("idDolly", GetType(Guid))
            .Add("dolly", GetType(String))
            .Add("idChofer", GetType(String))
            .Add("chofer", GetType(String))
            .Add("idAgencia", GetType(Guid))
            .Add("agencia", GetType(String))
            .Add("idCustodio", GetType(Guid))
            .Add("custodio", GetType(String))
            .Add("idAgenciaSeguridad", GetType(Guid))
            .Add("agenciaSeguridad", GetType(String))
            .Add("fechaEntrada", GetType(DateTime))
            .Add("fechaSalida", GetType(DateTime))
            .Add("estado", GetType(String))
        End With

        ugvDollys.DataSource = dtAcarreo
        SetDisplayedColumnsDollys()

        DesactivaBotones()
    End Sub

    Private Sub cargarAgencia()
        Try
            uceAgencia.Items.Clear()
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgencia.ToString).Rows
                uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgencia.SelectedIndex = 0

            uceAgenciaSeguridad.Items.Clear()
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgenciaSeguridad.ToString).Rows
                uceAgenciaSeguridad.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
            Next
            uceAgenciaSeguridad.SelectedIndex = 0

            If myDetalleVuelo.idAgencia.ToString = idAerolineaUps Then
                lblPersonalAerolinea.Visible = True
                ucePersonalAerolinea.Visible = True
                ucePersonalAerolinea.Clear()
                For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(Guid.Parse(idAerolineaUps)).Rows
                    ucePersonalAerolinea.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
                Next
                ucePersonalAerolinea.SelectedIndex = 0
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub uceAgencia_SelectionChanged(sender As Object, e As EventArgs) Handles uceAgencia.SelectionChanged
        uceDolly.Items.Clear()
        uceDolly.Items.Add(Guid.NewGuid, "Escoja una opción")
        For Each r As DataRow In CommonData.GetDollyPorIdAgencia(uceAgencia.Value).Rows
            uceDolly.Items.Add(r.Item("idDolly"), r.Item("codigoDolly"))
        Next
        uceDolly.SelectedIndex = 0

        uceChofer.Items.Clear()
        uceChofer.Items.Add("0000000000", "Escoja una opción")
        For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(uceAgencia.Value).Rows
            uceChofer.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
        Next
        uceChofer.SelectedIndex = 0
    End Sub

    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click
        If validaInfo() Then
            If SaveAcarreo() Then
                If SaveDetalleAcarreo() Then
                    InfoAcarreoToTable()
                End If
            End If
        Else
            MessageBox.Show("Debe llenar todos los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function SaveDetalleAcarreo() As Boolean
        Dim result As Boolean = False
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            myDetalleAcarreo.IdDetalle = Guid.NewGuid
            myDetalleAcarreo.idAcarreo = myAcarreo.IdAcarreo
            myDetalleAcarreo.idDolly = uceDolly.Value
            myDetalleAcarreo.idChofer = uceChofer.Value
            myDetalleAcarreo.idAgencia = uceAgencia.Value
            If myDetalleVuelo.idAgencia.ToString = idAerolineaUps Then
                If uceCustodio.Value <> String.Empty Or uceCustodio.Value <> "00000000000" Then
                    If ucePersonalAerolinea.Value <> String.Empty Or ucePersonalAerolinea.Value <> "00000000000" Then
                        myDetalleAcarreo.idCustodio = ucePersonalAerolinea.Value
                        myDetalleAcarreo.idAgenciaSeguridad = Guid.Parse(idAerolineaUps)
                    End If
                Else
                    myDetalleAcarreo.idCustodio = uceCustodio.Value
                    myDetalleAcarreo.idAgenciaSeguridad = uceAgenciaSeguridad.Value
                End If
            Else
                If uceCustodio.Value <> String.Empty Or uceCustodio.Value <> "00000000000" Then
                    myDetalleAcarreo.idCustodio = uceCustodio.Value
                    myDetalleAcarreo.idAgenciaSeguridad = uceAgenciaSeguridad.Value
                End If
            End If
            myDetalleAcarreo.estado = "I"
            myDetalleAcarreo.fechaEntrada = DateTime.Now
            If myDetalleAcarreo.estado = "I" Then
                myDetalleAcarreo.fechaSalida = Date.Parse("1/1/0001 12:00:00 AM")
            End If
            req.myDetalleAcarreoItem = myDetalleAcarreo
            res = WsClnt.SaveDetalleAcarreoItem(req)
            If res.ActionResult Then
                result = True
            Else
                result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function SaveAcarreo() As Boolean
        Dim result As Boolean = False
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myAcarreo) Then myAcarreo = New AcarreoItem
            If myAcarreo.IdAcarreo = Guid.Empty Then
                myAcarreo.IdAcarreo = Guid.NewGuid
            End If
            myAcarreo.idBriefing = myDetalleVuelo.idBriefing
            myAcarreo.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
            myAcarreo.fecha = DateTime.Now
            req.myAcarreoItem = myAcarreo
            res = WsClnt.SaveAcarreoItem(req)
            If res.ActionResult Then
                result = True
            Else
                result = False
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub InfoAcarreoToTable()
        'Dim r As DataRow
        'r = dtAcarreo.NewRow
        'r.Item("idDetalle") = myDetalleAcarreo.IdDetalle
        'r.Item("idAcarreo") = myDetalleAcarreo.idAcarreo
        'r.Item("idDolly") = myDetalleAcarreo.idDolly
        'r.Item("dolly") = uceDolly.Text
        'r.Item("idChofer") = myDetalleAcarreo.idChofer
        'r.Item("chofer") = uceChofer.Text
        'r.Item("idAgencia") = myDetalleAcarreo.idAgencia
        'r.Item("agencia") = uceAgencia.Text
        'r.Item("fechaEntrada") = myDetalleAcarreo.fechaEntrada
        'r.Item("fechaSalida") = myDetalleAcarreo.fechaSalida
        'dtAcarreo.Rows.Add(r)
        dtAcarreo = CommonProcess.GetDetalleAcarreoPorIdAcarreo(myAcarreo.IdAcarreo)
        ugvDollys.DataSource = dtAcarreo
        SetDisplayedColumnsDollys()
    End Sub

    Private Function validaInfo()
        Try
            If txtVuelo.Text = String.Empty Then
                Return False
                Exit Function
            End If
            If IsNothing(myDetalleVuelo) Then
                Return False
                Exit Function
            End If
            If uceAgencia.Value = Guid.Empty Then
                Return False
                Exit Function
            End If
            If uceDolly.Value = Guid.Empty Then
                Return False
                Exit Function
            End If
            If uceChofer.Value = String.Empty Then
                Return False
                Exit Function
            End If
            If myDetalleVuelo.idAgencia.ToString = idAerolineaUps Then
                If (uceCustodio.Value = String.Empty Or uceCustodio.Value = "0000000000") Or ucePersonalAerolinea.Value = String.Empty Then
                    Return False
                    Exit Function
                End If
            Else
                If uceCustodio.Value = String.Empty Or uceCustodio.Value = "0000000000" Then
                    Return False
                    Exit Function
                End If
            End If
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvDollys.Rows
                    If uceDolly.Value = r.Cells.Item("idDolly").Value And r.Cells.Item("fechaSalida").Value.ToString = "1/1/0001 12:00:00 AM" Then
                        MessageBox.Show("El Dolly ya se encuentra ingresado, verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                        Exit Function
                    End If
                Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function

    Private Sub SetDisplayedColumnsDollys()
        Try

            ugvDollys.DisplayLayout.Bands(0).Columns("idDetalle").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("idAcarreo").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("idDolly").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("dolly").Header.Caption = "Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("idChofer").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("chofer").Header.Caption = "Chofer"
            ugvDollys.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia de Rampa"
            ugvDollys.DisplayLayout.Bands(0).Columns("idCustodio").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("Custodio").Header.Caption = "Custodio"
            ugvDollys.DisplayLayout.Bands(0).Columns("idAgenciaSeguridad").Hidden = True
            ugvDollys.DisplayLayout.Bands(0).Columns("agenciaSeguridad").Header.Caption = "Agencia de Seguridad"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").Header.Caption = "Fecha de Entrada Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").Format = "dd/MM/yyyy H:mm:ss"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaEntrada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").Header.Caption = "Fecha de Salida Dolly"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").Format = "dd/MM/yyyy H:mm:ss"
            ugvDollys.DisplayLayout.Bands(0).Columns("fechaSalida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvDollys.DisplayLayout.Bands(0).Columns("estado").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvDollys_AfterSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles ugvDollys.AfterSelectChange
        If isEditDolly Then
            If Not ugvDollys.ActiveRow.Cells("idDolly").Value.ToString = String.Empty Then
                If ugvDollys.ActiveRow.Cells("estado").Value.ToString = "I" Then
                    DesactivaBotones()
                    infoDollyToObject()
                    btnSa.Enabled = True
                    isEditDolly = True
                Else
                    MessageBox.Show("El Dolly ya se encuentra en la Pista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ActivaBotones()
                    isEditDolly = False
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub ugvDollys_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvDollys.DoubleClickCell
        If Not ugvDollys.ActiveRow.Cells("idDolly").Value.ToString = String.Empty Then
            If ugvDollys.ActiveRow.Cells("estado").Value.ToString = "I" Then
                DesactivaBotones()
                infoDollyToObject()
                btnSa.Enabled = True
                isEditDolly = True
            Else
                MessageBox.Show("El Dolly ya se encuentra en la Pista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActivaBotones()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnSa_Click(sender As Object, e As EventArgs) Handles btnSa.Click
        Dim req As New AcarreoRequest
        Dim res As New AcarreoResponse
        Dim WsClnt As New ProcesoServiceSoapClient
        Try
            General.SetBARequest(req)
            If IsNothing(myDetalleAcarreo) Then myDetalleAcarreo = New DetalleAcarreoItem

            myDetalleAcarreo.estado = "O"
            myDetalleAcarreo.fechaSalida = DateTime.Now
            req.myDetalleAcarreoItem = myDetalleAcarreo
            res = WsClnt.SaveDetalleAcarreoItem(req)
            If res.ActionResult Then
                MessageBox.Show("Actualizado con éxtito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error en Actualización", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New Exception(res.ErrorMessage)
            End If
            ActivaBotones()
            isEditDolly = False
            InfoAcarreoToTable()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub infoDollyToObject()
        Try
            myDetalleAcarreo.idDolly = ugvDollys.ActiveRow.Cells("idDolly").Value
            myDetalleAcarreo.idAcarreo = ugvDollys.ActiveRow.Cells("idAcarreo").Value
            myDetalleAcarreo.idAgencia = ugvDollys.ActiveRow.Cells("idAgencia").Value
            myDetalleAcarreo.idChofer = ugvDollys.ActiveRow.Cells("idChofer").Value
            myDetalleAcarreo.IdDetalle = ugvDollys.ActiveRow.Cells("idDetalle").Value
            myDetalleAcarreo.idCustodio = ugvDollys.ActiveRow.Cells("idCustodio").Value
            myDetalleAcarreo.idAgenciaSeguridad = ugvDollys.ActiveRow.Cells("idAgenciaSeguridad").Value
            myDetalleAcarreo.fechaEntrada = ugvDollys.ActiveRow.Cells("fechaEntrada").Value
            myDetalleAcarreo.fechaSalida = ugvDollys.ActiveRow.Cells("fechaSalida").Value
            myDetalleAcarreo.estado = ugvDollys.ActiveRow.Cells("estado").Value
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub uceAgenciaSeguridad_SelectionChanged(sender As Object, e As EventArgs) Handles uceAgenciaSeguridad.SelectionChanged
        Try
            uceCustodio.Items.Clear()
            uceCustodio.Items.Add("0000000000", "Escoja una opción")
            For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(uceAgenciaSeguridad.Value).Rows
                uceCustodio.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto"))
            Next
            uceCustodio.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class