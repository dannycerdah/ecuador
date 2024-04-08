Imports Ensamblado_ReporteFlights.ProcesoService
Imports Ensamblado_ReporteFlights.ReportService
Imports Ensamblado_ReporteFlights.VuelosService
Public Class ReportFlights
    Public Property myProceso As New ProcesoItem
    Public Property myAcarreo As New AcarreoItem
    Public Property myDetalleVuelo As New DetalleVuelo
    Public Property myNovedades As New Novedades

    Public Property myDetalleProceso As New DetalleProcesoItem
    Public Property myElementoProceso As New ElementoProcesoItem
    Public Property myElemento As New ElementoCatalogItem

    Dim dtDollys As New DataTable("Dollys")
    Dim dtCamiones As New DataTable("Camiones")
    Dim dtPersonalProceso As New DataTable("PersonalProceso")
    Dim dtDetalleProcesoReporte As New DataTable("detalleProcesosReporte")
    Dim dtDetallePersonalProcesoReporte As New DataTable("detallePersonalProcesoReporte")
    Dim dtDetalleProcesoCargaReporte As New DataTable("detalleProcesoCargaReporte")
    Dim dtDetalleProcesoCargaReporteCargaI As New DataTable("detalleProcesoCargaReporteCargaI")
    Dim dtDetalleProcesoCargaReporteCargaR As New DataTable("detalleProcesoCargaReporteCargaR")
    Dim dtDetalleProcesoCargaAlmacenaje As New DataTable("detalleProcesoCargaReporte")
    Dim dtComparacionPeso As New DataTable("comparacionPeso")
    Dim dtDetalleProcesoCargaElementosCargados As New DataTable("detalleProcesoCargaReporteElementosCargados")
    Dim dtDetalleAcarreoReporte As New DataTable("detalleAcarreoReporte")
    Dim dtStackPallet As New DataTable("stack")


    Dim dtPersonalGeneral As New DataTable("General")
    Dim dtPersonalAgenciaCarga As New DataTable("AgenciaCarga")
    Dim dtPersonalAerolinea As New DataTable("Aerolinea")
    Dim dtPersonalSeguridad As New DataTable("Seguridad")
    Dim dtPersonalInstitucion As New DataTable("Institucion")

    Dim briefingEncabezado As New BriefingEncabezado
    Dim briefingDetalle As New BriefingDetalle
    Dim elementoPresel As New ElementosPreseleccionados
    Dim elementoPreselDetalle As New ElementosPreseleccionadosDetalle
    Dim camionEncabezado As New CamionesEncabezado
    Dim camionDetalle As New CamionesDetalle
    Dim PersonalProceso As New PersonalProceso
    Dim PersonalProcesoDetalle As New PersonalProcesoDetalle
    Dim ProcesoCarga As New ProcesoCarga
    Dim ProcesoCarga2 As New ProcesoCarga2
    Dim ProcesoCargaAlmacenaje As New ProcesoCargaAlmacenaje
    Dim elementosCargados As New ElementosCargados
    Dim elementosCargadosDetalle As New ElementosCargadosDetalle
    Dim ProcesoCargaDetalle As New ProcesoCargaDetalle
    Dim ProcesoCargaDetalle2 As New ProcesoCargaDetalle2
    Dim ProcesoCargaAlmacenajeDetalle As New ProcesoCargaAlmacenajeDetalle
    Dim Acarreo As New Acarreo
    Dim DetalleAcarreo As New DetalleAcarreo

    Dim idTipoGeneral As String = "38b4e437-f3dd-4625-8e73-538858824fce"
    Dim idTipoAgenciaCarga As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim idTipoLineaAerea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim idTipoSeguridad As String = "d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"
    Dim idTipoInsituciones As String = "9cf3597e-0d79-4498-8d58-5889045c3729"
    Dim tempContacto As New ContactoCatalogItem
    Dim dtTempMatriz As New DataTable("tempMatriz")
    Dim dtCaptura As New DataTable("Captura")
    Dim dtTotalElementos As New DataTable("TotalElementos")
    Dim dtTotalGuias As New DataTable("TotalGuias")
    Dim dtGuias As New DataTable("Guias")
    Dim dtGuiaCamiones As New DataTable("GuiaCamiones")
    Dim dtGuiaProductos As New DataTable("GuiaProductos")
    Dim dtDetalleProceso As New DataTable("Procesos")
    Dim dtdetalleProcesoTemp As New DataTable("ProcesosTemp")
    Dim dtChequeoPan As New DataTable("ChequeoPan")

    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Dim DataIn As String = String.Empty
    Dim band_balanza As Boolean = False
    Dim id As Guid
    Dim idProceso As New Guid
    Dim ult As Integer = 0
    Dim procesoExist As Boolean = False
    Delegate Sub SetTextCallback(ByVal text As String)
    Dim cantBultos As Integer = 1
    Dim isNewProceso As Boolean = False
    Dim tempElementoProceso As New ElementoProcesoItem

    Dim tempCantidadCarga As Integer = 0
    Dim tempPesoReal As Decimal = 0D
    Dim tempCantidadGuias As Integer = 0
    Dim totPesoCargaA As Decimal = 0D
    Dim totPesoCargaI As Decimal = 0D
    Dim totPesoCargaR As Decimal = 0D
    Dim totPesoCargaD As Decimal = 0D
    Dim totPesoCargaC As Decimal = 0D


    Public Function cargarVuelo(idAerolinea As Guid, fechaIni As Date, fechaFin As Date) As Boolean
        Dim result As Boolean = False
        Try
            generarReporte(idAerolinea)
        Catch ex As Exception
        End Try
        Return result
    End Function

    Public Function generarReporte(idBriefing As Guid) As Boolean
        Dim result As Boolean = False
        Try
            iniciarTodo()
            obtenerDetalleVuelo(idBriefing)
            'myDetalleVuelo = frmConsultaVuelos.resDetVuelo
            cargarVuelo(idBriefing.ToString)
            CargarRptBriefing()
            CargarRptProcesoCarga()
            CargarRptNovedades()
            'If Not IsNothing(myNovedades) Then
            '    Try
            '        udtLlegadaAvion.Value = myNovedades.llegada
            '        udtSalidaAvion.Value = myNovedades.salida
            '        udtSubeCargaDesde.Value = myNovedades.subeDesde
            '        udtSubeCargaHasta.Value = myNovedades.subeHasta
            '        txtObs.Text = myNovedades.observacion
            '    Catch ex As Exception
            '    End Try
            'End If
            'txtCargaEstimada.Text = tempCantidadCarga
            'txtCargaRecibida.Text = tempPesoReal
            'txtCargaAvion.Text = totPesoCargaA
            'txtCargaQuedadaEste.Text = totPesoCargaI
            'txtCargaQuedadaOtros.Text = totPesoCargaR
            cargarUgvChequeoPan()
            imprimir()
        Catch ex As Exception
        End Try
        Return False
    End Function

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
            'ErrorManager.SetLogEvent(ex, res, req)
        End Try
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        Dim contactoDe As New ContactoCatalogItem
        Dim contactoPara As New ContactoCatalogItem
        contactoDe = CommonData.GetContactoItem(resDtVuelo.enviaVuelo)
        contactoPara = CommonData.GetContactoItem(resDtVuelo.recibeVuelo)
        'txtAgencia.Text = Aerolinea
        'txtNumVuelo.Text = resDtVuelo.codigoVuelo
        'txtDe.Text = contactoDe.primerApellido + " " + contactoDe.segundoApellido + " " + contactoDe.primerNombre
        'txtPara.Text = contactoPara.primerApellido + " " + contactoPara.segundoApellido + " " + contactoPara.primerNombre
        'txtAvion.Text = resDtVuelo.descripcionAvion
        'txtMatricula.Text = resDtVuelo.matriculaAvion
        'udtEta.Value = resDtVuelo.llegadaVuelo
        'udtEtd.Value = resDtVuelo.salidaVuelo
        'udtFecha.Value = resDtVuelo.fechaVuelo
        consultaProceso()
        ObtenerGuias(resDtVuelo.idBriefing)
        consultaCamion()
        consultaDollys()
        consultaPersonal()
        'CargarGuias()
    End Sub

    Private Sub CargarRptBriefing()
        Try
            BriefingEncabezado = New BriefingEncabezado
            Dim envia As New ContactoCatalogItem
            Dim recibe As New ContactoCatalogItem
            BriefingEncabezado.numeroVuelo = myDetalleVuelo.codigoVuelo
            BriefingEncabezado.aerolinea = myDetalleVuelo.descripcionAgencia
            BriefingEncabezado.fechaRecibido = myProceso.fechaInicio
            BriefingEncabezado.fechaVuelo = myDetalleVuelo.fechaVuelo
            envia = CommonData.GetContactoItem(myDetalleVuelo.enviaVuelo)
            BriefingEncabezado.envia = envia.primerApellido + " " + envia.primerNombre
            recibe = CommonData.GetContactoItem(myDetalleVuelo.recibeVuelo)
            BriefingEncabezado.recibe = recibe.primerApellido + " " + recibe.primerNombre
            BriefingEncabezado.matriculaAvion = myDetalleVuelo.matriculaAvion
            BriefingEncabezado.tipoAvion = myDetalleVuelo.descripcionAvion
            BriefingEncabezado.eta = myDetalleVuelo.llegadaVuelo
            BriefingEncabezado.etd = myDetalleVuelo.salidaVuelo

            For Each r As DataRow In dtGuias.Rows
                BriefingDetalle = New BriefingDetalle
                BriefingDetalle.horaEstimada = r.Item("fechaLlegada")
                BriefingDetalle.agencia = r.Item("descripcionAgencia")
                BriefingDetalle.guia = r.Item("descripcion")
                BriefingDetalle.destinoFinal = r.Item("ciudadDestino")
                BriefingDetalle.producto = r.Item("producto")
                BriefingDetalle.bultos = r.Item("bultos")
                BriefingDetalle.peso = r.Item("peso")
                BriefingDetalle.fecha = r.Item("fechaAct")
                Dim tempRecibe As New ContactoCatalogItem
                tempRecibe = CommonData.GetContactoItem(r.Item("UsuarioAct"))
                BriefingDetalle.recibe = tempRecibe.primerApellido + " " + tempRecibe.primerNombre + " - " + tempRecibe.tagsa
                tempCantidadCarga = tempCantidadCarga + r.Item("peso")
                tempCantidadGuias = tempCantidadGuias + 1
                BriefingEncabezado.briefingDetalle.Add(BriefingDetalle)
            Next

            BriefingEncabezado.estimadoDeCarga = tempCantidadCarga
            BriefingEncabezado.cantidadGuias = tempCantidadGuias
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarRptProcesoCarga()
        Try
            totPesoCargaA = 0D
            totPesoCargaI = 0D
            totPesoCargaR = 0D
            totPesoCargaD = 0D
            totPesoCargaC = 0D
            tempPesoReal = 0D
            ProcesoCarga = New ProcesoCarga
            ProcesoCarga2 = New ProcesoCarga2
            For Each r As DataRow In dtDetalleProcesoCargaReporteCargaI.Rows
                totPesoCargaI += r.Item("peso")
            Next

            For Each r As DataRow In dtDetalleProcesoCargaReporteCargaR.Rows
                totPesoCargaR += r.Item("peso")
            Next

            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                If r.Item("estado") = "D" Then
                    totPesoCargaD = r.Item("peso")
                End If
                If r.Item("estado") = "C" Then
                    totPesoCargaC = r.Item("peso")
                End If
                ProcesoCargaDetalle = New ProcesoCargaDetalle
                ProcesoCargaDetalle.fecha = r.Item("fecha")
                ProcesoCargaDetalle.horaInicio = r.Item("horaIni")
                ProcesoCargaDetalle.horaFin = r.Item("horaFin")
                ProcesoCargaDetalle.agencia = r.Item("agenciaCargaGuia")
                ProcesoCargaDetalle.guia = r.Item("guia")
                ProcesoCargaDetalle.elemento = r.Item("idElemento")
                ProcesoCargaDetalle.producto = r.Item("descripcionProducto")
                ProcesoCargaDetalle.temperatura = r.Item("temperaturaProm")
                ProcesoCargaDetalle.piezas = r.Item("piezas")
                ProcesoCargaDetalle.peso = r.Item("peso")
                tempPesoReal += r.Item("peso")
                If r.Item("volumen") < r.Item("peso") Then
                    ProcesoCargaDetalle.volumen = r.Item("peso")
                Else
                    ProcesoCargaDetalle.volumen = r.Item("volumen")
                End If
                ProcesoCargaDetalle.rx = r.Item("rx")
                ProcesoCargaDetalle.man = r.Item("man")
                ProcesoCargaDetalle.k9 = r.Item("k9")
                ProcesoCargaDetalle.eds = r.Item("eds")
                ProcesoCargaDetalle.M = r.Item("muelle").ToString.Substring(0, 7).Remove(0, 6)
                ProcesoCargaDetalle.estado = r.Item("estado")
                ProcesoCarga.ProcesoCargaDetalle.Add(ProcesoCargaDetalle)
            Next
            tempPesoReal = tempPesoReal - totPesoCargaR
            ProcesoCarga.CargaRecibida = tempPesoReal
            totPesoCargaA = tempPesoReal - totPesoCargaI + totPesoCargaR - totPesoCargaD - totPesoCargaC
            ProcesoCarga.CaragaAlAvion = totPesoCargaA
            ProcesoCarga.CargaQuedada = totPesoCargaI
            ProcesoCarga.CargaOtroVuelo = totPesoCargaR
            ProcesoCarga.CargaDevuelta = totPesoCargaD
            ProcesoCarga.CargaDecomisada = totPesoCargaC

            Dim tempFecha As Date
            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                If r.Item("estado") = "A" Then
                    tempFecha = Date.Parse(r.Item("fecha"))
                    Exit For
                End If
            Next

            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                'If (r.Item("estado") = "A" Or r.Item("estado") = "I" Or r.Item("estado") = "D") And tempFecha = Date.Parse(r.Item("fecha")) Then
                If (r.Item("estado") = "A" Or r.Item("estado") = "I" Or r.Item("estado") = "D") Then
                    ProcesoCargaDetalle2 = New ProcesoCargaDetalle2
                    ProcesoCargaDetalle2.fecha = r.Item("fecha")
                    ProcesoCargaDetalle2.horaInicio = r.Item("horaIni")
                    ProcesoCargaDetalle2.horaFin = r.Item("horaFin")
                    ProcesoCargaDetalle2.agencia = r.Item("agenciaCargaGuia")
                    ProcesoCargaDetalle2.guia = r.Item("guia")
                    ProcesoCargaDetalle2.elemento = r.Item("idElemento")
                    ProcesoCargaDetalle2.producto = r.Item("descripcionProducto")
                    ProcesoCargaDetalle2.temperatura = r.Item("temperaturaProm")
                    ProcesoCargaDetalle2.piezas = r.Item("piezas")
                    ProcesoCargaDetalle2.peso = r.Item("peso")
                    tempPesoReal += r.Item("peso")
                    If r.Item("volumen") < r.Item("peso") Then
                        ProcesoCargaDetalle2.volumen = r.Item("peso")
                    Else
                        ProcesoCargaDetalle2.volumen = r.Item("volumen")
                    End If
                    ProcesoCargaDetalle2.rx = r.Item("rx")
                    ProcesoCargaDetalle2.man = r.Item("man")
                    ProcesoCargaDetalle2.k9 = r.Item("k9")
                    ProcesoCargaDetalle2.eds = r.Item("eds")
                    ProcesoCargaDetalle2.M = r.Item("muelle").ToString.Substring(0, 7).Remove(0, 6)
                    ProcesoCarga2.ProcesoCargaDetalle2.Add(ProcesoCargaDetalle2)
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarRptNovedades()
        Try
            myNovedades = New Novedades
            Dim novedadesItem As NovedadesItem
            novedadesItem = CommonProcess.GetNovedadesPorIdProceso(myProceso.IdProceso)
            If Not IsNothing(novedadesItem) Then
                myNovedades.idProceso = novedadesItem.idProceso
                myNovedades.llegada = novedadesItem.llegada
                myNovedades.salida = novedadesItem.salida
                myNovedades.subeDesde = novedadesItem.subeDesde
                myNovedades.subeHasta = novedadesItem.subeHasta
                myNovedades.observacion = novedadesItem.observacion
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarUgvChequeoPan()
        Try
            dtChequeoPan.Clear()
            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                Dim nr As DataRow
                nr = dtChequeoPan.NewRow
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
                nr.Item("producto") = r.Item("descripcionProducto")
                nr.Item("piezas") = r.Item("piezas")
                nr.Item("peso") = r.Item("peso")
                nr.Item("man") = r.Item("man")
                dtChequeoPan.Rows.Add(nr)
            Next
            'ugvChequeo.DataSource = dtChequeoPan
            'SetDisplayColumnsChequeo()
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub imprimir()
        Try
            'CargarRptBriefing()
            CargarRptElementosPresel()
            CargarRptCamiones()
            CargarRptPersonalProceso()
            'CargarRptProcesoCarga()
            CargarRptProcesoAlmacenaje()
            CargarRptProcesoElementosCargados()
            CargarRptDetalleAcarreo()
            'CargarRptDetalleAcarreoStack()
            CargarRptNovedades()

            'Dim frm As New RptReportFlights()
            'frm.briefingEncabezado.Add(BriefingEncabezado)
            'frm.briefingDetalle = BriefingEncabezado.briefingDetalle

            'frm.ElementoPresel.Add(elementoPresel)
            'frm.ElementoPreselDetalle = elementoPresel.elementosPreseleccionadosDetalle

            'frm.camionesEncabezado.Add(camionEncabezado)
            'frm.camionesDetalle = camionEncabezado.CamionesDetalle

            'frm.PersonalProceso.Add(PersonalProceso)
            'frm.PersonalProcesoDetalle = PersonalProceso.PersonalProcesoDetalle

            'frm.ProcesoCarga.Add(ProcesoCarga)
            'frm.ProcesoCargaDetalle = ProcesoCarga.ProcesoCargaDetalle

            'frm.ProcesoCarga2.Add(ProcesoCarga2)
            'frm.ProcesoCargaDetalle2 = ProcesoCarga2.ProcesoCargaDetalle2

            'frm.ProcesoCargaAlmacenaje.Add(ProcesoCargaAlmacenaje)
            'frm.ProcesoCargaAlmacenajeDetalle = ProcesoCargaAlmacenaje.ProcesoCargaAlmacenajeDetalle

            'frm.ElementoCargado.Add(ElementosCargados)
            'frm.ElementoCargadoDetalle = ElementosCargados.ElementosCargadosDetalle

            'frm.Acarreo.Add(Acarreo)
            'frm.DetalleAcarreo = Acarreo.detalleAcarreo

            'frm.Novedades.Add(myNovedades)

            'frm.Show()
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
    '    Try
    '        Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
    '        Limpiar()
    '        frmConsultaVuelos.ShowDialog()
    '        If frmConsultaVuelos.Aerolinea <> "" Then
    '            obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
    '            myDetalleVuelo = frmConsultaVuelos.resDetVuelo
    '            cargarVuelo(frmConsultaVuelos.Aerolinea)
    '            CargarRptBriefing()
    '            CargarRptProcesoCarga()
    '            CargarRptNovedades()
    '            If Not IsNothing(myNovedades) Then
    '                Try
    '                    udtLlegadaAvion.Value = myNovedades.llegada
    '                    udtSalidaAvion.Value = myNovedades.salida
    '                    udtSubeCargaDesde.Value = myNovedades.subeDesde
    '                    udtSubeCargaHasta.Value = myNovedades.subeHasta
    '                    txtObs.Text = myNovedades.observacion
    '                Catch ex As Exception
    '                End Try
    '            End If
    '            txtCargaEstimada.Text = tempCantidadCarga
    '            txtCargaRecibida.Text = tempPesoReal
    '            txtCargaAvion.Text = totPesoCargaA
    '            txtCargaQuedadaEste.Text = totPesoCargaI
    '            txtCargaQuedadaOtros.Text = totPesoCargaR
    '            cargarUgvChequeoPan()
    '        End If
    '    Catch ex As Exception
    '        General.SetLogEvent(ex)
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

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
                Dim nr As DataRow
                For Each r As DataRow In res.dsResult.Tables(0).Rows
                    nr = dtGuias.NewRow
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("descripcion") = r.Item("descripcion")
                    nr.Item("idBriefing") = r.Item("idBriefing")
                    nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("producto") = r.Item("producto")
                    nr.Item("idAgencia") = r.Item("idAgencia")
                    nr.Item("descripcionAgencia") = r.Item("agencia")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("bultos") = r.Item("bultos")
                    nr.Item("fechaLlegada") = r.Item("fechaLlegada")
                    nr.Item("estado") = r.Item("estado")
                    nr.Item("DAE") = r.Item("DAE")
                    nr.Item("fechaAct") = r.Item("fechaAct")
                    nr.Item("usuarioAct") = r.Item("usuarioAct")
                    dtGuias.Rows.Add(nr)
                Next
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            'ErrorManager.SetLogEvent(ex, res, req)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerProceso()
        Dim dt As New DataTable
        Dim nr As DataRow
        Try
            dtCaptura.Rows.Clear()
            dtDetalleProceso.Rows.Clear()
            With myProceso
                .idAvion = resDtVuelo.idAvion
                .idBriefing = resDtVuelo.idBriefing
            End With

            myProceso = CommonProcess.GetProcesoPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In CommonProcess.GetDetalleProcesoPorIdProceso(myProceso.IdProceso).Rows
                nr = dtDetalleProceso.NewRow
                nr.Item("idProceso") = r.Item("idProceso")
                nr.Item("fecha") = r.Item("fecha")
                nr.Item("idGuia") = r.Item("idGuia")
                nr.Item("guia") = r.Item("guia")
                nr.Item("idElemento") = r.Item("idElemento")
                nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                nr.Item("bultos") = r.Item("bultos")
                nr.Item("peso") = r.Item("peso")
                nr.Item("piezas") = r.Item("piezas")
                nr.Item("volumen") = r.Item("volumen")
                nr.Item("hora") = r.Item("hora")
                nr.Item("idProducto") = r.Item("idProducto")
                nr.Item("estado") = r.Item("estado")
                nr.Item("idPosicion") = r.Item("idPosicion")
                nr.Item("temperatura") = r.Item("temperatura")
                nr.Item("rx") = r.Item("rx")
                nr.Item("man") = r.Item("man")
                nr.Item("k9") = r.Item("k9")
                nr.Item("eds") = r.Item("eds")
                nr.Item("largo") = r.Item("largo")
                nr.Item("ancho") = r.Item("ancho")
                nr.Item("alto") = r.Item("alto")
                nr.Item("tempA") = r.Item("tempA")
                nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                nr.Item("tempB") = r.Item("tempB")
                nr.Item("tempC") = r.Item("tempC")
                nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                nr.Item("idCamion") = r.Item("idCamion")
                nr.Item("muelle") = r.Item("muelle")
                nr.Item("indice") = r.Item("indice")
                nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")
                dtDetalleProceso.Rows.Add(nr)
            Next

            If Not IsNothing(dtDetalleProceso) And dtDetalleProceso.Rows.Count > 0 Then
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaProceso()
        Dim proceso As New ProcesoItem
        Try
            With proceso
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            myProceso = proceso
            If Not proceso Is Nothing Then
                Dim nr As DataRow
                procesoExist = True
                For Each r As DataRow In CommonProcess.GetDetalleProcesoPorIdProceso(myProceso.IdProceso).Rows
                    nr = dtDetalleProceso.NewRow
                    nr.Item("idProceso") = r.Item("idProceso")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                    nr.Item("bultos") = r.Item("bultos")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("hora") = r.Item("hora")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("estado") = r.Item("estado")
                    nr.Item("idPosicion") = r.Item("idPosicion")
                    nr.Item("temperatura") = r.Item("temperatura")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    nr.Item("eds") = r.Item("eds")
                    nr.Item("largo") = r.Item("largo")
                    nr.Item("ancho") = r.Item("ancho")
                    nr.Item("alto") = r.Item("alto")
                    nr.Item("tempA") = r.Item("tempA")
                    nr.Item("tempA_3_4") = r.Item("tempA_3_4")
                    nr.Item("tempB") = r.Item("tempB")
                    nr.Item("tempC") = r.Item("tempC")
                    nr.Item("tempZ_Flor") = r.Item("tempZ_Flor")
                    nr.Item("tempZ_Pq") = r.Item("tempZ_Pq")
                    nr.Item("idCamion") = r.Item("idCamion")
                    nr.Item("muelle") = r.Item("muelle")
                    nr.Item("indice") = r.Item("indice")
                    nr.Item("RegCargaCuartoFrio") = r.Item("RegCargaCuartoFrio")
                    nr.Item("UsusarioIngreso") = r.Item("UsusarioIngreso")
                    dtDetalleProceso.Rows.Add(nr)
                Next
            End If

            dtDetalleProcesoReporte = CommonProcess.GetDetalleProcesoPorIdProcesoReporte(myProceso.IdProceso)
            dtDetallePersonalProcesoReporte = CommonProcess.GetDetallePersonalPorIdProcesoReporte(myProceso.IdProceso)
            dtDetalleProcesoCargaReporte = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(myProceso.IdProceso)
            dtDetalleProcesoCargaReporteCargaI = CommonProcess.GetDetalleProcesoPorIdProcesoCargaI(myProceso.IdProceso)
            dtDetalleProcesoCargaReporteCargaR = CommonProcess.GetDetalleProcesoPorIdProcesoCargaR(myProceso.IdProceso)
            dtDetalleProcesoCargaAlmacenaje = CommonProcess.GetDetalleProcesoCargaPorIdProcesoAlmacenaje(myProceso.IdProceso)
            dtComparacionPeso = CommonProcess.GetElementoProcesoPorIdProceso(myProceso.IdProceso)
            dtDetalleProcesoCargaElementosCargados = CommonProcess.GetReportePorIdProcesoGroupByElemento2(myProceso.IdProceso)
            dtDetalleAcarreoReporte = CommonProcess.GetDetalleAcarreoIdProcesoReporte(myProceso.IdProceso)
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub actualizarDetalleProceso()
        ObtenerProceso()
    End Sub

    Private Sub consultaCamion()
        Try
            Dim tempDtCamiones As New DataTable("tempCamiones")
            If Not IsNothing(dtGuias) Then
                For Each r As DataRow In dtGuias.Rows
                    Dim nr As DataRow
                    tempDtCamiones = CommonProcess.GetGuiaCamionesPorIdGuia(r.Item("idGuia"), r.Item("idBriefing"))
                    For Each r2 As DataRow In tempDtCamiones.Rows
                        nr = dtCamiones.NewRow
                        nr.Item("idGuia") = r2.Item("idGuia")
                        nr.Item("descripcion") = r2.Item("descripcion")
                        nr.Item("idAgencia") = r2.Item("idAgencia")
                        nr.Item("descripcionAgencia") = r2.Item("descripcionAgencia")
                        nr.Item("idCamion") = r2.Item("idCamion")
                        nr.Item("matriculaCamion") = r2.Item("matriculaCamion")
                        nr.Item("fecha") = r2.Item("fecha")
                        nr.Item("idContacto") = r2.Item("idContacto")
                        nr.Item("primerNombreContacto") = r2.Item("primerNombreContacto")
                        nr.Item("primerApellidoContacto") = r2.Item("primerApellidoContacto")
                        nr.Item("procedencia") = r2.Item("procedencia")
                        nr.Item("indice") = r2.Item("indice")
                        dtCamiones.Rows.Add(nr)
                    Next
                Next
            End If
            'ugvCamiones.DataSource = dtCamiones
            'SetDisplayColumnsCamiones()
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaDollys()
        Try
            obtenerAcarreo()
            obtenerDetalleAcarreo()
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerAcarreo()
        myAcarreo = CommonProcess.GetAcarreoPorIdBriefing(myDetalleVuelo.idBriefing)
    End Sub

    Private Sub obtenerDetalleAcarreo()
        If Not IsNothing(myAcarreo) Then
            dtDollys = CommonProcess.GetDetalleAcarreoPorIdAcarreo(myAcarreo.IdAcarreo)
            'ugvDollys.DataSource = dtDollys
            'SetDisplayColumnsDollys()
        End If
    End Sub

    Private Sub consultaPersonal()
        Try
            myProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing)
            dtPersonalProceso = CommonProcess.GetPersonalPorIdProceso(myProceso.IdProceso)
            'ugvProceso.DataSource = dtPersonalProceso
            'SetDisplayColumnsPersonal()
        Catch ex As Exception
            General.SetLogEvent(ex)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub consultaStackElementos()
        Dim dtElementos As New DataTable("Elementos")
        Dim dtTempElementos As New DataTable("TempElementos")
        Try

            With dtTempElementos.Columns
                .Add("elemento", GetType(String))
                .Add("peso", GetType(Decimal))
            End With
            dtElementos = CommonProcess.GetStackPalletsPorIdProceso(myProceso.IdProceso)
            dtStackPallet = CommonProcess.GetStackPalletsPorIdProceso(myProceso.IdProceso)
            For Each r As DataRow In dtTotalElementos.Rows
                Dim nr As DataRow
                nr = dtTempElementos.NewRow
                nr.Item("elemento") = r.Item("elemento")
                nr.Item("peso") = r.Item("pesoReal")
                dtTempElementos.Rows.Add(nr)
            Next
            Dim exist As Boolean = False
            For Each r As DataRow In dtElementos.Rows
                If r.Item("isBase") = "B" Then
                    Dim pesoStack As Decimal = 0D
                    pesoStack = r.Item("peso")
                    For Each r2 As DataRow In dtElementos.Rows
                        If r2.Item("isBase") = r.Item("idElemento") Then
                            pesoStack += r2.Item("peso")
                        End If
                    Next
                    exist = False
                    Dim nr As DataRow
                    For Each r2 As DataRow In dtTempElementos.Rows
                        If r2.Item("elemento") = r.Item("idElemento") Then
                            exist = True
                        End If
                    Next
                    If Not exist Then
                        nr = dtTotalElementos.NewRow
                        nr.Item("elemento") = r.Item("idElemento")
                        nr.Item("totalBultos") = 0
                        nr.Item("totalPiezas") = 0
                        nr.Item("pesoReal") = pesoStack
                        nr.Item("pesoVolumen") = 0
                        dtTotalElementos.Rows.Add(nr)
                    End If
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex, "agregarStack")
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarRptElementosPresel()
        elementoPresel = New ElementosPreseleccionados
        Dim elementoBriefing As New ElementoBriefingItem
        Try
            elementoBriefing.idBriefing = myDetalleVuelo.idBriefing
            For Each r As DataRow In CommonProcess.GetElementoBriefingPorIdBriefing(elementoBriefing).Rows
                Dim elemento As New ElementoCatalogItem
                elementoPreselDetalle = New ElementosPreseleccionadosDetalle
                elemento = CommonData.GetElementoItem(r.Item("idElemento"))
                elementoPreselDetalle.idElemento = elemento.Id
                elementoPreselDetalle.descripcionAgencia = elemento.descripcionAgencia
                elementoPreselDetalle.descripcionTipo = CommonData.GetTipoElementoItem(elemento.tipoElemento).descripcionTipo
                elementoPreselDetalle.materialPiso = elemento.materialPiso
                elementoPreselDetalle.materialPared = elemento.materialPared
                elementoPreselDetalle.materialtecho = elemento.materialTecho
                elementoPreselDetalle.materialRed = elemento.materialRed
                elementoPreselDetalle.materialPuerta = elemento.materialPuerta
                elementoPreselDetalle.materialSeguros = elemento.materialSeguros
                elementoPreselDetalle.alto = elemento.alto
                elementoPreselDetalle.ancho = elemento.ancho
                elementoPreselDetalle.largo = elemento.largo
                elementoPreselDetalle.pesoReal = elemento.pesoReal
                elementoPreselDetalle.pesoRef = elemento.pesoReferencial
                elementoPreselDetalle.pesoActual = elemento.pesoActual
                elementoPreselDetalle.fechaLlegada = elemento.fechaIngresoPlataforma
                elementoPreselDetalle.fechaUltimaAct = elemento.fechaUltimaAct
                Dim tempContacto As New ContactoCatalogItem
                If r.Item("idContacto") <> String.Empty Then
                    tempContacto = CommonData.GetContactoItem(r.Item("idContacto"))
                End If
                elementoPreselDetalle.usuario = tempContacto.tagsa + " - " + tempContacto.primerApellido + " " + tempContacto.segundoApellido + " " + tempContacto.primerNombre
                elementoPresel.elementosPreseleccionadosDetalle.Add(elementoPreselDetalle)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub CargarRptCamiones()
        Try
            camionEncabezado = New CamionesEncabezado
            For Each r As DataRow In dtDetalleProcesoReporte.Rows
                If r.Item("estado") <> "R" Then
                    camionDetalle = New CamionesDetalle
                    camionDetalle.llegada = r.Item("fechaLlegadaCamion")
                    camionDetalle.agencia = r.Item("agenciaCargaCamion")
                    camionDetalle.placa = r.Item("matriculaCamion")
                    camionDetalle.presinto = r.Item("presinto")
                    camionDetalle.idChofer = r.Item("idContacto")
                    camionDetalle.chofer = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                    camionDetalle.bultos = r.Item("bultosCamion")
                    camionDetalle.temperatura = r.Item("temperatura")
                    camionDetalle.tipoEnvase = r.Item("descripcionTipo").ToString
                    camionDetalle.materialEnvase = r.Item("descripcionMaterial").ToString
                    camionDetalle.llegadaEstimadaGuia = r.Item("fechaLlegadaEstimadaGuia")
                    camionDetalle.inicioGuia = r.Item("horaIni")
                    camionDetalle.finGuia = r.Item("horaFin")
                    camionDetalle.guiaGuia = r.Item("guia")
                    camionDetalle.agenciaCargaGuia = r.Item("agenciaCargaGuia")
                    camionDetalle.productoGuia = r.Item("descripcionProducto")
                    camionDetalle.pizasGuia = r.Item("piezas")
                    camionDetalle.bultosGuia = r.Item("bultos")
                    camionDetalle.pesoGuia = r.Item("peso")
                    camionDetalle.dae = CommonProcess.GetGuiaPorIdGuia(r.Item("idGuia")).DAE
                    camionDetalle.muelle = r.Item("muelle").ToString.Substring(0, r.Item("muelle").ToString.Length - 3)
                    camionEncabezado.CamionesDetalle.Add(camionDetalle)
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarRptPersonalProceso()
        Try
            PersonalProceso = New PersonalProceso
            dtPersonalGeneral.Rows.Clear()
            dtPersonalAerolinea.Rows.Clear()
            dtPersonalAgenciaCarga.Rows.Clear()
            dtPersonalInstitucion.Rows.Clear()
            dtPersonalSeguridad.Rows.Clear()
            For Each r As DataRow In dtDetallePersonalProcesoReporte.Rows
                If r.Item("tipoAgencia").ToString = idTipoGeneral Then
                    Dim r2 As DataRow = dtPersonalGeneral.NewRow
                    r2.Item("orden") = 1
                    r2.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    r2.Item("cargo") = r.Item("cargo")
                    r2.Item("idContacto") = r.Item("idContacto")
                    r2.Item("primerNombreContacto") = r.Item("primerNombreContacto")
                    r2.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
                    r2.Item("primerApellidoContacto") = r.Item("tagsaContacto") + " - " + r.Item("primerApellidoContacto")
                    r2.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
                    r2.Item("horaInicio") = r.Item("horaInicio")
                    r2.Item("horaFin") = r.Item("horaFin")
                    Dim tempMuelle As String = r.Item("muelle")
                    r2.Item("muelle") = tempMuelle.ToString.Substring(0, tempMuelle.Length - 3)
                    dtPersonalGeneral.Rows.Add(r2)
                End If
            Next

            For Each r As DataRow In dtDetallePersonalProcesoReporte.Rows
                If r.Item("tipoAgencia").ToString = idTipoAgenciaCarga Then
                    Dim r2 As DataRow = dtPersonalAgenciaCarga.NewRow
                    r2.Item("orden") = 2
                    r2.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    r2.Item("cargo") = r.Item("cargo")
                    r2.Item("idContacto") = r.Item("idContacto")
                    r2.Item("primerNombreContacto") = r.Item("primerNombreContacto")
                    r2.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
                    r2.Item("primerApellidoContacto") = r.Item("tagsaContacto") + " - " + r.Item("primerApellidoContacto")
                    r2.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
                    r2.Item("horaInicio") = r.Item("horaInicio")
                    r2.Item("horaFin") = r.Item("horaFin")
                    Dim tempMuelle As String = r.Item("muelle")
                    r2.Item("muelle") = tempMuelle.ToString.Substring(0, tempMuelle.Length - 3)
                    dtPersonalAgenciaCarga.Rows.Add(r2)
                End If
            Next

            For Each r As DataRow In dtDetallePersonalProcesoReporte.Rows
                If r.Item("tipoAgencia").ToString = idTipoLineaAerea Then
                    Dim r2 As DataRow = dtPersonalAerolinea.NewRow
                    r2.Item("orden") = 3
                    r2.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    r2.Item("cargo") = r.Item("cargo")
                    r2.Item("idContacto") = r.Item("idContacto")
                    r2.Item("primerNombreContacto") = r.Item("primerNombreContacto")
                    r2.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
                    r2.Item("primerApellidoContacto") = r.Item("tagsaContacto") + " - " + r.Item("primerApellidoContacto")
                    r2.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
                    r2.Item("horaInicio") = r.Item("horaInicio")
                    r2.Item("horaFin") = r.Item("horaFin")
                    Dim tempMuelle As String = r.Item("muelle")
                    r2.Item("muelle") = tempMuelle.ToString.Substring(0, tempMuelle.Length - 3)
                    dtPersonalAerolinea.Rows.Add(r2)
                End If
            Next

            For Each r As DataRow In dtDetallePersonalProcesoReporte.Rows
                If r.Item("tipoAgencia").ToString = idTipoSeguridad Then
                    Dim r2 As DataRow = dtPersonalSeguridad.NewRow
                    r2.Item("orden") = 4
                    r2.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    r2.Item("cargo") = r.Item("cargo")
                    r2.Item("idContacto") = r.Item("idContacto")
                    r2.Item("primerNombreContacto") = r.Item("primerNombreContacto")
                    r2.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
                    r2.Item("primerApellidoContacto") = r.Item("tagsaContacto") + " - " + r.Item("primerApellidoContacto")
                    r2.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
                    r2.Item("horaInicio") = r.Item("horaInicio")
                    r2.Item("horaFin") = r.Item("horaFin")
                    Dim tempMuelle As String = r.Item("muelle")
                    r2.Item("muelle") = tempMuelle.ToString.Substring(0, tempMuelle.Length - 3)
                    dtPersonalSeguridad.Rows.Add(r2)
                End If
            Next

            For Each r As DataRow In dtDetallePersonalProcesoReporte.Rows
                If r.Item("tipoAgencia").ToString = idTipoInsituciones Then
                    Dim r2 As DataRow = dtPersonalInstitucion.NewRow
                    r2.Item("orden") = 5
                    r2.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    r2.Item("cargo") = r.Item("cargo")
                    r2.Item("idContacto") = r.Item("idContacto")
                    r2.Item("primerNombreContacto") = r.Item("primerNombreContacto")
                    r2.Item("segundoNombreContacto") = r.Item("segundoNombreContacto")
                    r2.Item("primerApellidoContacto") = r.Item("tagsaContacto") + " - " + r.Item("primerApellidoContacto")
                    r2.Item("segundoApellidoContacto") = r.Item("segundoApellidoContacto")
                    r2.Item("horaInicio") = r.Item("horaInicio")
                    r2.Item("horaFin") = r.Item("horaFin")
                    Dim tempMuelle As String = r.Item("muelle")
                    r2.Item("muelle") = tempMuelle.ToString.Substring(0, tempMuelle.Length - 3)
                    dtPersonalInstitucion.Rows.Add(r2)
                End If
            Next

            For Each r As DataRow In dtPersonalGeneral.Rows
                PersonalProcesoDetalle = New PersonalProcesoDetalle
                PersonalProcesoDetalle.orden = r.Item("orden")
                PersonalProcesoDetalle.agencia = r.Item("descripcionAgencia")
                PersonalProcesoDetalle.cargo = r.Item("cargo")
                PersonalProcesoDetalle.idContacto = r.Item("idContacto")
                PersonalProcesoDetalle.primerNombre = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                PersonalProcesoDetalle.segundoNombre = r.Item("segundoNombreContacto")
                PersonalProcesoDetalle.primerApellido = r.Item("primerApellidoContacto")
                PersonalProcesoDetalle.segundoApellido = r.Item("segundoApellidoContacto")
                PersonalProcesoDetalle.horaInicio = r.Item("horaInicio")
                PersonalProcesoDetalle.horaFin = r.Item("horaFin")
                PersonalProcesoDetalle.muelle = r.Item("muelle")
                PersonalProceso.PersonalProcesoDetalle.Add(PersonalProcesoDetalle)
            Next

            For Each r As DataRow In dtPersonalAgenciaCarga.Rows
                PersonalProcesoDetalle = New PersonalProcesoDetalle
                PersonalProcesoDetalle.orden = r.Item("orden")
                PersonalProcesoDetalle.agencia = r.Item("descripcionAgencia")
                PersonalProcesoDetalle.cargo = r.Item("cargo")
                PersonalProcesoDetalle.idContacto = r.Item("idContacto")
                PersonalProcesoDetalle.primerNombre = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                PersonalProcesoDetalle.segundoNombre = r.Item("segundoNombreContacto")
                PersonalProcesoDetalle.primerApellido = r.Item("primerApellidoContacto")
                PersonalProcesoDetalle.segundoApellido = r.Item("segundoApellidoContacto")
                PersonalProcesoDetalle.horaInicio = r.Item("horaInicio")
                PersonalProcesoDetalle.horaFin = r.Item("horaFin")
                PersonalProcesoDetalle.muelle = r.Item("muelle")
                PersonalProceso.PersonalProcesoDetalle.Add(PersonalProcesoDetalle)
            Next

            For Each r As DataRow In dtPersonalAerolinea.Rows
                PersonalProcesoDetalle = New PersonalProcesoDetalle
                PersonalProcesoDetalle.orden = r.Item("orden")
                PersonalProcesoDetalle.agencia = r.Item("descripcionAgencia")
                PersonalProcesoDetalle.cargo = r.Item("cargo")
                PersonalProcesoDetalle.idContacto = r.Item("idContacto")
                PersonalProcesoDetalle.primerNombre = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                PersonalProcesoDetalle.segundoNombre = r.Item("segundoNombreContacto")
                PersonalProcesoDetalle.primerApellido = r.Item("primerApellidoContacto")
                PersonalProcesoDetalle.segundoApellido = r.Item("segundoApellidoContacto")
                PersonalProcesoDetalle.horaInicio = r.Item("horaInicio")
                PersonalProcesoDetalle.horaFin = r.Item("horaFin")
                PersonalProcesoDetalle.muelle = r.Item("muelle")
                PersonalProceso.PersonalProcesoDetalle.Add(PersonalProcesoDetalle)
            Next

            For Each r As DataRow In dtPersonalSeguridad.Rows
                PersonalProcesoDetalle = New PersonalProcesoDetalle
                PersonalProcesoDetalle.orden = r.Item("orden")
                PersonalProcesoDetalle.agencia = r.Item("descripcionAgencia")
                PersonalProcesoDetalle.cargo = r.Item("cargo")
                PersonalProcesoDetalle.idContacto = r.Item("idContacto")
                PersonalProcesoDetalle.primerNombre = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                PersonalProcesoDetalle.segundoNombre = r.Item("segundoNombreContacto")
                PersonalProcesoDetalle.primerApellido = r.Item("primerApellidoContacto")
                PersonalProcesoDetalle.segundoApellido = r.Item("segundoApellidoContacto")
                PersonalProcesoDetalle.horaInicio = r.Item("horaInicio")
                PersonalProcesoDetalle.horaFin = r.Item("horaFin")
                PersonalProcesoDetalle.muelle = r.Item("muelle")
                PersonalProceso.PersonalProcesoDetalle.Add(PersonalProcesoDetalle)
            Next

            For Each r As DataRow In dtPersonalInstitucion.Rows
                PersonalProcesoDetalle = New PersonalProcesoDetalle
                PersonalProcesoDetalle.orden = r.Item("orden")
                PersonalProcesoDetalle.agencia = r.Item("descripcionAgencia")
                PersonalProcesoDetalle.cargo = r.Item("cargo")
                PersonalProcesoDetalle.idContacto = r.Item("idContacto")
                PersonalProcesoDetalle.primerNombre = r.Item("primerApellidoContacto") + " " + r.Item("primerNombreContacto")
                PersonalProcesoDetalle.segundoNombre = r.Item("segundoNombreContacto")
                PersonalProcesoDetalle.primerApellido = r.Item("primerApellidoContacto")
                PersonalProcesoDetalle.segundoApellido = r.Item("segundoApellidoContacto")
                PersonalProcesoDetalle.horaInicio = r.Item("horaInicio")
                PersonalProcesoDetalle.horaFin = r.Item("horaFin")
                PersonalProcesoDetalle.muelle = r.Item("muelle")
                PersonalProceso.PersonalProcesoDetalle.Add(PersonalProcesoDetalle)
            Next

        Catch ex As Exception
            General.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CargarRptProcesoAlmacenaje()
        Try
            ProcesoCargaAlmacenaje = New ProcesoCargaAlmacenaje
            For Each r As DataRow In dtDetalleProcesoCargaAlmacenaje.Rows
                ProcesoCargaAlmacenajeDetalle = New ProcesoCargaAlmacenajeDetalle
                ProcesoCargaAlmacenajeDetalle.fecha = r.Item("fecha")
                ProcesoCargaAlmacenajeDetalle.horaInicio = r.Item("horaIni")
                ProcesoCargaAlmacenajeDetalle.horaFin = r.Item("horaFin")
                ProcesoCargaAlmacenajeDetalle.agencia = r.Item("agenciaCargaGuia")
                ProcesoCargaAlmacenajeDetalle.guia = r.Item("guia")
                ProcesoCargaAlmacenajeDetalle.elemento = r.Item("idElemento")
                ProcesoCargaAlmacenajeDetalle.producto = r.Item("descripcionProducto")
                ProcesoCargaAlmacenajeDetalle.tempA = r.Item("tempA")
                ProcesoCargaAlmacenajeDetalle.tempA_3_4 = r.Item("tempA_3_4")
                ProcesoCargaAlmacenajeDetalle.tempB = r.Item("tempB")
                ProcesoCargaAlmacenajeDetalle.tempC = r.Item("tempC")
                ProcesoCargaAlmacenajeDetalle.tempZ_Flor = r.Item("tempZ_Flor")
                ProcesoCargaAlmacenajeDetalle.tempZ_Pq = r.Item("tempZ_Pq")
                ProcesoCargaAlmacenajeDetalle.bultos = r.Item("bultos")
                ProcesoCargaAlmacenajeDetalle.estado = r.Item("estado")
                ProcesoCargaAlmacenajeDetalle.peso = r.Item("peso")
                ProcesoCargaAlmacenajeDetalle.piezas = r.Item("piezas")
                ProcesoCargaAlmacenajeDetalle.RegCargaCuartoFrio = r.Item("RegCargaCuartoFrio")
                ProcesoCargaAlmacenajeDetalle.UsusarioIngreso = r.Item("UsusarioIngreso")
                For Each r2 As DataRow In dtComparacionPeso.Rows
                    If r.Item("idElemento") = r2.Item("idElemento") And r2.Item("estado") = "A" Then
                        ProcesoCargaAlmacenajeDetalle.cpPesoElemento = r2.Item("pesoEntradaElemento")
                        ProcesoCargaAlmacenajeDetalle.cpPesoCaptura = r2.Item("pesoCaptura")
                        ProcesoCargaAlmacenajeDetalle.cpPesoCarga = r2.Item("pesoCarga")
                        ProcesoCargaAlmacenajeDetalle.cpPesoDescarga = r2.Item("pesoDescarga")
                        ProcesoCargaAlmacenajeDetalle.cpPesoDiferencia = r2.Item("pesoDiferencia")
                        ProcesoCargaAlmacenajeDetalle.cpPesoTotal = r2.Item("pesoCaptura") + r2.Item("pesoEntradaElemento")
                        ProcesoCargaAlmacenajeDetalle.cpUser = r2.Item("usuarioComparacionPeso")
                    End If
                Next
                ProcesoCargaAlmacenaje.ProcesoCargaAlmacenajeDetalle.Add(ProcesoCargaAlmacenajeDetalle)
            Next
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub CargarRptDetalleAcarreo()
        Try
            Acarreo = New Acarreo
            For Each r As DataRow In dtDetalleAcarreoReporte.Rows
                DetalleAcarreo = New DetalleAcarreo
                DetalleAcarreo.ingreso = r.Item("fechaEntrada")
                DetalleAcarreo.salida = r.Item("fechaSalida")
                DetalleAcarreo.dolly = r.Item("dolly")
                DetalleAcarreo.chofer = r.Item("tagsaChofer") + " - " + r.Item("apellidoChofer") + " " + r.Item("nombreChofer")
                DetalleAcarreo.custodio = r.Item("tagsaCustodio") + " - " + r.Item("apellidoCustodio") + " " + r.Item("nombreCustodio")
                DetalleAcarreo.elemento = r.Item("idElemento")
                DetalleAcarreo.peso = r.Item("peso")
                DetalleAcarreo.agencia = r.Item("descripcionAgencia")
                Acarreo.detalleAcarreo.Add(DetalleAcarreo)
            Next
            For Each o In Acarreo.detalleAcarreo
                For Each r As DataRow In dtDetalleProcesoCargaElementosCargados.Rows
                    If o.elemento = r.Item("idElemento") Then
                        o.peso = 0
                        If r.Item("estado") = "A" Or r.Item("estado") = "R" Then
                            o.peso += r.Item("peso")
                        End If
                    End If
                Next
            Next

            For Each r In ProcesoCargaAlmacenaje.ProcesoCargaAlmacenajeDetalle
                For Each r2 In dtDetalleAcarreoReporte.Rows
                    If r.elemento = r2.item("idElemento") Then
                        r.horaInicio = r2.item("fechaSalida")
                    End If
                Next
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            ' MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    '    Dim result As Boolean = False
    '    Dim req As New NovedadesRequest
    '    Dim novedadesItem As New NovedadesItem
    '    Dim res As New NovedadesResponse
    '    Dim WsClnt As New ProcesoServiceSoapClient
    '    Try
    '        General.SetBARequest(req)
    '        If myProceso.IdProceso <> Guid.Empty Then
    '            novedadesItem.idProceso = myProceso.IdProceso
    '            novedadesItem.llegada = udtLlegadaAvion.Value
    '            novedadesItem.salida = udtSalidaAvion.Value
    '            novedadesItem.subeDesde = udtSubeCargaDesde.Value
    '            novedadesItem.subeHasta = udtSubeCargaHasta.Value
    '            novedadesItem.observacion = txtObs.Text
    '            req.myNovedadesItem = novedadesItem
    '            res = WsClnt.SaveNovedadesItem(req)
    '        End If
    '        If res.ActionResult Then
    '            MessageBox.Show("Registro actualizado con éxito!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            Throw New Exception(res.ErrorMessage)
    '        End If
    '    Catch ex As Exception
    '        General.SetLogEvent(ex)
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub CargarRptProcesoElementosCargados()
        ElementosCargados = New ElementosCargados
        Try
            For Each r As DataRow In dtDetalleProcesoCargaElementosCargados.Rows
                ElementosCargadosDetalle = New ElementosCargadosDetalle
                ElementosCargadosDetalle.fecha = r.Item("fecha")
                ElementosCargadosDetalle.horaIni = r.Item("horaIni")
                ElementosCargadosDetalle.horaFin = r.Item("horaFin")
                ElementosCargadosDetalle.guia = r.Item("guia")
                ElementosCargadosDetalle.agenciaCargaGuia = r.Item("agenciaCargaGuia")
                ElementosCargadosDetalle.idGuia = r.Item("idGuia")
                ElementosCargadosDetalle.idElemento = r.Item("idElemento")
                ElementosCargadosDetalle.agenciaElemento = r.Item("agenciaElemento")
                ElementosCargadosDetalle.ciudadDestino = r.Item("ciudadDestino")
                ElementosCargadosDetalle.bultos = r.Item("bultos")
                ElementosCargadosDetalle.peso = r.Item("peso")
                ElementosCargadosDetalle.piezas = r.Item("piezas")
                ElementosCargadosDetalle.tempProm = r.Item("temperaturaProm")
                ElementosCargadosDetalle.estado = r.Item("estado")
                ElementosCargadosDetalle.tipoEnvase = r.Item("descripcionTipo")
                ElementosCargadosDetalle.materialEnvase = r.Item("descripcionMaterial")
                ElementosCargados.ElementosCargadosDetalle.Add(ElementosCargadosDetalle)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub iniciarTodo()
        Try
            'btnConsVuelo.Select()
            With dtCamiones.Columns
                .Add("idGuia", GetType(Guid))
                .Add("descripcion", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("idCamion", GetType(Guid))
                .Add("matriculaCamion", GetType(String))
                .Add("fecha", GetType(DateTime))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("procedencia", GetType(String))
                .Add("indice", GetType(Guid))
            End With
            'ugvCamiones.DataSource = dtCamiones
            'SetDisplayColumnsCamiones()


            With dtDollys.Columns
                .Add("idDetalle", GetType(Guid))
                .Add("idAcarreo", GetType(String))
                .Add("idDolly", GetType(Guid))
                .Add("dolly", GetType(String))
                .Add("idChofer", GetType(String))
                .Add("chofer", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("agencia", GetType(String))
                .Add("idCustodio", GetType(Guid))
                .Add("custodio", GetType(String))
                .Add("idAgenciaSeguridad", GetType(String))
                .Add("agenciaSeguridad", GetType(String))
                .Add("fechaEntrada", GetType(DateTime))
                .Add("fechaSalida", GetType(DateTime))
                .Add("estado", GetType(String))
            End With
            ' ugvDollys.DataSource = dtDollys
            ' SetDisplayColumnsDollys()



            With dtPersonalProceso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("idMatrizSeg", GetType(Guid))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("idAgencia", GetType(Guid))
                .Add("idTipo", GetType(Guid))
                .Add("descripcionTipo", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idPersona", GetType(String))
                .Add("descripcionAgencia", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
            End With
            ' ugvProceso.DataSource = dtPersonalProceso
            ' SetDisplayColumnsPersonal()

            With dtGuias.Columns
                .Add("idGuia", GetType(Guid))
                .Add("descripcion", GetType(String))
                .Add("idBriefing", GetType(Guid))
                .Add("ciudadDestino", GetType(String))
                .Add("idAgencia", GetType(Guid))
                .Add("idProducto", GetType(Guid))
                .Add("producto", GetType(String))
                .Add("descripcionAgencia", GetType(String))
                .Add("peso", GetType(Double))
                .Add("bultos", GetType(Integer))
                .Add("fechaLlegada", GetType(DateTime))
                .Add("estado", GetType(String))
                .Add("DAE", GetType(String))
                .Add("camionAsig", GetType(Boolean))
                .Add("fechaAct", GetType(DateTime))
                .Add("usuarioAct", GetType(String))
            End With

            With dtDetalleProceso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("volumen", GetType(Double))
                .Add("hora", GetType(DateTime))
                .Add("idProducto", GetType(Guid))
                .Add("estado", GetType(String))
                .Add("idPosicion", GetType(Guid))
                .Add("temperatura", GetType(Integer))
                .Add("rx", GetType(Boolean))
                .Add("man", GetType(Boolean))
                .Add("k9", GetType(Boolean))
                .Add("eds", GetType(Boolean))
                .Add("largo", GetType(Integer))
                .Add("ancho", GetType(Integer))
                .Add("alto", GetType(Integer))
                .Add("tempA", GetType(Double))
                .Add("tempA_3_4", GetType(Double))
                .Add("tempB", GetType(Double))
                .Add("tempC", GetType(Double))
                .Add("tempZ_Flor", GetType(Double))
                .Add("tempZ_Pq", GetType(Double))
                .Add("idCamion", GetType(Guid))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
                .Add("UsusarioIngreso", GetType(String))
            End With

            With dtdetalleProcesoTemp.Columns
                .Add("idProceso", GetType(Guid))
                .Add("fecha", GetType(DateTime))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("bultos", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("volumen", GetType(Double))
                .Add("hora", GetType(DateTime))
                .Add("idProducto", GetType(Guid))
                .Add("estado", GetType(String))
                .Add("idPosicion", GetType(Guid))
                .Add("temperatura", GetType(Integer))
                .Add("rx", GetType(Boolean))
                .Add("man", GetType(Boolean))
                .Add("k9", GetType(Boolean))
                .Add("eds", GetType(Boolean))
                .Add("largo", GetType(Integer))
                .Add("ancho", GetType(Integer))
                .Add("alto", GetType(Integer))
                .Add("tempA", GetType(Integer))
                .Add("tempB", GetType(Integer))
                .Add("tempC", GetType(Integer))
                .Add("idCamion", GetType(Guid))
                .Add("muelle", GetType(String))
                .Add("indice", GetType(Guid))
            End With

            With dtPersonalGeneral.Columns
                .Add("orden", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("segundoNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("segundoApellidoContacto", GetType(String))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("muelle", GetType(String))
            End With

            With dtPersonalAgenciaCarga.Columns
                .Add("orden", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("segundoNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("segundoApellidoContacto", GetType(String))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("muelle", GetType(String))
            End With

            With dtPersonalAerolinea.Columns
                .Add("orden", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("segundoNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("segundoApellidoContacto", GetType(String))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("muelle", GetType(String))
            End With

            With dtPersonalSeguridad.Columns
                .Add("orden", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("segundoNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("segundoApellidoContacto", GetType(String))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("muelle", GetType(String))
            End With

            With dtPersonalInstitucion.Columns
                .Add("orden", GetType(Integer))
                .Add("descripcionAgencia", GetType(String))
                .Add("cargo", GetType(String))
                .Add("idContacto", GetType(String))
                .Add("primerNombreContacto", GetType(String))
                .Add("segundoNombreContacto", GetType(String))
                .Add("primerApellidoContacto", GetType(String))
                .Add("segundoApellidoContacto", GetType(String))
                .Add("horaInicio", GetType(DateTime))
                .Add("horaFin", GetType(DateTime))
                .Add("muelle", GetType(String))
            End With

            With dtChequeoPan.Columns
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("producto", GetType(String))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Decimal))
                .Add("man", GetType(Integer))
            End With

            With dtTotalElementos.Columns
                .Add("elemento", GetType(String))
                .Add("totalBultos", GetType(Integer))
                .Add("totalPiezas", GetType(Integer))
                .Add("pesoReal", GetType(Double))
                .Add("pesoVolumen", GetType(Double))
                .Add("idDolly", GetType(Guid))
                .Add("dolly", GetType(String))
                .Add("idDetalleAcarreoElemento", GetType(Guid))
            End With
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
