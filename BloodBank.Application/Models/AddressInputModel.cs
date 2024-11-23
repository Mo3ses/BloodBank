
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Application.Models
{
    public class AddressInputModel
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string PostalCode { get; private set; }
        public int DonorId { get; private set; }

        public Address ToEntity() => new(street: Street, city: City, state: State, postalCode: PostalCode, donorId: DonorId);
    }
}