using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomMvc.Foundation.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string GenerateAbsoluteUrl(this UrlHelper helper, string path, bool forceHttps = false)
        {
            const string HTTPS = "https";
            var uri = helper.RequestContext.HttpContext.Request.Url;
            var scheme = forceHttps ? HTTPS : uri.Scheme;
            var host = uri.Host;
            var port = (forceHttps || uri.Scheme == HTTPS) ? string.Empty : (uri.Port == 80 ? string.Empty : ":" + uri.Port);

            return string.Format("{0}://{1}{2}/{3}", scheme, host, port, string.IsNullOrEmpty(path) ? string.Empty : path.TrimStart('/'));
        }
    }
}