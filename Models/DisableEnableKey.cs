using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GMRTTranscription.Models
{
    class DisableEnableKey
    {

        #region
        [DllImport("user32.dll")]

        public static extern int RegisterHotKey( int id, int fsModifiers, int vk); [DllImport("user32.dll")]
        public static extern int UnregisterHotKey ( int id);
        #endregion


        #region
      //  Modifier Constants and Variables
// Constants for modifier keys


    private const int USE_ALT = 1;
        private const int USE_CTRL = 2;
        private const  int USE_SHIFT = 4;
        private const int USE_WIN = 8;
        // Hot key ID tracker

        short mHotKeyId = 0;
        #endregion

        public void RegisterGlobalHotKey(Keys hotkey, int modifiers)
        {
            try

            {
                // increment the hot key value - we are just identifying

                // them with a sequential number since we have multiples

                mHotKeyId++;

                if (mHotKeyId > 0)
                {
                    // register the hot key combination

                    if  (RegisterHotKey(mHotKeyId, modifiers, Convert.ToInt16(hotkey)) == 0)
                    {
                        // tell the user which combination failed to register 

                        // this is useful to you, not an end user; the user

                        // should never see this application run

                        MessageBox.Show("Error: " + mHotKeyId.ToString() + " - " + Marshal.GetLastWin32Error().ToString(),"Hot Key Registration");
                    }
                }
            }
            catch

            {
                // clean up if hotkey registration failed -

                // nothing works if it fails

                UnregisterGlobalHotKey();
            }
        }


        public void UnregisterGlobalHotKey()
        {
            // loop through each hotkey id and

            // disable it


            for(int i = 0; i < mHotKeyId; i++)
            {
                UnregisterHotKey( i);
            }
        }
    }
}
