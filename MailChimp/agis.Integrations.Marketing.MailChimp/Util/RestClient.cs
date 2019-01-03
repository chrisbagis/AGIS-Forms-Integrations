using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace agis.Integrations.Marketing.MailChimp.Util
{
    public class RestClient
    {
        private const string API_VERSION = "2.0";

        #region --- Properties ---

        public MailChimpApi MailChimpApi { get; private set; }

        #endregion --- Properties ---

        public RestClient(MailChimpApi mailChimpApi)
        {
            this.MailChimpApi = mailChimpApi;
        }

        public RestClient()
        {

        }

        private string GetWebMethodUrl(string path, params string[] parameters)
        {
            path = path.Replace("[VER]", API_VERSION);
            path = path.Replace("[FORMAT]", MailChimpApi.OutputFormat.ToString());
            string paramString = parameters.Length > 0 ? string.Format("?{0}", string.Join("&", parameters)) : string.Empty;
            string url = string.Format("{0}://{1}.api.mailchimp.com/{2}{3}", MailChimpApi.UseHttps ? "https" : "http", MailChimpApi.DataCenter, path, paramString);

            return url;
        }

        private HttpWebRequest CreateRequest(string path, string method, params string[] parameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetWebMethodUrl(path, parameters: parameters));
            request.UseDefaultCredentials = false;
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            return request;
        }

        public RestResponse Get(string path, params string[] parameters)
        {
            RestResponse response = new RestResponse();
            HttpWebRequest request = CreateRequest(path, "GET", parameters);

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());

                response.StatusCode = webResponse.StatusCode;
                response.Message = webResponse.StatusDescription;
                response.Body = responseReader.ReadToEnd();

                return response;
            }
            catch (WebException wex)
            {
                response.HasError = true;
                if (wex.Response != null)
                    response.StatusCode = ((HttpWebResponse)wex.Response).StatusCode;
                else
                    response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = wex.Message;

                return response;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return response;
            }

        }

        public RestResponse Post(string path, string data, params string[] parameters)
        {
            RestResponse response = new RestResponse();
            HttpWebRequest request = CreateRequest(path, "POST", parameters);

            if (!string.IsNullOrEmpty(data))
            {
                byte[] requestBytes = System.Text.ASCIIEncoding.UTF8.GetBytes(data);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
            }

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());

                response.StatusCode = webResponse.StatusCode;
                response.Message = webResponse.StatusDescription;
                response.Body = responseReader.ReadToEnd();

                return response;
            }
            catch (WebException wex)
            {
                response.HasError = true;
                if (wex.Response != null)
                {
                    StreamReader responseReader = new StreamReader(wex.Response.GetResponseStream());
                    response.StatusCode = ((HttpWebResponse)wex.Response).StatusCode;
                    response.Body = responseReader.ReadToEnd();
                }
                else
                    response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = wex.Message;

                return response;
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return response;
            }

        }
    }

}
