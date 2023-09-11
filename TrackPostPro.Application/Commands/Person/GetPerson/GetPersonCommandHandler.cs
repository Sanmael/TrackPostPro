using Aplication.Models;
using Context.Repositories;
using MediatR;
using TrackPostPro.Application.Models;
using Entities;
using Entities.Interfaces;

namespace TrackPostPro.Application.Commands.GetPerson
{
    public class GetPersonCommandHandler : IRequestHandler<GetPersonCommand, BaseResult<PersonViewModel>>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResult<PersonViewModel>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            Entities.Person personEntity = await _personRepository.GetPersonById(request.Id);

            if (personEntity == null)
                return new BaseResult<PersonViewModel>(null, success: false, message: "Pessoa não encontrada.");

            PersonViewModel person = new PersonViewModel().MapperEntityToModel(personEntity);

            return new BaseResult<PersonViewModel>(person);
        }
    }
}