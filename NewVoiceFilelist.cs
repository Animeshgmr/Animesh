using System;
using System.Collections.Generic;
using GMRTTranscription.Models;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Threading;

namespace GMRTTranscription
{
    public partial class NewVoiceFilelist : Form
    {
        public static bool WorkFormStatus = false;

        
        public NewVoiceFilelist()
        {
            InitializeComponent();

        }
        //WaitWndFun waitForm;
        PopUpForm pform;
        private void NewVoiceFilelist_Load(object sender, EventArgs e)
        {
            pform = new PopUpForm();
            pform.Show();
            this.Enabled = false;
            GetNewFileList();
            this.WindowState = FormWindowState.Maximized;
            this.invoiceGrid.AllowUserToAddRows = false;
            pform.Close();

        }

        private void GetNewFileList()
        {
            try
            {
                //Login API
                string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";
                string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                int cnt = 0;
                string filestaus = "";
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                invoiceGrid.Refresh();
                invoiceGrid.DataSource = null;

                invoiceGrid.Columns[1].Visible = false;
                invoiceGrid.Columns[2].Visible = false;
                invoiceGrid.Columns[3].Visible = false;
                invoiceGrid.Columns[6].Visible = false;

                foreach (Dictionary<string, object> item in dictionary)
                {
                    string fileExtension = Path.GetExtension(item["filename"].ToString());
                    if (!fileExtension.ToLower().Equals(".pdf") && !fileExtension.ToLower().Equals(".doc") && !fileExtension.ToLower().Equals(".docx"))
                    {
                        cnt = cnt + 1;
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
                        po_tat = po_tat.Split(':')[0].ToString();
                        DataGridViewRow row = (DataGridViewRow)invoiceGrid.Rows[0].Clone();  //dt.NewRow();

                        row.Cells[0].Value = cnt.ToString();
                        row.Cells[1].Value = fileid;
                        row.Cells[2].Value = po_id;
                        row.Cells[3].Value = customer_id;
                        row.Cells[4].Value = filename;
                        row.Cells[5].Value = duration;
                        row.Cells[6].Value = downloadurl;
                        row.Cells[7].Value = deadlinedate;
                        row.Cells[8].Value = deadlinetime;
                        row.Cells[9].Value = payrate;
                        row.Cells[10].Value = po_tat;
                        row.Cells[11].Value = eservice;
                        row.Cells[12].Value = instrcution;
                        filestaus = item["partialfilestatus"] == null ? "" : item["partialfilestatus"].ToString();
                        if (filestaus == "3")
                        {
                            filestaus = "New File";
                        }
                        else
                        {
                            filestaus = "Partial File";
                        }

                        row.Cells[13].Value = filestaus;


                        if (filestaus == "New File")
                        {

                            row.DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Cyan;
                        }

                        invoiceGrid.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                pform.Close();
                Common.ShowErrorDialog(ex.Message.ToString());
            }
            this.Enabled = true;
          //  waitForm.Close();

        }

        private void invoiceGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 14)
                {
                    string strFileId = invoiceGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string lblFileId = strFileId.ToString();
                    string po_id = invoiceGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string lblCustomerId = invoiceGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string FileName = invoiceGrid.Rows[e.RowIndex].Cells[4].Value.ToString();

                    string duration = invoiceGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string FileDownloadURL = invoiceGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                    string Deadlinedate = invoiceGrid.Rows[e.RowIndex].Cells[7].Value.ToString();
                    string DeadlineTime = invoiceGrid.Rows[e.RowIndex].Cells[8].Value.ToString();
                    string payrate = invoiceGrid.Rows[e.RowIndex].Cells[9].Value.ToString();
                    string Language = invoiceGrid.Rows[e.RowIndex].Cells[10].Value.ToString();
                    string Fileinstruction = invoiceGrid.Rows[e.RowIndex].Cells[11].Value.ToString();
                    string eservice = invoiceGrid.Rows[e.RowIndex].Cells[11].Value.ToString();
                    string Filestatus = invoiceGrid.Rows[e.RowIndex].Cells[13].Value.ToString();
                    NewVoicefile nf = new NewVoicefile();
                    nf.fileid = strFileId;
                    nf.po_id = po_id;
                    nf.customer_id = lblCustomerId;
                    nf.filename = FileName;
                    nf.FILE_NAME = FileName;
                    nf.duration = duration;
                    nf.downloadurl = FileDownloadURL;
                    nf.deadlinedate = Deadlinedate;
                    nf.deadlinetime = DeadlineTime;
                    nf.payrate = payrate;
                    nf.instrcution = Fileinstruction;
                    nf.po_tat = Language;
                    nf.File_Status = Filestatus;
                    //nf.MdiParent = this.MdiParent;
                    //nf.Show();
                    //this.Close();
                    MDIForm.ChildForm(nf);
                }
            }

            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());

            }

        }

         

        private void invoiceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MDIForm.CloseTab();
        }
    }
}
