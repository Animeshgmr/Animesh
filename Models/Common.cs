using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMRTTranscription.Models
{
    class Common
    {
        public static void ShowErrorDialog(string errorMgs)
        {
            MessageBox.Show("Error: " + errorMgs, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformationDialog(string Msg)
        {
            MessageBox.Show(Msg, "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, false));
            builder.Append(RandomInt(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch = '\0';
            int i = 0;
            while (i < size)
            {
                ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));

                if (ch == '[')
                {
                    ch = 'h';

                }

                builder.Append(ch);
                i += 1;
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }


        public static bool CheckIfFileIsBeingUsed(string fileName)
        {

            try
            {

                File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            }

            catch (Exception exp)
            {

                return true;

            }

            return false;

        }


        public static bool KillProcess(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }


        public static List<int> getRunningProcesses()
        {
            List<int> ProcessIDs = new List<int>();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains("WINWORD"))
                {
                    ProcessIDs.Add(clsProcess.Id);
                }
            }
            return ProcessIDs;
        }


        public static void killProcesses(List<int> processesbeforegen, List<int> processesaftergen)
        {
            foreach (int pidafter in processesaftergen)
            {
                bool processfound = false;
                foreach (int pidbefore in processesbeforegen)
                {
                    if (pidafter == pidbefore)
                    {
                        processfound = true;
                        Process clsProcess = Process.GetProcessById(pidafter);
                        clsProcess.Kill();
                    }
                }

                if (processfound == false)
                {
                    Process clsProcess = Process.GetProcessById(pidafter);
                    clsProcess.Kill();
                }
            }
        }


        public static bool FileIsLocked(string strFullFileName)
        {
            bool blnReturn = false;
            System.IO.FileStream fs;
            try
            {
                fs = System.IO.File.Open(strFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
                fs.Close();
            }
            catch (System.IO.IOException ex)
            {
                blnReturn = true;
            }
            return blnReturn;
        }


       public static string WriteTextFile(string Msg,string filepath)
        {
            string text = Msg + Environment.NewLine;

            File.AppendAllText(filepath, text);          

            return "";
        }


        public static string GrantAccess(string fullPath)
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
            return "";
        }

        public static void Empty(String dirpath)
        {
            string windowsInstallPath = Path.GetPathRoot(Environment.SystemDirectory).ToLower().ToString();
            windowsInstallPath = windowsInstallPath + "\\Temp\\GMRT";
            windowsInstallPath = windowsInstallPath + "\\documents\\";
            windowsInstallPath = windowsInstallPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
            windowsInstallPath = windowsInstallPath + dirpath;
            System.IO.DirectoryInfo di = new DirectoryInfo(windowsInstallPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static string GetHMSfromSecond(double sec)
        {             
            TimeSpan t = TimeSpan.FromSeconds(sec);
            string Hms = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            return Hms;
        }

        public static bool CheckOpened(string name)
        {
            try
            {
                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    if (frm.Name == name)
                    {
                        frm.Close();
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                Common.ShowErrorDialog(ex.Message);
                return false;
            }
            return false;
        }
    }
}
