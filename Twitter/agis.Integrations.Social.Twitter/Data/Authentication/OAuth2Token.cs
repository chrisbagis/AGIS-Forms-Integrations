using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Social.Twitter.Data.Authentication
{
    public class OAuth2Token
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
    }
}
