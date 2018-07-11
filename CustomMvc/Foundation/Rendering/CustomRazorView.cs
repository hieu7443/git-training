using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomMvc.Foundation.Rendering
{
    public class CustomRazorView : RazorView
    {
        public CustomRazorView(ControllerContext controllerContext, string viewPath, string layoutPath, bool runViewStartPages, IEnumerable<string> viewStartFileExtensions, IViewPageActivator viewPageActivator)
        : base(controllerContext, viewPath, layoutPath, runViewStartPages, viewStartFileExtensions, viewPageActivator)
        {

        }

        public override void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            base.Render(viewContext, writer);
        }

        protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
        {
            base.RenderView(viewContext, writer, instance);
        }
    }
}