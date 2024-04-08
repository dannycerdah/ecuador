Imports System.IO 'simon
'Imports WebCAM.WebCam

Public Class frmVisualizar
    Public Property capturaRostro As Image
    Public Property myImagen As String
    Public Property idContaco As String
    Public webcam As New WebCamVisor
    Public Property myImagenes As List(Of Server.ReportService.ContactoImagenCatalogoItem)

    Dim lwinu_control As Integer
    Dim lwinuPosicion As Integer
    Dim misControles As New System.Collections.Generic.Dictionary(Of String, PictureBox)

    Private Sub frmVisualizar_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        capturaRostro = picImagen_01.Image 'guille
        'wcimagenPerfil.Stop()
    End Sub

    Private Sub frmVisualizar_x(sender As Object, e As EventArgs) Handles Me.FormClosing
        If Not picImagen_01.Image Is Nothing Then
            capturaRostro = picImagen_01.Image 'guille
        End If
    End Sub

    Private Sub frmVisualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureCamara.Image = Drawing.Image.FromFile(My.Computer.FileSystem.CurrentDirectory + "\Resources\imagenPerfil.jpg")

        lwinu_control = 1
        lwinuPosicion = 1
        cargarImagenes()
        Me.iniciar.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'capturaRostro = wcimagenPerfil.Imagen

        capturaRostro = picImagen_01.Image 'guille
        cargarImagenesCapturadas()
        webcam.Apagar()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Dim imagen As Image
        imagen = webcam.CAPTURAR()

        If imagen Is Nothing Then
            Exit Sub
        End If

        If chkRemplaza.Checked = True Then
            picImagen_01.Image = imagen
            Exit Sub
        End If

        If Not picImagen_01.Image Is Nothing Then
            crearcontroles(imagen)
        Else
            picImagen_01.Image = imagen
        End If

    End Sub

    Private Sub btnQuitar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnBoton As Button = DirectCast(sender, Button)

        EventosdelosBotones(btnBoton.Name)
    End Sub

    Private Sub btnQuitarPictureBox_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btnBoton As Button = DirectCast(sender, Button)
        Dim sNombreboton As String
        Dim img As Server.ReportService.ContactoImagenCatalogoItem
        Dim frm As frmContactoDetails
        sNombreboton = btnBoton.Name

        Dim numero_control = sNombreboton.Substring(sNombreboton.Length - 2, 2)
        Dim picImagen As PictureBox = misControles("picImagen_" & StrDup(2 - Len(numero_control.ToString), "0") + numero_control.ToString)

        'verifico si esta quitando un elemento imagen que ya existia en la BD
        'si es el caso activo la bandera para eliminar de la BD
        If Not picImagen.Image Is Nothing Then
            If Not myImagenes Is Nothing Then
                For lwicontador = 0 To myImagenes.Count - 1
                    If Not myImagenes(lwicontador) Is Nothing Then

                        If myImagenes(lwicontador).imagen = frm.ImageToBase64(picImagen.Image) Then
                            myImagenes(lwicontador).estado = Server.ReportService.estadoImagen.Inactivo
                        End If
                    End If
                Next
            End If
        End If


        Me.Controls.Remove(picImagen)
        Me.Controls.Remove(btnBoton)

        'redimencionar espacios
        lwinuPosicion = 0
        numero_control = 0
        For Each ctrl In Controls

            If TypeOf (ctrl) Is PictureBox Then
                Dim sNombrectrl As String
                sNombrectrl = ctrl.Name

                If sNombrectrl.Substring(0, sNombrectrl.Length - 2) = "picImagen_" Then

                    lwinuPosicion += 1
                    ctrl.Location = New System.Drawing.Point(230 * lwinuPosicion + 20, 12)
                    numero_control = sNombrectrl.Substring(sNombrectrl.Length - 2, 2)
                    If numero_control > 2 Then
                        Me.Controls("btnQuitar_" & StrDup(2 - Len(numero_control.ToString), "0") + numero_control.ToString).Location = New System.Drawing.Point(ctrl.Location.X + 140, 290)
                    End If


                End If


            End If

        Next
        Me.Width = Me.Width - 220
        Me.CenterToScreen()


    End Sub

    'Private Sub btnCapturar_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim wcimagen As WebCAM.WebCam = DirectCast(sender, WebCAM.WebCam)
    '    capturaRostro = wcimagen.Imagen
    'End Sub

    Sub EventosdelosBotones(mensaje As String)
        MsgBox(mensaje)
    End Sub
    Private Sub cargarImagenes()
        Dim frm As frmContactoDetails
        Dim base64String As String
        Dim imagen As Server.ReportService.ContactoImagenCatalogoItem
        Dim lwicon As Integer
        lwicon = 0

        If myImagenes Is Nothing Then
            Exit Sub
        End If

        For Each imagen In myImagenes

            base64String = imagen.imagen

            If Not myImagen Is Nothing Then
                Dim capturaRostro As System.Drawing.Image = frm.Base64ToImage(base64String)
                lwicon = lwicon + 1
                If lwicon = 1 Then
                    picImagen_01.Image = capturaRostro
                Else
                    crearcontroles(Nothing)
                    Dim picImagen As PictureBox = misControles("picImagen_" & StrDup(2 - Len(lwicon.ToString), "0") + lwicon.ToString)
                    picImagen.Image = capturaRostro
                End If
            End If
        Next

    End Sub
    Private Sub cargarImagenesCapturadas()
        Dim imagen As Server.ReportService.ContactoImagenCatalogoItem
        Dim frm As frmContactoDetails
        Dim flag As Boolean
        Try

            For Each ctrl In Controls
                If TypeOf (ctrl) Is PictureBox Then
                    flag = False

                    Dim sNombrectrl As String
                    sNombrectrl = ctrl.Name

                    If sNombrectrl.Substring(0, sNombrectrl.Length - 2) = "picImagen_" Then
                        If Not myImagenes Is Nothing Then
                            For Each imagen In myImagenes
                                If imagen.imagen = frm.ImageToBase64(ctrl.Image) Then
                                    flag = True
                                    Exit For
                                End If
                            Next

                        End If


                        If Not flag Then
                            If Not ctrl.Image Is Nothing Then
                                imagen = New Server.ReportService.ContactoImagenCatalogoItem
                                imagen.idContacto = idContaco
                                imagen.idImagen = Guid.NewGuid()
                                imagen.imagen = frm.ImageToBase64(ctrl.Image)
                                imagen.Usuario = ""
                                imagen.estado = Server.ReportService.estadoImagen.Nuevo
                                If myImagenes Is Nothing Then
                                    myImagenes = New List(Of Server.ReportService.ContactoImagenCatalogoItem)
                                End If
                                myImagenes.Add(imagen)
                            End If

                        End If

                    End If



                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub crearcontroles(imagen As Image)
        Dim control_img As New PictureBox

        Dim control_btn As New Button
        Dim control_btnQuitar As New Button



        'agregar control PictureBox


        lwinu_control += 1
        lwinuPosicion += 1
        control_img.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        'control_img.Image = wcimagenPerfil.Imagen
        control_img.Image = imagen
        control_img.Location = New System.Drawing.Point(230 * lwinuPosicion + 20, 12)
        control_img.Name = "picImagen_" + StrDup(2 - Len(lwinu_control.ToString), "0") + lwinu_control.ToString
        control_img.Size = New System.Drawing.Size(220, 272)
        control_img.SizeMode = PictureBoxSizeMode.StretchImage

        misControles.Add(control_img.Name, control_img)
        Me.Controls.Add(control_img)
        Me.Width = control_img.Location.X + control_img.Size.Width + 20

        ' agregar boton control button Quitar
        control_btnQuitar.Location = New System.Drawing.Point(control_img.Location.X + 140, 290)
        control_btnQuitar.Name = "btnQuitar_" + StrDup(2 - Len(lwinu_control.ToString), "0") + lwinu_control.ToString
        control_btnQuitar.Size = New System.Drawing.Size(75, 23)
        control_btnQuitar.Text = "Quitar"
        control_btnQuitar.UseVisualStyleBackColor = True

        Me.Controls.Add(control_btnQuitar)
        Me.CenterToScreen()
        AddHandler control_btnQuitar.Click, AddressOf btnQuitarPictureBox_Click
    End Sub

    Private Sub iniciar_Click(sender As Object, e As EventArgs) Handles iniciar.Click
        webcam.PictBox = PictureCamara

        Me.iniciar.Enabled = Not webcam.OpenPreviewWindow()

    End Sub


End Class

