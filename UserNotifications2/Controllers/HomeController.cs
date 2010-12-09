using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserNotifications.alerts;
using System.IO;

namespace UserNotifications.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(AlertMetaData alertmetadata)
        {
            return View(alertmetadata);
        }

        public ActionResult Index()
        {
            var alertMetaData =
                new AlertMetaData()
                {

                    CssFile = @"../../alerts/css/alerts.css",

                    ErrorMessage = "Error Message",
                    ErrorClickToClose = true,
                    ErrorFadeOut = 2000,
                    
                    InfoMessage = "Info Message",
                    InfoClickToClose = true,
                    InfoFadeOut = 0,
                    
                    OKMessage = "OK Message",
                    OKClickToClose = false,
                    OKFadeOut = 4000,

                    WarningMessage = "Warning Message",
                    WarningClickToClose = true,
                    WarningFadeOut = 10000
                };


            return View(alertMetaData);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
