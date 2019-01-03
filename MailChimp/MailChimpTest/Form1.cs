using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agis.Integrations.Marketing.MailChimp;
using agis.Integrations.Marketing.MailChimp.Data.Lists;
using agis.Integrations.Marketing.MailChimp.Data.Emails;

namespace MailChimpTest
{
    public partial class Form1 : Form
    {
        private MailChimpApi _api = null;

        public Form1()
        {
            InitializeComponent();

            _api = new MailChimpApi();
            _api.ApiKey = "1ff36b16ef1a8d2006e6a9f72f367351-us6"; // PAAutism.org
            _api.ApiKey = "a9636855aef143bce54a98f4405d326e-us5"; // agis
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<InterestGroupGroupingInfo> groupings = _api.GetInterestGroupings("ed84e944ac"); // PAAutism.org
            List<InterestGroupGroupingInfo> groupings = _api.GetInterestGroupings("a67a7d1cbe"); // agis
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> merge_vars = new Dictionary<string, object>();

            merge_vars.Add("FNAME", "Josh");
            merge_vars.Add("LNAME", "Randall");
            merge_vars.Add("ZIP", "17554");

            EmailInfo result = _api.SubscribeToList("ed84e944ac", new EmailInfo { email = "josh@ag-is.com" }, merge_vars, "html", false, true, true, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetListsResult resutl = _api.GetLists(null, null, null, string.Empty, string.Empty);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetMergeVarsResult result = _api.GetMergeVars(new string[] { "ed84e944ac" });
        }

    }
}
