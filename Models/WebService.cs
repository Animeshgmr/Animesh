using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GMRTTranscription.Models
{
    class WebService
    {
        /// <summary>
        /// For calling the WebService 
        /// </summary>
        /// <param name="webServiceUrl">Pass the URL OF WebService</param>
        /// <returns></returns>
        public static string GetWebServiceResponse(string webServiceUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webServiceUrl);
                request.MaximumAutomaticRedirections = 4;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                sResponse = sResponse.Replace("\"", "");
                return sResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error :: Web Service Error :: " + ex.Message.ToString());
            }
        }

        public static string CallWebServiceWithXmlData(string webServiceUrl)
        {
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                string fileName = "test.xml";
                req = WebRequest.Create(webServiceUrl);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Method = "POST";        // Post method
                req.ContentType = "text/xml";     // content type
                // Wrap the request stream with a text-based writer
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream
                string XMLContent = GetContentFromFile(fileName);
                writer.WriteLine(XMLContent);
                writer.Close();
                // Send the data to the webserver
                rsp = req.GetResponse();

                Stream receiveStream = rsp.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                return sResponse;
            }
            catch (WebException webEx)
            {
                throw new Exception("Error: " + webEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
        }

        public static string CallWebServiceWithXmlData(string webServiceUrl, string XMLData)
        {
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                req = WebRequest.Create(webServiceUrl);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Method = "POST";        // Post method
                req.ContentType = "text/xml";     // content type
                // Wrap the request stream with a text-based writer
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream
                string XMLContent = XMLData;
                writer.WriteLine(XMLContent);
                writer.Close();
                // Send the data to the webserver
                rsp = req.GetResponse();

                Stream receiveStream = rsp.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                return sResponse;
            }
            catch (WebException webEx)
            {
                throw new Exception("Error: " + webEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
        }

        public static string CallWebServiceWithJSONData(string webServiceUrl, string JSONData)
        {
            webServiceUrl = Global.WEB_SERVICE_ROOT_URL + webServiceUrl;
            WebRequest req = null;
            WebResponse rsp = null;
            try
            {
                req = WebRequest.Create(webServiceUrl);
                //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
                req.Method = "POST";        // Post method
                req.ContentType = "application/json"; 
                // Wrap the request stream with a text-based writer
                StreamWriter writer = new StreamWriter(req.GetRequestStream());
                // Write the XML text into the stream
                string JSONContent = JSONData;
                writer.WriteLine(JSONContent);
                writer.Close();
                // Send the data to the webserver
                rsp = req.GetResponse();

                Stream receiveStream = rsp.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                return sResponse;
            }
            catch (WebException webEx)
            {
                throw new Exception("Error: " + webEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }
        }

        public static string GetContentFromFile(string file)
        {
            string fileName = file;
            string AppPath = System.Windows.Forms.Application.StartupPath.ToString().ToLower().ToString();
            AppPath = AppPath.Replace("\\bin\\debug", "").Replace("\\bin\\release", "");
            AppPath += "\\" + fileName;
            fileName = AppPath;

            StreamReader reader = new StreamReader(fileName);
            string sOut = reader.ReadToEnd();
            reader.Close();

            return sOut;
        }

        public static string GetIntialXML()
        {
            string sOut = "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>");
            sb.AppendFormat("<Text2Text>");
            sb.AppendFormat("<Signon>");
            sb.AppendFormat("<APIKey>{0}</APIKey>", "text2text-api-key");
            sb.AppendFormat("<Username>{0}</Username>", "text2text@admin.com");
            sb.AppendFormat("<Password>{0}</Password>", "text2text@pwd");
            sb.AppendFormat("</Signon>");
            sb.AppendFormat("##ActualTag##");
            sb.AppendFormat("</Text2Text>");
            sOut = sb.ToString();

            return sOut;
        }        

        public static string LowerCaseTags(string xml)
        {
            return Regex.Replace(
                xml,
                @"<[^<>]+>",
                m => { return m.Value.ToLower(); },
                RegexOptions.Multiline | RegexOptions.Singleline);
        }
        public static DataTable ConvertXMLIntoDataTableForWork(string XMLData)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("WorkId", Type.GetType("System.String"));
                dt.Columns.Add("Title", Type.GetType("System.String"));
                dt.Columns.Add("Heading1", Type.GetType("System.String"));
                dt.Columns.Add("Heading2", Type.GetType("System.String"));
                dt.Columns.Add("Heading3", Type.GetType("System.String"));

                XmlDocument xDoc = new XmlDocument();
                XmlDocument xDocResponse = new XmlDocument();

                xDoc.LoadXml(WebService.LowerCaseTags(XMLData));

                string ErrorMessage = xDoc.SelectSingleNode("text2text/error/errordescription").InnerText;

                if (String.IsNullOrEmpty(ErrorMessage))
                {
                    //WebService Successfull
                    DataRow dr = null;
                    XmlNodeList xnl = xDoc.SelectNodes("text2text/workdetails/work");
                    foreach (XmlNode xn in xnl)
                    {
                        dr = dt.NewRow();

                        dr["WorkId"] = xn.SelectSingleNode("workid").InnerText.ToString();
                        dr["Title"] = xn.SelectSingleNode("title").InnerText.ToString();
                        dr["Heading1"] = xn.SelectSingleNode("heading1").InnerText.ToString();
                        dr["Heading2"] = xn.SelectSingleNode("heading2").InnerText.ToString();
                        dr["Heading3"] = xn.SelectSingleNode("heading3").InnerText.ToString();

                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error :: ConvertXMLIntoDataTableForWork :: " + ex.Message.ToString());
            }
        }       

    }
}
