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

End Class
