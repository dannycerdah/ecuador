Imports System.Net
Imports System.Xml
Imports Microsoft.Web.Services3
Imports SPC.ISenae
Imports System.IO
Imports System.Xml.Serialization
Imports System.Text
Imports System.Runtime.Serialization
Imports SPC.Server.ReportService

Public Class MessagesManager
    Private Shared Function CallWebService(ByVal WebserviceURL As String, ByVal SOAP As String, Optional ByVal SoapAction As String = "") As XmlDocument
        Dim retXMLDoc As New XmlDocument()
        Try
            Using wc As New WebClient()
                'Header HTTP
                wc.Headers.Add("Content-Type", "application/soap+xml; charset=utf-8")
                If SoapAction <> String.Empty Then wc.Headers.Add("SOAPAction", SoapAction)
                retXMLDoc.LoadXml(wc.UploadString(WebserviceURL, SOAP))
            End Using
        Catch ex As Exception
            Dim rutaejecutable As String = Application.StartupPath
            If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
                FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
            End If
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        End Try
        Return retXMLDoc
    End Function


#Region "IIE"


    Public Shared Function SendIIEDoc(DAE As String, Piezas As Integer, Peso As Double, Producto As String, sec As Integer, isIIE As Boolean, NumRem As String) As String
        Dim Result As String = String.Empty
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        Try
            If DAE = String.Empty Then
                MessageBox.Show("Error: El campo DAE es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & "Error: El campo DAE es obligatorio" & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
                FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & "Error: El campo DAE es obligatorio" & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
                Return Result
                Exit Function
            End If
            Result = ExecuteIIE(BuildSoap(DAE, Piezas, Peso, Producto, sec, isIIE, NumRem), sec)
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        End Try
        Return Result
    End Function

    Private Shared Function BuildSoap(DAE As String, Piezas As Integer, Peso As Double, Producto As String, secuencial As Integer, isIIE As Boolean, NumRem As String) As String
        Dim xml As String = String.Empty
        Dim Anio, Sec, ID As String
        DAE = DAE.Trim
        Producto = Producto.Trim
        Anio = Date.Now.Year
        'Sec = My.Settings.Secuential + 1
        Sec = secuencial
        Sec = Sec.PadLeft(8, "0")
        ID = "29000001" & Anio & Sec & "S"

        Dim env As New SoapEnvelope()
        Dim myHeader As New Header
        Dim eDoc As New DocumentMetadata
        Dim myDeclaration As New Declaration
        Dim myConsigment As New Consignment
        Dim myConsigmentItem As New ConsignmentItem
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If

        With myConsigmentItem
            .TransportEquipment = New TransportEquipment() With {.SequenceNumeric = 1}
            .Commodity = New Commodity() With {.Name = Producto, .CountQuantity = Piezas, .SizeMeasure = Peso}
            .Packaging = New Packaging() With {.TypeCode = "035"}
            .RemNumberID = NumRem
        End With

        With myConsigment
            .TransactionDateTime = Date.UtcNow.ToString("yyyy-MM-dd") & "T" & Date.UtcNow.ToString("HH:mm:ss") & "Z"
            If DAE = String.Empty Then
                MessageBox.Show("Error: El campo DAE es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & "Error: El campo DAE es obligatorio" & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
                FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & "Error: El campo DAE es obligatorio" & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
                Return xml
                Exit Function
            Else
                .CarryInBaseNumberID = DAE
            End If
            .TransportContractDocument = New TransportContractDocument() With {.TypeCode = "D"}
            .ConsignmentItem = myConsigmentItem
        End With

        With myDeclaration
            .ID = ID
            If isIIE Then
                .TypeCode = "031"
            Else
                .TypeCode = "032"
            End If
            .IssueDateTime = Date.UtcNow.ToString("yyyy-MM-dd") & "T" & Date.UtcNow.ToString("HH:mm:ss") & "Z"
            .DeclarationOfficeID = "019"
            .VersionID = "1.0"
            .Agent = New Agent() With {.ID = "29000001"}
            .BorderTransportMeans = New BorderTransportMeans
            .Consignment = myConsigment
        End With

        With eDoc
            .Declaration = myDeclaration
        End With


        Try

            With myHeader
                .DclrCd = "29000001"
                .DclrRuc = "1791409981001"
                .DclrSeCd = "01"
                .DclrSeId = "29000001"
                .DocPrcsType = "O"
                .RcsdEdocAfrCd = "004"
                .RcsdEdocAfrId = "002"
                .RcsdEdocTypeCd = "031"
                .SmtNo = ID
                .UserId = "VALERIAROSERO"
            End With

            Dim msgHeader As System.Runtime.Remoting.Messaging.Header
            msgHeader = New Runtime.Remoting.Messaging.Header("ns0", myHeader, False, "ns0")



            Dim soaSerializer As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter()
            Dim memStream As MemoryStream
            memStream = New MemoryStream()

            Dim memStreamXml As MemoryStream
            memStreamXml = New MemoryStream()
            Dim x As New XmlSerializer(eDoc.GetType)
            Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces()
            ns.Add("", "urn:wco:datamodel:EC:IM:1:0:0")
            x.Serialize(memStreamXml, eDoc, ns)
            memStreamXml.Close()
            Dim xmlArg0 As String
            xmlArg0 = Encoding.UTF8.GetString(memStreamXml.GetBuffer())
            xmlArg0 = xmlArg0.Substring(xmlArg0.IndexOf(Convert.ToChar(60)))
            xmlArg0 = xmlArg0.Substring(0, (xmlArg0.LastIndexOf(Convert.ToChar(62)) + 1))
            xmlArg0 = xmlArg0.Remove(0, 22) '<?xml version="1.0"?>
            Dim strMetadata As String
            strMetadata = "<DocumentMetadata xsi:schemaLocation=" & Chr(34) & "urn:wco:datamodel:EC:IIE:1:0:0 EC_IIE_0p1.03.xsd" & Chr(34) & " xmlns=" & Chr(34) & "urn:wco:datamodel:EC:IIE:1:0:0" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & "> "
            xmlArg0 = xmlArg0.Replace("<DocumentMetadata>", strMetadata)

            Dim objSendExportCargaIIE As New sendExportCargaIIE 'With {.arg0 = xmlArg0}
            soaSerializer.TypeFormat = Formatters.FormatterTypeStyle.XsdString

            soaSerializer.Serialize(memStream, objSendExportCargaIIE, New System.Runtime.Remoting.Messaging.Header() {msgHeader})
            'soaSerializer.Serialize(memStream, objSendExportCargaIIE) ', New System.Runtime.Remoting.Messaging.Header() {msgHeader})


            memStream.Close()
            xml = Encoding.UTF8.GetString(memStream.GetBuffer())
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)))
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1))


            xml = xml.Replace("<_", "<")
            xml = xml.Replace("</_", "</")
            xml = xml.Remove(386, 57)
            xml = xml.Replace("a1:Header", "ns0:Header")
            xml = xml.Replace("xmlns:a1", "xmlns:ns0")
            'xml = xml.Replace("http://schemas.microsoft.com/clr/nsassem/eSPC/ePlus%20SPC%2C%20Version%3D1.0.0.376%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Dnull", "http://soapinterop.org/xsd")
            xml = xml.Replace("http://schemas.microsoft.com/clr/nsassem/SPC/SPC%2C%20Version%3D1.0.0.376%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Dnull", "http://soapinterop.org/xsd")
            xml = xml.Replace("DclrCd", "ns0:DclrCd")
            xml = xml.Replace("DclrRuc", "ns0:DclrRuc")
            xml = xml.Replace("DclrSeCd", "ns0:DclrSeCd")
            xml = xml.Replace("DclrSeId", "ns0:DclrSeId")
            xml = xml.Replace("DocPrcsType", "ns0:DocPrcsType")
            xml = xml.Replace("RcsdEdocAfrCd", "ns0:RcsdEdocAfrCd")
            xml = xml.Replace("RcsdEdocAfrId", "ns0:RcsdEdocAfrId")
            xml = xml.Replace("RcsdEdocTypeCd", "ns0:RcsdEdocTypeCd")
            xml = xml.Replace("SmtNo", "ns0:SmtNo")
            xml = xml.Replace("UserId", "ns0:UserId")
            xml = xml.Replace("a1:", "tns:")
            xml = xml.Replace("id=" & Chr(34) & "ref-1" & Chr(34) & " xmlns:ns0=" & Chr(34) & "http://soapinterop.org/xsd", "xmlns:tns=" & Chr(34) & "http://webservice.ecg.ecuapass.aduana.gob.ec/")
            If isIIE Then
                xml = xml.Replace("/a1:sendExportCargaIIE", "/tns:sendExportCargaIIE")
            Else
                xml = xml.Replace("/a1:sendExportCargaIIE", "/tns:sendExportCargaISE")
            End If
            xml = xml.Replace("<arg0 xsi:null=" & Chr(34) & "1" & Chr(34) & "/>", "<arg0><![CDATA[" & xmlArg0 & "]]></arg0>")
            xml = xml.Replace(" id=" & Chr(34) & "ref-3" & Chr(34), "")
            Dim soap1, soap2 As String
            soap1 = "<SOAP-ENV:Envelope xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:SOAP-ENC=" & Chr(34) & "http://schemas.xmlsoap.org/soap/encoding/" & Chr(34) & " xmlns:SOAP-ENV=" & Chr(34) & "http://schemas.xmlsoap.org/soap/envelope/" & Chr(34) & " xmlns:clr=" & Chr(34) & "http://schemas.microsoft.com/soap/encoding/clr/1.0" & Chr(34) & " SOAP-ENV:encodingStyle=" & Chr(34) & "http://schemas.xmlsoap.org/soap/encoding/" & Chr(34) & ">"
            soap2 = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=" & Chr(34) & "http://schemas.xmlsoap.org/soap/envelope/" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & ">"
            xml = xml.Replace(soap1, soap2)
            xml = xml.Replace(" />", "/>")
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        Finally
            My.Settings.Secuential = My.Settings.Secuential + 1
            My.Settings.Save()
        End Try
        Return xml
    End Function

    Private Shared Function ExecuteIIE(xml As String, secuencial As Integer) As String
        Dim result As String = String.Empty
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml\IIE") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml\IIE")
        End If
        Try
            Dim objRes As XmlDocument
            Dim ID, Anio, Sec As String
            Anio = Date.Now.Year
            Sec = secuencial 'My.Settings.Secuential
            Sec = Sec.PadLeft(8, "0")
            ID = "29000001" & Anio & Sec & "S"
            'FileIO.FileSystem.WriteAllText("C:\xml\IIE\REQ" & ID & ".xml", xml, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\IIE\REQ" & ID & ".xml", xml, True)
            objRes = CallWebService("http://cdes.aduana.gob.ec/cdes_svr/SENAE_ExportCargaService?wsdl", xml)
            'objRes.Save("C:\xml\IIE\RES" & ID & ".xml")
            objRes.Save(rutaejecutable & "\xml\IIE\RES" & ID & ".xml")
            result = ID & ControlChars.CrLf & ControlChars.CrLf & objRes.InnerXml
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        End Try
        Return result
    End Function

