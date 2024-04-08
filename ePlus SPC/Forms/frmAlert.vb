Imports SPC.Server.UserService

Public Class frmAlert
    Property S_Mensaje As String
    Property S_ColorFondo As String
    Property B_Negrita As Boolean = False
    Property I_Tamaño As Integer
    Property B_MensajeSupervision As Boolean = False
    Property S_MensajeSupervision As String
    Dim resp As DialogResult = Windows.Forms.DialogResult.No
    Property C_Usuario As New UserClient

    Private Sub frmAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblMsj.Text = S_Mensaje
        LblMsj.Left = (Me.Width - LblMsj.Width) / 2
        LblMsj.Top = (Me.Height - LblMsj.Height) / 2
        If B_Negrita Then
            LblMsj.Font = New Font(LblMsj.Font.Name, I_Tamaño, FontStyle.Bold)
        Else
            LblMsj.Font = New Font(LblMsj.Font.Name, I_Tamaño)
        End If
        If S_ColorFondo = "Rojo" Then
            LblMsj.ForeColor = Color.Red
        End If
        pnlMain.BackColor = Color.Red
    End Sub

    Private Sub frmAlert_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If B_MensajeSupervision Then
            resp = MessageBox.Show(S_MensajeSupervision, "Solicitud de Clave", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resp = Windows.Forms.DialogResult.Yes Then
                Dim frmCheck As New frmCheckUserManager
                With frmCheck
                    .B_RegistraBita = True
                    .S_Proceso = C_Usuario.S_Proceso
                    .S_UsuarioProduc = C_Usuario.S_UsuarioProduc
                    .S_Observacion = C_Usuario.S_Observacion
                End With
                frmCheck.ShowDialog()
                B_MensajeSupervision = frmCheck.result
            End If

        End If
    End Sub
End Class