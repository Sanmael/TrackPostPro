using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.DTos;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode
{
    public class TrackingCodeGetCommandHandler : IRequestHandler<TrackingCodeGetCommand, BaseResult<TrackingCodeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackingCodeGetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult<TrackingCodeDTO>> Handle(TrackingCodeGetCommand request, CancellationToken cancellationToken)
        {
            //TrackingCode trackingCode = await _unitOfWork.TrackingCodeRepository.GetTrackingCodeByCode(request.Code);

            //if (trackingCode == null)
                return new BaseResult<TrackingCodeDTO>(null, success: false, message: "Codigo de Rastreio não encontrado.");

            //TrackingCodeDTO TrackingCodeDTO = new TrackingCodeDTO().EntityToDto(trackingCode);

            //return new BaseResult<TrackingCodeDTO>(TrackingCodeDTO, success: true);
        }
    }
}
