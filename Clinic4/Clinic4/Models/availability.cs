namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("availability")]
    [TimeOverLapping]
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date (M-D-Y)")]
        public DateTime Date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:hh:mm tt}")]
        [Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [Display(Name = "Available To")]
        public DateTime AvailableTo { get; set; }

        [Display(Name = "Appointment Duration")]
        public int? AppointmentDuration { get; set; }

        public virtual doctor doctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timeslot> timeslots { get; set; }
    }
}
