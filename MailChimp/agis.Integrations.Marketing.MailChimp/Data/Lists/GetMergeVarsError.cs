using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class GetMergeVarsError
    {
        /// <summary>
        /// the passed list id that failed
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// the resulting error code
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// the resulting error message
        /// </summary>
        public string msg { get; set; }
    }
}
