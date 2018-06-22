using Clinic4.Models;
//using Clinic4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic4.Controllers
{
    public class PatientController : Controller
    {
        PatientRepository repo = new PatientRepository();

        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyProfile(int id)
        {
            patient patient = repo.GetPatientByID(id);
            return PartialView(patient);
        }

        public ActionResult BookAppointment()
        {
            return View();
        }
        public ActionResult ToManageAppointments(int id)
        {

            var appointments = repo.GetPatientAppointmentsById(id);
            return View(appointments);
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult partialTestView()
        {
            return PartialView();
        }

        public ActionResult DisplayAvailableSlots()
        {
            ModelClinic context = new ModelClinic();
            var Slots = context.display_available_slots.ToList();
            return View(Slots);
        }
    }
}