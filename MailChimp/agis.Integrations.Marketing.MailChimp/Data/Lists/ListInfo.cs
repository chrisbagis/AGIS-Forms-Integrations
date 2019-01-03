using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class ListInfo
    {
        public string id { get; set; }
        public int web_id { get; set; }
        public string name { get; set; }
        public string date_created { get; set; }
        public bool email_type_option { get; set; }
        public bool use_awesomebar { get; set; }
        public string default_from_name { get; set; }
        public string default_from_email { get; set; }
        public string default_subject { get; set; }
        public string default_language { get; set; }
        public double list_rating { get; set; }
        public string subscribe_url_short { get; set; }
        public string subscribe_url_long { get; set; }
        public string beamer_address { get; set; }
        public string visibility { get; set; }
        public ListStats stats { get; set; }
        public List<string> modules { get; set; }

        public ListInfo()
        {
            stats = new ListStats();
            modules = new List<string>();
        }
    }
}
