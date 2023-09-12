using DomainTrackPostPro.Entities;

namespace TrackPostPro.Application.Models
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public PersonViewModel MapperEntityToModel(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Age = person.Age;

            return this;
        }
    }
}
