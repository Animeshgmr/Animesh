using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMRTTranscription
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + new Guid()))
            {
                if (!mutex.WaitOne(0, false))
                {
                    GMRTTranscription.Models.Common.ShowInformationDialog("Information: Application already running");                   
                    return;
                }

                if (mutex.WaitOne(0, false)==true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login_Form());
                    //Application.Run(new MyTestCode());
                }

                //System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                //System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                //if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                //{
                //    //If the administrator, is directly run
                //    Application.Run(new Login_Form());
                //}
                //else
                //{                    
                //    //Create a startup object
                //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //    startInfo.UseShellExecute = true;
                //    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                //    startInfo.FileName = Application.ExecutablePath;
                //    //Set the start action, make sure to run as Administrator
                //    startInfo.Verb = "runas";
                //    try
                //    {
                //        System.Diagnostics.Process.Start(startInfo);
                //    }
                //    catch
                //    {
                //        return;
                //    }
                //    //Sign out
                //    Application.Exit();
                //}

            }
        }
    }
}
