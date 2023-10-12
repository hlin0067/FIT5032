using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace project100900.Models
{
    public partial class ImageViewModel : DbContext
    {
        public ImageViewModel()
            : base("name=ImageViewModel")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
