using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace project100900.Models
{
    public partial class RatingVewModel : DbContext
    {
        public RatingVewModel()
            : base("name=RatingVewModel")
        {
        }

        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .Property(e => e.Score)
                .HasPrecision(2, 1);
        }
    }
}
