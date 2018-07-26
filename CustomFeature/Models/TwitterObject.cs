using CustomMvc.Foundation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.Models
{
    public class TwitterObject
    {
        [DynamicField("created_at")]
        public string created_at { get; set; }
        [DynamicField("id")]
        public long id { get; set; }
        [DynamicField("full_text")]
        public string full_text { get; set; }
        [DynamicField("truncated")]
        public bool truncated { get; set; }
        [DynamicField("entities")]
        public TwitterEntity entities { get; set; }
    }
    public class TwitterEntity
    {
        [DynamicField("user_mentions")]
        public TwttierUserMention[] user_mentions { get; set; }
        [DynamicField("media")]
        public TwitterMedia[] media { get; set; }
    }
    public class TwttierUserMention
    {
        [DynamicField("screen_name")]
        public string screen_name { get; set; }
        [DynamicField("name")]
        public string name { get; set; }
        [DynamicField("id")]
        public long id { get; set; }
        [DynamicField("indices")]
        public int[] indices { get; set; }
    }
    public class TwitterMedia
    {
        [DynamicField("id")]
        public long id { get; set; }
        [DynamicField("indices")]
        public int[] indices { get; set; }
        [DynamicField("media_url")]
        public string media_url { get; set; }
    }
}