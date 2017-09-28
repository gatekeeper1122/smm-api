Imports System.IO
Imports System.Net

Public Class Form1
    Dim wc As New WebClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            CourseData()
        Catch ex As Exception
            MsgBox("An error has ocurred.")
            Visible = True
        End Try
    End Sub

    Private Sub CourseData()
        Visible = False
        Dim tmpPath As String = Path.GetTempFileName
        wc.DownloadFile("http://www.blar.de/smm/fetch?code=" & TextBox1.Text, tmpPath)
        Dim _c() As String = IO.File.ReadAllLines(tmpPath)
        Dim _cTitle As String = _c(3).Replace("<title>", "").Replace("</title>", "")
        Dim _cImg1 As Bitmap = New Bitmap(New IO.MemoryStream(wc.DownloadData(_c(4).Replace("<cover>", "").Replace("</cover>", ""))))
        Dim _cImg2 As Bitmap = New Bitmap(New IO.MemoryStream(wc.DownloadData(_c(5).Replace("<map>", "").Replace("</map>", ""))))
        Dim _cType As String = _c(6).Replace("<type>", "").Replace("</type>", "")
        Dim _cDifficulty As String = _c(7).Replace("<difficulty>", "").Replace("</difficulty>", "")
        Dim _cCreated As String = _c(8).Replace("<created>", "").Replace("</created>", "")
        Dim _cStatsTried As String = _c(10).Replace("<tried>", "").Replace("</tried>", "")
        Dim _cStatsSolved As String = _c(11).Replace("<solved>", "").Replace("</solved>", "")
        Dim _cStatsPlayed As String = _c(12).Replace("<played>", "").Replace("</played>", "")
        Dim _cStatsRated As String = _c(13).Replace("<rated>", "").Replace("</rated>", "")
        Dim _cStatsShared As String = _c(14).Replace("<shared>", "").Replace("</shared>", "")
        Dim _cStatsClearRate As String = _c(15).Replace("<clear-rate>", "").Replace("</clear-rate>", "") & " % "
        Dim _cStatsComments As String = _c(16).Replace("<comments>", "").Replace("</comments>", "")
        Dim _cCreatorName As String = _c(20).Replace("<name>", "").Replace("</name>", "")
        Dim _cCreatorImg As Bitmap = New Bitmap(New IO.MemoryStream(wc.DownloadData(_c(21).Replace("<avatar>", "").Replace("</avatar>", ""))))
        Dim _cCreatorBookmarkURL As String = _c(22).Replace("<url>", "").Replace("</url>", "")
        Dim _cFirstName As String = _c(27).Replace("<name>", "").Replace("</name>", "")
        Dim _cFirstImg As Bitmap = New Bitmap(New IO.MemoryStream(wc.DownloadData(_c(28).Replace("<avatar>", "").Replace("</avatar>", ""))))
        Dim _cFirstBookmarkURL As String = _c(29).Replace("<url>", "").Replace("</url>", "")
        Dim _cRecordName As String = _c(34).Replace("<name>", "").Replace("</name>", "")
        Dim _cRecordImg As Bitmap = New Bitmap(New IO.MemoryStream(wc.DownloadData(_c(35).Replace("<avatar>", "").Replace("</avatar>", ""))))
        Dim _cRecordBookmarkURL As String = _c(36).Replace("<url>", "").Replace("</url>", "")
        Dim _cRecordTime As String = _c(37).Replace("<duration>", "").Replace("</duration>", "")
        cData.Text = "Title:" & _cTitle & vbNewLine & "Type:" & _cType & vbNewLine & "Difficulty:" & _cDifficulty & vbNewLine & "Created:" & _cCreated & vbNewLine & "Tried:" & _cStatsTried & vbNewLine & "Solved:" & _cStatsSolved & vbNewLine & "Played:" & _cStatsPlayed & vbNewLine & "Rated:" & _cStatsRated & vbNewLine & "Shared:" & _cStatsShared & vbNewLine & "Clear Rate:" & _cStatsClearRate & vbNewLine & "Comments:" & _cStatsComments
        Label1.Text = "Mii Name:" & _cRecordName & vbNewLine & "Duration:" & _cRecordTime
        Label2.Text = "Name:" & _cCreatorName
        Label3.Text = "Mii Name:" & _cFirstName
        LinkLabel1.Tag = _cCreatorBookmarkURL
        LinkLabel2.Tag = _cRecordBookmarkURL
        LinkLabel3.Tag = _cFirstBookmarkURL
        LinkLabel4.Tag = "https://supermariomakerbookmark.nintendo.net/courses/" & TextBox1.Text
        PictureBox1.Image = _cImg1
        PictureBox2.Image = _cImg2
        PictureBox3.Image = _cCreatorImg
        PictureBox4.Image = _cRecordImg
        PictureBox5.Image = _cFirstImg
        My.Computer.FileSystem.DeleteFile(tmpPath)
        Visible = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("Connect you to Internet!")
            End
        End If

        Button1_Click(sender, e)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Clipboard.SetText(LinkLabel2.Tag)
        MsgBox("URL copied.")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Clipboard.SetText(LinkLabel1.Tag)
        MsgBox("URL copied.")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Clipboard.SetText(LinkLabel3.Tag)
        MsgBox("URL copied.")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Clipboard.SetText(LinkLabel4.Tag)
        MsgBox("URL copied.")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Image.Save("img1.jpg", Imaging.ImageFormat.Jpeg)
        MsgBox("Saved to img1.jpg.")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PictureBox2.Image.Save("img2.jpg", Imaging.ImageFormat.Jpeg)
        MsgBox("Saved to img2.jpg.")
    End Sub
End Class
