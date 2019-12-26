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
using GMRTTranscription;
using WMPLib;

namespace GMRTTranscription
{
    public partial class NewVoicefile : Form
    {
        #region for testing purpose
        //for testing purpose
        string[] sourcenumber = {"122969",  "8443", "8443", "122969",   "7819", "7819", "7819", "7819", "7819", "7819", "186612",   "186612",   "186533",   "5659", "186534",   "186534",   "186534",   "186534",   "186534",   "186534",   "98455",    "98455",    "98455",    "98455",    "98455",    "186573",   "97852",    "186352",   "85951",    "85951",    "85951",    "85951",    "85951",    "85951",    "85951",    "85951",    "85951",    "85951",    "186566",   "186566",   "186566",   "186566",   "186566",   "6247", "6247", "6247", "186566",   "97666",    "98660",    "186566",   "186566",   "186566",   "186566",   "186566",   "186566",   "98794",    "98794",    "98794",    "98794",    "98459",    "98459",    "98459",    "98459",    "98459",    "98459",    "98459",    "98459",    "186608",   "110791",   "19515",    "19515",    "98459",    "98459",    "98459",    "98459",    "98459",    "122978",   "143849",   "86193",    "8443", "98167",    "98167",    "74563",    "74563",    "7338", "123460",   "123460",   "123460",   "123460",   "86567",    "86567",    "175671",   "175671",   "186361",   "6315", "6315", "6315", "6315", "6315",
                                    "74858",    "75537",    "75537",    "1674", "1674", "1674", "144120",   "29841",    "164828",   "164828",   "186126",   "97666",    "1674", "1674", "186096",   "86193",    "100366",   "97835",    "144536",   "144536",   "144536",   "144536",   "144536",   "74758",    "74758",    "74758",    "74758",    "74758",    "143849",   "186066",   "186546",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "164845",   "30473",    "30473",    "30473",    "30473",    "30473",    "144463",   "186273",   "186273",   "186273",   "186273",   "100366",   "74524",    "74524",    "186499",   "154684",   "175763",   "86497",    "144403",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186452",   "186344",   "186344",   "154684",   "8443", "175765",   "175765",   "175765",   "175765",   "175765",   "175765",   "175765",   "175765",   "175765",   "175765",   "175765",
                                    "186053",   "52060",    "52015",    "51749",    "51609",    "31274",    "31273",    "31272",    "31057",    "31056",    "30982",    "30753",    "30697",    "30632",    "30631",    "30597",    "30589",    "30588",    "30339",    "29974",    "5467", "3735"
                                };

