﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace agis.Integrations.Marketing.MailChimp.Util
{
    public static class Extensions
    {
        public static string ToJSON(this object data)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            return ser.Serialize(data);
        }
    }
}
