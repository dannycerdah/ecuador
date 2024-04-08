
Public Class frmConsultaAgencia
    Dim AgenciaAerolinea As String = "04be18e6-fd0c-4466-aed2-04b0e8025772"
    Dim AgenciaAerolineaEX As String = "34d5b7d2-db23-44da-8f79-e05329c20377"
    Dim AgenciaTransporte As String = "e4bc6f72-6aee-42e0-a060-6cab35ab8867"

    Dim Id As String = ""
    Public Avion As New Server.ReportService.AirplaneCatalogItem
    Public dtATransporte As New DataTable("Transporte")
    Public tempDesc As String = ""
    Public tempId As New Guid

    Public Sub New(ByVal AgenciaId As String)
        InitializeComponent()
        Id = AgenciaId
        cargarComboAgencia()
    End Sub

    Private Sub cargarComboAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgenciaPorTipo(Id).Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia.SelectedIndex = 0
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            If Id = AgenciaAerolinea Then
                ugdAgentes.DataSource = CommonData.GetAvionPorIdAgencia(uceAgencia.Value)
                SetDisplayedColumnsAvion()
            ElseIf Id = AgenciaTransporte Then
                ugdAgentes.DataSource = CommonData.GetAgenciaPorTipo(Id)
                SetDisplayedColumnsTransporte()
            ElseIf Id = AgenciaAerolineaEX Then
                ugdAgentes.DataSource = CommonData.GetAvionPorIdAgencia(uceAgencia.Value)
                SetDisplayedColumnsAvion()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsTransporte()
        Try
            ugdAgentes.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("tipoAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Agencia"
            ugdAgentes.DisplayLayout.Bands(0).Columns("direccionAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("telefonoAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("mailAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("contactoAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("estadoAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("observacionAgencia").Header.Caption = "Observación"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDisplayedColumnsAvion()
        Try
            ugdAgentes.DisplayLayout.Bands(0).Columns("idAvion").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("idAgencia").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("descripcionAgencia").Header.Caption = "Agencia"
            ugdAgentes.DisplayLayout.Bands(0).Columns("descripcionAvion").Header.Caption = "Descripcion"
            ugdAgentes.DisplayLayout.Bands(0).Columns("modeloAvion").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("descripcion").Header.Caption = "Tipo"
            ugdAgentes.DisplayLayout.Bands(0).Columns("pesoMaximoAvion").Hidden = True
            ugdAgentes.DisplayLayout.Bands(0).Columns("matriculaAvion").Header.Caption = "Matricula"
            ugdAgentes.DisplayLayout.Bands(0).Columns("estadoAvion").Hidden = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ugdAgentes_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugdAgentes.DoubleClickRow
        Try
            If Id = AgenciaAerolinea Or Id = AgenciaAerolineaEX Then
                Avion.Id = ugdAgentes.ActiveRow.Cells("idAvion").Value
                Avion.IdAgencia = ugdAgentes.ActiveRow.Cells("idAgencia").Value
                Avion.Descripcion = ugdAgentes.ActiveRow.Cells("descripcionAvion").Value
                Avion.Modelo = ugdAgentes.ActiveRow.Cells("modeloAvion").Value
                Avion.Tipo = ugdAgentes.ActiveRow.Cells("descripcion").Value
                Avion.PesoMax = ugdAgentes.ActiveRow.Cells("pesoMaximoAvion").Value
                Avion.Matricula = ugdAgentes.ActiveRow.Cells("matriculaAvion").Value
                Avion.estado = ugdAgentes.ActiveRow.Cells("estadoAvion").Value
                tempDesc = ugdAgentes.ActiveRow.Cells("descripcionAgencia").Value
                tempId = uceAgencia.Value
            ElseIf Id = AgenciaTransporte Then
                Dim r As DataRow
                r = dtATransporte.NewRow
                r.Item("idAgencia") = ugdAgentes.ActiveRow.Cells("idAgencia").Value
                r.Item("tipoAgencia") = ugdAgentes.ActiveRow.Cells("tipoAgencia").Value
                r.Item("descripcionAgencia") = ugdAgentes.ActiveRow.Cells("descripcionAgencia").Value
                r.Item("direccionAgencia") = ugdAgentes.ActiveRow.Cells("direccionAgencia").Value
                r.Item("telefonoAgencia") = ugdAgentes.ActiveRow.Cells("telefonoAgencia").Value
                r.Item("mailAgencia") = ugdAgentes.ActiveRow.Cells("mailAgencia").Value
                r.Item("contactoAgencia") = ugdAgentes.ActiveRow.Cells("contactoAgencia").Value
                r.Item("estadoAgencia") = ugdAgentes.ActiveRow.Cells("estadoAgencia").Value
                r.Item("observacionAgencia") = ugdAgentes.ActiveRow.Cells("observacionAgencia").Value
                dtATransporte.Rows.Add(r)
            End If
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmConsultaAgencia_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dtATransporte.Columns
            .Add("idAgencia", GetType(String))
            .Add("tipoAgencia", GetType(String))
            .Add("descripcionAgencia", GetType(String))
            .Add("direccionAgencia", GetType(String))
            .Add("telefonoAgencia", GetType(String))
            .Add("mailAgencia", GetType(String))
            .Add("contactoAgencia", GetType(String))
            .Add("estadoAgencia", GetType(String))
            .Add("observacionAgencia", GetType(String))
        End With
    End Sub
End Class