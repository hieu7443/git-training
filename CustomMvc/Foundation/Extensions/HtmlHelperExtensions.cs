using CustomMvc.Foundation.Controllers;
using CustomMvc.Foundation.Helpers;
using CustomMvc.Foundation.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomMvc.Foundation.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PlaceHolder(this HtmlHelper html, string name)
        {
            IEnumerable<Models.ItemRendering> renderings = CustomContext.Presentation?.GetRenderings(name);
            List<IHtmlString> htmls = new List<IHtmlString>();
            foreach (Models.ItemRendering rendering in renderings)
            {
                using (new RenderSession(rendering))
                {
                    string action = rendering.Rendering.Action;
                    string controller = rendering.Rendering.Controller;
                    string assembly = rendering.Rendering.Assembly;
                    htmls.Add(HtmlRendering.InvokeAction(assembly, controller, action, null));
                }
            }
            return new HtmlString(String.Join("", htmls));
        }
    }
}