using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic4.Models;

namespace Clinic4.Models
{
    public class PatientRepository
    {
        ModelClinic context = new ModelClinic();

        public patient GetPatientByID(int id)
        {
            return (from p in context.patients where p.Id == id select p).SingleOrDefault();
        }

        public List<display_appointements_for_Patient> GetPatientAppointmentsById(int id)
        {

            var apt = (from x in context.display_appointements_for_Patient where x.PatientId == id select x).ToList();


            return apt;

        }

        public List<doctor> GetAllDoctors()
        {

            return (from d in context.doctors select d).ToList();

        }

        public void AddAppointment(appointment apt)
        {

            context.appointments.Add(apt);
            context.SaveChanges();

        }

        /*
        public int GetTimeslotId(DateTime datetime)
        {
            timeslot timeslot = 
                (from ts in context.timeslots
                 where ts.SlotStart == datetime
                 select ts).SingleOrDefault();

            
            if (timeslot == null)
            {
                return 0;
            }

            if (timeslot.IsAvailable == true)
            {
                return timeslot.Id;
            }
            else
            {
                return 0;
            }
        }
        */
        public List<timeslot> GetTimeslots()
        {
            return (from ts in context.timeslots select ts).ToList();
        }

        public List<timeslot> GetAvailableTimeslots()
        {
            return (from ts in context.timeslots where ts.IsAvailable == true select ts).ToList();
        }

        public List<display_available_slots> GetTimeslotsByStartDate(DateTime date)
        {
            var timeslots = (from ts in context.display_available_slots select ts).ToList();

            List<display_available_slots> validTimeslots = new List<display_available_slots>();

            foreach (var ts in timeslots)
            {
                if (ts.Start.ToShortDateString().Equals(date.ToShortDateString()))
                {
                    validTimeslots.Add(ts);
                }

            }
            return validTimeslots;
        }
    }
}