using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace agis.Integrations.Social.Twitter.Util
{
    public class RestClient
    {
        private const string API_VERSION = "1.1";
        private const string CONSUMER_KEY = "W69N3tZbbwBbMuB6F6Zg";
        private const string CONSUMER_SECRET = "CzGOVEkQdMjEYDmw6GI4k7H7LBFxtiIewakIr1X8o8";

        private string AuthorizationHeader
        {
            get
            {
                if (!string.IsNullOrEmpty(TwitterApi.BearerToken))
                {
                    return string.Format("Authorization: Bearer {0}", TwitterApi.BearerToken);
                }

                byte[] authorizationBytes = System.Text.ASCIIEncoding.Default.GetBytes(string.Format("{0}:{1}", HttpUtility.UrlEncode(TwitterApi.ConsumerKey), HttpUtility.UrlEncode(TwitterApi.ConsumerSecret)));
                return string.Format("Authorization: Basic {0}", Convert.ToBase64String(authorizationBytes));
            }
        }

        #region --- Properties ---

        public TwitterAPI TwitterApi { get; private set; }

        #endregion --- Properties ---

        public RestClient(TwitterAPI twitterApi)
        {
            this.TwitterApi = twitterApi;
        }

        public RestClient()
        {

        }

        private string GetWebMethodUrl(string path, params string[] parameters)
        {
            path = path.Replace("[VER]", API_VERSION);
            string paramString = parameters.Length > 0 ? string.Format("?{0}", string.Join("&", parameters)) : string.Empty;
            string url = string.Format("https://api.twitter.com/{0}{1}", path, paramString);

            return url;
        }

        private HttpWebRequest CreateRequest(string path, string method, params string[] parameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetWebMethodUrl(path, parameters: parameters));
            request.UseDefaultCredentials = false;
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            if (!string.IsNullOrEmpty(AuthorizationHeader))
            {
                request.Headers.Add(AuthorizationHeader);
            }

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
    }

}
