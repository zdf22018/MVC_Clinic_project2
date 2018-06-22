using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class PatientAppointment
    {
        // from appointments -> patientId -> patients
        public string PatientName { get; set; } // FullName (if that works, its an auto generated column)


        // from availability
        public DateTime? AppointmentDate { get; set; } // AvailableFrom
        //public int AppointmentDuration { get; set; } // AppointmentDuration

        // from availability -> doctorId -> doctors
        public string DoctorName { get; set; } // FullName(if that works, its an auto generated column)
    }
}