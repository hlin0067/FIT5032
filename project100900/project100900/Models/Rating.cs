namespace project100900.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        public int RatingId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string UserId { get; set; }

        public decimal Score { get; set; }
    }
}
