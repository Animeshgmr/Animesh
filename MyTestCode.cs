using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace GMRTTranscription
{
    public partial class MyTestCode : Form
    {

     public   string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
        public bool gb_playstartonce = false;

        public MyTestCode()
        {
            InitializeComponent();
        }

        private void MyTestCode_Load(object sender, EventArgs e)
        {          
            windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
            windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
            string DirectoryName = windowsInstallPath + "\\documents\\Temp\\";         
            voiceplayer.URL = DirectoryName + "990_TEST_GMR_july_july_3.mp3";
            volumebar.Value = voiceplayer.settings.volume;
            voiceplayer.Ctlcontrols.play();
            pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;
            WindowsMediaPlayerClass wmp = new WindowsMediaPlayerClass();
            IWMPMedia mediaInfo = wmp.newMedia(DirectoryName + "990_TEST_GMR_july_july_3.mp3");          
            lbl_totalduration.Text = GMRTTranscription.Models.Common.GetHMSfromSecond(mediaInfo.duration);
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition -= 5;
        }

        private void volumebar_Scroll(object sender, EventArgs e)
        {
            voiceplayer.settings.volume = volumebar.Value;
        }
     
        private void pic_playpause_Click(object sender, EventArgs e)
        {
            if (voiceplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                voiceplayer.Ctlcontrols.pause();              
                pic_playpause.Image = GMRTTranscription.Properties.Resources.play1;
            }

            else if (voiceplayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                voiceplayer.Ctlcontrols.play();
                pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;
                 
            }

            else if (pic_playpause.Image == GMRTTranscription.Properties.Resources.play1 && gb_playstartonce == false)
            {
                voiceplayer.Ctlcontrols.play();
                pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;                
                gb_playstartonce = true;
                volumebar.Value = voiceplayer.settings.volume;
            }
        }

        private void MyTestCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Escape))
            {
                pic_playpause_Click(sender, e);               
            }

        }       

        private void lbl_speed_MouseHover(object sender, EventArgs e)
        {
            playbackspeed.Visible = true;
        }

     

        private void playbackspeed_Scroll(object sender, EventArgs e)
        {
            voiceplayer.settings.rate = playbackspeed.Value;
            voiceplayer.Ctlcontrols.play();
            pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;
        }

        private void playbackspeed_Leave(object sender, EventArgs e)
        {
            playbackspeed.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerstatusbar.Value = (int)voiceplayer.Ctlcontrols.currentPosition;
            lbl_playduration.Text = GMRTTranscription.Models.Common.GetHMSfromSecond(voiceplayer.Ctlcontrols.currentPosition);
        }

        private void voiceplayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                double dur = voiceplayer.currentMedia.duration;
                playerstatusbar.Maximum = (int)dur;
            }
        }

        private void playerstatusbar_Scroll(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition = (int)playerstatusbar.Value;
        }
    }
}
