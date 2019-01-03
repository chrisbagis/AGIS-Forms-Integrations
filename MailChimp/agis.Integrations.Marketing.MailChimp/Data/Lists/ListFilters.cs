using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class ListFilters
    {
        public string list_id { get; set; }
        public string list_name { get; set; }
        public string from_name { get; set; }
        public string from_email { get; set; }
        public string from_subject { get; set; }
        public string created_before { get; set; }
        public string created_after { get; set; }
        public bool exact { get; set; }
    }
}
