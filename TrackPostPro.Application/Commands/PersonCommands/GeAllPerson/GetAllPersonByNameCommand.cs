using Aplication.Response;
using MediatR;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Commands.PersonCommands.GetAllPerson
{
    public class GetAllPersonByNameCommand : IRequest<BaseResult<List<PersonDTO>>>
    {
        public string Name { get; set; }
    }
}
