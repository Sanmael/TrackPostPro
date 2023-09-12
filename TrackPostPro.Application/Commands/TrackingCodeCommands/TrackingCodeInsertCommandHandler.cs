using Aplication.Models;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands
{
    public class TrackingCodeInsertCommandHandler : IRequestHandler<TrackingCodeInsertCommand, BaseResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackingCodeInsertCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(TrackingCodeInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TrackingCode trackingCode = new TrackingCode().CreateTrackingCode(request.PersonId, request.Code);

                _unitOfWork.BeginTransaction();

                await _unitOfWork.TrackingCodeRepository.CreateTrackingCode(trackingCode);

                _unitOfWork.Commit();

                return new BaseResult<Guid>(trackingCode.Id, success : true, "teste");
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
