using System.Text.Json.Serialization;

namespace TrackPostPro.Application.DTos
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        [JsonPropertyName("localidade")]
        public string City { get; set; } = "";
        [JsonPropertyName("uf")]
        public string State { get; set; } = "";
        [JsonPropertyName("cep")]
        public string PostalCode { get; set; } = "";
        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; } = "";
        [JsonPropertyName("logradouro")]
        public string PublicPlace { get; set; } = "";
        public AddressDTO()
        {

        }
        public AddressDTO(string postalCode)
        {
            PostalCode = postalCode;
        }
        public AddressDTO(Guid id, Guid personId, string city, string state, string postalCode, string neighborhood, string publicPlace)
        {
            Id = id;
            PersonId = personId;
            City = city;
            State = state;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            PublicPlace = publicPlace;
        }
        public AddressDTO(Guid personId, string city, string state, string postalCode, string neighborhood, string publicPlace)
        {                  
            PersonId = personId;
            City = city;
            State = state;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            PublicPlace = publicPlace;
        }
    }
}