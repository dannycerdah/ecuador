Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Imports SPC.Server.ProcesoService
Public Class frmDecomiso
    Dim dtDetalleProcesoDecomiso As New DataTable("dtDetalleProcesoDecomiso")
    Dim dtDetalleProcesoDaePiezaDecomiso As New DataTable("dtDetalleProcesoDaePiezaDecomiso")
    Dim myDetalleVuelo As New DetalleVuelo
    Dim frmDetalleDecomiso As frmDecomisoDetalle

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
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
                CargarVuelo(frmConsultaVuelos.Aerolinea)
            End If

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarVuelo(ByVal Aerolinea As String)
        consultaProcesoDecomiso()
    End Sub

    Private Sub consultaProcesoDecomiso()
        Dim proceso As New ProcesoItem
        Try
            With proceso
                .idBriefing = myDetalleVuelo.idBriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
            If Not proceso Is Nothing Then
                Dim nr As DataRow
                Dim nrdae As DataRow
                For Each r As DataRow In CommonProcess.GetDetalleProcesoDecomisoPorIdProceso(proceso.IdProceso).Rows
                    nr = dtDetalleProcesoDecomiso.NewRow
                    nr.Item("idProceso") = r.Item("idProceso")
                    nr.Item("idBriefing") = r.Item("idBriefing")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("dae") = r.Item("dae")
                    nr.Item("camion") = r.Item("matriculaCamion")
                    nr.Item("idChofer") = r.Item("idContacto")
                    nr.Item("fechaCamion") = r.Item("fechaCamion")
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                    nr.Item("agenciaTransporteDescripcion") = r.Item("agenciaTransporteDescripcion")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("descripcionProducto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    nr.Item("eds") = r.Item("eds")
                    nr.Item("AgenciaCamion") = r.Item("AgenciaCamion")
                    nr.Item("descripcionCamion") = r.Item("descripcionCamion") 'JRO 01022018
                    dtDetalleProcesoDecomiso.Rows.Add(nr)
                Next
                For Each r As DataRow In CommonProcess.GetDetalleProcesoDecomisoDaePorIdProceso(proceso.IdProceso).Rows
                    nrdae = dtDetalleProcesoDaePiezaDecomiso.NewRow
                    nrdae.Item("idGuia") = r.Item("idGuia")
                    nrdae.Item("guia") = r.Item("guia")
                    nrdae.Item("dae") = r.Item("dae")
                    nrdae.Item("piezas") = r.Item("piezas")
                    nrdae.Item("peso") = r.Item("peso")
                    nrdae.Item("descripcionProducto") = r.Item("descripcionProducto")
                    dtDetalleProcesoDaePiezaDecomiso.Rows.Add(nrdae)
                Next
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub frmAcarreo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            With dtDetalleProcesoDecomiso.Columns
                .Add("idProceso", GetType(Guid))
                .Add("idBriefing", GetType(Guid))
                .Add("fecha", GetType(Date))
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("dae", GetType(String))
                .Add("camion", GetType(String))
                .Add("idChofer", GetType(String))
                .Add("fechaCamion", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("agenciaTransporte", GetType(Guid))
                .Add("agenciaTransporteDescripcion", GetType(String))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("volumen", GetType(Double))
                .Add("idProducto", GetType(Guid))
                .Add("descripcionProducto", GetType(String))
                .Add("rx", GetType(Integer))
                .Add("man", GetType(Integer))
                .Add("k9", GetType(Integer))
                .Add("eds", GetType(Integer))
                .Add("AgenciaCamion", GetType(String)) 'Se egrea para poder tener la agencia a la que pertenece el camion registrado
                .Add("descripcionCamion", GetType(String)) 'Se egrea para poder tener la descripcion a la que pertenece el camion registrado
            End With
            ugvDetalleProcesoDecomiso.DataSource = dtDetalleProcesoDecomiso
            With dtDetalleProcesoDaePiezaDecomiso.Columns
                .Add("idGuia", GetType(Guid))
                .Add("guia", GetType(String))
                .Add("dae", GetType(String))
                .Add("piezas", GetType(Integer))
                .Add("peso", GetType(Double))
                .Add("descripcionProducto", GetType(String))
            End With
            SetDisplayedColumnsElemento()
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsElemento()
        Try
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idChofer").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("camion").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("fechaCamion").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("guia").Header.Caption = "Guia"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("agenciaTransporte").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("agenciaTransporteDescripcion").Header.Caption = "Agencia Transporte"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("piezas").Header.Caption = "T. Piezas"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("peso").Header.Caption = "Peso Real"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("volumen").Header.Caption = "Peso Volumen"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("idProducto").Hidden = True
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("descripcionProducto").Header.Caption = "Producto"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("rx").Header.Caption = "RX"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("man").Header.Caption = "MAN"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("k9").Header.Caption = "K9"
            ugvDetalleProcesoDecomiso.DisplayLayout.Bands(0).Columns("eds").Header.Caption = "EDS"
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub

    Private Sub ugvDetalleProcesoDecomiso_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugvDetalleProcesoDecomiso.DoubleClickCell
        Try
            If ugvDetalleProcesoDecomiso.ActiveRow.Cells("idGuia").Value.ToString <> String.Empty Then
                    ShowDecomisoDetails(ugvDetalleProcesoDecomiso.ActiveRow.Cells("idGuia").Value)
            End If
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowDecomisoDetails(idGuia As Guid)
        Using frmDetalleDecomiso As New frmDecomisoDetalle()
            Dim nr As DataRow
            Dim row As DataRow()
            Dim tablas As New DataTable()
            For Each r As DataRow In dtDetalleProcesoDecomiso.Rows
                If r.Item("idGuia") = idGuia Then
                    nr = frmDetalleDecomiso.dtDetalleProcesoDecomiso.NewRow
                    nr.Item("idProceso") = r.Item("idProceso")
                    nr.Item("idBriefing") = r.Item("idBriefing")
                    nr.Item("fecha") = r.Item("fecha")
                    nr.Item("idGuia") = r.Item("idGuia")
                    nr.Item("guia") = r.Item("guia")
                    nr.Item("dae") = r.Item("dae")
                    nr.Item("camion") = r.Item("camion")
                    nr.Item("idChofer") = r.Item("idChofer")
                    nr.Item("fechaCamion") = r.Item("fechaCamion")
                    nr.Item("idElemento") = r.Item("idElemento")
                    nr.Item("agenciaTransporte") = r.Item("agenciaTransporte")
                    nr.Item("agenciaTransporteDescripcion") = r.Item("agenciaTransporteDescripcion")
                    nr.Item("piezas") = r.Item("piezas")
                    nr.Item("peso") = r.Item("peso")
                    nr.Item("volumen") = r.Item("volumen")
                    nr.Item("idProducto") = r.Item("idProducto")
                    nr.Item("descripcionProducto") = r.Item("descripcionProducto")
                    nr.Item("rx") = r.Item("rx")
                    nr.Item("man") = r.Item("man")
                    nr.Item("k9") = r.Item("k9")
                    nr.Item("eds") = r.Item("eds")
                    nr.Item("AgenciaCamion") = r.Item("AgenciaCamion")
                    nr.Item("descripcionCamion") = r.Item("descripcionCamion") 'JRO 01022018
                    frmDetalleDecomiso.dtDetalleProcesoDecomiso.Rows.Add(nr)
                    tablas = dtDetalleProcesoDaePiezaDecomiso.Clone
                    row = dtDetalleProcesoDaePiezaDecomiso.Select("idGuia='" & idGuia.ToString & "'")
                    For Each myrow As DataRow In row
                        tablas.ImportRow(myrow)
                    Next
                End If
            Next
            If tablas.Rows.Count > 0 Then
                frmDetalleDecomiso.dtDetalleProcesoDaeDecomiso = tablas
            End If
            frmDetalleDecomiso.ShowDialog()
        End Using
    End Sub

End Class