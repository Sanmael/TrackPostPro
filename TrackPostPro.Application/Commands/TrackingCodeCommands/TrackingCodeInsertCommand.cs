using Aplication.Models;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands
{
    public class TrackingCodeInsertCommand : IRequest<BaseResult<Guid>>
    {
        public Guid PersonId { get; set; }
        public string Code { get; set; }
    }
}
