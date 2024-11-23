using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IAddressRepository
    {
        Task Create(Address address);
        Task Update(Address address);
    }
}