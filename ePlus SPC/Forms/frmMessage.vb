Imports SPC.Server.UserService

Public Class frmMessage

    Public Property HasToWait As Boolean
    Public Property MyAutorizacionOnline As AutorizacionOnline

    'Public Sub SetMessage(MyMessage As String)
    '    lblMessage.Text = MyMessage
    'End Sub

    Public Sub New(Message As String, caption As String, Optional MustWait As Boolean = False)
        InitializeComponent()
        Me.lblMessage.Text = Message
        Me.Text = caption
        HasToWait = MustWait
    End Sub

    Private Sub frmMessage_Load(sender As Object, e As EventArgs) Handles Me.Load
        If HasToWait Then
            tmrWait.Enabled = True
        End If
    End Sub

    Private Sub tmrWait_Tick(sender As Object, e As EventArgs) Handles tmrWait.Tick
        ConsultaEstadoAutorizacion()
    End Sub

    Private Sub ConsultaEstadoAutorizacion()
        Dim req As New AutorizacionesOnlineRequest
        Dim res As New AutorizacionesOnlineResponse
        Dim wsclient As New UserServiceSoapClient
        Try
            req.AutorizacionesOnline = New List(Of AutorizacionOnline)
            req.AutorizacionesOnline.Add(MyAutorizacionOnline)
            res = wsclient.GetAutorizacionesOnline(req)
            If res.ActionResult Then
                MyAutorizacionOnline = res.myAutorizacionesOnline(0)
                If MyAutorizacionOnline.EstadoAutorizacion = EstadoAprobacion.Aprobado Then
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ErrorManager.SetLogEvent(ex)
        End Try
    End Sub


End Class