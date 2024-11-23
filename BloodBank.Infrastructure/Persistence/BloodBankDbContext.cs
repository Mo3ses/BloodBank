using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>(e =>
            {
                e.HasKey(address => address.Id);
                e.HasOne(address => address.Donor)
                    .WithOne(donor => donor.Address)
                    .HasForeignKey<Address>(donor => donor.DonorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<BloodStock>(e =>
            {
                e.HasKey(bloodStock => bloodStock.Id);
            });

            builder.Entity<Donation>(e =>
            {
                e.HasKey(donation => donation.Id);
                e.HasOne(donation => donation.Donor)
                    .WithMany(donor => donor.Donations)
                    .HasForeignKey(donation => donation.DonorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Donor>(e =>
            {
                e.HasKey(donor => donor.Id);
            });
        }
    }
}