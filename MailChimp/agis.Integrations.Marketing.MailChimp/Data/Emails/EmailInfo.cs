using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Emails
{
    public class EmailInfo
    {
        public string email { get; set; }
        public string euid { get; set; }
        public string leid { get; set; }

        public EmailInfo()
        {
            email = string.Empty;
            euid = string.Empty;
            leid = string.Empty;
        }
    }
}
