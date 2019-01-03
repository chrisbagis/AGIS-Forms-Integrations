using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class InterestGroupGroupingInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string form_field { get; set; }
        public List<InterestGroupInfo> groups { get; set; }

        public InterestGroupGroupingInfo()
        {
            groups = new List<InterestGroupInfo>();
        }
    }
}