        string[] sourcename = { "122969_Mike Turner Town Hall_Asia Pacific 09_23_2019.mp3", "8443_MK-2019-145 RICK R PC.m4a",   "8443_MK-2019-145 Sweeney PC.m4a",  "122969_Mike Turner's Town Hall 09_23_2019.mp3",    "7819_Tobi Fairley 7_9_19_01.mp3",  "7819_Phil Graham 7_16_19_01.mp3",  "7819_Leah McHenry 5_28_19_01.mp3", "7819_Charlie Gilkey 7_16_19_01.mp3",   "7819_Ariel Garten 7_23_19_01.mp3", "7819_Amy Porterfield 7_23_19_01.mp3",  "186612_09212019123646_DN-700R.mp3",    "186612_09212019080051_DN-700R.mp3",    "186533_2019-09-23 13_34 IndusCo.mp4",  "5659_18WM11801 8-15-19 .mp3",  "186534_2538-2 parent.WAV", "186534_2492-90 teen.WAV",  "186534_2492-90 parent.WAV",    "186534_2492-46 teen.WAV",  "186534_2492-46 - parent.WAV",  "186534_2492-36 parent  teen.WAV",  "98455_bh2_09172019_5.mp3", "98455_bh2_09172019_4.mp3", "98455_bh2_09172019_3.mp3", "98455_bh2_09172019_2.mp3", "98455_bh2_09172019_1.mp3", "186573_Participant 01_8-8-2019.WMA",   "97852_190920 SR2040.m4a",  "186352_Focus group 1_8_21_19 audio only.m4a",  "85951_135_19Aug2019_EH.wav",   "85951_134_4Sept2019_CD.wav",   "85951_124_19Sept2019_CD.wav",  "85951_118_4Sept2019_EH.wav",   "85951_115_8Aug2019_CD.wav",    "85951_114_3Sept2019_EH.wav",   "85951_108_21Aug2019_CD.wav",   "85951_107_21Aug2019_CD.wav",   "85951_105_4Sept2019_EH.wav",   "85951_102_30Aug2019_CD.wav",   "186566_IMG_0445 Part 2_1 for translation.mp4", "186566_IMG_0445 Part 1_1 for translation.mp4", "186566_AR Clip 3 - Support-1 for Translation.mp4", "186566_AR Clip 2 - Crisis -1 for Translation.mp4", "186566_AR Clip 1 - Head Injury-1 for Translation.mp4", "6247_Meyer2_8L00733_002208.MP4",   "6247_Meyer2_8L00733_001810.MP4",   "6247_Meyer2_8L00733_000810.MP4",   "186566_IMG_0447_0.mp4",    "97666_190923_001.MP3", "98660_9_20_19.WAV",    "186566_IMG_0447_1.mp4",    "186566_IMG_0445 Part 2_0.mp4", "186566_IMG_0445 Part 1_0.mp4", "186566_AR Clip 3 - Support.mp4",   "186566_AR Clip 2 - Crisis .mp4",   "186566_AR Clip 1 - Head Injury.mp4",   "98794_Sept 17.m4a",    "98794_Sept 13.m4a",    "98794_Sept 10.m4a",    "98794_Marty phone messages camp cedar Falls.m4a",  "98459_JFK 4.mp3",  "98459_JFK 3.mp3",  "98459_JFK 2.mp3",  "98459_JFK 1.mp3",  "98459_Dog Days 4.mp3", "98459_Dog Days 3.mp3", "98459_Dog Days 2.mp3", "98459_Dog Days 1.mp3", "186608_CERTIFICADO DE ESTUDIOS VISADO.pdf",    "110791_CMC_115_2019-9-20_eh.wav",  "19515_2019-09-19_GDOT_CAOcall.MP3",    "19515_2019-09-19_GDOT_CFO-SuntrustCall.MP3",   "98459_Breaking the Waves 1_6 5.mp3",   "98459_Breaking the Waves 1_6 4.mp3",   "98459_Breaking the Waves 1_6 3.mp3",   "98459_Breaking the Waves 1_6 2.mp3",   "98459_Breaking the Waves 1_6 1.mp3",   "122978_Brooks Broadhurst 9_23_19.MP3", "143849_eSCCIP video overlays for GMR.docx",    "86193_18551 Deck2 Grp2.mp3",   "8443_2019-0032 LNG ThriverExpert.m4a", "98167_KimLieb.mp3",    "98167_BrookeGraff.mp3",    "74563_Tawanda ONeal-2.m4a",    "74563_Omar George-2.m4a",  "7338_P27.mp3", "123460_James4.m4a",    "123460_James3.m4a",    "123460_james2.m4a",    "123460_james1.m4a",    "86567_Cuernavaca.WAV", "86567_CDMX_tres.WAV",  "175671_UNC_PharmFIT 027pt2_9_17_19 (pharmacist).m4a",  "175671_UNC_PharmFIT 027pt1_9_17_19 (pharmacist).m4a",  "186361_NW 13th St 5.m4a",  "6315_5-synergeyes_session 5_sales_2019-09-20-153043.m4a",  "6315_4-Synergeyes_Session_4_RD_2019-09-20-134055.m4a", "6315_3-synergeyes_session_3_tour_033_only_2019-09-20-124156.m4a",  "6315_2-synergeyes_session_2_WSJ_2019-09-20-122016.m4a",    "6315_1-synergEyes_session_1_Overview92019_2019-09-20-090726.m4a",
                                "74858_Voice Dialogue with Miriam 9-20-19 Fear of Crazy and Plant medicine.MP3",    "75537_Marcel Joosten, Centralpoint.mp4",   "75537_Chris Ogburn, HPE.mp4",  "1674_K-ANEP student 4B.MP3",   "1674_K-ANEP student 4A.MP3",   "1674_K-ANEP GED Student 3.MP3",    "144120_Manual Development T_E_B_ Cycle 09-20-2019.mp3",    "29841_SAC Winter 2019 Permission Slips_Eng.docx",  "164828_Philadelphia Group 2 - White YSO and HCP 0745 091819.mp3",  "164828_Philadelphia Group 1 - Latino YSO and HCP 0530 091819.mp3", "186126_170001_006_Unedited TED2016 talk on 'Recording and Changing dreams'_160218-2.mp4",  "97666_L_ Urban 156_19LA AUDIO.mp3",    "1674_K-ANEP GED student 2.MP3",    "1674_IAC-T3Y4-Robin.MP3",  "186096_Bullock, L - UM's 1st ROGs and RPDs to Plaintiff filed 09_19_19.pdf",   "86193_LINCOLNPARKSTRATEGIES_19-4364_9-11-2019_400pm_.mp3", "100366_008 Sept 182019.m4a",   "97835_122 Child.MP3",  "144536_EPC033_Round 2_LS100158_Spanish.WMA",   "144536_EPC028_Round 2_LS100180_Spanish 2of3.WMA",  "144536_EPC028_Round 2_LS100179_Spanish 3of3.WMA",  "144536_EPC028_Round 2_LS100178_Spanish 1of3.WMA",  "144536_EPC027_Round 2_LS100191_Spanish.WMA",   "74758_Wolf_ORCA_Past Claims_09132019.mp3", "74758_Wolf_ORCA_091319.mp3",   "74758_Sainsbury-ORCA_091319.mp3",  "74758_Najera-ORCA_091319.mp3", "74758_McCoy_ORCA_9_11_19.mp3", "143849_eSCCIP Modules_master_AP.doc",  "186066_201907~1.WAV",  "186546_26 pages of Ehrman Pitt.pdf",   "164845_Erin_190726_1022.mp3",  "164845_A0160000 copy.mp3", "164845_A0150000 copy.mp3", "164845_A0140000.mp3",  "164845_A0110000 copy.mp3", "164845_A0100000 copy.mp3", "164845_190730_1435.mp3",   "164845_190730_1323.mp3",   "164845_190730_1026.mp3",   "164845_190729_1610.mp3",   "164845_190729_1410.mp3",   "164845_190729_1108.mp3",   "164845_190729_0934.mp3",   "164845_190725_1436.mp3",   "164845_190724_1350.mp3",   "164845_190723_1159.mp3",   "30473_FocusGroup_Aug20_MenPart2.MP3",  "30473_FocusGroup_Aug20_Men.MP3",   "30473_FocusGroup_Aug19_Men.MP3",   "30473_FocusGroup_Aug17_Women.MP3", "30473_FocusGroup_Aug17_Men.MP3",   "144463_028.WMA",   "186273_Carolina_Rodriguez.mp3",    "186273_1577_Oro_Vista_Rd_31-2.mp4",    "186273_1577_Oro_Vista_Rd_31.mp4",  "186273_1577_Oro_Vista_Rd.mp4", "100366_011_provider_interview_09_13_2019.m4a", "74524_BCARE65 ID 54.WMA",  "74524_BCARE65 ID 53.WMA",  "186499_Ascent Milton 091019.m4a",  "154684_LS9_13.MP3",    "175763_50_WV_HS_9_03_19.mp3",  "86497_Mike Larson NCT Bio Interview-20190913 1405-1.mp4",  "144403_162021848.MP3", "186452_Entrevista8_F_08-15-19.mp3",    "186452_Entrevista8_F_08-14-19.mp3",    "186452_Entrevista8_F_08-13-19.mp3",    "186452_Entrevista7_M_08-15-19.mp3",    "186452_Entrevista7_F_20-25yrs_08-13-19.mp3",   "186452_Entrevista7_F_08-14-19.mp3",    "186452_Entrevista6_M_60-70yrs_08-13-19.mp3",   "186452_Entrevista6_F_08-15-19.mp3",    "186452_Entrevista6_F_08-14-19p3.mp3",  "186452_Entrevista5_M_25-30yrs_08-13-19.mp3",   "186452_Entrevista4_F_08-15-19.mp3",    "186452_Entrevista3_M_08-14-19.mp3",    "186452_Entrevista3_M_08-13-19.mp3",    "186452_Entrevista2_M_08-14-19.mp3",    "186452_Entrevista2_F_08-13-19.mp3",    "186452_Entrevista1_M_08-13-19.mp3",    "186452_Entrevista1_F_08-15-19.mp3",    "186452_Entrevista1_F_08-14-19.mp3",    "186452_Asociacion Mujeres 08-12-19.mp3",   "186452_AMIR 08-16-08-19.mp3",  "186344_13 Jun 2019 13.mp3",    "186344_12 Jun 2019 12.mp3",    "154684_EM 9_10.mp3",   "8443_2019-0021 MMY MDA Houston TM.m4a",    "175765_255 (old 246 duplicate)_July 17.mp3",   "175765_252_July 25.mp3",   "175765_251_July 25.mp3",   "175765_250_July 25.mp3",   "175765_249_July 25.mp3",   "175765_246_July 23.mp3",   "175765_231_July 23.mp3",   "175765_228_July 19.mp3",   "175765_226_July 19.mp3",   "175765_130_July 19.mp3",   "175765_119_June 29.mp3",
                                "186053_New Recording 43 _For review.m4a",  "ppc_gmr_add_21oct.mp3",    "tci_audio_test_6.mp3", "Board Meeting 9.9.16.wav", "test.docx",    "Audion_gmr1july.mp3",  "Audion_gmr1july.mp3",  "Audion_gmr1july.mp3",  "Test.docx",    "test.docx",    "Testfile.docx",    "LSM Monthly Report April_2016- Costa Mesa Urgent Care.docx",   "testfromgmr5may.mp3",  "ppc aprilapril_26457.mp3", "ppc aprilapril_26457.mp3", "Test file.mp4",    "Ajay Prasad Bio.docx", "Ajay Prasad Bio.docx", "test1.docx",   "Recording 1.MP3",  "5467_Certified Careers.doc",   "Spirituality_diversity.mp3"
                              };
        int filecounter = 0;
        //end of testing
        #endregion


        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        public static bool WorkFormStatus = false;
        double[] speedArray = { 0.0d, 0.1d, 0.2d, 0.3d, 0.4d, 0.5d, 0.6d, 0.7d, 0.8d, 0.9d, 1.0d, 1.1d, 1.2d, 1.3d, 1.4d, 1.5d, 1.6d, 1.7d, 1.8d, 1.9d, 2.0d };
        double fileDuration = 0;
        ExtendedRichTextBox.CharStyle cs;

