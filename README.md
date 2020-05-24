<h1>BasicVLC ~ VLC.Dotnet_Farewell</h1>
<p>BasicVLC is an video player with basic controls that are neccessary needed in any player.
It can be an farewell to VLC.Dotnet (Wonderfull project) as developers wants to replace it with Libvlcsharp.
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
<a href="https://github.com/graysuit/BasicVLC/releases/tag/1">windows binaries</a></p>

<center><img src="https://raw.githubusercontent.com/graysuit/BasicVLC/master/BasicVLC/Images/screenshot.PNG" style="max-width:100%;"></center>
<h1>Events in form1.vb</h1>
<ol>
<li>form1_shown Plays video from CommandLineArgs (Can be associate videos with player)</li>
<li>VlcControl1_VlcLibDirectoryNeeded Generate logs LibVlcLogs.log and set libvlc dir</li>
<li>form1_load refresh volume status</li>
<li>pictureBox2_Click is playbutton</li>
<li>PlayNow() plays video according to situation</li>
<li>TrackBar3_Scroll is for changing volume status</li>
<li>VlcControl1_EndReached sets relaod image in play button and progressbar value to maximum</li>
<li>PictureBox6_Click for Fullscreen/normal screen</li>
<li>Fullscreen() for Fullscreen/normal screen</li>
<li>PlayFile(filename) plays from both URL and filename</li>
<li>VlcControl1_Playing with set total ms of video in label2 after seekbar</li>
<li>PictureBox7_Click will stop and dispose video</li>
<li>ChangeProgress(),ProgressBar1_MouseMove,ProgressBar1_MouseDown changes progress using mouse moves</li>
<li>timer1_Tick sets current video time status in Label1 after every 1 second</li>
<li>timer2_Tick will run in fullscreen mode,used for hiding controls and cursor  after 3 seconds no activity</li>
<li>VlcControl1_DoubleClick to fullscreen</li>
<li>VlcControl1_Click to pause,play,reload</li>
<li>VlcControl1_SizeChanged for setting aspect ratio,Good for removing Blackshadow around sides</li>
<li>pictureBox8_Click to mute/unmute video</li>
<li>OpenToolStripMenuItem1_Click for opeing file path and play</li>
<li>StreamToolStripMenuItem_Click for opeing stream and play</li>
<li>AboutToolStripMenuItem1_Click for opeing about form2</li>
<li>ExitToolStripMenuItem1_Click for exiting</li>
<li>VlcControl1_DragDrop for playing dragged video</li>
<li>VlcControl1_DragEnter for preparing DragDrop event</li>
<li>User32Interop.GetLastInput() returns time of last mouse/keyboard move</li>
</ol>
<h2> Contact me :</h2>
<ul><li>Facebook: <a href="https://fb.com/messages/t/gray.programmerz.5"><b>gray.programmerz.5</b></a></li>
<li>Email: <b><a href="mailto:hackrefisher@gmail.com">hackrefisher@gmail.com</a></b></li>
<li>Website: <a href="https://tiplava.blogspot.com/"><b>tiplava</b></a></li></ul>

[![Gitter](https://badges.gitter.im/ha3kre/community.svg)](https://gitter.im/ha3kre/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

<h1>I Love ALLAH + Holy Prophet + Islam and Pakistan.</h1>
