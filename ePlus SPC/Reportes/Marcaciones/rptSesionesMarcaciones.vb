Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class rptSesionesMarcaciones
    Public CabeceraMarcaciones As New List(Of CabeceraMarcaciones)
    Public Detallemarcaciones As New List(Of DetalleMarcaciones)
    Public FrmSesiones As New frmSesionContactosByZonas
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _Usuario As String
    Private _Segmento As String
    Private Sub rptSesionesMarcaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Parametros As ReportParameter() = New ReportParameter(3) {}
            Parametros(0) = New ReportParameter("ReportParameterFechaInicio", "Desde " & _FechaInicio.ToString("dd/MM/yyyy HH:mm:ss"))
            Parametros(1) = New ReportParameter("ReportParameterFechaFin", "Hasta " & _FechaFin.ToString("dd/MM/yyyy HH:mm:ss"))
            Parametros(2) = New ReportParameter("ReportParameterUsuario", _Usuario)
            Parametros(3) = New ReportParameter("ReportParameterSegmentoReport", _Segmento)
            ReportSesionMarcaciones.LocalReport.DataSources.Clear()
            'ReportSesionMarcaciones.LocalReport.DataSources.Add(New ReportDataSource("CabeceraMarcaciones", CabeceraMarcaciones))
            ReportSesionMarcaciones.LocalReport.DataSources.Add(New ReportDataSource("DetalleMarcaciones", Detallemarcaciones))
            Me.ReportSesionMarcaciones.LocalReport.SetParameters(Parametros)
            Me.ReportSesionMarcaciones.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportSesionMarcaciones.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaFin As Date
        Get
            Return _FechaFin
        End Get
        Set(value As Date)
            _FechaFin = value
        End Set
    End Property
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property
    Public Property Segmento As String
        Get
            Return _Segmento
        End Get
        Set(value As String)
            _Segmento = value
        End Set
    End Property

    Private Sub DetalleMarcacionesBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles DetalleMarcacionesBindingSource.CurrentChanged

    End Sub
End Class