using Aplication.Response;
using DomainTrackPostPro.Entities;
using MediatR;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommand : IRequest<BaseResult<Guid>>
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Password { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Neighborhood { get; set; } = "";
        public string PublicPlace { get; set; } = "";
    }
}
