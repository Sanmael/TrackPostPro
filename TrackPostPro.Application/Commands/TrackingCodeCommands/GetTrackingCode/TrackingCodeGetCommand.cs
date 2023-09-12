using Aplication.Models;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode
{
    public class TrackingCodeGetCommand : IRequest<BaseResult<TrackingCodeViewModel>>
    {
        public string Code { get; set; }
    }
}
