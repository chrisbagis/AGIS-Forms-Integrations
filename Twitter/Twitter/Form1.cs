using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agis.Integrations.Social.Twitter;
using agis.Integrations.Social.Twitter.Data.Authentication;
using agis.Integrations.Social.Twitter.Data.Tweets;

namespace Twitter
{
    public partial class Form1 : Form
    {
        private TwitterAPI _api = null;

        public Form1()
        {
            InitializeComponent();

            _api = new TwitterAPI();

            _api.ConsumerKey = "W69N3tZbbwBbMuB6F6Zg";
            _api.ConsumerSecret = "CzGOVEkQdMjEYDmw6GI4k7H7LBFxtiIewakIr1X8o8";
        }

        private void ObtainToken_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BearerToken.Text))
            {
                OAuth2Token token = _api.GetApplicationToken();
                BearerToken.Text = token.access_token;
                _api.BearerToken = token.access_token;
            }
        }

        private void GetTimeline_Click(object sender, EventArgs e)
        {
            List<Tweet> timeline = _api.GetUserTimeline("screen_name", "agismarketing", 10);

            StringBuilder sb = new StringBuilder();

            foreach (Tweet t in timeline)
            {
                sb.AppendLine(t.text);
            }

            ResponseText.Text = sb.ToString();
        }
    }
}
