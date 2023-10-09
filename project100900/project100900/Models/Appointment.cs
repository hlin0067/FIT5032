namespace project100900.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointment
    {
        public int AppointmentID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(255)]
        public string DoctorId { get; set; }

        public DateTime Date { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
