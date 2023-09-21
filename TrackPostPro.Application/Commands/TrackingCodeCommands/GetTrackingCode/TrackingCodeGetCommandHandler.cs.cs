using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode
{
    public class TrackingCodeGetCommandHandler : IRequestHandler<TrackingCodeGetCommand, BaseResult<TrackingCodeDTO>>
    {
        public async Task<BaseResult<TrackingCodeDTO>> Handle(TrackingCodeGetCommand request, CancellationToken cancellationToken)
        {
           
                return new BaseResult<TrackingCodeDTO>(null, success: false, message: "Codigo de Rastreio não encontrado.");


        }
    }
}
