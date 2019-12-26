using GMRTTranscription.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

namespace GMRTTranscription
{
    public partial class NewFile : Form
    {
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        public static bool WorkFormStatus = false;
        ExtendedRichTextBox.CharStyle cs;

        private const Keys CopyKeys = Keys.Control | Keys.C;
        private const Keys PasteKeys = Keys.Control | Keys.V;
        public string txtFile;
        public int HorizOrVer = 1; //1 For Vertical and 2 For Horizontal
        public string FILE_NAME = "";
        public string fileid, po_id, customer_id, filename, duration, downloadurl,  deadlinedate, deadlinetime, payrate, instrcution, eservice, po_tat,File_Status;

        public NewFile()
        {
            InitializeComponent();
           SizeChanged += new EventHandler(NewFile_SizeEventHandler);
        }
        // WaitWndFun waitForm = new WaitWndFun();
        PopUpForm plzwait = new PopUpForm();
        private void NewFile_Load(object sender, EventArgs e)
        {
            try
            {
                //  waitForm.Show(this);
                cs = advancedTextEditor1.TextEditor.SelectionCharStyle;
                plzwait.Show(this);
                this.Enabled = false;
                plzwait.StartPosition = FormStartPosition.CenterParent;
              
             
                //labelSpeed.Text = "";
                labelPerc.Text = "";
                labelDownloaded.Text = "";
                labelDownloaded.Visible = false;
                btnHorizontal.Visible = false;
                btnVertical.Visible = false;
                //lblDownloading.Visible = false;
                lblFileId.Visible = false;
                ContextMenu _blankContextMenu = new ContextMenu();
                advancedTextEditor1.TextEditor.ContextMenu = _blankContextMenu;
                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                GrantAccess(windowsInstallPath);
                txtFile = windowsInstallPath +"\\" + DateTime.Now.ToString("ddMMyyyyHHmm") +".txt";

               
                FillFileList(false);
               

               

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if ((keyData == Keys.F4) )
        //    {
        //        return true;
        //    }
        //    else if ((keyData == Keys.F8))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return base.ProcessCmdKey(ref msg, keyData);
        //    }
        //}
        private void FillFileList_bak(bool isPageLoad = true)
        {
            try
            {
                lblFileId.Text = "0";
                lblCustomerId.Text = "0";
                string outFile = "";
                pdfViewer.setShowToolbar(false);
                pdfViewer.src = outFile + "#toolbar=0";
                advancedTextEditor1.TextEditor.Rtf = "";
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;


                string JSONDATA = "{ \"vendorid\":\"" + Models.Global.VendorId + "\" }";

                //Function : List upload transcribe list
                string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                System.Data.DataTable dt = new System.Data.DataTable("NewFileLists");
                dt.Columns.Add("FILE_NAME", Type.GetType("System.String"));
                dt.Columns.Add("FILE_NAME_DISPLAY", Type.GetType("System.String"));
                dt.Columns.Add("FILE_ID", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DURATION", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DOWNLOAD_URL", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DEADLINE_DATE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DEADLINE_TIME", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PAY_RATE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_INSTRUCTION", Type.GetType("System.String"));
                dt.Columns.Add("FILE_eSERVICE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PO_ID", Type.GetType("System.String")); 
                dt.Columns.Add("CUSTOMER_ID", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PO_TAT", Type.GetType("System.String"));
                DataRow dr = null;

                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                
                foreach (Dictionary<string, object> item in dictionary)
                {

                    string FILE_NAME = item["filename"] == null ? "" : item["filename"].ToString();
                    string FILE_NAME_DISPLAY = FILE_NAME.Substring(0, FILE_NAME.LastIndexOf('.'));
                    string FILE_ID = item["fileid"] == null ? "0" : item["fileid"].ToString();
                    string FILE_DURATION = item["duration"] == null ? "0" : item["duration"].ToString();
                    string FILE_DOWNLOAD_URL = item["downloadurl"] == null ? "#" : item["downloadurl"].ToString();
                    string FILE_DEADLINE_DATE = item["deadlinedate"] == null ? "" : item["deadlinedate"].ToString();
                    string FILE_DEADLINE_TIME = item["deadlinetime"] == null ? "" : item["deadlinetime"].ToString();
                    string FILE_PAY_RATE = item["payrate"] == null ? "" : item["payrate"].ToString();
                    string FILE_INSTRUCTION = item["instrcution"] == null ? "" : item["instrcution"].ToString();
                    string FILE_eSERVICE = item["eservice"] == null ? "" : item["eservice"].ToString();
                    string FILE_PO_ID = item["po_id"] == null ? "" : item["po_id"].ToString();
                    string CUSTOMER_ID = item["customer_id"] == null ? "" : item["customer_id"].ToString();
                    string FILE_PO_TAT = item["po_tat"] == null ? "" : item["po_tat"].ToString();

                    dr = dt.NewRow();
                    dr["FILE_NAME"] = FILE_NAME;
                    dr["FILE_NAME_DISPLAY"] = FILE_NAME_DISPLAY;
                    dr["FILE_ID"] = FILE_ID;
                    dr["FILE_DURATION"] = FILE_DURATION;
                    dr["FILE_DOWNLOAD_URL"] = FILE_DOWNLOAD_URL;
                    dr["FILE_DEADLINE_DATE"] = FILE_DEADLINE_DATE;
                    dr["FILE_DEADLINE_TIME"] = FILE_DEADLINE_TIME;
                    dr["FILE_PAY_RATE"] = FILE_PAY_RATE;
                    dr["FILE_INSTRUCTION"] = FILE_INSTRUCTION;
                    dr["FILE_eSERVICE"] = FILE_eSERVICE;
                    dr["FILE_PO_ID"] = FILE_PO_ID;
                    dr["CUSTOMER_ID"] = CUSTOMER_ID;
                    dr["FILE_PO_TAT"] = FILE_PO_TAT;
                    dt.Rows.Add(dr);
                }

                dataGridFileLists.DataSource = dt;
                dataGridFileLists.Columns[1].Visible = true;
                dataGridFileLists.Columns[1].Width = 300;
                dataGridFileLists.Columns[0].Visible = false;
                dataGridFileLists.Columns[2].Visible = false;
                dataGridFileLists.Columns[3].Visible = false;
                dataGridFileLists.Columns[4].Visible = false;
                dataGridFileLists.Columns[5].Visible = false;
                dataGridFileLists.Columns[6].Visible = false;
                dataGridFileLists.Columns[7].Visible = false;
                dataGridFileLists.Columns[8].Visible = false;
                dataGridFileLists.Columns[9].Visible = false;
                dataGridFileLists.Columns[10].Visible = false;
                dataGridFileLists.Columns[11].Visible = false;
                dataGridFileLists.Columns[12].Visible = false;

                
                //Fill Fil List Top one
                if (dt.Rows.Count > 0 && isPageLoad == false)
                {
                    lblFileId.Text = dt.Rows[0]["FILE_ID"].ToString();
                    lblCustomerId.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
                    WordDocumentViewer(dt.Rows[0]["FILE_DOWNLOAD_URL"].ToString());
                }
                else
                {

                    string outFiles = "";
                    pdfViewer.LoadFile(outFiles);
                    pdfViewer.src = outFiles + "#toolbar=0";
                    
                    pdfViewer.setShowToolbar(false);
                    pdfViewer.Show();
                    // pdfViewer.LoadFile("Empty");
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }


        private void FillFileList(bool isPageLoad = true)
        {
            try
            {
                lblFileId.Text = "0";
                lblCustomerId.Text = "0";

                Common.WriteTextFile("Starting FillFileList()", txtFile);

                pdfViewer.LoadFile("");
                pdfViewer.src = "" + "#toolbar=0";
                pdfViewer.setShowToolbar(false);
                pdfViewer.Show();

                advancedTextEditor1.TextEditor.Rtf = "";
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;


                //string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";

                ////Function : List upload transcribe list
                //string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                //string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                System.Data.DataTable dt = new System.Data.DataTable("NewFileLists");
                dt.Columns.Add("FILE_NAME", Type.GetType("System.String"));
                dt.Columns.Add("FILE_NAME_DISPLAY", Type.GetType("System.String"));
                dt.Columns.Add("FILE_ID", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DURATION", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DOWNLOAD_URL", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DEADLINE_DATE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_DEADLINE_TIME", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PAY_RATE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_INSTRUCTION", Type.GetType("System.String"));
                dt.Columns.Add("FILE_eSERVICE", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PO_ID", Type.GetType("System.String"));
                dt.Columns.Add("CUSTOMER_ID", Type.GetType("System.String"));
                dt.Columns.Add("FILE_PO_TAT", Type.GetType("System.String"));
                
                DataRow dr = null;
                string FILE_NAME_DISPLAY = FILE_NAME.Substring(0, FILE_NAME.LastIndexOf('.'));                    
                string FILE_eSERVICE = ""; 
                dr = dt.NewRow();
                dr["FILE_NAME"] = FILE_NAME;
                dr["FILE_NAME_DISPLAY"] = FILE_NAME_DISPLAY;
                dr["FILE_ID"] = fileid;
                dr["FILE_DURATION"] = duration;
                dr["FILE_DOWNLOAD_URL"] = downloadurl;
                dr["FILE_DEADLINE_DATE"] = deadlinedate;
                dr["FILE_DEADLINE_TIME"] = deadlinetime;
                dr["FILE_PAY_RATE"] = payrate;
                dr["FILE_INSTRUCTION"] = instrcution;
                dr["FILE_eSERVICE"] = FILE_eSERVICE;
                dr["FILE_PO_ID"] = po_id;
                dr["CUSTOMER_ID"] = customer_id;
                dr["FILE_PO_TAT"] = po_tat;

                string status = File_Status;
                
                lbl_Filename.Text = FILE_NAME;
                lbl_tat.Text = po_tat;
                lbl_status.Text = status;
                lbl_deadline.Text = deadlinedate + ":" + deadlinetime;

                pdfViewer.setShowToolbar(false);
                pdfViewer.setShowScrollbars(false);

                dt.Rows.Add(dr);
                dataGridFileLists.DataSource = dt;
                dataGridFileLists.Columns[1].Visible = true;
                dataGridFileLists.Columns[1].Width = 300;
                dataGridFileLists.Columns[0].Visible = false;
                dataGridFileLists.Columns[2].Visible = false;
                dataGridFileLists.Columns[3].Visible = false;
                dataGridFileLists.Columns[4].Visible = false;
                dataGridFileLists.Columns[5].Visible = false;
                dataGridFileLists.Columns[6].Visible = false;
                dataGridFileLists.Columns[7].Visible = false;
                dataGridFileLists.Columns[8].Visible = false;
                dataGridFileLists.Columns[9].Visible = false;
                dataGridFileLists.Columns[10].Visible = false;
                dataGridFileLists.Columns[11].Visible = false;
                dataGridFileLists.Columns[12].Visible = false;
                //Fill Fil List Top one
                if (dt.Rows.Count > 0 && isPageLoad == false)
                {
                    lblFileId.Text = dt.Rows[0]["FILE_ID"].ToString();
                    lblCustomerId.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
                    WordDocumentViewer(dt.Rows[0]["FILE_DOWNLOAD_URL"].ToString());
                    
                }
                else
                {
                    pdfViewer.LoadFile("Empty");
                    pdfViewer.src = "" + "#toolbar=0";
                    pdfViewer.setShowToolbar(false);
                    pdfViewer.Show();                    
                }
                 
                

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }
       
       

        private void dataGridFileLists_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    int currentRowIndex = dataGridFileLists.CurrentRow.Index;
                    string FileId = dataGridFileLists.Rows[currentRowIndex].Cells[2].Value.ToString();
                    lblFileId.Text = FileId.ToString();
                    string FileName = dataGridFileLists.Rows[currentRowIndex].Cells[0].Value.ToString();
                    string FileDownloadURL = dataGridFileLists.Rows[currentRowIndex].Cells[4].Value.ToString();
                    lblCustomerId.Text = dataGridFileLists.Rows[currentRowIndex].Cells[11].Value.ToString();
                    WordDocumentViewer(FileDownloadURL);
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void dataGridFileLists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {                
                string FileId = dataGridFileLists.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblFileId.Text = FileId.ToString();
                string FileName = dataGridFileLists.Rows[e.RowIndex].Cells[0].Value.ToString();
                string FileDownloadURL = dataGridFileLists.Rows[e.RowIndex].Cells[4].Value.ToString();
                lblCustomerId.Text = dataGridFileLists.Rows[e.RowIndex].Cells[11].Value.ToString();
                WordDocumentViewer(FileDownloadURL);
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }        

        private void WordDocumentViewer(string FileName)
        {
            
         
           
            try
            {
             
                Common.WriteTextFile("Starting WordDocumentViewer", txtFile);
                pdfViewer.LoadFile("Empty");
                pdfViewer.src = "" + "#toolbar=0";
                pdfViewer.setShowToolbar(false);
                pdfViewer.Show();
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;

                
                //WordToRTF(FileName);
                string NewFileName = FileName.Substring(FileName.LastIndexOf('/'));
                NewFileName = NewFileName.Substring(0, NewFileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory).ToLower().ToString();  //Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                GrantAccess(windowsInstallPath);


                GrantAccess(windowsInstallPath + "\\documents\\Temp");
                GrantAccess(windowsInstallPath);
                windowsInstallPath = windowsInstallPath + "\\documents\\pdf";
                GrantAccess(windowsInstallPath);
                windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
                string outFile = windowsInstallPath +  NewFileName + ".pdf";
                Common.WriteTextFile("Starting WordDocumentViewer : " + outFile, txtFile);
                string DirectoryName = windowsInstallPath ;
                GrantAccess(DirectoryName);
                Common.WriteTextFile("Starting WordDocumentViewer :GrantAccess" , txtFile);

                //here
                Text = "Downloading file. Please wait...";               
                
                string Extension = System.IO.Path.GetExtension(FileName).ToLower().ToString();

                //Download File First
                string downloadedPath = windowsInstallPath + NewFileName + Extension;

                //  DownloadFileFromServerAndLoadInPdfViewerAsync(FileName, downloadedPath);
                Common.WriteTextFile("Starting WordDocumentViewer :DownloadFile", txtFile);
               
                DownloadFile(FileName, downloadedPath);
                 
                labelDownloaded.Text = FileName;
                FileName = downloadedPath;

                Text = "Work Lists";

            }
            catch(Exception ex)
            {
                Common.ShowErrorDialog(ex.ToString());
            }
            
        }

        private string RTF2Word(string FileName)
        {
            try
            {
               Common.WriteTextFile("RTF2Word(): Started in RTF2Word", txtFile);
                string NewFileName = FileName.Substring(FileName.LastIndexOf('\\'));
                NewFileName = NewFileName.Replace("\\", "");
                NewFileName = NewFileName.Substring(0, NewFileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                

                string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewFileName + ".docx";               
                string DirectoryName = windowsInstallPath + "\\documents\\pdf\\";
               Common.WriteTextFile("RTF2Word(): Started GrantAccess(DirectoryName);", txtFile);
                GrantAccess(DirectoryName);
               Common.WriteTextFile("RTF2Word():End GrantAccess(DirectoryName);", txtFile);
                
                //Common.ShowErrorDialog("RTF2Word: Done GarbagageCollect");
                //Creating the instance of Word Application
                Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();

                // Give the Source file name & Target file names
                object Source = FileName;
                //Common.ShowErrorDialog("FileName: Created");
                // Give the Target file names
                object Target = outFile;

                // Use for the parameter whose type are not known or say Missing
                object Unknown = Type.Missing;
                //Common.ShowErrorDialog("RTF2Word 2: Word File Opened ");
                // Source document open here
                // Additional Parameters are not known so that are // set as a missing type
                //    newApp.Documents.Open(ref Source, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);

                Microsoft.Office.Interop.Word.Document doc = newApp.Documents.Open(ref Source, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);

                foreach(Microsoft.Office.Interop.Word.Section section in doc.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    headerRange.Font.Name = "Times New Roman";    
                    headerRange.Font.Size = 12;
                    headerRange.Font.Bold = 24 ;
                    headerRange.Text = "File Name: " + lbl_Filename.Text;
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in doc.Sections)
                {
                    object anchor = "https://www.gmrtranscription.com";
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkBlue;
                    footerRange.Font.Name = "Arial";
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "www.gmrtranscription.com";
                    // Add hyperlink to it.
                    
                    
                }

                // Specifying the format in which you want the output file
                object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault;

                //Changing the format of the document
                newApp.ActiveDocument.SaveAs(ref Target, ref format, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);
              //  Common.ShowErrorDialog("RTF2Word 2: Word File Quiting ");
                // for closing the application
                newApp.Quit(ref Unknown, ref Unknown, ref Unknown);

               Common.WriteTextFile("RTF2Word(): Word File Quit;", txtFile);
                //   Common.ShowErrorDialog("RTF2Word 2: Word File Quit ");
                //sOut = System.IO.File.ReadAllText(outFile, System.Text.Encoding.Default);
                //Delete Original File 
                //After uplaoding delete the root file
                try
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(FileName);
                    if (file.Exists)
                    {
                       Common.WriteTextFile("RTF2Word(): Now in  file.Exists", txtFile);
                        // Common.ShowErrorDialog("RTF2Word 2: Word File Delete ");
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                    //   file.Delete();
                       Common.WriteTextFile("RTF2Word():  Done File.Delete(FileName);", txtFile);

                        //  file.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog("RTF2word:Exception 1 " + ex.Message.ToString());                   
                }                

                return outFile;
            }
            catch(Exception ex)
            {
                Common.ShowErrorDialog("RTF2Word Exception 2: " + ex.Message.ToString());
                throw new Exception("RTF2Word  Exception 2: " + ex.Message.ToString());
            }
        }

        private string RTF2Word_WithOutHeader(string FileName)
        {
            try
            {
                Common.WriteTextFile("RTF2Word(): Started in RTF2Word", txtFile);
                string NewFileName = FileName.Substring(FileName.LastIndexOf('\\'));
                NewFileName = NewFileName.Replace("\\", "");
                NewFileName = NewFileName.Substring(0, NewFileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";


                string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewFileName + ".docx";
                string DirectoryName = windowsInstallPath + "\\documents\\pdf\\";
                Common.WriteTextFile("RTF2Word(): Started GrantAccess(DirectoryName);", txtFile);
                GrantAccess(DirectoryName);
                Common.WriteTextFile("RTF2Word():End GrantAccess(DirectoryName);", txtFile);

                //Common.ShowErrorDialog("RTF2Word: Done GarbagageCollect");
                //Creating the instance of Word Application
                Microsoft.Office.Interop.Word.Application newApp = new Microsoft.Office.Interop.Word.Application();

                // Give the Source file name & Target file names
                object Source = FileName;
                //Common.ShowErrorDialog("FileName: Created");
                // Give the Target file names
                object Target = outFile;

                // Use for the parameter whose type are not known or say Missing
                object Unknown = Type.Missing;
                //Common.ShowErrorDialog("RTF2Word 2: Word File Opened ");
                // Source document open here
                // Additional Parameters are not known so that are // set as a missing type
                newApp.Documents.Open(ref Source, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                
                // Specifying the format in which you want the output file
                object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault;

                //Changing the format of the document
                newApp.ActiveDocument.SaveAs(ref Target, ref format, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                //  Common.ShowErrorDialog("RTF2Word 2: Word File Quiting ");
                // for closing the application
                newApp.Quit(ref Unknown, ref Unknown, ref Unknown);

                Common.WriteTextFile("RTF2Word(): Word File Quit;", txtFile);
                //   Common.ShowErrorDialog("RTF2Word 2: Word File Quit ");
                //sOut = System.IO.File.ReadAllText(outFile, System.Text.Encoding.Default);
                //Delete Original File 
                //After uplaoding delete the root file
                try
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(FileName);
                    if (file.Exists)
                    {
                        Common.WriteTextFile("RTF2Word(): Now in  file.Exists", txtFile);
                        // Common.ShowErrorDialog("RTF2Word 2: Word File Delete ");
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();
                        Common.WriteTextFile("RTF2Word():  Done File.Delete(FileName);", txtFile);
                        //  file.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Common.ShowErrorDialog("RTF2word:Exception 1 " + ex.Message.ToString());
                }

                return outFile;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog("RTF2Word Exception 2: " + ex.Message.ToString());
                throw new Exception("RTF2Word  Exception 2: " + ex.Message.ToString());
            }
        }
        private void FillPreviousContentifAny()
        {
            string outFile = "";
            try
            {
                plzwait.SetProcess("Checking Transcribe File.. Please Wait");

                string VendorId = Models.Global.VendorId;
                string VoiceFileId = lblFileId.Text.ToString();
                string CustomerId = lblCustomerId.Text.ToString();                
                //string Status = "0";
                string Data = "";
                string JSONDATA = "{ \"vendor_id\":\"" + Models.Global.VendorId + "\", \"vf_id\": \"" + VoiceFileId + "\", \"customerid\": \"" + CustomerId + "\", \"data\": \"" + Data + "\" }";

                string webServiceUrl = "/api/textfiledetails/partilefiledetails";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);

                //Get FIle Name if any
                var jss = new JavaScriptSerializer();
                var dictionary = jss.Deserialize<dynamic>(sResponse);
                foreach (KeyValuePair<string, object> item in dictionary)
                {
                    string Key = String.IsNullOrEmpty(item.Key) ? "" : item.Key.ToString().ToLower().Trim();
                    object Value = item.Value == null ? "" : item.Value.ToString().ToLower().Trim();
                    if (Key == "data")
                    {
                        string RandomString = Models.Common.GetRandomString();

                        string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                        windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";

                          outFile = windowsInstallPath + "\\documents\\pdf\\" + VendorId + ".rtf";
                        System.IO.FileInfo fileexist = new System.IO.FileInfo(outFile);
                        if (fileexist.Exists)
                        {
                            fileexist.Delete();
                        }

                        string DirectoryName = windowsInstallPath + "\\documents\\pdf\\";
                        GrantAccess(DirectoryName);

                        string FilName = Value.ToString();
                        if(!String.IsNullOrEmpty(FilName))
                        {
                            //Download file and put the content in editor
                            //Download Pdf
                            //lblDownloading.Visible = true;
                            Uri URL = new Uri(FilName);
                            WebClient webClient = new WebClient();                         
                            webClient.DownloadFileAsync(URL, outFile);                           
                            
                            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                            object file = outFile;
                            object nullobj = System.Reflection.Missing.Value;
                            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(
                            ref file, false, true, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj);
                            doc.ActiveWindow.Selection.WholeStory();
                            doc.ActiveWindow.Selection.Copy();
                            IDataObject data = Clipboard.GetDataObject();
                            advancedTextEditor1.TextEditor.Rtf = data.GetData(DataFormats.Rtf).ToString();
                            doc.Close();
                            string status = File_Status;
                            lbl_Filename.Text = FILE_NAME;
                            lbl_tat.Text = po_tat;
                            lbl_status.Text = status;
                            lbl_deadline.Text = deadlinedate + ":" + deadlinetime;
                            //    lblDownloading.Text = "File Name:" +  FILE_NAME + Environment.NewLine + " DeadLine Date & time:" + deadlinedate + ":" + deadlinetime +Environment.NewLine +" TAT: " + po_tat + Environment.NewLine + " Status:" + status;
                            //Now Delete the file
                            //System.IO.FileInfo file1 = new System.IO.FileInfo(outFile);
                            //if (file1.Exists)
                            //{
                            //    file1.Delete();
                            //}
                           
                        }
                        else
                        {
                            advancedTextEditor1.TextEditor.Rtf = "";
                        }                       
                        break;
                    }
                }
                //Set Transparent Panel Size
                SetTransparentSizeAccording2Screen();
            }
            catch (Exception ex)
            {
                System.IO.FileInfo file1 = new System.IO.FileInfo(outFile);
                if (file1.Exists)
                {
                    file1.Delete();
                }
                Common.ShowErrorDialog(ex.Message.ToString());
                throw new Exception("FillPreviousContentifAny: " + ex.Message.ToString());
            }
            

        }

        private string PartiallySaveData(out string plainFileText)
        {
            try
            {
                Common.WriteTextFile("Started PartiallySaveData()",txtFile);
                string VendorId = Models.Global.VendorId;
                string CustomerId = lblCustomerId.Text.ToString();
                string VoiceFileId = lblFileId.Text.ToString();                
                string Filname = System.IO.Path.GetFileNameWithoutExtension(lbl_Filename.Text);
                //Get The Content Of Advanced Text Editor
                Common.WriteTextFile("PartiallySaveData(): Getting windowsInstallPath",txtFile);
                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                string fileName = windowsInstallPath + "\\Documents\\Temp\\" + Filname + ".rtf";
                Common.WriteTextFile("PartiallySaveData(): CheckIfFileIsBeingUsed",txtFile);
                Boolean isuse = Common.CheckIfFileIsBeingUsed(fileName);
                if (isuse)
                {
                    Common.WriteTextFile("PartiallySaveData(): closing File is in use",txtFile);
                    //  Common.FileIsLocked(fileName);
                    Common.WriteTextFile("PartiallySaveData(): End of closing File is in use",txtFile);
                }
                else
                {
                    
                }

                string plainFileName = windowsInstallPath + "\\Documents\\Temp\\" + Filname + ".txt";
                string DirectoryName = windowsInstallPath + "\\Documents\\Temp\\";
                Common.WriteTextFile("PartiallySaveData(): GrantAccess(DirectoryName);",txtFile);
                GrantAccess(DirectoryName);
                Common.WriteTextFile("PartiallySaveData(): GrantAccess(DirectoryName) Done",txtFile);
                
                System.IO.FileInfo file;
                //Common.KillProcess("WINWORD");
                //List<int> processesbeforegen = Common.getRunningProcesses();
                //// APP CREATION/ DOCUMENT CREATION HERE...
                //List<int> processesaftergen = Common.getRunningProcesses();
                //Common.killProcesses(processesbeforegen, processesaftergen);


                //Check if file exists then delete first
                try
                {
                    


                   file = new System.IO.FileInfo(fileName);
                    if (file.Exists)
                    {
                        Common.WriteTextFile("PartiallySaveData(): 1 file.Exists",txtFile);
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();
                        

                        Common.WriteTextFile("PartiallySaveData():   File.Delete(fileName);",txtFile);
                        //  file.Delete();

                    }
                }
                catch { }

                try
                {
                      file = new System.IO.FileInfo(plainFileName);
                    if (file.Exists)
                    {
                        Common.WriteTextFile("PartiallySaveData(): Started  File.Delete(plainFileName);",txtFile);
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();
                        // file.Delete();
                        Common.WriteTextFile("PartiallySaveData(): End  File.Delete(plainFileName);",txtFile);
                    }
                }
                catch { }

                Common.WriteTextFile("PartiallySaveData(): Started advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.RichText);",txtFile);
                advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.RichText);
               Common.WriteTextFile("PartiallySaveData(): End advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.RichText);", txtFile);

               Common.WriteTextFile("PartiallySaveData(): Started advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.PlainText);", txtFile);
                advancedTextEditor1.TextEditor.SaveFile(plainFileName, RichTextBoxStreamType.PlainText);
               Common.WriteTextFile("PartiallySaveData(): End advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.PlainText);", txtFile);
                plainFileText = plainFileName;
                return fileName;               
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
                throw new Exception("Exception: " + ex.Message.ToString());
            }
        }

        private void GrantAccess(string fullPath)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(fullPath);
                if (!dInfo.Exists)
                {
                    Directory.CreateDirectory(fullPath);
                }
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog("GrantAccess: " + ex.Message.ToString());
            }            
        }        

        private void FinalUploadFile()
        {        
            try
            { 

                string VendorId = Models.Global.VendorId;
                string CustomerId = lblCustomerId.Text.ToString();
                string VoiceFileId = lblFileId.Text.ToString();

                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    client.BaseAddress = new Uri(Models.Global.WEB_SERVICE_ROOT_URL);

                    string palinFileFname = "";
                    string genratedFileName = PartiallySaveData(out palinFileFname);
                    Common.WriteTextFile("PartiallySaveData(): Completed with Plain FileName",txtFile);
                    genratedFileName = RTF2Word(genratedFileName);
                    Common.WriteTextFile("RTF2Word():  Done RTF2Word with genratedFileName;", txtFile);
                    string FileName = genratedFileName.Substring(genratedFileName.LastIndexOf('\\'));
                    FileName = FileName.Replace("\\", "");
                    string totalCount = "0";

                    try
                    {

                        //System.IO.FileInfo file = new System.IO.FileInfo(FileName);
                        //Common.KillProcess("WINWORD");
                        //List<int> processesbeforegen = Common.getRunningProcesses();
                        //// APP CREATION/ DOCUMENT CREATION HERE...
                        //List<int> processesaftergen = Common.getRunningProcesses();
                        //Common.killProcesses(processesbeforegen, processesaftergen);


                        Common.WriteTextFile("FinalUploadFile():  Started Reading palinFileFname;",txtFile);

                        string plainContent = System.IO.File.ReadAllText(palinFileFname);
                        plainContent = String.IsNullOrEmpty(plainContent) ? "" : plainContent.Trim();
                        plainContent = plainContent.Replace("\r", " ").Replace("\n", " ").Replace("\f", " ").Replace("\t", " ");

                        string[] wordCount = plainContent.Split(' ');
                        //totalCount = wordCount == null ? "0" : (wordCount.Length).ToString();      
                        int counter = 0;                  
                        foreach (string str in wordCount)
                        {
                            string strToCount = String.IsNullOrEmpty(str) ? "" : str.Trim().ToString();
                            if (!String.IsNullOrEmpty(strToCount) && strToCount != "�")
                            {
                                counter++;
                            }
                        }
                        totalCount = counter.ToString();
                    }
                    catch (Exception ex) {
                        Common.ShowErrorDialog("FinalUploadFile 1." + ex.Message.ToString());

                    }
                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(@"" + genratedFileName));
                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = FileName
                    };

                    content.Add(fileContent1);

                    content.Add(new StringContent(VendorId), "vendor_id");
                    content.Add(new StringContent(CustomerId), "customer_id");
                    content.Add(new StringContent(VoiceFileId), "file_id");
                    content.Add(new StringContent(totalCount), "totalcount");

                    // Make a call to Web API
                    //Delete Later
                      var result = client.PostAsync("/api/fileuploadconfimation", content).Result;

                    Common.WriteTextFile("FinalUploadFile():  File Upload fileuploadconfimation Successfully;",txtFile);
                    //After uplaoding. delete the root file
                    try
                    {
                        System.IO.FileInfo file = new System.IO.FileInfo(genratedFileName);
                        //Common.KillProcess("WINWORD");
                        //List<int> processesbeforegen = Common.getRunningProcesses();
                        //// APP CREATION/ DOCUMENT CREATION HERE...
                        //List<int> processesaftergen = Common.getRunningProcesses();
                        //Common.killProcesses(processesbeforegen, processesaftergen);

                     //   System.IO.FileInfo file = new System.IO.FileInfo(genratedFileName);
                        if (file.Exists)
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            //Delete Later
                           file.Delete();
                            //file.Delete();
                        }
                    }
                    catch (Exception ex)
                    {

                        Common.ShowErrorDialog("FinalUploadFile 4." + ex.Message.ToString());
                    }

                    try
                    {
                        System.IO.FileInfo file = new System.IO.FileInfo(palinFileFname);
                        //Common.KillProcess("WINWORD");
                        //List<int> processesbeforegen = Common.getRunningProcesses();
                        //// APP CREATION/ DOCUMENT CREATION HERE...
                        //List<int> processesaftergen = Common.getRunningProcesses();
                        //Common.killProcesses(processesbeforegen, processesaftergen);
                        if (file.Exists)
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            //Delete Later
                             file.Delete();
                            // file.Delete();
                        }
                    }
                    catch (Exception ex)
                    {

                        Common.ShowErrorDialog("FinalUploadFile 3." + ex.Message.ToString());
                    }

                    if (result != null)
                    {
                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            Common.ShowInformationDialog("Data Saved & File Uploded Successfully!!!");
                        }
                        else
                        {
                            Common.ShowErrorDialog(result.ReasonPhrase);
                        }
                    }
                    else
                    {
                        Common.ShowErrorDialog("Some error occured while uploading files to server...");
                    }

                }
            }

            catch (Exception ex)
            {
             
                Common.ShowErrorDialog("FinalUploadFile 2." + ex.Message.ToString());
            }

        }

        private void PartialUploadFile()
        {
            try
            {
                string VendorId = Models.Global.VendorId;
                string CustomerId = lblCustomerId.Text.ToString();
                string VoiceFileId = lblFileId.Text.ToString();

                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    client.BaseAddress = new Uri(Models.Global.WEB_SERVICE_ROOT_URL);

                    string palinFileFname = "";
                    string genratedFileName = PartiallySaveData(out palinFileFname);
                    string FileName = genratedFileName.Substring(genratedFileName.LastIndexOf('\\'));
                    FileName = FileName.Replace("\\", "");

                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(@"" + genratedFileName));
                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = FileName
                    };

                    content.Add(fileContent1); 

                    content.Add(new StringContent(VendorId), "vendor_id");
                    content.Add(new StringContent(CustomerId), "customer_id");
                    content.Add(new StringContent(VoiceFileId), "file_id");

                   // content.Add(new StringContent("2"), "totalcount");



                    // Make a call to Web API
                    var result = client.PostAsync("/api/partialfile", content).Result;

                    //After uplaoding delete the root file
                    //Now Delete the file
                    try
                    {
                        System.IO.FileInfo file = new System.IO.FileInfo(genratedFileName);
                        if (file.Exists)
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            file.Delete();
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ShowErrorDialog("5." + ex.Message.ToString());
                    }
                    try
                    {
                        System.IO.FileInfo file = new System.IO.FileInfo(palinFileFname);
                        if (file.Exists)
                        {
                            System.GC.Collect();
                            System.GC.WaitForPendingFinalizers();
                            file.Delete();
                           // file.Delete();
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ShowErrorDialog("4." + ex.Message.ToString());
                    }
                    
                    if (result != null)
                    {
                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            Common.ShowInformationDialog("Data Saved Successfully!!!");
                        }
                        else
                        {
                            Common.ShowErrorDialog(result.ReasonPhrase);
                        }
                    }
                    else
                    {
                        Common.ShowErrorDialog("Some error occured while uploading files to server...");
                    }                    
                }
            }

