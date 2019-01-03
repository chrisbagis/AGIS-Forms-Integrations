using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class InterestGroupInfo
    {
        public string bit { get; set; }
        public string name { get; set; }
        public int display_order { get; set; }
        public int? subscribers { get; set; }
    }
}
