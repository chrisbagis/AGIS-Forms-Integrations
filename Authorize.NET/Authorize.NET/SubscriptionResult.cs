using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public class SubscriptionResult
    {
        public bool Successful { get; set; }
        public long SubscriptionId { get; set; }
        public string Message { get; set; }
    }
}
