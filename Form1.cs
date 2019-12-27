using GMRTTranscription.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
      

namespace GMRTTranscription
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            object oMissing = System.Type.Missing;
            object outputFile = @"D:\grid.pdf";
            //Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref outputFile, ref oMissing,
            //             ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //             ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //             ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //doc.Activate();
            //int wordCount = doc.Words.Count;
            //wordApp.Quit();
         //   Common.ShowInformationDialog("Total Words: " + wordCount);
            webBrowser1.Navigate(outputFile.ToString());
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
            //Common.ShowInformationDialog(windowsInstallPath);
            
            string DirectoryName = windowsInstallPath + "\\Temp\\Documents\\MyFolder\\";
            GrantAccess(DirectoryName);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory);
            string DirectoryName = windowsInstallPath + "\\Temp\\Documents\\MyFolder\\";

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(DirectoryName);
            if (dir.Exists)
            {
                dir.Delete();
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
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

       
    }
}
