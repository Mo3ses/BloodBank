using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _context;
        public DonorRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task Create(Donor donor)
        {
            await _context.AddAsync(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAll()
        {
            var results = await _context.Donors
                .Where(d => !d.IsDeleted)
                .Include(d => d.Addresses.Where(a => !a.IsDeleted))
                .ToListAsync();
            return results;
        }

        public async Task<Donor> GetById(int id)
        {
            var result = await _context.Donors
                .Where(d => !d.IsDeleted)
                .Include(d => d.Addresses.Where(a => !a.IsDeleted))
                .Include(d => d.Donations.Where(dn => !dn.IsDeleted))
                .SingleOrDefaultAsync(d => d.Id == id);
            return result;
        }

        public async Task Update(Donor donor)
        {
            _context.Update(donor);
            await _context.SaveChangesAsync();
        }
    }
}