using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class DoctorRepository
    {
        ModelClinic context = new ModelClinic();

        //get all the patient records
        public List<patient> GetAllPatients()
        {
            return (from p in context.patients select p).ToList();
        }

        // get a single doctor
        public doctor GetDoctorById(int Id)
        {
            var doctor = (from d in context.doctors where d.Id == Id select d).SingleOrDefault();
            return doctor;
        }

        // display doctors' schedules
        public List<doctor_schedule> GetDoctorSchedule(int id)
        {
            var doctorS = (from s in context.doctor_schedule where s.DoctorId == id select s).ToList();
            return doctorS;
        }

        //display availability
        public List<availability> GetAvailabilities(int id)
        {
            var doctorA = (from a in context.availabilities where a.DoctorId == id && a.AvailableTo > DateTime.Now select a).ToList();
            return doctorA;
        }
        // Add Availability
        //public void AddAvailability(availability a)
        //{
        //    // this function need validation to check the one being added is not overlaping with existing ones.
        //    //code???
        //    //check the sTime if is overlapping with existing availabilities
        //    bool CanAddAvailability = true;
        //    var list = (from av in context.availabilities where av.DoctorId == a.DoctorId select av).ToList();
        //    foreach (availability x in list)
        //    {
        //        if (a.AvailableFrom >= x.AvailableFrom && a.AvailableFrom <= x.AvailableTo) { CanAddAvailability = false; }

        //    }
        //    if (CanAddAvailability)
        //    {
        //        context.availabilities.Add(a);
        //        context.SaveChanges();

        //    }
            



        }


    }
