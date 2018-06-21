namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("availability")]
    public partial class availability
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public availability()
        {
            timeslots = new HashSet<timeslot>();
        }

        public int Id { get; set; }

        public int DoctorId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }

        public int? AppointmentDuration { get; set; }

        public virtual doctor doctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timeslot> timeslots { get; set; }
    }
}
