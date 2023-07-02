using Domain;
using Domain.Complaints;
using Domain.Complaints.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        //Entities
        public DbSet<CleaningEvent> CleaningEvents { get; set; }
        public DbSet<CleaningEventAttendee> CleaningEventAttendees { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ComplaintLocation> ComplaintLocations { get; set; }
        public DbSet<ComplainantLocation> ComplainantLocations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<TranslatedComplaint> TranslatedComplaints { get; set; }
        public DbSet<AddressTranslation> AddressTranslations { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<ComplaintLocation>()
                .HasOne(cl => cl.Address)
                .WithOne(a => a.ComplaintLocation)
                .HasForeignKey<ComplaintLocation>(cl => cl.AddressId);

            builder
                .Entity<ComplainantLocation>()
                .HasOne(cl => cl.Address)
                .WithOne(a => a.ComplainantLocation)
                .HasForeignKey<ComplainantLocation>(cl => cl.AddressId);

            builder
                .Entity<Complaint>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Complaints)
                .HasForeignKey(c => c.AddressId);

            builder
                .Entity<State>()
                .HasMany<Address>(s => s.Addresses)
                .WithOne(a => a.State)
                .HasForeignKey(a => a.StateId);

            builder
                .Entity<City>()
                .HasMany<Address>(s => s.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);

            builder
                .Entity<State>()
                .HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StateId);

            builder
                .Entity<Complaint>()
                .HasOne(e => e.Feedback)
                .WithOne(e => e.Complaint)
                .HasForeignKey<Complaint>(f => f.Id)
                .IsRequired(false);

            builder
                .Entity<Complaint>()
                .HasMany(c => c.TranslatedComplaints)
                .WithOne(tc => tc.Complaint)
                .HasForeignKey(tc => tc.ComplaintId);

            builder
                .Entity<TranslatedComplaint>()
                .HasOne(tc => tc.AddressTranslation)
                .WithOne(at => at.TranslatedComplaint)
                .HasForeignKey<AddressTranslation>(at => at.TranslatedComplaintId);

            builder.Entity<CleaningEventAttendee>(
                x => x.HasKey(aa => new { aa.AppUserId, aa.CleaningEventId })
            );

            builder
                .Entity<CleaningEventAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.CleaningEvents)
                .HasForeignKey(aa => aa.AppUserId);

            builder
                .Entity<CleaningEventAttendee>()
                .HasOne(u => u.CleaningEvent)
                .WithMany(a => a.Attendees)
                .HasForeignKey(aa => aa.CleaningEventId);

            builder
                .Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
