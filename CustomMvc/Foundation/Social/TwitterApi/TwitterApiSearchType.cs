using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Social
{
    public struct TwitterApiSearchTypes
    {
        public static readonly TwitterApiSearchType Search = new TwitterApiSearchType()
        {
            Url = "https://api.twitter.com/1.1/search/tweets.json",
            Parameters = new Dictionary<string, string>() {
                { "count", "2" },
                { "tweet_mode", "extended" },
                { "q", "@hieu7443" }
            }
        };
        public static readonly TwitterApiSearchType Timeline = new TwitterApiSearchType()
        {
            Url = "https://api.twitter.com/1.1/statuses/user_timeline.json",
            Parameters = new Dictionary<string, string>() {
                { "count", "2" },
                { "tweet_mode", "extended" },
                { "screen_name", "hieu7443" }
            }
        };
    }
    public class TwitterApiSearchType
    {
        public string Url { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}