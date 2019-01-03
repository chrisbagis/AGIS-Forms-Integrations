using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace agis.Integrations.Marketing.MailChimp.Data.Lists
{
    public class MergeFieldInfo
    {
        /// <summary>
        /// Name of the merge field
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Denotes whether the field is required (true) or not (false)
        /// </summary>
        public bool req { get; set; }

        /// <summary>
        /// The "data type" of this merge var. One of the options accepted by field_type in lists/merge-var-add
        /// </summary>
        public string field_type { get; set; }

        /// <summary>
        /// Whether or not this field is visible to list subscribers
        /// </summary>
        [DataMember(Name = "public")]
        public bool @public { get; set; }

        /// <summary>
        /// Whether the list owner has this field displayed on their list dashboard
        /// </summary>
        public bool show { get; set; }

        /// <summary>
        /// The order the list owner has set this field to display in
        /// </summary>
        public int order { get; set; }

        /// <summary>
        /// The default value the list owner has set for this field
        /// </summary>
        [DataMember(Name = "default")]
        public string @default { get; set; }

        /// <summary>
        /// The helptext for this field
        /// </summary>
        public string helptext { get; set; }

        /// <summary>
        /// The width of the field to be used
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// The merge tag that's used for forms and lists/subscribe() and listUpdateMember()
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// For radio and dropdown field types, an array of the options available
        /// </summary>
        public List<string> choices { get; set; }

        /// <summary>
        /// An unchanging id for the merge var
        /// </summary>
        public int id { get; set; }

        public MergeFieldInfo()
        {
            choices = new List<string>();
        }
    }
}
