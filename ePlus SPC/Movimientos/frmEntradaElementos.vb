Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmEntradaElementos
    Dim myDetalleVuelo As New DetalleVuelo
    Dim dtElemento As New DataTable("Elementos")
    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim agencia2 As String = "65ec9238-d302-49e9-bbb5-038e1caea03c"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Limpiar()
    End Sub

    Private Sub btnConsultaElemento_Click(sender As Object, e As EventArgs) Handles btnConsultaElemento.Click
        Try
            Dim frmConsultaElemento As New frmConsultaElementos
            frmConsultaElemento.isEntradaElemento = True
            frmConsultaElemento.ShowDialog()
            If frmConsultaElemento.Elemento.Id <> "" Then
                Dim elemento As ElementoCatalogItem = frmConsultaElemento.Elemento
                For Each re As DataRow In dtElemento.Rows
                    If elemento.Id = re.Item("idElemento") Then
                        MessageBox.Show("Elemento ya Ingresado, Por favor verifique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Next
                Dim r As DataRow
                r = dtElemento.NewRow
                r.Item("idElemento") = elemento.Id
                r.Item("idAgencia") = elemento.IdAgencia
                r.Item("descripcionAgencia") = elemento.descripcionAgencia
                r.Item("pesoRef") = elemento.pesoReferencial
                r.Item("pesoReal") = elemento.pesoReal
                r.Item("fechaIngreso") = elemento.fechaIngreso
                r.Item("indice") = Guid.NewGuid
                r.Item("estado") = elemento.estado
                dtElemento.Rows.Add(r)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConsultaElementos()
        Dim tempElementoBriefing As New ElementoBriefingItem
        Try
            tempElementoBriefing.idBriefing = myDetalleVuelo.idBriefing
            For Each r As DataRow In CommonProcess.GetElementoBriefingPorIdBriefing(tempElementoBriefing).Rows
                Dim elemento As New ElementoCatalogItem
                elemento = CommonData.GetElementoItem(r.Item("idElemento"))
                If Not IsNothing(elemento) Then
                    Dim r2 As DataRow
                    r2 = dtElemento.NewRow
                    r2.Item("idElemento") = elemento.Id
                    r2.Item("idAgencia") = elemento.IdAgencia
                    r2.Item("descripcionAgencia") = elemento.descripcionAgencia
                    r2.Item("pesoRef") = elemento.pesoReferencial
                    r2.Item("pesoReal") = elemento.pesoReal
                    r2.Item("fechaIngreso") = elemento.fechaIngreso
                    r2.Item("indice") = r.Item("indice")
                    dtElemento.Rows.Add(r2)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmPreseleccionElementos_Load(sender As Object, e As EventArgs) Handles Me.Load
        'btnConsultaElemento.Enabled = False

        With dtElemento.Columns
            .Add("idElemento", GetType(String))
            .Add("idAgencia", GetType(Guid))
            .Add("descripcionAgencia", GetType(String))
            .Add("pesoRef", GetType(Double))
            .Add("pesoReal", GetType(Double))
            .Add("fechaIngreso", GetType(DateTime))
            .Add("indice", GetType(Guid))
            .Add("estado", GetType(String))
        End With

        ugvElementos.DataSource = dtElemento
        SetDisplayedColumnsElementos()
        cargarComboAgencia()
        cargarComboAgenciaRampa()

    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(IIf(My.Settings.LoginEmpr = 1, AgenciaAerolinea, AgenciaAerolineaEX)).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub cargarComboAgenciaRampa()
        uceAgenciaRampa.Items.Clear()
        uceAgenciaRampa.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(agencia2).Rows
            uceAgenciaRampa.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgenciaRampa.SelectedIndex = 0
    End Sub

    Private Sub SetDisplayedColumnsElementos()
        ugvElementos.DisplayLayout.Bands(0).Columns("idElemento").Header.Caption = "Elemento"
        ugvElementos.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
        ugvElementos.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Compañia"
        ugvElementos.DisplayLayout.Bands(0).Columns("pesoRef").Header.Caption = "Peso Referencial"
        ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").Header.Caption = "Fecha Ingreso"
        ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").Format = "dd/MM/yyyy"
        ugvElementos.DisplayLayout.Bands(0).Columns("fechaIngreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        ugvElementos.DisplayLayout.Bands(0).Columns("indice").Hidden = True
        ugvElementos.DisplayLayout.Bands(0).Columns("estado").Hidden = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim myElementoIngresoPlataforma As New ElementoCatalogItem
        Dim resultR As Boolean = False
        For Each r As DataRow In dtElemento.Rows
            resultR = False
            Dim result As Boolean = False
            Dim req As New ElementoRequest
            Dim res As New ElementoResponse
            Dim WsClnt As New ReportServiceSoapClient
            Try
                myElementoIngresoPlataforma.Id = r.Item("IdElemento")
                myElementoIngresoPlataforma.fechaUltimaAct = DateTime.Now
                myElementoIngresoPlataforma.usuarioIngreso = MyCurrentUser.userName
                myElementoIngresoPlataforma.estado = "A"
                myElementoIngresoPlataforma.chofer = uceChofer.Value
                myElementoIngresoPlataforma.mula = uceMula.Value
                myElementoIngresoPlataforma.fechaIngresoPlataforma = DateTime.Now
                General.SetBARequest(req)
                req.myElementoItem = myElementoIngresoPlataforma
                res = WsClnt.SaveElementoIngresoPlataforma(req)
                If res.ActionResult Then
                    resultR = True
                    Try
                        Dim resul As Boolean
                        Dim elementoHistorico As New ElementoHistoricoItem
                        elementoHistorico.Id = Guid.NewGuid
                        elementoHistorico.idElemento = myElementoIngresoPlataforma.Id
                        elementoHistorico.pesoElemento = myElementoIngresoPlataforma.pesoReal
                        elementoHistorico.estadoElemento = myElementoIngresoPlataforma.estado
                        elementoHistorico.tipoRegistro = "ING"
                        elementoHistorico.fecha = DateTime.Now
                        elementoHistorico.usuario = MyCurrentUser.userName
                        elementoHistorico.idProceso = Guid.Empty
                        elementoHistorico.idVuelo = Guid.Empty
                        resul = CommonData.SaveElementoHistorico(elementoHistorico)
                    Catch ex As Exception
                        ErrorManager.SetLogEvent(ex)
                    End Try
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
        If resultR Then
            MessageBox.Show("Registro Actualizado con Éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub uceAgenciaRampa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles uceAgenciaRampa.SelectionChangeCommitted
        uceMula.Items.Clear()
        uceMula.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetDollyPorIdAgencia(uceAgenciaRampa.Value).Rows
            uceMula.Items.Add(r.Item("idDolly"), r.Item("codigoDolly"))
        Next
        uceMula.SelectedIndex = 0

        uceChofer.Items.Clear()
        uceChofer.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetContactoAgenciaPorIdAgencia(uceAgenciaRampa.Value).Rows
            uceChofer.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") + " " + r.Item("SegundoApellidoContacto") + " " + r.Item("primerNombreContacto"))
        Next
        uceChofer.SelectedIndex = 0
    End Sub


End Class