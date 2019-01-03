using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Social.Twitter.Data.Common
{
    public class Entities
    {
        public List<HashTag> hashtags { get; set; }
        public List<Url> urls { get; set; }
        public List<UserMention> user_mentions { get; set; }
    }
}
