using CustomMvc.Foundation.Controllers;
using CustomMvc.Foundation.Helpers;
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
            string action = "Index";
            string controller = "TestFeature.Controllers.TestFeatureController";
            string assembly = "TestFeature";
            object[] actionParams = null;
            return HtmlRendering.InvokeAction(assembly, controller, action, actionParams);
        }
    }
}