            catch (Exception ex)
            {
                Common.ShowErrorDialog("3." + ex.Message.ToString());
                
                //  Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void btnPartialSave_Click(object sender, EventArgs e)
        {           
            try
            {
                string CustomerId = lblCustomerId.Text.ToString();
                string VoiceFileId = lblFileId.Text.ToString();

                if(Convert.ToInt64(CustomerId) > 0 && Convert.ToInt64(VoiceFileId) > 0)
                {
                    btnPartialSave.Text = "Please Wait...";
                    btnPartialSave.Enabled = false;
                    btnSaveTask.Enabled = false;
                    PartialUploadFile();
                    btnPartialSave.Enabled = true;
                    btnSaveTask.Enabled = true;
                    btnPartialSave.Text = "Partial Save";
                    Common.Empty("pdf");
                    Common.Empty("Temp");

                    MDIForm.CloseTab();
                    //NewFilelist nf = new NewFilelist();
                    //nf.MdiParent = this.MdiParent;
                    //nf.Show();
                    //this.Close();
                }
                else
                {
                    Common.ShowInformationDialog("Please select any file");
                }

               
            }
            catch (Exception ex)
            {
                
                Common.ShowErrorDialog(ex.Message.ToString());
               
            }                
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure want to submit file?", "Confirmation!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (confirmResult == DialogResult.Yes)
                {
                    string CustomerId = lblCustomerId.Text.ToString();
                    string VoiceFileId = lblFileId.Text.ToString();

                    if (Convert.ToInt64(CustomerId) > 0 && Convert.ToInt64(VoiceFileId) > 0)
                    {
                        btnSaveTask.Text = "Please Wait...";
                        btnPartialSave.Enabled = false;
                        btnSaveTask.Enabled = false;
                        string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                        windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                        txtFile =  windowsInstallPath + "\\"+  DateTime.Now.ToString("yyyyMMdd_HHMM")+ ".txt";
                        Common.WriteTextFile("Started FinalUploadFile()", txtFile);
                        FinalUploadFile();
                        Common.WriteTextFile("End of  FinalUploadFile()", txtFile);
                        Common.Empty("pdf");
                        Common.Empty("Temp");
                        //Fill File List Again
                        // FillFileList(false);

                        //NewFilelist nf = new NewFilelist();
                        //nf.MdiParent = this.MdiParent;
                        //nf.Show();

                        btnPartialSave.Enabled = true;
                        btnSaveTask.Enabled = true;
                        btnSaveTask.Text = "SAVE";
                        //this.Close();
                    }
                    else
                    {
                        Common.ShowInformationDialog("Please select any file");
                    }
                }                
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }            
        }

