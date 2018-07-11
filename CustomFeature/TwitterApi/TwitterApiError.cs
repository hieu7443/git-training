using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.TwitterApi
{
    public class TwitterApiError
    {
        [JsonProperty("errors")]
        public TwitterApiErrorMessage[] Messages { get; set; }
    }
    public class TwitterApiErrorMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}