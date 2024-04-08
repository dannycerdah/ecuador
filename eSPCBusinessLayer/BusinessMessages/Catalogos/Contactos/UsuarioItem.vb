Public Class UsuarioItem
    Public Property idUsuario As String
    Public Property idContacto As String
    Public Property password As String
    Public Property estado As String
    Public Property admin As String
    Public Property idContactoCreacion As String
    Public Property fechaCreacion As DateTime
    Public Property fechaAct As DateTime
    Public Property perfilesUsuario As New List(Of PerfilesUsuarioItem)
    Public Property usuarioEmpresa As New List(Of UsuarioEmpresaItem)

End Class
