using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMRTTranscription.Models;
using System.Web.Script.Serialization;

namespace GMRTTranscription
{
    public partial class Dashboard : Form
    {
        public static bool MDIFormStatus = false;
        private bool CloseFormStatus = false;
        public Dashboard()
        {
            InitializeComponent();
        }
      
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
            this.Enabled = false;
            NewFileCount();
           
            // CompletedFileCount();
            //InvoiceFileCount();
            //TicketCount();
            this.Enabled = true;
            
        }

        private void NewFileLink_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewFileCount.Text) > 0)
            {
                try
                {
                    NewFilelist df = new NewFilelist();
                    df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");
            }
        }

        private void newFilesMenuLink_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewFileCount.Text) > 0)
            {

                try
                {

                    NewFilelist df = new NewFilelist();
                    df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");
            }
        }

        private void NewVoiceFileLink_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    CompletedFiles df = new CompletedFiles();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void NewVoiceFileMenuLink_Click(object sender, EventArgs e)
        {
            try
            {
                NewVoiceFilelist df = new NewVoiceFilelist();
                df.Show();
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void InvoiceFileLink_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    InvoiceFile df = new InvoiceFile();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void invoiceFilesMenuLink_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    InvoiceFile df = new InvoiceFile();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void ViewTicketsLink_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ViewTickets df = new ViewTickets();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void createViewTicketsMenuLink_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ViewTickets df = new ViewTickets();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void myProfileMenuLink_Click(object sender, EventArgs e)
        {
            try
            {
                MyProfile df = new MyProfile();
                df.Show();
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

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
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
                    Application.Exit();
                    return;
                }

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        //private void NewFileCount()
        //{
        //    try
        //    {
        //        string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
        //        string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
        //        string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
        //        int counter = 0;
        //        var jss = new JavaScriptSerializer();
        //        var dictionary = jss.Deserialize<dynamic>(sResponse);
        //        foreach (Dictionary<string, object> item in dictionary)
        //        {
        //            counter++;
        //        }

        //        lblNewFileCount.Text = "" + counter;
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.ShowErrorDialog(ex.Message.ToString());
        //    }
        //}




        private void NewFileCount()
        {
            try
            {
                //Login API
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                int cnt = 0;
                 
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                int counter = 0;
                int countervoice = 0;
                foreach (Dictionary<string, object> item in dictionary)
                {   
                    string filename = item["filename"] == null ? "" : item["filename"].ToString();                   
                     
                    if (System.IO.Path.GetExtension(filename).Contains("doc") || System.IO.Path.GetExtension(filename).Contains("docx") || System.IO.Path.GetExtension(filename).Contains("pdf"))
                    {
                        counter++;
                    }
                    else
                    {
                        countervoice++;
                    }
                                    
                }

                lblNewFileCount.Text = "" + counter;
                lblNewvoiceFileCount.Text = "" + countervoice;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
            this.Enabled = true;
            

        }
        
        private void CompletedFileCount()
        {
            try
            {
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistuploadfilelist/vendoruploadfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                int counter = 0;
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (Dictionary<string, object> item in dictionary)
                {
                    counter++;
                }
                lblNewvoiceFileCount.Text = "" + counter;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void InvoiceFileCount()
        {
            try
            {
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistinvoicelist/vendorinvoicefilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                int counter = 0;
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (Dictionary<string, object> item in dictionary)
                {
                    counter++;
                }
                lblInvoiceCount.Text = "" + counter;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void TicketCount()
        {
            try
            {
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistticketlist/vendorticketfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                int counter = 0;
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (Dictionary<string, object> item in dictionary)
                {
                    counter++;
                }
                lblTicketCount.Text = "" + counter;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 df = new Form1();
            df.Show();
        }

        private void testFormToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 df = new Form1();
            df.Show();
        }

        private void tableLayoutPanel3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewFileCount.Text) > 0)
            {

                try
                {
                    NewFilelist df = new NewFilelist();    //   NewFile df = new NewFile();
                    df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");

            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
             
               

             
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    ViewTickets df = new ViewTickets();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void tableLayoutPanel6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ViewTickets df = new ViewTickets();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}

        }

        private void tableLayoutPanel5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewvoiceFileCount.Text) >= 0)
            {

                try
                {
                  //  NewVoiceFilelist df = new NewVoiceFilelist();    //   NewFile df = new NewFile();
                  //  df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");
            }
            //try
            //{
            //    CompletedFiles df = new CompletedFiles();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void tableLayoutPanel4_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    InvoiceFile df = new InvoiceFile();
            //    df.Show();
            //}
            //catch (Exception ex)
            //{
            //    Common.ShowErrorDialog(ex.Message.ToString());
            //}
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNewFileCount_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewFileCount.Text) > 0)
            {

                try
                {
                    NewFilelist df = new NewFilelist();    //   NewFile df = new NewFile();
                    df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Delete Later
            //Common.Empty("Temp");
            //Common.Empty("pdf");
        }

        private void lblNewvoiceFileCount_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lbl_newvoicefiles.Text) > 0)
            {

                try
                {
                    //NewVoiceFilelist df = new NewVoiceFilelist();    //   NewFile df = new NewFile();
                    //df.Show();
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No File Assigned for Transcribe.!!!");
            }
        }
    }
}
