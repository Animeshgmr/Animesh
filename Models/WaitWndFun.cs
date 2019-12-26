using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GMRTTranscription.Models
{
    public class WaitWndFun
    {
        PopUpForm loadingForm;
        Thread loadthread;

        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcessEx));
            loadthread.Start();

        }
        public void Show(Form parent)
        {
         //   loadingForm.BringToFront();
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
            loadthread.Start(parent);


        }

        public void Close()
        {
            if (loadingForm != null)
            {
                loadingForm.BeginInvoke(new System.Threading.ThreadStart(loadingForm.CloseLoadingForm));
                loadingForm = null;
                loadthread = null;
                
            }
        }

        private void LoadingProcessEx()
        {
            loadingForm = new PopUpForm();
            loadingForm.BringToFront();
            
            loadingForm.ShowDialog();
            
        }
        private void LoadingProcessEx(object parent)
        {
            Form Cparent = parent as Form;
            loadingForm = new PopUpForm(Cparent);
            
            loadingForm.BringToFront();
            loadingForm.ShowDialog();
            
        }
     
    }
}
