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
        public PersonDTO(string name, DateTime birthDate, AddressDTO addressDTO)
        {
            Name = name;
            BirthDate = birthDate;
            Address = addressDTO;
        }
        public PersonDTO(Guid id, string name, DateTime birthDate, AddressDTO addressDTO)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Address = addressDTO;
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