Imports System.Security.Cryptography
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports MySql.Data.MySqlClient
Imports MessageSender.ErrorManager
Imports Microsoft.Practices.EnterpriseLibrary.Data
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
        'Dim cert As New X509Certificate2("C:\certificados\aduana.cer")
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
        'Base de datos
        Dim dbTran As Database
        Dim cmd As New MySqlCommand
        Dim drReader As MySqlDataReader
        Dim passDB As String = ""
        Dim ramdomKey As String = randomKey()
        Dim rsaKey As String = RSA_Encrypt(ramdomKey)
        Try
            dbTran = MyDbFactory.CreateDatabase("TranDB")
            With cmd
                .CommandText = "obtenerConfiguraciones"
                .CommandType = CommandType.StoredProcedure
                .Connection = dbTran.CreateConnection
                .Connection.Open()
            End With
            drReader = cmd.ExecuteReader() 'Lee registro
            If drReader.Read Then
                dataEcuapass(0) = AES_Encrypt(drReader.GetValue(drReader.GetOrdinal("userEcuapass")), ramdomKey)
                passDB = drReader.GetValue(drReader.GetOrdinal("passwordEcuapass")) 'AES_Decrypt(drReader.GetValue(drReader.GetOrdinal("passwordEcuapass")), drReader.GetValue(drReader.GetOrdinal("keyEcuapass")))
                dataEcuapass(1) = AES_Encrypt(passDB, ramdomKey)
                dataEcuapass(2) = rsaKey
            End If
            cmd.Connection.Close()
            drReader.Close()
        Catch ex As Exception
            SetLogEvent(ex)
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar Reader de la conexión
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd = Nothing
            End If
        Finally
            If Not drReader.IsClosed Then drReader.Close() 'Cerrar Reader de la conexión
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
                cmd = Nothing
            End If
        End Try
        Return dataEcuapass 'Retornamos datos de Ecuapass
    End Function
End Class