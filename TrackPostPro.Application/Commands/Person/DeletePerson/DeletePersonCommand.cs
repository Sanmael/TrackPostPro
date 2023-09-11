using Aplication.Models;
using MediatR;

namespace TrackPostPro.Application.Commands.Person.DeletePerson
{
    public class DeletePersonCommand : IRequest<BaseResult<Guid>>
    {
        public Guid Id { get; set; }
    }
}
