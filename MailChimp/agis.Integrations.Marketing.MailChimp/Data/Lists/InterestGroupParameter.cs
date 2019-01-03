using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class InterestGroupParameter
    {
        public int? id { get; set; }
        public string name { get; set; }
        public List<string> groups { get; set; }

        public InterestGroupParameter()
        {
            groups = new List<string>();
        }
    }
}
