Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PictureBox1.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & ".jpg")))
            PictureBox2.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & "_full.jpg")))
            WebBrowser1.Url = New Uri("https://supermariomakerbookmark.nintendo.net/courses/" & TextBox1.Text)
        Catch ex As Exception
            MsgBox("Invalid Course ID/Network Error!")
        End Try
    End Sub

    Private Sub CourseData(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Label1.Text = "Name: " & WebBrowser1.DocumentTitle.Replace("SUPER MARIO MAKER BOOKMARK | ", "").Replace(TextBox1.Text, "").Replace(" - ", "")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("Connect you to Internet!")
            End
        End If

        Button1_Click(sender, e)
    End Sub
End Class
