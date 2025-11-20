Public Class BitacoraNovedadVueloResponse
    Inherits GenericResponse
    Public Property dsResult As New DataSet
    Sub New()
        _dsResult = New DataSet
    End Sub
End Class
