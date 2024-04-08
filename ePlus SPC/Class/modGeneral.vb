Imports System.IO
Imports System.Xml

Module modGeneral
    Public MyCurrentUser As New UserClient

    <STAThread()> _
    Sub Main()
        Dim LoginFrm As New frmLogin
        LoginFrm.ShowDialog()
        If LoginFrm.Retorno = False Then
            End
        End If
        Dim frm1 As frmMainSpc
        frm1 = New frmMainSpc
        Application.Run(frm1)

    End Sub
End Module
