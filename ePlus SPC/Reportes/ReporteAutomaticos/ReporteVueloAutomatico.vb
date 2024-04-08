Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.Server.ProcesoService

Public Class ReporteVueloAutomatico
    Dim Dt_VuelosHoy As New DataTable("Dt_VuelosHoy")
    Dim Dt_LoadDataTable As New DataTable("Dt_LoadDataTable")
    Dim dtDetalleProcesoReporte As New DataTable("detalleProcesosReporte")
    Dim dtDetalleProceso As New DataTable("Procesos")
    Dim dtPersonalGeneral As New DataTable("General")
    Dim dtPersonalAgenciaCarga As New DataTable("AgenciaCarga")
    Dim dtPersonalAerolinea As New DataTable("Aerolinea")
    Dim dtPersonalSeguridad As New DataTable("Seguridad")
    Dim dtPersonalInstitucion As New DataTable("Institucion")
    Dim dtPersonalExportador As New DataTable("Exportador")
    Dim dtPersonalProceso As New DataTable("PersonalProceso")
    Dim dtGuias As New DataTable("Guias")
    Dim dtdetalleProcesoTemp As New DataTable("ProcesosTemp")
    Dim dtChequeoPan As New DataTable("ChequeoPan")
    Dim dtTotalElementos As New DataTable("TotalElementos")
    Dim dtDetallePersonalProcesoReporte As New DataTable("detallePersonalProcesoReporte")
    Dim dtDetalleProcesoCargaReporte As New DataTable("detalleProcesoCargaReporte")
    Dim dtDetalleProcesoCargaReporteCargaI As New DataTable("detalleProcesoCargaReporteCargaI")
    Dim dtDetalleProcesoCargaReporteCargaR As New DataTable("detalleProcesoCargaReporteCargaR")
    Dim dtDetalleProcesoCargaAlmacenaje As New DataTable("detalleProcesoCargaReporte")
    Dim dtComparacionPeso As New DataTable("comparacionPeso")
    Dim dtDetalleProcesoCargaElementosCargados As New DataTable("detalleProcesoCargaReporteElementosCargados")
    Dim dtDetalleAcarreoReporte As New DataTable("detalleAcarreoReporte")
    Dim dtStackPallet As New DataTable("stack")
    Dim briefingDetalle As New BriefingDetalle
    Dim elementoPresel As New ElementosPreseleccionados
    Dim elementoPreselDetalle As New ElementosPreseleccionadosDetalle
    Dim camionEncabezado As New CamionesEncabezado
    Dim briefingEncabezado As New BriefingEncabezado
    Dim ProcesoCargaDetalle As New ProcesoCargaDetalle
    Dim ProcesoCargaDetalle2 As New ProcesoCargaDetalle2
    Dim PersonalProceso As New PersonalProceso
    Dim ProcesoCarga As New ProcesoCarga
    Dim ProcesoCarga2 As New ProcesoCarga2
    Dim camionDetalle As New CamionesDetalle
    Dim elementosCargados As New ElementosCargados
    Dim elementosCargadosDetalle As New ElementosCargadosDetalle
    Dim PersonalProcesoDetalle As New PersonalProcesoDetalle
    Dim DetalleAcarreo As New DetalleAcarreo
    Dim Acarreo As New Acarreo
    Dim myNovedades As New Novedades
    Dim myProceso As New ProcesoItem
    Dim ProcesoCargaAlmacenajeDetalle As New ProcesoCargaAlmacenajeDetalle
    Dim ProcesoCargaAlmacenaje As New ProcesoCargaAlmacenaje
    Dim resDtVuelo As DetalleVuelo
    Dim totPesoCargaA As Decimal = 0D
    Dim totPesoCargaI As Decimal = 0D
    Dim totPesoCargaR As Decimal = 0D
    Dim totPesoCargaD As Decimal = 0D
    Dim totPesoCargaC As Decimal = 0D
    Dim tempPesoReal As Decimal = 0D
    Dim tempCantidadCarga As Integer = 0
    Dim tempCantidadGuias As Integer = 0
    Dim cargaHoraInicio As DateTime = Now()
    Dim cargaHoraFin As DateTime = Convert.ToDateTime("1000-01-01")
    Dim idTipoGeneral As String = "38b4e437-f3dd-4625-8e73-538858824fce"
    Dim idTipoAgenciaCarga As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"
    Dim idTipoLineaAerea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim idTipoSeguridad As String = "d68cfbd1-0c3d-4b77-9018-7e190f8b74e8"
    Dim idTipoInsituciones As String = "9cf3597e-0d79-4498-8d58-5889045c3729"
    Dim EXPORTADOR As String = "EXPORTADOR"
    Private Shared ReporteVueloAutomatico As ReporteVueloAutomatico
    Public Property CicloEjecu As Boolean = True
    Dim ExecuteHilo As Boolean = False
    Dim TablasCradas As Boolean = False
    Dim thrEjecutarReportAuto As Threading.Thread
    Private PuntoEjecucion As String
    Private ClassControlEjecucionHilo As New ControlEjecucionHilo
    Public Property Users As String
    Public Shared Function Instancia() As ReporteVueloAutomatico
        If ReporteVueloAutomatico Is Nothing Then
            ReporteVueloAutomatico = New ReporteVueloAutomatico
        End If
        Return ReporteVueloAutomatico
    End Function
    Public Sub EjecutarHilo()
        obtenerDatosHost()
        If TablasCradas = False Then
            CrearTabla()
            TablasCradas = True
        End If
        ClassControlEjecucionHilo.Tipo = "C"
        ClassControlEjecucionHilo.NombreControl = "HiloReportVueloAuto"
        ClassControlEjecucionHilo = CommonProcess.Sp_MantControlEjecutHilo(ClassControlEjecucionHilo)
        If ExecuteHilo = False And IsNothing(ClassControlEjecucionHilo.Estado) Then
            thrEjecutarReportAuto = New Threading.Thread(AddressOf EjecutaProcesoReport)
            thrEjecutarReportAuto.IsBackground = True
            thrEjecutarReportAuto.Start()
            Threading.Thread.Sleep(60)
            ExecuteHilo = True
            With ClassControlEjecucionHilo
                ClassControlEjecucionHilo.Tipo = "I"
                ClassControlEjecucionHilo.UsuarioIngresoControl = Users
                ClassControlEjecucionHilo.NombreControl = "HiloReportVueloAuto"
                ClassControlEjecucionHilo.PuntoEjecucion = PuntoEjecucion
            End With
            ClassControlEjecucionHilo = CommonProcess.Sp_MantControlEjecutHilo(ClassControlEjecucionHilo)
            With ClassControlEjecucionHilo
                ClassControlEjecucionHilo.Tipo = "C"
                ClassControlEjecucionHilo.UsuarioIngresoControl = Users
                ClassControlEjecucionHilo.NombreControl = "HiloReportVueloAuto"
                ClassControlEjecucionHilo.PuntoEjecucion = PuntoEjecucion
            End With
            ClassControlEjecucionHilo = CommonProcess.Sp_MantControlEjecutHilo(ClassControlEjecucionHilo)
        End If
    End Sub
    Private Sub EjecutaProcesoReport()
        While CicloEjecu
            CargarDatosInicial()
            EnviarReporteVuelo()
            Threading.Thread.Sleep(600000)
        End While
    End Sub
    Public Sub CargarDatosInicial()
        Dim row As DataRow
        Dim IngReg As Boolean = True
        Dt_LoadDataTable = CargarVuelosDia()
        If Dt_VuelosHoy.Rows.Count >= 300 Then
            Dt_VuelosHoy.Clear()
        End If
        If Dt_LoadDataTable.Rows.Count > 0 Then
            For Each r As DataRow In Dt_LoadDataTable.Rows
                If Dt_VuelosHoy.Rows.Count > 0 Then
                    For Each rows As DataRow In Dt_VuelosHoy.Rows
                        If r.Item("idBriefing") = rows.Item("idBriefing") And r.Item("idVuelo") = rows.Item("idVuelo") Then
                            IngReg = False
                        End If
                    Next
                End If
                If IngReg Then
                    row = Dt_VuelosHoy.NewRow
                    row.Item("idBriefing") = r.Item("idBriefing")
                    row.Item("idVuelo") = r.Item("idVuelo")
                    row.Item("idAgencia") = r.Item("idAgencia")
                    row.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    row.Item("codigoVuelo") = r.Item("codigoVuelo")
                    row.Item("fechaVuelo") = r.Item("fechaVuelo")
                    row.Item("llegadaVuelo") = r.Item("llegadaVuelo")
                    row.Item("salidaVuelo") = r.Item("salidaVuelo")
                    row.Item("enviaVuelo") = r.Item("enviaVuelo")
                    row.Item("recibeVuelo") = r.Item("recibeVuelo")
                    row.Item("estadoVuelo") = r.Item("estadoVuelo")
                    row.Item("briefingVuelo") = r.Item("briefingVuelo")
                    row.Item("idAvion") = r.Item("idAvion")
                    row.Item("idMatriz") = r.Item("idMatriz")
                    row.Item("ciudadOrigen") = r.Item("ciudadOrigen")
                    row.Item("aeropuertoOrigen") = r.Item("aeropuertoOrigen")
                    row.Item("ciudadLlegada") = r.Item("ciudadLlegada")
                    row.Item("aeropuertoLlegada") = r.Item("aeropuertoLlegada")
                    row.Item("descripcion") = r.Item("descripcion")
                    row.Item("descripcionAvion") = r.Item("descripcionAvion")
                    row.Item("matriculaAvion") = r.Item("matriculaAvion")
                    row.Item("EstadoProceso") = "A"
                    Dt_VuelosHoy.Rows.Add(row)
                End If
                IngReg = True
            Next
        End If
    End Sub
    Public Sub AbortarHilo()
        Try
            If ExecuteHilo Then
                thrEjecutarReportAuto.Abort()
                While True
                    thrEjecutarReportAuto.Abort()
                    If thrEjecutarReportAuto.IsAlive = False Then
                        With ClassControlEjecucionHilo
                            ClassControlEjecucionHilo.Tipo = "D"
                            ClassControlEjecucionHilo.UsuarioIngresoControl = Users
                            ClassControlEjecucionHilo.NombreControl = "HiloReportVueloAuto"
                            ClassControlEjecucionHilo.PuntoEjecucion = PuntoEjecucion
                        End With
                        ClassControlEjecucionHilo = CommonProcess.Sp_MantControlEjecutHilo(ClassControlEjecucionHilo)
                        Exit While
                    End If
                    Threading.Thread.Sleep(300)
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub obtenerDatosHost()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        PuntoEjecucion = hostInfo.HostName.ToString
    End Sub
    Private Sub CrearTabla()
        With Dt_VuelosHoy.Columns
            .Add("idBriefing", GetType(Guid))
            .Add("idVuelo", GetType(Guid))
            .Add("idAgencia", GetType(Guid))
            .Add("descripcionAgencia", GetType(String))
            .Add("codigoVuelo", GetType(String))
            .Add("fechaVuelo", GetType(Date))
            .Add("llegadaVuelo", GetType(Date))
            .Add("salidaVuelo", GetType(Date))
            .Add("enviaVuelo", GetType(String))
            .Add("recibeVuelo", GetType(String))
            .Add("estadoVuelo", GetType(String))
            .Add("briefingVuelo", GetType(Date))
            .Add("idAvion", GetType(Guid))
            .Add("idMatriz", GetType(Guid))
            .Add("ciudadOrigen", GetType(Guid))
            .Add("aeropuertoOrigen", GetType(Guid))
            .Add("ciudadLlegada", GetType(Guid))
            .Add("aeropuertoLlegada", GetType(Guid))
            .Add("descripcion", GetType(String))
            .Add("descripcionAvion", GetType(String))
            .Add("matriculaAvion", GetType(String))
            .Add("EstadoProceso", GetType(String))
        End With
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
            .Add("RegCargaCuartoFrio", GetType(String))
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
            .Add("tempA", GetType(Double))
            .Add("tempA_3_4", GetType(Double))
            .Add("tempB", GetType(Double))
            .Add("tempC", GetType(Double))
            .Add("tempZ_Flor", GetType(Double))
            .Add("tempZ_Pq", GetType(Double))
            .Add("idCamion", GetType(Guid))
            .Add("muelle", GetType(String))
            .Add("indice", GetType(Guid))
            .Add("RegCargaCuartoFrio", GetType(String))
            .Add("UsusarioIngreso", GetType(String))
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
        With dtPersonalExportador.Columns
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
        TablasCradas = True
    End Sub
    Private Function CargarVuelosDia() As DataTable
        Dim wsClient As New VuelosServiceSoapClient
        Dim req As New DetalleVueloRequest
        Dim res As New DetalleVueloResponse
        Dim dtVuelo As New DetalleVuelo
        Dim result As New DataTable("Dt_VuelosHoy")
        Try
            General.SetBARequest(req)
            req.myDetalleVuelo = dtVuelo
            res = wsClient.obtenerdetalleVueloPorFechaHoy2(req)
            If res.ActionResult Then
                result = res.DsResult.Tables(0)
                If result.Rows.Count = 0 Then
                    MessageBox.Show("No existen Vuelos Ingresados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function
    Private Sub EnviarReporteVuelo()
        Try
            Dim FechaEnvio As DateTime
            Dim ClassReportVueloEnvi As New ReportVuelosEnviados
            For Each r As DataRow In Dt_VuelosHoy.Rows
                dtPersonalProceso.Clear()
                dtGuias.Clear()
                dtDetalleProceso.Clear()
                dtdetalleProcesoTemp.Clear()
                dtPersonalGeneral.Clear()
                dtPersonalAgenciaCarga.Clear()
                dtPersonalAerolinea.Clear()
                dtPersonalSeguridad.Clear()
                dtPersonalInstitucion.Clear()
                dtChequeoPan.Clear()
                dtTotalElementos.Clear()
                dtPersonalExportador.Clear()
                briefingEncabezado = Nothing
                elementoPresel = Nothing
                camionEncabezado = Nothing
                PersonalProceso = Nothing
                ProcesoCarga = Nothing
                ProcesoCarga2 = Nothing
                ProcesoCargaAlmacenaje = Nothing
                elementosCargados = Nothing
                Acarreo = Nothing
                With ClassReportVueloEnvi
                    .IdBriefing = r.Item("idBriefing")
                    .IdVuelo = r.Item("IdVuelo")
                    .Tipo = "C"
                End With
                ClassReportVueloEnvi = CommonProcess.Sp_RegReporteVuelosEnviados(ClassReportVueloEnvi)
                If consultaProceso(r.Item("idBriefing")) And ClassReportVueloEnvi.Result = True And ClassReportVueloEnvi.Total = 0 And r.Item("EstadoProceso") = "A" Then
                    CargarRptNovedades()
                    FechaEnvio = myNovedades.salida
                    FechaEnvio = FechaEnvio.AddMinutes(15)
                    If Date.Now >= FechaEnvio Then
                        Dim Datos As New DetalleVuelo
                        With Datos
                            .codigoVuelo = r.Item("codigoVuelo")
                            .descripcionAgencia = r.Item("descripcionAgencia")
                            .matriculaAvion = r.Item("matriculaAvion")
                            .descripcionAvion = r.Item("descripcionAvion")
                            .llegadaVuelo = r.Item("llegadaVuelo")
                            .salidaVuelo = r.Item("salidaVuelo")
                        End With
                        obtenerDetalleVuelo(r.Item("idBriefing"))
                        Datos.enviaVuelo = resDtVuelo.enviaVuelo
                        Datos.recibeVuelo = resDtVuelo.recibeVuelo
                        CargarRptBriefing(r.Item("idBriefing"), Datos)
                        CargarRptCamiones()
                        CargarRptPersonalProceso()
                        CargarRptProcesoAlmacenaje()
                        CargarRptProcesoElementosCargados()
                        CargarRptDetalleAcarreo()
                        CargarRptProcesoCarga()

                        CargarRptElementosPresel(r.Item("idBriefing"))
                        Dim frm As New RptReportFlights()
                        frm.briefingEncabezado.Add(briefingEncabezado)
                        frm.briefingDetalle = briefingEncabezado.briefingDetalle

                        frm.ElementoPresel.Add(elementoPresel)
                        frm.ElementoPreselDetalle = elementoPresel.elementosPreseleccionadosDetalle

                        frm.camionesEncabezado.Add(camionEncabezado)
                        frm.camionesDetalle = camionEncabezado.CamionesDetalle

                        frm.PersonalProceso.Add(PersonalProceso)
                        frm.PersonalProcesoDetalle = PersonalProceso.PersonalProcesoDetalle

                        frm.ProcesoCarga.Add(ProcesoCarga)
                        frm.ProcesoCargaDetalle = ProcesoCarga.ProcesoCargaDetalle

                        frm.ProcesoCarga2.Add(ProcesoCarga2)
                        frm.ProcesoCargaDetalle2 = ProcesoCarga2.ProcesoCargaDetalle2

                        frm.ProcesoCargaAlmacenaje.Add(ProcesoCargaAlmacenaje)
                        frm.ProcesoCargaAlmacenajeDetalle = ProcesoCargaAlmacenaje.ProcesoCargaAlmacenajeDetalle

                        frm.ElementoCargado.Add(elementosCargados)
                        frm.ElementoCargadoDetalle = elementosCargados.ElementosCargadosDetalle

                        frm.Acarreo.Add(Acarreo)
                        frm.DetalleAcarreo = Acarreo.detalleAcarreo

                        frm.Novedades.Add(myNovedades)
                        frm.idAgenciaReport = resDtVuelo.idAgencia
                        frm.vuelo = r.Item("codigoVuelo")
                        frm.aerolinea = r.Item("descripcionAgencia")
                        frm.guardarReporte()
                        If frm.result Then
                            'MessageBox.Show("Correo eviado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            With ClassReportVueloEnvi
                                .IdBriefing = r.Item("idBriefing")
                                .IdVuelo = r.Item("IdVuelo")
                                .Tipo = "I"
                            End With
                            ClassReportVueloEnvi = CommonProcess.Sp_RegReporteVuelosEnviados(ClassReportVueloEnvi)
                            r.Item("EstadoProceso") = "P"
                        Else
                            MessageBox.Show("Error al enviar correo. Por favor reintentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                ElseIf ClassReportVueloEnvi.Total = 1 And r.Item("EstadoProceso") = "A" Then
                    r.Item("EstadoProceso") = "P"
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarRptBriefing(idBriefing As Guid, datos As DetalleVuelo)
        Try
            briefingEncabezado = New BriefingEncabezado
            Dim envia As New Server.ReportService.ContactoCatalogItem
            Dim recibe As New Server.ReportService.ContactoCatalogItem
            briefingEncabezado.numeroVuelo = datos.codigoVuelo
            briefingEncabezado.aerolinea = datos.descripcionAgencia
            briefingEncabezado.fechaRecibido = myProceso.fechaInicio
            briefingEncabezado.fechaVuelo = datos.fechaVuelo
            envia = CommonData.GetContactoItem(datos.enviaVuelo)
            briefingEncabezado.envia = envia.primerApellido + " " + envia.primerNombre
            recibe = CommonData.GetContactoItem(datos.recibeVuelo)
            briefingEncabezado.recibe = recibe.primerApellido + " " + recibe.primerNombre
            briefingEncabezado.matriculaAvion = datos.matriculaAvion
            briefingEncabezado.tipoAvion = datos.descripcionAvion
            briefingEncabezado.eta = datos.llegadaVuelo
            briefingEncabezado.etd = datos.salidaVuelo

            For Each r As DataRow In dtGuias.Rows
                briefingDetalle = New BriefingDetalle
                briefingDetalle.horaEstimada = r.Item("fechaLlegada")
                briefingDetalle.agencia = r.Item("descripcionAgencia")
                briefingDetalle.guia = r.Item("descripcion")
                briefingDetalle.destinoFinal = r.Item("ciudadDestino")
                briefingDetalle.producto = r.Item("producto")
                briefingDetalle.bultos = r.Item("bultos")
                briefingDetalle.peso = r.Item("peso")
                briefingDetalle.fecha = r.Item("fechaAct")
                Dim tempRecibe As New ContactoCatalogItem
                tempRecibe = CommonData.GetContactoItem(r.Item("UsuarioAct"))
                briefingDetalle.recibe = tempRecibe.primerApellido + " " + tempRecibe.primerNombre + " - " + tempRecibe.tagsa
                tempCantidadCarga = tempCantidadCarga + r.Item("peso")
                tempCantidadGuias = tempCantidadGuias + 1
                briefingEncabezado.briefingDetalle.Add(briefingDetalle)
            Next

            briefingEncabezado.estimadoDeCarga = tempCantidadCarga
            briefingEncabezado.cantidadGuias = tempCantidadGuias
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    totPesoCargaD += r.Item("peso")
                End If
                If r.Item("estado") = "C" Then
                    totPesoCargaC += r.Item("peso")
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
                If r.Item("estado") <> "C" Then
                    tempPesoReal += r.Item("peso")
                End If
                If r.Item("volumen") < r.Item("peso") Then
                    ProcesoCargaDetalle.volumen = r.Item("peso")
                Else
                    ProcesoCargaDetalle.volumen = r.Item("volumen")
                End If
                ProcesoCargaDetalle.rx = r.Item("rx")
                ProcesoCargaDetalle.man = r.Item("man")
                ProcesoCargaDetalle.k9 = r.Item("k9")
                ProcesoCargaDetalle.eds = r.Item("eds")
                ProcesoCargaDetalle.M = r.Item("muelle").ToString.Substring(0, 8).Remove(0, 6) 'MARZ
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
                    ProcesoCargaDetalle2.M = r.Item("muelle").ToString.Substring(0, 8).Remove(0, 6) 'MARZ 
                    ProcesoCargaDetalle2.CuartoFrio = r.Item("RegCargaCuartoFrio")
                    ProcesoCarga2.ProcesoCargaDetalle2.Add(ProcesoCargaDetalle2)

                    If ProcesoCargaDetalle2.horaInicio < cargaHoraInicio Then
                        cargaHoraInicio = ProcesoCargaDetalle2.horaInicio
                    End If
                    If ProcesoCargaDetalle2.horaFin > cargaHoraFin Then
                        cargaHoraFin = ProcesoCargaDetalle2.horaFin
                    End If
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function consultaProceso(idBriefing As Guid) As Boolean
        Dim result As Boolean = False
        Try
            myProceso = CommonProcess.GetProcesoPoridBriefing(idBriefing)
            If Not myProceso Is Nothing Then
                Dim nr As DataRow
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
            If dtDetalleProceso.Rows.Count = 0 Then
                result = False
            Else
                result = True
            End If
        Catch ex As Exception
            result = False
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function
    Private Sub CargarRptElementosPresel(idBriefing As Guid)
        elementoPresel = New ElementosPreseleccionados
        Dim elementoBriefing As New Server.VuelosService.ElementoBriefingItem
        Try
            elementoBriefing.idBriefing = idBriefing
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim ExportadorRows() As DataRow
            ExportadorRows = dtDetallePersonalProcesoReporte.Select("descripcionAgencia = '" & "EXPORTADOR" & "'")
            For Each r As DataRow In ExportadorRows
                Dim r2 As DataRow = dtPersonalExportador.NewRow
                r2.Item("orden") = 6
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
                dtPersonalExportador.Rows.Add(r2)
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

            For Each r As DataRow In dtPersonalExportador.Rows
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarRptProcesoElementosCargados()
        elementosCargados = New ElementosCargados
        Try
            Dim dtGuiaCamiones As DataTable
            For Each r As DataRow In dtDetalleProcesoCargaElementosCargados.Rows
                elementosCargadosDetalle = New ElementosCargadosDetalle
                Dim tempGuia As New Server.VuelosService.GuiaCamionesItem
                tempGuia.idGuia = r.Item("idGuia")
                dtGuiaCamiones = CommonProcess.GetGuiaCamionesPorId(tempGuia)
                elementosCargadosDetalle.fecha = r.Item("fecha")
                elementosCargadosDetalle.horaIni = r.Item("horaIni")
                elementosCargadosDetalle.horaFin = r.Item("horaFin")
                elementosCargadosDetalle.guia = r.Item("guia")
                elementosCargadosDetalle.agenciaCargaGuia = r.Item("agenciaCargaGuia")
                elementosCargadosDetalle.idGuia = r.Item("idGuia")
                elementosCargadosDetalle.idElemento = r.Item("idElemento")
                elementosCargadosDetalle.agenciaElemento = r.Item("agenciaElemento")
                elementosCargadosDetalle.ciudadDestino = r.Item("ciudadDestino")
                elementosCargadosDetalle.bultos = r.Item("bultos")
                elementosCargadosDetalle.peso = r.Item("peso")
                elementosCargadosDetalle.piezas = r.Item("piezas")
                elementosCargadosDetalle.tempProm = r.Item("temperaturaProm")
                elementosCargadosDetalle.estado = r.Item("estado")
                For Each r2 As DataRow In dtGuiaCamiones.Rows
                    elementosCargadosDetalle.tipoEnvase = r2.Item("descripcionTipo")
                    elementosCargadosDetalle.materialEnvase = r2.Item("descripcionMaterial")
                Next
                elementosCargados.ElementosCargadosDetalle.Add(elementosCargadosDetalle)
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
    Private Sub CargarRptProcesoAlmacenaje()
        Try
            ProcesoCargaAlmacenaje = New ProcesoCargaAlmacenaje
            Dim muelle As String
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
                ProcesoCargaAlmacenajeDetalle.RegCargaCuartoFrio = r.Item("RegCargaCuartoFrio")
                ProcesoCargaAlmacenajeDetalle.UsusarioIngreso = r.Item("UsusarioIngreso")
                ProcesoCargaAlmacenajeDetalle.bultos = r.Item("bultos")
                ProcesoCargaAlmacenajeDetalle.estado = r.Item("estado")
                ProcesoCargaAlmacenajeDetalle.peso = r.Item("peso")
                ProcesoCargaAlmacenajeDetalle.piezas = r.Item("piezas")
                If r.Item("RegCargaCuartoFrio") = "A2" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempA")
                ElseIf r.Item("RegCargaCuartoFrio") = "A3-4" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempA_3_4")
                ElseIf r.Item("RegCargaCuartoFrio") = "A5" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempC")
                ElseIf r.Item("RegCargaCuartoFrio") = "B" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempB")
                ElseIf r.Item("RegCargaCuartoFrio") = "Z-Flores" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempZ_Flor")
                ElseIf r.Item("RegCargaCuartoFrio") = "Z-Pequeño" Then
                    ProcesoCargaAlmacenajeDetalle.TempMuelle = r.Item("tempZ_Pq")
                End If
                ProcesoCargaAlmacenajeDetalle.Muelle = "Temp" & r.Item("RegCargaCuartoFrio")
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                o.peso = 0
                For Each r As DataRow In dtDetalleProcesoCargaElementosCargados.Rows
                    If o.elemento = r.Item("idElemento") Then
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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
