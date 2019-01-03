using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class ListMergeFieldInfo
    {
        /// <summary>
        /// the list id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// the list name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// merge fields in this list
        /// </summary>
        public List<MergeFieldInfo> merge_vars { get; set; }
    }
}
