Public Class Config
    
    Public Shared ReadOnly Property scPort As String
        Get
            Return My.Settings.ScalePort
        End Get
    End Property

    Public Shared ReadOnly Property scBaudRate As String
        Get
            Return My.Settings.ScaleBaudRate
        End Get
    End Property

    Public Shared ReadOnly Property scStopBits As String
        Get
            Return My.Settings.ScaleStopBits
        End Get
    End Property

    Public Shared ReadOnly Property scParity As String
        Get
            Return My.Settings.ScaleParity
        End Get
    End Property

    Public Shared ReadOnly Property scDataBits As String
        Get
            Return My.Settings.ScaleDataBits
        End Get
    End Property

    Public Shared ReadOnly Property scStringBeginChar As Integer
        Get
            Return My.Settings.ScaleStringBeginChr
        End Get
    End Property

    Public Shared ReadOnly Property scStringEndChar As Integer
        Get
            Return My.Settings.ScaleStringEndChr
        End Get
    End Property

    Public Shared ReadOnly Property scDivisor As Integer
        Get
            Return My.Settings.ScaleDivisor
        End Get
    End Property

    Public Shared ReadOnly Property IsUsingScale As Boolean
        Get
            Return My.Settings.UseScale
        End Get
    End Property

    'MARZ_02.10.17
    Public Shared ReadOnly Property correoHost As String
        Get
            Return My.Settings.hostCorreo
        End Get
    End Property

    Public Shared ReadOnly Property correoPuerto As Integer
        Get
            Return My.Settings.puertoCorreo
        End Get
    End Property

    Public Shared ReadOnly Property correoRemitente As String
        Get
            Return My.Settings.remitenteCorreo
        End Get
    End Property

    Public Shared ReadOnly Property correoClave As String
        Get
            Return My.Settings.claveCorreo
        End Get
    End Property

    Public Shared ReadOnly Property correoSSL As Boolean
        Get
            Return My.Settings.sslCorreo
        End Get
    End Property

    Public Shared ReadOnly Property SbuscarKg As Integer
        Get
            Return My.Settings.SbuscarKg
        End Get
    End Property

    Public Shared ReadOnly Property SCaracterBuscar As String
        Get
            Return My.Settings.SCaracterBuscar
        End Get
    End Property

    Public Shared ReadOnly Property SNumCadena As Integer
        Get
            Return My.Settings.SNumCadena
        End Get
    End Property

    Public Shared ReadOnly Property UsuarioCorreo As String
        Get
            Return My.Settings.UsuarioCorreo
        End Get
    End Property

    Public Shared Sub SetScaleSettings(Port As String, BaudRate As String, StopBits As String, Parity As String, _
                                     DataBits As String, CharIni As Integer, CharEnd As Integer, Divisor As Integer, Kg As Integer, CaracterBuscar As String, NumCadena As Integer)
        With My.Settings
            .UseScale = True
            .ScalePort = Port
            .ScaleBaudRate = BaudRate
            .ScaleStopBits = StopBits
            .ScaleParity = Parity
            .ScaleDataBits = DataBits
            .ScaleStringBeginChr = CharIni
            .ScaleStringEndChr = CharEnd
            .ScaleDivisor = Divisor
            .SbuscarKg = Kg
            .SCaracterBuscar = CaracterBuscar
            .SNumCadena = NumCadena
        End With
        My.Settings.Save()
    End Sub

    'MARZ_28.09.17
    Public Shared Sub SetScaleSettings(Host As String, Port As Integer, Remitente As String, Clave As String, SSL As Boolean)
        With My.Settings
            .hostCorreo = Host
            .puertoCorreo = Port
            .remitenteCorreo = Remitente
            .claveCorreo = Clave
            .sslCorreo = SSL
        End With
        My.Settings.Save()
    End Sub
    'ini jrodriguez sprint01 25/04/2025
    'Se crean propiedades que contienen los valores de configuración de la aplicación. Estas serán utilizadas para el envío de notificaciones,
    'asegurando que los parámetros adecuados estén disponibles y correctos para cada evento, mejorando la funcionalidad y la experiencia del usuario.
    Public Shared ReadOnly Property CuerpoNotificacionWH As String
        Get
            Return My.Settings.CuerpoMsjNotiWH
        End Get
    End Property
    Public Shared ReadOnly Property AsuntoNotificacionWH As String
        Get
            Return My.Settings.AsuntoNotiWH
        End Get
    End Property
    Public Shared ReadOnly Property MsjAlertaNotiEmailOk As String
        Get
            Return My.Settings.MsjAlertaNotiEmailOk
        End Get
    End Property
    Public Shared ReadOnly Property MsjAlertaNotiEmailError As String
        Get
            Return My.Settings.MsjAlertaNotiEmailError
        End Get
    End Property
    Public Shared ReadOnly Property RutaNotificacion As String
        Get
            Return My.Settings.RutaNotificacion
        End Get
    End Property
    'fin jrodriguez sprint01 25/04/2025
End Class