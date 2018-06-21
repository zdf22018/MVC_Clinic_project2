namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class doctor_schedule
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int appointmentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int patientId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int slotId { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int? DoctorId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(101)]
        public string Doctor { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(101)]
        public string Patient { get; set; }

        [Column("Is Available")]
        public bool? Is_Available { get; set; }
    }
}
