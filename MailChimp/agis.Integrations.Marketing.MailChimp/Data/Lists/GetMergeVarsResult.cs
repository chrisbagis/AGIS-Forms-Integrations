using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class GetMergeVarsResult
    {
        /// <summary>
        /// the number of subscribers successfully found on the list
        /// </summary>
        public int success_count { get; set; }

        /// <summary>
        /// the number of subscribers who were not found on the list
        /// </summary>
        public int error_count { get; set; }

        /// <summary>
        /// Array of lists with merge fields
        /// </summary>
        public List<ListMergeFieldInfo> data { get; set; }

        /// <summary>
        /// Array of errors
        /// </summary>
        public List<GetMergeVarsError> errors { get; set; }

        public GetMergeVarsResult()
        {
            data = new List<ListMergeFieldInfo>();
            errors = new List<GetMergeVarsError>();
        }
    }
}
