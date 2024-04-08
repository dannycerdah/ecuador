Imports SPC.Server.VuelosService

Public Class frmAsignarGuia
    Dim dtGuias As New DataTable("Guias")
    Dim idBriefing As New Guid

    Private Sub btnConsultar_Click_1(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                idBriefing = frmConsultaVuelos.resDetVuelo.idBriefing
                ObtenerGuias(idBriefing)
                txtAgencia.Text = frmConsultaVuelos.resDetVuelo.descripcionAgencia
                txtAvion.Text = frmConsultaVuelos.resDetVuelo.descripcionAvion
                txtMatricula.Text = frmConsultaVuelos.resDetVuelo.matriculaAvion
                txtNumVuelo.Text = frmConsultaVuelos.resDetVuelo.codigoVuelo
                udtFecha.Value = frmConsultaVuelos.resDetVuelo.fechaVuelo
                Dim envia As Server.ReportService.ContactoCatalogItem = CommonData.GetContactoItem(frmConsultaVuelos.resDetVuelo.enviaVuelo)
                txtDe.Text = envia.primerApellido + " " + envia.segundoApellido + " " + envia.primerNombre
                Dim recibe As Server.ReportService.ContactoCatalogItem = CommonData.GetContactoItem(frmConsultaVuelos.resDetVuelo.recibeVuelo)
                txtPara.Text = recibe.primerApellido + " " + recibe.segundoApellido + " " + recibe.primerNombre
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtAgencia.Clear()
        txtAvion.Clear()
        txtMatricula.Clear()
        txtNumVuelo.Clear()
        udtFecha.Value = Date.Now
        txtDe.Clear()
        txtPara.Clear()
    End Sub

    Private Sub ObtenerGuias(idBriefing As Guid)
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
                ugvGuias.DataSource = dtGuias
                SetDisplayedColumnsGuias()
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsGuias()
        Try
            ugvGuias.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Guia"
            ugvGuias.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("idCiudad").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("ciudadDestino").Header.Caption = "Destino"
            ugvGuias.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("producto").Header.Caption = "Producto"
            ugvGuias.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("agencia").Header.Caption = "Agencia de Carga"
            ugvGuias.DisplayLayout.Bands(0).Columns("fechaLlegada").Header.Caption = "Fecha de Llegada Estimada"
            ugvGuias.DisplayLayout.Bands(0).Columns("fechaLlegada").Format = "dd/MM/yyyy"
            ugvGuias.DisplayLayout.Bands(0).Columns("fechaLlegada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvGuias.DisplayLayout.Bands(0).Columns("peso").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("bultos").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugvGuias.DisplayLayout.Bands(0).Columns("DAE").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugvGuias_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugvGuias.DoubleClickRow
        Try
            Dim myGuia As New GuiaItem
            If Not ugvGuias.ActiveRow.Cells("idGuia").Value.ToString = String.Empty Then
                myGuia.Id = ugvGuias.ActiveRow.Cells("idGuia").Value
                myGuia.Descripcion = ugvGuias.ActiveRow.Cells("descripcion").Value
                myGuia.idBriefing = ugvGuias.ActiveRow.Cells("idBriefing").Value
                myGuia.idCiudad = ugvGuias.ActiveRow.Cells("idCiudad").Value
                myGuia.ciudadDestino = ugvGuias.ActiveRow.Cells("ciudadDestino").Value
                myGuia.IdAgencia = ugvGuias.ActiveRow.Cells("idAgencia").Value
                myGuia.DescripcionAgencia = ugvGuias.ActiveRow.Cells("agencia").Value
                myGuia.FechaLlegada = ugvGuias.ActiveRow.Cells("fechaLlegada").Value
                myGuia.Peso = ugvGuias.ActiveRow.Cells("peso").Value
                myGuia.Bultos = ugvGuias.ActiveRow.Cells("bultos").Value
                myGuia.Estado = ugvGuias.ActiveRow.Cells("estado").Value
                myGuia.DAE = ugvGuias.ActiveRow.Cells("DAE").Value
                myGuia.FechaAct = ugvGuias.ActiveRow.Cells("fechaAct").Value
                myGuia.usuarioAct = ugvGuias.ActiveRow.Cells("usuarioAct").Value
                ShowAsignarCamionDetails(myGuia)
            End If
            'RefreshData()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ShowAsignarCamionDetails(guia As GuiaItem)
        Using frmDetails As New frmAsignarGuiaDetalle(guia)
            frmDetails.ShowDialog()
            ObtenerGuias(idBriefing)
        End Using
    End Sub

End Class