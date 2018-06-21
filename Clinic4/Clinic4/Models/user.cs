namespace Clinic4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginPassWord { get; set; }

        [Required]
        [StringLength(10)]
        public string UserRole { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public virtual doctor doctor { get; set; }

        public virtual patient patient { get; set; }
    }
}
