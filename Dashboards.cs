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
    public partial class Dashboards : Form
    {
      
        public Dashboards()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        
        private void Dashboards_Load(object sender, EventArgs e)
        {
           
            this.Enabled = false;
            NewFileCount();

            // CompletedFileCount();
            //InvoiceFileCount();
            //TicketCount();
            this.Enabled = true;
            
        }

        private void NewFileCount()
        {
            try
            {
                //Login API
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
               

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

        private void NewFileLink_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(lblNewFileCount.Text) > 0)
            {
                try
                {
                    NewFilelist df = new NewFilelist();
                    //df.MdiParent = this.MdiParent;
                    //df.Show();
                    MDIForm.ChildForm(df);
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
            if (Convert.ToInt64(lblNewvoiceFileCount.Text) > 2)
            {
                try
                {
                    NewVoiceFilelist df = new NewVoiceFilelist();
                    //df.MdiParent = this.MdiParent;
                    //df.Show();
                    MDIForm.ChildForm(df);
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog(ex.Message.ToString());
                }
            }
            else
            {
                Common.ShowInformationDialog("No VoiceFile Assigned for Transcribe.!!!");
            }
        }
    }
}
