
Public Class frmConsultaElementos
    'id = aerolineas
    ' Dim Id As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"

    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"

    Public isEntradaElemento As Boolean = False
    Public isPesajeElemento As Boolean = False
    Public Elemento As New Server.ReportService.ElementoCatalogItem
    Public IdElemento As String = ""
    Dim dtElmentos As New DataTable("Elementos")
    Dim dtTipoElementos As New DataTable("TipoElementos")
    Public Property isPreseleccionElemento As Boolean = False

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX)).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub txtElemento_ValueChanged(sender As Object, e As EventArgs) Handles txtElemento.ValueChanged
        If txtElemento.Text.Length > 0 Then
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                If InStr(r.Cells("descripcionAgencia").Value, txtElemento.Text) Or InStr(r.Cells("idElemento").Value, txtElemento.Text) Then
                    r.Hidden = False
                Else
                    r.Hidden = True
                End If
            Next
        Else
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In ugvElementos.Rows
                r.Hidden = False
            Next
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        If uceTipo.Text = "TODOS" Then
            Elemento.IdAgencia = uceAgencia.Value
            If isEntradaElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaEnSalida(Elemento)
            ElseIf isPesajeElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaEnPesaje(Elemento)
            ElseIf isPreseleccionElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaEnPreseleccion(Elemento)
            Else
                ugvElementos.DataSource = CommonData.GetElementoPorAgencia(Elemento)
            End If
        Else
            Elemento.IdAgencia = uceAgencia.Value
            Elemento.tipoElemento = uceTipo.Value
            If isEntradaElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaYTipoEnSalida(Elemento)
            ElseIf isPesajeElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaEnPesaje(Elemento)
            ElseIf isPreseleccionElemento Then
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaEnPreseleccion(Elemento)
            Else
                ugvElementos.DataSource = CommonData.GetElementoPorAgenciaYTipo(Elemento)
            End If
        End If
        RefreshData()
    End Sub

    Public Sub RefreshData()
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Codigo"
            ugvElementos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Agencia"
            ugvElementos.DisplayLayout.Bands(0).Columns("tipoElemento").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialPiso").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialPared").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialTecho").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialRed").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialPuerta").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("materialSeguros").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("alto").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("ancho").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("largo").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("pesoReferencial").Header.Caption = "Peso Referencial"
            ugvElementos.DisplayLayout.Bands(0).Columns("pesoReal").Header.Caption = "Peso Real"
            ugvElementos.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").Header.Caption = "Fecha Ingreso"
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").Format = "dd/MM/yyyy"
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            ugvElementos.DisplayLayout.Bands(0).Columns("usuarioIngreso").Header.Caption = "Usuario Ingreso"
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Header.Caption = "Fecha Ultima Actualización"
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaUltimaAct").Format = "dd/MM/yyyy"
            ugvElementos.DisplayLayout.Bands(0).Columns("fechaUltimaAct").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdAgentes_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugvElementos.DoubleClickRow
        Try
            If isPreseleccionElemento Then
                Dim frmPesoElemento As New frmPesoElemento
                Elemento.Id = ugvElementos.ActiveRow.Cells("idElemento").Value
                frmPesoElemento.myElemento = Elemento
                frmPesoElemento.ShowDialog()
                If Not frmPesoElemento.isSave Then
                    Elemento.Id = ""
                    Exit Sub
                End If
                Elemento.pesoActual = frmPesoElemento.tempPesoActual
            End If
            Elemento.Id = ugvElementos.ActiveRow.Cells("idElemento").Value
            IdElemento = ugvElementos.ActiveRow.Cells("idElemento").Value
            Elemento.IdAgencia = ugvElementos.ActiveRow.Cells("idAgencia").Value
            Elemento.descripcionAgencia = ugvElementos.ActiveRow.Cells("descripcionAgencia").Value
            Elemento.tipoElemento = ugvElementos.ActiveRow.Cells("tipoElemento").Value
            Elemento.materialPiso = ugvElementos.ActiveRow.Cells("materialPiso").Value
            Elemento.materialPared = ugvElementos.ActiveRow.Cells("materialPared").Value
            Elemento.materialTecho = ugvElementos.ActiveRow.Cells("materialTecho").Value
            Elemento.materialRed = ugvElementos.ActiveRow.Cells("materialRed").Value
            Elemento.materialPuerta = ugvElementos.ActiveRow.Cells("materialPuerta").Value
            Elemento.materialSeguros = ugvElementos.ActiveRow.Cells("materialSeguros").Value
            Elemento.alto = ugvElementos.ActiveRow.Cells("alto").Value
            Elemento.ancho = ugvElementos.ActiveRow.Cells("ancho").Value
            Elemento.largo = ugvElementos.ActiveRow.Cells("largo").Value
            Elemento.pesoReferencial = ugvElementos.ActiveRow.Cells("pesoReferencial").Value
            Elemento.pesoReal = ugvElementos.ActiveRow.Cells("pesoReal").Value
            Elemento.estado = ugvElementos.ActiveRow.Cells("estado").Value
            Elemento.fechaIngreso = ugvElementos.ActiveRow.Cells("fechaIngreso").Value
            Elemento.usuarioIngreso = ugvElementos.ActiveRow.Cells("usuarioIngreso").Value
            Elemento.fechaUltimaAct = ugvElementos.ActiveRow.Cells("fechaUltimaAct").Value
            Me.Close()
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cargarComboTipoElemento()
        Try
            dtTipoElementos = CommonData.GetTipoElementoCatalog
            uceTipo.Clear()
            For Each r As DataRow In dtTipoElementos.Rows
                uceTipo.Items.Add(r.Item("idTipo"), r.Item("codigo") + " " + r.Item("descripcionTipo"))
            Next
            uceTipo.Items.Add(Guid.Empty, "TODOS")
            uceTipo.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmConsultaElementos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            cargarComboAgencia()
            cargarComboTipoElemento()
            Elemento.IdAgencia = uceAgencia.Value
            Elemento.tipoElemento = uceTipo.Value
            ugvElementos.DataSource = CommonData.GetElementoPorAgenciaYTipo(Elemento)
            RefreshData()
        Catch ex As Exception
            General.SetLogEvent(ex)
        End Try
    End Sub
End Class