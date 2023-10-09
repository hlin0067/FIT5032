using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace project100900.Models
{
    public partial class AppointmentViewModel : DbContext
    {
        public AppointmentViewModel()
            : base("name=AppointmentViewModel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
