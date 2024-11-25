namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(int id);
        Task<int> Create(Donation donation);
        Task Update(Donation donation);
        Task AddStock(BloodStock donation);
    }
}