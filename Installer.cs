using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMRTTranscription
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }

        public override void Uninstall(IDictionary savedState)
        {
            String p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GMRTTranscription");
            string[] ss = Directory.GetDirectories(p, "GMRTTranscription.*");
            foreach (string s in ss)
            {
                if (MessageBox.Show("Delete " + s + "?", "Delete Settings?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Directory.Delete(s, true);
            }
            base.Uninstall(savedState);

            // base.Uninstall(savedState);

            // string appFileName = Environment.GetCommandLineArgs()[0];
            // string directory = Path.GetDirectoryName(appFileName);
            // GMRTTranscription.Models.Common.ShowInformationDialog(directory);
            //File.Delete(directory);
            // GMRTTranscription.Properties.Settings.Default.Reset();
            // // Delete folder here.
        }
    }
}
