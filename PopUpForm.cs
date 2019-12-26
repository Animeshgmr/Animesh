using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMRTTranscription
{
    public partial class PopUpForm : Form
    {
        public PopUpForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void PopUpForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2));
        }

     

        public PopUpForm(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                this.BringToFront();
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2, parent.Location.Y + parent.Height / 2 - this.Height / 2);
              
                
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }
        public void CloseLoadingForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (lbl_process.Image != null)
            {
                lbl_process.Image.Dispose();
            }


        }

        public void SetProcess(string Processinfo)
        {
            lbl_process.Text = Processinfo;


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void lbl_process_Click(object sender, EventArgs e)
        {

        }
    }
}
