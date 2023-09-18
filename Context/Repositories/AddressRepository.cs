using Dapper;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System.Net;

namespace Context.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IContext _context;
        private readonly IGenericRepository _genericRepository;

        public AddressRepository(IContext context, IGenericRepository genericRepository)
        {
            _context = context;
            _genericRepository = genericRepository;
        }

        public async Task CreateNewAddress(Address address)
        {
            try
            {
                await _genericRepository.Insert(address);
            }
            catch
            {
                throw;
            }            
        }

        public async Task<Address> GetAddressByPersonId(Guid personId)
        {            
            try
            {
                string sql = "SELECT * FROM Address WHERE PersonId = @Id";

                return await _context.DbConnection.QueryFirstOrDefaultAsync<Address>(sql: sql, new { Id = personId });
            }
            catch
            {
                throw;
            }
        }
    }
}
