using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Social.Twitter.Data.Common
{
    public class UserMention
    {
        public string name { get; set; }
        public int[] indices { get; set; }
        public string screen_name { get; set; }
        public Int64 id { get; set; }
        public string id_str { get; set; }
    }
}
