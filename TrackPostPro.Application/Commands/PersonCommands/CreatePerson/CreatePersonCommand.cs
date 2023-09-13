using Aplication.Response;
using DomainTrackPostPro.Entities;
using MediatR;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommand : IRequest<BaseResult<Guid>>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
}
