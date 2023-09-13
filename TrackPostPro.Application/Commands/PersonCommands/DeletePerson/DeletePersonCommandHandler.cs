using DomainTrackPostPro.Interfaces;
using MediatR;
using DomainTrackPostPro.Entities;
using TrackPostPro.Application.Interfaces;
using TrackPostPro.Application.DTos;
using Aplication.Response;

namespace TrackPostPro.Application.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResult<Guid>>
    {
        private readonly IPersonService _personService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IPersonService personService, ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _personService = personService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDTO person = await _personService.GetPersonById(request.Id);

                if (person == null)
                    return new BaseResult<Guid>(Guid.Empty, success: false, message: "Pessoa não encontrada")!;

                _unitOfWork.BeginTransaction();

                await _tokenService.DeleteToken(person.Id);

                await _personService.DeletePerson(person);

                _unitOfWork.Commit();

                return new BaseResult<Guid>(request.Id, success: true);
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }          
        }
    }
}
