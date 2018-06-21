using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic4.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return PartialView();
        }

        public ActionResult BookAppointment()
        {
            return View();
        }
        public ActionResult ManageAppointments()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult partialTestView()
        {
            return PartialView();
        }
    }
}