        private const Keys CopyKeys = Keys.Control | Keys.C;
        private const Keys PasteKeys = Keys.Control | Keys.V;
        public string txtFile;
        public int HorizOrVer = 1; //1 For Vertical and 2 For Horizontal
        public string FILE_NAME = "";
        public string fileid, po_id, customer_id, filename, duration, downloadurl, deadlinedate, deadlinetime, payrate, instrcution, eservice, po_tat, File_Status;
        public bool gb_playstartonce = false;
        public NewVoicefile()
        {
            InitializeComponent();
            SizeChanged += new EventHandler(NewVoicefile_SizeEventHandler); 

        }
        PopUpForm waitForm = new PopUpForm();
        private void NewVoicefile_Load(object sender, EventArgs e)
        {
            try
            {
                cs = advancedTextEditor1.TextEditor.SelectionCharStyle;
                waitForm.Show(this);
                //this.Enabled = false;
                waitForm.StartPosition = FormStartPosition.CenterParent;

                this.SendToBack();
                //labelSpeed.Text = "";
                labelPerc.Text = "";
                labelDownloaded.Text = "";
                labelDownloaded.Visible = false;
                btnHorizontal.Visible = false;
                btnVertical.Visible = false;
                playbackspeed.Value = 10;
                lblFileId.Visible = false;
                ContextMenu _blankContextMenu = new ContextMenu();
                advancedTextEditor1.TextEditor.ContextMenu = _blankContextMenu;
                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                txtFile = windowsInstallPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".txt";
                lblBuffer.Visible = false;

                FillFileList(false);


                // waitForm.Close();

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
                //pdfViewer.setShowToolbar(false);

                //pdfViewer.src = outFile + "#toolbar=0";
                voiceplayer.URL = outFile;
                advancedTextEditor1.TextEditor.Rtf = "";
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;


                string JSONDATA = "{ \"vendorid\":\"" + Models.Global.VendorId + "\" }";

                //Function : List upload transcribe list
                string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                System.Data.DataTable dt = new System.Data.DataTable("NewVoicefileLists");
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
                    //  pdfViewer.LoadFile(outFiles);
                    //pdfViewer.src = outFiles + "#toolbar=0";
                    voiceplayer.URL = outFiles;

                    //   pdfViewer.setShowToolbar(false);
                    //   pdfViewer.Show();
                    voiceplayer.Show();
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

                //pdfViewer.LoadFile("");

                //pdfViewer.src = "" + "#toolbar=0";
                //pdfViewer.setShowToolbar(false);
                voiceplayer.URL = "";
                voiceplayer.Show();

                advancedTextEditor1.TextEditor.Rtf = "";
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;


                //string JSONDATA = "{ \"vendorid\":\"" + Global.VendorId + "\" }";

                ////Function : List upload transcribe list
                //string webServiceUrl = "/api/typistfilelistgmr/vendorfilelistgmr";
                //string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);
                System.Data.DataTable dt = new System.Data.DataTable("NewVoicefileLists");
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

                //pdfViewer.setShowToolbar(false);
                //pdfViewer.setShowScrollbars(false);

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
                    voiceplayer.URL = "";
                    //pdfViewer.LoadFile("Empty");
                    //pdfViewer.src = "" + "#toolbar=0";
                    //pdfViewer.setShowToolbar(false);
                    voiceplayer.Show();
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
                voiceplayer.URL = "";


                voiceplayer.Show();
                btnPartialSave.Enabled = false;
                btnSaveTask.Enabled = false;


                //WordToRTF(FileName);
                string NewVoicefileName = FileName.Substring(FileName.LastIndexOf('/'));
                NewVoicefileName = NewVoicefileName.Substring(0, NewVoicefileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory).ToLower().ToString();  //Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";

                GrantAccess(windowsInstallPath + "\\documents\\Temp");
                windowsInstallPath = windowsInstallPath + "\\documents\\pdf";
                windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
                string outFile = windowsInstallPath + NewVoicefileName + ".pdf";
                Common.WriteTextFile("Starting WordDocumentViewer : " + outFile, txtFile);
                string DirectoryName = windowsInstallPath;
                GrantAccess(DirectoryName);
                Common.WriteTextFile("Starting WordDocumentViewer :GrantAccess", txtFile);
                Text = "Downloading file. Please wait...";

                string Extension = System.IO.Path.GetExtension(FileName).ToLower().ToString();

                //Download File First
                string downloadedPath = windowsInstallPath + NewVoicefileName + Extension;

                //  DownloadFileFromServerAndLoadInPdfViewerAsync(FileName, downloadedPath);
                Common.WriteTextFile("Starting WordDocumentViewer :DownloadFile", txtFile);

                labelDownloaded.Text = FileName;
                //DownloadFile(FileName, downloadedPath);

                //by Anup
                RealStreamAudioVideo(FileName);

                //FileName = downloadedPath;
                Text = "NewVoicefile";

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.ToString());
            }

        }

