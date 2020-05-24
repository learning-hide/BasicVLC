<h1>BasicVLC ~ VLC.Dotnet_Farewell</h1>
<p><b>BasicVLC</b> is an video player with basic controls that are neccessary needed in any player.
It can be an farewell to <b><a href="https://github.com/ZeBobo5/Vlc.DotNet">VLC.Dotnet</a></b> (Wonderfull project) as developers wants to replace it with <b><a href="https://github.com/videolan/libvlcsharp">Libvlcsharp</a></b>.
This player can be used as sample of VLC.Dotnet or Libvlc.
It is specially designed for developers with comments but windows users can also use it.
BasicVLC uses VLC.Dotnet that is wrapper around Libvlc (Library provided by Videolan ~ THANKS)</p>
<center><img src="https://raw.githubusercontent.com/graysuit/BasicVLC/master/BasicVLC/Images/icon.PNG"></center>
<h1>Clone it now:</h1>
<code><pre>git clone https://github.com/graysuit/BasicVLC.git</pre></code>
<h1>Download for windows:</h1>
<p>Don't need to code,<br>
Don't build anything,<br>
We already build it for you,<br>
Just test and try it now.<br>
<a href="https://github.com/graysuit/BasicVLC/releases">windows binaries</a></p>
<center><img src="https://raw.githubusercontent.com/graysuit/BasicVLC/master/BasicVLC/Images/screenshot.PNG" style="max-width:100%;"></center>
<h1>Events in form1.vb</h1>
<ol>
<li><b>form1_shown</b> Plays video from CommandLineArgs (Can be associate videos with player)</li>
<li><b>VlcControl1_VlcLibDirectoryNeeded</b> Generate logs LibVlcLogs.log and set libvlc dir</li>
<li><b>form1_load</b> refresh volume status</li>
<li><b>pictureBox2_Click</b> is playbutton</li>
<li><b>PlayNow()</b> plays video according to situation</li>
<li><b>TrackBar3_Scroll</b> is for changing volume status</li>
<li><b>VlcControl1_EndReached</b> sets relaod image in play button and progressbar value to maximum</li>
<li><b>PictureBox6_Click</b> for Fullscreen/normal screen</li>
<li><b>Fullscreen()</b> for Fullscreen/normal screen</li>
<li><b>PlayFile(filename)</b> plays from both URL and filename</li>
<li><b>VlcControl1_Playing</b> with set total ms of video in label2 after seekbar</li>
<li><b>PictureBox7_Click</b> will stop and dispose video</li>
<li><b>ChangeProgress(),ProgressBar1_MouseMove,ProgressBar1_MouseDown</b> changes progress using mouse moves</li>
<li><b>timer1_Tick</b> sets current video time status in Label1 after every 1 second</li>
<li><b>timer2_Tick</b> will run in fullscreen mode,used for hiding controls and cursor  after 3 seconds no activity</li>
<li><b>VlcControl1_DoubleClick</b> to fullscreen</li>
<li><b>VlcControl1_Click</b> to pause,play,reload</li>
<li><b>VlcControl1_SizeChanged</b> for setting aspect ratio,Good for removing Blackshadow around sides</li>
<li><b>pictureBox8_Click</b> to mute/unmute video</li>
<li><b>OpenToolStripMenuItem1_Click</b> for opeing file path and play</li>
<li><b>StreamToolStripMenuItem_Click</b> for opeing stream and play</li>
<li><b>AboutToolStripMenuItem1_Click</b> for opeing about form2</li>
<li><b>ExitToolStripMenuItem1_Click</b> for exiting</li>
<li><b>VlcControl1_DragDrop</b> for playing dragged video</li>
<li><b>VlcControl1_DragEnter</b> for preparing DragDrop event</li>
<li><b>User32Interop.GetLastInput()</b> returns time of last mouse/keyboard move</li>
</ol>
<h2> Contact me :</h2>
<ul><li>Facebook: <a href="https://fb.com/messages/t/gray.programmerz.5"><b>gray.programmerz.5</b></a></li>
<li>Email: <b><a href="mailto:hackrefisher@gmail.com">hackrefisher@gmail.com</a></b></li>
<li>Website: <a href="https://tiplava.blogspot.com/"><b>tiplava</b></a></li></ul>

[![Gitter](https://badges.gitter.im/ha3kre/community.svg)](https://gitter.im/ha3kre/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

<h1>I Love ALLAH + Holy Prophet + Islam and Pakistan.</h1>
