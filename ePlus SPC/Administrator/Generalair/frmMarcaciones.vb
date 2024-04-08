Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmMarcaciones
    Public CabeceraMarcaciones As CabeceraMarcaciones
    Dim workTable As DataTable = New DataTable("Marcaciones")
    Dim ExisteReport As Integer = 0
    Private _Usuario As String
    Dim FechaInicio As Date
    Dim FechaFin As Date
    'Dim tableFinal As DataTable = New DataTable("MarcacionesFinal")

    Private Sub frmMarcacionesEmpleados_Load(sender As Object, e As EventArgs) Handles Me.Load
    

        uceEmpleados.Items.Clear()
        uceEmpleados.Items.Add("Todos", "Todas los empleados")
        For Each r As DataRow In CommonData.GetEmpleadosGeneral().Rows
            uceEmpleados.Items.Add(r.Item("idContacto"), r.Item("empleado"))
        Next
        uceEmpleados.SelectedIndex = 0
        'Cargos
        uceCargos.Items.Clear()
        For Each r As DataRow In CommonData.GetCargoCatalog().Rows
            uceCargos.Items.Add(r.Item("idCargo"), r.Item("descripcionCargo"))
        Next
        uceEmpleados.SelectedIndex = 0

        'todos los contactos

        uceContactos.Clear()
        For Each r As DataRow In CommonData.GetEntireContactoCatalog().Rows
            uceContactos.Items.Add(r.Item("idContacto"), r.Item("primerApellidoContacto") & " " & r.Item("segundoApellidoContacto") & " " & r.Item("primerNombreContacto") & " " & r.Item("segundoNombreContacto"))
        Next
        uceContactos.SelectedIndex = 0

        'ugdContacto.DataSource = CommonData.GetEntireContactoCatalog()



    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        FechaInicio = Convert.ToDateTime(udtInicio.Value & " " & DateTimeHoraInicio.Text)
        FechaFin = Convert.ToDateTime(udtFin.Value & " " & DateTimeHoraFin.Text)
        Dim CompracionFecha As Integer = DateTime.Compare(udtInicio.Value, udtFin.Value)
        Dim CompracionHora As Integer = DateTime.Compare(DateTimeHoraInicio.Text, DateTimeHoraFin.Text)
        CabeceraMarcaciones = New CabeceraMarcaciones
        If CompracionFecha <= 0 Then
            If CompracionHora > 0 And CompracionFecha = 0 Then
                MessageBox.Show("La hora fin no puede ser menor a la hora inicio")
            Else
                If uceTipoConsulta.Text = String.Empty Then
                    MessageBox.Show("Debe seleccionar tipo de consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If udtInicio.Value = Nothing Then
                    MessageBox.Show("Debe indicar fecha de inicio mínimo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf udtFin.Value < udtInicio.Value Then
                    MessageBox.Show("Fecha de final menor a la de inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    SearchData()
                    If ExisteReport > 0 Then
                        If (uceEmpleados.SelectedIndex > 0 And uceEmpleados.Enabled = True) Or (uceContactos.SelectedIndex > 0 And uceContactos.Enabled = True) Then
                            Dim frmficha As New rptReporteFichaEmpleado

                            If (uceEmpleados.SelectedIndex > 0 And uceEmpleados.Enabled = True) Then
                                ConsultarData(uceEmpleados.Value)
                            Else
                                ConsultarData(uceContactos.Value)
                            End If


                            frmficha.FechaFin = FechaFin
                            frmficha.FechaInicio = FechaInicio
                            frmficha.Usuario = _Usuario
                            frmficha.DsFicha = CabeceraMarcaciones.datosDatosFichapersonallst
                            frmficha.DsFichaCarga = CabeceraMarcaciones.datosFichaProcesoCargalst
                            frmficha.DsFichaMarcaciones = CabeceraMarcaciones.datosFichaMarcacioneslst
                            frmficha.DsAtrasos = CabeceraMarcaciones.datosFichaMarcacionesAtarasoslst

                            frmficha.Show()
                        Else
                            Dim frm As New rptMarcacionesEmpleados()
                            frm.FechaFin = FechaFin
                            frm.FechaInicio = FechaInicio
                            frm.Usuario = _Usuario
                            frm.Segmento = uceTipoConsulta.Text & "-" & uceEmpleados.Text
                            frm.DetalleMarcacionEmpleados = CabeceraMarcaciones.detalle
                            frm.Show()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SearchData()
 
        Select Case uceTipoConsulta.SelectedIndex
            Case 0
                workTable = CommonData.GetMarkingsGeneralair(uceCargos.Text, FechaInicio, FechaFin, "2")
            Case 1
                If uceEmpleados.SelectedIndex = 0 Then 'todos  los  empleados
                    workTable = CommonData.GetMarkingsGeneralair(uceEmpleados.Value, FechaInicio, FechaFin, "0")
                Else 'Buscar por un empleado especifico
                    workTable = CommonData.GetMarkingsGeneralair(uceEmpleados.Value, FechaInicio, FechaFin, "1")
                End If
            Case 2
                'buscar por un contacto especifico
                workTable = CommonData.GetMarkingsGeneralair(uceContactos.Value, FechaInicio, FechaFin, "1")
        End Select



        If workTable.Rows.Count > 0 And UltraCheckReporte.Checked = True Then
            ExisteReport = ExisteReport + 1
            For Each r As DataRow In workTable.Rows
                Dim DetalleMarcaciones = New DetalleMarcaciones
                With DetalleMarcaciones
                    .cargo = r.Item("cargo")
                    .NombresApellidos = r.Item("empleado")
                    .Cedula = r.Item("idContacto")
                    .Direccion = r.Item("direccion")
                    .Telefono = r.Item("telefono")
                    .FechaNacimiento = r.Item("fechaNacimientoContacto").ToString
                    .NoTagsa = r.Item("tagsaContacto")
                    .ingreso = r.Item("ingreso").ToString
                    .salida = r.Item("salida").ToString
                    .diferencia = r.Item("diferencia").ToString
                    .diferenciaMinutos = IIf(IsDBNull(r.Item("diferenciaMinutos")), 0, r.Item("diferenciaMinutos"))
                    .diferenciaatrasos = r.Item("diferenciaatraso")
                    .atraso = r.Item("tiempoatraso")
                    .imagen = r.Item("imagenPerfil")
                    .fechacaducidadtagsa = r.Item("fechacaducaTagsa")

                    If uceTipoConsulta.SelectedIndex = 1 Or uceTipoConsulta.SelectedIndex = 2 Then
                        If uceEmpleados.SelectedIndex <> 0 Or uceContactos.SelectedIndex > 0 Then
                            .fechaInicioJornada = IIf(IsDBNull(r.Item("fechaInicioJornada")), "", r.Item("fechaInicioJornada"))
                            .fechaFinalJornada = IIf(IsDBNull(r.Item("fechaFinJornada")), "", r.Item("fechaFinJornada"))
                            .ciudad = r.Item("nombreCiudad")
                        End If
                    End If

                End With
                CabeceraMarcaciones.detalle.Add(DetalleMarcaciones)
            Next
        End If
        'Eliminar columnas vacías
        If chbCompletas.Checked Then
            If UltraCheckReporte.Checked = False Then
                ExisteReport = 0
            End If
            Dim foundRow As DataRow() = workTable.Select("salida is null")
            If foundRow.Length > 0 Then
                For Each row In foundRow
                    row.Delete()
                Next
                workTable.AcceptChanges()
            End If
        End If

        ugdMarcaciones.DataSource = workTable
        If ugdMarcaciones.DataSource.rows.count < 1 Then
            SetDisplayedColumnsByEmpleado()
            MessageBox.Show("No se encontró ninguna información para consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else 'Mostrar datos
            workTable.DefaultView.Sort = "empleado ASC"
            workTable = workTable.DefaultView.ToTable
            btnExcelExport.Enabled = True
            btnPDF.Enabled = True
            ugdMarcaciones.Text = "MARCACIONES DEL " & CDate(udtInicio.Value).ToString("dd/MM/yyyy") & " AL " & CDate(udtFin.Value).ToString("dd/MM/yyyy")
            'SumatoriasHoras(workTable)
            SetDisplayedColumnsByEmpleado()
        End If
    End Sub

  

    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        General.ExportToExcel(ugdMarcaciones)
    End Sub

    Private Sub SetDisplayedColumnsByEmpleado()
        Dim band As UltraGridBand = ugdMarcaciones.DisplayLayout.Bands(0)
        ugdMarcaciones.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.Brown
        ugdMarcaciones.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        band.Columns("empleado").AllowGroupBy = DefaultableBoolean.True
        band.SortedColumns.Add("empleado", False, True)
        band.Columns("id").Hidden = True
        band.Columns("cargo").Header.Caption = "Cargo"
        band.Columns("empleado").Header.Caption = "Empleado"
        band.Columns("Empleado").GroupByRowAppearance.ForeColor = Color.Black
        band.Columns("ingreso").Header.Caption = "Ingreso"
        band.Columns("ingreso").Format = "dd/MM/yyyy HH:mm:ss"
        band.Columns("ingreso").CellActivation = Activation.NoEdit
        band.Columns("salida").Header.Caption = "Salida"
        band.Columns("salida").Format = "dd/MM/yyyy HH:mm:ss"
        band.Columns("salida").CellActivation = Activation.NoEdit
        band.Columns("diferencia").Header.Caption = "Duración"
        band.Columns("diferencia").Format = "HH:mm:ss"
        band.Columns("mensaje").Header.Caption = "Mensaje"
        band.Columns("observation").Header.Caption = "Observación"
        band.Summaries.Clear()
        Dim summary As SummarySettings = band.Summaries.Add("TimeTotal", SummaryType.Custom,
        New TimeTotalSummary(), band.Columns("diferencia"), SummaryPosition.UseSummaryPositionColumn, Nothing)
        summary.Appearance.BackColor = Color.Yellow
        summary.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        band.SummaryFooterCaption = "Tiempo total trabajado"
    End Sub

    Private Sub ugdMarcaciones_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs)
        Dim id As String = ugdMarcaciones.ActiveRow.Cells("id").Value.ToString
        Dim empleado As String = ugdMarcaciones.ActiveRow.Cells("empleado").Value.ToString
        Dim tiempoInicial As String = ugdMarcaciones.ActiveRow.Cells("ingreso").Value.ToString
        Dim tiempoFinal As String = ugdMarcaciones.ActiveRow.Cells("salida").Value.ToString
        Dim observation As String = ugdMarcaciones.ActiveRow.Cells("observation").Value.ToString
        Using frmDetalle As New frmMarcacionesDetalle(id, empleado, tiempoInicial, tiempoFinal, observation)
            frmDetalle.ShowDialog()
        End Using
    End Sub

    Private Sub uceTipoConsulta_ValueChanged(sender As Object, e As EventArgs) Handles uceTipoConsulta.ValueChanged

        Select Case uceTipoConsulta.SelectedIndex
            Case 0
                uceCargos.Enabled = True
                uceEmpleados.Enabled = False
                uceContactos.Enabled = False
                uceEmpleados.Visible = True
                uceContactos.Visible = False

            Case 1
                uceEmpleados.Enabled = True
                uceCargos.Enabled = False
                uceEmpleados.Visible = True
                uceContactos.Visible = False
                uceContactos.Enabled = False
            Case 2
                uceEmpleados.Enabled = False
                uceCargos.Enabled = False
                uceEmpleados.Visible = False
                uceContactos.Visible = True
                uceContactos.Enabled = True
        End Select
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        Dim cabecera As New CabeceraMarcaciones
        Dim detalle As New DetalleMarcaciones
        cabecera.rangoFechas = ugdMarcaciones.Text
        For Each row As DataRow In workTable.Rows
            detalle = New DetalleMarcaciones
            detalle.contacto = row.Item(2)
            detalle.cargo = row.Item(1)
            detalle.ingreso = String.Format("{0:dd/MM/yyyy HH:mm:ss}", row.Item(3))
            If IsDBNull(row.Item(4)) Then
                detalle.salida = ""
            Else
                detalle.salida = String.Format("{0:dd/MM/yyyy HH:mm:ss}", row.Item(4))
            End If
            If IsDBNull(row.Item(5)) Then
                detalle.diferencia = Nothing
            Else
                detalle.diferencia = row.Item(5)
            End If
            cabecera.detalle.Add(detalle)
        Next
        Dim reporte As New rptMarcaciones
        reporte.cabecera.Add(cabecera)
        reporte.detalle = cabecera.detalle
        reporte.Show()
    End Sub
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property


    Private Sub ConsultarData(idContacto As String)
        Dim resp As DataSet
        Dim dtDatos As DataTable
        Dim lwnuActividad As Integer
        Dim lwuHorasWork As Integer
        Dim lwnuAtrasos As Integer
        Dim lwtiempoatraso As Integer
        Dim lwnuActividad_proc As Integer
        Try
            'datos empleado
            Dim datosrptFicha As New DatosFichapersonal
            lwnuActividad = 0
            lwnuActividad_proc = 0
            For Each detamarcacion As DetalleMarcaciones In CabeceraMarcaciones.detalle
                datosrptFicha.cedula = detamarcacion.Cedula
                datosrptFicha.nombres = detamarcacion.NombresApellidos
                datosrptFicha.cargo = detamarcacion.cargo
                datosrptFicha.tagsa = detamarcacion.NoTagsa
                datosrptFicha.fechaexpiracion = detamarcacion.fechacaducidadtagsa
                datosrptFicha.direccion = detamarcacion.Direccion
                datosrptFicha.ciudad = detamarcacion.ciudad
                datosrptFicha.telefono = detamarcacion.Telefono
                datosrptFicha.foto = detamarcacion.imagen

                'detalle de  marcaciones
                If Not detamarcacion.ingreso.Equals("") Then
                    Dim datosrptMarcaciones As New FichaMarcaciones
                    datosrptMarcaciones.cedula = detamarcacion.Cedula
                    datosrptMarcaciones.fecha = detamarcacion.ingreso.ToString
                    datosrptMarcaciones.horaingreso = detamarcacion.ingreso
                    datosrptMarcaciones.horasalida = detamarcacion.salida
                    datosrptMarcaciones.totalhorastrab = detamarcacion.diferencia
                    datosrptMarcaciones.totalhorastrabmin = detamarcacion.diferenciaMinutos
                    datosrptMarcaciones.fechainicioJornada = detamarcacion.fechaInicioJornada
                    datosrptMarcaciones.fechafinalJornada = detamarcacion.fechaFinalJornada
                    lwuHorasWork += detamarcacion.diferenciaMinutos
                    If detamarcacion.atraso <= 0 Then
                        datosrptMarcaciones.indatrasos = "NO"
                    Else
                        datosrptMarcaciones.indatrasos = "SI"
                        Dim datosrptMarcacionesAt As New FichaMarcacionesAtarasos
                        datosrptMarcacionesAt.cedula = detamarcacion.Cedula
                        datosrptMarcacionesAt.fecha = detamarcacion.ingreso

                        datosrptMarcacionesAt.horaingreso = detamarcacion.ingreso
                        datosrptMarcacionesAt.horasalida = detamarcacion.salida

                        datosrptMarcacionesAt.totalatraso = detamarcacion.diferenciaatrasos
                        datosrptMarcacionesAt.totalatrasomin = detamarcacion.atraso

                        datosrptMarcacionesAt.fechainicioJornada = detamarcacion.fechaInicioJornada
                        datosrptMarcacionesAt.fechafinalJornada = detamarcacion.fechaFinalJornada
                        lwtiempoatraso += detamarcacion.atraso
                        CabeceraMarcaciones.datosFichaMarcacionesAtarasoslst.Add(datosrptMarcacionesAt)
                        lwnuAtrasos += 1
                    End If

                    CabeceraMarcaciones.datosFichaMarcacioneslst.Add(datosrptMarcaciones)
                End If



            Next
         
            'carga
            Dim datosrptCargalst As New List(Of FichaProcesoCarga)

            dtDatos = CommonData.GetDetalleProcesoporContacto(idContacto, FechaInicio, FechaFin)

            If Not dtDatos Is Nothing Then
                For Each dr As DataRow In dtDatos.Rows
                    Dim datosrptCarga As New FichaProcesoCarga
                    datosrptCarga.cedula = uceEmpleados.Value
                    datosrptCarga.aerolinea = dr.Item("agenciaElemento")
                    datosrptCarga.vuelo = dr.Item("codigoVuelo")
                    datosrptCarga.muelle = dr.Item("muelle")
                    datosrptCarga.desde = dr.Item("fechaInicioProceso")
                    datosrptCarga.hasta = dr.Item("fechaFinProceso")
                    datosrptCarga.totalactividad = dr.Item("diferencia")
                    datosrptCarga.totalactividadmin = dr.Item("diferenciaMinutos")
                    lwnuActividad += dr.Item("diferenciaMinutos")

                    datosrptCarga.procfecha = dr.Item("fechaInicioProceso") 'OK
                    datosrptCarga.procdesde = dr.Item("FechaInicio_proc")
                    datosrptCarga.prochasta = dr.Item("Fechafinal_proc")
                    datosrptCarga.proctotalactividad = dr.Item("diferencia_proc")
                    datosrptCarga.proctotalactividadmin = dr.Item("diferenciaMinutos_proc")

                    lwnuActividad_proc += dr.Item("diferenciaMinutos_proc")



                    datosrptCargalst.Add(datosrptCarga)
                    CabeceraMarcaciones.datosFichaProcesoCargalst.Add(datosrptCarga)
                Next

            End If

            'numero de  accesos 
            Dim ds = CommonData.GetLogsAccesosporContactoyFechas(idContacto, FechaInicio, FechaFin)
            datosrptFicha.accesos = ds.Tables(0).Rows.Count
            datosrptFicha.horasactividad = lwnuActividad
            datosrptFicha.horastrabajadas = lwuHorasWork
            datosrptFicha.cantidadatrsados = lwnuAtrasos
            datosrptFicha.tiempototalatrasos = lwtiempoatraso
            datosrptFicha.horasactividad_proc = lwnuActividad_proc
            CabeceraMarcaciones.datosDatosFichapersonallst.Add(datosrptFicha)


        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "MENSAJE DEL SISTEMA")
        End Try
    End Sub


  
End Class