using Aplication.Response;
using DomainTrackPostPro.Entities;
using MediatR;

namespace Aplication.Commands.PersonCommands.CreatePerson
{
    public class CreatePersonCommand : IRequest<BaseResult>
    {
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Neighborhood { get; set; } = "";
        public string PublicPlace { get; set; } = "";
    }
}
