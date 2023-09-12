using Aplication.Models;
using MediatR;

namespace TrackPostPro.Application.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommand : IRequest<BaseResult<Guid>>
    {
        public Guid Id { get; set; }
    }
}
