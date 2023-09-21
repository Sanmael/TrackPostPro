using DomainTrackPostPro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTrackPostPro.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);
    }
}
