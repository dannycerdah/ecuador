Imports SPC.Server.ProcesoService
Imports Infragistics.Win.UltraWinGrid
Public Class frmProduccion
    Dim proceso As ProcesoItem = New ProcesoItem
    Dim idVacio As Guid = Guid.Parse("00000000-0000-0000-0000-000000000000")
    Dim agencia1 As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim dtDetalleProcesoReporte As New DataTable("dtDetalleProcesoReporte")
    Dim dtDetalleProcesoCargaReporte As New DataTable("dtDetalleProcesoCargaReporte")
    Dim totalVolumen As Decimal = 0D
    Dim totalPesos As Decimal = 0D
    Dim totalPesosDev As Decimal = 0D

    Public Sub RefreshData()
        Dim dtProduccion As New DataTable("Produccion")
        dtProduccion = CommonData.GetProduccion(udtFechaInicio.Value, udtFechaFin.Value, uceAgencia.Value)
        For Each r As DataRow In dtProduccion.Rows
            cargarProceso(r.Item("idBriefing"))
            If Not (proceso Is Nothing) Then
                dtDetalleProcesoCargaReporte = CommonProcess.GetDetalleProcesoCargaPorIdProcesoReporte(proceso.IdProceso)
                CargarProcesamientoCargayVolumen()
                r.Item("DevolucionPeso") = totalPesosDev
                r.Item("CargaVolumenPeso") = totalVolumen
                r.Item("CargaPeso") = totalPesos

                If r.Item("Verificado") = "No" Then
                    r.Item("Devolucion") = totalPesosDev * r.Item("devolucionCarTar")
                    r.Item("Carga_Volumen") = totalVolumen * r.Item("procesamientoCVTar")
                    r.Item("Carga") = totalPesos * r.Item("procesamientoCarTar")
                End If
            End If
        Next
        ugdAirplane.DataSource = dtProduccion
        SetDisplayedColumns()
    End Sub

    Private Sub SetDisplayedColumns()
        Try

            ugdAirplane.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
            ugdAirplane.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            ugdAirplane.DisplayLayout.Bands(0).Columns("H").Width = 210
            ugdAirplane.DisplayLayout.Bands(0).Columns("Fecha_vuelo").Width = 50
            ugdAirplane.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Width = 120
            ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").Width = 50


            ugdAirplane.DisplayLayout.Bands(0).Columns("idproduccion").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("idBriefing").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("idVuelo").Hidden = True

            If uceAgencia.Value = Guid.Empty Then
                ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = False
            Else
                ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = True
            End If

            'tarifas
            ugdAirplane.DisplayLayout.Bands(0).Columns("devolucionCarTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("procesamientoCarTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("procesamientoCVTar").Hidden = True

            '--
            ugdAirplane.DisplayLayout.Bands(0).Columns("agenteCarTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("almacenajeConTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("almacenajeCorTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("almacenajeCarTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("correoTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("estibaDesTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("limpiezaEleTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("manipuleoTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("minimoMesTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("minimoVueloTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("montaCargaTar").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("precoolingTar").Hidden = True
            'fin tarifas

            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion_Carga_Vol").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Vol").Hidden = True
            ugdAirplane.DisplayLayout.Bands(0).Columns("H").Hidden = False
            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Header.Caption = "Valor"
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga_volumen").Header.Caption = "Valor"
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga").Header.Caption = "Valor"
            ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso").Header.Caption = "Peso"
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso").Header.Caption = "Peso"
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso").Header.Caption = "Peso"

            ugdAirplane.DisplayLayout.Bands(0).Columns("Fecha_vuelo").Header.Caption = "Fecha Vuelo" 'Fecha Vuelo
            ugdAirplane.DisplayLayout.Bands(0).Columns("codigoVuelo").Header.Caption = "Código Vuelo "
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Header.Caption = "Aerolínea"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").Header.Caption = "Visto"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Fecha_vuelo").RowLayoutColumnInfo.OriginX = 0
            ugdAirplane.DisplayLayout.Bands(0).Columns("codigoVuelo").RowLayoutColumnInfo.OriginX = 2
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").RowLayoutColumnInfo.OriginX = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").RowLayoutColumnInfo.OriginX = 6
            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").RowLayoutColumnInfo.OriginX = 8
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").RowLayoutColumnInfo.OriginX = 10
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").RowLayoutColumnInfo.OriginX = 12
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").RowLayoutColumnInfo.OriginX = 14
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").RowLayoutColumnInfo.OriginX = 20
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").RowLayoutColumnInfo.OriginX = 22
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").RowLayoutColumnInfo.OriginX = 24
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").RowLayoutColumnInfo.OriginX = 26
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").RowLayoutColumnInfo.OriginX = 28
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").RowLayoutColumnInfo.OriginX = 30
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").RowLayoutColumnInfo.OriginX = 32
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").RowLayoutColumnInfo.OriginX = 34
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").RowLayoutColumnInfo.OriginX = 44


            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").RowLayoutColumnInfo.LabelSpan = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").RowLayoutColumnInfo.SpanY = 4
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").RowLayoutColumnInfo.LabelSpan = 4




            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Header.Caption = "Agente de carga por vuelo"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Header.Caption = "Almacenaje container +5"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Header.Caption = "Almacenaje Corral"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Header.Caption = "Almacenaje Carga"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Header.Caption = "Correo por vuelo"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Header.Caption = "Estiba / Destiba"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Header.Caption = "Limpieza Corral Elem"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Header.Caption = "Manipuleo por vuelo"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Header.Caption = "Minimo por mes"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Header.Caption = "Minimo por vuelo"
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Header.Caption = "Montacarga 1/2 hora"
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Header.Caption = "PreCooling"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Header.Caption = "Varios"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion_Carga_Vol").Header.Caption = "Devolucion carga V"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Vol").Header.Caption = "Estiba V"
            ugdAirplane.DisplayLayout.Bands(0).Columns("H").Header.Caption = " "

            ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga_volumen").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion_Carga_Vol").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Vol").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga_volumen").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion_Carga_Vol").Format = "$#,##0.00"
            ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Vol").Format = "$#,##0.00"

            ugdAirplane.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.GroupLayout 'ewlm
            ugdAirplane.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.AllowAll
            Dim band As UltraGridBand = Me.ugdAirplane.DisplayLayout.Bands(0) 'ewlm
            band.ColHeaderLines = 3

            Dim firstGroup As UltraGridGroup = band.Groups.Add("FirstGroup", "Devolución")
            Dim secondGroup As UltraGridGroup = band.Groups.Add("SecondGroup", "Procesamiento Carga")
            Dim thirdGroup As UltraGridGroup = band.Groups.Add("ThirdGroup", "Volumen Carga ")
            firstGroup.Width = 120
            secondGroup.Width = 120
            thirdGroup.Width = 120
            firstGroup.RowLayoutGroupInfo.OriginX = 16
            secondGroup.RowLayoutGroupInfo.OriginX = 36
            thirdGroup.RowLayoutGroupInfo.OriginX = 40
            ugdAirplane.DisplayLayout.Bands(0).Columns("H").RowLayoutColumnInfo.OriginX = 46  ' de 4 en 4 por grupos, 2 en 2 por columnas

            band.Columns("Fecha_vuelo").RowLayoutColumnInfo.SpanY = 4
            band.Columns("Fecha_vuelo").RowLayoutColumnInfo.LabelSpan = 4
            band.Columns("codigoVuelo").RowLayoutColumnInfo.SpanY = 4
            band.Columns("codigoVuelo").RowLayoutColumnInfo.LabelSpan = 4
            band.Columns("Aerolinea").RowLayoutColumnInfo.SpanY = 4
            band.Columns("Aerolinea").RowLayoutColumnInfo.LabelSpan = 4
            band.Columns("Verificado").RowLayoutColumnInfo.SpanY = 4
            band.Columns("Verificado").RowLayoutColumnInfo.LabelSpan = 4


            band.Columns("Devolucion").RowLayoutColumnInfo.ParentGroup = firstGroup
            band.Columns("DevolucionPeso").RowLayoutColumnInfo.ParentGroup = firstGroup
            band.Columns("carga").RowLayoutColumnInfo.ParentGroup = secondGroup
            band.Columns("CargaPeso").RowLayoutColumnInfo.ParentGroup = secondGroup
            band.Columns("carga_volumen").RowLayoutColumnInfo.ParentGroup = thirdGroup
            band.Columns("CargaVolumenPeso").RowLayoutColumnInfo.ParentGroup = thirdGroup

            ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("carga_volumen").Width = 60
            ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso").Width = 60

            'ewlm

            ugdAirplane.DisplayLayout.Bands(0).Summaries.Clear()
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso")).DisplayFormat = "{0}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso")).DisplayFormat = "{0}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso")).DisplayFormat = "{0}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("devolucion")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Carga")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Carga_Volumen")).DisplayFormat = "{0:C2}"

            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Varios")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion_Carga_Vol")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Vol")).DisplayFormat = "{0:C2}"
            ugdAirplane.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cargarProceso(idbriefing As Guid)
        Try
            If (proceso Is Nothing) Then
                proceso = New ProcesoItem
            End If
            With proceso
                .idBriefing = idbriefing
            End With
            proceso = CommonProcess.GetProcesoPoridBriefing(proceso.idBriefing)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CargarProcesamientoCargayVolumen()
        Dim totalvol As Decimal = 0D
        Dim totalpeso As Decimal = 0D
        Dim totalpesoDev As Decimal = 0D
        totalVolumen = 0D
        totalPesos = 0D
        Try
            For Each r As DataRow In dtDetalleProcesoCargaReporte.Rows
                If (r.Item("estado") = "A" Or r.Item("estado") = "I" Or r.Item("estado") = "D") Then
                    totalpeso = r.Item("peso") + totalpeso
                    If r.Item("volumen") < r.Item("peso") Then
                        totalvol = r.Item("peso") + totalvol
                    Else
                        totalvol = r.Item("volumen") + totalvol
                    End If
                End If
                If (r.Item("estado") = "D") Then
                    totalpesoDev = r.Item("peso") + totalpesoDev
                End If
            Next
            totalVolumen = totalvol
            totalPesos = totalpeso
            totalPesosDev = totalpesoDev
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CargarDevolucion() As Decimal
        Try

            Dim totalpeso As Decimal = 0D
            Dim totalvol As Decimal = 0D
            Dim totalDias As Integer = 0
            For Each r As DataRow In dtDetalleProcesoReporte.Rows
                If r.Item("estado") <> "R" Then
                    totalDias = DateDiff("n", r.Item("fechaLlegadaCamion"), r.Item("fechaLlegadaEstimadaGuia"))
                    If totalDias <= -30 Or totalDias > 30 Then
                        totalpeso = r.Item("peso") + totalpeso
                    End If
                End If
            Next
            Return totalpeso
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Private Sub ShowTarifasDetails(idB As Guid, id As Guid)
        Using frmDetails As New frmProduccionDetalle(idB, id)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Todos")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(agencia1).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub


