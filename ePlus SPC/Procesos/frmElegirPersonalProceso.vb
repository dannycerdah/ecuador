Imports SPC.Server.ReportService
Public Class frmElegirPersonalProceso
    Public Property dtPersonal As New DataTable("Personal")
    Public Property tempGuiaItem As New Server.VuelosService.GuiaItem
    Public Property idAerolinea As Guid = Guid.Empty
    Public Property idAgenciaSeguridad As Guid = Guid.Empty
    Public Property personaAgenciaCarga As New ContactoCatalogItem
    Public Property personaSeguridad As New ContactoCatalogItem
    Public Property personaAerolinea As New ContactoCatalogItem
    Public Property agenciaSeguridad As String = String.Empty
    Public Property isCancel As Boolean = False
    Public Property isSaved As Boolean = False

    Private Sub PopulateAgenciaCarga()
        Try
            ucePersonalAgenciaCarga.Items.Clear()
            For Each r As DataRow In dtPersonal.Rows
                If r.Item("descripcionAgencia") = tempGuiaItem.DescripcionAgencia Then
                    Dim tempPersonalAgenciaCarga As New ContactoCatalogItem
                    tempPersonalAgenciaCarga = CommonData.GetContactoItem(r.Item("idPersona"))
                    ucePersonalAgenciaCarga.Items.Add(tempPersonalAgenciaCarga.idContacto, tempPersonalAgenciaCarga.primerApellido + " " + tempPersonalAgenciaCarga.primerNombre)
                End If
            Next
            ucePersonalAgenciaCarga.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateAerolienea()
        Try
            ucePersonalAerolinea.Items.Clear()
            For Each r As DataRow In dtPersonal.Rows
                If r.Item("descripcionAgencia") = CommonData.GetAgenciaItem(idAerolinea).Descripcion Then
                    Dim tempPersonalAerolinea As New ContactoCatalogItem
                    tempPersonalAerolinea = CommonData.GetContactoItem(r.Item("idPersona"))
                    ucePersonalAerolinea.Items.Add(tempPersonalAerolinea.idContacto, tempPersonalAerolinea.primerApellido + " " + tempPersonalAerolinea.primerNombre)
                End If
            Next
            ucePersonalAerolinea().SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            isCancel = True
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub SaveChanges()
        Try
            personaAerolinea = CommonData.GetContactoItem(ucePersonalAerolinea.Value)
            personaAgenciaCarga = CommonData.GetContactoItem(ucePersonalAgenciaCarga.Value)
            Try
                personaSeguridad = CommonData.GetContactoItem(uceSeguridad.Value)
                agenciaSeguridad = CommonData.GetAgenciaItem(Guid.Parse(agenciaSeguridad)).Descripcion
            Catch ex As Exception
            End Try
            isSaved = True
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmElegirPersonalProceso_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateAerolienea()
        PopulateAgenciaCarga()
        PopulateSeguridad()
    End Sub

    Private Sub PopulateSeguridad()
        Try
            uceSeguridad.Items.Clear()
            For Each r As DataRow In dtPersonal.Rows
                If r.Item("descripcionTipo") = "SEGURIDAD" Then
                    Dim tempPersonalSeguridad As New ContactoCatalogItem
                    tempPersonalSeguridad = CommonData.GetContactoItem(r.Item("idPersona"))
                    uceSeguridad.Items.Add(tempPersonalSeguridad.idContacto, tempPersonalSeguridad.primerApellido + " " + tempPersonalSeguridad.primerNombre)
                    agenciaSeguridad = r.Item("idAgencia").ToString
                End If
            Next
            uceSeguridad.SelectedIndex = 0
        Catch ex As Exception
            General.SetLogEvent(ex)
            MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

