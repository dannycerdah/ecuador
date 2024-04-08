Imports Infragistics.Shared
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class TimeTotalSummary
    Implements ICustomSummaryCalculator
    Private total As TimeSpan

    Public Sub New()
    End Sub
    Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
        Dim segundos As Double
        Try
            Dim tiempo As Object = row.GetCellValue(summarySettings.SourceColumn.Band.Columns("diferenciaMinutos"))
            Dim time As TimeSpan
            If tiempo Is DBNull.Value Then
                Return
            End If
            'Dim tiempoString As String = tiempo.ToString
            'time = TimeSpan.Parse(tiempoString)
            'segundos = time.TotalSeconds
            Me.total += TimeSpan.FromMinutes(tiempo)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
        Me.total = Nothing
    End Sub

    Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
        Return String.Format("{0}:{1}:{2}", total.Days * 24 + total.Hours, total.Minutes, total.Seconds)
    End Function
End Class
