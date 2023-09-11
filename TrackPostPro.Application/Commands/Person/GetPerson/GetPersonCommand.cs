using Aplication.Models;
using Entities;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.GetPerson
{
    public class GetPersonCommand : IRequest<BaseResult<PersonViewModel>>
    {
        public Guid Id { get; set; }                
    }
}
