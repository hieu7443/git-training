using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CustomMvc.Foundation.Extensions
{
    public static class RequestContextExtensions
    {
        public static string GetRouteValue(this RequestContext requestContext, string key)
        {
            if (requestContext == null || requestContext.RouteData == null || !requestContext.RouteData.Values.ContainsKey(key))
                return null;
            return (string)requestContext.RouteData.Values[key];
        }
    }
}