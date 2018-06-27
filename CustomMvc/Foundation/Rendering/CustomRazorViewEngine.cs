using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomMvc.Foundation.Rendering
{
    public class CustomRazorViewEngine : RazorViewEngine
    {
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new CustomRazorView(
                controllerContext,
                partialPath,
                null,
                false,
                base.FileExtensions,
                base.ViewPageActivator
            );
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new CustomRazorView(
                controllerContext,
                viewPath,
                masterPath,
                false,
                base.FileExtensions,
                base.ViewPageActivator
            );
        }
    }
}