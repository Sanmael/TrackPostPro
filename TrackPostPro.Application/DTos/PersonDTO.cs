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
        public PersonDTO(string name, DateTime birthDate, string postalCode)
        {
            Name = name;
            BirthDate = birthDate;
            Address = new AddressDTO(postalCode);
        }
        public PersonDTO()
        {
            
        }
       
        public Person MapperPersonEntity() => new Person(Name, BirthDate);

        public PersonDTO(Guid personId, string name, DateTime birthDate)
        {
            Id = personId;
            Name = name;
            BirthDate = birthDate;
        }
    }
}