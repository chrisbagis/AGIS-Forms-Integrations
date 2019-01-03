using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Marketing.MailChimp.Util;

namespace agis.Integrations.Marketing.MailChimp.Services
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
