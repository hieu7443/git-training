using CustomFeature.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.TwitterApi
{
    public class TwitterData : DynamicObject
    {
        public static TwitterData[] RenderFromTimeline(JToken data)
        {
            return data.Select(i => i.RenderObject<TwitterData>()).ToArray();
        }
    }
}