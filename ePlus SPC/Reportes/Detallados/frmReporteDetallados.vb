Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports SPC.Server.ReportService
Imports System.IO.Ports

Public Class frmReporteDetallados
    Public Property myDetalleVuelo As New DetalleVuelo
    Public resDtReportDetalleProceso As New DataTable("ReportDetalleProceso")
    Public resDtReportGroupByAgencia As New DataTable("ReportGroupByAgencia")
    Public resDtReportGroupByElemento As New DataTable("ReportGroupByElemento")
    Public resDtReportGroupByDestino As New DataTable("ReportGroupByDestino")
    Public resDtReportGroupByGuia As New DataTable("ReportGroupByGuia")
    Dim dtDetalleProcesoReporte As New DataTable("detalleProcesosReporte")
    Dim dtRptDetallado As New DataTable("Reporte")
    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Public myProceso As New ProcesoItem
    Dim Tipo As String = String.Empty
    Dim DetalladoAgenciaEnc As New DetalladoAgenciaEnc
    Dim DetalladoAgenciaDet As New DetalladoAgenciaDet
    Dim DetalladoElementoEnc As New DetalladoElementoEnc
    Dim DetalladoElementoDet As New DetalladoElementoDet
    Dim DetalladoDestinoEnc As New DetalladoDestinoEnc
    Dim DetalladoDestinoDet As New DetalladoDestinoDet
    Dim DetalladoGuiaEnc As New DetalladoGuiaEnc
    Dim DetalladoGuiaDet As New DetalladoGuiaDet

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
        obtenerReporteDetalleProceso()
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
            obtenerReporteProcesoGroupByElemento()
            ucePallet.Items.Clear()
            For Each r As DataRow In resDtReportGroupByElemento.Rows
                ucePallet.Items.Add(r.Item("idElemento"), r.Item("idElemento"))
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

    Private Sub obtenerReporteDetalleProceso()
        Dim wsClient As New ProcesoServiceSoapClient
        Dim req As New ReportGroupRequest
        Dim res As New ReportGroupResponse
        Dim ReportGroupByAgencia As New ReportGroupByAgencia
        Try
            General.SetBARequest(req)
            ReportGroupByAgencia.idProceso = myProceso.IdProceso
            req.myReportGroupByAgencia = ReportGroupByAgencia
            res = wsClient.GetReporteDetalleProcesoPorIdProceso(req)
            If res.ActionResult Then
                resDtReportDetalleProceso = res.dsResult.Tables(0)
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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If rdbAgencia.Checked Then
                CargarRptAgencia()
                Dim frmRA As New RptDetalladoPorAgencia
                frmRA.enc.Add(DetalladoAgenciaEnc)
                frmRA.det = DetalladoAgenciaEnc.DetalladoAgenciaDetalle
                frmRA.Show()
            End If
            If rdbPalet.Checked Then
                CargarRptElemento()
                Dim frmRE As New RptDetalladoPorElemento
                frmRE.enc.Add(DetalladoElementoEnc)
                frmRE.det = DetalladoElementoEnc.detalladoElementoDetalle
                frmRE.Show()
            End If
            If rdbDestino.Checked Then
                CargarRptDestino()
                Dim frmRD As New RptDetalladoPorDestino
                frmRD.enc.Add(DetalladoDestinoEnc)
                frmRD.det = DetalladoDestinoEnc.DetalladoDestinoDetalle
                frmRD.Show()
            End If
            If rdbGuia.Checked Then
                CargarRptGuia()
                Dim frmRG As New RptDetalladoPorGuia
                frmRG.enc.Add(DetalladoGuiaEnc)
                frmRG.det = DetalladoGuiaEnc.DetalladoGuiaDetalle
                frmRG.Show()
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
                .Add("pallet", GetType(String))
                .Add("guia", GetType(String))
                .Add("temp", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("volumen", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("fecha", GetType(DateTime))
                .Add("hora", GetType(DateTime))
                .Add("producto", GetType(String))
                .Add("rx", GetType(Integer))
                .Add("man", GetType(Integer))
                .Add("k9", GetType(Integer))
                .Add("sumVolumen", GetType(Double))
                .Add("sumPeso", GetType(Double))
                .Add("sumPiezas", GetType(Integer))
                .Add("minPeso", GetType(Double))
                .Add("proPeso", GetType(Double))
                .Add("maxPeso", GetType(Double))
                .Add("sumRx", GetType(Integer))
                .Add("sumMan", GetType(Integer))
                .Add("sumK9", GetType(Integer))
            End With
            If todos Then
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    cont += 1
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("pallet") = r.Item("idElemento")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("temp") = r.Item("temperatura")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("hora") = r.Item("fecha")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    sumVolumen += r.Item("volumen")
                    sumPiezas += r.Item("piezas")
                    sumRx += r.Item("rx")
                    sumMan += r.Item("man")
                    sumK9 += r.Item("k9")

                    If tempMinPeso > r.Item("peso") Then
                        tempMinPeso = r.Item("peso")
                    End If
                    If tempMaxPeso < r.Item("peso") Then
                        tempMaxPeso = r.Item("peso")
                    End If
                    sumPeso += r.Item("peso")
                    result.Rows.Add(nr)
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
                Next
            Else
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    If idAgencia = r.Item("idAgencia") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        cont += 1
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("pallet") = r.Item("idElemento")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("temp") = r.Item("temperatura")
                        nr.Item("peso") = r.Item("peso")
                        nr.Item("volumen") = r.Item("volumen")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("fecha") = r.Item("fecha")
                        nr.Item("hora") = r.Item("fecha")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("rx") = r.Item("rx")
                        nr.Item("man") = r.Item("man")
                        nr.Item("k9") = r.Item("k9")
                        sumVolumen += r.Item("volumen")
                        sumPiezas += r.Item("piezas")
                        sumRx += r.Item("rx")
                        sumMan += r.Item("man")
                        sumK9 += r.Item("k9")

                        If tempMinPeso < r.Item("peso") Then
                            tempMinPeso = r.Item("peso")
                        End If
                        If tempMaxPeso > r.Item("peso") Then
                            tempMaxPeso = r.Item("peso")
                        End If
                        sumPeso += r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
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
                .Add("agencia", GetType(String))
                .Add("pallet", GetType(String))
                .Add("guia", GetType(String))
                .Add("temp", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("volumen", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("fecha", GetType(DateTime))
                .Add("hora", GetType(DateTime))
                .Add("producto", GetType(String))
                .Add("rx", GetType(Integer))
                .Add("man", GetType(Integer))
                .Add("k9", GetType(Integer))
                .Add("sumVolumen", GetType(Double))
                .Add("sumPeso", GetType(Double))
                .Add("sumPiezas", GetType(Integer))
                .Add("minPeso", GetType(Double))
                .Add("proPeso", GetType(Double))
                .Add("maxPeso", GetType(Double))
                .Add("sumRx", GetType(Integer))
                .Add("sumMan", GetType(Integer))
                .Add("sumK9", GetType(Integer))
            End With
            If todos Then
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    cont += 1
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("pallet") = r.Item("idElemento")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("temp") = r.Item("temperatura")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("hora") = r.Item("fecha")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    sumVolumen += r.Item("volumen")
                    sumPiezas += r.Item("piezas")
                    sumRx += r.Item("rx")
                    sumMan += r.Item("man")
                    sumK9 += r.Item("k9")

                    If tempMinPeso > r.Item("peso") Then
                        tempMinPeso = r.Item("peso")
                    End If
                    If tempMaxPeso < r.Item("peso") Then
                        tempMaxPeso = r.Item("peso")
                    End If
                    sumPeso += r.Item("peso")
                    result.Rows.Add(nr)
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
                Next
            Else
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    If idElemento = r.Item("idElemento") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        cont += 1
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("pallet") = r.Item("idElemento")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("temp") = r.Item("temperatura")
                        nr.Item("peso") = r.Item("peso")
                        nr.Item("volumen") = r.Item("volumen")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("fecha") = r.Item("fecha")
                        nr.Item("hora") = r.Item("fecha")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("rx") = r.Item("rx")
                        nr.Item("man") = r.Item("man")
                        nr.Item("k9") = r.Item("k9")
                        sumVolumen += r.Item("volumen")
                        sumPiezas += r.Item("piezas")
                        sumRx += r.Item("rx")
                        sumMan += r.Item("man")
                        sumK9 += r.Item("k9")

                        If tempMinPeso < r.Item("peso") Then
                            tempMinPeso = r.Item("peso")
                        End If
                        If tempMaxPeso > r.Item("peso") Then
                            tempMaxPeso = r.Item("peso")
                        End If
                        sumPeso += r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
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
                .Add("agencia", GetType(String))
                .Add("ciudadDestino", GetType(String))
                .Add("pallet", GetType(String))
                .Add("guia", GetType(String))
                .Add("temp", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("volumen", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("fecha", GetType(DateTime))
                .Add("hora", GetType(DateTime))
                .Add("producto", GetType(String))
                .Add("rx", GetType(Integer))
                .Add("man", GetType(Integer))
                .Add("k9", GetType(Integer))
                .Add("sumVolumen", GetType(Double))
                .Add("sumPeso", GetType(Double))
                .Add("sumPiezas", GetType(Integer))
                .Add("minPeso", GetType(Double))
                .Add("proPeso", GetType(Double))
                .Add("maxPeso", GetType(Double))
                .Add("sumRx", GetType(Integer))
                .Add("sumMan", GetType(Integer))
                .Add("sumK9", GetType(Integer))
            End With
            If todos Then
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    cont += 1
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                    nr.Item("pallet") = r.Item("idElemento")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("temp") = r.Item("temperatura")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("hora") = r.Item("fecha")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    sumVolumen += r.Item("volumen")
                    sumPiezas += r.Item("piezas")
                    sumRx += r.Item("rx")
                    sumMan += r.Item("man")
                    sumK9 += r.Item("k9")

                    If tempMinPeso > r.Item("peso") Then
                        tempMinPeso = r.Item("peso")
                    End If
                    If tempMaxPeso < r.Item("peso") Then
                        tempMaxPeso = r.Item("peso")
                    End If
                    sumPeso += r.Item("peso")
                    result.Rows.Add(nr)
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
                Next
            Else
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    If idDestino = r.Item("idDestino") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        cont += 1
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("ciudadDestino") = r.Item("ciudadDestino")
                        nr.Item("pallet") = r.Item("idElemento")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("temp") = r.Item("temperatura")
                        nr.Item("peso") = r.Item("peso")
                        nr.Item("volumen") = r.Item("volumen")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("fecha") = r.Item("fecha")
                        nr.Item("hora") = r.Item("fecha")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("rx") = r.Item("rx")
                        nr.Item("man") = r.Item("man")
                        nr.Item("k9") = r.Item("k9")
                        sumVolumen += r.Item("volumen")
                        sumPiezas += r.Item("piezas")
                        sumRx += r.Item("rx")
                        sumMan += r.Item("man")
                        sumK9 += r.Item("k9")

                        If tempMinPeso < r.Item("peso") Then
                            tempMinPeso = r.Item("peso")
                        End If
                        If tempMaxPeso > r.Item("peso") Then
                            tempMaxPeso = r.Item("peso")
                        End If
                        sumPeso += r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
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
                .Add("agencia", GetType(String))
                .Add("pallet", GetType(String))
                .Add("guia", GetType(String))
                .Add("temp", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("volumen", GetType(Double))
                .Add("piezas", GetType(Integer))
                .Add("fecha", GetType(DateTime))
                .Add("hora", GetType(DateTime))
                .Add("producto", GetType(String))
                .Add("rx", GetType(Integer))
                .Add("man", GetType(Integer))
                .Add("k9", GetType(Integer))
                .Add("sumVolumen", GetType(Double))
                .Add("sumPeso", GetType(Double))
                .Add("sumPiezas", GetType(Integer))
                .Add("minPeso", GetType(Double))
                .Add("proPeso", GetType(Double))
                .Add("maxPeso", GetType(Double))
                .Add("sumRx", GetType(Integer))
                .Add("sumMan", GetType(Integer))
                .Add("sumK9", GetType(Integer))
            End With
            If todos Then
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    Dim nr As DataRow
                    nr = result.NewRow
                    cont += 1
                    nr.Item("agencia") = r.Item("agenciaCargaGuia")
                    nr.Item("pallet") = r.Item("idElemento")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("temp") = r.Item("temperatura")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("hora") = r.Item("fecha")
                    nr.Item("producto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    sumVolumen += r.Item("volumen")
                    sumPiezas += r.Item("piezas")
                    sumRx += r.Item("rx")
                    sumMan += r.Item("man")
                    sumK9 += r.Item("k9")

                    If tempMinPeso > r.Item("peso") Then
                        tempMinPeso = r.Item("peso")
                    End If
                    If tempMaxPeso < r.Item("peso") Then
                        tempMaxPeso = r.Item("peso")
                    End If
                    sumPeso += r.Item("peso")
                    result.Rows.Add(nr)
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
                Next
            Else
                Dim tempMaxPeso As Double = 0D
                Dim tempMinPeso As Double = 100000000.0
                Dim sumPeso As Double = 0D
                Dim sumVolumen As Double = 0D
                Dim sumPiezas As Integer = 0
                Dim sumRx As Integer = 0
                Dim sumMan As Integer = 0
                Dim sumK9 As Integer = 0
                Dim cont As Integer = 0
                For Each r As DataRow In resDtReportDetalleProceso.Rows
                    If idGuia = r.Item("idGuia") Then
                        Dim nr As DataRow
                        nr = result.NewRow
                        cont += 1
                        nr.Item("agencia") = r.Item("agenciaCargaGuia")
                        nr.Item("pallet") = r.Item("idElemento")
                        nr.Item("guia") = r.Item("guia")
                        nr.Item("temp") = r.Item("temperatura")
                        nr.Item("peso") = r.Item("peso")
                        nr.Item("volumen") = r.Item("volumen")
                        nr.Item("piezas") = r.Item("piezas")
                        nr.Item("fecha") = r.Item("fecha")
                        nr.Item("hora") = r.Item("fecha")
                        nr.Item("producto") = r.Item("descripcionProducto")
                        nr.Item("rx") = r.Item("rx")
                        nr.Item("man") = r.Item("man")
                        nr.Item("k9") = r.Item("k9")
                        sumVolumen += r.Item("volumen")
                        sumPiezas += r.Item("piezas")
                        sumRx += r.Item("rx")
                        sumMan += r.Item("man")
                        sumK9 += r.Item("k9")

                        If tempMinPeso < r.Item("peso") Then
                            tempMinPeso = r.Item("peso")
                        End If
                        If tempMaxPeso > r.Item("peso") Then
                            tempMaxPeso = r.Item("peso")
                        End If
                        sumPeso += r.Item("peso")
                        result.Rows.Add(nr)
                    End If
                Next
                For Each r In result.Rows
                    r.item("Sumvolumen") = sumVolumen
                    r.item("sumPeso") = sumPeso
                    r.item("sumPiezas") = sumPiezas
                    r.item("sumRx") = sumRx
                    r.item("sumMan") = sumMan
                    r.item("sumK9") = sumK9
                    r.item("minPeso") = tempMinPeso
                    r.item("maxPeso") = tempMaxPeso
                    r.item("proPeso") = sumPeso / cont
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub CargarRptAgencia()
        Dim dtReporte As New DataTable("Reporte")
        DetalladoAgenciaEnc = New DetalladoAgenciaEnc
        If uceAgencia.Text <> "Todos" Then
            dtReporte = RptPorAgencia(uceAgencia.Value, False)
        Else
            dtReporte = RptPorAgencia(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            DetalladoAgenciaDet = New DetalladoAgenciaDet
            DetalladoAgenciaDet.vuelo = myDetalleVuelo.codigoVuelo
            DetalladoAgenciaDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            DetalladoAgenciaDet.agencia = r.Item("agencia")
            DetalladoAgenciaDet.pallet = r.Item("pallet")
            DetalladoAgenciaDet.guia = r.Item("guia")
            DetalladoAgenciaDet.temp = r.Item("temp")
            DetalladoAgenciaDet.peso = r.Item("peso")
            DetalladoAgenciaDet.volumen = r.Item("volumen")
            DetalladoAgenciaDet.piezas = r.Item("piezas")
            DetalladoAgenciaDet.fecha = r.Item("fecha")
            DetalladoAgenciaDet.hora = r.Item("fecha")
            DetalladoAgenciaDet.producto = r.Item("producto")
            DetalladoAgenciaDet.rx = r.Item("rx")
            DetalladoAgenciaDet.man = r.Item("man")
            DetalladoAgenciaDet.k9 = r.Item("k9")
            DetalladoAgenciaDet.sumVolumen = r.Item("sumVolumen")
            DetalladoAgenciaDet.sumPeso = r.Item("sumPeso")
            DetalladoAgenciaDet.sumPiezas = r.Item("sumPiezas")
            DetalladoAgenciaDet.sumRx = r.Item("sumRx")
            DetalladoAgenciaDet.sumMan = r.Item("sumMan")
            DetalladoAgenciaDet.sumK9 = r.Item("sumK9")
            DetalladoAgenciaDet.minPeso = r.Item("minPeso")
            DetalladoAgenciaDet.maxPeso = r.Item("maxPeso")
            DetalladoAgenciaDet.proPeso = r.Item("proPeso")
            DetalladoAgenciaEnc.detalladoAgenciaDetalle.Add(DetalladoAgenciaDet)
        Next
    End Sub

    Private Sub CargarRptElemento()
        Dim dtReporte As New DataTable("Reporte")
        DetalladoElementoEnc = New DetalladoElementoEnc
        If ucePallet.Text <> "Todos" Then
            dtReporte = RptPorElemento(ucePallet.Value, False)
        Else
            dtReporte = RptPorElemento("", True)
        End If
        For Each r As DataRow In dtReporte.Rows
            DetalladoElementoDet = New DetalladoElementoDet
            DetalladoElementoDet.vuelo = myDetalleVuelo.codigoVuelo
            DetalladoElementoDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            DetalladoElementoDet.agencia = r.Item("agencia")
            DetalladoElementoDet.pallet = r.Item("pallet")
            DetalladoElementoDet.guia = r.Item("guia")
            DetalladoElementoDet.temp = r.Item("temp")
            DetalladoElementoDet.peso = r.Item("peso")
            DetalladoElementoDet.volumen = r.Item("volumen")
            DetalladoElementoDet.piezas = r.Item("piezas")
            DetalladoElementoDet.fecha = r.Item("fecha")
            DetalladoElementoDet.hora = r.Item("fecha")
            DetalladoElementoDet.producto = r.Item("producto")
            DetalladoElementoDet.rx = r.Item("rx")
            DetalladoElementoDet.man = r.Item("man")
            DetalladoElementoDet.k9 = r.Item("k9")
            DetalladoElementoDet.sumVolumen = r.Item("sumVolumen")
            DetalladoElementoDet.sumPeso = r.Item("sumPeso")
            DetalladoElementoDet.sumPiezas = r.Item("sumPiezas")
            DetalladoElementoDet.sumRx = r.Item("sumRx")
            DetalladoElementoDet.sumMan = r.Item("sumMan")
            DetalladoElementoDet.sumK9 = r.Item("sumK9")
            DetalladoElementoDet.minPeso = r.Item("minPeso")
            DetalladoElementoDet.maxPeso = r.Item("maxPeso")
            DetalladoElementoDet.proPeso = r.Item("proPeso")
            DetalladoElementoEnc.detalladoElementoDetalle.Add(DetalladoElementoDet)
        Next
    End Sub

    Private Sub CargarRptDestino()
        Dim dtReporte As New DataTable("Reporte")
        DetalladoDestinoEnc = New DetalladoDestinoEnc
        If uceDestino.Text <> "Todos" Then
            dtReporte = RptPorDestino(uceDestino.Value, False)
        Else
            dtReporte = RptPorDestino(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            DetalladoDestinoDet = New DetalladoDestinoDet
            DetalladoDestinoDet.vuelo = myDetalleVuelo.codigoVuelo
            DetalladoDestinoDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            DetalladoDestinoDet.agencia = r.Item("agencia")
            DetalladoDestinoDet.ciudadDestino = r.Item("ciudadDestino")
            DetalladoDestinoDet.pallet = r.Item("pallet")
            DetalladoDestinoDet.guia = r.Item("guia")
            DetalladoDestinoDet.temp = r.Item("temp")
            DetalladoDestinoDet.peso = r.Item("peso")
            DetalladoDestinoDet.volumen = r.Item("volumen")
            DetalladoDestinoDet.piezas = r.Item("piezas")
            DetalladoDestinoDet.fecha = r.Item("fecha")
            DetalladoDestinoDet.hora = r.Item("fecha")
            DetalladoDestinoDet.producto = r.Item("producto")
            DetalladoDestinoDet.rx = r.Item("rx")
            DetalladoDestinoDet.man = r.Item("man")
            DetalladoDestinoDet.k9 = r.Item("k9")
            DetalladoDestinoDet.sumVolumen = r.Item("sumVolumen")
            DetalladoDestinoDet.sumPeso = r.Item("sumPeso")
            DetalladoDestinoDet.sumPiezas = r.Item("sumPiezas")
            DetalladoDestinoDet.sumRx = r.Item("sumRx")
            DetalladoDestinoDet.sumMan = r.Item("sumMan")
            DetalladoDestinoDet.sumK9 = r.Item("sumK9")
            DetalladoDestinoDet.minPeso = r.Item("minPeso")
            DetalladoDestinoDet.maxPeso = r.Item("maxPeso")
            DetalladoDestinoDet.proPeso = r.Item("proPeso")
            DetalladoDestinoEnc.detalladoDestinoDetalle.Add(DetalladoDestinoDet)
        Next
    End Sub

    Private Sub CargarRptGuia()
        Dim dtReporte As New DataTable("Reporte")
        DetalladoGuiaEnc = New DetalladoGuiaEnc
        If uceGuia.Text <> "Todos" Then
            dtReporte = RptPorGuia(uceGuia.Value, False)
        Else
            dtReporte = RptPorGuia(Guid.Empty, True)
        End If
        For Each r As DataRow In dtReporte.Rows
            DetalladoGuiaDet = New DetalladoGuiaDet
            DetalladoGuiaDet.vuelo = myDetalleVuelo.codigoVuelo
            DetalladoGuiaDet.fechaVuelo = myDetalleVuelo.fechaVuelo
            DetalladoGuiaDet.agencia = r.Item("agencia")
            DetalladoGuiaDet.pallet = r.Item("pallet")
            DetalladoGuiaDet.guia = r.Item("guia")
            DetalladoGuiaDet.temp = r.Item("temp")
            DetalladoGuiaDet.peso = r.Item("peso")
            DetalladoGuiaDet.volumen = r.Item("volumen")
            DetalladoGuiaDet.piezas = r.Item("piezas")
            DetalladoGuiaDet.fecha = r.Item("fecha")
            DetalladoGuiaDet.hora = r.Item("fecha")
            DetalladoGuiaDet.producto = r.Item("producto")
            DetalladoGuiaDet.rx = r.Item("rx")
            DetalladoGuiaDet.man = r.Item("man")
            DetalladoGuiaDet.k9 = r.Item("k9")
            DetalladoGuiaDet.sumVolumen = r.Item("sumVolumen")
            DetalladoGuiaDet.sumPeso = r.Item("sumPeso")
            DetalladoGuiaDet.sumPiezas = r.Item("sumPiezas")
            DetalladoGuiaDet.sumRx = r.Item("sumRx")
            DetalladoGuiaDet.sumMan = r.Item("sumMan")
            DetalladoGuiaDet.sumK9 = r.Item("sumK9")
            DetalladoGuiaDet.minPeso = r.Item("minPeso")
            DetalladoGuiaDet.maxPeso = r.Item("maxPeso")
            DetalladoGuiaDet.proPeso = r.Item("proPeso")
            DetalladoGuiaEnc.detalladoGuiaDetalle.Add(DetalladoGuiaDet)
        Next
    End Sub

End Class