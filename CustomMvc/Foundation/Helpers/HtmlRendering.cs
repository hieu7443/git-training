using CustomMvc.Foundation.Controllers;
using CustomMvc.Foundation.Extensions;
using CustomMvc.Foundation.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomMvc.Foundation.Helpers
{
    public static class HtmlRendering
    {
        public static IHtmlString InvokeAction(string assemblyName, string typeName, string actionName, object[] actionParams)
        {
            Type controllerType = Type.GetType($"{typeName}, {assemblyName}");
            IControllerFactory factory = DependencyResolver.Current.GetService<IControllerFactory>() ?? new DefaultControllerFactory();
            string controllerName = controllerType.Name.Replace("Controller", "").Replace("controller", "");
            Controller controller = (Controller)factory.CreateController(HttpContext.Current.Request.RequestContext, controllerName);
            RouteData route = new RouteData();
            route.Values.Add("controller", controllerName);
            route.Values.Add("action", actionName);
            ControllerContext newContext = new ControllerContext(new HttpContextWrapper(HttpContext.Current), route, controller);
            controller.ControllerContext = newContext;
            controller.ViewEngineCollection.Clear();
            controller.ViewEngineCollection.Add(new CustomRazorViewEngine());

            object controllerInstance = Convert.ChangeType(controller, controllerType);
            MethodInfo action = controllerType.GetMethod(actionName);
            ActionResult actionResult = (ActionResult)action.Invoke(controllerInstance, actionParams);
            return new MvcHtmlString(actionResult.Capture(newContext));
        }
    }
}