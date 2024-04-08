Public Class frmTemperatura
    Private dtTemperatura As New DataTable("Temperatura")
    Private dtCuartos As New DataTable("Cuartos")
    Dim lv_cuarto As String = ""
    Dim ln_CountCuarto As Integer = 0
    Private Sub frmTemperatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCuartos.Clear()
        cmbCuartos.Items.Add(0, "Todos los Cuartos")
        dtTemperatura.Clear()
        For Each r As DataRow In CommonData.ObtenerCuartosFrios.Rows
            cmbCuartos.Items.Add(r.Item("idCuarto"), r.Item("NombreCuarto"))
        Next
        cmbCuartos.SelectedIndex = 0
        With dtTemperatura.Columns
            .Add("NombreCuarto", GetType(String))
            .Add("Humedad", GetType(Double))
            .Add("Centigrado", GetType(Double))
            .Add("fahrenheit", GetType(Double))
            .Add("FechaIngreso", GetType(DateTime))
            .Add("tiempo", GetType(String))
        End With
        With dtCuartos.Columns
            .Add("NombreCuarto", GetType(String))
            .Add("CantRegistros", GetType(Double))
        End With
        ugdTemperatura.DataSource = dtTemperatura
        CargaReporte(Now.AddDays(-2), Now)
        SetDisplayedColumns()
    End Sub
    Private Sub CargaReporte(ByVal fechaInicio, ByVal fechaFinal)
        Dim row As DataRow
        Dim countRow As Integer = 0
        Dim rowCuartos As DataRow
        dtTemperatura.Clear()
        dtCuartos.Clear()
        If cmbCuartos.SelectedIndex = 0 Then
            For r = 0 To cmbCuartos.Items.Count - 1
                countRow = 0
                If r > 0 Then
                    For Each i As DataRow In CommonData.ObtenerReportTemp(cmbCuartos.Items.Item(r).ToString, fechaInicio, fechaFinal).Rows
                        row = dtTemperatura.NewRow
                        row.Item("NombreCuarto") = i.Item("NombreCuartoFrio")
                        row.Item("Humedad") = Double.Parse(i.Item("Humedad"))
                        row.Item("Centigrado") = Double.Parse(i.Item("Centigrado"))
                        row.Item("fahrenheit") = Double.Parse(i.Item("fahrenheit"))
                        row.Item("FechaIngreso") = Date.Parse(i.Item("FechaIngreso").ToString).ToString("MM/dd/yyyy")
                        row.Item("tiempo") = i.Item("tiempo")
                        dtTemperatura.Rows.Add(row)
                        countRow += 1
                    Next
                    rowCuartos = dtCuartos.NewRow
                    rowCuartos.Item("NombreCuarto") = cmbCuartos.Items.Item(r).ToString
                    rowCuartos.Item("CantRegistros") = countRow
                    dtCuartos.Rows.Add(rowCuartos)
                End If
            Next
        Else
            countRow = 0
                For Each i As DataRow In CommonData.ObtenerReportTemp(cmbCuartos.SelectedItem.ToString, fechaInicio, fechaFinal).Rows
                    row = dtTemperatura.NewRow
                    row.Item("NombreCuarto") = i.Item("NombreCuartoFrio")
                    row.Item("Humedad") = Double.Parse(i.Item("Humedad"))
                    row.Item("Centigrado") = Double.Parse(i.Item("Centigrado"))
                    row.Item("fahrenheit") = Double.Parse(i.Item("fahrenheit"))
                    row.Item("FechaIngreso") = Date.Parse(i.Item("FechaIngreso").ToString).ToString("MM/dd/yyyy")
                    row.Item("tiempo") = i.Item("tiempo")
                    dtTemperatura.Rows.Add(row)
                    countRow += 1
                Next
                rowCuartos = dtCuartos.NewRow
                rowCuartos.Item("NombreCuarto") = cmbCuartos.SelectedItem.ToString
                rowCuartos.Item("CantRegistros") = countRow
                dtCuartos.Rows.Add(rowCuartos)
        End If
    End Sub
    Private Sub UltraBtnExportExcel_Click(sender As Object, e As EventArgs) Handles UltraBtnExportExcel.Click
        Dim fechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim fechaFinal As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim CompracionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFinal.Value)
        Dim CompracionHora As Integer = DateTime.Compare(DateTimeHoraInicio.Text, DateTimeHoraFin.Text)
        If CompracionFecha <= 0 Then
            If CompracionHora > 0 And CompracionFecha = 0 Then
                MessageBox.Show("La hora fin no puede ser menor a la hora inicio")
            Else
                If DateTimeHoraInicio.Text = DateTimeHoraFin.Text And CompracionFecha = 0 Then
                    fechaFinal = Date.Now()
                End If
                CargaReporte(fechaInicio, fechaFinal)
                Using frm As New RptTemperatura
                    Dim ListRegtemp As New ClassTemp
                    Dim DetalleRegTemp As ClassDetalleTemp
                    Dim dataviw As New DataView
                    Dim CargarLista As Boolean = True
                    dataviw = dtCuartos.AsDataView
                    dataviw.Sort = "CantRegistros DESC"
                    dtCuartos = dataviw.ToTable
                    For Each r As DataRow In dtCuartos.Rows
                        Dim foundRows() As DataRow
                        foundRows = dtTemperatura.Select("NombreCuarto = '" & r.Item("NombreCuarto") & "'")
                        Dim items As Integer = 0
                        For Each i As DataRow In foundRows
                            If CargarLista Then
                                DetalleRegTemp = New ClassDetalleTemp
                                If r.Item("NombreCuarto") = "CUARTO-FRIO-A-2" Then
                                    With DetalleRegTemp
                                        .Humedad_A = i.Item(1)
                                        .Centigrado_A = i.Item(2)
                                        .fahrenheit_A = i.Item(3)
                                    End With
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-A-3-4" Then
                                    With DetalleRegTemp
                                        .Humedad_A3_4 = i.Item(1)
                                        .Centigrado_A3_4 = i.Item(2)
                                        .fahrenheit_A3_4 = i.Item(3)
                                    End With
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-A-5" Then
                                    With DetalleRegTemp
                                        .Humedad_A5 = i.Item(1)
                                        .Centigrado_A5 = i.Item(2)
                                        .fahrenheit_A5 = i.Item(3)
                                    End With
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-B-1" Then
                                    With DetalleRegTemp
                                        .Humedad_B = i.Item(1)
                                        .Centigrado_B = i.Item(2)
                                        .fahrenheit_B = i.Item(3)
                                    End With
                                End If
                                DetalleRegTemp.FechaInicio = Date.Parse(i.Item(4).ToString).ToString("MM/dd/yyyy")
                                DetalleRegTemp.Descripcion = i.Item(5)
                                ListRegtemp.RegTempratura.Add(DetalleRegTemp)
                            Else
                                If r.Item("NombreCuarto") = "CUARTO-FRIO-A-2" Then
                                    ListRegtemp.RegTempratura.Item(items).Humedad_A = i.Item(1)
                                    ListRegtemp.RegTempratura.Item(items).Centigrado_A = i.Item(2)
                                    ListRegtemp.RegTempratura.Item(items).fahrenheit_A = i.Item(3)
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-A-3-4" Then
                                    ListRegtemp.RegTempratura.Item(items).Humedad_A3_4 = i.Item(1)
                                    ListRegtemp.RegTempratura.Item(items).Centigrado_A3_4 = i.Item(2)
                                    ListRegtemp.RegTempratura.Item(items).fahrenheit_A3_4 = i.Item(3)
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-A-5" Then
                                    ListRegtemp.RegTempratura.Item(items).Humedad_A5 = i.Item(1)
                                    ListRegtemp.RegTempratura.Item(items).Centigrado_A5 = i.Item(2)
                                    ListRegtemp.RegTempratura.Item(items).fahrenheit_A5 = i.Item(3)
                                ElseIf r.Item("NombreCuarto") = "CUARTO-FRIO-B-1" Then
                                    ListRegtemp.RegTempratura.Item(items).Humedad_B = i.Item(1)
                                    ListRegtemp.RegTempratura.Item(items).Centigrado_B = i.Item(2)
                                    ListRegtemp.RegTempratura.Item(items).fahrenheit_B = i.Item(3)
                                End If
                            End If
                            items += 1
                        Next
                        CargarLista = False
                    Next
                    frm.RegTemp = ListRegtemp
                    frm._FechaInicio = fechaInicio
                    frm._FechaFin = fechaFinal
                    If cmbCuartos.SelectedIndex = 0 Then
                        frm._TipoDeInforme = "T"
                    ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-2" Then
                        frm._TipoDeInforme = "Cuarto Frio A2"
                    ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-3-4" Then
                        frm._TipoDeInforme = "Cuarto Frio A3_4"
                    ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-5" Then
                        frm._TipoDeInforme = "Cuarto Frio A5"
                    ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-B-1" Then
                        frm._TipoDeInforme = "Cuarto Frio B"
                    End If
                    frm.ShowDialog()
                End Using
                SetDisplayedColumns()
            End If
        ElseIf CompracionFecha > 0 Then
            MessageBox.Show("La Fecha fin no puede ser menor a la Fecha inicio")
        End If
    End Sub

    Private Sub btnConsultarCZ_Click(sender As Object, e As EventArgs) Handles btnConsultarCZ.Click
        Dim fechaInicio As Date = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        Dim fechaFinal As Date = Convert.ToDateTime(udtFinal.Value & " " & DateTimeHoraFin.Text)
        Dim CompracionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFinal.Value)
        Dim CompracionHora As Integer = DateTime.Compare(DateTimeHoraInicio.Text, DateTimeHoraFin.Text)
        If CompracionFecha <= 0 Then
            If CompracionHora > 0 And CompracionFecha = 0 Then
                MessageBox.Show("La hora fin no puede ser menor a la hora inicio")
            Else
                If DateTimeHoraInicio.Text = DateTimeHoraFin.Text And CompracionFecha = 0 Then
                    fechaFinal = Date.Now()
                End If
                CargaReporte(fechaInicio, fechaFinal)
            End If
        ElseIf CompracionFecha > 0 Then
            MessageBox.Show("La Fecha fin no puede ser menor a la Fecha inicio")
        End If
    End Sub
    Private Sub SetDisplayedColumns()
        Dim lb_visible As Boolean
        Try
            ugdTemperatura.DisplayLayout.Bands(0).Columns("FechaIngreso").Header.Caption = "Fecha"
            ugdTemperatura.DisplayLayout.Bands(0).Columns("FechaIngreso").Format = "dd/MM/yyyy"
            ugdTemperatura.DisplayLayout.Bands(0).Columns("FechaIngreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Catch ex As Exception
        End Try
    End Sub
End Class
