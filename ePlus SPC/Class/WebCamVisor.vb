Imports System.Runtime.InteropServices

Public Class WebCamVisor

    Public Property PictBox As PictureBox

    Dim DATOS As IDataObject
    Dim IMAGEN As Image
    Dim CARPETA As String
    Dim FECHA As String = DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_")
    Dim DIRECTORIO As String = "C:\Users\SALVADOR\Desktop\" ' AQUI COLOCA LA RUTA A TU ESCRITORIO
    Dim DESTINO As String
    Dim CONTADOR As Integer = 1
    Dim CARPETAS_DIARIAS As String
    Public Const WM_CAP As Short = &H400S
    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    Public Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Public Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Public Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Public Const WM_CAP_SEQUENCE As Integer = WM_CAP + 62
    Public Const WM_CAP_FILE_SAVEAS As Integer = WM_CAP + 23
    Public Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Public Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Public Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4S
    Public Const HWND_BOTTOM As Short = 1
    Public Const WM_CAP_STOP As Integer = WM_CAP + 68

    Public iDevice As Integer = 0 ' Current device ID
    Public hHwnd As Integer ' Handle to preview window

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean


    'Open View
    Public Function OpenPreviewWindow() As Boolean
        Dim ActivaCamara As Boolean

        ' Open Preview window in picturebox
        '
        ActivaCamara = False

        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
           480, PictBox.Handle.ToInt32, 0)

        ' Connect to device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '
            ' Establecer la escala de vista previa

            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            'Establecer la tasa de vista previa en milisegundos
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            'Comience a obtener una vista previa de la imagen de la cámara
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PictBox.Width, PictBox.Height, _
                    SWP_NOMOVE Or SWP_NOZORDER)


            SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)


            ActivaCamara = True
        Else
            ' Error connecting to device close window
            ' 
            DestroyWindow(hHwnd)
            ActivaCamara = False

        End If

        Return ActivaCamara

    End Function
    Public Sub OpenPreviewWindowCliente()

        ' Open Preview window in picturebox
        '
        'hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 600, _
        '   480, PictBox.Handle.ToInt32, 0)

        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 230, _
   282, PictBox.Handle.ToInt32, 0)


        ' Connect to device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0)
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            '
            'Set the preview scale

            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            'Set the preview rate in milliseconds
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            'Start previewing the image from the camera
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, PictBox.Width, PictBox.Height, _
                    SWP_NOMOVE Or SWP_NOZORDER)

        Else
            ' Error connecting to device close window
            ' 
            DestroyWindow(hHwnd)

        End If
    End Sub

   

    Public Sub ClosePreviewWindow()
        '
        ' Disconnect from device
        '
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)
        '
        ' close window
        '
        'DestroyWindow(hHwnd)
    End Sub

    Public Sub INICIAR()
        'Load And Capture Device
        OpenPreviewWindow()

    End Sub

    Public Function CAPTURAR() As System.Drawing.Image
        ' Copiar imagen al portapapeles
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        ' Obtengo la imagen del portapapeles y conviértala en un mapa de bits
        DATOS = Clipboard.GetDataObject()
        IMAGEN = CType(DATOS.GetData(GetType(System.Drawing.Bitmap)), Image)
        Return IMAGEN

    End Function
    Public Sub Apagar()
        ClosePreviewWindow()
    End Sub

End Class
