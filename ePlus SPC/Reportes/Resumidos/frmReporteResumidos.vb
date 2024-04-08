Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Imports System.IO.Ports

Public Class frmReporteResumidos
    Public Property myDetalleVuelo As New DetalleVuelo
    Public resDtReportGroupByAgencia As New DataTable("ReportGroupByAgencia")
    Public resDtReportGroupByElemento As New DataTable("ReportGroupByElemento")
    Public resDtReportGroupByDestino As New DataTable("ReportGroupByDestino")
    Public resDtReportGroupByGuia As New DataTable("ReportGroupByGuia")
    Dim dtDetalleProcesoReporte As New DataTable("detalleProcesosReporte")
    Dim dtRptResumido As New DataTable("Reporte")
    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Public myProceso As New ProcesoItem
    Dim Tipo As String = String.Empty
    Dim ResumidoAgenciaEnc As New ResumidoAgenciaEnc
    Dim ResumidoAgenciaDet As New ResumidoAgenciaDet
    Dim ResumidoElementoEnc As New ResumidoElementoEnc
    Dim ResumidoElementoDet As New ResumidoElementoDet
    Dim ResumidoDestinoEnc As New ResumidoDestinoEnc
    Dim ResumidoDestinoDet As New ResumidoDestinoDet
    Dim ResumidoGuiaEnc As New ResumidoGuiaEnc
    Dim ResumidoGuiaDet As New ResumidoGuiaDet

    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing()
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                obtenerDetalleVuelo(frmConsultaVuelos.resDetVuelo.idBriefing)
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                myProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing)
                CargarVuelo(frmConsultaVuelos.Aerolinea)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        Try
            txtAgencia.Text = Aerolinea
            txtNumVuelo.Text = resDtVuelo.codigoVuelo
            txtAvion.Text = resDtVuelo.descripcionAvion
            txtMatricula.Text = resDtVuelo.matriculaAvion
            udtFecha.Value = resDtVuelo.fechaVuelo
            cargarCombos()
            dtDetalleProcesoReporte = CommonProcess.GetDetalleProcesoPorIdProcesoReporte(myProceso.IdProceso)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cargarCombos()
        CargarComboAgencia()
        CargarComboPallet()
        CargarComboDestino()
        CargarComboGuia()
    End Sub

    Private Sub CargarComboAgencia()
        Try
            obtenerReporteProcesoGroupByAgencia()
            uceAgencia.Items.Clear()
            For Each r As DataRow In resDtReportGroupByAgencia.Rows
                uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("agenciaCargaGuia"))
            Next
            uceAgencia.Items.Add(0, "Todos")
            uceAgencia.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarComboPallet()
        Try
            Dim tempIdElemento As String = ""
            obtenerReporteProcesoGroupByElemento()
            ucePallet.Items.Clear()
            For Each r As DataRow In resDtReportGroupByElemento.Rows
                If tempIdElemento <> r.Item("idElemento") Then
                    ucePallet.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
                End If
                tempIdElemento = r.Item("idElemento")
            Next
            ucePallet.Items.Add(0, "Todos")
            ucePallet.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarComboDestino()
        Try
            obtenerReporteProcesoGroupByDestino()
            uceDestino.Items.Clear()
            For Each r As DataRow In resDtReportGroupByDestino.Rows
                uceDestino.Items.Add(r.Item("idCiudad"), r.Item("ciudadDestino"))
            Next
            uceDestino.Items.Add(0, "Todos")
            uceDestino.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarComboGuia()
        Try
            obtenerReporteProcesoGroupByGuia()
            uceGuia.Items.Clear()
            For Each r As DataRow In resDtReportGroupByGuia.Rows
                uceGuia.Items.Add(r.Item("idGuia"), r.Item("guia"))
            Next
            uceGuia.Items.Add(0, "Todos")
            uceGuia.SelectedIndex = 0
        Catch ex As Exception
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
                resDsVuelo = res.DsResult
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerReporteProcesoGroupByAgencia()
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByAgencia As New ReportGroupByAgencia
        Try
            General.SetBARequest(req)
            ReportGroupByAgencia.idProceso = myProceso.IdProceso
            req.myReportGroupByAgencia = ReportGroupByAgencia
            res = wsClient.GetReportePorIdProcesoGroupByAgenciaCarga(req)
            If res.ActionResult Then
                resDtReportGroupByAgencia = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerReporteProcesoGroupByElemento()
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByElemento As New ReportGroupByElemento
        Try
            General.SetBARequest(req)
            ReportGroupByElemento.idProceso = myProceso.IdProceso
            req.myReportGroupByElemento = ReportGroupByElemento
            res = wsClient.GetReportePorIdProcesoGroupByElemento(req)
            If res.ActionResult Then
                resDtReportGroupByElemento = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerReporteProcesoGroupByDestino()
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByDestino As New ReportGroupByDestino
        Try
            General.SetBARequest(req)
            ReportGroupByDestino.idProceso = myProceso.IdProceso
            req.myReportGroupByDestino = ReportGroupByDestino
            res = wsClient.GetReportePorIdProcesoGroupByDestino(req)
            If res.ActionResult Then
                resDtReportGroupByDestino = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub obtenerReporteProcesoGroupByGuia()
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByGuia As New ReportGroupByAgencia
        Try
            General.SetBARequest(req)
            ReportGroupByGuia.idProceso = myProceso.IdProceso
            req.myReportGroupByAgencia = ReportGroupByGuia
            res = wsClient.GetReportePorIdProcesoGroupByGuia(req)
            If res.ActionResult Then
                resDtReportGroupByGuia = res.dsResult.Tables(0)
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtAvion.Clear()
        txtAvion.Clear()
        txtMatricula.Clear()
        txtNumVuelo.Clear()
        udtFecha.Value = Date.Now
    End Sub


    Private Sub rdbAgencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAgencia.CheckedChanged
        If rdbAgencia.CheckAlign Then
            Tipo = "A"
        End If
        HabilitaCombos()
    End Sub

    Private Sub HabilitaCombos()
        uceAgencia.Enabled = False
        uceDestino.Enabled = False
        uceGuia.Enabled = False
        ucePallet.Enabled = False

        Select Case Tipo
            Case "A"
                uceAgencia.Enabled = True
            Case "D"
                uceDestino.Enabled = True
            Case "G"
                uceGuia.Enabled = True
            Case "P"
                ucePallet.Enabled = True
        End Select
    End Sub

    Private Sub rdbDestino_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDestino.CheckedChanged
        If rdbDestino.CheckAlign Then
            Tipo = "D"
        End If
        HabilitaCombos()
    End Sub

    Private Sub rdbGuia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbGuia.CheckedChanged
        If rdbGuia.CheckAlign Then
            Tipo = "G"
        End If
        HabilitaCombos()
    End Sub

    Private Sub rdbPalet_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPalet.CheckedChanged
        If rdbPalet.CheckAlign Then
            Tipo = "P"
        End If
        HabilitaCombos()
    End Sub

    Private Sub rdbMan_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMan.CheckedChanged
        If rdbMan.CheckAlign Then
            Tipo = "M"
        End If
        HabilitaCombos()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If rdbAgencia.Checked Then
                CargarRptAgencia()
                Dim frmRA As New RptResumidoPorAgencia
                frmRA.enc.Add(ResumidoAgenciaEnc)
                frmRA.det = ResumidoAgenciaEnc.resumidoAgenciaDetalle
                frmRA.Show()
            End If
            If rdbDestino.Checked Then
                CargarRptDestino()
                Dim frmRD As New RptResumidoPorDestino
                frmRD.enc.Add(ResumidoDestinoEnc)
                frmRD.det = ResumidoDestinoEnc.resumidoDestinoDetalle
                frmRD.Show()
            End If
            If rdbGuia.Checked Then
                CargarRptGuia()
                Dim frmRG As New RptResumidoPorGuia
                frmRG.enc.Add(ResumidoGuiaEnc)
                frmRG.det = ResumidoGuiaEnc.resumidoGuiaDetalle
                frmRG.Show()
            End If
            If rdbPalet.Checked Then
                CargarRptElemento()
                Dim frmRE As New RptResumidoPorElemento
                frmRE.enc.Add(ResumidoElementoEnc)
                frmRE.det = ResumidoElementoEnc.resumidoElementoDetalle
                frmRE.Show()
            End If
            If rdbMan.Checked Then

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function RptPorAgencia(idAgencia As Guid, todos As Boolean) As DataTable
        Dim result As New DataTable("Result")
        Try
            With result.Columns
                .Add("agencia", GetType(String))
                .Add("guia", GetType(String))
                .Add("destino", GetType(String))
                .Add("producto", GetType(String))
                .Add("inicio", GetType(DateTime))
                .Add("fin", GetType(DateTime))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
            End With
            If todos Then
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("destino") = r.Item("ciudadDestino")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("inicio") = r.Item("horaIni")
                    nr.Item("fin") = r.Item("horaFin")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    result.Rows.Add(nr)
                Next
            Else
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    If idAgencia = r.Item("idAgencia") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("destino") = r.Item("ciudadDestino")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("inicio") = r.Item("horaIni")
                        nr.Item("fin") = r.Item("horaFin")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("peso") = r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function RptPorElemento(idElemento As String, todos As Boolean) As DataTable
        Dim result As New DataTable("Result")
        Try
            With result.Columns
                .Add("idElemento", GetType(String))
                .Add("agenciaElemento", GetType(String))
                .Add("agencia", GetType(String))
                .Add("guia", GetType(String))
                .Add("destino", GetType(String))
                .Add("producto", GetType(String))
                .Add("inicio", GetType(DateTime))
                .Add("fin", GetType(DateTime))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
            End With
            If todos Then
                For Each r As DataRow In resDtReportGroupByElemento.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("destino") = r.Item("ciudadDestino")
                    ' nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("inicio") = r.Item("horaIni")
                    nr.Item("fin") = r.Item("horaFin")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    result.Rows.Add(nr)
                Next
            Else
                For Each r As DataRow In resDtReportGroupByElemento.Rows
                    If idElemento = r.Item("idElemento") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        nr.Item("idElemento") = r.Item("idElemento")
                        nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("destino") = r.Item("ciudadDestino")
                        ' nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("inicio") = r.Item("horaIni")
                        nr.Item("fin") = r.Item("horaFin")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("peso") = r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function RptPorDestino(idDestino As Guid, todos As Boolean) As DataTable
        Dim result As New DataTable("Result")
        Try
            With result.Columns
                .Add("idElemento", GetType(String))
                .Add("agenciaElemento", GetType(String))
                .Add("agencia", GetType(String))
                .Add("guia", GetType(String))
                .Add("destino", GetType(String))
                .Add("producto", GetType(String))
                .Add("inicio", GetType(DateTime))
                .Add("fin", GetType(DateTime))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
            End With
            If todos Then
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("destino") = r.Item("ciudadDestino")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("inicio") = r.Item("horaIni")
                    nr.Item("fin") = r.Item("horaFin")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    result.Rows.Add(nr)
                Next
            Else
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    If idDestino = r.Item("idCiudad") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        nr.Item("idElemento") = r.Item("idElemento")
                        nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("destino") = r.Item("ciudadDestino")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("inicio") = r.Item("horaIni")
                        nr.Item("fin") = r.Item("horaFin")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("peso") = r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Function RptPorGuia(idGuia As Guid, todos As Boolean) As DataTable
        Dim result As New DataTable("Result")
        Try
            With result.Columns
                .Add("idElemento", GetType(String))
                .Add("agenciaElemento", GetType(String))
                .Add("agencia", GetType(String))
                .Add("guia", GetType(String))
                .Add("destino", GetType(String))
                .Add("producto", GetType(String))
                .Add("inicio", GetType(DateTime))
                .Add("fin", GetType(DateTime))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
            End With
            If todos Then
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("destino") = r.Item("ciudadDestino")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("inicio") = r.Item("horaIni")
                    nr.Item("fin") = r.Item("horaFin")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    result.Rows.Add(nr)
                Next
            Else
                For Each r As DataRow In resDtReportGroupByGuia.Rows
                    If idGuia = r.Item("idGuia") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        nr.Item("idElemento") = r.Item("idElemento")
                        nr.Item("agenciaElemento") = r.Item("agenciaElemento")
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("destino") = r.Item("ciudadDestino")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("inicio") = r.Item("horaIni")
                        nr.Item("fin") = r.Item("horaFin")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("peso") = r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub CargarRptAgencia()
        Dim dtReporte As New DataTable("Reporte")
        ResumidoAgenciaEnc = New ResumidoAgenciaEnc
        If uceAgencia.Text <> "Todos" Then
            dtReporte = RptPorAgencia(uceAgencia.Value, False)
        Else
            dtReporte = RptPorAgencia(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            ResumidoAgenciaDet = New ResumidoAgenciaDet
            ResumidoAgenciaDet.vuelo = myDetalleVuelo.codigoVuelo
            ResumidoAgenciaDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            ResumidoAgenciaDet.agencia = r.Item("agencia")
            ResumidoAgenciaDet.guia = r.Item("guia")
            ResumidoAgenciaDet.destino = r.Item("destino")
            ResumidoAgenciaDet.producto = r.Item("producto")
            ResumidoAgenciaDet.inicio = r.Item("inicio")
            ResumidoAgenciaDet.fin = r.Item("fin")
            ResumidoAgenciaDet.piezas = r.Item("piezas")
            ResumidoAgenciaDet.peso = r.Item("peso")
            ResumidoAgenciaEnc.resumidoAgenciaDetalle.Add(ResumidoAgenciaDet)
        Next
    End Sub

    Private Sub CargarRptElemento()
        Dim dtReporte As New DataTable("Reporte")
        ResumidoElementoEnc = New ResumidoElementoEnc
        If ucePallet.Text <> "Todos" Then
            dtReporte = RptPorElemento(ucePallet.Value, False)
        Else
            dtReporte = RptPorElemento("", True)
        End If
        For Each r As DataRow In dtReporte.Rows
            ResumidoElementoDet = New ResumidoElementoDet
            ResumidoElementoDet.vuelo = myDetalleVuelo.codigoVuelo
            ResumidoElementoDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            ResumidoElementoDet.idElemento = r.Item("idElemento")
            ResumidoElementoDet.agenciaElemento = r.Item("agenciaElemento")
            ResumidoElementoDet.agencia = r.Item("agencia")
            ResumidoElementoDet.guia = r.Item("guia")
            ResumidoElementoDet.destino = r.Item("destino")
            'ResumidoElementoDet.producto = r.Item("producto")
            ResumidoElementoDet.inicio = r.Item("inicio")
            ResumidoElementoDet.fin = r.Item("fin")
            ResumidoElementoDet.piezas = r.Item("piezas")
            ResumidoElementoDet.peso = r.Item("peso")
            ResumidoElementoEnc.resumidoElementoDetalle.Add(ResumidoElementoDet)
        Next
    End Sub

    Private Sub CargarRptDestino()
        Dim dtReporte As New DataTable("Reporte")
        ResumidoDestinoEnc = New ResumidoDestinoEnc
        If uceDestino.Text <> "Todos" Then
            dtReporte = RptPorDestino(uceDestino.Value, False)
        Else
            dtReporte = RptPorDestino(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            ResumidoDestinoDet = New ResumidoDestinoDet
            ResumidoDestinoDet.vuelo = myDetalleVuelo.codigoVuelo
            ResumidoDestinoDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            ResumidoDestinoDet.idElemento = r.Item("idElemento")
            ResumidoDestinoDet.agenciaElemento = r.Item("agenciaElemento")
            ResumidoDestinoDet.agencia = r.Item("agencia")
            ResumidoDestinoDet.guia = r.Item("guia")
            ResumidoDestinoDet.destino = r.Item("destino")
            ResumidoDestinoDet.producto = r.Item("producto")
            ResumidoDestinoDet.inicio = r.Item("inicio")
            ResumidoDestinoDet.fin = r.Item("fin")
            ResumidoDestinoDet.piezas = r.Item("piezas")
            ResumidoDestinoDet.peso = r.Item("peso")
            ResumidoDestinoEnc.resumidoDestinoDetalle.Add(ResumidoDestinoDet)
        Next
    End Sub

    Private Sub CargarRptGuia()
        Dim dtReporte As New DataTable("Reporte")
        ResumidoGuiaEnc = New ResumidoGuiaEnc
        If uceGuia.Text <> "Todos" Then
            dtReporte = RptPorGuia(uceGuia.Value, False)
        Else
            dtReporte = RptPorGuia(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            ResumidoGuiaDet = New ResumidoGuiaDet
            ResumidoGuiaDet.vuelo = myDetalleVuelo.codigoVuelo
            ResumidoGuiaDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            ResumidoGuiaDet.idElemento = r.Item("idElemento")
            ResumidoGuiaDet.agenciaElemento = r.Item("agenciaElemento")
            ResumidoGuiaDet.agencia = r.Item("agencia")
            ResumidoGuiaDet.guia = r.Item("guia")
            ResumidoGuiaDet.destino = r.Item("destino")
            ResumidoGuiaDet.producto = r.Item("producto")
            ResumidoGuiaDet.inicio = r.Item("inicio")
            ResumidoGuiaDet.fin = r.Item("fin")
            ResumidoGuiaDet.piezas = r.Item("piezas")
            ResumidoGuiaDet.peso = r.Item("peso")
            ResumidoGuiaEnc.resumidoGuiaDetalle.Add(ResumidoGuiaDet)
        Next
    End Sub

End Class