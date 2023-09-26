using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Transactions;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.ValidationErrorLogs;

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
            Address address = new Address(addressDTO.PersonId, addressDTO.City, addressDTO.State, addressDTO.PostalCode, addressDTO.Neighborhood, addressDTO.PublicPlace, isPrincipalAddress: true);

            await _addressRepository.CreateNewAddress(address);

            addressDTO.Id = address.Id;
        }

        public async Task DeleteAddress(Guid personId)
        {
            await _addressRepository.DeleteAddress(personId);
        }

        public async Task<AddressDTO?> GetAddressByPersonId(Guid personId)
        {
            Address? address = await _addressRepository.GetAddressByPersonId(personId);

            if (address == null)
                return null;

            return new AddressDTO(address.Id, address.PersonId, address.City, address.State, address.PostalCode, address.Neighborhood, address.PublicPlace);
        }
     
    }
}
