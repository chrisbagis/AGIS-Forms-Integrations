using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace agis.Integrations.Social.Twitter
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

        public T Get<T>() where T: class
        {
            T t = default(T);
            if (this.HasData && !String.IsNullOrEmpty(this.Body))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                t = ser.Deserialize<T>(this.Body);
            }

            return t;
        }
    }
}
