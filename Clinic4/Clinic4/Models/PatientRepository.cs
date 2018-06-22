using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class PatientRepository
    {
        ModelClinic context = new ModelClinic();

        public patient GetPatientByID(int id)
        {
            return (from p in context.patients where p.Id == id select p).SingleOrDefault();
        }

        public List<PatientAppointment> GetPatientAppointmentsById(int id)
        {

            var apt = (from a in context.appointments
                                   join pa in context.patients on a.PatientId equals pa.Id
                                   join ts in context.timeslots on a.TimeSlotId equals ts.Id
                                   join dc in context.doctors on ts.SlotDoctorId equals dc.Id
                                   where a.PatientId == id
                                   select new PatientAppointment
                                   {                                       
                                       PatientName = pa.FullName,
                                       DoctorName = dc.FullName,
                                       AppointmentDate = ts.SlotStart
                                   }).ToList();

            return apt.ToList<PatientAppointment>();

        }
    }
}