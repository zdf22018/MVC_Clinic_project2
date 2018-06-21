namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int TimeSlotId { get; set; }

        public virtual patient patient { get; set; }

        public virtual timeslot timeslot { get; set; }
    }
}
