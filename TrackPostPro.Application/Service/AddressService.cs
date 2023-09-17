using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using System.Transactions;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class AddressService : IAddresService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILoggerRepository _loggerRepository;

        public AddressService(IAddressRepository addressRepository, ILoggerRepository loggerRepository)
        {
            _addressRepository = addressRepository;
            _loggerRepository = loggerRepository;
        }

        public async Task CreateNewAddres(AddressDTO addressDTO)
        {
            try
            {
                Address address = new Address(addressDTO.PersonId, addressDTO.City, addressDTO.State, addressDTO.PostalCode, addressDTO.Neighborhood, addressDTO.PublicPlace, isPrincipalAddress: true);

                await _addressRepository.CreateNewAddress(address);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
