using DomainTrackPostPro.Entities;

namespace TrackPostPro.Application.DTos
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonDTO(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
        public PersonDTO()
        {
            
        }
       
        public Person MapperToEntity() => new Person().CreateNewPerson(Name, Age);

        public PersonDTO EntityToDto(Person person)
        {
            Id = person.Id;
            Name = person.Name!;
            Age = person.Age;

            return this;
        }
    }
}
