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
                e.HasOne(d => d.Address)
                    .WithOne()
                    .HasForeignKey<Address>(address => address.DonorId)
                    .OnDelete(DeleteBehavior.Restrict); ;
            });
        }
    }
}