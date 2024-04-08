Imports SPC.Server.VuelosService
Imports SPC.Server.ReportService
Public Class frmPreseleccionElementos
    Dim myDetalleVuelo As New DetalleVuelo
    Dim dtElemento As New DataTable("Elementos")
    Dim myElemento As New ElementoCatalogItem

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Limpiar()
        txtVuelo.Clear()
        txtMatricula.Clear()
        txtAvion.Clear()
    End Sub

    Private Sub btnConsultaElemento_Click(sender As Object, e As EventArgs) Handles btnConsultaElemento.Click
        Try
            Dim frmConsultaElemento As New frmConsultaElementos
            frmConsultaElemento.isPreseleccionElemento = True
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

    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            Dim frmConsultaVuelos As New frmConsultaVuelosBriefing
            Limpiar()
            frmConsultaVuelos.ShowDialog()
            If frmConsultaVuelos.Aerolinea <> "" Then
                myDetalleVuelo = frmConsultaVuelos.resDetVuelo
                txtVuelo.Text = myDetalleVuelo.codigoVuelo
                txtAvion.Text = myDetalleVuelo.descripcionAvion
                txtMatricula.Text = myDetalleVuelo.matriculaAvion
                udtFecha.Value = myDetalleVuelo.fechaVuelo
                udtEta.Value = myDetalleVuelo.llegadaVuelo
                udtEtd.Value = myDetalleVuelo.salidaVuelo
                btnConsultaElemento.Enabled = True
                ConsultaElementos()
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
        btnConsultaElemento.Enabled = False

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
        Dim myElementoBriefing As New ElementoBriefingItem
        Dim resultR As Boolean = False
        For Each r As DataRow In dtElemento.Rows
            resultR = False
            Dim result As Boolean = False
            Dim req As New VueloRequest
            Dim res As New VueloResponse
            Dim WsClnt As New VuelosServiceSoapClient
            Try
                If r.Item("estado").ToString <> "S" And r.Item("estado").ToString <> "" Then
                    myElementoBriefing.indice = r.Item("indice")
                    myElementoBriefing.idElemento = r.Item("idElemento")
                    myElementoBriefing.fecha = DateTime.Now
                    myElementoBriefing.idBriefing = myDetalleVuelo.idBriefing
                    myElementoBriefing.usuario = MyCurrentUser.userName
                    myElementoBriefing.estado = "A"
                    General.SetBARequest(req)
                    req.myElementoBriefingItem = myElementoBriefing
                    res = WsClnt.SaveElementoBriefingItem(req)
                    If res.ActionResult Then
                        SaveEstadoElemento(myElementoBriefing)
                        resultR = True
                        Try
                            Dim resul As Boolean
                            Dim elementoHistorico As New ElementoHistoricoItem
                            elementoHistorico.Id = Guid.NewGuid
                            elementoHistorico.idElemento = myElementoBriefing.idElemento
                            elementoHistorico.pesoElemento = CommonData.GetElementoItem(myElementoBriefing.idElemento).pesoActual
                            elementoHistorico.estadoElemento = r.Item("estado").ToString
                            elementoHistorico.tipoRegistro = "PRE"
                            elementoHistorico.fecha = DateTime.Now
                            elementoHistorico.usuario = MyCurrentUser.userName
                            elementoHistorico.idProceso = CommonProcess.GetProcesoPoridBriefing(myDetalleVuelo.idBriefing).IdProceso
                            elementoHistorico.idVuelo = myDetalleVuelo.idBriefing
                            resul = CommonData.SaveElementoHistorico(elementoHistorico)
                        Catch ex As Exception
                            ErrorManager.SetLogEvent(ex)
                        End Try
                    Else
                        Throw New Exception(res.ErrorMessage)
                    End If
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

    Private Sub SaveEstadoElemento(elemento As ElementoBriefingItem)
        Dim myElemento As New Server.ReportService.ElementoCatalogItem
        Dim result As Boolean = False
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            myElemento.Id = elemento.idElemento
            myElemento.estado = "P"
            myElemento.fechaUltimaAct = Date.Now
            General.SetBARequest(req)
            req.myElementoItem = myElemento
            res = WsClnt.SaveEstadoElemento(req)
            If Not res.ActionResult Then
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SaveEstadoElemento(idElemento As String) As Boolean
        Dim result As Boolean = False
        Dim req As New Server.ReportService.ElementoRequest
        Dim res As New Server.ReportService.ElementoResponse
        Dim WsClnt As New Server.ReportService.ReportServiceSoapClient
        Try
            myElemento.Id = idElemento
            myElemento.estado = "D"
            General.SetBARequest(req)
            req.myElementoItem = myElemento
            res = WsClnt.SaveEstadoElemento(req)
            If res.ActionResult Then
                result = True
            Else
                Throw New Exception(res.ErrorMessage)
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex, res, req)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
    End Function

    Private Sub ugvElementos_KeyDown(sender As Object, e As KeyEventArgs) Handles ugvElementos.KeyDown
        If e.KeyData = Keys.Delete Then
            Try
                For Each r As DataRow In dtElemento.Rows
                    If ugvElementos.ActiveRow.Cells("idElemento").Value = r.Item("idElemento") Then
                        Dim idElemento As String = ugvElementos.ActiveRow.Cells("idElemento").Value
                        Dim result As Boolean = False
                        If SaveEstadoElemento(idElemento) Then
                            Dim elementoBriefing As New ElementoBriefingItem
                            elementoBriefing.indice = r.Item("indice")
                            elementoBriefing.estado = "E"
                            If CommonProcess.ModificarEstadoElementoBriefingPorIndice(elementoBriefing) Then
                                result = True
                            End If
                        End If
                        If result Then
                            r.Delete()
                        Else
                            MessageBox.Show("Error al actualizar, comunicarse con Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class