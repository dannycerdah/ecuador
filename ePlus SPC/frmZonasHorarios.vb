Public Class frmZonasHorarios
    Public Property dtHorarios As New DataTable("dtHorarios")
    Private Function AgregarInfoHorarios()
        For i = 0 To dgvHorarios.ColumnCount - 1
            dtHorarios.Columns.Add(dgvHorarios.Columns(i).Name)
        Next
        For i = 0 To dgvHorarios.RowCount - 2
            Dim newRow As DataRow
            newRow = dtHorarios.NewRow
            newRow.Item(0) = dgvHorarios.Rows(i).Cells(0).Value
            newRow.Item(1) = dgvHorarios.Rows(i).Cells(1).Value
            newRow.Item(2) = dgvHorarios.Rows(i).Cells(2).Value
            dtHorarios.Rows.Add(newRow)
        Next
        Return dtHorarios
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AgregarInfoHorarios()
        Me.Close()
    End Sub
End Class