using System;
using agis.Integrations.Social.Twitter.Data.Users;
using agis.Integrations.Social.Twitter.Util;
using agis.Integrations.Social.Twitter.Data.Common;

namespace agis.Integrations.Social.Twitter.Data.Tweets
{
    public class Tweet
    {
        public string created_at { get; set; }
        public Entities entities { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public string filter_level { get; set; }
        public Int64 id { get; set; }
        public string id_str { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public Int64? in_reply_to_status_id { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public Int64? in_reply_to_user_id { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public int retweet_count { get; set; }
        public bool retweeted { get; set; }
        public string source { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public User user { get; set; }
        public bool withheld_copyright { get; set; }
        public string[] withheld_in_countries { get; set; }
        public string withheld_scope { get; set; }

        public DateTime created_at_date
        {
            get
            {
                return TwitterDate.FromString(this.created_at);
            }
        }

        public string timeline_timestamp
        {
            get
            {
                DateTime createdUTC = created_at_date.ToUniversalTime();
                TimeSpan timeSince = DateTime.UtcNow - createdUTC;

                if (timeSince.TotalHours > 24)
                {
                    return createdUTC.ToLocalTime().Date.ToString("d MMM");
                }

                if (timeSince.TotalHours >= 1)
                {
                    return string.Format("{0}h", Convert.ToInt32(timeSince.TotalHours));
                }
                else if (timeSince.TotalMinutes >= 1)
                {
                    return string.Format("{0}m", Convert.ToInt32(timeSince.TotalMinutes));
                }
                else
                {
                    return string.Format("{0}s", Convert.ToInt32(timeSince.TotalSeconds));
                }
            }
        }

        public string text_with_links
        {
            get
            {
                string result = this.text;

                if (entities != null)
                {

                    if (entities.urls != null)
                    {
                        foreach (Url url in entities.urls)
                        {
                            result = result.Replace(url.url, string.Format("<a href=\"{0}\" target=\"twitterlink\">{1}</a>", url.url, url.display_url));
                        }
                    }

                    if (entities.user_mentions != null)
                    {
                        foreach (UserMention um in entities.user_mentions)
                        {
                            result = result.Replace(string.Format("@{0}", um.screen_name), string.Format("<a href=\"https://www.twitter.com/{0}\" target=\"twitterlink\">@{0}</a>", um.screen_name));
                        }
                    }

                    if (entities.hashtags != null)
                    {
                        foreach (HashTag ht in entities.hashtags)
                        {
                            result = result.Replace(string.Format("#{0}", ht.text), string.Format("<a href=\"https://www.twitter.com/search?q=%23{0}\" target=\"twitterlink\">@{0}</a>", ht.text));
                        }
                    }
                }

                return result;
            }
        }
    }
}
