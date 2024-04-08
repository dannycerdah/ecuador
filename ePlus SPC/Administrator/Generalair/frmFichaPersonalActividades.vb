Imports SPC.Server.ReportService

Public Class frmFichaPersonalActividades

    Private Sub frmFichaPersonalActividades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'limpiamos  la lista de empleados
        uceEmpleados.Items.Clear()
        uceEmpleados.Items.Add("Todos", "Todas los empleados")
        For Each r As DataRow In CommonData.GetEmpleadosGeneral().Rows
            uceEmpleados.Items.Add(r.Item("idContacto"), r.Item("empleado"))
        Next
        uceEmpleados.SelectedIndex = 0

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If udtInicio.Value = Nothing Then
            MessageBox.Show("Debe indicar fecha de inicio ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If udtFin.Value < udtInicio.Value Then
            MessageBox.Show("Fecha de final menor a la de inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ConsultarData(uceEmpleados.Value)


    End Sub

    Private Sub ConsultarData(idContacto As String)
        Dim serReport As New ReportServiceSoapClient
        Dim resp As DataSet
        Dim reqContacto As New ContactoRequest
        Dim dtDatos As DataTable
        Dim datosrptFichalst As New List(Of DatosFichapersonal)
        Dim lwnuActividad As Integer
        Dim lwuHorasWork As Integer
        Dim lwnuAtrasos As Integer
        Dim lwtiempoatraso As Integer
        Try
            'datos empleado
            reqContacto.myContactoItem.idContacto = idContacto
            resp = serReport.GetFichaPersonal(reqContacto).DsResult
            dtDatos = resp.Tables("contactos")
            For Each dr As DataRow In dtDatos.Rows
                Dim datosrptFicha As New DatosFichapersonal
                datosrptFicha.cedula = dr.Item("idContacto").ToString
                datosrptFicha.nombres = dr.Item("primerApellidoContacto").ToString & " " & dr.Item("segundoApellidoContacto").ToString & "" & dr.Item("primerNombreContacto").ToString & " " & dr.Item("segundoNombreContacto").ToString
                datosrptFicha.cargo = dr.Item("").ToString
                datosrptFicha.tagsa = dr.Item("tagsaContacto").ToString
                datosrptFicha.fechaexpiracion = dr.Item("fechaCaducaTagsa").ToString
                datosrptFicha.direccion = dr.Item("direccionContacto").ToString
                datosrptFicha.telefono = dr.Item("telefono").ToString
                datosrptFicha.foto = dr.Item("imagenPerfil")

                datosrptFicha.accesos = 0
                datosrptFicha.horasactividad = 0
                datosrptFicha.horastrabajadas = 0
                datosrptFicha.cantidadatrsados = 0
                datosrptFicha.tiempototalatrasos = 0
                datosrptFichalst.Add(datosrptFicha)
            Next
            lwnuActividad = 0
            'carga
            Dim datosrptCargalst As New List(Of FichaProcesoCarga)
            dtDatos = Nothing
            dtDatos = resp.Tables("procesosCargas")
            For Each dr As DataRow In dtDatos.Rows
                Dim datosrptCarga As New FichaProcesoCarga
                datosrptCarga.cedula = dr.Item("idContacto")
                datosrptCarga.aerolinea = dr.Item("agenciaCargaGuia")
                datosrptCarga.vuelo = dr.Item("agenciaElemento")
                datosrptCarga.muelle = dr.Item("muelle")
                datosrptCarga.desde = dr.Item("fechaInicioProceso")
                datosrptCarga.hasta = dr.Item("fechaFinProceso")
                datosrptCarga.totalactividad = DateDiff(DateInterval.Minute, dr.Item("fechaInicioProceso"), dr.Item("fechaFinProceso"))
                lwnuActividad += DateDiff(DateInterval.Minute, dr.Item("fechaInicioProceso"), dr.Item("fechaFinProceso"))
                datosrptCargalst.Add(datosrptCarga)
            Next

            'marcaciones
            lwnuAtrasos = 0
            lwuHorasWork = 0
            lwtiempoatraso = 0
            Dim datosrptMarcacioneslst As New List(Of FichaMarcaciones)
            Dim datosrptMarcacionesAtralst As New List(Of FichaMarcacionesAtarasos)
            dtDatos = Nothing
            dtDatos = resp.Tables("marcaciones")
            For Each dr As DataRow In dtDatos.Rows
                Dim datosrptMarcaciones As New FichaMarcaciones
                datosrptMarcaciones.cedula = dr.Item("idContacto")
                datosrptMarcaciones.fecha = dr.Item("ingreso")
                datosrptMarcaciones.horaingreso = dr.Item("ingreso")
                datosrptMarcaciones.horasalida = dr.Item("salida")
                datosrptMarcaciones.totalhorastrab = DateDiff(DateInterval.Hour, dr.Item("ingreso"), dr.Item("salida"))
                lwuHorasWork += DateDiff(DateInterval.Hour, dr.Item("ingreso"), dr.Item("salida"))
                If DateDiff(DateInterval.Hour, dr.Item("fechahoraingreso"), dr.Item("ingreso")) > 0 Then
                    datosrptMarcaciones.indatrasos = "NO"
                Else
                    datosrptMarcaciones.indatrasos = "SI"

                    Dim datosrptMarcacionesAt As New FichaMarcacionesAtarasos
                    datosrptMarcacionesat.cedula = dr.Item("idContacto")
                    datosrptMarcacionesAt.fecha = dr.Item("ingreso")
                    datosrptMarcacionesat.horaingreso = dr.Item("ingreso")
                    datosrptMarcacionesat.horasalida = dr.Item("salida")
                    datosrptMarcacionesAt.totalatraso = DateDiff(DateInterval.Minute, dr.Item("fechahoraingreso"), dr.Item("ingreso"))
                    lwtiempoatraso += DateDiff(DateInterval.Minute, dr.Item("fechahoraingreso"), dr.Item("ingreso"))
                    datosrptMarcacionesAtralst.Add(datosrptMarcacionesAt)
                    lwnuAtrasos += 1

                End If


                datosrptMarcacioneslst.Add(datosrptMarcaciones)

            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation, "MENSAJE DEL SISTEMA")
        End Try
    End Sub

End Class