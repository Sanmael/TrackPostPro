﻿using DomainTrackPostPro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Interfaces
{
    public interface IAddressRepository
    {
        public Task CreateNewAddress(Address address);
        public Task<Address> GetAddressByPersonId(Guid personId);
        public Task DeleteAddress(Guid personId);
    }
}
