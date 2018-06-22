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
            TempData["DoctorId"] = id;
            TempData.Keep();
            DoctorRepository r = new DoctorRepository();
            var doctor = r.GetDoctorById(id);
            return View(doctor);
        }

        public ActionResult GetAvailabilities(int id)
        {
            TempData["DoctorId"] = id;
            TempData.Keep();
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
            ModelClinic context = new ModelClinic();
            a.DoctorId = Convert.ToInt32(TempData["DoctorId"]); // this need to be get from login
            a.Date = (DateTime)(Convert.ToDateTime(formCollection[1]));
            a.AvailableFrom = (DateTime)(a.Date + new TimeSpan(Convert.ToInt32(formCollection[2]), 0, 0));
            a.AvailableTo = (DateTime)(a.Date + new TimeSpan(Convert.ToInt32(formCollection[3]), 0, 0));
            a.AppointmentDuration = Convert.ToInt32(formCollection[4]);


            bool CanAddAvailability = true;
            var list = (from av in context.availabilities where av.DoctorId == a.DoctorId select av).ToList();
            foreach (availability x in list)
            {
                if (a.AvailableFrom >= x.AvailableFrom && a.AvailableFrom <= x.AvailableTo) { CanAddAvailability = false; }

            }
            if (CanAddAvailability)
            {

                context.availabilities.Add(a);
                context.SaveChanges();
                TempData["notice"] = "Successfully added Availability";
                RedirectToAction("GetAvailabilities", new { id = TempData["DoctorId"] });

            }
            if (!CanAddAvailability)
            {
                TempData["notice"] = "Not Added because of time overlapping";


            }
            return View();

        }

        public ActionResult MyProfile(int id)
        {
            DoctorRepository r = new DoctorRepository();
            var doctor = r.GetDoctorById(id);
            return View(doctor);
        }
        public ActionResult EditDoctor(int id)
        {
            DoctorRepository r = new DoctorRepository();
            var doctor = r.GetDoctorById(id);
            return View(doctor);

        }
        [HttpPost]
        public ActionResult EditDoctor(doctor doc)
        {
            ModelClinic context = new ModelClinic();
            var d = context.doctors.Single(x => x.Id == doc.Id);
            int returnValue = 0;
            d.Id = doc.Id;
            d.FirstName = doc.FirstName;
            d.LastName = doc.LastName;
            d.Phone = doc.Phone;
            d.Speciality = doc.Speciality;
            d.Email = doc.Email;
            d.UserName = doc.UserName;
            d.LoginPassWord = doc.LoginPassWord;
            returnValue = context.SaveChanges();
            if (returnValue > 0)
            { TempData["notice"] = " User profiles have been updated successfully."; }
            else
            { TempData["notice"] = "No updates have been written to the database."; }
            return View("EditDoctor");

        }

    }
}