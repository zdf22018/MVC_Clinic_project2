using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class TimeslotDetails
    {
        public int TimeslotId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
    }
}