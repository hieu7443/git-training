using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFeature.Controllers
{
    public class CustomFeatureController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}