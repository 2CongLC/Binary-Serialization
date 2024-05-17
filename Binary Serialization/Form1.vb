Imports System.IO
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

                Dim obj As String = File.ReadAllText(OpenFileDialog1.FileName)
                SerializationManager(Of String).WriteToBinFile(SaveFileDialog1.FileName, obj)
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

                Dim obj As String = SerializationManager(Of String).ReadFromBinFile(OpenFileDialog1.FileName)
                File.WriteAllText(SaveFileDialog1.FileName, obj)
                MessageBox.Show("ok")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    <Obsolete>
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then

                Dim obj As String = File.ReadAllText(OpenFileDialog1.FileName)
                Dim bs As String = BinarySerialize(Of String)(obj)
                File.WriteAllText(SaveFileDialog1.FileName, bs)
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

                Dim obj As String = File.ReadAllText(OpenFileDialog1.FileName)
                Dim bs As String = BinaryDeSerialize(Of String)(obj)
                File.WriteAllText(SaveFileDialog1.FileName, bs)
                MessageBox.Show("ok")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    <Obsolete>
    Public Function BinarySerialize(Of t)(ByVal obj As t) As String
        Dim _outms As MemoryStream = New MemoryStream()
        Dim binaryFormatter As New BinaryFormatter()
        binaryFormatter.Serialize(_outms, obj)
        Return Encoding.UTF8.GetString(_outms.ToArray())
    End Function

    <Obsolete>
    Public Function BinaryDeSerialize(Of t)(ByVal value As String) As t

        Dim binaryFormatter As New BinaryFormatter()
        Dim obj As t = Nothing
        obj = DirectCast(binaryFormatter.Deserialize(, t)
        Return obj
    End Function



End Class
