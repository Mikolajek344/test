Imports TagLib.Id3v2
Imports AxWMPLib
Imports System.IO



Public Class Form1
    Private Sub OtwórzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtwórzToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            wmp.URL = OpenFileDialog1.FileName
            Label2.Text = wmp.currentMedia.name
            Timer1.Start()
            PictureBox1.Show()
            Dim file As TagLib.File = TagLib.File.Create(OpenFileDialog1.FileName.ToString)
            If (file.Tag.Pictures.Length > 0) Then
                Dim bin = CType(file.Tag.Pictures(0).Data.Data, Byte())
                PictureBox1.Image = Image.FromStream(New MemoryStream(bin)).GetThumbnailImage(600, 600, Nothing, IntPtr.Zero)
            Else
                PictureBox1.Hide()
            End If
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub AxWindowsMediaPlayer_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        wmp.Ctlcontrols.pause()
        Button2.Hide()
        Button3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        wmp.Ctlcontrols.play()
        Button3.Hide()
        Button2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        wmp.Ctlcontrols.stop()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        wmp.settings.volume = TrackBar1.Value
        If TrackBar1.Value = "0" Then
            wmp.settings.volume = 0
            Button4.Show()
            Button1.Hide()
        Else
            wmp.settings.volume = TrackBar1.Value
            Button1.Show()
            Button4.Hide()
        End If
    End Sub



    Private Sub wmp_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent)
        If Me.wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Timer1.Start()
        ElseIf Me.wmp.playState = WMPLib.WMPPlayState.wmppsMediaEnded Or Me.wmp.playState = WMPLib.WMPPlayState.wmppsStopped Then
            Me.TrackBar2.Value = 0
            Me.Timer1.Stop()
        End If
        If wmp.windowlessVideo = True Then
            wmp.uiMode = "none"
        End If
    End Sub

    Private Sub wmp_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs)

        Me.wmp.Ctlcontrols.currentPosition = Me.TrackBar2.Value

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Cur As Integer = wmp.Ctlcontrols.currentPosition
        Dim Len As Integer = wmp.currentMedia.duration
        TrackBar2.Value = Cur
        TrackBar2.Maximum = wmp.currentMedia.duration
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TrackBar1.Value = 30 Or 50
        wmp.settings.volume = TrackBar1.Value
        Button1.Show()
        Button4.Hide()
        If TrackBar1.Value = 0 Then
            Button4.Show()
            Button1.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        wmp.settings.volume = 0
        TrackBar1.Value = 0
        Button4.Show()
        Button1.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        wmp.Ctlcontrols.fastForward()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        wmp.Ctlcontrols.fastReverse()
    End Sub

    Private Sub TwórcaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PełnyEkranToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WłączPełnyEkranToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wmp.Dock = DockStyle.Fill
    End Sub

    Private Sub WyłączPełnyEkranToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wmp.Dock = DockStyle.None
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PełnyEkranToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PlayListaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click_3(sender As Object, e As EventArgs)
        wmp.fullScreen = True
    End Sub

    Private Sub Button8_Click_4(sender As Object, e As EventArgs) Handles Button8.Click
        wmp.uiMode = "full"
        wmp.fullScreen = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.Text = wmp.status()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub wmp_SwitchedToControl(sender As Object, e As EventArgs) Handles wmp.SwitchedToControl

    End Sub

    Private Sub wmp_Resize(sender As Object, e As EventArgs) Handles wmp.Resize

    End Sub
End Class
