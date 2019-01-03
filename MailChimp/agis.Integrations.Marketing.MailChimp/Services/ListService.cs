using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Marketing.MailChimp.Util;
using agis.Integrations.Marketing.MailChimp.Data.Lists;
using agis.Integrations.Marketing.MailChimp.Data.Emails;
using agis.Integrations.Marketing.MailChimp.Data.Errors;

namespace agis.Integrations.Marketing.MailChimp.Services
{
    public class ListService : BaseService
    {

        public ListService(RestClient restClient)
            : base(restClient)
        {
        }

        public List<InterestGroupGroupingInfo> GetInterestGroupings(string apiKey, string listId, bool counts = false)
        {
            List<InterestGroupGroupingInfo> interestGroupings = null;
            var parameters = new
            {
                apikey = apiKey,
                id = listId,
                counts = counts.ToString()
            };

            RestResponse response = RestClient.Post("[VER]/lists/interest-groupings.[FORMAT]", parameters.ToJSON());

            if (response.HasError)
            {
                if (response.HasData)
                {
                    ErrorResponseInfo e = response.Get<ErrorResponseInfo>();

                    if (e.name == "List_InvalidOption") // List doesn't have interest groups
                        return new List<InterestGroupGroupingInfo>();

                    throw new Exception(string.Format("{0} ({1}) {2}",e.name,e.code,e.error));
                }

                throw new Exception(response.Message);
            }

            if (response.HasData)
            {
                interestGroupings = response.Get<List<InterestGroupGroupingInfo>>();
            }

            return interestGroupings;

        }

        public EmailInfo SubscribeToList(string apiKey, string listId, EmailInfo email, IDictionary<string, object> merge_vars, string email_type, bool double_optin, bool update_existing, bool replace_interests, bool send_welcome)
        {
            EmailInfo result = null;
            var parameters = new
            {
                apikey = apiKey,
                id = listId,
                email = email,
                merge_vars = merge_vars,
                email_type = email_type,
                double_optin = double_optin,
                update_existing = update_existing,
                replace_interests = replace_interests,
                send_welcome = send_welcome
            };

            RestResponse response = RestClient.Post("[VER]/lists/subscribe.[FORMAT]", parameters.ToJSON());

            if (response.HasError)
            {
                if (response.HasData)
                {
                    ErrorResponseInfo e = response.Get<ErrorResponseInfo>();
                    throw new Exception(string.Format("{0} ({1}) {2}", e.name, e.code, e.error));
                }

                throw new Exception(response.Message);
            }

            if (response.HasData)
            {
                result = response.Get<EmailInfo>();
            }

            return result;
        }

        public GetListsResult GetLists(string apiKey, ListFilters filters, int? start, int? limit, string sort_field, string sort_dir)
        {
            GetListsResult result = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("apikey", apiKey);
            parameters.Add("filters", filters);
            if (start.HasValue) parameters.Add("start", start.Value);
            if (limit.HasValue) parameters.Add("limit", limit.Value);
            if (!string.IsNullOrEmpty(sort_field)) parameters.Add("sort_field", sort_field);
            if (!string.IsNullOrEmpty(sort_dir)) parameters.Add("sort_dir", sort_dir);

            RestResponse response = RestClient.Post("[VER]/lists/list.[FORMAT]", parameters.ToJSON());

            if (response.HasError)
            {
                if (response.HasData)
                {
                    ErrorResponseInfo e = response.Get<ErrorResponseInfo>();
                    throw new Exception(string.Format("{0} ({1}) {2}", e.name, e.code, e.error));
                }

                throw new Exception(response.Message);
            }

            if (response.HasData)
            {
                result = response.Get<GetListsResult>();
            }
            
            return result;

        }

        public GetMergeVarsResult GetMergeVars(string apiKey, IEnumerable<string> listIds)
        {
            GetMergeVarsResult result = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("apikey", apiKey);
            parameters.Add("id", listIds);

            RestResponse response = RestClient.Post("[VER]/lists/merge-vars.[FORMAT]", parameters.ToJSON());

            if (response.HasError)
            {
                if (response.HasData)
                {
                    ErrorResponseInfo e = response.Get<ErrorResponseInfo>();
                    throw new Exception(string.Format("{0} ({1}) {2}", e.name, e.code, e.error));
                }

                throw new Exception(response.Message);
            }

            if (response.HasData)
            {
                result = response.Get<GetMergeVarsResult>();
            }
            
            return result;

        }
    }
}