#Region "events"

    Private Sub frmProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        udtFechaInicio.Value = DateTime.Now()
        udtFechaFin.Value = DateTime.Now()
        cargarComboAgencia()
        RefreshData()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        RefreshData()
    End Sub

    Private Sub ugdAirplane_DoubleClickCell_1(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdAirplane.DoubleClickCell
        If Not ugdAirplane.ActiveRow.Cells("idBriefing").Value.ToString = String.Empty Then
            If (ugdAirplane.ActiveRow.Cells("idProduccion").Value.ToString.Trim = "") Then
                ShowTarifasDetails(ugdAirplane.ActiveRow.Cells("idBriefing").Value, idVacio)
            Else
                ShowTarifasDetails(ugdAirplane.ActiveRow.Cells("idBriefing").Value, ugdAirplane.ActiveRow.Cells("idProduccion").Value)
            End If
        Else
            Using frmDetails As New frmProduccionDetalle(True)
                frmDetails.ShowDialog()
            End Using
        End If
        RefreshData()
    End Sub


    Private Sub btnExcelExport_Click(sender As Object, e As EventArgs) Handles btnExcelExport.Click
        ugdAirplane.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        ugdAirplane.DisplayLayout.Override.ColumnHeaderTextOrientation = Infragistics.Win.TextOrientationInfo.Horizontal
        ugdAirplane.DisplayLayout.Override.GroupHeaderTextOrientation = Infragistics.Win.TextOrientationInfo.Horizontal 'ewlm
        ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Hidden = True

        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga_Volumen").Hidden = True

        ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga_Volumen").Hidden = False
        ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Hidden = False

        ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").Hidden = True
        If uceAgencia.Value = Guid.Empty Then
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = False
        Else
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = True
        End If
        ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Width = 75

        ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga_Volumen").Width = 75

        ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso").Width = 75

        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Width = 80
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Width = 80
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Width = 80
        ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Carga_Volumen").Width = 75
        ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Width = 75

        ugdAirplane.DisplayLayout.Bands(0).Columns("Fecha_vuelo").Width = 60
        ugdAirplane.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = 70
        ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Width = 80

        ugdAirplane.DisplayLayout.Bands(0).Columns("H").Hidden = True

        General.ExportToExcel(ugdAirplane)
        ugdAirplane.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        ugdAirplane.DisplayLayout.Override.ColumnHeaderTextOrientation = Infragistics.Win.TextOrientationInfo.Horizontal
        ugdAirplane.DisplayLayout.Override.GroupHeaderTextOrientation = Infragistics.Win.TextOrientationInfo.Horizontal 'ewlm
        ugdAirplane.DisplayLayout.Bands(0).Columns("Agente_Carga_X_Vuelo").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Container_5").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Corral_Kg").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Alm_Carga_Kg").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Correo_X_Vuelo").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Estiba_Camion_Dolly").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Limpieza_Elem_Corral").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Manipuleo_X_Vuelo").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Mes").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Minimo_X_Vuelo").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("MontaCarga_media_hora").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("PreCooling").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("Varios").Hidden = True
        ugdAirplane.DisplayLayout.Bands(0).Columns("H").Hidden = False

        ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").Hidden = False

        If uceAgencia.Value = Guid.Empty Then
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = False
        Else
            ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Hidden = True
        End If

        ugdAirplane.DisplayLayout.Bands(0).Columns("H").Width = 210
        ugdAirplane.DisplayLayout.Bands(0).Columns("Fecha_vuelo").Width = 30
        ugdAirplane.DisplayLayout.Bands(0).Columns("codigoVuelo").Width = 30
        ugdAirplane.DisplayLayout.Bands(0).Columns("Aerolinea").Width = 35
        ugdAirplane.DisplayLayout.Bands(0).Columns("Verificado").Width = 10

        ugdAirplane.DisplayLayout.Bands(0).Groups("FirstGroup").Width = 55
        ugdAirplane.DisplayLayout.Bands(0).Groups("FirstGroup").Width = 60
        ugdAirplane.DisplayLayout.Bands(0).Groups("FirstGroup").Width = 55

        ugdAirplane.DisplayLayout.Bands(0).Columns("Devolucion").Width = 27
        ugdAirplane.DisplayLayout.Bands(0).Columns("DevolucionPeso").Width = 27
        ugdAirplane.DisplayLayout.Bands(0).Columns("carga").Width = 30
        ugdAirplane.DisplayLayout.Bands(0).Columns("CargaPeso").Width = 30
        ugdAirplane.DisplayLayout.Bands(0).Columns("carga_volumen").Width = 27
        ugdAirplane.DisplayLayout.Bands(0).Columns("CargaVolumenPeso").Width = 27
    End Sub

#End Region


    Private Sub ugdAirplane_SummaryValueChanged(sender As Object, e As SummaryValueChangedEventArgs) Handles ugdAirplane.SummaryValueChanged
        e.SummaryValue.Appearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub
End Class