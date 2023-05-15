using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //Entities
        public DbSet<CleaningEvent> CleaningEvents { get; set; }
        public DbSet<CleaningEventAttendee> CleaningEventAttendees { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CleaningEventAttendee>(x =>x.HasKey(aa => new {aa.AppUserId, aa.CleaningEventId}));

            builder.Entity<CleaningEventAttendee>()
               .HasOne(u => u.AppUser)
               .WithMany(a => a.CleaningEvents)
               .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<CleaningEventAttendee>()
               .HasOne(u => u.CleaningEvent)
               .WithMany(a => a.Attendees)
               .HasForeignKey(aa => aa.CleaningEventId);

            builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole{Name="Member", NormalizedName = "MEMBER"},
                new IdentityRole{Name="Admin", NormalizedName = "ADMIN"}
            );
        }

    }

}