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
    public partial class InvoiceFile : Form
    {
        public InvoiceFile()
        {
            InitializeComponent();
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                //Login API
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistinvoicelist/vendorinvoicefilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);

                DataTable dt = new DataTable("InvoiceLists");
                dt.Columns.Add("fileid", Type.GetType("System.String"));
                dt.Columns.Add("Invoice Id", Type.GetType("System.String"));
                dt.Columns.Add("File Name", Type.GetType("System.String"));
                dt.Columns.Add("Word Count", Type.GetType("System.String"));
                dt.Columns.Add("Uploaded Date", Type.GetType("System.String"));
                dt.Columns.Add("Pay Rate", Type.GetType("System.String"));
                dt.Columns.Add("Total Amount", Type.GetType("System.String"));
                dt.Columns.Add("TAT", Type.GetType("System.String"));
                DataRow dr = null;

                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (Dictionary<string, object> item in dictionary)
                {

                    string fileid = item["fileid"] == null ? "0" : item["fileid"].ToString();
                    string typistinvid = item["typistinvid"] == null ? "0" : item["typistinvid"].ToString();
                    string filename = item["filename"] == null ? "" : item["filename"].ToString();
                    string duration = item["duration"] == null ? "0" : item["duration"].ToString();
                    string typistinvdate = item["typistinvdate"] == null ? "" : item["typistinvdate"].ToString();
                    string payrate = item["payrate"] == null ? "" : item["payrate"].ToString();
                    string invtotalamt = item["invtotalamt"] == null ? "" : item["invtotalamt"].ToString();
                    string po_tat = item["po_tat"] == null ? "" : item["po_tat"].ToString();

                    dr = dt.NewRow();
                    dr["fileid"] = fileid;
                    dr["Invoice Id"] = typistinvid;
                    dr["File Name"] = filename;
                    dr["Word Count"] = duration;
                    dr["Uploaded Date"] = typistinvdate;
                    dr["Pay Rate"] = String.Format("${0:#0.00}", payrate);
                    dr["Total Amount"] = String.Format("${0:#0.00}", invtotalamt);
                    dr["TAT"] = po_tat;

                    dt.Rows.Add(dr);
                }



                invoiceGrid.DataSource = dt;
                invoiceGrid.Columns[0].Visible = false;
                invoiceGrid.Columns[1].Visible = false;
                invoiceGrid.Columns[2].Width = 400;
                invoiceGrid.Columns[4].Width = 150;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }
    }
}
