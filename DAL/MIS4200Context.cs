using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CarrMIS4200.Models;

namespace CarrMIS4200.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            // add the SetInitializer statement here
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, CarrMIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
        public DbSet<customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }

        // add this method - it will be used later
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        //public System.Data.Entity.DbSet<CarrMIS4200.Models.Patient> Patients { get; set; }

        //public System.Data.Entity.DbSet<CarrMIS4200.Models.Doctor> Doctors { get; set; }

        //public System.Data.Entity.DbSet<CarrMIS4200.Models.DoctorAppointment> DoctorAppointments { get; set; }
    }
    // add this method - it will be used later

}