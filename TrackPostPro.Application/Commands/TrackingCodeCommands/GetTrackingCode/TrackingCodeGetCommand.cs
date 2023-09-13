using Aplication.Response;
using MediatR;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode
{
    public class TrackingCodeGetCommand : IRequest<BaseResult<TrackingCodeDTO>>
    {
        public string Code { get; set; }
    }
}
