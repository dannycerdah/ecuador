Public Class PermisoEspecialItem
    Public Property id As Guid
    Public Property description As String
    Public Property beginDate As Date
    Public Property endDate As Date
    Public Property beginTime As String
    Public Property endTime As String
    Public Property usuario As String
    Public Property fecha As DateTime
    Public Property observation As String
    Public Property estado As String
    Public Property permisosContacto As New List(Of PermisosContactoItem)
End Class
