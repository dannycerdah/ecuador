Public Class MantCuartoFrios
    Private DtCuartos As New DataTable("conftemperatura")
    Private LbSetData As Boolean
    Private NombreCuarto As String = "CUARTO-FRIO-"
    Private Sub MantCuartoFrios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DtCuartos.Columns
            .Add("NombreCuarto", GetType(String))
            .Add("Descripcion", GetType(String))
            .Add("FechaIngreso", GetType(DateTime))
            .Add("Estado", GetType(String))
        End With
        CargaCuartos()
    End Sub
    Private Sub CargaCuartos()
        DtCuartos = CommonDataTempera.ObtenerCuartosFrios
        If DtCuartos.Rows.Count > 0 Then
            dgvCuartos.DataSource = DtCuartos
            dgvCuartos.Refresh()
            LbSetData = True
            SetDataGrid()
        End If
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim addRow As Boolean = True
        Dim row As DataRow
        Dim resultIngr As Boolean
        Dim NombreCuartoFrio As String
        NombreCuartoFrio = NombreCuarto & cmbCuarto.SelectedItem & "-" & cmbNum.SelectedItem
        If Not IsNothing(cmbNum2.SelectedItem) Then
            NombreCuartoFrio = NombreCuartoFrio & "-" & cmbNum2.SelectedItem
        End If
        If Not IsNothing(cmbNum.SelectedItem) And Not IsNothing(cmbCuarto.SelectedItem) Then
            If dgvCuartos.Rows.Count > 0 Then
                For Each r As DataGridViewRow In dgvCuartos.Rows
                    If r.Cells("NombreCuarto").Value = NombreCuartoFrio Then
                        addRow = False
                        Exit For
                    End If
                Next
            End If
            If addRow = True Then
                row = DtCuartos.NewRow
                row.Item("NombreCuarto") = NombreCuartoFrio
                row.Item("Descripcion") = txtDescrip.Text
                row.Item("Estado") = "A"
                DtCuartos.Rows.Add(row)
                dgvCuartos.Refresh()
                resultIngr = CommonDataTempera.RegCuartoFrio(NombreCuartoFrio, "A", txtDescrip.Text)
                If resultIngr Then
                    MessageBox.Show("Registro Ingresado Correctamente")
                Else
                    MessageBox.Show("Error al registrar el cuarto frio")
                End If
                If LbSetData = False Then
                    dgvCuartos.DataSource = DtCuartos
                End If
                SetDataGrid()
            End If
        Else
            MessageBox.Show("Seleccione el Cuarto y su Numeracion")
        End If
    End Sub
    Private Sub SetDataGrid()
        dgvCuartos.Columns("IdCuarto").Visible = False
        dgvCuartos.Columns("FechaIngreso").Visible = False
    End Sub

    Private Sub dgvCuartos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvCuartos.UserDeletingRow
        Dim resp As Boolean
        Try
            For Each r As DataGridViewRow In dgvCuartos.SelectedRows
                resp = CommonDataTempera.RegCuartoFrio(r.Cells("NombreCuarto").Value, "E", r.Cells("Descripcion").Value)
                If Not resp Then
                    MessageBox.Show("error el intentar grebar los registros")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class