Imports SPC.Server.ReportService
Public Class frmTurnoDetalle
    Dim isNewTurno As Boolean = False
    Public Property myTurno As New TurnoItem

    Public Sub New(MustCreateNewTurno As Boolean)
        InitializeComponent()
        isNewTurno = MustCreateNewTurno
    End Sub
    Public Sub New(ByVal id As Guid)
        InitializeComponent()
        myTurno = CommonData.GetTurnoById(id)
    End Sub
    Private Sub FillDataTurno()
        Try
            txtTitle.Text = myTurno.title
            dtpAtraso.Text = myTurno.atraso
            dtpInicio.Text = myTurno.inicio
            dtpFin.Text = myTurno.fin
            If myTurno.estado = "A" Then
                uceEstado.SelectedIndex = 0
            Else
                uceEstado.SelectedIndex = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If validateData() Then
                SaveTurno()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save, Turno")
        End Try
    End Sub
    Private Function validateData() As Boolean
        Dim result As Boolean = False
        If txtTitle.Text.Trim = String.Empty Then
            MsgBox("Ingrese un título del horario")
        ElseIf dtpInicio.Value.TimeOfDay.ToString = "00:00" Or dtpFin.Value.TimeOfDay.ToString = "00:00" Then
            MessageBox.Show("Debe asignar hora de inicio y fin", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf uceEstado.Text.Trim = String.Empty Then
            MsgBox("Seleccione un estado")
        Else
            result = True
        End If
        Return result
    End Function

    Private Sub SaveTurno()
        Try
            Dim req As New ContactoRequest
            Dim res As New ContactoResponse
            Dim wsClnt As New ReportServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
            Dim msgc As String = "Registro actualizado con éxito"
            If isNewTurno Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
                myTurno.id = Guid.NewGuid
            End If
            myTurno.title = txtTitle.Text.Trim
            myTurno.atraso = dtpAtraso.Value.TimeOfDay.ToString("hh\:mm")
            myTurno.inicio = dtpInicio.Value.TimeOfDay.ToString("hh\:mm")
            myTurno.fin = dtpFin.Value.TimeOfDay.ToString("hh\:mm")
            myTurno.usuario = MyCurrentUser.userName
            myTurno.fecha = Date.Now
            myTurno.estado = uceEstado.Value
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myTurno = myTurno
                res = wsClnt.SaveTurnoItem(req)
            If res.ActionResult Then
                MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Throw New Exception(res.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save Data, Turno")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmTurnoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        If isNewTurno Then
            uceEstado.SelectedIndex = 0
        Else
            FillDataTurno()
        End If
    End Sub

    Private Sub dtpAtraso_ValueChanged(sender As Object, e As EventArgs) Handles dtpAtraso.ValueChanged

    End Sub
End Class