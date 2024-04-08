Public Class GenericResponse
    Private _ActionResult As Boolean
    Private _ErrorMessage As String
    Private _ErrorCode As Integer

    Public Property ErrorCode() As Integer
        Get
            Return _ErrorCode
        End Get
        Set(ByVal value As Integer)
            If _ErrorCode = Value Then
                Return
            End If
            _ErrorCode = Value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            If _ErrorMessage = value Then
                Return
            End If
            _ErrorMessage = value
        End Set
    End Property

    Public Property ActionResult() As Boolean
        Get
            Return _ActionResult
        End Get
        Set(ByVal value As Boolean)
            If _ActionResult = Value Then
                Return
            End If
            _ActionResult = Value
        End Set
    End Property


    Public Sub New()
        _ActionResult = True
        _ErrorMessage = String.Empty
        _ErrorCode = 0
    End Sub

End Class
