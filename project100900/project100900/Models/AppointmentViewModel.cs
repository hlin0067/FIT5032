using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace project100900.Models
{
    public partial class Appointmentviewmodel : DbContext
    {
        public Appointmentviewmodel()
            : base("name=Appointmentviewmodel")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
