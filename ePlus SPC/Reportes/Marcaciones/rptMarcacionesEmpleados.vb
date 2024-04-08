Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class rptMarcacionesEmpleados
    Public DetalleMarcacionEmpleados As New List(Of DetalleMarcaciones)
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _Usuario As String
    Private _Segmento As String
    Private Sub MarcacionesEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportMarcacionesEmpleados.LocalReport.DataSources.Clear()
        Dim Parametros As ReportParameter() = New ReportParameter(3) {}
        Parametros(0) = New ReportParameter("ReportParameterFechaIni", "Desde " & _FechaInicio.ToString("dd/MM/yyyy HH:mm:ss"))
        Parametros(1) = New ReportParameter("ReportParameterFechaFin", "Hasta " & _FechaFin.ToString("dd/MM/yyyy HH:mm:ss"))
        Parametros(2) = New ReportParameter("ReportParameterUsuario", _Usuario)
        Parametros(3) = New ReportParameter("ReportParameterSegmento", _Segmento)
        ReportMarcacionesEmpleados.LocalReport.SetParameters(Parametros)
        ReportMarcacionesEmpleados.LocalReport.DataSources.Add(New ReportDataSource("DataSetRptMarcacionEmpleados", DetalleMarcacionEmpleados))
        Me.ReportMarcacionesEmpleados.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportMarcacionesEmpleados.RefreshReport()
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


End Class