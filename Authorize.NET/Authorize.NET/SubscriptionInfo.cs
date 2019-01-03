using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public enum IntervalUnit
    {
        Days,
        Weeks,
        Months,
        Years
    }

    public class SubscriptionInfo
    {
        public string SubscriptionName { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public short TotalOccurrences { get; set; }
        public short Interval { get; set; }
        public IntervalUnit IntervalUnit { get; set; }
    }
}
