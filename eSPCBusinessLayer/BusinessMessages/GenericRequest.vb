Public Class GenericRequest

    Public Enum ManagementActions
        [NOTHING] = 0
        [INSERT] = 1
        [UPDATE] = 2
        [DELETE] = 3
        [QUERY] = 4
        [REPLICATED] = 5
        [REFRESH] = 6
        [EXPORT] = 7
        [SEARCH] = 8
        [PRINT] = 9
    End Enum


    Public Property IpAddress As String
    Public Property TerminalId As String
    Public Property ActionKey As String
    Public Property InterfaceId As String
    Public Property RequestDate As DateTime
    Public Property PcId As String
    Public Property UserId As String
    Public Property myManagementAction As ManagementActions
    Public Property SessionKey As Guid
    Public Property id As Guid
    Public Property fechaIni As Date
    Public Property fechaFin As Date
    Public Property codigoVuelo As String

    Public Function GetAdditionalInfo() As String
        Dim errorString As String = ""
        errorString += "    PC_ID : " & PcId & vbCrLf
        errorString += "    Action Key :" & ActionKey & vbCrLf
        errorString += "    Request Date:" & RequestDate & vbCrLf
        errorString += "    IPAdress :" & IpAddress
        errorString += "    User Id :" & UserId
        Return errorString
    End Function

End Class
