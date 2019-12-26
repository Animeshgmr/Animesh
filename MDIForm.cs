using GMRTTranscription.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GMRTTranscription
{
    public partial class MDIForm : Form
    {
        private int childFormNumber = 0;

        public MDIForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();


        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void newFilesMenuLink_Click(object sender, EventArgs e)
        {
            //Common.CheckOpened("Dashboards");
            //Common.CheckOpened("NewFile");
            //Common.CheckOpened("MyProfile");
            //NewFilelist newMDIChild = new NewFilelist();
            //// Set the Parent Form of the Child window.
            //newMDIChild.MdiParent =this;
            //// Display the new form.
            //newMDIChild.Show();
            //newMDIChild.BringToFront();

            NewFilelist form = new NewFilelist();
            OpenFormInTab(form);
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Common.CheckOpened("NewFilelist");
            //Common.CheckOpened("NewFile");
            //Common.CheckOpened("MyProfile");
            //Dashboards newMDIChild = new Dashboards();
            //// Set the Parent Form of the Child window.
            //newMDIChild.MdiParent = this;
            //// Display the new form.
            //newMDIChild.Show();
            //newMDIChild.BringToFront();

            Dashboards form = new Dashboards();
            OpenFormInTab(form);
        }

        private void MDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing) // Prompt user to save his data                
                {
                    var confirmResult = MessageBox.Show("Are you sure want to close this application?", "Confirmation!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (confirmResult != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (confirmResult == DialogResult.Yes)
                    {
                        Application.Exit();
                        //Delete Later
                        Common.Empty("Temp");
                        Common.Empty("pdf");

                    }
                }

                if (e.CloseReason == CloseReason.WindowsShutDown) // Autosave and clear up ressources                    
                {
                    Common.Empty("Temp");
                    Common.Empty("pdf");
                    Application.Exit();
                   
                    return;
                }

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void myProfileMenuLink_Click(object sender, EventArgs e)
        {
            try
            {
                //MyProfile df = new MyProfile();
                //df.MdiParent = this;
                //df.Show();
                MyProfile form = new MyProfile();
                OpenFormInTab(form);
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void logOutMenuLink_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure want to logout?", "Confirmation!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    this.Hide();                    
                    Login_Form df = new Login_Form();
                    df.Show();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            //Dashboards mfdash = new Dashboards();
            //mfdash.MdiParent = this;
            //mfdash.Show(this);
            tabControl1.Cursor = Cursors.Arrow;
            Dashboards form = new Dashboards();
            form.TopLevel = false;
            form.Visible = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(form.Text);
            int count = tabControl1.TabCount;
            tabControl1.TabPages[count - 1].Controls.Add(form);
            tabControl1.SelectedTab = tabControl1.TabPages[count - 1];
            tabControl1.TabPages.RemoveAt(0);
        }

        private void NewVoiceFileMenuLink_Click(object sender, EventArgs e)
        {
            try
            {
                //Common.CheckOpened("Dashboards");
                //Common.CheckOpened("NewFilelist");
                //Common.CheckOpened("NewFile");
                //Common.CheckOpened("MyProfile");
                //NewVoiceFilelist df = new NewVoiceFilelist();
                //df.MdiParent = this;
                //df.Show();
                //df.BringToFront();
                NewVoiceFilelist frm = new NewVoiceFilelist();
                OpenFormInTab(frm);

                //Common.CheckOpened("NewFile");
                //Common.CheckOpened("MyProfile");

                //Dashboards newMDIChild = new Dashboards();
                //// Set the Parent Form of the Child window.
                //newMDIChild.MdiParent = this;
                //// Display the new form.
                //newMDIChild.Show();
                //newMDIChild.BringToFront();
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }



        //custom method for tab implementation by anup
        public static void ChildForm(Form form)
        {
            OpenFormInTab(form);
        }

        public static void OpenFormInTab(Form frm)
        {
            int flag = 0;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text.Equals(frm.Text))
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.IndexOf(tp)];
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                tabControl1.TabPages.Add(frm.Text);
                int count = tabControl1.TabCount;
                tabControl1.TabPages[count - 1].Controls.Add(frm);
                tabControl1.SelectedTab = tabControl1.TabPages[count - 1];
            }
        }

        public static void CloseTab()
        {
            //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            tabControl1.SelectedTab.Dispose();
            tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];
        }
    }
}
