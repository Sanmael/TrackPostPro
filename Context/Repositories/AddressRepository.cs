using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;

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
    }
}
