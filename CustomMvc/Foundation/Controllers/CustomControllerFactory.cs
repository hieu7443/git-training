using CustomMvc.Foundation.Extensions;
using CustomMvc.Foundation.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomMvc.Foundation.Controllers
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private void RenderRequestContext(RequestContext requestContext, string[] paths, ref string controllerName)
        {
            string controller = "CustomFeature.Controllers.CustomFeatureController";
            string assembly = "CustomFeature";
            string action = "Index";
            Type controllerType = Type.GetType($"{controller}, {assembly}");
            controllerName = controllerType.GetControllerName();
            requestContext.RouteData.Values["controller"] = controllerName; //just for show on futher processes
            requestContext.RouteData.Values["action"] = action;
        }
        private string[] GetRequestPaths(RequestContext requestContext)
        {
            List<string> result = new List<string>();
            foreach (var requestStr in requestContext.HttpContext.Request.Url.AbsolutePath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(requestStr);
            }
            return result.ToArray();
        }
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            string requestedController = requestContext.GetRouteValue("controller");
            string requestedAction = requestContext.GetRouteValue("action");
            if (requestedController == "Base" && (requestedAction == "Robots" || requestedAction == "Sitemap"))
            {
                return base.CreateController(requestContext, controllerName);
            }
            string[] paths = GetRequestPaths(requestContext);
            RenderRequestContext(requestContext, paths, ref controllerName);
            Controller controller = (Controller)base.CreateController(requestContext, controllerName); //system looks for matched controller on all assemblies
            controller.ViewEngineCollection.Clear();
            controller.ViewEngineCollection.Add(new CustomRazorViewEngine());
            return controller;
        }
    }
}