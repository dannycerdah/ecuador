Public Class FrmConsultaVuelosGuias
    Private DescripcionAgencia As String
    Private IdAgencia As Guid
    Private DtVuelosGuias As New DataTable("DtVuelosGuias")
    Public CodigoVuelo As String
    Public Guia As String
    Public IdBriefing As Guid
    Public IdGuia As Guid
    Public IdProceso As Guid
    Public IdElemento As String
    Private ObtenerElememto As Boolean = False
    Private DatosTempBitacoraCuarto As New Server.ControlTemp.TempBitacoraCuarto

    Public Sub New(DescripcionAgencia_ As String, IdAgencia_ As Guid)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IdAgencia = IdAgencia_
        DescripcionAgencia = DescripcionAgencia_
    End Sub
    Public Sub New(DescripcionAgencia_ As String, IdAgencia_ As Guid, ObtenerElememto_ As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IdAgencia = IdAgencia_
        DescripcionAgencia = DescripcionAgencia_
        ObtenerElememto = True
    End Sub
    Private Sub FrmConsultaVuelosGuias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DtVuelosGuias.Columns
            .Add("idBriefing", GetType(Guid))
            .Add("idVuelo", GetType(Guid))
            .Add("idAgencia", GetType(Guid))
            .Add("idProceso", GetType(Guid))
            .Add("descripcionAgencia", GetType(String))
            .Add("codigoVuelo", GetType(String))
            .Add("idGuia", GetType(Guid))
            .Add("Guia", GetType(String))
            .Add("idElemento", GetType(String))
            .Add("fechaVuelo", GetType(DateTime))
            .Add("llegadaVuelo", GetType(DateTime))
            .Add("salidaVuelo", GetType(DateTime))
        End With
        ugdVuelos.DataSource = DtVuelosGuias
        ConsultarVuelosGuiasHoy()
        txtAreroLinea.Text = DescripcionAgencia
        txtAreroLinea.Enabled = False
    End Sub
    Private Sub ConsultarVuelosGuiasHoy()
        Dim rows As DataRow
        If ObtenerElememto Then
            With DatosTempBitacoraCuarto
                .TipoConsulta = 0
                .idAgencia = IdAgencia
                .fechaInicio = Now()
                .fechaFin = Now()
            End With
            For Each r As DataRow In CommonData.ObtenerVuelosElemen(DatosTempBitacoraCuarto).Rows
                rows = DtVuelosGuias.NewRow
                rows.Item("idBriefing") = r.Item("idBriefing")
                rows.Item("idProceso") = r.Item("idProceso")
                rows.Item("idVuelo") = r.Item("idVuelo")
                rows.Item("idAgencia") = r.Item("idAgencia")
                rows.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                rows.Item("fechaVuelo") = r.Item("fechaVuelo")
                rows.Item("llegadaVuelo") = r.Item("llegadaVuelo")
                rows.Item("salidaVuelo") = r.Item("salidaVuelo")
                rows.Item("idGuia") = r.Item("idGuia")
                rows.Item("Guia") = r.Item("Guia")
                rows.Item("idElemento") = r.Item("idElemento")
                DtVuelosGuias.Rows.Add(rows)
            Next
        Else
            For Each r As DataRow In CommonDataFact.GetVuelosGuias(0, IdAgencia, Now(), Now()).Rows
                rows = DtVuelosGuias.NewRow
                rows.Item("idBriefing") = r.Item("idBriefing")
                rows.Item("idVuelo") = r.Item("idVuelo")
                rows.Item("idAgencia") = r.Item("idAgencia")
                rows.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                rows.Item("fechaVuelo") = r.Item("fechaVuelo")
                rows.Item("llegadaVuelo") = r.Item("llegadaVuelo")
                rows.Item("salidaVuelo") = r.Item("salidaVuelo")
                rows.Item("idGuia") = r.Item("idGuia")
                rows.Item("Guia") = r.Item("Guia")
                DtVuelosGuias.Rows.Add(rows)
            Next
        End If
        SetDisplayedColumns()
    End Sub
    Private Sub SetDisplayedColumns()
        Try
            If Not ObtenerElememto Then
                ugdVuelos.DisplayLayout.Bands(0).Columns("idElemento").Hidden = True
            End If
            ugdVuelos.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idGuia").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
            ugdVuelos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Aerolinea de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Número de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").Header.Caption = "Fecha de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").Format = "dd/MM/yyyy"
            ugdVuelos.DisplayLayout.Bands(0).Columns("fechaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").Header.Caption = "Llegada Estimada de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").Format = "dd/MM/yyyy H:mm"
            ugdVuelos.DisplayLayout.Bands(0).Columns("llegadaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").Header.Caption = "Salida Estimada de Vuelo"
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").Format = "dd/MM/yyyy H:mm"
            ugdVuelos.DisplayLayout.Bands(0).Columns("salidaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim rows As DataRow
        DtVuelosGuias.Clear()
        If ObtenerElememto Then
            With DatosTempBitacoraCuarto
                .TipoConsulta = 1
                .idAgencia = IdAgencia
                .fechaInicio = udtDesde.Value
                .fechaFin = udtHasta.Value
            End With
            For Each r As DataRow In CommonData.ObtenerVuelosElemen(DatosTempBitacoraCuarto).Rows
                rows = DtVuelosGuias.NewRow
                rows.Item("idBriefing") = r.Item("idBriefing")
                rows.Item("idProceso") = r.Item("idProceso")
                rows.Item("idVuelo") = r.Item("idVuelo")
                rows.Item("idAgencia") = r.Item("idAgencia")
                rows.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                rows.Item("fechaVuelo") = r.Item("fechaVuelo")
                rows.Item("llegadaVuelo") = r.Item("llegadaVuelo")
                rows.Item("salidaVuelo") = r.Item("salidaVuelo")
                rows.Item("idGuia") = r.Item("idGuia")
                rows.Item("Guia") = r.Item("Guia")
                rows.Item("idElemento") = r.Item("idElemento")
                DtVuelosGuias.Rows.Add(rows)
            Next
        Else
            For Each r As DataRow In CommonDataFact.GetVuelosGuias(1, IdAgencia, udtDesde.Value, udtHasta.Value).Rows
                rows = DtVuelosGuias.NewRow
                rows.Item("idBriefing") = r.Item("idBriefing")
                rows.Item("idVuelo") = r.Item("idVuelo")
                rows.Item("idAgencia") = r.Item("idAgencia")
                rows.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                rows.Item("codigoVuelo") = r.Item("codigoVuelo")
                rows.Item("fechaVuelo") = r.Item("fechaVuelo")
                rows.Item("llegadaVuelo") = r.Item("llegadaVuelo")
                rows.Item("salidaVuelo") = r.Item("salidaVuelo")
                rows.Item("Guia") = r.Item("Guia")
                rows.Item("idGuia") = r.Item("idGuia")
                DtVuelosGuias.Rows.Add(rows)
            Next
            SetDisplayedColumns()
        End If

    End Sub
    Private Sub ugdVuelos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdVuelos.DoubleClickCell
        If ObtenerElememto Then
            IdElemento = ugdVuelos.ActiveRow.Cells("IdElemento").Value
            IdProceso = ugdVuelos.ActiveRow.Cells("IdProceso").Value
        End If
        CodigoVuelo = ugdVuelos.ActiveRow.Cells("codigoVuelo").Value
        Guia = ugdVuelos.ActiveRow.Cells("Guia").Value
        IdBriefing = ugdVuelos.ActiveRow.Cells("idBriefing").Value
        IdGuia = ugdVuelos.ActiveRow.Cells("IdGuia").Value
        Me.Close()
    End Sub
    Private Sub txtContacto_ValueChanged(sender As Object, e As EventArgs) Handles txtVueloGuia.ValueChanged
        If txtVueloGuia.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdVuelos.Rows
                If ObtenerElememto Then
                    If InStr(r.Cells("codigoVuelo").Value, txtVueloGuia.Text) <> 0 Or InStr(r.Cells("Guia").Value, txtVueloGuia.Text) <> 0 Or InStr(r.Cells("IdElemento").Value, txtVueloGuia.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                Else
                    If InStr(r.Cells("codigoVuelo").Value, txtVueloGuia.Text) <> 0 Or InStr(r.Cells("Guia").Value, txtVueloGuia.Text) <> 0 Then
                        r.Hidden = False
                    Else
                        r.Hidden = True
                    End If
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugdVuelos.Rows
                r.Hidden = False
            Next
        End If
    End Sub
End Class
