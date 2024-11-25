using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAll();
        Task<Donor> GetById(int id);
        Task<int> Create(Donor donor);
        Task Update(Donor donor);
    }
}