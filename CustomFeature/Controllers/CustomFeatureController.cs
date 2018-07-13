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
            TwitterData[] statuses = null;
            using (TwitterApiClient client = new TwitterApiClient())
            {
                if (client.Authorized)
                {
                    statuses = client.GetStatuses(TwitterApiSearchTypes.Timeline);
                    if (statuses != null && statuses.Length > 0)
                    {
                        var status = statuses[0];
                        var test = status.GetObject("entities");
                        var test2 = status.GetObject<TwitterData>("entities");
                        var test3 = test2.GetObjectArray<TwitterData>("user_mentions");
                        var test4 = test2.GetObjectArray<TwitterData>("media");
                        var test5 = status.GetValue<long>("id");
                        var test6 = test3[0].GetValueArray<int>("indices");
                        var test7 = test3[0].GetValue<int>("non");
                        var test8 = test3[0].GetObject<TwitterData>("non");
                        var test9 = test3[0].GetObjectArray<TwitterData>("non");
                        var test10 = test3[0].GetValueArray<int>("non");
                    }
                }
            }
            return Json(new {
                data = statuses
            }, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}