Public Class DatosFichapersonal
    Public Property cedula As String
    Public Property nombres As String
    Public Property cargo As String
    Public Property tagsa As String
    Public Property fechaexpiracion As String
    Public Property direccion As String
    Public Property telefono As String
    Public Property foto As String

    Public Property accesos As Integer
    Public Property horasactividad As Integer
    Public Property horastrabajadas As Integer
    Public Property cantidadatrsados As Integer
    Public Property tiempototalatrasos As String
    Public Property horasactividad_proc As Integer
    Public Property ciudad As String

End Class

Public Class FichaProcesoCarga
    Public Property cedula As String
    Public Property aerolinea As String
    Public Property vuelo As String
    Public Property muelle As String
    Public Property desde As String
    Public Property hasta As String
    Public Property totalactividad As String
    Public Property totalactividadmin As Integer
    'datos  proceso
    Public Property procfecha As String
    Public Property procdesde As String
    Public Property prochasta As String
    Public Property proctotalactividad As String
    Public Property proctotalactividadmin As Integer

End Class

Public Class FichaMarcaciones
    Public Property cedula As String
    Public Property fecha As String
    Public Property horaingreso As String
    Public Property horasalida As String
    Public Property totalhorastrab As String
    Public Property indatrasos As String
    Public Property totalhorastrabmin As Integer
    Public Property fechainicioJornada As String
    Public Property fechafinalJornada As String
End Class


Public Class FichaMarcacionesAtarasos
    Public Property cedula As String
    Public Property fecha As String
    Public Property fechainicioJornada As String
    Public Property fechafinalJornada As String
    Public Property horaingreso As String
    Public Property horasalida As String
    Public Property totalatraso As String
    Public Property totalatrasomin As Integer
End Class



