Imports SPC.Server.ProcesoService
Public Class frmEjecucionReportVueloAuto
    Private PuntoEjecucion As String
    Public Property Users As String
    Private ClassControlEjecucionHilo As New ControlEjecucionHilo
    Private EjeuctarProceso As ReporteVueloAutomatico = ReporteVueloAutomatico.Instancia
    Private Sub frmEjecucionReportVueloAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerDatosHost()
        EjecucionProceso()
    End Sub
    Private Sub obtenerDatosHost()
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(nombreHost)
        PuntoEjecucion = hostInfo.HostName.ToString
    End Sub
    Private Sub BtnEjecutProceso_Click(sender As Object, e As EventArgs) Handles BtnEjecutProceso.Click
        EjecucionProceso()
    End Sub
    Private Sub EjecucionProceso()
        ClassControlEjecucionHilo.Tipo = "C"
        ClassControlEjecucionHilo.NombreControl = "HiloReportVueloAuto"
        ClassControlEjecucionHilo = CommonProcess.Sp_MantControlEjecutHilo(ClassControlEjecucionHilo)
        If IsNothing(ClassControlEjecucionHilo.Estado) Then
            BtnEjecutProceso.Enabled = False
            BtnDetenerProceso.Enabled = True
            EjeuctarProceso.Users = Users
            EjeuctarProceso.CicloEjecu = True
            EjeuctarProceso.EjecutarHilo()
            UltraLabel1.Visible = True
            TxtTerminal.Visible = True
            TxtTerminal.Text = PuntoEjecucion
        Else
            TxtTerminal.Text = ClassControlEjecucionHilo.PuntoEjecucion
            UltraLabel1.Visible = True
            TxtTerminal.Visible = True
            BtnEjecutProceso.Enabled = False
            BtnDetenerProceso.Enabled = True
        End If
    End Sub
    Private Sub BtnDetenerProceso_Click(sender As Object, e As EventArgs) Handles BtnDetenerProceso.Click
        EjeuctarProceso.CicloEjecu = False
        EjeuctarProceso.AbortarHilo()
        BtnEjecutProceso.Enabled = True
        BtnDetenerProceso.Enabled = False
    End Sub

    Private Sub frmEjecucionReportVueloAuto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        EjeuctarProceso.CicloEjecu = False
        EjeuctarProceso.AbortarHilo()
        BtnEjecutProceso.Enabled = True
        BtnDetenerProceso.Enabled = False
    End Sub
End Class