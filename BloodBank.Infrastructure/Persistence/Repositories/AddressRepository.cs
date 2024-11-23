using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Core.Repositories;

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

        public async Task Update(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
        }
    }
}