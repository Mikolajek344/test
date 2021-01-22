Imports AxWMPLib

Public Class Form1
    Private Sub OtwórzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtwórzToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            wmp.URL = OpenFileDialog1.FileName
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
    End Sub



    Private Sub wmp_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles wmp.PlayStateChange
        If Me.wmp.playState = WMPLib.WMPPlayState.wmppsBuffering Or Me.wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then

            ' set trackbar1 min and maximum values

            Me.TrackBar2.Minimum = 0

            Me.TrackBar2.Maximum = Me.wmp.currentMedia.duration

            Me.Timer1.Start()

        ElseIf Me.wmp.playState = WMPLib.WMPPlayState.wmppsMediaEnded Or Me.wmp.playState = WMPLib.WMPPlayState.wmppsStopped Then

            Me.TrackBar2.Value = 0

            Me.Timer1.Stop()

        End If
    End Sub

    Private Sub wmp_Enter(sender As Object, e As EventArgs) Handles wmp.Enter

    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll

        Me.wmp.Ctlcontrols.currentPosition = Me.TrackBar2.Value

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'adjust trackbar2 value for current media position
        If wmp.playState = WMPLib.WMPPlayState.wmppsPlaying Then

            TrackBar2.Value = wmp.Ctlcontrols.currentPosition

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
        wmp.fullScreen = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.Text = wmp.status()
    End Sub
End Class
