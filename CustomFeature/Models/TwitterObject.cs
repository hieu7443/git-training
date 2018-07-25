using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.Models
{
    public class TwitterObject
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string full_text { get; set; }
        public bool truncated { get; set; }
        public TwitterEntity entities { get; set; }
    }
    public class TwitterEntity
    {
        public TwttierUserMention[] user_mentions { get; set; }
        public TwitterMedia[] media { get; set; }
    }
    public class TwttierUserMention
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public long id { get; set; }
        public int[] indices { get; set; }
    }
    public class TwitterMedia
    {
        public long id { get; set; }
        public int[] indices { get; set; }
        public string media_url { get; set; }
    }
}