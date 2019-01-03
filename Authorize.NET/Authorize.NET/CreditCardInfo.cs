using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public class CreditCardInfo
    {
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CardCode { get; set; }
    }
}
