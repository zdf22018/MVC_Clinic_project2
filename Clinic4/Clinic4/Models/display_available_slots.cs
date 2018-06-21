namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class display_available_slots
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSoltId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(101)]
        public string Doctor { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
