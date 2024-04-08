Imports SPC.Server.ProcesoService
Imports SPC.Server.VuelosService
Imports SPC.Server.CourrierService
Imports SPC.Server.ReportService

Public Class FormAsignarCubeta
    Dim dtAsignarCubetas As New DataTable("AsignarCubetas")
    Dim dtGuias As New DataTable("Guias")
    Dim idBriefing As String
    Dim dtDetalleProceso As New DataTable()
    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet


    Private Sub FormAsignarCubeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtAsignarCubetas.Clear()
        With dtAsignarCubetas
            .Columns.Add("idgavetaguia", GetType(String))
            .Columns.Add("idElemento", GetType(String))
            .Columns.Add("idDetalleProceso", GetType(String))
            .Columns.Add("pesoReferencialElemento", GetType(String)) 'cubeta
            .Columns.Add("pesoCarga", GetType(String))
            .Columns.Add("nuSaca", GetType(String))
            .Columns.Add("estado", GetType(String))
        End With
        ugvCubetasSacas.DataSource = dtAsignarCubetas
        SetDisplayedColumnsDetalleGavetas()
    End Sub

    Private Sub obtenerDetalleVuelo(ByVal BriefingId As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        With dtVuelo
            .idBriefing = BriefingId
        End With
        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.GetDetalleVueloPorIdBriefing(req)
            If res.ActionResult Then
                resDtVuelo = res.myDetalleVuelo
                resDsVuelo = res.DsResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> String.Empty Then
                obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
                obtenerDatosdeGuias(frmConsultaVuelos.resDetVuelo.idBriefing)
                idBriefing = frmConsultaVuelos.resDetVuelo.idBriefing.ToString()
                txtVuelo.Text = frmConsultaVuelos.uceAerolinea.Text
                txtNumVuelo.Text = resDtVuelo.codigoVuelo
                udtFecha.Value = resDtVuelo.fechaVuelo


            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtNumVuelo.Text = ""
        txtVuelo.Text = ""
        ucbGuia.Clear()
        ucbSaca.Clear()
        txtGaveta.Text = ""
        idBriefing = ""

    End Sub

    Private Sub obtenerDatosdeGuias(idBriefing As Guid)
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New GuiaRequest
        Dim res As New GuiaResponse
        Dim Guia As New GuiaItem

        With Guia
            .idBriefing = idBriefing
        End With
        Try
            General.SetBARequest(req)
            req.myGuiaItem = Guia
            res = wsClient.GetGuiaPorIdBriefing(req)
            If res.ActionResult Then

                dtGuias = res.dsResult.Tables(0)
                ucbGuia.Clear()
                For Each r As DataRow In dtGuias.Rows
                    ucbGuia.Items.Add(r.Item("idGuia"), r.Item("descripcion"))
                Next
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub obtenerDatosDetalledeProceso(idBriefing As String, idGuia As String)
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ProcesoRequest
        Dim res As New ProcesoResponse
        Dim Proceso As New ProcesoItem
        Try
            General.SetBARequest(req)
            req.myProcesoItem = New ProcesoItem
            req.myProcesoItem.idBriefing = Guid.Parse(idBriefing)
            req.myDetalleProcesoItem = New DetalleProcesoItem
            req.myDetalleProcesoItem.idGuia = Guid.Parse(idGuia)
            res = wsClient.Getdetalleprocesocargaporidbriefingidguia(req)
            ucbSaca.Clear()
            If res.ActionResult Then
                dtDetalleProceso = res.dsResult.Tables(0)
                For Each dr As DataRow In res.dsResult.Tables(0).Rows
                    ucbSaca.Items.Add(dr.Item("indice"), dr.Item("nusaca"))
                Next
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerDetalleGavetasporGuia(ByVal idBriefing As String, ByVal idGuia As String)
        Dim wsClient As New CourrierServiceSoapClient
        Dim req As New GavetaGuiaRequest
        Dim res As New GavetaGuiaResponse
        Dim dt


        Dim Proceso As New GavetaGuiaItem
        Try
            General.SetBARequest(req)
            req.myGavetaGuiaItem.idBriefing = idBriefing
            req.myGavetaGuiaItem.idGuia = idGuia
            res = wsClient.ObtenerGavetaGuiaporBriefingIdGuia(req)
            If res.ActionResult Then
                For Each dr As DataRow In res.dsResult.Tables(0).Rows
                    Dim drcub = dtAsignarCubetas.NewRow()
                    drcub.Item("idgavetaguia") = dr.Item("idgavetaguia")
                    drcub.Item("idElemento") = dr.Item("idElemento")
                    drcub.Item("idDetalleProceso") = dr.Item("idDetalleProceso")
                    drcub.Item("pesoReferencialElemento") = dr.Item("pesoReferencialElemento")
                    drcub.Item("pesoCarga") = dr.Item("pesoCarga")
                    drcub.Item("nuSaca") = dr.Item("nuSaca")
                    drcub.Item("estado") = dr.Item("estado")
                Next
            End If

            ugvCubetasSacas.DataBind()
            ugvCubetasSacas.Refresh()
            SetDisplayedColumnsDetalleGavetas()

        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub SetDisplayedColumnsDetalleGavetas()
        Try
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("idgavetaguia").Hidden = True
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "ELEMENTO"
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("idDetalleProceso").Hidden = True
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("pesoReferencialElemento").Header.Caption = "PESO ELEMENTO"
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("pesoCarga").Header.Caption = "PESO CARGA"
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("nuSaca").Header.Caption = "SACA"
            ugvCubetasSacas.DisplayLayout.Bands(0).Columns("estado").Hidden = True

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SaveEstadoElemento()
        'For Each r As DataRow In dtTotalElementos.Rows
        '    Dim result As Boolean = False
        '    Dim req As New Server.ReportService.ElementoRequest
        '    Dim res As New Server.ReportService.ElementoResponse
        '    Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        '    Try
        '        myElemento.Id = r.Item("elemento")
        '        myElemento.estado = "C"
        '        General.SetBARequest(req)
        '        req.myElementoItem = myElemento
        '        res = WsClnt.SaveEstadoElemento(req)
        '        If res.ActionResult Then
        '            result = True
        '        Else
        '            Throw New Exception(res.ErrorMessage)
        '        End If
        '    Catch ex As Exception
        '        ErrorManager.SetLogEvent(ex, res, req)
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'Next
    End Sub

    Private Sub ucbGuia_ValueChanged(sender As Object, e As EventArgs) Handles ucbGuia.ValueChanged
        obtenerDatosDetalledeProceso(idBriefing, ucbGuia.Value.ToString())
    End Sub

    Private Sub txtGaveta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGaveta.KeyDown
        Dim datos As New GavetaGuiaItem
        Dim req As New GavetaGuiaRequest
        Dim dr As DataRow
        Dim dt As New DataTable


        Dim ItemElemento As New ElementoCatalogItem

        If e.KeyCode = Keys.Return Then
            If txtGaveta.Text.Trim() <> String.Empty Then

                'validar si existe elemento
                ItemElemento = CommonData.GetElementoItem(txtGaveta.Text.Trim())

                If ItemElemento.estado = "A" Or ItemElemento.estado = "P" Then

                Else
                    MessageBox.Show("No existe elemento o no esta disponible", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'validar si no ha sido usado elemento en la guia
                dt = CommonData.getGavetaGuiaporIdGuiaIdElemento(ucbGuia.Value, txtGaveta.Text.Trim())
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("EL elemento ya se encuentra ocupado con carga ", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If


                datos.idgavetaguia = Guid.NewGuid().ToString()
                datos.idGuia = ucbGuia.Value
                datos.idDetalleProceso = ucbSaca.Value
                datos.idBriefing = idBriefing
                datos.idElemento = txtGaveta.Text.Trim()
                datos.fecha = Date.Now()
                datos.pesoReferencialElemento = 0
                datos.fechaCarga = Date.Now()
                dr = dtDetalleProceso.Select("indice = '" & ucbSaca.Value.ToString & "'").First
                datos.pesoCarga = dr.Item("peso")
                datos.estado = "A"

                If CommonData.SavegavetasGuia(datos) Then

                    obtenerDetalleGavetasporGuia(idBriefing, ucbGuia.Value)
                    Me.txtGaveta.Text = ""
                    Me.txtGaveta.Focus()

                End If






            End If
        End If
    End Sub

    Private Sub txtGaveta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGaveta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

End Class