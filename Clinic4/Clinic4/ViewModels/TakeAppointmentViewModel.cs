using Clinic4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic4.ViewModels
{
    public class TakeAppointmentViewModel
    {
        [Required]
        public int SelectedDoctorId { get; set; }

        public int PatientId { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public List<doctor> Doctors { get; set; }

        public List<timeslot> Timeslots { get; set; }
    }
}