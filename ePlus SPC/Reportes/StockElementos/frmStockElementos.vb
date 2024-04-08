Imports SPC.Server.ReportService
Imports System.IO
Imports System.Text
Public Class frmStockElementos
    Dim idAgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim encabezadoElemento As encabezadoElemento
    Dim isReportTxt As Boolean = False
    Dim path As String = String.Empty
    Dim textStr As String = String.Empty
    Dim dtStockElementos As DataTable

    Public Sub New(ByVal value As Boolean)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        isReportTxt = value
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Property detalleElemento As detalleElemento

    Private Sub frmStockElementos_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        cargarCombo()
        UltraButton1.Visible = False
        If Not isReportTxt Then
            UltraButton1.Visible = True
        End If
    End Sub

    Private Sub cargarCombo()
        Try
            uceAerolinea.Items.Clear()
            uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")
            For Each r As DataRow In CommonData.GetAgenciaPorTipo(idAgenciaAerolinea).Rows
                uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia")).Tag = r.Item("abreviatura")
            Next
            uceAerolinea.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultaElemento_Click(sender As Object, e As EventArgs) Handles btnConsultaElemento.Click
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\ReportsElementos") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\ReportsElementos")
        End If
        If uceAerolinea.Text = "Escoja una Opción" Then
            Exit Sub
        End If
        cargarRptStockElementos()
        If Not isReportTxt Then
            Dim frm As New RptElementoStock()
            frm.encabezadoElemento.Add(encabezadoElemento)
            frm.detalleElemento = encabezadoElemento.detalleElemento
            frm.aerolinea = uceAerolinea.Text
            frm.Show()
        Else
            Try
                'If Not FileIO.FileSystem.DirectoryExists("C:\ReportsElementos\") Then
                '    FileIO.FileSystem.CreateDirectory("C:\ReportsElementos\")
                'End If
                'path = "C:\ReportsElementos\" & uceAerolinea.Text & "-" & DateTime.Now.ToString("dd-MM-yyyy") & ".txt"
                path = rutaejecutable & "\ReportsElementos\" & uceAerolinea.Text & "-" & DateTime.Now.ToString("dd-MM-yyyy") & ".txt"
                'path = "C:\REPORTE ELEMENTOS-" & uceAerolinea.Text & "-" & Now.Date.ToString & ".txt"
                'Dim fs As FileStream = File.Create(path)
                textStr = String.Empty
                textStr += vbCrLf & "QLMFMIB  " & "GYEFFIB  " & "MADFNIB"
                textStr += vbCrLf & "MADFNIB"
                textStr += vbCrLf & "SCM"
                textStr += vbCrLf & "GYE." & DateTime.Now.ToString("ddMMM/hhmm").ToUpper & vbCrLf
                Dim antStr As String = String.Empty
                Dim cont As Integer = 0
                Dim cont2 As Integer = 0
                For Each r As DataRow In dtStockElementos.Rows
                    Dim tempStr As String = String.Empty
                    Dim elem As String = String.Empty
                    tempStr = r.Item("idElemento").ToString.Substring(0, 3)
                    elem = r.Item("idElemento").ToString.Substring(3, r.Item("idElemento").ToString.Length - 3)
                    If (antStr = "" Or cont = 1) And cont2 < 1 Then
                        antStr = tempStr
                        textStr += "." & tempStr & "."
                    ElseIf antStr = "" Or cont = 0 Then
                        antStr = tempStr
                        textStr += "." & tempStr & "."
                    End If
                    If antStr = tempStr Then
                        textStr += elem & "/"
                        cont += 1
                    Else
                        textStr += ".T" & cont.ToString
                        cont = 0
                        textStr += vbCrLf
                        textStr += "." & tempStr & "."
                        textStr += elem & "/"
                        antStr = tempStr
                    End If
                    If dtStockElementos.Rows.Count = cont2 + 1 Then
                        'cont += 1
                        textStr += ".T" & cont.ToString
                        'cont = 0
                        textStr += vbCrLf
                        'textStr += "." & tempStr & "."
                        'textStr += elem & vbCrLf
                    End If
                    If cont < 6 And cont = 0 Then
                        cont += 1
                    ElseIf cont > 5 Then
                        textStr += ".T" & cont.ToString
                        cont = 0
                        textStr += vbCrLf
                    End If
                    cont2 += 1
                Next
                IO.File.WriteAllText(path, textStr)
                System.Diagnostics.Process.Start(path)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub cargarRptStockElementos()
        Try
            encabezadoElemento = New encabezadoElemento
            dtStockElementos = CommonData.GetElementoPorAgenciaStock(uceAerolinea.Value)
            For Each r As DataRow In CommonData.GetElementoPorAgenciaStock(uceAerolinea.Value).Rows
                detalleElemento = New detalleElemento
                detalleElemento.inicialElemento = r.Item("idElemento").ToString.Substring(0, 3)
                detalleElemento.idElemento = r.Item("idElemento")
                detalleElemento.descripcionAgencia = r.Item("descripcionAgencia")
                detalleElemento.tipoElemento = r.Item("descripcionTipo")
                detalleElemento.pesoRef = r.Item("pesoReferencial")
                detalleElemento.pesoReal = r.Item("pesoReal")
                detalleElemento.pesoActual = r.Item("pesoActual")
                detalleElemento.fechaUltAct = r.Item("fechaUltimaAct")
                detalleElemento.fileImgCondicion = r.Item("fileImgCondicion")
                Dim tempUsuarioIngreso As New ContactoCatalogItem
                Dim LongitudCadena = 20
                Try
                    tempUsuarioIngreso = CommonData.GetContactoItem(r.Item("usuarioIngreso"))
                    detalleElemento.usuarioIngreso = tempUsuarioIngreso.tagsa + " - " + tempUsuarioIngreso.primerApellido + " " + tempUsuarioIngreso.segundoApellido + " " + tempUsuarioIngreso.primerNombre
                    LongitudCadena = IIf(Len(detalleElemento.usuarioIngreso) > 20, LongitudCadena, Len(detalleElemento.usuarioIngreso))
                    detalleElemento.usuarioIngreso = detalleElemento.usuarioIngreso.Substring(0, LongitudCadena)
                Catch ex As Exception
                End Try
                detalleElemento.materialPiso = r.Item("materialPiso")
                detalleElemento.materialPared = r.Item("materialPared")
                detalleElemento.materialtecho = r.Item("materialTecho")
                detalleElemento.materialRed = r.Item("materialRed")
                detalleElemento.materialPuerta = r.Item("materialPuerta")
                detalleElemento.materialSeguros = r.Item("materialSeguros")
                Dim tempchofer As New ContactoCatalogItem
                Dim tempCustodio As New ContactoCatalogItem
                Try
                    LongitudCadena = 20
                    tempchofer = CommonData.GetContactoItem(r.Item("chofer"))
                    detalleElemento.chofer = tempchofer.tagsa + " - " + tempchofer.primerApellido + " " + tempchofer.segundoApellido + " " + tempchofer.primerNombre
                    LongitudCadena = IIf(Len(detalleElemento.chofer) > 20, LongitudCadena, Len(detalleElemento.chofer))
                    detalleElemento.chofer = detalleElemento.chofer.Substring(0, LongitudCadena)
                Catch ex As Exception
                End Try
                Dim tempMula As New DollyCatalogItem
                Try
                    LongitudCadena = 20
                    tempMula = CommonData.GetDollyItem(r.Item("mula"))
                    detalleElemento.mula = tempMula.codigo
                    LongitudCadena = IIf(Len(tempMula.nombreAgencia) > 20, LongitudCadena, Len(tempMula.nombreAgencia))
                    detalleElemento.compañia = tempMula.nombreAgencia.Substring(0, LongitudCadena)
                Catch ex As Exception
                End Try
                'Try
                '    detalleElemento.compañia = CommonData.GetAgenciaItem(tempMula.IdAgencia).Descripcion.Substring(0, 20)
                'Catch ex As Exception
                'End Try
                Try
                    LongitudCadena = 20
                    If r.Item("custodio") <> "Sin Custodio" Then
                        tempCustodio = CommonData.GetContactoItem(r.Item("custodio"))
                        detalleElemento.custodio = tempCustodio.tagsa + " - " + tempCustodio.primerApellido + " " + tempCustodio.segundoApellido + " " + tempCustodio.primerNombre
                    Else
                        detalleElemento.custodio = r.Item("custodio")
                    End If
                    LongitudCadena = IIf(Len(detalleElemento.custodio) > 20, LongitudCadena, Len(detalleElemento.custodio))
                    detalleElemento.custodio = detalleElemento.custodio.Substring(0, LongitudCadena)
                Catch ex As Exception
                End Try
                detalleElemento.fechaIngresoPlataforma = r.Item("fechaIngresoPlataforma")
                detalleElemento.obs = txtObs.Text
                If r.Item("estado") = "D" Then
                    detalleElemento.estado = "Disponible"
                ElseIf r.Item("estado") = "P" Then
                    detalleElemento.estado = "Ocupado"
                    Dim dtElementoBriefing As DataTable
                    Dim tempElementoBriefing As New Server.VuelosService.ElementoBriefingItem
                    tempElementoBriefing.idElemento = r.Item("idElemento")
                    dtElementoBriefing = CommonProcess.GetElementoBriefingPorIdElemento(tempElementoBriefing)
                    For Each r2 As DataRow In dtElementoBriefing.Rows
                        detalleElemento.estado += " / " + r2.Item("codigoVuelo")
                    Next
                ElseIf r.Item("estado") = "C" Then
                    detalleElemento.estado = "Con Carga"
                    Dim dtElementoBriefing As DataTable
                    Dim tempElementoBriefing As New Server.VuelosService.ElementoBriefingItem
                    tempElementoBriefing.idElemento = r.Item("idElemento")
                    dtElementoBriefing = CommonProcess.GetElementoBriefingPorIdElemento(tempElementoBriefing)
                    For Each r2 As DataRow In dtElementoBriefing.Rows
                        detalleElemento.estado += " / " + r2.Item("codigoVuelo")
                    Next
                End If
                encabezadoElemento.detalleElemento.Add(detalleElemento)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        If uceAerolinea.Text = "Escoja una Opción" Then
            Exit Sub
        End If
        cargarRptStockElementos()
        If Not isReportTxt Then
            Dim frm As New RptElementoStock()
            frm.encabezadoElemento.Add(encabezadoElemento)
            frm.detalleElemento = encabezadoElemento.detalleElemento
            frm.aerolinea = uceAerolinea.SelectedItem.Tag.ToString.Trim
            frm.idAgenciaReporte = uceAerolinea.Value

            frm.guardarReporte()
            If frm.result Then
                MessageBox.Show("Correo eviado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al enviar correo. Por favor reintentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class