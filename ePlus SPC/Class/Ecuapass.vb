Imports System.Security.Cryptography
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Public Class Ecuapass
    'Contraseña aleatoria de 128 bits 
    Shared Function randomKey() As String
        Dim passRandom As String = ""
        Dim rng As New RNGCryptoServiceProvider
        Dim byteBuffer(15) As Byte
        rng.GetBytes(byteBuffer)
        passRandom = Convert.ToBase64String(byteBuffer)
        Return passRandom
    End Function
    'RSA
    Shared Function RSA_Encrypt(ByVal secretKey As String) As String
        Dim cert As New X509Certificate2(My.Resources.aduana)
        Dim encrypted As String = ""
        Try
            Dim rsaProvider As RSACryptoServiceProvider = DirectCast(cert.PublicKey.Key, RSACryptoServiceProvider)
            Dim bytesData As Byte() = Encoding.UTF8.GetBytes(secretKey)
            Dim bytesEncrypted As Byte() = rsaProvider.Encrypt(bytesData, False)
            encrypted = Convert.ToBase64String(bytesEncrypted)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return encrypted
    End Function
    'AES
    Shared Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim plainBytes() As Byte = Encoding.UTF8.GetBytes(input)
        Return Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(pass)))
    End Function
    Shared Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim encryptedBytes = Convert.FromBase64String(input)
        Return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(pass)))
    End Function
    'AES/ECB/PKCS7
    Shared Function GetRijndaelManaged(ByVal secretKey As String) As RijndaelManaged
        Dim keyBytes(15) As Byte
        Dim secretKeyBytes = Convert.FromBase64String(secretKey)
        Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length))
        Dim rsaE As New RijndaelManaged()
        rsaE.Mode = CipherMode.ECB
        rsaE.Padding = PaddingMode.PKCS7
        rsaE.KeySize = 128
        rsaE.BlockSize = 128
        rsaE.Key = keyBytes
        rsaE.IV = keyBytes
        Return rsaE
    End Function
    Shared Function Encrypt(ByVal plainBytes() As Byte, ByRef rijndaelManaged As RijndaelManaged) As Byte()
        Return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length)
    End Function
    Shared Function Decrypt(ByVal encryptedData() As Byte, ByRef rijndaelManaged As RijndaelManaged) As Byte()
        Return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length)
    End Function
    'Data
    Shared Function getDataEcuapass() As String()
        Dim dataEcuapass(2) As String
        Dim myConf = CommonData.GetConfiguraciones() 'Base de datos (Configuraciones)
        Dim passDB As String = myConf.passwordEcuapass 'AES_Decrypt(myConf.passwordEcuapass, myConf.keyEcuapass) 'Descencriptar clave
        Dim ramdomKey As String = randomKey()
        Dim aesUsuario As String = myConf.userEcuapass 'AES_Encrypt(myConf.userEcuapass, ramdomKey)
        Dim aesClave As String = AES_Encrypt(passDB, ramdomKey) 'Test
        Dim rsaKey As String = RSA_Encrypt(ramdomKey)
        dataEcuapass(0) = AES_Encrypt(aesUsuario, ramdomKey) 'aesUsuario
        dataEcuapass(1) = AES_Encrypt(passDB, ramdomKey)
        dataEcuapass(2) = rsaKey
        Return dataEcuapass 'Retornamos datos de Ecuapass
    End Function
End Class
