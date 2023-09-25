using Aplication.Response;
using DomainTrackPostPro.Entities;
using DomainTrackPostPro.Interfaces;
using MediatR;

namespace TrackPostPro.Application.Commands.TrackingCodeCommands
{
    public class TrackingCodeInsertCommandHandler : IRequestHandler<TrackingCodeInsertCommand, BaseResult<Guid>>
    {
       
        public async Task<BaseResult<Guid>> Handle(TrackingCodeInsertCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TrackingCode trackingCode = new TrackingCode().CreateTrackingCode(request.PersonId, request.Code);

                return new BaseResult<Guid>(trackingCode.Id, "teste", success : true);
            }
            catch
            {
                throw;
            }
        }
    }
}
