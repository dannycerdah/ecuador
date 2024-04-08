Imports SPC.Server.ReportService
Public Class frmHistorialElementoDetalle
    Public elemento As New ElementoCatalogItem
    Dim dtHistorialDetalle As New DataTable("Historial")
    Dim dt As New DataTable
    Dim nr As DataRow
    Public elementoHistorico As New ElementoHistoricoItem

    Private Sub frmHistorialElementoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            With dtHistorialDetalle.Columns
                .Add("idRegistro", GetType(Guid))
                .Add("descripcionAgencia", GetType(String))
                .Add("idElemento", GetType(String))
                .Add("pesoElemento", GetType(Double))
                .Add("estadoElemento", GetType(String))
                .Add("tipoRegistro", GetType(String))
                .Add("tipo", GetType(String))
                .Add("procedencia", GetType(String))
                .Add("destino", GetType(String))
                .Add("fecha", GetType(DateTime))
                .Add("usuario", GetType(String))
                .Add("idProceso", GetType(Guid))
                .Add("idVuelo", GetType(Guid))
                .Add("nombreUsuario", GetType(String))
                .Add("codigoVuelo", GetType(String))
                .Add("fechaVuelo", GetType(DateTime))
                .Add("nombreChofer", GetType(String))
                .Add("nombreCustodio", GetType(String))
                .Add("nombreControl", GetType(String))
                .Add("nombreBascula", GetType(String))
            End With
            txtElemento.Text = elemento.Id
            elementoHistorico.idElemento = elemento.Id
            If elementoHistorico.ln_chekFecha = 1 And elementoHistorico.idAgencia = Guid.Empty Then
                ObtenerHistorialElementosPorAgenciaFecha()
            ElseIf elementoHistorico.idAgencia <> Guid.Empty Then
                ObtenerHistorialElementosPorAgencia()
            ElseIf elementoHistorico.idAgencia = Guid.Empty And elementoHistorico.ln_chekFecha = 0 Then
                ObtenerHistorialElementosPorElemento()
            End If

            setTipoRegistroHistorial()
            ugdHistorial.DataSource = dtHistorialDetalle
            setDisplayedColumns()
        Catch ex As Exception
            General.SetLogEvent(ex, "Load Elemento Historico Detalle")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub setDisplayedColumns()
        Try
            ugdHistorial.DisplayLayout.Bands(0).Columns("idRegistro").Hidden = True
            ugdHistorial.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Código Elemento"
            ugdHistorial.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Agencia"
            ugdHistorial.DisplayLayout.Bands(0).Columns("pesoElemento").Header.Caption = "Peso Elemento"
            ugdHistorial.DisplayLayout.Bands(0).Columns("estadoElemento").Hidden = True
            ugdHistorial.DisplayLayout.Bands(0).Columns("tipoRegistro").Header.Caption = "Tipo de Registro"
            'MARZ - 12-07-2017
            ugdHistorial.DisplayLayout.Bands(0).Columns("tipo").Hidden = True
            ugdHistorial.DisplayLayout.Bands(0).Columns("procedencia").Header.Caption = "Procedencia"
            ugdHistorial.DisplayLayout.Bands(0).Columns("destino").Header.Caption = "Destino"
            'MARZ
            ugdHistorial.DisplayLayout.Bands(0).Columns("fecha").Header.Caption = "Fecha Registro"
            ugdHistorial.DisplayLayout.Bands(0).Columns("usuario").Header.Caption = "Id Usuario"
            ugdHistorial.DisplayLayout.Bands(0).Columns("nombreUsuario").Header.Caption = "Nombre Usuario"
            ugdHistorial.DisplayLayout.Bands(0).Columns("idProceso").Hidden = True
            ugdHistorial.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True
            ugdHistorial.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Vuelo"
            ugdHistorial.DisplayLayout.Bands(0).Columns("fechaVuelo").Header.Caption = "Fecha Vuelo"
            ugdHistorial.DisplayLayout.Bands(0).Columns("fecha").Format = "dd/MM/yyyy HH:mm:ss"
            ugdHistorial.DisplayLayout.Bands(0).Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdHistorial.DisplayLayout.Bands(0).Columns("fechaVuelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugdHistorial.DisplayLayout.Bands(0).Columns("fechaVuelo").Format = "dd/MM/yyyy" 'MARZ
            'ugdHistorial.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        Catch ex As Exception
            General.SetLogEvent(ex, "setDisplayedColumns ElementoHistoricoDetalle")
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub setTipoRegistroHistorial()
        Try
            dtHistorialDetalle.Columns.Item("tipoRegistro").MaxLength = 30
            For Each r As DataRow In dtHistorialDetalle.Rows
                'MARZ
                If Not DBNull.Value.Equals(r.Item("tipo")) Then
                    If r.Item("tipo") = "E" Then
                        r.Item("destino") = ""
                    Else
                        r.Item("procedencia") = ""
                    End If
                End If
                'MARZ
                If r.Item("estadoElemento") = "A" And r.Item("tipoRegistro") = "CRE" Then
                    r.Item("tipoRegistro") = "CREACIÓN" 'CREACIÓN 
                End If
                If r.Item("estadoElemento") = "D" And r.Item("tipoRegistro") = "ING" Then
                    r.Item("tipoRegistro") = "RECEPCION (ULD)" 'INGRESO (ULD)
                End If
                If r.Item("estadoElemento") = "P" And r.Item("tipoRegistro") = "ACT" Then
                    r.Item("tipoRegistro") = "PRE-SELECCIÓN" 'PESO PRE-SELECCIÓN
                End If
                If r.Item("estadoElemento") = "D" And r.Item("tipoRegistro") = "PRE" Then
                    r.Item("tipoRegistro") = "PALETIZAJE"  ' "PRE-SELECCIÓN"
                End If
                If r.Item("tipoRegistro") = "MOD" Then
                    r.Item("tipoRegistro") = "MODIFICACIÓN SISTEMA" 'MODIFICACIÓN
                End If
                If r.Item("tipoRegistro") = "CRE" Then
                    r.Item("tipoRegistro") = "CREACIÓN SISTEMA" 'CREACIÓN
                End If
                If r.Item("tipoRegistro") = "SAL" Then
                    'MARZ
                    If r.Item("idProceso") = Guid.Empty Then
                        r.Item("tipoRegistro") = "ENTREGA (ULD)" 'SALIDA (ULD)
                    Else
                        r.Item("tipoRegistro") = "ACARREO" 'ACARREO
                        r.Item("destino") = "AVION"
                    End If
                    'MARZ
                End If
                If r.Item("estadoElemento") = "D" And r.Item("tipoRegistro") = "ACT" Then
                    r.Item("tipoRegistro") = "COMPARACION" '"PESAJE"
                End If
            Next
        Catch ex As Exception
            General.SetLogEvent(ex, "setTipoRegistroHistorial ElementoHistoricoDetalle")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdHistorial)
    End Sub
    Private Sub ObtenerHistorialElementosPorAgencia()
        Try
            For Each r As DataRow In CommonData.GetElementoTotalPorAgencia(elemento).Rows
                elementoHistorico.idElemento = r.Item("idElemento")
                dt = CommonData.GetElementoHistoricoPorIdElemento(elementoHistorico)
                For Each i As DataRow In dt.Rows
                    nr = dtHistorialDetalle.NewRow
                    nr.Item("idRegistro") = i.Item("idRegistro")
                    nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                    nr.Item("idElemento") = i.Item("idElemento")
                    nr.Item("pesoElemento") = i.Item("pesoElemento")
                    nr.Item("estadoElemento") = i.Item("estadoElemento")
                    nr.Item("tipoRegistro") = i.Item("tipoRegistro")
                    nr.Item("tipo") = i.Item("tipo")
                    nr.Item("procedencia") = i.Item("procedencia")
                    nr.Item("destino") = i.Item("destino")
                    nr.Item("fecha") = i.Item("fecha")
                    nr.Item("usuario") = i.Item("usuario")
                    nr.Item("idProceso") = i.Item("idProceso")
                    nr.Item("idVuelo") = i.Item("idVuelo")
                    nr.Item("nombreUsuario") = i.Item("nombreUsuario")
                    nr.Item("codigoVuelo") = i.Item("codigoVuelo")
                    nr.Item("fechaVuelo") = i.Item("fechaVuelo")
                    nr.Item("nombreChofer") = i.Item("nombreChofer")
                    nr.Item("nombreCustodio") = i.Item("nombreCustodio")
                    nr.Item("nombreControl") = i.Item("nombreControl")
                    nr.Item("nombreBascula") = i.Item("nombreBascula")
                    dtHistorialDetalle.Rows.Add(nr)
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ObtenerHistorialElementosPorAgenciaFecha()
        Try
            For Each a As DataRow In CommonData.GetAgenciaPorTipo("04be18e6-fd0c-4466-aed2-04b0e8025772").Rows
                elemento.IdAgencia = a.Item("idAgencia")
                For Each r As DataRow In CommonData.GetElementoTotalPorAgencia(elemento).Rows
                    elementoHistorico.idElemento = r.Item("idElemento")
                    dt = CommonData.GetElementoHistoricoPorIdElemento(elementoHistorico)
                    For Each i As DataRow In dt.Rows
                        nr = dtHistorialDetalle.NewRow
                        nr.Item("idRegistro") = i.Item("idRegistro")
                        nr.Item("descripcionAgencia") = r.Item("descripcionAgencia")
                        nr.Item("idElemento") = i.Item("idElemento")
                        nr.Item("pesoElemento") = i.Item("pesoElemento")
                        nr.Item("estadoElemento") = i.Item("estadoElemento")
                        nr.Item("tipoRegistro") = i.Item("tipoRegistro")
                        nr.Item("tipo") = i.Item("tipo")
                        nr.Item("procedencia") = i.Item("procedencia")
                        nr.Item("destino") = i.Item("destino")
                        nr.Item("fecha") = i.Item("fecha")
                        nr.Item("usuario") = i.Item("usuario")
                        nr.Item("idProceso") = i.Item("idProceso")
                        nr.Item("idVuelo") = i.Item("idVuelo")
                        nr.Item("nombreUsuario") = i.Item("nombreUsuario")
                        nr.Item("codigoVuelo") = i.Item("codigoVuelo")
                        nr.Item("fechaVuelo") = i.Item("fechaVuelo")
                        nr.Item("nombreChofer") = i.Item("nombreChofer")
                        nr.Item("nombreCustodio") = i.Item("nombreCustodio")
                        nr.Item("nombreControl") = i.Item("nombreControl")
                        nr.Item("nombreBascula") = i.Item("nombreBascula")
                        dtHistorialDetalle.Rows.Add(nr)
                    Next
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtenerHistorialElementosPorElemento()
        Try
            dt = CommonData.GetElementoHistoricoPorIdElemento(elementoHistorico)
            For Each i As DataRow In dt.Rows
                nr = dtHistorialDetalle.NewRow
                nr.Item("idRegistro") = i.Item("idRegistro")
                nr.Item("idElemento") = i.Item("idElemento")
                nr.Item("pesoElemento") = i.Item("pesoElemento")
                nr.Item("estadoElemento") = i.Item("estadoElemento")
                nr.Item("tipoRegistro") = i.Item("tipoRegistro")
                nr.Item("tipo") = i.Item("tipo")
                nr.Item("procedencia") = i.Item("procedencia")
                nr.Item("destino") = i.Item("destino")
                nr.Item("fecha") = i.Item("fecha")
                nr.Item("usuario") = i.Item("usuario")
                nr.Item("idProceso") = i.Item("idProceso")
                nr.Item("idVuelo") = i.Item("idVuelo")
                nr.Item("nombreUsuario") = i.Item("nombreUsuario")
                nr.Item("codigoVuelo") = i.Item("codigoVuelo")
                nr.Item("fechaVuelo") = i.Item("fechaVuelo")
                nr.Item("nombreChofer") = i.Item("nombreChofer")
                nr.Item("nombreCustodio") = i.Item("nombreCustodio")
                nr.Item("nombreControl") = i.Item("nombreControl")
                nr.Item("nombreBascula") = i.Item("nombreBascula")
                dtHistorialDetalle.Rows.Add(nr)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
