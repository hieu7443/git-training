using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFeature.TwitterApi
{
    public class TwitterData : Dictionary<string, object>
    {
        public TwitterData(JToken data)
        {
            foreach (var child in data)
            {
                var property = (JProperty)child;
                this.Add(property.Name, GetValue(property.Value));
            }
        }
        private object GetValue(JToken data)
        {
            object value = null;
            switch (data.Type)
            {
                case JTokenType.Array:
                    value = data.Select(i => GetValue(i)).ToArray();
                    break;
                case JTokenType.Object:
                    value = GetProperTy(data);
                    break;
                case JTokenType.Boolean:
                    value = data.Value<bool>();
                    break;
                case JTokenType.Bytes:
                    value = data.Value<byte[]>();
                    break;
                case JTokenType.Date:
                    value = data.Value<DateTime>();
                    break;
                case JTokenType.Float:
                    value = data.Value<double>();
                    break;
                case JTokenType.Guid:
                    value = data.Value<Guid>();
                    break;
                case JTokenType.Integer:
                    value = data.Value<long>();
                    break;
                case JTokenType.TimeSpan:
                    value = data.Value<TimeSpan>();
                    break;
                case JTokenType.Uri:
                    value = data.Value<Uri>();
                    break;
                default:
                    value = data.Value<string>();
                    break;
            }
            return value;
        }
        private Dictionary<string, object> GetProperTy(JToken data)
        {
            return data.Select(i => (JProperty)i).ToDictionary(i => i.Name, i => GetValue(i.Value));
        }
        public static TwitterData[] RenderFromTimeline(JToken data)
        {
            return data.Select(i => new TwitterData(i)).ToArray();
        }
    }
}