#End Region

#Region "DAE_SRCHEX"

    Public Shared Function SearchDAE(StartDate As Date, EndDate As Date) As DataTable
        Return BulkSearchDAE(StartDate, EndDate, String.Empty)
    End Function

    Public Shared Function SearchDAE(DAE As String) As DataTable
        Return BulkSearchDAE(Date.Now, Date.Now, DAE)
    End Function
    Public Shared Function SearchDAE(DAE As String, StartDate As Date) As DataTable
        Return BulkSearchDAE(StartDate, Date.Now, DAE)
    End Function
    Private Shared Function BulkSearchDAE(StartDate As Date, EndDate As Date, DAE As String) As DataTable
        Dim xml As String = String.Empty
        Dim result As New DataTable
        'MARZ - 02-08-2017
        Dim dataEcuapass() As String = Ecuapass.getDataEcuapass() 'MARZ
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        Try
            If DateDiff(DateInterval.Day, StartDate, EndDate) > 14 Then
                Throw New Exception("Rango de Fechas muy amplio, por favor reduzca su búsqueda")
            End If
            xml = My.Settings.SRCHEX_req 'Cabecera de seguridad
            'MARZ
            xml = xml.Replace("usuarioEcuapass", dataEcuapass(0))
            xml = xml.Replace("claveEcuapass", dataEcuapass(1))
            xml = xml.Replace("keyEcuapass", dataEcuapass(2))
            'MARZ - End
            If DAE = String.Empty Then
                xml = xml.Replace("2015-02-01", StartDate.ToString("yyyy-MM-dd"))
                xml = xml.Replace("2015-02-15", EndDate.ToString("yyyy-MM-dd"))
                xml = xml.Replace("DeclarationOfficeID&gt;028&lt;/DeclarationOfficeID", "DeclarationOfficeID&gt;019&lt;/DeclarationOfficeID")
            Else
                xml = xml.Replace("DeclarationNumberID&gt;&lt;/", "DeclarationNumberID&gt;" & DAE & "&lt;/")
                xml = xml.Replace("DeclarationOfficeID&gt;028&lt;/DeclarationOfficeID", "DeclarationOfficeID&gt;&lt;/DeclarationOfficeID")
                xml = xml.Replace("2015-02-01", StartDate.AddDays(-40).ToString("yyyy-MM-dd"))
                xml = xml.Replace("2015-02-15", EndDate.ToString("yyyy-MM-dd"))
                xml = xml.Replace("&lt;ConsultTypeID&gt;02&lt;/ConsultTypeID&gt;", "&lt;ConsultTypeID&gt;03&lt;/ConsultTypeID&gt;")
            End If
            result = SRCHEX(xml)
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            Throw ex
        End Try
        Return result
    End Function

    Private Shared Function SRCHEX(xml As String) As DataTable
        Dim newRes As New DataTable("BulkDAE")
        Dim objRes As XmlDocument
        Dim newRow As DataRow
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml\DAE\REQ") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml\DAE\REQ")
        End If
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml\DAE\RES") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml\DAE\RES")
        End If
        Try
            Dim ID As String = Date.Now.Ticks
            'FileIO.FileSystem.WriteAllText("C:\xml\DAE\REQ" & ID & ".xml", xml, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\DAE\REQ" & ID & ".xml", xml, True)
            objRes = CallWebService("http://cdes.aduana.gob.ec/cdes_svr/SENAE_ExportDespachoService_EC?wsdl", xml, "requestExportDespachoSRCHEX") 'MARZ
            'objRes.Save("C:\xml\DAE\RES" & ID & ".xml")
            objRes.Save(rutaejecutable & "\xml\DAE\RES" & ID & ".xml")

            With newRes
                .Columns.Add("DeclarationNumber", GetType(String))
                .Columns.Add("exporterDocumentId", GetType(String))
                .Columns.Add("exporterName", GetType(String))
                .Columns.Add("declarationOffice", GetType(String))
                .Columns.Add("declaration_Id", GetType(String))
                .Columns.Add("examinerName", GetType(String))
                .Columns.Add("EffectiveEndDate", GetType(Date))
                .Columns.Add("RemNumber", GetType(String))
                .Columns.Add("RemRucAgency", GetType(String))
                .Columns.Add("RemEndVigency", GetType(String))
                .Columns.Add("response_Id", GetType(String))
                .Columns.Add("examinationChannelName", GetType(String))
            End With

            Dim ds As New DataSet
            Dim xReader As XmlReader = New XmlNodeReader(objRes)
            ds.ReadXml(xReader)

            Dim query =
            From a In ds.Tables("Declaration").AsEnumerable
            Join b In ds.Tables("ExaminationChannel").AsEnumerable
            On a.Field(Of Integer)("Declaration_Id") Equals b.Field(Of Integer)("Declaration_Id")
            Select a, b
            Dim rows As DataRow()
            Dim strDate As String = String.Empty
            Dim strD() As String
            For Each obj In query
                newRow = newRes.NewRow()
                newRow.Item("DeclarationNumber") = obj.a.Item("DeclarationNumber")
                newRow.Item("exporterDocumentId") = obj.a.Item("exporterDocumentId")
                newRow.Item("exporterName") = obj.a.Item("exporterName")
                newRow.Item("declarationOffice") = obj.a.Item("declarationOffice")
                newRow.Item("declaration_Id") = obj.a.Item("declaration_Id")
                newRow.Item("examinerName") = obj.a.Item("examinerName")
                strDate = obj.a.Item("EffectiveEndDate").ToString
                strD = Split(strDate, "/")
                strDate = strD(1) & "/" & strD(0) & "/" & strD(2)
                newRow.Item("EffectiveEndDate") = strDate 'obj.a.Item("EffectiveEndDate")
                newRow.Item("response_Id") = 0
                newRow.Item("examinationChannelName") = obj.b.Item("examinationChannelName")
                If Not IsNothing(ds.Tables("RemInfoDetail")) Then
                    rows = ds.Tables("RemInfoDetail").Select("Declaration_Id = " & obj.a.Item("Declaration_Id") & "")
                    If rows.Count > 0 Then
                        For Each r As DataRow In rows
                            newRow.Item("RemNumber") = r.Item(0)
                            newRow.Item("RemRucAgency") = r.Item(1)
                            newRow.Item("RemEndVigency") = r.Item(2)
                        Next
                    End If
                End If
                newRes.Rows.Add(newRow)
            Next

        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        End Try

        Return newRes
    End Function
