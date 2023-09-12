using Aplication.Models;
using DomainTrackPostPro.Interfaces;
using MediatR;
using DomainTrackPostPro.Entities;

namespace TrackPostPro.Application.Commands.PersonCommands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = await _unitOfWork.PersonRepository.GetPersonById(request.Id);

            if (person == null)
                return new BaseResult<Guid>(Guid.Empty, success:false, message: "Pessoa não encontrada")!;

            await _unitOfWork.PersonRepository.DeletePerson(request.Id);

            return new BaseResult<Guid>(request.Id, message: "Pessoa deletada com sucesso");
        }
    }
}
