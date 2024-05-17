Imports System.IO
Imports System.Text

Public Class StringStream
    Inherits Stream

    Private ReadOnly _memory As MemoryStream

    Public Sub New(ByVal text As String)
        _memory = New MemoryStream(Encoding.UTF8.GetBytes(text))
    End Sub

    Public Sub New()
        _memory = New MemoryStream()
    End Sub

    Public Sub New(ByVal capacity As Integer)
        _memory = New MemoryStream(capacity)
    End Sub

    Public Overrides Sub Flush()
        _memory.Flush()
    End Sub

    Public Overrides Function Read(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer) As Integer
        Return _memory.Read(buffer, offset, count)
    End Function

    Public Overrides Function Seek(ByVal offset As Long, ByVal origin As SeekOrigin) As Long
        Return _memory.Seek(offset, origin)
    End Function

    Public Overrides Sub SetLength(ByVal value As Long)
        _memory.SetLength(value)
    End Sub

    Public Overrides Sub Write(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer)
        _memory.Write(buffer, offset, count)
    End Sub

    Public Overrides ReadOnly Property CanRead As Boolean
        Get
            Return _memory.CanRead
        End Get
    End Property

    Public Overrides ReadOnly Property CanSeek As Boolean
        Get
            Return _memory.CanSeek
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return _memory.CanWrite
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Long
        Get
            Return _memory.Length
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            Return _memory.Position
        End Get
        Set(ByVal value As Long)
            _memory.Position = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Encoding.UTF8.GetString(_memory.GetBuffer(), 0, CInt(_memory.Length))
    End Function

    Public Overrides Function ReadByte() As Integer
        Return _memory.ReadByte()
    End Function

    Public Overrides Sub WriteByte(ByVal value As Byte)
        _memory.WriteByte(value)
    End Sub
End Class
