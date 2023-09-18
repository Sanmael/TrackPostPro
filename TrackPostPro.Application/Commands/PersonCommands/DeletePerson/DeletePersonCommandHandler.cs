using DomainTrackPostPro.Interfaces;
using MediatR;
using DomainTrackPostPro.Entities;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.DTos;
using Aplication.Response;
using TrackPostPro.Application.Service;
using TrackPostPro.Application.CustomMessages;
using TrackPostPro.Application.ValidationErrorLogs;

namespace TrackPostPro.Application.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResult<Guid>>
    {
        private readonly IPersonService _personService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public DeletePersonCommandHandler(IPersonService personService, ITokenService tokenService, IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _personService = personService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<BaseResult<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDTO person = await _personService.GetPersonById(request.Id);

                if (person == null)
                    throw new ValidationException(ValidationMessages.PersonNotFound);

                _unitOfWork.BeginTransaction();

                await _tokenService.DeleteToken(person.Id);

                await _personService.DeletePerson(person);

                _unitOfWork.Commit();

                return new BaseResult<Guid>(request.Id, success: true);
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();

                await _loggerService.SaveLog(ex, ex.Message, ex.TargetSite!.DeclaringType!.DeclaringType!.Name);

                throw;
            }          
        }
    }
}
