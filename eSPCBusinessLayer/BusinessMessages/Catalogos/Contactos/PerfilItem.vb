Public Class PerfilItem

    Public Property idPerfil As Guid
    Public Property nombrePerfil As String
    Public Property comentarioPerfil As String
    Public Property estadoPerfil As String
    Public Property idUsuario As String
    Public Property fecha As DateTime
    Public Property padrePerfil As String
    Public Property permisosPerfil As New List(Of PermisosPerfilItem)
End Class
