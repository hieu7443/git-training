using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace CustomMvc.Foundation.Extensions
{
    public static class XmlExtensions
    {
        public static JToken XmlToJToken(this string file)
        {
            JProperty property = XDocument.Load(file).Root.ToJToken().First as JProperty;
            return property.Value;
        }
        public static JToken ToJToken(this XObject xml)
        {
            string json = JsonConvert.SerializeXNode(xml);
            return JToken.Parse(json);
        }
    }
}