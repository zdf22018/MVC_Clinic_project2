namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class timeslot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public timeslot()
        {
            appointments = new HashSet<appointment>();
        }

        public int Id { get; set; }

        public int AvailabilityId { get; set; }

        public DateTime? SlotStart { get; set; }

        public DateTime? SlotEnd { get; set; }

        public int? SlotDoctorId { get; set; }

        public bool? IsAvailable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointment> appointments { get; set; }

        public virtual availability availability { get; set; }
    }
}
