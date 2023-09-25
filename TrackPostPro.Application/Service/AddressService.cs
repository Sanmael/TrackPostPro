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
        private readonly IConfiguration _configuration;
        public AddressService(IAddressRepository addressRepository, IConfiguration configuration)
        {
            _addressRepository = addressRepository;
            _configuration = configuration;
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
        public async Task<AddressDTO?> GetAddress(string postalCode)
        {
            postalCode = postalCode.Replace("-", "");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("CepUrl"));

                string relativeUrl = $"ws/{postalCode}/json/";

                var response = await httpClient.GetStringAsync(relativeUrl);

                if (response.Contains("erro"))
                    return null;

                var address = JsonSerializer.Deserialize<AddressDTO>(response);

                return address!;
            }

        }
    }
}
