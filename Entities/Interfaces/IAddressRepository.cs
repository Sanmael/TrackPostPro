using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public  interface IAddressRepository 
    {
        public void CreateAddress(Address address);
        public Address GetAddressByPostalCode(string postalCode);
        public List<Address> GetAddressesByPersonId(Guid id);
    }
}
