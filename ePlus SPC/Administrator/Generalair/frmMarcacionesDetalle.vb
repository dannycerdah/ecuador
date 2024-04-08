Imports SPC.Server.MarkingService
Public Class frmMarcacionesDetalle
    Public Property myMarkingGeneral As New MarkingGeneralItem
    Dim iden As Integer
    Dim nombres As String
    Dim timeInicio As String
    Dim timeFinal As String
    Dim mensaje As String

    Public Sub New(ByVal id As String, ByVal empleado As String, ByVal inicio As String, ByVal final As String, ByVal observation As String)
        InitializeComponent()
        iden = CInt(id)
        nombres = empleado
        timeInicio = inicio
        timeFinal = final
        mensaje = observation
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dtpSalida.Value <= dtpIngreso.Value Then
            MessageBox.Show("Salida no puede ser menor a ingreso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            UpdateMarkingGeneral()
        End If
    End Sub

    Private Sub UpdateMarkingGeneral()
        Try
            Dim req As New MarkingGeneralRequest
            Dim res As New MarkingGeneralResponse
            Dim wsClnt As New MarkingServiceSoapClient
            Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
            Dim msgc As String = "Registro actualizado con éxito"
            myMarkingGeneral.id = iden
            myMarkingGeneral.salida = dtpSalida.Value
            myMarkingGeneral.observation = txtObservation.Text
            General.SetBARequest(req)
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                req.myMarkingGeneral = myMarkingGeneral
                res = wsClnt.UpdateMarkingGeneralair(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            General.SetLogEvent(ex, "Save Data, Marking")
        End Try
    End Sub

    Sub FillData()
        txtEmpleado.Text = nombres
        dtpIngreso.Text = timeInicio
        If timeFinal = String.Empty Then
            dtpSalida.Value = DateTime.Now
        Else
            dtpSalida.Text = timeFinal
        End If
        txtObservation.Text = mensaje
    End Sub


    Private Sub frmMarcacionesDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillData()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class