        private void NewFile_Shown(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void SetTransparentSizeAccording2Screen()
        {
            try
            {
                int Width = pdfViewer.Width;
                int Height = pdfViewer.Height;

                int tmpWidth = 920;
                int newWidth = 0;              

                for (int i = 1900; i >= 0;)
                {
                    tmpWidth -= 50;

                    if (Width > 1900)
                    {
                        newWidth = tmpWidth;
                        break;
                    }
                    else if (Width >= i && Width < (i + 100))
                    {
                        if (Width <= 550)
                        {
                            tmpWidth = tmpWidth - 50;
                        }
                        newWidth = tmpWidth;
                        break;
                    }
                    i = i - 100;
                }

                transparentControlForPdfViewer.Dock = System.Windows.Forms.DockStyle.Left;
                transparentControlForPdfViewer.Location = new System.Drawing.Point(0, 0);
                transparentControlForPdfViewer.Size = new System.Drawing.Size(newWidth, Height);
               
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void NewFile_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                //Set Transparent Panel Size
                SetTransparentSizeAccording2Screen();
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void NewFile_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            try
            {
                //Set Transparent Panel Size
                SetTransparentSizeAccording2Screen();
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void NewFile_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Control | Keys.B))
            {
                if (cs.Bold)
                {
                    cs.Bold = false;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
                else
                {
                    cs.Bold = true;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.I))
            {
                if (cs.Italic)
                {
                    cs.Italic = false;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
                else
                {
                    cs.Italic = true;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
            }

            if (e.KeyData == (Keys.Control | Keys.U))
            {
                if (cs.Underline)
                {
                    cs.Underline = false;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
                else
                {
                    cs.Underline = true;
                    advancedTextEditor1.TextEditor.SelectionCharStyle = cs;
                }
            }

        }

        private void lblDownloading_Click(object sender, EventArgs e)
        {

        }

        private void transparentpanelLeft_Click(object sender, EventArgs e)
        {

        }

        private void transparentControlForPdfViewer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NewFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Delete Later
            Common.Empty("pdf");
            Common.Empty("Temp");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MDIForm.CloseTab();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void NewFile_SizeEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    SetTransparentSizeAccording2Screen();
                }
                if (this.WindowState == FormWindowState.Normal)
                {
                    SetTransparentSizeAccording2Screen();
                }
                if (this.WindowState == FormWindowState.Maximized)
                {
                    SetTransparentSizeAccording2Screen();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void DownloadFile(string urlAddress, string location)
        {
            
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                 
                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = new Uri(urlAddress); //urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);
                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    // Start downloading the file
                    Common.WriteTextFile("Starting DownloadFile :Start downloading the file", txtFile);

                    plzwait.SetProcess("Downloading file.. Please Wait");
                    webClient.DownloadFileAsync(URL, location);
                    
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
        }


        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            //labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";

            //// Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            //labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
            //    (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
            //    (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
               

                // Reset the stopwatch.
                sw.Reset();

                if (e.Cancelled == true)
                {
                    MessageBox.Show("Download has been canceled.");
                }
                else
                {
                    //MessageBox.Show("Download completed!");
                   
                    Common.WriteTextFile("Starting Completed :Download completed!", txtFile);
                    string FileName = labelDownloaded.Text.ToString();
                    string NewFileName = FileName.Substring(FileName.LastIndexOf('/'));
                    NewFileName = NewFileName.Substring(0, NewFileName.LastIndexOf('.'));
                    Common.WriteTextFile("Starting Completed :" + NewFileName, txtFile);
                    string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                    windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                    windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
                    string DirectoryName = windowsInstallPath + "\\documents\\pdf\\";
                    Common.WriteTextFile("Starting Completed :Creating Directory"+ DirectoryName, txtFile);
                    string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewFileName + ".pdf";
                    Common.WriteTextFile("Starting Completed :Creating outFile path" + outFile, txtFile);
                    System.IO.FileInfo fileexist = new System.IO.FileInfo(outFile);                     
                    GrantAccess(DirectoryName);
                    string Extension = System.IO.Path.GetExtension(FileName).ToLower().ToString();
                    if (Extension == ".doc" || Extension == ".docx")
                    {
                        //lblDownloading.Visible = true;
                        Common.WriteTextFile("Starting Completed : Converting File to Doc", txtFile);
                        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document doc = null;
                        Common.WriteTextFile("Starting Completed : app.Documents.Open", txtFile);
                        doc = app.Documents.Open(FileName, Type.Missing, false);
                        Common.WriteTextFile("Starting Completed :Cross app.Documents.Open", txtFile);
                        //Convert doc to pdf
                        Common.WriteTextFile("Starting Completed :Convert doc to pdf", txtFile);
                        doc.ExportAsFixedFormat(outFile, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                        //close doc file and quit app word
                        Common.WriteTextFile("Starting Completed :close doc file and quit app word", txtFile);
                        doc.Close(false, Type.Missing, Type.Missing);
                        app.Quit(false, false, false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                        Common.WriteTextFile("Starting Completed :System.Runtime.InteropServices.Marshal.ReleaseComObject", txtFile);
                        //lblDownloading.Visible = false;
                     
                        pdfViewer.src = outFile + "#toolbar=0";
                      
                        Common.WriteTextFile("Starting Completed : Converting File to Doc Completed", txtFile);

                        pdfViewer.setShowToolbar(false);
                        plzwait.SetProcess("Download completed.. Please Wait");
                        //  pdfViewer.Show();


                        try
                        {
                            //Now Delete the file
                            //System.IO.FileInfo file = new System.IO.FileInfo(outFile);
                            //if (file.Exists)
                            //{
                            //    file.Delete();
                            //}
                        }
                        catch (Exception ex1)
                        {
                            Common.WriteTextFile("Starting Completed  ex1 : " + ex1.Message, txtFile);
                        }
                        Common.WriteTextFile("Starting Completed : Going FillPreviousContentifAny", txtFile);
                        
                        FillPreviousContentifAny();

                        btnPartialSave.Enabled = true;
                        btnSaveTask.Enabled = true;
                    }
                    else if (Extension == ".pdf")
                    {
                        //Download Pdf
                        //lblDownloading.Visible = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(FileName, outFile);
                        //lblDownloading.Visible = false;
                        
                        pdfViewer.LoadFile(outFile);
                        pdfViewer.src = outFile + "#toolbar=0";
                        pdfViewer.setShowToolbar(false);
                        plzwait.SetProcess("Download completed.. Please Wait");
                        //try
                        //{
                        //    //Now Delete the file
                        //    System.IO.FileInfo file = new System.IO.FileInfo(outFile);
                        //    if (file.Exists)
                        //    {

                        //        file.Delete();
                        //    }
                        //}
                        //catch (Exception ex2)
                        //{
                        //    Common.WriteTextFile("Starting Completed   ex2 Extension PDF : " + ex2.Message, txtFile);
                        //}

                        FillPreviousContentifAny();

                        btnPartialSave.Enabled = true;
                        btnSaveTask.Enabled = true;
                    }
                    else
                    {
                        btnPartialSave.Enabled = false;
                        btnSaveTask.Enabled = false;
                        Common.ShowInformationDialog("Sorry!!! Currently we are only supporting text to text transcription in desktop application. For voice to text transcription please log into the website.");
                    }
                    
                    pdfViewer.setShowToolbar(false);
                    pdfViewer.Controls.Add(transparentpanelLeft);
                  

                    Text = "Work Lists";

                    plzwait.Close();
                    // waitForm.Close();
                    //  pdfViewer.src = outFile + "#navpanes=0";


                    this.Enabled = true;
                    
                }
            }
            catch (Exception ex4)
            {
                Common.WriteTextFile("Starting Completed   ex4 Extension PDF : " + ex4.Message, txtFile);
                this.Enabled = true;
               
            }
            Common.WriteTextFile("Fially Completed Successfully ", txtFile);
        }        

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void dataGridFileLists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void SplitHorizontal()
        //{
        //    try
        //    {
        //        HorizOrVer = 2;

        //        tableLayoutPanel1.Controls.Clear();
        //        tableLayoutPanel1.RowCount = 3;
        //        tableLayoutPanel1.ColumnCount = 2;

        //        // lblFileLists
        //        tableLayoutPanel1.Controls.Add(lblFileLists, 0, 0);
        //        lblFileLists.Location = new System.Drawing.Point(1, 37);
        //        lblFileLists.AutoSize = true;
        //        lblFileLists.Dock = System.Windows.Forms.DockStyle.Top;

        //        // lblDownloading
        //        tableLayoutPanel1.Controls.Add(this.lblDownloading, 1, 0);
        //        lblDownloading.Location = new System.Drawing.Point((lblFileLists.Width + 10), 13);
        //        lblDownloading.AutoSize = true;
        //        lblDownloading.Dock = System.Windows.Forms.DockStyle.Top;

        //        // dataGridFileLists
        //        dataGridFileLists.Controls.Clear();
        //        tableLayoutPanel1.Controls.Add(dataGridFileLists, 0, 1);
        //        dataGridFileLists.Dock = System.Windows.Forms.DockStyle.Fill;
        //        dataGridFileLists.Location = new System.Drawing.Point(3, 64);
        //       dataGridFileLists.Size = new System.Drawing.Size(100, 484);

        //        //lblCustomerId
        //        this.tableLayoutPanel1.Controls.Add(this.lblCustomerId, 0, 2);
        //        this.lblCustomerId.AutoSize = true;
        //        this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        this.lblCustomerId.Location = new System.Drawing.Point(5, 551);
        //        this.lblCustomerId.Name = "lblCustomerId";
        //        this.lblCustomerId.Size = new System.Drawing.Size(111, 24);
        //        this.lblCustomerId.TabIndex = 24;
        //        this.lblCustomerId.Text = "Customer Id";
        //        this.lblCustomerId.Visible = false;


        //        tableLayoutPanel1.Controls.Add(this.advancedTextEditor1, 1, 1);
        //        tableLayoutPanel1.Controls.Add(this.panelForPdfViewer, 1, 1);
        //        tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
        //        tableLayoutPanel1.Controls.Add(this.lblFileId, 2, 0);
        //        tableLayoutPanel1.Controls.Add(this.tableLayoutPanelForSaveAndPartialSaveButtons, 2, 2);
        //        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        //        tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
        //        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        //        int width = 0, height = 0;
        //        width = Screen.PrimaryScreen.WorkingArea.Width - dataGridFileLists.Width - 10;
        //        height = Screen.PrimaryScreen.WorkingArea.Height - dataGridFileLists.Height;
        //        //panelForPdfViewer
        //        panelForPdfViewer.Controls.Clear();
        //        panelForPdfViewer.Controls.Add(this.transparentControlForPdfViewer);
        //        panelForPdfViewer.Controls.Add(this.pdfViewer);
        //        panelForPdfViewer.Controls.Add(this.advancedTextEditor1);
        //        panelForPdfViewer.Location = new System.Drawing.Point(pdfViewer.Height + 10, 64);
        //        panelForPdfViewer.Name = "panelForPdfViewer";
        //        panelForPdfViewer.Size = new System.Drawing.Size(width, dataGridFileLists.Height);
        //        panelForPdfViewer.TabIndex = 26;
        //        //panelForPdfViewer

              
        //        this.pdfViewer.Dock = System.Windows.Forms.DockStyle.None;               
        //        this.pdfViewer.Enabled = true;
        //        this.pdfViewer.Location = new System.Drawing.Point(0, 0);
        //        this.pdfViewer.Name = "pdfViewer";
        //        this.pdfViewer.Size = new System.Drawing.Size((width), height);
        //        this.pdfViewer.TabIndex = 2;

        //        this.advancedTextEditor1.AutoSize = true;
        //        this.advancedTextEditor1.Dock = System.Windows.Forms.DockStyle.None;
        //      //  height = pdfViewer.Height + 100;
        //        this.advancedTextEditor1.Name = "advancedTextEditor1";
        //        this.advancedTextEditor1.Enabled = true;
        //        this.advancedTextEditor1.Location = new System.Drawing.Point(0, pdfViewer.Height + 10);              
        //        this.advancedTextEditor1.Size = new System.Drawing.Size((width), height);
        //        this.advancedTextEditor1.TabIndex = 3;


        //        //    tableLayoutPanel1.Controls.Add(this.tableLayoutPanelForSaveAndPartialSaveButtons, 2, 2);




        //        //tableLayoutPanel1.Dock = DockStyle.None;

        //        //tableLayoutPanel1.Controls.Add(dataGridFileLists,0,1);

        //        //dataGridFileLists.Location = new Point(3, 64);
        //        //dataGridFileLists.Size = new Size(193, 484);
        //        //tableLayoutPanel1.RowCount = 3;
        //        //tableLayoutPanel1.ColumnCount =2;

        //        //tableLayoutPanel1.Controls.Add(tableLayoutPanelForSaveAndPartialSaveButtons, 2, 2);
        //        //tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
        //        //tableLayoutPanel1.Controls.Add(pdfViewer,2,1);
        //        //pdfViewer.Location = new Point(3 + dataGridFileLists.Width + 10, dataGridFileLists.Height);
        //        //pdfViewer.Size = new Size((3 + dataGridFileLists.Width + 10), (dataGridFileLists.Height ));

        //        //pdfViewer.Dock = DockStyle.Fill;
        //        //tableLayoutPanel1.Controls.Add(advancedTextEditor1, 2, 2);

        //        //advancedTextEditor1.Location = new Point(3 + dataGridFileLists.Width + 10, pdfViewer.Height);
        //        //advancedTextEditor1.Size = new Size(pdfViewer.Width, pdfViewer.Height);


        //        //tableLayoutPanel1.Controls.Add(advancedTextEditor1, 1, 0);

        //        //transparentControlForPdfViewer.Dock = DockStyle.Right;

        //        //dataGridFileLists.Dock = DockStyle.Left;


        //        //   pdfViewer.Dock = DockStyle.Right;




        //        //   tableLayoutPanel1.Dock = DockStyle.Fill;


        //        //   advancedTextEditor1.Dock = DockStyle.Fill;

        //        //tableLayoutPanel1.RowCount = 3;
        //        //tableLayoutPanel1.ColumnCount = 3;
        //        //ColumnStyle CS = new ColumnStyle();
        //        //CS.SizeType = SizeType.Percent;
        //        //CS.Width = 100;
        //        //tableLayoutPanel1.ColumnStyles.Add(CS);

        //        ////   tableLayoutPanel1.Controls.Add(transparentControlForPdfViewer, 0, 0);
        //        //tableLayoutPanel1.Controls.Add(advancedTextEditor1, 2, 2);

        //        //TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
        //        //foreach (RowStyle style in styles)
        //        //{
        //        //    style.SizeType = SizeType.Percent;
        //        //    style.Height = 50;
        //        //}

        //        SetTransparentSizeAccording2Screen();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void SplitVertical()
        //{
        //    try
        //    {
        //        HorizOrVer = 1;
        //        tableLayoutPanel1.Controls.Clear();
        //        tableLayoutPanel1.Dock = DockStyle.Fill;
        //        transparentControlForPdfViewer.Dock = DockStyle.Fill;

        //        pdfViewer.Dock = DockStyle.Fill;
        //        transparentControlForPdfViewer.Controls.Add(pdfViewer);
        //        transparentControlForPdfViewer.Dock = DockStyle.Left;
        //        transparentControlForPdfViewer.Width = 100;
        //       // pdfViewer.Controls.Add(transparentControlForPdfViewer);

        //        advancedTextEditor1.Dock = DockStyle.Fill;
        //        tableLayoutPanel1.ColumnCount = 2;
        //        tableLayoutPanel1.Controls.Add(transparentControlForPdfViewer, 0, 2);
        //        tableLayoutPanel1.Controls.Add(advancedTextEditor1, 1, 0);

        //        int cnt = 0;
        //        TableLayoutRowStyleCollection styles = tableLayoutPanel1.RowStyles;
        //        foreach (RowStyle style in styles)
        //        {
        //            style.SizeType = SizeType.Percent;
        //            if (cnt == 0)
        //            {
        //                style.Height = 100;
        //            }
        //            else
        //            {
        //                style.Height = 0;
        //            }
        //            cnt++;
        //        }

        //        SetTransparentSizeAccording2Screen();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void lblFileId_Click(object sender, EventArgs e)
        {

        }

        private void btnHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                btnHorizontal.BackColor = Color.Green;
                btnHorizontal.ForeColor = Color.White;

                btnVertical.BackColor = SystemColors.Control;
                btnVertical.ForeColor = SystemColors.ControlText;

              // SplitHorizontal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVertical_Click(object sender, EventArgs e)
        {
            try
            {
                btnVertical.BackColor = Color.Green;
                btnVertical.ForeColor = Color.White;
                btnHorizontal.BackColor = SystemColors.Control;
                btnHorizontal.ForeColor = SystemColors.ControlText;
              //  SplitVertical();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblCustomerId_Click(object sender, EventArgs e)
        {

        } 



    }
}
