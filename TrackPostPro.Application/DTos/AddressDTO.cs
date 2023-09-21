namespace TrackPostPro.Application.DTos
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Neighborhood { get; set; } = "";
        public string PublicPlace { get; set; } = "";
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
