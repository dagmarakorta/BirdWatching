using BirdWatching.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdWatching.Data
{
    public class BirdWatchingDbContext : DbContext
    {

        public BirdWatchingDbContext(DbContextOptions<BirdWatchingDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<ControlCenter> ControlCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sighting>()
                .HasOne(s => s.User).WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sighting>()
                .HasOne(s => s.Bird).WithMany()
                .HasForeignKey(s => s.BirdId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sighting>()
                .HasOne(s => s.ControlCenter)
                .WithMany()
                .HasForeignKey(s => s.ControlCenterId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
