using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class GetListsResult
    {
        public int total { get; set; }
        public List<ListInfo> data { get; set; }

        public GetListsResult()
        {
            data = new List<ListInfo>();
        }
    }
}
