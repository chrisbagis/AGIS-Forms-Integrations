using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Social.Twitter.Data.Authentication;
using agis.Integrations.Social.Twitter.Util;

namespace agis.Integrations.Social.Twitter.Services
{
    public class AuthenticationService : BaseService
    {

        public AuthenticationService(RestClient restClient)
            : base(restClient)
        {

        }

        public OAuth2Token GetApplicationToken()
        {
            OAuth2Token token = null;

            RestResponse response = RestClient.Post("oauth2/token", "grant_type=client_credentials");

            if (response.HasData)
            {
                token = response.Get<OAuth2Token>();
            }
            else
            {
                if (response.HasError)
                {
                    throw new Exception(response.Message);
                }
            }

            return token;
        }
    }
}
