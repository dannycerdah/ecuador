Imports SPC.Server.VuelosService
Imports SPC.Server.ProcesoService
Imports System.IO.Ports
Imports System.IO
Imports System.Threading
Imports SPC.MessagesManager

Public Class frmProduccionDetalle
    Public Property myProceso As New ProcesoItem
    Public resDtVuelo As New DetalleVuelo
    Public resDsVuelo As New DataSet
    Dim ProduccionID As Guid
    Dim dtStockElementos As DataTable
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewProd As Boolean = False
    Dim idVuelos As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim dtDetalleProcesoReporte As New DataTable("detalleProcesosReporte")
    Dim dtDetalleProcesoCargaReporte As New DataTable("detalleProcesoCargaReporte")
    Dim dtPreciosTarifas As New DataTable("preciosTarifas")
    Dim dtDetalleProcesoCargaAlmacenaje As New DataTable("detalleProcesoCargaReporte")
    Dim dtDetalleAcarreoReporte As New DataTable("dtDetalleAcarreoReporte")
    ' Dim dtDetalleProcesoCargaAlmacenaje As New DataTable("dtDetalleProcesoCargaAlmacenaje")
    Dim camionEncabezado As New CamionesEncabezado
    Dim camionDetalle As New CamionesDetalle
    Dim initial As Boolean = True
    Public Property myProduccion As New ProduccionItem
