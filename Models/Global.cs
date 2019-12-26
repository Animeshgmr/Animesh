using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMRTTranscription.Models
{
    class Global
    {
        #region Class Properties

        public static string ApplicationName = "Text 2 Text";
        public static bool IsLogin { get; set; }
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Emailid { get; set; }
        public static string RoleId { get; set; }
        public static string RoleName { get; set; }
        public static string VendorId { get; set; }
        public static string FName { get; set; }
        public static string LName { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyAddress { get; set; }
        public static string CompanyURL { get; set; }
        public static string PhoneNo { get; set; }
        public static string MobileNo { get; set; }
        public static string Address1 { get; set; }
        public static string Address2 { get; set; }
        public static string City { get; set; }
        public static string Vendor { get; set; }        
        public static Int64 FILE_ID { get; set; }
        public static string FILE_NAME { get; set; }
        public static Int64 WORK_ID { get; set; }
        public static bool FILE_SAVE_STATUS { get; set; }

        public static string WEB_SERVICE_ROOT_URL = "http://services.gmrtranscription.com/";

        public static string WEB_SERVICE_ROOT_URL_voiceFile = "http://localhost:56814/";

        #endregion        
    }
}
