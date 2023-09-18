using DomainTrackPostPro.Entities;
using System.Text.Json.Serialization;

namespace TrackPostPro.Application.DTos
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [JsonIgnore] 
        public TokenDTO Token { get; set; }
        public AddressDTO Address { get; set; }
        public PersonDTO(string name, int age,string pass, string city, string state, string postalCode, string neighborhood, string publicPlace)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Token = new TokenDTO(Id, pass);
            Address = new AddressDTO(Id, city, state, postalCode, neighborhood, publicPlace);
        }
        public PersonDTO()
        {
            
        }
       
        public Person MapperToEntity() => new Person(Id,Name, Age);

        public PersonDTO EntityToDto(Person person)
        {
            Id = person.Id;
            Name = person.Name!;
            Age = person.Age;

            return this;
        }
    }
}
