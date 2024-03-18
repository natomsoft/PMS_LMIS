Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class hlpPasswordEncryptDecrypt
    Implements IDisposable
    Private bytKey() As Byte
    Private bytIV() As Byte
    Private bytInput() As Byte
    Private objTripleDES As TripleDESCryptoServiceProvider
    Private objOutputStream As MemoryStream

    'Public Sub New(ByVal Key() As Byte, ByVal IV() As Byte)
    '    'Initialize the security key and initialization vector
    '    bytKey = Key
    '    bytIV = IV
    '    'Instantiate a new instance of the TripleDESCryptoServiceProvider class
    '    objTripleDES = New TripleDESCryptoServiceProvider
    'End Sub

    Public Sub New()
        'Initialize the security key and initialization vector
        bytKey = System.Text.Encoding.UTF8.GetBytes("G~v!x@Z#c$a%C^b&h*K(e)K_")
        bytIV = System.Text.Encoding.UTF8.GetBytes("rgY^p$b%")
        'Instantiate a new instance of the TripleDESCryptoServiceProvider class
        objTripleDES = New TripleDESCryptoServiceProvider
    End Sub

    Public Function Encrypt(ByVal strToEncrypt As String) As String
        Try
            'Convert the input string to a byte array
            Dim bytInput() As Byte = Encoding.UTF8.GetBytes(strToEncrypt)
            'Instantiate a new instance of the MemoryStream class
            Using objOutputStream As New MemoryStream
                'Encrypt the byte array
                Dim objCryptoStream As New CryptoStream(objOutputStream, objTripleDES.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                objCryptoStream.Write(bytInput, 0, bytInput.Length)
                objCryptoStream.FlushFinalBlock()
                'Return the byte array as a Base64 string
                Encrypt = Convert.ToBase64String(objOutputStream.ToArray())
            End Using
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Decrypt(ByVal strToDecrypt As String) As String
        Try
            'Convert the input string to a byte array
            Dim inputByteArray() As Byte = Convert.FromBase64String(strToDecrypt)
            'Instantiate a new instance of the MemoryStream class
            Using objOutputStream As New MemoryStream
                'Decrypt the byte array
                Dim objCryptoStream As New CryptoStream(objOutputStream, objTripleDES.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write)
                objCryptoStream.Write(inputByteArray, 0, inputByteArray.Length)
                objCryptoStream.FlushFinalBlock()
                'Return the byte array as a string
                Decrypt = Encoding.UTF8.GetString(objOutputStream.ToArray())
            End Using
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, ExceptionErr.InnerException)
        End Try
    End Function

#Region "IDisposable Support"
                Private disposedValue As Boolean ' To detect redundant calls

                ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            objTripleDES = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
