using Aplication.Models;
using MediatR;
using TrackPostPro.Application.Models;
using DomainTrackPostPro.Interfaces;
using DomainTrackPostPro.Entities;

namespace TrackPostPro.Application.Commands.PersonCommands.GetPerson
{
    public class GetPersonCommandHandler : IRequestHandler<GetPersonCommand, BaseResult<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult<PersonViewModel>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            Person personEntity = await _unitOfWork.PersonRepository.GetPersonById(request.Id);

            if (personEntity == null)
                return new BaseResult<PersonViewModel>(null, success: false, message: "Pessoa não encontrada.");

            PersonViewModel person = new PersonViewModel().MapperEntityToModel(personEntity);

            return new BaseResult<PersonViewModel>(person);
        }
    }
}