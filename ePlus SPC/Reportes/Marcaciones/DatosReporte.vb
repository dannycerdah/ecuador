Public Class DatosReporte
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _Usuario As String

    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaFin As Date
        Get
            Return _FechaFin
        End Get
        Set(value As Date)
            _FechaFin = value
        End Set
    End Property
    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property
End Class
