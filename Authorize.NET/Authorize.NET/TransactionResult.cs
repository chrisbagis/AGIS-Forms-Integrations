using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public class TransactionResult
    {
        public bool Approved { get; set; }
        public Response Response { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseReasonCode { get; set; }
        public string Message { get; set; }
        public string RawResponse { get; set; }
    }

    public enum Response
    {
        Approved,
        Declined,
        Error,
        HeldForReview
    }
}
