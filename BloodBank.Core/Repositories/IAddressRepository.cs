namespace BloodBank.Core.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll();
        Task<Address> GetById(int id);
        Task Create(Address address);
        Task Update(Address address);
    }
}