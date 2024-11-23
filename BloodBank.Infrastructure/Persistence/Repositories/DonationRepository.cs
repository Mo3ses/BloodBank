using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _context;
        public DonationRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task Create(Donation donation)
        {
            await _context.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetAll()
        {
            var results = await _context.Donations
                .Where(d => !d.IsDeleted)
                .ToListAsync();
            return results;
        }

        public async Task<Donation> GetById(int id)
        {
            var result = await _context.Donations
                .Where(d => !d.IsDeleted)
                .Include(d => d.Donor)
                .SingleOrDefaultAsync(d => d.Id == id);
            return result;
        }

        public async Task Update(Donation donation)
        {
            _context.Update(donation);
            await _context.SaveChangesAsync();
        }
    }
}