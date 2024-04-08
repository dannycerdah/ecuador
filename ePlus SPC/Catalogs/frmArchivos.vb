Imports System.IO
Imports System.Diagnostics
Imports SPC.Server.ReportService
Public Class frmArchivo
    Public Property myArchivoAgencia As New ArchivoAgenciaCatalogItem
    Public Property myArchivoContacto As New ArchivoContactoCatalogItem
    Private Property IsNewArchivo As Boolean = False
    Dim isArchivoAgencia As Boolean = False

    Private Sub InitializeValues()
        myArchivoAgencia.idAgencia = Guid.Empty
        myArchivoAgencia.idArchivo = Guid.Empty
        myArchivoAgencia.descripcionArchivo = ""
        myArchivoAgencia.extArchivo = ""
    End Sub

    Public Sub New(ByVal AgenciaId As Guid)
        InitializeComponent()
        InitializeValues()
        myArchivoAgencia.idAgencia = AgenciaId
        IsNewArchivo = True
        isArchivoAgencia = True
    End Sub

    Public Sub New(ByVal ContactoId As String)
        InitializeComponent()
        InitializeValues()
        myArchivoContacto.idContacto = ContactoId
        IsNewArchivo = True
    End Sub

    Public Sub New(ByVal AgenciaId As Guid, ByVal id As Guid)
        isArchivoAgencia = True
        InitializeComponent()
        InitializeValues()
        myArchivoAgencia = CommonData.GetArchivoAgenciaItem(id)
        fillInfoArchivoAgencia()
    End Sub

    Public Sub New(ByVal ContactoId As String, ByVal id As Guid)
        InitializeComponent()
        InitializeValues()
        myArchivoContacto = CommonData.GetArchivoContactoItem(id)
        fillInfoArchivoContacto()
    End Sub

    Public Sub fillInfoArchivoAgencia()
        Bytes_Archivo(myArchivoAgencia.binArchivo, myArchivoAgencia.descripcionArchivo, myArchivoAgencia.extArchivo)
        txtDescripcion.Text = myArchivoAgencia.descripcionArchivo
    End Sub

    Public Sub fillInfoArchivoContacto()
        Bytes_Archivo(myArchivoContacto.binArchivo, myArchivoContacto.descripcionArchivo, myArchivoContacto.extArchivo)
        txtDescripcion.Text = myArchivoContacto.descripcionArchivo
    End Sub

    Private Sub Bytes_Archivo(ByVal Archivo As Byte(), ByVal desc As String, ByVal ext As String)
        Dim ruta As String = Application.StartupPath & "\" & desc & "." & ext
        txtRuta.Text = ruta
        Dim buffersize As Integer = 300000
        Dim outbyte(300000 - 1) As Byte
        Dim retVal() As Byte = Nothing
        Dim starIndex As Long = 0
        Dim pub_id As String = ""
        Dim fs As New FileStream(ruta, FileMode.Create)
        Dim bw As BinaryWriter = New BinaryWriter(fs)
        bw.Write(Archivo)
        bw.Flush()
        bw.Close()
        ReadBinaryFile(ruta)
    End Sub

    Public Shared Function ReadBinaryFile(ByVal ruta As String)
        Dim streamBinary As New FileStream(ruta, FileMode.Open)
        Dim readerInput As BinaryReader = New BinaryReader(streamBinary)
        Dim lengthFile As Integer = streamBinary.Length
        Dim inputData As Byte() = readerInput.ReadBytes(lengthFile)
        streamBinary.Close()
        readerInput.Close()
        Dim psi As New ProcessStartInfo()
        psi.UseShellExecute = True
        psi.FileName = ruta
        Process.Start(psi)
        Return inputData
    End Function

    Private Function Archivo_Bytes(ByVal ruta As String) As Byte()
        If Not ruta Is Nothing Then
            Dim fs As New FileStream(ruta, FileMode.Open, FileAccess.Read)
            Dim binario(fs.Length) As Byte
            fs.Read(binario, 0, fs.Length)
            fs.Close()
            Return binario
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
            If isArchivoAgencia Then
                SaveArchivoAgencia()
            Else
                SaveArchivoContacto()
            End If
    End Sub

    Private Sub SaveArchivoAgencia()
        Dim req As New ArchivoAgenciaRequest
        Dim res As New ArchivoAgenciaResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try

          

            If txtRuta.Text = "" Then
                MessageBox.Show("Ingrese la Ruta del Archivo.", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese la descripcion del Archivo.", "Descripcion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If IsNewArchivo Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If
            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                ArchivoAgenciaInfoToObject()
                req.myArchivoAgenciaItem = myArchivoAgencia
                res = wsClnt.SaveArchivoAgenciaItem(req)
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

    Private Sub SaveArchivoContacto()

        Dim req As New ContactoRequest
        Dim res As New ContactoResponse
        Dim wsClnt As New ReportServiceSoapClient
        Dim msgp As String = "¿Está seguro que desea actualizar este registro?"
        Dim msgc As String = "Registro actualizado con éxito."
        Try

            If frmContactoDetails.IsNewContacto = True Then

                ArchivoContactoInfoToObject()
                Me.Close()

                Exit Sub
            End If

            If txtRuta.Text = "" Then
                MessageBox.Show("Ingrese la Ruta del Archivo.", "Ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtDescripcion.Text = "" Then
                MessageBox.Show("Ingrese la descripcion del Archivo.", "Descripcion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If IsNewArchivo Then
                msgp = "¿Está seguro que desea guardar este registro?"
                msgc = "Registro guardado con éxito."
            End If

            If MessageBox.Show(msgp, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                General.SetBARequest(req)
                ArchivoContactoInfoToObject()
                req.myArchivoContactoItem = myArchivoContacto
                res = wsClnt.SaveArchivoContactoItem(req)
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

    Public Sub ArchivoAgenciaInfoToObject()
        Dim Archivo As Byte()
        Archivo = Archivo_Bytes(txtRuta.Text)
        myArchivoAgencia.idArchivo = Guid.NewGuid
        myArchivoAgencia.descripcionArchivo = txtDescripcion.Text
        myArchivoAgencia.extArchivo = txtRuta.Text.Substring(txtRuta.Text.Length - 3)
        myArchivoAgencia.binArchivo = Archivo
        myArchivoAgencia.estado = "A"
    End Sub

    Public Sub ArchivoContactoInfoToObject()
        Dim Archivo As Byte()
        Dim tstnum As Integer = 0
        Dim lengnum As Integer = 0
        Archivo = Archivo_Bytes(txtRuta.Text)
        myArchivoContacto.idArchivo = Guid.NewGuid
        myArchivoContacto.descripcionArchivo = txtDescripcion.Text
        lengnum = txtRuta.Text.Length
        tstnum = InStrRev(txtRuta.Text, ".", , CompareMethod.Text)
        If (lengnum - tstnum) = 4 Then
            myArchivoContacto.extArchivo = txtRuta.Text.Substring(txtRuta.Text.Length - 4)
        Else
            myArchivoContacto.extArchivo = txtRuta.Text.Substring(txtRuta.Text.Length - 3)
        End If
        myArchivoContacto.binArchivo = Archivo
        myArchivoContacto.estado = "A"


        frmContactoDetails.myArchivoContacto = myArchivoContacto

    End Sub

    Private Sub btnSelectArchivo_Click_1(sender As Object, e As EventArgs) Handles btnSelectArchivo.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Todos los Archivos|*.*"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            txtRuta.Text = openFileDialog.FileName
            picImagen.ImageLocation = txtRuta.Text
        End If
    End Sub
End Class