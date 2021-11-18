Public Class Form1

    Dim IPAd As String

    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String

        Return lines(lineNumber - 1)

    End Function



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IPAd = TextBox3.Text

        Dim address As String = "http://ip-api.com/line/" & IPAd & "?fields=17983"
        Dim client As System.Net.WebClient = New System.Net.WebClient()
        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(client.OpenRead(address))


        Dim allLines As List(Of String) = New List(Of String)
        Do While Not reader.EndOfStream
            allLines.Add(reader.ReadLine())
        Loop
        reader.Close()

        If ReadLine(1, allLines) = "fail" Then

            MsgBox("Failed to fetch IP info")

        Else

            Label4.Text = "Country: " & ReadLine(2, allLines)
            Label5.Text = "Country Code: " & ReadLine(3, allLines)
            Label6.Text = "Region: " & ReadLine(5, allLines)
            Label7.Text = "Region Code: " & ReadLine(4, allLines)
            Label8.Text = "City: " & ReadLine(6, allLines)
            Label9.Text = "ZIP Code: " & ReadLine(7, allLines)
            Label10.Text = "ISP: " & ReadLine(8, allLines)
            Label11.Text = "Organisation: " & ReadLine(9, allLines)

        End If

    End Sub
End Class
