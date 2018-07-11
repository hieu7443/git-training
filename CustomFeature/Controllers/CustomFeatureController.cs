using CustomFeature.TwitterApi;
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
        [HttpGet]
        public ActionResult JsonAction()
        {
            object statuses = null;
            using (TwitterApiClient client = new TwitterApiClient())
            {
                if (client.Authorized)
                {
                    statuses = client.GetStatuses(TwitterApiSearchTypes.Timeline);
                }
            }
            return Json(new {
                data = statuses
            }, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}