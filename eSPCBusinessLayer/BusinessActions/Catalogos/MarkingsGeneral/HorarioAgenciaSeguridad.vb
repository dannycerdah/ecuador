Public Class HorarioAgenciaSeguridad
    Public Property idHorarioAgenciaSeguridad As Integer
    Public Property idBriefing As Guid = Guid.Empty
    Public Property idAgencia As Guid = Guid.Empty
    Public Property idContacto As String
    Public Property FechaInicio As Date
    Public Property FechaFin As Date
    Public Property Estado As String
    Public Property FechaIngreso As Date
    Public Property UsuarioIngreso As String
    Public Property FechaActualizacion As Date
    Public Property UsuarioActualizacion As String
End Class
