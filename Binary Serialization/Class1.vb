<Serializable>
Public Class Card
    Public Property Id As Integer
    Public Property Number As String
    Public Property CVC As UShort
    Public Property ExpireDate As Date
    Public Property CardHolder As String
End Class

<Serializable>
Public Class Person
    Public Sub New()
        Cards = New List(Of Card)()
    End Sub
    Public Property Id As Integer
    Public Property Name As String
    Public Property Surname As String
    Public Property Age As Byte
    Public Property Email As String
    Public Property Cards As List(Of Card)
End Class

Public Class InMemoryDb
    Public Property People As List(Of Person)
    Public Property Cards As List(Of Card)
    Public Sub New()
        '#Region "initialize datas"
        Cards = New List(Of Card) From {
            New Card With {
                .Id = 1,
                .CardHolder = "MR. IZUKU MIDORIYA",
                .CVC = 456,
                .ExpireDate = DateTime.Now.AddYears(2),
                .Number = "1234-1234-1234"
            },
            New Card With {
                .Id = 2,
                .CardHolder = "MR. IZUKU MIDORIYA",
                .CVC = 233,
                .ExpireDate = DateTime.Now.AddYears(2),
                .Number = "1234-1234-1234"
            },
            New Card With {
                .Id = 3,
                .CardHolder = "MR. SHOTO TODOROKI",
                .CVC = 788,
                .ExpireDate = DateTime.Now.AddYears(2),
                .Number = "1999-1999-1999-1993"
            }
        }
        People = New List(Of Person) From {
            New Person With {
                .Id = 1,
                .Age = 34,
                .Email = "izuku@gmail.com",
                .Name = "Izuku",
                .Surname = "Midoriya",
                .Cards = New List(Of Card) From {Cards(0), Cards(1)}
            },
            New Person With {
                .Id = 2,
                .Age = 24,
                .Email = "katsumi@gmail.com",
                .Name = "Katsumi",
                .Surname = "Bakugo"
            },
            New Person With {
                .Id = 3,
                .Age = 34,
                .Email = "shoto@gmail.com",
                .Name = "Shoto",
                .Surname = "Todoroki",
                .Cards = New List(Of Card) From {Cards(2)}
            }
        }
        '#End Region
    End Sub
End Class