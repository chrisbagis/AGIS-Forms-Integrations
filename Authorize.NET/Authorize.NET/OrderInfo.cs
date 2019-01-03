using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public class OrderInfo
    {
        public bool TestTransaction { get; set; }
        public string InvoiceNumber { get; set; }
        public string OrderSummary { get; set; }
        public double Amount { get; set; }
    }
}
