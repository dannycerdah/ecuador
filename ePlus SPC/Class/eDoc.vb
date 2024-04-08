Namespace ISenae

    <Serializable> _
    Public Class DocumentMetadata
        Dim m_WCODataModelVersion As String = ""
        Public Property WCODataModelVersion() As String
            Get
                Return m_WCODataModelVersion
            End Get
            Set(ByVal Value As String)
                m_WCODataModelVersion = Value
            End Set
        End Property

        Dim m_WCODocumentName As String = ""
        Public Property WCODocumentName() As String
            Get
                Return m_WCODocumentName
            End Get
            Set(ByVal Value As String)
                m_WCODocumentName = Value
            End Set
        End Property

        Dim m_CountryCode As String = ""
        Public Property CountryCode() As String
            Get
                Return m_CountryCode
            End Get
            Set(ByVal Value As String)
                m_CountryCode = Value
            End Set
        End Property

        Dim m_AgencyName As String = ""
        Public Property AgencyName() As String
            Get
                Return m_AgencyName
            End Get
            Set(ByVal Value As String)
                m_AgencyName = Value
            End Set
        End Property

        Dim m_AgencyAssignedCountrySubEntityID As String = ""
        Public Property AgencyAssignedCountrySubEntityID() As String
            Get
                Return m_AgencyAssignedCountrySubEntityID
            End Get
            Set(ByVal Value As String)
                m_AgencyAssignedCountrySubEntityID = Value
            End Set
        End Property

        Dim m_AgencyAssignedCustomizedDocumentName As String = ""
        Public Property AgencyAssignedCustomizedDocumentName() As String
            Get
                Return m_AgencyAssignedCustomizedDocumentName
            End Get
            Set(ByVal Value As String)
                m_AgencyAssignedCustomizedDocumentName = Value
            End Set
        End Property

        Dim m_AgencyAssignedCustomizedDocumentVersion As String = ""
        Public Property AgencyAssignedCustomizedDocumentVersion() As String
            Get
                Return m_AgencyAssignedCustomizedDocumentVersion
            End Get
            Set(ByVal Value As String)
                m_AgencyAssignedCustomizedDocumentVersion = Value
            End Set
        End Property

        Dim m_Declaration As Declaration
        Public Property Declaration() As Declaration
            Get
                Return m_Declaration
            End Get
            Set(ByVal Value As Declaration)
                m_Declaration = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class Declaration
        Dim m_ID As String = ""
        Public Property ID() As String
            Get
                Return m_ID
            End Get
            Set(ByVal Value As String)
                m_ID = Value
            End Set
        End Property

        Dim m_TypeCode As String = ""
        Public Property TypeCode() As String
            Get
                Return m_TypeCode
            End Get
            Set(ByVal Value As String)
                m_TypeCode = Value
            End Set
        End Property

        Dim m_IssueDateTime As String = ""
        Public Property IssueDateTime() As String
            Get
                Return m_IssueDateTime
            End Get
            Set(ByVal Value As String)
                m_IssueDateTime = Value
            End Set
        End Property

        Dim m_DeclarationOfficeID As String = ""
        Public Property DeclarationOfficeID() As String
            Get
                Return m_DeclarationOfficeID
            End Get
            Set(ByVal Value As String)
                m_DeclarationOfficeID = Value
            End Set
        End Property

        Dim m_VersionID As String = ""
        Public Property VersionID() As String
            Get
                Return m_VersionID
            End Get
            Set(ByVal Value As String)
                m_VersionID = Value
            End Set
        End Property

        Dim m_Agent As Agent
        Public Property Agent() As Agent
            Get
                Return m_Agent
            End Get
            Set(ByVal Value As Agent)
                m_Agent = Value
            End Set
        End Property

        Dim m_BorderTransportMeans As BorderTransportMeans
        Public Property BorderTransportMeans() As BorderTransportMeans
            Get
                Return m_BorderTransportMeans
            End Get
            Set(ByVal Value As BorderTransportMeans)
                m_BorderTransportMeans = Value
            End Set
        End Property

        Dim m_Consignment As Consignment
        Public Property Consignment() As Consignment
            Get
                Return m_Consignment
            End Get
            Set(ByVal Value As Consignment)
                m_Consignment = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class Agent
        Dim m_ID As String = ""
        Public Property ID() As String
            Get
                Return m_ID
            End Get
            Set(ByVal Value As String)
                m_ID = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class BorderTransportMeans
        Dim m_Master As String = ""
        Public Property Master() As String
            Get
                Return m_Master
            End Get
            Set(ByVal Value As String)
                m_Master = Value
            End Set
        End Property

        Dim m_TransportEquipment As String = ""
        Public Property TransportEquipment() As String
            Get
                Return m_TransportEquipment
            End Get
            Set(ByVal Value As String)
                m_TransportEquipment = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class Consignment
        Dim m_TransactionDateTime As String = ""
        Public Property TransactionDateTime() As String
            Get
                Return m_TransactionDateTime
            End Get
            Set(ByVal Value As String)
                m_TransactionDateTime = Value
            End Set
        End Property

        Dim m_CarryInBaseNumberID As String = ""
        Public Property CarryInBaseNumberID() As String
            Get
                Return m_CarryInBaseNumberID
            End Get
            Set(ByVal Value As String)
                m_CarryInBaseNumberID = Value
            End Set
        End Property

        Dim m_TransportContractDocument As TransportContractDocument
        Public Property TransportContractDocument() As TransportContractDocument
            Get
                Return m_TransportContractDocument
            End Get
            Set(ByVal Value As TransportContractDocument)
                m_TransportContractDocument = Value
            End Set
        End Property

        Dim m_ConsignmentItem As ConsignmentItem = New ConsignmentItem
        Public Property ConsignmentItem As ConsignmentItem
            Get
                Return m_ConsignmentItem
            End Get
            Set(ByVal Value As ConsignmentItem)
                m_ConsignmentItem = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class ConsignmentItem
        Dim m_TransportEquipment As TransportEquipment
        Public Property TransportEquipment() As TransportEquipment
            Get
                Return m_TransportEquipment
            End Get
            Set(ByVal Value As TransportEquipment)
                m_TransportEquipment = Value
            End Set
        End Property

        Dim m_Commodity As Commodity
        Public Property Commodity() As Commodity
            Get
                Return m_Commodity
            End Get
            Set(ByVal Value As Commodity)
                m_Commodity = Value
            End Set
        End Property

        Dim m_Packaging As Packaging
        Public Property Packaging() As Packaging
            Get
                Return m_Packaging
            End Get
            Set(ByVal Value As Packaging)
                m_Packaging = Value
            End Set
        End Property
        Dim m_RemNumberID As String = ""
        Public Property RemNumberID() As String
            Get
                Return m_RemNumberID
            End Get
            Set(ByVal Value As String)
                m_RemNumberID = Value
            End Set
        End Property
    End Class

    <Serializable> _
    Public Class TransportEquipment
        Dim m_SequenceNumeric As String = ""
        Public Property SequenceNumeric() As String
            Get
                Return m_SequenceNumeric
            End Get
            Set(ByVal Value As String)
                m_SequenceNumeric = Value
            End Set
        End Property

        Dim m_SealID As String() = New String() {}
        Public Property SealID() As String()
            Get
                Return m_SealID
            End Get
            Set(ByVal Value As String())
                m_SealID = Value
            End Set
        End Property
    End Class

    <Serializable> _
    Public Class Commodity
        Dim m_Name As String = ""
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property

        Dim m_CountQuantity As String = ""
        Public Property CountQuantity() As String
            Get
                Return m_CountQuantity
            End Get
            Set(ByVal Value As String)
                m_CountQuantity = Value
            End Set
        End Property

        Dim m_SizeMeasure As String = ""
        Public Property SizeMeasure() As String
            Get
                Return m_SizeMeasure
            End Get
            Set(ByVal Value As String)
                m_SizeMeasure = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class Packaging
        Dim m_TypeCode As String = ""
        Public Property TypeCode() As String
            Get
                Return m_TypeCode
            End Get
            Set(ByVal Value As String)
                m_TypeCode = Value
            End Set
        End Property

    End Class

    <Serializable> _
    Public Class TransportContractDocument
        Dim m_TypeCode As String = ""
        Public Property TypeCode() As String
            Get
                Return m_TypeCode
            End Get
            Set(ByVal Value As String)
                m_TypeCode = Value
            End Set
        End Property

    End Class


End Namespace

