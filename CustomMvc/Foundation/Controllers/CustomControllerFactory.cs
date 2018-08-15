using CustomMvc.Foundation.Extensions;
using CustomMvc.Foundation.Models;
using CustomMvc.Foundation.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomMvc.Foundation.Controllers
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private void RenderRequestContext(RequestContext requestContext, string[] paths, ref string controllerName)
        {
            controllerName = "_Base";
            string action = "Index";
            if (paths.FirstOrDefault() == "api")
            {
                if (paths.Length < 3)
                    throw new HttpException((int)HttpStatusCode.BadRequest, "Bad request");
                controllerName = paths[1];
                action = paths[2];
            }
            else
            {
                Item item = Repository.GetItem(String.Join("/", paths));
                if (item == null || item.Presentation == null)
                    throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
                RenderCustomContext(item);
            }
            requestContext.RouteData.Values["controller"] = controllerName; //just for show on futher processes
            requestContext.RouteData.Values["action"] = action;
        }
        private void RenderCustomContext(Item item)
        {
            CustomContext.Current = item;
            CustomContext.Presentation = item.Presentation;
            CustomContext.ProcessedPlaceholders = new List<string>();
        }
        private string[] GetRequestPaths(RequestContext requestContext)
        {
            List<string> result = new List<string>();
            var requestUrl = requestContext.HttpContext.Request.Url.AbsolutePath;
            if (!String.IsNullOrEmpty(requestContext.HttpContext.Request.Url.Query))
                requestUrl = requestUrl.Replace(requestContext.HttpContext.Request.Url.Query, "");
            foreach (var requestStr in requestUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries))
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