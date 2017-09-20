Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PictureBox1.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & ".jpg")))
            PictureBox2.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & "_full.jpg")))
            Label1.Text = "Getting name..."
            WebBrowser1.Url = New Uri("https://supermariomakerbookmark.nintendo.net/courses/" & TextBox1.Text)
        Catch ex As Exception
            MsgBox("Invalid Course ID!")
        End Try
    End Sub

    Private Sub CourseData(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Label1.Text = WebBrowser1.DocumentTitle.Replace("SUPER MARIO MAKER BOOKMARK | ", "").Replace(TextBox1.Text, "").Replace(" - ", "")
    End Sub
End Class
