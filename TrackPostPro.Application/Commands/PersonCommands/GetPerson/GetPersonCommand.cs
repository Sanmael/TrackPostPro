using Aplication.Models;
using DomainTrackPostPro;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.PersonCommands.GetPerson
{
    public class GetPersonCommand : IRequest<BaseResult<PersonViewModel>>
    {
        public Guid Id { get; set; }                
    }
}
