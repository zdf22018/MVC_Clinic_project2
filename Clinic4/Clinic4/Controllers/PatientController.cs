using Clinic4.Models;
using Clinic4.ViewModels;
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

        // returns a view to book an appointment
        public ActionResult BookAppointment(int id)
        {
            TakeAppointmentViewModel model = new TakeAppointmentViewModel
            {
                Doctors = repo.GetAllDoctors(),
                PatientId = id,
                Timeslots = repo.GetTimeslots()
            };

            return View(model);
        }

        // registers the appointment if valid
        /*
        [HttpPost]
        public ActionResult RegisterAppointment(TakeAppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("BookAppointment");
            }
            // if timeslot taken
            if (repo.GetTimeslotId(model.Start) == 0)
            {
                return View("BookAppointment");
            }

            appointment apt = new appointment
            {
                PatientId = model.PatientId,
                TimeSlotId = repo.GetTimeslotId(model.Start)
            };
            repo.AddAppointment(apt);

            return RedirectToAction("Patient", "Home", new { appointmentAdded = true });
        }
        */
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

        public ActionResult DisplayAvailableSlotsForDate()
        {
            
            DateTime selectedDate = DateTime.Parse(Request.QueryString["selectedDate"]);
            
            //var Slots = context.display_available_slots.ToList();
            return PartialView("DisplayAvailableSlots", repo.GetTimeslotsByStartDate(selectedDate));
        }
        /*
        public ActionResult TimeslotAvailable(DateTime datetime)
        {
            if (Request.IsAjaxRequest())
            {
                timeslot ts = repo.GetTimeslotByStartTime(datetime);

                if (ts == null)
                {
                    return PartialView("UnavailableSlot");
                }
                else return View();
            }
            else
            {
                return View();
            }
        }
        */
    }
}