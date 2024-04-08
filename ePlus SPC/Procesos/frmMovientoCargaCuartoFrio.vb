Public Class frmMovientoCargaCuartoFrio
    Private P_idBriefing As Guid
    Private P_idGuia As Guid
    Private P_idProceso As Guid
    Private P_idElemento As String
    Public IdUsuario As String
    Dim tipoAgencia As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim Cuarto As String
    Private Sub frmMovientoCargaCuartoFrio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAerolinea()
        CargarCuartos()
    End Sub
    Private Sub CargarAerolinea()
        Dim dt As New DataTable("Agencia")
        Dim ds As New DataSet
        uceAerolinea.Items.Clear()
        uceAerolinea.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(tipoAgencia).Rows
            uceAerolinea.Items.Add(r.Item("idAgencia"), r.Item("DescripcionAgencia"))
        Next
        uceAerolinea.SelectedIndex = 0
    End Sub
    Private Sub CargarCuartos()
        cmbCuartos.Clear()
        cmbCuartos2.Clear()
        cmbCuartos.Items.Add(0, "Todos los Cuartos")
        cmbCuartos2.Items.Add(0, "Todos los Cuartos")
        For Each r As DataRow In CommonData.ObtenerCuartosFrios.Rows
            cmbCuartos.Items.Add(r.Item("idCuarto"), r.Item("NombreCuarto"))
            cmbCuartos2.Items.Add(r.Item("idCuarto"), r.Item("NombreCuarto"))
        Next
        cmbCuartos.SelectedIndex = 0
        cmbCuartos2.SelectedIndex = 0
    End Sub
    Private Sub btnConsVuelo_Click(sender As Object, e As EventArgs) Handles btnConsVuelo.Click
        Try
            If uceAerolinea.Value <> Guid.Empty Then
                Dim frmConsultaVuelos As New FrmConsultaVuelosGuias(uceAerolinea.Text, uceAerolinea.Value, True)
                frmConsultaVuelos.ShowDialog()
                txtNumVuelo.Text = frmConsultaVuelos.CodigoVuelo
                txtGuia.Text = frmConsultaVuelos.IdElemento
                P_idBriefing = frmConsultaVuelos.IdBriefing
                P_idGuia = frmConsultaVuelos.IdGuia
                P_idProceso = frmConsultaVuelos.IdProceso
                P_idElemento = frmConsultaVuelos.IdElemento
            End If
            Dim CuartoBuscar As String
            Dim MayorCuarto As Integer
            Dim row As Integer = 0
            For Each i As DataRow In CommonData.ObtenerCuartoFrioIdProIdGui(P_idProceso, P_idElemento).Rows
                If row = 0 Then
                    MayorCuarto = i.Item("total")
                    CuartoBuscar = i.Item("RegCargaCuartoFrio")
                    row += 1
                Else
                    If MayorCuarto < i.Item("total") Then
                        MayorCuarto = i.Item("total")
                        CuartoBuscar = i.Item("RegCargaCuartoFrio")
                    End If
                End If
            Next
            If row > 0 Then
                If CuartoBuscar = "A2" Then
                    Cuarto = "CUARTO-FRIO-A-2"
                ElseIf CuartoBuscar = "A3-4" Then
                    Cuarto = "CUARTO-FRIO-A-3-4"
                ElseIf CuartoBuscar = "A5" Then
                    Cuarto = "CUARTO-FRIO-A-5"
                ElseIf CuartoBuscar = "B" Then
                    Cuarto = "CUARTO-FRIO-B-1"
                ElseIf CuartoBuscar = "Z-Flores" Then
                    Cuarto = "CUARTO-FRIO-Z-1"
                ElseIf CuartoBuscar = "Z-Pequeño" Then
                    Cuarto = "CUARTO-FRIO-Z-2"
                End If
                For r = 0 To cmbCuartos.Items.Count - 1
                    If cmbCuartos.Items.[All](r).ToString = Cuarto Then
                        cmbCuartos.SelectedIndex = r
                        cmbCuartos.Enabled = False
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If cmbCuartos2.SelectedIndex <> 0 And cmbCuartos.SelectedItem.ToString <> cmbCuartos2.SelectedItem.ToString Then
            Dim DatosCuarto As New Server.ControlTemp.TempBitacoraCuarto
            Dim CuartoActaual As String
            Dim CuartoAnt As String
            If cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-A-2" Then
                CuartoActaual = "A2"
            ElseIf cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-A-3-4" Then
                CuartoActaual = "A3-4"
            ElseIf cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-A-5" Then
                CuartoActaual = "A5"
            ElseIf cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-B-1" Then
                CuartoActaual = "B"
            ElseIf cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-Z-1" Then
                CuartoActaual = "Z-Flores"
            ElseIf cmbCuartos2.SelectedItem.ToString = "CUARTO-FRIO-Z-2" Then
                CuartoActaual = "Z-Pequeño"
            End If
            If cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-2" Then
                CuartoAnt = "A2"
            ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-3-4" Then
                CuartoAnt = "A3-4"
            ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-A-5" Then
                CuartoAnt = "A5"
            ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-B-1" Then
                CuartoAnt = "B"
            ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-Z-1" Then
                CuartoAnt = "Z-Flores"
            ElseIf cmbCuartos.SelectedItem.ToString = "CUARTO-FRIO-Z-2" Then
                CuartoAnt = "Z-Pequeño"
            End If
            With DatosCuarto
                .idProceso = P_idProceso
                .idElemento = P_idElemento
                .CuartoActual = CuartoActaual
                .CuartoAnteriror = CuartoAnt
                .idGuia = P_idGuia
                .idProceso = P_idBriefing
                .UsuarioIngreso = IdUsuario
            End With
            If CommonData.AgregaBitacoraCargaCuarto(DatosCuarto) Then
                MessageBox.Show("Registro de Movimiento con Exito", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If CuartoActaual = "A2" Then
                    Cuarto = "CUARTO-FRIO-A-2"
                ElseIf CuartoActaual = "A3-4" Then
                    Cuarto = "CUARTO-FRIO-A-3-4"
                ElseIf CuartoActaual = "A5" Then
                    Cuarto = "CUARTO-FRIO-A-5"
                ElseIf CuartoActaual = "B" Then
                    Cuarto = "CUARTO-FRIO-B-1"
                ElseIf CuartoActaual = "Z-Flores" Then
                    Cuarto = "CUARTO-FRIO-Z-1"
                ElseIf CuartoActaual = "Z-Pequeño" Then
                    Cuarto = "CUARTO-FRIO-Z-2"
                End If
                For r = 0 To cmbCuartos.Items.Count - 1
                    If cmbCuartos.Items.[All](r).ToString = Cuarto Then
                        cmbCuartos.SelectedIndex = r
                        cmbCuartos.Enabled = False
                        Exit For
                    End If
                Next
            Else
                MessageBox.Show("Registro de Movimiento con Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class