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
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
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

        public async Task<AddressDTO?> GetAddressByPersonId(Guid personId)
        {
            try
            {
                Address? address = await _addressRepository.GetAddressByPersonId(personId);

                if (address == null)
                    return null;

                return new AddressDTO().EntityToDto(address.Id,address.PersonId, address.City, address.State, address.PostalCode, address.Neighborhood, address.PublicPlace);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
