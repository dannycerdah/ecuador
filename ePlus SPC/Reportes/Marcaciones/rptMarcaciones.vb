Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class rptMarcaciones

    Public cabecera As New List(Of CabeceraMarcaciones)
    Public detalle As New List(Of DetalleMarcaciones)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub rptMarcaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WareHouseMarcaciones.LocalReport.DataSources.Clear()
            WareHouseMarcaciones.LocalReport.DataSources.Add(New ReportDataSource("dtsEncabezadoMarcaciones", cabecera))
            WareHouseMarcaciones.LocalReport.DataSources.Add(New ReportDataSource("dtsMarcaciones", detalle))
            Me.WareHouseMarcaciones.SetDisplayMode(DisplayMode.PrintLayout)
            Me.WareHouseMarcaciones.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class