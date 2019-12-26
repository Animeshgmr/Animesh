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
    public partial class CompletedFiles : Form
    {
        public CompletedFiles()
        {
            InitializeComponent();
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                //Login API
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistuploadfilelist/vendoruploadfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);

                DataTable dt = new DataTable("InvoiceLists");
                dt.Columns.Add("fileid", Type.GetType("System.String"));
                dt.Columns.Add("po_id", Type.GetType("System.String"));
                dt.Columns.Add("customer_id", Type.GetType("System.String"));
                dt.Columns.Add("File Name", Type.GetType("System.String"));
                dt.Columns.Add("Word Count", Type.GetType("System.String"));
                dt.Columns.Add("Download URL", Type.GetType("System.String"));
                dt.Columns.Add("Dead Line Date", Type.GetType("System.String"));
                dt.Columns.Add("Dead Line Time", Type.GetType("System.String"));
                dt.Columns.Add("Pay Rate", Type.GetType("System.String"));
                dt.Columns.Add("Instruction", Type.GetType("System.String"));
                dt.Columns.Add("TAT", Type.GetType("System.String"));
                DataRow dr = null;

                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (Dictionary<string, object> item in dictionary)
                {

                    string fileid = item["fileid"] == null ? "0" : item["fileid"].ToString();
                    string po_id = item["po_id"] == null ? "0" : item["po_id"].ToString();
                    string customer_id = item["customer_id"] == null ? "0" : item["customer_id"].ToString();
                    string filename = item["filename"] == null ? "" : item["filename"].ToString();
                    string duration = item["duration"] == null ? "0" : item["duration"].ToString();
                    string downloadurl = item["downloadurl"] == null ? "" : item["downloadurl"].ToString();
                    string deadlinedate = item["deadlinedate"] == null ? "" : item["deadlinedate"].ToString();
                    string deadlinetime = item["deadlinetime"] == null ? "" : item["deadlinetime"].ToString();
                    string payrate = item["payrate"] == null ? "0" : item["payrate"].ToString();
                    string instrcution = item["instrcution"] == null ? "" : item["instrcution"].ToString();
                    string eservice = item["eservice"] == null ? "" : item["eservice"].ToString();
                    string po_tat = item["po_tat"] == null ? "" : item["po_tat"].ToString();

                    dr = dt.NewRow();
                    dr["fileid"] = fileid;
                    dr["po_id"] = po_id;
                    dr["customer_id"] = customer_id;
                    dr["File Name"] = filename;
                    dr["Word Count"] = duration;
                    dr["Download URL"] = downloadurl;
                    dr["Dead Line Date"] = deadlinedate;
                    dr["Dead Line Time"] = deadlinetime;
                    dr["Pay Rate"] = String.Format("${0:#0.00}", payrate);
                    dr["Instruction"] = instrcution;
                    dr["TAT"] = po_tat;
                    dt.Rows.Add(dr);
                }



                invoiceGrid.DataSource = dt;
                invoiceGrid.Columns[0].Visible = false;
                invoiceGrid.Columns[1].Visible = false;
                invoiceGrid.Columns[2].Visible = false;
                invoiceGrid.Columns[5].Visible = false;

                invoiceGrid.Columns[3].Width = 300;
                invoiceGrid.Columns[10].Width = 300;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
