Public Class UserClient
    Public Property userId As String = String.Empty
    Public Property userName As String = String.Empty
    Public Property isAdministrador As Boolean = False
    Public Property permisosUsuario As New List(Of String) 'MARZ
    Public Property S_Proceso As String
    Public Property S_UsuarioProduc As String
    Public Property S_Observacion As String
End Class