        private string RTF2Word(string FileName)
        {
            try
            {
                Common.WriteTextFile("RTF2Word(): Started in RTF2Word", txtFile);
                string NewVoicefileName = FileName.Substring(FileName.LastIndexOf('\\'));
                NewVoicefileName = NewVoicefileName.Replace("\\", "");
                NewVoicefileName = NewVoicefileName.Substring(0, NewVoicefileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";


                string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewVoicefileName + ".docx";
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

                foreach (Microsoft.Office.Interop.Word.Section section in doc.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    headerRange.Font.Name = "Times New Roman";
                    headerRange.Font.Size = 12;
                    headerRange.Font.Bold = 24;
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
                //by anup
                doc.Close();

                
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
            catch (Exception ex)
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
                string NewVoicefileName = FileName.Substring(FileName.LastIndexOf('\\'));
                NewVoicefileName = NewVoicefileName.Replace("\\", "");
                NewVoicefileName = NewVoicefileName.Substring(0, NewVoicefileName.LastIndexOf('.'));

                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";


                string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewVoicefileName + ".docx";
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
                        if (!String.IsNullOrEmpty(FilName))
                        {
                            //Download file and put the content in editor
                            //Download Pdf
                            //lblDownloading.Visible = true;
                            Uri URL = new Uri(FilName);
                            //below line added by anup
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
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
                            string status = "New File";
                            if (advancedTextEditor1.TextEditor.Rtf.Length > 0)
                            {
                                status = "Partial File";
                            }

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
                Common.WriteTextFile("Started PartiallySaveData()", txtFile);
                string VendorId = Models.Global.VendorId;
                string CustomerId = lblCustomerId.Text.ToString();
                string VoiceFileId = lblFileId.Text.ToString();
                string Filname = System.IO.Path.GetFileNameWithoutExtension(lbl_Filename.Text);
                //Get The Content Of Advanced Text Editor
                Common.WriteTextFile("PartiallySaveData(): Getting windowsInstallPath", txtFile);
                string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";


                string fileName = windowsInstallPath + "\\Documents\\Temp\\" + Filname + ".rtf";
                Common.WriteTextFile("PartiallySaveData(): CheckIfFileIsBeingUsed", txtFile);
                Boolean isuse = Common.CheckIfFileIsBeingUsed(fileName);

                if (isuse)
                {
                    Common.WriteTextFile("PartiallySaveData(): closing File is in use", txtFile);
                    //  Common.FileIsLocked(fileName);
                    Common.WriteTextFile("PartiallySaveData(): End of closing File is in use", txtFile);
                }
                else
                {

                }

                string plainFileName = windowsInstallPath + "\\Documents\\Temp\\" + Filname + ".txt";
                string DirectoryName = windowsInstallPath + "\\Documents\\Temp\\";
                Common.WriteTextFile("PartiallySaveData(): GrantAccess(DirectoryName);", txtFile);
                GrantAccess(DirectoryName);
                Common.WriteTextFile("PartiallySaveData(): GrantAccess(DirectoryName) Done", txtFile);

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
                        Common.WriteTextFile("PartiallySaveData(): 1 file.Exists", txtFile);
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();


                        Common.WriteTextFile("PartiallySaveData():   File.Delete(fileName);", txtFile);
                        //  file.Delete();

                    }
                }
                catch { }

                try
                {
                    file = new System.IO.FileInfo(plainFileName);
                    if (file.Exists)
                    {
                        Common.WriteTextFile("PartiallySaveData(): Started  File.Delete(plainFileName);", txtFile);
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();
                        // file.Delete();
                        Common.WriteTextFile("PartiallySaveData(): End  File.Delete(plainFileName);", txtFile);
                    }
                }
                catch { }

                Common.WriteTextFile("PartiallySaveData(): Started advancedTextEditor1.TextEditor.SaveFile(fileName, RichTextBoxStreamType.RichText);", txtFile);
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
                    Common.WriteTextFile("PartiallySaveData(): Completed with Plain FileName", txtFile);
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


                        Common.WriteTextFile("FinalUploadFile():  Started Reading palinFileFname;", txtFile);

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
                    catch (Exception ex)
                    {
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

                    Common.WriteTextFile("FinalUploadFile():  File Upload fileuploadconfimation Successfully;", txtFile);
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

                if (Convert.ToInt64(CustomerId) > 0 && Convert.ToInt64(VoiceFileId) > 0)
                {
                    btnPartialSave.Text = "Please Wait...";
                    btnPartialSave.Enabled = false;
                    btnSaveTask.Enabled = false;
                    PartialUploadFile();

                    btnPartialSave.Enabled = true;
                    btnSaveTask.Enabled = true;
                    btnPartialSave.Text = "Partial Save";


                    MDIForm.CloseTab();
                    //this.Close();
                    //NewVoiceFilelist nf = new NewVoiceFilelist();
                    //nf.Show();
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
                        txtFile = windowsInstallPath + "\\" + DateTime.Now.ToString("yyyyMMdd_HHMM") + ".txt";
                        Common.WriteTextFile("Started FinalUploadFile()", txtFile);
                        FinalUploadFile();
                        Common.WriteTextFile("End of  FinalUploadFile()", txtFile);
                        //Fill File List Again
                        // FillFileList(false);
                        //this.Close();
                        //NewVoiceFilelist nf = new NewVoiceFilelist();
                        //nf.Show();
                        btnPartialSave.Enabled = true;
                        btnSaveTask.Enabled = true;
                        btnSaveTask.Text = "SAVE";
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

        private void NewVoicefile_Shown(object sender, EventArgs e)
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
                int Width = voiceplayer.Width;
                int Height = voiceplayer.Height;

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

                //transparentControlForPdfViewer.Dock = System.Windows.Forms.DockStyle.Left;
                //transparentControlForPdfViewer.Location = new System.Drawing.Point(0, 0);
                //transparentControlForPdfViewer.Size = new System.Drawing.Size(newWidth, Height);

            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void NewVoicefile_ResizeEnd(object sender, EventArgs e)
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

        private void NewVoicefile_MaximizedBoundsChanged(object sender, EventArgs e)
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

        private void NewVoicefile_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Escape))
            {
                pic_playpause_Click(sender, e);
            }

            if (e.KeyData == (Keys.F1) || (e.KeyData == (Keys.Control | Keys.LButton)))
            {
                pic_back_Click(sender, e);
            }

            if (e.KeyData == (Keys.F2) || (e.KeyData == (Keys.Control | Keys.RButton)))
            {
                pic_forward_Click(sender, e);
            }

            if (e.KeyData == (Keys.F3) || (e.KeyData == (Keys.Control | Keys.D3)))
            {
                try
                {
                    DecreaseSpeed();
                }
                catch (Exception ep)
                {
                }
            }

            if (e.KeyData == (Keys.F4) || (e.KeyData == (Keys.Control | Keys.D4)))
            {
                IncreaseSpeed();
            }

            if (e.KeyData == (Keys.Control | Keys.D0))
            {
                voiceplayer.Ctlcontrols.currentPosition = 0;
            }

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
            else if (gb_playstartonce == false)
            {
                voiceplayer.Ctlcontrols.play();
                pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;
                gb_playstartonce = true;
                volumebar.Value = voiceplayer.settings.volume;
                lbl_playduration.Text = GMRTTranscription.Models.Common.GetHMSfromSecond(voiceplayer.Ctlcontrols.currentPosition);
            }
            else if (voiceplayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                voiceplayer.Ctlcontrols.play();
                pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;

            }

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition -= 5;
        }

        private void volumebar_Scroll(object sender, EventArgs e)
        {
            voiceplayer.settings.volume = volumebar.Value;
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
                fileDuration = dur;
                lblTotalDuration.Text = lbl_totalduration.Text = GMRTTranscription.Models.Common.GetHMSfromSecond(dur);
                pic_playpause.Image = GMRTTranscription.Properties.Resources.pause1;
                volumebar.Value = 100;
                lblBuffer.Visible = false;
            }
            if(e.newState == 6)
            {
                lblBuffer.Visible = true;
            }
        }

        private void playerstatusbar_Scroll(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition = (double)playerstatusbar.Value;
        }

        private void playbackspeed_MouseLeave(object sender, EventArgs e)
        {
            playbackspeed.Visible = false;

        }

        private void lbl_speed_Click(object sender, EventArgs e)
        {

        }

        private void lbl_speed_MouseHover(object sender, EventArgs e)
        {
            playbackspeed.Visible = true;
        }

        private void btnforward_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition += 5;
        }

