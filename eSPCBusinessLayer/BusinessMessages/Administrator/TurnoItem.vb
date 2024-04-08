Public Class TurnoItem
    Public Property id As Guid
    Public Property title As String
    Public Property atraso As String
    Public Property inicio As String
    Public Property fin As String
    Public Property usuario As String
    Public Property fecha As DateTime
    Public Property estado As String
    Public Property daysTurnoContacto As New List(Of DaysTurnosContactoItem)
End Class
