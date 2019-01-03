using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace agis.Integrations.Social.Twitter.Util
{
    public class TwitterDate
    {
        public static DateTime FromString(string value)
        {
            DateTime result = DateTime.MinValue;
            const string format = "ddd MMM dd HH:mm:ss %zzzz yyyy";
            return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
        }
    }
}
