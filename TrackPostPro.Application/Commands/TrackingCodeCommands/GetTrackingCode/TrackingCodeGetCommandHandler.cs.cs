using Aplication.Models;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;
using TrackPostPro.Application.Models;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands.GetTrackingCode
{
    public class TrackingCodeGetCommandHandler : IRequestHandler<TrackingCodeGetCommand, BaseResult<TrackingCodeViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackingCodeGetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult<TrackingCodeViewModel>> Handle(TrackingCodeGetCommand request, CancellationToken cancellationToken)
        {
            TrackingCode trackingCode = await _unitOfWork.TrackingCodeRepository.GetTrackingCodeByCode(request.Code);

            if (trackingCode == null)
                return new BaseResult<TrackingCodeViewModel>(null, success: false, message: "Codigo de Rastreio não encontrado.");

            TrackingCodeViewModel trackingCodeViewModel = new TrackingCodeViewModel().EntityToDto(trackingCode);

            return new BaseResult<TrackingCodeViewModel>(trackingCodeViewModel, success: true);
        }
    }
}
