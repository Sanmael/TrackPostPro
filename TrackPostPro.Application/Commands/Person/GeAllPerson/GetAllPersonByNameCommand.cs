using Aplication.Models;
using Entities;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.GetAllPerson
{
    public class GetAllPersonByNameCommand : IRequest<BaseResult<ListPersonViewModel>>
    {
        public string Name { get; set; }
    }
}
