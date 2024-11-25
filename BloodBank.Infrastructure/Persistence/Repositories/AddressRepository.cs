using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BloodBankDbContext _context;
        public AddressRepository(BloodBankDbContext context)
        {
            _context = context;
        }
        public async Task Create(Address address)
        {
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAll()
        {
            var results = await _context.Addresses
                .Where(a => !a.IsDeleted)
                .ToListAsync();
            return results;
        }

        public async Task<Address> GetById(int id)
        {
            var result = await _context.Addresses
                .Where(a => !a.IsDeleted)
                .SingleOrDefaultAsync(a => a.Id == id);
            return result;
        }
        public async Task Update(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
        }
    }
}