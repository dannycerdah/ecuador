Imports System.Data.SqlClient
Imports System.Windows
Imports System.Deployment.Application


Public Class frmMainSpc
    Private MyFrmAirports As frmAirports
    Private MyFrmAirplanes As frmAirplane
    Private MyFrmAgencia As frmAgencia
    Private MyFrmContacto As frmContacto
    Private MyFrmSesionContactosByZonas As frmSesionContactosByZonas
    Private MyFrmDestinatarios As frmDestinatarios
    Private MyFrmUsuarios As frmUsuarios
    Private MyFrmCiudad As frmCiudad
    Private MyFrmPais As frmPais
    Private MyFrmCamion As frmCamion
    Private MyFrmDolly As frmDolly
    Private MyFrmElemento As frmElemento
    Private MyFrmHistorialElemento As frmHistorialElemento
    Private MyFrmMateriales As frmMateriales
    Private MyFrmProductos As frmProducto
    Private MyFrmPosicones As frmPosiciones
    Private MyFrmTiposElemento As frmTiposElemento
    Private MyFrmTiposProducto As frmTiposProducto
    Private MyFrmTipoAgencia As frmTiposAgencia
    Private MyFrmMatrizSeguridad As frmMatrizSeguridad
    Private MyFrmVisorProduccion As frmVisorProduccion
    Private MyFrmProduccion As frmProduccion
    Private MyFrmTarifas As frmTarifas
    Dim cnn As SqlClient.SqlConnection
    Dim tipoAgencia As Guid = Guid.Empty
    Public esSalida As Boolean
    Private dbTran As Database
    Dim nombrePc As String = ""
    Dim direccionIpPc As String = ""
    Private MyFrmCargos As frmCargo 'MARZ
    Private MyFrmPerfiles As frmPerfiles 'MARZ
    Private MyFrmTurnos As frmTurnos 'MARZ
    Private MyFrmConsultarTurnos As frmConsultarTurnosPersonal 'MARZ
    Private MyFrmMarcaciones As frmMarcaciones 'MARZ
    Private MyFrmPermisosEspeciales As frmPermisosEspeciales 'MARZ
    Private MyFrmHistorialProceso As frmHistorialProceso 'MARZ
    Private MyFrmFactura As frmFactura 'MARZ
    Private Usuario As String
    Private MyFrmCompania As frmCompanias
    Private MyFrmTemperatura As frmTemperatura
    Private MyFrmClientes As FrmClientes
    Private MyFrmServicios As FrmServicios
    Private MyFrmPeriodicidad As FrmPeriodicidad
    Private MyFrmPlantillaClientServ As FrmPlantillaClientServ
    Private MyrmConfiNotiTemp As frmConfiNotiTemp
    Private MyFrmReporteProduccion As FrmReporteProduccion
    Public Event XEvent()
    Public Event YEvent()
    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Threading.Thread.CurrentThread.Name = "MainThread"
        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.CreateSpecificCulture("en-US")
        Try
            obtenerDatosHost()

            If My.Settings.LoginEmpr = 1 Then
                Me.UtmMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Default
                Me.UtmMain.Ribbon.ApplicationMenuButtonImage = My.Resources.GA2
            Else
                Me.UtmMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon
                Me.UtmMain.Ribbon.ApplicationMenuButtonImage = Nothing
            End If

            Dim tempCont As New Server.ReportService.ContactoCatalogItem
            tempCont = CommonData.GetContactoItem(MyCurrentUser.userName)
            usbPrincipal.Panels("USB.USER").Text = tempCont.primerApellido + " " + tempCont.primerNombre
            Usuario = tempCont.primerApellido + " " + tempCont.primerNombre
            usbPrincipal.Panels("USB.TRM").Text = nombrePc.ToUpper
            Dim version As String = ""
            version = "Versión: " + My.Application.Info.Version.ToString
            usbPrincipal.Panels("USB.VER").Text = version.ToUpper
            desactivarControles() 'MARZ_17.08.17
            activarControles() 'MARZ_17.08.17
        Catch ex As Exception
            General.SetLogEvent(ex, "Main Load")
        End Try
    End Sub

    Private Sub desactivarControles() 'MARZ  - Desactivar controles del menú
        For i = 0 To Me.UtmMain.Tools.Count - 1
            Me.UtmMain.Tools.Item(i).SharedProps.Enabled = False
            Me.UtmMain.Tools.Item(i).SharedProps.Visible = False
        Next
    End Sub

    Private Sub activarControles() 'MARZ  - Activamos controles del menú por perfil
        Me.UtmMain.Tools.Item("SPC.SAL").SharedProps.Enabled = True
        Me.UtmMain.Tools.Item("SPC.ACT").SharedProps.Enabled = True

        Me.UtmMain.Tools.Item("SPC.SAL").SharedProps.Visible = True
        Me.UtmMain.Tools.Item("SPC.ACT").SharedProps.Visible = True

        For Each key As String In MyCurrentUser.permisosUsuario
            Me.UtmMain.Tools.Item(key).SharedProps.Enabled = True
            Me.UtmMain.Tools.Item(key).SharedProps.Visible = True
        Next
        'Soló el usuario JCARLOS    
        If MyCurrentUser.userId = "JCARLOS" Then
            Me.UtmMain.Tools.Item("SPC.ADM.CON.COR").SharedProps.Enabled = True
            Me.UtmMain.Tools.Item("SPC.ADM.CON.COR").SharedProps.Visible = True
        End If

    End Sub

    Private Sub obtenerDatosHost()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        nombrePc = hostInfo.HostName.ToString
    End Sub

    Private Sub UtmMain_ToolClick_1(sender As Object, e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UtmMain.ToolClick
        SelectActionByKey(e.Tool.Key)
    End Sub

    Private Sub SelectActionByKey(ByVal key As String)
        Try
            Select Case key
                'CATÁLOGOS - CATÁLOGOS
                Case "SPC.CAT.CAT.TDA" '#1 TIPO DE ACTIVIDAD
                    'SetCurrentForm(MyFrmTipoAgencia, GetType(frmTiposAgencia))
                    'MyFrmTipoAgencia.RefreshData()
                    Dim frmTipoAgen As New frmTiposAgencia
                    frmTipoAgen.RefreshData()
                    frmTipoAgen.Show()
                Case "SPC.CAT.CAT.AER" '#2 AEROPUERTOS
                    SetCurrentForm(MyFrmAirports, GetType(frmAirports))
                    MyFrmAirports.RefreshData()
                Case "SPC.CAT.CAT.AVI" '#3 AVIONES
                    'SetCurrentForm(MyFrmAirplanes, GetType(frmAirplane)) 'jro 26122018
                    'MyFrmAirplanes.RefreshData()'jro 26122018
                    'ini jro 26122018
                    Dim MyFrmAirplanes As New frmAirplane
                    MyFrmAirplanes.RefreshData()
                    MyFrmAirplanes.Show()
                    'fin jro 26122018
                Case "SPC.CAT.CAT.PDE" '#4 POSICIÓN DE ELEMENTO
                    'SetCurrentForm(MyFrmPosicones, GetType(frmPosiciones)) 'jro 26122018
                    'MyFrmPosicones.RefreshData() 'jro 26122018
                    'ini jro 26122018
                    Dim MyFrmPosicones As New frmPosiciones
                    MyFrmPosicones.RefreshData()
                    MyFrmPosicones.Show()
                    'fin jro 26122018
                Case "SPC.CAT.CAT.MDE" '#5 MATERIAL DEL ELEMENTO
                    'SetCurrentForm(MyFrmMateriales, GetType(frmMateriales)) 'jro 26122018
                    'MyFrmMateriales.RefreshData() 'jro 26122018
                    'ini jro 26122018
                    Dim MyFrmMateriales As New frmMateriales
                    MyFrmMateriales.RefreshData()
                    MyFrmMateriales.Show()
                    'fin jro 26122018
                Case "SPC.CAT.CAT.GDP" '#6 GRUPO DE PRODUCTOS
                    SetCurrentForm(MyFrmTiposProducto, GetType(frmTiposProducto))
                    MyFrmTiposProducto.RefreshData()
                Case "SPC.CAT.CAT.PRO" '#7 PRODUCTOS
                    SetCurrentForm(MyFrmProductos, GetType(frmProducto))
                    MyFrmProductos.RefreshData()

                    'CATÁLOGOS - REGISTROS
                Case "SPC.CAT.REG.CON" '#8 CONTACTOS
                    SetCurrentForm(MyFrmContacto, GetType(frmContacto))
                    MyFrmContacto.IdUsuario = MyCurrentUser.userName 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                    MyFrmContacto.RefreshData()
                Case "SPC.CAT.REG.CAR" '#9 CARGOS - MARZ
                    SetCurrentForm(MyFrmCargos, GetType(frmCargo))
                    MyFrmCargos.RefreshData()
                Case "SPC.CAT.REG.DES" '#10 DESTINATARIOS
                    SetCurrentForm(MyFrmDestinatarios, GetType(frmDestinatarios))
                    MyFrmDestinatarios.RefreshData()
                Case "SPC.CAT.REG.CAM" '#11 CAMIONES
                    SetCurrentForm(MyFrmCamion, GetType(frmCamion))
                    MyFrmCamion.RefreshData()
                Case "SPC.CAT.REG.MUL" '#12 MULAS (DOLLYS)
                    'SetCurrentForm(MyFrmDolly, GetType(frmDolly))'JRO 04012019
                    'MyFrmDolly.RefreshData()'JRO 04012019
                    'INI jro 04012019
                    Dim MyFrmDolly As New frmDolly
                    MyFrmDolly.RefreshData()
                    MyFrmDolly.Show()
                    'FIN jro 04012019
                Case "SPC.CAT.REG.ELE" '#13 ELEMENTOS 
                    Dim myfrmelemento As New frmElemento
                    myfrmelemento.Show()
                Case "SPC.CAT.REG.PES" '#14... PERMSIOS ESPECIALES 
                    SetCurrentForm(MyFrmPermisosEspeciales, GetType(frmPermisosEspeciales))
                    MyFrmPermisosEspeciales.RefreshData()

                    'CATÁLOGOS - OTROS
                Case "SPC.CAT.OTR.TAR" '#14 TARIFAS
                    SetCurrentForm(MyFrmTarifas, GetType(frmTarifas))
                    MyFrmTarifas.RefreshData()
                Case "SPC.CAT.OTR.PAI" '#15 PAÍSES
                    SetCurrentForm(MyFrmPais, GetType(frmPais))
                    MyFrmPais.RefreshData()
                Case "SPC.CAT.OTR.CIU" '#16 CIUDADES
                    SetCurrentForm(MyFrmCiudad, GetType(frmCiudad))
                    MyFrmCiudad.RefreshData()
                Case "SPC.CAT.OTR.PER" '#17 PERFILES - MARZ
                    SetCurrentForm(MyFrmPerfiles, GetType(frmPerfiles))
                    MyFrmPerfiles.RefreshData()
                Case "SPC.CAT.OTR.USU" '#18 USUARIOS
                    SetCurrentForm(MyFrmUsuarios, GetType(frmUsuarios))
                    MyFrmUsuarios.RefreshData()
                Case "SPC.CAT.OTR.MDS" '#19 MATRIZ DE SEGURIDAD
                    SetCurrentForm(MyFrmMatrizSeguridad, GetType(frmMatrizSeguridad))
                    MyFrmMatrizSeguridad.RefreshData()
                Case "SPC.CAT.OTR.CNT" '#20 Configuracion Notificacion Temp.
                    SetCurrentForm(MyrmConfiNotiTemp, GetType(frmConfiNotiTemp))
                    MyrmConfiNotiTemp.IdUsuario = MyCurrentUser.userName
                    MyrmConfiNotiTemp.RefreshData()
                Case "SPC.CYE.DAP.AGE" '#1 DATOS PERSONALES POR TIPO DE AGENCIA
                    SetCurrentForm(MyFrmAgencia, GetType(frmAgencia))
                    MyFrmAgencia.IdUsuario = MyCurrentUser.userName
                Case "SPC.CYE.DAP.AE" '#2 Aerolineas
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("04be18e6-fd0c-4466-aed2-04b0e8025772", False)
                Case "SPC.CYE.CYE.ADC" '#3 Agencias de Carga
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("e4bc6f72-6aee-42e0-a060-6cab35ab8867", False)
                Case "SPC.CYE.CYE.INS" '#4 Instituciones
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("9cf3597e-0d79-4498-8d58-5889045c3729", False)
                Case "SPC.CYE.CYE.ADS" '#5 Compañias de Seguridad
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("d68cfbd1-0c3d-4b77-9018-7e190f8b74e8", False)
                Case "SPC.CYE.CYE.SDR" '#6 Compañias de Rampa
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("65ec9238-d302-49e9-bbb5-038e1caea03c", False)
                Case "SPC.CYE.CYE.ADT" '#7 Compañias de Transporte
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("6b18f807-1df9-42fa-a490-281e61ae9679", False)
                Case "SPC.CYE.CYE.CPE" '#8 Compañias Proveedoras
                    SetCurrentForm(MyFrmCompania, GetType(frmCompanias))
                    MyFrmCompania.IdUsuario = MyCurrentUser.userName
                    MyFrmCompania.RefreshData("a0eb238b-21b3-4e46-8f06-c7d0f89f3e12", False)
                    'MOVIMIENTOS - MOVIMIENTOS
                Case "SPC.MOV.MOV.EDP" '#1 ENTRADA DE PALLETS
                    Dim FrmEntradaPallets As New frmEntradaPallets
                    FrmEntradaPallets.Show()
                Case "SPC.MOV.MOV.MDC" '#4 MOVIMIENTO DE CARGA
                    Dim FrmMovimientoDeCarga As New frmMovimientoDeCarga
                    FrmMovimientoDeCarga.IdUsuario = MyCurrentUser.userName
                    FrmMovimientoDeCarga.Show()
                Case "SPC.MOV.MOV.DDC" '#5 DEVOLUCIÓN DE CARGA
                    Dim FrmDevolucionDeCarga As New frmDevolucionDeCarga
                    FrmDevolucionDeCarga.IdUsuario = MyCurrentUser.userName
                    FrmDevolucionDeCarga.Show()
                    'PROCESOS - PROCESOS
                Case "SPC.PRO.PRO.BDV" '#1 BRIEFING DE VUELOS
                    Dim FrmBriefingVuelos As New frmBriefingVuelos
                    FrmBriefingVuelos.IdUsuario = MyCurrentUser.userName
                    FrmBriefingVuelos.Show()
                Case "SPC.PRO.PRO.PAE" '#2 PRE-ALERT DE ELEMENTOS
                    Dim FrmPreAlertElementos As New frmPreAlertElementos
                    FrmPreAlertElementos.Show()
                Case "SPC.PRO.PRO.PSE" '#3 PRE-SELECCIÓN DE ELEMENTOS
                    Dim FrmPreseleccionElementos As New frmPreseleccionElementos
                    FrmPreseleccionElementos.Show()
                Case "SPC.PRO.PRO.RDC" '#4 REGISTRO DE CAMIONES (GUÍAS)
                    Dim FrmAsignarGuia As New frmAsignarGuia
                    FrmAsignarGuia.Show()
                Case "SPC.PRO.PRO.CDP" '#5 CAPTURA DE PESO
                    'If My.Settings.LoginEmpr = 1 Then
                    Dim frmCapturaPeso As New frmCapturaPeso
                        frmCapturaPeso.IdUsuario = MyCurrentUser.userName 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                        frmCapturaPeso.Show()
                    'Else
                    '    Dim frmCapturaPeso As New frmCapturaPesoExpor
                    '    frmCapturaPeso.IdUsuario = MyCurrentUser.userName 'jro 14062018 se agreaga para tener el usuario q regalizo el ingreso o actualizacion del contacto
                    '    frmCapturaPeso.Show()
                    'End If



                        Case "SPC.PRO.PRO.SDE" '#6 STACK DE ELEMENTOS
                    Dim frmStackElementos As New frmStackPallets
                    frmStackPallets.Show()
                Case "SPC.PRO.PRO.CPE" '#7 COMPARACIÓN DEL PESO DEL ELEMENTO
                    Dim frmComparacionPeso As New frmComparacionPeso
                    frmComparacionPeso.Show()
                Case "SPC.PRO.PRO.RDM" '#8 REGISTRO DE MULAS
                    Dim FrmRegistroMula As New frmRegistroMula
                    FrmRegistroMula.Show()
                Case "SPC.PRO.PRO.ACA" '#9 ACARREO
                    Dim FrmAcarreo As New frmAcarreo
                    FrmAcarreo.Show()
                Case "SPC.PRO.PRO.RDV" '#10 REPORTE DE VUELOS
                    Dim FrmReporteVuelos As New frmReporteVuelos
                    FrmReporteVuelos.Show()
                    'PROCESOS - ULD
                Case "SPC.PRO.ULD.ENT" '#11 ENTRADA DE ULD 
                    esSalida = False
                    Dim frmULD As New frmRecepcionUld(esSalida)
                    frmULD.Show()
                Case "SPC.PRO.ULD.SAL" '#12 SALIDA DE ULD
                    esSalida = True
                    Dim frmULD As New frmRecepcionUld(esSalida)
                    frmULD.Show()
                Case "SPC.PRO.PRO.SCC" '#13 SERVICIOS CONSUMIDOS POR CLIENTES
                    Dim MyFrmRegistroConsuServ As New FrmRegistroConsuServ
                    MyFrmRegistroConsuServ.IdUsuario = MyCurrentUser.userName
                    MyFrmRegistroConsuServ.Show()
                Case "SPC.PRO.PRO.MCC" '#14 CAMBI DE CARGA DE UN CUARTO FRIO A OTRO 
                    Dim MyfrmMovientoCargaCuartoFrio As New frmMovientoCargaCuartoFrio
                    MyfrmMovientoCargaCuartoFrio.IdUsuario = MyCurrentUser.userName
                    MyfrmMovientoCargaCuartoFrio.Show()
                Case "SPC.PRO.PRO.RAV" '#14 CAMBI DE CARGA DE UN CUARTO FRIO A OTRO 
                    Dim frmEjecucionReportVueloAuto As New frmEjecucionReportVueloAuto
                    frmEjecucionReportVueloAuto.Users = MyCurrentUser.userName
                    frmEjecucionReportVueloAuto.Show()
                    'REPORTES - REPORTES
                Case "SPC.REP.REP.DEC" '#1 REPORTE DE DECOMISOS
                    Dim FrmDecomiso As New frmDecomiso
                    FrmDecomiso.Show()
                Case "SPC.REP.REP.DET" '#2 REPORTE DETALLADO
                    Dim FrmReporteDetallados As New frmReporteDetallados
                    FrmReporteDetallados.Show()
                Case "SPC.REP.REP.RES" '#5 REPORTE RESUMIDO
                    Dim FrmReporteResumidos As New frmReporteResumidos
                    FrmReporteResumidos.Show()
                Case "SPC.REP.REP.SDE" '#7 STOCK DE ELEMENTOS
                    Dim FrmReporteDetallados As New frmStockElementos(False)
                    FrmReporteDetallados.Show()
                Case "SPC.REP.REP.SDET" '#8 STOCK ELEMENTOS FORMATO .TXT
                    Dim FrmReporteDetallados As New frmStockElementos(True)
                    FrmReporteDetallados.Show()
                Case "SPC.REP.REP.HDE" '#9 REPORTE HISTORIAL DE ELEMENTOS
                    SetCurrentForm(MyFrmHistorialElemento, GetType(frmHistorialElemento))
                    MyFrmHistorialElemento.RefreshData()
                Case "SPC.REP.REP.RDPP" '#10 REPORTE DE PRODUCCIÓN (PESO)
                    If MyCurrentUser.isAdministrador Then 'Test
                        SetCurrentForm(MyFrmProduccion, GetType(frmProduccion))
                        MyFrmProduccion.RefreshData()
                    Else
                        MessageBox.Show("Opción no habilitada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Case "SPC.REP.REP.VDP" '#11 VISOR DE PRODUCCIÓN
                    If MyCurrentUser.isAdministrador Then
                        SetCurrentForm(MyFrmVisorProduccion, GetType(frmVisorProduccion))
                        MyFrmVisorProduccion.RefreshData()
                    Else
                        MessageBox.Show("Opción no habilitada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Case "SPC.REP.REP.RDP" '#12 REPORTE DE PRODUCCIÓN
                    If MyCurrentUser.isAdministrador Then
                        SetCurrentForm(MyFrmHistorialProceso, GetType(frmHistorialProceso))
                        MyFrmHistorialProceso.RefreshData()
                    Else
                        MessageBox.Show("Opción no habilitada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Case "SPC.REP.REP.PEZ" '#13 CONTACTOS EN ZONA
                    SetCurrentForm(MyFrmSesionContactosByZonas, GetType(frmSesionContactosByZonas))
                    MyFrmSesionContactosByZonas.Usuario = Usuario
                    MyFrmSesionContactosByZonas.IsReportSesion = True
                    MyFrmSesionContactosByZonas.IsReportLogSesion = False
                    MyFrmSesionContactosByZonas.ConfigurationInicial() 'MARZ 
                Case "SPC.REP.REP.HPZ" '#14 HISTORIAL DE CONTACTOS EN ZONA
                    SetCurrentForm(MyFrmSesionContactosByZonas, GetType(frmSesionContactosByZonas))
                    MyFrmSesionContactosByZonas.Usuario = Usuario
                    MyFrmSesionContactosByZonas.IsReportSesion = False
                    MyFrmSesionContactosByZonas.IsReportLogSesion = True
                    MyFrmSesionContactosByZonas.ConfigurationInicial() 'MARZ
                    'REPORTES - INDIVIDUAL

                    'ADMINISTRACIÓN - CONFIGURACIONES
                Case "SPC.ADM.CON.GEN" '#1 CONFIGURACIÓN GENERAL - MARZ
                    Dim FrmConfiguratonGeneral As New frmConfigurationGeneral
                    FrmConfiguratonGeneral.Show()

                Case "SPC.ADM.CON.BAL" '#2 CONFIGURACIÓN DE BALANZA
                    Dim FrmConfiguracionBalanza As New frmConfigurationBalanza
                    FrmConfiguracionBalanza.Show()

                Case "SPC.ADM.CON.COR" '#3 CONFIGURACIÓN DEL CORREO
                    Dim FrmConfiguratonCorreo As New frmConfigurationEmail
                    FrmConfiguratonCorreo.Show()

                    'ADMINISTRACIÓN - GENERALAIR
                Case "SPC.ADM.GEN.TUR" '#1 TURNOS
                    SetCurrentForm(MyFrmTurnos, GetType(frmTurnos))
                    MyFrmTurnos.RefreshData()

                Case "SPC.ADM.GEN.ATP" '#2 ASIGNAR TURNOS A PERSONAL
                    Dim FrmAsignarTurnosPersonal As New frmAsignarTurnosPersonal
                    FrmAsignarTurnosPersonal.Show()

                Case "SPC.ADM.GEN.CTP" '#3 CONSULTAR TURNOS PERSONAL
                    SetCurrentForm(MyFrmConsultarTurnos, GetType(frmConsultarTurnosPersonal))

                Case "SPC.ADM.GEN.MDE" '#4 MARCACIONES DE EMPLEADOS
                    SetCurrentForm(MyFrmMarcaciones, GetType(frmMarcaciones))
                    MyFrmMarcaciones.Usuario = Usuario
                Case "SPC.ADM.GEN.FAC" '#5 FACTURACIÓN
                    SetCurrentForm(MyFrmFactura, GetType(frmFactura))
                    'FACTURACION - GENERALAIR
                Case "SPC.ADM.FAC.CLI" '#1 CLIENTES
                    SetCurrentForm(MyFrmClientes, GetType(FrmClientes))
                    MyFrmClientes.IdUsuario = MyCurrentUser.userName
                    MyFrmClientes.RefreshData()
                Case "SPC.ADM.FAC.SER" '#2 SERVICIOS GENERAL
                    SetCurrentForm(MyFrmServicios, GetType(FrmServicios))
                    MyFrmServicios.IdUsuario = MyCurrentUser.userName
                    MyFrmServicios.RefreshData()
                Case "SPC.ADM.FAC.PER" '#3 PERIODICIDAD
                    SetCurrentForm(MyFrmPeriodicidad, GetType(FrmPeriodicidad))
                    MyFrmPeriodicidad.IdUsuario = MyCurrentUser.userName
                    MyFrmPeriodicidad.RefreshData()
                Case "SPC.ADM.FAC.PCS" '#3 PLANTILLA
                    SetCurrentForm(MyFrmPlantillaClientServ, GetType(FrmPlantillaClientServ))
                    MyFrmPlantillaClientServ.IdUsuario = MyCurrentUser.userName
                    MyFrmPlantillaClientServ.RefreshData()
                Case "SPC.ADM.FAC.PFT" '#4 PREFACTURACION
                    Dim MyFrmPrefacturacion As New FrmPrefacturacion
                    MyFrmPrefacturacion.IdUsuario = MyCurrentUser.userName
                    MyFrmPrefacturacion.Show()
                Case "SPC.SAL" 'SALIR DE SISTEMA
                    Me.Close()
                Case "SPC.ACT" 'BUSCAR ACTUALIZACIÓN
                    InstallUpdateSyncWithInfo()
                Case "SPC.REP.REP.RTP" '#15 Reporte de Temperatura
                    SetCurrentForm(MyFrmTemperatura, GetType(frmTemperatura))
                Case "SPC.REP.REP.RDP2" '#16 Reporte de Produccion 2
                    Dim MyFrmReporteProduccion As New FrmReporteProduccion
                    MyFrmReporteProduccion.Show()
                Case "SPC.PRO.PRO.AGS" ' ASIGNACION DE GAVETAS
                    Dim MyAsignarGaveta As New FormAsignarCubeta
                    MyAsignarGaveta.Show()

                Case Else
                    MessageBox.Show("Opción no habilitada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("La nueva versión de la aplicación no se puede descargar en este momento. " + ControlChars.Lf & ControlChars.Lf & "Por favor, compruebe la conexión de red, o inténtelo de nuevo más tarde. error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("Hay disponible una actualización. ¿Quieres actualizar la aplicación ahora?", "Actualización disponible", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("Esta aplicación ha detectado una actualización obligatoria de su actual " & _
                        "versión a versión " & info.MinimumRequiredVersion.ToString() & _
                        ". La aplicaión de actualizará y se reiniciará", _
                        "Actualización disponible", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("La aplicación se ha actualizado, y ahora se reiniciará.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("No se puede instalar la última versión de la aplicación. " & ControlChars.Lf & ControlChars.Lf & "Por favor, compruebe la conexión de red, o inténtelo de nuevo más tarde.")
                        Return
                    End Try
                End If
            End If
        Else
            MessageBox.Show("Ya estás usando la última versión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private blnPopUpQueryForms As Boolean = False
    Private Sub SetCurrentForm(ByRef DesiredForm As Object, ByVal t As Type)
        If DesiredForm Is Nothing Then
            DesiredForm = t.GetConstructor(New System.Type() {}).Invoke(New Object() {})
        End If
        If Not blnPopUpQueryForms Then
            DesiredForm.TopLevel = False
            DesiredForm.Parent = Me.pnlMain.ClientArea
            DesiredForm.Dock = DockStyle.Fill
            DesiredForm.Show()
            DesiredForm.visible = True
            DesiredForm.BringToFront()
        Else
            DesiredForm.
            DesiredForm.Show()
        End If
    End Sub
End Class