using Aplication.Response;
using MediatR;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands
{
    public class TrackingCodeInsertCommand : IRequest<BaseResult<Guid>>
    {
        public Guid PersonId { get; set; }
        public string Code { get; set; } = string.Empty;
    }
}
