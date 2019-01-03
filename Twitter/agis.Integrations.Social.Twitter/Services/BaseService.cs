using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Social.Twitter.Util;

namespace agis.Integrations.Social.Twitter.Services
{
    public class BaseService
    {
        protected RestClient RestClient { get; private set; }

        public BaseService(RestClient restClient)
        {
            if (restClient == null)
                throw new ArgumentNullException("restClient");

            this.RestClient = restClient;
        }
    }
}
