using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agis.Integrations.Social.Twitter.Util;
using agis.Integrations.Social.Twitter.Data.Tweets;

namespace agis.Integrations.Social.Twitter.Services
{
    public class StatusService: BaseService
    {
        public StatusService(RestClient restClient):base(restClient)
        {

        }

        public List<Tweet> GetUserTimeline(string idField, string fieldValue, int count)
        {
            List<Tweet> timeline = null;

            RestResponse response = RestClient.Get("[VER]/statuses/user_timeline.json", string.Format("{0}={1}", idField, fieldValue), string.Format("count={0}", count));

            if (response.HasData)
            {
                timeline = response.Get<List<Tweet>>();
            }
            else
            {
                if (response.HasError)
                {
                    throw new Exception(response.Message);
                }
            }

            return timeline;
        }
    }
}
