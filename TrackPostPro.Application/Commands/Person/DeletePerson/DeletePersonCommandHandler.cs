using Aplication.Commands.CreatePerson;
using Aplication.Models;
using Entities.Interfaces;
using Entities;
using MediatR;

namespace TrackPostPro.Application.Commands.Person.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResult<Guid>>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResult<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            Entities.Person person = await _personRepository.GetPersonById(request.Id);

            if (person == null)
                return new BaseResult<Guid>(Guid.Empty, success:false, message: "Pessoa não encontrada")!;

            await _personRepository.DeletePerson(request.Id);

            return new BaseResult<Guid>(request.Id, message: "Pessoa deletada com sucesso");
        }
    }
}
