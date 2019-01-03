using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using agis.Integrations.Social.Twitter.Services;
using agis.Integrations.Social.Twitter.Util;
using System.IO;
using System.Web.Script.Serialization;
using agis.Integrations.Social.Twitter.Data.Authentication;
using agis.Integrations.Social.Twitter.Data.Tweets;

namespace agis.Integrations.Social.Twitter
{
    public class TwitterAPI
    {

        #region --- Services ---

        private RestClient RestClient { get; set; }
        private AuthenticationService AuthenticationService { get; set; }
        private StatusService StatusService { get; set; }

        #endregion --- Services ---

        #region --- Properties ---

        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string BearerToken { get; set; }

        #endregion --- Properties ---

        public TwitterAPI()
        {
            RestClient = new RestClient(this);
            AuthenticationService = new AuthenticationService(RestClient);
            StatusService = new StatusService(RestClient);
        }


        #region --- Authentication ---

        public OAuth2Token GetApplicationToken()
        {
            return AuthenticationService.GetApplicationToken();
        }

        #endregion --- Authentication ---

        #region --- Statuses ---

        public List<Tweet> GetUserTimeline(string idField, string fieldValue, int count)
        {
            return StatusService.GetUserTimeline(idField, fieldValue, count);
        }

        #endregion --- Statuses ---
    }
}
