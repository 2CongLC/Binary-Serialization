Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class SerializationManager(Of t As Class)

    <Obsolete>
    Public Shared Function ReadFromBinFile(ByVal filePath As String) As t
        Using fs As Stream = New FileStream(filePath, FileMode.Open)
            Dim binaryFormatter As New BinaryFormatter()
            Dim obj As t = DirectCast(binaryFormatter.Deserialize(fs), t)
            Return obj
        End Using
    End Function

    <Obsolete>
    Public Shared Sub WriteToBinFile(ByVal filePath As String, ByVal objectToWrite As t)
        Dim writer As Stream = Nothing
        Try
            Dim serializer = New BinaryFormatter()
            writer = New FileStream(filePath, FileMode.Create)
            serializer.Serialize(writer, objectToWrite)
        Finally
            If writer IsNot Nothing Then
                writer.Close()
            End If
        End Try
    End Sub


    <Obsolete>
    Public Shared Function BinarySerialize(ByVal obj As t) As String

        Dim ms As MemoryStream = New MemoryStream()
        Dim binaryFormatter As New BinaryFormatter()
        Try
            binaryFormatter.Serialize(ms, obj)
        Catch ex As Exception
        End Try
        Return Encoding.UTF8.GetString(ms.ToArray())

    End Function

    <Obsolete>
    Public Shared Function BinaryDeSerialize(ByVal value As String) As t

        Dim ms As MemoryStream = New MemoryStream(Encoding.UTF8.GetBytes(value))
        Dim binaryFormatter As New BinaryFormatter()
        Dim obj As t = Nothing
        Try
            obj = DirectCast(binaryFormatter.Deserialize(ms), t)
        Catch ex As Exception
        End Try
        Return obj

    End Function
        
End Class
