Imports System.IO

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
End Class