#Region "Inicial"
    Private Sub InitializeValues()
        ' myProduccion.idProduccion = Guid.Empty
        myProduccion.idTarifas = Guid.Empty
        udtFecha.Value = DateTime.Now
    End Sub

    Public Sub New(MustCreateNewProd As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()
        ProduccionID = Guid.NewGuid()
        IsNewProd = True
    End Sub
    Private Sub PopulateEstado()
        uceEstado.Items.Clear()
        uceEstado.Items.Add(String.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetEstado().Rows
            uceEstado.Items.Add(r.Item("idEstado"), r.Item("descripcionEstado"))
        Next
        uceEstado.SelectedIndex = 1
    End Sub
    Public Sub New(ByVal BriefingId As Guid, ByVal PrdId As Guid)
        InitializeComponent()
        InitializeValues()
        PopulateEstado()
        obtenerDetalleVuelo(BriefingId)
        CargarVuelo()
        ProduccionID = PrdId
        If ProduccionID.ToString = "00000000-0000-0000-0000-000000000000" Then
            ProduccionID = Guid.NewGuid()
            lblGuardado.Text = "No"
        Else
            lblGuardado.Text = "Si"
        End If
        'myCamion = CommonData.GetCamionItem(CamionId)
    End Sub
    Private Sub frmProduccionDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Calcular()
        initial = False
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
    Private Sub CargarVuelo()
        Try
            Me.txtAgencia.Text = resDtVuelo.descripcionAgencia.ToString.Trim()
            Me.txtNumVuelo.Text = resDtVuelo.codigoVuelo.ToString.Trim()
            Me.udtFechVuelo.Value = resDtVuelo.fechaVuelo
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region
    Private Sub Calcular()
        ObtenerUnidades()
        If lblGuardado.Text = "Si" Then
            ObtenerProduccionTotalesGuardados()
        Else

        End If
        ObtenerPrecios()
        Totalizar()
    End Sub

    Private Sub reCalcular()
        ObtenerPrecios()
        ObtenerUnidades()
        Totalizar()
    End Sub

    Private Sub ObtenerUnidades()
        CargarProceso()
        AlmacenajeContainer()
        CargarEstiba()
        CargarProcesamientoCargayVolumen()
        'CargarDevolucion()
        CargarPrecooling()
    End Sub

    Private Sub CargarProceso()
        Dim proceso As New ProcesoItem
        Try
            With proceso
                .idBriefing = resDtVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            myProceso = proceso
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ObtenerPrecios()
        Try
            dtPreciosTarifas = CommonData.GetTarifaporAgenciayFecha(resDtVuelo.idAgencia, resDtVuelo.fechaVuelo)
            For Each r As DataRow In dtPreciosTarifas.Rows
                'precios
                myProduccion.idTarifas = r.Item("idTarifas")
                txtAgCarP.Text = r.Item("agenteCarTar")
                txtalmCP.Text = r.Item("almacenajeConTar")
                txtAlmCorrP.Text = r.Item("almacenajeCorTar")
                txtAlmCarP.Text = r.Item("almacenajeCarTar")
                txtDevCarP.Text = r.Item("devolucionCarTar")
                TxtCorVueP.Text = r.Item("correoTar")
                txtEstibaP.Text = r.Item("estibaDesTar")
                txtLimpiezaP.Text = r.Item("limpiezaEleTar")
                txtManipuleoP.Text = r.Item("manipuleoTar")
                txtMinMesP.Text = r.Item("minimoMesTar")
                txtMinVueP.Text = r.Item("minimoVueloTar")
                txtMontCarP.Text = r.Item("montaCargaTar")
                txtPreCoolP.Text = r.Item("precoolingTar")
                txtProCarP.Text = r.Item("procesamientoCarTar")
                txtProCarVolP.Text = r.Item("procesamientoCVTar")
                txtVariosP.Text = r.Item("variosTar")
                'iva incluido
            Next
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AlmacenajeContainer()

        Dim antStr As String = String.Empty
        Dim cont As Integer = 0
        Dim cont2 As Integer = 0
        txtAlmCS.Text = 0
        dtStockElementos = CommonData.GetElementoPorAgenciaStock(resDtVuelo.idAgencia)
        For Each r As DataRow In dtStockElementos.Rows
            Dim tempStr As String = String.Empty
            Dim elem As String = String.Empty
            tempStr = r.Item("idElemento").ToString.Substring(0, 3)
            If tempStr = "AKE" Or tempStr = "AYY" Or tempStr = "ADD" Or tempStr = "AAZ" Then
                elem = r.Item("idElemento").ToString.Substring(3, r.Item("idElemento").ToString.Length - 3)
                If (antStr = "" Or cont = 1) And cont2 < 1 Then
                    antStr = tempStr
                ElseIf antStr = "" Or cont = 0 Then
                    antStr = tempStr
                End If
                If antStr = tempStr Then
                    cont += 1
                    If cont > 5 Then
                        txtAlmCS.Text = 1
                    End If
                Else
                    antStr = tempStr
                    cont = 0
                End If
                cont += 1
                cont2 += 1
            Else
                cont = 0
            End If
        Next
    End Sub

    Private Function AlmacenajeCarga() As DateTime
        Dim fechaSalida As DateTime = "01/01/3000"
        dtDetalleAcarreoReporte = CommonProcess.GetDetalleAcarreoIdProcesoReporte(myProceso.IdProceso)
        For Each r As DataRow In dtDetalleAcarreoReporte.Rows
            fechaSalida = r.Item("fechaSalida")
        Next
        Return fechaSalida
    End Function

    Sub CargarPrecooling()
        Dim totalpeso As Decimal = 0D
        dtDetalleProcesoCargaAlmacenaje = CommonProcess.GetDetalleProcesoCargaPorIdProcesoAlmacenaje(myProceso.IdProceso)
        For Each r As DataRow In dtDetalleProcesoCargaAlmacenaje.Rows
            If r.Item("estado") <> "D" Then
                totalpeso = r.Item("peso") + totalpeso
            End If
        Next
        txtPreCoolS.Value = 0 'totalpeso.ToString
    End Sub


    Sub CargarDevolucion()
        Try
            Dim totalpeso As Decimal = 0D
            Dim totalvol As Decimal = 0D
            Dim totalDias As Integer = 0

            For Each r As DataRow In dtDetalleProcesoReporte.Rows
                If r.Item("estado") <> "R" Then
                    totalDias = DateDiff("n", r.Item("fechaLlegadaCamion"), r.Item("fechaLlegadaEstimadaGuia"))
                    If totalDias <= -30 Or totalDias > 30 Then
                        totalpeso = r.Item("peso") + totalpeso
                        ' totalvol = r.Item("volumen") + totalvol
                    End If
                End If
            Next
            txtSDevolucion.Text = totalpeso.ToString
            ' txtSProcCargaVolumen.Text = totalvol.ToString
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub CargarProcesamientoCargayVolumen()
        Dim totalpeso As Decimal = 0D
        Dim totalvol As Decimal = 0D
        Dim totalpesoDev As Decimal = 0D
        Dim totalpesoAlmacenaje As Decimal = 0D
        Dim fechaAcarreoFin As DateTime = "01/01/3000"
        Dim parametro As String = ""
        Try
            fechaAcarreoFin = AlmacenajeCarga()
            dtDetalleProcesoCargaReporte = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(myProceso.IdProceso)
            dtDetalleProcesoCargaAlmacenaje = CommonProcess.GetDetalleProcesoCargaPorIdProcesoAlmacenaje(myProceso.IdProceso)
            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                If (r.Item("estado") = "A" Or r.Item("estado") = "I" Or r.Item("estado") = "D") Then
                    totalpeso = r.Item("peso") + totalpeso
                    If r.Item("volumen") < r.Item("peso") Then
                        totalvol = r.Item("peso") + totalvol
                    Else
                        totalvol = r.Item("volumen") + totalvol
                    End If
                End If

                If (r.Item("estado") = "D") Then
                    totalpesoDev = r.Item("peso") + totalpesoDev
                End If
                If r.Item("horaIni") > DateAdd(DateInterval.Day, 1, fechaAcarreoFin) Then
                    Dim foundRows() As DataRow
                    'parametro = "idGuia =" + r.Item("idGuia").ToString '+ " and 
                    parametro = "idElemento = '" + r.Item("idElemento").ToString + "' and idGuia = '" + r.Item("idGuia").ToString + "'"
                    foundRows = dtDetalleProcesoCargaAlmacenaje.Select(parametro)
                    If foundRows.Count > 0 Then
                        totalpesoAlmacenaje = r.Item("peso") + totalpesoAlmacenaje
                    End If
                End If
            Next
            txtSProcCarga.Text = totalpeso.ToString
            txtSProcCargaVolumen.Text = totalvol.ToString
            txtSDevolucion.Text = totalpesoDev.ToString
            txtSAlmCarP.Text = totalpesoAlmacenaje.ToString
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarEstiba()
        Try
            dtDetalleProcesoReporte = CommonProcess.GetDetalleProcesoPorIdProcesoReporte(myProceso.IdProceso)
            Dim totalpeso As Decimal = 0D
            For Each r As DataRow In dtDetalleProcesoReporte.Rows
                If r.Item("estado") <> "R" Then
                    totalpeso = r.Item("peso") + totalpeso
                End If
            Next
            txtEstibaS.Text = totalpeso.ToString
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerProduccionTotalesGuardados()
        Dim dtProduccion As New DataTable("Produccion")
        dtProduccion = CommonData.GetProduccionById(ProduccionID)
        For Each r As DataRow In dtProduccion.Rows
            txtAgCarTG.Value = r.Item("agenteCarPro")
            txtAlmCTG.Value = r.Item("almacenajeConPro")
            txtAlmCorrTG.Value = r.Item("almacenajeCorPro")
            'almacenajeCorPro
            txtAlmCarTG.Value = r.Item("almacenajeCarPro")
            txtDevolucionTG.Value = r.Item("devolucionCarPro")
            txtCorVueTG.Value = r.Item("correoPro")
            txtEstibaTG.Value = r.Item("estibaDesPro")
            txtLimpiezaTG.Value = r.Item("limpiezaElePro")
            'limpiezaElePro txtLimpiezaTot.Value = (Double.Parse(txtLimpiezaP.Value) * Double.Parse(txtLimpiezaS.Value)).ToString
            txtManipuleoTG.Value = r.Item("manipuleoPro")
            TxtMinMesTG.Value = r.Item("minimoMesPro")
            txtMinVueTG.Value = r.Item("minimoVueloPro")
            TxtMontCarTG.Value = r.Item("montaCargaPro")
            txtPreCoolTG.Value = r.Item("precoolingPro")
            'montaCargaPro
            'precoolingPro TxtPreCoolTot.Value = (Double.Parse(txtPreCoolP.Value) * Double.Parse(txtPreCoolS.Value)).ToString

            txtProCarTG.Value = r.Item("procesamientoCarPro")

            TxtProCarVoiPTG.Value = r.Item("procesamientoCVPro")
            TxtVariosTG.Value = r.Item("variosPro")
            uceEstado.SelectedIndex = 0
            For i As Integer = 0 To uceEstado.Items.Count - 1
                uceEstado.SelectedIndex = i
                If uceEstado.Value = r.Item("estado") Then
                    Exit For
                End If
            Next
            udtFecha.Value = r.Item("fechaPro")


        Next
        txtTotalG.Value = (Double.Parse(txtAgCarTG.Value) + Double.Parse(txtAlmCTG.Value) + Double.Parse(txtAlmCorrTG.Value) + Double.Parse(txtAlmCarTG.Value) + Double.Parse(txtDevolucionTG.Value) + Double.Parse(txtCorVueTG.Value) + Double.Parse(txtEstibaTG.Value) + Double.Parse(txtLimpiezaTG.Value) + Double.Parse(txtManipuleoTG.Value) + Double.Parse(TxtMinMesTG.Value) + Double.Parse(txtMinVueTG.Value) + Double.Parse(TxtMontCarTG.Value) + Double.Parse(txtPreCoolTG.Value) + Double.Parse(txtProCarTG.Value) + Double.Parse(TxtProCarVoiPTG.Value) + Double.Parse(TxtVariosTG.Value)).ToString
    End Sub
    Private Sub Totalizar()
        txtAgCarTot.Value = (Double.Parse(txtAgCarP.Value) * Double.Parse(txtAgCarS.Value)).ToString
        txtAlmCTot.Value = (Double.Parse(txtalmCP.Value) * Double.Parse(txtAlmCS.Value)).ToString
        '
        txtAlmCarPTot.Value = (Double.Parse(txtAlmCarP.Value) * Double.Parse(txtSAlmCarP.Value)).ToString
        TxtDevolucionTot.Value = (Double.Parse(txtDevCarP.Value) * Double.Parse(txtSDevolucion.Value)).ToString
        TxtCorVueTot.Value = (Double.Parse(TxtCorVueP.Value) * Double.Parse(TxtCorVueS.Value)).ToString
        TxtEstibaTot.Value = (Double.Parse(txtEstibaP.Value) * Double.Parse(txtEstibaS.Value)).ToString
        'txtLimpiezaTot.Value = (Double.Parse(txtLimpiezaP.Value) * Double.Parse(txtLimpiezaS.Value)).ToString
        txtManipuleoTot.Value = (Double.Parse(txtManipuleoP.Value) * Double.Parse(txtManipuleoS.Value)).ToString
        TxtMinMesTot.Value = (Double.Parse(txtMinMesP.Value) * Double.Parse(txtMinMesS.Value)).ToString
        TxtMinVueTot.Value = (Double.Parse(txtMinVueP.Value) * Double.Parse(TxtMinVueS.Value)).ToString
        '
        'TxtPreCoolTot.Value = (Double.Parse(txtPreCoolP.Value) * Double.Parse(txtPreCoolS.Value)).ToString
        TxtProCarTot.Value = (Double.Parse(txtProCarP.Value) * Double.Parse(txtSProcCarga.Value)).ToString
        TxtProcarVoiPTot.Value = (Double.Parse(txtProCarVolP.Value) * Double.Parse(txtSProcCargaVolumen.Value)).ToString

        'txtTotal.Value = (Double.Parse(txtAgCarTot.Value) + Double.Parse(txtAlmCTot.Value) + Double.Parse(TxtDevolucionTot.Value) + Double.Parse(TxtCorVueTot.Value) + Double.Parse(TxtEstibaTot.Value) + Double.Parse(txtManipuleoTot.Value) + Double.Parse(TxtMinMesTot.Value) + Double.Parse(TxtMinVueTot.Value) + Double.Parse(TxtPreCoolTot.Value) + Double.Parse(TxtProCarTot.Value) + Double.Parse(TxtProcarVoiPTot.Value)).ToString
        txtTotal.Value = (Double.Parse(txtAgCarTot.Value) + Double.Parse(txtAlmCTot.Value) + Double.Parse(txtAlmCarPTot.Value) + Double.Parse(TxtDevolucionTot.Value) + Double.Parse(TxtCorVueTot.Value) + Double.Parse(TxtEstibaTot.Value) + Double.Parse(txtManipuleoTot.Value) + Double.Parse(TxtMinMesTot.Value) + Double.Parse(TxtMinVueTot.Value) + Double.Parse(TxtProCarTot.Value) + Double.Parse(TxtProcarVoiPTot.Value)).ToString
    End Sub
    Sub totalGrabar(sender As Object)
        'sender.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        If initial = False Then
            If sender.value = "" Or Not IsNumeric(sender.value) Then
                sender.value = "0"
            End If

            txtTotalG.Value = (Double.Parse(txtAgCarTG.Value) + Double.Parse(txtAlmCTG.Value) + Double.Parse(txtAlmCorrTG.Value) + Double.Parse(txtAlmCarTG.Value) + Double.Parse(txtDevolucionTG.Value) + Double.Parse(txtCorVueTG.Value) + Double.Parse(txtEstibaTG.Value) + Double.Parse(txtLimpiezaTG.Value) + Double.Parse(txtManipuleoTG.Value) + Double.Parse(TxtMinMesTG.Value) + Double.Parse(txtMinVueTG.Value) + Double.Parse(TxtMontCarTG.Value) + Double.Parse(txtPreCoolTG.Value) + Double.Parse(txtProCarTG.Value) + Double.Parse(TxtProCarVoiPTG.Value) + Double.Parse(TxtVariosTG.Value)).ToString
        End If
    End Sub
#Region "Eventos"
    Private Sub btnRecalcular_Click(sender As Object, e As EventArgs) Handles btnRecalcular.Click
        'If MessageBox.Show("Esto recalculara todos los valores del formulario." & vbLf & "¿Desea Continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
        reCalcular()
        ' End If
    End Sub
    Private Sub txtAlmCS_ValueChanged(sender As Object, e As EventArgs) Handles txtAlmCS.ValueChanged

    End Sub
    Private Sub ugbCamion_Click(sender As Object, e As EventArgs) Handles ugbCamion.Click

    End Sub
    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        txtAgCarTG.Value = txtAgCarTot.Value
        txtAlmCTG.Value = txtAlmCTot.Value
        '
        ' txtAlmCorrTG.Value = txtAlmCarPTot.Value
        txtAlmCarTG.Value = txtAlmCarPTot.Value
        txtDevolucionTG.Value = TxtDevolucionTot.Value
        txtCorVueTG.Value = TxtCorVueTot.Value
        txtEstibaTG.Value = TxtEstibaTot.Value
        'txtLimpiezaTot.Value = (Double.Parse(txtLimpiezaP.Value) * Double.Parse(txtLimpiezaS.Value)).ToString
        txtManipuleoTG.Value = txtManipuleoTot.Value
        TxtMinMesTG.Value = TxtMinMesTot.Value
        txtMinVueTG.Value = TxtMinVueTot.Value
        '
        'TxtPreCoolTot.Value = (Double.Parse(txtPreCoolP.Value) * Double.Parse(txtPreCoolS.Value)).ToString
        txtProCarTG.Value = TxtProCarTot.Value
        TxtProCarVoiPTG.Value = TxtProcarVoiPTot.Value
        TxtVariosTG.Value = txtVariosTot.Value
        'txtTotal.Value = (Double.Parse(txtAgCarTot.Value) + Double.Parse(txtAlmCTot.Value) + Double.Parse(TxtDevolucionTot.Value) + Double.Parse(TxtCorVueTot.Value) + Double.Parse(TxtEstibaTot.Value) + Double.Parse(txtManipuleoTot.Value) + Double.Parse(TxtMinMesTot.Value) + Double.Parse(TxtMinVueTot.Value) + Double.Parse(TxtPreCoolTot.Value) + Double.Parse(TxtProCarTot.Value) + Double.Parse(TxtProcarVoiPTot.Value)).ToString
        'txtTotal.Value = (Double.Parse(txtAgCarTot.Value) + Double.Parse(txtAlmCTot.Value) + Double.Parse(TxtDevolucionTot.Value) + Double.Parse(TxtCorVueTot.Value) + Double.Parse(TxtEstibaTot.Value) + Double.Parse(txtManipuleoTot.Value) + Double.Parse(TxtMinMesTot.Value) + Double.Parse(TxtMinVueTot.Value) + Double.Parse(TxtProCarTot.Value) + Double.Parse(TxtProcarVoiPTot.Value)).ToString

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub
#End Region
#Region "Totales txt"
    Private Sub txtAgCarTG_ValueChanged(sender As Object, e As EventArgs) Handles txtAgCarTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtAlmCTG_ValueChanged(sender As Object, e As EventArgs) Handles txtAlmCTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtAlmCorrTG_ValueChanged(sender As Object, e As EventArgs) Handles txtAlmCorrTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtAlmCarTG_ValueChanged(sender As Object, e As EventArgs) Handles txtAlmCarTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtDevolucionTG_ValueChanged(sender As Object, e As EventArgs) Handles txtDevolucionTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtCorVueTG_ValueChanged(sender As Object, e As EventArgs) Handles txtCorVueTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtEstibaTG_ValueChanged(sender As Object, e As EventArgs) Handles txtEstibaTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtLimpiezaTG_ValueChanged(sender As Object, e As EventArgs) Handles txtLimpiezaTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtManipuleoTG_ValueChanged(sender As Object, e As EventArgs) Handles txtManipuleoTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub TxtMinMesTG_ValueChanged(sender As Object, e As EventArgs) Handles TxtMinMesTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtMinVueTG_ValueChanged(sender As Object, e As EventArgs) Handles txtMinVueTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub TxtMontCarTG_ValueChanged(sender As Object, e As EventArgs) Handles TxtMontCarTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtPreCoolTG_ValueChanged(sender As Object, e As EventArgs) Handles txtPreCoolTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub txtProCarTG_ValueChanged(sender As Object, e As EventArgs) Handles txtProCarTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub TxtProCarVoiPTG_ValueChanged(sender As Object, e As EventArgs) Handles TxtProCarVoiPTG.ValueChanged
        totalGrabar(sender)
    End Sub

    Private Sub TxtVariosTG_ValueChanged(sender As Object, e As EventArgs) Handles TxtVariosTG.ValueChanged
        totalGrabar(sender)
    End Sub
#End Region


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        produccionInfoToObject()
        Dim result As Boolean = CommonProcess.SaveProduccionItem(myProduccion)
        If result Then
            MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al Guardar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub produccionInfoToObject()
        myProduccion.idProduccion = ProduccionID
        'myProduccion.idTarifas = texto
        myProduccion.idBriefing = resDtVuelo.idBriefing
        myProduccion.idagencia = resDtVuelo.idAgencia
        myProduccion.fechaPro = udtFecha.Value
        myProduccion.estado = uceEstado.Value
        myProduccion.agenteCarPro = txtAgCarTG.Value
        myProduccion.almacenajeConPro = txtAlmCTG.Value
        myProduccion.almacenajeCorPro = txtAlmCorrTG.Value
        myProduccion.almacenajeCarPro = txtAlmCarTG.Value
        myProduccion.devolucionCarPro = txtDevolucionTG.Value
        myProduccion.correoPro = txtCorVueTG.Value
        myProduccion.estibaDesPro = txtEstibaTG.Value
        myProduccion.limpiezaElePro = txtLimpiezaTG.Value
        myProduccion.manipuleoPro = txtManipuleoTG.Value
        myProduccion.minimoMesPro = TxtMinMesTG.Value
        myProduccion.minimoVueloPro = txtMinVueTG.Value
        myProduccion.montaCargaPro = TxtMontCarTG.Value
        myProduccion.precoolingPro = txtPreCoolTG.Value
        myProduccion.procesamientoCarPro = txtProCarTG.Value
        myProduccion.procesamientoCVPro = TxtProCarVoiPTG.Value
        myProduccion.variosPro = TxtVariosTG.Value
        myProduccion.devCarPVPro = 0
        myProduccion.estibaPVPro = 0
    End Sub

End Class