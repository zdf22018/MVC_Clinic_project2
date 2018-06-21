using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic4.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["loggedIn"] = false;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Admin()
        {


            return View();
        }
        public ActionResult Doctor()
        {


            return View();
        }
        public ActionResult Patient()
        {


            return View();
        }
    }
}