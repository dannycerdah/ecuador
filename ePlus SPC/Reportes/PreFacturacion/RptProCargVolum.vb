Imports Microsoft.Reporting.WinForms
Public Class RptProCargVolum
    Public ListDetallePesoVolumenVuelo2 As New List(Of ListDetallePesoVolumenVuelo)
    Public ListDetallePesoVolumenVuelo As New ListDetallePesoVolumenVuelo
    Public TipoServicio As Integer = 0
    Private Sub RptProCargVolum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If TipoServicio = 5 Or TipoServicio = 10 Or TipoServicio = 11 Or TipoServicio = 15 Then
                With RptProCargVolumen
                    .LocalReport.DataSources.Add(New ReportDataSource("ListDetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo2))
                    .LocalReport.DataSources.Add(New ReportDataSource("DetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo.DetallePesoVolumenVuelo))
                    .SetDisplayMode(DisplayMode.PrintLayout)
                    .Refresh()
                End With
            ElseIf TipoServicio = 1 Then
                Me.RptProCargVolumen.LocalReport.ReportEmbeddedResource = "SPC.RptAgenCarVuelo.rdlc"
                'RptProCargVolumen.LocalReport.ReportPath = "..\\..\\Reportes\\PreFacturacion\\RptAgenCarVuelo.rdlc"
                With RptProCargVolumen
                    .LocalReport.DataSources.Add(New ReportDataSource("ListDetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo2))
                    .LocalReport.DataSources.Add(New ReportDataSource("DetalleVuelos", ListDetallePesoVolumenVuelo.DetalleVuelos))
                    .SetDisplayMode(DisplayMode.PrintLayout)
                    .Refresh()
                End With
            ElseIf TipoServicio = 2 Then
                Me.RptProCargVolumen.LocalReport.ReportEmbeddedResource = "SPC.RptServContainer.rdlc"
                'RptProCargVolumen.LocalReport.ReportPath = "..\\..\\Reportes\\PreFacturacion\\RptServContainer.rdlc"
                With RptProCargVolumen
                    .LocalReport.DataSources.Add(New ReportDataSource("ListDetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo2))
                    .LocalReport.DataSources.Add(New ReportDataSource("DetalleServicioContainer", ListDetallePesoVolumenVuelo.DetalleServicioContainer))
                    .SetDisplayMode(DisplayMode.PrintLayout)
                    .Refresh()
                End With
            ElseIf TipoServicio = 7 Then
                Me.RptProCargVolumen.LocalReport.ReportEmbeddedResource = "SPC.RptEstibaDesestiba.rdlc"
                With RptProCargVolumen
                    .LocalReport.DataSources.Add(New ReportDataSource("ListDetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo2))
                    .LocalReport.DataSources.Add(New ReportDataSource("DetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo.DetallePesoVolumenVuelo))
                    .SetDisplayMode(DisplayMode.PrintLayout)
                    .Refresh()
                End With
            ElseIf TipoServicio = 12 Then
                Me.RptProCargVolumen.LocalReport.ReportEmbeddedResource = "SPC.RptAlquilerMonCarga.rdlc"
                'RptProCargVolumen.LocalReport.ReportPath = "..\\..\\Reportes\\PreFacturacion\\RptAlquilerMonCarga.rdlc"
                With RptProCargVolumen
                    .LocalReport.DataSources.Add(New ReportDataSource("ListDetallePesoVolumenVuelo", ListDetallePesoVolumenVuelo2))
                    .LocalReport.DataSources.Add(New ReportDataSource("DetalleServMontCarga", ListDetallePesoVolumenVuelo.DetalleServMontCarga))
                    .SetDisplayMode(DisplayMode.PrintLayout)
                    .Refresh()
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class