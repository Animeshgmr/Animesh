using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMRTTranscription.Models;
using System.Xml;
using System.Web.Script.Serialization;
using System.Collections;

namespace GMRTTranscription
{
    public partial class Login_Form : Form
    {        
        public Login_Form()
        {
            InitializeComponent();            
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            txtUserName.Text = String.IsNullOrEmpty(GMRTTranscription.Properties.Settings.Default.UserName.Trim().ToString()) ? "" : GMRTTranscription.Properties.Settings.Default.UserName.Trim().ToString(); 
            txtPassword.Text = String.IsNullOrEmpty(GMRTTranscription.Properties.Settings.Default.Password.Trim().ToString()) ? "" : GMRTTranscription.Properties.Settings.Default.Password.Trim().ToString();
            if (txtUserName.Text == "" && txtPassword.Text =="")
            {
                CheckboxRemember.Checked = false;
            }
            else
            {
                CheckboxRemember.Checked = true;

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnLogin.Text.ToLower().ToString() == "please wait...")
                {
                    return;
                }

                if (IsValidForm())
                {
                    btnLogin.Text = "Please wait...";                                          
                    
                    string UserName = String.IsNullOrEmpty(txtUserName.Text) ? "" : txtUserName.Text.Trim().ToString();
                    string Password = String.IsNullOrEmpty(txtPassword.Text) ? "" : txtPassword.Text.Trim().ToString();

                    //Login API
                    string JSONDATA = "{ \"email\":\"" + UserName + "\", \"password\":\"" + Password + "\" }";
                    string webServiceUrl = "/api/adminlogin/validatetypistlogin";
                    string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);

                    bool isValidLogin = false;
                    string ErrorMessage = "";
                    var jss = new JavaScriptSerializer();
                    var dictionary = jss.Deserialize<dynamic>(sResponse);
                    foreach (KeyValuePair<string, object> item in dictionary)
                    {
                        string Key = String.IsNullOrEmpty(item.Key) ? "" : item.Key.ToString().ToLower().Trim();
                        object Value = item.Value == null ? "" : item.Value.ToString().ToLower().Trim();
                        if(Key == "result")
                        {
                            if(Value.ToString() == "success")
                            {
                                
                                isValidLogin = true;

                                if (CheckboxRemember.Checked)                              
                                {
                                    GMRTTranscription.Properties.Settings.Default.UserName = txtUserName.Text;
                                    GMRTTranscription.Properties.Settings.Default.Password = txtPassword.Text;
                                    GMRTTranscription.Properties.Settings.Default.Save();
                                }
                                else
                                {                                    
                                    GMRTTranscription.Properties.Settings.Default.Reset();

                                }


                            }
                            else
                            {
                                isValidLogin = false;
                                ErrorMessage = "Invalid Username or password";
                            }
                            break;
                        }

                    }

                    if (isValidLogin)
                    {
                        Global.Password = Password;
                        Global.Emailid = UserName;
                        Global.UserId = UserName;

                        //Store all information into global variable
                        Global.IsLogin = true;
                        foreach (KeyValuePair<string, object> item in dictionary)
                        {
                            string Key = String.IsNullOrEmpty(item.Key) ? "" : item.Key.ToString().ToLower().Trim();
                            object Value = item.Value == null ? "" : item.Value.ToString();
                            if (Key == "userid")
                            {
                                Global.VendorId = Value.ToString();
                            }
                            else if (Key == "emailid")
                            {
                                Global.Emailid = Value.ToString();
                                Global.UserId = Value.ToString();
                            }
                            else if (Key == "fname")
                            {
                                Global.FName = Value.ToString();
                            }
                            else if (Key == "lname")
                            {
                                Global.LName = Value.ToString();
                            }
                            else if (Key == "company_name")
                            {
                                Global.CompanyName = Value.ToString();
                            }
                            else if (Key == "address")
                            {
                                Global.CompanyAddress = Value.ToString();
                            }
                            else if (Key == "company_url")
                            {
                                Global.CompanyURL = Value.ToString();
                            }
                            else if (Key == "phone")
                            {
                                Global.PhoneNo = Value.ToString();
                            }
                        }

                        this.Hide();
                        MDIForm MF = new MDIForm();
                        MF.Show();
                        //Dashboard df = new Dashboard();
                        //df.Show();
                    }
                    else
                    {
                        Common.ShowErrorDialog(ErrorMessage);
                        btnLogin.Text = "Login";
                    }                                                         
                }                            
            }
            catch(Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
                btnLogin.Text = "Login";
            }
        }

        private bool IsValidForm()
        {
            try
            {
                bool sOut = true;

                string UserName = String.IsNullOrEmpty(txtUserName.Text) ? "" : txtUserName.Text.Trim().ToString();
                string Password = String.IsNullOrEmpty(txtPassword.Text) ? "" : txtPassword.Text.Trim().ToString();
                if (UserName == "")
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter Username");
                    txtUserName.Focus();
                    return sOut;
                }
                else if (Password == "")
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter Password");
                    txtPassword.Focus();
                    return sOut;
                }
                else
                {
                    return sOut;
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
                return false;
            }
        }

        private void btnLogin_EnabledChanged(object sender, EventArgs e)
        {            
            try
            {
                btnLogin.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Prompt user to save his data                
            {
                var confirmResult = MessageBox.Show("Are you sure want to close this application?", "Confirmation!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (confirmResult != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }

                if (confirmResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            if (e.CloseReason == CloseReason.WindowsShutDown) // Autosave and clear up ressources                    
            {
                Application.Exit();
                return;
            }

            if (e.CloseReason == CloseReason.ApplicationExitCall)                   
            {
                //Save all data in database then exit only

                Application.Exit();
                return;
            }
        }

        private void CheckboxRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
