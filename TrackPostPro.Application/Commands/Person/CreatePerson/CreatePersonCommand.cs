using Aplication.Models;
using Entities;
using MediatR;

namespace Aplication.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<BaseResult<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public Person MapperToEntity() => new Person().CreateNewPerson(Name, Age);
    }
}
