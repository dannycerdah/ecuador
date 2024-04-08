Imports SPC.Server.ReportService
Public Class frmPosicionDetails
    Public Property myPosicion As New PosicionItem
    Private Property DetailsEditingMode As Boolean = False
    Private Property IsNewPosicion As Boolean = False

    Private Sub InitializeValues()
        myPosicion.Id = Guid.Empty
        myPosicion.descripcion = ""
    End Sub

    Public Sub New(ByVal myPosicionItem As PosicionItem)
        InitializeComponent()
        InitializeValues()
        myPosicion = myPosicionItem
    End Sub

    Public Sub New(MustCreateNewMterial As Boolean)
        InitializeComponent()
        InitializeValues()
        myPosicion.Id = Guid.NewGuid
        IsNewPosicion = True
    End Sub

    Public Sub New(ByVal PosicionId As Guid)
        InitializeComponent()
        InitializeValues()
        myPosicion = CommonData.GetPosicionItem(PosicionId)
    End Sub


    Private Sub frmPosicionDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FillPosicionInfo()
    End Sub

    Private Sub FillPosicionInfo()
        If Not IsNewPosicion Then
            txtDescripcion.Text = myPosicion.descripcion
        End If
    End Sub

    Private Sub SaveChanges()
        Dim req As New PosicionRequest
        Dim res As New PosicionResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito"
        Try
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsNewPosicion Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito"
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                CamionInfoToObject()
                req.myPosicionItem = myPosicion
                res = wsClnt.SavePosicionInfo(req)
                If res.ActionResult Then
                    MessageBox.Show(msgc, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception(res.ErrorMessage)
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(res.ErrorMessage)
            ErrorManager.SetLogEvent(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub CamionInfoToObject()
        If IsNewPosicion Then
            myPosicion.Id = Guid.NewGuid
        End If
        myPosicion.descripcion = txtDescripcion.Text
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("¿Desea salir sin guardar cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

End Class

