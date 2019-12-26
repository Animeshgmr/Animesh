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
    public partial class MyProfile : Form
    {
        Color backColorOnFocus;
        Color foreColorOnFocus;
        Color backColorOnFocusLost;
        Color foreColorOnFocusLost;

        public MyProfile()
        {
            InitializeComponent();

            backColorOnFocus = new Color();
            backColorOnFocus = Color.Silver; //Color.FromArgb(52, 152, 219);

            foreColorOnFocus = new Color();
            foreColorOnFocus = Color.Black;

            backColorOnFocusLost = new Color();
            backColorOnFocusLost = Color.White;

            foreColorOnFocusLost = new Color();
            foreColorOnFocusLost = Color.Black;
        }        

        private void MyProfile_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProfileDetails();
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }            
        }

        private void btnProfileUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnProfileUpdate.Text.ToLower().ToString() == "please wait...")
                {
                    return;
                }

                if (IsValidProfileForm())
                {
                    btnProfileUpdate.Text = "Please wait...";

                    string FName = String.IsNullOrEmpty(txtFName.Text) ? "" : txtFName.Text.Trim().ToString();
                    string LName = String.IsNullOrEmpty(txtLName.Text) ? "" : txtLName.Text.Trim().ToString();
                    string CompanyName = String.IsNullOrEmpty(txtCompanyName.Text) ? "" : txtCompanyName.Text.Trim().ToString();
                    string CompanyAddress = String.IsNullOrEmpty(txtCompanyAddress.Text) ? "" : txtCompanyAddress.Text.Trim().ToString();
                    string CompanyURL = String.IsNullOrEmpty(txtCompanyURL.Text) ? "" : txtCompanyURL.Text.Trim().ToString();
                    string PhoneNumber = String.IsNullOrEmpty(txtPhoneNumber.Text) ? "" : txtPhoneNumber.Text.Trim().ToString();

                    string JSONDATA = "{ \"userid\":\"" + Global.VendorId + "\", \"email\":\"" + Global.Emailid + "\", \"fname\":\"" + FName + "\", \"lname\":\"" + LName + "\", \"company_name\":\"" + CompanyName + "\", \"company_url\":\"" + CompanyURL + "\", \"address\":\"" + CompanyAddress + "\", \"phone\":\"" + PhoneNumber + "\" }";
                    string webServiceUrl = "/api/admintypistprofile/Typistprofile_update";
                    string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);

                    bool isSuccess = false;
                    var jss = new JavaScriptSerializer();
                    var dictionary = jss.Deserialize<dynamic>(sResponse);
                    foreach (KeyValuePair<string, object> item in dictionary)
                    {
                        string Key = String.IsNullOrEmpty(item.Key) ? "" : item.Key.ToString().ToLower().Trim();
                        object Value = item.Value == null ? "" : item.Value.ToString().ToLower().Trim();
                        if (Key == "result")
                        {
                            if (Value.ToString().ToLower().ToString() == "success")
                            {
                                isSuccess = true;
                            }
                            else
                            {
                                isSuccess = false;
                            }
                            break;
                        }

                    }

                    string Message = "";
                    foreach (KeyValuePair<string, object> item in dictionary)
                    {
                        string Key = String.IsNullOrEmpty(item.Key) ? "" : item.Key.ToString().ToLower().Trim();
                        object Value = item.Value == null ? "" : item.Value.ToString().ToLower().Trim();
                        if (Key == "details")
                        {
                            Message = Value.ToString();                            
                            break;
                        }
                    }

                    if (isSuccess)
                    {
                        Common.ShowInformationDialog("Profile updated successfully...");
                        Global.FName = FName;
                        Global.LName = LName;
                        Global.CompanyName = CompanyName;
                        Global.CompanyAddress = CompanyAddress;
                        Global.CompanyURL = CompanyURL;
                        Global.PhoneNo = PhoneNumber;
                    }
                    else
                    {
                        Common.ShowInformationDialog(Message);
                    }
                    btnProfileUpdate.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void btnPasswordUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPasswordUpdate.Text.ToLower().ToString() == "please wait...")
                {
                    return;
                }

                if (IsValidPasswordForm())
                {
                    btnPasswordUpdate.Text = "Please wait...";
                    //Update Password API
                    string NewPassword = String.IsNullOrEmpty(txtNewPassword.Text) ? "" : txtNewPassword.Text.Trim().ToString();
                    string JSONDATA = "{ \"venid\":\"" + Global.VendorId + "\", \"newpassword\":\"" + NewPassword + "\" }";
                    string webServiceUrl = "/api/vendorpasswordupdate/update_vendor_password";
                    string sResponse = WebService.CallWebServiceWithJSONData(webServiceUrl, JSONDATA);                    
                    Common.ShowInformationDialog("Password updated successfully...");
                    Global.Password = NewPassword;
                    btnPasswordUpdate.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtFName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtFName.SelectAll();
                txtFName.BackColor = backColorOnFocus;
                txtFName.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtFName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtFName.BackColor = backColorOnFocusLost;
                txtFName.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtFName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtLName.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtLName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLName.SelectAll();
                txtLName.BackColor = backColorOnFocus;
                txtLName.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLName.BackColor = backColorOnFocusLost;
                txtLName.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }

        }

        private void txtLName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtCompanyName.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.SelectAll();
                txtCompanyName.BackColor = backColorOnFocus;
                txtCompanyName.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.BackColor = backColorOnFocusLost;
                txtCompanyName.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtCompanyAddress.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyAddress_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyAddress.SelectAll();
                txtCompanyAddress.BackColor = backColorOnFocus;
                txtCompanyAddress.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyAddress_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCompanyAddress.BackColor = backColorOnFocusLost;
                txtCompanyAddress.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyAddress_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtCompanyURL.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyURL_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyURL.SelectAll();
                txtCompanyURL.BackColor = backColorOnFocus;
                txtCompanyURL.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyURL_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCompanyURL.BackColor = backColorOnFocusLost;
                txtCompanyURL.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtCompanyURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtPhoneNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPhoneNumber.SelectAll();
                txtPhoneNumber.BackColor = backColorOnFocus;
                txtPhoneNumber.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPhoneNumber.BackColor = backColorOnFocusLost;
                txtPhoneNumber.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtPhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    btnProfileUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtOldPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOldPassword.SelectAll();
                txtOldPassword.BackColor = backColorOnFocus;
                txtOldPassword.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtOldPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOldPassword.BackColor = backColorOnFocusLost;
                txtOldPassword.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtOldPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtNewPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNewPassword.SelectAll();
                txtNewPassword.BackColor = backColorOnFocus;
                txtNewPassword.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNewPassword.BackColor = backColorOnFocusLost;
                txtNewPassword.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtNewPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    txtConfirmPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.BackColor = backColorOnFocus;
                txtConfirmPassword.ForeColor = foreColorOnFocus;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                txtConfirmPassword.BackColor = backColorOnFocusLost;
                txtConfirmPassword.ForeColor = foreColorOnFocusLost;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Enter))
                {
                    btnPasswordUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }




        #region Private Method
        private bool IsValidProfileForm()
        {
            try
            {
                bool sOut = true;

                string FName = String.IsNullOrEmpty(txtFName.Text) ? "" : txtFName.Text.Trim().ToString();
                string LName = String.IsNullOrEmpty(txtLName.Text) ? "" : txtLName.Text.Trim().ToString();
                string CompanyName = String.IsNullOrEmpty(txtCompanyName.Text) ? "" : txtCompanyName.Text.Trim().ToString();
                string CompanyAddress = String.IsNullOrEmpty(txtCompanyAddress.Text) ? "" : txtCompanyAddress.Text.Trim().ToString();
                string CompanyURL = String.IsNullOrEmpty(txtCompanyURL.Text) ? "" : txtCompanyURL.Text.Trim().ToString();
                string PhoneNumber = String.IsNullOrEmpty(txtPhoneNumber.Text) ? "" : txtPhoneNumber.Text.Trim().ToString();

                if (String.IsNullOrEmpty(FName))
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter First Name");
                    txtFName.Focus();
                    return sOut;
                }
                else if (String.IsNullOrEmpty(LName))
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter Last Name");
                    txtLName.Focus();
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

        private bool IsValidPasswordForm()
        {
            try
            {
                bool sOut = true;

                string OldPassword = String.IsNullOrEmpty(txtOldPassword.Text) ? "" : txtOldPassword.Text.Trim().ToString();
                string NewPassword = String.IsNullOrEmpty(txtNewPassword.Text) ? "" : txtNewPassword.Text.Trim().ToString();
                string ConfirmPassword = String.IsNullOrEmpty(txtConfirmPassword.Text) ? "" : txtConfirmPassword.Text.Trim().ToString();

                if (String.IsNullOrEmpty(OldPassword))
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter Old Password");
                    txtOldPassword.Focus();
                    return sOut;
                }
                else if (OldPassword != Global.Password)
                {
                    sOut = false;
                    Common.ShowInformationDialog("Invalid Old Password!!!");
                    txtOldPassword.Focus();
                    return sOut;
                }
                else if (String.IsNullOrEmpty(NewPassword))
                {
                    sOut = false;
                    Common.ShowInformationDialog("Please Enter New Password");
                    txtNewPassword.Focus();
                    return sOut;
                }                
                else if (NewPassword != ConfirmPassword)
                {
                    sOut = false;
                    Common.ShowInformationDialog("Confirm Password Do Not Match!!!");
                    txtConfirmPassword.Focus();
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

        private void LoadProfileDetails()
        {
            try
            {
                txtEmailId.Text = Global.Emailid;
                txtFName.Text = Global.FName;
                txtLName.Text = Global.LName;
                txtCompanyName.Text = Global.CompanyName;
                txtCompanyAddress.Text = Global.CompanyAddress;
                txtCompanyURL.Text = Global.CompanyURL;
                txtPhoneNumber.Text = Global.PhoneNo;
            }
            catch (Exception ex)
            {
                Common.ShowErrorDialog(ex.Message.ToString());
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            MDIForm.CloseTab();
        }
    }
}
