using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(int id);
        Task Create(Donation donation);
        Task Update(Donation donation);
    }
}