namespace Clinic4.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelClinic : DbContext
    {
        public ModelClinic()
            : base("name=ModelClinic")
        {
        }

        public virtual DbSet<appointment> appointments { get; set; }
        public virtual DbSet<availability> availabilities { get; set; }
        public virtual DbSet<doctor> doctors { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<timeslot> timeslots { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<display_appointements_for_Patient> display_appointements_for_Patient { get; set; }
        public virtual DbSet<display_available_slots> display_available_slots { get; set; }
        public virtual DbSet<doctor_schedule> doctor_schedule { get; set; }
        public virtual DbSet<take_Appointment> take_Appointment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<availability>()
                .HasMany(e => e.timeslots)
                .WithRequired(e => e.availability)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.Speciality)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.LoginPassWord)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.availabilities)
                .WithRequired(e => e.doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.MedicalCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.LoginPassWord)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<timeslot>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.timeslot)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.LoginPassWord)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.UserRole)
                .IsUnicode(false);

            modelBuilder.Entity<display_appointements_for_Patient>()
                .Property(e => e.Doctor)
                .IsUnicode(false);

            modelBuilder.Entity<display_available_slots>()
                .Property(e => e.Doctor)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_schedule>()
                .Property(e => e.Doctor)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_schedule>()
                .Property(e => e.Patient)
                .IsUnicode(false);

            modelBuilder.Entity<take_Appointment>()
                .Property(e => e.Doctor)
                .IsUnicode(false);
        }
    }
}
