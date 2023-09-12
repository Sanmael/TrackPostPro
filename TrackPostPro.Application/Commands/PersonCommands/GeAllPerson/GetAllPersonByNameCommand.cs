using Aplication.Models;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.PersonCommands.GetAllPerson
{
    public class GetAllPersonByNameCommand : IRequest<BaseResult<ListPersonViewModel>>
    {
        public string Name { get; set; }
    }
}
