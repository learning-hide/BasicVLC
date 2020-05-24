Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Vlc.DotNet.Core.Interops
Public Class Form1
    Private Sub form1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'If someone associated videos with BasicVLC
        'Or video dragged on player icon
        'Then check whether path correct and play
        If My.Application.CommandLineArgs.Count = 1 Then
            If File.Exists(My.Application.CommandLineArgs(0)) Then
                PlayFile(My.Application.CommandLineArgs(0))
            End If
        End If
    End Sub

    Private Sub VlcControl1_VlcLibDirectoryNeeded(sender As Object, e As Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs) Handles VlcControl1.VlcLibDirectoryNeeded
        'It will generate logs
        'Helpfull in reporting issues
        VlcControl1.VlcMediaplayerOptions = {"--file-logging", "-vvv", "--logfile=LibVlcLogs.log"}

        'These lines will set libvlc dir
        Dim currentAssembly = Assembly.GetEntryAssembly()
        Dim currentDirectory = New FileInfo(currentAssembly.Location).DirectoryName
        'e.VlcLibDirectory = New DirectoryInfo(currentDirectory) 'I used this for binaries
        e.VlcLibDirectory = New DirectoryInfo(Path.Combine(currentDirectory.ToString, "libvlc", If(IntPtr.Size = 4, "win-x86", "win-x64"))) 'Mostly people use this
    End Sub
    Private Sub form1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Refresh volume status
        TrackBar3.Value = VlcControl1.Audio.Volume
        Label3.Text = TrackBar3.Value & "%"
    End Sub

    Private Sub pictureBox2_Click(sender As Object, e As EventArgs) Handles pictureBox2.Click
        'PLay Button
        If VlcControl1.GetCurrentMedia IsNot Nothing Then PlayNow()
    End Sub
    Sub PlayNow()
        Try
            If VlcControl1.State = Signatures.MediaStates.Playing Then 'If Video is already playing then pause
                VlcControl1.Pause()
                pictureBox2.Image = My.Resources.pause
                timer1.Enabled = False

            ElseIf VlcControl1.State = Signatures.MediaStates.Ended Then 'Else If Video is ended then play again
                PlayFile(My.Settings.filename)
                timer1.Enabled = True
                VlcControl1.Video.AspectRatio = VlcControl1.Width & ":" & VlcControl1.Height
            Else 'Else play 
                pictureBox2.Image = My.Resources.play
                VlcControl1.VlcMediaPlayer.Play()
                ProgressBar1.Maximum = VlcControl1.GetCurrentMedia.Duration.TotalMilliseconds
                timer1.Enabled = True
                VlcControl1.Video.AspectRatio = VlcControl1.Width & ":" & VlcControl1.Height
            End If
            'Gets total video duration and insert into label2 like 00:54
            Dim t As TimeSpan = TimeSpan.FromMilliseconds(VlcControl1.GetCurrentMedia.Duration.TotalMilliseconds)
            label2.Text = String.Format("{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        VlcControl1.Audio.Volume = TrackBar3.Value
        Label3.Text = TrackBar3.Value & "%"
    End Sub
    Private Sub VlcControl1_EndReached(sender As Object, e As Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs) Handles VlcControl1.EndReached
        'As video ended then set relaod image and progressbar value to maximum
        pictureBox2.Image = My.Resources.reload
        ProgressBar1.Value = ProgressBar1.Maximum
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'Fullscreen button click
        'If is there any video then full screen or normal screen
        If VlcControl1.GetCurrentMedia IsNot Nothing Then Fullscreen()
    End Sub

    Sub Fullscreen()
        If Me.FormBorderStyle = FormBorderStyle.Sizable Then 'If form has default border
            'Then fullscreen
            WindowState = FormWindowState.Normal
            MenuStrip1.Visible = False
            FormBorderStyle = FormBorderStyle.None
            WindowState = FormWindowState.Maximized
            PictureBox6.Image = My.Resources.exit_full
            Timer2.Enabled = True
        Else
            'Else normal screen
            MenuStrip1.Visible = True
            FormBorderStyle = FormBorderStyle.Sizable
            PictureBox6.Image = My.Resources.full
            WindowState = FormWindowState.Normal
            PictureBox6.Visible = True
            Timer2.Enabled = False
        End If
    End Sub

    Sub PlayFile(filename) 'Plays video from filepath or URL
        'Saves filename path
        'Helpfull in playing again when video ended
        My.Settings.filename = filename
        My.Settings.Save()
        If VlcControl1.GetCurrentMedia IsNot Nothing Then VlcControl1.ResetMedia() 'If video found then dispose it
        Try
            VlcControl1.Play(If(filename.contains("http") Or filename.contains("://"), New Uri(filename), New FileInfo(filename))) 'Checking whether it is URL or filepath
            pictureBox2.Image = My.Resources.play
            timer1.Enabled = True  'Timer will change time taken every after 1 second like 00:51
            VlcControl1.Video.IsKeyInputEnabled = False
            VlcControl1.Video.IsMouseInputEnabled = False
            VlcControl1.Video.AspectRatio = VlcControl1.Width & ":" & VlcControl1.Height
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub VlcControl1_Playing(sender As Object, e As Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs) Handles VlcControl1.Playing
        'On playing video
        'Sets the progressbar maximum value
        'And also label2
        ProgressBar1.Maximum = VlcControl1.GetCurrentMedia.Duration.TotalMilliseconds
        Dim t As TimeSpan = TimeSpan.FromMilliseconds(VlcControl1.GetCurrentMedia.Duration.TotalMilliseconds)
        label2.Text = String.Format("{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        'Stop button
        'Onclick it will dispose video
        If VlcControl1.GetCurrentMedia IsNot Nothing Then
            timer1.Enabled = False
            VlcControl1.Stop()
            VlcControl1.ResetMedia()
            ProgressBar1.Value = 1
            Label1.Text = "00:00"
            pictureBox2.Image = My.Resources.pause
        End If
    End Sub
    Private Sub ChangeProgress(bar As ProgressBar, e As MouseEventArgs)
        'It will change progressbar value
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim mousepos = Math.Min(Math.Max(e.X, 0), bar.ClientSize.Width)
            Dim value = CInt(bar.Minimum + (bar.Maximum - bar.Minimum) * mousepos / bar.ClientSize.Width)
            If value > bar.Value And value < bar.Maximum Then
                bar.Value = value + 1
                bar.Value = value
            Else
                bar.Value = value
            End If
            If VlcControl1.GetCurrentMedia IsNot Nothing Then VlcControl1.Time = ProgressBar1.Value
        End If
    End Sub

    Private Sub ProgressBar1_MouseMove(sender As Object, e As MouseEventArgs) Handles ProgressBar1.MouseMove
        'If some move mouse on ProgressBar1
        'Then change progress
        ChangeProgress(ProgressBar1, e)
    End Sub

    Private Sub ProgressBar1_MouseDown(sender As Object, e As MouseEventArgs) Handles ProgressBar1.MouseDown
        'If some move down on ProgressBar1
        'Then change progress
        ChangeProgress(ProgressBar1, e)
    End Sub
    Private Sub timer1_Tick(sender As Object, e As EventArgs) Handles timer1.Tick
        'Timer will change time taken every after 1 second like 00:51
        If VlcControl1.GetCurrentMedia IsNot Nothing And Not VlcControl1.Time > ProgressBar1.Maximum And Not VlcControl1.Time <= 0 Then ProgressBar1.Value = VlcControl1.Time
        Dim t = TimeSpan.FromMilliseconds(VlcControl1.Time)
        Label1.Text = String.Format("{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)
    End Sub

    Private activityTimer As Timer = New Timer()
    Private activityThreshold As TimeSpan = TimeSpan.FromSeconds(3)
    Private cursorHidden As Boolean = False
    Public shouldHide As Boolean
    Private Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
    Private Sub Timer2_Tick() Handles Timer2.Tick
        'This timer is for hiding controls and cursor 
        'After every 3 seconds when no mouse movement
        If FormBorderStyle = FormBorderStyle.None And VlcControl1.GetCurrentMedia IsNot Nothing Then
            shouldHide = GetLastInput() > activityThreshold
            If cursorHidden <> shouldHide Then
                If shouldHide Then
                    ShowCursor(False)
                    Panel1.Visible = False
                    TableLayoutPanel1.RowCount = 1
                Else
                    ShowCursor(True)
                    Panel1.Visible = True
                    TableLayoutPanel1.RowCount = 2
                End If
                cursorHidden = shouldHide
            End If
        Else
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub VlcControl1_DoubleClick(sender As Object, e As EventArgs) Handles VlcControl1.DoubleClick
        'If someone double clicks on Video 
        'then fullscreen or normal screen
        'Also play again
        If VlcControl1.GetCurrentMedia IsNot Nothing Then
            Fullscreen()
            PlayNow()
        End If
    End Sub

    Private Sub VlcControl1_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles VlcControl1.Click
        'If someone single clicks on Video 
        'then play or pause
        If VlcControl1.GetCurrentMedia IsNot Nothing Then
            If e.Button = MouseButtons.Left Then
                PlayNow()
            End If
        End If
    End Sub

    Private Sub VlcControl1_SizeChanged(sender As Object, e As EventArgs) Handles VlcControl1.SizeChanged
        'if form width/height changed
        'Then make video aspect ratio according to width/height
        If VlcControl1.GetCurrentMedia IsNot Nothing Then
            VlcControl1.Video.AspectRatio = VlcControl1.Width & ":" & VlcControl1.Height
        End If
    End Sub

    Private Sub pictureBox8_Click(sender As Object, e As EventArgs) Handles pictureBox8.Click
        'Speaker/Volume Button click
        If VlcControl1.Audio.IsMute = True Then
            VlcControl1.Audio.IsMute = False
            pictureBox8.Image = My.Resources.volume
        Else
            VlcControl1.Audio.IsMute = True
            pictureBox8.Image = My.Resources.mute
        End If
    End Sub

    '1) Open button
    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem4.Click
        Dim o As New OpenFileDialog With {.Multiselect = False}
        If o.ShowDialog = DialogResult.OK Then
            PlayFile(o.FileName)
        End If
    End Sub

    '2) Stream button
    Private Sub StreamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StreamToolStripMenuItem.Click
        Dim URL = InputBox("http://example.com/sample-video.mp4")
        If Not URL = Nothing Then
            PlayFile(URL)
        End If
    End Sub

    '3) About button
    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem4.Click
        Form2.Show()
    End Sub

    '4) Exit button
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem4.Click
        Application.Exit()
    End Sub

    Private Sub VlcControl1_DragDrop(sender As Object, e As DragEventArgs) Handles VlcControl1.DragDrop
        'When dragged any video
        'Then play that video
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            PlayFile(filePaths(0))
        End If
    End Sub
    Private Sub VlcControl1_DragEnter(sender As Object, e As DragEventArgs) Handles VlcControl1.DragEnter
        'When trying to drag any video
        'Then prepare for dropping
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

End Class
Module User32Interop
    'It returns time of last mouse/keyboard move
    Public Function GetLastInput() As TimeSpan
        Dim plii = New LASTINPUTINFO()
        plii.cbSize = CUInt(Marshal.SizeOf(plii))
        If GetLastInputInfo(plii) Then
            Return TimeSpan.FromMilliseconds(Environment.TickCount - plii.dwTime)
        Else
            Throw New ComponentModel.Win32Exception(Marshal.GetLastWin32Error())
        End If
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Private Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function
    Structure LASTINPUTINFO
        Public cbSize As UInteger
        Public dwTime As UInteger
    End Structure
End Module