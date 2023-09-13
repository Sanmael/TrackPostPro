using Aplication.Response;
using DomainTrackPostPro;
using MediatR;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Commands.PersonCommands.GetPerson
{
    public class GetPersonCommand : IRequest<BaseResult<PersonDTO>>
    {
        public Guid Id { get; set; }                
    }
}
