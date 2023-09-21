using DomainTrackPostPro.Entities;
using System.Text.Json.Serialization;

namespace TrackPostPro.Application.DTos
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDTO Address { get; set; }
        public PersonDTO(string name, DateTime birthDate,string city, string state, string postalCode, string neighborhood, string publicPlace)
        {
            Name = name;
            BirthDate = birthDate;
            Address = new AddressDTO(Id, city, state, postalCode, neighborhood, publicPlace);
        }
        public PersonDTO()
        {
            
        }
       
        public Person MapperPersonEntity() => new Person(Id,Name, BirthDate);

        public PersonDTO(Guid personId, string name, DateTime birthDate)
        {
            Id = personId;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
