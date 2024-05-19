Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text

Public Class Form1

    <Obsolete>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim db As New InMemoryDb()
                Dim people As List(Of Person) = db.People

                SerializationManager(Of Object).WriteToBinFile(SaveFileDialog1.FileName, people)
                MessageBox.Show("ok")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    <Obsolete>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then

                Dim db As Object = SerializationManager(Of Object).ReadFromBinFile(OpenFileDialog1.FileName)

                For Each s As Person In db
                    TextBox1.Text = s.Id
                    TextBox2.Text = s.Email
                Next

                MessageBox.Show("ok")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    <Obsolete>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim a = File.ReadAllText(OpenFileDialog1.FileName)
                SerializationManager(Of String).WriteToBinFile(SaveFileDialog1.FileName, a)
                MessageBox.Show("ok")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub
    <Obsolete>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim a As String = SerializationManager(Of String).ReadFromBinFile(OpenFileDialog1.FileName)
                File.WriteAllText(SaveFileDialog1.FileName, a)
                MessageBox.Show("ok")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    <Obsolete>
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim a As Byte() = SerializeBIN(Of String)(File.ReadAllText(OpenFileDialog1.FileName))
                File.WriteAllBytes(SaveFileDialog1.FileName, a)
                MessageBox.Show("ok")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub
    <Obsolete>
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim a As String = DeserializeBIN(Of String)(File.ReadAllBytes(OpenFileDialog1.FileName))
                File.WriteAllText(SaveFileDialog1.FileName, a)
                MessageBox.Show("ok")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    <Obsolete>
    Public Function SerializeBIN(Of T)(obj As T) As Byte()
        Using memStream As New MemoryStream()
            Dim binSerializer As New BinaryFormatter()
            binSerializer.Serialize(memStream, obj)
            Return memStream.ToArray()
        End Using
    End Function

    <Obsolete>
    Public Function DeserializeBIN(Of T)(serializedObj As Byte()) As T
        Dim obj As T = Nothing
        Using memStream As New MemoryStream(serializedObj)
            Dim binSerializer As New BinaryFormatter()
            obj = DirectCast(binSerializer.Deserialize(memStream), T)
        End Using
        Return obj
    End Function

    Public Function Serializer(ByVal obj As t) As Byte()
        Dim bytes As Byte()
        Using _MemoryStream As New MemoryStream()
            Dim _BinaryFormatter As IFormatter = New BinaryFormatter()
            _BinaryFormatter.Serialize(_MemoryStream, obj)
            bytes = _MemoryStream.ToArray()
        End Using
        Return bytes
    End Function

    Public Function Deserializer(Of T)(ByVal Bytes As Byte()) As T
        Dim ReturnValue As T

        Using _MemoryStream As New MemoryStream(Bytes)
            Dim _BinaryFormatter As IFormatter = New BinaryFormatter()
            ReturnValue = CType(_BinaryFormatter.Deserialize(_MemoryStream), T)
        End Using
        Return ReturnValue
    End Function




End Class
