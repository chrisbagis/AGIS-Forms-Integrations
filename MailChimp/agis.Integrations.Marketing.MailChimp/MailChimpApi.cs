using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Marketing.MailChimp.Services;
using agis.Integrations.Marketing.MailChimp.Util;
using agis.Integrations.Marketing.MailChimp.Data.Lists;
using agis.Integrations.Marketing.MailChimp.Data.Emails;

namespace agis.Integrations.Marketing.MailChimp
{
    public class MailChimpApi
    {
        public enum Format
        {
            json = 1,
            xml = 2
        }

        #region --- Properties ---

        public bool UseHttps { get; set; }
        public string ApiKey { get; set; }
        public Format OutputFormat { get; set; }
        public string DataCenter
        {
            get
            {
                if (string.IsNullOrEmpty(ApiKey) || !ApiKey.Contains("-"))
                {
                    return string.Empty;
                }

                return ApiKey.Substring(ApiKey.IndexOf("-") + 1);

            }
        }

        #endregion --- Properties ---

        #region --- Services ---

        private RestClient RestClient { get; set; }
        private ListService ListService { get; set; }

        #endregion --- Services ---

        public MailChimpApi()
        {
            RestClient = new RestClient(this);
            ListService = new ListService(RestClient);
            UseHttps = true;
            OutputFormat = Format.json;
        }

        #region --- Lists ---

        public List<InterestGroupGroupingInfo> GetInterestGroupings(string listId, bool counts = false)
        {
            return ListService.GetInterestGroupings(ApiKey, listId, counts);
        }

        public EmailInfo SubscribeToList(string listId, EmailInfo email, IDictionary<string, object> merge_vars, string email_type, bool double_optin, bool update_existing, bool replace_interests, bool send_welcome)
        {
            return ListService.SubscribeToList(ApiKey, listId, email, merge_vars, email_type, double_optin, update_existing, replace_interests, send_welcome);
        }

        public GetListsResult GetLists(ListFilters filters, int? start, int? limit, string sort_field, string sort_dir)
        {
            return ListService.GetLists(ApiKey, filters, start, limit, sort_field, sort_dir);
        }

        public GetMergeVarsResult GetMergeVars(IEnumerable<string> listIds)
        {
            return ListService.GetMergeVars(ApiKey, listIds);
        }

        #endregion --- Lists ---
    }
}