#End Region

    Public Shared Function QueryDocStatus(eDocId As String, SubmitDate As Date) As String
        Dim result As String = String.Empty
        Dim xml As String = My.Settings.CommonResponseList_req 'Cabecera de seguridad
        Dim dtReference As New DataTable("dtReference")
        Dim xRes As New XmlDocument
        Dim dsRes As New DataSet
        Dim dclrResponse As DeclarationResponse
        'MARZ - 02-08-2017
        Dim dataEcuapass() As String = Ecuapass.getDataEcuapass() 'MARZ - Cambios a partir del 6 de Septiembre
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml\QRY") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml\QRY")
        End If
        Try
            'MARZ
            xml = xml.Replace("usuarioEcuapass", dataEcuapass(0))
            xml = xml.Replace("claveEcuapass", dataEcuapass(1))
            xml = xml.Replace("keyEcuapass", dataEcuapass(2))
            'MARZ - End
            xml = xml.Replace("2015-02-24 09:37:00", Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            xml = xml.Replace("<EffectiveDateTime>2015-02-23</EffectiveDateTime>", "<EffectiveDateTime>" & SubmitDate.ToString("yyyy-MM-dd") & "</EffectiveDateTime>")
            xml = xml.Replace("<ReleaseDateTime>2015-02-23</ReleaseDateTime>", "<ReleaseDateTime>" & SubmitDate.ToString("yyyy-MM-dd") & "</ReleaseDateTime>")
            xml = xml.Replace("String", "")
            xRes = CallWebService("http://cdes.aduana.gob.ec/cdes_svr/SENAE_CommonResponseService_EC?wsdl", xml, "requestCommonResponseList")
            'xRes.Save("C:\xml\QRY\" & Date.Now.Ticks.ToString & ".xml")
            xRes.Save(rutaejecutable & "\xml\QRY\" & Date.Now.Ticks.ToString & ".xml")
            dsRes.ReadXml(New XmlNodeReader(xRes))
            dtReference = dsRes.Tables("Declaration")
            If dtReference Is Nothing Then Return "SIN ERRORES"
            For Each dRow As DataRow In dtReference.Rows
                dclrResponse = New DeclarationResponse
                dclrResponse = QueryDocumentResponseByReferenceId(dRow.Item("FunctionalReferenceID"), SubmitDate)
                If dclrResponse.ID = eDocId Then
                    result = dclrResponse.ErrorDescription
                    Exit For
                End If
            Next
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            Return "SIN RESPUESTA"
        End Try
        Return result
    End Function


    Private Shared Function QueryDocumentResponseByReferenceId(FunctionalReferenceID As String, SubmitDate As Date) As DeclarationResponse
        Dim Result As New DeclarationResponse
        Dim xml As String = My.Settings.DocumentResponse_req 'Cabecera de seguridad
        Dim ds As New DataSet
        Dim xRes As New XmlDocument
        Dim xDocDet As New XmlDocument
        Dim resDocDetail As String = String.Empty
        Dim dataEcuapass() As String = Ecuapass.getDataEcuapass() 'MARZ 
        Dim rutaejecutable As String = Application.StartupPath
        If Not FileIO.FileSystem.DirectoryExists(rutaejecutable & "\xml") Then
            FileIO.FileSystem.CreateDirectory(rutaejecutable & "\xml")
        End If
        Try
            'MARZ
            xml = xml.Replace("usuarioEcuapass", dataEcuapass(0))
            xml = xml.Replace("claveEcuapass", dataEcuapass(1))
            xml = xml.Replace("keyEcuapass", dataEcuapass(2))
            'MARZ - End
            xml = xml.Replace("2015-02-24 09:37:00", Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            xml = xml.Replace("<EffectiveDateTime>2015-02-23</EffectiveDateTime>", "<EffectiveDateTime>" & SubmitDate.ToString("yyyy-MM-dd") & "</EffectiveDateTime>")
            xml = xml.Replace("<ReleaseDateTime>2015-02-23</ReleaseDateTime>", "<ReleaseDateTime>" & SubmitDate.ToString("yyyy-MM-dd") & "</ReleaseDateTime>")
            xml = xml.Replace("201502231317053", FunctionalReferenceID)
            xRes = CallWebService("http://cdes.aduana.gob.ec/cdes_svr/SENAE_CommonResponseService_EC?wsdl", xml, "requestNotificationAcceptanceNA") 'MARZ
            ds.ReadXml(New XmlNodeReader(xRes))
            resDocDetail = ds.Tables("Response").Rows(0).Item("DocumentDetail")
            ds.Clear()
            ds = New DataSet
            xDocDet.LoadXml(resDocDetail)
            ds.ReadXml(New XmlNodeReader(xDocDet))
            Result.ID = ds.Tables("Declaration").Rows(0).Item("ID")
            Result.ErrorDescription = String.Empty
            For Each dr As DataRow In ds.Tables("Error").Rows
                Result.ErrorDescription += dr.Item("ErrorDescription") & ControlChars.CrLf
            Next
        Catch ex As Exception
            'FileIO.FileSystem.WriteAllText("C:\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
            FileIO.FileSystem.WriteAllText(rutaejecutable & "\xml\log.txt", Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & " - " & ex.Message & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf, True)
        End Try
        Return Result
    End Function

    Public Enum eDocType As Integer
        [IIE] = 1
        [ISE] = 2
        [CII] = 3
    End Enum

    Private Structure DeclarationResponse
        Dim ID As String
        Dim ErrorDescription As String
    End Structure

End Class
