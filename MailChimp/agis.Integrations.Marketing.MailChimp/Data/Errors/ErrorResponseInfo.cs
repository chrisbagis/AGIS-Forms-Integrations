using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Errors
{
    public class ErrorResponseInfo
    {
        public string status { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string error { get; set; }
    }
}
