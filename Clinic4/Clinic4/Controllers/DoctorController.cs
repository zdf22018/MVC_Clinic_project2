using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic4.Models;

namespace Clinic4.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult GetDoctorSchedule(int id)
        {
            ViewData["DoctorId"] = id;
            DoctorRepository r = new DoctorRepository();
            var schedule = r.GetDoctorSchedule(id);
            return View(schedule);
        }
        public ActionResult GetAllPatients()
        {
            DoctorRepository r = new DoctorRepository();
            var plist = r.GetAllPatients();
            return View(plist);
        }

        public ActionResult GetDoctorById(int id)
        {
            ViewData["DoctorId"] = id;
            DoctorRepository r = new DoctorRepository();
            var doctor = r.GetDoctorById(id);
            return View(doctor);
        }

        public ActionResult GetAvailabilities(int id)
        {
            ViewData["DoctorId"] = id;
            DoctorRepository r = new DoctorRepository();
            var a = r.GetAvailabilities(id);
            return View(a);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult AddAvailability_get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult AddAvailability_post(FormCollection formCollection)
        {
            availability a = new availability();
            a.DoctorId = 13; // this need to be get from login
            a.Date = (DateTime)(Convert.ToDateTime(formCollection[1]));
            a.AvailableFrom = (DateTime)(a.Date + new TimeSpan(Convert.ToInt32(formCollection[2]), 0, 0));
            a.AvailableTo = (DateTime)(a.Date + new TimeSpan(Convert.ToInt32(formCollection[3]), 0, 0));
            a.AppointmentDuration = Convert.ToInt32(formCollection[4]);
            DoctorRepository r = new DoctorRepository();

            try
            {
                r.AddAvailability(a);
                return RedirectToAction("GetAvailabilities");
            }
            catch
            {
                return View();
            }


        }
    }
}