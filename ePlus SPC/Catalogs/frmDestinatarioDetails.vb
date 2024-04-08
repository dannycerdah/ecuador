Imports SPC.Server.ReportService
Public Class frmDestinatarioDetails
    Private Property IsNewDestinatario As Boolean = False
    Private Property destIdReporte As Integer
    Private Property destIdAgencia As Guid
    Private Sub InitializeValues()

    End Sub

    Public Sub New(ByVal myDestinatarioItem As DestinatarioCatalog)
        InitializeComponent()
        InitializeValues()
    End Sub

    Public Sub New(MustCreateNewDestinatario As Boolean)
        InitializeComponent()
        InitializeValues()
        PopulateAgencia()
        IsNewDestinatario = True
        uceReporte.SelectedIndex = 0
    End Sub

    Public Sub New(ByVal destinatarioIdReporte As Integer, ByVal destinatarioIdAgencia As Guid)
        InitializeComponent()
        InitializeValues()
        'ugdDestinatarios.DataSource = CommonData.GetDestinatariosbyIdReporteyAgencia(destinatarioIdReporte, destinatarioIdAgencia)
        destIdReporte = destinatarioIdReporte
        destIdAgencia = destinatarioIdAgencia
        RefreshData()
    End Sub

    Private Sub frmDestinatarioDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillDestinatarioInfo()
    End Sub

    Private Sub FillDestinatarioInfo()
        uceReporte.Items.Add(0, "Escoja una Opcion")
        For Each r As DataRow In CommonData.GetResportes().Rows
            uceReporte.Items.Add(r.Item("idReporte"), r.Item("nombreReporte"))
        Next
        uceReporte.SelectedIndex = 0
        Dim isSelectedContacto As Boolean = False
        If Not IsNewDestinatario Then
            'EDWIN LOPEZ 09/08/2016
            uceReporte.SelectedIndex = 0
            For i As Integer = 0 To uceReporte.Items.Count - 1
                uceReporte.SelectedIndex = i
                If uceReporte.Value = destIdReporte Then
                    Exit For
                End If
            Next

            PopulateAgencia()
            For i As Integer = 0 To uceAgencia.Items.Count - 1
                uceAgencia.SelectedIndex = i
                If uceAgencia.Value = destIdAgencia Then
                    Exit For
                End If
            Next
        Else
            uceAgencia.Enabled = True
            uceReporte.Enabled = True
        End If
    End Sub

    Private Sub PopulateAgencia()
        uceAgencia.Items.Clear()
        uceAgencia.Items.Add(Guid.Empty, "Escoja una Opción")
        For Each r As DataRow In CommonData.GetAgencia().Rows
            uceAgencia.Items.Add(r.Item("idAgencia"), r.Item("descripcionAgencia"))
        Next
        uceAgencia().SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Function validaNuevoDestinatario() As Boolean
        If uceAgencia.SelectedIndex > 0 And Not (uceReporte.Text.Trim) = "" Then
            Return True
        Else
            MessageBox.Show("Ingrese por favor Agencia y Reporte", "ePlus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
    End Function

    Private Sub ugdDestinatarios_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugdDestinatarios.DoubleClickCell
        If Not ugdDestinatarios.ActiveRow.Cells("descripcionAgencia").Value.ToString = String.Empty Then
            ShowTiposContactoDetails(ugdDestinatarios.ActiveRow.Cells("idDestinatario").Value)
        Else
            If validaNuevoDestinatario() Then
                newAgenciaDestinatario()
            End If
        End If
        RefreshData()
    End Sub
    Public Sub RefreshData()
        ugdDestinatarios.DataSource = CommonData.GetDestinatariosbyIdReporteyAgencia(destIdReporte, destIdAgencia)
        'dest = CommonData.GetDestinatariosPorIdReporte(6)
        SetDisplayedColumns()
    End Sub
    Private Sub ShowTiposContactoDetails(idD As Guid)
        Using frmDetails As New frmDestinatarioContacts(idD)
            frmDetails.ShowDialog()
        End Using
    End Sub

    Private Sub SetDisplayedColumns()
        Try
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("idContacto").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("idReporte").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("idDestinatario").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("idagencia").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("descripcionagencia").Header.Caption = "Compañia"
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("primerNombreContacto").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("estado").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("primerApellidoContacto").Header.Caption = "Primer Apellido"
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("segundoApellidoContacto").Header.Caption = "Segundo Apellido"
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("descripcionReporte").Hidden = True
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("mail").Header.Caption = "Correo Electronico"
            ugdDestinatarios.DisplayLayout.Bands(0).Columns("segundoNombreContacto").Hidden = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ugdDestinatarios_DoubleClick(sender As Object, e As EventArgs) Handles ugdDestinatarios.DoubleClick
        If validaNuevoDestinatario() And uceAgencia.Enabled = True Then
            newAgenciaDestinatario()
        End If
    End Sub
    Private Sub newAgenciaDestinatario()
        destIdReporte = uceReporte.Value
        destIdAgencia = uceAgencia.Value
        Using frmDetails As New frmDestinatarioContacts(destIdAgencia, destIdReporte, True)
            frmDetails.ShowDialog()
        End Using
        uceAgencia.Enabled = False
        uceReporte.Enabled = False
        RefreshData()
    End Sub

End Class