        private void lbl_totalduration_Click(object sender, EventArgs e)
        {

        }

        private void pic_forward_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition += 5;
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition -= 5;
        }

        private void transparentControlForPdfViewer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void playerstatusbar_RightToLeftChanged(object sender, EventArgs e)
        {
            //  DecreaseSpeed();
        }

        private void playbackspeed_ValueChanged(object sender, EventArgs e)
        {
            voiceplayer.settings.rate = speedArray[playbackspeed.Value];
            lbl_speed.Text = speedArray[playbackspeed.Value].ToString("0.0") + "x Speed";
        }

        private void picOffset_Click(object sender, EventArgs e)
        {
            int hrSec = (Convert.ToInt32(txthr.Text)) * 3600;
            int minSec = (Convert.ToInt32(txtmin.Text)) * 60;
            int Sec = Convert.ToInt32(txtsec.Text);
            double totaltime = (hrSec + minSec + Sec);
            if (totaltime < fileDuration)
            {
                voiceplayer.Ctlcontrols.currentPosition = totaltime;
            }
        }

        private void NewVoicefile_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Delete Later
            Common.Empty("pdf");
            Common.Empty("Temp");
        }

        private void pic_Repeat_Click(object sender, EventArgs e)
        {
            voiceplayer.Ctlcontrols.currentPosition = 0;
            voiceplayer.URL = labelDownloaded.Text;
            playbackspeed.Value = 10;
            voiceplayer.settings.rate = 1.0;
            lbl_speed.Text = "1x Speed";
        }

        private void pic_Stop_Click(object sender, EventArgs e)
        {
            lbl_speed.Text = "1x Speed";
            voiceplayer.Ctlcontrols.stop();
            pic_playpause.Image = GMRTTranscription.Properties.Resources.play1;
            playbackspeed.Value = 10;
        }


        private void NewVoicefile_SizeChanged(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            MDIForm.CloseTab();
        }

        private void voiceplayer_ErrorEvent(object sender, EventArgs e)
        {
            Common.ShowInformationDialog("Sorry!!! this file is not available on the server");
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void NewVoicefile_SizeEventHandler(object sender, EventArgs e)
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
                    string NewVoicefileName = FileName.Substring(FileName.LastIndexOf('/'));
                    NewVoicefileName = NewVoicefileName.Substring(0, NewVoicefileName.LastIndexOf('.'));
                    Common.WriteTextFile("Starting Completed :" + NewVoicefileName, txtFile);

                    string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
                    windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
                    windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
                    string DirectoryName = windowsInstallPath + "\\documents\\pdf\\";
                    Common.WriteTextFile("Starting Completed :Creating Directory" + DirectoryName, txtFile);
                    string outFile = windowsInstallPath + "\\documents\\pdf\\" + NewVoicefileName + ".pdf";
                    Common.WriteTextFile("Starting Completed :Creating outFile path" + outFile, txtFile);
                    System.IO.FileInfo fileexist = new System.IO.FileInfo(outFile);

                    GrantAccess(DirectoryName);
                    string Extension = System.IO.Path.GetExtension(FileName).ToLower().ToString();
                    if (Extension.ToLower() == ".3gp" || Extension.ToLower() == ".aac" || Extension.ToLower() == ".aif" || Extension.ToLower() == ".dss" || Extension.ToLower() == ".m4a" || Extension.ToLower() == ".mov" || Extension.ToLower() == ".mp2" || Extension.ToLower() == ".MP3" || Extension == ".mp4" || Extension.ToLower() == ".mpg" || Extension.ToLower() == ".ogg" || Extension.ToLower() == ".wav" || Extension.ToLower() == ".wma" || Extension.ToLower() == ".wmv" || Extension.ToLower() == ".mp3")
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(FileName, outFile);
                        voiceplayer.URL = outFile;

                        volumebar.Value = voiceplayer.settings.volume;

                        WindowsMediaPlayerClass wmp = new WindowsMediaPlayerClass();
                        IWMPMedia mediaInfo = wmp.newMedia(outFile);
                        lbl_totalduration.Text = GMRTTranscription.Models.Common.GetHMSfromSecond(mediaInfo.duration);
                        fileDuration = mediaInfo.duration;
                        FillPreviousContentifAny();
                        btnPartialSave.Enabled = true;
                        btnSaveTask.Enabled = true;
                    }
                    else
                    {
                        btnPartialSave.Enabled = false;
                        btnSaveTask.Enabled = false;
                        Common.ShowInformationDialog("Sorry!!! Currently This Screen is only supporting Voice to text transcription in desktop application. For Text to text transcription please Open .");
                    }
                    Text = "Work Lists";
                    waitForm.Close();
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



        private void dataGridFileLists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnHorizontal_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    btnHorizontal.BackColor = Color.Green;
            //    btnHorizontal.ForeColor = Color.White;

            //    btnVertical.BackColor = SystemColors.Control;
            //    btnVertical.ForeColor = SystemColors.ControlText;

            //    // SplitHorizontal();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            if(filecounter < sourcename.Length)
            {
                string filename2 = "https://www.gmrtranscription.com/voicefiles/" + sourcenumber[filecounter] + "/" + sourcename[filecounter];
                filecounter++;
                lbl_Filename.Text = filename2.Substring(filename2.LastIndexOf('/'));
                RealStreamAudioVideo(filename2);
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

        private void IncreaseSpeed()
        {
            if (voiceplayer.settings.rate < 2.0 && playbackspeed.Value < 20)
            {
                playbackspeed.Value += 1;
            }
        }

        private void DecreaseSpeed()
        {
            if (voiceplayer.settings.rate > 0.1 && playbackspeed.Value > 1)
            {
                playbackspeed.Value -= 1;
            }
        }

        private void OnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                picOffset_Click(sender, e);
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        //by Anup
        private void RealStreamAudioVideo(string FileName)
        {
            try
            {
                // Reset the stopwatch.
                sw.Reset();
                string Extension = System.IO.Path.GetExtension(FileName).ToLower().ToString();
                if (Extension.ToLower() == ".3gp" || Extension.ToLower() == ".aac" || Extension.ToLower() == ".aif" || Extension.ToLower() == ".dss" || Extension.ToLower() == ".m4a" || Extension.ToLower() == ".mov" || Extension.ToLower() == ".mp2" || Extension.ToLower() == ".MP3" || Extension == ".mp4" || Extension.ToLower() == ".mpg" || Extension.ToLower() == ".ogg" || Extension.ToLower() == ".wav" || Extension.ToLower() == ".wma" || Extension.ToLower() == ".wmv" || Extension.ToLower() == ".mp3")
                {
                    FillPreviousContentifAny();

                    //voiceplayer.URL = @"C:\Users\Anup Kumar\Downloads\paypal\paypal\070_final_touches.mp4";
                    //voiceplayer.URL = "http://techslides.com/demos/sample-videos/small.mp4";
                    //voiceplayer.URL = "https://www.radiantmediaplayer.com/media/bbb-360p.mp4";
                    //voiceplayer.URL = "https://www.gmrtranscription.com/voicefiles/74563/74563_Tawanda ONeal-2.m4a";
                    voiceplayer.URL = FileName;
                    volumebar.Value = voiceplayer.settings.volume;
                    btnPartialSave.Enabled = true;
                    btnSaveTask.Enabled = true;
                }
                else
                {
                    btnPartialSave.Enabled = false;
                    btnSaveTask.Enabled = false;
                    Common.ShowInformationDialog("Sorry!!! Currently This Screen is only supporting Voice to text transcription in desktop application. For Text to text transcription please Open .");
                }
                waitForm.Close();
                //this.Enabled = true;
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message.ToString());
                this.Enabled = true;

            }
        }


    }
}
