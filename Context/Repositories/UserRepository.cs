using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System;

namespace Context.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public UserRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public async Task CreateUser(User user)
        {
            try
            {
                await _genericRepository.Insert(user);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
