Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PictureBox1.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & ".jpg")))
            PictureBox2.Image = New Bitmap(New IO.MemoryStream(New WebClient().DownloadData("https://dypqnhofrd2x2.cloudfront.net/" & TextBox1.Text & "_full.jpg")))
        Catch ex As Exception
            MsgBox("Invalid Course ID!")
        End Try
    End Sub
End Class
