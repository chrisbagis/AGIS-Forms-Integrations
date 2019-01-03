using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace agis.Integrations.Marketing.MailChimp
{
    public class RestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Body { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }

        public bool HasData
        {
            get
            {
                return !string.IsNullOrEmpty(Body);
            }
        }

        public T Get<T>() where T : class
        {
            T t = default(T);
            if (this.HasData && !String.IsNullOrEmpty(this.Body))
            {
                //JavaScriptSerializer ser = new JavaScriptSerializer();
                //t = ser.Deserialize<T>(this.Body);

                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(Body);
                    ms.Write(buffer, 0, buffer.Length);
                    ms.Position = 0;
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                    t = ser.ReadObject(ms) as T;
                }
            }

            return t;
        }
    }
}
