Public Class ReportRequest
    Inherits GenericRequest

    Public cacId As Guid
    Public Property DateEnd As DateTime
    Public Property DateBegin As DateTime
    Public Property DocId As String
    Public Property CusId As Guid
    Public Property prmArr As String()
    Public Property prmInt As Integer

End Class
