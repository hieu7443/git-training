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

            //var view = (BuildManagerCompiledView)viewContext.View;
            //var context = viewContext.HttpContext;
            //var path = context.Server.MapPath(view.ViewPath);
            //var viewName = Path.GetFileNameWithoutExtension(path);
            //var controller = viewContext.RouteData.GetRequiredString("controller");
            //var js = context.Server.MapPath(
            //    string.Format(
            //        "~/ClientApp/Controllers/{0}/{0}.{1}.js",
            //        viewName,
            //        controller
            //    )
            //);
            //if (File.Exists(js))
            //{
            //    writer.WriteLine(
            //        string.Format(
            //            "<script type=\"text/javascript\">{0}</script>",
            //            File.ReadAllText(js)
            //        )
            //    );
            //}
        }
    }
}