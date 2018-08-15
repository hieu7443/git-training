using CustomMvc.Foundation.SEO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CustomMvc.Foundation.Controllers
{
    public class _BaseController : Controller
    {
        public ActionResult Index()
        {
            return View(CustomContext.Presentation.Layout.Source);
        }
        public ActionResult Sitemap()
        {
            var sitemapNodes = SitemapRepository.GetSitemapNodes(this.Url);
            string xml = SitemapRepository.GetSitemapDocument(sitemapNodes);
            return Content(xml, "text/xml", Encoding.UTF8);
        }
        public ActionResult Robots()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("disallow: /error/");
            stringBuilder.AppendLine("allow: /error/foo");
            stringBuilder.Append("sitemap: ");
            stringBuilder.AppendLine(this.Url.RouteUrl("Sitemap", null, this.Request.Url.Scheme).TrimEnd('/'));

            return Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }
    }
}